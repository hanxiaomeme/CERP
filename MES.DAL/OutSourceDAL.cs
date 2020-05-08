using Lanyun.DBUtil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LanyunMES.DAL
{
    public class OutSourceDAL
    {

        public DataTable GetHead(string cCode)
        {
            #region 获取表头
            StringBuilder sb = new StringBuilder();
            sb.Append("select ven.cVenName, dep.cDepName, t1.* from MES_OutSource t1 ");
            sb.Append(" join Vendor ven on t1.cVenCode = ven.cVenCode");
            sb.Append(" join Department dep on t1.cDepCode = dep.cDepCode");
            sb.Append(" where t1.cCode = @cCode");

            return DbHelperSQL.Query(sb.ToString(), new SqlParameter("@cCode", cCode)).Tables[0]; 
            #endregion
        }

        public DataTable GetBody(string cCode)
        {
            #region 获取表体
            StringBuilder sb = new StringBuilder();
            sb.Append("select inv.cInvName, inv.cInvStd, inv.cInvDefine5 dubie, inv.cInvDefine1 yachang,");
            sb.Append(" zjb.caizhi, op.description opName, cardD.bizhong, t1.* from MES_OutSourceList t1 ");
            sb.Append(" left join Inventory inv on t1.cInvCode = inv.cInvCode");
            sb.Append(" left join sfc_operation op on t1.operationId = op.operationId");
            sb.Append(" left join MES_CardMain card on t1.cardNo = card.cardNo");
            sb.Append(" left join MES_carddetails cardD on t1.cardNo = cardD.cardNo and t1.OpSeq = cardD.OpSeq");
            sb.Append(" left join zhongjianbiao zjb on card.ylBarCode = zjb.tiaoma");
            sb.Append(" where t1.cCode = @cCode order by inv.cInvStd");

            return DbHelperSQL.Query(sb.ToString(), new SqlParameter("@cCode", cCode)).Tables[0]; 
            #endregion
        }

        public DataTable GetTableList(List<string> whereList, List<SqlParameter> paramList)
        {
            #region 查询委外列表

            StringBuilder sb = new StringBuilder();
            sb.Append("select t2.cVenName, dep.cDepName, inv.cInvName, inv.cInvStd, inv.cInvDefine5 dubie, ");
            sb.Append(" op.Description opName, t1.*, t3.* from MES_OutSource t1");
            sb.Append(" left join Vendor t2 on t1.cVenCode = t2.cVenCode");
            sb.Append(" left join MES_OutSourceList t3 on t1.cCode= t3.cCode");
            sb.Append(" left join Inventory inv on t3.cInvCode = inv.cInvCode");
            sb.Append(" left join sfc_operation op on t3.operationId = op.operationId");
            sb.Append(" left join Department dep on t1.cDepCode = dep.cDepCode");

            if (whereList.Count > 0)
            {
                sb.Append(" where " + string.Join(" and ", whereList.ToArray()));
            }


            if (paramList != null && paramList.Count > 0)
            {
                return DbHelperSQL.Query(sb.ToString(), paramList.ToArray()).Tables[0];
            }
            else
            {
                return DbHelperSQL.Query(sb.ToString()).Tables[0];
            } 

            #endregion
        }

        public int UpdateMemo(string cCode, string cMemo)
        {
            #region 更新备注
            if (!Exists(cCode))
            {
                throw new Exception("单据号:" + cCode + " 不存在!");
            }

            string sql = "update MES_OutSource set cMemo = @cMemo where cCode = @cCode";

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@cCode", cCode),
                new SqlParameter("@cMemo", cMemo)
            };

            return DbHelperSQL.ExecuteSql(sql, p); 
            #endregion
        }

        public void Delete(string cCode)
        {
            #region 删除委外单号
            if (!Exists(cCode))
            {
                throw new Exception("单据号：" + cCode + "不存在！");
            }

            string sql = "select RDFlag from MES_OutSource where cCode = '" + cCode + "'";

            int rdflag = Convert.ToInt32(DbHelperSQL.GetSingle(sql));

            if (rdflag == 0)
            {
                sql = "update t1 set bOut = 0 from MES_CardDetails t1 ";
                sql += " join MES_OutSourceList t2 on t1.CardNo = t2.cardNo and t1.OpSeq = t2.OpSeq";
                sql += " where t2.cCode = @cCode;";
                sql += " delete MES_OutSourceList where cCode = @cCode;";
                sql += " delete MES_OutSource where cCode = @cCode";
            }
            else if (rdflag == 1)
            {
                sql = "update t1 set bOut = 1 from MES_CardDetails t1 ";
                sql += " join MES_OutSourceList t2 on t1.CardNo = t2.cardNo and t1.OpSeq = t2.OpSeq";
                sql += " where t2.cCode = @cCode;";
                sql += " delete MES_OutSourceList where cCode = @cCode;";
                sql += " delete MES_OutSource where cCode = @cCode";
            }

            DbHelperSQL.ExecuteSql(sql, new SqlParameter("@cCode", cCode)); 
            #endregion
        }

        public bool Exists(string cCode)
        {
            string sql = "select 1 from MES_OutSource where cCode = @cCode";

            return DbHelperSQL.Exists(sql, new SqlParameter("@cCode", cCode));
        }
    }
}
