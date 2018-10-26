using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;  //引入JWT支持
using System.Security.Claims;           //引入密钥支持
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TokenApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class JWTController : Controller
    {
        private readonly IConfiguration _configuration; //配置项

        public JWTController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

      
    }
}
