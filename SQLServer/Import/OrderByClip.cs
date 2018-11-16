using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.Common;

namespace SQLServer
{
    /// <summary>
    /// 排列条件类
    /// 作者：程淮榕
    /// 时间：2018-10-26
    /// </summary>
    public class OrderByClip:Collection<ItemStruct>
    {
        public OrderByClip AddClip(Column column,object name)
        {
            Add(new ItemStruct(column, name));
            return this;
        }

        public OrderByClip ClearClip()
        {
            this.Clear();
            return this;
        }
        
        public void GetPartmeterString(ExcuteImport excuteImport,ref string orderBySql,ref List<DbParameter> dbParameters)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (IEnumerator<ItemStruct>IEnumerator = GetEnumerator())
            {
                while (IEnumerator.MoveNext())
                {
                    ItemStruct col = IEnumerator.Current;
                    if (stringBuilder.Length <= 0)
                    {
                        stringBuilder.Append(", ");
                    }
                    stringBuilder.Append(col.Column.GetName);
                    stringBuilder.Append(excuteImport.sqlSetting.Flag + col.Column.GetName);
                    dbParameters.Add(excuteImport.CreateDbParameter(excuteImport.sqlSetting.Flag + col.Column.GetName, col.Value));
                }
              
            }
            orderBySql = stringBuilder.ToString(); 
        }
    }
}
