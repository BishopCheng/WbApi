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

        int Update(UpdateClip updateClip, WhereClip whereClip);

        int Delete(object primaryValue, string userName, string changeBanth, ref DBtransaction dbtran);

        int Delete(object primaryValue, ref DBtransaction dbtran);

        int Delete(object primaryValue, string userName);

        int Delete(object primaryValue);

        int Delete(Collection<object> keys, string userName, string changeBanth, ref DBtransaction dtran);

        int Delete(Collection<object> keys, ref DBtransaction dbtran);

        int Delete(Collection<object> keys, string userName);

        int Delete(Collection<object> keys);

        int Delete(WhereClip whereClip, string userName);

        int Delete(WhereClip whereClip);

        DataTable GetDataTable(OrderByClip orderByClip, Dictionary<string, Dictionary<string, string>> dtConvert = null);

        DataTable GetDataTable(WhereClip whereClip, OrderByClip orderByClip, Dictionary<string, Dictionary<string, string>> dtConvert = null);

        PageData<DataTable> GetPageData(OrderByClip orderByClip, Dictionary<string, Dictionary<string, string>> dtConvert = null);

        PageData<DataTable> GetPageData(WhereClip whereClip, OrderByClip orderByClip, Dictionary<string, Dictionary<string, string>> dtConvert = null);

        string GetJsons(OrderByClip orderByClip, Dictionary<string, Dictionary<string, string>> dtConvert = null);

        string GetJsons(WhereClip whereClip, OrderByClip orderByClip, Dictionary<string, Dictionary<string, string>> dtConvert = null);

        string GetJsons(OrderByClip orderByClip, int pageIndex, int pageSize, Dictionary<string, Dictionary<string, string>> dtConvert = null);

        string GetJsons(WhereClip whereClip, OrderByClip orderByClip, int pageIndex, int pageSize, Dictionary<string, Dictionary<string, string>> dtConvert = null);

        List<T> GetList(OrderByClip orderByClip, Dictionary<string, Dictionary<string, string>> dtConvert = null);

        List<T> GetList(WhereClip whereClip, OrderByClip orderByClip, Dictionary<string, Dictionary<string, string>> dtConvert = null);

        PageData<T> GetList(OrderByClip orderByClip, int pageIndex, int pageSize, Dictionary<string, Dictionary<string, string>> dtConvert = null);

        PageData<T> GetList(WhereClip whereClip, OrderByClip orderByClip, int pageIndex, int pageSize, Dictionary<string, Dictionary<string, string>> dtConvert = null);

        int BanthInsert(List<T> tLst, string userName);

        int BanthInsert(List<T> tLst);

        int BanthInsert(List<T> tLst, string userName, string changeBanth, ref DBtransaction dbtran);

        int BanthInsert(List<T> tLst, ref DBtransaction dbtran);

        int BanthDelete(List<T> tLst, string userName);

        int BanthDelete(List<T> tLst);

        int BanthDelete(List<T> tLst, string userName, string changeBanth, ref DBtransaction dbtran);

        int BanthDelete(List<T> tLst, ref DBtransaction dbtran);

        int BanthUpdate(List<T> tLst, string userName);

        int BanthUpdate(List<T> tLst);

        int BanthUpdate(List<T> tLst, string userName, string changeBanth, ref DBtransaction dbtran);

        int BanthUpdate(List<T> tLst, ref DBtransaction dbtran);

        T Get(string primaryKey);

        T Get(WhereClip whereClip, OrderByClip orderByClip);

        string GetJson(string key);

        string GetJson(WhereClip whereClip, OrderByClip orderByClip);

        int IsExist(string key);

        int IsExist(WhereClip whereClip, OrderByClip orderByClip);

        int Count(WhereClip whereClip, OrderByClip orderByClip);

        decimal Sum(WhereClip whereClip, Column column);

       
    }
}
