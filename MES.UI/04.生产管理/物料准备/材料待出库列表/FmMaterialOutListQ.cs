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
    using U8Ext.Ref;
    using DAL;

    public partial class FmMaterialOutListQ : LanyunMES.UIBase.FmQBox
    {
        public FmMaterialOutListQ()
        {
            InitializeComponent();
            this.dateBegin.Value = DateTime.Now.AddMonths(-1).Date;
            this.dateEnd.Value = DateTime.Now.Date;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            base.GetSqlParams();
            this.DialogResult = DialogResult.OK;
        }
    }
}
