using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity
{
    public class Mould
    {
        public string MId { get; set; }
        public int MCId { get; set; }
        public string cMCCode { get; set; }
        public string cMCName { get; set; }
        public string cMCode { get; set; }
        public string cMName { get; set; }
        public int Points { get; set; }
        public bool bStop { get; set; } = false;
        public string cMaker { get; set; }
        public DateTime? dCreateDate { get; set; }
        public string cModifier { get; set; }
        public DateTime? dModifyDate { get; set; }
        /// <summary>
        /// 是否成套模具
        /// </summary>
        public bool bGroup { get; set; } = false;

        public DataTable dtEquipment { get; set; } 

    }
}
