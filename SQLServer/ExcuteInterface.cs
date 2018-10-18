using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using SQLServer;

namespace SQLServer
{
    /// <summary>
    /// SQL执行类通用接口
    /// 作者：程淮榕
    /// 时间：2018-10-07
    /// </summary>
    public interface ExcuteInterface
    {

        /// <summary>
        /// 非查询类执行(单语句单类参数)
        /// </summary>
        /// <param name="sqlList">参数集合</param>
        /// <returns></returns>
        int ExcuteNotQuery(string sqlStr,List<DbParameter>Parmeters);

        /// <summary>
        /// 带事务的非查询类执行(单语句单类参数)
        /// </summary>
        /// <param name="sqlStr">sql语句</param>
        /// <param name="lstParmeters">参数集合</param>
        /// <param name="dbtran">事务</param>
        /// <returns></returns>
        int ExcuteNotQuery(string sqlStr, List<DbParameter> Parmeters, DBtransaction dbtran);

        /// <summary>
        /// 非查询类执行(单语句多类参数)
        /// </summary>
        /// <param name="sqlStr">sql语句</param>
        /// <param name="lstParmeters">参数类list</param>
        /// <returns></returns>
        int ExcuteNotQuery(string sqlStr, IList<List<DbParameter>> lstParmeters);

        /// <summary>
        /// 带事务的非查询类执行(单语句单类参数)
        /// </summary>
        /// <param name="sqlStr">sql语句</param>
        /// <param name="lstParmeters">参数类list</param>
        /// <param name="dbtran">事务</param>
        /// <returns></returns>
        int ExcuteNotQuery(string sqlStr, IList<List<DbParameter>> lstParmeters, DBtransaction dbtran);

        /// <summary>
        /// 非查询执行类(多语句多参数)
        /// </summary>
        /// <param name="lstSqls">sql语句集合</param>
        /// <param name="lstParmeters">参数类list</param>
        /// <returns></returns>
        int ExcuteNotQuery(IList<string> lstSqls, IList<List<DbParameter>> lstParmeters);

        /// <summary>
        /// 非查询执行类(多语句多参数，带事务)
        /// </summary>
        /// <param name="lstSqls">sql语句集合</param>
        /// <param name="lstParmeters">参数类list</param>
        /// <param name="dbtran">使用事务</param>
        /// <returns></returns>
        int ExcuteNotQuery(IList<string> lstSqls, IList<List<DbParameter>> lstParmeters, DBtransaction dbtran);

        /// <summary>
        /// 查询执行
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="sqlStr">sql语句</param>
        /// <param name="lstParmeters">参数集合</param>
        /// <returns></returns>
        IEnumerable<T> Excute<T>(string sqlStr, List<DbParameter> lstParmeters) where T : class;

        /// <summary>
        /// 分页执行查询
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="sqlCount">sql数量</param>
        /// <param name="sqlData">sql数据</param>
        /// <param name="lstDbParmeters">参数集合</param>
        /// <returns></returns>
        PageData<T> ExecutePagerData<T>(string sqlCount, string sqlData, List<DbParameter> lstDbParmeters) where T : class;

        /// <summary>
        /// 创建SQL命令的方法
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="lstDbParameter">参数集合</param>
        /// <param name="commandType">command类型</param>
        /// <returns></returns>
        DbCommand CreateDbCommand(string sql, List<DbParameter> lstDbParameter, CommandType commandType);

        /// <summary>
        /// 创建数据参数实体
        /// </summary>
        /// <param name="name">实体名称</param>
        /// <param name="value">实体值</param>
        /// <returns></returns>
        DbParameter CreateDbParameter(string name, object value);

        /// <summary>
        /// 创建带说明的数据参数实体
        /// </summary>
        /// <param name="name">实体名称</param>
        /// <param name="parameterDirection">参数说明</param>
        /// <param name="value">实体值</param>
        /// <returns></returns>
        DbParameter CreateDbParmeter(string name, ParameterDirection parameterDirection, object value);
    }
}
