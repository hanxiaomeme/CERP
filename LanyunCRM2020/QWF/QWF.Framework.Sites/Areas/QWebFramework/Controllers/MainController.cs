using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QWF.Framework.ExtendUtils;

namespace QWF.Framework.Sites.Areas.QWebFramework.Controllers
{
    public class MainController : Controller
    {
        public ActionResult Index()
        {
            var userInfo = Web.UserContext.GetCurrentInfo();

            return View(userInfo);
        }

        public ActionResult ResetPassword()
        {

            var oldPassword = this.Request["oldPwd"].SafeConvert().ToStr();
            var newPassword = this.Request["newPwd"].SafeConvert().ToStr();
            var curUserId = Web.UserContext.GetCurrentInfo().CurrentUserId;

            MainServices.CreateWebAppServices.GetUserServices().ResetPassword(curUserId,oldPassword, newPassword);
            var result = Web.ResultWebData.Default();
            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result)); 
        }

        [QWF.Framework.Web.Filter.PermissionUrl(IsAuth = false)]
        public ActionResult Logout()
        {
            //退出
            Web.UserContext.Logout();
            var loginUrl = QWF.Framework.Common.ConfigHelper.GetParameterValue(QWF.Framework.GlobalConst.APP_Core_ConfigName, "LoginUrl");
            return Redirect(loginUrl);
        }


    }
}