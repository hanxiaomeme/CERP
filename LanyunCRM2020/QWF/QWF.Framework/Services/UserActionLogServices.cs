using QWF.Framework.Services.SvrModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Services
{
    public class UserActionLogServices
    {
        private SvrModels.SvrUserIdentifier svrUser;

        private readonly static object _lock = new object();

        public UserActionLogServices(SvrModels.SvrUserIdentifier svrUser)
        {
            this.svrUser = svrUser;
        }


        /// <summary>
        /// 写入用户操作日志
        /// </summary>
        /// <param name="logCode">日志代码，例如:crm.add.user 或 新增用户</param>
        /// <param name="logType">日志类型</param>
        /// <param name="logDesc">日志描述</param>
        /// <param name="logItem">匿名对象 new{ key1=valu1,key2=values2 }</param>
        /// <returns></returns>
        public bool WriterActionLog(string logCode, SverUserActionLogType logType= SverUserActionLogType.Default, string logDesc=null, object logItem=null)
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var dbModel = new DbAccess.T_QWF_UserActionLog();

                dbModel.LogCode = logCode;
                dbModel.LogType = (int)logType;
                dbModel.LogDescription = logDesc;
                dbModel.UserId = this.svrUser.UserId;
                dbModel.UserName = this.svrUser.UserName;
                dbModel.UserIp = Web.QWFRequest.GetIP();
                dbModel.UserCode = this.svrUser.UserCode;
                if(logItem!=null)
                {
                    dbModel.LogItems = Newtonsoft.Json.JsonConvert.SerializeObject(logItem);
                }

                #region 调用者方法
                System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
                string methodName = null;
                string className = null;
                string namespaceName = null;

                foreach (System.Diagnostics.StackFrame sf in st.GetFrames())
                {
                    MethodBase method = sf.GetMethod();
                    methodName = method.Name;
                    className = method.DeclaringType.Name;
                    namespaceName = method.DeclaringType.Namespace;

                    if (namespaceName != "QWF.Framework.Services" && methodName != "WriterActionLog")
                        break;
                }
                #endregion

                var actionMethod = namespaceName + "." + className + "." + methodName;

                dbModel.ActionMethod = actionMethod;
                dbModel.CreateTime = svrUser.CurrentTime;

                db.T_QWF_UserActionLog.Add(dbModel);

                db.SaveChanges();

                return true;
            }
            

        }
    }
}
