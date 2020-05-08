using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.CRM.Utils
{
    public class UserConter
    {
        public static DbAccess.T_QCRM_UserCenter GetUserConfig()
        {
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            var result = QWF.Framework.Web.ResultWebData.Default();

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var userCenter = db.T_QCRM_UserCenter.Where(w => w.UserCode == curUser.CurrentUserCode).FirstOrDefault();

               return userCenter;
                 
            }
        }
    }
}
