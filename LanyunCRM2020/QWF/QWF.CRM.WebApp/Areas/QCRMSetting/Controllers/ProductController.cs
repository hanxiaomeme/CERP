using QWF.Framework.ExtendUtils;
using QWF.Framework.GlobalException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QWF.CRM.WebApp.Areas.QCRMSetting.Controllers
{
    public class ProductController : Controller
    {
        // GET: QCRMSetting/BDS_QueryList
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList()
        {

            var qryName = this.Request["qryName"].SafeConvert().ToStr();

            int pageSize = this.Request["rows"].SafeConvert().ToInt32(30);
            int pageIndex = this.Request["page"].SafeConvert().ToInt32(1);
            var pageSort = this.Request["sort"].SafeConvert().ToStr("SortId"); //排序字段 
            var pageOrderby = this.Request["orderby"].SafeConvert().ToStr("asc");// 升序或降序

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var qry = from a in db.T_QCRM_Product
                          select new
                          {
                              a.Id,
                              a.Code,
                              a.Name,
                              a.SortId,
                              a.UpdateTime,
                              a.CreateTime,
                              a.ServerType,
                              a.IsHide,
                              a.ItemTitle
                              
                          };

                //排序
                qry = QWF.Framework.Dynamic.QueryableHelper.DataSorting(qry, pageSort, pageOrderby);

                //过滤
                if (qryName.Length > 0)
                    qry = qry.Where(w => w.Name.IndexOf(qryName) > -1);

                var total = qry.Count();
                qry = QWF.Framework.Dynamic.QueryableHelper.DataPaging(qry, pageIndex, pageSize);
                var fieldTypes = QWF.Framework.MainServices.CreateWebAppServices.GetConfigServices().GetNodeItemsByCode("qwf.qcrm.fieldtype");

                var rows = qry.ToList().Select(s =>
                new
                {
                    s.Id,
                    s.Code,
                    s.Name,
                    s.ServerType,
                    ServerTypeName = s.ServerType == 1 ? "有时限" : "一次性服务",
                    s.IsHide,
                    HideName = s.IsHide == 1 ? "√" : "",
                    s.ItemTitle,
                    CreateTime = s.CreateTime.SafeConvert().ToTimeStrDefault(),
                    UpdateTime = s.UpdateTime.SafeConvert().ToTimeStrDefault()
                });

                var result = new { total = total, rows = rows };
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));

            }
        }

        public ActionResult Save()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();

            var id = this.Request["id"].SafeConvert().ToInt32();
            var name = this.Request["productName"].SafeConvert().ToStr();
            var serverType = this.Request["serverType"].SafeConvert().ToInt32();
            var isHide = this.Request["isHide"].SafeConvert().ToBool();
            var itemTitle = this.Request["itemTitle"].SafeConvert().ToStr();

            if (name.Length == 0)
                throw new UIValidateException("请填写公司相关业务的名称");

            using (var db = DbAccess.DbCRMContext.Create())
            {
                if (id == 0)
                {
                    //新增:
                    if (db.T_QCRM_Product.Where(w => w.Name == name).Count() > 0)
                        throw new UIValidateException("{0}已经存在,请换一个名称。",name);

                    var dbModel = new DbAccess.T_QCRM_Product();
                    var maxId = db.T_QCRM_Product.Max(m => m.SortId);
                    dbModel.SortId = (maxId == null ? 0 : maxId.Value) + 1;
                    dbModel.Code = QWF.Framework.MainServices.CreateWebAppServices.GetSeqServices().CreateNewSeqNo("crm.product.code");
                    dbModel.Name = name;
                    dbModel.ServerType = serverType;
                    dbModel.ItemTitle = itemTitle;
                    dbModel.CreateTime = DateTime.Now;
                    dbModel.CreateUser = curUser.CurrentUserCode;

                    db.T_QCRM_Product.Add(dbModel);

                }
                else
                {
                    var dbModel = db.T_QCRM_Product.Where(w => w.Id == id).FirstOrDefault();
                    if (dbModel == null)
                        throw new UIValidateException("要编辑的数据不存在,ID={0}。",id);

                    dbModel.Name = name;
                    dbModel.ServerType = serverType;
                    dbModel.IsHide = isHide ? 1 : 0;
                    dbModel.ItemTitle = itemTitle;
                    dbModel.UpdateUser = curUser.CurrentUserName;
                    dbModel.UpdateTime = DateTime.Now;
                }

                db.SaveChanges();
            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));

        }

        public ActionResult Delete()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();

            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            var id = this.Request["id"].SafeConvert().ToInt32(0);

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var dbModel = db.T_QCRM_Product.Where(w => w.Id == id).FirstOrDefault();

                if (dbModel != null)
                    db.T_QCRM_Product.Remove(dbModel);

                db.T_QCRM_ProductItem.Where(w => w.ProduceCode == dbModel.Code).ToList().ForEach(item =>
                {
                    db.T_QCRM_ProductItem.Remove(item);
                });

                db.SaveChanges();
            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        public ActionResult GetProductItem()
        {
            var productCode = this.Request["qryProductCode"].SafeConvert().ToStr();
            using (var db = DbAccess.DbCRMContext.Create())
            {
                var rows = db.T_QCRM_ProductItem.Where(w => w.ProduceCode == productCode).OrderBy(o => o.SortId).ToList().
                    Select(s => new
                    {
                        s.Id,
                        s.ProduceCode,
                        s.ItemName,
                        s.IsHide,
                        HideName = s.IsHide == 1 ? "√" : "",
                        CreateTime = s.CreateTime.SafeConvert().ToTimeStrDefault(),
                        UpdateTime = s.UpdateTime.SafeConvert().ToTimeStrDefault()

                    });
                var result = new { total = rows.Count(), rows = rows };
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
            }
        }

        public ActionResult Sort()
        {
            var dic = QWF.Framework.Web.QWFRequest.GetSortDictionary();
            //
            var result = QWF.Framework.Web.ResultWebData.Default();
            var formData = Request["id"].SafeConvert().ToInt32(0);
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            //排序
            using (var db = DbAccess.DbCRMContext.Create())
            {
                foreach (var d in dic)
                {
                    var dbModel = db.T_QCRM_Product.Where(w => w.Id == d.Key).FirstOrDefault();
                    if (dbModel != null)
                    {
                        dbModel.SortId = d.Value;
                    }
                }
                db.SaveChanges();
            }


            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }


        public ActionResult SaveProductItem()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();

            var productCode = this.Request["productCode"].SafeConvert().ToStr();
            var itemId = this.Request["itemId"].SafeConvert().ToInt32();
            var itemName = this.Request["productItemName"].SafeConvert().ToStr();
            var isHide = this.Request["productItemHide"].SafeConvert().ToBool();

            if (itemName.Length == 0)
                throw new UIValidateException("请填写公司相关业务的名称");

            using (var db = DbAccess.DbCRMContext.Create())
            {
                if (itemId == 0)
                {
                    //新增:
                    if (db.T_QCRM_ProductItem.Where(w => w.ItemName == itemName && w.ProduceCode == productCode).Count() > 0)
                        throw new UIValidateException("{0}已经存在,请换一个名称!",itemName);

                    var dbModel = new DbAccess.T_QCRM_ProductItem();
                    var maxId = db.T_QCRM_ProductItem.Max(m => m.SortId);
                    dbModel.ProduceCode = productCode;
                    dbModel.SortId = (maxId == null ? 0 : maxId.Value) + 1;
                    dbModel.ItemName = itemName;
                    dbModel.CreateTime = DateTime.Now;
                    dbModel.CreateUser = curUser.CurrentUserCode;

                    db.T_QCRM_ProductItem.Add(dbModel);

                }
                else
                {
                    var dbModel = db.T_QCRM_ProductItem.Where(w => w.Id == itemId).FirstOrDefault();
                    if (dbModel == null)
                        throw new UIValidateException("要编辑的数据不存在，id={0}",itemId);

                    dbModel.ItemName = itemName;
                    dbModel.IsHide = isHide ? 1 : 0;
                    dbModel.UpdateUser = curUser.CurrentUserName;
                    dbModel.UpdateTime = DateTime.Now;
                }

                db.SaveChanges();
            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));

        }

        public ActionResult SortItem()
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
                    var dbModel = db.T_QCRM_ProductItem.Where(w => w.Id == d.Key).FirstOrDefault();
                    if (dbModel != null)
                    {
                        dbModel.SortId = d.Value;
                    }
                }
                db.SaveChanges();
            }


            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        public ActionResult DeleteProductItem()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();

            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            var id = this.Request["itemId"].SafeConvert().ToInt32(0);


            using (var db = DbAccess.DbCRMContext.Create())
            {
                var dbModel = db.T_QCRM_ProductItem.Where(w => w.Id == id).FirstOrDefault();

                if (dbModel != null)
                    db.T_QCRM_ProductItem.Remove(dbModel);

                db.SaveChanges();
            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }


     
    }
}
