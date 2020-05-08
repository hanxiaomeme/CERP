using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QWF.CRM.WebApp.Areas.Sales.Models
{
    public class UI_UserField
    {
        public int Id { get; set; }
        public string ListType { get; set; }
        public string TableCode { get; set; }
        public string FieldCode { get; set; }
        public int StyleWidth { get; set; }
        public int SortId { get; set; }
        public string StyleCss { get; set; }
        public string TitleName { get; set; }
        public string FieldFormatter { get; set; }
        public string FormatterType { get; set; }
        public string FieldType { get; set; }
        public int Checkbox { get; set; }
        public int IsHide { get; set; }
    }
}