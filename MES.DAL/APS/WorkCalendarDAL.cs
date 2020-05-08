using Lanyun.DBUtil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LanyunMES.DAL
{
    public class WorkCalendarDAL
    {
        public DataTable GetList(int year, int month)
        {
            string sql = "select *, datename(weekday,dDate) WeekDay from WorkCalendar where year(dDate) = @year and month(dDate) = @month";

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@year", year),
                new SqlParameter("@month", month)
            };

            return DbHelperSQL.Query(sql, p).Tables[0];
        }

        public void Add(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from WorkCalendar where year(dDate) = @year and month(dDate) = @month");

            int year = ((DateTime)dt.Rows[0]["dDate"]).Year;
            int month = ((DateTime)dt.Rows[0]["dDate"]).Month;

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@year", year),
                new SqlParameter("@month", month),
            };

            SqlCommand cmd = new SqlCommand(sb.ToString());
            cmd.Parameters.AddRange(p);

            List<SqlCommand> cmdlist = new List<SqlCommand>();
            cmdlist.Add(cmd);

            foreach(DataRow r in dt.Rows)
            {
                sb.Clear();
                sb.Append("insert into WorkCalendar(dDate, iHours, bRest) ");
                sb.Append("values(@dDate, @iHours, @bRest)");

                p = new SqlParameter[]
                {
                     new SqlParameter("@dDate", r["dDate"]),
                     new SqlParameter("@iHours", r["iHours"]),
                     new SqlParameter("@bRest", r["bRest"]),
                };

                cmd = new SqlCommand(sb.ToString());
                cmd.Parameters.AddRange(p);
                cmdlist.Add(cmd);
            }

            DbHelperSQL.ExecuteSqlTran(cmdlist.ToArray());
        }
    }
}
