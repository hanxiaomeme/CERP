using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QWF.Framework.ExtendUtils;

namespace QWF.Framework.Sites.Areas.QWebFramework.Controllers
{
    public class RoleInResourceController : Controller
    {
        // GET: QWebFramework/RoleInResource
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetRoleList()
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var rows = db.T_QWF_Role.AsNoTracking().Where(w => w.IsDelete == 0).ToList().Select(o => new
                {
                    o.RoleId,
                    o.RoleName
                }).ToList();

                var data = new { total = rows.Count, rows = rows };
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(rows));
            }
        }

        public ActionResult GetRoleInResource()
        {
            var roleId = this.Request["roleId"].SafeConvert().ToInt32(0);

            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var qry = from a in db.T_QWF_RoleInResource.AsNoTracking()
                          join b in db.T_QWF_Resource.AsNoTracking() on a.RuleId equals b.RuleId
                          where a.RoleId == roleId
                          select b;

                var rows = qry.ToList().Select(o => new
                {
                    RuleId = o.RuleId,
                    ResourceName = o.ResourceName,
                    ResourceCode = o.ResourceCode,
                    ResourceRemarks = o.ResourceRemarks
                });

                var result = new { total = rows.Count(), rows = rows };

                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
                           
            }
        }

        public ActionResult GetResouceList()
        {
            #region 参数
            //固定参数
            int pageSize = this.Request["rows"].SafeConvert().ToInt32(30);
            int pageIndex = this.Request["page"].SafeConvert().ToInt32(1);
            var pageSort = this.Request["sort"].SafeConvert().ToStr("CreateTime"); //排序字段 
            var pageOrderby = this.Request["orderby"].SafeConvert().ToStr("desc");// 升序或降序
            //业务参数
            var qryResourceName = this.Request["qryResourceName"].SafeConvert().ToStr();
            var qryResourceCode = this.Request["qryResourceCode"].SafeConvert().ToStr();
            #endregion
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                //查询
                var qry = db.T_QWF_Resource.AsNoTracking().AsQueryable();

                //排序
                qry = QWF.Framework.Dynamic.QueryableHelper.DataSorting(qry, pageSort, pageOrderby);

                //条件
                if (qryResourceCode.Length > 0)
                {
                    qry = qry.Where(w => w.ResourceCode.Contains(qryResourceCode));
                }
                if (qryResourceName.Length > 0)
                {
                    qry = qry.Where(w => w.ResourceName.Contains(qryResourceName));
                }

                //分页
                var total = qry.Count();
                var rows = QWF.Framework.Dynamic.QueryableHelper.DataPaging(qry, pageIndex, pageSize).ToList()
                    .Select(o => new
                    {
                        o.ResourceRemarks,
                        o.ResourceCode,
                        o.ResourceName,
                        o.RuleId,
                        CreateTime = o.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                        UpdateTime = o.UpdateTime == null ? string.Empty : o.UpdateTime.Value.ToString("yyyy-MM-dd HH:mm:ss")
                    });


                //输出

                var result = new { total = total, rows = rows };

                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
            }
        }

        public ActionResult SaveRoleInResource()
        {
            var result = Web.ResultWebData.Default();
            var roleId = this.Request["roleId"].SafeConvert().ToInt32(0);
            var ruleIds = this.Request["ruleIds"].StringHelper().SplitToArray(",", StringSplitOptions.RemoveEmptyEntries);


            MainServices.CreateWebAppServices.GetRoleServices().AddRoleInResource(roleId, ruleIds);

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        public ActionResult DelRoleInResource()
        {
            var result = Web.ResultWebData.Default();
            var roleId = this.Request["roleId"].SafeConvert().ToInt32(0);
            var ruleIds = this.Request["ruleIds"].StringHelper().SplitToArray(",", StringSplitOptions.RemoveEmptyEntries);


            MainServices.CreateWebAppServices.GetRoleServices().DeleteRoleInResource(roleId, ruleIds);

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }
    }
}