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
using System.IO;

namespace WEBApiSite.Controllers
{
    [Produces("application/json")]
    [EnableCors("any")] //允许跨域
    public class ValidateController : Controller
    {
        public IActionResult GetValidateCode()
        {
            Random rm = new Random();
            try
            {
                MemoryStream MS = new MemoryStream();
                MS = Tools.identifyingCodeBulid.CreateValidateCode(out string CodeStr);
                var file = File(MS.ToArray(), "image/jpeg");
                return file;
            }
            catch(Exception ex)
            {
                ex.ToString();
                return Json("获取失败");
            }
        }

    }
}