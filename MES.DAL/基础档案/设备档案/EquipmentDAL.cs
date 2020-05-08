using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LanyunMES.DAL
{
    using Dapper;
    using Entity;
    using Lanyun.DBUtil;

    public class EquipmentDAL
    {
        SqlConnection conn = DbHelperSQL.GetConnection();

        class op
        {
            public int AutoId { get; set; }
            public int operationId { get; set; }
            public int EQId { get; set; }
            public decimal cycleTime { get; set; }
        };

        public DataTable GetTable(string[] wheres, params SqlParameter[] parameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from (");
            sb.Append("select t1.*, t2.cEQCCode, t2.cEQCName, op.OpCode, op.description OpName from Equipment t1 ");
            sb.Append(" left join EquipmentClass t2 on t1.EQCId = t2.EQCId");
            sb.Append(") T ");

            if (wheres != null && wheres.Length > 0)
            {
                sb.Append(" where " + string.Join(" and ", wheres));
            }
            sb.Append(" order by cEQCode");

            return DbHelperSQL.Query(sb.ToString(), parameters).Tables[0];
        }

        public List<Equipment> GetList(string[] wheres, object parameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select ROW_NUMBER() over(order by cEQCode) RowNo, * from (");
            sb.Append("select t1.*, t2.cEQCCode, t2.cEQCName from Equipment t1 ");
            sb.Append(" left join EquipmentClass t2 on t1.EQCId = t2.EQCId");
            sb.Append(") T ");

            if (wheres != null && wheres.Length > 0)
            {
                sb.Append(" where " + string.Join(" and ", wheres));
            }
            sb.Append(" order by cEQCode");

            return conn.Query<Equipment>(sb.ToString(), parameters).ToList();
        }

        public Equipment Get(int EQId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select t1.*, t2.cEQCCode, t2.cEQCName from Equipment t1 ");
            sb.Append(" left join EquipmentClass t2 on t1.EQCId = t2.EQCId");
            sb.Append(" where t1.EQId = @EQId");

            var model = conn.Query<Equipment>(sb.ToString(), new { @EQId = EQId }).SingleOrDefault();
            model.dtOperations = this.GetDTable(EQId);

            return model;
        }

        public DataTable GetDTable(int EQId)
        {
            string sql = "select * from EquipmentOP where EQId = @EQId";

            return DbHelperSQL.Query(sql, new SqlParameter("@EQId", EQId)).Tables[0];
        }

        public int Add(Equipment model)
        {
            model.dCreateDate = DateTime.Now.Date;

            StringBuilder sb = new StringBuilder();
            sb.Append("insert into Equipment(EQCId, cEQCode, cEQName, workHours, bStop, cMaker, dCreateDate) output inserted.EQId");
            sb.Append(" values(@EQCId, @cEQCode, @cEQName, @workHours, @bStop, @cMaker, @dCreateDate)");

            string sql = "insert into EquipmentOP(EQId, operationId, cycleTime) values(@EQId, @operationId, @cycleTime)";

            if(conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            var tran = conn.BeginTransaction();

            try
            {
                var id = conn.ExecuteScalar<int>(sb.ToString(), model, tran);
                foreach (DataRow r in model.dtOperations.Rows)
                {
                    var m = DataHelper.DataRowToModel<op>(r);
                    m.EQId = id;
                    conn.Execute(sql, m, tran);
                }
                tran.Commit();
                return id;
            }
            catch(Exception ex)
            {
                tran.Rollback();
                throw new Exception("执行SQL出错: " + ex.Message);
            }
        }

        public void Update(Equipment model)
        {
            model.dModifyDate = DateTime.Now.Date;

            string sqlM = CommonDAL.GetUpdateSql("Equipment", "EQId");

            string addSql = "insert into EquipmentOP(EQId, operationId, cycleTime) values(@EQId, @operationId, @cycleTime)";
            string updateSql = "update EquipmentOP set operationId = @operationId, cycleTime = @cycleTime where AutoId= @AutoId";
            string deleteSql = "delete from EquipmentOP where AutoId = @AutoId";

            if (conn.State == ConnectionState.Closed) conn.Open();

            var tran = conn.BeginTransaction();

            try
            {
                conn.Execute(sqlM, model, tran);

                foreach (DataRow r in model.dtOperations.Rows)
                {
                    if (r.RowState != DataRowState.Deleted)
                    {
                        var m = DataHelper.DataRowToModel<op>(r);
                        m.EQId = model.EQId;

                        if (r.RowState == DataRowState.Added)
                        {
                            conn.Execute(addSql, m, tran);
                        }
                        else if (r.RowState == DataRowState.Modified)
                        {
                            conn.Execute(updateSql, m, tran);
                        }
                    }
                    else if(r.RowState ==  DataRowState.Deleted)
                    {
                        conn.Execute(deleteSql, new { AutoId = r["AutoId", DataRowVersion.Original] }, tran);
                    }
                }

                tran.Commit();
            }
            catch(Exception ex)
            {
                tran.Rollback();
                throw new Exception("执行SQL出错:" + ex.Message);
            }
        }

        public bool Delete(int EQId)
        {
            string sql = "delete from Equipment where EQId = @EQId";
            sql += "; delete from EquipmentOP where EQId = @EQId";

            return conn.Execute(sql, new { EQId = EQId }) > 0;
        }

        public bool Exists(string cEQCode)
        {
            string sql = "select count(1) from Equipment where cEQCode = @cEQCode";

            return (int)conn.ExecuteScalar(sql, new { @cEQCode = cEQCode }) > 0;
        }

        public bool ExistsRef(int EQId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select count(1) from MouldEquipment where EQId = @EQId");

            return conn.ExecuteScalar<int>(sb.ToString(), new { EQId = EQId }) > 0;
        }
    }
}
