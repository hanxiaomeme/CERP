using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.DAL
{
    using Dapper;
    using Entity;
    using Lanyun.DBUtil;
    using System.Data;
    using System.Data.SqlClient;

    public class UserDAL : IItemDAL<User>
    {
        public int Add(User model)
        {
            string sql = SQLBuilder.GetInsertSql("t_User");

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.Execute(sql, model);
            }
        }

        public bool Delete(int id)
        {
            string sql = "delete from t_User where UserId = @id";

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.Execute(sql, new { id = id }) > 0;
            }
        }

        public bool Exists(string userName)
        {
            string sql = "select count(1) from t_user where UserName = @cName";

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.QuerySingle<int>(sql, new { cName = userName }) > 0;
            }
        }

        public bool ExistsRef(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(string userName)
        {
            string sql = "select * from t_user where userName = @userName";

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.QuerySingleOrDefault<User>(sql, new { userName = userName });
            }
        }

        public List<User> GetList()
        {
            string sql = "select * from t_User";

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.Query<User>(sql).ToList();
            }
        }

        public DataTable GetTable(string userName = null)
        {
            string sql = "select t1.*, t2.FName as FDeptName from t_User t1 ";
            sql += " left join t_Department t2 on t1.FDeptID = t2.FItemID";

            if(string.IsNullOrEmpty(userName))
            {
                sql += " where t1.userName like '%' + @userName + '%'";
            }

            return DbHelperSQL.Query(sql, new SqlParameter("userName", userName)).Tables[0];
        }

        public bool Update(User model)
        {
            throw new NotImplementedException();
        }

        public bool HaveMenuAuth(int UserId, int MenuId)
        {
            string sql = "select count(1) from t_UserMenu where UserId = @userId and MenuID = @menuId";

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.QuerySingle<int>(sql, new { userId = UserId, menuId = MenuId }) > 0;
            }
        }
    }
}
