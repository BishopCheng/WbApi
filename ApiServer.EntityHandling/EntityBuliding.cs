using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace ApiServer.EntityHandling
{
    /// <summary>
    /// 实体创建类
    /// 作者：程淮榕
    /// 时间：2018-10-15
    /// </summary>
    public static  class EntityBuliding
    {
        /// <summary>
        /// 读取模型
        /// </summary>
        /// <typeparam name="T">要读取的模型</typeparam>
        /// <param name="dataReaderObject">读取器</param>
        /// <returns></returns>
        public static T ReadModel<T>(this IDataReader dataReaderObject)
        {
            using (dataReaderObject) {
                if (dataReaderObject.Read()) {
                    Type typeFromHandle = typeof(T);    //获取T的类型
                    int fieldCount = dataReaderObject.FieldCount;  //获取读取器的区域块数
                    T val = Activator.CreateInstance<T>();         //建立访问器
                    for (int i = 0; i < fieldCount;i++)
                    {
                        if (!ISNullOrDBNull(dataReaderObject[i]))   //如果读取器的区域块数不为空,则写入
                        {
                            PropertyInfo propertyInfo = typeFromHandle.GetProperty(dataReaderObject.GetName(i), BindingFlags.IgnoreCase | BindingFlags.Instance |
                            BindingFlags.Public | BindingFlags.GetProperty);
                            if (propertyInfo != (PropertyInfo)null)
                            {
                                //将IDataReader读出来的数据写到实体对象的属性里
                                propertyInfo.SetValue(val, CheckType(dataReaderObject[i], propertyInfo.PropertyType), null);
                            }
                        }
                       
                    }
                    return val;
                }
                return default(T);
            }
        }

        /// <summary>
        /// 判断数据源是否为空
        /// </summary>
        /// <returns></returns>
        private static bool ISNullOrDBNull(object objInput)
        {
            if(objInput == null || objInput is DBNull)
            { return true; }
            else { return false; }
        }


        /// <summary>
        /// 检查实体类型
        /// </summary>
        /// <param name="value">实体</param>
        /// <param name="conversionType">类型</param>
        /// <returns></returns>
        private static object CheckType(Object value, Type conversionType)
        {
            if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    return null;
                }
                NullableConverter nullableConverter = new NullableConverter(conversionType);
                conversionType = nullableConverter.UnderlyingType;
            }
            return Convert.ChangeType(value, conversionType);
        }
    }
}
