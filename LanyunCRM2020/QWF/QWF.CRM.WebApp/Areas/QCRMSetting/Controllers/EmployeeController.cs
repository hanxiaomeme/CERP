using QWF.Framework.ExtendUtils;
using QWF.Framework.GlobalException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QWF.CRM.WebApp.Areas.QCRMSetting.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: QCRMSetting/Employee
        public ActionResult Index()
        {
            using (var db = DbAccess.DbCRMContext.Create())
            {
                ViewBag.Roles = QWF.Framework.MainServices.CreateWebAppServices.GetConfigServices().GetNodeItemsByCode("qwf.qcrm.rolegroup").ToList();

            }
            return View();
        }


        public ActionResult GetList()
        {
            var qryOrgId = this.Request["qryOrgId"].SafeConvert().ToStr();
            var qryRoleCode = this.Request["qryRoleCode"].SafeConvert().ToStr();
            var qryKey = this.Request["qryKey"].SafeConvert().ToStr();
            var qryUserStatus = this.Request["qryUserStatus"].SafeConvert().ToInt32(0);

            int pageSize = this.Request["rows"].SafeConvert().ToInt32(30);
            int pageIndex = this.Request["page"].SafeConvert().ToInt32(1);
            var pageSort = this.Request["sort"].SafeConvert().ToStr("CreateTime"); //排序字段 
            var pageOrderby = this.Request["orderby"].SafeConvert().ToStr("desc");// 升序或降序

            using (var db = DbAccess.DbCRMContext.Create())
            {

                var qry = from a in db.T_QWF_User
                          join b in db.T_QWF_Org on a.OrgId equals b.OrgId
                          join c in db.vw_UserInRoles on a.UserId equals c.UserId into cc
                          from d in cc.DefaultIfEmpty()
                          where a.IsDelete == 0 && b.IsDelete == 0
                          select new
                          {
                              a.UserId,
                              a.UserName,
                              a.UserStatus,
                              a.UserCode,
                              a.Realname,
                              b.OrgId,
                              b.OrgIdList,
                              b.OrgNamePath,
                              RoleCodes = d == null ? "" : d.RoleCodes,
                              RoleNames = d == null ? "" : d.RoleNames,
                              a.CreateTime,
                              a.UpdateTime,
                              a.Phone,
                              a.Tel,
                              a.Leader,
                              a.Email,
                              a.Position,
                              a.QQ,
                              a.Weixin,
                              a.Fax,
                              a.LastLoginIp,
                              a.LastLoginTime,
                              a.UserRemarks

                          };
                //排序
                qry = QWF.Framework.Dynamic.QueryableHelper.DataSorting(qry, pageSort, pageOrderby);

                if (qryOrgId.Length > 0)
                    qry = qry.Where(w => w.OrgIdList.IndexOf("," + qryOrgId + ",") > -1);
                if (qryRoleCode.Length > 0)
                    qry = qry.Where(w => w.RoleCodes.IndexOf(qryRoleCode + ",") > -1);

                if (qryUserStatus > 0)
                    qry = qry.Where(w => w.UserStatus == qryUserStatus);

                if (qryKey.Length > 0)
                {
                    int userId = 0;
                    Int32.TryParse(qryKey, out userId);

                    qry = qry.Where(w => w.Realname.IndexOf(qryKey) > -1
                   || w.UserName == qryKey
                   || w.UserId == userId
                   || w.UserCode == qryKey
                   );
                }



                var total = qry.Count();
                qry = QWF.Framework.Dynamic.QueryableHelper.DataPaging(qry, pageIndex, pageSize);

                var rows = qry.ToList().Select(s => new
                {
                    s.UserId,
                    s.UserCode,
                    s.Realname,
                    s.UserName,
                    s.OrgId,
                    s.OrgNamePath,
                    s.RoleCodes,
                    s.RoleNames,
                    CreateTime = s.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    UpdateTime = s.UpdateTime == null ? "" : s.UpdateTime.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                    s.UserStatus,
                    UserStatusName = s.UserStatus == 1 ? "正常" : "禁用",
                    s.Leader,
                    LeaderName = s.Leader == 1 ? "√" : "",
                    Tel = s.Tel,
                    Phone = s.Phone,
                    Email = s.Email,
                    Position = s.Position,
                    QQ = s.QQ,
                    Weixin = s.Weixin,
                    Fax = s.Fax,
                    LastLoginIp = s.LastLoginIp,
                    LastLoginTime = s.LastLoginTime == null ? "" : s.LastLoginTime.Value.ToString("yyyy-MM-dd HH:mm"),
                    s.UserRemarks
                });

                var result = new { total = total, rows = rows };

                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));

            }
        }

        public ActionResult GetOrgTree()
        {
            using (var db = DbAccess.DbCRMContext.Create())
            {
                var rows = db.T_QWF_Org.AsNoTracking().Where(w => w.IsDelete == 0).OrderBy(o => o.SortId).ToList();

                var tree = new QWF.Framework.Web.UI.TreeConverter<DbAccess.T_QWF_Org>();

                tree.ClosedLayer = 3;//这里要全部展开。否则是会异步加载

                tree.GetId = m => { return m.OrgId.ToString(); };
                tree.GetParentId = m => { return m.ParentId.ToString(); };

                //映射字段
                var treeList = tree.ConvertTo(item =>
                {
                    var node = new QWF.Framework.Web.UI.BaseTreeNode();
                    node.id = item.OrgId.ToString();
                    node.text = item.OrgName;
                    return node;
                }, rows, "0");

                treeList.Insert(0, new Framework.Web.UI.BaseTreeNode { id = "", text = "==全部== " });
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(treeList));
            }
        }

        public ActionResult GetRoles()
        {
            using (var db = DbAccess.DbCRMContext.Create())
            {
                var item = new Framework.Services.SvrModels.SvrConfig { Name = "==全部==", Value = "", Id = 0, IsHide = false };
                var rows = QWF.Framework.MainServices.CreateWebAppServices.GetConfigServices().GetNodeItemsByCode("qwf.qcrm.rolegroup").ToList();
                rows.Insert(0, item);

                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(rows));
            }
        }

        public ActionResult Save()
        {
            var userId = this.Request["id"].SafeConvert().ToInt32(0);
            var orgId = this.Request["orgId"].SafeConvert().ToInt32(0);
            var realname = this.Request["realname"].SafeConvert().ToStr();
            var userName = this.Request["userName"].SafeConvert().ToStr();
            var password = this.Request["password"].SafeConvert().ToStr();
            var roleCodes = this.Request["roleCode"].SafeConvert().ToStr().StringHelper().SplitToArray();
            var tel = this.Request["tel"].SafeConvert().ToStr();
            var phone = this.Request["phone"].SafeConvert().ToStr();
            var fax = this.Request["fax"].SafeConvert().ToStr();
            var weixin = this.Request["weixin"].SafeConvert().ToStr();
            var position = this.Request["position"].SafeConvert().ToStr();
            var userRemarks = this.Request["userRemarks"].SafeConvert().ToStr();
            var userStatus = this.Request["userStatus"].SafeConvert().ToInt32(0);
            var leader = this.Request["leader"].SafeConvert().ToBool();
            var qq = this.Request["qq"].SafeConvert().ToStr();
            var email = this.Request["email"].SafeConvert().ToStr();
            var result = QWF.Framework.Web.ResultWebData.Default();
            var create = this.Request["create"].SafeConvert().ToBool();

            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();

            if (userId == 0 && userName.Length == 0)
                throw new UIValidateException("请填写账号。");
            if (userId == 0 && password.Length == 0)
                throw new UIValidateException("请填些密码。");
            if (roleCodes.Length == 0)
                throw new UIValidateException("请选择角色。");
            if (orgId == 0)
                throw new UIValidateException("请选择部门。");

            using (var db = DbAccess.DbCRMContext.Create())
            {
                if (userId == 0)
                {

                    if (db.T_QWF_User.Where(w => w.UserName == userName && w.IsDelete == 0).Count() > 0)
                        throw new UIValidateException("账号【{0}】已存在，请更换。", userName);

                    //新增
                    var svrModel = new QWF.Framework.Services.SvrModels.SvrUserInfo();

                    svrModel.Realname = realname;
                    svrModel.OrgId = orgId;
                    svrModel.UserName = userName;
                    svrModel.PassWord = password.StringHelper().EncodeMD5(); //密码MD5小写
                    svrModel.Phone = phone;
                    svrModel.Position = position;
                    svrModel.QQ = qq;
                    svrModel.Leader = leader;
                    svrModel.Fax = fax;
                    svrModel.Tel = tel;
                    svrModel.Weixin = weixin;
                    svrModel.Email = email;
                    svrModel.UserStatus = (Framework.Services.SvrModels.SvrUserInfo.UserStatusEnum)userStatus;
                    svrModel.UserRemarks = userRemarks;

                    var services = QWF.Framework.MainServices.CreateWebAppServices;
                    var newUserId = services.GetUserServices().CreateUser(svrModel);
                    //保存角色
                    services.GetRoleServices().SaveUserInRoleByCodes(roleCodes, newUserId);

                }
                else
                {
                    //编辑
                    var svrModel = new QWF.Framework.Services.SvrModels.SvrUserInfo();
                    svrModel.Realname = realname;
                    svrModel.UserId = userId;
                    svrModel.OrgId = orgId;
                    svrModel.PassWord = password.Length > 0 ? password.StringHelper().EncodeMD5() : string.Empty;
                    svrModel.Phone = phone;
                    svrModel.Position = position;
                    svrModel.QQ = qq;
                    svrModel.Leader = leader;
                    svrModel.Fax = fax;
                    svrModel.Tel = tel;
                    svrModel.Weixin = weixin;
                    svrModel.Email = email;
                    svrModel.UserStatus = (Framework.Services.SvrModels.SvrUserInfo.UserStatusEnum)userStatus;
                    svrModel.UserRemarks = userRemarks;

                    //调用框架接口
                    var services = QWF.Framework.MainServices.CreateWebAppServices;
                    services.GetUserServices().UpdateUser(svrModel);
                    //保存角色
                    services.GetRoleServices().SaveUserInRoleByCodes(roleCodes, userId);
                }
                db.SaveChanges();
            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));

        }

        public ActionResult Delete()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();

            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            var userId = this.Request["userId"].SafeConvert().ToInt32(0);

            using (var db = DbAccess.DbCRMContext.Create())
            {
                //删除角色
                db.T_QWF_UserInRole.Where(w => w.UserId == userId).ToList().ForEach(item =>
                {
                    db.T_QWF_UserInRole.Remove(item);
                });

                //删除用户
                var user = db.T_QWF_User.Where(w => w.UserId == userId).FirstOrDefault();
                if (user != null)
                {
                    user.IsDelete = 1;
                    user.UpdateTime = DateTime.Now;
                    user.UpdateUserId = curUser.CurrentUserId;

                }

                db.SaveChanges();

            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }


        public ActionResult GetAllUserList()
        {

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var rows = db.T_QWF_User.Where(w => w.IsDelete == 0).OrderBy(o => o.Realname).Select(s => new { Name = s.Realname, Value = s.UserCode });

                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(rows));

            }
        }

        public ActionResult ChangCustomer()
        {
            var fromUserCode = this.Request["fromUserCode"].SafeConvert().ToStr();
            var toUserCode = this.Request["toUserCode"].SafeConvert().ToStr();
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            var result = QWF.Framework.Web.ResultWebData.Default();

            if (fromUserCode.Length == 0)
                throw new UIValidateException("拥有者不能为空。");
            if (toUserCode.Length == 0)
                throw new UIValidateException("接收者不能为空。");

            if (!QWF.CRM.Utils.PermissionUtils.Create().IsChangCustomer())
                throw new UIValidateException("权限不够，不能转移客户。");

            //标准的SQL更新语句，采用EF执行SQL
            using (var db = DbAccess.DbCRMContext.Create())
            {
                string sql = string.Format("UPDATE  TB_Customer SET  CreateUser = '{0}' WHERE CreateUser='{1}'", toUserCode, fromUserCode);
                db.Database.SqlQuery<int>(sql);
                //写入日志
                QWF.Framework.MainServices.CreateWebAppServices.GetUserActionLogServices().WriterActionLog("批量转移客户",Framework.Services.SvrModels.SverUserActionLogType.Update,null,new { 拥有者=fromUserCode,接收者=toUserCode });
            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }
    }
}