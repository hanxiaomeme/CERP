using QWF.Framework.ExtendUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QWF.Framework.Sites.Areas.QWebFramework.Controllers
{
    public class ResourceController : Controller
    {
        // GET: QWebFramework/Resource/ResourceList
        public ActionResult ResourceList()
        {
            return View();
        }

        public ActionResult GetResouceList()
        {
            //
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


        public ActionResult SaveResource()
        {
            var result = Web.ResultWebData.Default();

            var ruleId = this.Request["hidRuleId"].SafeConvert().ToInt32(0);
            var resourceCode = this.Request["resourceCode"].SafeConvert().ToStr();
            var resourceName = this.Request["resourceName"].SafeConvert().ToStr();
            var remarks = this.Request["remark"].SafeConvert().ToStr();

            var services = MainServices.CreateWebAppServices.GetResouceServices();
            if(ruleId==0)
            {
                services.CreateResourceCode(resourceCode, resourceName,remarks);
            }
            else
            {
                services.UpdateResourceCode(ruleId, resourceName,remarks);
            }
            

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        public ActionResult DelResource()
        {
            var result = Web.ResultWebData.Default();

            var ruleId = this.Request["ruleId"].SafeConvert().ToInt32(0);
            var services = MainServices.CreateWebAppServices.GetResouceServices();
            services.DeleteResource(ruleId);

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

    }
}