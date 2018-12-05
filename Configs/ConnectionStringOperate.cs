using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;

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
            }
            set
            {

            }
        }
    }
}
