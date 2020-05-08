using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QWF.Framework.Sites.Areas.QWebFramework.Models
{
    public class ConfigTreeGrid:Web.UI.BaseTreeNode
    {
        public int ConfigId { get; set; }
        public int ParentId { get; set; }
        public string ConfigName { get; set; }
        public string ConfigCode { get; set; }
        public string ConfigValue { get; set; }
        public string ValueType { get; set; }
        public string Remarks { get; set; }
        public string CreateTime { get; set; }
        public string UpdateTime { get; set; }
    }
}