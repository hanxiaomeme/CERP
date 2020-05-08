using QWF.Framework.ExtendUtils;
using QWF.Framework.GlobalException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QWF.CRM.WebApp.Areas.QCRMSetting.Controllers
{
    public class BDS_FormController : Controller
    {
        // GET: QCRMSetting/BDS_Form
        public ActionResult Index()
        {
            using (var db = DbAccess.DbCRMContext.Create())
            {
                var tables = db.T_QCRM_Tables.Where(w => w.Deleted == 0).ToList();

                ViewBag.Tables = tables;
            }
              
            return View();
        }

        public ActionResult GetList()
        {

            var code = this.Request["qryCode"].SafeConvert().ToStr();
            var name = this.Request["qryName"].SafeConvert().ToStr();

            int pageSize = this.Request["rows"].SafeConvert().ToInt32(30);
            int pageIndex = this.Request["page"].SafeConvert().ToInt32(1);
            var pageSort = this.Request["sort"].SafeConvert().ToStr("CreateTime"); //排序字段 
            var pageOrderby = this.Request["orderby"].SafeConvert().ToStr("desc");// 升序或降序

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var qry = from a in db.T_QCRM_Form.AsNoTracking()
                          join b in db.T_QCRM_Tables.AsNoTracking() on a.MainTable equals b.Code
                          select new
                          {
                              a.Code,
                              a.Name,
                              a.MainTable,
                              MainTableName = b.Name,
                              a.ActionType,
                              a.ActionName,
                              a.ActionStyle,
                              a.WindowsWidth,
                              a.StyleColums,
                              a.ButtonStyle,
                              a.ButtonIcon,
                              a.Remarks,
                              a.CreateTime,
                              a.UpdateTime,
                              a.PlugInClass
                          };

                //排序
                qry = QWF.Framework.Dynamic.QueryableHelper.DataSorting(qry, pageSort, pageOrderby);

                //过滤
                if (code.Length > 0)
                {
                    qry = qry.Where(w => w.Code == code);
                }
                if (name.Length > 0)
                {
                    qry = qry.Where(w => w.Name.Contains(name));

                }

                var total = qry.Count();
                qry = QWF.Framework.Dynamic.QueryableHelper.DataPaging(qry, pageIndex, pageSize);

                var rows = from a in qry.ToList()
                           select new
                           {
                               a.Code,
                               a.Name,
                               a.MainTable,
                               a.MainTableName,
                               a.ActionType,
                               ActionTypeName = GetActionTypeName(a.ActionType), 
                               a.ActionName,
                               a.ActionStyle,
                               ActionStyleName = a.ActionStyle == 10 ? "弹窗" : "确认对话框",
                               a.StyleColums,
                               StyleColumsName = a.ActionStyle == 10 ? (a.StyleColums == 1 ? "单列" : "多列") : "", //只有弹窗才有意义
                               WindowsWidth = a.ActionStyle == 10 ? a.WindowsWidth.ToString() : "",
                               a.ButtonStyle,
                               a.ButtonIcon,
                               a.Remarks,
                               CreateTime = a.CreateTime.SafeConvert().ToTimeStrDefault(),
                               UpdateTime = a.UpdateTime.SafeConvert().ToTimeStrDefault(),
                               a.PlugInClass
                           };

                var result = new { total = total, rows = rows };
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
            }
        }

        public ActionResult Save()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();

            var id = this.Request["id"].SafeConvert().ToStr();
            var code = this.Request["code"].SafeConvert().ToStr();
            var name = this.Request["name"].SafeConvert().ToStr();
            var actionName = this.Request["actionName"].SafeConvert().ToStr();
            var actionStyle = this.Request["actionStyle"].SafeConvert().ToInt32(0);
            var actionType = this.Request["actionType"].SafeConvert().ToStr();
            var buttonIcon = this.Request["buttonIcon"].SafeConvert().ToStr();
            var buttonStyle = this.Request["buttonStyle"].SafeConvert().ToStr();
            var remaks = this.Request["remarks"].SafeConvert().ToStr();
            var styleColums = this.Request["styleColums"].SafeConvert().ToInt32(1);
            var windowsWidth = this.Request["windowsWidth"].SafeConvert().ToInt32(550);
            var mainTable = this.Request["mainTable"].SafeConvert().ToStr();
            var plugInClass = this.Request["plugInClass"].SafeConvert().ToStr();

            if (id.Length == 0 && code.Length == 0)
                throw new UIValidateException("表单代码不能空填。");
            if (name.Length == 0)
                throw new UIValidateException("表单名称不能空填。");
            if (actionName.Length == 0)
                throw new UIValidateException("事件名称不能空填。");
            if (actionType.Length == 0)
                throw new UIValidateException("事件类型不能为空填");
            if (actionStyle == 0)
                throw new UIValidateException("弹窗样式不能为空填。");

            var permission = QWF.CRM.Utils.PermissionUtils.Create();

            using (var db = DbAccess.DbCRMContext.Create())
            {
                if (id.Length == 0)
                {
                    if (mainTable.Length == 0)
                        throw new UIValidateException("请选择所属表。");

                    if (!code.StrValidatorHelper().IsLetterOrNumberCode())
                        throw new UIValidateException("表单代码格式不正确，只能是字母、数字或下划线组合。");


                    var dbModel = db.T_QCRM_Form.Where(w => w.Code == code).FirstOrDefault();
                    if (dbModel != null)
                        throw new UIValidateException("表单代码【{0}】已经存在，请更换代码。", code);

                    dbModel = new DbAccess.T_QCRM_Form();

                    dbModel.Code = code;
                    dbModel.Name = name;
                    dbModel.ActionType = actionType;
                    dbModel.ActionName = actionName;
                    dbModel.ActionStyle = actionStyle;
                    dbModel.StyleColums = styleColums;
                    dbModel.WindowsWidth = windowsWidth;
                    dbModel.ButtonStyle = buttonStyle;
                    dbModel.ButtonIcon = buttonIcon;
                    dbModel.Remarks = remaks;
                    dbModel.MainTable = mainTable;
                    dbModel.CreateUser = curUser.CurrentUserCode;
                    dbModel.CreateTime = DateTime.Now;

                    if(permission.IsAdministrator())
                    {
                        dbModel.PlugInClass = plugInClass;
                    }

                    db.T_QCRM_Form.Add(dbModel);
                }
                else
                {
                    //编辑
                    var dbModel = db.T_QCRM_Form.Where(w => w.Code == id).FirstOrDefault();
                    if (dbModel == null)
                        throw new UIValidateException("表单代码不存在，请检查数据【ID={0}】。", id);

                    dbModel.Name = name;
                    dbModel.ActionType = actionType;
                    dbModel.ActionName = actionName;
                    dbModel.ActionStyle = actionStyle;
                    dbModel.StyleColums = styleColums;
                    dbModel.WindowsWidth = windowsWidth;
                    dbModel.ButtonStyle = buttonStyle;
                    dbModel.ButtonIcon = buttonIcon;
                    dbModel.Remarks = remaks;
                    dbModel.UpdateUser = curUser.CurrentUserCode;
                    dbModel.UpdateTime = DateTime.Now;

                    if (permission.IsAdministrator())
                    {
                        dbModel.PlugInClass = plugInClass;
                    }

                }

                db.SaveChanges();
            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));

        }

        public ActionResult Delete()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();

            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            var code = this.Request["code"].SafeConvert().ToStr();

            if (code.Length == 0)
                throw new UIValidateException("表单编码为空。");

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var dbModel = db.T_QCRM_Form.Where(w => w.Code == code).FirstOrDefault();

                if (db.T_QCRM_FormInput.Where(w => w.FormCode == code).Count() > 0)
                    throw new UIValidateException("在【{0}】的表单下还存在表单关联数据项，不能删除。", dbModel.Name);

                if (db.T_QCRM_ListInForm.Where(w => w.FormCode == code).Count() > 0)
                    throw new UIValidateException("在【查询列表页配置】的菜单表单【{0}】有关联数据，不能删除。", dbModel.Name);

                //清除权限表
                db.T_QCRM_UserInForm.Where(w => w.FormCode == code).ToList().ForEach(item =>
                {
                    db.T_QCRM_UserInForm.Remove(item);
                });

                db.T_QCRM_Form.Remove(dbModel);

                db.SaveChanges();
            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        private string GetActionTypeName(string actionType)
        {
            if (actionType == "create")
                return "创建数据";
            if (actionType == "update")
                return "变更数据";
            if (actionType == "delete")
                return "删除数据";

            return string.Empty;
        }
    }
}