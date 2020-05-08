using QWF.Framework.Services.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QWF.Framework.ExtendUtils;

namespace QWF.Framework.Services.BLL
{
    internal class User
    {
        DbAccess.T_QWF_User dbModel;
        private BLL.UserHelper helper;
        /// <summary>
        /// 设置 属性
        /// </summary>
        public DbAccess.T_QWF_User DbModel
        {
            get
            {
                return this.dbModel;
            }
            set
            {
                this.dbModel = value;
            }
        }

        public User(DbAccess.T_QWF_User dbModel, DbAccess.DbFrameworkContext db, UserHelper helper)
        {
            //初始化数据
            this.helper = helper;
            this.dbModel = dbModel;
        }

        public string GetPassword()
        {
            return this.dbModel.PassWord;
        }

        public string GetUserName()
        {
            return this.dbModel.UserName;
        }


        public bool CheckPassword(string password)
        {
            if (this.dbModel.PassWord == password)
                return true;

            return false;

        }

        public bool CheckUserInMenuPermission(string url)
        {
           var rootPath = Common.ConfigHelper.GetParameterValue("qwf.core", "SiteRootPath");
            var path = string.Empty;
            if(rootPath!=".")
            {
                path = "/"+rootPath;
            }

            var qry = from a in helper.DbContext.T_QWF_UserInRole
                      join b in helper.DbContext.T_QWF_RoleInMenu on a.RoleId equals b.RoleId
                      join c in helper.DbContext.T_QWF_MenuInUrl on b.MenuId equals c.MenuId
                      where a.UserId == dbModel.UserId && path + c.Url == url
                      select a.Id;
            if (qry.Count() > 0)
                return true;

            return false;
        }

        /// <summary>
        /// 更新用户登录转态
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public bool UpdateLoginLog(string ip)
        {
            this.dbModel.LastLoginIp = ip;
            this.dbModel.LastLoginTime = DateTime.Now;

            return true;
        }

        /// <summary>
        /// 保存到用户的COOKIE的客户端
        /// </summary>
        /// <param name="appId">APPID</param>
        public void SetUserTokenCookie(string appId)
        {
            string token = string.Empty;
            DateTime times = DateTime.Now;
            BLL.Models.UserToken userToken = new UserToken();

            userToken.CilentPassWord = (times.ToString() + this.dbModel.PassWord).StringHelper().EncodeMD5();
            userToken.Time = times;
            userToken.UserName = this.dbModel.UserName;


            string json = Newtonsoft.Json.JsonConvert.SerializeObject(userToken);
            string encryJson = Common.DES3.DES3EncryptECB(json, GlobalConst.DES3Key);

            Web.QWFRequest.WriteCookie(GlobalConst.COOKIE_Key_UserToken, encryJson);
            Web.QWFRequest.WriteCookie(GlobalConst.COOKIE_Key_AppId, appId);


        }


        /// <summary>
        /// 转化为简短的用户信息
        /// </summary>
        /// <returns></returns>
        public SvrModels.SvrShortUserInfo GetSvrShortUserInfo()
        {
            var currentUser = new Services.SvrModels.SvrShortUserInfo();

            currentUser.CurrentOrgId = this.dbModel.OrgId;
            currentUser.CurrentUserName = this.dbModel.UserName;
            currentUser.CurrentUserId = this.dbModel.UserId;
            currentUser.CurrentUserCode = this.dbModel.UserCode;
            currentUser.Realname = this.dbModel.Realname;

            return currentUser;
        }

        /// <summary>
        /// 获取新增用户的自增ID
        /// </summary>
        /// <returns></returns>
        public int GetNewUserId()
        {
            return this.dbModel.UserId;
        }

        public void StopUser()
        {
            this.dbModel.UserStatus = (int)SvrModels.SvrUserInfo.UserStatusEnum.禁用;
        }

        public void StartUser()
        {
            this.dbModel.UserStatus = (int)SvrModels.SvrUserInfo.UserStatusEnum.正常;
        }

        public void DelUser()
        {
            this.dbModel.IsDelete = 1;
            //清除用户对应的角色
            helper.DbContext.T_QWF_UserInRole.Where(w => w.UserId == this.dbModel.UserId).ToList().ForEach(item =>
              {
                  helper.DbContext.T_QWF_UserInRole.Remove(item);
              });
        }

        public void ResetPassword(string newPassword)
        {
            this.dbModel.PassWord = newPassword;
        }


    }
}
