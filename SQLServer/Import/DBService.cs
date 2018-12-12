using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Linq;

namespace SQLServer
{
    /// <summary>
    /// 数据库反射操作实现类
    /// </summary>
    /// <typeparam name="DB"></typeparam>
    /// <typeparam name="T"></typeparam>
    public class DBService<DB,T> where DB:IDataBase, new() where T:IEntity,new()
    {
        /// <summary>
        /// json格式化的时间字符串
        /// </summary>
        private static JsonSerializerSettings dateTimeJsonSerializerSettings = null;

        private string BaseDirection_
        {
            get
            {
                if (BaseDirection_.Length > 0)
                {
                    goto IL_0018;
                }
                goto IL_0018;
                IL_0018:
                return BaseDirection_;
            }
            set
            {
                BaseDirection_ = value;
            }
        }
        /// <summary>
        /// 默认的缓存延时
        /// </summary>
        private int CacheTime_ = 60;

        private int CacheTime
        {
            get
            {

                return CacheTime_;
            }
            set
            {
                CacheTime_ = value;
            }
        }

        public static JsonSerializerSettings DateTimeJsonSerializerSettings
        {
            get
            {
                //如果json格式化的时间字符串设置为空,则进行赋值
                if(dateTimeJsonSerializerSettings == null)
                {
                    IsoDateTimeConverter val = new IsoDateTimeConverter();
                    val.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
                    IsoDateTimeConverter item = val;
                    JsonSerializerSettings val2 = new JsonSerializerSettings();
                    val2.MissingMemberHandling = 0;
                    val2.NullValueHandling = NullValueHandling.Ignore;
                    val2.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    dateTimeJsonSerializerSettings = val2;
                    dateTimeJsonSerializerSettings.Converters.Add(item);
                }
                return dateTimeJsonSerializerSettings;
            }
        }

        public string BanthInsert(List<T>tList,string userName)
        {

        }

        public string BanthInsert(List<T> tList) {

        }

        public string BanthInsert(List<T>tList,string userName,string changeBantch,ref DBtransaction dbtran)
        {

        }

        public string BantchInsert(List<T>tList,ref DBtransaction dbtran)
        {

        }

        public string BantchUpdate(List<T> tList)
        {

        }

        public string BantchUpdate(List<T>tList)
    }
}
