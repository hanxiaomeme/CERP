using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Services.SvrModels
{
    /// <summary>
    /// 机构模型
    /// </summary>
    public class SvrOrgInfo
    {
        /// <summary>
        /// 机构ID
        /// </summary>
        public int OrgId { get; set; }
        /// <summary>
        /// 机构编码,如果不传入则系统默认生产18位编号
        /// OG-年-月日-00001
        /// </summary>
        public string OrgCode { get; set; }
        /// <summary>
        /// 机构名称
        /// </summary>
        public string OrgName { get; set; }
        /// <summary>
        /// 机构属性
        /// </summary>
        public OrgAttributeEnum OrgAttribute { get; set; }
        /// <summary>
        /// 是否外部
        /// </summary>
        public int IsOut { get; set; }
        /// <summary>
        /// 父节点
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 机构属性枚举
        /// </summary>
        public enum OrgAttributeEnum
        {
            机构 = 1,
            部门 = 2,
            小组 = 3
        }
    }
}
