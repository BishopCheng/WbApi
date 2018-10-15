using System;
using System.Collections.Generic;
using System.Text;

namespace CacheServers
{
    /// <summary>
    /// 静态类调用缓存
    /// 作者：程淮榕
    /// 时间：2018-09-12
    /// </summary>
    public class CommonCache
    {
        private static readonly object lockobj = new object();
        private static volatile CacheEntity _cache = null;

        public static CacheEntity CacheObj
        {
            get
            {
                if (_cache == null)
                {
                    lock (lockobj)
                    {
                        if (_cache == null)
                            _cache = new CacheEntity();
                    }
                }
                return _cache;
            }
        }
    }

}

