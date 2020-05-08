using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace LanyunMES.DAL
{
    using Dapper;
    using Entity;
    using Lanyun.DBUtil;
    using System.Data;

    public class RoutingDAL: IBaseMSDAL<Routing>
    {
        SqlConnection conn = DbHelperSQL.GetConnection();

        public Routing New()
        {
            Routing model = new Routing();
            model.DtRoutings = this.GetDTable(0);

            return model;
        }

        public Routing Get(int routingId)
        {
            string sql = "select * from Routing where RoutingId = @Id";

            var routing = conn.QuerySingle<Routing>(sql, new { Id = routingId });

            routing.DtRoutings = GetDTable(routingId);

            return routing;
        }

        public bool Exists(string routingCode)
        {
            string sql = "select count(1) from Routing where RoutingCode = @cCode";

            return conn.QuerySingle<int>(sql, new { cCode = routingCode }) > 0;
        }

        public DataTable GetDTable(int routingId)
        {
            string sql = "select t1.*, t2.OpCode, t2.Description as OpName from Routings t1 left join ";
            sql += "A..sfc_operation t2 on t1.operationId = t2.operationId";
            sql += " where RoutingId = @Id";

            return DbHelperSQL.Query(sql, new SqlParameter("Id", routingId)).Tables[0];
        }

        public int Add(Routing model)
        {
            string sql = CommonDAL.GetInsertSql("Routing");

            if (conn.State != System.Data.ConnectionState.Open) conn.Open();

            var tran = conn.BeginTransaction();

            try
            {
                var id = conn.ExecuteScalar<int>(sql, model, tran);

                var ls = DataHelper.DataTableToModel<Routings>(model.DtRoutings);
                ls.ForEach(x => x.RoutingId = id);
                sql = CommonDAL.GetInsertSql("Routings");

                conn.Execute(sql, ls, tran);
                tran.Commit();

                return id;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception("SQL执行出错: " + ex.Message);
            }
        }

        public bool Delete(int routingId)
        {
            string sql = "delete from Routing where RoutingId = @id";
            sql += "; delete from Routings where RoutingId = @id";

            return conn.Execute(sql, new { id = routingId }) > 0;
        }

        public void Update(Routing model)
        {
            string sqlM = CommonDAL.GetUpdateSql("Routing", "RoutingId");
            string sqlAddD = CommonDAL.GetInsertSql("Routings");
            string sqlUpdateD = CommonDAL.GetUpdateSql("Routings", "RoutingId");
            string sqlDeleteD = "delete from Routings where AutoId = @AutoId";

            if (conn.State != System.Data.ConnectionState.Open) conn.Open();

            var tran = conn.BeginTransaction();

            try
            {
                conn.Execute(sqlM, model, tran);

                foreach (DataRow row in model.DtRoutings.Rows)
                {
                    if (row.RowState == DataRowState.Added)
                    {
                        var d = DataHelper.DataRowToModel<Routings>(row);
                        d.RoutingId = model.RoutingId;
                        conn.Execute(sqlAddD, d, tran);
                    }
                    else if (row.RowState == DataRowState.Modified)
                    {
                        var d = DataHelper.DataRowToModel<Routings>(row);
                        conn.Execute(sqlUpdateD, d, tran);
                    }
                    else if (row.RowState == DataRowState.Deleted)
                    {
                        int autoid = Convert.ToInt32(row["AutoId", DataRowVersion.Original]);
                        conn.Execute(sqlDeleteD, new { AutoId = autoid }, tran);
                    }
                }

                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception("SQL执行出错: " + ex.Message);
            }
             
        }

        public DataTable GetTable(string[] wheres)
        {
            StringBuilder sb = new StringBuilder("select * from Routing ");
            if(wheres!= null && wheres.Length > 0)
            {
                sb.Append(" where " + string.Join(" and ", wheres));
            }

            return DbHelperSQL.Query(sb.ToString()).Tables[0];

        }

        public bool ExistsRef(int id)
        {
            throw new NotImplementedException();
        }
    }
}
