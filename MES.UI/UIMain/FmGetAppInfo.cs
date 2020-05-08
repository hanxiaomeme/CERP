using System;
using System.Threading;
using System.Windows.Forms;

namespace LanyunMES.UI
{
    using Entity;
 
    using Common;
    using Component;

    public partial class FmGetAppInfo : Form
    {
        public FmGetAppInfo()
        {
            InitializeComponent();
        }

        private void FmGetAppInfo_Load(object sender, System.EventArgs e)
        {
            while (!this.IsHandleCreated) { ; }
            Thread t = new Thread(this.GetInfo);
            t.IsBackground = true;
            t.Start();
        }

        private void GetInfo()
        {
            #region 委托InitInfo
            try
            {
                this.BeginInvoke(new m_dgtUICursor(this.UICursor), new object[] { Cursors.WaitCursor });

                Thread.Sleep(500);

                this.BeginInvoke(new Action(this.InitInfo));
            }
            catch (Exception ex)
            {
                MsgBox.ShowInfoMsg(ex.Message + " - GetInfo");
            }
            finally
            {
                this.BeginInvoke(new m_dgtUICursor(this.UICursor), new object[] { Cursors.Default });
            } 
            #endregion
        }

        private void InitInfo()
        {
            #region 界面刷新，初始化数据

            try
            {
                //设置数据库连接字符串
                Thread.Sleep(100);
                //DbHelperSQL.SetConnectionStr(Information.UserInfo.ConnStr);
                CollectInfoProc(1);

                //文件服务器信息
                Thread.Sleep(100);
                //Information.FileServerInfo = new UserManager.UserManagerClient().GetFtpUser();
                CollectInfoProc(2);

                Thread.Sleep(100);

                Close();
            }
            catch (Exception Exp)
            {
                MsgBox.ShowInfoMsg(Exp.Message + "-InitInfo"); 
                Environment.Exit(Environment.ExitCode);
            }

                        

            #endregion
        }
   
        private void CollectInfoProc(int nValue)
        {
            #region 进度条进度
            if (!this.pBarCollectInfo.Visible)
                this.pBarCollectInfo.Visible = true;
            if (nValue <= this.pBarCollectInfo.Maximum && this.pBarCollectInfo.Minimum <= nValue)
                this.pBarCollectInfo.Value = nValue;
            else
                this.pBarCollectInfo.Value = this.pBarCollectInfo.Minimum; 
            #endregion
        }

        protected void UICursor(Cursor cursor)
        {
            this.Cursor = cursor;
        }
    }
}