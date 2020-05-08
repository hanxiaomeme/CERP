using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;

namespace MES
{
    using MES.Model;
    using MES.DAL;
    using MES.UIBase;

    public partial class FmInvDetail : DevComponents.DotNetBar.OfficeForm
    {
        public FmInvDetail(OpState op, Inventory inv)
        {
            InitializeComponent();
            this.opState = op;
            this.inv = inv;
            this.old_InvCode = inv.InvCode;
        }

        public FmInvDetail(OpState op, InventoryClass invC)
        {
            InitializeComponent();
            this.opState = op;
            this.invC = invC;
        }

        /// <summary>
        /// 代理：界面更新方法
        /// </summary>
        protected delegate void m_dgtUIMethod();
        /// <summary>
        /// 代理：界面更新方法
        /// </summary>
        protected delegate void m_dgtUICursor(Cursor curosr);
        /// <summary>
        /// 当前业务操作(新增，修改，删除)
        /// </summary>
        private OpState opState { get; set; }
        private Inventory inv { get; set; }
        private InventoryClass invC { get; set; }
        private string old_InvCode = null;
        private string invAddress = "";

        private bool _saved = false;
        public bool Saved
        {
            get { return this._saved; }
        }


        private void FmInvDetail_Load(object sender, EventArgs e)
        {
            #region 加载主窗体

            if (inv != null)
            {
                this.invAddress = FTPConfig.FtpAddress + "/" + inv.InvCode;
            }

            SetTextBoxState(gpHead, this.opState);
            SetTextBoxState(gpBody, this.opState);

            this.btn_Edit.Enabled = this.opState == OpState.Browse;
            this.btn_Save.Enabled = !(this.opState == OpState.Browse);


            if (this.opState == OpState.Add)
                this.Text = "新增 - " + this.tab_Main.Text;
            else if (this.opState == OpState.Update)
                this.Text = "编辑 - " + this.tab_Main.Text;

            new Thread(new ThreadStart(this.GetData)).Start();

            #endregion
        }

        private void GetData()
        {
            #region 获取业务数据
            try
            {
                while (!this.IsHandleCreated) { ; }
                this.BeginInvoke(new m_dgtUICursor(this.UICursor), new object[] { Cursors.WaitCursor });
                this.BeginInvoke(new m_dgtUIMethod(this.LoadData));
            }
            catch (Exception ex)
            {
                MsgBox.ShowInfoMsg(ex.ToString());
            }
            finally
            {
                this.BeginInvoke(new m_dgtUICursor(this.UICursor), new object[] { Cursors.Default });
            }
            #endregion
        }

        protected virtual void LoadData()
        {
            #region UI加载数据


            if (this.opState == OpState.Update || opState == OpState.Browse)
            {
                this.txtw_InvCode.Text = inv.InvCode;
                this.txtw_InvName.Text = inv.InvName;
                this.txtw_InvStd.Text = inv.InvStd;
                this.txtr_InvCName.Text = inv.InvCName;
                this.txtr_InvCName.Tag = inv.InvCID;
                this.txtw_BWCS.Text = inv.BWCS;
                this.txtw_CDCS.Text = inv.CDCS;
                this.txtw_CGCD_1.Text = inv.CGCD_1;
                this.txtw_CGCD_2.Text = inv.CGCD_2;
                this.txtw_CGZJ_1.Text = inv.CGZJ_1;
                this.txtw_CGZJ_2.Text = inv.CGZJ_2;
                this.txtw_Chishu.Text = inv.Chishu;
                this.txtw_DDCS.Text = inv.DDCS;
                this.txtw_FLZJ.Text = inv.FLZJ;
                this.txtw_Houdu.Text = inv.Houdu;
                this.txtw_LJDB.Text = inv.LJDB;
                this.txtw_Luoju.Text = inv.Luoju;
                this.txtw_Yachang.Text = inv.Yachang;

                //获取InvCode目录，没有创建对应文件夹
                Ftp ftp = new Ftp(FTPConfig.FtpAddress, FTPConfig.UserName, FTPConfig.Password);
                if (!ftp.FileExist(inv.InvCode))
                {
                    ftp.MakeDir(inv.InvCode);
                }
                else
                {
                    GetFTPFileList(inv.InvCode);
                }
            }
            else if (this.opState == OpState.Add)
            {
                this.txtr_InvCName.Text = invC.InvCName;
                this.txtr_InvCName.Tag = invC.InvCId;
                this.txtw_InvCode.Text = invC.InvCCode + ".";
            }

            #endregion
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            #region 保存
            if (!this.SaveCheck(this.opState))
            {
                return;
            }

            InventoryDAL invDAL = new InventoryDAL();

            if (opState == OpState.Add)
            {
                this.inv = new Inventory();
                this.SetData(inv);
                if (FTPOperate(this.opState))
                {
                    invDAL.Add(inv);
                }
            }
            else if (opState == OpState.Update)
            {
                this.SetData(inv);
                if (FTPOperate(this.opState))
                {
                    invDAL.Update(inv);
                }
            }

            this.opState = OpState.Browse;
            this.SetTextBoxState(gpHead, this.opState);
            this.SetTextBoxState(gpBody, this.opState); 
            this.btn_Save.Enabled = false;
            this.btn_Edit.Enabled = true;
            this.TabCtrl.SelectedTab = tab_files;
            this.invAddress = FTPConfig.FtpAddress + "/" + inv.InvCode;
            this.GetFTPFileList(inv.InvCode);
            this._saved = true;
            #endregion
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            #region 编辑
            this.btn_Save.Enabled = true;
            this.btn_Edit.Enabled = false;
            this.opState = OpState.Update;
            this.SetTextBoxState(gpHead, this.opState);
            this.SetTextBoxState(gpBody, this.opState); 
            #endregion
        }

        private void btn_Upload_Click(object sender, EventArgs e)
        {
            #region 上传
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (UpLoadFile(dlg.FileNames))
                {
                    MsgBox.ShowInfoMsg("OK");
                    this.GetFTPFileList(inv.InvCode);
                }
            } 
            #endregion
        }

        private void btn_Download_Click(object sender, EventArgs e)
        {
            #region 下载
            if (listBoxAdv1.SelectedItem == null)
            {
                MsgBox.ShowInfoMsg("请选择下载的文档！");
            }
            else
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = (string)listBoxAdv1.SelectedItem;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string filePath = dlg.FileName.Substring(0, dlg.FileName.LastIndexOf("\\"));
                     
                    Ftp ftp = new Ftp(invAddress, FTPConfig.UserName, FTPConfig.Password);
                    string message = ftp.Download(filePath, (string)listBoxAdv1.SelectedItem);
                    if (message == "") message = "下载完成！";
                    MessageBox.Show(message);
                }
            } 
            #endregion
        }

        private void btn_DelFile_Click(object sender, EventArgs e)
        {
            #region 删除文档
            if (listBoxAdv1.SelectedItem == null)
            {
                MsgBox.ShowInfoMsg("请选择要删除的记录！");
            }
            else if (MsgBox.ShowYesNoMsg("确定删除选中文档？") == DialogResult.Yes)
            {
                Ftp ftp = new Ftp(invAddress, FTPConfig.UserName, FTPConfig.Password);
                ftp.DeleteFileName((string)listBoxAdv1.SelectedItem);
                this.GetFTPFileList(inv.InvCode);
            } 
            #endregion
        }



        private bool FTPOperate(OpState op)
        {
            Ftp ftp = new Ftp(FTPConfig.FtpAddress, FTPConfig.UserName, FTPConfig.Password);

            try
            {
                if (op == OpState.Add || op == OpState.Browse)
                {
                    if (!ftp.FileExist(inv.InvCode))
                    {
                        ftp.MakeDir(inv.InvCode);
                    }
                }
                else if (op == OpState.Update)
                {
                    if (this.old_InvCode != inv.InvCode)
                    {
                        if (ftp.FileExist(old_InvCode))
                        {
                            ftp.Rename(old_InvCode, inv.InvCode);
                        }
                        else
                        {
                            if (!ftp.FileExist(inv.InvCode))
                            {
                                ftp.MakeDir(inv.InvCode);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowInfoMsg(ex.ToString());
                return false;
            }
            return true;
        }

        private void GetFTPFileList(string InvCode)
        {
            #region 获取FTP文件列表

            string address = FTPConfig.FtpAddress + "/" + InvCode;
            Ftp ftp = new Ftp(address, FTPConfig.UserName, FTPConfig.Password);
            if (ftp.GetFileList() != null && ftp.GetFileList().Length > 0)
            {
                string[] sArray = ftp.GetFileList();
                this.listBoxAdv1.Items.Clear();
                foreach (string s in sArray)
                {
                    this.listBoxAdv1.Items.Add(s);
                }
            } 
            #endregion
        }

        private bool SaveCheck(OpState op)
        {
            #region 保存校验
            if (txtw_InvCode.Text.Trim() == "")
            {
                MsgBox.ShowInfoMsg("图纸编码不能为空!");
                return false;
            }
            else if (txtw_InvName.Text.Trim() == "")
            {
                MsgBox.ShowInfoMsg("图纸名称不能为空!");
                return false;
            }
            else if (txtr_InvCName.Tag == null)
            {
                MsgBox.ShowInfoMsg("图纸分类不能为空！");
                return false;
            }

            InventoryDAL invDAL = new InventoryDAL();

            if (this.opState == OpState.Add)
            {
                if (invDAL.Exists(txtw_InvCode.Text.Trim()))
                {
                    MsgBox.ShowInfoMsg("该编码文档已经存在！");
                    return false;
                }
            }
            else if (this.opState == OpState.Update)
            {
                if (this.inv.InvCode != txtw_InvCode.Text.Trim())
                {
                    if (invDAL.Exists(txtw_InvCode.Text.Trim()))
                    {
                        MsgBox.ShowInfoMsg("该编码文档已经存在！");
                        return false;
                    }
                }
            }
            return true;
            #endregion
        }

        private void SetData(Inventory inv)
        {
            #region 对象属性初始化
            inv.InvCode = this.txtw_InvCode.Text.Trim();
            inv.InvName = this.txtw_InvName.Text.Trim();
            inv.InvStd = this.txtw_InvStd.Text.Trim();
            inv.InvCID = Convert.ToInt32(txtr_InvCName.Tag);

            if (this.opState == OpState.Add)
            {
                inv.createPsn = UserToKen.CurrentUserToKen.UserName;
                inv.createDate = DateTime.Now;
            }
            else if (this.opState == OpState.Update)
            {
                inv.modifyPsn = UserToKen.CurrentUserToKen.UserName;
                inv.modifyDate = DateTime.Now;
            }

            if (txtw_CDCS.Text.Trim() != "")
                inv.CDCS = txtw_CDCS.Text;
            if (txtw_BWCS.Text.Trim() != "")
                inv.BWCS = txtw_BWCS.Text;
            if (txtw_CGCD_1.Text.Trim() != "")
                inv.CGCD_1 = txtw_CGCD_1.Text;
            if (txtw_CGCD_2.Text.Trim() != "")
                inv.CGCD_2 = txtw_CGCD_2.Text;
            if (txtw_CGZJ_1.Text.Trim() != "")
                inv.CGZJ_1 = txtw_CGZJ_1.Text;
            if (txtw_CGZJ_2.Text.Trim() != "")
                inv.CGZJ_2 = txtw_CGZJ_2.Text;
            if (txtw_Chishu.Text.Trim() != "")
                inv.Chishu = txtw_Chishu.Text;
            if (txtw_DDCS.Text.Trim() != "")
                inv.DDCS = txtw_DDCS.Text;
            if (txtw_FLZJ.Text.Trim() != "")
                inv.FLZJ = txtw_FLZJ.Text;
            if (txtw_Houdu.Text.Trim() != "")
                inv.Houdu = txtw_Houdu.Text;
            if (txtw_LJDB.Text.Trim() != "")
                inv.LJDB = txtw_LJDB.Text;
            if (txtw_Luoju.Text.Trim() != "")
                inv.Luoju = txtw_Luoju.Text;
            if (txtw_Yachang.Text.Trim() != "")
                inv.Yachang = txtw_Yachang.Text;
            #endregion
        }       

        private bool UpLoadFile(params string[] fileNames)
        {
            #region 上传图纸
            if (fileNames.Length < 1)
            {
                MsgBox.ShowInfoMsg("选择需要上传的图纸！");
                return false;
            }

            try
            {

                Ftp ftp = new Ftp(invAddress, FTPConfig.UserName, FTPConfig.Password);


                foreach (string fileName in fileNames)
                {
                    FileInfo file = new FileInfo(fileName);

                    if (ftp.FileExist(file.Name))
                    {
                        MsgBox.ShowInfoMsg("FTP已存在相同名称的图纸：" + file.Name);
                        return false;
                    }
                }

                foreach (string fileName in fileNames)
                {
                    FileInfo file = new FileInfo(fileName);
                    string message = ftp.Upload(file.FullName);
                    if (message != "")
                    {
                        MsgBox.ShowInfoMsg(message);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowInfoMsg(ex.ToString());
                return false;
            }

            return true; 

            #endregion
        }


        protected virtual void UICursor(Cursor cursor)
        {
            this.Cursor = cursor;
        }

        /// <summary>
        /// 设置TextBox状态
        /// </summary>
        /// <param name="ctl">TextBox所在control</param>
        protected virtual void SetTextBoxState(Control ctl, OpState op)
        {
            foreach (Control c in ctl.Controls)
            {
                if (c is TextBox)
                {
                    if (op == OpState.Browse)
                    {
                        (c as TextBox).ReadOnly = true;
                        (c as TextBox).BackColor = SystemColors.ControlLight;
                    }
                    else
                    {
                        if (c.Name.Length >= 4 && c.Name.Substring(0, 4).ToLower() == "txtr")
                        {
                            (c as TextBox).ReadOnly = true;
                            c.BackColor = SystemColors.ControlLight;
                        }
                        if (c.Name.Length >= 4 && c.Name.Substring(0, 4).ToLower() == "txtw")
                        {
                            (c as TextBox).ReadOnly = false;
                            c.BackColor = SystemColors.Window;
                        }
                    }
                }
                else if (c is Button)
                {
                    if (op == OpState.Browse)
                    {
                        (c as Button).Enabled = false;
                    }
                    else
                    {
                        (c as Button).Enabled = true;
                    }
                }
            }
        }

        private void btn_PdfPreview_Click(object sender, EventArgs e)
        {
            if (listBoxAdv1.SelectedItem != null)
            {
                string fileName = Convert.ToString(listBoxAdv1.SelectedItem);
                FmPDFView frm = new FmPDFView(fileName, inv.InvCode);
                frm.ShowDialog();
            }
            else
            {
                MsgBox.ShowInfoMsg("请选择需要查看的图纸!");
            }
        }

        public void CodeBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 限制输入特殊字符
            Char[] chs = new Char[] { '/', '<', '>', '\\', '*', '?', ':', '|', '"' };

            foreach (char ch in chs)
            {
                if (e.KeyChar == ch)
                {
                    e.Handled = true;
                }
            } 
            #endregion
        }




    }
}
