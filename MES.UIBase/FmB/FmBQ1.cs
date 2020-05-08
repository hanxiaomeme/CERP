using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Eastar
{
    public partial class FmBQ1 : Form
    {
        public FmBQ1()
        {
            InitializeComponent();
        }

        protected bool isFullName = false;

        public string[] QueryCondition
        {
            get { return this.m_strAryQueryCondition; }
            set { this.m_strAryQueryCondition = value; }
        }
        protected string[] m_strAryQueryCondition = null;

        /// <summary>
        /// FormLoad ±≥ı ºªØ
        /// </summary>
        protected virtual void QCInit()
        {
        }

        protected virtual void QCCls()
        {
        }

        protected virtual void QCSave()
        {
        }

        protected virtual void btnOK_Click(object sender, EventArgs e)
        {
            QCSave();
            this.DialogResult = DialogResult.OK;
        }

        private void btnClsQC_Click(object sender, EventArgs e)
        {
            QCCls();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; Close();
        }

        protected void FmBQ_Load(object sender, EventArgs e)
        {
            this.pnl0201.Height = 0;
            this.pnl020203.Width = 0;
            this.pnl01.Height = 0;
            QCInit();
        }
    }
}