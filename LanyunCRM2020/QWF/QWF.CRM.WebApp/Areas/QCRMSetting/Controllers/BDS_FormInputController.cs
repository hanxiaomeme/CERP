using QWF.Framework.ExtendUtils;
using QWF.Framework.GlobalException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QWF.CRM.WebApp.Areas.QCRMSetting.Controllers
{
    public class BDS_FormInputController : Controller
    {
        // GET: QCRMSetting/BDS_FormInput
        public ActionResult Index()
        {
            using (var db = DbAccess.DbCRMContext.Create())
            {
                var formList = db.T_QCRM_Form.AsNoTracking().OrderBy(o=>o.Name).Select(s => new QWF.Framework.Web.BaseItemKeyValue { Value = s.Name, Key = s.Code }).ToList();
                var tableList = db.T_QCRM_Tables.AsNoTracking().Where(w => w.Deleted == 0).OrderBy(o=>o.Name).ToList();
                var inputTypeList = QWF.Framework.MainServices.CreateWebAppServices.GetConfigServices().GetNodeItemsByCode("qwf.qcrm.inputtype");
                var defaultTypeList = QWF.Framework.MainServices.CreateWebAppServices.GetConfigServices().GetNodeItemsByCode("qwf.qcrm.defaultValueType");
                var sysCodeList = db.T_QWF_Seq.AsNoTracking().ToList();

                ViewBag.FormList = formList;
                ViewBag.TableList = tableList;
                ViewBag.InputTypeList = inputTypeList;
                ViewBag.DefaultTypeList = defaultTypeList;
                ViewBag.SysCodeList = sysCodeList;
                ViewBag.DictionaryList = db.T_QCRM_Dictionary.Where(w => w.ParentId == 0).Select(s => new QWF.Framework.Web.BaseItemKeyValue { Value = s.ItemName, Key = s.Code }).ToList();
            }

            return View();
        }

        public ActionResult GetFieldList()
        {
            var formCode = this.Request["formCode"].SafeConvert().ToStr();

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var form = db.T_QCRM_Form.Where(w => w.Code == formCode).FirstOrDefault();
                if (form == null)
                    throw new UIValidateException("表单信息为空,表单代码【{0}】。",form.Code);

                var qry = db.T_QCRM_Fields.Where(w => w.TableCode == form.MainTable && w.Deleted == 0 && w.IsVirtual == 0);

                var result = qry.Select(s => new { id = s.Code, name = s.Name }).ToList();

                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
            }

        }

        public ActionResult GetList()
        {
            var formCode = this.Request["qryFormCode"].SafeConvert().ToStr();
            var name = this.Request["qryName"].SafeConvert().ToStr();

            int pageSize = this.Request["rows"].SafeConvert().ToInt32(30);
            int pageIndex = this.Request["page"].SafeConvert().ToInt32(1);
            var pageSort = this.Request["sort"].SafeConvert().ToStr("SortId"); //排序字段 
            var pageOrderby = this.Request["orderby"].SafeConvert().ToStr("asc");// 升序或降序

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var qry = from a in db.T_QCRM_Form
                          join b in db.T_QCRM_FormInput on a.Code equals b.FormCode
                          join c in db.T_QCRM_Fields on new { TableCode = b.TableCode, FieldCode = b.FieldCode } equals new { TableCode = c.TableCode, FieldCode = c.Code }
                          select new
                          {
                              b.Id,
                              b.SortId,
                              FormName = a.Name,
                              b.TableCode,
                              b.FieldCode,
                              b.FormCode,
                              b.Name,
                              b.InputName,
                              b.InputType,
                              c.IsNotNull,
                              c.OnlyKey,
                              b.DefaultValue,
                              b.DefaultValueType,
                              b.CreateTime,
                              b.UpdateTime,
                              c.FieldType,
                              b.CssWidth,
                              b.CssHeight,
                              b.InputDesc

                          };
                //排序
                qry = QWF.Framework.Dynamic.QueryableHelper.DataSorting(qry, pageSort, pageOrderby);
                //过滤
                if(formCode.Length > 0 )
                {
                    qry = qry.Where(w => w.FormCode == formCode);
                }
                if (name.Length > 0)
                {
                    qry = qry.Where(w => w.Name.Contains(name));
                }
                var total = qry.Count();
                qry = QWF.Framework.Dynamic.QueryableHelper.DataPaging(qry, pageIndex, pageSize);

                // 获取字典
                var inputTypes = QWF.Framework.MainServices.CreateWebAppServices.GetConfigServices().GetNodeItemsByCode("qwf.qcrm.inputtype");
                var fieldTypes = QWF.Framework.MainServices.CreateWebAppServices.GetConfigServices().GetNodeItemsByCode("qwf.qcrm.fieldtype");
                var defaultTypes = QWF.Framework.MainServices.CreateWebAppServices.GetConfigServices().GetNodeItemsByCode("qwf.qcrm.defaultValueType");

                var rows = from a in qry.ToList()
                           join b in inputTypes on a.InputType equals b.Value
                           join c in fieldTypes on a.FieldType equals c.Value
                           join d in defaultTypes on a.DefaultValueType equals d.Value into dd
                           from e in dd.DefaultIfEmpty()
                           select new
                           {
                               a.Id,
                               a.TableCode,
                               a.FieldCode,
                               a.FormName,
                               a.FormCode,
                               a.Name,
                               a.InputName,
                               a.InputType,
                               a.FieldType,
                               InputTypeName = b.Name,
                               FieldTypeName = c.Name,
                               a.IsNotNull,
                               IsNotNullName = a.IsNotNull == 1 ? "√" : "",
                               a.OnlyKey,
                               OnlyKeyName = a.OnlyKey == 1 ? "√" : "",
                               a.DefaultValue,
                               a.DefaultValueType,
                               a.CssWidth,
                               a.CssHeight,
                               a.InputDesc,
                               DefaultValueTypeName = e == null ? "" : e.Name,
                               CreateTime = a.CreateTime.SafeConvert().ToTimeStrDefault(),
                               UpdateTime = a.UpdateTime.SafeConvert().ToTimeStrDefault()
                           };

                var result = new { total = total, rows = rows };
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));

            }
        }

        public ActionResult Save()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();

            var id = this.Request["id"].SafeConvert().ToInt32(0);
            var formCode = this.Request["formCode"].SafeConvert().ToStr();
            var fieldCode = this.Request["fieldCode"].SafeConvert().ToStr();
            var name = this.Request["name"].SafeConvert().ToStr();
            var inputType = this.Request["inputType"].SafeConvert().ToStr();
            var defaultValueType = this.Request["defaultValueType"].SafeConvert().ToStr();
            var defaultValue = this.Request["defaultValue"].SafeConvert().ToStr();
            var sysCode = this.Request["sysCode"].SafeConvert().ToStr();
            var cssWidth = this.Request["cssWidth"].SafeConvert().ToInt32(0);
            var cssHeight = this.Request["cssHeight"].SafeConvert().ToInt32(0);
            var inputDesc = this.Request["inputDesc"].SafeConvert().ToStr();


            if (formCode.Length == 0)
                throw new UIValidateException("所属表单不能为空填。");
            if (fieldCode.Length == 0)
                throw new UIValidateException("所属字段不能为空填。");
            if (inputType.Length == 0)
                throw new UIValidateException("表单类型不能空填。");
            if (inputType == "system" && defaultValueType.Length == 0)
                throw new UIValidateException("默认值类型不能为空填。");

            if (defaultValueType == "request" && defaultValue.Length == 0)
                throw new UIValidateException("默认值请填写客户端参数名称。");

            if (defaultValueType == "sys_value" && defaultValue.Length == 0)
                throw new UIValidateException("默认值能为空填。");

            if (cssWidth == 0)
                cssWidth = (inputType == "checkbox" || inputType == "radio") ? 30 : 300; //单选or复选默认30，其它默认300

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var form = db.T_QCRM_Form.Where(w => w.Code == formCode).FirstOrDefault();
                if (form == null)
                    throw new UIValidateException("表单所属表没有找到表单代码CODE=【{0}】。", formCode);

                if (id == 0)
                {
                    if (db.T_QCRM_FormInput.Where(w => w.FormCode == formCode && w.TableCode == form.MainTable && w.FieldCode == fieldCode).Count() > 0)
                        throw new UIValidateException("已经配置了该表单【{0}】数据项，请重新选择。", formCode);

                    var dbModel = new DbAccess.T_QCRM_FormInput();
                    var maxSortId = 0;
                    if (inputType != "system")
                    {
                        maxSortId = db.T_QCRM_FormInput.Where(w => w.FormCode == formCode).ToList().Max(m => m.SortId) + 1;
                    }
                    dbModel.Name = name;
                    dbModel.FormCode = formCode;
                    dbModel.TableCode = form.MainTable;
                    dbModel.FieldCode = fieldCode;
                    dbModel.InputName = form.MainTable + "_" + fieldCode;
                    dbModel.CreateTime = DateTime.Now;
                    dbModel.CreateUser = curUser.CurrentUserCode;
                    dbModel.SortId = maxSortId;
                    dbModel.InputType = inputType;
                    dbModel.DefaultValueType = defaultValueType;
                    dbModel.CssHeight = cssHeight;
                    dbModel.CssWidth = cssWidth;
                    dbModel.InputDesc = inputDesc;

                    if (defaultValueType != "sys_value" && defaultValueType != "request")
                    {
                        dbModel.DefaultValue = string.Empty;
                    }
                    else
                    {
                        dbModel.DefaultValue = defaultValueType == "sys_code" ? sysCode : defaultValue;
                    }

                    db.T_QCRM_FormInput.Add(dbModel);

                }
                else
                {
                    //
                    var dbModel = db.T_QCRM_FormInput.Where(w => w.Id == id).FirstOrDefault();
                    if (dbModel == null)
                        throw new UIValidateException("表单数据项不存在 ID=【{0}】。", id);

                    dbModel.Name = name;
                    dbModel.FormCode = formCode;
                    dbModel.TableCode = form.MainTable;
                    dbModel.FieldCode = fieldCode;
                    dbModel.InputName = form.MainTable + "_" + fieldCode;
                    dbModel.UpdateTime = DateTime.Now;
                    dbModel.UpdateUser = curUser.CurrentUserCode;
                    dbModel.SortId = inputType == "system" ? 0 : dbModel.SortId;
                    dbModel.InputType = inputType;
                    dbModel.DefaultValueType = defaultValueType;
                    dbModel.CssHeight = cssHeight;
                    dbModel.CssWidth = cssWidth;
                    dbModel.InputDesc = inputDesc;

                    if (defaultValueType != "sys_value" && defaultValueType != "request")
                    {
                        dbModel.DefaultValue = string.Empty;
                    }
                    else
                    {
                        dbModel.DefaultValue = defaultValueType == "sys_code" ? sysCode : defaultValue;
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
            var id = this.Request["Id"].SafeConvert().ToInt32(0);

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var dbModel = db.T_QCRM_FormInput.Where(w => w.Id == id).FirstOrDefault();
                if (dbModel != null)
                {
                    db.T_QCRM_FormInput.Remove(dbModel);
                    //记录操作日志。
                    QWF.Framework.MainServices.CreateWebAppServices.GetUserActionLogServices().
                        WriterActionLog("表单数据项删除", Framework.Services.SvrModels.SverUserActionLogType.Delete, null, new { 表 = dbModel.TableCode, 字段 = dbModel.FieldCode, 表单名称 = dbModel.Name });

                }


                db.SaveChanges();
            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        public ActionResult GetInputItemList()
        {
            var formInputId = this.Request["formInputId"].SafeConvert().ToInt32(0);

            int pageSize = this.Request["rows"].SafeConvert().ToInt32(30);
            int pageIndex = this.Request["page"].SafeConvert().ToInt32(1);
            var pageSort = this.Request["sort"].SafeConvert().ToStr("ItemSort"); //排序字段 
            var pageOrderby = this.Request["orderby"].SafeConvert().ToStr("asc");// 升序或降序


            using (var db = DbAccess.DbCRMContext.Create())
            {
                var formInput = db.T_QCRM_FormInput.Where(w => w.Id == formInputId).FirstOrDefault();

                if (formInput == null)
                    throw new UIValidateException("表单项不存在ID={0}", formInputId);

                DbAccess.T_QCRM_Dictionary dictionary = null;

                if (!string.IsNullOrWhiteSpace(formInput.DictionaryCode))
                    dictionary = db.T_QCRM_Dictionary.Where(w => w.Code == formInput.DictionaryCode).FirstOrDefault();

                if (dictionary != null)
                {
                    if (dictionary.DataSource == 0)
                    {
                        //固定数据
                        #region EF 查询
                        var qry = db.T_QCRM_Dictionary.Where(w => w.ParentId == dictionary.Id && w.Hide == 0).Select(s => new
                        {
                            s.Id,
                            s.Code,
                            s.ItemName,
                            s.ItemValue,
                            s.ItemSort
                        });
                        //排序
                        qry = QWF.Framework.Dynamic.QueryableHelper.DataSorting(qry, pageSort, pageOrderby);
                        var total = qry.Count();
                        qry = QWF.Framework.Dynamic.QueryableHelper.DataPaging(qry, pageIndex, pageSize);

                        // 获取字典
                        var rows = qry.ToList().Select(s => new
                        {
                            s.Id,
                            DictionaryCode = s.Code,
                            DefaultItemName = formInput.SelectItemValue == s.ItemValue ? "√" : "",
                            s.ItemName,
                            s.ItemValue
                        });
                        var result = new { total = total, rows = rows };
                        return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));

                        #endregion
                    }
                    else
                    {
                        var fields = string.Format(" Id,'{0}' DictionaryCode,DicName as ItemName,DicValue as ItemValue", formInput.DictionaryCode);
                        var total = 0;
                        var ado = new ADO.CRMDatabase();
                        var dt = ado.GetPagedList(fields, dictionary.ViewName, "1=1", "SortId", pageIndex, pageSize, true, ref total).Tables[0];
                        var result = new { total = total, rows = dt };
                        var json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.None, new Newtonsoft.Json.Converters.DataTableConverter());

                        return this.Content(json);
                    }
                }

                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(new { total = 0, rows = new object { } }));

            }
        }

        public ActionResult SaveInputItem()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();

            var formInputId = this.Request["formInputId"].SafeConvert().ToInt32(0);
            var dictionaryCode = this.Request["dictionaryCode"].SafeConvert().ToStr();

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var dbModel = db.T_QCRM_FormInput.Where(w => w.Id == formInputId).FirstOrDefault();
                if (dbModel == null)
                    throw new UIValidateException("表单项数据不存在 ID=【{0}】，无法保存。", formInputId);

                dbModel.DictionaryCode = dictionaryCode;
                dbModel.UpdateTime = DateTime.Now;
                dbModel.UpdateUser = curUser.CurrentUserCode;

                db.SaveChanges();
            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));

        }

        public ActionResult SetDefaultIntpuItem()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();

            var id = this.Request["id"].SafeConvert().ToInt32(0);
            var itemValue = this.Request["itemValue"].SafeConvert().ToStr();

            if (id == 0)
                throw new UIValidateException("ID=0");

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var dbModel = db.T_QCRM_FormInput.Where(w => w.Id == id).FirstOrDefault();
                if (dbModel == null)
                    throw new UIValidateException("表单项数据不存在ID=【{0}】", id);

                dbModel.SelectItemValue = itemValue;

                db.SaveChanges();
            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        public ActionResult CopyInputItems()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();

            var fromInputCode = this.Request["fromInputCode"].SafeConvert().ToStr();
            var toInputCode = this.Request["toInputCode"].SafeConvert().ToStr();

            if (fromInputCode.Length == 0 || toInputCode.Length == 0)
                throw new UIValidateException("请选择需要复制的表单数据。");
            if (fromInputCode == toInputCode)
                throw new UIValidateException("源表单“需要复制“和“复制到”表单不能相同。");
            using (var db = DbAccess.DbCRMContext.Create())
            {
                var dbModelToInput = db.T_QCRM_Form.Where(w => w.Code == toInputCode).FirstOrDefault();
                if (dbModelToInput == null)
                    throw new UIValidateException("“复制到”表单不存在。");

                //查找表主键，
                var pkInfo = (from a in db.T_QCRM_Form
                              join b in db.T_QCRM_Tables on a.MainTable equals b.Code
                              join c in db.T_QCRM_Fields on b.Code equals c.TableCode
                              where c.PK == 1
                              select new { c.TableCode, FileCode = c.Code }).ToList().FirstOrDefault();

                db.T_QCRM_FormInput.Where(w => w.FormCode == fromInputCode).ToList().ForEach(item =>
                {

                    var now = DateTime.Now;
                    var dbModel = db.T_QCRM_FormInput.Where(w => w.FormCode == toInputCode && w.TableCode == item.TableCode && w.FieldCode == item.FieldCode).FirstOrDefault();
                    var isAdd = dbModel == null ? true : false;//  //新增 or 编辑

                    if (isAdd)
                    {
                        dbModel = new DbAccess.T_QCRM_FormInput();
                        dbModel.CreateTime = now;
                        dbModel.CreateUser = curUser.CurrentUserCode;
                    }
                    else
                    {
                        dbModel.UpdateTime = now;
                        dbModel.UpdateUser = curUser.CurrentUserCode;
                    }

                    dbModel.FormCode = toInputCode;
                    dbModel.Name = item.Name;
                    dbModel.TableCode = item.TableCode;
                    dbModel.FieldCode = item.FieldCode;
                    dbModel.InputName = item.InputName;
                    dbModel.SortId = item.SortId;
                    dbModel.InputType = item.InputType;
                    dbModel.DefaultValueType = item.DefaultValueType;
                    dbModel.DefaultValue = item.DefaultValue;
                    dbModel.DictionaryCode = item.DictionaryCode;
                    dbModel.CssHeight = item.CssHeight;
                    dbModel.CssWidth = item.CssWidth;

                    if (isAdd)
                    {
                        if (pkInfo.TableCode != item.TableCode || pkInfo.FileCode != item.FieldCode)
                        {
                            //当为编辑状态则不写入PK
                            db.T_QCRM_FormInput.Add(dbModel);
                        }
                    }

                });

                db.SaveChanges();
            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }



        public ActionResult Sort()
        {
            var dic = QWF.Framework.Web.QWFRequest.GetSortDictionary();
            var result = QWF.Framework.Web.ResultWebData.Default();
            var formData = Request["id"].SafeConvert().ToInt32(0);
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            //排序
            using (var db = DbAccess.DbCRMContext.Create())
            {
                foreach (var d in dic)
                {
                    var dbModel = db.T_QCRM_FormInput.Where(w => w.Id == d.Key).FirstOrDefault();
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