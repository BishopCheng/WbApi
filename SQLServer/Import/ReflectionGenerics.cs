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


    }
}
