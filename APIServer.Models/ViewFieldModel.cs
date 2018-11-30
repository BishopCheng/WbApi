using System;
using System.Collections.Generic;
using System.Text;

namespace APIServer.Models
{
    /// <summary>
    /// 视图属性
    /// </summary>
     public class ViewFieldModel
    {
        public string 视图编码 { get; set; }

        public int 字段序号 { get; set; }

        public string 字段名 { get; set; }

        public string 标识 { get; set; }

        public string 主键 { get; set; }

        public string 类型 { get; set; }

        public int 占用字节数 { get; set; }

        public int 长度 { get; set; }

        public int 小数位数 { get; set; }

        public string 允许空 { get; set; }

        public string 默认值 { get; set; }

        public string 数据源 { get; set; }

        public string 说明 { get; set; }
    }
}
