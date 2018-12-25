using System;
using System.Collections.Generic;
using System.Text;
using ApiServer.Entity;
using ApiServer.EntityHandling;
using SQLServer;
using ApiServer.Entity.TableModel.ADO;
using ApiServer.Entity.ViewModel.ADO;

namespace APIServer.DataAccess.DBPlatform.User
{
    /// <summary>
    /// 用户管理数据库功能访问类
    /// 作者：程淮榕
    /// 日期:2018-12-23
    /// </summary>
     public class VUserUserGroupDataAccess:DBService<dbplatform,v_user_group_info>
    {
        /// <summary>
        /// 用户列表数据查询
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="realName">真实姓名</param>
        /// <param name="status">状态</param>
        /// <param name="userGroupName">用户组</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页条数</param>
        /// <returns></returns>
        //public PageData<v_user_group_info>GetList(string userName,string realName,string status,string userGroupName,int pageIndex,int pageSize)
        //{
        //    WhereClip whereClip = new WhereClip();
        //    if (!string.IsNullOrEmpty(userName))
        //    {
        //        whereClip.AddClip(v_user_group_info._.userName.Equals(userName));
        //    }
            
        //}
    }
}
