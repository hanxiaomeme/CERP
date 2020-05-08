using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LanyunMES.UI
{
    using Business;
    using Entity;
    using Component;

    public partial class FmMdyPwd : Form
    {
        public FmMdyPwd()
        {
            InitializeComponent();
        }

        UserService business = new UserService();

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtNewPwd.Text.Trim() == "")
            {
                MsgBox.ShowInfoMsg("�����벻��Ϊ�գ�");
            }
            else if (this.txtNewPwd.Text.Trim() != this.txtConfirmNewPwd.Text.Trim())
            {
                MsgBox.ShowErrMsg2("����ȷ�ϴ���", "�޸�����");
            }
            else if (business.Login(Information.UserInfo.UserName) == null)
            {
                MsgBox.ShowErrMsg2("ԭ�������", "�޸�����");
                this.txtOldPwd.Focus();
            }
            //else
            //{
            //    try
            //    {
            //        if (userBll.ModifyPwd(Information.UserInfo.cUser_Id, txtNewPwd.Text.Trim()) > 0)
            //        {
            //            MsgBox.ShowInfoMsg("�޸ĳɹ���");
            //            this.Close();
            //        }
            //        else
            //        {
            //            MsgBox.ShowInfoMsg("�޸�����ʧ�ܣ�");
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MsgBox.ShowInfoMsg(ex.Message);
            //    }
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}