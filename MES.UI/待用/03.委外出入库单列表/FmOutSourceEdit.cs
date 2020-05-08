using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LanyunMES.UI
{
    using Component;
 
    public partial class FmOutSourceEdit : Form
    {
        public FmOutSourceEdit(DataRow row)
        {
            InitializeComponent();
            this._cCode = row["cCode"].ToString();
            this.richTextBox1.Text = row["cMemo"].ToString();
            this.lbl_cCode.Text += row["cCode"];
            this.lbl_cVenName.Text += row["cVenName"];
        }

        private string _cCode;
        
        private void BtnOK_Click(object sender, EventArgs e)
        {
            #region 保存
            string cMemo = this.richTextBox1.Text;
            try
            {
                new OutSourceDAL().UpdateMemo(_cCode, cMemo);
            }
            catch (Exception ex)
            {
                MsgBox.ShowInfoMsg(ex.Message);
            }

            this.DialogResult = DialogResult.OK; 
            #endregion
        }
    }
}
