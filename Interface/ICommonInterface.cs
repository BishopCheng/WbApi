using System;
using System.Collections.Generic;
using System.Data.Common;

namespace ApiServer.Interface
{
    /// <summary>
    /// 通用接口
    /// 作者：程淮榕
    /// 时间：2018-09-20
    /// </summary>
    public interface ICommonInterface
    {
        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="o">实体</param>
        /// <returns></returns>
        int CreateData(object o);

        /// <summary>
        /// 新增记录(记录作者)
        /// </summary>
        /// <param name="o">实体</param>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        int CreateData(object o, string userName);

        /// <summary>
        /// 新增记录(记录时间)
        /// </summary>
        /// <param name="o"> 实体</param>
        /// <param name="dtInsert">操作时间</param>
        /// <returns></returns>
        int CreateData(object o, DateTime dtInsert);

        /// <summary>
        /// 新增记录(记录作者和时间)
        /// </summary>
        /// <param name="o"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        int CreateData(object o, string userName,DateTime dtInsert);


       /// <summary>
       /// 批量新增记录
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="objectList">记录列表</param>
       /// <param name="dbtran">执行事务</param>
       /// <returns></returns>
        int BantchCreateData<T>(List<T> objectList, ref DbTransaction dbtran) where T : class;

        /// <summary>
        /// 批量新增记录(记录作者)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectList">记录列表</param>
        /// <param name="userName">用户名</param>
        /// <param name="dbtran">执行事务</param>
        /// <returns></returns>
        int BantchCreateData<T>(List<T> objectList, string userName, ref DbTransaction dbtran) where T : class;

        /// <summary>
        /// 批量新增记录(记录时间)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectList">记录列表</param>
        /// <param name="dtInsert">记录时间</param>
        /// <param name="dbtran">执行事务</param>
        /// <returns></returns>
        int BantchCreateData<T>(List<T> objectList, DateTime dtInsert, ref DbTransaction dbtran) where T : class;

        /// <summary>
        ///  批量新增记录(记录作者和时间)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectList"></param>
        /// <param name="dtInsert"></param>
        /// <param name="dbtran"></param>
        /// <returns></returns>
        int BantchCreateData<T>(List<T> objectList, DateTime dtInsert, string userName, ref DbTransaction dbtran) where T : class;



        /// <summary>
        /// 获取记录
        /// </summary>
        /// <param name="key">索引关键字</param>
        /// <returns></returns>
        T GetData<T>(string key) where T:class;


        /// <summary>
        /// 获取多条记录列表
        /// </summary>
        /// <typeparam name="T">记录类型</typeparam>
        /// <param name="key">索引关键字</param>
        /// <returns></returns>
        List<T> GetList<T>(string key) where T : class;

        /// <summary>
        /// 分页获取多条记录列表
        /// </summary>
        /// <typeparam name="T">记录类型</typeparam>
        /// <param name="key">索引关键字</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        List<T> GetList<T>(string key, int pageIndex, int pageSize) where T : class;

       

    }
}
