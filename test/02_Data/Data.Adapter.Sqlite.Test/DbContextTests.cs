﻿using System.Data;
using Xunit;
using Xunit.Abstractions;

namespace Data.Adapter.Sqlite.Test
{
    public class DbContextTests : BaseTest
    {
        public DbContextTests(ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// 数据库上下文状态测试
        /// </summary>
        [Fact]
        public async void NewConnectionTest()
        {
            await ClearTable();

            using var con = _dbContext.NewConnection();

            Assert.NotNull(con);
            Assert.Equal(ConnectionState.Closed, con.State);

            con.Open();

            Assert.Equal(ConnectionState.Open, con.State);
        }
    }
}
