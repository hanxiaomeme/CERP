using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity
{
    public class MouldEquipmentInv
    {
        public int AutoId { get; set; }
        public string cInvCode { get; set; }
        public string cInvName { get; set; }
        public string cInvStd { get; set; }
        /// <summary>
        /// 模具GUID
        /// </summary>
        public string MId { get; set; }
        public string cMCode { get; set; }
        public string cMName { get; set; }
        /// <summary>
        /// 穴数
        /// </summary>
        public int Points { get; set; }
        /// <summary>
        /// 设备ID
        /// </summary>
        public int EQId { get; set; }
        public string cEQCode { get; set; }
        public string cEQName { get; set; }
        public bool bClass { get; set; }
        public string bClassDesc { get; set; }
        public int iOrder { get; set; }
        /// <summary>
        /// 节拍
        /// </summary>
        public int iStep { get; set; }
        /// <summary>
        /// 产能
        /// </summary>
        public decimal timeQty { get; set; }
        public string cMemo { get; set; }
    }
}
