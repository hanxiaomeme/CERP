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
    public partial class FmCalendarSet : DevComponents.DotNetBar.OfficeForm
    {
        public FmCalendarSet()
        {
            InitializeComponent();
        }

        public decimal WorkHours { get; private set; }
        public List<string> WeekDays { get; private set; } 

        private void BtnOK_Click(object sender, EventArgs e)
        {
            WeekDays = new List<string>();

            foreach(CheckBox cb in groupBox1.Controls)
            {
                if(cb.Checked)
                {
                    WeekDays.Add(cb.Text);
                }
            }

            this.WorkHours = numHours.Value;

            this.DialogResult = DialogResult.OK;
        }
    }
}