using QWF.Framework.ExtendUtils;
using QWF.Framework.GlobalException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QWF.CRM.WebApp.Areas.QCRMSetting.Controllers
{
    public class BDS_FieldsController : Controller
    {
        // GET: QCRMSetting/BDS_Fields
        public ActionResult Index()
        {
            ViewBag.FieldTypeItem = QWF.Framework.MainServices.CreateWebAppServices.GetConfigServices().GetNodeItemsByCode("qwf.qcrm.fieldtype");

            using (var db = DbAccess.DbCRMContext.Create())
            {
                ViewBag.Tables = db.T_QCRM_Tables.AsNoTracking().Where(w => w.Deleted == 0).ToList();
            }
            return View();
        }

        public ActionResult GetList()
        {

            var tableCode = this.Request["qryTableCode"].SafeConvert().ToStr();
            var key = this.Request["qryKey"].SafeConvert().ToStr();
            

            int pageSize = this.Request["rows"].SafeConvert().ToInt32(30);
            int pageIndex = this.Request["page"].SafeConvert().ToInt32(1);
            var pageSort = this.Request["sort"].SafeConvert().ToStr("CreateTime"); //排序字段 
            var pageOrderby = this.Request["orderby"].SafeConvert().ToStr("desc");// 升序或降序

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var qry = from a in db.T_QCRM_Tables
                          join b in db.T_QCRM_Fields on a.Code equals b.TableCode
                          where a.Deleted == 0 && b.Deleted == 0
                          select new
                          {
                              TableCode = a.Code,
                              TableName = a.Name,
                              b.PK,
                              b.Name,
                              b.Code,
                              b.FieldType,
                              b.FieldTypeLength,
                              b.Remarks,
                              b.CreateTime,
                              b.UpdateTime,
                              b.IsNotNull,
                              b.OnlyKey,
                              b.IsVirtual
                          };

                //排序
                qry = QWF.Framework.Dynamic.QueryableHelper.DataSorting(qry, pageSort, pageOrderby);

                //过滤
                if (tableCode.Length > 0)
                {
                    qry = qry.Where(w => w.TableCode == tableCode);
                }

                if (key.Length > 0)
                {
                    qry = qry.Where(w => w.Code.Contains(key) || w.Name.Contains(key));
                }
              
                var total = qry.Count();
                qry = QWF.Framework.Dynamic.QueryableHelper.DataPaging(qry, pageIndex, pageSize);

                // 获取字典
                var fieldTypeList = QWF.Framework.MainServices.CreateWebAppServices.GetConfigServices().GetNodeItemsByCode("qwf.qcrm.fieldtype");

                var rows = from a in qry.ToList()
                           join b in fieldTypeList on a.FieldType equals b.Value
                           select new
                           {
                               a.TableCode,
                               a.TableName,
                               a.Name,
                               a.Code,
                               a.FieldType,
                               a.FieldTypeLength,
                               a.Remarks,
                               a.PK,
                               PkName = a.PK == 1 ? "√" : "",
                               FullFieldCode = a.TableCode + "." + a.Code,
                               CreateTime = a.CreateTime.SafeConvert().ToTimeStrDefault(),
                               UpdateTime = a.UpdateTime == null ? "" : a.CreateTime.SafeConvert().ToTimeStrDefault(),
                               FieldTypeName = b.Name,
                               a.IsNotNull,
                               IsNotNullName = a.IsNotNull == 1 ? "√" : "",
                               a.OnlyKey,
                               OnlyKeyName = a.OnlyKey == 1 ? "√" : "",
                               a.IsVirtual,
                               IsVirtualName = a.IsVirtual == 1 ? "√" : "",
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
            var tableId = this.Request["tableId"].SafeConvert().ToStr();
            var tableCode = this.Request["tableCode"].SafeConvert().ToStr();
            var code = this.Request["code"].SafeConvert().ToStr();
            var name = this.Request["name"].SafeConvert().ToStr();
            var fieldType = this.Request["fieldType"].SafeConvert().ToStr();
            var fieldTypeLength = this.Request["fieldTypeLength"].SafeConvert().ToInt32(0);
            var remaks = this.Request["remarks"].SafeConvert().ToStr();
            var create = Request["create"].SafeConvert().ToBool();
            var edit = Request["edit"].SafeConvert().ToBool();
            var isNotNull = Request["isNotNull"].SafeConvert().ToBool();
            var onlyKey = Request["onlyKey"].SafeConvert().ToBool();
            var isVirtual = this.Request["isVirtual"].SafeConvert().ToBool();

            using (var db = DbAccess.DbCRMContext.Create())
            {
                if (tableId.Length == 0 && tableCode.Length == 0)
                    throw new UIValidateException("请选择所属表。");

                if (id.Length == 0 && code.Length == 0)
                    throw new UIValidateException("请填写字段名。");

                if (name.Length == 0)
                    throw new UIValidateException("请填写字段描述。");

                var ado = ADO.ADO_Helper.Create();

                if (id.Length == 0)
                {

                    if (!code.StrValidatorHelper().IsDbNameCode())
                        throw new UIValidateException("字段名格式不正确，只能是3-128位字母、数字或下划线组合，不能以数字开头。");

                    if (create && ado.ExistsField(code, name))
                        throw new QWF.Framework.GlobalException.UIValidateException("字段【{0}.{1}】已经物理存在，请更换名称。", tableCode, code);

                    var dbModel = db.T_QCRM_Fields.Where(w => w.TableCode == tableCode && w.Code == code && w.Deleted == 0).FirstOrDefault();
                    if (dbModel != null)
                        throw new UIValidateException("字段【{0}.{1}】已经存在，请换一个字段名！", tableCode, code);

                    dbModel = new DbAccess.T_QCRM_Fields();
                    dbModel.TableCode = tableCode;
                    dbModel.Code = code;
                    dbModel.Name = name;
                    dbModel.FieldType = fieldType;
                    dbModel.FieldTypeLength = fieldTypeLength;
                    dbModel.Remarks = remaks;
                    dbModel.CreateUser = curUser.CurrentUserCode;
                    dbModel.CreateTime = DateTime.Now;
                    dbModel.OnlyKey = onlyKey ? 1 : 0 ;
                    dbModel.IsNotNull = isNotNull ? 1 : 0;
                    dbModel.IsVirtual = isVirtual ? 1 : 0;

                    db.T_QCRM_Fields.Add(dbModel);

                    //创建字段
                    if (create&!isVirtual)
                    {
                        ado.CreateField(tableCode, code, fieldType, fieldTypeLength);
                    }
                }
                else
                {
                    //编辑
                    var dbModel = db.T_QCRM_Fields.Where(w => w.TableCode == tableId && w.Code == id && w.Deleted == 0).FirstOrDefault();
                    if (dbModel == null)
                        throw new UIValidateException("字段【{0}.{1}】的数据记录不存在！", tableId, id);

                    dbModel.Name = name;
                    dbModel.Remarks = remaks.Trim();
                    dbModel.FieldTypeLength = fieldTypeLength;
                    dbModel.UpdateUser = curUser.CurrentUserCode;
                    dbModel.UpdateTime = DateTime.Now;
                    dbModel.OnlyKey = onlyKey ? 1 : 0;
                    dbModel.IsNotNull = isNotNull ? 1 : 0;
                    dbModel.IsVirtual = isVirtual ? 1 : 0;

                    //编辑字段长度
                    var hidFieldType = this.Request["hidFieldType"].ToString();
                    if (edit && (hidFieldType == "text" || hidFieldType == "decimal"))
                    {
                        ado.AlterFieldLength(tableId, id, hidFieldType, fieldTypeLength);
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
            var tableCode = this.Request["tableCode"].SafeConvert().ToStr();
            if (code.Length == 0 || tableCode.Length == 0)
                throw new UIValidateException("表或字段为NULL");

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var dbModel = db.T_QCRM_Fields.Where(w => w.TableCode == tableCode && w.Code == code).FirstOrDefault();
                if (dbModel != null)
                {
                    dbModel.Deleted = 1;
                    dbModel.UpdateTime = DateTime.Now;
                    dbModel.UpdateUser = curUser.CurrentUserCode;
                }
                db.SaveChanges();
            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        public ActionResult SetPK()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();

            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            var code = this.Request["code"].SafeConvert().ToStr();
            var tableCode = this.Request["tableCode"].SafeConvert().ToStr();
            if (code.Length == 0 || tableCode.Length == 0)
                throw new UIValidateException("表或字段为NULL");

            using (var db = DbAccess.DbCRMContext.Create())
            {
                db.T_QCRM_Fields.Where(w => w.TableCode == tableCode).ToList().ForEach(item =>
                  {
                      item.PK = item.Code == code ? 1 : 0;
                      item.UpdateTime = DateTime.Now;
                      item.UpdateUser = curUser.CurrentUserCode;

                  });
                db.SaveChanges();
            }
            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

    }
}