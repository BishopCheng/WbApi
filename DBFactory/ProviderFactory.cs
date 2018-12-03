using System;
using System.Collections.Generic;
using System.Data.Common;
using DBFactory;
using SQLSettings;
using DBDictionary;

namespace DBFactory
{
    /// <summary>
    /// 数据库驱动工厂类
    /// 作者：程淮榕
    /// 时间：2018-12-03
    /// </summary>
    public class ProviderFactory
    {
        /// <summary>
        /// 名称字典
        /// </summary>
        private static Dictionary<DbProviderType, string> providerInvariantNames;
        /// <summary>
        /// 驱动工厂字典
        /// </summary>
        private static Dictionary<DbProviderType, DbProviderFactory> providerFactories;

        /// <summary>
        /// 驱动工厂构造方法
        /// </summary>
        static ProviderFactory()
        {
            providerInvariantNames = new Dictionary<DbProviderType, string>();
            providerFactories = new Dictionary<DbProviderType, DbProviderFactory>();

            //暂时先添加三个
            providerInvariantNames.Add(DbProviderType.SqlServer, "System.Data.SqlClient");
            providerInvariantNames.Add(DbProviderType.MySql, "MySql.Data.MySqlClient");
            providerInvariantNames.Add(DbProviderType.Oracle, "Oracle.ManagedDataAccess.Client");
        }

        public static string GetProviderInvariantName(DbProviderType providerType)
        {
            return providerInvariantNames[providerType];
        }

        /// <summary>
        /// 获取数据库驱动工厂
        /// </summary>
        /// <param name="providerType"></param>
        /// <returns></returns>
        public static DbProviderFactory GetProviderFactory(DbProviderType providerType)
        {
            //先锁住驱动工厂字典,如果驱动工厂中不包含传入类型,则将该类型添加到工厂字典中，如果包含，则返回该工厂
            lock (providerFactories)
            {
                if (!providerFactories.ContainsKey(providerType))
                {
                    providerFactories.Add(providerType, ImprotDbProviderFactory(providerType));
                }
                return providerFactories[providerType];
            }
        }

        /// <summary>
        /// 实现驱动工厂
        /// </summary>
        /// <param name="providerType">驱动类型</param>
        /// <returns></returns>
        private static DbProviderFactory ImprotDbProviderFactory(DbProviderType providerType)
        {
            //先获取名称，再根据名称获取工厂
            string providerName = providerInvariantNames[providerType];
            DbProviderFactory dbProviderFactory = null;
            try
            {
                return DbProviderFactories.GetProviderFactory(providerName);
            }
            catch (ArgumentException ex)
            {
                dbProviderFactory = null;
                throw ex;
            }
        }

        /// <summary>
        /// 获取数据库驱动类型
        /// </summary>
        /// <param name="dbProviderTypeName"></param>
        /// <returns></returns>
        private static DbProviderType GetDbProviderType(string dbProviderTypeName)
        {
            switch (dbProviderTypeName)
            {
                case "System.Data.SqlClient":
                    return DbProviderType.SqlServer;
                case "MySql.Data.MySqlClient":
                    return DbProviderType.MySql;
                case "Oracle.ManagedDataAccess.Client":
                    return DbProviderType.Oracle;
                default:                             //默认返回SqlServer.Client
                    return DbProviderType.SqlServer;

            }
        }

        /// <summary>
        /// 根据数据库类型名称返回对应的SQL通用占位符语句接口
        /// </summary>
        /// <param name="dbProviderTypeName"></param>
        /// <returns></returns>
        public static ISetting GetSqlSetting(string dbProviderTypeName)
        {
            //默认返回sqlServer链接，否则按名称返回
            if(dbProviderTypeName == "MySql.Data.MySqlClient")
            {
                return new MySqlSetting();
            }
            else
            {
                return new MsSQLSeverSetting();
            }
        }

        /// <summary>
        /// 获取SQL语句操作对象接口
        /// </summary>
        /// <param name="dbProviderTypeName"></param>
        /// <returns></returns>
        public static  IDBDictionarySql GetDbDictionarySql(string dbProviderTypeName)
        {
            if (dbProviderTypeName == "MySql.Data.MySqlClient")
            {
                return new DictionaryMySql();
            }
            else
            {
                return new DictionaryMySql();
            }
        }

        /// <summary>
        /// 获取数据库链接字符串格式语句
        /// </summary>
        /// <param name="dbProviderTypeName"></param>
        /// <returns></returns>
        public static string GetConnectFormat(string dbProviderTypeName)
        {
            //暂时默认只有MySql的链接字符串
            return "Server={0};Database={1};Uid={2};Pwd={3}";
        }

        /// <summary>
        /// 获取数据库和程序数据类型转换类接口
        /// </summary>
        /// <param name="dbProviderTypeName"></param>
        /// <returns></returns>
        public static IDBDataType GetIDBDataType(string dbProviderTypeName)
        {
            //暂时只返回MySql类型对应接口
            return new DBDataTypeMySql();
        }
    }
}
