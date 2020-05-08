using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QWF.CRM.WebApp.Areas.Sales.Models
{
    public class UI_ProductItem
    {
        public int ItemId { get; set; }
        public string ProductCode { get; set; }
        public string ItemName { get; set; }
        public int SortId { get; set; }

    }
}