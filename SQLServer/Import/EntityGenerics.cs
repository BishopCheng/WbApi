using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.Common;

namespace SQLServer.Import
{
    /// <summary>
    /// 反射实体类
    /// </summary>
    /// <typeparam name="DB"></typeparam>
    /// <typeparam name="T"></typeparam>
    public class EntityGenerics<DB, T> : IEntityGenerics<DB, T> where DB : IDataBase, new() where T : IEntity, new()
    {
        private class Nested
        {
            internal static readonly EntityGenerics<DB, T> instance;  //只读访问器,单例模式

            static Nested()
            {
                instance = new EntityGenerics<DB, T>();
            }
        }
        #region 实体
        private T t_;
        private DB db_;
        private string connectionString_;
        private string provideName_;
        private string primaryKey_;
        private string tableName_;
        private string dataBase_;
        private List<DbParameter> lstDbParmeters_;
        private SelectName selectName_;
        private UpdateClip updateClip_;
        private InsertClip insertClip_;
        private OrderByClip orderByClip_;
        private GroupByClip groupByClip_;
        private WhereClip whereClip_;
        private List<string> OtherT_;
        private int skipNum_;
        private int takeNum_;
        private string searchKey_;
        #endregion
        public static EntityGenerics<DB, T> Instance => new EntityGenerics<DB, T>();
        private ExcuteImport dbExcute => dB.ExcuteImport;
        public T t
        {
            get
            {
                if(t_ == null)
                {
                    t_ = t;
                }
                return t_;
            }
        }


        public DB dB {
            get
            {
                if(db_ == null)
                {
                    db_ = dB;
                }
                return dB;
            }
        }



        public string connectionString {
            get { if (connectionString_ == null)
                {
                    connectionString_ = dB.ConnectionString;
                }
                return connectionString_;
            }
        }
        public string ProvideName
        {
            get
            {
                if(provideName_ == null)
                {
                    provideName_ = dB.ProvidName;
                }
                return provideName_;
            }
        }
        public string TableName
        {
            get
            {
                if(tableName_ == null || tableName_.Length <= 0)
                {
                    tableName_ = t.TableName;
                }
                return tableName_;
            }
        }
        public string DataBase
        {
            get
            {
                if(dataBase_==null || dataBase_.Length <= 0)
                {
                    dataBase_ = dB.DataBaseName;
                }
                return dataBase_;
            }
        }
        /// <summary>
        /// 数据库参数属性，只能在该类中访问,所以定义成私有
        /// </summary>
        private List<DbParameter> lstParmeters
        {
            get
            {
                return lstDbParmeters_;
            }
            set
            {
                lstDbParmeters_ = value;
            }
        }

        public string primaryKey {
            get
            {
                if(primaryKey_ == null || primaryKey_.Length <= 0)
                {
                    primaryKey_ = primaryKey;
                }
                return primaryKey_;
            }
        }

        public SelectName SelectName
        {
            get
            {
                if(selectName_ == null)
                {
                    selectName_ = SelectName;
                }
                return selectName_;
            }
            set {
                selectName_ = value;
            }
        }

        public UpdateClip UpdateClip
        {
            get
            {
                if(updateClip_ == null) {
                    updateClip_ = new UpdateClip();
                }
                return updateClip_;
            }
            set {
                updateClip_ = value;
            }
                
        }
        public InsertClip InsertClip
        {
            get
            {
                if(insertClip_ == null)
                {
                    insertClip_ = new InsertClip();
                }
                return insertClip_;
            }
            set
            {
                insertClip_ = value;
            }
        }

        public OrderByClip OrderByClip
        {
            get
            {
                if(orderByClip_ == null)
                {
                    orderByClip_ = new OrderByClip();
                }
                return orderByClip_;
            }
            set
            {
                orderByClip_ = value;
            }
        }
        public GroupByClip GroupByClip
        {
            get
            {
                if(groupByClip_ == null)
                {
                    groupByClip_ = new GroupByClip();
                }
                return groupByClip_;
            }
            set
            {
                groupByClip_ = value;
            }
        }
        public WhereClip WhereClip
        {
            get {
                if(whereClip_ == null)
                {
                    whereClip_ = new WhereClip();
                }
                return whereClip_;
            }
            set
            {
                whereClip_ = value;
            }

        }
        public List<string> OtherT
        {
            get {
                if(OtherT_ == null)
                {
                    OtherT_ = new List<string>();
                }
                return OtherT_;
            }
            set
            {
                OtherT_ = value;
            }
        }
        public int SkipNum
        {
            get {
                return skipNum_;
            }
            set {
                skipNum_ = value;
            }
        }
        public int TakeNum
        {
            get {
                return takeNum_;
            }
            set {
                takeNum_ = value;
            }
        }

        public string SearchKey
        {
            get
            {
                return searchKey_;
            }
            set
            {
                searchKey_ = value;
            }
        }

        public string ConnectionString => throw new NotImplementedException();

        public string PrimaryKey => throw new NotImplementedException();

        UpdateClip IEntityGenerics<DB, T>.UpdateClip { get => ((IEntityGenerics<DB, T>)Instance).UpdateClip; set => ((IEntityGenerics<DB, T>)Instance).UpdateClip = value; }
        InsertClip IEntityGenerics<DB, T>.InsertClip { get => ((IEntityGenerics<DB, T>)Instance).InsertClip; set => ((IEntityGenerics<DB, T>)Instance).InsertClip = value; }
        OrderByClip IEntityGenerics<DB, T>.OrderByClip { get => ((IEntityGenerics<DB, T>)Instance).OrderByClip; set => ((IEntityGenerics<DB, T>)Instance).OrderByClip = value; }
        GroupByClip IEntityGenerics<DB, T>.GroupByClip { get => ((IEntityGenerics<DB, T>)Instance).GroupByClip; set => ((IEntityGenerics<DB, T>)Instance).GroupByClip = value; }
        WhereClip IEntityGenerics<DB, T>.WhereClip { get => ((IEntityGenerics<DB, T>)Instance).WhereClip; set => ((IEntityGenerics<DB, T>)Instance).WhereClip = value; }
        List<string> IEntityGenerics<DB, T>.OtherT { get => ((IEntityGenerics<DB, T>)Instance).OtherT; set => ((IEntityGenerics<DB, T>)Instance).OtherT = value; }

        public int BanthDelete(List<T> tList)
        {
            throw new NotImplementedException();
        }

        public int BanthDelete(List<T> tList,  DBtransaction dbtran)
        {
            throw new NotImplementedException();
        }

        public int BanthInsert(List<T> tList)
        {
            return BanthInsert(tList,null);
        }

        public int BanthInsert(List<T> tList,  DBtransaction dbtran)
        {
            List<List<DbParameter>> list = new List<List<DbParameter>>();
            foreach (T t in tList)
            {
                list.Add(t.GetFullParmeters());
            }
            if(dbtran != null) //如果事务不为空,则执行事务
            {
                return dbExcute.ExcuteNotQuery(this.t.GetInsertPlate(), list, dbtran);
            }
            return dbExcute.ExcuteNotQuery(this.t.GetInsertPlate(), list);
        }

        public int BanthUpdate(List<T> tList)
        {
            return BanthUpdate(tList, null);
        }

        public int BanthUpdate(List<T> tList,  DBtransaction dbtran)
        {
            List<List<DbParameter>> list = new List<List<DbParameter>>();
            foreach (T t in tList)
            {
                list.Add(t.GetFullParmeters());
            }
            if(dbtran!=null)
            {
                return dbExcute.ExcuteNotQuery(this.t.GetUpdatePlate(), list, dbtran);
            }
            return dbExcute.ExcuteNotQuery(this.t.GetUpdatePlate(), list);
        }
        /// <summary>
        /// 清空选项
        /// </summary>
        public void ClearCondition()
        {
            SelectName = new SelectName();
            UpdateClip = new UpdateClip();
            InsertClip = new InsertClip();
            OrderByClip = new OrderByClip();
            GroupByClip = new GroupByClip();
            WhereClip = new WhereClip();
            OtherT = new List<string>();
            SkipNum = 0;
            TakeNum = 0;
            SearchKey = "";
            lstDbParmeters_ = new List<DbParameter>();

        }

        public int Count(WhereClip whereClip)
        {
            List<DbParameter> lstDbParameters = new List<DbParameter>();
            string sqlWhereClip = "";
            whereClip.GetPartmerStrings(dbExcute, ref sqlWhereClip, ref lstDbParameters);
            string sqlString = string.Format(dbExcute.sqlSetting.Count_sql_WhereClip, TableName, sqlWhereClip);
            return GetCountBySql(sqlString, lstDbParameters);
        }

        public int Count(WhereClip whereClip, Column column)
        {
            List<DbParameter> lstDbParameters = new List<DbParameter>();
            string sqlWhereClip = "";
            whereClip.GetPartmerStrings(dbExcute, ref sqlWhereClip, ref lstDbParameters);
            string sqlString = string.Format(dbExcute.sqlSetting.Count_sql_WhereClip_Column, TableName, column.Name, sqlWhereClip);
            return GetCountBySql(sqlString, lstDbParameters);
        }

        public int Count()
        {
            List<DbParameter> lstDbParameters = new List<DbParameter>();
            string sqlString = string.Format(dbExcute.sqlSetting.Count_sql, t.TableName);
            return GetCountBySql(sqlString, lstDbParameters);
        }

        public int Delete(WhereClip whereClip)
        {
            List<DbParameter> lstdbParameters = new List<DbParameter>();
            string sqlWhereClip = "";
            whereClip.GetPartmerStrings(dbExcute, ref sqlWhereClip, ref lstdbParameters);
            string sqlString = string.Format(dbExcute.sqlSetting.DeleteModel_sql_WhereClip, TableName, sqlWhereClip);
            return dbExcute.ExcuteNotQuery(sqlString, lstdbParameters);
        }

        public int Delete(WhereClip whereClip, DBtransaction dbtran)
        {
            List<DbParameter> lstdbParameters = new List<DbParameter>();
            string sqlWhereClip = "";
            whereClip.GetPartmerStrings(dbExcute, ref sqlWhereClip, ref lstdbParameters);
            string sqlString = string.Format(dbExcute.sqlSetting.DeleteModel_sql_WhereClip, TableName, sqlWhereClip);
            return dbExcute.ExcuteNotQuery(sqlString, lstdbParameters,dbtran);
        }

        public int DeleteModel(T t)
        {
            string sqlString = string.Format(dbExcute.sqlSetting.DeleteModel_sql, TableName, PrimaryKey);
            List<DbParameter> parameters = new List<DbParameter>
            {
                dbExcute.CreateDbParameter(dbExcute.sqlSetting.DeleteModel_PrimaryKey,t.PrimaryKey)
            };
            return dbExcute.ExcuteNotQuery(sqlString, parameters);
        }

        public int DeleteModel(Collection<object> primaryKeyList)
        {
            WhereClip whereClip = new WhereClip();
            whereClip.AddClip(t.GetColumn(t.PrimaryKey).In(primaryKeyList));
            List<DbParameter> lstDbParameter = new List<DbParameter>();
            string sqlWhereClip = "";
            whereClip.GetPartmerStrings(dbExcute, ref sqlWhereClip, ref lstDbParameter);
            string sql = string.Format(dbExcute.sqlSetting.DeleteModel_sql_WhereClip, TableName, sqlWhereClip);
            return dbExcute.ExcuteNotQuery(sql, lstDbParameter);

        }

        public int DeleteModel(object primaryKey)
        {
            string sqlString = string.Format(dbExcute.sqlSetting.DeleteModel_sql, TableName, PrimaryKey);
            List<DbParameter> parameters = new List<DbParameter>
            {
                dbExcute.CreateDbParameter(dbExcute.sqlSetting.DeleteModel_PrimaryKey,primaryKey)
            };
            return dbExcute.ExcuteNotQuery(sqlString, parameters);
        }

        public int DeleteModel(T t, DBtransaction dbtran)
        {
            string sqlString = string.Format(dbExcute.sqlSetting.DeleteModel_sql, TableName, PrimaryKey);
            List<DbParameter> list = new List<DbParameter>();
            list.Add(dbExcute.CreateDbParameter(dbExcute.sqlSetting.Flag + PrimaryKey, t.PrimaryKeyValue));
            return dbExcute.ExcuteNotQuery(sqlString, list, dbtran);
        }

        public int DeleteModel(Collection<object> primaryKeyList, DBtransaction dbtran)
        {
            throw new NotImplementedException();
        }

        public int DeleteModel(object primaryKey, DBtransaction dbtran)
        {
            throw new NotImplementedException();
        }

        public EntityGenerics<DB, T> FullJoin(IEntity OtherT, Column A, Column B)
        {
            throw new NotImplementedException();
        }

        public EntityGenerics<DB, T> GetByRange(int SkipNum, int takeNum)
        {
            throw new NotImplementedException();
        }

        public int GetColumnMaxID(Column column)
        {
            throw new NotImplementedException();
        }

        public int GetCountBySql(string sql, List<DbParameter> lstDbparameters)
        {
            throw new NotImplementedException();
        }

        public T GetModel(object primaryKey)
        {
            throw new NotImplementedException();
        }

        public EntityGenerics<DB, T> InnerJoin(IEntity OtherT, Column A, Column B)
        {
            throw new NotImplementedException();
        }

        public int Insert(InsertClip InsertClip)
        {
            throw new NotImplementedException();
        }

        public int Insert(InsertClip insertClip, DBtransaction dbtran)
        {
            throw new NotImplementedException();
        }

        public int InsertModel(T t)
        {
            throw new NotImplementedException();
        }

        public int InsertModel(T t, DBtransaction dbtran)
        {
            throw new NotImplementedException();
        }

        public int IsExist(WhereClip whereClip)
        {
            throw new NotImplementedException();
        }

        public int IsExist(object primaryKey)
        {
            throw new NotImplementedException();
        }

        public bool IsTabExist()
        {
            throw new NotImplementedException();
        }

        public EntityGenerics<DB, T> Join(IEntity OtherT)
        {
            throw new NotImplementedException();
        }

        public EntityGenerics<DB, T> LeftJoin(IEntity OtherT, Column A, Column B)
        {
            throw new NotImplementedException();
        }

        public EntityGenerics<DB, T> RigthJoin(IEntity OtherT, Column A, Column B)
        {
            throw new NotImplementedException();
        }

        public EntityGenerics<DB, T> Select()
        {
            throw new NotImplementedException();
        }

        public EntityGenerics<DB, T> Select(SelectName selectName)
        {
            throw new NotImplementedException();
        }

        public EntityGenerics<DB, T> SetGroupByClip(Column GroupByClip)
        {
            throw new NotImplementedException();
        }

        public EntityGenerics<DB, T> SetGroupByClip(GroupByClip groupByClip)
        {
            throw new NotImplementedException();
        }

        public EntityGenerics<DB, T> SetOrderByClip(ItemStruct orderByClip)
        {
            throw new NotImplementedException();
        }

        public EntityGenerics<DB, T> SetOrderByClip(OrderByClip orderByClip)
        {
            throw new NotImplementedException();
        }

        public EntityGenerics<DB, T> SetWhereClip(ConditionItem whereClip)
        {
            throw new NotImplementedException();
        }

        public EntityGenerics<DB, T> SetWhereClip(WhereClip whereClip)
        {
            throw new NotImplementedException();
        }

        public T ToFirst()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ToList()
        {
            throw new NotImplementedException();
        }

        public PageData<T> ToList(int PageSize, int PageIndex)
        {
            throw new NotImplementedException();
        }

        public int Update(UpdateClip UpdateClip, WhereClip WhereClip)
        {
            throw new NotImplementedException();
        }

        public int Update(UpdateClip updateClip, DBtransaction dbtran)
        {
            throw new NotImplementedException();
        }

        public int UpdateModel(T t)
        {
            throw new NotImplementedException();
        }

        public int UpdateModel(T t, DBtransaction dbtran)
        {
            throw new NotImplementedException();
        }
    }
}
