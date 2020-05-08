using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity
{
    public class WorkCalendar
    {
        public DateTime dDate { get; set; }
        public int iHours { get; set; } = 0;
        public bool bRest { get; set; } = false;
    }
}
