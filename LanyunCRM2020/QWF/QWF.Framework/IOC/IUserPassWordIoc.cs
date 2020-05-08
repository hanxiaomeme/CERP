using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QWF.Framework.IOC
{
    /// <summary>
    /// 用户信息注入类
    /// </summary>
    public abstract class IUserPassWordIoc
    {
        /// <summary>
        /// 业务系统自定义用户登录密码加密算法，不实现接口则系统默认按32位小写md5加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public abstract string OtherUserPassWord(string password);
    }
}
