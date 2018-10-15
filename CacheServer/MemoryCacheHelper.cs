using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.Memory;

namespace CacheServers
{
    /// <summary>
    /// 缓存操作类实现
    /// 作者：程淮榕
    /// 时间：2018-09-12
    /// </summary>
    public class MemoryCacheHelper : ICacheHelper
    {
        public static IMemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        //public MemoryCacheHelper(MemoryCacheOptions options)
        //{
        //    _cache = new MemoryCache(options);
        //}

        /// <summary>
        /// 释放缓存
        /// </summary>
        public void Dispose()
        {
            if (_cache != null)
                _cache.Dispose(); //从内存中销毁
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 是否存在此缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Exists(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException(nameof(key));
            object v = null;
            return _cache.TryGetValue<object>(key, out v);
        }

        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetCache<T>(string key) where T : class
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException(nameof(key));
            T v = null;
            _cache.TryGetValue<T>(key, out v);
            return v;
        }

        public void GetMessages()
        {
            throw new NotImplementedException();
        }

        public void Publish(string msg)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key"></param>
        public void RemoveCache(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException(nameof(key));

            _cache.Remove(key);
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetCache(string key, object value)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException(nameof(key));
            if (value == null)
                throw new ArgumentException(nameof(value));

            object v = null;
            if (_cache.TryGetValue(key, out v))  //如果缓存中已经存在此对象，则需先移除该对象后再负责
                _cache.Remove(key);
            _cache.Set<object>(key, value);
        }

        /// <summary>
        /// 设置缓存绝对过期
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiressAbsoulte">结束时间</param>
        public void SetCache(string key, object value, DateTimeOffset expiressAbsoulte)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException(nameof(key));
            if (value == null)
                throw new ArgumentException(nameof(value));

            object v = null;
            if (_cache.TryGetValue(key, out v))
                _cache.Remove(key);

            _cache.Set<object>(key, value, expiressAbsoulte);
        }

        public void SetCache(string key, object value, TimeSpan timeSpan)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 设置缓存绝对过期
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expirationMinute">间隔时间(分钟)</param>
        public void SetCache(string key, object value, double expirationMinute)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException(nameof(key));
            if (value == null)
                throw new ArgumentException(nameof(value));

            object v = null;
            if (_cache.TryGetValue(key, out v))
                _cache.Remove(key);
            DateTime now = DateTime.Now;
            TimeSpan ts = now.AddMinutes(expirationMinute) - DateTime.Now;
            _cache.Set<object>(key, value, ts);

        }

        public void SetSlidingCache(string key, object value, TimeSpan timeSpan)
        {
            throw new NotImplementedException();
        }
    }
}

