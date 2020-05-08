using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QWF.Framework.Sites.Areas.QWebFramework.Models
{
    public class RoleInMenu
    {

        public string MenuName { get; set; }
        public int MenuId { get; set; }
        public int ParentId { get; set; }
        public int? RoleId { get; set; }
        public int IsSubNode { get; set; }

    }
}