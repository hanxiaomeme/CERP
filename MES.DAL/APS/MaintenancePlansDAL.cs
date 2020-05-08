using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LanyunMES.DAL
{
    using Entity;
    using Lanyun.DBUtil;

    public class MaintenancePlansDAL
    {
        string ufdb = "A";

        public DataTable GetTable(string[] wheres, params SqlParameter[] parameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from (");
            sb.Append("select t1.*, E.cEQCode, E.cEQName, E.workHours as iHours,");
            sb.Append("EC.cEQCCode, EC.cEQCName from MaintenancePlans t1");
            sb.Append(" left join Equipment E on t1.EQId = E.EQId ");
            sb.Append(" left join EquipmentClass EC on E.EQCId = EC.EQCId");
            sb.Append(") T ");

            if (wheres != null && wheres.Length > 0)
            {
                sb.Append(" where " + string.Join(" and ", wheres));
            }
            sb.Append(" order by cEQCode");

            return DbHelperSQL.Query(sb.ToString(), parameters).Tables[0];
        }

        /// <summary>
        /// 根据设备编码查询
        /// </summary>
        public DataTable GetTable(string cEQCode)
        {
            string[] where = new string[]
            {
                "cEQCode like @cEQCode + '%'"
            };

            SqlParameter p = new SqlParameter("@cEQCode", cEQCode);

            return GetTable(where, p);
        }

        public MaintenancePlans Get(int autoId)
        {
            string[] wheres = new string[] { "AutoID = @autoId" };

            var row = GetTable(wheres, new SqlParameter("@autoId", autoId)).Rows[0];

            var model = DataHelper.DataRowToModel<MaintenancePlans>(row);

            return model;
        }


        public bool Add(MaintenancePlans model)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into MaintenancePlans(EQId, dDate, stopHours, workHours, reason, cMaker, dCreateDate)");
            sb.Append(" values(@EQId, @dDate, @stopHours, @workHours, @reason, @cMaker, @dCreateDate)");

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@EQId", model.EQId),
                new SqlParameter("@dDate", model.dDate),
                new SqlParameter("@stopHours", model.stopHours),
                new SqlParameter("@workHours", model.workHours),
                new SqlParameter("@reason", DataHelper.SqlNull(model.reason)),
                new SqlParameter("@cMaker", model.cMaker),
                new SqlParameter("@dCreateDate", DateTime.Now.Date)
            };


            return DbHelperSQL.ExecuteSql(sb.ToString(), p) > 0;
        }

        public bool Update(MaintenancePlans model)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("update MaintenancePlans set dDate = @dDate, EQId = @EQId, stopHours = @stopHours, ");
            sb.Append(" workHours = @workHours, reason = @reason where autoId = @autoId ");

            var p = new SqlParameter[]
            {
                new SqlParameter("@autoId", model.AutoId),
                new SqlParameter("@EQId", model.EQId),
                new SqlParameter("@dDate", model.dDate),
                new SqlParameter("@stopHours", model.stopHours),
                new SqlParameter("@workHours",model.workHours),
                new SqlParameter("@reason", DataHelper.SqlNull(model.reason))
            };
               
            return DbHelperSQL.ExecuteSql(sb.ToString(), p) > 0;
        }

        public bool Delete(int AutoId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from MaintenancePlans where AutoId = @AutoId");

            return DbHelperSQL.ExecuteSql(sb.ToString(), new SqlParameter("@AutoId", AutoId)) > 0;
        }

        public bool Exists(int EQId, DateTime dDate)
        {
            string sql = "select count(1) from MaintenancePlans where EQId = @EQId and dDate = @dDate";

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@EQId", EQId),
                new SqlParameter("@dDate", dDate)
            };

            return DbHelperSQL.Exists(sql, p);
        }

    }
}
