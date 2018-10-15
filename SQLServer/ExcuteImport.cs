using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace SQLServer
{

    /// <summary>
    /// SQL执行类实现
    /// 作者：程淮榕
    /// 时间：2018-10-09
    /// </summary>
    public sealed class ExcuteImport : ExcuteInterface
    {
        private string connectionString = string.Empty; //创建链接字符串
        private DbProviderFactory providerFactory;   //创建数据源类工厂
        private int commandTimeOut = 0;              //将延时设定为0
        public DbCommand CreateDbCommand(string sql, List<DbParameter> lstDbParameter, CommandType commandType)
        {
            DbConnection dbconection = null;  //创建链接
            try
            {
                dbconection = providerFactory.CreateConnection();
                dbconection.ConnectionString = connectionString;
                dbconection.Open();
                DbCommand dbCommand = providerFactory.CreateCommand();
                dbCommand.CommandText = sql;
                dbCommand.CommandType = commandType;
                dbCommand.Connection = dbconection;
                dbCommand.CommandTimeout = commandTimeOut;

                //添加参数
                if(lstDbParameter.Count>0 && lstDbParameter != null)
                {
                    dbCommand.Parameters.AddRange(lstDbParameter.ToArray());  //添加lstDbParameter中的所有元素到dbCommand.Parameters的末尾
                }
                return dbCommand;
            }
            catch (Exception ex)
            {
                //如果报错则关闭链接
                if (dbconection != null && dbconection.State == ConnectionState.Open)
                {
                    dbconection.Close();
                    dbconection.Dispose();
                }
                throw ex;
            }
            finally
            {

            }
        }

        //public IEnumerable<T> Excute<T>(string sqlStr, List<DbParameter> lstParmeters) where T : class
        //{
        //    DbCommand dbcommad = null;
        //    try
        //    {
        //        using (CreateDbCommand(sqlStr, lstParmeters, CommandType.Text))
        //        {
        //            DbDataReader dtReader = dbcommad.ExecuteReader();

        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
           
        //}

        public int ExcuteNotQuery(string sqlStr, List<DbParameter> Parmeters)
        {
            int result = 0;
            DbCommand dbCommand = null;
            try {
                using (dbCommand = CreateDbCommand(sqlStr, Parmeters, CommandType.Text))
                {
                    result = dbCommand.ExecuteNonQuery();
                    dbCommand.Parameters.Clear();
                   
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                //关闭Command
                if(dbCommand != null && dbCommand.Connection.State == ConnectionState.Open)
                {
                    dbCommand.Connection.Close();
                    dbCommand.Connection.Dispose();
                }
            }
            return result;
        }

        public int ExcuteNotQuery(string sqlStr, List<DbParameter> Parmeters, DBtransaction dbtran)
        {
            int result = 0;
            DbCommand dbCommand = providerFactory.CreateCommand();
            try
            {
                dbCommand.CommandText = sqlStr;
                dbCommand.CommandType = CommandType.Text;
                dbCommand.Connection = dbtran.DbConnection;
                dbCommand.Transaction = dbtran.DbTransaction;
                dbCommand.CommandTimeout = commandTimeOut;

                if(Parmeters!=null && Parmeters.Count>0)
                {
                    dbCommand.Parameters.AddRange(Parmeters.ToArray());
                }
                result= dbCommand.ExecuteNonQuery();
                dbCommand.Parameters.Clear();  // 清空参数
                dbCommand.Connection.Close();  //关闭Command
              
            }
            catch (Exception ex)
            {
                if(dbCommand!=null && dbCommand.Connection.State == ConnectionState.Open)
                {
                    dbtran.RollBack();
                    dbCommand.Transaction.Dispose();
                    dbCommand.Connection.Close();
                }
                throw ex;
            }
            finally
            {

            }
            return result;
        }

        public int ExcuteNotQuery(string sqlStr, IList<List<DbParameter>> lstParmeters)
        {
            int num = 0;
            DbTransaction dbTransaction = null;
            DbConnection dbConnection = null;
            string str = "";
            try
            {
                dbConnection = providerFactory.CreateConnection();  //利用链接工厂创建链接
                dbConnection.ConnectionString = connectionString;   //给链接字符串赋值
                dbConnection.Open();                                //打开链接
                dbTransaction = dbConnection.BeginTransaction(IsolationLevel.Serializable); //开始事务
                int count = lstParmeters.Count;
                for (int i = 0; i < count; i++)
                {
                    DbCommand dbCommand = providerFactory.CreateCommand();
                    dbCommand.CommandText = sqlStr;
                    dbCommand.Connection = dbConnection;
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.Transaction = dbTransaction;
                    str = sqlStr + ">>" + i;
                    if (lstParmeters[i] != null && lstParmeters[i].Count > 0) { dbCommand.Parameters.AddRange(lstParmeters[i].ToArray()); }
                    num += dbCommand.ExecuteNonQuery();  //保存下此刻执行完毕的条数，并添加到总数中
                    dbCommand.Parameters.Clear();        //清空参数
                }
                dbTransaction?.Commit();                //允许提交空事务
            }
            catch (Exception ex)
            {
                dbTransaction?.Rollback();
                throw new Exception(str + "执行错误！" + ex.Message + "");
            }
            finally
            {
                if(dbConnection!=null && dbConnection.State ==ConnectionState.Open)
                {
                    dbTransaction.Rollback();
                    dbTransaction.Dispose();
                    dbConnection.Close();
                    dbConnection.Dispose();
                }
              
            }
            return num;
        }

        public int ExcuteNotQuery(string sqlStr, IList<List<DbParameter>> lstParmeters, DBtransaction dbtran)
        {
            int num = 0;
            int count = lstParmeters.Count;
            try
            {
                for (int i = 0; i < count; i++)
                {
                    DbCommand dbCommand = providerFactory.CreateCommand();
                    dbCommand.CommandText = sqlStr;
                    dbCommand.Connection = dbtran.DbConnection;
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.Transaction = dbtran.DbTransaction;
                    if (lstParmeters[i] != null && lstParmeters[i].Count > 0)
                    {
                        dbCommand.Parameters.AddRange(lstParmeters[i].ToArray());
                    }
                    num += dbCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("'" + sqlStr + "'" + "执行错误!" + ex);
            }
            finally {
                if (dbtran != null) { dbtran.RollBack(); }
            }
            return num;
              
        }

        public int ExcuteNotQuery(IList<string> lstSqls, IList<List<DbParameter>> lstParmeters)
        {
            DbTransaction dbTransaction = null;
            DbConnection dbConnection = null;
            int num = 0;
            string str = "";
            try {
                           
                dbConnection = providerFactory.CreateConnection();
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                int count = lstParmeters.Count;
                dbTransaction = dbConnection.BeginTransaction(IsolationLevel.Serializable);
                for (int i = 0; i < count; i++)
                {
                    DbCommand dbCommand = providerFactory.CreateCommand();
                    dbCommand.CommandText = lstSqls[i];
                    dbCommand.CommandTimeout = commandTimeOut;
                    dbCommand.Connection = dbConnection;
                    str = lstSqls[i];
                    if (lstParmeters[i] != null && lstParmeters[i].Count > 0)
                    {
                        dbCommand.Parameters.AddRange(lstParmeters[i].ToArray());
                    }
                    num += dbCommand.ExecuteNonQuery();
                    dbCommand.Parameters.Clear();
                }
                dbTransaction?.Commit();
            }
            catch (Exception ex)
            {
                dbTransaction.Rollback();
                throw new Exception("'" + str + "'" + "执行错误!" + ex);
            }
            finally
            {
                dbTransaction.Dispose();
                dbConnection.Close();
                dbConnection.Dispose();
            }
            return num;
        }
        

        public int ExcuteNotQuery(IList<string> lstSqls, IList<List<DbParameter>> lstParmeters, DBtransaction dbtran)
        {
            int num = 0;
            string sqlstr = "";
            try
            {
                int counts = lstSqls.Count;
                for (int i = 0; i < counts; i++)
                {
                    DbCommand dbCommand = providerFactory.CreateCommand();
                    dbCommand.CommandText = lstSqls[i];
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandTimeout = commandTimeOut;
                    dbCommand.Connection = dbtran.DbConnection;
                    dbCommand.Transaction = dbtran.DbTransaction;
                    sqlstr = lstSqls[i];
                    if (lstParmeters[i] != null && lstParmeters[i].Count>0)
                    {
                        dbCommand.Parameters.AddRange(lstParmeters[i].ToArray());
                    }
                    num+= dbCommand.ExecuteNonQuery();
                    dbCommand.Parameters.Clear();
                }
               
            }
            catch (Exception ex)
            {
                if (dbtran != null) {
                    throw new Exception(sqlstr + "执行错误！" + ex);  
                }
            }
            finally
            {
                if (dbtran != null) {
                    dbtran.DbTransaction.Dispose();
                    dbtran.DbConnection.Dispose();
                }
            }
            return num;
        }
    }
}
