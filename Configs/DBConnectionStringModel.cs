using System;

namespace Configs
{
    /// <summary>
    /// 数据库连接类实体模型
    /// 作者：程淮榕
    /// 日期：2018-12-04
    /// </summary>
    public class DBConnectionStringModel
    {
        /// <summary>
        /// 连接名称
        /// </summary>
        public string ConnectionName { get; set; }

        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// 驱动名称
        /// </summary>
        public string ProviderName { get; set; }

        /// <summary>
        /// 延时
        /// </summary>
        public int TimeOut { get; set; }
    }
}
