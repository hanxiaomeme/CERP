using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QWF.CRM.WebApp.Areas.QCRMSetting.Models
{
    public class DictionaryTreeGrid : QWF.Framework.Web.UI.BaseTreeNode
    {
        public string Code { get; set; }
        public string IsParent { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string ItemValue { get; set; }
        public string ItemValueTypeName { get; set; }
        public int ItemValueType { get; set; }
        public int ItemSort { get; set; }
        public string CreateTime { get; set; }
        public string UpdateTime { get; set; }
    }
}