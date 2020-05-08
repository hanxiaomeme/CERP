using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NDF
{
    public partial class FmIUUser : Eastar.FmBIU
    {
        public FmIUUser()
        {
            InitializeComponent();

            this.m_strModuleName = "User";
        }

        protected override void FmB_Load(object sender, EventArgs e)
        {
            base.FmB_Load(sender, e);
        }

        protected override void UIDataBinding(int nFlag)
        {
            this.txtWUserName.DataBindings.Add("Text", this.m_dvM, "UserName");
            this.txtSPsnCode.DataBindings.Add("Text", this.m_dvM, "PersonCode");
            this.txtRPsnName.DataBindings.Add("Text", this.m_dvM, "PersonName");
            this.txtRDepCode.DataBindings.Add("Text", this.m_dvM, "DepCode");
            this.txtRDepName.DataBindings.Add("Text", this.m_dvM, "DepName");
            this.txtWMemo.DataBindings.Add("Text", this.m_dvM, "Memo");
        }

        protected override void btnAdd_Click(object sender, EventArgs e)
        {
            base.btnAdd_Click(sender, e);

            this.m_dvM[this.dgM.CurrentRowIndex]["UserState"] = 1;
            this.m_dvM[this.dgM.CurrentRowIndex]["IsSysSave"] = 0;
            this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

            this.txtWUserName.Focus();
        }

        protected override void btnEdit_Click(object sender, EventArgs e)
        {
            base.btnEdit_Click(sender, e);

            this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

            UICtrl.TextBox_Status1(this.txtWUserName);
            UICtrl.TextBox_Focus1(this.txtWUserName);
        }

        protected override void btnSave_Click(object sender, EventArgs e)
        {
            #region 保存数据
            if (this.m_bOpState == BusiOpState.AddBusiData || this.m_bOpState == BusiOpState.EditBusiData)
            {
                if (this.m_dvM[this.dgM.CurrentRowIndex]["UserName"].ToString().Trim() == "")
                {
                    MsgBox.ShowInfoMsg2("用户名不可为空！");
                    if (this.tabCtlMain.SelectedIndex != 1) this.tabCtlMain.SelectedIndex = 1;
                    this.txtWUserName.Clear(); this.txtWUserName.Focus(); return;
                }

                if (this.m_dvM[this.dgM.CurrentRowIndex]["UserName"].ToString().Trim().ToLower() == "admin".ToLower())
                {
                    MsgBox.ShowInfoMsg2("admin 不可使用！\nadmin 为系统内置用户名！");
                    if (this.tabCtlMain.SelectedIndex != 1) this.tabCtlMain.SelectedIndex = 1;
                    this.txtWUserName.Clear(); this.txtWUserName.Focus(); return;
                }

                if (this.m_dvM[this.dgM.CurrentRowIndex]["PersonCode"].ToString().Trim() == "")
                {
                    MsgBox.ShowInfoMsg2("职员不可为空！");
                    if (this.tabCtlMain.SelectedIndex != 1) this.tabCtlMain.SelectedIndex = 1;
                    this.txtSPsnCode.Clear(); this.txtSPsnCode.Focus(); return;
                }

                #region 检查用户编码
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    string s = "select count(*) as RSCount from UserInfo with(updlock) where ";
                    s += "UserName='" + this.m_dvM[this.dgM.CurrentRowIndex]["UserName"].ToString().Trim() + "'";
                    s += " and ";
                    s += "UserId!=" + this.m_dvM[this.dgM.CurrentRowIndex]["UserId"].ToString();

                    BusinessObject bo = new BusinessObject();
                    bo.BusiDataSQL = new string[] { s };

                    bo.GetBusiData();
                    if (bo.BusiMsg[0] == "0")
                    {
                        MsgBox.ShowInfoMsg2(bo.BusiMsg[1]); return;
                    }
                    else if (bo.BusiMsg[0] == "1")
                    {
                        if ((int)bo.BusiData.Tables[0].Rows[0][0] > 0)
                        {
                            MsgBox.ShowInfoMsg2("用户编码已经存在！"); this.txtWUserName.Focus(); return;
                        }
                    }
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
                #endregion
            }

            base.btnSave_Click(sender, e);
            #endregion
        }

        private void btnSUFPsn_Click(object sender, EventArgs e)
        {
            FmRPsn f = new FmRPsn();
            UICtrl.SetShowStyle(f, 2);
            if (DialogResult.OK == f.ShowDialog())
            {
                DataRow dr = (DataRow)f.SelectedInfo[0];
                this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
                this.m_dvM[this.dgM.CurrentRowIndex]["PersonId"] = dr["PersonId"];
                this.m_dvM[this.dgM.CurrentRowIndex]["PersonCode"] = dr["PersonCode"];
                this.m_dvM[this.dgM.CurrentRowIndex]["PersonName"] = dr["PersonName"];
                this.m_dvM[this.dgM.CurrentRowIndex]["DepCode"] = dr["DepCode"];
                this.m_dvM[this.dgM.CurrentRowIndex]["DepName"] = dr["DepName"];
                this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
            }
            UICtrl.TextBox_Focus1(this.txtSPsnCode);
        }
    }
}