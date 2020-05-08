using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity
{
    public interface IItem
    {
        int FItemID { get; set; }

        string FNumber { get; set; }

        string FName { get; set; }
    }
}
