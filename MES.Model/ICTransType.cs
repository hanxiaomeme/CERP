using System;
using System.Collections.Generic;

namespace LanyunMES.Entity
{
    public partial class ICTransType
    {
        /// <summary>
        /// FTranType
        /// </summary>
        public int FTranType { get; set; }

        /// <summary>
        /// 单据说明
        /// </summary>
        public string FCaption { get; set; }

        /// <summary>
        /// 列表查询SQL
        /// </summary>
        public string FListSQL { get; set; }

        public List<ICTableInfo> Tables { get; set; } = new List<ICTableInfo>();
    }
}