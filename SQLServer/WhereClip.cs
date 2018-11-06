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
                                text = ((!text.Contains(list[num].ParameterName + ",")) ? text.Replace(list[num].ParameterName + " ", list[num].ParameterName + "_" + count + " ") : text.Replace(list[num].ParameterName + ",", list[num].ParameterName + "_" + count + ","));
                                list[num].ParameterName = list[num].ParameterName + "_" + count; 
                            }
                        }
                        lstDbParameter.AddRange(list);  //将转换好的list装入参数集合容器
                        stringBuilder.Append(" " + text);
                    }
                }
            }
            else
            {
                using (IEnumerator<object> enumerator2 = GetEnumerator())
                {
                    while (enumerator2.MoveNext())
                    {
                        object current = enumerator2.Current;
                        //如果是符号,将其转换成字符串类型
                        if(current is Symbol)
                        {
                            stringBuilder.Append(current.ToString());
                        }
                        else if(current is ConditionItem)
                        {
                            ConditionItem conditionItem2 = new ConditionItem();
                            conditionItem2 = current as ConditionItem;
                            List<DbParameter> lstDbParameter2 = new List<DbParameter>();
                            if (conditionItem2.lstDbParmeters != null)
                            {
                                for (int j = 0; j < conditionItem2.lstDbParmeters.Count; j++)
                                {
                                    lstDbParameter2.Add(excuteImport.DbParameterCopy(conditionItem2.lstDbParmeters[j]));
                                }
                            }
                            string text2 = conditionItem2.sqlStr;
                            int count3 = lstDbParameter.Count;
                            int count4 = lstDbParameter2.Count;
                            if (count4 > 0)
                            {
                                text2 = text2.Replace(lstDbParameter2[count4 - 1].ParameterName, lstDbParameter2[count4 - 1].ParameterName + "_" + count3);
                                lstDbParameter2[count4 - 1].ParameterName = lstDbParameter2[count4 - 1].ParameterName + "_" + count3;
                            }
                            else if(count4>1)
                            {
                                for (int num2 = lstDbParameter2.Count-2; num2 >=0; num2--)
                                {
                                    text2 = ((!text2.Contains(lstDbParameter2[num2].ParameterName + ",")) ? text2.Replace(lstDbParameter2[num2].ParameterName + " ", lstDbParameter2[num2].ParameterName + "_" + count3 + " ") : text2.Replace(lstDbParameter2[num2].ParameterName + ",", lstDbParameter2[num2].ParameterName + "_" + count3 + "_"));
                                    lstDbParameter2[num2].ParameterName = lstDbParameter2[num2] + "_" + count3;
                                }
                            }
                            lstDbParameter.AddRange(lstDbParameter2);
                            stringBuilder.Append(" " + text2);
                        }
                    }

                }

            }
            //获取whereClip的String格式
            stringBuilder.Append(" ");
            sqlWhereClip = stringBuilder.ToString();
        }

        /// <summary>
        /// 重写Tostring方式
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (flag)
            {
                using(IEnumerator<object>enumerator = GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        ConditionItem conditionItem = (ConditionItem)enumerator.Current;
                        if (stringBuilder.Length > 0)
                        {
                            stringBuilder.Append(" AND ");
                        }
                        string text = conditionItem.sqlStr;  //转换成text
                        if (conditionItem.lstDbParmeters != null)
                        {
                            foreach (DbParameter item in conditionItem.lstDbParmeters)
                            {
                                text = text.Replace(item.ParameterName, DataToSQL(item.Value));  //将ParameterName转换成SQL格式
                            }
                        }
                        stringBuilder.Append(" " + text);
                    }
                }
            }
            else
            {
                using (IEnumerator<object>enumerator3 = GetEnumerator())
                {
                    while (enumerator3.MoveNext())
                    {
                        object current2 = enumerator3.Current;
                        if(current2 is Symbol)
                        {
                            stringBuilder.Append(current2.ToString());
                        }
                        else if(current2 is ConditionItem)
                        {
                            ConditionItem conditionItem2 =current2 as ConditionItem; //将当前参数转换成ConditionItem类型
                            string text2 = conditionItem2.sqlStr;
                            if (conditionItem2.lstDbParmeters != null)
                            {
                                foreach (DbParameter item in conditionItem2.lstDbParmeters)
                                {
                                    text2 = text2.Replace(item.ParameterName, DataToSQL(item.Value));
                                }
                            }
                            stringBuilder.Append(" " + text2);
                        }
                    }
                }
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// 将传入的对象转换成sql语句字符串
        /// </summary>
        /// <param name="value">传入的对象</param>
        /// <returns></returns>
        private string DataToSQL(object value)
        {
            //允许传入空值，当给出空值时，返回字符串“NULL”以确保不会报错
            if (value != null)
            {
                switch (value.GetType().ToString().Replace("System.", ""))
                {
                    case "String":
                        return "'" + value + "'";
                    case "Int64":
                        return value.ToString();
                    case "Byte":
                        return "'" + value + "'";
                    case "Byte[]":
                        return "'" + value + "'";
                    case "Boolean":
                        return "'" + value + "'";
                    case "DateTime":
                        return "'" + value + "'";
                    case "Decimal":
                        return value.ToString();
                    case "Double":
                        return value.ToString();
                    case "Int32":
                        return value.ToString();
                    case "Int16":
                        return value.ToString();
                    case "Guid":
                        return "'" + value + "'";
                    default:
                        return value.ToString();
                }
            }
            return "null";
        }
    }
}
