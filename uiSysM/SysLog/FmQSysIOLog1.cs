using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NDF
{
    public partial class FmQSysIOLog1 : FmBQ1
    {
        public FmQSysIOLog1()
        {
            InitializeComponent();
        }


        protected override void QCInit()
        {

            BusinessObject bo = new BusinessObject();

            string s = "select distinct username from sysiolog order by username";
            s += ";";
            s += "select distinct hostname from sysiolog order by hostname";

            bo.BusiDataSQL = new string[] { s };
            bo.GetBusiData();

            this.cboBoxUserName.Items.Add("全部");
            if (bo.BusiData.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < bo.BusiData.Tables[0].Rows.Count; i++)
                {
                    this.cboBoxUserName.Items.Add(bo.BusiData.Tables[0].Rows[i][0].ToString());
                }
            }
            this.cboBoxUserName.SelectedIndex = 0;
            this.cboBoxHostName.Items.Add("全部");
            if (bo.BusiData.Tables[1].Rows.Count > 0)
            {
                for (int i = 0; i < bo.BusiData.Tables[1].Rows.Count; i++)
                {
                    this.cboBoxHostName.Items.Add(bo.BusiData.Tables[1].Rows[i][0].ToString());
                }
            }
            this.cboBoxHostName.SelectedIndex = 0;

            string strQCFile = ConfInfo.GetQCFile(this.Name);
            string strValue = DFHelper.IniReadValue("QC", this.txtLDateF.Name, strQCFile);
            if (strValue != "")
                this.txtLDateF.Text = strValue;
            strValue = DFHelper.IniReadValue("QC", this.txtLDateT.Name, strQCFile);
            if (strValue != "")
                this.txtLDateT.Text = strValue;
            strValue = DFHelper.IniReadValue("QC", this.cboBoxUserName.Name, strQCFile);
            if (strValue != "")
                this.cboBoxUserName.SelectedIndex = this.cboBoxUserName.FindString(strValue);
            strValue = DFHelper.IniReadValue("QC", this.cboBoxHostName.Name, strQCFile);
            if (strValue != "")
                this.cboBoxHostName.SelectedIndex = this.cboBoxHostName.FindString(strValue);
        }

        protected override void QCCls()
        {
            this.txtLDateF.Clear();
            this.txtLDateT.Clear();
            this.cboBoxUserName.SelectedIndex = 0;
            this.cboBoxHostName.SelectedIndex = 0;
        }

        protected override void QCSave()
        {
            string strQCFile = ConfInfo.GetQCFile(this.Name);
            DFHelper.IniWriteValue("QC", this.txtLDateF.Name, this.txtLDateF.Text.Trim(), strQCFile);
            DFHelper.IniWriteValue("QC", this.txtLDateT.Name, this.txtLDateT.Text.Trim(), strQCFile);
            DFHelper.IniWriteValue("QC", this.cboBoxUserName.Name, this.cboBoxUserName.Text.Trim(), strQCFile);
            DFHelper.IniWriteValue("QC", this.cboBoxHostName.Name, this.cboBoxHostName.Text.Trim(), strQCFile);
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            string s = "1=1";
            if (this.txtLDateF.Text.Trim() != "")
                s += " and LDate>='" + this.txtLDateF.Text.Trim() + "'";
            if (this.txtLDateT.Text.Trim() != "")
                s += " and LDate<='" + this.txtLDateT.Text.Trim() + "'";
            if (this.cboBoxUserName.SelectedIndex > 0 && this.cboBoxUserName.Text != "")
                s += " and UserName='" + this.cboBoxUserName.Text + "'";
            if (this.cboBoxHostName.SelectedIndex > 0 && this.cboBoxHostName.Text != "")
                s += " and HostName='" + this.cboBoxHostName.Text + "'";

            this.m_strAryQueryCondition = new string[] { s };

            base.btnOK_Click(sender, e);
        }

        private void btnSLDateF_Click(object sender, EventArgs e)
        {
            FmDate f = new FmDate();
            f.DateTimeSelected = this.txtLDateF.Text;
            UICtrl.SetShowStyle(f, sender as Button);
            if(f.ShowDialog() == DialogResult.OK)
            {
                this.txtLDateF.Text = f.DateTimeSelected;
            }
            UICtrl.TextBox_Focus1(this.txtLDateF);
        }

        private void btnSLDateT_Click(object sender, EventArgs e)
        {
            FmDate f = new FmDate();
            f.DateTimeSelected = this.txtLDateT.Text;
            UICtrl.SetShowStyle(f, sender as Button);
            if (f.ShowDialog() == DialogResult.OK)
            {
                this.txtLDateT.Text = f.DateTimeSelected;
            }
            UICtrl.TextBox_Focus1(this.txtLDateT);
        }

        private void txtLDateF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                this.txtLDateF.Text = "";
            }
        }

        private void txtLDateT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                this.txtLDateT.Text = "";
            }
        }
    }
}