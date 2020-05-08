using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity 
{
    public class MergeCard
    {
        public string Guid { get; set; }
        public string MCCode { get; set; }
        public string cWhCode { get; set; }
        public DateTime dDate { get; set; }
        public string cInvCode { get; set; }
        public string cInvName { get; set; }
        public string cInvStd { get; set; }
        public string cComUnitName { get; set; }
        public decimal iQuantity { get; set; }
        public string cMaker { get; set; }
        public DateTime dCreateDate { get; set; }
        public string cAuditPsn { get; set; }
        public DateTime? dAuditDate { get; set; }
        public string cMemo { get; set; }
        public string U8RDId { get; set; }

        public DataTable dtDetails { get; set; }
    }
}
