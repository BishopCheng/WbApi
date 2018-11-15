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

        int Insert(T model, ref DBtransaction dBtransaction);

        int Insert(T model, string userName);

        int Insert(T model);

        int UpdateModel(T oldModel, T newModel, string userName, string changeBanth, ref DBtransaction dbtran);

        int UpdateModel(T newModel, ref DBtransaction dBtransaction);

        int Update(T oldModel, T newModel, string userName);

        int Update(T model);

        int Update(UpdateClip updateClip, WhereClip whereClip, string userName);



        
    }
}
