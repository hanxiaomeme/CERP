using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QWF.CRM.WebApp.Areas.Sales.Models
{
    public class UI_Input
    {
        public int Id { get; set; }
        public string FormCode { get; set; }
        public string TableCode { get; set; }
        public string FieldCode { get; set; }
        public string Name { get; set; }
        public string InputName { get; set; }
        public string InputType { get; set; }
        public int IsNotNull { get; set; }
        public int OnlyKey { get; set; }
        public string DefaultValueType { get; set; }
        public string DefaultValue { get; set; }
        public int SortId { get; set; }
        public string DictionaryCode { get; set; }
        public string SelectItemValue { get; set; }
        public int CssHeight { get; set; }
        public int CssWidth { get; set; }
        public string InputDesc { get; set; }
    }
}