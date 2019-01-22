using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace SiteSystem.Areas.CMS.Controllers
{
    [Area("CMS")]
    public class UserManageController : Controller
    {
        private readonly IHostingEnvironment _ihostingEnvironment;

        //在控制器中注入HostingEnvironment
        public UserManageController(IHostingEnvironment hostingEnvironment) {
            _ihostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}