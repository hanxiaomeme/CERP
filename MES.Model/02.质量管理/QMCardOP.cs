using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity
{
    public class QMCardOP
    {
        public int AutoId { get; set; }
        public string CardNo { get; set; }
        public string OpSeq { get; set; }
        public DateTime dRepDate { get; set; }
        public decimal iQuantity { get; set; }
    }
}
