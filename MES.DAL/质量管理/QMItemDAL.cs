using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LanyunMES.DAL
{
    using Dapper;
    using Entity;
    using Lanyun.DBUtil;
    using System.Data.SqlClient;

    public class QMItemDAL
    {
        SqlConnection conn = DbHelperSQL.GetConnection();

        public QMItem Get(int QMItemId)
        {
            string sql = "select t1.*, t2.QMCCode, t2.QMCName from QM_QMItem t1 left join QM_QMItemClass t2 on t1.QMCId = t2.QMCId ";
            sql += " where QMItemId = @QMItemId";

            return conn.QuerySingle<QMItem>(sql, new { QMItemId = QMItemId });
        }

        public int Add(QMItem model)
        {
            string sql = "insert into QM_QMItem(QMCId, QMItemCode, QMItemName, cMemo, cMaker, dCreateDate) output inserted.QMItemId ";
            sql += "values(@QMCId, @QMItemCode, @QMItemName, @cMemo, @cMaker, @dCreateDate)";

            model.dCreateDate = DateTime.Now;

            return conn.ExecuteScalar<int>(sql, model);
        }

        public void Update(QMItem model)
        {
            string sql = "update QM_QMItem set QMCId = @QMCId, QMItemCode = @QMItemCode, QMItemName = @QMItemName where QMItemId = @QMItemId";

            conn.Execute(sql, model);
        }

        public void Delete(int QMItemId)
        {
            string sql = "delete from QM_QMItem where QMItemId = @id";
            conn.Execute(sql, new { id = QMItemId });
        }

        public List<QMItem> GetList(int qmcid)
        {
            string sql = "select t1.*, t2.QMCCode, t2.QMCName from QM_QMItem t1 left join QM_QMItemClass t2 on t1.QMCId = t2.QMCId ";
            sql += " where t1.qmcid = @qmcid";

            return conn.Query<QMItem>(sql, new { qmcid = qmcid }).ToList();
        }

        public bool Exists(string QMItemCode)
        {
            string sql = "select count(1) from QM_QMItem where QMItemCode = @QMItemCode";

            return conn.QuerySingle<int>(sql, new { QMItemCode = QMItemCode }) > 0;
        }


        //==============================

        public int AddClass(QMItemClass model)
        {
            string sql = "insert into QM_QMItemClass output inserted.QMCId values(@QMCCode, @QMCName, @cMaker, @dCreateDate)";

            model.dCreateDate = DateTime.Now;
 
            return conn.ExecuteScalar<int>(sql, model);
        }

        public void UpdateClass(QMItemClass model)
        {
            string sql = "update QM_QMItemClass set QMCCode = @QMCCode, QMCName = @QMCName where QMCId = @QMCId";

            conn.Execute(sql, model);
        }

        public QMItemClass GetClass(int QMCId)
        {
            string sql = "select * from QM_QMItemClass where QMCId = @QMCId";

            return conn.QuerySingle<QMItemClass>(sql, new { QMCId = QMCId });
        }

        /// <summary>
        /// 删除质检分类
        /// </summary>
        public void DeleteClass(int QMCId)
        {
            string sql = "delete from QM_QMItemClass where QMCId = @id";

            conn.Execute(sql, new { id = QMCId });
        }

        public List<QMItemClass> GetClassList()
        {
            string sql = "select * from QM_QMItemClass ";
            return conn.Query<QMItemClass>(sql).ToList();
        }

        /// <summary>
        /// 质检分类编码是否存在
        /// </summary>
        public bool ExistClass(string cCode)
        {
            string sql = "select count(1) from QM_QMItemClass where QMCCode = @QMCCode";

            return conn.QuerySingle<int>(sql, new { QMCCode = cCode }) > 0;
        }

        /// <summary>
        /// 是否存在下级分类
        /// </summary>
        public bool ExistChildClass(string cCode)
        {
            string sql = "select count(1) from QM_QMItemClass where QMCCode like @cCode + '%' and QMCCode <> @cCode";

            return conn.QuerySingle<int>(sql, new { cCode = cCode }) > 0;
        }

        /// <summary>
        /// 质检分类是否被引用
        /// </summary>
        public bool ExistChild(int QMCId)
        {
            string sql = "select count(1) from QM_QMItem where QMCId = @id";

            return conn.QuerySingle<int>(sql, new { id = QMCId }) > 0;
        }

    }
}
