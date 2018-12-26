using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Data;

namespace ValidateServer
{
    /// <summary>
    /// Json操作类
    /// </summary>
    public class JsonService
    {
        #region 变量
        private static JsonSerializerSettings jsonSettings_;

        private static JsonSerializerSettings dateJsonSettings_;

        private static JsonSerializerSettings dateTimeJsonSettings_;
        #endregion

        #region  属性
        public static JsonSerializerSettings DateJsonSettings
        {
            get
            {
                if(dateJsonSettings_ == null)
                {
                    IsoDateTimeConverter val = new IsoDateTimeConverter();
                    val.DateTimeFormat = "yyyy-MM-dd";
                    IsoDateTimeConverter item = val;
                    JsonSerializerSettings val2 = new JsonSerializerSettings();
                    val2.MissingMemberHandling = 0;
                    val2.NullValueHandling = NullValueHandling.Ignore;
                    val2.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    dateJsonSettings_ = val2;
                    dateJsonSettings_.Converters.Add(item);
                }
                return dateJsonSettings_;
            }
        }

        public static JsonSerializerSettings DateTimeJsonSettings
        {
            get
            {
                if(dateTimeJsonSettings_ == null)
                {
                    IsoDateTimeConverter val =new IsoDateTimeConverter();
                    val.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
                    IsoDateTimeConverter item = val;
                    JsonSerializerSettings val2 = new JsonSerializerSettings();
                    val2.MissingMemberHandling = 0;
                    val2.NullValueHandling = NullValueHandling.Ignore;
                    val2.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    dateTimeJsonSettings_ = val2;
                    dateTimeJsonSettings_.Converters.Add(item);
                }
                return dateTimeJsonSettings_;
            }
        }


        #endregion

        #region 方法
        /// <summary>
        /// 构造函数
        /// </summary>
        public JsonService()
        {
            jsonSettings_ = DateTimeJsonSettings;
        }

        public static string Encrypt(string value)
        {
            
            return RandomEncrypt.Encrypt(value);
        }

        public static string Decrypt(string value)
        {
            if ((!value.StartsWith("{") || !value.EndsWith("}")) && (!value.StartsWith("[") || !value.EndsWith("]")))
            {
                return RandomEncrypt.Decrypt(value);
            }
            return value;
        }

        public static string EntityToJson(object entity)
        {
            if (entity != null)
            {
                string value = JsonConvert.SerializeObject(entity, 0, jsonSettings_);
                return Encrypt(value);
            }
            return null;
        }

        public static string DataTableToJson(DataTable dt)
        {
            string value = JsonConvert.SerializeObject((object)dt, jsonSettings_);
            return Encrypt(value);
        }

        public static string DataRowViewToJson(DataRowView drv)
        {
            string value = JsonConvert.SerializeObject((object)drv.Row, jsonSettings_);
            return Encrypt(value);
        }

        public static string DataSetToJson(DataSet ds)
        {
            string value = JsonConvert.SerializeObject((object)ds, jsonSettings_);
            return Encrypt(value);
        }

        public static string ListToJson<T>(List<T> lstT)
        {
            string value = JsonConvert.SerializeObject((object)lstT, 0, jsonSettings_);
            return Encrypt(value);
        }

        public static T JsonToEntity<T>(string json)
        {
            json = Decrypt(json);
            return JsonConvert.DeserializeObject<T>(json, jsonSettings_);
        }

        public static DataTable JsonToDataTable(string strJson)
        {
            strJson = Decrypt(strJson);
            return JsonConvert.DeserializeObject<DataTable>(strJson, jsonSettings_);
        }

        public static DataRowView JsonToDataRowView(string json)
        {
            json = Decrypt(json);
            if (!json.StartsWith("[") || !json.EndsWith("]"))
            {
                json = "[" + json + "]";
            }
            return JsonConvert.DeserializeObject<DataTable>(json, jsonSettings_).DefaultView[0];
        }

        public static DataSet JsonToDataSet(string json)
        {
            json = Decrypt(json);
            return JsonConvert.DeserializeObject<DataSet>(json, jsonSettings_);
        }

        public static List<T> JsonToList<T>(string json)
        {
            json = Decrypt(json);
            return JsonConvert.DeserializeObject<List<T>>(json, jsonSettings_);
        }

        public static JObject JsonToJObject(string json)
        {
            //IL_0014: Unknown result type (might be due to invalid IL or missing references)
            //IL_0019: Expected O, but got Unknown
            json = Decrypt(json);
            return (JObject)JsonConvert.DeserializeObject(json, jsonSettings_);
        }

        public static string ObjectToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj, jsonSettings_);
        }
        #endregion

    }
}
