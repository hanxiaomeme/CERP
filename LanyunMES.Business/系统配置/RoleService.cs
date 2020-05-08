using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Business 
{
    using Entity;
    using DAL;
    using Lanyun.DBUtil;

    public class RoleService
    {
        RoleDAL DAL = new RoleDAL();

        public RoleUserDTO GetRoleUserDTO(int roleId)
        {
            return DAL.GetRoleUserDTO(roleId);
        }

        public bool Update(RoleUserDTO role)
        {
            var oRole = DAL.GetRoleUserDTO(role.RoleID);

            var tran = DbHelperSQL.GetTransaction();

            try
            {
                DAL.Update(role, tran);

                oRole.UserList.ForEach(x =>
                {
                    if (role.UserList.Find(n => x.UserID == n.UserID) == null)
                    {
                        DAL.DeleteUser(role.RoleID, x.UserID, tran);
                    }
                });

                role.UserList.ForEach(x =>
                {
                    if (oRole.UserList.Find(n => x.UserID == n.UserID) == null)
                    {
                        DAL.AddUser(role.RoleID, x.UserID, tran);
                    }
                });

                tran.Commit();

                return true;
            }
            catch(Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            
        }
    }
}
