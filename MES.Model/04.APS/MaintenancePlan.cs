using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity
{
    public class MaintenancePlan
    {
        public string guid { get; set; }
        public int EQId { get; set; }
        public string cCode { get; set; }
        public string cName { get; set; }
        public bool bClass { get; set; } = false;
        public string bClassDesc { get; set; }
        public string cMaker { get; set; }
        public DateTime dMakeDate { get; set; }
        public string cModifier { get; set; }
        public DateTime dModifyDate { get; set; }
        public DataTable DtBody { get; set; }
    }
}
