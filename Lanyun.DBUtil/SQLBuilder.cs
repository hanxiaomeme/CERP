using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
 
namespace Lanyun.DBUtil
{
    public class SQLBuilder
    {     
        /// <summary>
        /// 通过表名获取Insert语句
        /// </summary>
        public static string GetInsertSql(string tableName, string dbName = null, params string[] filterFields)
        {
            string T = tableName;
            string colTable = "sys.columns";
            string objTable = "sys.objects";

            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(dbName))
            {
                T = dbName + ".." + tableName;
                colTable = dbName + "." + colTable;
                objTable = dbName + "." + objTable;
            }

            string sql = "select t1.* from " + colTable + " t1 ";
            sql += " join " + objTable + " t2 on t1.object_id = t2.object_id ";
            sql += " where t2.name = @tableName ";

            if (filterFields != null && filterFields.Length > 0)
            {
                sql += " and t1.name not in ('" + string.Join("','", filterFields) + "')";
            }

            sb.Append("insert into " + T + "(");

            var dt = DbHelperSQL.Query(sql, new SqlParameter("tableName", tableName)).Tables[0];

            string sqloutput = "";

            foreach(DataRow row in dt.Rows)
            {
                if (Convert.ToBoolean(row["is_identity"]))
                {
                    sqloutput = " output inserted." + row["name"];
                }
                else
                {
                    sb.Append(row["name"] + ", ");
                }
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append(") ");

            if (!string.IsNullOrEmpty(sqloutput)) sb.Append(sqloutput);

            sb.Append(" values (");

            foreach (DataRow row in dt.Rows)
            {
                if (!Convert.ToBoolean(row["is_identity"]))
                {
                    sb.Append("@" + row["name"] + ", ");
                }
            }

            sql = sb.ToString().Substring(0, sb.Length - 2) + ")";
            return sql;
        }

        /// <summary>
        /// 通过表名获取update语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="keyFieldName">主键</param>
        /// <param name="dbName">数据库名</param>
        /// <param name="filterFields">过滤字段</param>
        public static string GetUpdateSql(string tableName, string keyFieldName, string dbName = null, params string[] filterFields)
        {
            string T = tableName;
            string colTable = "sys.columns";
            string objTable = "sys.objects";

            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(dbName))
            {
                T = dbName + ".." + tableName;
                colTable = dbName + "." + colTable;
                objTable = dbName + "." + colTable;
            }

            var ls = new List<string>();

            ls.Add(keyFieldName);

            if (filterFields == null) ls.AddRange(filterFields.ToArray());

            string sql = "select t1.* from " + colTable + " t1 ";
            sql += " join " + objTable + " t2 on t1.object_id = t2.object_id ";
            sql += " where t2.name = @tableName and t1.is_identity = 0";
            sql += " and t1.name not in ('" + string.Join("','", ls.ToArray()) + "')";

            if (filterFields != null && filterFields.Length > 0)
            {
                sql += " and t1.name not in ('" + string.Join("','", filterFields) + "')";
            }

            sb.Append("update " + T + " set ");

            var dt = DbHelperSQL.Query(sql, new SqlParameter("tableName", tableName)).Tables[0];

            foreach(DataRow row in dt.Rows)
            {
                sb.Append(row["name"] + "= @" + row["name"] + ", ");
            }

            sql = sb.ToString().Substring(0, sb.Length - 2);

            sql += " where " + keyFieldName + " = @" + keyFieldName;

            return sql;
        }
    }

    public class SysColumns
    {
        public int object_id { get; set; }

        /// <summary>
        /// 列名
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 列顺序
        /// </summary>
        public int column_id { get; set; }

        /// <summary>
        /// 是否自增列
        /// </summary>
        public bool is_identity { get; set; }

        public int max_length { get; set; }
    }
}

  
