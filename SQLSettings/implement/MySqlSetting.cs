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

        string ISetting.First_sql { get { return "SELECT * FROM {0}{1} LIMIT 1"; } }

        string ISetting.Last_sql { get { return "SELECT * FROM {0}{1} ORDER BY object_id DESC LIMIT 1"; } }

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

        string ISetting.Column_ToDate { get { return "STR_TO_DATE({0}, '%Y-%m-%d')"; } }

        string ISetting.Column_ToDateTime { get { return "STR_TO_DATE({0}, '%Y-%m-%d %H:%i:%s')"; } }

        string ISetting.Column_ToDateString { get { return "DATE_FORMAT({0}, '%Y-%m-%d')"; } }

        string ISetting.Column_ToDateTimeString { get { return "DATE_FORMAT({0}, '%Y-%m-%d %H:%i:%s')"; } }

        string ISetting.GetColumn_ToDate { get { return "STR_TO_DATE({0}, '%Y-%m-%d')"; } }

        string ISetting.GetColumn_ToDateTime { get { return "STR_TO_DATE({0}, '%Y-%m-%d %H:%i:%s')"; } }

        string ISetting.GetColumn_ToDateString { get { return "DATE_FORMAT({0}, '%Y-%m-%d')"; } }

        string ISetting.GetColumn_ToDateTimeString { get { return "DATE_FORMAT({0}, '%Y-%m-%d %H:%i:%s')"; } }

        string ISetting.Column_Count { get { return "Count({0})"; } }

        string ISetting.Column_Sum { get { return "Sum({0})"; } }

        string ISetting.Column_Max { get { return "Max({0})"; } }

        string ISetting.Column_Min { get { return "Min({0})"; } }

        string ISetting.Column_CharNum { get { return "LENGTH({0})-LENGTH(REPLACE({1},{2}{3}0,''))={4}{5}1"; } }

        string ISetting.ConditionItem_Equals_object_null { get { return " {0} is null "; } }

        string ISetting.ConditionItem_Equals_object { get { return " {0}={1}{2 }"; } }

        string ISetting.ConditionItem_In_object { get { return " {0} IN ({1})"; } }

        string ISetting.ConditionItem_In_objects { get { return " {0} IN ({1})"; } }
        string ISetting.CondtionItem_NotIn_object { get { return " {0} NOT IN ({1})"; } }
        string ISetting.CondtionItem_NotIn_objects { get { return " {0} NOT IN ({1})"; } }

        string ISetting.ConditionItem_Contains { get { return " {0} LIKE {1}{2}"; } }

        string ISetting.ConditonItem_NotContains { get { return " NOT {0} LIKE {1}{2}"; } }

        string ISetting.ConditionItem_StartWith { get { return " {0} LIKE {1}{2}"; } }


        string ISetting.ConditionItem_NotStartWith { get { return " NOT {0} LIKE {1}{2}"; } }


        string ISetting.ConditionItem_EndWith { get { return " {0} LIKE {1}{2}"; } }

        string ISetting.ConditionItem_NotEndWith { get { return " NOT {0} LIKE {1}{2}"; } }

        string ISetting.ConditionItem_Larger { get { return " {0}>{1}{2}"; } }
        string ISetting.ConditionItem_Smaller { get { return " {0}<{1}{2}"; } }

        string ISetting.ConditionItem_NotLarger { get { return " {0}<={1}{2}"; } }

        string ISetting.ConditionItem_NotSmaller { get { return " {0}>={1}{2}"; } }

        string ISetting.ConditionItem_LengthEquals { get { return " LENGTH({0})={1}{2}"; } }

        string ISetting.ConditionItem_LengthLarger { get { return " LENGTH({0})>{1}{2}"; } }

        string ISetting.ConditionItem_LengthSmaller { get { return " LENGTH({0})<{1}{2}"; } }

        string ISetting.ConditionItem_LengthNotLarger { get { return " LENGTH({0})<={1}{2}"; } }

        string ISetting.ConditionItem_LengthNotSmaller { get { return " LENGTH(0)>={1}{2}"; } }

        string ISetting.ConditionItem_BetweenColumn { get { return " {0} BETWEEN {1} AND {2}"; } }

        string ISetting.ConditionItem_BetweenObject { get { return " {0} BETWEEN {1}{2}0 AND {3}{4}1"; } }

        List<string> ISetting.Search_sql(string tableName, string selectFiled, string getJoin, string sqlWhereClip, string orderby, string groupByStr, int pageIndex, int pageSize, bool isAll, string index, int version)
        {
            //如果Group By字段不为空,在语句中加入group by 条件
            if (!string.IsNullOrEmpty(groupByStr))
            {
                groupByStr = " Group By " + groupByStr;
            }
            List<string> list; //定义sql语句集合
            if (!isAll)  //带条件搜索
            {
                list = new List<string>();
                list.Add("SELECT COUNT(0) FROM " + tableName + getJoin + " WHERE " + sqlWhereClip);
                list.Add("SELECT " + selectFiled + " FROM " + tableName + getJoin + " WHERE " + sqlWhereClip + " ORDER BY " + orderby + groupByStr + " LIMIT " + (pageIndex - 1) * pageSize + "," + pageSize);
                return list;
            }
            //不带搜索条件
            list = new List<string>();
            list.Add("SELECT COUNT(0) FROM " + tableName + getJoin);
            list.Add("SELECT " + selectFiled + " FROM " + tableName + getJoin + " ORDER BY " + orderby + groupByStr + " LIMIT " + (pageIndex - 1) * pageSize + "," + pageSize);
            return list;
        }
    }
}
