using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MES.DAL
{
    using Model;

    public class UA_UserDAL
    {

        public bool Exist(string user)
        {
            string sql = "select count(1) from UFSystem..UA_User where cUser_ID = @user or cUser_Name = @user";

            SqlParameter p1 = new SqlParameter("@userName", user);

            return DbHelperSQL.Exists(sql, p1);
        }

        public bool Login(string user, string ExtPassword)
        {
            string sql = "select count(1) from UFSystem..UA_User where (cUser_ID = @user or cUser_Name = @user)";
            sql += " and pwdcompare(@ExtPassword,ExtPassword) = 1";

            SqlParameter p1 = new SqlParameter("@user", user);
            SqlParameter p2 = new SqlParameter("@ExtPassword", ExtPassword);

            return DbHelperSQL.Exists(sql, p1, p2);
        }

        public int ModifyPwd(string cUser_ID, string ExtPassword)
        {
            string sql = "update UFSystem..UA_User set ExtPassword = pwdencrypt(@password) where cUser_ID = @userid";
            SqlParameter p1 = new SqlParameter("@password", ExtPassword);
            SqlParameter p2 = new SqlParameter("@userid", cUser_ID);

            return DbHelperSQL.ExecuteSql(sql, p1, p2);
        }

        public DataSet GetList(string strWhere)
        {
            string sql = "select * from UFSystem..UA_User ";
            if (!string.IsNullOrEmpty(strWhere))
            {
                sql += " where " + strWhere;
            }

            return DbHelperSQL.Query(sql);
        }

        public User GetModel(string user)
        {
            string sql = "select * from UFSystem..UA_User where cUser_ID = @user or cUser_Name = @user";

            SqlParameter p1 = new SqlParameter("@user", user);
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add(p1);

            DataRow row = DbHelperSQL.Query(cmd).Tables[0].Rows[0];

            return (DataRowToModel(row));
        }

        public User DataRowToModel(DataRow row)
        {
            User model = new User();

            if (row["cUser_ID"] != null && row["cUser_ID"].ToString() != "")
            {
                model.cUser_Id = row["cUser_ID"].ToString();
            }
            if (row["cUser_Name"] != null && row["cUser_Name"].ToString() != "")
            {
                model.cUser_Name = Convert.ToString(row["cUser_Name"]);
            }
            //if (row["dCrDate"] != null && row["dCrDate"].ToString() != "")
            //{
            //    model. = Convert.ToDateTime(row["dCrDate"]);
            //}

            return model;
        }
    }
}
