using SQLServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiServer.Entity
{
    /// <summary>
    /// 数据库访问器
    /// 作者:程淮榕
    /// 日期:2018-12-06
    /// </summary>
    public class dbplatformAccess<T> where T:IEntity,new()
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public dbplatformAccess() { }

        /// <summary>
        /// 访问器
        /// </summary>
        public static EntityGenerics<dbplatform, T> Instance
        {
            get
            {
                return Nested.instance;
            }
        }
        /// <summary>
        /// 内部类(新建只读实体)
        /// </summary>
        class Nested
        {
            static Nested() { }
            internal static readonly EntityGenerics<dbplatform, T> instance = new EntityGenerics<dbplatform, T>();
        }
    }
}
