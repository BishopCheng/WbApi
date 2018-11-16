using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Collections.ObjectModel;

namespace SQLServer
{   
     /// <summary>
     /// 分组条件类
     /// 作者：程淮榕
     /// 日期：2018-11-16
     /// </summary>
     [Serializable]
     public class GroupByClip:Collection<Column>
    {
        public GroupByClip AddClip(Column column)
        {
            Add(column);
            return this;
        }

        public GroupByClip Clear()
        {
            this.Clear();
            return this;
        }

        
    }
}
