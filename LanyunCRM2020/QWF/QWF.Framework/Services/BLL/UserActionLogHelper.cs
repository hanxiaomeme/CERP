using QWF.Framework.Services.SvrModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Services.BLL
{
    class UserActionLogHelper
    {
        /// <summary>
        /// 框架DB的上下文
        /// </summary>
        public DbAccess.DbFrameworkContext DbContext { get; private set; }
        /// <summary>
        /// 服务调用者标识
        /// </summary>
        public SvrModels.SvrUserIdentifier SvrUser { get; set; }

        public UserActionLogHelper(DbAccess.DbFrameworkContext db, SvrModels.SvrUserIdentifier svrUser)
        {
            this.DbContext = db;
            this.SvrUser = svrUser;
        }


       
    }
}
