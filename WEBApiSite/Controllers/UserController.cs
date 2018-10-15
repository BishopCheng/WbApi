using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiServer.DataContext;
using Newtonsoft.Json;
using CacheServers;
using ValidateServer;

namespace WEBApiSite.Controllers
{
    //[Route("actionRoute")]
    [Produces("application/json")]
    [EnableCors("any")]//允许跨域
    public class UserController : ControllerBase
    {
        private CompanySiteDataContexts _companySiteDataContexts;

        public UserController(CompanySiteDataContexts context)
        {
            _companySiteDataContexts = context;
        }


        [HttpGet]
        public IActionResult Get(string id)
        {
            string IDInput = id;
            CompanySiteDataContexts context = _companySiteDataContexts;
            var u = context.t_User.FirstOrDefault(c => c.userId == IDInput);
            if (u == null) { return NotFound("用户无效"); }
            return Ok(u);
        }


        [HttpGet]
        public IActionResult Login(string userName,string passWord,string validateCode)
        {
            //判断验证码是否正确  (从缓存中获取验证码)
            bool ifhascode = CommonCache.CacheObj.Exists<MemoryCacheHelper>("key");
            if(ifhascode == false) { return Content("刷新验证码"); }
            string vcode = CommonCache.CacheObj.GetCache<String, MemoryCacheHelper>("key");
            if (vcode != validateCode) { return Content("验证码错误"); }
            else
            {

                CompanySiteDataContexts context = _companySiteDataContexts;
                var u = context.t_User.FirstOrDefault(c => c.userName == userName);
                if (u == null) { return Content("用户无效"); }
                else if (u.passWord != passWord) { return Content("密码错误"); }
                else { return Ok(u); }
            }
        }

        
    }
}