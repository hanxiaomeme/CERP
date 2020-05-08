using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Services.SvrModels
{
    /// <summary>
    /// 基本的用户信息,用来存储到 SESSION 中
    /// </summary>
    public class SvrShortUserInfo
    {
        private int currentId = 0;

        /// <summary>
        /// 当前用户的机构ID
        /// </summary>
        public int CurrentOrgId
        {
            get;
            set;
        }
        public string CurrentUserCode { get; set; }
        /// <summary>
        /// 当前用户ID
        /// </summary>
        public int CurrentUserId
        {
            get
            {
                return currentId;
            }
            set
            {
                currentId = value;
            }
        }
        /// <summary>
        /// 当前用户名
        /// </summary>
        public string CurrentUserName { get; set; }

        public bool IsGuest
        {
            get
            {
                if (this.currentId > 0)
                    return false;
                return true;
            }
        }

        public string Realname { get; set; }
        /// <summary>
        /// 是否是管理员
        /// </summary>
        /// <returns></returns>
        public bool IsAdministrator()
        {
            if (currentId == 0)
                return false;

            return IsAuthorization("qwf.administrator");
        }

        public bool IsAuthorization(string resourceCode)
        {
         
            var cacheKey = string.Format("qwf_cache_roleresource_{0}_{1}", this.currentId ,resourceCode);
            var success = (string)Common.EasyCacheHelper.GetCache(cacheKey);

            if(success == null )
            {
                using (var db = DbAccess.DbFrameworkContext.Create())
                {
                    var qry = from a in db.T_QWF_UserInRole
                              join b in db.T_QWF_RoleInResource on a.RoleId equals b.RoleId
                              join c in db.T_QWF_Resource on b.RuleId equals c.RuleId
                              where a.UserId == this.currentId && c.ResourceCode == resourceCode
                              select a.UserId;

                    if (qry.Count() > 0)
                    {
                        success = "true";
                        Common.EasyCacheHelper.SetCache(cacheKey, success, 60);
                    }
                };
            }
            if (success == "true")
                return true;

            return false;
        }

        /// <summary>
        /// 获取用户角色代码
        /// </summary>
        /// <returns></returns>
        public string[] GetRolesCodes()
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var result = (from a in db.T_QWF_UserInRole
                              join b in db.T_QWF_Role on a.RoleId equals b.RoleId
                              where a.UserId == CurrentUserId && b.IsDelete == 0
                              select b.RoleCode
                              ).ToArray();

                return result;
            }
        }
    }
}
