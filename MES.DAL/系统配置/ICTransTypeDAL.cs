using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.DAL 
{
    using Lanyun.DBUtil;
    using Dapper;
    using Entity;

    public class ICTransTypeDAL
    {
        public ICTransType Get(int FTranType)
        {
            string sql = "select * from ICTransType where FTranType = @fTranType";

            using (var conn = DbHelperSQL.GetConnection())
            {
                var model = conn.QuerySingleOrDefault<ICTransType>(sql, new { fTranType = FTranType });

                sql = "select * from ICTableInfo where FTranType = @fTranType";

                model.Tables = conn.Query<ICTableInfo>(sql, new { fTranType = FTranType }).ToList();

                return model;
            }
        }

        public void Add(ICTransType model)
        {
            string sqlM = SQLBuilder.GetInsertSql("ICTransType");
            string sqlD = SQLBuilder.GetInsertSql("ICTableInfo");

            var tran = DbHelperSQL.GetTransaction();

            try
            {
                tran.Connection.Execute(sqlM, model, tran);

                tran.Connection.Execute(sqlD, model.Tables, tran);

                tran.Commit();
            }
            catch(Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
        }

        public bool Delete(int FTranType)
        {
            string sql = "delete from ICTableInfo where FTranType = @Id;";
            sql += "delete from ICTransType where FTranType = @Id;";
            sql += "delete from ICTableField where FTranType = @Id";

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.Execute(sql, new { Id = FTranType }) > 0;
            }
        }
 
    }
}
