using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace SQLServer
{
    /// <summary>
    /// 列对象定义类
    /// 作者:程淮榕
    /// 时间：2018-11-09
    /// </summary>
    [Serializable]
    public class Column
    {
        /// <summary>
        /// 执行类
        /// </summary>
        private ExcuteImport excuteImport;

        /// <summary>
        /// 获取名称
        /// </summary>
        private string getName_;

        /// <summary>
        /// 名称
        /// </summary>
        private string name_;

        public string GetName { get { return getName_; } set { getName_ = value; } }

        public string Name { get { return name_; } set { name_ = value; } }

        public string ASC => GetName + " ASC";

        public string DESC => GetName + " DESC";

        public Column(){}

        public Column(string getName, ExcuteImport excuteImport_) {
            excuteImport = excuteImport_;
            getName_ = getName;
        }

        public Column(string getName,string name,ExcuteImport excuteImport_)
        {
            getName_ = getName;
            name_ = name;
            excuteImport = excuteImport_;
        }

        public string Link(Column column)
        {
            if (column != null)
            {
                return GetName + "=" + column.GetName;
            }
            return GetName + "=" + GetName;
        }

        public Column ToDate()
        {
            return new Column(string.Format(excuteImport.sqlSetting.Column_ToDate, GetName), excuteImport);
        }
        public Column ToDateTime()
        {
            return new Column(string.Format(excuteImport.sqlSetting.Column_ToDateTime, GetName), excuteImport);
        }
        public Column ToDateString()
        {
            return new Column(string.Format(excuteImport.sqlSetting.Column_ToDateString, GetName), excuteImport);
        }
        public Column ToDateTimeString()
        {
            return new Column(string.Format(excuteImport.sqlSetting.Column_ToDateTimeString, GetName), excuteImport);
        }
        public Column Length()
        {
            return new Column(string.Format(excuteImport.sqlSetting.Column_Length, GetName), excuteImport);
        }
        public Column SubString()
        {
            return new Column(string.Format(excuteImport.sqlSetting.Column_Substring, GetName), excuteImport);
        }
        public Column Replace()
        {
            return new Column(string.Format(excuteImport.sqlSetting.Column_Replace, GetName), excuteImport);
        }
        public Column Count()
        {
            return new Column(string.Format(excuteImport.sqlSetting.Column_Count, GetName), excuteImport);
        }
        public Column Sum()
        {
            return new Column(string.Format(excuteImport.sqlSetting.Column_Sum, GetName), excuteImport);
        }
        public Column Max()
        {
            return new Column(string.Format(excuteImport.sqlSetting.Column_Max, GetName), excuteImport);
        }
        public Column Min()
        {
            return new Column(string.Format(excuteImport.sqlSetting.Column_Min, GetName), excuteImport);
        }
        public ConditionItem CharNum(char c,int num)
        {
            ConditionItem conditionItem = new ConditionItem();
            conditionItem.sqlStr = string.Format(excuteImport.sqlSetting.Column_CharNum, GetName, GetName, excuteImport.sqlSetting.Flag, Name, excuteImport.sqlSetting.Flag, Name);
            ConditionItem conditionItem2 = conditionItem;
            conditionItem2.lstDbParmeters.Add(excuteImport.CreateDbParameter(excuteImport.sqlSetting.Flag + Name + "0", c));
            conditionItem2.lstDbParmeters.Add(excuteImport.CreateDbParameter(excuteImport.sqlSetting.Flag + Name + "1", num));
            return conditionItem2;
        }
        public new ConditionItem Equals(object value)
        {
            ConditionItem conditionItem = new ConditionItem();
            if(value == null)
            {
                //比对对象为空,则调用object_null方法
                conditionItem.sqlStr = string.Format(excuteImport.sqlSetting.ConditionItem_Equals_object_null, GetName);
                conditionItem.lstDbParmeters = null;
            }
            else
            {
                //比对对象不为空,则调用object_notnull方法
                conditionItem.sqlStr = string.Format(excuteImport.sqlSetting.ConditionItem_Equals_object, GetName,excuteImport.sqlSetting.Flag,Name);
                conditionItem.lstDbParmeters.Add(excuteImport.CreateDbParameter(excuteImport.sqlSetting.Flag + Name, value));
            }
            return conditionItem;
        }

        public ConditionItem NotEquals(object value)
        {
            ConditionItem conditionItem = new ConditionItem();
            if (value == null)
            {
                conditionItem.sqlStr = string.Format(excuteImport.sqlSetting.ConditonItem_NotEquals_object_null, GetName);
                conditionItem.lstDbParmeters = null;
            }
            else {
                conditionItem.sqlStr = string.Format(excuteImport.sqlSetting.ConditionItem_NotEquals_object, GetName, excuteImport.sqlSetting.Flag, Name);
                conditionItem.lstDbParmeters.Add(excuteImport.CreateDbParameter(excuteImport.sqlSetting.Flag + Name, value));
            }
            return conditionItem;
        }

        public ConditionItem In(Collection<object> value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            ConditionItem conditionItem = new ConditionItem();
            int count = value.Count;
            for (int i = 0; i < count; i++)
            {
                if (stringBuilder.Length > 0)
                {
                    stringBuilder.Append(",");  //如果值不为空,则加入逗号,准备插入条件
                }
                    stringBuilder.Append(excuteImport.sqlSetting.Flag + Name + i);
                    conditionItem.lstDbParmeters.Add(excuteImport.CreateDbParameter(excuteImport.sqlSetting.Flag + Name + i, value[i]));

                }
            conditionItem.sqlStr = string.Format(excuteImport.sqlSetting.ConditionItem_In_objects, GetName, stringBuilder.ToString());
            return conditionItem;

        }

        public ConditionItem In(object value)
        {
            ConditionItem conditionItem = new ConditionItem();
            conditionItem.sqlStr = string.Format(excuteImport.sqlSetting.ConditionItem_In_objects, GetName, excuteImport.sqlSetting.Flag, Name);
            conditionItem.lstDbParmeters.Add(excuteImport.CreateDbParameter(excuteImport.sqlSetting.Flag, value));
            return conditionItem;
        }
       
        public ConditionItem NotIn(Collection<object> value)
        {
            ConditionItem conditionItem = new ConditionItem();
            StringBuilder stringBuilder = new StringBuilder();
            int count = value.Count;
            for (int i = 0; i < count; i++)
            {
                if (stringBuilder.Length > 0)
                {
                    stringBuilder.Append(",");
                }
                stringBuilder.Append(excuteImport.sqlSetting.Flag + Name + i);
                conditionItem.lstDbParmeters.Add(excuteImport.CreateDbParameter(excuteImport.sqlSetting.Flag + Name + i, value[i]));
            }
            conditionItem.sqlStr = string.Format(excuteImport.sqlSetting.ConditionItem_NotIn_objects, GetName, stringBuilder.ToString());
            return conditionItem;
        }

        public ConditionItem NotIn(object value)
        {
            ConditionItem conditionItem = new ConditionItem();
            conditionItem.sqlStr = string.Format(excuteImport.sqlSetting.ConditionItem_NotIn_objects, GetName, excuteImport.sqlSetting.Flag, Name);
            conditionItem.lstDbParmeters.Add(excuteImport.CreateDbParameter(excuteImport.sqlSetting.Flag + Name, value));
            return conditionItem;
        }

        public ConditionItem Contains(string value)
        {
            ConditionItem conditionItem = new ConditionItem();
            conditionItem.sqlStr = string.Format(excuteImport.sqlSetting.ConditionItem_Contains, GetName, excuteImport.sqlSetting.Flag, Name);
            conditionItem.lstDbParmeters.Add(excuteImport.CreateDbParameter(excuteImport.sqlSetting.Flag + Name, "%" + value + "%"));
            return conditionItem;
        }

        public ConditionItem NotContains(string value)
        {
            ConditionItem conditionItem = new ConditionItem();
            conditionItem.sqlStr = string.Format(excuteImport.sqlSetting.ConditonItem_NotContains, GetName, excuteImport.sqlSetting.Flag, Name);
            conditionItem.lstDbParmeters.Add(excuteImport.CreateDbParameter(excuteImport.sqlSetting.Flag + Name, "%" + value + "%"));
            return conditionItem;
        }

        public ConditionItem StartWith(string value)
        {
            ConditionItem conditionItem = new ConditionItem();
            conditionItem.sqlStr = string.Format(excuteImport.sqlSetting.ConditionItem_StartWith, GetName, excuteImport.sqlSetting.Flag, Name);
            conditionItem.lstDbParmeters.Add(excuteImport.CreateDbParameter(excuteImport.sqlSetting.Flag + Name, value+"%"));
            return conditionItem;
        }

        public ConditionItem NotStartWith(string value)
        {
            ConditionItem conditionItem = new ConditionItem();
            conditionItem.sqlStr = string.Format(excuteImport.sqlSetting.ConditionItem_NotStartWith, GetName, excuteImport.sqlSetting.Flag, Name);
            conditionItem.lstDbParmeters.Add(excuteImport.CreateDbParameter(excuteImport.sqlSetting.Flag + Name, value + "%"));
            return conditionItem;
        }

        public ConditionItem EndWith(string value)
        {
            ConditionItem conditionItem = new ConditionItem();
            conditionItem.sqlStr = string.Format(excuteImport.sqlSetting.ConditionItem_EndWith, GetName, excuteImport.sqlSetting.Flag, Name);
            conditionItem.lstDbParmeters.Add(excuteImport.CreateDbParameter(excuteImport.sqlSetting.Flag + Name,  "%" + value));
            return conditionItem;
        }

        public ConditionItem NotEndWith(string value)
        {
            ConditionItem conditionItem = new ConditionItem();
            conditionItem.sqlStr = string.Format(excuteImport.sqlSetting.ConditionItem_NotEndWith, GetName, excuteImport.sqlSetting.Flag, Name);
            conditionItem.lstDbParmeters.Add(excuteImport.CreateDbParameter(excuteImport.sqlSetting.Flag + Name, "%" + value));
            return conditionItem;
        }

        public ConditionItem Larger(string value)
        {
            ConditionItem conditionItem = new ConditionItem();
            conditionItem.sqlStr = string.Format(excuteImport.sqlSetting.ConditionItem_Larger, GetName, excuteImport.sqlSetting.Flag, Name);
            conditionItem.lstDbParmeters.Add(excuteImport.CreateDbParameter(excuteImport.sqlSetting.Flag + Name, value));
            return conditionItem;
        }

        public ConditionItem Smaller(string value)
        {
            ConditionItem conditionItem = new ConditionItem();
            conditionItem.sqlStr = string.Format(excuteImport.sqlSetting.ConditionItem_Smaller, GetName, excuteImport.sqlSetting.Flag, Name);
            conditionItem.lstDbParmeters.Add(excuteImport.CreateDbParameter(excuteImport.sqlSetting.Flag + Name, value));
            return conditionItem;
        }

        public ConditionItem NotLarger(string value)
        {

        }
    }
}
