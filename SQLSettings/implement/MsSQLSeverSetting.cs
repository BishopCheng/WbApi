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

    }
}
