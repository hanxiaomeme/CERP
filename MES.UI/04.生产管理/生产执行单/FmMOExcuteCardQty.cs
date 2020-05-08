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


    public partial class FmMOExcuteCardQty : DevComponents.DotNetBar.OfficeForm
    {
        public FmMOExcuteCardQty()
        {
            InitializeComponent();
            this.txt_Qty.KeyPress += UICtrl.TextBox_NumOnly;
        }

        /// <summary>
        /// 流转卡数量
        /// </summary>
        public decimal CardQty { get; private set; }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txt_Qty.Text) || Convert.ToDecimal(txt_Qty.Text) == 0)
            {
                throw new Exception("预计生产数量不能小于等于0!");
            }

            this.CardQty = Convert.ToDecimal(txt_Qty.Text);

            this.DialogResult = DialogResult.OK;
        }
    }
}