using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity
{
    public class BusinessInfo
    {
        public BusinessInfo()
        {

        }

        /// <summary>
        /// 业务模块名称
        /// </summary>
        public string BusiName { get; set; }
        /// <summary>
        /// 业务表类型
        /// </summary>
        public string cType { get; set; }
        /// <summary>
        /// 主表视图名称
        /// </summary>
        public string MView { get; set; }
        /// <summary>
        /// 从表视图名称
        /// </summary>
        public string DView { get; set; }
        /// <summary>
        /// 列表视图名称
        /// </summary>
        public string ListView { get; set; }
        /// <summary>
        /// 主表主键名称
        /// </summary>
        public string MPK { get; set; }
        /// <summary>
        /// 从表主键名称
        /// </summary>
        public string DPK { get; set; }
        /// <summary>
        /// 从表外键名称
        /// </summary>
        public string DFK { get; set; }
        /// <summary>
        /// Tree结构关联字段名称
        /// </summary>
        public string MTLnk { get; set; }

        public string AddDataSP { get; set; }

        public string EditDataSP { get; set; }

        public string DelDataSP { get; set; }

        public string AuditDataSP { get; set; }

        public string UnAuditDataSP { get; set; }
    }
}
