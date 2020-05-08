using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QWF.CRM.WebApp.Areas.QCRMSetting.Models
{
    public class QueryCategoryTreeGrid : QWF.Framework.Web.UI.BaseTreeNode
    {
        public string Name { get; set; }
        public string Remarks { get; set; }
        public int ParentId { get; set; }
        public int SortId { get; set; }
        public int QueryCategoryId { get; set; }
        public string CreateTime { get; set; }
        public string UpdateTime { get; set; }
        public string SortField { get; set; }
        public string AscOrDesc { get; set; }
        public string SortFieldName { get; set; }
        public string AndOr { get; set; }
        public string AndOrName { get; set; }
    }

    public class DB_QueryCategory
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ?UpdateTime { get; set; }
        public string AscOrDesc { get; set; }
        public string SortField { get; set; }
        public string TitleName { get; set; }
        public string AndOr { get; set; }
    }

}