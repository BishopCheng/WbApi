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
    public class BaseController:Controller
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
        /// 成功返回单个object(带时间)
        /// </summary>
        /// <param name="data">数据对象</param>
        /// <param name="msg">结果</param>
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

        /// <summary>
        /// 返回单个信息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public IActionResult SuccessRes(string msg = "")
        {
            apiResult = new ApiResult()
            {
                Msg = msg
            };
            return Json(apiResult);
        }


        /// <summary>
        /// 返回对象集合
        /// </summary>
        /// <param name="data"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public IActionResult SuccessRes(IEnumerable<object> data, string msg = "")
        {
            apiResult = new ApiResult()
            {
                Data = new ListData()
                {
                    ListInfo = data,
                    PageIndex = 1,
                    Total = data.Count()
                },
                Msg = msg
            };
            return Json(apiResult);
        }

        /// <summary>
        /// 返回分页的对象集合
        /// </summary>
        /// <param name="data">数据包</param>
        /// <param name="pageIndex">每页数量</param>
        /// <param name="pageSize">页数</param>
        /// <param name="total">总条数</param>
        /// <param name="msg">结果</param>
        /// <returns></returns>
        public IActionResult SuccessRes(IEnumerable<object>data,int pageIndex,int pageSize,int total,string msg = "")
        {
            apiResult = new ApiResult()
            {
                Data = new ListData()
                {
                    ListInfo = data,
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    Total = total
                },
                Msg = msg
            };
            return Json(apiResult, jsonSerializerSettings);
        }

        /// <summary>
        /// 返回错误信息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        public IActionResult ErroRes(string msg="",string errorCode="")
        {
            apiResult = new ApiResult()
            {
                Success = false,
                Msg = msg
            };
            return Json(apiResult);
        }

    }
}
