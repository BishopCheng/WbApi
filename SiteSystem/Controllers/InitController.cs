using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.Account;
using ApiServer.Entity.TableModel.ADO;
using System.IO;
using ValidateServer;

namespace Infomation.Controllers
{
    public class InitController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Init()
        {
            return View();
        }
       
       

        [HttpPost]
        public ActionResult Login(IFormCollection form)
        {
            //获取参数
            string userName = form["userName"];
            string passWord = form["password"];
            string validateCode = form["validateCode"];
            if (string.IsNullOrEmpty(userName)) { return Content("用户名不能为空！"); }
            if (string.IsNullOrEmpty(passWord)) { return Content("密码不能为空！"); }
            t_user userModel = new t_user();

            //先判断验证码是否正确,如果不正确则直接返回
            if (!validateCode.Equals(HttpContext.Session.GetString("validate"))) { return Content("验证码不正确！"); }
            //调用业务逻辑层
            LoginService loginService = new LoginService();
            string msg = "";
            msg = loginService.Login(userName, passWord, validateCode, ref userModel);
            return Content(msg);
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>

        public ActionResult GetValidataCode()
        {
            //获取验证码地址
            var img = new MemoryStream();
            string validateCode = "";
            img = Tools.identifyingCodeBulid.CreateValidateCode(out validateCode);
            //将验证码存入Session中
            HttpContext.Session.SetString("validate", validateCode);
            return File(img.ToArray(), "image/jpeg");
        }

        /// <summary>
        /// 进入桌面
        /// </summary>
        /// <returns></returns>
        public IActionResult CMSDesk()
        {
            return View();
        }

        public IActionResult CMSContent()
        {
            return View();
        }
    }
}