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
    public partial class FmQStockDetail : LanyunMES.UIBase.FmQBox
    {
        public FmQStockDetail()
        {
            InitializeComponent();
            this.dChangeDate.Value = DateTime.Now.Date;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            base.GetSqlParams();

            this.DialogResult = DialogResult.OK;
        }
    }
}
