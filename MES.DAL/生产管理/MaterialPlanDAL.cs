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

    public class MaterialPlanDAL
    {  
        public MaterialPlan Get(string guid)
        {
            string sql = "select t1.*, rd.cCode as U8RDCode, t2.cRdName, dep.cDepName, wh.cWhName from MaterialPlan t1 ";
            sql += " where t1.guid = @guid";

            using (var conn = DbHelperSQL.GetConnection())
            {
                var model = conn.QuerySingleOrDefault<MaterialPlan>(sql, new { guid = guid });

                if (model != null)
                {
                    model.dtDetails = GetBody(guid);
                }

                return model;
            }
        }

        public DataTable GetBody(string guid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select pos.cPosName, inv.cInvName, inv.cInvStd, cu.cComUnitName, op.Description as OpName, ");
            sb.Append(" wh.cWhName, rd.cCode, t1.* from MaterialPlans t1");
            sb.Append(" where t1.guid = @guid");

            return DbHelperSQL.Query(sb.ToString(), new SqlParameter("@guid", guid)).Tables[0];
        }

        public DataTable GetTable(string[] wheres, params SqlParameter[] paramArry)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from (");
            sb.Append("select t1.*, mo.MoCode, mod.SortSeq, wh.cWhName, inv.cInvName, inv.cInvStd, cu.cComUnitName, ");
            sb.Append(" pInv.cInvCode pInvCode, pInv.cInvName as pInvName, cm.iQuantity cardQty,");
            sb.Append(" t2.cardNo, t2.OpSeq, t2.OperationId, t2.cInvCode, t2.iQuantity, op.Description OpName, rd.cCode U8RdCode");
            sb.Append(" from MaterialPlan t1");
            sb.Append(" left join MaterialPlans t2 on t1.guid = t2.guid");
            sb.Append(" left join mom_cardMain cm on t2.cardNo = cm.cardNo");
            sb.Append(" left join WorkOrder wo on cm.WoGuid = wo.guid");
            sb.Append(") T ");
            if(wheres != null && wheres.Length > 0)
            {
                sb.Append(" where " + string.Join(" and ", wheres));
            }

            return DbHelperSQL.Query(sb.ToString(), paramArry).Tables[0];
        }

        public string Add(MaterialPlan model, SqlTransaction tran = null)
        {
            #region 增加
            string guid = Guid.NewGuid().ToString();

            model.Guid = guid;
            model.MPCode = GetMPCode();
            model.dCreateDate = DateTime.Now;

            var dlist = model.dtDetails.ToDynamicList();
            dlist.ForEach(x => x.guid = guid);

            string[] Fields = new string[]
            {
                "cModifier", "dModifyDate", "cAuditPsn", "dAuditDate", "U8RDId"
            };

            string[] DFields = new string[] { "U8Id", "U8AutoId", "AuditPsn", "AuditDate" };

            string sql = CommonDAL.GetInsertSql("MaterialPlan", filterFields: Fields);
            string sqlD = CommonDAL.GetInsertSql("MaterialPlans", filterFields: DFields);
            sqlD += ";update MaterialRequest set bMP = 1 where guid = @mrGuid ";
            sqlD += ";update t3 set rQuantity = t1.iQuantity from MaterialPlans t1";
            sqlD += " join MaterialPlan MP on t1.Guid = MP.Guid";
            sqlD += " join MaterialRequest t2 on t1.mrGuid = t2.guid";
            sqlD += " join mom_cardChildren t3 on t2.CardChildId = t3.AutoId";
            sqlD += " where MP.guid = @guid";


            if (tran == null)
            {
                var conn = DbHelperSQL.GetConnection();
                conn.Open();
                tran = conn.BeginTransaction();
            }
           
            using (tran)
            {
                try
                {
                    tran.Connection.Execute(sql, model, tran);
                    tran.Connection.Execute(sqlD, dlist, tran);

                    tran.Commit();
                }
                catch(Exception ex)
                {
                    tran.Rollback();
                    throw new Exception("SQL执行出错:" + ex.Message);
                }
            }
        
 

            //SqlParameter[] p = new SqlParameter[]
            //{
            //    new SqlParameter("@guid", guid),
            //    new SqlParameter("@MPCode", GetMPCode()),
            //    new SqlParameter("@cDepCode", model.cDepCode),
            //    new SqlParameter("@cRdCode", model.cRdCode),
            //    new SqlParameter("@dDate", model.dDate),
            //    new SqlParameter("@cMaker",model.cMaker),
            //    new SqlParameter("@cWhCode", model.cWhCode),
            //    new SqlParameter("@dCreateDate", DateTime.Now),
            //    new SqlParameter("@cMemo", DataHelper.SqlNull(model.cMemo))
            //};



            //SqlCommand cmd = new SqlCommand(sql);
            //cmd.Parameters.AddRange(p);

            //List<SqlCommand> cmdlist = new List<SqlCommand>();
            //cmdlist.Add(cmd);

            //foreach (DataRow r in model.dtDetails.Rows)
            //{
            //    p = new SqlParameter[]
            //    {
            //        new SqlParameter("@guid", guid),
            //        //new SqlParameter("@mccId", r["mccId"]),
            //        new SqlParameter("@cWhCode", r["cWhCode"]),
            //        new SqlParameter("@cPosCode", r["cPosCode"]),
            //        new SqlParameter("@cardNo", r["cardNo"]),
            //        new SqlParameter("@Opseq", r["OpSeq"]),
            //        new SqlParameter("@operationId",r["operationId"]),
            //        new SqlParameter("@cInvCode", r["cInvCode"]),
            //        new SqlParameter("@iQuantity", r["iQuantity"]),
            //        new SqlParameter("@mrGuid", r["mrGuid"])
            //    };

            //    cmd = new SqlCommand(sqlD);
            //    cmd.Parameters.AddRange(p);
            //    cmdlist.Add(cmd);
            //}

            //DbHelperSQL.ExecuteSqlTran(cmdlist.ToArray());

            return guid; 
            #endregion
        }

        public void Update(MaterialPlan model, SqlTransaction tran = null)
        {

            string sqlM = "Update MES..MaterialPlan set MPCode = @MPCode, dDate = @dDate, cWhCode = @cWhCode, cModifier = @cModifier,";
            sqlM += " dModifyDate = @dModifyDate, cRdCode = @cRDCode, cDepCode = @cDepCode, cMemo = @cMemo where guid = @guid";

            string[] DFields = new string[] { "U8Id", "U8AutoId", "AuditPsn", "AuditDate" };

            string sqlDAdd = CommonDAL.GetInsertSql("MaterialPlans", filterFields: DFields);
            sqlDAdd += ";update MaterialRequest set bMP = 1 where guid = @mrGuid ";
            sqlDAdd += ";update t3 set rQuantity = t1.iQuantity from MaterialPlans t1";
            sqlDAdd += " join MaterialRequest t2 on t1.mrGuid = t2.guid";
            sqlDAdd += " join mom_cardChildren t3 on t2.CardChildId = t3.AutoId";
            sqlDAdd += " where t1.AutoId = @AutoId";

            string sqlDupdate = "update MES..MaterialPlans set cardNo = @cardNo, OpSeq = @OpSeq, OperationId = @OperationId,";
            sqlDupdate += "mrGuid = @mrGuid, cPosCode = @cPosCode, cWhCode = @cWhCode where AutoID = @AutoID";

            StringBuilder sb = new StringBuilder();
            sb.Append("update t1 set bMP = 0 from MES..MaterialRequest t1 ");
            sb.Append(" join MES..MaterialPlans t2 on t1.guid = t2.mrGuid where t2.AutoId = @AutoId");

            sb.Append(";update t3 set rQuantity = 0 from MES..MaterialPlans t1");
            sb.Append(" join MES..MaterialRequest t2 on t1.mrGuid = t2.guid");
            sb.Append(" join MES..mom_cardChildren t3 on t2.CardChildId = t3.AutoId");
            sb.Append(" where t1.AutoId = @AutoId");
            sb.Append("; delete MES..MaterialPlans where AutoId = @AutoId");

            string sqlDDel = sb.ToString();

            if (tran != null)
            {
                tran.Connection.Execute(sqlM, model, tran);

                foreach (DataRowView drv in model.dtDetails.DefaultView)
                {
                    if (drv.Row.RowState == DataRowState.Added)
                    {
                        var d = DataHelper.DataRowToModel<MaterialPlans>(drv.Row);
                        d.Guid = model.Guid;
                        tran.Connection.Execute(sqlDAdd, d, tran);
                    }
                    else if (drv.Row.RowState == DataRowState.Modified)
                    {
                        var d = DataHelper.DataRowToModel<MaterialPlans>(drv.Row);
                        tran.Connection.Execute(sqlDupdate, d, tran);
                    }
                    else if (drv.Row.RowState == DataRowState.Deleted)
                    {
                        tran.Connection.Execute(sqlDDel, new { AutoId = drv["AutoId"] }, tran);
                    }
                }
            }
            else
            {
                using (var conn = DbHelperSQL.GetConnection())
                {
                    conn.Open();
                    tran = conn.BeginTransaction();

                    try
                    {
                        tran.Connection.Execute(sqlM, model, tran);

                        foreach (DataRowView drv in model.dtDetails.DefaultView)
                        {
                            if (drv.Row.RowState == DataRowState.Added)
                            {
                                var d = DataHelper.DataRowToModel<MaterialPlans>(drv.Row);
                                d.Guid = model.Guid;
                                tran.Connection.Execute(sqlDAdd, d, tran);
                            }
                            else if (drv.Row.RowState == DataRowState.Modified)
                            {
                                var d = DataHelper.DataRowToModel<MaterialPlans>(drv.Row);
                                tran.Connection.Execute(sqlDupdate, d, tran);
                            }
                            else if (drv.Row.RowState == DataRowState.Deleted)
                            {
                                tran.Connection.Execute(sqlDDel, new { AutoId = drv["AutoId"] }, tran);
                            }
                        }

                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw new Exception("SQL执行出错:" + ex.Message);
                    }
                }
            }
        }

        public bool Delete(string guid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update t1 set bMP = 0 from MaterialRequest t1 ");
            sb.Append(" join MaterialPlans t2 on t1.guid = t2.mrGuid where t2.guid = @guid");

            sb.Append(";update t3 set rQuantity = 0 from MaterialPlans t1");
            sb.Append(" join MaterialPlan MP on t1.Guid = MP.Guid");
            sb.Append(" join MaterialRequest t2 on t1.mrGuid = t2.guid");
            sb.Append(" join mom_cardChildren t3 on t2.CardChildId = t3.AutoId");
            sb.Append(" where MP.guid = @guid");

            sb.Append(";delete from MaterialPlans where guid = @guid");
            sb.Append(";delete from MaterialPlan where guid = @guid");

            return DbHelperSQL.ExecuteSql(sb.ToString(), new SqlParameter("@guid", guid)) > 0;
        }

        /// <summary>
        /// 审核(弃用) - 使用服务器端审核
        /// </summary>
        public bool Audit(string guid, string cAuditPsn)
        {
            string sql = "update MaterialPlan set cAuditPsn = @cAuditPsn, dAuditDate = @dAuditDate where guid = @guid";

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@guid", guid),
                new SqlParameter("@cAuditPsn", cAuditPsn),
                new SqlParameter("@cAuditDate", DateTime.Now.Date)
            };

            return DbHelperSQL.ExecuteSql(sql, p) > 0;
        }

        /// <summary>
        /// 弃审
        /// </summary>
        public bool UnAudit(string guid)
        {
            string sql = "update MaterialPlan set cAuditPsn = null, dAuditDate = null, U8RDId = null where guid = @guid";

            SqlParameter p = new SqlParameter("@guid", guid);

            return DbHelperSQL.ExecuteSql(sql, p) > 0;
        }


        /// <summary>
        /// 获取拣货单号
        /// </summary>
        /// <returns></returns>
        private string GetMPCode()
        {
            string sql = "select 'MP' + CONVERT(char(6),getDate(),12) + right(1001 + isnull(RIGHT(max(MPCode),3),0), 3 ) from MaterialPlan ";
            sql += " where dDate = convert(char(10),getDate(),121)";

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.QuerySingle<string>(sql);
            }
        }

        
    }
}
