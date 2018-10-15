using System;
using System.Collections.Generic;
using System.Text;

namespace CacheServers
{
    /// <summary>
    /// 功能：Cache操作通用接口
    /// 作者：程淮榕
    /// 创建日期：2018-09-11
    /// </summary>
    public interface ICacheHelper
    {
        bool Exists(string key);   //是否包含

        T GetCache<T>(string key) where T : class;   //获取缓存

        void SetCache(string key, object value);  //给缓存赋值

        void SetCache(string key, object value, DateTimeOffset expiressAbsoulte);  //给缓存赋值,设置绝对过期时间

        void SetCache(string key, object value, TimeSpan timeSpan);   //给缓存赋值,设置相对当前时间的过期时间

        void SetCache(string key, object value, double Exminutes);   //给缓存赋值，设置绝对过期时间（通过间隔时间）

        void SetSlidingCache(string key, object value, TimeSpan timeSpan);  //设置滑动过期

        void RemoveCache(string key);  //删除缓存

        void Dispose();        //清空缓存

        void GetMessages();    //获取信息

        void Publish(string msg);    //发布
    }
}
