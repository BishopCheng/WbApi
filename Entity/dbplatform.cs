using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Configuration;
using Configs;
using SQLServer;

namespace ApiServer.Entity
{
    /// <summary>
    /// 数据库访问对象类
    /// 作者：程淮榕
    /// 日期：2018-12-06
    /// </summary>
    public class dbplatform : SQLServer.IDataBase
    {
        /// <summary>
        /// 连接实体
        /// </summary>
        private static DbConnection dbConnection_;
        /// <summary>
        /// 连接字符串
        /// </summary>
        private static string connectionString_;
        /// <summary>
        /// 驱动名称
        /// </summary>
        private static string providerName_;
        /// <summary>
        /// 驱动工厂实体
        /// </summary>
        private static DbProviderFactory dbProviderFactory_;

        /// <summary>
        /// 构造函数
        /// </summary>
        public dbplatform() { }

        public static dbplatform Instance
        {
            get
            {
                return Nested.instance;
            }
        }
        /// <summary>
        /// 内部类（访问器）
        /// </summary>
        class Nested
        {
            static Nested() { }
            internal static readonly dbplatform instance = new dbplatform();
        }
        /// <summary>
        /// 数据库名称
        /// </summary>
        public override string DataBaseName
        {
            get { return "dbplatform"; }
        }

        /// <summary>
        /// 连接名称
        /// </summary>
        public override string ConnectionName
        {
            get { return "dbplatform"; }
        }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public override string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(connectionString_))
                {
                    DBConnectionStringModel dBConnectionStringModel = ConnectionStringOperate.GetDBConnectionStringModel("dbplatform");
                    connectionString_ = dBConnectionStringModel.ConnectionString;
                }
                return connectionString_;
            }

        }
        /// <summary>
        /// 数据库连接实体
        /// </summary>
        public override DbConnection Dbconnection
        {
            get
            {
                //如果连接实体是空的,或者实体的连接字符串不包括当前连接字符串的话，则赋值
                if(dbConnection_ == null || !dbConnection_.ConnectionString.Equals(connectionString_))
                {
                    DbProviderFactory dbProviderFactory = DbProviderFactory;  //获取工厂
                    DbConnection dbConnection = dbProviderFactory.CreateConnection(); //创建连接实体
                    dbConnection.ConnectionString = ConnectionString;   //给连接字符串赋值
                    dbConnection_ = dbConnection;    //给实体赋值
                }
                return dbConnection_;
            }
        }

        /// <summary>
        /// 数据库驱动工厂
        /// </summary>
        public override DbProviderFactory DbProviderFactory
        {
            get
            {
                if(dbProviderFactory_ == null)
                {
                    dbProviderFactory_ = DBFactory.ProviderFactory.GetProviderFactory(DBFactory.ProviderFactory.GetDbProviderType(ProvidName));
                }
                return dbProviderFactory_;
            }
        }

        /// <summary>
        /// 驱动名称
        /// </summary
        public override string ProvidName {
            get { 
            
                if(string.IsNullOrEmpty(providerName_))
                {
                 //先获取链接实体，再获取驱动名称
                 DBConnectionStringModel dBConnectionStringModel = ConnectionStringOperate.GetDBConnectionStringModel("dbplatform");
                providerName_ = dBConnectionStringModel.ProviderName;
                }
                 return providerName_;
            }
        }


        private static SQLServer.ExcuteImport excuteImport_;
        /// <summary>
        /// 数据库SQL操作项
        /// </summary>
        public override ExcuteImport ExcuteImport 
        {
            get
            {
                //如果为空,则赋值
                if(excuteImport_ == null)
                {
                    excuteImport_ = new SQLServer.ExcuteImport(ConnectionString, ProvidName);
                }
                return excuteImport_;
            }
        }
    }
}
