using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LanyunMES.DAL
{
    using Lanyun.DBUtil;
    using LanyunMES.Entity;

    public class DataScaleDAL
    {

        public DataScale GetDataScale()
        {
            DataScale ds = new DataScale();

            string sql = "select * from SetInformation where SetID = 'SJJD'";

            DataTable dt = DbHelperSQL.Query(sql).Tables[0];

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow drScale in dt.Rows)
                {
                    if (drScale["SetName"].ToString().ToLower() == "chsl")
                    {
                        ds.CHSL = drScale["SetValue"].ToString() != "" ? int.Parse(drScale["SetValue"].ToString()) : 0;
                    }
                    else if (drScale["SetName"].ToString().ToLower() == "chjs")
                    {
                        ds.CHJS = drScale["SetValue"].ToString() != "" ? int.Parse(drScale["SetValue"].ToString()) : 0;
                    }
                    else if (drScale["SetName"].ToString().ToLower() == "dj")
                    {
                        ds.DJ = drScale["SetValue"].ToString() != "" ? int.Parse(drScale["SetValue"].ToString()) : 0;
                    }
                    else if (drScale["SetName"].ToString().ToLower() == "je")
                    {
                        ds.JE = drScale["SetValue"].ToString() != "" ? int.Parse(drScale["SetValue"].ToString()) : 0;
                    }
                    else if (drScale["SetName"].ToString().ToLower() == "hsl")
                    {
                        ds.HSL = drScale["SetValue"].ToString() != "" ? int.Parse(drScale["SetValue"].ToString()) : 0;
                    }
                }
            }

            return ds;
        }
    }
}
