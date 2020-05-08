using QWF.Framework.ExtendUtils;
using QWF.Framework.GlobalException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QWF.Framework.Sites.Areas.QWebFramework.Controllers
{
    public class RoleController : Controller
    {
        //GET: QWebFramework/Role
        public ActionResult Index()
        {
            //查询角色组

            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var qry = db.T_QWF_RoleGroup.AsNoTracking().Where(w => w.IsDelete == 0).OrderBy(o => o.SortId).ToList().
                    Select(o => new Web.BaseItemKeyValue
                    {
                        Key = o.GroupId.ToString(),
                        Value = o.GroupName
                    });

                var roleGroupItems = qry.ToList();
                roleGroupItems.Insert(0, new Web.BaseItemKeyValue { Key = "", Value = "==全部==" });

                ViewBag.RoleGroupItmes = roleGroupItems;
            }

            return View(ViewBag);
        }

        public ActionResult List()
        {
            #region 参数
            int pageSize = this.Request["rows"].SafeConvert().ToInt32(30);
            int pageIndex = this.Request["page"].SafeConvert().ToInt32(1);
            var pageSort = this.Request["sort"].SafeConvert().ToStr("CreateTime"); //排序字段 
            var pageOrderby = this.Request["orderby"].SafeConvert().ToStr("desc");// 升序或降序

            var qryGroupId = Request["qryGroupId"].SafeConvert().ToInt32(0);
            var qryRoleId = Request["qryRoleId"].SafeConvert().ToInt32(0);
            var qryRoleName = Request["qryRoleName"].SafeConvert().ToStr();

            #endregion
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                //查询
                var qry = from a in db.T_QWF_RoleGroup.AsNoTracking()
                          join b in db.T_QWF_Role on a.GroupId equals b.RoleGroupId
                          where a.IsDelete==0 && b.IsDelete==0 
                          select new
                          {
                              a.GroupId,
                              a.GroupName,
                              b.RoleId,
                              b.RoleCode,
                              b.RoleName,
                              b.CreateTime,
                              b.UpdateTime,
                              b.Remarks
                          };

                //排序
                qry = QWF.Framework.Dynamic.QueryableHelper.DataSorting(qry, pageSort, pageOrderby);

                //过滤条件
                if (qryGroupId > 0)
                {
                    qry = qry.Where(w => w.GroupId == qryGroupId);
                }
                if(qryRoleId > 0)
                {
                    qry = qry.Where(w => w.RoleId == qryRoleId);
                }
                if(qryRoleName.Length>0)
                {
                    qry = qry.Where(w => w.RoleName.Contains(qryRoleName));
                }

                //分页
                var total = qry.Count();
                qry = QWF.Framework.Dynamic.QueryableHelper.DataPaging(qry, pageIndex, pageSize);

                var rows = qry.ToList().Select(o => new
                {
                    RoleGroupId = o.GroupId,
                    GroupName = o.GroupName,
                    RoleId = o.RoleId,
                    RoleCode = o.RoleCode,
                    RoleName = o.RoleName,
                    CreateTime = o.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    UpdateTime = o.UpdateTime == null ? string.Empty : o.UpdateTime.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                    Remarks = o.Remarks == null ? string.Empty : o.Remarks
                });
                //输出
                var data = new { total = total, rows = rows };
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(data));
            }

        }

        public ActionResult SaveRole()
        {
            Web.ResultWebData result = Web.ResultWebData.Default();

            var groupId = Request["groupId"].SafeConvert().ToInt32(0);
            var remarks = Request["remarks"].SafeConvert().ToStr();
            var roleId = Request["roleId"].SafeConvert().ToInt32(0);
            var roleName = Request["roleName"].SafeConvert().ToStr();

            var svrModel = new Services.SvrModels.SvrRoleInfo();

            svrModel.RoleGroupId = groupId;
            svrModel.RoleId = roleId;
            svrModel.RoleName = roleName;
            svrModel.Remarks = remarks;



            var services = MainServices.CreateWebAppServices.GetRoleServices();
            if (roleId == 0)
            {
                services.CreateRole(svrModel);
            }
            else
            {
                services.UpdateRole(svrModel);
            }
            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        public ActionResult Delete()
        {
            Web.ResultWebData result = Web.ResultWebData.Default();
            var roleId = Request["roleId"].SafeConvert().ToInt32();
            var services = MainServices.CreateWebAppServices.GetRoleServices();
            services.DeleteRole(roleId);
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