using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.Model
{
    public class Role
    {
        public Role()
        {
            this.UserRole = new List<UserRole>();
            this.RoleMenu = new List<RoleMenu>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Remark { get; set; }
        public List<UserRole> UserRole { get; set; }
        public List<RoleMenu> RoleMenu { get; set; }
    }
}
