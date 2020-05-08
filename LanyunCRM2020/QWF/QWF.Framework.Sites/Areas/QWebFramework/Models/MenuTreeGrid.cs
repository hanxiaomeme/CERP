using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QWF.Framework.Sites.Areas.QWebFramework.Models
{
    public class MenuTreeGrid:Web.UI.BaseTreeNode
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string CreateTime { get; set; }
        public string UpdateTime { get; set; }

    }
}