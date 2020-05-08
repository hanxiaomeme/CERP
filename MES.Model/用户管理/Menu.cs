using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.Model
{
    public class Menu
    {
        public Menu()
        {
            this.RoleMenu = new List<RoleMenu>();
        }
        public int MenuId { get; set; }
        public string MenuCode { get; set; }
        public string MenuName { get; set; }
        /// <summary>
        /// 权限类别
        /// </summary>
        public string AuthType { get; set; }
        public int iGrade { get; set; }
        public List<RoleMenu> RoleMenu { get; set; }
    }
}
