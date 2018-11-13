using System;
using System.Collections.Generic;
using SQLSettings.Interface;

namespace SQLSettings.implement
{
    /// <summary>
    /// MicorsoftSQLServer数据库接口实现
    /// </summary>
    public class MsSQLSeverSetting:ISetting
    {
       string ISetting.Flag
        {
            get
            {
                return "@";
            }
        }

        string ISetting.DateFiled_sql => throw new NotImplementedException();

        string ISetting.ColumnExists_sql => throw new NotImplementedException();

        string ISetting.ColumnExists_tableName => throw new NotImplementedException();

        string ISetting.ColumExists_columnName => throw new NotImplementedException();

        string ISetting.GetMaxID_sql => throw new NotImplementedException();

        string ISetting.TabExists_sql => throw new NotImplementedException();

        string ISetting.Column_GetDate => throw new NotImplementedException();

        string ISetting.GetServerDate_sql => throw new NotImplementedException();

        string ISetting.WriteClick_sql => throw new NotImplementedException();

        string ISetting.BantchDelete_sql => throw new NotImplementedException();

        string ISetting.DeleteModel_sql => throw new NotImplementedException();

        string ISetting.DeleteModel_sql_In => throw new NotImplementedException();

        string ISetting.DeleteModel_PrimaryKey => throw new NotImplementedException();

        string ISetting.DeleteModel_primaryKeyList => throw new NotImplementedException();

        string ISetting.DeleteModel_sql_WhereClip => throw new NotImplementedException();

        string ISetting.First_sql => throw new NotImplementedException();

        string ISetting.Insert_sql => throw new NotImplementedException();

        string ISetting.Update_sql => throw new NotImplementedException();

        string ISetting.IsExist_sql => throw new NotImplementedException();

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
