using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity 
{
   public  class WorkOrderDetail
    {
        public string Guid { get; set; }

        public int AutoId { get; set; }

        /// <summary>
        /// 指令单工序ID
        /// </summary>
        public int RouterId { get; set; }

        /// <summary>
        /// 材料编码
        /// </summary>
        public string DinvCode { get; set; }

        public string DInvName { get; set; }

        public string DInvStd { get; set; }

        public string DComUnitName { get; set; }

        /// <summary>
        /// 工序ID
        /// </summary>
        public int OperationId { get; set; }

        /// <summary>
        /// 材料需求数量
        /// </summary>
        public decimal iQty { get; set; }

    }
}
