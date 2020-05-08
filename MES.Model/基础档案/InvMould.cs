using System;
using System.Data;

namespace MES.Model
{
    public class InvMould
    {
        public string Guid { get; set; }
        public string cInvCode { get; set; }
        public string cInvName { get; set; }
        public string cInvStd { get; set; }
        public string cFree1 { get; set; }
        public string cComUnitName { get; set; }
        public int iState { get; set; } = 0;
        public string cMaker { get; set; }
        public DateTime dCreateDate { get; set; }
        public string cModifier { get; set; }
        public DateTime dModifyDate { get; set; }
        public string cAuditPsn { get; set; }
        public DateTime dAuditDate { get; set; }

        public DataTable dtMouldEq { get; set; }
    }
}
