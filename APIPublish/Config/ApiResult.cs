using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPublish.Config
{

    /// <summary>
    /// API返回结果类
    /// 作者：程淮榕
    /// 日期：2018-12-27
    /// </summary>
    public class ApiResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 数据索引
        /// </summary>
        public object DataExt { get; set; }
    }

    public class ListData
    {
        public object ListInfo { get; set; }

        public int PageIndex { get; set; } 

        public int PageSize { get; set; }

        public int Total { get; set; } = 0;

    }
}
