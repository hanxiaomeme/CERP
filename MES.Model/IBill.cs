using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity
{
    public interface IBill
    {
        string Guid { get; set; }
        DateTime dDate { get; set; }
        string cMaker { get; set; }
        DateTime? dCreateDate { get; set; }
        string cModifier { get; set; }
        DateTime? dModifyDate { get; set; }
        string cAuditPsn { get; set; }
        DateTime? dAuditDate { get; set; }
    }
}
