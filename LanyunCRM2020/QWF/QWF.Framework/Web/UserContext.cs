using QWF.Framework.Services.SvrModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace QWF.Framework.Web
{
    /// <summary>
    /// 当前用户信息上下文
    /// </summary>
    public class UserContext
    {

        /// <summary>
        /// 获取当前用户基本信息
        /// </summary>
        /// <returns></returns>
        public static SvrShortUserInfo GetCurrentInfo()
        {
            SvrShortUserInfo currentUser = null;

            //优先在当前Session中取当前用户对象
            if (HttpContext.Current.Session[GlobalConst.SESSION_Key_UserInfo] != null)
            {
                currentUser = (SvrShortUserInfo)HttpContext.Current.Session[GlobalConst.SESSION_Key_UserInfo];
                HttpContext.Current.Session.Timeout = 40;

            }
            else if (HttpContext.Current.Request.Cookies[GlobalConst.COOKIE_Key_UserToken] != null && HttpContext.Current.Request.Cookies[GlobalConst.COOKIE_Key_AppId] != null)
            {
                //在COOKIE获取用户对象
                string token = HttpContext.Current.Request.Cookies[GlobalConst.COOKIE_Key_UserToken].Value.ToString();
                string appId = HttpContext.Current.Request.Cookies[GlobalConst.COOKIE_Key_AppId].Value.ToString();

                using (var qwfContext = DbAccess.DbFrameworkContext.Create())
                {
                    var identifider = new Services.SvrModels.SvrUserIdentifier();

                    Services.BLL.UserHelper userHelper = new Services.BLL.UserHelper(qwfContext,identifider);
                    //验证用户token 
                    Services.BLL.User user = userHelper.CheckUserToken(appId, token);

                    //验证通过 设置Seesion
                    HttpContext.Current.Session[GlobalConst.SESSION_Key_UserInfo] = user.GetSvrShortUserInfo();
                    HttpContext.Current.Session.Timeout = 40;

                    qwfContext.SaveChanges();

                    currentUser = user.GetSvrShortUserInfo();
                }

            }

            return currentUser;
        }

        /// <summary>
        /// 退出系统
        /// </summary>
        public static void Logout()
        {
            // 清空 全部 session
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.RemoveAll();
            HttpContext.Current.Session.Abandon();
            // 清空 登陆 cookie 
            Web.QWFRequest.RomoveCookie(GlobalConst.COOKIE_Key_UserToken);

        }


    }
}
