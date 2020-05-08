using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MES
{
    public partial class FmPDFView : DevComponents.DotNetBar.OfficeForm
    {
        public FmPDFView(string fileName, string invCode)
        {
            InitializeComponent();
            this._invCode = invCode;
            this._filePath = Environment.GetEnvironmentVariable("TEMP") + "\\" + fileName;
        }

        private string _invCode = "";
        private string _filePath = "";

        private void FmPDFView_Load(object sender, EventArgs e)   
        {
            string ip = "192.168.0.10/PDF Files/" + _invCode;
            Ftp ftp = new Ftp(ip, "ftpuser", "ndf1985");
            if (ftp.SavetoTemp(_filePath) == "")
            {
                this.webBrowser1.Navigate(_filePath);
            }

            //this.webBrowser1.Navigate(@"D:\Desktop\51CTO下载-U810.1EAI使用手册.pdf");
        }


        private void FmPDFView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (File.Exists(_filePath))
            {
                try
                {
                    File.Delete(_filePath);
                }catch { }
            }
        }


        protected string UrlEncode(string url)
        {
            byte[] bs = Encoding.GetEncoding("GB2312").GetBytes(url);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bs.Length; i++)
            {
                if (bs[i] < 128)
                    sb.Append((char)bs[i]);
                else
                {
                    sb.Append("%" + bs[i++].ToString("x").PadLeft(2, '0'));
                    sb.Append("%" + bs[i].ToString("x").PadLeft(2, '0'));
                }
            }
            return sb.ToString();
        }
    }
}
