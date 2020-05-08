using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.Model
{
    public class UserRole
    {
        public int cUser_Id { get; set; }
        public string cUser_Name { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
