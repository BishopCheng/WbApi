using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Text;

namespace SQLServer
{
    /// <summary>
    /// 查询条件类
    /// 作者：程淮榕
    /// 时间：2018-10-26
    /// </summary>
    [Serializable]  //声明该类可以被序列化
    public class WhereClip:Collection<object>   //继承自Object
    {
        public bool flag = true;

        public WhereClip AddClip(ConditionItem value)
        {
            flag = true;
            Add(value);
            return this;
        }

        public WhereClip AddComClip(ConditionItem value)
        {
            flag = true;
            Add(value);
            return this;
        }
    }
}
