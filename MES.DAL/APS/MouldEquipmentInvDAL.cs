using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LanyunMES.DAL
{
    using Entity;
    using Lanyun.DBUtil;

    public class MouldEquipmentInvDAL
    {
 
        public MouldEquipmentInv Get()
        {
            return null;
        }

        public DataTable GetInvTable(string[] wheres, params SqlParameter[] parameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select distinct * from (");
            sb.Append("select t1.cInvCode, inv.cInvName, inv.cInvStd from MouldEquipmentInv t1 ");
            sb.Append(") T ");

            if (wheres != null && wheres.Length > 0)
            {
                sb.Append(" where " + string.Join(" and ", wheres));
            }

            return DbHelperSQL.Query(sb.ToString(), parameters).Tables[0];
        }

        public DataTable GetTableByInv(string cInvCode)
        {
            string[] wheres = new string[] { "cInvCode = @cInvCode" };

            SqlParameter p = new SqlParameter("@cInvCode", cInvCode);

            return GetTable(wheres, p);
        }

        public DataTable GetTableByMould(string MId)
        {
            string[] wheres = new string[] { "MId = @MId" };

            SqlParameter p = new SqlParameter("@MId", MId);

            return GetTable(wheres, p);
        }

        public DataTable GetTable(string[] wheres, params SqlParameter[] parameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from (");
            sb.Append("select t1.*, inv.cInvName, inv.cInvStd, m.cMCode, m.cMName, m.Points, ");
            sb.Append(" isnull(e.cEQCode, ec.cEQCCode) cEQCode, isnull(e.cEQName, ec.cEQCName) cEQName,");
            sb.Append(" case t1.bClass when 1 then '设备分类' else '设备明细' end bClassDesc");
            sb.Append(" from MouldEquipmentInv t1 ");
            sb.Append(" left join Mould m on t1.MId = m.MId");
            sb.Append(" left join Equipment e on t1.EQId = e.EQId and t1.bClass = 0");
            sb.Append(" left join EquipmentClass ec on t1.EQId = ec.EQCId and t1.bClass = 1");
            sb.Append(") T ");

            if (wheres != null && wheres.Length > 0)
            {
                sb.Append(" where " + string.Join(" and ", wheres));
            }

            return DbHelperSQL.Query(sb.ToString(), parameters).Tables[0];
        }

        public void Update(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            SqlParameter[] p = null;
            SqlCommand cmd;
            List<SqlCommand> cmdlist = new List<SqlCommand>();

            foreach(DataRow r in dt.Rows)
            {
                sb.Clear();
                if(r.RowState == DataRowState.Added)
                {
                    var model = DataHelper.DataRowToModel<MouldEquipmentInv>(r);

                    sb.Append("insert into MouldEquipmentInv(cInvCode, MId, EQId, bClass, iOrder, iStep, timeQty, cMemo)");
                    sb.Append(" values(@cInvCode, @MId, @EQId, @bClass, @iOrder, @iStep, @timeQty, @cMemo)");

                    p = new SqlParameter[]
                    {
                        new SqlParameter("@cInvCode", model.cInvCode),
                        new SqlParameter("@MId", model.MId),
                        new SqlParameter("@EQId", model.EQId),
                        new SqlParameter("@bClass", model.bClass),
                        new SqlParameter("@iOrder", model.iOrder),
                        new SqlParameter("@iStep", model.iStep),
                        new SqlParameter("@timeQty", model.timeQty),
                        new SqlParameter("@cMemo", DataHelper.SqlNull(model.cMemo))
                    };
                }
                else if(r.RowState == DataRowState.Modified)
                {
                    var model = DataHelper.DataRowToModel<MouldEquipmentInv>(r);

                    sb.Append("update MouldEquipmentInv set cInvCode = @cInvCode, MId = @MId, EQId = @EQId, bClass = @bClass, ");
                    sb.Append("iOrder = @iOrder, iStep = @iStep, timeQty = @timeQty, cMemo = @cMemo where AutoId = @AutoID");

                    p = new SqlParameter[]
                    {
                        new SqlParameter("@cInvCode", model.cInvCode),
                        new SqlParameter("@MId", model.MId),
                        new SqlParameter("@EQId", model.EQId),
                        new SqlParameter("@bClass", model.bClass),
                        new SqlParameter("@iOrder", model.iOrder),
                        new SqlParameter("@iStep", model.iStep),
                        new SqlParameter("@timeQty", model.timeQty),
                        new SqlParameter("@cMemo", DataHelper.SqlNull(model.cMemo)),
                        new SqlParameter("@AutoID", model.AutoId)
                    };
                }
                else if(r.RowState == DataRowState.Deleted)
                {
                    sb.Append("delete from MouldEquipmentInv where AutoID = @AutoId");

                    p = new SqlParameter[]
                    {
                        new SqlParameter("@AutoId", r["AutoId", DataRowVersion.Original])
                    };
                }

                cmd = new SqlCommand(sb.ToString());
                cmd.Parameters.AddRange(p);
                cmdlist.Add(cmd);
            }

            DbHelperSQL.ExecuteSqlTran(cmdlist.ToArray());
        }

        public void Save(string cInvCode, DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from MouldEquipmentInv where cInvCode = @cInvCode");
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@cInvCode", cInvCode)
            };
            SqlCommand cmd = new SqlCommand(sb.ToString());
            cmd.Parameters.AddRange(p);

            List<SqlCommand> cmdlist = new List<SqlCommand>();
            cmdlist.Add(cmd);

            foreach (DataRow r in dt.Rows)
            {
                if (r.RowState == DataRowState.Deleted) continue;

                var model = DataHelper.DataRowToModel<MouldEquipmentInv>(r);

                sb.Clear();
                sb.Append("insert into MouldEquipmentInv(cInvCode, MId, EQId, bClass, iOrder, iStep, timeQty, cMemo)");
                sb.Append(" values(@cInvCode, @MId, @EQId, @bClass, @iOrder, @iStep, @timeQty, @cMemo)");

                p = new SqlParameter[]
                {
                    new SqlParameter("@cInvCode", model.cInvCode),
                    new SqlParameter("@MId", model.MId),
                    new SqlParameter("@EQId", model.EQId),
                    new SqlParameter("@bClass", model.bClass),
                    new SqlParameter("@iOrder", model.iOrder),
                    new SqlParameter("@iStep", model.iStep),
                    new SqlParameter("@timeQty", model.timeQty),
                    new SqlParameter("@cMemo", DataHelper.SqlNull(model.cMemo))
                };

                cmd = new SqlCommand(sb.ToString());
                cmd.Parameters.AddRange(p);
                cmdlist.Add(cmd);
            }

            DbHelperSQL.ExecuteSqlTran(cmdlist.ToArray());
            dt.AcceptChanges();
        }

        public bool DeleteByInv(string cInvCode)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from MouldEquipmentInv where cInvCode = @cInvCode");

            return DbHelperSQL.ExecuteSql(sb.ToString(), new SqlParameter("@cInvCode", cInvCode)) > 0;
        }

        public bool ExistInv(string cInvCode)
        {
            string sql = "select count(1) from MouldEquipmentInv where cInvCode = @cInvCode";

            return DbHelperSQL.Exists(sql, new SqlParameter("@cInvCode", cInvCode));
        }
    }
}
