using System;

namespace LanyunMES.Entity
{
    public partial class ICTableInfo
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int AutoID { get; set; }

        /// <summary>
        /// FTranType
        /// </summary>
        public int FTranType { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        public string FTableName { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        public string FPKName { get; set; }

        /// <summary>
        /// 是否从表
        /// </summary>
        public bool bSlave { get; set; }

        /// <summary>
        /// 是否自增
        /// </summary>
        public bool PK_identity { get; set; } = true;

        /// <summary>
        /// 是否金额权限
        /// </summary>
        public bool bMoneyAuth { get; set; } = false;

    }
}
