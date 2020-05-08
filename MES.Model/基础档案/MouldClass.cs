using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity
{
    public class MouldClass :ITreeItem
    {
        public int FItemID { get; set; }
        public string FNumber { get; set; }
        public string FName { get; set; }
        public int FLevel { get; set; }
        public bool IsEnd { get; set; }
        public string cMaker { get; set; }
        public DateTime dCreateDate { get; set; }
    }
}
