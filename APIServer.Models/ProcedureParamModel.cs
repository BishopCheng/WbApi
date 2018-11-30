using System;
using System.Collections.Generic;
using System.Text;

namespace APIServer.Models
{
     public  class ProcedureParamModel
    {
        public int 参数编号 { get; set; }

        public string 存储过程编码 { get; set; }

        public string 参数取向 { get; set; }

        public string 字段名 { get; set; }

        public string 类型 { get; set; }

        public int 占用字节数 { get; set; }

        public int 长度 { get; set; }

        public int 小数位数 { get; set; }
    }
}
