using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.CRM.Models
{
    /// <summary>
    /// 用户类型
    /// </summary>
    public enum PermissionUserType
    {
        /// <summary>
        /// 系统管理员
        /// </summary>
        SystemAdmin = 2,
        /// <summary>
        /// CRM管理员
        /// </summary>
        CrmAdmin=1,
        /// <summary>
        /// 用户
        /// </summary>
        User = 0,
    }

    /// <summary>
    /// 数据范围类型
    /// </summary>
    public enum PermissionDataRange
    {
        /// <summary>
        /// 全部数据
        /// </summary>
        All=2,
        /// <summary>
        /// 本组，按节点
        /// </summary>
        Group=1,
        /// <summary>
        /// 自己
        /// </summary>
        Self=0
    }

}
