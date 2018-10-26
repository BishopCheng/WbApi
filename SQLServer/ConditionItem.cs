using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;

namespace SQLServer
{
    /// <summary>
    /// 执行参数实体类
    /// 作者：程淮榕
    /// 时间：2018-10-26
    /// </summary>
    public  class ConditionItem
    {
        private string sqlStr_;

        private List<DbParameter> lstDbParmeters_ = new List<DbParameter>();

        public string sqlStr
        {
            get { return sqlStr_; }
            set { this.sqlStr_ = value; }
        }

        public List<DbParameter> lstDbParmeters
        {
            get { return lstDbParmeters_; }
            set { this.lstDbParmeters_ = value; }
        }

    }
}
