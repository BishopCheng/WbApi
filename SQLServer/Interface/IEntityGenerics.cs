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

        int BanthInsert(List<T> tList, ref DBtransaction dbtran);

        int BanthUpdate(List<T> tList, ref DBtransaction dbtran);

        int BanthDelete(List<T> tList, ref DBtransaction dbtran);

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
    }
}
