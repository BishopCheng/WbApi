using System;
using System.Collections.Generic;


namespace SQLSettings
{
    /// <summary>
    /// MicorsoftSQLServer数据库接口实现
    /// </summary>
    public class MsSQLSeverSetting : ISetting
    {
        string ISetting.Flag
        {
            get
            {
                return "@";
            }
        }

        string ISetting.DateFiled_sql { get{return "{0}"; } }

        string ISetting.ColumnExists_sql { get { return "select count(*) from systemcolumns where [id]=object_id(?tableName) and [name]=?ColumnName"; } }

        string ISetting.ColumnExists_tableName { get { return "?tableName"; } }

        string ISetting.ColumExists_columnName { get { return "?columnName"; } }

        string ISetting.GetMaxID_sql { get { return "select max({0}) from ({1})"; } }

        //待定
        string ISetting.TabExists_sql => throw new NotImplementedException();

        string ISetting.Column_GetDate { get { return "getdate()"; } }

        string ISetting.GetServerDate_sql { get { return "select convert(char(10),getdate(),120)"; } }

        string ISetting.WriteClick_sql { get { return "UPDATE {0} SET {1}={2}+{1} WHERE {3}={4}"; } }

        string ISetting.BantchDelete_sql { get { return "DELETE {0} WHERE {1}={2}"; } }

        string ISetting.DeleteModel_sql { get { return "DELETE {0} WHERE {1}=?PrimaryKey"; } }

        string ISetting.DeleteModel_sql_In { get { return "DELETE {0} WHERE {1} IN {2}"; } }

        string ISetting.DeleteModel_PrimaryKey { get { return "?PrimaryKey"; } }

        string ISetting.DeleteModel_primaryKeyList { get { return "?PrimaryKeyList"; } }

        string ISetting.DeleteModel_sql_WhereClip { get { return "DELETE FROM {0} WHERE {1}"; } }

        string ISetting.First_sql { get { return "SELECT TOP (1) * FROM {0}{1}"; } }

        string ISetting.Last_sql { get { return "SELECT TOP (1) * FROM {0}{1} DESC"; } }

        string ISetting.Insert_sql { get { return "INSERT {0} {1}"; } }

        string ISetting.Update_sql { get { return "UPDATE {0} {1} WHERE {2}"; } }

        string ISetting.IsExist_sql { get { return "" } }

        string ISetting.IsExist_sql_WhereClip => throw new NotImplementedException();

        string ISetting.Count_sql => throw new NotImplementedException();

        string ISetting.Count_sql_WhereClip => throw new NotImplementedException();

        string ISetting.Count_sql_WhereClip_Column => throw new NotImplementedException();

        string ISetting.Sum_sql => throw new NotImplementedException();

        string ISetting.Select_sql => throw new NotImplementedException();

        string ISetting.Select_all => throw new NotImplementedException();

        string ISetting.SQL_where => throw new NotImplementedException();

        string ISetting.SQL_orderby => throw new NotImplementedException();

        string ISetting.SQL_groupby => throw new NotImplementedException();

        string ISetting.SQL_and => throw new NotImplementedException();

        string ISetting.FullSearch_sqlCount => throw new NotImplementedException();

        string ISetting.FullSearch_sql => throw new NotImplementedException();

        string ISetting.FullSearch_SearchKey => throw new NotImplementedException();

        string ISetting.Join_sql => throw new NotImplementedException();

        string ISetting.InnerJoin_sql => throw new NotImplementedException();

        string ISetting.LeftJoin_sql => throw new NotImplementedException();

        string ISetting.RightJoin_sql => throw new NotImplementedException();

        string ISetting.FullJoin_sql => throw new NotImplementedException();

        string ISetting.CrossJoin_sql => throw new NotImplementedException();

        string ISetting.Column_Length => throw new NotImplementedException();

        string ISetting.Column_Substring => throw new NotImplementedException();

        string ISetting.Column_Replace => throw new NotImplementedException();

        string ISetting.Column_ToDate => throw new NotImplementedException();

        string ISetting.Column_ToDateTime => throw new NotImplementedException();

        string ISetting.Column_ToDateString => throw new NotImplementedException();

        string ISetting.Column_ToDateTimeString => throw new NotImplementedException();

        string ISetting.GetColumn_ToDate => throw new NotImplementedException();

        string ISetting.GetColumn_ToDateTime => throw new NotImplementedException();

        string ISetting.GetColumn_ToDateString => throw new NotImplementedException();

        string ISetting.GetColumn_ToDateTimeString => throw new NotImplementedException();

        string ISetting.Column_Count => throw new NotImplementedException();

        string ISetting.Column_Sum => throw new NotImplementedException();

        string ISetting.Column_Max => throw new NotImplementedException();

        string ISetting.Column_Min => throw new NotImplementedException();

        string ISetting.Column_CharNum => throw new NotImplementedException();

        string ISetting.ConditionItem_Equals_object_null => throw new NotImplementedException();

        string ISetting.ConditionItem_Equals_object => throw new NotImplementedException();

        string ISetting.ConditionItem_In_object => throw new NotImplementedException();

        string ISetting.ConditionItem_In_objects => throw new NotImplementedException();

        string ISetting.ConditionItem_Contains => throw new NotImplementedException();

        string ISetting.ConditonItem_NotContains => throw new NotImplementedException();

        string ISetting.ConditionItem_StartWith => throw new NotImplementedException();

        string ISetting.ConditionItem_NotStartWith => throw new NotImplementedException();

        string ISetting.ConditionItem_EndWith => throw new NotImplementedException();

        string ISetting.ConditionItem_NotEndWith => throw new NotImplementedException();

        string ISetting.ConditionItem_Larger => throw new NotImplementedException();

        string ISetting.ConditionItem_Smaller => throw new NotImplementedException();

        string ISetting.ConditionItem_NotLarger => throw new NotImplementedException();

        string ISetting.ConditionItem_NotSmaller => throw new NotImplementedException();

        string ISetting.ConditionItem_LengthEquals => throw new NotImplementedException();

        string ISetting.ConditionItem_LengthLarger => throw new NotImplementedException();

        string ISetting.ConditionItem_LengthSmaller => throw new NotImplementedException();

        string ISetting.ConditionItem_LengthNotLarger => throw new NotImplementedException();

        string ISetting.ConditionItem_LengthNotSmaller => throw new NotImplementedException();

        string ISetting.ConditionItem_BetweenColumn => throw new NotImplementedException();

        string ISetting.ConditionItem_BetweenObject => throw new NotImplementedException();

        string ISetting.Last_sql => throw new NotImplementedException();

        string ISetting.ConditionItem_NotEquals_object => throw new NotImplementedException();

        string ISetting.ConditonItem_NotEquals_object_null => throw new NotImplementedException();

        string ISetting.ConditionItem_NotIn_object => throw new NotImplementedException();

        string ISetting.ConditionItem_NotIn_objects => throw new NotImplementedException();

        List<string> ISetting.Search_sql(string tableName, string selectFiled, string getJoin, string sqlWhereClip, string orderby, string groupByStr, int pageIndex, int pageSize, bool isAll, string index, int version)
        {
            throw new NotImplementedException();
        }
    }
}
