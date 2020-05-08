using QWF.Framework.ExtendUtils;
using QWF.Framework.GlobalException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QWF.CRM.WebApp.Areas.QCRMSetting.Controllers
{
    public class QuickSreachUserController : Controller
    {
        // GET: QCRMSetting/QuickSreachUser
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList()
        {
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var qry = from a in db.T_QCRM_QuickSreach.AsNoTracking()
                          join b in db.T_QCRM_QuickSreachUser.AsNoTracking() on a.Id equals b.SreachId
                          where b.UserCode == curUser.CurrentUserCode
                          select new
                          {
                              b.Id,
                              b.SreachId,
                              a.SreachTitle,
                              b.CreateTime
                          };
                var total = qry.Count();

                var rows = from a in qry.ToList()

                           select new
                           {
                               a.Id,
                               a.SreachId,
                               a.SreachTitle,
                               CreateTime = a.CreateTime.SafeConvert().ToTimeStrDefault()
                           };

                rows = rows.OrderBy(o => o.CreateTime).ToList();

                var result = new { total = total, rows = rows };
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));

            }
        }


        public ActionResult GetSreachFieldList()
        {
            using (var db = DbAccess.DbCRMContext.Create())
            {
                var qry = db.T_QCRM_QuickSreach.AsNoTracking().ToList().Select(s => new
                {
                    Id = s.Id.ToString(),
                    Name = s.SreachTitle
                });
                var result = qry.ToList();
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
            }
        }


        public ActionResult Save()
        {
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            var result = QWF.Framework.Web.ResultWebData.Default();

            var sreachId = Request["sreachId"].SafeConvert().ToInt32(0);
            if (sreachId == 0)
                throw new UIValidateException("请选择需要搜索字段。");

            using (var db = DbAccess.DbCRMContext.Create())
            {

                if (db.T_QCRM_QuickSreach.Where(w => w.Id == sreachId).Count() == 0)
                    throw new UIValidateException("搜索字段没有配置,id=[{0}]。", sreachId);

                if (db.T_QCRM_QuickSreachUser.Where(w => w.SreachId == sreachId && w.UserCode == curUser.CurrentUserCode).Count() > 0)
                    throw new UIValidateException("该字段已经配置，请选择别的搜索字段。");

                var dbModel = new QWF.CRM.DbAccess.T_QCRM_QuickSreachUser();

                dbModel.UserCode = curUser.CurrentUserCode;
                dbModel.SreachId = sreachId;
                dbModel.CreateTime = DateTime.Now;

                db.T_QCRM_QuickSreachUser.Add(dbModel);

                db.SaveChanges();

                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
            }
        }

        public ActionResult Delete()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();

            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            var id = this.Request["id"].SafeConvert().ToInt32(0);

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var dbModel = db.T_QCRM_QuickSreachUser.Where(w => w.Id == id && w.UserCode == curUser.CurrentUserCode).FirstOrDefault();

                if (dbModel != null)
                {
                    db.T_QCRM_QuickSreachUser.Remove(dbModel);
                }
                db.SaveChanges();
            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }
    }
}
