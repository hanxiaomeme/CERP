using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace LanyunMES.UI
{
    using Component;
    using DAL;

    public partial class mAPSSet : DevComponents.DotNetBar.OfficeForm
    {
        public mAPSSet()
        {
            InitializeComponent();
            this.Load += LoadData;

        }

        WorkCalendarDAL dal = new WorkCalendarDAL();

        DataTable dtMain;

        private decimal workhours = 0;

        private void BtnLoadDate_Click(object sender, EventArgs e)
        {

        }

        private void LoadData(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
 

        }

        private void dataGridViewX1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}