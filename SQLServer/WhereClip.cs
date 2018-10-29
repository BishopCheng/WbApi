using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Text;

namespace SQLServer
{
    /// <summary>
    /// 查询条件类
    /// 作者：程淮榕
    /// 时间：2018-10-26
    /// </summary>
    [Serializable]  //声明该类可以被序列化
    public class WhereClip:Collection<object>   //继承自Object
    {
        public bool flag = true;

        public WhereClip AddClip(ConditionItem value)
        {
            flag = true;
            Add(value);
            return this;
        }

        public WhereClip AddComClip(ConditionItem value)
        {
            flag = true;
            Add(value);
            return this;
        }

        public WhereClip ClearClip()
        {
            Clear();
            return this;
        }

        /// <summary>
        /// 获取参数列表
        /// </summary>
        public void GetPartmerStrings(ExcuteImport excuteImport,ref string sqlWhereClip,ref List<DbParameter>lstDbParameter)
        {
            StringBuilder stringBuilder = new StringBuilder(); //新建一个可变长度的字符串拼接类
            if (flag)
            {
                using (IEnumerator<object>enumerator = GetEnumerator())   //使用集合迭代器
                {
                    while (enumerator.MoveNext()) //操作集合中的数据
                    {
                        ConditionItem conditionItem = (ConditionItem)enumerator.Current;   //将迭代器中的数据转换成ConditionItem类型
                        if (stringBuilder.ToString().Length > 0)
                        {
                            stringBuilder.Append(" AND ");   //在现有字符串后面拼接上AND
                        }
                        List<DbParameter> list = new List<DbParameter>();   //新建一个参数集合
                        if (conditionItem.lstDbParmeters != null)
                        {
                            //如果该数据的参数集合不为空,则向参数列表中添加参数
                            for (int i = 0; i < conditionItem.lstDbParmeters.Count; i++)
                            {
                                list.Add(excuteImport.DbParameterCopy(conditionItem.lstDbParmeters[i]));
                            }
                        }
                        string text = conditionItem.sqlStr;   //将ConditionItem写成成Sql语句式
                        int count = lstDbParameter.Count;
                        int count2 = list.Count;
                        if (count2 > 0)
                        {
                            text = text.Replace(list[count2 - 1].ParameterName, list[count2 - 1].ParameterName + "_" + count);
                            list[count2 - 1].ParameterName = list[count2 - 1].ParameterName + "_" + count;
                        }
                        if (count2 > 1)
                        {
                            for (int num = list.Count-2; num >=0; num--)
                            {
                                text = ((!text.Contains(list[num].ParameterName + ",")) ? text.Replace(list[num].ParameterName + "  ", list[num].ParameterName + "_" + count + " ") : text.Replace(list[num].ParameterName + ",", list[num].ParameterName + "_" + count + ","));
                            }
                        }
                    }
                }
            }
        }
    }
}
