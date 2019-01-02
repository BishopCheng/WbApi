using ApiServer.EntityHandling;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using SQLSettings;
using Configs;
using DBFactory;

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
        public ISetting sqlSetting;                     //通过接口引用SQL字符串拼接类
        private DbProviderFactory providerFactory;     //创建数据源类工厂
        private int commandTimeOut = 0;                //将延时设定为0

        public string ConnectionString
        {
            get
            {
                return connectionString;
            }
            set
            {
                //如果连接字符串为空或者连接字符串不等于当前值时，进行赋值操作
                if(connectionString == null || !connectionString.Equals(value))
                {
                    connectionString = value;
                }
            }
        }

        private int CommandTimeOut
        {
            //如果等于0的话，则设置
            get
            {
                if(commandTimeOut == 0)
                {
                    commandTimeOut = Configs.ConnectionStringOperate.GetDBConnectionStringTimeOut(ConnectionString);
                }
                return commandTimeOut;
            }
            
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public ExcuteImport() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="providTypeName">驱动类型名称</param>
        public ExcuteImport(string connectionString,string providTypeName) {
            ConnectionString = connectionString;
            providerFactory = ProviderFactory.GetProviderFactory(ProviderFactory.GetDbProviderType(providTypeName));  
            if(providerFactory == null)
            {
                throw new ArgumentException("不能为给定值providertype不会加载dbproviderfactory");
            }
            sqlSetting = ProviderFactory.GetSqlSetting(providTypeName);
        }

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

        
        public DbParameter CreateDbParameter(string name, object value)
        {
            DbParameter dbParameter = providerFactory.CreateParameter();
            dbParameter.ParameterName = name;
            dbParameter.Value = ((value == null) ? DBNull.Value : value);
            return dbParameter;
        }

        public DbParameter CreateDbParameter(string name, ParameterDirection parameterDirection, object value)
        {
            DbParameter dbParameter = providerFactory.CreateParameter();
            dbParameter.ParameterName = name;
            dbParameter.Value = ((value == null) ? DBNull.Value : value);
            dbParameter.Direction = parameterDirection;
            return dbParameter;
        }

        public DbParameter DbParameterCopy(DbParameter dbParameter)
        {
            return CreateDbParameter(dbParameter.ParameterName, dbParameter.Direction, dbParameter.Value);
        }

        public IEnumerable<T> Excute<T>(string sqlStr, List<DbParameter> lstParmeters) where T : class
        {
            DbCommand dbcommad = null;
            try
            {
                using (CreateDbCommand(sqlStr, lstParmeters, CommandType.Text))
                {
                    DbDataReader dtReader = dbcommad.ExecuteReader();    //执行sql语句
                    IEnumerable<T> result = dtReader.ReadToList<T>();    //将执行后得到的结果 写入IEnumerable
                    dbcommad.Connection.Close();                         //关闭链接
                    return result;                                       //返回查询结果

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(dbcommad !=null && dbcommad.Connection.State == ConnectionState.Open)
                {
                    dbcommad.Connection.Close();
                    dbcommad.Connection.Dispose();
                }
            }
        }

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

        public PageData<T> ExecutePagerData<T>(string sqlCount, string sqlData, List<DbParameter> lstDbParmeters) where T : class
        {
            PageData<T> pageData = new PageData<T>();
            DbConnection dbConnection = null;
            try
            {
                dbConnection = providerFactory.CreateConnection();
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                DbCommand dbCommand = providerFactory.CreateCommand();
                dbCommand.CommandText = sqlCount;
                dbCommand.CommandType = CommandType.Text;
                dbCommand.Connection = dbConnection;
                dbCommand.CommandTimeout = commandTimeOut;
                if(lstDbParmeters !=null && lstDbParmeters.Count > 0)
                {
                    dbCommand.Parameters.AddRange(lstDbParmeters.ToArray());
                }
                object obj = dbCommand.ExecuteScalar();    //ExecuteScalar方法，执行过后返回一个对象
                int result = 0;
                //此处执行两个方法，一个是获取受到影响的条目数量，一个是查询得到的数据
                if (obj != null)
                {
                    int.TryParse(obj.ToString(), out result);  //此处的obj中装载的是查询到结果的条目数量
                }
                pageData.Total = result;
                //以下是获取具体数据的方法
                dbCommand.Parameters.Clear();
                DbCommand dbcommand2 = providerFactory.CreateCommand();
                dbcommand2.CommandText = sqlData;
                dbcommand2.CommandType = CommandType.Text;
                dbcommand2.Connection = dbConnection;
                dbcommand2.CommandTimeout = commandTimeOut;
                if (lstDbParmeters != null && lstDbParmeters.Count > 0)
                {
                    dbcommand2.Parameters.AddRange(lstDbParmeters.ToArray());
                }
                DbDataReader obj2 = dbcommand2.ExecuteReader();
                //将获取的数据对象通过ReadToList方法装入集合
                IEnumerable<T> enumerable = new List<T>();
                pageData.Rows = obj2.ReadToList<T>();
                dbcommand2.Parameters.Clear();
                return pageData;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (dbConnection.State == ConnectionState.Open)
                {
                    dbConnection.Close();
                    dbConnection.Dispose();
                }
            }
        }

        public DataSet RunProcedure(string storedProcedureName, List<DbParameter> dbParameters, string tableName)
        {
            DbCommand dbCommand = null;
            try
            {
                using (dbCommand = CreateDbCommand(storedProcedureName, dbParameters, CommandType.StoredProcedure)) //创建Command
                {
                    using (DbDataAdapter dataAdapter = providerFactory.CreateDataAdapter())  //创建数据适配器
                    {
                        dataAdapter.SelectCommand = dbCommand;
                        DataSet dataSet = new DataSet();       //新建DataSet
                        dataAdapter.Fill(dataSet, tableName);  //填充适配器
                        dbCommand.Parameters.Clear();          //清空参数列表
                        return dataSet;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if(dbCommand.Connection.State==ConnectionState.Open && dbCommand != null)
                {
                    dbCommand.Connection.Close();
                    dbCommand.Connection.Dispose();
                }
            }
        }

        public DataSet RunProcedureToDataSet(string storedProcedureName, List<DbParameter> dbParameters)
        {
            DbCommand dbCommand = null;
            try
            {
                using (dbCommand = CreateDbCommand(storedProcedureName, dbParameters, CommandType.StoredProcedure))
                {
                    using (DbDataAdapter dbDataAdapter = providerFactory.CreateDataAdapter())
                    {
                        dbDataAdapter.SelectCommand = dbCommand;
                        DataSet dataSet = new DataSet();
                        dbDataAdapter.Fill(dataSet);
                        dbCommand.Parameters.Clear();
                        return dataSet;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if(dbCommand!=null && dbCommand.Connection.State == ConnectionState.Open)
                {
                    dbCommand.Connection.Close();
                    dbCommand.Connection.Dispose();
                }
            }
        }

        public bool RunProcedure(string storedProcedureName, List<DbParameter> dbParameters)
        {
            DbCommand dbCommand = null;
            try
            {
                using (dbCommand = CreateDbCommand(storedProcedureName, dbParameters, CommandType.StoredProcedure))
                {
                    int num = 0;
                    num = dbCommand.ExecuteNonQuery();
                    dbCommand.Parameters.Clear();
                    return num > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                dbCommand.Connection.Close();
                dbCommand.Connection.Dispose();
            }
        }

        public bool ColumnExists(string tableName, string columnName)
        {
            List<DbParameter> lstDbParameters = new List<DbParameter>();
            DbParameter dbParameter1 = CreateDbParameter(sqlSetting.ColumnExists_tableName, tableName);
            DbParameter dbParameter2 = CreateDbParameter(sqlSetting.ColumExists_columnName, columnName);
            lstDbParameters.Add(dbParameter1);
            lstDbParameters.Add(dbParameter2);

            object obj = ExecuteScalar(sqlSetting.ColumnExists_sql, lstDbParameters);
            if (obj != null)
            {
                bool result;
               result= Convert.ToInt32(obj) > 0 ? true : false;
                return result;
            }
            return false;
            
        }

        public int GetMaxID(string fieldName, string tableName)
        {
            string sql = string.Format(sqlSetting.GetMaxID_sql, fieldName, tableName);
            object obj = ExecuteScalar(sql, null);
            if (obj != null) { return (int)obj; }
            return 1;
        }

        public bool Exists(string strSql, List<DbParameter> parameters = null)
        {
            object obj = ExecuteScalar(strSql, parameters);
            if (!object.Equals(obj, null) && !object.Equals(obj, DBNull.Value) && int.Parse(obj.ToString()) != 0)
            {
                return true;
            }
            return false;
        }

        public bool TabExists(string tableName)
        {
            string sql = string.Format(sqlSetting.TabExists_sql, tableName);
            object obj = ExecuteScalar(sql, null);
            if(!object.Equals(obj,null) && !object.Equals(obj,DBNull.Value) && int.Parse(obj.ToString()) != 0)
            {
                return true;
            }
            return false;
        }

        public object ExecuteScalar(string sql, List<DbParameter> parameters)  //获取第一条结果
        {
            DbCommand dbCommand = null;
            try
            {
                using (dbCommand = CreateDbCommand(sql, parameters, CommandType.Text))
                {
                    object result = dbCommand.ExecuteScalar();
                    dbCommand.Parameters.Clear();
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if(dbCommand!=null && dbCommand.Connection.State == ConnectionState.Open)
                {
                    dbCommand.Connection.Close();
                    dbCommand.Connection.Dispose();
                }
            }
        }
    }
}
