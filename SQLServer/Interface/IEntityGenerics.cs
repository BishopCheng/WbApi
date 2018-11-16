using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Data;

namespace SQLServer
{
    /// <summary>
    /// 实体泛型接口
    /// 作者：程淮榕
    /// 时间：2018-11-16
    /// </summary>
   internal interface IEntityGenerics<DB,T> where DB: IDataBase,new() where T: IEntity,new()
    {
        
        T t { get; }

        DB dB { get; }

        string connectionString { get; }

        string primaryKey { get; }

        string tableName { get; }

        string dataBase { get; }

        UpdateClip updateClip { get; set; }

        
    }
}
