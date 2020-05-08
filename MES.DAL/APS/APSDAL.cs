using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.DAL
{
    using Entity;
    using Dapper;
    using System.Data;
    using System.Data.SqlClient;
    using Lanyun.DBUtil;

    public class APSDAL
    {
        string ufdb = "A";
        SqlConnection conn = DbHelperSQL.GetConnection();

        public DataTable GetMomTable(DateTime pcDate)
        {
            #region 获取生产订单列表

            StringBuilder sb = new StringBuilder();
            sb.Append(";select *, NWGQuantity - PCQty as NPCQty from ( ");
            sb.Append(" select t1.WOCode, t2.MoId, mom.MoCode, t1.CreateDate, case t2.BomType when 1 then '标准' else '非标准' end as BomType,");
            sb.Append(" t2.modid, t2.SortSeq, t1.iQuantity, t1.WGQuantity, t2.MrpQty, t2.SoDId, t2.BomId, t2.SoCode, Inv.cInvCode, ");
            sb.Append(" t1.iQuantity - isnull(t1.WGQuantity,0) as NWGQuantity, isnull(pc.pcQty,0) as PCQty, '' as MID, '' as cMName, t3.StartDate, t3.DueDate,");
            sb.Append(" Inv.cInvName, inv.cInvStd, t2.Free1, unit.cComUnitName, t2.Remark, t2.CustCode");        //CustCode 客户代号 
            sb.Append(" from WorkOrder t1 ");
            sb.Append(" left join " + ufdb + "..mom_orderdetail t2 on t1.U8Modid = t2.MoDId ");
            sb.Append(" left join " + ufdb + "..mom_order mom on t2.Moid = mom.Moid");
            sb.Append(" left join " + ufdb + "..mom_morder t3 on t2.MoDid = t3.MoDid");
            sb.Append(" left join " + ufdb + "..Inventory Inv on t1.cInvCode = Inv.cInvCode ");
            sb.Append(" left join " + ufdb + "..ComputationUnit unit on Inv.cComUnitCode = unit.cComUnitCode");
            sb.Append(" left join (select WOCode, SUM(pcQty) pcQty from APSResult where dDate >= @pcDate group by WOCode) pc");
            sb.Append(" on t1.WOCode = pc.WOCode ");
            sb.Append(") T where NWGQuantity > PCQty");


            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@pcDate", pcDate)
            };

            return DbHelperSQL.Query(sb.ToString(), p).Tables[0];


            #endregion
        }

        public DataTable GetMouldEq(string cInvCode, string MId)
        {
            #region 获取产品对应机台

            StringBuilder sb = new StringBuilder();
            sb.Append("select distinct t2.* from MouldInventory t1 ");
            sb.Append(" join MouldEquipment t2 on t1.MId = t2.MId");
            sb.Append(" left join Equipment eq on t2.EQId = eq.EQId and t2.bClass  = 0");
            sb.Append(" left join Equipment eq2 on t2.EQId = eq2.EQCId and t2.bClass = 1");
            sb.Append(" where  t1.cInvCode = @cInvCode and t2.MId = @MId ");
            sb.Append(" order by t2.iOrder");

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@cInvCode", cInvCode),
                new SqlParameter("@MId", MId)
            };

            return DbHelperSQL.Query(sb.ToString(), p).Tables[0]; 

            #endregion
        }

        public DataTable GetEqDayCapacity(DateTime dBegin, DateTime dEnd)
        {
            #region 设备产能按日展开

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@dBegin", dBegin),
                new SqlParameter("@dEnd", dEnd)
            };

            return DbHelperSQL.QueryWithProc("sp_GetEqDayCapacity", p); 

            #endregion
        }

        public Mould GetMouldSignle(string cInvCode)
        {
            string sql = "select t2.* from MouldInventory t1 join Mould t2 on t1.MID = t2.MID where t1.cInvCode = @cInvCode";

            var dt = DbHelperSQL.Query(sql, new SqlParameter("@cInvCode", cInvCode)).Tables[0];

            if(dt.Rows.Count < 1)
            {
                return null;
            }
            else
            {
                return DataHelper.DataRowToModel<Mould>(dt.Rows[0]);
            }
            
        }

        public DataTable GetMould(string cInvCode)
        {
            string sql = "select t1.cInvCode, t2.* from MouldInventory t1 join Mould t2 on t1.MID = t2.MID where t1.cInvCode = @cInvCode";

            SqlParameter p = new SqlParameter("@cInvCode", cInvCode);

            return  DbHelperSQL.Query(sql, p).Tables[0];     
        }

        public DataTable GetAPSResult(DateTime dBegin, DateTime dEnd)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@dBegin", dBegin),
                new SqlParameter("@dEnd", dEnd),
                new SqlParameter("@ufdb", ufdb)
            };

            return DbHelperSQL.QueryWithProc("sp_GetAPSResult", p);
        }

        public DataTable GetAPSResultByMom(DateTime dBegin, DateTime dEnd)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@dBegin", dBegin),
                new SqlParameter("@dEnd", dEnd),
                new SqlParameter("@ufdb", ufdb)
            };

            return DbHelperSQL.QueryWithProc("sp_GetAPSResultByMom", p);
        }

        public DataTable GetAPSEQResult(DateTime dBegin, DateTime dEnd)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@dBegin", dBegin),
                new SqlParameter("@dEnd", dEnd)
            };

            return DbHelperSQL.QueryWithProc("sp_GetAPSEQResult", p);
        }
 
        public bool CheckWorkCalendar(int year, int month)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select count(1) from WorkCalendar where year(dDate) = @year and month(dDate) = @month");

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@year", year),
                new SqlParameter("@month", month)
            };

            return DbHelperSQL.Exists(sb.ToString(), p);
        }

        public bool CheckAPSResult(DateTime dBegin)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select count(1) from APSResult where dDate >= @dBegin");
            SqlParameter p = new SqlParameter("@dBegin", dBegin);

            return DbHelperSQL.Exists(sb.ToString(), p);
        }

        public void ClearAPSResult(DateTime dBegin)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from APSResult where dDate >= @dBegin");
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@dBegin", dBegin)
            };

            DbHelperSQL.ExecuteSql(sb.ToString(), p);
        }



        public SqlCommand GetAddRecordCmd(params SqlParameter[] parameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into APSResult(EQID, MID, cInvCode, dDate, WOCode, sortSeq, pcQty, PCHours, cMemo) ");
            sb.Append(" values(@EQId, @MID, @cInvCode, @dDate, @WOCode, @sortSeq, @pcQty, @PCHours, @cMemo)");

            SqlCommand cmd = new SqlCommand(sb.ToString());
            cmd.Parameters.AddRange(parameters);

            return cmd;
        }
    }
}
