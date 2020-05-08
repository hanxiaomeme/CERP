using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LanyunMES.UI
{
    public partial class FmQMCardList : UIBase.FmQBox
    {
        public FmQMCardList()
        {
            InitializeComponent();
            this.dBegin.Value = DateTime.Now.AddDays(-30).Date;
            this.dEnd.Value = DateTime.Now.Date;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            base.GetSqlParams();
            this.DialogResult = DialogResult.OK;
        }
    }
}
