using System;
using System.Collections.Generic;
using System.Text;
using ApiServer.Entity;
using ApiServer.EntityHandling;
using SQLServer;
using ApiServer.Entity.TableModel.ADO;
using ApiServer.Entity.ViewModel.ADO;

namespace APIServer.DataAccess.DBPlatform
{
    /// <summary>
    /// 用户管理数据库功能访问类
    /// 作者：程淮榕
    /// 日期:2018-12-23
    /// </summary>
     public class UUserDataAccess:DBService<dbplatform,v_user_group_info>
    {
        /// <summary>
        /// 用户列表数据查询
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="realName"></param>
        /// <param name="status"></param>
        /// <param name="userGroupName"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PageData<v_user_group_info>GetList(string userName,string realName,string status,string userGroupName,int pageIndex,int pageSize)
        {

        }
    }
}
