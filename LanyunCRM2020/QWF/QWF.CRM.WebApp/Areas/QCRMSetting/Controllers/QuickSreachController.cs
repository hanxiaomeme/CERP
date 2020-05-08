using QWF.Framework.ExtendUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QWF.Framework.ExtendUtils;
using QWF.Framework.GlobalException;

namespace QWF.CRM.WebApp.Areas.QCRMSetting.Controllers
{
    public class QuickSreachController : Controller
    {
        // GET: QCRMSetting/QickSreach
        public ActionResult Index()
        {
            using (var db = DbAccess.DbCRMContext.Create())
            {
                var dictionaryList = db.T_QCRM_Dictionary.AsNoTracking().Where(w => w.Hide == 0 && w.ParentId == 0).ToList()
                    .Select(s => new QWF.Framework.Web.BaseItemKeyValue
                    {
                        Key = s.Id.ToString(),
                        Value = s.ItemName
                    }).ToList();

                ViewBag.DictionaryList = dictionaryList;

            }
            return View();
        }

        public ActionResult GetList()
        {
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var qry = from a in db.T_QCRM_QuickSreach.AsNoTracking()
                          join dic in db.T_QCRM_Dictionary.AsNoTracking() on a.DictionaryId equals dic.Id into bb
                          from b in bb.DefaultIfEmpty()
                          select new
                          {
                              a.Id,
                              a.QueryFieldId,
                              a.SreachTitle,
                              a.SreachType,
                              a.CreateTime,
                              a.UpdateTime,
                              a.DictionaryId,
                              DictionaryName = b == null ? "" : b.ItemName
                          };

                var total = qry.Count();
                var sreachTypes = QWF.Framework.MainServices.CreateWebAppServices.GetConfigServices().GetNodeItemsByCode("qwf.qcrm.qicksreachtype");

                var rows = from a in qry.ToList()
                           join b in sreachTypes on a.SreachType equals b.Value
                           select new
                           {
                               a.Id,
                               a.QueryFieldId,
                               a.SreachTitle,
                               a.SreachType,
                               a.DictionaryId,
                               a.DictionaryName,
                               SreachTypeName = a.SreachType == "select" ? b.Name + "【" + a.DictionaryName + "】" : b.Name,
                               CreateTime = a.CreateTime.SafeConvert().ToTimeStrDefault(),
                               UpdateTime = a.UpdateTime.SafeConvert().ToTimeStrDefault()
                           };

                rows = rows.OrderBy(o => o.CreateTime).ToList();

                var result = new { total = total, rows = rows };
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));

            }
        }


        public ActionResult GetFieldList()
        {
            using (var db = DbAccess.DbCRMContext.Create())
            {
                var defaultListType = QWF.Framework.Common.ConfigHelper.GetParameterValue("qwf.crm", "customer.main.list");


                var qry = db.T_QCRM_QueryList.AsNoTracking().Where(w => w.ListType == defaultListType).ToList().Select(s => new
                {
                    Id = s.Id.ToString(),
                    Name = s.TitleName
                });

                var result = qry.ToList();
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));

            }
        }


        public ActionResult Save()
        {
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            var result = QWF.Framework.Web.ResultWebData.Default();

            var id = this.Request["id"].SafeConvert().ToInt32(0);
            var queryFieldId = Request["queryFieldId"].SafeConvert().ToInt32(0);
            var sreachTitle = Request["sreachTitle"].SafeConvert().ToStr();
            var sreachType = Request["sreachType"].SafeConvert().ToStr();
            var dictionaryId = Request["dictionaryId"].SafeConvert().ToInt32(0);


            if (sreachTitle.Length == 0)
                throw new UIValidateException("请填写搜索字段名称。");
            if (sreachType.Length == 0)
                throw new UIValidateException("请选择搜索类型。");

            if (sreachType == "select" && dictionaryId == 0)
                throw new UIValidateException("请选择表单字典。");

            using (var db = DbAccess.DbCRMContext.Create())
            {

                if (db.T_QCRM_QueryList.Where(w => w.Id == queryFieldId).Count() == 0)
                    throw new UIValidateException("查询字段不存在,ID=[{0}]", queryFieldId);

                if (id == 0)
                {
                    if (db.T_QCRM_QuickSreach.Where(w => w.QueryFieldId == queryFieldId).Count() > 0)
                        throw new UIValidateException("该字段已经配置过了，请选择其它字段。");

                    var dbModel = new QWF.CRM.DbAccess.T_QCRM_QuickSreach();

                    dbModel.QueryFieldId = queryFieldId;
                    dbModel.SreachTitle = sreachTitle;
                    dbModel.SreachType = sreachType;
                    dbModel.DictionaryId = sreachType == "select" ? dictionaryId : 0;

                    dbModel.CreateTime = DateTime.Now;
                    dbModel.CreateUser = curUser.CurrentUserName;

                    db.T_QCRM_QuickSreach.Add(dbModel);

                }
                else
                {
                    var dbModel = db.T_QCRM_QuickSreach.Where(w => w.Id == id).FirstOrDefault();
                    if (dbModel == null)
                        throw new UIValidateException("该配置数据不存在，可能已经被删除。");

                    if (db.T_QCRM_QuickSreach.Where(w => w.QueryFieldId == queryFieldId && w.Id !=id).Count() > 0)
                        throw new UIValidateException("该字段已经配置过了，请选择其它字段。");

                    dbModel.QueryFieldId = queryFieldId;
                    dbModel.SreachTitle = sreachTitle;
                    dbModel.SreachType = sreachType;
                    dbModel.DictionaryId = sreachType == "select" ? dictionaryId : 0;
                    dbModel.UpdateTime = DateTime.Now;
                    dbModel.UpdateUser = curUser.CurrentUserName;
                }

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
                var dbModel = db.T_QCRM_QuickSreach.Where(w => w.Id == id).FirstOrDefault();

                if (dbModel != null)
                {
                    //移除用户配置
                    db.T_QCRM_QuickSreachUser.Where(w => w.SreachId == id).ToList().ForEach(item =>
                    {
                        db.T_QCRM_QuickSreachUser.Remove(item);
                    });

                    //移除全局配置
                    db.T_QCRM_QuickSreach.Remove(dbModel);

                }


                db.SaveChanges();
            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

    }
}