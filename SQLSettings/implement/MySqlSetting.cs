using System;
using System.Collections.Generic;
using SQLSettings.Interface;

namespace SQLSettings.implement
{
    /// <summary>
    /// MySql数据库接口实现
    /// </summary>
    public class MySqlSetting : ISetting
    {
        string ISetting.Flag { get { return "?"; } }

        string ISetting.DateFiled_sql { get { return "{0}"; } }

        string ISetting.ColumnExists_sql { get { return "select count(*) from syscolumns where [id]=object_id(?tableName) and [name]=?columnName"; } }

        string ISetting.ColumnExists_tableName { get { return "?tableName"; } }

        string ISetting.ColumExists_columnName { get { return "?columnName"; } }

        string ISetting.GetMaxID_sql { get { return "select max({0}) from ({1})"; } }

        string ISetting.TabExists_sql { get { return "select count(*) from sysobjects where id=object_id(N'[{0}]') and OBJECTPROPERTY(id, N'IsUserTable') = 1"; } }

        string ISetting.Column_GetDate { get { return "now()"; } }

        string ISetting.GetServerDate_sql { get { return "select now() as datetime"; } }

        string ISetting.WriteClick_sql { get { return "UPDATE {0} SET {1}={2}+{1} WHERE {3}={4}"; } }

        string ISetting.BantchDelete_sql { get { return "DELETE FROM {0} WHERE {1}={2}"; } }

        string ISetting.DeleteModel_sql { get { return "DELETE FROM {0} WHERE {1}=?PrimaryKey"; } }

        string ISetting.DeleteModel_sql_In { get { return "DELETE FROM {0} WHERE {1} IN {2}"; } }

        string ISetting.DeleteModel_PrimaryKey { get { return "?PrimaryKey"; } }

        string ISetting.DeleteModel_primaryKeyList { get { return "?PrimaryKeyList"; } }

        string ISetting.DeleteModel_sql_WhereClip { get { return "DELETE FROM {0} WHERE {1}"; } }

        string ISetting.First_sql => throw new NotImplementedException();

        string ISetting.Insert_sql { get { return "INSERT {0} {1}"; } }

        string ISetting.Update_sql { get { return "UPDATE {0} {1} WHERE {2}"; } }

        string ISetting.IsExist_sql { get { return "SELECT COUNT(*) FROM {0} WHERE {1}=?{2}"; } }

        string ISetting.IsExist_sql_WhereClip { get { return "SELECT COUNT(*) FROM {0} WHERE {1}"; } }

        string ISetting.Count_sql { get { return "SELECT COUNT(*) as CountNum FROM {0}"; } }

        string ISetting.Count_sql_WhereClip { get { return "SELECT COUNT(*) as CountNum FROM {0} WHERE {1}"; } }

        string ISetting.Count_sql_WhereClip_Column { get { return "SELECT COUNT(distinct({0})) as CountNum FROM {1} WHERE {2}"; } }

        string ISetting.Sum_sql { get { return "SELECT SUM({0}) AS SUM FROM {1} WHERE {2}"; } }

        string ISetting.Select_sql { get { return "SELECT * FROM {0} WHERE {1}={2}"; } }

        string ISetting.Select_all { get { return " * "; } }

        string ISetting.SQL_where { get { return "WHERE"; } }

        string ISetting.SQL_orderby { get { return " ORDER BY "; } }

        string ISetting.SQL_groupby { get { return " GROUP BY "; } }
        string ISetting.SQL_and { get { return " AND "; } }

        string ISetting.FullSearch_sqlCount { get { return "SELECT count(*) FROM {0} WHERE freetext(*,?SearchKey)"; } }

        string ISetting.FullSearch_sql { get { return "SELECT {0} FROM (SELECT *,ROW_NUMBER() OVER(ORDER BY KEY_TBL.RANK DESC) AS RowNumber FROM {1} AS FT_TBL INNER JOIN FREETEXTTABLE({2},*,?SearchKey) AS KEY_TBL ON FT_TBL.{3} =KEY_TBL.[KEY]) AS T WHERE RowNumber between {4} and {5}"; } }

        string ISetting.FullSearch_SearchKey { get { return "?SearchKey"; } }

        string ISetting.Join_sql { get { return " ,{0} "; } }

        string ISetting.InnerJoin_sql { get { return " INNER JOIN {0} ON {1}={2} "; } }

        string ISetting.LeftJoin_sql { get { return " LEFT JOIN {0} ON {1}={2} "; } }

        string ISetting.RightJoin_sql { get { return " RIGHT JOIN {0} ON {1}={2} "; } }

        string ISetting.FullJoin_sql { get { return " FULL OUTER JOIN {0} ON {1}={2} "; } }

        string ISetting.CrossJoin_sql { get { return " CROSS JOIN {0} "; } }

        string ISetting.Column_Length { get { return "LENGTH({0})"; } }

        string ISetting.Column_Substring { get { return "SUBSTRING({0},{1},{2})"; } }

        string ISetting.Column_Replace { get { return "REPLACE({0},{1},{2})"; } }

        string ISetting.Column_ToDate { get { return "STR_TO_DATE({0},'%Y-%m-%d')"; } }

        string ISetting.Column_ToDateTime { get { return "STR_TO_DATE({0},'%Y-%m-%d %H:%i:%s')"; } }

        string ISetting.Column_ToDateString { get { return "DATE_FROMAT({0},'%Y-%m-%d')"; } }

        string ISetting.Column_ToDateTimeString { get { return "DATE_FORMAT({0},'%Y-%m-%d %H:%i:%s')"; } }

        string ISetting.GetColumn_ToDate => throw new NotImplementedException();

        string ISetting.GetColumn_ToDateTime => throw new NotImplementedException();

        string ISetting.GetColumn_ToDateString => throw new NotImplementedException();

        string ISetting.GetColumn_ToDateTimeString => throw new NotImplementedException();

        string ISetting.Column_Count { get { return "Count({0})"; } }

        string ISetting.Column_Sum { get { return "Sum({0})"; } }

        string ISetting.Column_Max { get { return "Max({0})"; } }

        string ISetting.Column_Min { get { return "Min({0})"; } }

        string ISetting.Column_CharNum { get { return "LENGTH({0})-LENGTH(REPLACE({1},{2}{3}0,''))={4}{5}1"; } }

        string ISetting.ConditionItem_Equals_object_null => throw new NotImplementedException();

        string ISetting.ConditionItem_Equals_object => throw new NotImplementedException();

        string ISetting.ConditionItem_In_object => throw new NotImplementedException();

        string ISetting.ConditionItem_In_objects => throw new NotImplementedException();

        string ISetting.CondtionItem_NotIn_object => throw new NotImplementedException();

        string ISetting.CondtionItem_NotIn_objects => throw new NotImplementedException();

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

        List<string> ISetting.Search_sql(string tableName, string selectFiled, string getJoin, string sqlWhereClip, string orderby, string groupByStr, int pageIndex, int pageSize, bool isAll, string index, int version)
        {
            throw new NotImplementedException();
        }
    }
}
