using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QWF.Framework.Sites.Areas.QWebFramework.Models
{
    public class LeftMenuTree
    {
        public int MenuId { get; set; }
        public int ParentId { get; set; }
        public string MenuName { get; set; }
        public string DefaultUrl { get; set; }
        public string IconCls { get; set; }
        public int Target { get; set; }
    }
}