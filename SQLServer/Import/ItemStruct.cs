using System;
using System.Collections.Generic;
using System.Text;

namespace SQLServer
{
    /// <summary>
    /// 条目结构体
    /// </summary>
    public struct ItemStruct
    {
        /// <summary>
        /// 列
        /// </summary>
        public Column Column;

        /// <summary>
        /// 值
        /// </summary>
        public object Value;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        public ItemStruct(Column column,object value)
        {
            Column = column;
            Value = value;
        }

        public ItemStruct(object value)
        {
            Column = null;
            Value = value.ToString();
        }

        public override bool Equals(object obj)
        {
            //先转换成当前类型后，再与传入对象比较
            return ((ValueType)this).Equals(obj);
        }

        public override int GetHashCode()
        {
            return ((ValueType)this).GetHashCode();
        }
    }
}
