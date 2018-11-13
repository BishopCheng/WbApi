using System;
using System.Collections.Generic;
using System.Text;

namespace SQLServer
{
    /// <summary>
    /// 列的结构体
    /// 作者：程淮榕
    /// 时间：2018-11-12
    /// </summary>
    public struct ColumnStruct
    {
        public Column Column;

        public string Name;

        public ColumnStruct(Column column,string name)
        {
            Column = column;
            Name = name;
        }
    }
}
