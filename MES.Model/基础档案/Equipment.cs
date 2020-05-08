using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity
{
    public class Equipment
    {
        public int EQId { get; set; }
        public int EQCId { get; set; }
        public string cEQCCode { get; set; }
        public string cEQCName { get; set; }
        public string cEQCode { get; set; }
        public string cEQName { get; set; }
        //public int operationId { get; set; }
        //public string OpCode { get; set; }
        //public string OpName { get; set; }
        public decimal workHours { get; set; }
        public bool bStop { get; set; } = false;
        public string cMaker { get; set; }
        public DateTime dCreateDate { get; set; }
        public string cModifier { get; set; }
        public DateTime dModifyDate { get; set; }

        public DataTable dtOperations { get; set; }
    }
}
