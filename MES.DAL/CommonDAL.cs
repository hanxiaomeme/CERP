using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanyunMES.DAL
{
    using Dapper;
    using Lanyun.DBUtil;

    public class CommonDAL
    {
 
        /// <summary>
        /// 获取单据号
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fieldName">单据号字段</param>
        /// <param name="prefix">前缀+日期:MM190120</param>
        public static string GetNewCode(string tableName, string fieldName, string prefix)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select right(right(isnull(max(" + fieldName);
            sb.Append("),0),3) + 1001, 3) from " + tableName);
            sb.Append(" where " + fieldName + " like @prefix + '%'");

            using (var conn = DbHelperSQL.GetConnection())
            {
                return prefix + conn.QuerySingle<string>(sb.ToString(), new { prefix = prefix });
            }
        }

        /// <summary>
        /// 获取表体update语句
        /// </summary>
        public static string GetUpdateSql(string tableName, string keyFieldName, string dbName = "")
        {
            string sql = "";
            if(dbName != "")
            {
                sql += "use " + dbName + "; \r\n";
            }
            sql += "select t1.* from sys.columns t1 join sys.objects t2 on t1.object_id = t2.object_id where t2.name = @tableName";
            sql += " and t1.is_identity = 0";

            using (var conn = DbHelperSQL.GetConnection())
            {
                var list = conn.Query<dynamic>(sql, new { tableName = tableName }).ToList();

                StringBuilder sb = new StringBuilder("update " + tableName + " set ");
                list.ForEach(x =>
                {
                    sb.Append(x.name + "= @" + x.name + ", ");
                });

                sql = sb.ToString().Substring(0, sb.Length - 2);

                sql += " where " + keyFieldName + " = @" + keyFieldName;
                return sql;
            };
        }

        /// <summary>
        /// 获取insert语句
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        public static string GetInsertSql(string tableName, string dbName = "", params string[] filterFields)
        {
            string sql = "";
            if (dbName != "")
            {
                sql += "use " + dbName + "; \r\n";
            }

            sql += "select t1.* from sys.columns t1 join sys.objects t2 on t1.object_id = t2.object_id ";
            sql += " where t2.name = @tableName ";

            if (filterFields != null && filterFields.Length > 0)
            {
                sql += " and t1.name not in ('" + string.Join("','", filterFields) + "')";
            }

            using (var conn = DbHelperSQL.GetConnection())
            {
                var list = conn.Query<dynamic>(sql, new { tableName = tableName }).ToList();

                string strOutput = "";
                StringBuilder sb = new StringBuilder("insert into " + tableName + "(");
                list.ForEach(x =>
                {
                    if (!x.is_identity)
                    {
                        sb.Append(x.name + ", ");
                    }
                    else
                    {
                        strOutput = " output inserted." + x.name;
                    }
                });

                sb.Remove(sb.Length - 2, 2);
                sb.Append(")");
                sb.Append(strOutput);

                sb.Append(" values( ");
                list.ForEach(x =>
                {
                    if (!x.is_identity)
                    {
                        sb.Append("@" + x.name + ", ");
                    }
                });


                sql = sb.ToString().Substring(0, sb.Length - 2) + ")";
                return sql;
            }
        }

    }
}
