using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Linq;

namespace SQLServer
{
    /// <summary>
    /// 反射类
    /// 作者：程淮榕
    /// 时间：2018-11-23
    /// </summary>
    public class ReflectionGenerics  
    {
        private static ReflectionGenerics Instance_;  //定义访问器

        private static Dictionary<string, IEntity> lstIEntity = new Dictionary<string, IEntity>();

        private static Dictionary<string, IDataBase> lstIDataBase = new Dictionary<string, IDataBase>();

        private string primaryKey_;

        private string tableName_;

        private string dataBase_;

        private IDataBase IDataBase_;

        private IEntity IEntity_;

        private Column GetDate_ = null; //获取时间

        private ExcuteImport excuteImport_;  //执行类

        private List<DbParameter> lstDbParameters_;  //操作参数

        #region  操作项
        private SelectName selectName_;

        private UpdateClip updateClip_;

        private InsertClip insertClip_;

        private OrderByClip orderByClip_;

        private GroupByClip groupByClip_;

        private WhereClip whereClip_;

        private List<string> otherT_;
        #endregion

        #region  参数
        private int skipNum_;  //跳过的数量
        private int takeNum_;  //获取的数量
        #endregion
        /// <summary>
        /// 访问器,返回一个新的实例
        /// </summary>
        public static ReflectionGenerics Instance
        {
            get
            {
                if(Instance_ == null)
                {
                    Instance_ = new ReflectionGenerics();
                }
                return Instance_;
            }
        }


        public ReflectionGenerics this[string db,string table]
        {
            get
            {
                IDataBase = ReflectionDataBase(db);
                IEntity = ReflectionEntity(table);
                return this;
            }
            
        }
        
        /// <summary>
        /// 实体属性反射(通过属性)
        /// </summary>
        public IEntity IEntity
        {
            get
            {
                return IEntity_;
            }
            set
            {
                IEntity_ = value;
            }
        }
        /// <summary>
        /// 数据库反射(通过属性)
        /// </summary>
        public IDataBase IDataBase
        {
            get
            {
                return IDataBase_;
            }
            set
            {
                IDataBase_ = value;
            }
        }

        public string ConnectionString => IDataBase.ConnectionString;

        public string PrimaryKey
        {
            get
            {
                if(dataBase_ == null || primaryKey_.Length <= 0)
                {
                    primaryKey_ = IEntity.PrimaryKey;
                }
                return primaryKey_;
            }
        }

        public string TableName
        {
            get
            {
                if(dataBase_ == null || tableName_.Length <= 0)
                {
                    tableName_ = IEntity.TableName;
                }
                return tableName_;
            }
        }

        public string DataBase
        {
            get
            {
                if(dataBase_ == null|| dataBase_.Length<=0)
                {
                    dataBase_ = IDataBase_.DataBaseName;

                }
                return dataBase_;
            }
        }

        
        public Column GetDate
        {
            get
            {
                if(GetDate_ == null)
                {
                    GetDate_ = new Column("GetDate()",excuteImport_);
                }
                return GetDate_;
            }
        }

        private ExcuteImport excuteImport
        {
            get
            {
                excuteImport_ = IDataBase_.ExcuteImport;
                return excuteImport_;
            }
        }

        private List<DbParameter> lstDbParmeters
        {
            get
            {
                return lstDbParameters_;
            }
            set
            {
                lstDbParameters_ = value;
            }
        }

        public SelectName SelectName
        {
            get
            {
                if(selectName_ == null)
                {
                    selectName_ = new SelectName();
                }
                return selectName_;
            }
            set
            {
                selectName_ = value;
            }
        }

        #region  SQL操作类型参数项
        public UpdateClip UpdateClip
        {
            get
            {
                if(updateClip_ == null)
                {
                    updateClip_ = new UpdateClip();
                }
                return updateClip_;
            }
            set
            {
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
                if (orderByClip_ == null)
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
            get
            {
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
            get
            {
                if(otherT_ == null)
                {
                    otherT_ = new List<string>();
                }
                return otherT_;
            }
            set
            {
                otherT_ = value;
            }
        }

        public int SKipNum
        {
            get
            {
                return skipNum_;
            }
            set
            {
                skipNum_ = value;
            }
        }

        public int TakeNum
        {
            get {
                return takeNum_;
            }
            set
            {
                takeNum_ = value;
            }
        }


        #endregion

        #region 数据库和实体反射接口
        public IDataBase ReflectionDataBase(string dbpath)
        {
            if (!lstIDataBase.ContainsKey(dbpath))
            {
                try
                {
                    string assemblyString = dbpath.Substring(0, dbpath.LastIndexOf("."));
                    IDataBase value = (IDataBase)Assembly.Load(assemblyString).CreateInstance(dbpath);
                    lstIDataBase.Add(dbpath, value);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            return lstIDataBase[dbpath];
        }

        public IEntity ReflectionEntity(string tablepath)
        {
            if (!lstIDataBase.ContainsKey(tablepath))
            {
                try
                {
                    string assemblyString = tablepath.Substring(0, tablepath.LastIndexOf("."));
                    IEntity value = (IEntity)Assembly.Load(assemblyString).CreateInstance(tablepath);
                    lstIEntity.Add(tablepath, value);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            return lstIEntity[tablepath];
        }
        #endregion

        #region 操作方法(CURD),通过接口
        public int BantchInsert(List<IEntity> tlist)
        {
            return BantchInsert(tlist);
        }

        public int BantchInsert(List<IEntity>tlist,DBtransaction dbtran)
        {
            IList<List<DbParameter>> list = new List<List<DbParameter>>();
            foreach (IEntity t in tlist)
            {
                list.Add(t.GetFullParameters());
            }
            if(dbtran != null)
            {
                return excuteImport.ExcuteNotQuery(IEntity.GetInsertPlate(), list, dbtran);
            }
            return excuteImport.ExcuteNotQuery(IEntity.GetInsertPlate(), list);
        }

        public int BantchUpdate(List<IEntity>tlist)
        {
            return BantchUpdate(tlist);
        }

        public int BantchUpdate(List<IEntity>tlist,DBtransaction dbtran)
        {
            IList<List<DbParameter>> parameterList = new List<List<DbParameter>>();
            foreach (IEntity t in tlist)
            {
                parameterList.Add(t.GetFullParameters());
            }
            if (dbtran != null)
            {
                return excuteImport.ExcuteNotQuery(IEntity.GetUpdatePlate(), parameterList, dbtran);
            }
            return excuteImport.ExcuteNotQuery(IEntity.GetUpdatePlate(), parameterList);
        }

        public int BantchDelete(List<IEntity>tlist,DBtransaction dbtran)
        {
            IList<List<DbParameter>> parameterlist = new List<List<DbParameter>>();
            //由于此处没有定义虚函数，所以在此编写sql语句
            foreach (IEntity t in tlist)
            {
                List<DbParameter> list2 = new List<DbParameter>();
                list2.Add(excuteImport.CreateDbParameter("@" + PrimaryKey, t.PrimaryKeyValue));
                parameterlist.Add(list2);
            }
            string sql = " DELETE " + TableName + " WHERE " + IEntity.PrimaryKey + "=@" + PrimaryKey;
            if(dbtran != null)
            {
                return excuteImport.ExcuteNotQuery(sql, parameterlist, dbtran);
            }
            return excuteImport.ExcuteNotQuery(sql, parameterlist);
        }
        public int BantchDelete(List<IEntity>tlist)
        {
            return BantchDelete(tlist);
        }

        public int BantchSave(List<IEntity>tlist,DBtransaction dbtran)
        {
            //使用stringbulider，生成存储过程语句
            StringBuilder stringbulider = new StringBuilder();
            stringbulider.Append(" IF EXISTS(SELECT " + PrimaryKey + " FROM " + TableName + " WHERE " + PrimaryKey + "=@" + PrimaryKey + ")");
            stringbulider.Append(" BEGIN ");
            stringbulider.Append(IEntity.GetUpdatePlate());
            stringbulider.Append(" END ELSE BEGIN ");
            stringbulider.Append(" END ");

            IList<List<DbParameter>> list = new List<List<DbParameter>>();
            foreach (IEntity T in tlist)
            {
                //写入参数
                list.Add(T.GetFullParameters());
            }
            if (dbtran != null)
            {
                return excuteImport.ExcuteNotQuery(stringbulider.ToString(), list, dbtran);
            }
            return excuteImport.ExcuteNotQuery(stringbulider.ToString(), list);
        }

        public int BantchSave(List<string> strList, List<List<DbParameter>> lstDbParmerter)
        {
            return excuteImport.ExcuteNotQuery(strList, lstDbParmerter);
        }

        public int BantchSave(List<string>strList,List<List<DbParameter>>lstDbParmeter,DBtransaction dbtran)
        {
            return excuteImport.ExcuteNotQuery(strList, lstDbParmeter, dbtran);
        }

        public int BantchOnce(List<IEntity> tlist)
        {
            return BantchOnce(tlist);
        }

        public int BantchOnce(List<IEntity> tlist,DBtransaction dbtran)
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<DbParameter> list = new List<DbParameter>();
            string str = " IF EXIST (SELECT  " + PrimaryKey + " FROM " + TableName + " WHERE " + PrimaryKey + "=@" + PrimaryKey + ")";
            str += " BEGIN ";
            str += IEntity.GetUpdatePlate();
            str += " END ELSE BEGIN ";
            str += IEntity.GetInsertPlate();
            str += " END ";
            int count = tlist.Count;
            for (int i = 0; i < count; i++)
            {
                string text = str;
                List<DbParameter> fullParmeters = tlist[i].GetFullParameters(); //获取所有的Parameters
                int count2 = fullParmeters.Count;
                //把每一个ParameterName加上序号
                for (int j = 0; j < count2; j++)
                {
                    text = text.Replace(fullParmeters[j].ParameterName, fullParmeters[j].ParameterName + j);
                    fullParmeters[j].ParameterName = fullParmeters[j].ParameterName + i;
                }
                stringBuilder.Append(text.ToString());
                list.AddRange(fullParmeters);
            }
            if (dbtran != null)
            {
                return excuteImport.ExcuteNotQuery(stringBuilder.ToString(), list, dbtran);
            }
            return excuteImport.ExcuteNotQuery(stringBuilder.ToString(), list);
        }

        public int InsertModel(IEntity iEntity) {
            return excuteImport.ExcuteNotQuery(IEntity.GetInsertPlate(), IEntity.GetFullParameters());
        }

        public int UpdateModel(IEntity iEntity) {
            return excuteImport.ExcuteNotQuery(IEntity.GetUpdatePlate(), IEntity.GetFullParameters());
        }

        public int DeleteModel(IEntity iEntity) {
            StringBuilder stringBuilder = new StringBuilder();

            //拼接语句
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(excuteImport.CreateDbParameter("@" + PrimaryKey, PrimaryKey));
            string sql = "DELETE " + TableName + " WHERE " + PrimaryKey + "=@" + PrimaryKey;
            //执行SQL语句
            return excuteImport.ExcuteNotQuery(sql, parameters);
        }

        public int DeleteModel(Collection<string> primaryKeyList)
        {
            WhereClip whereClip = new WhereClip();
            whereClip.AddClip(IEntity.GetColumn(IEntity.PrimaryKey).In(primaryKeyList));
            List<DbParameter> dbParameters = new List<DbParameter>();
            string sqlwhereClip = "";
            whereClip.GetPartmerStrings(excuteImport, ref sqlwhereClip, ref dbParameters);
            string sqlString = " DELETE " + TableName + " WHERE " + sqlwhereClip;
            return excuteImport.ExcuteNotQuery(sqlString, dbParameters);
        }
        #endregion

        #region 操作方法（CURD），通过自定义Clip
        public int Insert(InsertClip insertClip)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            string sqlInsert = "";
            insertClip.GetParameterString(excuteImport, ref sqlInsert, ref parameters);
            sqlInsert = "INSERT " + TableName + insertClip;
            return excuteImport.ExcuteNotQuery(sqlInsert, parameters);
        }

        public int Update(UpdateClip updateClip,WhereClip whereClip)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            string updateSql = "";
            string selectSql = "";
            updateClip.GetParamString(excuteImport, ref updateSql, ref parameters);
            whereClip.GetPartmerStrings(excuteImport, ref selectSql, ref parameters);
            string sqlStr = "UPDATE " + TableName +" " +  updateSql + " WHERE " + selectSql;
            return excuteImport.ExcuteNotQuery(sqlStr, parameters);
        }

        public int Delete(WhereClip whereClip)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            string deletesql = "";
            whereClip.GetPartmerStrings(excuteImport, ref deletesql, ref parameters);
            string sqlStr = "DELETE " + TableName + " WHERE " + deletesql;
            return excuteImport.ExcuteNotQuery(sqlStr, parameters);
        }

        public bool IsExist()
        {
            return excuteImport.TabExists(TableName);
        }

        public bool IsExist(object primaryValue)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(excuteImport.CreateDbParameter("@" + PrimaryKey, primaryValue));
            string sqlStr = "SELECT COUNT(*) FROM " + TableName + " WHERE " + PrimaryKey + "=@" + PrimaryKey;
            return excuteImport.Exists(sqlStr, parameters);
        }

        /// <summary>
        /// 操作当前表单
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            List<DbParameter> parameters = new List<DbParameter>();
            string sqlStr = "SELECT COUNT(*) AS coutumn FROM " + IEntity.TableName;
            return GetCountBySql(sqlStr, parameters);
        }

      

        public int Count(WhereClip whereClip, Column column)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            string sqlWhereClip = "";
            whereClip.GetPartmerStrings(excuteImport, ref sqlWhereClip,ref parameters);
            string sqlStr = "SELECT COUNT(distinct(" + column.Name + " )) as countumn FROM " + TableName + " WHERE " + sqlWhereClip;
            return GetCountBySql(sqlStr, parameters);
        }

        public decimal Sum(WhereClip whereClip,Column column)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            string sqlWhereClip = "";
            whereClip.GetPartmerStrings(excuteImport, ref sqlWhereClip, ref parameters);
            string sqlStr = "SELECT SUM(" + column.Name + ") as SumValue FROM " + TableName + " WHERE " + sqlWhereClip;
            //先获得object对象,然后再转换成decimal对象
            object obj = excuteImport.ExecuteScalar(sqlStr, parameters);
            decimal result = default(decimal);
            if(obj != null)
            {
                decimal.TryParse(obj.ToString(), out result);
            }
            return result;
        }

        public int GetCountBySql(string sql, List<DbParameter> lstDbparameters)
        {
            //先获取一个OBJ，然后把结果转换类型后装入OBJ存起来
            object obj = excuteImport.ExecuteScalar(sql, lstDbparameters);
            int result = 0;
            if (obj != null)
            {
                int.TryParse(obj.ToString(), out result);
            }
            return result;
        }
        #endregion

        #region 操作方法（CURD）,带事务
        public int InsertModel(IEntity iEntity,DBtransaction dbtran)
        {
            return excuteImport.ExcuteNotQuery(iEntity.GetInsertPlate(), iEntity.GetFullParameters(), dbtran);
        }

        public int UpdateModel(IEntity iEntity, DBtransaction dbtran)
        {
            return excuteImport.ExcuteNotQuery(iEntity.GetUpdatePlate(), iEntity.GetFullParameters(), dbtran);
        }

        public int DeleteModel(IEntity iEntity, DBtransaction dbtran)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            string sqlStr = "";
            parameters.Add(excuteImport.CreateDbParameter("@"+PrimaryKey, iEntity.PrimaryKeyValue));
            sqlStr = " DELETE " + TableName + " WHERE " + PrimaryKey + "=@PrimaryKey";
            return excuteImport.ExcuteNotQuery(sqlStr, parameters, dbtran);
        }

        public int DeleteModel(object primaryKey,DBtransaction dbtran)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            string sqlStr = "";
            parameters.Add(excuteImport.CreateDbParameter("@" + PrimaryKey, primaryKey));
            sqlStr = " DELETE " + TableName + " WHERE " + PrimaryKey + "=@PrimaryKey";
            return excuteImport.ExcuteNotQuery(sqlStr, parameters, dbtran);
        }

        
        public int DeleteModel(Collection<object> primaryKeyList,DBtransaction dbtran)
        {
            string text = "";
            List<DbParameter> list = new List<DbParameter>();
            int count = primaryKeyList.Count;
            for (int i = 0; i < count; i++)
            {
                //将所有primaryKey添加到集合中,如果是第一个，直接添加,如果不是第一个,则加入逗号后添加
                text = ((text.Length != 0) ? (text + "," + excuteImport.sqlSetting.Flag + i.ToString()) : (text + excuteImport.sqlSetting.Flag + i.ToString()));
                list.Add(excuteImport.CreateDbParameter(excuteImport.sqlSetting.Flag + PrimaryKey + i.ToString(), primaryKeyList[i]));
            }
            string sqlStr = string.Format(excuteImport.sqlSetting.DeleteModel_sql_In, TableName, PrimaryKey, text);
            return excuteImport.ExcuteNotQuery(sqlStr, list, dbtran);
        }

        public int Insert(InsertClip insertClip,DBtransaction dbtran)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            string sqlInsert = "";
            insertClip.GetParameterString(excuteImport, ref sqlInsert, ref parameters);
            string sqlStr = "INSERT " + TableName + sqlInsert;
            return excuteImport.ExcuteNotQuery(sqlStr, parameters,dbtran);            
        }

        public int Update(UpdateClip updateClip,WhereClip whereClip,DBtransaction dbtran)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            string updateSql = "";
            string whereSql = "";
            updateClip.GetParamString(excuteImport, ref updateSql, ref parameters);
            whereClip.GetPartmerStrings(excuteImport, ref whereSql, ref parameters);
            string sqlStr = "UPDATE " + TableName + " " + updateSql + " WHERE " + whereSql;
            return excuteImport.ExcuteNotQuery(sqlStr, parameters, dbtran);
        }

        public int Delete(WhereClip whereClip,DBtransaction dbtran)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            string sqlWhereClip = "";
            whereClip.GetPartmerStrings(excuteImport, ref sqlWhereClip, ref parameters);
            string sqlStr = "DELETE " + TableName + " " + "WHERE " + sqlWhereClip;
            return excuteImport.ExcuteNotQuery(sqlStr, parameters, dbtran);
        }

        public IEntity GetModel(object primaryKey)
        {
            string sql = "SELECT * FROM " + TableName + " WHERE " + PrimaryKey + "=@" + PrimaryKey;
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(excuteImport.CreateDbParameter("@" + PrimaryKey, primaryKey));
            //用Excute方法获取查找的资源
            IEnumerable<IEntity> source = excuteImport.Excute<IEntity>(sql, parameters);
            return source.FirstOrDefault();
        }
        #endregion

        #region 类的构造函数
        public ReflectionGenerics Select()
        {
            ClearCondition();
            return this;
        }

        public ReflectionGenerics Select(SelectName selectName)
        {
            ClearCondition();
            foreach (ColumnStruct item in selectName)
            {
                SelectName.Add(item);
            }
            return this;
        }

        public ReflectionGenerics SetOrderByClip(OrderByClip orderByClip)
        {
            foreach (ItemStruct item in orderByClip)
            {
                OrderByClip.Add(item);
            }
            return this;
        }

        public ReflectionGenerics SetWhereClip(ConditionItem whereClip)
        {
            WhereClip.Add(whereClip);
            return this;
        }

        public ReflectionGenerics SetWhereClip(WhereClip whereClip)
        {
            if (whereClip.flag)
            {
                //获取whereClip中的参数个数
                for (int i = 0; i < whereClip.Count; i++)
                {
                    WhereClip.AddClip((ConditionItem)whereClip[i]);
                }
            }
            else
            {
                for (int j = 0;  j < whereClip.Count;  j++)
                {
                    //如果是符号类型，whereClip中加入symol类型对象,否则加入conditionItem类型对象
                    if(whereClip[j] is Symbol)
                    {
                        WhereClip.AddComClip((Symbol)whereClip[j]);
                    }
                    else
                    {
                        WhereClip.AddComClip((ConditionItem)whereClip[j]);
                    }
                }
            }
            return this;
        }
        
        public ReflectionGenerics SetGroupByClip(Column groupByClip)
        {
            GroupByClip.Add(groupByClip);
            return this;
        }


        public ReflectionGenerics SetGroupByClip(GroupByClip groupByClip)
        {
            foreach (Column item in groupByClip)
            {
                GroupByClip.Add(item);
            }
            return this;
        }

        public ReflectionGenerics GetByRange(int skipNum,int takeNum)
        {
            SKipNum = skipNum;
            TakeNum = takeNum;
            return this;
        }


        #endregion

        #region 类本身方法

        public IEnumerable<IEntity> ToList()
        {
            return excuteImport.Excute<IEntity>(ToString(), lstDbParmeters);
        }

        public PageData<IEntity>ToList(int pageIndex,int pageSize)
        {
            string text = "";
            //先取出OrderByClip中的item，再取出WhereClip中的item
            foreach (ItemStruct item in OrderByClip)
            {
                if (text.Length > 0)
                {
                    text += ",";
                }
                text = item.Value + "";
            }
            string groupByStr = GroupByClip.ToString();
            PageData<IEntity> pageData = new PageData<IEntity>();
            if (WhereClip.Count <=0)
            {
                //没有where条件,直接返回结果,使用sqlSetting的SerchSQL语句模型
                List<string> list = excuteImport.sqlSetting.Search_sql(TableName, GetSelectField(), GetJoin(), "", text, groupByStr, pageIndex, pageSize, true, PrimaryKey, 2018);
                return excuteImport.ExecutePagerData<IEntity>(list[0], list[1], null);
            }
            //有Where条件,添加Dbparamerts
            List<DbParameter> parameters = new List<DbParameter>();
            string sqlWhereClip = "";
            WhereClip.GetPartmerStrings(excuteImport, ref sqlWhereClip, ref parameters);
            List<string> list2 = excuteImport.sqlSetting.Search_sql(TableName, GetSelectField(), GetJoin(), sqlWhereClip, text, groupByStr, pageIndex, pageSize, true, PrimaryKey, 2018);
            return excuteImport.ExecutePagerData<IEntity>(list2[0], list2[1], parameters);
            
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT");
            if(TakeNum == 0)
            {
                stringBuilder.Append(GetSelectField());
                stringBuilder.Append(" FROM " + TableName);
                GetCondition(ref stringBuilder);
            }
            else
            {
                stringBuilder.Append(" TOP " + TakeNum);
                stringBuilder.Append(" " + GetSelectField());
                stringBuilder.Append(" FROM " + TableName+GetJoin());
                stringBuilder.Append(" WHERE " + PrimaryKey + " NOT IN ");
                stringBuilder.Append("(SELECT TOP" + SKipNum + " " + PrimaryKey);
                stringBuilder.Append(" FROM " + TableName);
                stringBuilder.Append(" " + GetCondition(true));
                stringBuilder.Append(" " + GetCondition(false));
            }
            return stringBuilder.ToString();
        }

        public void ClearCondition()
        {
            SelectName = new SelectName();
            InsertClip = new InsertClip();
            UpdateClip = new UpdateClip();
            OrderByClip = new OrderByClip();
            GroupByClip = new GroupByClip();
            WhereClip = new WhereClip();
            OtherT = new List<string>();
            SKipNum = 0;
            TakeNum = 0;
            lstDbParmeters = new List<DbParameter>();
        }

        private string GetSelectField()
        {
            //如果没有selectName，默认搜索全部,返回*
            if (SelectName.Count <=0)
            {
                return "*";
            }
            return SelectName.ToString();
        }

        private string GetJoin()
        {
            string text = "";
            foreach (string item in OtherT)
            {
                text += item;
            }
            return text;
        }

        private string GetCondition(bool flag)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(GetJoin());
            if (WhereClip.Count >0)
            {
                string sqlWhereClip = "";
                List<DbParameter> parameters = new List<DbParameter>();
                WhereClip.GetPartmerStrings(excuteImport, ref sqlWhereClip, ref parameters);
                lstDbParmeters.AddRange(parameters);
                if (flag)
                {
                    //是where条件语句的头部
                    stringBuilder.Append(" WHERE " + sqlWhereClip);
                }
                else
                {
                    stringBuilder.Append(" AND " + sqlWhereClip);
                }
            }
            if (GroupByClip.Count > 0)
            {
                stringBuilder.Append(" GROUP BY " + GroupByClip.ToString());
            }
            if (OrderByClip.Count > 0)
            {
                stringBuilder.Append(" ORDER BY " + OrderByClip.ToString());
            }
            return stringBuilder.ToString();
        }

        public void GetCondition(ref StringBuilder strBuilder)
        {
            strBuilder.Append(GetJoin());
            if (WhereClip.Count > 0)
            {
                string sqlWhereClip = "";
                List<DbParameter> parameters = new List<DbParameter>();
                WhereClip.GetPartmerStrings(excuteImport, ref sqlWhereClip, ref parameters);
                lstDbParmeters.AddRange(parameters);
                strBuilder.Append(" WHERE " + sqlWhereClip);
            }
            if (GroupByClip.Count > 0)
            {
                strBuilder.Append(" GROUP BY " + GroupByClip.ToString());
            }
            if (OrderByClip.Count > 0)
            {
                strBuilder.Append(" ORDER BY " + OrderByClip.ToString());
            }
            
        }
        #endregion
    }
}
