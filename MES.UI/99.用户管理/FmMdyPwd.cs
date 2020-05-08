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
                MsgBox.ShowInfoMsg("新密码不能为空！");
            }
            else if (this.txtNewPwd.Text.Trim() != this.txtConfirmNewPwd.Text.Trim())
            {
                MsgBox.ShowErrMsg2("密码确认错误！", "修改密码");
            }
            else if (business.Login(Information.UserInfo.UserName) == null)
            {
                MsgBox.ShowErrMsg2("原密码错误！", "修改密码");
                this.txtOldPwd.Focus();
            }
            //else
            //{
            //    try
            //    {
            //        if (userBll.ModifyPwd(Information.UserInfo.cUser_Id, txtNewPwd.Text.Trim()) > 0)
            //        {
            //            MsgBox.ShowInfoMsg("修改成功！");
            //            this.Close();
            //        }
            //        else
            //        {
            //            MsgBox.ShowInfoMsg("修改密码失败！");
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