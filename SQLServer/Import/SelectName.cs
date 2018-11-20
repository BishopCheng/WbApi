using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Collections.ObjectModel;

namespace SQLServer.Import
{
    /// <summary>
    /// 获取列名
    /// </summary>
    [Serializable]
     public class SelectName:Collection<ColumnStruct>
    {
        public SelectName AddClip(Column column,string name)
        {
            Add(new ColumnStruct(column, name));
            return this;
        }
        public SelectName AddClip(Column column)
        {
            Add(new ColumnStruct(column, column.Name));
            return this;
        }
        public SelectName ClearClip()
        {
            Clear();
            return this;
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (base.Count > 0)
            {
                using (IEnumerator<ColumnStruct>IEnumerator = GetEnumerator())
                {
                    while (IEnumerator.MoveNext())
                    {
                        ColumnStruct columnCurrent = IEnumerator.Current;
                        if (stringBuilder.Length > 0)
                        {
                            stringBuilder.Append(", ");
                        }
                        stringBuilder.Append(columnCurrent.Column.GetName + " AS " + columnCurrent.Name);
                    }
                   
                }
                return stringBuilder.ToString();
            }
            return " * ";

        }
    }
}
