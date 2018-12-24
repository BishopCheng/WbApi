using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Linq;

namespace SQLServer
{
    /// <summary>
    /// 数据库反射操作实现类
    /// </summary>
    /// <typeparam name="DB"></typeparam>
    /// <typeparam name="T"></typeparam>
    public class DBService<DB,T> where DB:IDataBase, new() where T:IEntity,new()
    {
        /// <summary>
        /// json格式化的时间字符串
        /// </summary>
        private static JsonSerializerSettings dateTimeJsonSerializerSettings = null;

        private string BaseDirection_
        {
            get
            {
                if (BaseDirection_.Length > 0)
                {
                    goto IL_0018;
                }
                goto IL_0018;
                IL_0018:
                return BaseDirection_;
            }
            set
            {
                BaseDirection_ = value;
            }
        }
        /// <summary>
        /// 默认的缓存延时
        /// </summary>
        private int CacheTime_ = 60;

        private int CacheTime
        {
            get
            {

                return CacheTime_;
            }
            set
            {
                CacheTime_ = value;
            }
        }

        public static JsonSerializerSettings DateTimeJsonSerializerSettings
        {
            get
            {
                //如果json格式化的时间字符串设置为空,则进行赋值
                if(dateTimeJsonSerializerSettings == null)
                {
                    IsoDateTimeConverter val = new IsoDateTimeConverter();
                    val.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
                    IsoDateTimeConverter item = val;
                    JsonSerializerSettings val2 = new JsonSerializerSettings();
                    val2.MissingMemberHandling = 0;
                    val2.NullValueHandling = NullValueHandling.Ignore;
                    val2.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    dateTimeJsonSerializerSettings = val2;
                    dateTimeJsonSerializerSettings.Converters.Add(item);
                }
                return dateTimeJsonSerializerSettings;
            }
        }

        public string BanthInsert(List<T>tList,string userName)
        {
            int num = EntityGenerics<DB, T>.Instance.BanthInsert(tList);
            return (num > 0) ? "" : "批量添加失败";
        }

        public string BanthInsert(List<T> tList) {
            int num = EntityGenerics<DB, T>.Instance.BanthInsert(tList);
            return (num > 0) ? "" : "批量添加失败";
        }

        public string BanthInsert(List<T>tList,string userName,string changeBantch,ref DBtransaction dbTran)
        {
            int num = EntityGenerics<DB, T>.Instance.BanthInsert(tList,dbTran);
            return (num > 0) ? "" : "批量添加失败";
        }

        public string BantchInsert(List<T>tList,ref DBtransaction dbTran)
        {
            int num = EntityGenerics<DB, T>.Instance.BanthInsert(tList, dbTran);
            return (num > 0) ? "" : "批量添加失败";
        }

        public string BantchUpdate(List<T> tList)
        {
            int num = EntityGenerics<DB, T>.Instance.BanthInsert(tList);
            return (num > 0) ? "" : "批量添加失败";
        }

        public string BantchUpdate(List<T> oldList,List<T>tList,string userName)
        {
            int num = EntityGenerics<DB, T>.Instance.BanthUpdate(tList);
            return (num > 0) ? "" : "批量更新失败";
        }

        public string BantchUpdate(List<T> tList,ref DBtransaction dbTran)
        {
            int num = EntityGenerics<DB, T>.Instance.BanthUpdate(tList);
            return (num > 0) ? "" : "批量更新失败";
        }

        public string BantchUpdate(List<T> oldtList, List<T> tList, string userName, string changeBanth, ref DBtransaction dbTran)
        {
            int num = EntityGenerics<DB, T>.Instance.BanthUpdate(tList,dbTran);
            return (num > 0) ? "" : "批量更新失败";
        }

        public string BantchDelete(List<T>tList,string userName)
        {
            int num = EntityGenerics<DB, T>.Instance.BanthDelete(tList);
            return (num > 0) ? "" : "批量删除失败";
        }

        public string BantchDelete(List<T> tList)
        {
            int num = EntityGenerics<DB, T>.Instance.BanthDelete(tList);
            return (num > 0) ? "" : "批量删除失败";
        }

        public string BantchDelete(List<T>tList,string userName,string changeBanth,ref DBtransaction dbtran)
        {
            int num = EntityGenerics<DB, T>.Instance.BanthDelete(tList, dbtran);
            return (num > 0) ? "" : "批量删除失败";
        }

        public string BantchDelete(List<T>tList,ref DBtransaction dbtran)
        {
            int num = EntityGenerics<DB, T>.Instance.BanthDelete(tList, dbtran);
            return (num > 0) ? "" : "批量删除失败";
        }

        public string DeleteModel(object primaryValue,string userName,string changeBanth,ref DBtransaction dbtran)
        {
            int num = EntityGenerics<DB, T>.Instance.DeleteModel(primaryValue, dbtran);
            return (num > 0) ? "" : "删除失败";
        }

        public string DeleteModel(object primaryValue,ref DBtransaction dbtran)
        {
            int num = EntityGenerics<DB, T>.Instance.DeleteModel(primaryValue, dbtran);
            return (num > 0) ? "" : "删除失败";
        }

        public string DeleteModel(object primaryValue,string userName)
        {
            int num = EntityGenerics<DB, T>.Instance.DeleteModel(primaryValue);
            return (num > 0) ? "" : "删除失败";
        }

        public string DeleteModel(object primaryValue)
        {
            int num = EntityGenerics<DB, T>.Instance.DeleteModel(primaryValue);
            return (num > 0) ? "" : "删除失败";
        }

        public string Delete(Collection<object>keys,string userName,string changeBantch,ref DBtransaction dbtran)
        {
            int num = EntityGenerics<DB, T>.Instance.DeleteModel(keys);
            return (num > 0) ? "" : "删除失败";
        }
      
        public string Delete(Collection<object>keys,ref DBtransaction dbtran)
        {
            int num = EntityGenerics<DB, T>.Instance.DeleteModel(keys, dbtran);
            return (num > 0) ? "" : "删除失败";
        }

        public string Delete(Collection<object>keys,string userName)
        {
            int num = EntityGenerics<DB, T>.Instance.DeleteModel(keys);
            return (num > 0) ? "" : "删除失败";
        }

        public string Delete(Collection<object> keys)
        {
            int num = EntityGenerics<DB, T>.Instance.DeleteModel(keys);
            return (num > 0) ? "" : "删除失败";
        }

        public string Delete(WhereClip whereClip,string userName)
        {
            int num = EntityGenerics<DB, T>.Instance.Delete(whereClip);
            return (num > 0) ? "" : "删除失败";

        }

        public string Delete(WhereClip whereClip)
        {
            int num = EntityGenerics<DB, T>.Instance.Delete(whereClip);
            return (num > 0) ? "" : "删除失败";
        }

        public T Get(string key)
        {
            return EntityGenerics<DB, T>.Instance.GetModel(key);
        }

        public T Get(WhereClip whereClip,OrderByClip orderByClip)
        {
            return EntityGenerics<DB, T>.Instance.Select().SetWhereClip(whereClip).SetOrderByClip(orderByClip).ToFirst();
        }

        public string GetJson(string key)
        {
            //获取实体，然后序列化成json
            T val = Get(key);
            return JsonConvert.SerializeObject((object)val,DateTimeJsonSerializerSettings);
        }

        public string GetJson(WhereClip whereClip,OrderByClip orderByClip)
        {
            T val = Get(whereClip, orderByClip);
            return JsonConvert.SerializeObject((object)val, DateTimeJsonSerializerSettings);
        }

        private IEnumerable<T> ChangeSource(IEnumerable<T>lst,Dictionary<string,Dictionary<string,string>>dtConvert)
        {
            if (dtConvert != null)
            {
                int num = Enumerable.Count<T>(lst);
                foreach (string key in dtConvert.Keys)
                {
                    foreach (T item in lst)
                    {
                        item.SetColumnValue(key, dtConvert[key][string.Concat(item.ColumnValue(key))]);
                    }

                }
                return lst;
            }
            return lst;
        }

        public string InsertModel(T model,string userName,string changeBanth,ref DBtransaction dbtran)
        {
            int num = EntityGenerics<DB, T>.Instance.InsertModel(model, dbtran);
            return (num > 0) ? "" : "添加失败";
        }

        public string InsertModel(T model,ref DBtransaction dbtran)
        {
            int num = EntityGenerics<DB, T>.Instance.InsertModel(model, dbtran);
            return (num > 0) ? "" : "添加失败";
        }

        public string InsertModel(T model,string userName)
        {
            int num = EntityGenerics<DB, T>.Instance.InsertModel(model);
            return (num > 0) ? "" : "添加失败";
        }

        public string InsertModel(T model)
        {
            int num = EntityGenerics<DB, T>.Instance.InsertModel(model);
            return (num > 0) ? "" : "添加失败";
        }

        public bool IsExist(string key)
        {
            bool result = EntityGenerics<DB, T>.Instance.IsExist(key);
            return result;
        }

        public bool IsExist(WhereClip whereClip)
        {
            bool result = EntityGenerics<DB, T>.Instance.IsExist(whereClip);
            return result;
        }

        public int Count(WhereClip whereClip)
        {
            return EntityGenerics<DB, T>.Instance.Count(whereClip);
        }

        public decimal Sum(WhereClip whereClip,Column column)
        {
            return EntityGenerics<DB, T>.Instance.Sum(whereClip, column);
        }

        public void SetCacheTime(int second)
        {
            CacheTime = second;
        }

        public void SetBaseDirection(string dir)
        {
            BaseDirection_ = dir;
        }

        public IEnumerable<T>GetList(OrderByClip orderByClip, Dictionary<string, Dictionary<string, string>> dtConvert =null)
        {
            IEnumerable<T> lst = EntityGenerics<DB, T>.Instance.Select().SetOrderByClip(orderByClip).ToList();
            return ChangeSource(lst, dtConvert);
        }


        public IEnumerable<T>GetList(WhereClip whereClip,OrderByClip orderByClip, Dictionary<string, Dictionary<string, string>> dtConvert = null)
        {
            IEnumerable<T> lst = EntityGenerics<DB, T>.Instance.Select().SetWhereClip(whereClip).SetOrderByClip(orderByClip).ToList();
            return ChangeSource(lst, dtConvert);
        }

        public PageData<T>GetList(OrderByClip orderByClip,int pageIndex,int pageSize,Dictionary<string,Dictionary<string,string>>dtConvert= null)
        {
            PageData<T> page = EntityGenerics<DB, T>.Instance.Select().SetOrderByClip(orderByClip).ToList(pageSize,pageIndex);
            page.Rows = ChangeSource(page.Rows, dtConvert);
            return page;
        }

        public PageData<T>GetList(WhereClip whereClip,OrderByClip orderByClip,int pageIndex,int pageSize,Dictionary<string,Dictionary<string,string>> dtConvert= null)
        {
            PageData<T> page = EntityGenerics<DB, T>.Instance.Select().SetWhereClip(whereClip).SetOrderByClip(orderByClip).ToList(pageSize, pageIndex);
            page.Rows = ChangeSource(page.Rows, dtConvert);
            return page;
        }

        public IEnumerable<T>GetSelect(SelectName selectClip,WhereClip whereClip,OrderByClip orderByClip,GroupByClip groupByClip, Dictionary<string, Dictionary<string, string>> dtConvert = null)
        {
            IEnumerable<T>lst = EntityGenerics<DB, T>.Instance.Select(selectClip).SetWhereClip(whereClip)
                .SetOrderByClip(orderByClip).SetGroupByClip(groupByClip).ToList();
            return ChangeSource(lst, dtConvert);
        }

        public string GetSelectJsons(SelectName selectClip,WhereClip whereClip,OrderByClip orderByClip,GroupByClip groupByClip,Dictionary<string,Dictionary<string,string>>dtConvert = null)
        {
            IEnumerable<T> lst = EntityGenerics<DB, T>.Instance.Select(selectClip).SetWhereClip(whereClip)
                .SetOrderByClip(orderByClip).SetGroupByClip(groupByClip).ToList();
            lst = ChangeSource(lst, dtConvert);
            return JsonConvert.SerializeObject((object)lst, DateTimeJsonSerializerSettings);
        }

        public PageData<T>GetSelect(SelectName selectClip,WhereClip whereClip,OrderByClip orderByClip,GroupByClip groupByClip,int pageIndex, int pageSize,Dictionary<string,Dictionary<string,string>>dtConvert = null)
        {
            PageData<T> page = EntityGenerics<DB, T>.Instance.Select(selectClip).SetWhereClip(whereClip)
                .SetOrderByClip(orderByClip).SetGroupByClip(groupByClip).ToList(pageSize, pageIndex);
            page.Rows = ChangeSource(page.Rows, dtConvert);
            return page;
        }

        public string GetSelectJsons(SelectName selectClip,WhereClip whereClip,OrderByClip orderByClip,GroupByClip groupByClip,int pageIndex,int pageSize,Dictionary<string,Dictionary<string,string>>dtConvert = null)
        {
            PageData<T> page = EntityGenerics<DB, T>.Instance.Select(selectClip).SetWhereClip(whereClip)
                .SetOrderByClip(orderByClip).SetGroupByClip(groupByClip).ToList(pageSize, pageIndex);
            page.Rows = ChangeSource(page.Rows, dtConvert);
            return JsonConvert.SerializeObject((object)page, dateTimeJsonSerializerSettings);
        }

        public string UpdateModel(T oldModel,T newModel,string userName,string changeBanth,ref DBtransaction dbtran)
        {
            int num = EntityGenerics<DB, T>.Instance.UpdateModel(newModel, dbtran);
            return (num > 0) ? "" : "更新失败";
        }

        public string UpdateModel(T newModel,ref DBtransaction dbtran)
        {
            int num = EntityGenerics<DB, T>.Instance.UpdateModel(newModel, dbtran);
            return (num > 0) ? "" : "更新失败";
        }

        public string UpdateModel(T oldModel,T newModel,string userName)
        {
            int num = EntityGenerics<DB, T>.Instance.UpdateModel(newModel);
            return (num > 0) ? "" : "更新失败";
        }

        public string UpdateModel(T newModel)
        {
            int num = EntityGenerics<DB, T>.Instance.UpdateModel(newModel);
            return (num > 0) ? "" : "更新失败";
        }

        public string Update(UpdateClip updateClip,WhereClip whereClip,string userName)
        {
            //先用IEnumerable获取list，然后再进行 update操作
            IEnumerable<T> lst = EntityGenerics<DB, T>.Instance.Select().SetWhereClip(whereClip).ToList();
            int num = EntityGenerics<DB, T>.Instance.Update(updateClip, whereClip);
            return (num > 0) ? "" : "更新失败";
        }

        public string Update(UpdateClip updateClip,WhereClip whereClip)
        {
            IEnumerable<T> lst = EntityGenerics<DB, T>.Instance.Select().SetWhereClip(whereClip).ToList();
            int num = EntityGenerics<DB, T>.Instance.Update(updateClip, whereClip);
            return (num > 0) ? "" : "更新失败";
        }
    }
}
