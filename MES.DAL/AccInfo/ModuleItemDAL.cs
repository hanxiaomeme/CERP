using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LanyunMES.DAL
{
    using Lanyun.DBUtil;
    using LanyunMES.Entity;

    public class ModuleItemDAL
    {
        public ModuleItem GetModel(string moduleCode)
        {
            string sql = "select * from ModuleInfo where ModuleCode = @moduleCode";
            DataSet ds = DbHelperSQL.Query(sql, new SqlParameter("moduleCode", moduleCode));
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }

            return null;
        }

        public ModuleItem DataRowToModel(DataRow row)
        {
            ModuleItem item = new ModuleItem();

            if (row != null)
            {
                if (row["ModuleCode"] != null && row["ModuleCode"].ToString() != "")
                {
                    item.ModuleCode = row["moduleCode"].ToString();
                }
                if (row["ModuleName"] != null && row["ModuleName"].ToString() != "")
                {
                    item.ModuleName = row["ModuleName"].ToString();
                }
                if (row["FileName"] != null && row["FileName"].ToString() != "")
                {
                    item.FileName = row["FileName"].ToString();
                }
                if (row["FileType"] != null && row["FileType"].ToString() != "")
                {
                    item.FileType = row["FileType"].ToString();
                }
                if (row["ClassFullName"] != null && row["ClassFullName"].ToString() != "")
                {
                    item.ClassFullName = row["ClassFullName"].ToString();
                }
                if (row["IsEnd"] != null && row["IsEnd"].ToString() != "")
                {
                    item.IsEnd = (bool)row["IsEnd"];
                }
                if (row["IsUse"] != null && row["IsUse"].ToString() != "")
                {
                    item.IsUse = (bool)row["IsUse"];
                }
                //if (row["Params"] != null && row["Params"].ToString() != "")
                //{
                //    item.Params = row["Params"].ToString();
                //}
                //if (row["ShowStyle"] != null && row["ShowStyle"].ToString() != "")
                //{
                //    item.ShowStyle = (int)row["ShowStyle"];
                //}
            }

            return item;
        }
    }
}
