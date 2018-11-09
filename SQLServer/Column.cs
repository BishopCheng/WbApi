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
         
    }
}
