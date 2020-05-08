using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity
{
    public class QMItem
    {
        public int QMItemId { get; set; }
        public int QMCId { get; set; }
        public string QMItemCode { get; set; }
        public string QMItemName { get; set; }
        public string QMCCode { get; set; }
        public string QMCName { get; set; }
        public string cMemo { get; set; }
        public string cMaker { get; set; }
        public DateTime dCreateDate { get; set; }

    }
}
