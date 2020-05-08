using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LanyunMES.DAL
{
    using Common;
    using Entity;
    using Lanyun.DBUtil;

    public class UserTokenDAL
    {

        public UserToKen GetUserInfo(string userName, DateTime busiDate)
        {
            UserToKen user = new UserToKen();

            DataTable dt; 

            #region USER信息
            string sql = "select * from UserInfo where userName = @userName";
            SqlParameter param = new SqlParameter("userName", userName);

            dt = DbHelperSQL.Query(sql, param).Tables[0];

            if (dt.Rows.Count == 1)
            {
                user.UserId = (int)dt.Rows[0]["userid"];
                user.UserName = userName;

                //if (dt.Rows[0]["PersonCode"].ToString() == "")
                //{
                //    user.PsnId = 0;
                //    user.PsnCode = "未指定人员";
                //    user.PsnName = "未指定人员";
                //}
                //else
                //{
                //    user.PsnId = int.Parse(dt.Rows[0]["PersonId"].ToString());
                //    user.PsnCode = dt.Rows[0]["PersonCode"].ToString();
                //    user.PsnName = dt.Rows[0]["PersonName"].ToString();
                //    user.DepId = int.Parse(dt.Rows[0]["PersonDepId"].ToString());
                //    user.DepCode = dt.Rows[0]["PersonDepCode"].ToString();
                //    user.DepName = dt.Rows[0]["PersonDepName"].ToString();
                //}
            }
            #endregion

            #region USER是否管理员

            //sql = "select 1 from v_UserRole where RoleID in (1,5) and userName = @userName";

            //dt = DbHelperSQL.Query(sql, param).Tables[0]; 
               
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    user.isAdmin = true;
            //}
            #endregion

            #region 获取用户模块信息
            //sql = "sp_GetUserFuncModule @userName";
            sql = "select * from v_ModuleInfo order by ModuleCode";
            dt = DbHelperSQL.Query(sql, param).Tables[0];
            if (dt != null)
            {
                user.UserFuncModule = dt;
            }
            #endregion

            user.BusiDate = busiDate;
            user.HostName = WorkDevice.HostName;
            user.IPAddr = WorkDevice.IPAddress[0];

            return user;

        }
    }
}
