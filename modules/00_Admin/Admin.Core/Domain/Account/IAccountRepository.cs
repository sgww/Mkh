﻿using System;
using System.Threading.Tasks;
using Mkh.Data.Abstractions;

namespace Mkh.Mod.Admin.Core.Domain.Account;

/// <summary>
/// 账户仓储接口
/// </summary>
public interface IAccountRepository : IRepository<AccountEntity>
{
    /// <summary>
    /// 判断用户名是否存在
    /// </summary>
    /// <param name="username"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> ExistsUsername(string username, Guid? id = null);

    /// <summary>
    /// 判断手机号是否存在
    /// </summary>
    /// <param name="phone"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> ExistsPhone(string phone, Guid? id = null);

    /// <summary>
    /// 判断邮箱是否存在
    /// </summary>
    /// <param name="email"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> ExistsEmail(string email, Guid? id = null);

    /// <summary>
    /// 根据用户名查询账户信息
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    Task<AccountEntity> GetByUserName(string username);
}