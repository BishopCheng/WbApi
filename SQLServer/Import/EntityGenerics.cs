using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;

namespace SQLServer
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
                    db_ = new DB();
                }
                return db_;
            }
        }



        public string ConnectionString {
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

        public string PrimaryKey {
            get
            {
                if(primaryKey_ == null || primaryKey_.Length <= 0)
                {
                    primaryKey_ = t.PrimaryKey;
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


        #region 对Conditon操作

        UpdateClip IEntityGenerics<DB, T>.UpdateClip { get => ((IEntityGenerics<DB, T>)Instance).UpdateClip; set => ((IEntityGenerics<DB, T>)Instance).UpdateClip = value; }
        InsertClip IEntityGenerics<DB, T>.InsertClip { get => ((IEntityGenerics<DB, T>)Instance).InsertClip; set => ((IEntityGenerics<DB, T>)Instance).InsertClip = value; }
        OrderByClip IEntityGenerics<DB, T>.OrderByClip { get => ((IEntityGenerics<DB, T>)Instance).OrderByClip; set => ((IEntityGenerics<DB, T>)Instance).OrderByClip = value; }
        GroupByClip IEntityGenerics<DB, T>.GroupByClip { get => ((IEntityGenerics<DB, T>)Instance).GroupByClip; set => ((IEntityGenerics<DB, T>)Instance).GroupByClip = value; }
        WhereClip IEntityGenerics<DB, T>.WhereClip { get => ((IEntityGenerics<DB, T>)Instance).WhereClip; set => ((IEntityGenerics<DB, T>)Instance).WhereClip = value; }
        List<string> IEntityGenerics<DB, T>.OtherT { get => ((IEntityGenerics<DB, T>)Instance).OtherT; set => ((IEntityGenerics<DB, T>)Instance).OtherT = value; }
        #endregion

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
                list.Add(t.GetFullParameters());
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
                list.Add(t.GetFullParameters());
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
            string text = "";
            List<DbParameter> list = new List<DbParameter>();
            int count = primaryKeyList.Count;
            for (int i = 0; i < count; i++)
            {
                text = (text.Length != 0) ? (text + "," + dbExcute.sqlSetting.Flag + PrimaryKey + i.ToString()) : (text + dbExcute.sqlSetting.Flag + PrimaryKey + i.ToString());
                list.Add(dbExcute.CreateDbParameter(dbExcute.sqlSetting.Flag + PrimaryKey + i.ToString(), primaryKeyList[i]));
            }
            string sqlString = string.Format(dbExcute.sqlSetting.DeleteModel_sql_In, TableName, PrimaryKey, text);
            return dbExcute.ExcuteNotQuery(sqlString, list, dbtran);
        }

        public int DeleteModel(object primaryKey, DBtransaction dbtran)
        {
            string sqlString = string.Format(dbExcute.sqlSetting.DeleteModel_PrimaryKey, TableName, PrimaryKey);
            List<DbParameter> list = new List<DbParameter>
            {
                dbExcute.CreateDbParameter(dbExcute.sqlSetting.Flag+t.PrimaryKey,primaryKey)
            };
            return dbExcute.ExcuteNotQuery(sqlString, list, dbtran);
            
        }

        public EntityGenerics<DB, T> FullJoin(IEntity otherT, Column A, Column B)
        {
            OtherT.Add(string.Format(dbExcute.sqlSetting.FullJoin_sql, otherT.TableName, A.GetName, B.GetName));
            return this;
        }

        public EntityGenerics<DB, T> GetByRange(int skipNum, int takeNum)
        {
            SkipNum = skipNum;
            TakeNum = takeNum;
            return this;
        }

        public int GetColumnMaxID(Column column)
        {
            return dbExcute.GetMaxID(column.Name, TableName);
        }


        public Decimal Sum(WhereClip whereClip,Column column)
        {
            List<DbParameter> lstDbParameters = new List<DbParameter>();
            string sqlWhereClip = "";
            whereClip.GetPartmerStrings(dbExcute, ref sqlWhereClip, ref lstDbParameters);
            string sql = string.Format(dbExcute.sqlSetting.Sum_sql, column.Name, TableName, whereClip);
            object obj = dbExcute.ExecuteScalar(sql, lstDbParameters);
            decimal result = default(Decimal);
            if (obj != null)
            {
                decimal.TryParse(obj.ToString(), out result);
            }
            return result;
        }

        public int GetCountBySql(string sql, List<DbParameter> lstDbparameters)
        {
            object obj = dbExcute.ExecuteScalar(sql, lstDbparameters);
            int result = 0;
            if (obj != null)
            {
                int.TryParse(obj.ToString(), out result);
            }
            return result;
        }

        public T GetModel(object primaryKey)
        {
            string sqlString = string.Format(dbExcute.sqlSetting.Select_sql, TableName, PrimaryKey, PrimaryKey);
            List<DbParameter> lstDbParameters = new List<DbParameter>();
            lstDbParameters.Add(dbExcute.CreateDbParameter(dbExcute.sqlSetting.Flag + PrimaryKey, PrimaryKey));
            IEnumerable<T> source = dbExcute.Excute<T>(sqlString, lstDbParameters);
            return Enumerable.FirstOrDefault<T>(source);
        }

        public EntityGenerics<DB, T> InnerJoin(IEntity otherT, Column A, Column B)
        {
            OtherT.Add(string.Format(dbExcute.sqlSetting.InnerJoin_sql, A.GetName, B.GetName));
            return this;
        }

        public int Insert(InsertClip insertClip)
        {
            List<DbParameter> lstDbParameter = new List<DbParameter>();
            string sqlInsert = "";
            InsertClip.GetParameterString(dbExcute, ref sqlInsert, ref lstDbParameter);
            return dbExcute.ExcuteNotQuery(string.Format(dbExcute.sqlSetting.Insert_sql,TableName,sqlInsert),lstDbParameter);
        }

        public int Insert(InsertClip insertClip, DBtransaction dbtran)
        {
            List<DbParameter> lstDbParameter = new List<DbParameter>();
            string sqlInsert = "";
            insertClip.GetParameterString(dbExcute, ref sqlInsert, ref lstDbParameter);
            return dbExcute.ExcuteNotQuery(string.Format(dbExcute.sqlSetting.Insert_sql, TableName, sqlInsert), lstDbParameter, dbtran);
        }

        public int InsertModel(T t)
        {
            return dbExcute.ExcuteNotQuery(t.GetInsertPlate(), t.GetFullParameters());
        }

        public int InsertModel(T t, DBtransaction dbtran)
        {
            return dbExcute.ExcuteNotQuery(t.GetInsertPlate(), t.GetFullParameters(), dbtran);
        }

        public bool IsExist(WhereClip whereClip)
        {
            List<DbParameter> lstDbParameters = new List<DbParameter>();
            string sqlString = "";
            whereClip.GetPartmerStrings(dbExcute, ref sqlString, ref lstDbParameters);
            string sqls = string.Format(dbExcute.sqlSetting.IsExist_sql_WhereClip, TableName, sqlString);
            return dbExcute.Exists(sqls, lstDbParameters);
        }

        public bool IsExist(object primaryKey)
        {
            List<DbParameter> list = new List<DbParameter>();
            list.Add(dbExcute.CreateDbParameter(dbExcute.sqlSetting.Flag + PrimaryKey, primaryKey));
            string sqlString = string.Format(dbExcute.sqlSetting.IsExist_sql, TableName, PrimaryKey, PrimaryKey);
            return dbExcute.Exists(sqlString, list);
        }

        public bool IsTabExist()
        {
            return dbExcute.TabExists(t.TableName);
        }

        public EntityGenerics<DB, T> Join(IEntity otherT)
        {
            OtherT.Add(string.Format(dbExcute.sqlSetting.Join_sql, otherT.TableName));
            return this;
        }

        public EntityGenerics<DB, T> LeftJoin(IEntity otherT, Column A, Column B)
        {
            OtherT.Add(string.Format(dbExcute.sqlSetting.LeftJoin_sql, A.GetName, B.GetName));
            return this;
        }

        public EntityGenerics<DB, T> RigthJoin(IEntity otherT, Column A, Column B)
        {
            OtherT.Add(string.Format(dbExcute.sqlSetting.RightJoin_sql, A.GetName, B.GetName));
            return this;
        }

        public EntityGenerics<DB, T> Select()
        {
            ClearCondition();
            return this;
        }

        public EntityGenerics<DB, T> Select(SelectName selectName)
        {
            ClearCondition();
            //使用ColumnStruct类型填充
            foreach (ColumnStruct column in selectName)
            {
                SelectName.Add(column);

            }
            return this;
        }

        public EntityGenerics<DB, T> SetGroupByClip(Column groupByClip)
        {
            GroupByClip.Add(groupByClip);
            return this;
        }

        public EntityGenerics<DB, T> SetGroupByClip(GroupByClip groupByClip)
        {
            foreach (Column item in groupByClip)
            {
                GroupByClip.Add(item);
            }
            return this;
        }

        public EntityGenerics<DB, T> SetOrderByClip(ItemStruct orderByClip)
        {
            OrderByClip.Add(orderByClip);
            return this;
        }


        public EntityGenerics<DB, T> SetOrderByClip(OrderByClip orderByClip)
        {
            foreach (ItemStruct item in orderByClip)
            {
                OrderByClip.Add(item);
            }
            return this;
        }

        public EntityGenerics<DB, T> SetWhereClip(ConditionItem whereClip)
        {
            WhereClip.AddClip(whereClip);
            return this;
        }

        public EntityGenerics<DB, T> SetWhereClip(WhereClip whereClip)
        {
            if (whereClip.flag)
            {
                for (int i = 0; i < whereClip.Count; i++)
                {
                    WhereClip.AddClip((ConditionItem)whereClip[i]);
                }
            }
            else
            {
                for (int j = 0; j < whereClip.Count; j++)
                {
                    //符号标签处理
                    if(whereClip[j] is Symbol)
                    {
                        WhereClip.AddComClip((Symbol)whereClip[j]);
                    }
                    else
                    {
                        WhereClip.AddClip((ConditionItem)whereClip[j]);
                    }
                    
                }
                
            }
            return this;
        }

        public T ToFirst()
        {
            StringBuilder stringBuilder = new StringBuilder();
            GetCondition(ref stringBuilder);
            string sqlStr = string.Format(dbExcute.sqlSetting.First_sql, t.SqlTableName,stringBuilder.ToString());
            IEnumerable<T> source = dbExcute.Excute<T>(sqlStr, lstParmeters);
            return Enumerable.FirstOrDefault<T>(source);
        }

        public IEnumerable<T> ToList()
        {
            return dbExcute.Excute<T>(ToString(), lstParmeters);
        }

        public PageData<T> ToList(int PageSize, int PageIndex)
        {
            string text = "";
            for (int i = 0; i < OrderByClip.Count; i++)
            {
                if (text.Length > 0)
                {
                    text += ",";
                }
                text += OrderByClip[i].Column.Name;
            }
            string groupByStr = GroupByClip.ToString();
            PageData<T> pageData = new PageData<T>();
            if (WhereClip.Count <= 0)
            {
                List<string> lst = dbExcute.sqlSetting.Search_sql(TableName, GetSelectField(), GetJoin(), "", text, groupByStr, PageIndex, PageSize, true, PrimaryKey, 2018);
                return dbExcute.ExecutePagerData<T>(lst[0], lst[1], (List<DbParameter>)null);
            }
            List<DbParameter> lstDbParameters = new List<DbParameter>();
            string sqlWhereClip = "";
            WhereClip.GetPartmerStrings(dbExcute, ref sqlWhereClip, ref lstDbParameters);
            List<string> list2 = dbExcute.sqlSetting.Search_sql(TableName, GetSelectField(), GetJoin(), sqlWhereClip, text, groupByStr, PageIndex, PageSize, true, PrimaryKey, 2018);
            return dbExcute.ExecutePagerData<T>(list2[0], list2[1], lstDbParameters);
        }

        public IEnumerable<TT>ToList<TT>() where TT : class
        {

            return dbExcute.Excute<TT>(ToString(), lstParmeters);
            
        }

        public PageData<TT>ToList<TT>(int pageSize,int pageIndex) where TT : class
        {
            //先取OrderBy条件，再取GroupBy条件，最后取WhereClip条件
            string text = "";
            for (int i = 0; i < OrderByClip.Count; i++)
            {
                if (text.Length> 0)
                {
                    text += ",";
                }
                text += OrderByClip[i].Column.Name;
            }
            string groupByStr = GroupByClip.ToString();
            PageData<T> pageData = new PageData<T>();
            if (WhereClip.Count<=0)
            {
                //没有查询条件
                //调用SqlSetting的Search方法获取sqllist
                List<string> list = dbExcute.sqlSetting.Search_sql(TableName, GetSelectField(), GetJoin(), "", text, groupByStr, pageIndex, pageSize, true, PrimaryKey, 2018);
                return dbExcute.ExecutePagerData<TT>(list[0], list[1], (List<DbParameter>)null);
            }
            else
            {
                //有查询条件，写入查询条件
                List<DbParameter> lstDbParameters = new List<DbParameter>();
                string sqlWhereClip = "";
                this.WhereClip.GetPartmerStrings(dbExcute, ref sqlWhereClip, ref lstDbParameters);
                List<string> list2 = this.dbExcute.sqlSetting.Search_sql(this.TableName, this.GetSelectField(), this.GetJoin(), sqlWhereClip, text, groupByStr, pageIndex, pageSize, true, PrimaryKey, 2018);
                return dbExcute.ExecutePagerData<TT>(list2[0], list2[1], lstDbParameters);
            }

        }

        public int Update(UpdateClip UpdateClip, WhereClip WhereClip)
        {
            //先取得UpdateClip条件,再取得WhereClip条件
            List<DbParameter> lstParameters = new List<DbParameter>();
            string sqlwhereClip = "";
            string sqlupdateClip = "";

            //获取参数字符串
            UpdateClip.GetParamString(dbExcute, ref sqlupdateClip, ref lstParameters);
            WhereClip.GetPartmerStrings(dbExcute, ref sqlwhereClip, ref lstParameters);
            //使用update占位语句执行
            return dbExcute.ExcuteNotQuery(string.Format(dbExcute.sqlSetting.Update_sql, TableName, sqlupdateClip, sqlwhereClip), lstParameters);
        }

        public int Update(UpdateClip UpdateClip,WhereClip WhereClip, DBtransaction dbtran)
        {
            List<DbParameter> lstDbParameters = new List<DbParameter>();
            string sqlwhereClip = "";
            string sqlupdateClip = "";

            //获取执行参数
            UpdateClip.GetParamString(dbExcute, ref sqlupdateClip, ref lstDbParameters);
            WhereClip.GetPartmerStrings(dbExcute, ref sqlwhereClip, ref lstDbParameters);
            //使用update带事务的占位语句执行
            return dbExcute.ExcuteNotQuery(string.Format(dbExcute.sqlSetting.Update_sql, TableName, sqlupdateClip, sqlwhereClip), lstDbParameters,dbtran);
        }

        public int UpdateModel(T t)
        {
            return dbExcute.ExcuteNotQuery(t.GetUpdatePlate(), t.GetFullParameters());
        }

        public int UpdateModel(T t, DBtransaction dbtran)
        {
            return dbExcute.ExcuteNotQuery(t.GetUpdatePlate(), t.GetFullParameters());
        }

        #region 私有方法
        private void GetCondition(ref StringBuilder stringbuliderSql)
        {
            stringbuliderSql.Append(GetJoin());
            if (WhereClip.Count > 0)
            {
                string sqlwhereClip = "";
                List<DbParameter> lstDbParameters = new List<DbParameter>();
                WhereClip.GetPartmerStrings(dbExcute, ref sqlwhereClip, ref lstDbParameters);
                lstDbParameters.AddRange(lstDbParameters);
                stringbuliderSql.Append(dbExcute.sqlSetting.SQL_where+ sqlwhereClip);

            }
            if (GroupByClip.Count > 0)
            {
                stringbuliderSql.Append(dbExcute.sqlSetting.SQL_groupby + GroupByClip.ToString());
            }
            if (OrderByClip.Count > 0)
            {
                stringbuliderSql.Append(dbExcute.sqlSetting.SQL_orderby + OrderByClip.ToString());
            }
        }

        private void GetCondition(bool flag)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(GetJoin());
            if (WhereClip.Count > 0)
            {
                string sqlWhereClip = "";
                List<DbParameter> dbParameters = new List<DbParameter>();
                WhereClip.GetPartmerStrings(dbExcute, ref sqlWhereClip, ref dbParameters);
                dbParameters.AddRange(dbParameters);
                if (WhereClip.Count > 0)
                {
                    if (flag)
                    {
                        stringBuilder.Append(dbExcute.sqlSetting.SQL_where + WhereClip.ToString());
                    }
                    else
                    {
                        stringBuilder.Append(dbExcute.sqlSetting.SQL_and + WhereClip.ToString());
                    }
                }
                if (OrderByClip.Count > 0)
                {
                    stringBuilder.Append(dbExcute.sqlSetting.SQL_orderby + OrderByClip.ToString());
                }
                if (GroupByClip.Count > 0)
                {
                    stringBuilder.Append(dbExcute.sqlSetting.SQL_groupby + GroupByClip.ToString());
                }
                
            }
        }
        /// <summary>
        /// 获取join
        /// </summary>
        /// <returns></returns>
        private string GetJoin()
        {
            string text = "";
            foreach (var item in OtherT)
            {
                text += item;
            }
            return text;
        }
        private string GetSelectField()
        {
            if (SelectName.Count <= 0)
            {
                return dbExcute.sqlSetting.Select_all;
            }
            return SelectName.ToString();
        }

        #endregion
    }
}
