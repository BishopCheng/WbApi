using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  Business.Account;
using ApiServer.Entity.TableModel.ADO;
using Microsoft.AspNetCore.Http;

namespace APIPublish.Controllers.Account
{
    /// <summary>
    /// 登陆控制器
    /// 作者:程淮榕
    /// 日期：2018-12-28
    /// </summary>

    public class LoginServiceController:BaseController
    {
        /// <summary>
        /// 登陆服务
        /// </summary>
        /// <returns></returns>
       
        public IActionResult Login(string userName,string password)
        {
            t_user tuser = new t_user();
            //调用LoginService
            string result = "";
            LoginService loginService = new LoginService();
            result= loginService.Login(userName, password, ref tuser);
            return SuccessRes(result);
        }
    }
}
