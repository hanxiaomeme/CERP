using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity
{
    public interface ITreeItem : IItem
    {
        int FLevel { get; set; }
        bool IsEnd { get; set; }
    }
}
