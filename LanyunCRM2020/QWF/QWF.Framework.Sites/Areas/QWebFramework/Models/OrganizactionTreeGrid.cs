using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QWF.Framework.Sites.Areas.QWebFramework.Models
{
    public class OrganizactionTreeGrid:QWF.Framework.Web.UI.BaseTreeNode
    {
        public int OrgId { get; set; }
        public int ParentId { get; set; }
        public string OrgCode { get; set; }
        public string OrgName { get; set; }
        
        public int OrgAttribute { get; set; }
        public string OrgAttributeName { get; set; }

        public bool IsOut { get; set; }
        public string IsOutName { get; set; }

        public string CreateTime { get; set; }
        public string UpdateTime { get; set; }
        public string IsSubNode { get; set; }
        public string Remarks { get; set; }
    }
}