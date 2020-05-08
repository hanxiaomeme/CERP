using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity
{
    public class MCard
    {
        /// <summary>
        /// 流转卡号
        /// </summary>
        public string CardNo { get; set; }

        /// <summary>
        /// 工单ID
        /// </summary>
        public string WOGuid { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal iQuantity { get; set; }

        /// <summary>
        /// 制卡人
        /// </summary>
        public string cMaker { get; set; }

        /// <summary>
        /// 制卡日期
        /// </summary>
        public DateTime? dCreateDate { get; set; }

        /// <summary>
        /// 当前工序行号
        /// </summary>
        public string curOpSeq { get; set; }

        /// <summary>
        /// 当前工序
        /// </summary>
        public MCardDetail curOperation { get; set; }

        /// <summary>
        /// 是否完工
        /// </summary>
        public bool bComplete { get; set; }

        /// <summary>
        /// 完工数量
        /// </summary>
        public decimal cmpQuantity { get; set; }

        /// <summary>
        /// 是否已入库
        /// </summary>
        public bool bStockIn { get; set; }

        /// <summary>
        /// U8入库单ID
        /// </summary>
        public string U8RDID { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string cMemo { get; set; }

        /// <summary>
        /// 是否关闭
        /// </summary>
        public bool bClosed { get; set; } = false;

        /// <summary>
        /// 是否暂停
        /// </summary>
        public bool bPause { get; set; } = false;
    }
}
