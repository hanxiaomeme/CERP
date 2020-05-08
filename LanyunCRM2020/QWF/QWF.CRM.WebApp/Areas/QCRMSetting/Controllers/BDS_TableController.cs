using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QWF.Framework.ExtendUtils;
using QWF.Framework.GlobalException;

namespace QWF.CRM.WebApp.Areas.QCRMSetting.Controllers
{
    public class BDS_TableController : Controller
    {
        // GET: QCRMSetting/BDS_Table
        public ActionResult Index()
        {
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
                var qry = db.T_QCRM_Tables.Where(w => w.Deleted == 0);

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

                var rows = qry.ToList().Select(s => new
                {
                    s.Name,
                    s.Code,
                    s.Remarks,
                    s.DeleteType,
                    DeleteTypeName = s.DeleteType == 1 ? "√" : "",
                    s.DeleteField,
                    s.DeleteFlag,
                    CreateTime = s.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    UpdateTime = s.UpdateTime == null ? "" : s.UpdateTime.Value.ToString("yyyy-MM-dd HH:mm:ss")

                });

                var result = new { total = total, rows = rows };

                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));

            }
        }

        public ActionResult Save()
        {
            var id = this.Request["id"].SafeConvert().ToStr();
            var code = this.Request["code"].SafeConvert().ToStr();
            var name = this.Request["name"].SafeConvert().ToStr();
            var remaks = this.Request["remarks"].SafeConvert().ToStr();
            var result = QWF.Framework.Web.ResultWebData.Default();
            var create = this.Request["create"].SafeConvert().ToBool();
            var deleteType = this.Request["deleteType"].SafeConvert().ToInt32(0);
            var deleteField = this.Request["deleteField"].SafeConvert().ToStr();
            var deleteFlag = this.Request["deleteFlag"].SafeConvert().ToStr();

            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            using (var db = DbAccess.DbCRMContext.Create())
            {
                if (id.Length == 0 && code.Length == 0)
                    throw new UIValidateException("请填写表名。");

                if (name.Length == 0)
                    throw new UIValidateException("请填写描述。");

                if(deleteType == 1)
                {
                    if(deleteField.Length == 0 )
                        throw new UIValidateException("请填写字段名。");

                    if (deleteFlag.Length == 0)
                        throw new UIValidateException("请填写正常标识。");

                }

                if (id.Length == 0)
                {
                    if (!code.StrValidatorHelper().IsDbNameCode())
                        throw new UIValidateException("表名格式不正确,只能3-128位字母、数字或下划线组合，不能以数字开头。");
                
                    var ado = ADO.ADO_Helper.Create();
                    if ( create && ado.ExistsTable(code) )
                        throw new UIValidateException("表名【{0}】已经物理存在，请更换表名。", code);

                    //新增
                    var dbModel = db.T_QCRM_Tables.Where(w => w.Code == code && w.Deleted == 0).FirstOrDefault();
                    if (dbModel != null)
                        throw new UIValidateException("表名【{0}】已经存在，请更换表名。", code);

                    dbModel = new DbAccess.T_QCRM_Tables();
                    dbModel.Code = code;
                    dbModel.Name = name;
                    dbModel.Remarks = remaks;
                    dbModel.CreateUser = curUser.CurrentUserCode;
                    dbModel.CreateTime = DateTime.Now;
                    dbModel.DeleteField = deleteField;
                    dbModel.DeleteFlag = deleteFlag;
                    dbModel.DeleteType = deleteType;

                    db.T_QCRM_Tables.Add(dbModel);

                    //创建表
                    if (create)
                    {
                        ado.CreateTable(code);

                        //这里需要添加一个默认字段
                        var fieldModel = new DbAccess.T_QCRM_Fields();
                        fieldModel.TableCode = code;
                        fieldModel.Code = "Id";
                        fieldModel.Name = "ID";
                        fieldModel.Remarks = "创建表默认字段，主键 GUID";
                        fieldModel.FieldType = "text";
                        fieldModel.FieldTypeLength = 0;
                        fieldModel.CreateTime = DateTime.Now;
                        fieldModel.CreateUser = curUser.CurrentUserCode;
                        fieldModel.PK = 1;
                       


                        db.T_QCRM_Fields.Add(fieldModel);
                    }
                }
                else
                {
                    //编辑
                    var dbModel = db.T_QCRM_Tables.Where(w => w.Code == id && w.Deleted == 0).FirstOrDefault();
                    if (dbModel == null)
                        throw new UIValidateException("表名【{0}】的数据记录不存在。",code);

                    dbModel.Name = name;
                    dbModel.Remarks = remaks.Trim();
                    dbModel.UpdateUser = curUser.CurrentUserCode;
                    dbModel.UpdateTime = DateTime.Now;
                    dbModel.DeleteField = deleteField;
                    dbModel.DeleteFlag = deleteFlag;
                    dbModel.DeleteType = deleteType;
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
                throw new UIValidateException("表名为空");

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var dbModel = db.T_QCRM_Tables.Where(w => w.Code == code).FirstOrDefault();
                if(dbModel != null)
                {
                    dbModel.Deleted = 1;
                    dbModel.UpdateTime = DateTime.Now;
                    dbModel.UpdateUser = curUser.CurrentUserCode;
                }
                db.SaveChanges();
            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

    }
}