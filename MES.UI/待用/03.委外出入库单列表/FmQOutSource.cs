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
    using Common;
    using DAL;
    using U8Ext.Ref;

    public partial class FmQOutSource : LanyunMES.UIBase.FmQBox
    {
        public FmQOutSource()
        {
            InitializeComponent();
            this.dBegin.Value = DateTime.Now.AddMonths(-1).Date;
            this.dEnd.Value = DateTime.Now.Date;
            this.txt_cVenCode.KeyPress += UICtrl.Textbox_ClearTextAndTag;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            #region 查询

            base.GetSqlParams();
            if (Rb_In.Checked)
            {
                this._ListWhere.Add("t1.RDFlag = 1");
            }
            else
            {
                this._ListWhere.Add("t1.RDFlag = 0");
            }
            this.DialogResult = DialogResult.OK; 

            #endregion
        }

        private void Btn_Ref_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Tag.ToString() == "txt_cVenCode")
            {
                IRefDAL dal = new U8Ext.Ref.VendorDAL(DbHelperSQL.GetConnectionStr());
                RefForm frm = new RefForm(dal);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.txt_cVenCode.Text = frm.rows[0]["cVenCode"].ToString();
                }
            }
        }

        private void txt_cVenCode_MouseEnter(object sender, EventArgs e)
        {
            this.Btn_Ref.Visible = true;
            this.Btn_Ref.Tag = (sender as TextBox).Name;
        }
    }
}
