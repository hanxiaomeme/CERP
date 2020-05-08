using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace MES.DAL
{
    /// <summary>
    /// 数据访问类:UserModuleAuth
    /// </summary>
    public partial class AuthDAL
    {

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool HasModuleAuth(int userid, int moduleid)
        {
            string sql = "select count(1) from MES_UserAuth where UserID = @userId and ModuleId = @ModuleId";

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@userId", userid),
                new SqlParameter("@ModuleId", moduleid)
            };

            return DbHelperSQL.Exists(sql, p);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MES.Model.UserModuleAuth model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into UserModuleAuth(");
            strSql.Append("uid,moduleID,UserType)");
            strSql.Append(" values (");
            strSql.Append("@uid,@moduleID,@UserType)");
            SqlParameter[] parameters = {
					new SqlParameter("@uid", SqlDbType.Int,4),
					new SqlParameter("@moduleID", SqlDbType.Int,4),
					new SqlParameter("@UserType", SqlDbType.Char,1)};
            parameters[0].Value = model.uid;
            parameters[1].Value = model.moduleID;
            parameters[2].Value = model.UserType;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int uid, int moduleID, string UserType)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from UserModuleAuth ");
            strSql.Append(" where uid = @uid and moduleid = @moduleid and UserType = @UserType ");
            SqlParameter[] parameters = {
					new SqlParameter("@uid", SqlDbType.Int,4),
                    new SqlParameter("@moduleid", SqlDbType.Int,4),
					new SqlParameter("@UserType", SqlDbType.Char,1)			};
            parameters[0].Value = uid;
            parameters[1].Value = moduleID;
            parameters[2].Value = UserType;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MES.Model.UserModuleAuth GetModel(int uid, int moduleid, string UserType)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 uid,moduleID,UserType from UserModuleAuth ");
            strSql.Append(" where uid=@uid and moduleid = @moduleid and UserType=@UserType ");
            SqlParameter[] parameters = {
					new SqlParameter("@uid", SqlDbType.Int,4),
                    new SqlParameter("@moduleid", SqlDbType.Int,4),
					new SqlParameter("@UserType", SqlDbType.Char,1)			};
            parameters[0].Value = uid;
            parameters[1].Value = moduleid;
            parameters[2].Value = UserType;

            MES.Model.UserModuleAuth model = new MES.Model.UserModuleAuth();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MES.Model.UserModuleAuth DataRowToModel(DataRow row)
        {
            MES.Model.UserModuleAuth model = new MES.Model.UserModuleAuth();
            if (row != null)
            {
                if (row["uid"] != null && row["uid"].ToString() != "")
                {
                    model.uid = int.Parse(row["uid"].ToString());
                }
                if (row["moduleID"] != null && row["moduleID"].ToString() != "")
                {
                    model.moduleID = int.Parse(row["moduleID"].ToString());
                }
                if (row["UserType"] != null)
                {
                    model.UserType = row["UserType"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int userid)
        {
            SqlCommand cmd = new SqlCommand("sp_GetUserAuth");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("userid", userid));

            return DbHelperSQL.Query(cmd);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM UserModuleAuth ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        #endregion  BasicMethod
    }
}

