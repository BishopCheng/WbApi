using System;
using System.Collections.Generic;
using System.Text;

namespace SQLServer
{
    /// <summary>
    /// 分页工具类
    /// 作者：程淮榕
    /// 时间：2018-10-18
    /// </summary>
     public class PageData<T> where T : class
    { 
            public IEnumerable<T> Rows; //行数

            public int Total = 0;       //总数
          
    }
}
