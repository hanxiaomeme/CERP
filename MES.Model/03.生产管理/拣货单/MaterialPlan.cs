using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity 
{
    public class MaterialPlan 
    {
        public string Guid { get; set; }

        /// <summary>
        /// 拣货单号
        /// </summary>
        public string MPCode { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        public string cWhCode { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        public string cWhName { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime dDate { get; set; }

        /// <summary>
        /// 部门编码
        /// </summary>
        public string cDepCode { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string cDepName { get; set; }

        /// <summary>
        /// 出库类别编码
        /// </summary>
        public string cRdCode { get; set; }

        /// <summary>
        /// 出库类别名称
        /// </summary>
        public string cRdName { get; set; }

        /// <summary>
        /// 制单人
        /// </summary>
        public string cMaker { get; set; }

        /// <summary>
        /// 制单日期
        /// </summary>
        public DateTime? dCreateDate { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public string cModifier { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? dModifyDate { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public string cAuditPsn { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? dAuditDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string cMemo { get; set; }

        /// <summary>
        /// U8材料出库单ID
        /// </summary>
        public string U8RDId { get; set; }

        /// <summary>
        /// U8材料出库单号
        /// </summary>
        public string U8RDCode { get; set; }

        public DataTable dtDetails { get; set; }

    }
}
