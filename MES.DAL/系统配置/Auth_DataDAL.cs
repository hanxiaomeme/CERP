using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanyunMES.DAL
{
    using Dapper;
    using Entity;
    using Lanyun.DBUtil;

    /// <summary>
    /// 用户金额权限
    /// </summary>
    public class Auth_DataDAL
    {
        public bool Exist(int fTranType, int userId)
        {
            string sql = "select count(1) from t_Auth_Data t1 ";
            sql += " join t_UserRole t2 on t1.RoleId = t2.RoleID ";
            sql += " where t1.FTranType = @fTranType and t2.UserId = @userId";

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.QuerySingle<int>(sql, new { fTranType = fTranType, userId = userId }) > 0;
            }
        }
    }
}
