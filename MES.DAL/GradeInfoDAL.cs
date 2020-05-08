using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LanyunMES.DAL
{
    using Dapper;
    using Entity;
    using Lanyun.DBUtil;

    public class GradeInfoDAL
    {
        public GradeInfo GetModel(string moduleName)
        {
            string sql = "select * from GradeConf where keyWord = @moduleName";

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.QuerySingleOrDefault<GradeInfo>(sql, new { moduleName = moduleName });
            }
        }
    }
}
