using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Data;
using SQLServer.Import;

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

        string ConnectionString { get; }

        string PrimaryKey { get; }

        string TableName { get; }

        string DataBase { get; }

        UpdateClip UpdateClip { get; set; }
        
        InsertClip InsertClip { get; set; }

        OrderByClip OrderByClip { get; set; }

        GroupByClip GroupByClip { get; set; }

        WhereClip WhereClip { get; set; }

        /// <summary>
        /// 其他类型实体
        /// </summary>
        List<string> OtherT { get; set; }

        /// <summary>
        /// 跳过数量
        /// </summary>
        int SkipNum { get; set; }

        /// <summary>
        /// 获取数量
        /// </summary>
        int TakeNum { get; set; }
       
        int BanthInsert(List<T>tList);

        int BanthUpdate(List<T> tList);

        int BanthDelete(List<T> tList);

        int BanthInsert(List<T> tList,  DBtransaction dbtran);

        int BanthUpdate(List<T> tList,  DBtransaction dbtran);

        int BanthDelete(List<T> tList,  DBtransaction dbtran);

        int InsertModel(T t);

        int UpdateModel(T t);

        int DeleteModel(T t);

        /// <summary>
        /// 通过主键集合批量删除实体
        /// </summary>
        /// <param name="primaryKeyList"></param>
        /// <returns></returns>
        int DeleteModel(Collection<object> primaryKeyList);

        /// <summary>
        /// 通过主键删除单个实体
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        int DeleteModel(object primaryKey);

        int Insert(InsertClip InsertClip);

        int Update(UpdateClip UpdateClip, WhereClip WhereClip);

        int Delete(WhereClip whereClip);

        /// <summary>
        /// 表是否存在
        /// </summary>
        /// <returns></returns>
        bool IsTabExist();

        int GetColumnMaxID(Column column);

        bool IsExist(WhereClip whereClip);

        bool IsExist(object primaryKey);
       
        /// <summary>
        /// 条件统计
        /// </summary>
        /// <param name="whereClip"></param>
        /// <returns></returns>
        int Count(WhereClip whereClip);
        /// <summary>
        /// 条件统计列
        /// </summary>
        /// <param name="whereClip"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        int Count(WhereClip whereClip, Column column);

        int GetCountBySql(string sql, List<DbParameter> lstDbparameters);

        int InsertModel(T t, DBtransaction dbtran);

        int UpdateModel(T t, DBtransaction dbtran);

        int DeleteModel(T t, DBtransaction dbtran);

        int DeleteModel(Collection<object> primaryKeyList, DBtransaction dbtran);

        int DeleteModel(object primaryKey, DBtransaction dbtran);

        int Insert(InsertClip insertClip, DBtransaction dbtran);

        int Update(UpdateClip updateClip,WhereClip whereClip, DBtransaction dbtran);

        int Delete(WhereClip whereClip, DBtransaction dbtran);

        #region 构造函数
        EntityGenerics<DB,T>Select();

        EntityGenerics<DB, T>Select(SelectName selectName);

        EntityGenerics<DB, T>Join(IEntity OtherT);

        EntityGenerics<DB, T>InnerJoin(IEntity OtherT, Column A, Column B);

        EntityGenerics<DB, T>LeftJoin(IEntity OtherT, Column A, Column B);

        EntityGenerics<DB, T> RigthJoin(IEntity OtherT, Column A, Column B);

        EntityGenerics<DB, T> FullJoin(IEntity OtherT, Column A, Column B);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        T GetModel(object primaryKey);

        EntityGenerics<DB, T>SetOrderByClip(ItemStruct orderByClip);

        EntityGenerics<DB, T>SetOrderByClip(OrderByClip orderByClip);

        EntityGenerics<DB, T>SetWhereClip(ConditionItem whereClip);

        EntityGenerics<DB, T>SetWhereClip(WhereClip whereClip);

        EntityGenerics<DB, T>SetGroupByClip(Column GroupByClip);

        EntityGenerics<DB, T>SetGroupByClip(GroupByClip groupByClip);

        EntityGenerics<DB, T> GetByRange(int SkipNum, int takeNum);
        /// <summary>
        /// 循环获取集合
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> ToList();
        /// <summary>
        /// 获取分页集合
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        PageData<T> ToList(int PageSize, int PageIndex);
        /// <summary>
        /// 获取第一个元素
        /// </summary>
        /// <returns></returns>
        T ToFirst();
        /// <summary>
        /// 计数
        /// </summary>
        /// <returns></returns>
        int Count();
        /// <summary>
        /// 返回字符串类型
        /// </summary>
        /// <returns></returns>
        new string ToString();

        void ClearCondition();
        #endregion
    }
}
