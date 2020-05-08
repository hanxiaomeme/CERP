using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity
{
    public class MomOrder
    {
        public string Guid { get; set; }
        public int U8modid { get; set; }
        public string MoCode { get; set; }
        public int SortSeq { get; set; }
        public string cInvCode { get; set; }
        public string cInvName { get; set; }
        public string cInvStd { get; set; }
        public string cComUnitName { get; set; }
        public decimal iQuantity { get; set; }
        public string remark { get; set; }

        /// <summary>
        /// 产品子件
        /// </summary>
        public DataTable MomOrders { get; set; }
        /// <summary>
        /// 子件原料
        /// </summary>
        public DataTable MomOrdersDetail { get; set; }
        /// <summary>
        /// 子件工艺
        /// </summary>
        public DataTable MomOrdersRouter { get; set; }
    }
}
