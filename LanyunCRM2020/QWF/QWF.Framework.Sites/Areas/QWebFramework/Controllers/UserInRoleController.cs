using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QWF.Framework.ExtendUtils;

namespace QWF.Framework.Sites.Areas.QWebFramework.Controllers
{
    public class UserInRoleController : Controller
    {
        // GET: QWebFramework/UserInRole/Index

        public ActionResult Index()
        {  //查询角色组

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
            var pageOrderby = this.Request["orderby"].SafeConvert().ToStr("asc");// 升序或降序

            var qryGroupId = Request["qryGroupId"].SafeConvert().ToInt32(0);
            var qryRoleName = Request["qryRoleName"].SafeConvert().ToStr();
            var qryUseName = Request["qryUserName"].SafeConvert().ToStr();
            var qryRealname = Request["qryRealname"].SafeConvert().ToStr();

            #endregion

            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var qry = from a in db.T_QWF_RoleGroup.AsNoTracking()
                          join b in db.T_QWF_Role.AsNoTracking() on a.GroupId equals b.RoleGroupId
                          join c in db.T_QWF_UserInRole.AsNoTracking() on b.RoleId equals c.RoleId
                          join d in db.T_QWF_User.AsNoTracking() on c.UserId equals d.UserId
                          where a.IsDelete==0 && d.IsDelete==0
                          select new
                          {
                              c.Id,
                              a.GroupName,
                              a.GroupId,
                              b.RoleName,
                              c.CreateTime,
                              d.UserName,
                              d.Realname
                          };

                //排序
                qry = QWF.Framework.Dynamic.QueryableHelper.DataSorting(qry, pageSort, pageOrderby);
                //过滤
                if (qryGroupId > 0)
                {
                    qry = qry.Where(w => w.GroupId == qryGroupId);
                }
                if (qryRoleName.Length > 0)
                {
                    qry = qry.Where(w => w.Realname.Contains(qryRoleName));
                }
                if (qryUseName.Length > 0)
                {
                    qry = qry.Where(w => w.UserName.Contains(qryUseName));
                }
                if (qryRoleName.Length > 0)
                {
                    qry = qry.Where(w => w.Realname.Contains(qryRealname));
                }

                //分页
                var total = qry.Count();
                qry = QWF.Framework.Dynamic.QueryableHelper.DataPaging(qry, pageIndex, pageSize);

                //输出
                var rows = qry.ToList().Select(o => new
                {
                    Id = o.Id,
                    GroupName = o.GroupName,
                    GroupId = o.GroupId,
                    RoleName = o.RoleName,
                    UserName = o.UserName,
                    Realname = o.Realname,
                    CreateTime = o.CreateTime.ToString("yyyy-MM-dd HH:mm:ss")
                });

                var data = new { total = total, rows = rows };
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(data));
            }
        }


        public ActionResult GetUserList()
        {
            #region 参数
            //固定参数
            int pageSize = this.Request["rows"].SafeConvert().ToInt32(30);
            int pageIndex = this.Request["page"].SafeConvert().ToInt32(1);
            var pageSort = this.Request["sort"].SafeConvert().ToStr("CreateTime"); //排序字段 
            var pageOrderby = this.Request["orderby"].SafeConvert().ToStr("desc");// 升序或降序

            //业务参数
            var qryOrgId = this.Request["qryOrgId"].SafeConvert().ToStr();
            var qryUserName = this.Request["qryUserName"].SafeConvert().ToStr();
            var qryRealname = this.Request["qryRealName"].SafeConvert().ToStr();


            #endregion

            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                //查询
                var qry = from a in db.T_QWF_Org.AsNoTracking()
                          join b in db.T_QWF_User.AsNoTracking() on a.OrgId equals b.OrgId
                          where a.IsDelete == 0 && b.IsDelete == 0
                          select new
                          {
                              b,
                              a.OrgId,
                              a.OrgIdList,
                              a.OrgName,
                              b.CreateTime
                          };
                //排序
                qry = QWF.Framework.Dynamic.QueryableHelper.DataSorting(qry, pageSort, pageOrderby);
                //筛选条件
                if (qryOrgId.Length > 0)
                    qry = qry.Where(w => w.OrgIdList.Contains("," + qryOrgId + ","));

                if (qryUserName.Length > 0)
                    qry = qry.Where(w => w.b.UserName == qryUserName);

                if (qryRealname.Length > 0)
                    qry = qry.Where(w => w.b.Realname.Contains(qryRealname));

                //分页
                var total = qry.Count();
                qry = QWF.Framework.Dynamic.QueryableHelper.DataPaging(qry, pageIndex, pageSize);

                //输出并格式化
                var rows = qry.ToList().Select(o => new
                {
                    UserId = o.b.UserId,
                    UserCode = o.b.UserCode,
                    UserName = o.b.UserName,
                    OrgName = o.OrgName,
                    Realname = o.b.Realname,
                    UserStatus = o.b.UserStatus == 1 ? "正常" : "禁用",
                    Leader = o.b.Leader==1 ? "是" : "否",
                    Position = o.b.Position,
                    CreateTime = o.b.CreateTime.ToString("yyyy-MM-dd HH:mm")
                });

                var data = new { total = total, rows = rows };
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(data));
            }
        }

        public ActionResult GetRoleList()
        {
            var qryRoleIdOrgId = this.Request["groupId"].SafeConvert().ToInt32(0);

            using (var db = DbAccess.DbFrameworkContext.Create())
            {

                //查询
                var qry = db.T_QWF_Role.AsNoTracking().Where(w => w.RoleGroupId == qryRoleIdOrgId && w.IsDelete == 0);
                var data = qry.ToList().Select(o => new Web.BaseItemKeyValue
                {
                    Key = o.RoleId.ToString(),
                    Value = o.RoleName
                }).ToList();

                data.Insert(0, new Web.BaseItemKeyValue { Key = "", Value = "==请选择==" });


                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(data));
            }
        }

        public ActionResult SaveUserInRole()
        {
            var result = Web.ResultWebData.Default();

            var roleId = this.Request["roleId"].SafeConvert().ToInt32(0);
            var userIds = this.Request["userIds"].StringHelper().SplitToArray(",", StringSplitOptions.RemoveEmptyEntries);

            MainServices.CreateWebAppServices.GetRoleServices().AddUserInRole(roleId, userIds);

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));


        }

        public ActionResult DeleteUserInRole()
        {
            var result = Web.ResultWebData.Default();

            var ids = this.Request["ids"].StringHelper().SplitToArray(",", StringSplitOptions.RemoveEmptyEntries);

            MainServices.CreateWebAppServices.GetRoleServices().DeleteUserInRoles(ids);

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));

        }



    }
}