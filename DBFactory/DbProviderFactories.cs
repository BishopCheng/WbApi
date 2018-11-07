using System;
using MySql.Data.MySqlClient;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OracleClient;

namespace DBFactory
{
    /// <summary>
    /// 数据库工厂模型类
    /// </summary>
    public static class DbProviderFactories
    {
        /// <summary>
        /// 获取数据库工厂实体
        /// </summary>
        /// <param name="provideName">工厂名称</param>
        /// <returns></returns>
        public static DbProviderFactory GetProviderFactory(string provideName)
        {
            if (!string.IsNullOrEmpty(provideName))
            {
                switch(provideName)
                {
                    case "MySql.Data.MySqlClient":                          //MySql
                        return (DbProviderFactory)new MySqlClientFactory();
                    case "System.Data.SqlClient":
                        return (DbProviderFactory)SqlClientFactory.Instance;  //SQL
                    case "Npgsql":
                        return (DbProviderFactory)NpgsqlFactory.Instance;   //NPGSQL
                    case "System.Data.OracleClient":
                        return (DbProviderFactory)new OracleClientFactory();  //Oracle
                    case "System.Data.OleDb":
                        throw new Exception("暂不支持您使用的数据库类型！");
                    case "System.Data.ODBC":
                        throw new Exception("暂不支持您使用的数据库类型！");
                    case "Oracle.DataAccess.Client":
                        throw new Exception("暂不支持您使用的数据库类型！");
                    case "System.Data.SQLite":
                        throw new Exception("暂不支持您使用的数据库类型！");
                    case "FirebirdSql.Data.Firebird":
                        throw new Exception("暂不支持您使用的数据库类型！");
                    case "IBM.Data.DB2.iSeries":
                        throw new Exception("暂不支持您使用的数据库类型！");
                    case "IBM.Data.Informix":
                        throw new Exception("暂不支持您使用的数据库类型！");
                    case "System.Data.SqlServerCe":
                        throw new Exception("暂不支持您使用的数据库类型！");
                    default:
                        throw new Exception("暂不支持您使用的数据库类型！");
                }
            }
            throw new Exception("数据库驱动类型配置不正确");
        }

        /// <summary>
        /// 获取链接实体类
        /// </summary>
        /// <param name="providName">数据库驱动名称</param>
        /// <param name="connectionString">链接字段</param>
        /// <returns></returns>
        public static DbConnection GetDbConnection(string providName,string connectionString)
        {
            if (!string.IsNullOrEmpty(providName))
            {
                switch (providName)
                {
                    case "MySql.Data.MySqlClient":                          //MySql
                        return (DbConnection)new MySqlConnection(connectionString);
                    case "System.Data.SqlClient":                          //SQLServer
                        return (DbConnection)new SqlConnection(connectionString);
                    case "Npgsql":                                         //Npgsql
                        return (DbConnection)new NpgsqlConnection(connectionString);
                    case "System.Data.OracleClient":                       //Oracle
                        return (DbConnection)new OracleConnection(connectionString);
                    case "System.Data.OleDb":
                        throw new Exception("数据库驱动类型配置不正确！");
                    case "System.Data.ODBC":
                        throw new Exception("数据库驱动类型配置不正确！");
                    case "Oracle.DataAccess.Client":
                        throw new Exception("数据库驱动类型配置不正确！");
                    case "System.Data.SQLite":
                        throw new Exception("数据库驱动类型配置不正确！");
                    case "FirebirdSql.Data.Firebird":
                        throw new Exception("数据库驱动类型配置不正确！");
                    case "IBM.Data.DB2.iSeries":
                        throw new Exception("数据库驱动类型配置不正确！");
                    case "IBM.Data.Informix":
                        throw new Exception("数据库驱动类型配置不正确！");
                    case "System.Data.SqlServerCe":
                        throw new Exception("数据库驱动类型配置不正确！");
                    default:
                        throw new Exception("数据库驱动类型配置不正确！");
                }
                 
            }
            throw new Exception("数据库驱动类型配置不正确！");
        }

    }
}
