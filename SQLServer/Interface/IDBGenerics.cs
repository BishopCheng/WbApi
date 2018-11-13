using System;
using System.Collections.Generic;
using System.Text;

namespace SQLServer
{
    /// <summary>
    /// 数据库反射接口
    /// </summary>
    internal interface IDBGenerics<DB> where DB: IDataBase, new()
    {
        /// <summary>
        /// 新建数据库
        /// </summary>
        /// <returns></returns>
        bool CreateDataBase();

        /// <summary>
        /// 删除数据库
        /// </summary>
        /// <returns></returns>
        bool DeleteDataBase();

        /// <summary>
        /// 是否存在数据库
        /// </summary>
        /// <returns></returns>
        bool IsExistDataBase();

        /// <summary>
        /// 事务开始
        /// </summary>
        /// <returns></returns>
        DBtransaction BeginTransaction();

        /// <summary>
        /// 事务结束
        /// </summary>
        void EndTransaction(DBtransaction dbtran);

        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        DateTime GetServerTime();

        /// <summary>
        /// 数据库更新
        /// </summary>
        /// <param name="saveFile"></param>
        /// <returns></returns>
        bool UpdateDataBase(string saveFile);

        /// <summary>
        /// 数据库覆盖
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        bool RecoverDataBase(string filePath);

    }
}
