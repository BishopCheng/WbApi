using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  Business.Account;
using ApiServer.Entity.TableModel.ADO;
using Microsoft.AspNetCore.Http;
using ValidateServer;
using CacheServers;
using System.DrawingCore;
using System.DrawingCore.Imaging;
using System.IO;

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
       
        public IActionResult Login(string userName,string passWord,string validateCode)
        {
            t_user tuser = new t_user();
            //调用LoginService
            string result = "";
            LoginService loginService = new LoginService();
            result= loginService.Login(userName, passWord, validateCode, ref tuser);
            return SuccessRes(result);
        }

        public IActionResult GetValidateCode()
        {
            //获取验证码(图片流),然后回传
            var img = new MemoryStream();
            string validateCode = "";
            img = Tools.identifyingCodeBulid.CreateValidateCode(out validateCode);
            return File(img, "image/jpeg");

        }
    }
}
