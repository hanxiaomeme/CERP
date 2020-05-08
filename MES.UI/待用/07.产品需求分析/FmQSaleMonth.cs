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
    public partial class FmQSaleMonth : LanyunMES.UIBase.FmQBox
    {
        public FmQSaleMonth()
        {
            InitializeComponent();

            this.intbox_year.Value = DateTime.Now.Year;
            this.intbox_month.Value = DateTime.Now.Month - 1;
            this.intbox_count.Value = 3;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            #region 查询

            base.GetSqlParams();

            this.DialogResult = DialogResult.OK;

            #endregion
        }
    }
}
