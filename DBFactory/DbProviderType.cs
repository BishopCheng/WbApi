using System;
using System.Collections.Generic;
using System.Text;

namespace DBFactory
{
    /// <summary>
    /// 驱动类型
    /// </summary>
    public enum DbProviderType : byte
    {
        SqlServer,
        MySql,
        SQLite,
        Oracle,
        ODBC,
        OleDb,
        Firebird,
        PostgreSql,
        DB2,
        Informix,
        SqlServerCe
    }
}
