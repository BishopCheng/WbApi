using System;
using System.Collections.Generic;
using System.Text;

namespace DBDictionary
{
     public interface IDBDataType
    {
        /// <summary>
        /// 获取数据类型接口(传入数据库类型，获取程序类型)
        /// </summary>
        /// <param name="dbType"></param>
        /// <returns></returns>
        string GetDataType(string dbType);
    }
}
