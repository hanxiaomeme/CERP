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
            #region ί��InitInfo
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
            #region ����ˢ�£���ʼ������

            try
            {
                //�������ݿ������ַ���
                Thread.Sleep(100);
                //DbHelperSQL.SetConnectionStr(Information.UserInfo.ConnStr);
                CollectInfoProc(1);

                //�ļ���������Ϣ
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
            #region ����������
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