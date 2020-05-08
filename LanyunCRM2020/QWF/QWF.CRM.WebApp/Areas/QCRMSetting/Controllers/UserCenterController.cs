using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QWF.Framework.ExtendUtils;

namespace QWF.CRM.WebApp.Areas.QCRMSetting.Controllers
{
    public class UserCenterController : Controller
    {
        // GET: QCRMSetting/UserCenter
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get()
        {
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            var result = QWF.Framework.Web.ResultWebData.Default();

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var userCenter = db.T_QCRM_UserCenter.Where(w => w.UserCode == curUser.CurrentUserCode).FirstOrDefault();

                result.Data = userCenter;

                return Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
            }
        }

        public ActionResult Save()
        {
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            var result = QWF.Framework.Web.ResultWebData.Default();

            var uiStyle = Request["uiStyle"].SafeConvert().ToStr();

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var dbModel = db.T_QCRM_UserCenter.Where(w => w.UserCode == curUser.CurrentUserCode).FirstOrDefault();

                if (dbModel == null)
                {
                    dbModel = new DbAccess.T_QCRM_UserCenter();

                    dbModel.UserCode = curUser.CurrentUserCode;
                    dbModel.UI_Style = uiStyle;
                    dbModel.CreateTime = DateTime.Now;

                    db.T_QCRM_UserCenter.Add(dbModel);
                }
                else
                {
                    //更新
                    dbModel.UI_Style = uiStyle;
                    dbModel.UpdateTime = DateTime.Now;
                }

                db.SaveChanges();

                return Content(Newtonsoft.Json.JsonConvert.SerializeObject(uiStyle));
            }
        }
    }
}