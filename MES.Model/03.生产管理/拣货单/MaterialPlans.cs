using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity
{
    public class MaterialPlans
    {
        public string Guid { get; set; }

        public int AutoId { get; set; }

        public string  CardNo { get; set; }

        /// <summary>
        /// 工序行号
        /// </summary>
        public string OpSeq { get; set; }

        /// <summary>
        /// 工序ID
        /// </summary>
        public int OperationId { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        public string cWhCode { get; set; }

        /// <summary>
        /// 货位编码
        /// </summary>
        public string cPosCode { get; set; }

        public string cInvCode { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal iQuantity { get; set; }

        /// <summary>
        /// 需求单(MaterialRequest) Guid
        /// </summary>
        public string mrGuid { get; set; }


    }
}
