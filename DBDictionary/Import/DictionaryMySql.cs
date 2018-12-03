﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DBDictionary
{
    /// <summary>
    /// 数据库SQL字典实现类
    /// </summary>
    public class DictionaryMySql : IDBDictionarySql
    {
        private string dbName;

        public string DBName
        {
            get
            {
                return dbName;
            }
            set
            {
                dbName = value;
            }
        }


        public string GetProcedureParams => "SELECT ORDINAL_POSITION 参数序号, SPECIFIC_NAME 存储过程编码, PARAMETER_MODE 参数取向,PARAMETER_NAME 字段名, DATA_TYPE 类型,CHARACTER_OCTET_LENGTH 占用字节数, (CASE WHEN CHARACTER_MAXIMUM_LENGTH IS NULL THEN NUMERIC_PRECISION ELSE CHARACTER_MAXIMUM_LENGTH END) 长度, NUMERIC_SCALE 小数位数 FROM INFORMATION_SCHEMA.PARAMETERS WHERE SPECIFIC_SCHEMA = '" + DBName + "' AND  SPECIFIC_NAME IN (SELECT SPECIFIC_NAME FROM MYSQL.PROC WHERE DB='" + DBName + "' AND `TYPE`='PROCEDURE') ORDER BY SPECIFIC_NAME,ORDINAL_POSITION; ";

        public string GetProcedures => "SELECT SPECIFIC_NAME 存储过程编码, NAME 存储过程名称 FROM MYSQL.PROC WHERE DB='" + DBName + "' AND `TYPE`='PROCEDURE' ORDER BY NAME;";

        public string GetTableFields => "SELECT TABLE_NAME 表编码,ORDINAL_POSITION 字段序号,COLUMN_NAME 字段名, '0' 标识, (CASE WHEN COLUMN_KEY = 'PRI' THEN '1' ELSE '0' END) 主键,DATA_TYPE 类型, CHARACTER_OCTET_LENGTH 占用字节数, (CASE WHEN CHARACTER_MAXIMUM_LENGTH IS NULL THEN NUMERIC_PRECISION ELSE CHARACTER_MAXIMUM_LENGTH END) 长度, NUMERIC_SCALE 小数位数, (CASE WHEN IS_NULLABLE = 'YES' THEN '1' ELSE '0' END) 允许空,COLUMN_DEFAULT 默认值, COLUMN_COMMENT 说明,'' 数据源  FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = '" + DBName + "' AND  TABLE_NAME IN (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA='" + DBName + "' AND TABLE_TYPE='BASE TABLE') ORDER BY TABLE_NAME,ORDINAL_POSITION ";

        public string GetTables => "SELECT TABLE_NAME 表编码, TABLE_NAME 表名称 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA='" + DBName + "' AND TABLE_TYPE='BASE TABLE' ORDER BY TABLE_NAME;";

        public string GetViewFields => "SELECT TABLE_NAME 视图编码,ORDINAL_POSITION 字段序号,COLUMN_NAME 字段名, '0' 标识, (CASE WHEN COLUMN_KEY = 'PRI' THEN '1' ELSE '0' END) 主键,DATA_TYPE 类型, CHARACTER_OCTET_LENGTH 占用字节数, (CASE WHEN CHARACTER_MAXIMUM_LENGTH IS NULL THEN NUMERIC_PRECISION ELSE CHARACTER_MAXIMUM_LENGTH END) 长度, NUMERIC_SCALE 小数位数, (CASE WHEN IS_NULLABLE = 'YES' THEN '1' ELSE '0' END) 允许空,COLUMN_DEFAULT 默认值, COLUMN_COMMENT 说明,'' 数据源  FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = '" + DBName + "' AND  TABLE_NAME IN (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA='" + DBName + "' AND TABLE_TYPE='VIEW') ORDER BY TABLE_NAME,ORDINAL_POSITION";

        public string GetViews => "SELECT TABLE_NAME 视图编码,TABLE_NAME 视图名称 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA='" + DBName + "' AND TABLE_TYPE='VIEW' ORDER BY TABLE_NAME;";
    }
}
