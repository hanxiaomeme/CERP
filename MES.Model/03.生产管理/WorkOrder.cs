using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity 
{
    /// <summary>
    /// 工单主表
    /// </summary>
    public class WorkOrder
    {
        public string Guid { get; set; }

        public string WOCode { get; set; }

        /// <summary>
        /// U8生产订单行ID
        /// </summary>
        public int U8Modid { get; set; }

        public string cInvCode { get; set; }

        public decimal iQuantity { get; set; }

        public string Remark { get; set; }

        public string maker { get; set; }

        public string CreateDate { get; set; }

        /// <summary>
        /// BOM层级 0:顶层
        /// </summary>
        public int Grade { get; set; }

        /// <summary>
        /// 完工数量
        /// </summary>
        public decimal WGQuantity { get; set; }

        public bool bClosed { get; set; } = false;

        public string ClosePsn { get; set; }

        public DateTime? CloseDate { get; set; }
    }
}
