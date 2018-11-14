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
        /// 返回查询结果中的第一列
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="parameters">参数集合</param>
        /// <returns></returns>
        object ExecuteScalar(string sql, List<DbParameter> parameters);

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
        DbParameter CreateDbParameter(string name, ParameterDirection parameterDirection, object value);

        /// <summary>
        /// 数据参数复制
        /// </summary>
        /// <param name="dbParameter">传入的数据参数</param>
        /// <returns></returns>
        DbParameter DbParameterCopy(DbParameter dbParameter);

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcedureName">存储过程名称</param>
        /// <param name="dbParameters">参数列表</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        DataSet RunProcedure(string storedProcedureName, List<DbParameter> dbParameters, string tableName);

        /// <summary>
        /// 执行存储过程填充到DataSet
        /// </summary>
        /// <param name="storedProcedureName">存储过程名称</param>
        /// <param name="dbParameters">参数列表</param>
        /// <returns></returns>
        DataSet RunProcedureToDataSet(string storedProcedureName, List<DbParameter> dbParameters);

        /// <summary>
        /// 执行存储过程(是否执行成功)
        /// </summary>
        /// <param name="storedProcedureName">存储过程名称</param>
        /// <param name="dbParameters">参数列表</param>
        /// <returns></returns>
        bool RunProcedure(string storedProcedureName, List<DbParameter> dbParameters);

        /// <summary>
        /// 实体列是否存在
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="columnName">列名</param>
        /// <returns></returns>
        bool ColumnExists(string tableName, string columnName);

        /// <summary>
        /// 获取最大ID
        /// </summary>
        /// <param name="fieldName">区域名称</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        int GetMaxID(string fieldName, string tableName);

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        bool Exists(string strSql, List<DbParameter> parameters = null);

        /// <summary>
        /// 判断表是否存在
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        bool TabExists(string tableName);

    }
}
