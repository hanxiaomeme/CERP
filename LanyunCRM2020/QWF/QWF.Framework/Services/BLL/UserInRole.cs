using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Services.BLL
{
    internal class UserInRole
    {
        private DbAccess.T_QWF_UserInRole dbModel;
        private RoleHelper helper;

        public UserInRole(DbAccess.T_QWF_UserInRole dbModel, RoleHelper helper)
        {
            this.dbModel = dbModel;
            this.helper = helper;
        }

        public int GetId()
        {
            return this.dbModel.Id;
        }
        public void Deleted()
        {
            this.helper.DbContext.T_QWF_UserInRole.Remove(dbModel);
        }


    }
}
