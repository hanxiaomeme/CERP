using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.DAL
{
    using System.Data;
    using System.Data.SqlClient;
    using MES.Model;

    public class MachineDAL
    {
        public Machine GetModel(string cMacCode)
        {
            #region 获取Machine
            string sql = "select * from UFSD_Machine where cMacCode = @cMacCode";
            DataRow row = DbHelperSQL.Query(sql, new SqlParameter("@cMacCode", cMacCode)).Tables[0].Rows[0];
            return DataRowToModel(row); 
            #endregion
        }

        public List<Machine> GetModelList(string WcCode)
        {
            #region 获取MachineList
            string sql;
            DataTable dt;
            if (string.IsNullOrEmpty(WcCode))
            {
                sql = "select * from UFSD_Machine";
                dt = DbHelperSQL.Query(sql).Tables[0];
            }
            else
            {
                sql = "select * from UFSD_Machine where WcCode = @WcCode";
                dt = DbHelperSQL.Query(sql, new SqlParameter("@WcCode", WcCode)).Tables[0];
            }

            List<Machine> list = new List<Machine>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(DataRowToModel(row));
            }

            return list; 
            #endregion
        }

        public List<Machine> GetModelList(params int[] modids)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select distinct cMacCode, cMacName, cMacStd, cMacVend, cPsn, mac.WcCode from UFSD_Machine mac");
            sb.Append(" join UFSD_sfc_proutingdetail_work pd on pd.WcCode = mac.WcCode ");
            sb.Append(" join UFSD_sfc_proutingpart pt on pt.PRoutingId = pd.PRoutingId");

            if (modids != null && modids.Length > 0)
            {
                sb.Append(" where pt.PartId in (select distinct partId from mom_orderDetail ");
                sb.Append(" where modid in (" + string.Join(",", modids) + "))");
            }

            sb.Append(" order by mac.wcCode, mac.cMacCode");

            DataTable dt = DbHelperSQL.Query(sb.ToString()).Tables[0];

            List<Machine> list = new List<Machine>();
            foreach(DataRow row in dt.Rows)
            {
                list.Add(DataRowToModel(row));
            }

            return list;
        }

        private Machine DataRowToModel(DataRow row)
        {
            #region DataRowToModel
            Machine model = new Machine();

            if (row.Table.Columns.Contains("cMacCode") && row["cMacCode"] != null && row["cMacCode"].ToString() != "")
            {
                model.cMacCode = row["cMacCode"].ToString();
            }
            if (row.Table.Columns.Contains("cMacName") && row["cMacName"] != null && row["cMacName"].ToString() != "")
            {
                model.cMacName = row["cMacName"].ToString();
            }
            if (row.Table.Columns.Contains("cMacStd") && row["cMacStd"] != null && row["cMacStd"].ToString() != "")
            {
                model.cMacStd = row["cMacStd"].ToString();
            }
            if (row.Table.Columns.Contains("cMacVend") && row["cMacVend"] != null && row["cMacVend"].ToString() != "")
            {
                model.cMacVend = row["cMacVend"].ToString();
            }
            if (row.Table.Columns.Contains("WcCode") && row["WcCode"] != null && row["WcCode"].ToString() != "")
            {
                model.WcCode = row["WcCode"].ToString();
            }

            return model; 
            #endregion
        }

    
    }
}
