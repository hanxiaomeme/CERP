using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QWF.Framework.ExtendUtils;
using QWF.Framework.GlobalException;

namespace QWF.Framework.Sites.Areas.QWebFramework.Controllers
{
    public class RoleGroupController : Controller
    {
        // GET: QWebFramework/RoleGroup
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            #region 参数
            int pageSize = this.Request["rows"].SafeConvert().ToInt32(30);
            int pageIndex = this.Request["page"].SafeConvert().ToInt32(1);
            var pageSort = this.Request["sort"].SafeConvert().ToStr("SortId"); //排序字段 
            var pageOrderby = this.Request["orderby"].SafeConvert().ToStr("asc");// 升序或降序

            var qryGroupName = Request["qryGroupName"].SafeConvert().ToStr();

            #endregion

            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var qry = from a in db.T_QWF_RoleGroup.AsNoTracking()
                          where a.IsDelete==0
                          select new
                          {
                              a.GroupId,
                              a.GroupName,
                              a.GroupRemarks,
                              a.CreateTime,
                              a.SortId
                          };

                //排序
                qry = QWF.Framework.Dynamic.QueryableHelper.DataSorting(qry, pageSort, pageOrderby);
                //过滤
                if (qryGroupName.Length > 0)
                {
                    qry = qry.Where(w => w.GroupName.Contains(qryGroupName));
                }
                //分页
                var total = qry.Count();
                qry = QWF.Framework.Dynamic.QueryableHelper.DataPaging(qry, pageIndex, pageSize);

                //输出
                var rows = qry.ToList().Select(o => new
                {
                    GroupId = o.GroupId,
                    GroupName = o.GroupName,
                    GroupRemarks = o.GroupRemarks == null ? string.Empty : o.GroupRemarks,
                    CreateTime = o.CreateTime.ToString("yyyy-MM-dd HH:mm:ss")
                });
                
                var data = new { total = total, rows = rows };
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(data));
            }

        }

        public ActionResult SaveRoleGroup()
        {
            Web.ResultWebData result = Web.ResultWebData.Default();

            var groupName = Request["groupName"].SafeConvert().ToStr();
            var remarks = Request["remarks"].SafeConvert().ToStr();
            var groupId = Request["groupId"].SafeConvert().ToInt32(0);

            var svrModel = new Services.SvrModels.SvrRoleGroupInfo();
            svrModel.GroupId = groupId;
            svrModel.GroupRemarks = remarks;
            svrModel.GroupName = groupName;

            var services = MainServices.CreateWebAppServices.GetRoleServices();
            if (groupId == 0)
            {
                services.CreateRoleGroup(svrModel);
            }
            else
            {
                services.UpdateRoleGroup(svrModel);
            }
            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        public ActionResult Delete()
        {
            Web.ResultWebData result = Web.ResultWebData.Default();
            var groupId = Request["groupId"].SafeConvert().ToInt32();
            var services = MainServices.CreateWebAppServices.GetRoleServices();
            services.DeleteRoleGroup(groupId);
            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }


        public ActionResult Sort()
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            string[] keys = QWF.Framework.Web.QWFRequest.GetFormAllKeys();
            foreach (string key in keys)
            {
                if (key.StartsWith("sortId_"))
                {
                    int sortId = Request[key].SafeConvert().ToInt32(-1);
                    int orgId = key.Substring(7).SafeConvert().ToInt32(-1);
                    if (sortId == -1 || orgId == 0)
                    {
                        throw new UIValidateException("排序数字请填写正确");
                    }
                    dic.Add(orgId, sortId);
                }
            }
            var result = Web.ResultWebData.Default();
            //排序
            MainServices.CreateWebAppServices.GetRoleServices().RoleGroupSort(dic);

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }
    }
}