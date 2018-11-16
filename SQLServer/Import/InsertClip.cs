using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.Common;

namespace SQLServer
{
    [Serializable]
    public  class InsertClip:Collection<ItemStruct>
    {
        public InsertClip AddClip(Column column,object name)
        {
            Add(new ItemStruct(column, name));
            return this;
        }

        public InsertClip ClearClip()
        {
            this.Clear();
            return this;
        }

        public void GetParameterString(ExcuteImport excuteImport,ref string insertSql,ref List<DbParameter>dbParameters)
        {
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder stringBuilder2 = new StringBuilder();
            using (IEnumerator<ItemStruct>enumerator = GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    ItemStruct itemCurrent = enumerator.Current;
                    if (stringBuilder.Length <= 0)
                    {
                        stringBuilder.Append("(");
                    }
                    else
                    {
                        stringBuilder.Append(", ");
                    }
                    stringBuilder.Append(itemCurrent.Column.GetName);
                    if (stringBuilder2.Length <= 0)
                    {
                        stringBuilder2.Append("VALUES( ");
                    }
                    else
                    {
                        stringBuilder2.Append(", ");
                    }
                    stringBuilder2.Append(excuteImport.sqlSetting.Flag + itemCurrent.Column.GetName);
                    dbParameters.Add(excuteImport.CreateDbParameter(excuteImport.sqlSetting.Flag + itemCurrent.Column.GetName, itemCurrent.Value));
                }
            }
            stringBuilder.Append(") ");
            stringBuilder2.Append(") ");
            stringBuilder.Append(stringBuilder2);
            insertSql = stringBuilder.ToString();

        }
    }
}
