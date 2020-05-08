using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace LanyunMES.DAL
{
    using Lanyun.DBUtil;
    using LanyunMES.Entity;

    public partial class UA_AccountDAL
    {
        public UA_Account GetModel(string cAcc_Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 cAcc_Id, cAcc_Name, iYear, cUnitName from UFSystem..UA_Account where cAcc_Id = @cAcc_Id");
            SqlParameter param = new SqlParameter("@cAcc_Id", cAcc_Id);

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), param);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public UA_Account DataRowToModel(DataRow row)
        {
            UA_Account model = new UA_Account();
            if (row != null)
            {
                if (row["cUnitName"] != null)
                {
                    model.cUnitName = row["cUnitName"].ToString();
                }
                if (row["cAcc_Name"] != null)
                {
                    model.cAcc_Name = row["cAcc_Name"].ToString();
                }
                if (row["cAcc_Id"] != null)
                {
                    model.cAcc_Id = row["cAcc_Id"].ToString();
                }
                if (row["iYear"] != null)
                {
                    model.iYear = row["iYear"].ToString();
                }
            }
            return model;
        }
    }
}

