using System;

namespace LanyunMES.Entity
{
    public partial class ICTableField
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
        /// 字段名
        /// </summary>
        public string FFieldName { get; set; }

        /// <summary>
        /// 是否新增
        /// </summary>
        public bool bInsert { get; set; }

        /// <summary>
        /// 是否更新
        /// </summary>
        public bool bUpdate { get; set; }

        /// <summary>
        /// 是否必输
        /// </summary>
        public bool bRequired { get; set; }

        /// <summary>
        /// 引用表
        /// </summary>
        public string FRefTable { get; set; }

        /// <summary>
        /// 引用表别名
        /// </summary>
        public string FRefTableAliases { get; set; }

        /// <summary>
        /// 引用表关联字段
        /// </summary>
        public string FRefKeyField { get; set; }

        /// <summary>
        /// 本表关联字段
        /// </summary>
        public string FKeyField { get; set; }

        /// <summary>
        /// 引用字段
        /// </summary>
        public string FRefField { get; set; }

        /// <summary>
        /// JOIN附件条件
        /// </summary>
        public string FConditions { get; set; }

        /// <summary>
        /// 字段说明
        /// </summary>
        public string FCaption { get; set; }

        /// <summary>
        /// 计算字段
        /// </summary>
        public string FFormula { get; set; }
    }
}
