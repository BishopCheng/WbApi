using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.Account;
using ApiServer.Entity.TableModel.ADO;

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

            t_user userModel = new t_user();

            //调用业务逻辑层
            LoginService loginService = new LoginService();
            string msg = "";
            msg = loginService.Login(userName, passWord, validateCode, ref userModel);
            return Content(msg);
        }

        /// <summary>
        /// 进入桌面
        /// </summary>
        /// <returns></returns>
        public IActionResult CMSDesk()
        {
            return View();
        }
    }
}