using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.DAL
{
    using Dapper;
    using Entity;
    using Lanyun.DBUtil;

    public class MouldClassDAL: ITreeDAL<MouldClass>, IItemDAL<MouldClass>
    {
        public List<MouldClass> GetList() 
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select MCId, cMCCode as Code, cMCName as Name, ");
            sb.Append("isEnd, cMaker, dCreateDate,");
            sb.Append(" dbo.GetGrade(cMCCode) Grade from MouldClass Order by cMCCode");

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.Query<MouldClass>(sb.ToString()).ToList();
            }
        }

        public int Add(MouldClass model)
        {
            model.dCreateDate = DateTime.Now.Date;

            string sql = SQLBuilder.GetInsertSql("MouldClass");

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.ExecuteScalar<int>(sql, model);
            }
        }

        public bool Delete(int Id)
        {
            string sql = "delete from MouldClass where MCId = @Id";

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.Execute(sql, new { @Id = Id }) > 0;
            }
        }

        public bool Update(MouldClass model)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update MouldClass set cMCCode = @Code, cMCName = @Name, ");
            sb.Append("isEnd = @isEnd, cMaker = @cMaker where MCId = @Id");

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.Execute(sb.ToString(), model) > 0;
            }
        }

        public bool Exists(string cCode)
        {
            string sql = "select count(1) from MouldClass where cMCCode = @cCode";

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.ExecuteScalar<int>(sql, new { @cCode = cCode }) > 0;
            }
        }

        public bool ExistsChild(string cCode)
        {
            string sql = "select count(1) from MouldClass where cMCCode like @cCode + '%'";

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.ExecuteScalar<int>(sql, new { @cCode = cCode }) > 1;
            }
        }

        public bool ExistsRef(int id)
        {
            string sql = "select count(1) from Mould where MCId = @id";

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.ExecuteScalar<int>(sql, new { MCId = id }) > 0;
            }
        }

        public MouldClass Get(int id)
        {
            string sql = "select * from MouldClass where id = @id";

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.QuerySingleOrDefault<MouldClass>(sql, new { id = id });
            }
        }
    }
}
