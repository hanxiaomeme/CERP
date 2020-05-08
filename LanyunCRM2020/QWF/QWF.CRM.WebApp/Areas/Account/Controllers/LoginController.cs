using QWF.Framework;
using QWF.Framework.ExtendUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QWF.CRM.WebApp.Areas.Account.Controllers
{
    public class LoginController : Controller
    {
        [QWF.Framework.Web.Filter.PermissionUrl(IsAuth = false)]
        public ActionResult Index()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();
            string appid = "qwf.app.qcrm";

            string userName = this.Request["userName"].SafeConvert().ToStr();
            string passWord = this.Request["passWord"].SafeConvert().ToStr();

            MainServices.GuestServices.GetUserLoginServices().CheckUserLogin(appid, userName, passWord);

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));


        }
    }
}