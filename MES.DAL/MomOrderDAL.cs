using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.DAL
{
    using Dapper;
    using Entity;
    using Lanyun.DBUtil;
    using System.Data;
    using System.Data.SqlClient;

    public class MomOrderDAL
    {
        SqlConnection conn = DbHelperSQL.GetConnection();

        public MomOrder GetOrder(string guid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select mm.MoCode, md.SortSeq, t1.*, inv.cInvName, inv.cInvStd, unit.cComUnitName ");
            sb.Append(" from WorkOrder t1 ");
            sb.Append(" where t1.Guid = @guid");

            var row = DbHelperSQL.Query(sb.ToString(), new SqlParameter("@guid", guid)).Tables[0].Rows[0];

            MomOrder model = DataHelper.DataRowToModel<MomOrder>(row);

            model.MomOrders = null;
            model.MomOrdersDetail = null;
            model.MomOrdersRouter = null;

            return model;
        }

        public DataTable GetMomOrders(string guid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select t1.*, inv.cInvName, inv.cInvStd, unit.cComUnitName from MomOrders t1");
            sb.Append(" where t1.Guid = @guid");

            return DbHelperSQL.Query(sb.ToString(), new SqlParameter("@guid", guid)).Tables[0];
        }

        public DataTable GetMomOrdersDetail(string guid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select t1.*, inv.cInvName DInvName, inv.cInvStd DInvStd, unit.cComUnitName DComUnitName from MomOrdersDetail t1");
            sb.Append(" where t1.Guid = @guid");

            return DbHelperSQL.Query(sb.ToString(), new SqlParameter("@guid", guid)).Tables[0];
        }

        public DataTable GetMomOrdersRouter(string guid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("");
            sb.Append("");
            sb.Append("");
            sb.Append("");

            return null;
        }
    }
}
