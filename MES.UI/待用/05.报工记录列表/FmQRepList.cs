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
    public partial class FmQRepList : LanyunMES.UIBase.FmQBox
    {
        public FmQRepList()
        {
            InitializeComponent();
            this.dBegin.Value = DateTime.Now.AddDays(-1).Date;
            this.dEnd.Value = DateTime.Now.Date;
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
