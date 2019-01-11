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
using Microsoft.AspNetCore.Cors;
using Configs;
using APIPublish.Config;

namespace APIPublish.Controllers.Account
{
    /// <summary>
    /// 登陆控制器
    /// 作者:程淮榕
    /// 日期：2018-12-28
    /// </summary>
    [EnableCors("any")]//允许跨域
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
            //获取验证码地址
            var img = new MemoryStream();
            string validateCode = "";
            img = Tools.identifyingCodeBulid.CreateValidateCode(out validateCode);
            string path = "";
            string  fileName = Tools.identifyingCodeBulid.FileContenBulid(img);

            //构造网络图片地址
            //获取当前主机IP,从配置文件读取
            AppConfigurationService appConfigurtaionService = new AppConfigurationService();
            ServerUrl serverUrl  = appConfigurtaionService.GetAppSetting<ServerUrl>("Base", "appsettings.json");
            string currentIp = serverUrl.CurrentIp;
            string port = serverUrl.CurrentPort;

            string dicpath = "http://" + currentIp + ":" + port + "/WEBAPIPublish/" + fileName;

            return SuccessRes(dicpath);
        }
    }
}
