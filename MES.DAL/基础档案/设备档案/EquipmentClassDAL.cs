using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace LanyunMES.DAL
{
    using Dapper;
    using Entity;
    using Lanyun.DBUtil;

    public class EquipmentClassDAL: ITreeDAL<EquipmentClass>
    {
        public List<EquipmentClass> GetList()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select EQCId, cEQCCode as Code, cEQCName as Name, IsEnd, cMaker, dCreateDate, ");
            sb.Append(" dbo.GetGrade(cEQCCode) Grade from EquipmentClass Order by cEQCCode");

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.Query<EquipmentClass>(sb.ToString()).ToList();
            }
        }

        public int Add(EquipmentClass model)
        {
            model.dCreateDate = DateTime.Now.Date;
            string sql = SQLBuilder.GetInsertSql("EquipmentClass");

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.ExecuteScalar<int>(sql, model);
            }
        }

        public bool Delete(int Id)
        {
            string sql = "delete from EquipmentClass where EQCId = @Id";

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.Execute(sql, new { @Id = Id }) > 0;
            }
        }

        public bool Update(EquipmentClass model)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update EquipmentClass set cEQCCode = @cEQCCode, cEQCName = @cEQCName, ");
            sb.Append("isEnd = @isEnd, cMaker = @cMaker where EQCId = @Id");

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.Execute(sb.ToString(), model) > 0;
            }
        }

        public bool Exists(string cCode)
        {
            string sql = "select count(1) from EquipmentClass where cEQCCode = @cCode";

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.ExecuteScalar<int>(sql, new { @cCode = cCode }) > 0;
            }
        }

        public bool ExistsChild(string cCode)
        {
            string sql = "select count(1) from EquipmentClass where cEQCCode like @cCode + '%'";

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.ExecuteScalar<int>(sql, new { @cCode = cCode }) > 1;
            }
        }

        public bool ExistsRef(int id)
        {
            string sql = "select count(1) from Equipment where EQCId = @id";

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.ExecuteScalar<int>(sql, new { @id = id }) > 0;
            }
        }

    }
}
