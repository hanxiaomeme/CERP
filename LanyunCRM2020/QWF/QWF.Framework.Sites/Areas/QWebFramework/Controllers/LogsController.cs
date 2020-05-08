using QWF.Framework.ExtendUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QWF.Framework.Sites.Areas.QWebFramework.Controllers
{
    public class LogsController : Controller
    {

        // GET: QWebFramework/Logs
        #region 用户登录日志
        public ActionResult UserLoginLogs()
        {
            return View();
        }

        public ActionResult GetUserLoginLogList()
        {
            #region 参数

            int pageSize = this.Request["rows"].SafeConvert().ToInt32(30);
            int pageIndex = this.Request["page"].SafeConvert().ToInt32(1);
            var pageSort = this.Request["sort"].SafeConvert().ToStr("LoginTime"); //排序字段 
            var pageOrderby = this.Request["orderby"].SafeConvert().ToStr("desc");// 升序或降序

            var qryUserName = Request["qryUserName"].SafeConvert().ToStr();
            var qryRealname = Request["qryRealname"].SafeConvert().ToStr();
            var qryUserStatus = Request["qryUserStatus"].SafeConvert().ToInt32(0);
            var qryBeginTime = Request["qryBeginTime"].SafeConvert().ToDateTime(new DateTime(0001, 1, 1));
            var qryEndTime = Request["qryEndTime"].SafeConvert().ToDateTime(new DateTime(9999, 1, 1));
            var qryLoginStatus = Request["qryLoginStatus"].SafeConvert().ToInt32(0);

            #endregion
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                //查询
                var qry = from a in db.T_QWF_LoginLog.AsNoTracking()
                          join b in db.T_QWF_User on a.UserName equals b.UserName into cc
                          from c in cc.DefaultIfEmpty()
                          select new
                          {
                              LoginUser = a.UserName,
                              a.AppId,
                              a.Ip,
                              a.LoginStatus,
                              a.LoginTime,
                              a.Remarks,
                              c
                          };

                qry = QWF.Framework.Dynamic.QueryableHelper.DataSorting(qry, pageSort, pageOrderby);

                //过滤

                if (qryUserName.Length > 0)
                    qry = qry.Where(w => w.LoginUser.Contains(qryUserName));
                if (qryRealname.Length > 0)
                    qry = qry.Where(w => w.c != null && w.c.Realname.Contains(qryRealname));
                if (qryUserStatus > 0)
                    qry = qry.Where(w => w.c != null && w.c.UserStatus == qryUserStatus);

                if (qryBeginTime.Year > 0001)
                    qry = qry.Where(w => w.LoginTime >= qryBeginTime && w.LoginTime <= qryEndTime);

                if (qryLoginStatus > 0)
                    qry = qry.Where(w => w.LoginStatus == qryLoginStatus);

                //分页
                var total = qry.Count();
                qry = QWF.Framework.Dynamic.QueryableHelper.DataPaging(qry, pageIndex, pageSize);

                var rows = qry.ToList().Select(o => new
                {
                    AppId = o.AppId,
                    LoginUser = o.LoginUser,
                    Ip = o.Ip,
                    LoginStatus = o.LoginStatus,
                    LoginStatusName = o.LoginStatus == 1 ? "正常" : "失败",
                    LoginTime = o.LoginTime.ToString("yyyy-MM-dd:HH:mm:ss"),
                    Remarks = o.Remarks,
                    //UserExists = o.c ==null ? "账号不存在" : "", 
                    Realname = o.c != null ? o.c.Realname : string.Empty,
                    Position = o.c != null ? o.c.Position : string.Empty,
                    IsDelete = o.c != null ? (o.c.IsDelete==1 ? "√" : "") : string.Empty
                });
                //输出
                var data = new { total = total, rows = rows };
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(data));
            }

        }
        #endregion

        #region 用户操作日志
        public ActionResult UserActionLogs()
        {
            return View();
        }
        public ActionResult GetUserActionLogList()
        {
            #region 参数

            int pageSize = this.Request["rows"].SafeConvert().ToInt32(30);
            int pageIndex = this.Request["page"].SafeConvert().ToInt32(1);
            var pageSort = this.Request["sort"].SafeConvert().ToStr("CreateTime"); //排序字段 
            var pageOrderby = this.Request["orderby"].SafeConvert().ToStr("desc");// 升序或降序

            var qryUserId = Request["qryUserId"].SafeConvert().ToInt32(0);
            var qryUserCode = Request["qryUserCode"].SafeConvert().ToStr();
            var qryUserName = Request["qryUserName"].SafeConvert().ToStr();
            var qryLogCode = Request["qryLogCode"].SafeConvert().ToStr();
            var qryLogTypes = Request["qryLogTypes"].SafeConvert().ToInt32(0);
            var qryBeginTime = Request["qryBeginTime"].SafeConvert().ToDateTime(new DateTime(0001, 1, 1));
            var qryEndTime = Request["qryEndTime"].SafeConvert().ToDateTime(new DateTime(9999, 1, 1));

            #endregion

            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var qry = db.T_QWF_UserActionLog.AsNoTracking().AsQueryable();

                //条件
                if (qryUserId > 0)
                    qry = qry.Where(w => w.UserId == qryUserId);
                if (qryUserCode.Length > 0)
                    qry = qry.Where(w => w.UserCode == qryUserCode);
                if (qryUserName.Length > 0)
                    qry = qry.Where(w => w.UserName == qryUserName);
                if (qryLogCode.Length > 0)
                    qry = qry.Where(w => w.LogCode == qryLogCode);
                if (qryLogTypes > 0)
                    qry = qry.Where(w => w.LogType == qryLogTypes);
                if (qryBeginTime.Year > 0001)
                    qry = qry.Where(w => w.CreateTime >= qryBeginTime && w.CreateTime <= qryEndTime);

                //分页
                var total = qry.Count();
                qry = QWF.Framework.Dynamic.QueryableHelper.DataPaging(qry, pageIndex, pageSize);


                //输出
                var rows = qry.ToList();
                var data = new { total = total, rows = rows };
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(data));
            }
        }
        #endregion

        #region 应用程序日志
        public ActionResult AppLogs()
        {
            //日志目录
            var sysPath = QWF.Framework.Common.ConfigHelper.GetParameterValue("qwf.core", "LogPath");
            var director = new System.IO.DirectoryInfo(sysPath);
            var dirsList = director.GetDirectories().ToList().Select(o => o.Name).ToList();
            dirsList.Insert(0, "根目录");
            ViewBag.Dirs = dirsList;

            return View();
        }

        public ActionResult ReadAppContent()
        {
            //日志目录
            var sysPath = QWF.Framework.Common.ConfigHelper.GetParameterValue("qwf.core", "LogPath");
            var director = new System.IO.DirectoryInfo(sysPath);
            
            var fileDir = this.Request["filedir"].SafeConvert().ToStr();
            var fileName = this.Request["fileName"].SafeConvert().ToStr();
            //日志目录
            string logPath = System.IO.Path.Combine(sysPath, fileName); ;
            if (fileDir.Length > 0 && fileDir != "根目录")
            {
                logPath = System.IO.Path.Combine(sysPath, fileDir,fileName);
            }

            string content = string.Empty;
            using (System.IO.StreamReader sr = new System.IO.StreamReader(logPath))
            {
                content = sr.ReadToEnd().Replace("\r\n","<br/>");
            }
            return View(content);
        }


        public ActionResult GetAppLogList()
        {
            #region 参数

            int pageSize = this.Request["rows"].SafeConvert().ToInt32(30);
            int pageIndex = this.Request["page"].SafeConvert().ToInt32(1);
            var pageSort = this.Request["sort"].SafeConvert().ToStr("CreateTime"); //排序字段 
            var pageOrderby = this.Request["orderby"].SafeConvert().ToStr("desc");// 升序或降序

            var qryDir = this.Request["qryDir"].SafeConvert().ToStr();
            var qryBeginTime = Request["qryBeginTime"].SafeConvert().ToDateTime(DateTime.Now.AddDays(-30).Date);
            var qryEndTime = Request["qryEndTime"].SafeConvert().ToDateTime(DateTime.Now.Date);

            #endregion


            //日志目录
            var sysPath = QWF.Framework.Common.ConfigHelper.GetParameterValue("qwf.core", "LogPath");
            string logPath = sysPath;
            if (qryDir.Length > 0 && qryDir != "根目录")
            {
                logPath = System.IO.Path.Combine(sysPath, qryDir);
            }

            //获取目录下所有文件
            var director = new System.IO.DirectoryInfo(logPath);
            var fileList = director.GetFiles().ToList();

            var qry = fileList.Select(o => new
            {
                FileName = o.Name,
                FileDir = qryDir,
                FileSize = Math.Round((o.Length / (1024.0)), 2),
                LastTime = o.LastWriteTime
            }).OrderByDescending(o => o.LastTime).ToList();


            if (qryBeginTime.Year > 0001)
                qry = qry.Where(w => w.LastTime >= qryBeginTime && w.LastTime <= qryEndTime).ToList();

            //分页
            var total = qry.Count();
            qry = QWF.Framework.Dynamic.QueryableHelper.ListPaged(qry.ToList(), pageIndex, pageSize);

            var data = qry.Select(o =>
            new
            {
                o.FileName,
                o.FileSize,
                o.FileDir,
                LastTime = o.LastTime.ToString("yyyy-MM-dd HH:mm:ss")
            }).ToList();

            var result = new { total = total, rows = data };
            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));

        }

        #endregion
    }
}