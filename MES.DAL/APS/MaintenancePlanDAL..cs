using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LanyunMES.DAL
{
    using Dapper;
    using Entity;
    using Lanyun.DBUtil;

    public class MaintenancePlanDAL
    {
 
        public DataTable GetDataTable(string[] wheres, params SqlParameter[] parameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from (");
            sb.Append("select t1.*, isnull(E.cEQCode, EC.cEQCCode) cEQCode, isnull(E.cEQName,EC.cEQCName) cEQName,");
            sb.Append(" case isnull(bClass,0) when 1 then '设备分类' else '设备明细' end bClassDesc");
            sb.Append(" from MaintenancePlan t1");
            sb.Append(" left join Equipment E on t1.EQId = E.EQId and isnull(t1.bClass,0) = 0");
            sb.Append(" left join EquipmentClass EC on t1.EQId = EC.EQCId and t1.bClass = 1");
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
        public DataTable GetDataTable(string cEQCode)
        {
            string[] where = new string[]
            {
                "cEQCode like @cEQCode + '%'"
            };

            SqlParameter p = new SqlParameter("@cEQCode", cEQCode);

            return GetDataTable(where, p);
        }

        public MaintenancePlan Get(string guid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select t1.*, isnull(E.cEQCode, EC.cEQCCode) cCode, isnull(E.cEQName,EC.cEQCName) cName,");
            sb.Append(" case isnull(bClass,0) when 1 then '设备分类' else '设备明细' end bClassDesc");
            sb.Append(" from MaintenancePlan t1 ");
            sb.Append(" left join Equipment E on t1.EQId = E.EQId and isnull(t1.bClass,0) = 0");
            sb.Append(" left join EquipmentClass EC on t1.EQId = EC.EQCId and t1.bClass = 1 ");
            sb.Append(" where t1.guid = @guid");

            var row = DbHelperSQL.Query(sb.ToString(), new SqlParameter("@guid", guid)).Tables[0].Rows[0];

            var model = DataHelper.DataRowToModel<MaintenancePlan>(row);

            model.DtBody = GetBodyTable(guid);

            return model;
        }

        public MaintenancePlans GetBody(int autoId)
        {
            string sql = "select * from MaintenancePlans where AutoId = @autoId";

            var row = DbHelperSQL.Query(sql, new SqlParameter("@autoId", autoId)).Tables[0].Rows[0];

            return DataHelper.DataRowToModel<MaintenancePlans>(row);
        }

        public List<MaintenancePlans> GetBodyList(string guid)
        {
            string sql = "select * from MaintenancePlans where guid = @guid";

            var dt = DbHelperSQL.Query(sql, new SqlParameter("@guid", guid)).Tables[0];

            List<MaintenancePlans> list = new List<MaintenancePlans>();

            foreach(DataRow r in dt.Rows)
            {
                list.Add(DataHelper.DataRowToModel<MaintenancePlans>(r));
            }

            return list;
        }

        public DataTable GetBodyTable(string guid)
        {
            string sql = "select * from MaintenancePlans where guid = @guid";

            return DbHelperSQL.Query(sql, new SqlParameter("@guid", guid)).Tables[0];
        }

        public string Add(MaintenancePlan model)
        {
            string guid = Guid.NewGuid().ToString();

            StringBuilder sb = new StringBuilder();
            sb.Append("insert into MaintenancePlan(guid, EQId, bClass, cMaker, dMakeDate)");
            sb.Append(" values(@guid, @EQId, @bClass)");

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@guid", guid),
                new SqlParameter("@EQId", model.EQId),
                new SqlParameter("@bClass", model.bClass),
                new SqlParameter("@cMaker", model.cMaker),
                new SqlParameter("@dMakeDate", DateTime.Now.Date)
            };

            SqlCommand cmd = new SqlCommand(sb.ToString());
            cmd.Parameters.AddRange(p);

            List<SqlCommand> cmdlist = new List<SqlCommand>();
            cmdlist.Add(cmd);

            foreach (DataRow r in model.DtBody.Rows)
            {
                sb.Clear();
                sb.Append("insert into MaintenancePlans(guid, dDate, stopHours, workHours, reason )");
                sb.Append(" values(@guid, @dDate, @stopHours, @workHours, @reason)");

                p = new SqlParameter[]
                {
                    new SqlParameter("@guid", guid),
                    new SqlParameter("@dDate", r["dDate"]),
                    new SqlParameter("@stopHours", r["stopHours"]),
                    new SqlParameter("@workHours", r["workHours"]),
                    new SqlParameter("@reason", r["reason"])
                };
            }

            DbHelperSQL.ExecuteSqlTran(cmdlist.ToArray());

            return guid;
        }

        public void Update(MaintenancePlan model)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update MaintenancePlan set EQId = @EQId, bClass = @bClass,");
            sb.Append("cModifier = @cModifier, dModifyDate = @dModifyDate where guid = @guid");

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@guid", model.guid),
                new SqlParameter("@EQId", model.EQId),
                new SqlParameter("@bClass", model.bClass),
                new SqlParameter("@cModifier", model.cModifier),
                new SqlParameter("@dModifyDate", model.dModifyDate)
            };

            SqlCommand cmd = new SqlCommand(sb.ToString());
            cmd.Parameters.AddRange(p);

            List<SqlCommand> cmdlist = new List<SqlCommand>();
            cmdlist.Add(cmd);

            foreach (DataRow r in model.DtBody.Rows)
            {
                sb.Clear();
                if (r.RowState == DataRowState.Added)
                {
                    sb.Append("insert into MaintenancePlans(guid, dDate, stopHours, workHours, reason )");
                    sb.Append(" values(@guid, @dDate, @stopHours, @workHours, @reason)");

                    p = new SqlParameter[]
                    {
                        new SqlParameter("@guid", model.guid),
                        new SqlParameter("@dDate", r["dDate"]),
                        new SqlParameter("@stopHours", r["stopHours"]),
                        new SqlParameter("@workHours", r["workHours"]),
                        new SqlParameter("@reason", r["reason"])
                    };
                }
                else if(r.RowState == DataRowState.Modified)
                {
                    sb.Append("update MaintenancePlans set dDate = @dDate, stopHours = @stopHours, ");
                    sb.Append(" workHours = @workHours, reason = @reason where autoId = @autoId ");

                    p = new SqlParameter[]
                    {
                        new SqlParameter("@autoId", r["AutoId"]),
                        new SqlParameter("@dDate", r["dDate"]),
                        new SqlParameter("@stopHours", r["stopHours"]),
                        new SqlParameter("@workHours", r["workHours"]),
                        new SqlParameter("@reason", r["reason"])
                    };
                }
                else if(r.RowState == DataRowState.Deleted)
                {
                    sb.Append("delete from MaintenancePlans where autoId = @autoId");
                    p = new SqlParameter[]
                    {
                        new SqlParameter("@autoId", r["autoId", DataRowVersion.Original])
                    };
                }

                cmd = new SqlCommand(sb.ToString());
                cmd.Parameters.AddRange(p);
                cmdlist.Add(cmd);
            }

            DbHelperSQL.ExecuteSqlTran(cmdlist.ToArray());
        }

        public bool Delete(string guid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from MaintenancePlan where guid = @guid");
            sb.Append("; delete from MaintenancePlans where guid = @guid");

            return DbHelperSQL.ExecuteSql(sb.ToString(), new SqlParameter("@guid", guid)) > 0;
        }

        public bool Exists(int EQId, DateTime dDate)
        {
            string sql = "select count(1) from MaintenancePlan t1 ";
            sql += " join MaintenancePlans t2 on t1.guid = t2.guid ";
            sql += " where EQId = @EQId and dDate = @dDate";

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@EQId", EQId),
                new SqlParameter("@dDate", dDate)
            };

            return DbHelperSQL.Exists(sql, p);
        }

    }
}
