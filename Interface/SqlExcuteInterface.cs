using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ApiServer.Interface
{
    /// <summary>
    /// Sql语句执行通用接口
    /// 作者：程淮榕
    /// 时间：2018-10-07
    /// </summary>
    public interface SqlExcuteInterface
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlList"></param>
        /// <returns></returns>
        int ExcuteNotQuery(IList<string> sqlList);

        
    }
}
