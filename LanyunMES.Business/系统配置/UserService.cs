using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Business
{
    using DAL;
    using Entity;

    public class UserService
    {
        UserDAL DAL = new UserDAL();

        public bool HaveMenuAuth(int UserId, int MenuId)
        {
            if(Information.UserInfo.UserName.ToLower() == "admin")
            {
                return true;
            }
            return DAL.HaveMenuAuth(UserId, MenuId);
        }

        public User Login(string userName)
        {
            return DAL.Get(userName);
        }

        public List<User> GetList()
        {
            return DAL.GetList();
        }
    }
}
