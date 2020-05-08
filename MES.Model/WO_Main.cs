using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity
{
    public class WO_Main
    {
        public string Guid { get; set; }
        public string WOCode { get; set; }
        public DateTime createDate { get; set; }
        public string cInvCode { get; set; }
        public string cInvName { get; set; }
        public string cInvStd { get; set; }
        public string cComUnitName { get; set; }
        public string maker { get; set; }
        /// <summary>
        /// BOM级次
        /// </summary>
        public string grade { get; set; }
        public decimal iQuantity { get; set; }
        public int MCardCount { get; set; }
        public decimal MCardQuantity { get; set; }

        public List<WO_Details> Detials = new List<WO_Details>();

    }
}
