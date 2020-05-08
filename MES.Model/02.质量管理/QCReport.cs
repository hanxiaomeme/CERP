using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity 
{
    public class QCReport
    {
        public string GUID { get; set; }
        public string QMCode { get; set; }
        public DateTime dDate { get; set; }
        public string cVenCode { get; set; }
        public string cMaker { get; set; }
        public string cModifier { get; set; }
        public DateTime dModifyDate { get; set; }
        public string cAuditPsn { get; set; }
        public DateTime dAuditDate { get; set; }
        public bool iState { get; set; } = false;
        public string cMemo { get; set; }
    }
}
