using System;
using System.Collections.Generic;
using System.Text;

namespace SQLServer
{
    /// <summary>
    /// 比较对象类
    /// </summary>
    public class CompareEntity
    {
        /// <summary>
        /// 域名称
        /// </summary>
        private string fieldName;

        /// <summary>
        /// 改变值
        /// </summary>
        private string changeValue;

        /// <summary>
        /// 新值
        /// </summary>
        private string newValue;

        /// <summary>
        /// ID
        /// </summary>
        private string key;

        public string FieldName
        {
            get { return fieldName; }
            set { fieldName = value; }
        }
        public string ChangeValue
        {
            get { return changeValue; }
            set { changeValue = value; }
        }
        public string NewValue
        {
            get { return newValue; }
            set { newValue = value; }
        }
        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        public CompareEntity(){

       }

        public CompareEntity(string fieldName_, string changeValue_)
        {
            fieldName = fieldName_;
            changeValue = changeValue_;
        }
        public CompareEntity(string fieldName_, string changeValue_,string newValue_)
        {
            fieldName = fieldName_;
            changeValue = changeValue_;
            newValue = newValue_;
        }
        public CompareEntity(string fieldName_, string changeValue_,string newValue_,string key_)
        {
            fieldName = fieldName_;
            changeValue = changeValue_;
            newValue = newValue_;
            key = key_;
        }
    }
}
