using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Collections.ObjectModel;

namespace SQLServer
{
    /// <summary>
    /// 更新条件类
    /// </summary>
    [Serializable]
    public  class UpdateClip:Collection<ItemStruct>
    {
        public UpdateClip AddClip(Column column,object value)
        {
            Add(new ItemStruct(column, value));
            return this;
        }

        public UpdateClip ClearClip()
        {
            Clear();
            return this;
        }

        public void GetParamString(ExcuteImport excuteImport,ref string sqlupdateClip,ref List<DbParameter>lstdbParameters)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (IEnumerator<ItemStruct>enumerator = GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    ItemStruct itemcurrent = enumerator.Current;
                    if(stringBuilder.Length<=0)
                    {
                        stringBuilder.Append("SET ");
                    }
                    else
                    {
                        stringBuilder.Append(", ");
                    }
                    stringBuilder.Append(itemcurrent.Column.GetName + "=" + excuteImport.sqlSetting.Flag + itemcurrent.Column.Name);
                    lstdbParameters.Add(excuteImport.CreateDbParameter(excuteImport.sqlSetting.Flag + itemcurrent.Column.Name, itemcurrent.Value));
                }
                stringBuilder.Append(" ");
                sqlupdateClip = stringBuilder.ToString();
            }
        }
    }
}
