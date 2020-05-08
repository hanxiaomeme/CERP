using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QWF.Framework.ExtendUtils;
using System.Dynamic;

namespace QWF.Framework.Sites.Areas.QWebFramework.Controllers
{
    public class UsersController : Controller
    {
        [QWF.Framework.Web.Filter.PermissionUrl(IsAuth = false)]
        public ContentResult UserLogin()
        {
            Web.ResultWebData result = new Web.ResultWebData();
            result.Success = true;

            string appid = "qwf.app.base";

            string userName = this.Request["userName"].SafeConvert().ToStr();
            string passWord = this.Request["passWord"].SafeConvert().ToStr();

            MainServices.GuestServices.GetUserLoginServices().CheckUserLogin(appid, userName, passWord);

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));

        }

        public ActionResult UserList()
        {
            return View();
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
            var qryUserId = this.Request["qryUserId"].SafeConvert().ToInt32(0);
            var qryUserName = this.Request["qryUserName"].SafeConvert().ToStr();
            var qryRealname = this.Request["qryRealName"].SafeConvert().ToStr();
            var qryUserStatus = this.Request["qryUserStatus"].SafeConvert().ToInt32(0);

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

                if (qryUserId > 0)
                    qry = qry.Where(w => w.b.UserId == qryUserId);

                if (qryUserName.Length > 0)
                    qry = qry.Where(w => w.b.UserName == qryUserName);

                if (qryRealname.Length > 0)
                    qry = qry.Where(w => w.b.Realname.Contains(qryRealname));
                if (qryUserStatus > 0)
                    qry = qry.Where(w => w.b.UserStatus == qryUserStatus);

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
                    OrgId = o.OrgId,
                    Realname = o.b.Realname,
                    UserStatus = o.b.UserStatus == 1 ? "正常" : "禁用",
                    Leader = o.b.Leader==1 ? "是" : "否",
                    Tel = o.b.Tel,
                    Phone = o.b.Phone,
                    Email = o.b.Email,
                    Position = o.b.Position,
                    QQ = o.b.QQ,
                    Weixin = o.b.Weixin,
                    Fax = o.b.Fax,
                    LastLoginIp = o.b.LastLoginIp,
                    LastLoginTime = o.b.LastLoginTime == null ? "" : o.b.LastLoginTime.Value.ToString("yyyy-MM-dd HH:mm"),
                    CreateTime = o.b.CreateTime.ToString("yyyy-MM-dd HH:mm"),
                    UserRemarks = o.b.UserRemarks
                });

                var data = new { total = total, rows = rows };
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(data));
            }

        }


        public ActionResult SaveUser()
        {
            //获取参数 
            var svrUser = new Services.SvrModels.SvrUserInfo();

            svrUser.OrgId = this.Request["orgId"].SafeConvert().ToInt32(0);
            svrUser.UserName = this.Request["userName"].SafeConvert().ToStr();
            svrUser.PassWord = this.Request["password"].SafeConvert().ToStr();
            svrUser.UserId = this.Request["userId"].SafeConvert().ToInt32(0);
            svrUser.Realname = this.Request["realname"].SafeConvert().ToStr();
            svrUser.Fax = this.Request["fax"].SafeConvert().ToStr();
            svrUser.Tel = this.Request["tel"].SafeConvert().ToStr();
            svrUser.Phone = this.Request["phone"].SafeConvert().ToStr();
            svrUser.Email = this.Request["email"].SafeConvert().ToStr();
            svrUser.QQ = this.Request["qq"].SafeConvert().ToStr();
            svrUser.Weixin = this.Request["weixin"].SafeConvert().ToStr();
            svrUser.Position = this.Request["position"].SafeConvert().ToStr();
            svrUser.Leader = this.Request["leader"] == null ? false:true;
            svrUser.UserRemarks = this.Request["userRemarks"].SafeConvert().ToStr();

            if (svrUser.UserId == 0)
            {
                if (svrUser.PassWord.StrValidatorHelper().StrIsNullOrEmpty())
                {
                    throw new QWF.Framework.GlobalException.UIValidateException("请填写密码");
                }

            }

            //密码处理
            if (!svrUser.PassWord.StrValidatorHelper().StrIsNullOrEmpty())
                svrUser.PassWord = svrUser.PassWord.StringHelper().EncodeMD5();
            //
            Web.ResultWebData result = new Web.ResultWebData();
            result.Success = true;
            result.Message = "success";

            int userId = 0;
            //控制反转
            IOC.IUserIoc userIoc = Iocs.GetInstance().Resolve<IOC.IUserIoc>();
            try
            {
                if (svrUser.UserId == 0)
                {
                    //新增前
                    if (userIoc != null)
                        svrUser = userIoc.CreateBegin(svrUser);

                    //新增
                    userId = MainServices.CreateWebAppServices.GetUserServices().CreateUser(svrUser);

                    //创建成功
                    if (userIoc != null)
                        userIoc.CreateSuccess(userId);
                }
                else
                {
                    //编辑

                    if (userIoc != null)
                        svrUser = userIoc.UpdateBegin(svrUser);

                    userId = MainServices.CreateWebAppServices.GetUserServices().UpdateUser(svrUser);

                    if (userIoc != null)
                        userIoc.UpdateSuccess(userId);

                }

            }
            catch (Exception ex)
            {
                if (userIoc != null)
                    userIoc.CreateFail(svrUser, ex);

                throw ex;
            }
            //输出用户ID
            result.Data = new { userId = userId };
            //输出JSON
            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));

        }

        public ActionResult OrderUser()
        {
            //获取参数 
            var type = this.Request["type"].SafeConvert().ToStr();
            var userIds = this.Request["userIds"].StringHelper().SplitToList(",", StringSplitOptions.RemoveEmptyEntries);

            if (type.Length == 0)
                throw new QWF.Framework.GlobalException.UIValidateException("type参数类型不正确");

            if(userIds==null)
                throw new QWF.Framework.GlobalException.UIValidateException("请选择一条记录");

            //
            Web.ResultWebData result = new Web.ResultWebData();
            result.Success = true;
            result.Message = "success";

            var userServices = MainServices.CreateWebAppServices.GetUserServices();

            IOC.IUserIoc ioc = Iocs.GetInstance().Resolve<IOC.IUserIoc>();
            if (ioc != null)
                ioc.OrderUserBegin(type, userIds);

            try
            {
                userServices.OrderUser(type, userIds);

                if (ioc != null)
                    ioc.OrderUserSuccess(type, userIds);
            }

            catch (Exception ex)
            {
                ioc.OrderUserFail(type, userIds);
                throw ex;
            }

            //输出JSON
            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));

        }

    }
}