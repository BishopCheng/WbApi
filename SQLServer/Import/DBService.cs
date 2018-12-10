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

        private string BaseDirection_ = "";
        /// <summary>
        /// 默认的缓存延时
        /// </summary>
        private int CacheTime_ = 60;

        public static JsonSerializerSettings DateTimeJsonSerializerSettings
        {
            get
            {
                //如果json格式化的时间字符串设置为空,则进行赋值
                if(dateTimeJsonSerializerSettings == null)
                {
                    IsoDateTimeConverter val = new IsoDateTimeConverter();
                    val.set_DateTimeFormat("yyyy-MM-dd HH:mm:ss");
                    IsoDateTimeConverter item = val;
                    JsonSerializerSettings val2 = new JsonSerializerSettings();
                    val2.set_MissingMemberHandling(0);
                    val2.set_NullValueHandling(1);
                    val2.set_ReferenceLoopHandling(1);
                    dateTimeJsonSerializerSettings = val2;
                    dateTimeJsonSerializerSettings.get_Converters().Add(item);
                }
            }
        }
    }
}
