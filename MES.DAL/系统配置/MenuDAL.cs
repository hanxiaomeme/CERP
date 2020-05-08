using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.DAL
{
    using Dapper;
    using Lanyun.DBUtil;
    using Entity;

    public class MenuDAL: IItemDAL<Menu>
    {
        public Menu Get(int MenuId)
        {
            string sql = "select * from t_Menu where FItemID = @id";

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.QuerySingleOrDefault<Menu>(sql, new { id = MenuId });
            }
        }

        public List<Menu> GetList()
        {
            string sql = "select *, dbo.GetGrade(FNumber) FLevel from t_Menu order by FNumber";

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.Query<Menu>(sql).ToList();
            }
        }

        public List<Menu> GetList(string UserName)
        {
            string sql = "select t1.*,dbo.GetGrade(t1.FNumber) FLevel from t_Menu t1 ";
            sql += " join t_UserMenu t2 on t1.FItemID = t2.MenuID";
            sql += " join t_User t3 on t2.UserID = t3.UserID";
            sql += " where t3.UserName = @userName and isnull(t1.IsStop,0) = 0 order by t1.FNumber";
 
            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.Query<Menu>(sql, new { userName = UserName }).ToList();
            }
        }

        public int Add(Menu model)
        {
            string sql = SQLBuilder.GetInsertSql("t_Menu");

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.ExecuteScalar<int>(sql, model);
            }
        }

        public bool Update(Menu model)
        {
            string sql = SQLBuilder.GetUpdateSql("t_Menu", "FItemID");

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.Execute(sql, model) > 0;
            }
        }

        public bool Delete(int MenuId)
        {
            string sql = "delete from t_Menu where FItemID = @id";

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.Execute(sql, new { id = MenuId }) > 0;
            }
        }

        public bool Exists(string FNumber)
        {
            string sql = "select count(1) from t_Menu where FNumber = @code";

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.QuerySingle<int>(sql, new { code = FNumber }) > 0;
            }
        }

        public bool ExistsRef(int FItemID)
        {
            string sql = "select count(1) from t_UserMenu where MenuID = @id";

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.QuerySingle<int>(sql, new { id = FItemID }) > 0;
            }
        }
    }
}
