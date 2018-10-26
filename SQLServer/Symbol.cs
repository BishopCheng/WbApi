using System;
using System.Collections.Generic;
using System.Text;

namespace SQLServer
{
    /// <summary>
    /// 符号标签处理类
    /// 作者：程淮榕
    /// 时间：2018-10-26
    /// </summary>
    public class Symbol
    {
        private string Value;

        public Symbol(string value)
        {
            Value = value;
        }

        //符号直接转换成字符串
        public override string ToString()
        {
            return Value;
        }
    }
}
