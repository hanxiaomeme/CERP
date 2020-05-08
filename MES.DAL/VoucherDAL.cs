using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
 
namespace LanyunMES.DAL
{
 
    using Dapper;
    using Lanyun.DBUtil;
    using LanyunMES.Entity;

    public class VoucherDAL
    {
        public VoucherDAL(ModelSqlInfo _mInfo, ModelSqlInfo _dInfo)
        {
            this.mInfo = _mInfo;
            this.dInfo = _dInfo;
        }

  
        //主表,子表配置信息
        public ModelSqlInfo mInfo { get; protected set; }
        public ModelSqlInfo dInfo { get; protected set; }
 

        //------------------------------------------------------------

        public virtual bool Exists(int fInterId)
        {
            string sql = "select count(1) from " + mInfo.TableInfo.FTableName + " where " + mInfo.TableInfo.FPKName + " = @id";

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.QuerySingle<int>(sql, new { id = fInterId }) > 0;
            }
        }

        public virtual Voucher Get(int fInterId)
        {
            if (string.IsNullOrEmpty(mInfo.SQL_Select))
            {
                throw new Exception("主表SelectSQL未配置!");
            }
            else if (string.IsNullOrEmpty(dInfo.SQL_Select))
            {
                throw new Exception("子表SelectSQL未配置!");
            }
 
            Voucher model = new Voucher();

            string sqlM = "select * from (" + mInfo.SQL_Select + ") T where " + mInfo.TableInfo.FPKName + " = @id";
            string sqlD = "select * from (" + dInfo.SQL_Select + ") T where " + mInfo.TableInfo.FPKName + " = @id";

            model.DtHead = DbHelperSQL.Query(sqlM, new SqlParameter("id", fInterId)).Tables[0];

            if (model.DtHead.Rows.Count > 0)
            {
                model.DtBody = DbHelperSQL.Query(sqlD, new SqlParameter("id", fInterId)).Tables[0];
            }

            return model;
        }
 

        /// <summary>
        /// 新增
        /// </summary>
        public virtual int Add(Voucher model, IDbTransaction tran)
        {
            var head = model.DtHead.ToDapperList()[0];
  
            int id = tran.Connection.ExecuteScalar<int>(mInfo.SQL_Insert, head, tran);

            foreach(DataRow row in model.DtBody.Rows)
            {
                row[mInfo.TableInfo.FPKName] = id;
            }

            var bodyList = model.DtBody.ToDapperList();

            tran.Connection.Execute(dInfo.SQL_Insert, bodyList, tran);
 
            return id;
        }

        /// <summary>
        /// 更新
        /// </summary>
        public virtual bool Update(Voucher model, IDbTransaction tran)
        {
            string pkName = mInfo.TableInfo.FPKName;

            var head = model.DtHead.ToDapperList()[0];

            tran.Connection.Execute(mInfo.SQL_Update, head, tran);

            int id = Convert.ToInt32(model.DtHead.Rows[0][pkName]);
 
            string sqlUpdate = dInfo.SQL_Update + " and " + pkName + " = @" + pkName;

            string sqlDel = dInfo.SQL_Delete + " and " + pkName + " = @" + pkName;

            foreach(DataRow x in model.DtBody.Rows)  
            {
                if (x.RowState == DataRowState.Added)
                {
                    x[pkName] = id;
                    var m = x.ToDapperParam();
                    tran.Connection.Execute(dInfo.SQL_Insert, m, tran);
                }
                else if (x.RowState == DataRowState.Modified)
                {
                    var m = x.ToDapperParam();
                    tran.Connection.Execute(sqlUpdate, m, tran);
                }
                else if (x.RowState == DataRowState.Deleted)
                {
                    var m = x.ToDapperParam();
                    tran.Connection.Execute(sqlDel, m, tran);
                }
            }
            
            return true;
        }

        /// <summary>
        /// 删除
        /// </summary>
        public virtual bool Delete(int fInterId, IDbTransaction tran)
        {
            return tran.Connection.Execute(mInfo.SQL_Delete, new { id = fInterId }, tran) > 0;
        }

        /// <summary>
        /// 审核
        /// </summary>
        public bool Audit(int fInterId, string fchecker, IDbTransaction tran)
        {
            string sql = "update " + mInfo.TableInfo.FTableName + " set FStatus = 1, FCheckDate = @dDate, FChecker = @fchecker where " + mInfo.TableInfo.FPKName + " = @id";

            tran.Connection.Execute(sql, new { id = fInterId, fchecker = fchecker, dDate = DateTime.Now.Date }, tran);

            return true;
        }

        /// <summary>
        /// 弃审
        /// </summary>
        public bool UnAudit(int fInterId, IDbTransaction tran)
        {
            string sql = "update " + mInfo.TableInfo.FTableName + " set FStatus = 0, FCheckDate = null, FChecker = null where fInterId = @id";

            tran.Connection.Execute(sql, new { id = fInterId }, tran);

            return true;
        }

        ///// <summary>
        ///// 单据类表分页查询
        ///// </summary>
        //public virtual DataTable GetPageList(JsonParameter qmodel)
        //{
        //    if (string.IsNullOrEmpty(mInfo.SQL_List))
        //    {
        //        throw new Exception("SQL配置错误,没有配置GetSQL!");
        //    }

        //    var pageSize = qmodel.pageSize;
        //    var pageNumber = qmodel.pageNumber;

        //    //var dp = SQLCondition.GetParam(qmodel);

        //    string orderStr = " order by " + string.Join(",", qmodel.orderFields);

        //    orderStr += qmodel.OrderSort == 1 ? " asc" : " desc";

        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("select top " + pageSize + " * from ");
        //    sb.Append("(");
        //    sb.Append("  select row_Number() over(" + orderStr + ") FNo, * from ");
        //    sb.Append("  (" + mInfo.SQL_List + ") A where " + SQLCondition.GetWheres(qmodel));
        //    sb.AppendFormat(") T where FNo > {0}", (pageNumber - 1) * pageSize);
        //    sb.Append(orderStr);

        //    //using (var conn = DbHelperSQL.GetConnection())
        //    //{
        //    //    return conn.Query<dynamic>(sb.ToString(), dp).ToList();
        //    //}

        //    var pList = SQLCondition.GetSqlParameters(qmodel);

        //    var cmd = new SqlCommand(sb.ToString());

        //    if (pList != null && pList.Count > 0) cmd.Parameters.AddRange(pList.ToArray());

        //    return DbHelperSQL.Query(cmd).Tables[0];
        //}

        ///// <summary>
        ///// 单据列表分页总记录数
        ///// </summary>
        //public virtual int GetCount(JsonParameter qmodel)
        //{
        //    string sql = "select count(1) from (" + mInfo.SQL_List + ") T where " + SQLCondition.GetWheres(qmodel);

        //    var dp = SQLCondition.GetParam(qmodel);

        //    using (var conn = DbHelperSQL.GetConnection())
        //    {
        //        return conn.QuerySingle<int>(sql, dp);
        //    }
        //}

        //public virtual DataTable GetHeadPageList(JsonParameter qmodel)
        //{
        //    int pageNumber = qmodel.pageNumber;
        //    int pageSize = qmodel.pageSize;

        //    string wheres = SQLCondition.GetWheres(qmodel);

        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("select top " + pageSize + " * from ");
        //    sb.Append("( select row_Number() over(order by FInterID desc) FNo, * from ");
        //    sb.Append("  ( " + mInfo.SQL_Select + ") A ");

        //    if (!string.IsNullOrEmpty(wheres))
        //    {
        //        sb.Append(" where " + wheres);
        //    }

        //    sb.AppendFormat(") T where FNo > {0}", (pageNumber - 1) * pageSize);

        //    //var dp = SQLCondition.GetParam(qmodel);

        //    //using (var conn = DbHelperSQL.GetConnection())
        //    //{
        //    //    return conn.Query(sb.ToString(), dp).ToList();
        //    //}


        //    var pList = SQLCondition.GetSqlParameters(qmodel);

        //    var cmd = new SqlCommand(sb.ToString());
        //    if (pList != null && pList.Count > 0) cmd.Parameters.AddRange(pList.ToArray());

        //    return DbHelperSQL.Query(cmd).Tables[0];
        //}

        //public virtual int GetHeadCount(JsonParameter qmodel)
        //{
        //    int pageNumber = qmodel.pageNumber;
        //    int pageSize = qmodel.pageSize;

        //    string sql = "select count(1) from (" + mInfo.SQL_Select + ") T where " + SQLCondition.GetWheres(qmodel);

        //    var dp = SQLCondition.GetParam(qmodel);

        //    using (var conn = DbHelperSQL.GetConnection())
        //    {
        //        return conn.QuerySingle<int>(sql, dp);
        //    }
        //}

        /// <summary>
        /// 获取单据状态
        /// </summary>
        /// <param name="fInterId">单据ID</param>
        public virtual int GetStatus(int fInterId)
        {
            string sql = "select isnull(FStatus,0) from " + mInfo.TableInfo.FTableName + " where " + mInfo.TableInfo.FPKName + " = @id";

            using (var conn = DbHelperSQL.GetConnection())
            {
                return conn.QuerySingle<int>(sql, new { id = fInterId });
            }
        }
    }
    
}
