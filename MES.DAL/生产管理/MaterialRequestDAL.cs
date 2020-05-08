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

    /// <summary>
    /// 材料需求单DAL
    /// </summary>
    public class MaterialRequestDAL
    {
        public MaterialRequest Get(string guid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select t1.*, inv.cInvName, inv.cInvStd, unit.cComUnitName, op.description OpName ");
            sb.Append(" from MaterialRequest t1 ");
            sb.Append(" where t1.guid = @guid");

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.QuerySingleOrDefault<MaterialRequest>(sb.ToString(), new { guid = guid });
            }
        }

        public List<MaterialRequest> GetList(int routerId)
        {
            StringBuilder sb = new StringBuilder();  
            sb.Append("select t1.*, inv.cInvName, inv.cInvStd, unit.cComUnitName, op.description OpName ");
            sb.Append(" from MES..MaterialRequest t1 ");
            sb.Append(" left join MES..mom_cardChildren mcc on t1.CardChildId = mcc.AutoId");
            sb.Append(" where mcc.routerId = @id");

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.Query<MaterialRequest>(sb.ToString(), new { id = routerId }).ToList();
            }
        }

        /// <summary>
        /// 是否合并领料单
        /// </summary>
        /// <param name="routerId">指令单工艺行ID</param>
        public bool IsMerge(int routerId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select count(1) from MaterialRequest t1");
            sb.Append(" left join mom_CardChildren t2 on t1.CardChildId = t2.AutoId");
            sb.Append(" where t2.RouterId = " + routerId);

            return !DbHelperSQL.Exists(sb.ToString());
        }

      
        /// <summary>
        /// 新增需求明细
        /// </summary>
        /// <param name="materials">材料需求集合</param>
        /// <param name="tran">事物对象</param>
        public void Add(List<MaterialRequest> materials)
        {
            string sql = CommonDAL.GetInsertSql("MaterialRequest", filterFields: new string[] { "bMP", "iRate" });

            materials.ForEach(x =>
            {
                x.Guid = Guid.NewGuid().ToString();
                x.dCreateDate = DateTime.Now.Date;
            });

            using (var conn = DbHelperSQL.GetConnection())
            {
                conn.Execute(sql, materials);
            }             
        }

        /// <summary>
        /// 新增-合并需求
        /// </summary>
        /// <param name="materials">材料集合</param>
        /// <param name="sumList">汇总集合</param>
        /// <param name="tran">事物对象</param>
        public void AddSum(List<MaterialRequest> materials, List<MaterialRequestSum> sumList)
        {
            string sqlSum = CommonDAL.GetInsertSql("MaterialRequestSum");
            string sqlD = CommonDAL.GetInsertSql("MaterialRequest", filterFields: new string[] { "bMP", "iRate" });

            materials.ForEach(x =>
            {
                x.Guid = Guid.NewGuid().ToString();
                x.dCreateDate = DateTime.Now.Date;
            });

            using (var conn = DbHelperSQL.GetConnection())
            {
                conn.Open();
                var tran = conn.BeginTransaction();

                try
                {
                    conn.Execute(sqlSum, sumList, tran);
                    conn.Execute(sqlD, materials, tran);
                    tran.Commit();
                }
                catch(Exception ex)
                {
                    tran.Rollback();
                    throw new Exception("SQL执行出错: " + ex.Message);
                }
            }
        }
       
        public bool Delete(string guid)
        {
            string sql = "delete from MaterialRequestD where guid = @guid";
            sql += ";delete from MaterialRequest where guid = @guid";

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.Execute(sql, new { guid = guid }) > 0;
            }
        }

        /// <summary>
        ///  流转卡是否已经请求材料
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public bool ExistCard(string cardNo, int RouterId)
        {
            string sql = "select count(1) from MaterialRequest t1  ";
            sql += " join mom_cardChildren t2 on t1.CardChildID = t2.AutoId";
            sql += " where t2.cardNo = @cardNo and t2.routerId = @routerId";

            using (var conn = DbHelperSQL.GetConnection())
            {
                if(conn.QuerySingle<int>(sql, new { cardNo = cardNo, routerId = RouterId }) > 0)
                {
                    return true;
                }
                else
                {
                    sql = "select count(1) from MaterialRequestD t1  ";
                    sql += " join mom_cardChildren t2 on t1.CardChildID = t2.AutoId";
                    sql += " where t2.cardNo = @cardNo and t2.routerId = @routerId";

                    return conn.QuerySingle<int>(sql, new { cardNo = cardNo, routerId = RouterId }) > 0;
                }

            }
        }

        /// <summary>
        /// 待领料出库列表
        /// </summary>
        public DataTable GetMaterialReqTable(string[] wheres, params SqlParameter[] parameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from (");
            sb.Append("select mo.MoCode, mod.SortSeq, mr.*, inv.cInvName, inv.cInvStd, cu.cComUnitName, ");
            sb.Append("case bMerge when 1 then '合并领料' else '' end IsMerge, op.Description as OpName");
            sb.Append(" from MaterialRequest mr ");
            sb.Append(" left join mom_cardMain cm on mr.cardNo = cm.cardNo");
            sb.Append(" left join WorkOrder wo on cm.WoGuid = wo.guid");
            sb.Append(" where isnull(mr.bMP,0) = 0 and isnull(cm.bClosed,0) = 0");
            sb.Append(") T");

            if(wheres != null && wheres.Length > 0)
            {
                sb.Append(" where  " + string.Join(" and ", wheres));
            }


            return DbHelperSQL.Query(sb.ToString(), parameters).Tables[0];
        }

        /// <summary>
        /// 合并领料记录 明细记录
        /// </summary>
        public DataTable GetMaterialReqDTable(string guid)
        {
            string sql = "select t1.*, t2.CardNo, op.Description as OpName, ";
            sql += " inv.cInvCode, inv.cInvName, inv.cInvStd, cu.cComUnitName";
            sql += " from MaterialRequestD t1 ";
            sql += " left join mom_cardchildren t2 on t1.CardChildId = t2.AutoId";
            sql += " where t1.Guid = @guid";

            return DbHelperSQL.Query(sql, new SqlParameter("@guid", guid)).Tables[0];
        }
    }
}
