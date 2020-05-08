using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.DAL
{
    using Dapper;
    using Lanyun.DBUtil;
    using Entity;
    using System.Data;
    using System.Data.SqlClient;

    public class QmCardOPDAL
    {
        public void Add(QMCardOP model)
        {
            string sql = "insert into QM_CardOperation(cardNo, OpSeq, iQuantity, dRepDate) values(@cardNo, @OpSeq, @iQuantity, @dRepDate)";

            using (var conn = DbHelperSQL.GetConnection())
            {
                conn.Execute(sql, model);
            }
               
        }

        public bool Del(int autoId)
        {
            string sql = "delete from QM_CardOperation where AutoId  = @AutoId";

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.Execute(sql, new { AutoId = autoId }) > 0;
            }
        }

        public bool Del(string cardNo, string opSeq)
        {
            string sql = "delete from QM_CardOperation where CardNo  = @cardNo and opSeq = @opSeq";

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.Execute(sql, new { cardNo = cardNo, opSeq = opSeq }) > 0;
            }
        }

        public DataTable GetTable(string[] wheres, params SqlParameter[] parameters)
        {
            string sql = "select * from (";
            sql += "select t1.*, t2.bChild, t2.pCardNo, inv.cInvCode, inv.cInvName, inv.cInvStd, unit.cComUnitName, ";
            sql += " op.operationId, op.description OpName, t2.cMemo, mo.MoCode from QM_cardOperation t1";
            sql += " left join mom_cardMain t2 on t1.cardNo = t2.cardNo";
            sql += " left join mom_cardDetail t3 on t1.cardNo = t3.cardNo and t1.OpSeq = t3.OpSeq";
            sql += " left join workorder wo on t2.woGuid = wo.guid";
            sql += ") T ";
            if(wheres != null && wheres.Length > 0)
            {
                sql += " where " + string.Join(" and ", wheres);
            }

            return DbHelperSQL.Query(sql, parameters).Tables[0];
        }
 
    }
}
