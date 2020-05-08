using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace LanyunMES.Entity
{
    public partial class User
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        public int FDetpID { get; set; }

        /// <summary>
        /// 是否停用
        /// </summary>
        public bool IsStop { get; set; } = false;

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime FCreateDate { get; set; }

    }
}

