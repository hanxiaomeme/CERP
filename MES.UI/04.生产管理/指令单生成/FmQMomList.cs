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
    using Model.U8;
    using DAL.U8;

    public partial class FmQMomList : LanyunMES.UIBase.FmQBox
    {
        public FmQMomList()
        {
            InitializeComponent();
            this.dBegin.Value = DateTime.Now.AddMonths(-1).Date;
            this.dEnd.Value = DateTime.Now.Date;
            this.Load += FmLoad;
        }

        private void FmLoad(object sender, EventArgs e)
        {
            var list = new MOTypeDAL().GetListAll();          
            cb_MoType.ValueMember = "MoTypeId";
            cb_MoType.DisplayMember = "MoTypeName";
            cb_MoType.DataSource = list;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            base.GetSqlParams();
            this.DialogResult = DialogResult.OK;
        }
    }
}
