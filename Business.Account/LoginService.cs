using System;
using System.Collections.ObjectModel;
using SQLServer;
using ApiServer.Entity;
using ApiServer.EntityHandling;
using APIServer.DataAccess;
using CacheServers;
using ApiServer.Entity.TableModel.ADO;


namespace Business.Account
{
    /// <summary>
    /// 用户登录业务类
    /// 作者：程淮榕
    /// 日期：2018-12-25
    /// </summary>
    public class LoginService
    {
        public string Login(string userName,string pwd,ref t_user userModel)
        {
            userModel = new t_user();
            try
            {
                //判断用户信息
                userModel = APIServer.DataAccess.DBPlatform.Data.UserData.Get(userName);
                string loginResult = "0";  //初始状态
                if(userModel == null)
                {
                    loginResult = "1";
                    return "用户名或密码错误！";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
