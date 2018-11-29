using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using SQLServer;

namespace APIServer.Common
{
     public static class EnumerableExtensions
    {
        /// <summary>
        /// 获取Field集合
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="lst">列表</param>
        /// <param name="fieldName">Field名称</param>
        /// <returns></returns>
        public static Collection<object>GetFieldCollection<T>(this IEnumerable<T>lst,string fieldName) where T : IEntity
        {
            Collection<object> Collections = new Collection<object>();
            foreach (T item in lst)
            {
                Collections.Add(item.ColumnValue(fieldName));
            }
            return Collections;
        }
    }
}
