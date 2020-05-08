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

    public class QmRecordDAL: IDAL<QmRecord>
    {
 
        public QmRecord Get(string guid)
        {
            string sql = "select * from QmRecord where guid = @guid";

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.QuerySingleOrDefault<QmRecord>(sql, new { guid = guid });
            }
        }

        public string Add(QmRecord model)
        {
            string guid = Guid.NewGuid().ToString();

            StringBuilder sb = new StringBuilder();
            sb.Append("insert into QmRecord(guid, QMRCode, dDate, checkPsn, cVenCode, cMaker, cMemo) ");
            sb.Append("values(@guid, @QMRCode, @dDate, @checkPsn, @cVenCode, @cMaker, @cMemo)");

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@guid",guid),
                new SqlParameter("@QMRCode",this.GetNewCode()),
                new SqlParameter("@dDate",model.dDate),
                new SqlParameter("@checkPsn",DataHelper.SqlNull(model.checkPsn)),
                new SqlParameter("@cVenCode",model.cVenCode),
                new SqlParameter("@cMaker",model.cMaker),
                new SqlParameter("@cMemo", DataHelper.SqlNull(model.cMemo))
            };

            SqlCommand cmd = new SqlCommand(sb.ToString());
            cmd.Parameters.AddRange(parameters);

            List<SqlCommand> cmdlist = new List<SqlCommand>();
            cmdlist.Add(cmd);

            foreach(DataRow row in model.Details.Rows)
            {
                sb.Clear();
                sb.Append("insert into QmRecords(guid, qmids, POIDs, cPosCode, cInvCode, cFree1, iQualifyQty, iUnQualifyQty, remark) ");
                sb.Append(" values(@guid, @qmids, @POIDs, @cPosCode, @cInvCode, @cFree1, @iQualifyQty, @iUnQualifyQty, @remark)");
                //更新报检单已检验数量
                sb.Append("; update QmReports set bChecked = 1, haveQmQty = isnull(haveQmQty,0) + @iQualifyQty + @iUnQualifyQty where autoid = @qmids");
                
                parameters = new SqlParameter[]
                {
                    new SqlParameter("@guid", guid),
                    new SqlParameter("@qmids", row["qmids"]),
                    new SqlParameter("@POIDs", row["POIDs"]),
                    new SqlParameter("@cPosCode", row["cPosCode"]),
                    new SqlParameter("@cInvCode", row["cInvCode"]),
                    new SqlParameter("@cFree1", DataHelper.SqlNull(row["cFree1"])),
                    new SqlParameter("@iQualifyQty", row["iQualifyQty"]),
                    new SqlParameter("@iUnQualifyQty", row["iUnQualifyQty"]),
                    new SqlParameter("@remark", DataHelper.SqlNull(row["remark"])),
                };
                cmd = new SqlCommand(sb.ToString());
                cmd.Parameters.AddRange(parameters);
                cmdlist.Add(cmd);
            }

            DbHelperSQL.ExecuteSqlTran(cmdlist.ToArray());

            return guid;
        }

        public void Update(QmRecord model)
        {
            StringBuilder sb = new StringBuilder();
            
            //sb.Append(";update t1 set haveQmQty = isnull(haveQmQty,0) - isnull(t2.iQualifyQty,0) - isnull(t2.iUnQualifyQty,0) ");
            //sb.Append(" from QmReports t1");
            //sb.Append(" left join QmRecords t2 on t1.AutoId = t2.qmids");
            //sb.Append(" where t2.guid = @guid; ");

            //更新表头
            sb.Append("update QmRecord set QMRCode = @QMRCode, dDate = @dDate, cVenCode = @cVenCode,");
            sb.Append(" cModifier = @cModifier, cMemo = @cMemo, dModifyDate = @dModifyDate where guid = @guid");

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@QMRCode", model.QMRCode),
                new SqlParameter("@dDate", model.dDate),
                new SqlParameter("@cVenCode", model.cVenCode),
                new SqlParameter("@cModifier", model.cModifier),
                new SqlParameter("@dModifyDate", DateTime.Now),
                new SqlParameter("@cMemo", DataHelper.SqlNull(model.cMemo)),
                new SqlParameter("@guid", model.Guid)
            };

            SqlCommand cmd = new SqlCommand(sb.ToString());
            cmd.Parameters.AddRange(p);

            List<SqlCommand> cmdlist = new List<SqlCommand>();
            cmdlist.Add(cmd);

            foreach (DataRow m in model.Details.Rows)
            {
                //修改行
                if (m.RowState == DataRowState.Modified)
                {
                    sb.Clear();
                    sb.Append("update QmRecords set POIDs = @POIDs, qmIds = @qmIds, cPosCode = @cPosCode, cInvCode = @cInvCode, cFree1 = @cFree1, ");
                    sb.Append("iQualifyQty = @iQualifyQty, iUnQualifyQty = @iUnQualifyQty, remark = @remark where AutoId = @AutoID");
                    //sb.Append("; update t1 set haveQmQty = t2.iQty from QmReports t1 left join ");
                    //sb.Append(" (select sum(iQualifyQty) + sum(iUnQualifyQty) as iQty from QmRecords where qmids = @qmIds) t2");
                    //sb.Append("  on 1 = 1 where t1.AutoID = @qmIds");
                    p = new SqlParameter[]
                    {
                        new SqlParameter("@AutoID", m["AutoId"]),
                        new SqlParameter("@POIDs", m["POIDs"]),
                        new SqlParameter("@qmIds", m["qmIds"]),
                        new SqlParameter("@cPosCode", m["cPosCode"]),
                        new SqlParameter("@cInvCode", m["cInvCode"]),
                        new SqlParameter("@cFree1", DataHelper.SqlNull(m["cFree1"])),
                        new SqlParameter("@iQualifyQty", m["iQualifyQty"]),
                        new SqlParameter("@iUnQualifyQty", m["iUnQualifyQty"]),
                        new SqlParameter("@remark", DataHelper.SqlNull(m["remark"]))
                    };
                    cmd = new SqlCommand(sb.ToString());
                    cmd.Parameters.AddRange(p);
                    cmdlist.Add(cmd);
                }
                //删行
                else if (m.RowState == DataRowState.Deleted)
                {
                    sb.Clear();
                    //更新报检单已检验数量
                    sb.Append("update t2 set bChecked = 0, haveQmQty = isnull(haveQmQty,0) - @iQualifyQty - @iUnQualifyQty from QmRecords t1");
                    sb.Append(" join QmReports t2 on t1.qmIds = t2.AutoId where t1.AutoId = @AutoID");

                    sb.Append(";delete from QmRecords where AutoID = @AutoID");
                    cmd = new SqlCommand(sb.ToString());
                    cmd.Parameters.Add(new SqlParameter("@AutoID", m["AutoId", DataRowVersion.Original]));
                    cmdlist.Add(cmd);
                }
                //增行
                else if (m.RowState == DataRowState.Added)
                {
                    sb.Clear();
                    sb.Append("insert into QmRecords(guid, qmIds, POIDs, cPosCode, cInvCode, cFree1, iQualifyQty, iUnQualifyQty, remark) ");
                    sb.Append("values(@guid, @qmIds, @POIDs, @cInvCode, @cFree1, @iQualifyQty, @iUnQualifyQty, @remark)");
                    //sb.Append("; update QmReports set bChecked = 1, haveQmQty = isnull(haveQmQty,0) + @iQualifyQty + @iUnQualifyQty where autoid = @qmids");
                    p = new SqlParameter[]
                    {
                        new SqlParameter("@guid", model.Guid),
                        new SqlParameter("@POIDs", m["POIDs"]),
                        new SqlParameter("@qmIds", m["qmIds"]),
                        new SqlParameter("@cPosCode", m["cPosCode"]),
                        new SqlParameter("@cInvCode", m["cInvCode"]),
                        new SqlParameter("@cFree1", DataHelper.SqlNull(m["cFree1"])),
                        new SqlParameter("@iQualifyQty", m["iQualifyQty"]),
                        new SqlParameter("@iUnQualifyQty", m["iUnQualifyQty"]),
                        new SqlParameter("@remark", DataHelper.SqlNull(m["remark"]))
                    };
                    cmd = new SqlCommand(sb.ToString());
                    cmd.Parameters.AddRange(p);
                    cmdlist.Add(cmd);
                }

            };


            //更新已检验数量
            sb.Clear();
            sb.Append(";update t1 set haveQmQty = isnull(t2.iQty,0) from QmReports t1");
            sb.Append("  left join (select qmids, sum(iQualifyQty) + sum(iUnQualifyQty) as iQty from QmRecords ");
            sb.Append("  where guid = @guid group by qmids ) t2 ");
            sb.Append("  on t1.AutoId = t2.qmids where t2.guid = @guid");

            cmd = new SqlCommand(sb.ToString());
            cmd.Parameters.Add(new SqlParameter("@guid", model.Guid));
            cmdlist.Add(cmd);

            try
            {
                DbHelperSQL.ExecuteSqlTran(cmdlist.ToArray());
                model.Details.AcceptChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DAL层错误：" + ex.Message);
            }
        }

        public bool Delete(string guid)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(";update t1 set haveQmQty = isnull(haveQmQty,0) - t2.iQty, bChecked = 0 from QmReports t1 ");
            sb.Append(" join ");
            sb.Append(" (select qmids, sum(iQualifyQty) + sum(iUnQualifyQty) as iQty from QmRecords ");
            sb.Append("  where guid = @guid group by qmids ) t2 ");
            sb.Append(" on t1.AutoId = t2.qmids ");

            sb.Append(";delete from QmRecord where guid = @guid");
            sb.Append(";delete from QmRecords where guid = @guid");

            SqlParameter p = new SqlParameter("@guid", guid);

            return DbHelperSQL.ExecuteSql(sb.ToString(), p) > 0;
        }

        public bool Audit(string guid, string person)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update QmRecord set cAuditPsn = @psn, dAuditDate = @dDate, iState = 1 where guid = @guid");
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@psn", person),
                new SqlParameter("@guid", guid),
                new SqlParameter("@dDate", DateTime.Now.Date)
            };

            return DbHelperSQL.ExecuteSql(sb.ToString(), p) > 0;
        }

        public bool Audit(string guid, string person, string vouchId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update QmRecord set cAuditPsn = @psn, dAuditDate = @dDate, iState = 1, rdId = @vouchId where guid = @guid");
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@psn", person),
                new SqlParameter("@guid", guid),
                new SqlParameter("@vouchId", vouchId),
                new SqlParameter("@dDate", DateTime.Now.Date)
            };

            return DbHelperSQL.ExecuteSql(sb.ToString(), p) > 0;
        }

        public bool UnAudit(string guid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update QmRecord set cAuditPsn = null, dAuditDate = null, rdid = null, iState = 0 where guid = @guid");
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("guid", guid)
            };

            return DbHelperSQL.ExecuteSql(sb.ToString(), p) > 0;
        }

        public bool UnAuditCheck(string guid)
        {
            #region 弃审检查
            StringBuilder sb = new StringBuilder();
            sb.Append("select count(1) from TransVouch where cSource = '检验单' and cSourceGuid = @guid");
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@guid", guid)
            };

            return !DbHelperSQL.Exists(sb.ToString(), p); 
            #endregion
        }

        public DataTable GetList(string[] wheres, params SqlParameter[] parameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from ( ");
            sb.Append("select ven.cVenName, inv.cInvName, inv.cInvStd, unit.cComUnitName, t4.cPOID, r.cCode U8RDCode, t3.ivouchrowno, ");
            sb.Append(" t1.QMRCode, t1.dDate, t1.cVenCode, t1.checkPsn, t1.cMaker, t1.cModifier, t1.dModifyDate,");
            sb.Append(" t1.cAuditPsn, t1.dAuditDate, t1.iState, t1.cMemo, pos.cPosName, t2.*, qmrep.qmQty from QmRecord t1");
            sb.Append(" join QmRecords t2 on t1.guid = t2.guid");
            sb.Append(" join QmReports qmrep on t2.qmids = qmrep.AutoId");
            sb.Append(") T");

            if (wheres != null && wheres.Length > 0)
            {
                sb.Append(" where " + string.Join(" and ", wheres));
            }

            return DbHelperSQL.Query(sb.ToString(), parameters).Tables[0];
        }

        public DataTable GetMList(string[] wheres, params SqlParameter[] parameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from ( ");
            sb.Append("select ven.cVenName, t1.* from QmRecord t1");
            sb.Append(") T");

            if (wheres != null && wheres.Length > 0)
            {
                sb.Append(" where " + string.Join(" and ", wheres));
            }

            return DbHelperSQL.Query(sb.ToString(), parameters).Tables[0];
        }

        public DataTable GetDList(string guid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select t1.*, inv.cInvName, inv.cInvStd, t4.cPOID, t3.ivouchrowno, t2.qmQty, unit.cComUnitName, ");
            sb.Append(" pos.cPosName from QmRecords t1 ");
            sb.Append(" join QmReports t2 on t1.qmIds = t2.AutoId");
            sb.Append(" where t1.guid = @guid");
 
            SqlParameter p = new SqlParameter("@guid", guid);
            return DbHelperSQL.Query(sb.ToString(), p).Tables[0];
        }

        public string GetNewCode()
        {
            string value = "QR-" + DateTime.Now.ToString("yyMMdd");

            string sql = "select 'QR-'+ CONVERT(char(6),getdate(),12) + CAST(right(1001 + isnull(MAX(right(QMRCode,3)),0),3) as CHAR(3)) ";
            sql += " from QmRecord where QMRCode like '" + value + "%'";

            return DbHelperSQL.GetSingle(sql).ToString();
        }
 
    }
}
