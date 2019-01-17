using System;
using System.Collections.ObjectModel;
using SQLServer;
using ApiServer.Entity;
using ApiServer.EntityHandling;
using APIServer.DataAccess;
using CacheServers;
using ApiServer.Entity.TableModel.ADO;
using ValidateServer;
using CacheServers;

namespace Business.Account
{
    /// <summary>
    /// 用户登录业务类
    /// 作者：程淮榕
    /// 日期：2018-12-25
    /// </summary>
    public class LoginService
    {
        public string Login(string userName,string pwd,string validateCode, ref t_user userModel)
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
                    return "用户不存在，请注册后再登陆！";
                }
                if (!userModel.status.ToString().Equals("1"))
                {
                    loginResult = "3";
                    return "用户状态异常，请联系管理员！";
                }

                if(userModel.wrongCounts>=5 && userModel.lastLoginTime.Value.Equals(DateTime.Now.Date))
                {
                    //当天错误次数已经超过了5次
                    loginResult = "5";
                    return "当天密码错误次数已经超过5次，请明天再登陆！";
                }

                if (!MD5Encrypt.Encrypt(pwd).Equals(userModel.passWord))
                {
                    //登陆密码错误
                    loginResult = "2";
                    userModel.wrongCounts +=1;
                    LoginingWrite(userModel);
                    return "密码输入错误，请重新输入！";
                }

                userModel.lastLoginTime = DateTime.Now;
                string result = LoginingWrite(userModel);

                if (result.Length < 1)
                {
                    loginResult = "10";
                    
                }
                else
                {
                    result = "FAIL";
                }
                return result;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 登陆写入
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>

        public string LoginingWrite(t_user userModel)
        {
            try
            {
                //更新
                APIServer.DataAccess.DBPlatform.Data.UserData.UpdateModel(userModel);
                return "";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        
    }
}
