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
    public partial class FmQStock : LanyunMES.UIBase.FmQBox
    {
        public FmQStock()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            base.GetSqlParams();

            this.DialogResult = DialogResult.OK;
        }
    }
}
