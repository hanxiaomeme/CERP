using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity
{
    /// <summary>
    /// 派工单子表Model
    /// </summary>
    public class WO_Details
    {
        public string WOCode { get; set; }
        public string MoCode { get; set; }
        public int modid { get; set; }
        public int SortSeq { get; set; }
        public string cInvCode { get; set; }
        public string cInvName { get; set; }
        public string cInvStd { get; set; }
        public string dubie { get; set; }

        public int operationId { get; set; }
        public string opName { get; set; }
        public string macNo { get; set; }
        /// <summary>
        /// 派工材质
        /// </summary>
        public string material { get; set; }
        public string JobNumber { get; set; }
        public DateTime PreCmpDate { get; set; } 
        public decimal iQty { get; set; }
    }
}
