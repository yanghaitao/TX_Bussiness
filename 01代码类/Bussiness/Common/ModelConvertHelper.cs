﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace Bussiness.Common
{
    public class ModelConvertHelper<T> where T : new()
    {
        public static IList<T> ConvertToModel(DataTable dt)
        {
            // 定义集合
            IList<T> ts = new List<T>();

            // 获得此模型的类型
            Type type = typeof(T);

            string tempName = "";

            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();

                // 获得此模型的公共属性
                PropertyInfo[] propertys = t.GetType().GetProperties();

                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;

                    // 检查DataTable是否包含此列
                    if (dt.Columns.Contains(tempName))
                    {
                        object value = dr[tempName];
                        pi.SetValue(t, value, null);
                    }
                }

                ts.Add(t);
            }

            return ts;

        }
    }
}
