using System;
using System.Collections.Generic;
using System.Text;


namespace Configs
{
    /// <summary>
    /// 数据库连接操作类
    /// 作者：程淮榕
    /// 日期： 2018-12-04
    /// </summary>
     public class ConnectionStringOperate
    {
        private static Dictionary<string, DBConnectionStringModel> dicDBConnectionModel_ = null;

        /// <summary>
        /// 数据库链接字典集
        /// </summary>
        private static Dictionary<string,DBConnectionStringModel> DicDBConnectionModel
        {
            get
            {
                if(dicDBConnectionModel_ == null)
                {
                    AppConfigurationService appConfigurationService = new AppConfigurationService(); //新建一个配置读取类实例
                    List<DBConnectionStringModel> lstDbConnectionStringModel = appConfigurationService.GetAppSetting<List<DBConnectionStringModel>>("ConnectionStrings", "appsettings.json"); //读取配置模型集合
                    dicDBConnectionModel_ = new Dictionary<string, DBConnectionStringModel>();
                    foreach (var item in lstDbConnectionStringModel)
                    {
                        //将项目添加到字典
                        dicDBConnectionModel_.Add(item.ConnectionName, item);
                    }
                }
                return dicDBConnectionModel_;
            }
            
        }

        /// <summary>
        /// 获取数据库连接模型
        /// </summary>
        /// <param name="dbConnectionStringModelName"></param>
        /// <returns></returns>
        public static DBConnectionStringModel GetDBConnectionStringModel(string dbConnectionStringModelName)
        {
            //如果字典中存在模型,返回模型，如果没有，返回错误信息不存在
            if (DicDBConnectionModel.ContainsKey(dbConnectionStringModelName))
            {
                return DicDBConnectionModel[dbConnectionStringModelName];
            }
            else
            {
                throw new Exception(string.Format("没有{0}数据库链接！", dbConnectionStringModelName));
            }
        }

        /// <summary>
        /// 获取连接模型延时
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <returns></returns>
        public static int GetDBConnectionStringTimeOut(string connectionString)
        {
            foreach (DBConnectionStringModel item in DicDBConnectionModel.Values)
            {
                if (item.ConnectionString.Equals(connectionString))
                {
                    return item.TimeOut;
                }
            }
            return 60;
          
        }
    }
}
