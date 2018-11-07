using System;
using System.Collections.Generic;
using System.Text;

namespace SQLSettings.Interface
{
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
        /// 选取首个对象(sql对象)
        /// </summary>
        string First_sql
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
    }
}
