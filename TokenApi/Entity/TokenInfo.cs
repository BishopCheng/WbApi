using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenApi.Entity
{
    /// <summary>
    /// TOKEN实体类
    /// </summary>
    public sealed class TokenInfo
    {
        /// <summary>
        /// 签发者
        /// </summary>
        public string iss { get; set; }

        /// <summary>
        /// JWT所面向的用户
        /// </summary>
        public string sub { get; set; }

        /// <summary>
        /// 接收JWT的一方
        /// </summary>
        public string aud { get; set; }

        /// <summary>
        /// JWT签发时间
        /// </summary>
        public string iat { get; set; }


    }
}
