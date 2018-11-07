using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using SQLServer;

namespace ApiServer.Interface
{
    /// <summary>
    /// 数据库接口(定义成抽象类)
    /// </summary>
    public abstract class IDataBase
    {
        /// <summary>
        /// 数据库名称
        /// </summary>
        public abstract string DataBaseName
        {
            get;
        }

        /// <summary>
        /// 链接名称
        /// </summary>
        public abstract string ConnectionName
        {
            get;
        }

        /// <summary>
        /// 链接字符串
        /// </summary>
        public abstract string ConnectionString
        {
            get;
        }

        /// <summary>
        /// 链接实体
        /// </summary>
        public abstract DbConnection Dbconnection
        {
            get;
        }

        /// <summary>
        /// 链接工厂实体
        /// </summary>
        public abstract DbProviderFactory DbProviderFactory
        {
            get;
        }

        /// <summary>
        /// 工厂名称
        /// </summary>
        public abstract string ProvidName
        {
            get;
        }

        /// <summary>
        /// SQL执行实现类
        /// </summary>
        public abstract ExcuteImport ExcuteImport
        {
            get;
        }
    }
}
