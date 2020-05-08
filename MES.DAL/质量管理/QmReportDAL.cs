using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.DAL
{
    using Entity;
    using System.Data;
    using System.Data.SqlClient;
    using Dapper;
    using Lanyun.DBUtil;

    public class QmReportDAL: IDAL<QmReport>
    {

        public QmReport Get(string guid)
        { 
            string sql = "select * from QmReport where guid = @guid";

            using (var conn = DbHelperSQL.GetConnection())
            {
                var model = conn.QuerySingleOrDefault<QmReport>(sql, new { guid = guid });

                if(model != null)
                {
                    model.Details = this.GetDetails(guid);
                }

                return model;
            }
        }
 

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns>guid主表主键</returns>
        public string Add(QmReport model)
        {
            string guid = Guid.NewGuid().ToString();
            model.QMCode = this.GetNewCode();

            StringBuilder sb = new StringBuilder();
            sb.Append("insert into QmReport(guid, QMCode, dDate, cVenCode, cMaker, cMemo) ");
            sb.Append("values(@guid, @QMCode, @dDate, @cVenCode, @cMaker, @cMemo)");

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@guid", guid),
                new SqlParameter("@QMCode", model.QMCode),
                new SqlParameter("@dDate", model.dDate),
                new SqlParameter("@cVenCode", model.cVenCode),
                new SqlParameter("@cMaker", model.cMaker),
                new SqlParameter("@cMemo", DataHelper.SqlNull(model.cMemo))
            };

            SqlCommand cmd = new SqlCommand(sb.ToString());
            cmd.Parameters.AddRange(p);

            List<SqlCommand> cmdlist = new List<SqlCommand>();
            cmdlist.Add(cmd);

            model.Details.ForEach(
                m =>
                {
                    sb.Clear();
                    sb.Append("insert into QmReports(guid, POIDs, cPosCode, bQualify, cInvCode, cFree1, arrQty, qmQty, remark) ");
                    sb.Append("values(@guid, @POIDs, @cPosCode, @bQualify, @cInvCode, @cFree1, @arrQty, @qmQty, @remark)");
                    p = new SqlParameter[]
                    {
                        new SqlParameter("@guid", guid),
                        new SqlParameter("@POIDs", m.POIDs),
                        new SqlParameter("@cPosCode", m.cPosCode),
                        new SqlParameter("@bQualify", m.bQualify),
                        new SqlParameter("@cInvCode", m.cInvCode),
                        new SqlParameter("@cFree1", DataHelper.SqlNull(m.cFree1)),
                        new SqlParameter("@arrQty", m.arrQty),
                        new SqlParameter("@qmQty", m.qmQty),
                        new SqlParameter("@remark", DataHelper.SqlNull(m.remark))
                    };
                    cmd = new SqlCommand(sb.ToString());
                    cmd.Parameters.AddRange(p);
                    cmdlist.Add(cmd);
                });

            try
            {
                DbHelperSQL.ExecuteSqlTran(cmdlist.ToArray());
                return guid;
            }
            catch (Exception ex)
            {
                throw new Exception("DAL层错误：" + ex.Message);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        public bool Delete(string guid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from QmReports where guid = @guid");
            sb.Append("; delete from QmReport where guid = @guid");
            SqlParameter p = new SqlParameter("@guid", guid);

            return DbHelperSQL.ExecuteSql(sb.ToString(), p) > 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public void Update(QmReport model)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update QmReport set QMCode = @QMCode, dDate = @dDate, cVenCode = @cVenCode,");
            sb.Append(" cMemo = @cMemo, cModifier = @cModifier, dModifyDate = @dModifyDate where guid = @guid");

            SqlParameter[] p = new SqlParameter[]
            {
            new SqlParameter("@QMCode", model.QMCode),
            new SqlParameter("@dDate", model.dDate),
            new SqlParameter("@cVenCode", model.cVenCode),
            new SqlParameter("@cMemo", DataHelper.SqlNull(model.cMemo)),
            new SqlParameter("@cModifier", model.cModifier),
            new SqlParameter("@dModifyDate", model.dModifyDate),
            new SqlParameter("@guid", model.Guid)
            };

            SqlCommand cmd = new SqlCommand(sb.ToString());
            cmd.Parameters.AddRange(p);

            List<SqlCommand> cmdlist = new List<SqlCommand>();
            cmdlist.Add(cmd);

            model.Details.ForEach(
                m =>
                {
                    //修改行
                    if (m.ModelState == ModelState.modified)
                    {
                        sb.Clear();
                        sb.Append("update QmReports set POIDs = @POIDs, bQualify = @bQualify, cInvCode = @cInvCode, cFree1 = @cFree1, ");
                        sb.Append("arrQty = @arrQty, cPosCode = @cPosCode, qmQty = @qmQty, remark = @remark where AutoId = @AutoID");
                        p = new SqlParameter[]
                        {
                            new SqlParameter("@AutoID", m.AutoId),
                            new SqlParameter("@POIDs", m.POIDs),
                            new SqlParameter("@cPosCode", m.cPosCode),
                            new SqlParameter("@bQualify", m.bQualify),
                            new SqlParameter("@cInvCode", m.cInvCode),
                            new SqlParameter("@cFree1", DataHelper.SqlNull(m.cFree1)),
                            new SqlParameter("@arrQty", m.arrQty),
                            new SqlParameter("@qmQty", m.qmQty),
                            new SqlParameter("@remark", DataHelper.SqlNull(m.remark))
                        };
                        cmd = new SqlCommand(sb.ToString());
                        cmd.Parameters.AddRange(p);
                        cmdlist.Add(cmd);
                    }
                    //删行
                    else if(m.ModelState == ModelState.deleted)
                    {
                        sb.Clear();
                        sb.Append("delete from QmReoprts where AutoID = @AutoID");
                        cmd = new SqlCommand(sb.ToString());
                        cmd.Parameters.Add(new SqlParameter("@AutoID", m.AutoId));
                        cmdlist.Add(cmd);
                    }
                    //增行
                    else if(m.ModelState == ModelState.added)
                    {
                        sb.Clear();
                        sb.Append("insert into QmReports(guid, POIDs, cPosCode, cInvCode, cFree1, arrQty, qmQty, remark) ");
                        sb.Append("values(@guid, @POIDs, @cPosCode, @cInvCode, @cFree1, @arrQty, @qmQty, @remark)");
                        p = new SqlParameter[]
                        {
                            new SqlParameter("@guid", model.Guid),
                            new SqlParameter("@POIDs", m.POIDs),
                            new SqlParameter("@cPosCode", m.cPosCode),
                            new SqlParameter("@cInvCode", m.cInvCode),
                            new SqlParameter("@cFree1", DataHelper.SqlNull(m.cFree1)),
                            new SqlParameter("@arrQty", m.arrQty),
                            new SqlParameter("@qmQty", m.qmQty),
                            new SqlParameter("@remark", DataHelper.SqlNull(m.remark))
                        };
                        cmd = new SqlCommand(sb.ToString());
                        cmd.Parameters.AddRange(p);
                        cmdlist.Add(cmd);
                    }
                });

            try
            {
                DbHelperSQL.ExecuteSqlTran(cmdlist.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("DAL层错误：" + ex.Message);
            }
        }

        public bool Audit(string guid, string person)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update QmReport set cAuditPsn = @psn, iState = 1, dAuditDate = @dDate where guid = @guid");
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@psn", person),
                new SqlParameter("@guid", guid),
                new SqlParameter("@dDate",DateTime.Now.Date)
            };

            return DbHelperSQL.ExecuteSql(sb.ToString(), p) > 0;
        }

        public bool UnAudit(string guid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update QmReport set cAuditPsn = null, dAuditDate = null, iState = 0 where guid = @guid");
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("guid", guid)
            };

            return DbHelperSQL.ExecuteSql(sb.ToString(), p) > 0;
        }


        public bool Exists(string guid)
        {
            string sql = "select count(1) from QmReport where guid = @guid";
            var p = new SqlParameter("@guid", guid);
            return DbHelperSQL.Exists(sql, p);
        }

        public string GetNewCode()
        {
            string value = "QM-" + DateTime.Now.ToString("yyMMdd");

            string sql = "select 'QM-'+ CONVERT(char(6),getdate(),12) + CAST(right(1001 + isnull(MAX(right(QMCode,3)),0),3) as CHAR(3)) ";
            sql += " from QmReport where QMCode like '" + value + "%'";

            return DbHelperSQL.GetSingle(sql).ToString();
        }

        /// <summary>
        ///  报检单列表
        /// </summary>
        public DataTable GetList(string[] wheres, params SqlParameter[] parameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from (");
            sb.Append(" select t1.QMCode, t1.dDate, pos.cPosName, t1.cVenCode, ven.cVenName, t1.cMaker, t1.cModifier, t1.dModifyDate, t1.cMemo,");
            sb.Append(" t1.iState, t4.cState, t2.*, t4.cPOID, t3.ivouchrowno, inv.cInvName, inv.cInvStd, unit.cComUnitName, t3.iQuantity,");
            sb.Append(" t1.cAuditPsn, t1.dAuditDate, t2.arrQty - isnull(t2.qmQty,0) - isnull(t2.stockInQty,0) canStockInQty,");
            sb.Append(" isnull(t2.qmQty,0) - isnull(t2.haveQmQty,0) canQmQty, r.cCode U8RDCode ");
            sb.Append(" from QmReport t1 ");
            sb.Append(" join QmReports t2 on t1.guid = t2.guid ");
            sb.Append(") T ");
            if (wheres != null && wheres.Length > 0)
            {
                sb.Append("where " + string.Join(" and ",wheres));
            }

            return DbHelperSQL.Query(sb.ToString(), parameters).Tables[0];
        }

        //--------------------------------------------------------

        private List<QmReports> GetDetails(string guid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select t1.*, unit.cComUnitName, pos.cPosName, t3.cPOID, t2.ivouchrowno, r.cCode U8RDCode from QmReports t1 ");
            sb.Append("where t1.guid = @guid ");

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.Query<QmReports>(sb.ToString(), new { guid = guid }).ToList();
            }
        }
 
    }
}
