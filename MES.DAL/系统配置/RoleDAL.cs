using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.DAL 
{
    using Entity;
    using Dapper;
    using Lanyun.DBUtil;
    using System.Data;

    public class RoleDAL
    {
        public RoleUserDTO GetRoleUserDTO(int Id)
        {
            string sql = "select * from t_Role where RoleID = @Id";

            using (var conn = DbHelperSQL.GetConnection())
            {
                var role = conn.QuerySingle<RoleUserDTO>(sql, new { Id = Id });

                sql = "select t1.* from t_User t1 join t_UserRole t2 on t1.RoleID = t2.RoleID";
                sql += " where t2.RoleID = @Id";

                role.UserList = conn.Query<User>(sql, new { Id = Id }).ToList();

                return role;
            }
        }

        public Role GetModel(int Id)
        {
            string sql = "select * from t_Role where RoleID = @Id";

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.QuerySingleOrDefault<Role>(sql, new { Id = Id });
            }
        }

        public int Add(Role role)
        {
            string sql = SQLBuilder.GetInsertSql("t_Role");

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.ExecuteScalar<int>(sql, role);
            }
        }

        public bool Update(Role role, IDbTransaction tran)
        {
            string sql = SQLBuilder.GetUpdateSql("t_Role", "RoleID");
   
            return tran.Connection.Execute(sql, role, tran) > 0;
             
        }

        public bool AddUser(int roleId, int userId, IDbTransaction tran)
        {
            string sql = SQLBuilder.GetInsertSql("t_UserRole");

            return tran.Connection.Execute(sql, new { UserID = userId, RoleID = roleId }, tran) > 0;
        }

        public bool DeleteUser(int roleId, int userId, IDbTransaction tran)
        {
            string sql = "delete from t_UserRole where RoleID = @RoleID and UserID = @UserID";

            return tran.Connection.Execute(sql, new { UserID = userId, RoleID = roleId }, tran) > 0;
        }
    }
}
