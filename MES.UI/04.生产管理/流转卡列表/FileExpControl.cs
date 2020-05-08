using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanyunMES.Entity;
using System.IO;
using Common;
using System.Diagnostics;
using LanyunMES.DAL;
using DevExpress.XtraGrid.Views.Grid;
using DevExpressUtility;

namespace LanyunMES.UI
{
    public partial class FileExpControl : UserControl
    {
        public FileExpControl(string cardNo)
        {
            InitializeComponent();
            this.CardNo = cardNo;
            this.Load += FmLoad;
        }


        private string basePath, curPath;


        public string CardNo { get; private set; }

        List<FileInformaion> filesList = new List<FileInformaion>();


        private void InitGrid(GridView Grid)
        {
            Grid.OptionsBehavior.AutoPopulateColumns = false;
            Grid.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;

            GridViewHelper.AddColumn(Grid, "FileName", "文件名称", readOnly: true);
            GridViewHelper.AddColumn(Grid, "FileExt", "类型", readOnly: true);

            var col = GridViewHelper.AddColumn(Grid, "FileSize", "文件大小", readOnly: true);
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n2} KB";

            col = GridViewHelper.AddColumn(Grid, "FileMdyDate", "修改日期", readOnly: true);
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
        }

        private void FmLoad(object sender, EventArgs e)
        {
            this.InitGrid(GridFile);

            var dal = new MCardDAL();

            var modInfo = dal.GetMomRow(CardNo);

            var cardM = dal.GetCardMain(CardNo);

            string fldr = cardM.cInvCode.Substring(0, 4) + modInfo.cInvCode.Substring(2);

            basePath = Information.FileServerInfo.FtpAddress + "\\" + modInfo.cInvCode + "\\" + fldr;

            this.gridControl1.DataSource = this.GetFileList(basePath);

            this.GridFile.DoubleClick += new EventHandler(new Action<object, EventArgs>((x, y) =>
            {
                var curfile = GridFile.GetFocusedRow() as FileInformaion;
                if (curfile.FileExt == "文件夹")
                {
                    this.curPath = curfile.FileFullName;
                    this.gridControl1.DataSource = this.GetFileList(curPath);
                }
                else
                {
                    ProcessStartInfo info = new ProcessStartInfo();
                    info.WorkingDirectory = basePath;
                    info.FileName = curfile.FileFullName;
                    Process.Start(info);
                }
            }));
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            if (GridFile.FocusedRowHandle < 0) return;

            var curfile = GridFile.GetFocusedRow() as FileInformaion;

            if (curfile.FileExt == "文件夹") return;

            var sdg = new SaveFileDialog();
            sdg.FileName = curfile.FileName;

            if (sdg.ShowDialog() == DialogResult.OK)
            {
                var sourcePath = curfile.FileFullName;
                File.Copy(sourcePath, sdg.FileName);
            }
        }


        private void BtnReturn_Click(object sender, EventArgs e)
        {
            if (curPath != basePath)
            {
                int i = curPath.LastIndexOf("\\");
                curPath = curPath.Substring(0, i);
                this.gridControl1.DataSource = GetFileList(curPath);
            }
        }



        private List<FileInformaion> GetFileList(string path)
        {
            var serInfo = Information.FileServerInfo;

            if (FileHelper.ConnectState(serInfo.FtpAddress, serInfo.FtpUserId, serInfo.FtpPassword))
            {
                if (Directory.Exists(path))
                {
                    List<FileInformaion> ls = new List<FileInformaion>();

                    var files = FileHelper.GetRemoteFile(path, serInfo.FtpUserId, serInfo.FtpPassword);

                    foreach (var file in files)
                    {
                        var finfo = new FileInformaion()
                        {
                            FileName = file.Name,
                            FileFullName = file.FullName,
                            FileExt = file.Extension,
                            FileSize = file.Length / 1024,
                            FileCreateDate = file.CreationTime,
                            FileMdyDate = file.LastWriteTime
                        };

                        ls.Add(finfo);
                    }

                    DirectoryInfo folder = new DirectoryInfo(path);

                    var dics = folder.GetDirectories();

                    foreach (var dic in dics)
                    {
                        var finfo = new FileInformaion()
                        {
                            FileName = dic.Name,
                            FileFullName = dic.FullName,
                            FileExt = "文件夹",
                            FileSize = null,
                            FileCreateDate = dic.CreationTime,
                            FileMdyDate = dic.LastWriteTime
                        };

                        ls.Add(finfo);
                    }

                    curPath = path;
                    return ls;
                }
            }

            return null;
        }
    }
}
