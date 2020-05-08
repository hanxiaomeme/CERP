using System;
using System.Data;

namespace LanyunMES.Entity
{

    public class QmRecord: NotifyPropertyChanged
    {
        public string Guid { get; set; }
        public string QMRCode { get; set; }
        public DateTime dDate { get; set; }
        public string checkPsn { get; set; }
        public string cVenCode { get; set; }

        public string cMaker { get; set; }
        public string cModifier { get; set; }
        public DateTime dModifyDate { get; set; }
        public string cAuditPsn { get; set; }
        public DateTime dAuditDate { get; set; }
        public int iState { get; set; }
        public int rdId { get; set; }
        public string cMemo { get; set; }

        public DataTable Details = new DataTable();
    }
}
