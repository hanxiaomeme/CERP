using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity
{
    public class QCReports
    {
        public int AutoId { get; set; }
        public string GUID { get; set; }
        /// <summary>
        /// 采购订单号
        /// </summary>
        public int POIDs { get; set; }
        /// <summary>
        /// 是否检验
        /// </summary>
        public bool bQualify { get; set; }

        public string cInvCode { get; set; }
        public string cFree1 { get; set; }
        /// <summary>
        /// 到货数量
        /// </summary>
        public decimal arrQty { get; set; }
        /// <summary>
        /// 检验数量
        /// </summary>
        public decimal qmQty { get; set; }
        /// <summary>
        /// 是否已检验
        /// </summary>
        public bool bChecked { get; set; }
        /// <summary>
        /// 已检验数量
        /// </summary>
        public decimal haveQmQty { get; set; }
        /// <summary>
        /// 已入库数量
        /// </summary>
        public decimal stockInQty { get; set; }
        /// <summary>
        /// 货位编码
        /// </summary>
        public string cPosCode { get; set; }
        /// <summary>
        /// U8采购入库单ID
        /// </summary>
        public int U8VouchId { get; set; }
    }
}
