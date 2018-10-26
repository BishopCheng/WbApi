using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Newtonsoft.Json.Linq;

namespace TokenApi.Model
{
    /// <summary>
    /// 令牌操作类
    /// 作者：程淮榕
    /// 时间：2018-10-26
    /// </summary>
    public class TokenHelper
    {
        public static String SECRET = "Freedom";  //公用密钥

        //创建Token
        public static string CreateToken()
        {
            DateTime TimeSign = DateTime.Now;
             
            
        }
    }
}
