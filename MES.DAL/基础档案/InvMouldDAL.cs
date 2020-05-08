using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.DAL
{
    using Model;
    using System.Data;
    using System.Data.SqlClient;

    public class InvMouldDAL
    {
        string ufdb = Information.UserInfo.UFDB;

        public DataTable GetList(string[] wheres, params SqlParameter[] parameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from (");
            sb.Append(" select t1.*, inv.cInvName, inv.cInvStd from InvMould t1  ");
            sb.Append(" join " + ufdb + "..Inventory inv on t1.cInvCode = inv.cInvCode");
            sb.Append(") T");
            if (wheres != null && wheres.Length > 0)
            {
                sb.Append(" where " + string.Join(" and ", wheres));
            }

            return DbHelperSQL.Query(sb.ToString(), parameters).Tables[0];
        }

        public InvMould Get(string guid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select *, inv.cInvName, inv.cInvStd, unit.cComUnitName from InvMould t1 ");
            sb.Append(" join " + ufdb + "..Inventory inv on t1.cInvCode = inv.cInvCode");
            sb.Append(" join " + ufdb + "..ComputationUnit unit on unit.cComUnitCode = inv.cComUnitCode");
            sb.Append(" where t1.guid = @guid");

            SqlParameter p = new SqlParameter("@guid", guid);

            DataRow row = DbHelperSQL.Query(sb.ToString(), p).Tables[0].Rows[0];

            var model = ConvertToModel<InvMould>.DataRowToModel(row);

            model.dtMouldEq = GetDTBody(guid);

            return model;
        }

        public DataTable GetDTBody(string guid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select t1.*, t2.cMCode, t2.cMName, t2.Points, t3.cEQCode, t3.cEQName, op.OpCode, op.description OpName ");
            sb.Append("from InvMoulds t1 ");
            sb.Append(" join Mould t2 on t1.MId = t2.MId ");
            sb.Append(" join Equipment t3 on t1.EQId = t3.EQId");
            sb.Append(" left join " + ufdb + "..sfc_Operation op on t3.operationId = op.operationId");
            sb.Append(" where t1.guid = @guid");

            SqlParameter p = new SqlParameter("@guid", guid);

            return DbHelperSQL.Query(sb.ToString(),p).Tables[0];
        }

        public string Add(InvMould model)
        {
            #region 新增
            string guid = Guid.NewGuid().ToString();

            StringBuilder sb = new StringBuilder();
            sb.Append("insert into InvMould(guid, cInvCode, iState, cMaker, dCreateDate) ");
            sb.Append("values(@guid, @cInvCode, @iState, @cMaker, @dCreateDate)");

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@guid", guid),
                new SqlParameter("@cInvCode", model.cInvCode),
                new SqlParameter("@iState", model.iState),
                new SqlParameter("@cMaker", model.cMaker),
                new SqlParameter("@dCreateDate", DateTime.Now.Date)
            };

            SqlCommand cmd = new SqlCommand(sb.ToString());
            cmd.Parameters.AddRange(p);

            List<SqlCommand> cmdlist = new List<SqlCommand>();
            cmdlist.Add(cmd);

            foreach (DataRow r in model.dtMouldEq.Rows)
            {
                sb.Clear();
                sb.Append("insert into InvMoulds(guid, MId, EQId, iStep, timeQty) ");
                sb.Append("values(@guid, @MId, @EQId, @iStep, @timeQty)");

                p = new SqlParameter[]
                {
                    new SqlParameter("@guid", guid),
                    new SqlParameter("@MId", r["MId"]),
                    new SqlParameter("@EQId", r["EQId"]),
                    new SqlParameter("@iStep", r["iStep"]),
                    new SqlParameter("@timeQty", r["timeQty"])
                };

                cmd = new SqlCommand(sb.ToString());
                cmd.Parameters.AddRange(p);
                cmdlist.Add(cmd);
            }

            DbHelperSQL.ExecuteSqlTran(cmdlist.ToArray());

            return guid;
            #endregion
        }

        public void Update(InvMould model)
        {
            #region 更新
            string guid = Guid.NewGuid().ToString();

            StringBuilder sb = new StringBuilder();
            sb.Append("update InvMould set cInvCode = @cInvCode, cModifier = @cModifier,");
            sb.Append(" dModifyDate = @dModifyDate where guid = @guid");

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@guid", guid),
                new SqlParameter("@cInvCode", model.cInvCode),
                new SqlParameter("@cModifier", model.cModifier),
                new SqlParameter("@dModifyDate", DateTime.Now.Date)
            };

            SqlCommand cmd = new SqlCommand(sb.ToString());
            cmd.Parameters.AddRange(p);

            List<SqlCommand> cmdlist = new List<SqlCommand>();
            cmdlist.Add(cmd);

            foreach (DataRow r in model.dtMouldEq.Rows)
            {
                sb.Clear();
                if (r.RowState == DataRowState.Added)
                {
                    sb.Append("insert into InvMoulds(guid, MId, EQId, iStep, timeQty) ");
                    sb.Append("values(@guid, @MId, @EQId, @iStep, @timeQty)");

                    p = new SqlParameter[]
                    {
                        new SqlParameter("@guid", guid),
                        new SqlParameter("@MId", r["MId", DataRowVersion.Original]),
                        new SqlParameter("@EQId", r["EQId", DataRowVersion.Original]),
                        new SqlParameter("@iStep", r["iStep", DataRowVersion.Original]),
                        new SqlParameter("@timeQty", r["timeQty", DataRowVersion.Original])
                    };

                    cmd = new SqlCommand(sb.ToString());
                    cmd.Parameters.AddRange(p);
                    cmdlist.Add(cmd);
                }
                else if(r.RowState == DataRowState.Modified)
                {
                    sb.Append("update InvMoulds set MId = @MId, EQId = @EQId,");
                    sb.Append("iStep = @iStep, timeQty = @timeQty where AutoId = @AutoId");

                    p = new SqlParameter[]
                    {
                        new SqlParameter("@AutoId", r["AutoId"]),
                        new SqlParameter("@MId", r["MId"]),
                        new SqlParameter("@EQId", r["EQId"]),
                        new SqlParameter("@iStep", r["iStep"]),
                        new SqlParameter("@timeQty", r["timeQty"])
                    };

                    cmd = new SqlCommand(sb.ToString());
                    cmd.Parameters.AddRange(p);
                    cmdlist.Add(cmd);
                }
                else if(r.RowState == DataRowState.Deleted)
                {
                    sb.Append("delete InvMoulds where AutoId = @AutoId");

                    p = new SqlParameter[]
                    {
                        new SqlParameter("@AutoId", r["AutoId"]),
                    };

                    cmd = new SqlCommand(sb.ToString());
                    cmd.Parameters.AddRange(p);
                    cmdlist.Add(cmd);
                }
            }

            DbHelperSQL.ExecuteSqlTran(cmdlist.ToArray());
            #endregion
        }

        public bool Delete(string guid)
        {
            #region 删除
            StringBuilder sb = new StringBuilder();
            sb.Append("delete InvMoulds where guid = @guid;");
            sb.Append("delete InvMould where guid = @guid");

            SqlParameter p = new SqlParameter("@guid", guid);

            return DbHelperSQL.ExecuteSql(sb.ToString(), p) > 0; 
            #endregion
        }

        public bool Exists(string cInvCode)
        {
            string sql = "select count(1) from InvMould where cInvCode = @cInvCode";

            SqlParameter p = new SqlParameter("@cInvCode", cInvCode);

            return DbHelperSQL.Exists(sql, p);
        }

    }
}
