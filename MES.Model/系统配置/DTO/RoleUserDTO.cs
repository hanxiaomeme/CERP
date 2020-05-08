using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity
{
    public class RoleUserDTO: Role
    {
        /// <summary>
        /// 用户列表
        /// </summary>
        public List<User> UserList { get; set; } = new List<User>();
    }
}
