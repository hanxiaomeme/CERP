using System;
using System.Threading;
using System.Windows.Forms;

namespace LanyunMES.UI
{
    using Common;
    using Component;
 
    public static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //初始化连接字符串

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += AppThreadException;

            if (SystemOption.OnlyOneAppInstance)
            {
                Mutex mutex = new Mutex(false, Application.ProductName + ".exe__ss__" + SystemParam.SoftProjName + "__SolutionOnlyOneInstance100702");
                if (!mutex.WaitOne(1/*Timeout.Infinite*/, true))//在派生类中被重写时，阻塞当前线程，直到当前的 WaitHandle 收到信码
                {
                    MsgBox.ShowExcMsg2("系统已经在运行！", "登录〖管理系统〗");
                    Environment.Exit(Environment.ExitCode);
                }
                //mutex.ReleaseMutex();//释放Mutex对象的所有权
            }

            string connectionString = "server=.;database=lanyun_001;uid=sa;pwd=1;";
            new Business.DBConfigService().SerConnectionString(connectionString);

            using (FmLogin frm = new FmLogin())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    (new FmGetAppInfo()).ShowDialog();
                    Application.Run(new FmMain());
                }
            }
        }

        //处理未处理异常
        private static void AppThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MsgBox.ShowInfoMsg(e.Exception.Message);
        }
    }
}