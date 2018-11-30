using System;
using System.Collections.Generic;
using System.Text;

namespace DBDictionary
{
    /// <summary>
    /// 数据库字典SQL语句操作接口
    /// </summary>
    public interface IDBDictionarySql
    {
        /// <summary>
        /// 数据库
        /// </summary>
        string DBName { get; }

        /// <summary>
        /// 获取表单
        /// </summary>
        string GetTables { get; }

        string GetTableFields { get; }

        /// <summary>
        /// 获取视图
        /// </summary>
        string GetViews { get; }

        string GetViewFields { get; }

        /// <summary>
        /// 获取存储过程
        /// </summary>
        string GetProcedures { get; }

        string GetProcedureParams { get; }
    }
}
