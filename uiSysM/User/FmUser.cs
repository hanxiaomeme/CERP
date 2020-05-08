using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NDF
{
    public partial class FmUser : Eastar.FmB12
    {
        public FmUser()
        {
            InitializeComponent();

            this.m_strModuleName = "User";
        }

        protected override void FmB_Load(object sender, EventArgs e)
        {
            base.FmB_Load(sender, e);
        }

        #region 表样式
        protected override void InitDGTabStyle()
        {
            this.dgM.TableStyles.Clear();

            DataGridTableStyle dgTS = new DataGridTableStyle();
            dgTS.MappingName = "t";

            DataGridTextBoxColumn dgColTextBox = null;
            DataGridDateTimePickerColumn dgColdtPicker = null;

            dgColTextBox = new DataGridNoActiveTextBoxColumn();
            dgColTextBox.HeaderText = "用户名";
            dgColTextBox.ReadOnly = true;
            dgColTextBox.Width = 150;
            dgColTextBox.MappingName = "UserName";
            dgColTextBox.NullText = string.Empty;
            dgTS.GridColumnStyles.Add(dgColTextBox);

            dgColTextBox = new DataGridNoActiveTextBoxColumn();
            dgColTextBox.HeaderText = "职员编码";
            dgColTextBox.ReadOnly = true;
            dgColTextBox.Width = 100;
            dgColTextBox.MappingName = "PersonCode";
            dgColTextBox.NullText = string.Empty;
            dgTS.GridColumnStyles.Add(dgColTextBox);

            dgColTextBox = new DataGridNoActiveTextBoxColumn();
            dgColTextBox.HeaderText = "职员名称";
            dgColTextBox.ReadOnly = true;
            dgColTextBox.Width = 100;
            dgColTextBox.MappingName = "PersonName";
            dgColTextBox.NullText = string.Empty;
            dgTS.GridColumnStyles.Add(dgColTextBox);

            dgColTextBox = new DataGridNoActiveTextBoxColumn();
            dgColTextBox.HeaderText = "部门编码";
            dgColTextBox.ReadOnly = true;
            dgColTextBox.Width = 100;
            dgColTextBox.MappingName = "DepCode";
            dgColTextBox.NullText = string.Empty;
            dgTS.GridColumnStyles.Add(dgColTextBox);

            dgColTextBox = new DataGridNoActiveTextBoxColumn();
            dgColTextBox.HeaderText = "部门名称";
            dgColTextBox.ReadOnly = true;
            dgColTextBox.Width = 100;
            dgColTextBox.MappingName = "DepName";
            dgColTextBox.NullText = string.Empty;
            dgTS.GridColumnStyles.Add(dgColTextBox);

            dgColTextBox = new DataGridNoActiveTextBoxColumn();
            dgColTextBox.HeaderText = "备注";
            dgColTextBox.ReadOnly = true;
            dgColTextBox.Width = 150;
            dgColTextBox.MappingName = "Memo";
            dgColTextBox.NullText = string.Empty;
            dgTS.GridColumnStyles.Add(dgColTextBox);

            dgColdtPicker = new DataGridDateTimePickerColumn();
            dgColdtPicker.HeaderText = "gDate";
            dgColdtPicker.Width = 0;
            dgColdtPicker.MappingName = "gDate";
            dgColdtPicker.NullText = DateTime.Now.Date.ToShortDateString();
            dgTS.GridColumnStyles.Add(dgColdtPicker);

            this.dgM.TableStyles.Add(dgTS);
        }
        #endregion

        protected override void UIUpd()
        {
            base.UIUpd();

            this.btnAuthMge.Enabled = this.btnCus.Enabled = this.dgM.CurrentRowIndex > -1;
        }

        protected override void btnAdd_Click(object sender, EventArgs e)
        {
            FmIUUser f = new FmIUUser();
            f.OuterFilterSQL = new string[] { "1=1 and " + this.m_strPK + "=-1" };
            f.OpState = BusiOpState.AddBusiData;
            UICtrl.SetShowStyle(f, 1);
            if (f.ShowDialog() == DialogResult.Yes)
            {
                this.m_bOpState = f.OpState; GetBusiData();
            }
        }

        protected override void btnEdit_Click(object sender, EventArgs e)
        {
            FmIUUser f = new FmIUUser();
            f.OuterFilterSQL = new string[] { "1=1 and " + this.m_strPK + "=" + this.m_dvM[this.dgM.CurrentRowIndex][this.m_strPK] };
            f.OpState = BusiOpState.EditBusiData;
            UICtrl.SetShowStyle(f, 1);
            if (f.ShowDialog() == DialogResult.Yes)
            {
                this.m_bOpState = f.OpState; GetBusiData();
            }
        }

        protected override void btnDel_Click(object sender, EventArgs e)
        {
            if (this.m_dvM[this.dgM.CurrentRowIndex]["UserName"].ToString().Trim().ToLower() == UserToKen.CurrentUserToKen.UserName.ToLower())
            {
                MsgBox.ShowInfoMsg2("不可删除当前系统操作用户！"); return;
            }

            base.btnDel_Click(sender, e);
        }

        private void btnAuthMge_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.cntAuthMge.Show((sender as Button), new Point(0, (sender as Button).Height));
        }

        private void cntAuthMge_Popup(object sender, EventArgs e)
        {
            DataRow drM = this.m_dvM[this.dgM.CurrentRowIndex].Row;

            BusinessObject bo = new BusinessObject();
            bo.BusiDataSQL = new string[] { "select * from UserInfo where UserId=" + drM["UserId"] };
            bo.GetBusiData();
            if (bo.BusiMsg[0] == "1" && bo.BusiData.Tables[0].Rows.Count > 0)
            {
                this.miShowAlartList1.Checked = bo.BusiData.Tables[0].Rows[0]["ShowAlarmWnd1"].ToString() == "1";
            }
        }

        private void miRoleMge_Click(object sender, EventArgs e)
        {
            (new FmUserRole((int)this.m_dvM[this.dgM.CurrentRowIndex]["UserId"], this.m_dvM[this.dgM.CurrentRowIndex]["UserName"].ToString())).ShowDialog();
        }

        private void miShowAlartList1_Click(object sender, EventArgs e)
        {
            DataRow drM = this.m_dvM[this.dgM.CurrentRowIndex].Row;

            BusinessObject bo = new BusinessObject();
            bo.BusiDataSQL = new string[] { "update UserInfo set ShowAlarmWnd1=" + (this.miShowAlartList1.Checked ? 0 : 1) + " where UserId=" + drM["UserId"] };
            bo.ExecBusiCmd1();
        }

        private void btnCus_Click(object sender, EventArgs e)
        {
            DataRow drM = this.m_dvM[dgM.CurrentRowIndex].Row;

            BusinessObject bo = new BusinessObject();
            bo.BusiDataSQL = new string[] { "select * from UserRoleInfo where userId = " + drM["UserId"] + " and RoleID in (1,5)" };
            bo.GetBusiData();
            if (bo.BusiMsg[0] == "1" && bo.BusiData.Tables[0].Rows.Count > 0)
            {
                MsgBox.ShowExcMsg2("管理员组用户,默认拥有所有客户权限,无需设置!");
                return;
            }
            FmUserCusInfo frm = new FmUserCusInfo(m_dvM[dgM.CurrentRowIndex]["UserID"].ToString(), m_dvM[dgM.CurrentRowIndex]["UserName"].ToString());
            frm.ShowDialog();
        }
    }
}