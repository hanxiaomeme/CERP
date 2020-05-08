using QWF.Framework.ExtendUtils;
using QWF.Framework.GlobalException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QWF.CRM.WebApp.Areas.QCRMSetting.Controllers
{
    public class BDS_ListTypeController : Controller
    {
        // GET: QCRMSetting/BDS_ListType
        //自定义查询列表
        public ActionResult Index()
        {
            using (var db = DbAccess.DbCRMContext.Create())
            {
                var formList = db.T_QCRM_Form.AsNoTracking().Select(s => new QWF.Framework.Web.BaseItemKeyValue { Value = s.Name, Key = s.Code }).ToList();
                ViewBag.FormList = formList;
            }
            return View();
        }

        public ActionResult GetList()
        {

            var listType = this.Request["qryListType"].SafeConvert().ToStr();
            var name = this.Request["qryName"].SafeConvert().ToStr();

            int pageSize = this.Request["rows"].SafeConvert().ToInt32(30);
            int pageIndex = this.Request["page"].SafeConvert().ToInt32(1);
            var pageSort = this.Request["sort"].SafeConvert().ToStr("CreateTime"); //排序字段 
            var pageOrderby = this.Request["orderby"].SafeConvert().ToStr("desc");// 升序或降序

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var qry = db.T_QCRM_ListType.AsNoTracking().AsQueryable();

                //排序
                qry = QWF.Framework.Dynamic.QueryableHelper.DataSorting(qry, pageSort, pageOrderby);

                //过滤
                if (listType.Length > 0)
                {
                    qry = qry.Where(w => w.ListType.Contains(listType));
                }
                if (name.Length > 0)
                {
                    qry = qry.Where(w => w.TypeName.Contains(name));

                }

                var total = qry.Count();
                qry = QWF.Framework.Dynamic.QueryableHelper.DataPaging(qry, pageIndex, pageSize);

                var rows = from a in qry.ToList()
                           select new
                           {

                               a.ListType,
                               a.TypeName,
                               a.IsHide,
                               IsHideName = a.IsHide == 1 ? "√" : "",
                               a.TableRelation,
                               a.OrderBy,
                               a.PageSize,
                               a.Remarks,
                               a.AscOrDesc,
                               AscOrDescName = a.AscOrDesc == "desc"?"降序":"升序",
                               CreateTime = a.CreateTime.SafeConvert().ToTimeStrDefault(),
                               UpdateTime = a.UpdateTime.SafeConvert().ToTimeStrDefault(),

                           };

                var result = new { total = total, rows = rows };
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));

            }
        }

        public ActionResult Save()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            var permission = QWF.CRM.Utils.PermissionUtils.Create();

            var id = this.Request["id"].SafeConvert().ToStr();
            var listType = this.Request["listType"].SafeConvert().ToStr();
            var typeName = this.Request["typeName"].SafeConvert().ToStr();
            var remarks = this.Request["remarks"].SafeConvert().ToStr();
            var tableRelation = this.Request["tableRelation"].SafeConvert().ToStr();
            var orderBy = this.Request["orderBy"].SafeConvert().ToStr();
            var pageSize = this.Request["pageSize"].SafeConvert().ToInt32(30);
            var ascOrDesc = this.Request["ascOrDesc"].SafeConvert().ToStr("desc");

            if (id.Length == 0 && listType.Length == 0)
                throw new UIValidateException("编号不能空填。");
            if (typeName.Length == 0)
                throw new UIValidateException("名称不能为空填。");

            if (permission.IsAdministrator())
            {
                if (orderBy.Length == 0)
                    throw new UIValidateException("排序字段不能空填。");
                if (tableRelation.Length == 0)
                    throw new UIValidateException("表关系不能空填。");
            }

            using (var db = DbAccess.DbCRMContext.Create())
            {
                if (id.Length == 0)
                {
                    if (!listType.StrValidatorHelper().IsLetterOrNumberCode())
                        throw new UIValidateException("编号格式不正确，只能是字母、数字或下划线组合。");

                    var dbModel = db.T_QCRM_ListType.Where(w => w.ListType == listType).FirstOrDefault();
                    if (dbModel != null)
                        throw new UIValidateException("编号为【{0}】的数据已经存在，请更换。", listType);

                    dbModel = new DbAccess.T_QCRM_ListType();
                    dbModel.ListType = listType;
                    dbModel.TypeName = typeName;
                    dbModel.OrderBy = orderBy;
                    dbModel.AscOrDesc = ascOrDesc;
                    dbModel.PageSize = pageSize;
                    dbModel.TableRelation = tableRelation;
                    dbModel.Remarks = remarks;
                    dbModel.CreateUser = curUser.CurrentUserCode;
                    dbModel.CreateTime = DateTime.Now;


                    db.T_QCRM_ListType.Add(dbModel);
                }
                else
                {
                    //编辑
                    var dbModel = db.T_QCRM_ListType.Where(w => w.ListType == id).FirstOrDefault();
                    if (dbModel == null)
                        throw new UIValidateException("编号为【{0}】的数据不存在，不能编辑。", id);

                    dbModel.TypeName = typeName;
                    dbModel.OrderBy = orderBy;
                    dbModel.AscOrDesc = ascOrDesc;
                    dbModel.PageSize = pageSize;
                    dbModel.TableRelation = tableRelation;
                    dbModel.Remarks = remarks;
                    dbModel.UpdateUser = curUser.CurrentUserCode;
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
            var listType = this.Request["listType"].SafeConvert().ToStr();

            if (listType.Length == 0)
                throw new UIValidateException("编码为空，不能删除");

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var dbModel = db.T_QCRM_ListType.Where(w => w.ListType == listType).FirstOrDefault();

                if (db.T_QCRM_QueryList.Where(w => w.ListType == listType).Count() > 0)
                    throw new UIValidateException("在【{0}】的【查询列表字段管理】下还存在数据字段配置子项，不能删除。", dbModel.TypeName);

                db.T_QCRM_ListType.Remove(dbModel);

                db.T_QCRM_ListInForm.Where(w => w.ListType == listType).ToList().ForEach(item =>
                {
                    //移除关联
                    db.T_QCRM_ListInForm.Remove(item);
                });


                //写入操作日志
                QWF.Framework.MainServices.CreateWebAppServices.GetUserActionLogServices().
                    WriterActionLog("查询列表管理删除", Framework.Services.SvrModels.SverUserActionLogType.Delete, null, new { 编码 = dbModel.ListType, 名称 = dbModel.TypeName });

                db.SaveChanges();
            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }


        public ActionResult GetListFormByCode()
        {
            var listType = this.Request["listType"].SafeConvert().ToStr();

            int pageSize = this.Request["rows"].SafeConvert().ToInt32(30);
            int pageIndex = this.Request["page"].SafeConvert().ToInt32(1);
            var pageSort = this.Request["sort"].SafeConvert().ToStr("SortId"); //排序字段 
            var pageOrderby = this.Request["orderby"].SafeConvert().ToStr("asc");// 升序或降序

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var qry = from a in db.T_QCRM_ListInForm.AsNoTracking()
                          join b in db.T_QCRM_Form.AsNoTracking() on a.FormCode equals b.Code
                          where a.ListType == listType
                          select new
                          {
                              a.Id,
                              a.FormCode,
                              a.ListType,
                              a.SortId,
                              a.CreateTime,
                              FormName = b.Name
                          };

                //排序
                qry = QWF.Framework.Dynamic.QueryableHelper.DataSorting(qry, pageSort, pageOrderby);

                var total = qry.Count();
                qry = QWF.Framework.Dynamic.QueryableHelper.DataPaging(qry, pageIndex, pageSize);

                var rows = from a in qry.ToList()
                           select new
                           {
                               a.ListType,
                               a.FormCode,
                               a.FormName,
                               a.SortId,
                               a.Id,
                               CreateTime = a.CreateTime.SafeConvert().ToTimeStrDefault(),

                           };

                var result = new { total = total, rows = rows };
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));

            }
        }

        public ActionResult SaveFormSetting()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();
            var listType = this.Request["formInListType"].SafeConvert().ToStr();
            var formCode = this.Request["formCode"].SafeConvert().ToStr();
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();

            if (listType.Length == 0)
                throw new UIValidateException("所属列表为null");

            if (formCode.Length == 0)
                throw new UIValidateException("请选择所属表单");


            using (var db = DbAccess.DbCRMContext.Create())
            {
                var maxSortId = 0;

                if (db.T_QCRM_ListInForm.Where(w => w.ListType == listType && w.FormCode == formCode).Count() > 0)
                    throw new UIValidateException("表单已经存在关联，不能添加");

                var list = db.T_QCRM_ListInForm.Select(s => new { s.SortId, s.ListType }).Where(w => w.ListType == listType).ToList();
                if (list.Count() > 0)
                    maxSortId = list.Max(m => m.SortId) + 1;

                var dbModel = new DbAccess.T_QCRM_ListInForm();
                dbModel.ListType = listType;
                dbModel.FormCode = formCode;
                dbModel.CreateTime = DateTime.Now;
                dbModel.CreateUser = curUser.CurrentUserCode;
                dbModel.SortId = maxSortId;

                db.T_QCRM_ListInForm.Add(dbModel);
                db.SaveChanges();

            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        public ActionResult DeleteFormSetting()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();

            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            var listType = this.Request["listType"].SafeConvert().ToStr();
            var formCode = this.Request["formCode"].SafeConvert().ToStr();

            if (listType.Length == 0)
                throw new UIValidateException("关键字段为null:listtype");
            if (formCode.Length == 0)
                throw new UIValidateException("关键字段为null:formCode");

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var dbModel = db.T_QCRM_ListInForm.Where(w => w.ListType == listType && w.FormCode == formCode).FirstOrDefault();
                db.T_QCRM_ListInForm.Remove(dbModel);
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
                    var dbModel = db.T_QCRM_ListInForm.Where(w => w.Id == d.Key).FirstOrDefault();

                    if (dbModel != null)
                        dbModel.SortId = d.Value;



                }
                db.SaveChanges();
            }


            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }
    }
}