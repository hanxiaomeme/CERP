using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QWF.CRM.WebApp.Areas.QCRMSetting.Models
{
    public class RoleInQueryCategory
    {
        public string RoleCode { get; set; }
        /// <summary>
        /// 分类ID
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// 父ID
        /// </summary>
        public int ParentId { get; set; }
        
    }
}