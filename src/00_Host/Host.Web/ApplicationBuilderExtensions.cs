﻿using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Mkh.Utils.App;

namespace Mkh.Host.Web;

internal static class ApplicationBuilderExtensions
{
    /// <summary>
    /// 配置路基跟地址
    /// </summary>
    /// <param name="app"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static IApplicationBuilder UsePathBase(this IApplicationBuilder app, Options.HostOptions options)
    {
        var pathBase = options!.Base;
        if (pathBase.NotNull())
        {
            //1、配置请求基础地址：
            app.Use((context, next) =>
            {
                context.Request.PathBase = pathBase;
                return next();
            });

            // 2、配置静态文件基地址：
            app.UsePathBase(pathBase);
        }

        return app;
    }

    /// <summary>
    /// 启用默认页
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseDefaultPage(this IApplicationBuilder app)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/app");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        //设置默认文档
        var defaultFilesOptions = new DefaultFilesOptions();
        defaultFilesOptions.DefaultFileNames.Clear();
        defaultFilesOptions.DefaultFileNames.Add("index.html");
        app.UseDefaultFiles(defaultFilesOptions);

        var options = new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(path),
            RequestPath = new PathString("/app")
        };

        app.UseStaticFiles(options);

        var appPath = "app";
        var rewriteOptions = new RewriteOptions().AddRedirect("^$", appPath);

        app.UseRewriter(rewriteOptions);

        return app;
    }

    /// <summary>
    /// 启用应用停止处理
    /// </summary>
    /// <returns></returns>
    public static IApplicationBuilder UseShutdownHandler(this IApplicationBuilder app)
    {
        var applicationLifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();
        applicationLifetime.ApplicationStopping.Register(() =>
        {
            var handlers = app.ApplicationServices.GetServices<IAppShutdownHandler>().ToList();
            foreach (var handler in handlers)
            {
                handler.Handle();
            }
        });

        return app;
    }

    /// <summary>
    /// 启用Banner图
    /// </summary>
    /// <param name="app"></param>
    /// <param name="appLifetime"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseBanner(this IApplicationBuilder app, IHostApplicationLifetime appLifetime)
    {
        appLifetime.ApplicationStarted.Register(() =>
        {
            //显示启动Banner
            var customFile = Path.Combine(AppContext.BaseDirectory, "banner.txt");
            if (File.Exists(customFile))
            {
                try
                {
                    var lines = File.ReadAllLines(customFile);
                    foreach (var line in lines)
                    {
                        Console.WriteLine(line);
                    }
                }
                catch
                {
                    Console.WriteLine("banner.txt文件无效");
                }
            }
            else
            {
                ConsoleBanner();
            }
        });

        return app;
    }

    /// <summary>
    /// 启动后打印Banner图案
    /// </summary>
    private static void ConsoleBanner()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        Console.WriteLine(@" ***************************************************************************************************************");
        Console.WriteLine(@" *                                                                                                             *");
        Console.WriteLine(@" *                               $$\   $$$$$$$$\ $$\      $$\ $$\   $$\ $$\   $$\                              *");
        Console.WriteLine(@" *                             $$$$ |  \____$$  |$$$\    $$$ |$$ | $$  |$$ |  $$ |                             *");
        Console.WriteLine(@" *                             \_$$ |      $$  / $$$$\  $$$$ |$$ |$$  / $$ |  $$ |                             *");
        Console.WriteLine(@" *                               $$ |     $$  /  $$\$$\$$ $$ |$$$$$  /  $$$$$$$$ |                             *");
        Console.WriteLine(@" *                               $$ |    $$  /   $$ \$$$  $$ |$$  $$<   $$  __$$ |                             *");
        Console.WriteLine(@" *                               $$ |   $$  /    $$ |\$  /$$ |$$ |\$$\  $$ |  $$ |                             *");
        Console.WriteLine(@" *                             $$$$$$\ $$  /     $$ | \_/ $$ |$$ | \$$\ $$ |  $$ |                             *");
        Console.WriteLine(@" *                             \______|\__/      \__|     \__|\__|  \__|\__|  \__|                             *");
        Console.WriteLine(@" *                                                                                                             *");
        Console.WriteLine(@" *                                                                                                             *");
        Console.Write(@" *                                      ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(@"启动成功，欢迎使用 17MKH ~");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"                                             *");
        Console.WriteLine(@" *                                                                                                             *");
        Console.WriteLine(@" *                                                                                                             *");
        Console.WriteLine(@" ***************************************************************************************************************");
        Console.WriteLine();
    }
}