using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace LanyunMES.UI
{
    public partial class FmCreateCardBox : DevComponents.DotNetBar.OfficeForm
    {
        public FmCreateCardBox()
        {
            InitializeComponent();
        }

       public FmCreateCardBox(decimal WOQuantity)
        {
            InitializeComponent();

            this._woQuantity = this.iQuantity = WOQuantity;
            this.lbl_WOQuantity.Text = string.Format("{0:n3}", _woQuantity);
            this.txt_iQuantity.Text = this._woQuantity.ToString("n3");
        }

        private decimal _woQuantity = 0;
     
        /// <summary>
        /// 开卡张数
        /// </summary>
        public int CreateCount { get; private set; } = 1;

        /// <summary>
        /// 每张数量
        /// </summary>
        public decimal iQuantity { get; private set; } = 0;


        private void BtnOK_Click(object sender, EventArgs e)
        {
            if(this.numericUpDown1.Value < 1)
            {
                throw new Exception("开卡数量不能小于1");
            }

            this.DialogResult = DialogResult.OK;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            decimal icount = numericUpDown1.Value;

            if(icount <= 0)
            {
                throw new Exception("开卡数量不能小于等于0 !");
            }

            this.CreateCount = Convert.ToInt32(numericUpDown1.Value);
            this.iQuantity = _woQuantity / icount;

            this.txt_iQuantity.Text = iQuantity.ToString("n3");
        }
    }
}