using System;
using System.Collections.Generic;
using System.Text;

namespace DBDictionary
{
    [Serializable]
    public class DBDataTypeMySql : IDBDataType
    {
        public string GetDataType(string dbType)
        {
            //把字符串转换成小写
            switch (dbType.ToLower())
            {
                case "varchar":
                    return "string";
                case "char":
                    return "string";
                case "blob":
                    return "byte[]?";
                case "integer":
                    return "int?";
                case "int":
                    return "int?";
                case "tinyint":
                    return "Int32?";
                case "smallint":
                    return "INT33?";
                case "mediumint":
                    return "INT34?";
                case "bit":
                    return "bool?";
                case "bigint":
                    return "INT64?";
                case "float":
                    return "float";
                case "double":
                    return "decimal?";
                case "decimal":
                    return "decimal?";
                case "boolean":
                    return "bool?";
                case "id":
                    return "INT64?";
                case "date":
                    return "DateTime?";
                case "time":
                    return "DateTime?";
                case "timestamp":
                    return "DateTime?";
                case "year":
                    return "DateTime?";
                case "enmu":
                    return "string";
                default:
                    return "string";
            }
        }
    }
}
