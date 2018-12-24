using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;

namespace SQLServer { 
    /// <summary>
    /// 数据库反射类
    /// 作者:程淮榕
    /// 日期：2018-12-24
    /// </summary>
    /// <typeparam name="DB"></typeparam>
     public class DBGenerics<DB>:IDBGenerics<DB> where DB: IDataBase,new()
    {
        #region 私有对象
        private DB db_;   //数据库
        private ExcuteImport excuteImport_; //SQL执行类
        private string connectionName_; //链接名称
        private string connectionString_; //数据库链接字符串
        private string dataBaseName_;    //数据库名称
        private DbConnection dbConnection_; //数据库链接实体
        private Column GetDate_ = null;    //获取时间 

        //SQL执行对象
        private ExcuteImport excuteImport{
            get
            {
                if(excuteImport_ == null)
                {
                    excuteImport_ = db_.ExcuteImport;
                }
                return excuteImport_;
            }
        } 
        #endregion

        #region 访问器(构造函数)
        public static DBGenerics<DB> Instance => new DBGenerics<DB>();
        #endregion

        #region 公共属性
        public DB db
        {
            get
            {
                if (db_ ==null) { db_ = new DB(); }
                return db_;
            }            
        }

        public string ConnectionName
        {
            get
            {
                if(connectionName_ == null) { connectionName_ = db.ConnectionName; }
                return connectionName_;
            }
        }

        public string ConnectionString
        {
            get
            {
                if (connectionString_ == null) { connectionString_ = db.ConnectionString; }
                return connectionString_;
            }
        }

        public string DataBaseName
        {
            get
            {
                if(dataBaseName_ == null) { dataBaseName_ = db.DataBaseName; }
                return dataBaseName_;
            }
        }

        public DbConnection DbConnection
        {
            get
            {
                if(dbConnection_ == null) { dbConnection_ = db.Dbconnection; }
                return dbConnection_;
            }
        }

        public Column GetDate
        {
            get
            {
                if(GetDate_ == null) { GetDate_ = new Column(excuteImport.sqlSetting.Column_GetDate, excuteImport); }
                return GetDate_;
            }
        }
        #endregion


        #region 操作方法
        public bool CreateDataBase()
        {
            throw new NotImplementedException();
        }

        public bool DeleteDataBase()
        {
            throw new NotImplementedException();
        }

        public bool IsExistDataBase()
        {
            throw new NotImplementedException();
        }

        public DBtransaction BeginTransaction()
        {
            return new DBtransaction(DbConnection);
        }

        public void EndTransaction(DBtransaction dbtran)
        {
            dbtran.Dispose();
        }

        public DateTime GetServerTime()
        {
            object obj = excuteImport.ExecuteScalar(excuteImport.sqlSetting.GetServerDate_sql, null);
            DateTime result = DateTime.Now;
            if (obj != null)
            {
                DateTime.TryParse(obj.ToString(), out result);
            }
            return result;
        }

        public Object GetObject(string sql, List<DbParameter> lstDbParameters)
        {
            return excuteImport.ExecuteScalar(sql, lstDbParameters);
        }

        public IEnumerable<T>GetData<T>(string sql, List<DbParameter> lstDbParameters) where T: class
        {
            return this.excuteImport.Excute<T>(sql, lstDbParameters);
        }

        public int RunSql(string sql, List<DbParameter> lstDbParameters)
        {
            return (int)excuteImport.ExecuteScalar(sql, lstDbParameters);
        }

        public void WriteClick(string tableName,Column updateColumn,Column mainColumn,string key)
        {
            string sql = string.Format(excuteImport.sqlSetting.WriteClick_sql, tableName, updateColumn.GetName,
            updateColumn.GetName, mainColumn, mainColumn.GetName);
            List<DbParameter> list = new List<DbParameter>();
            list.Add(excuteImport.CreateDbParameter(excuteImport.sqlSetting.Flag + mainColumn.GetName, key));
            RunSql(sql, list);
        }

        public bool UpdateDataBase(string saveFile)
        {
            throw new NotImplementedException();
        }

        public bool RecoverDataBase(string filePath)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
