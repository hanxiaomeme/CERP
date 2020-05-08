using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NDF
{
    public partial class FmRole : Eastar.FmB12
    {
        public FmRole()
        {
            InitializeComponent();

            this.m_strModuleName = "Role";
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
            dgColTextBox.HeaderText = "角色编码";
            dgColTextBox.Width = 150;
            dgColTextBox.MappingName = "RoleCode";
            dgColTextBox.NullText = string.Empty;
            dgTS.GridColumnStyles.Add(dgColTextBox);

            dgColTextBox = new DataGridNoActiveTextBoxColumn();
            dgColTextBox.HeaderText = "角色名称";
            dgColTextBox.Width = 350;
            dgColTextBox.MappingName = "RoleName";
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

            this.btnRoleModule.Enabled = this.btnUserList.Enabled = this.dgM.CurrentRowIndex > -1;
        }

        protected override void btnAdd_Click(object sender, EventArgs e)
        {
            FmIURole f = new FmIURole();
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
            FmIURole f = new FmIURole();
            f.OuterFilterSQL = new string[] { "1=1 and " + this.m_strPK + "=" + this.m_dvM[this.dgM.CurrentRowIndex][this.m_strPK] };
            f.OpState = BusiOpState.EditBusiData;
            UICtrl.SetShowStyle(f, 1);
            if (f.ShowDialog() == DialogResult.Yes)
            {
                this.m_bOpState = f.OpState; GetBusiData();
            }
        }

        private void btnRoleModule_Click(object sender, EventArgs e)
        {
            (new FmRoleModule((int)this.m_dvM[this.dgM.CurrentRowIndex]["RoleId"], this.m_dvM[this.dgM.CurrentRowIndex]["RoleName"].ToString())).ShowDialog();
        }

        private void btnUserList_Click(object sender, EventArgs e)
        {
            FmRoleUserList f = new FmRoleUserList();
            f.DataObject = this.m_dvM[this.dgM.CurrentRowIndex].Row;
            f.ShowDialog();
        }
    }
}