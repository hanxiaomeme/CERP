using System;
using System.Collections.Generic;

namespace LanyunMES.Entity
{
    public partial class Role
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleID { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string FNote { get; set; }
 
    }
}
