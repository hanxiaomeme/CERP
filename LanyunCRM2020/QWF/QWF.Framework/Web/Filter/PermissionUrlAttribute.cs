using QWF.Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using QWF.Framework.ExtendUtils;
using System.Web;

namespace QWF.Framework.Web.Filter
{
    /// <summary>
    /// 菜单权限属性
    /// </summary>
    public class PermissionUrlAttribute : FilterAttribute, IAuthorizationFilter
    {
        private bool isAuth = true;
        /// <summary>
        /// 是否验证当前 action
        /// </summary>
        public bool IsAuth
        {
            get
            {
                return isAuth;
            }
            set
            {
                isAuth = value;
            }
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            // 支持预请求
            if (filterContext.HttpContext.Request.HttpMethod.ToLower() == "options")
            {
                filterContext.Result = new EmptyResult();
                return;
            }

            if (!isAuth)
            {
                return;
            }

            ResultWebData result = new ResultWebData();

            //获取token
            string token = filterContext.HttpContext.Request.Headers["QWF-User-Token"].SafeConvert().ToStr();
            string appId = filterContext.HttpContext.Request.Headers["QWF-AppID"].SafeConvert().ToStr();
            //string url = filterContext.HttpContext.Request.RawUrl;
            string url = filterContext.HttpContext.Request.Url.AbsolutePath;

            if (token.StrValidatorHelper().StrIsNullOrEmpty() || appId.StrValidatorHelper().StrIsNullOrEmpty())
            {
                //cookie 取值
                if (filterContext.HttpContext.Request.Cookies[GlobalConst.COOKIE_Key_UserToken] == null || filterContext.HttpContext.Request.Cookies[GlobalConst.COOKIE_Key_AppId] == null)
                {
                    throw new QWF.Framework.GlobalException.UIValidateException("用户没有登录或登录超时，请重新登录！", GlobalConst.LoginURL);
                }
                token = filterContext.HttpContext.Request.Cookies[GlobalConst.COOKIE_Key_UserToken].Value.SafeConvert().ToStr();
                appId = filterContext.HttpContext.Request.Cookies[GlobalConst.COOKIE_Key_AppId].Value.SafeConvert().ToStr();
            }
            //验证用户
            using (var qwfContext = DbAccess.DbFrameworkContext.Create())
            {
                var identifider = new Services.SvrModels.SvrUserIdentifier()
                {
                    UserId = 0,
                    UserName = string.Empty
                };

                Services.BLL.UserHelper userHelper = new Services.BLL.UserHelper(qwfContext, identifider);
                //验证用户 token 
                Services.BLL.User user = userHelper.CheckUserToken(appId, token);

                //验证用户URL 权限
                
                if (!user.CheckUserInMenuPermission(url))
                    throw new QWF.Framework.GlobalException.PermissionException(user.GetUserName() + "没有权限访问(" + url + ")");

                //验证通过则 设置当前用户信息到Session
                HttpContext.Current.Session[GlobalConst.SESSION_Key_UserInfo] = user.GetSvrShortUserInfo();
                HttpContext.Current.Session.Timeout = 40;

                qwfContext.SaveChanges();

            }

        }


    }
}
