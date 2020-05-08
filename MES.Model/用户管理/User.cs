using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.Model
{
    public class User
    {
        public User()
        {
            this.UserRole = new List<UserRole>();
        }
        public string cUser_Id { get; set; }
        public string cUser_Name { get; set; }
        public string cDept { get; set; }
        public string ConnStr { get; set; }
        public List<UserRole> UserRole { get; set; }
    }
}
