
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace LanyunMES.DAL
{
    using Dapper;
    using Entity;
    using Lanyun.DBUtil;

    public class ICTableFieldDAL
    {

        /// <summary>
        /// 获取模块数据库表字段配置信息
        /// </summary>
        /// <param name="fid">模块ID</param>
        /// <param name="tableName">表名</param>
        public static List<ICTableField> GetTableFields(int fTranType, string tableName = "")
        {
            string sql = "select * from ICTableField where FTranType = @Id ";

            if(!string.IsNullOrEmpty(tableName))
            {
                sql += " and FTableName = @tableName";
            }

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.Query<ICTableField>(sql, new { Id = fTranType, tableName = tableName }).ToList();
            }
        }
    }
}
