using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity
{
    public class MaintenancePlans
    {
        public int AutoId { get; set; }
        public string guid { get; set; }
        public int EQId { get; set; }
        public string cEQCode { get; set; }
        public string cEQName { get; set; }
        public string cEQCCode { get; set; }
        public string cEQCName { get; set; }
        /// <summary>
        /// 日工作效率
        /// </summary>
        public decimal iHours { get; set; }
        public DateTime dDate { get; set; }
        public decimal stopHours { get; set; }
        public decimal workHours { get; set; }
        public string reason { get; set; }
        public string cMaker { get; set; }
        public DateTime dCreateDate { get; set; }

    }
}
