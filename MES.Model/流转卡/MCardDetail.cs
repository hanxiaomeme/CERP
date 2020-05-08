using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity
{
    public class MCardDetail
    {
        /// <summary>
        /// 主键
        /// </summary>		
        public int AutoId { get; set; }

        /// <summary>
        /// 流转卡号
        /// </summary>		
        public string CardNo { get; set; }

        /// <summary>
        /// 工序行号
        /// </summary>		
        public string OpSeq { get; set; }

        /// <summary>
        /// 工单工艺ID
        /// </summary>		
        public int RouterId { get; set; }

        /// <summary>
        /// 工序ID
        /// </summary>		
        public int OperationId { get; set; }

        /// <summary>
        /// 设备ID
        /// </summary>		
        public int EQId { get; set; }

        /// <summary>
        /// 合格数量
        /// </summary>		
        public decimal hgQty { get; set; }

        /// <summary>
        /// 不合格数量
        /// </summary>		
        public decimal bhgQty { get; set; }

        /// <summary>
        /// 操作员
        /// </summary>		
        public string cWorker { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>		
        public DateTime? dStartDate { get; set; }

        /// <summary>
        /// 报工日期
        /// </summary>		
        public DateTime? dRepDate { get; set; }

        /// <summary>
        /// 报工人
        /// </summary>		
        public string cRepPsn { get; set; }

        /// <summary>
        /// 状态
        /// </summary>		
        public int iStatus { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string cMemo { get; set; }
    }
}
