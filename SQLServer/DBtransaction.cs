using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace SQLServer
{
    /// <summary>
    /// 事务操作类
    /// </summary>
     public class DBtransaction
    {
        private DbConnection dbConnection_ = null;
        private DbTransaction dbTransaction_ = null;

        public DbConnection DbConnection
        {
            get { return dbConnection_; }
            set { dbConnection_ = value; }
         
        }
        public DbTransaction DbTransaction
        {
            get { return dbTransaction_; }
            set { dbTransaction_ = value; }

        }

        /// <summary>
        /// 事务构造方法
        /// </summary>
        /// <param name="dbConnection"></param>
        public DBtransaction(DbConnection dbConnection)
        {
            dbConnection_ = dbConnection;
            if(dbConnection_.State != ConnectionState.Open) { dbConnection_.Open(); }
            dbTransaction_ = dbConnection_.BeginTransaction(IsolationLevel.Serializable);
        }

        /// <summary>
        /// 事务提交
        /// </summary>
        public void Commit()
        {
            dbTransaction_.Commit();
            dbConnection_.Close();
        }

        /// <summary>
        /// 事务回滚
        /// </summary>
        public void RollBack()
        {
            dbTransaction_.Rollback();
            dbConnection_.Close();
        }

        /// <summary>
        /// 事务销毁
        /// </summary>
        public void Dispose()
        {
            dbTransaction_.Dispose();
            dbConnection_.Close();

        }
    }
}
