using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections.ObjectModel;

namespace SQLServer
{
    /// <summary>
    /// 数据库与实体反射接口
    /// </summary>
    /// <typeparam name="DB"></typeparam>
    /// <typeparam name="T"></typeparam>
    public interface IDBService<DB,T> where DB:IDataBase, new()where T: IEntity,new()
    {
        int Insert(T model, string UserName, string ChangeBanth, ref DBtransaction dbtran);
    }
}
