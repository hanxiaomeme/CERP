using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NDF
{
    public partial class FmIURole : LanyunMES.UIBase.FmBIU
    {
        public FmIURole()
        {
            InitializeComponent();

            this.m_strModuleName = "Role";
        }

        protected override void FmB_Load(object sender, EventArgs e)
        {
            base.FmB_Load(sender, e);
        }

        protected override void UIDataBinding(int nFlag)
        {
            this.txtWRoleCode.DataBindings.Add("Text", this.m_dvM, "RoleCode");
            this.txtWRoleName.DataBindings.Add("Text", this.m_dvM, "RoleName");
        }

        protected override void btnAdd_Click(object sender, EventArgs e)
        {
            base.btnAdd_Click(sender, e);

            this.m_dvM[this.dgM.CurrentRowIndex]["IsSysSave"] = 0;
            this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

            this.txtWRoleCode.Focus();
        }

        protected override void btnEdit_Click(object sender, EventArgs e)
        {
            base.btnEdit_Click(sender, e);

            UICtrl.TextBox_Status1(this.txtWRoleCode);
            UICtrl.TextBox_Focus1(this.txtWRoleName);
        }

        protected override void btnSave_Click(object sender, EventArgs e)
        {
            #region ����ҵ������
            if (this.m_bOpState == BusiOpState.AddBusiData || this.m_bOpState == BusiOpState.EditBusiData)
            {
                if (this.m_dvM[this.dgM.CurrentRowIndex]["RoleCode"].ToString().Trim() == "")
                {
                    MsgBox.ShowInfoMsg2("��ɫ���벻��Ϊ�գ�");
                    this.txtWRoleCode.Clear(); this.txtWRoleCode.Focus(); return;
                }

                if (this.m_dvM[this.dgM.CurrentRowIndex]["RoleCode"].ToString().Trim().ToLower() == "admin".ToLower())
                {
                    MsgBox.ShowInfoMsg2("admin ����ʹ�ã�\nadmin Ϊϵͳ���ý�ɫ���룡");
                    this.txtWRoleCode.Clear(); this.txtWRoleCode.Focus(); return;
                }

                if (this.m_dvM[this.dgM.CurrentRowIndex]["RoleName"].ToString().Trim() == "")
                {
                    MsgBox.ShowInfoMsg2("��ɫ���Ʋ���Ϊ�գ�");
                    this.txtWRoleName.Clear(); this.txtWRoleName.Focus(); return;
                }

                #region ����ɫ�����Ƿ��ظ�
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    string s = "select count(*) as RSCount from RoleInfo with(updlock) where ";
                    s += "RoleCode='" + this.m_dvM[this.dgM.CurrentRowIndex]["RoleCode"].ToString().Trim() + "'";
                    s += " and ";
                    s += "RoleId!=" + this.m_dvM[this.dgM.CurrentRowIndex]["RoleId"].ToString();

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
                            MsgBox.ShowInfoMsg2("��ɫ�����Ѿ����ڣ�"); this.txtWRoleCode.Focus(); return;
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
    }
}