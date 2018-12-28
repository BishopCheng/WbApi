using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIPublish.Config;
using Newtonsoft.Json;

namespace APIPublish.Controllers
{
    /// <summary>
    /// 基础类控制器
    /// </summary>
    public class BaseController
    {
        protected ApiResult apiResult;
        protected string ResStr = string.Empty;
        public static readonly JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings() { DateFormatString = "yyyy-MM-dd HH:mm:ss" };  //时间转换成JSON格式

        /// <summary>
        /// GUIDKEY
        /// </summary>
        public string GuidKey
        {
            get
            {
                return Guid.NewGuid().ToString("N");
            }
        }

        /// <summary>
        /// 成功返回单个object
        /// </summary>
        /// <param name="data"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public IActionResult SuccessRes(object data,string msg="")
        {
            //新起一个apiresult实体，将data数据和msg赋值，然后回传
            apiResult = new ApiResult()
            {
                Msg = msg,
                Data = data
            };
            return Json(apiResult, jsonSerializerSettings);
        }
    }
}
