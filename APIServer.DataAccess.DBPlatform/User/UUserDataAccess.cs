using System;
using System.Collections.Generic;
using System.Text;
using ApiServer.Entity;
using ApiServer.EntityHandling;
using SQLServer;

namespace APIServer.DataAccess.DBPlatform
{
    /// <summary>
    /// 用户管理数据库功能访问类
    /// 作者：程淮榕
    /// 日期:2018-12-23
    /// </summary>
     public class UUserDataAccess:DBService<dbplatform,users>
    {
        public PageData<users>GetList()
    }
}
