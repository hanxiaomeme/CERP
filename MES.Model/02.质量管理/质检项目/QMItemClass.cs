using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity
{
    public class QMItemClass
    {
        public int QMCId { get; set; }
        public string QMCCode { get; set; }
        public string QMCName { get; set; }
        public string cMaker { get; set; }
        public DateTime dCreateDate { get; set; }
    }
}
