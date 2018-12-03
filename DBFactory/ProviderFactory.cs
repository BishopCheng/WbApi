using System;
using System.Collections.Generic;
using System.Data.Common;
using DBFactory;
using SQLSettings;

namespace DBFactory
{
    /// <summary>
    /// 数据库驱动工厂
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
    }
}
