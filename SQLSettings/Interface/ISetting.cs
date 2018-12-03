using System;
using System.Collections.Generic;
using System.Text;

namespace SQLSettings { 
    /// <summary>
    /// SQL语句接口
    /// 作者：程淮榕
    /// 时间：2018-11-06
    /// </summary>
    public interface ISetting
    {
        string Flag
        {
            get;
        }

        /// <summary>
        /// 数据域
        /// </summary>
        string DateFiled_sql   
        {
            get;
        }

        /// <summary>
        /// 对象是否包含(sql语句)
        /// </summary>
        string ColumnExists_sql   
        {
            get;
        }

        /// <summary>
        /// 对象是否包含（表名）
        /// </summary>
        string ColumnExists_tableName  
        {
            get;
        }
        /// <summary>
        /// 对象是否包含（对象名）
        /// </summary>
        string ColumExists_columnName
        {
            get;
        }
        /// <summary>
        /// 获取最大ID（sql语句）
        /// </summary>
        string GetMaxID_sql
        {
            get;
        }
        /// <summary>
        /// 表是否包含（sql语句）
        /// </summary>
        string TabExists_sql
        {
            get;
        }
        /// <summary>
        /// 获取对象时间
        /// </summary>
        string Column_GetDate
        {
            get;
        }
        /// <summary>
        /// 获取服务器时间(sql语句)
        /// </summary>
        string GetServerDate_sql
        {
            get;
        }
        /// <summary>
        /// 写入点击(sql语句)
        /// </summary>
        string WriteClick_sql
        {
            get;
        }
        /// <summary>
        /// 批量删除(sql语句)
        /// </summary>
        string BantchDelete_sql
        {
            get;
        }
        /// <summary>
        /// 删除对象(sql语句)
        /// </summary>
        string DeleteModel_sql
        {
            get;
        }
        /// <summary>
        /// 删除对象(从集合中)
        /// </summary>
        string DeleteModel_sql_In
        {
            get;
        }
        /// <summary>
        /// 删除对象（主键）
        /// </summary>
        string DeleteModel_PrimaryKey
        {
            get;
        }
        /// <summary>
        /// 删除对象(主键列表)
        /// </summary>
        string DeleteModel_primaryKeyList
        {
            get;
        }
        /// <summary>
        /// 删除对象（sql语句,通过WhereClip）
        /// </summary>
        string DeleteModel_sql_WhereClip
        {
            get;
        }
        /// <summary>
        /// 选取首个对象(sql语句)
        /// </summary>
        string First_sql
        {
            get;
        }

        /// <summary>
        /// 选取最后一个对象(sql语句)
        /// </summary>
        string Last_sql
        {
            get;
        }

        /// <summary>
        /// 插入对象
        /// </summary>
        string Insert_sql
        {
            get;
        }
        /// <summary>
        /// 更新（sql语句）
        /// </summary>
        string Update_sql
        {
            get;
        }
        /// <summary>
        /// 是否包含(sql语句)
        /// </summary>
        string IsExist_sql
        {
            get;
        }
        /// <summary>
        /// 是否包含(sql语句)
        /// </summary>
        string IsExist_sql_WhereClip
        {
            get;
        }
        /// <summary>
        /// 计数(sql语句)
        /// </summary>
        string Count_sql
        {
            get;
        }
        /// <summary>
        /// 计数（sql语句，whereClip方式）
        /// </summary>
        string Count_sql_WhereClip
        {
            get;
        }
        /// <summary>
        /// 计数(sql语句,WhereClip方式,Column对象)
        /// </summary>
        string Count_sql_WhereClip_Column
        {
            get;
        }
        /// <summary>
        /// 加和（sql语句）
        /// </summary>
        string Sum_sql
        {
            get;
        }
        /// <summary>
        /// 选取（sql语句）
        /// </summary>
        string Select_sql
        {
            get;
        }
        /// <summary>
        /// 选取(全部)
        /// </summary>
        string Select_all
        {
            get;
        }
        /// <summary>
        /// where关键字(sql语句)
        /// </summary>
        string SQL_where
        {
            get;
        }
        /// <summary>
        /// orderby关键字(sql语句)
        /// </summary>
        string SQL_orderby
        {
            get;
        }
        /// <summary>
        /// groupby关键字(sql语句)
        /// </summary>
        string SQL_groupby
        {
            get;
        }
        /// <summary>
        /// and关键字(sql语句)
        /// </summary>
        string SQL_and
        {
            get;
        }
        /// <summary>
        /// 全部搜索(sql语句数量)
        /// </summary>
        string FullSearch_sqlCount
        {
            get;
        }
        /// <summary>
        /// 全部搜索(sql语句)
        /// </summary>
        string FullSearch_sql
        {
            get;
        }
        /// <summary>
        /// 全部搜索(关键字)
        /// </summary>
        string FullSearch_SearchKey
        {
            get;
        }
        /// <summary>
        /// 连接(sql语句)
        /// </summary>
        string Join_sql
        {
            get;
        }
        /// <summary>
        /// 内连接(sql语句)
        /// </summary>
        string InnerJoin_sql
        {
            get;
        }
        /// <summary>
        /// 左连接（sql语句）
        /// </summary>
        string LeftJoin_sql
        {
            get;
        }
        /// <summary>
        /// 右连接(sql语句)
        /// </summary>
        string RightJoin_sql
        {
            get;
        }
        /// <summary>
        /// 全连接(sql语句)
        /// </summary>
        string FullJoin_sql
        {
            get;
        }
        /// <summary>
        /// 笛卡尔积(sql语句)
        /// </summary>
        string CrossJoin_sql
        {
            get;
        }
        /// <summary>
        /// 列对象长度
        /// </summary>
        string Column_Length
        {
            get;
        }
        /// <summary>
        /// 列对象(截取)
        /// </summary>
        string Column_Substring
        {
            get;
        }
        /// <summary>
        /// 列对象（替换）
        /// </summary>
        string Column_Replace
        {
            get;
        }
        /// <summary>
        /// 列对象（转换成日期）
        /// </summary>
        string Column_ToDate
        {
            get;
        }
        /// <summary>
        /// 列对象(转换成时间)
        /// </summary>
        string Column_ToDateTime
        {
            get;
        }
        /// <summary>
        /// 列对象（转换成日期，字符串格式）
        /// </summary>
        string Column_ToDateString
        {
            get;
        }
        /// <summary>
        /// 列对象(转换成时间,字符串格式)
        /// </summary>
        string Column_ToDateTimeString
        {
            get;
        }
        /// <summary>
        /// 获取列对象（转换成日期）
        /// </summary>
        string GetColumn_ToDate
        {
            get;
        }
        /// <summary>
        /// 获取列对象(转换成时间)
        /// </summary>
        string GetColumn_ToDateTime
        {
            get;
        }
        /// <summary>
        /// 获取列对象（转换成日期，字符串格式）
        /// </summary>
        string GetColumn_ToDateString
        {
            get;
        }
        /// <summary>
        /// 获取列对象(转换成时间,字符串格式)
        /// </summary>
        string GetColumn_ToDateTimeString
        {
            get;
        }
        /// <summary>
        /// 列对象(计数)
        /// </summary>
        string Column_Count
        {
            get;
        }
        /// <summary>
        /// 列对象(累加)
        /// </summary>
        string Column_Sum
        {
            get;
        }
        /// <summary>
        /// 列对象(最大值)
        /// </summary>
        string Column_Max
        {
            get;
        }
        /// <summary>
        /// 列对象(最小值)
        /// </summary>
        string Column_Min
        {
            get;
        }
        /// <summary>
        /// 列对象(指定字符的个数)
        /// </summary>
        string Column_CharNum
        {
            get;
        }
        /// <summary>
        /// 条件对象(相同，含空)
        /// </summary>
        string ConditionItem_Equals_object_null
        {
            get;
        }
        /// <summary>
        /// 条件对象（相同）
        /// </summary>
        string ConditionItem_Equals_object
        {
            get;
        }
        string ConditionItem_NotEquals_object
        {
            get;
        }
        string ConditonItem_NotEquals_object_null
        {
            get;
        }
        /// <summary>
        /// 条件对象(在集合中)
        /// </summary>
        string ConditionItem_In_object
        {
            get;
        }
        /// <summary>
        /// 条件对象（在集合中，多个）
        /// </summary>
        string ConditionItem_In_objects
        {
            get;
        }
        /// <summary>
        /// 条件对象(不在集合中)
        /// </summary>
        string ConditionItem_NotIn_object
        {
            get;
        }
        /// 条件对象(不在集合中,多个)
        /// </summary>
        string ConditionItem_NotIn_objects
        {
            get;
        }
        /// <summary>
        /// 条件对象(包含)
        /// </summary>
        string ConditionItem_Contains
        {
            get;
        }
        /// <summary>
        /// 条件对象(不包含)
        /// </summary>
        string ConditonItem_NotContains
        {
            get;
        }
        /// <summary>
        /// 条件对象（以...开头）
        /// </summary>
        string ConditionItem_StartWith
        {
            get;
        }
        /// <summary>
        /// 条件对象(不以...开头)
        /// </summary>
        string ConditionItem_NotStartWith
        {
            get;
        }
        /// <summary>
        /// 条件对象（以...结尾）
        /// </summary>
        string ConditionItem_EndWith
        {
            get;
        }
        /// <summary>
        /// 条件对象(不以...结尾)
        /// </summary>
        string ConditionItem_NotEndWith
        {
            get;
        }
        /// <summary>
        /// 条件对象(大于)
        /// </summary>
        string ConditionItem_Larger
        {
            get;
        }
        /// <summary>
        /// 条件对象(小于)
        /// </summary>
        string ConditionItem_Smaller
        {
            get;
        }
        /// <summary>
        /// 条件对象(不大于)
        /// </summary>
        string ConditionItem_NotLarger
        {
            get;
        }
        /// <summary>
        /// 条件对象(不小于)
        /// </summary>
        string ConditionItem_NotSmaller
        {
            get;
        }
        /// <summary>
        /// 条件对象(长度等于)
        /// </summary>
        string ConditionItem_LengthEquals
        {
            get;
        }
        /// <summary>
        /// 条件对象(长度大于)
        /// </summary>
        string ConditionItem_LengthLarger
        {
            get;
        }
        /// <summary>
        /// 条件对象(长度小于)
        /// </summary>
        string ConditionItem_LengthSmaller
        {
            get;
        }
        /// <summary>
        /// 条件对象(长度不大于)
        /// </summary>
        string ConditionItem_LengthNotLarger
        {
            get;
        }
        /// <summary>
        /// 条件对象(长度不小于)
        /// </summary>
        string ConditionItem_LengthNotSmaller
        {
            get;
        }
        /// <summary>
        /// 条件对象(在列之间)
        /// </summary>
        string ConditionItem_BetweenColumn
        {
            get;
        }
        /// <summary>
        /// 条件对象(在对象之间)
        /// </summary>
        string ConditionItem_BetweenObject
        {
            get;
        }
        List<string> Search_sql(string tableName, string selectFiled, string getJoin, string sqlWhereClip, string orderby, string groupByStr, int pageIndex, int pageSize, bool isAll, string index = "", int version = 2008);
    }
}
