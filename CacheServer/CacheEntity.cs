using System;
using System.Collections.Generic;
using System.Text;

namespace CacheServers
{
    /// <summary>
    /// 缓存实例类，使用单例模式
    /// </summary>
    public sealed class CacheEntity
    {
        internal CacheEntity() { }

        public static ICacheHelper cache;
        /// <summary>
        /// 判断缓存是否存在
        /// </summary>
        /// <typeparam name="CacheType">缓存类型</typeparam>
        /// <param name="key">键名</param>
        /// <returns></returns>
        public bool Exists<CacheType>(string key) where CacheType : ICacheHelper, new()
        {
            if (cache != null && typeof(CacheType).Equals(cache.GetType()))
                return cache.Exists(key);
            else
            {
                cache = new CacheType();
                return cache.Exists(key);
            }
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T">转换的类</typeparam>
        /// <typeparam name="CacheType">缓存类型</typeparam>
        /// <param name="key">键名</param>
        /// <returns>转换成T类型的值</returns>
        public T GetCache<T, CacheType>(string key)
            where T : class
            where CacheType : ICacheHelper, new()
        {
            if (cache != null && typeof(CacheType).Equals(cache.GetType()))
                return cache.GetCache<T>(key);
            else
            {
                cache = new CacheType();
                return cache.GetCache<T>(key);
            }
        }


        /// <summary>
        /// 保存缓存
        /// </summary>
        /// <typeparam name="CacheType">缓存类型</typeparam>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public void Save<CacheType>(string key, object value) where CacheType : ICacheHelper, new()
        {
            if (cache != null && typeof(CacheType).Equals(cache.GetType()))
            {
                cache.SetCache(key, value);
            }
            else
            {
                cache = new CacheType();
                cache.SetCache(key, value);
            }
        }

        /// <summary>
        /// 保存缓存并设置绝对过期时间
        /// </summary>
        /// <typeparam name="CacheType">缓存类型</typeparam>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="expiressAbsoult">过期时间</param>
        public void Save<CacheType>(string key, object value, DateTimeOffset expiressAbsoult) where CacheType : ICacheHelper, new()
        {
            if (cache != null && typeof(CacheType).Equals(cache.GetType()))
            {
                cache.SetCache(key, value, expiressAbsoult);
            }
            else
            {
                cache = new CacheType();
                cache.SetCache(key, value, expiressAbsoult);
            }
        }


        /// <summary>
        /// 保存缓存并设置间隔过期时间
        /// </summary>
        /// <typeparam name="CacheType">缓存类型</typeparam>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="minutesSet">间隔时间(分钟)</param>
        public void Save<CacheType>(string key, object value, double minutesSet) where CacheType : ICacheHelper, new()
        {
            if (cache != null && typeof(CacheType).Equals(cache.GetType()))
            {
                cache.SetCache(key, value, minutesSet);
            }
            else
            {
                cache = new CacheType();
                cache.SetCache(key, value, minutesSet);
            }
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <typeparam name="CacheType"></typeparam>
        /// <param name="key"></param>
        public void Remove<CacheType>(string key) where CacheType : ICacheHelper, new()
        {
            if (cache != null && typeof(CacheType).Equals(cache.GetType()))
            {
                cache.RemoveCache(key);
            }
            else
            {
                cache = new CacheType();
                cache.RemoveCache(key);
            }
        }

        /// <summary>
        /// 释放
        /// </summary>
        /// <typeparam name="CacheType"></typeparam>
        public void Dispose<CacheType>() where CacheType : ICacheHelper, new()
        {
            if (cache != null && typeof(CacheType).Equals(cache.GetType()))
                cache.Dispose();
            else
            {
                cache = new CacheType();
                cache.Dispose();
            }
        }
    }
}