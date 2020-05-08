using System;
using System.Windows.Forms;
using System.Configuration;

namespace LanyunMES.UI
{
    using Common;
    using Business;
    using Entity;
    using System.Diagnostics;

    public partial class FmLogin : DevComponents.DotNetBar.OfficeForm
    {
        public FmLogin()
        {
            InitializeComponent();

            btnLogin.Click += Login;
            btnSetting.Click += Setting;
            BtnExit.Click += Exit;
            this.Load += FormLoad;
            this.Shown += FormShown;           
        }

        private void FormLoad(object sender, EventArgs e)
        {
            #region 读取配置信息

            this.dtPBusiDate.Value = DateTime.Now.Date;
            this.txtUserName.Text = XMLHelper.GetInnerText("./config.xml", "MESConfig/LoginUser");

            this.CheckVersion();

            #endregion
        }

        private void Login(object sender, EventArgs e)
        {
            #region 登录

            string userName = txtUserName.Text.Trim();
            string password = txtUserPwd.Text.Trim();

            if (string.IsNullOrEmpty(userName))
            {
                throw new Exception("用户名不能为空！");
            }
            //else if(string.IsNullOrEmpty(pwd))
            //{
            //    throw new Exception("密码不能为空！");
            //}
            var user = new UserService().Login(userName);

            if (user == null)
            {
                throw new Exception("用户名或密码错误!");
            }

            Information.UserInfo = user;
            Information.BusiDate = this.dtPBusiDate.Value;
 

            XMLHelper.SetInnerText("./config.xml", "MESConfig/LoginUser", userName);

            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //if(config.AppSettings.Settings["LastLoginUser"] != null)
            //{
            //    config.AppSettings.Settings["LastLoginUser"].Value = user;
            //    config.Save(ConfigurationSaveMode.Modified);
            //}

            this.DialogResult = DialogResult.OK;

            #endregion
        }

        private void Setting(object sender, EventArgs e)
        {
            #region 设置
            new FmAccCfg().ShowDialog(); 
            #endregion
        }

        private void FormShown(object sender, EventArgs e)
        {
            #region 设置焦点
            if (this.txtUserName.Text.Trim() != "")
            {
                this.txtUserPwd.Focus();
            }
            else
            {
                this.txtUserName.Focus();
            } 
            #endregion
        }

        private void Exit(object sender, EventArgs e)
        {
            this.Close();
        }


        private void CheckVersion()
        {
            #region 检查新版本

            //try
            //{
            //    int curVer = Convert.ToInt32(XMLHelper.GetInnerText("Config.xml", "MESConfig/version"));

            //    var verInfo = new Report.ReportClient().GetVersion("PC");
 
            //    if (curVer < verInfo.VerCode)
            //    {
            //        if (MsgBox.ShowYesNoMsg("检查到更新,是否立即更新？\n\n更新说明：\n" + verInfo.VerDesc) == DialogResult.Yes)
            //        {
            //            Process.Start("AutoUpdate.exe");
            //            Environment.Exit(Environment.ExitCode);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("更新检查出错: " + ex.Message);
            //}

            #endregion
        }

    }
}