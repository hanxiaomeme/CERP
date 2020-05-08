using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QWF.Framework.ExtendUtils;
using QWF.Framework.GlobalException;

namespace QWF.CRM.WebApp.Areas.QCRMSetting.Controllers
{
    public class BDS_UserInFormController : Controller
    {
        // GET: QCRMSetting/BDS_UserInForm
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetRoleList()
        {
            using (var db = DbAccess.DbCRMContext.Create())
            {
                var qry = db.T_QWF_Role.Where(w => w.IsDelete == 0).Select(s => new
                {
                    s.RoleId,
                    s.RoleCode,
                    s.RoleName
                });

                var data = new { total = qry.Count(), rows = qry.ToList() };

                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(data));
            }
        }

        public ActionResult GetFormList()
        {
            using (var db = DbAccess.DbCRMContext.Create())
            {
                var qry = db.T_QCRM_Form.AsNoTracking().Select(s => new
                {
                    s.Name,
                    s.Code,
                    s.ActionName
                }).OrderBy(o=>o.Name);

                var data = new { total = qry.Count(), rows = qry.ToList() };

                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(data));
            }
        }

        public ActionResult RoleInFormCodes()
        {
            var roleCode = this.Request["roleCode"].SafeConvert().ToStr();
            var result = QWF.Framework.Web.ResultWebData.Default();

            if (roleCode.Length == 0)
                throw new UIValidateException("请选择角色。");

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var rows = db.T_QCRM_UserInForm.Where(w => w.UserType == "role" && w.TypeCode == roleCode).Select(s => new
                {
                    s.Id,
                    s.FormCode
                }).ToList() ;

                result.Data = new  { rows = rows};

                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
            }
        }

        public ActionResult SaveInRoleForm()
        {
            var formCodes = this.Request["formCodes"].StringHelper().SplitToArray();
            var roleCode = this.Request["roleCode"].SafeConvert().ToStr();

            var result = QWF.Framework.Web.ResultWebData.Default();
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
           
            //幂等操作
            using (var db = DbAccess.DbCRMContext.Create())
            {
                //删除不需要的role
                db.T_QCRM_UserInForm.Where(w => !formCodes.Contains(w.FormCode) && w.TypeCode == roleCode && w.UserType == "role").
                    ToList().ForEach(item=> {
                        db.T_QCRM_UserInForm.Remove(item);
                    });

                // 
                foreach (var formCode in formCodes)
                {
                    if( db.T_QCRM_UserInForm.Where(w=>w.UserType=="role" &&w.TypeCode==roleCode && w.FormCode == formCode).Count()==0)
                    {
                        //add
                        var dbModel = new DbAccess.T_QCRM_UserInForm();

                        dbModel.FormCode = formCode;
                        dbModel.TypeCode = roleCode;
                        dbModel.UserType = "role";
                        dbModel.CreateTime = DateTime.Now;
                        dbModel.CreateUser = curUser.CurrentUserCode;

                        db.T_QCRM_UserInForm.Add(dbModel);
                    }
                }

                db.SaveChanges();
            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }


    }
}