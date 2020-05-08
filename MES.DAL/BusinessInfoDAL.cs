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

    public class BusinessInfoDAL
    {
        public BusinessInfo GetModel(string modelName)
        {
            string sql = "select * from BusinessInfo where BusiName = @moduleName";

            SqlParameter param = new SqlParameter("moduleName", modelName);

            DataSet ds =  DbHelperSQL.Query(sql, param);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public BusinessInfo DataRowToModel(DataRow row)
        {
            BusinessInfo busiInfo = new BusinessInfo();

            if (row != null)
            {
                busiInfo.BusiName = row["BusiName"].ToString();
                busiInfo.cType = row["cType"].ToString();
                busiInfo.MView = row["MView"].ToString();
                busiInfo.DView = row["DView"].ToString();
                busiInfo.ListView = row["ListView"].ToString();
                busiInfo.MPK = row["MPK"].ToString();
                busiInfo.DPK = row["DPK"].ToString();
                busiInfo.DFK = row["DFK"].ToString();
                busiInfo.MTLnk = row["MTLnkName"].ToString();
                busiInfo.AddDataSP = row["AddDataSP"].ToString();
                busiInfo.EditDataSP = row["EditDataSP"].ToString();
                busiInfo.DelDataSP = row["DelDataSP"].ToString();
                busiInfo.AuditDataSP = row["AuditDataSP"].ToString();
                busiInfo.UnAuditDataSP = row["UnAuditDataSP"].ToString();
            }

            return busiInfo;

        }
    }
}
