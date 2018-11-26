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
        }

        public GroupByClip groupByClip
        {
            get
            {
                if(groupByClip_ == null)
                {
                    groupByClip_ = new GroupByClip();
                }
                return groupByClip_;
            }
        }

        public WhereClip whereClip
        {
            get
            {
                if(whereClip_ == null)
                {
                    whereClip_ = new WhereClip();
                }
                return whereClip_;
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
                list.Add(t.GetFullParmeters());
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
                parameterList.Add(t.GetFullParmeters());
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
                list.Add(T.GetFullParmeters());
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
                List<DbParameter> fullParmeters = tlist[i].GetFullParmeters(); //获取所有的Parameters
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
        #endregion
    }
}
