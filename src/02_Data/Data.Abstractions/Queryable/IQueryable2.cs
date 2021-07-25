using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mkh.Data.Abstractions.Entities;
using Mkh.Data.Abstractions.Pagination;
using Mkh.Data.Abstractions.Queryable.Grouping;
using Mkh.Utils.Models;

namespace Mkh.Data.Abstractions.Queryable
{
    public interface IQueryable<TEntity, TEntity2> : IQueryable where TEntity : IEntity, new() where TEntity2 : IEntity, new()
    {
        #region ==Sort==

        /// <summary>
        /// 升序
        /// </summary>
        /// <param name="field">排序字段名称</param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> OrderBy(string field);

        /// <summary>
        /// 降序
        /// </summary>
        /// <param name="field">排序字段名称</param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> OrderByDescending(string field);

        /// <summary>
        /// 升序
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> OrderBy<TKey>(Expression<Func<IQueryableJoins<TEntity, TEntity2>, TKey>> expression);

        /// <summary>
        /// 降序
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> OrderByDescending<TKey>(Expression<Func<IQueryableJoins<TEntity, TEntity2>, TKey>> expression);

        #endregion

        #region ==Where==

        /// <summary>
        /// 过滤
        /// </summary>
        /// <param name="expression">过滤条件</param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> Where(Expression<Func<IQueryableJoins<TEntity, TEntity2>, bool>> expression);

        /// <summary>
        /// 附加SQL语句条件
        /// </summary>
        /// <param name="whereSql">查询条件</param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> Where(string whereSql);

        /// <summary>
        /// 条件为true时添加过滤
        /// </summary>
        /// <param name="condition">添加条件</param>
        /// <param name="expression">条件</param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> WhereIf(bool condition, Expression<Func<IQueryableJoins<TEntity, TEntity2>, bool>> expression);

        /// <summary>
        /// 条件为true时添加SQL语句条件
        /// </summary>
        /// <param name="condition">添加条件</param>
        /// <param name="whereSql">查询条件</param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> WhereIf(bool condition, string whereSql);

        /// <summary>
        /// 根据条件添加过滤
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="ifExpression"></param>
        /// <param name="elseExpression"></param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> WhereIfElse(bool condition, Expression<Func<IQueryableJoins<TEntity, TEntity2>, bool>> ifExpression, Expression<Func<IQueryableJoins<TEntity, TEntity2>, bool>> elseExpression);

        /// <summary>
        /// 根据条件添加SQL语句条件
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="ifWhereSql"></param>
        /// <param name="elseWhereSql"></param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> WhereIfElse(bool condition, string ifWhereSql, string elseWhereSql);

        /// <summary>
        /// 字符串不为Null以及空字符串的时候添加过滤
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> WhereNotNull(string condition, Expression<Func<IQueryableJoins<TEntity, TEntity2>, bool>> expression);

        /// <summary>
        /// 字符串不为Null以及空字符串的时候添加ifExpression，反之添加elseExpression
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="ifExpression"></param>
        /// <param name="elseExpression"></param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> WhereNotNull(string condition, Expression<Func<IQueryableJoins<TEntity, TEntity2>, bool>> ifExpression, Expression<Func<IQueryableJoins<TEntity, TEntity2>, bool>> elseExpression);

        /// <summary>
        /// 字符串不为Null以及空字符串的时候添加SQL语句条件
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="whereSql"></param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> WhereNotNull(string condition, string whereSql);

        /// <summary>
        /// 字符串不为Null以及空字符串的时候添加ifWhereSql，反之添加elseWhereSql
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="ifWhereSql"></param>
        /// <param name="elseWhereSql"></param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> WhereNotNull(string condition, string ifWhereSql, string elseWhereSql);

        /// <summary>
        /// 对象不为Null以及空字符串的时候添加SQL语句条件
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> WhereNotNull(object condition, Expression<Func<IQueryableJoins<TEntity, TEntity2>, bool>> expression);

        /// <summary>
        /// 对象不为Null的时候添加ifExpression，反之添加elseExpression
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="ifExpression"></param>
        /// <param name="elseExpression"></param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> WhereNotNull(object condition, Expression<Func<IQueryableJoins<TEntity, TEntity2>, bool>> ifExpression, Expression<Func<IQueryableJoins<TEntity, TEntity2>, bool>> elseExpression);

        /// <summary>
        /// 对象不为Null以及空字符串的时候添加SQL语句条件
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="whereSql"></param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> WhereNotNull(object condition, string whereSql);

        /// <summary>
        /// 对象不为Null的时候添加ifWhereSql，反之添加elseWhereSql
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="ifWhereSql"></param>
        /// <param name="elseWhereSql"></param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> WhereNotNull(object condition, string ifWhereSql, string elseWhereSql);

        /// <summary>
        /// GUID不为空的时候添加过滤条件
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> WhereNotEmpty(Guid condition, Expression<Func<IQueryableJoins<TEntity, TEntity2>, bool>> expression);

        /// <summary>
        /// GUID不为空的时候添加过滤SQL语句条件
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="whereSql"></param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> WhereNotEmpty(Guid condition, string whereSql);

        /// <summary>
        /// GUID不为空的时候添加ifExpression，反之添加elseExpression
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="ifExpression"></param>
        /// <param name="elseExpression"></param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> WhereNotEmpty(Guid condition, Expression<Func<IQueryableJoins<TEntity, TEntity2>, bool>> ifExpression, Expression<Func<IQueryableJoins<TEntity, TEntity2>, bool>> elseExpression);

        /// <summary>
        /// GUID不为空的时候添加ifExpression，反之添加elseExpression
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="ifWhereSql"></param>
        /// <param name="elseWhereSql"></param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> WhereNotEmpty(Guid condition, string ifWhereSql, string elseWhereSql);

        #endregion

        #region ==SubQuery==

        /// <summary>
        /// 子查询等于
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key">列</param>
        /// <param name="queryable">子查询的查询构造器</param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> SubQueryEqual<TKey>(Expression<Func<IQueryableJoins<TEntity, TEntity2>, TKey>> key, IQueryable queryable);

        /// <summary>
        /// 子查询不等于
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key">列</param>
        /// <param name="queryable">子查询的查询构造器</param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> SubQueryNotEqual<TKey>(Expression<Func<IQueryableJoins<TEntity, TEntity2>, TKey>> key, IQueryable queryable);

        /// <summary>
        /// 子查询大于
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key">列</param>
        /// <param name="queryable">子查询的查询构造器</param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> SubQueryGreaterThan<TKey>(Expression<Func<IQueryableJoins<TEntity, TEntity2>, TKey>> key, IQueryable queryable);

        /// <summary>
        /// 子查询大于等于
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key">列</param>
        /// <param name="queryable">子查询的查询构造器</param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> SubQueryGreaterThanOrEqual<TKey>(Expression<Func<IQueryableJoins<TEntity, TEntity2>, TKey>> key, IQueryable queryable);

        /// <summary>
        /// 子查询小于
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key">列</param>
        /// <param name="queryable">子查询的查询构造器</param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> SubQueryLessThan<TKey>(Expression<Func<IQueryableJoins<TEntity, TEntity2>, TKey>> key, IQueryable queryable);

        /// <summary>
        /// 子查询小于等于
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key">列</param>
        /// <param name="queryable">子查询的查询构造器</param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> SubQueryLessThanOrEqual<TKey>(Expression<Func<IQueryableJoins<TEntity, TEntity2>, TKey>> key, IQueryable queryable);

        /// <summary>
        /// 子查询包含
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key">列</param>
        /// <param name="queryable">子查询的查询构造器</param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> SubQueryIn<TKey>(Expression<Func<IQueryableJoins<TEntity, TEntity2>, TKey>> key, IQueryable queryable);

        /// <summary>
        /// 子查询不包含
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key">列</param>
        /// <param name="queryable">子查询的查询构造器</param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> SubQueryNotIn<TKey>(Expression<Func<IQueryableJoins<TEntity, TEntity2>, TKey>> key, IQueryable queryable);

        #endregion

        #region ==Select==

        /// <summary>
        /// 查询返回指定列
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="expression">返回的列</param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> Select<TResult>(Expression<Func<IQueryableJoins<TEntity, TEntity2>, TResult>> expression);

        /// <summary>
        /// 查询返回指定列
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="sql">SELECT后面的SQL语句，一般用于需要自定义的情况</param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> Select<TResult>(string sql);

        /// <summary>
        /// 查询排除指定列
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> SelectExclude<TResult>(Expression<Func<IQueryableJoins<TEntity, TEntity2>, TResult>> expression);

        #endregion

        #region ==Limit==

        /// <summary>
        /// 限制
        /// </summary>
        /// <param name="skip">跳过前几条数据</param>
        /// <param name="take">取前几条数据</param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> Limit(int skip, int take);

        #endregion

        #region ==Join==

        /// <summary>
        /// 左连接
        /// </summary>
        /// <typeparam name="TEntity3"></typeparam>
        /// <param name="onExpression"></param>
        /// <param name="tableName">自定义表名</param>
        /// <param name="noLock">针对SqlServer的NoLock特性，默认开启</param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2, TEntity3> LeftJoin<TEntity3>(Expression<Func<IQueryableJoins<TEntity, TEntity2, TEntity3>, bool>> onExpression, string tableName = null, bool noLock = true) where TEntity3 : IEntity, new();

        /// <summary>
        /// 内连接
        /// </summary>
        /// <typeparam name="TEntity3"></typeparam>
        /// <param name="onExpression"></param>
        /// <param name="tableName">自定义表名</param>
        /// <param name="noLock">针对SqlServer的NoLock特性，默认开启</param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2, TEntity3> InnerJoin<TEntity3>(Expression<Func<IQueryableJoins<TEntity, TEntity2, TEntity3>, bool>> onExpression, string tableName = null, bool noLock = true) where TEntity3 : IEntity, new();

        /// <summary>
        /// 右连接
        /// </summary>
        /// <typeparam name="TEntity3"></typeparam>
        /// <param name="onExpression"></param>
        /// <param name="tableName">自定义表名</param>
        /// <param name="noLock">针对SqlServer的NoLock特性，默认开启</param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2, TEntity3> RightJoin<TEntity3>(Expression<Func<IQueryableJoins<TEntity, TEntity2, TEntity3>, bool>> onExpression, string tableName = null, bool noLock = true) where TEntity3 : IEntity, new();

        #endregion

        #region ==List==

        /// <summary>
        /// 查询列表，返回指定类型
        /// </summary>
        /// <returns></returns>
        Task<IList<TEntity>> ToList();

        #endregion

        #region ==Pagination==

        /// <summary>
        /// 分页查询，返回实体类型
        /// </summary>
        /// <returns></returns>
        Task<IList<TEntity>> ToPagination();

        /// <summary>
        /// 分页查询，返回实体类型
        /// </summary>
        /// <param name="paging">分页对象</param>
        /// <returns></returns>
        Task<IList<TEntity>> ToPagination(Paging paging);

        /// <summary>
        /// 分页查询，返回实体类型
        /// </summary>
        /// <param name="paging">分页对象</param>
        /// <returns></returns>
        Task<IResultModel> ToPaginationResult(Paging paging);

        #endregion

        #region ==First==

        /// <summary>
        /// 查询第一条数据，返回指定类型
        /// </summary>
        /// <returns></returns>
        Task<TEntity> ToFirst();

        #endregion

        #region ==NotFilterSoftDeleted==

        /// <summary>
        /// 不过滤软删除数据
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> NotFilterSoftDeleted();

        #endregion

        #region ==NotFilterTenant==

        /// <summary>
        /// 不过滤租户
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> NotFilterTenant();

        #endregion

        #region ==Function==

        /// <summary>
        /// 获取最大值
        /// </summary>
        /// <returns></returns>
        Task<TResult> ToMax<TResult>(Expression<Func<IQueryableJoins<TEntity, TEntity2>, TResult>> expression);

        /// <summary>
        /// 获取最小值
        /// </summary>
        /// <returns></returns>
        Task<TResult> ToMin<TResult>(Expression<Func<IQueryableJoins<TEntity, TEntity2>, TResult>> expression);

        /// <summary>
        /// 求和
        /// </summary>
        /// <returns></returns>
        Task<TResult> ToSum<TResult>(Expression<Func<IQueryableJoins<TEntity, TEntity2>, TResult>> expression);

        /// <summary>
        /// 求平均值
        /// </summary>
        /// <returns></returns>
        Task<TResult> ToAvg<TResult>(Expression<Func<IQueryableJoins<TEntity, TEntity2>, TResult>> expression);

        #endregion

        #region ==GroupBy==

        IGroupingQueryable<TResult, TEntity, TEntity2> GroupBy<TResult>(Expression<Func<IQueryableJoins<TEntity, TEntity2>, TResult>> expression);

        #endregion

        #region ==Copy==

        /// <summary>
        /// 复制一个新的实例
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> Copy();

        #endregion

        #region ==UseUow==

        /// <summary>
        /// 使用工作单元
        /// </summary>
        /// <param name="uow"></param>
        /// <returns></returns>
        IQueryable<TEntity, TEntity2> UseUow(IUnitOfWork uow);

        #endregion
    }

    public interface IQueryableJoins<out TEntity, out TEntity2> where TEntity : IEntity, new() where TEntity2 : IEntity, new()
    {
        TEntity T1 { get; }

        TEntity2 T2 { get; }
    }
}
