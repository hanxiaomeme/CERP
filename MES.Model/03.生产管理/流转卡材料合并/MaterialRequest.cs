using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity
{
 
    public class MaterialRequest
    {
        /// <summary>
        /// 合并单GUID
        /// </summary>
        public string MergeGuid { get; set; }

        public string Guid { get; set; }

        /// <summary>
        /// 是否合并
        /// </summary>
        public bool bMerge { get; set; } = false;

        /// <summary>
        /// 工序ID
        /// </summary>
        public int operationId { get; set; }

        /// <summary>
        /// 工序名称
        /// </summary>
        public string OpName { get; set; }

        /// <summary>
        /// 流转卡材料行ID
        /// </summary>
        public int CardChildId { get; set; }

        /// <summary>
        /// 流转卡号
        /// </summary>
        public string CardNo { get; set; }

        /// <summary>
        /// 工序行号
        /// </summary>
        public string OpSeq { get; set; }

        /// <summary>
        /// 产品编码
        /// </summary>
        public string cInvCode { get; set; }
        public string cInvName { get; set; }
        public string cInvStd { get; set; }
        public string cComUnitName { get; set; }

        /// <summary>
        /// 领料需求数量
        /// </summary>
        public decimal iQuantity { get; set; }

        /// <summary>
        /// 原始需求数量(如果合并领料)
        /// </summary>
        public decimal? iReqQuantity { get; set; }

        /// <summary>
        /// 是否已经生成拣货单
        /// </summary>
        public bool bMP { get; set; } = false;

        /// <summary>
        /// 分摊比例
        /// </summary>
        public decimal iRate { get; set; }

        /// <summary>
        /// 请求日期
        /// </summary>
        public DateTime dCreateDate { get; set; }

        /// <summary>
        /// 是否关闭
        /// </summary>
        public bool bClosed { get; set; } = false;

        /// <summary>
        /// 关闭日期
        /// </summary>
        public DateTime? dCloseDate { get; set; }

        /// <summary>
        /// 关闭人
        /// </summary>
        public string ClosePsn { get; set; }

    }
}
