using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace SQLServer
{
    /// <summary>
    /// 实体类接口
    /// 作者:程淮榕
    /// 日期:2018-11-14
    /// </summary>
    [Serializable]
     public class IEntity
    {
        public virtual string TableName => "";

        public virtual string SqlTableName => "";

        public virtual string PrimaryKey => "";

        public virtual string OrderFiled => "";

        public virtual object PrimaryKeyValue => "";

        public virtual IEntity SetModel(DataRow dataRow)
        {
            return null;
        }

        public virtual object ColumnValue(string columnName)
        {
            return null;
        }


        public virtual void SetColumnValue(string columnName,object value)
        {
          
        }

        public virtual IEntity Copy()
        {
            return null;
        }

        public virtual bool HasColumn(string columnName)
        {
            return false;
        }
        public virtual Column GetColumn(string columnName)
        {
            return null;
        }
        public virtual List<CompareEntity>EntityCompare(IEntity newModel)
        {
            return null;
        }

        public virtual string GetInsertSql()
        {
            return null;
        }

        public virtual string GetUpdateSql()
        {
            return null;
        }

        public virtual string GetInsertPlate()
        {
            return null;
        }

        public virtual string GetUpdatePlate()
        {
            return null;
        }

        public virtual List<DbParameter> GetFullParmeters()
        {
            return null;
        }
    }
}
