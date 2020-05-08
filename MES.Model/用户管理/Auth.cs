using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.Model
{
 
    public enum Auth
    {
        /// <summary>
        /// 查看
        /// </summary>
        Browse,
        /// <summary>
        /// 新增
        /// </summary>
        Add,
        /// <summary>
        /// 修改
        /// </summary>
        Modify,
        /// <summary>
        /// 删除
        /// </summary>
        Del,
        /// <summary>
        /// 审核
        /// </summary>
        Audit,
        /// <summary>
        /// 弃审
        /// </summary>
        UnAudit,
        /// <summary>
        /// 打印
        /// </summary>
        Print,
        /// <summary>
        /// 导出
        /// </summary>
        Export
    }
}
