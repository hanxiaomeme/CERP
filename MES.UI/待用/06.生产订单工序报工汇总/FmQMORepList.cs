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
    public partial class FmQMORep : LanyunMES.UIBase.FmQBox
    {
        public FmQMORep()
        {
            InitializeComponent();
            this.dateTimeInput1.Value = DateTime.Now.AddMonths(-1).Date;
            this.dateTimeInput2.Value = DateTime.Now.Date;
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
