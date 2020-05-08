using Common;
using System.Windows.Forms;

namespace LanyunMES.UI
{
    public partial class FmAbout : Form
    {
        public FmAbout()
        {
            InitializeComponent();

            try
            {
                this.lblMemSize.Text = "Windows �Ŀ��������ڴ�: " + (WorkDevice.MemoryTotalPhys / 1024).ToString("n0") + " KB";
            }
            catch
            {
                this.lblMemSize.Text = "Windows �Ŀ��������ڴ�: (δ֪)";
            }
        }

        private void btnSysInfo_Click(object sender, System.EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("msinfo32.exe");
            }
            catch { }
        }
    }
}