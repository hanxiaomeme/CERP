using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Services.BLL
{
    public class UserLoginHelper
    {
        /// <summary>
        /// 框架DB的上下文
        /// </summary>
        public DbAccess.DbFrameworkContext DbContext { get; private set; }
        /// <summary>
        /// 服务调用者标识
        /// </summary>
        public SvrModels.SvrUserIdentifier SvrUser { get; set; }

        public UserLoginHelper(DbAccess.DbFrameworkContext db, SvrModels.SvrUserIdentifier svrUser)
        {
            this.DbContext = db;
            this.SvrUser = svrUser;
        }

        public bool Add(SvrModels.SvrLoginLog svrModel)
        {
            var dbModel = new DbAccess.T_QWF_LoginLog();
            dbModel.AppId = svrModel.AppId;
            dbModel.Ip = svrModel.Ip;
            dbModel.UserName = svrModel.UserName;
            dbModel.LoginTime = DateTime.Now;
            dbModel.LoginStatus = (int)svrModel.LoginStatus;
            dbModel.Remarks = svrModel.Remarks;

            this.DbContext.T_QWF_LoginLog.Add(dbModel);

            return true;

        }
    }
}
