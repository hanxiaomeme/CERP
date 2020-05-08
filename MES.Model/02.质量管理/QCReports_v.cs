using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity 
{
    public class QCReports_v: QCReport
    {
        public string cInvName { get; set; }
        public string cInvStd { get; set; }
        public string cComUnitName { get; set; }
        public string cPosName { get; set; }
        public string U8RDCode { get; set; }
    }
}
