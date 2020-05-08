using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity
{
    public class MaterialRequestSum
    {
        public string Guid { get; set; }

        public string cInvCode { get; set; }

        public string cInvName { get; set; }

        public string cInvStd { get; set; }

        public int OperationId { get; set; }

        public string OpName { get; set; }

        public string cComUnitName { get; set; }

        /// <summary>
        /// 明细汇总数量
        /// </summary>
        public decimal iQuantitySum { get; set; }

        /// <summary>
        /// 合并领料数量
        /// </summary>
        public decimal iQuantityMerge { get; set; }

        /// <summary>
        /// 比例
        /// </summary>
        public decimal iRate { get; set; }
    }
}
