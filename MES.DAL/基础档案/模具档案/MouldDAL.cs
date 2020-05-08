using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LanyunMES.DAL 
{
    using Entity;
    using Dapper;
    using Lanyun.DBUtil;

    public class MouldDAL
    {
        string ufdb = "A";
        SqlConnection conn = DbHelperSQL.GetConnection();

        public DataTable GetDataTable(string[] wheres, params SqlParameter[] parameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from (");
            sb.Append("select t1.*, t2.cMCCode, t2.cMCName from Mould t1 ");
            sb.Append(" left join MouldClass t2 on t1.MCId = t2.MCId");
            sb.Append(") T ");

            if (wheres != null && wheres.Length > 0)
            {
                sb.Append(" where " + string.Join(" and ", wheres));
            }
            sb.Append(" order by cMCode");

            return DbHelperSQL.Query(sb.ToString(), parameters).Tables[0];
        }

        public List<Mould> GetList(string[] wheres, object parameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from (");
            sb.Append("select t1.*, t2.cMCCode, t2.cMCName from Mould t1 ");
            sb.Append(" left join MouldClass t2 on t1.MCId = t2.MCId");
            sb.Append(") T ");

            if (wheres != null && wheres.Length > 0)
            {
                sb.Append(" where " + string.Join(" and ", wheres));
            }
            sb.Append(" order by cMCode");

            return conn.Query<Mould>(sb.ToString(), parameters).ToList();
        }


        public Mould Get(string MId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select t1.*, t2.cMCCode, t2.cMCName from Mould t1 ");
            sb.Append(" left join MouldClass t2 on t1.MCId = t2.MCId");
            sb.Append(" where t1.MID = @MId;");

            var model = conn.Query<Mould>(sb.ToString(), new { @MID = MId }).SingleOrDefault();

            model.dtEquipment = GetEqDetails(MId);

            return model;
        }


        public bool Add(Mould model)
        {
            #region 新增

            model.MId = Guid.NewGuid().ToString();
            model.dCreateDate = DateTime.Now.Date;

            StringBuilder sb = new StringBuilder();
            sb.Append("insert into Mould(MId, MCId, cMCode, cMName, Points, bStop, cMaker, bGroup, dCreateDate)");
            sb.Append(" values(@MId, @MCId, @cMCode, @cMName, @Points, @bStop, @cMaker, @bGroup, @dCreateDate)");

            return conn.Execute(sb.ToString(), model) > 0;
          
            #endregion
        }

        public bool Update(Mould model)
        {
            #region 更新

            model.dModifyDate = DateTime.Now.Date;

            StringBuilder sb = new StringBuilder();
            sb.Append("update Mould set MCId = @MCId, cMCode = @cMCode, cMName = @cMName, ");
            sb.Append(" Points = @Points, bStop = @bStop, cModifier = @cModifier,");
            sb.Append("dModifyDate = @dModifyDate, bGroup = @bGroup where MId = @MId \r\n");

            return conn.Execute(sb.ToString(), model) > 0;
         
            #endregion
        }

        public bool Delete(string MId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from Mould where MId = @MId");
            sb.Append("; delete from MouldEquipment where MId = @MId");
            sb.Append("; delete from MouldInventory where MId = @MId");

            return conn.Execute(sb.ToString(), new { @MId = MId }) > 0;
        }

        public bool Exists(string cMCode)
        {
            string sql = "select count(1) from Mould where cMCode = @cMCode";

            return conn.ExecuteScalar<int>(sql, new { @cMCode = cMCode }) > 0;
        }

        public bool ExistsRef(string MId)
        {
            return false;
            //throw new NotImplementedException();
        }


        //========================================================================

        public DataTable GetEqDetails(string MId)
        {
            #region 模具对应设备
            StringBuilder sb = new StringBuilder();
            sb.Append("select t1.*, M.cMCode, M.cMName, isnull(E.cEQCode, EC2.cEQCCode) cEQCode, ");
            sb.Append(" isnull(E.cEQName,EC2.cEQCName) cEQName, EC.cEQCName,");
            sb.Append(" case isnull(bClass,0) when 1 then '设备分类' else '设备明细' end bClassDesc");
            sb.Append(" from MouldEquipment t1");
            sb.Append(" join Mould M on t1.MId = M.MId");
            sb.Append(" left join Equipment E on t1.EQId = E.EQId and isnull(t1.bClass,0) = 0");
            sb.Append(" left join EquipmentClass EC on E.EQCId = EC.EQCId");
            sb.Append(" left join EquipmentClass EC2 on t1.EQId = EC2.EQCId");
            sb.Append(" where t1.MId = @MId");

            return DbHelperSQL.Query(sb.ToString(), new SqlParameter("@MId", MId)).Tables[0]; 
            #endregion
        }

        public DataTable GetInvDetails(string MId)
        {
            #region 模具对应产品
            StringBuilder sb = new StringBuilder();
            sb.Append("select t1.*, M.cMCode, M.cMName, M.Points, inv.cInvName, inv.cInvStd ");
            sb.Append(" from MouldInventory t1");
            sb.Append(" left join Mould M on t1.MId = M.MId");
            sb.Append(" left join " + ufdb + "..Inventory inv on t1.cInvCode = inv.cInvCode");
            sb.Append(" where t1.MId = @MId");

            return DbHelperSQL.Query(sb.ToString(), new SqlParameter("@MId", MId)).Tables[0];
            #endregion
        }

        /// <summary>
        /// 增加对应设备
        /// </summary>
        public void AddEq(string mid, DataTable dt)
        {
            #region 增加模具设备对照表

            SqlParameter[] p;
            SqlCommand cmd;
            List<SqlCommand> cmdlist = new List<SqlCommand>();

            StringBuilder sb = new StringBuilder();
            sb.Append("delete from MouldEquipment where MId = @MId");
            cmd = new SqlCommand(sb.ToString());
            cmd.Parameters.Add(new SqlParameter("@MId", mid));
            cmdlist.Add(cmd);

            foreach (DataRow r in dt.Rows)
            {
                sb.Clear();
                sb.Append("insert into MouldEquipment(MId, bClass, iOrder, EQId, iStep, capacity)");
                sb.Append(" values(@MId, @bClass, @iOrder, @EQId, @iStep, @capacity) ");

                p = new SqlParameter[]
                {
                    new SqlParameter("@MId", mid),
                    new SqlParameter("@EQId", r["EQId"]),
                    new SqlParameter("@bClass", r["bClass"]),
                    new SqlParameter("@iOrder", r["iOrder"]),
                    new SqlParameter("@iStep", r["iStep"]),
                    new SqlParameter("@capacity", r["capacity"]),
                };

                cmd = new SqlCommand(sb.ToString());
                cmd.Parameters.AddRange(p);
                cmdlist.Add(cmd);
            }

            DbHelperSQL.ExecuteSqlTran(cmdlist.ToArray()); 
            #endregion
        }

        public void AddInv(string mid, DataTable dt)
        {
            #region 增加模具产品对照表

            SqlParameter[] p;
            SqlCommand cmd;
            List<SqlCommand> cmdlist = new List<SqlCommand>();

            StringBuilder sb = new StringBuilder();
            sb.Append("delete from MouldInventory where MId = @MId");
            cmd = new SqlCommand(sb.ToString());
            cmd.Parameters.Add(new SqlParameter("@MId", mid));
            cmdlist.Add(cmd);

            foreach (DataRow r in dt.Rows)
            {
                sb.Clear();
                sb.Append("insert into MouldInventory(MId, cInvCode, iPoints, GroupId) values(@MId, @cInvCode, @iPoints, @GroupId) ");

                p = new SqlParameter[]
                {
                    new SqlParameter("@MId", mid),
                    new SqlParameter("@cInvCode", r["cInvCode"]),
                    new SqlParameter("@iPoints", r["iPoints"]),
                    new SqlParameter("@GroupId", r["GroupId"])
                };

                cmd = new SqlCommand(sb.ToString());
                cmd.Parameters.AddRange(p);
                cmdlist.Add(cmd);
            }

            DbHelperSQL.ExecuteSqlTran(cmdlist.ToArray());
            #endregion
        }


        public DataTable GetEqInvDetails(string MId)
        {
            #region 模具存货设备对应表
            StringBuilder sb = new StringBuilder();
            sb.Append("select t1.*, M.cMCode, M.cMName, isnull(E.cEQCode, EC2.cEQCCode) cEQCode, ");
            sb.Append(" isnull(E.cEQName,EC2.cEQCName) cEQName, EC.cEQCName,");
            sb.Append(" inv.cInvName, inv.cInvStd, ");
            sb.Append(" case isnull(bClass,0) when 1 then '设备分类' else '设备明细' end bClassDesc");
            sb.Append(" from MouldEquipmentInv t1");
            sb.Append(" join Mould M on t1.MId = M.MId");
            sb.Append(" join "+ ufdb + "..Inventory inv on t1.cInvCode = inv.cInvCode");
            sb.Append(" left join Equipment E on t1.EQId = E.EQId and isnull(t1.bClass,0) = 0");
            sb.Append(" left join EquipmentClass EC on E.EQCId = EC.EQCId");
            sb.Append(" left join EquipmentClass EC2 on t1.EQId = EC2.EQCId");
            sb.Append(" where t1.MId = @MId");

            return DbHelperSQL.Query(sb.ToString(), new SqlParameter("@MId", MId)).Tables[0];
            #endregion
        }

        /// <summary>
        /// 增加对应存货
        /// </summary>
        public void AddEqInv(string mid, DataTable dt)
        {
            #region 增加模具产品对照表

            SqlParameter[] p;
            SqlCommand cmd;
            List<SqlCommand> cmdlist = new List<SqlCommand>();

            StringBuilder sb = new StringBuilder();
            sb.Append("delete from MouldEquipmentInv where MId = @MId");
            cmd = new SqlCommand(sb.ToString());
            cmd.Parameters.Add(new SqlParameter("@MId", mid));
            cmdlist.Add(cmd);

            foreach (DataRow r in dt.Rows)
            {
                sb.Clear();
                sb.Append("insert into MouldEquipmentInv(MId, EQId, bClass, iOrder, iStep, timeQty, cInvCode, cMemo)");
                sb.Append(" values(@MId, @EQId, @bClass, @iOrder, @iStep, @timeQty, @cInvCode, @cMemo) ");

                p = new SqlParameter[]
                {
                    new SqlParameter("@MId", mid),
                    new SqlParameter("@EQId", r["EQId"]),
                    new SqlParameter("@bClass", r["bClass"]),
                    new SqlParameter("@iOrder", r["iOrder"]),
                    new SqlParameter("@iStep", r["iStep"]),
                    new SqlParameter("@timeQty", r["timeQty"]),
                    new SqlParameter("@cInvCode", r["cInvCode"]),
                    new SqlParameter("@cMemo", r["cMemo"])
                };

                cmd = new SqlCommand(sb.ToString());
                cmd.Parameters.AddRange(p);
                cmdlist.Add(cmd);
            }

            DbHelperSQL.ExecuteSqlTran(cmdlist.ToArray());
            #endregion
        }
    }
}
