using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanyunMES.Entity
{
    /// <summary>
    /// 金额权限
    /// </summary>
    public class Auth_Data
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int AutoID { get; set; }

        /// <summary>
        /// TranType
        /// </summary>
        public int FTranType { get; set; }
  
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 金额权限
        /// </summary>
        public bool FMoneyAuth { get; set; } = false;
    }
}
