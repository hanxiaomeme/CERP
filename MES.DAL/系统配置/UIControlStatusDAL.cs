using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.DAL
{
    using Dapper;
    using Entity;
    using Lanyun.DBUtil;

    public class UIControlStatusDAL
    {
        public UIControlStatus Get(string ctrlName)
        {
            string sql = "select * from UIControlStatus where ControlName = @ctrlName";
            
            using(var conn = DbHelperSQL.GetConnection())
            {
                return conn.QuerySingleOrDefault<UIControlStatus>(sql, new { ctrlName = ctrlName });
            }
        }
    }
}
