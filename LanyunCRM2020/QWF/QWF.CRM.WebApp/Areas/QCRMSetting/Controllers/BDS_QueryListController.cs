using QWF.Framework.ExtendUtils;
using QWF.Framework.GlobalException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QWF.CRM.WebApp.Areas.QCRMSetting.Controllers
{
    public class BDS_QueryListController : Controller
    {
        // GET: QCRMSetting/BDS_QueryList
        public ActionResult Index()
        {
            using (var db = DbAccess.DbCRMContext.Create())
            {
                var listTypes = db.T_QCRM_ListType.Select(s => new QWF.Framework.Web.BaseItemKeyValue { Key = s.ListType, Value = s.TypeName }).ToList();
                var tableList = db.T_QCRM_Tables.AsNoTracking().Where(w => w.Deleted == 0).ToList();

                ViewBag.TableList = tableList;
                ViewBag.ListTypes = listTypes;
            }

            return View();
        }

        public ActionResult GetList()
        {

            var qryListType = this.Request["qryListType"].SafeConvert().ToStr();
            var qryTitleName = this.Request["qryTitleName"].SafeConvert().ToStr();

            int pageSize = this.Request["rows"].SafeConvert().ToInt32(30);


            using (var db = DbAccess.DbCRMContext.Create())
            {
                var qry = from a in db.T_QCRM_QueryList
                          join b in db.T_QCRM_ListType on a.ListType equals b.ListType
                          join c in db.T_QCRM_Tables on a.TableCode equals c.Code
                          where c.Deleted == 0
                          select new
                          {
                              a.Id,
                              b.TypeName,
                              a.ListType,
                              a.TableCode,
                              TableName = c.Name,
                              a.FieldCode,
                              a.TitleName,
                              a.StyleCss,
                              a.FieldFormatter,
                              a.FieldType, //
                              a.CreateTime,
                              a.UpdateTime,
                              a.StyleWidth,
                              a.Checkbox,
                              a.SortId,
                              a.Hide,
                              a.FormatterType,
                              a.Sortable,
                              a.IsUserField
                          };
                //过滤

                qry = qry.Where(w => w.ListType == qryListType);

                if (qryTitleName.Length > 0)
                {
                    qry = qry.Where(w => w.TitleName.Contains(qryTitleName));

                }

                var total = qry.Count();
                var fieldTypes = QWF.Framework.MainServices.CreateWebAppServices.GetConfigServices().GetNodeItemsByCode("qwf.qcrm.fieldtype");
                var formatter = QWF.Framework.MainServices.CreateWebAppServices.GetConfigServices().GetNodeItemsByCode("qwf.qcrm.fomattertype");

                var rows = from a in qry.ToList()
                           join b in fieldTypes on a.FieldType equals b.Value
                           join fmt in formatter on a.FormatterType equals fmt.Value into cc
                           from c in cc.DefaultIfEmpty()
                           select new
                           {
                               a.Id,
                               a.SortId,
                               a.ListType,
                               a.TypeName,
                               a.TableCode,
                               a.TableName,
                               a.FieldCode,
                               a.TitleName,
                               a.StyleWidth,
                               a.StyleCss,
                               a.FormatterType,
                               a.FieldFormatter,
                               a.FieldType,
                               a.Checkbox,
                               CheckboxName = a.Checkbox == 1 ? "√" : "",
                               a.Hide,
                               HideName = a.Hide == 1 ? "√" : "",
                               a.Sortable,
                               SortableName = a.Sortable == 1 ? "√" : "",
                               a.IsUserField,
                               IsUserFieldName = a.IsUserField == 1 ? "√" : "",
                               FieldTypeName = b.Name,
                               FormatterTypeName = c == null ? "" : c.Name,
                               CreateTime = a.CreateTime.SafeConvert().ToTimeStrDefault(),
                               UpdateTime = a.UpdateTime.SafeConvert().ToTimeStrDefault()
                           };

                rows = rows.OrderBy(o => o.SortId).ToList().OrderBy(o => o.Hide).ToList();

                var result = new { total = total, rows = rows };

                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));

            }
        }

        public ActionResult Save()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();

            var id = Request["id"].SafeConvert().ToInt32(0);
            var listType = Request["listType"].SafeConvert().ToStr();
            var tableCode = Request["tableCode"].SafeConvert().ToStr();
            var fieldCode = Request["fieldCode"].SafeConvert().ToStr();
            var titleName = Request["titleName"].SafeConvert().ToStr();
            var formatterType = Request["formatterType"].SafeConvert().ToStr();
            var fieldFormatter = Request["fieldFormatter"].SafeConvert().ToStr();
            var contentLength = Request["contentLength"].SafeConvert().ToInt32(0);
            var styleCss = Request["styleCss"].SafeConvert().ToStr();
            var styleWidth = Request["styleWidth"].SafeConvert().ToInt32(100);
            var hide = Request["hide"].SafeConvert().ToBool();
            var sortable = Request["sortable"].SafeConvert().ToBool();
            var isUserField = Request["isUserField"].SafeConvert().ToBool();

            if (id == 0 && listType.Length == 0)
                throw new UIValidateException("请选择所属查询列表。");
            if (tableCode.Length == 0)
                throw new UIValidateException("请选择所属的表。");
            if (fieldCode.Length == 0)
                throw new UIValidateException("请选择所属表字段。");
            if (titleName.Length == 0)
                throw new UIValidateException("列名称不能为空。");

            using (var db = DbAccess.DbCRMContext.Create())
            {
                //查询字段类型
                var fieldModel = db.T_QCRM_Fields.Where(w => w.TableCode == tableCode && w.Code == fieldCode && w.Deleted == 0).FirstOrDefault();

                if (formatterType == "100" && fieldModel.FieldType != "datetime")
                    throw new UIValidateException("当字段类型为日期类型，才能格式化成日前格式。");

                if (formatterType == "102" && (fieldModel.FieldType != "decimal" || fieldModel.FieldType != "int"))
                    throw new UIValidateException("当字段类型为数字类型，才能格式化成货币格式。");

                if (formatterType == "103" && (fieldModel.FieldType != "decimal" || fieldModel.FieldType != "int"))
                    throw new UIValidateException("当字段类型为数字类型，才能格式化成小数格式。");

                if (formatterType == "105" && (fieldModel.FieldType != "decimal" || fieldModel.FieldType != "int"))
                    throw new UIValidateException("当字段类型为数字类型，才能格式化成百分比格式。");

                //检查字段是否在表关系中存在
                var query = db.T_QCRM_ListType.Where(w => w.ListType == listType).FirstOrDefault();
                if (query == null)
                    throw new UIValidateException("查询列表【{0}】不存在。", listType);

                var colName = tableCode + "_" + fieldCode;
                if (!ADO.ADO_Helper.Create().CheckedColumsExists(query.TableRelation, colName))
                    throw new UIValidateException("在查询列表【{0}】中不存在该字段,如需加入，请联系技术人员处理，字段名=【{1}】。", query.TypeName, colName);

                if (id == 0)
                {
                    if (db.T_QCRM_QueryList.Where(w => w.ListType == listType && w.TableCode == tableCode && w.FieldCode == fieldCode).Count() > 0)
                        throw new UIValidateException("列表页中已经存在了该字段，请更换所属字段选项。");

                    var maxSortId = db.T_QCRM_QueryList.Where(w => w.ListType == listType).Select(s => s.SortId).ToList().DefaultIfEmpty().Max();

                    var dbModel = new DbAccess.T_QCRM_QueryList();

                    dbModel.ListType = listType;
                    dbModel.TableCode = tableCode;
                    dbModel.FieldCode = fieldCode;
                    dbModel.FieldType = fieldModel.FieldType;
                    dbModel.FieldFormatter = fieldFormatter;
                    dbModel.FormatterType = formatterType;
                    dbModel.StyleWidth = styleWidth;
                    dbModel.TitleName = titleName;
                    dbModel.StyleCss = styleCss;
                    dbModel.Checkbox = fieldModel.PK;
                    dbModel.CreateUser = curUser.CurrentUserCode;
                    dbModel.CreateTime = DateTime.Now;
                    dbModel.SortId = fieldModel.PK == 1 ? 0 : maxSortId;
                    dbModel.Hide = hide ? 1 : 0;
                    dbModel.Sortable = sortable ? 1 : 0;
                    dbModel.IsUserField = isUserField ? 1 : 0;

                    if (dbModel.Hide == 1)
                        dbModel.SortId = 0;

                    db.T_QCRM_QueryList.Add(dbModel);
                }
                else
                {
                    //编辑
                    var dbModel = db.T_QCRM_QueryList.Where(w => w.Id == id).FirstOrDefault();

                    if (dbModel == null)
                        throw new UIValidateException(string.Format("数据不存在，不能编辑数据，ID=【{0}】。", dbModel.Id));

                    if (db.T_QCRM_QueryList.Where(w => w.ListType == listType && w.TableCode == tableCode && w.FieldCode == fieldCode && w.Id != id).Count() > 0)
                        throw new UIValidateException("其它列表页中已经存在了该字段，请更换所属字段选项。");

                    dbModel.ListType = listType;
                    dbModel.TableCode = tableCode;
                    dbModel.FieldCode = fieldCode;
                    dbModel.FieldType = fieldModel.FieldType;
                    dbModel.FieldFormatter = fieldFormatter;
                    dbModel.FormatterType = formatterType;
                    dbModel.StyleWidth = styleWidth;
                    dbModel.TitleName = titleName;
                    dbModel.StyleCss = styleCss;
                    dbModel.Checkbox = fieldModel.PK;
                    dbModel.UpdateUser = curUser.CurrentUserCode;
                    dbModel.UpdateTime = DateTime.Now;
                    dbModel.Hide = hide ? 1 : 0;
                    dbModel.Sortable = sortable ? 1 : 0;
                    dbModel.IsUserField = isUserField ? 1 : 0;

                    if (dbModel.Hide == 1)
                        dbModel.SortId = 0;
                }

                if (fieldModel.PK == 1)
                {
                    //主键项只能有一个
                    db.T_QCRM_QueryList.Where(w => w.ListType == listType).ToList().ForEach(item =>
                    {
                        if (item.TableCode == tableCode && item.FieldCode == fieldCode)
                        {
                            item.Checkbox = 1;
                        }
                        else
                        {
                            item.Checkbox = 0;
                        }

                    });
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
                var dbModel = db.T_QCRM_QueryList.Where(w => w.Id == id).FirstOrDefault();

                if (dbModel != null)
                {
                    //遍历移除快捷搜索字段
                    db.T_QCRM_QuickSreach.Where(w => w.QueryFieldId == id).ToList().ForEach(item =>
                    {
                        //遍历移除用户搜索字段配置
                        db.T_QCRM_QuickSreachUser.Where(w => w.SreachId == item.Id).ToList().ForEach(userItem =>
                        {
                            db.T_QCRM_QuickSreachUser.Remove(userItem);
                        });

                    });

                    //移除列表显示项
                    db.T_QCRM_QueryList.Remove(dbModel);

                    //写入操作日志
                    QWF.Framework.MainServices.CreateWebAppServices.GetUserActionLogServices().
                        WriterActionLog("查询列表字段管理删除", Framework.Services.SvrModels.SverUserActionLogType.Delete, null, new { 所属列表 = dbModel.ListType, 列名称 = dbModel.TitleName, 表 = dbModel.TableCode, 字段 = dbModel.FieldCode });

                }


                db.SaveChanges();
            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        public ActionResult GetFieldList()
        {
            var tableCode = this.Request["tableCode"].SafeConvert().ToStr();
            using (var db = DbAccess.DbCRMContext.Create())
            {
                var qry = db.T_QCRM_Fields.Where(w => w.TableCode == tableCode && w.Deleted == 0);
                var result = qry.Select(s => new { id = s.Code, name = s.Name, type = s.FieldType }).ToList();

                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
            }
        }

        public ActionResult Sort()
        {
            var dic = QWF.Framework.Web.QWFRequest.GetSortDictionary();
            //
            var result = QWF.Framework.Web.ResultWebData.Default();
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();

            //排序
            using (var db = DbAccess.DbCRMContext.Create())
            {
                foreach (var d in dic)
                {
                    var dbModel = db.T_QCRM_QueryList.Where(w => w.Id == d.Key).FirstOrDefault();

                    if (dbModel != null)
                    {
                        dbModel.SortId = d.Value;

                        if (dbModel.Hide == 1)
                            dbModel.SortId = 0;

                    }
                }

                db.SaveChanges();
            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

    }
}