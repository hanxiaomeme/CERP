using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LanyunMES.UIBase.UIBusiness
{
    using Business;
    public interface IUIItemService
    {
        IItemService business { get; set; }

        void InitGrid(DataGridView grid);
    }
}
