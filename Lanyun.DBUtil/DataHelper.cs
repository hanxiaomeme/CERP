using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Lanyun.DBUtil
{
    public class DataHelper
    {
        /// <summary>
        /// DataRow 转换对象
        /// </summary>
        public static T DataRowToModel<T>(DataRow row) where T : new()
        {
            T model = new T();

            foreach (var p in typeof(T).GetProperties())
            {
                if (row.Table.Columns.Contains(p.Name))
                {
                    if (p.CanWrite)
                    {
                        var value = row[p.Name] == DBNull.Value ? null : row[p.Name];

                        if (value == null)
                        {
                            if (value is int) continue;
                            if (value is double) continue;
                            if (value is decimal) continue;
                            if (value is DateTime) continue;
                        }

                        p.SetValue(model, value, null);
                    }
                }
            }
            return model;
        }
  
        /// <summary>
        /// DataTable 转换为List对象
        /// </summary>
        public static List<T> DataTableToModel<T>(DataTable dt) where T : new()
        {
            List<T> ls = new List<T>();

            foreach (DataRow row in dt.Rows)
            {
                ls.Add(DataRowToModel<T>(row));
            }

            return ls;
        }

        public static object SqlNull(object obj)
        {
            return obj == null ? DBNull.Value : obj;
        }

        /// <summary>
        /// 动态类List转DataTable
        /// </summary>
        public static DataTable ModelToDataTable(dynamic model)
        {
            DataTable dt = new DataTable();
            DataColumn column;

            var row = dt.NewRow();

            foreach ( var p in (model as object).GetType().GetProperties())
            {
                string name = p.Name;

                if (dt.Columns[name] == null)
                {
                    column = new DataColumn(name, p.PropertyType);
                    dt.Columns.Add(column);
                }

                row[name] = p.GetValue(model, null);
            }

            return dt;
        }

        public static DataTable ModelToDataTable(List<dynamic> ls)
        {
            DataTable dt = new DataTable();
            DataColumn column;

            ls.ForEach(x =>
            {
                DataRow row = dt.NewRow();

                foreach (var p in (x as object).GetType().GetProperties())
                {
                    string name = p.Name;

                    if (dt.Columns[name] == null)
                    {
                        column = new DataColumn(name, p.PropertyType);
                        dt.Columns.Add(column);
                    }

                    row[name] = p.GetValue(x, null);
                }
            });

            return dt;
        }

        /// <summary> 
        /// 将实体类转换成DataTable 
        /// </summary> 
        /// <typeparam name="T"></typeparam> 
        /// <param name="i_objlist"></param> 
        /// <returns></returns> 
        public static DataTable ModelToDataTable<T>(IList<T> objlist)
        {
            if (objlist == null || objlist.Count <= 0)
            {
                return null;
            }
            DataTable dt = new DataTable(typeof(T).Name);
            DataColumn column;
            DataRow row;

            PropertyInfo[] myPropertyInfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (T t in objlist)
            {
                if (t == null)
                {
                    continue;
                }

                row = dt.NewRow();

                for (int i = 0, j = myPropertyInfo.Length; i < j; i++)
                {
                    PropertyInfo pi = myPropertyInfo[i];

                    string name = pi.Name;

                    if (dt.Columns[name] == null)
                    {
                        column = new DataColumn(name, pi.PropertyType);
                        dt.Columns.Add(column);
                    }

                    row[name] = pi.GetValue(t, null);
                }

                dt.Rows.Add(row);
            }
            return dt;
        }
 
    }
}
