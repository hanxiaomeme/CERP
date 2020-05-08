using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Services.BLL.Models
{
    internal class UserToken
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get;set; }
        /// <summary>
        /// MD5(时间戳+ MD5(明文密码)) MD5为小写
        /// </summary>
        public string CilentPassWord { get;set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        public DateTime Time{get;set;}

    }
}
