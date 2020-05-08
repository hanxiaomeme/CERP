using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity
{
    public class GroupPlan
    {
        public DateTime dDate { get; set; }
        public string cCode { get; set; }
        public string cMaker { get; set; }
        public string cDepName { get; set; }
        public string cModifier { get; set; }

        public DataRow[] cBody { get; set; }
    }
}
