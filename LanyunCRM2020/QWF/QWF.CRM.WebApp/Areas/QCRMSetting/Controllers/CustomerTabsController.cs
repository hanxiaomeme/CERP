using QWF.Framework.ExtendUtils;
using QWF.Framework.GlobalException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QWF.CRM.WebApp.Areas.QCRMSetting.Controllers
{
    public class CustomerTabsController : Controller
    {
        // GET: QCRMSetting/CustomerTabs
        public ActionResult Index()
        {
            using (var db = DbAccess.DbCRMContext.Create())
            {
                var fields = db.T_QCRM_Fields.Where(w => w.TableCode == "TB_Customer" && w.Deleted == 0).Select(s => new QWF.Framework.Web.BaseItemKeyValue { Key = s.Code, Value = s.Name }).ToList();
                ViewBag.Tabs = CRM.Utils.ConfigUtils.Instance.GetCustomerTabs();
                ViewBag.Fields = fields;

            }
            return View();
        }

        public ActionResult GetList()
        {
            var tabCode = this.Request["qryTabCode"].SafeConvert().ToStr();

            int pageSize = this.Request["rows"].SafeConvert().ToInt32(30);
            int pageIndex = this.Request["page"].SafeConvert().ToInt32(1);
            var pageSort = this.Request["sort"].SafeConvert().ToStr("SortId"); //排序字段 
            var pageOrderby = this.Request["orderby"].SafeConvert().ToStr("asc");// 升序或降序

            using (var db = DbAccess.DbCRMContext.Create())
            {
                //获取客户表
                var tabConfig = QWF.Framework.Common.ConfigHelper.GetConfigXml("qwf.crm").SelectNodes("/ConfigPool/CustomerTab/Item");
                var tabs = CRM.Utils.ConfigUtils.Instance.GetCustomerTabs();

                var qry = from a in db.T_QCRM_Tabs
                          join b in db.T_QCRM_Fields on new { TableCode = a.TableCode, FieldCode = a.FieldCode } equals new { TableCode = b.TableCode, FieldCode = b.Code }
                          where b.TableCode == "TB_Customer"
                          select new
                          {
                              a.Id,
                              a.TabCode,
                              a.SortId,
                              FieldName = b.Name
                          };
                //排序
                qry = QWF.Framework.Dynamic.QueryableHelper.DataSorting(qry, pageSort, pageOrderby);

                qry = qry.Where(w => w.TabCode == tabCode);

                var total = qry.Count();
                qry = QWF.Framework.Dynamic.QueryableHelper.DataPaging(qry, pageIndex, pageSize);

                var rows = from a in qry.ToList()
                           join b in tabs on a.TabCode equals b.Key
                           select new
                           {
                               a.Id,
                               a.FieldName,
                               a.TabCode,
                               a.SortId,
                               TabName = b.Value
                           };


                var result = new { total = total, rows = rows };
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));

            }
        }

        public ActionResult Save()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();

            var tabCode = this.Request["tabCode"].SafeConvert().ToStr();
            var fieldCode = this.Request["fieldCode"].SafeConvert().ToStr();
            if (string.IsNullOrWhiteSpace(tabCode) || string.IsNullOrWhiteSpace(fieldCode))
                throw new UIValidateException("请选择所属表或所属字段。");

            using (var db = DbAccess.DbCRMContext.Create())
            {
                if (db.T_QCRM_Tabs.Where(w => w.TabCode == tabCode && w.FieldCode == fieldCode).Count() == 0)
                {
                    var dbModel = new DbAccess.T_QCRM_Tabs();
                    var maxId = db.T_QCRM_Tabs.Max(m => m.SortId);
                    dbModel.SortId = (maxId == null ? 0 : maxId.Value) + 1;
                    dbModel.TabCode = tabCode;
                    dbModel.TableCode = "TB_Customer";
                    dbModel.FieldCode = fieldCode;

                    db.T_QCRM_Tabs.Add(dbModel);

                    db.SaveChanges();
                }

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
                var dbModel = db.T_QCRM_Tabs.Where(w => w.Id == id).FirstOrDefault();

                if (dbModel != null)
                    db.T_QCRM_Tabs.Remove(dbModel);

                db.SaveChanges();
            }
            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }


        public ActionResult Sort()
        {
            var dic = QWF.Framework.Web.QWFRequest.GetSortDictionary();
            //
            var result = QWF.Framework.Web.ResultWebData.Default();
            var formData = Request["id"].SafeConvert().ToInt32(0);

            //排序
            using (var db = DbAccess.DbCRMContext.Create())
            {
                foreach (var d in dic)
                {
                    var dbModel = db.T_QCRM_Tabs.Where(w => w.Id == d.Key).FirstOrDefault();
                    if (dbModel != null)
                    {
                        dbModel.SortId = d.Value;
                    }
                }
                db.SaveChanges();
            }
            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }
    }
}