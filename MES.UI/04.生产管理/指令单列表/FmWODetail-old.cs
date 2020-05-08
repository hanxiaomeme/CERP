using System;
using Common.FTP;

namespace LanyunMES.UI
{
    using Model;
    using DAL;
    using U8Ext.Ref;
    using System.Windows.Forms;
    using System.IO;
    using System.Data;
    using Component;
    using DevExpressUtility;
    using Common;
    using DTO;

    public partial class FmWODetail : DevComponents.DotNetBar.OfficeForm
    {
        private FmWODetail()
        {
            InitializeComponent();
            this.Load += FormLoad;
            this.gridDetail.KeyDown += GridViewHelper.KeyDownCellCopy;
            this.gridRouter.KeyDown += GridViewHelper.KeyDownCellCopy;

            BtnSave.Click += Save;
            btn_AddOp.Click += RouterSet;
            btn_AddD.Click += AddDInventory;
            btn_DelD.Click += DelDInventory;
        }

        public FmWODetail(string guid, OpState op = OpState.Update) : this()
        {
            this.guid = guid;
            this.opState = op;
        }

        private string guid;
        private DataView dvRouter, dvDetail;
        private OpState opState = OpState.Browse;        
        private WorkOrderDTO model;
        private WorkOrderDAL dal = new WorkOrderDAL();


        private void FormLoad(object sender, EventArgs e)
        {
            this.InitGrid();
            this.model = dal.Get(guid);           
            this.UIDataBinding();
            this.ReflashUI();

            this.GetFTPFileList(model.WOCode);
        }

        private void InitGrid()
        {
            #region 初始化列
            //GridColumn col = UIGridControl.AddColumn(this.gridView1, "MoCode", "生产订单号", 80);
            //col.Fixed = FixedStyle.Left;
            //col.Summary.Add(DevExpress.Data.SummaryItemType.Count);
            //col.Summary[0].FieldName = "MoCode";
            //col.Summary[0].DisplayFormat = "记录数:{0}";

            //UIGridControl.AddColumn(this.gridView1, "CreateDate", "日期", 80);
            //UIGridControl.AddColumn(this.gridView1, "BomType", "类型", 50);
            //UIGridControl.AddColumn(this.gridView1, "SortSeq", "行号", 40);
            //UIGridControl.AddColumn(this.gridView1, "cInvCode", "存货编码", 150);
            //UIGridControl.AddColumn(this.gridView1, "cInvName", "存货名称", 120);
            //UIGridControl.AddColumn(this.gridView1, "cInvStd", "规格型号", 120);
            //UIGridControl.AddColumn(this.gridView1, "Free1", "头标", 80);

            //col = UIGridControl.AddColumn(this.gridView1, "Qty", "数量", 90);
            //col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //col.AppearanceCell.ForeColor = Color.Red;
            //col.DisplayFormat.FormatString = "n3";
            //var sitem = col.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            //sitem.FieldName = "Qty";
            //sitem.DisplayFormat = "{0:n2}";

            //UIGridControl.AddColumn(this.gridView1, "SoCode", "订单号", 80);
            //UIGridControl.AddColumn(this.gridView1, "iCount", "流转卡数量", 80);

            //UIGridControl.AddColumn(this.gridView1, "Remark", "备注", 150); 
            #endregion
        }

        private void UIDataBinding()
        {      
            UIBinding<WorkOrderDTO>.UIDataBinding(this, model);        //表头数据绑定

            dvRouter = model.WorkOrderRouter.DefaultView;
            dvDetail = model.WorkOrderDetail.DefaultView;

            this.gridControl2.DataSource = dvDetail;
            this.gridControl3.DataSource = dvRouter;

            repositoryItemLookUpEdit1.DataSource = model.WorkOrderRouter;
            repositoryItemLookUpEdit1.KeyMember = "autoid";
            repositoryItemLookUpEdit1.ValueMember = "autoid";
            repositoryItemLookUpEdit1.DisplayMember = "OpName";

            repositoryItemLookUpEdit1.Columns.AddRange(
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                {
                    new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OpSeq", "序号"),
                    new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OpName", "工序")
                });
        }

        private void Save(object sender, EventArgs e)
        {
            SaveCheck();

            gridDetail.UpdateCurrentRow();
            gridRouter.UpdateCurrentRow();

            dal.Save(model);

            this.opState = OpState.Browse;
            this.ReflashUI();
        }

        private void SaveCheck()
        {
            foreach(DataRow r in model.WorkOrderDetail.Rows)
            {
                if(r["routerId"].ToString() == "")
                {
                    throw new Exception("子件尚未选择工序!");
                }
                else if(r["iQty"].ToString() == "")
                {
                    throw new Exception("子件数量尚未填写!");
                }
            }
        }

        private void ReflashUI()
        {
            #region 刷新界面
            if (opState == OpState.Browse || opState == OpState.Audit)
            {
                bar2.Enabled = bar3.Enabled = false;
                btn_upload.Enabled = false;
                btn_delfile.Enabled = false;
                this.gridDetail.OptionsBehavior.Editable = false;
                this.gridDetail.OptionsBehavior.ReadOnly = true;
                this.gridRouter.OptionsBehavior.Editable = false;
                this.gridRouter.OptionsBehavior.ReadOnly = true;
            }
            else
            {
                bar2.Enabled = bar3.Enabled = true;
                btn_upload.Enabled = true;
                btn_delfile.Enabled = true;
                this.gridDetail.OptionsBehavior.Editable = true;
                this.gridDetail.OptionsBehavior.ReadOnly = false;
                this.gridRouter.OptionsBehavior.Editable = true;
                this.gridRouter.OptionsBehavior.ReadOnly = false;
            }

            UIControl.SetStatus(this, this.opState); 
            #endregion
        }


        private void RouterSet(object sender, EventArgs e)
        {
            #region 编辑工艺
            if (gridControl3.DataSource == null || gridRouter.RowCount < 1)
            {
                MsgBox.ShowInfoMsg("当前指令单没有记录!");
                return;
            }

            string woGuid = gridRouter.GetFocusedRowCellValue("guid").ToString();

            FmWORouter frm = new FmWORouter(woGuid);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                gridControl3.DataSource = new WorkOrderDAL().GetRouter(woGuid);
            } 
            #endregion
        }

        private void AddDInventory(object sender, EventArgs e)
        {
            #region 增减子件
            IRefDAL dal = new InventoryDAL(Information.UserInfo.ConnU8);
            RefForm frm = new RefForm(dal);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var r = model.WorkOrderDetail.NewRow();
                r["guid"] = model.Guid;
                r["DInvCode"] = frm.rows[0]["cInvCode"];
                r["DInvName"] = frm.rows[0]["cInvName"];
                r["DInvStd"] = frm.rows[0]["cInvStd"];

                model.WorkOrderDetail.Rows.Add(r);
            } 
            #endregion
        }

        private void DelDInventory(object sender, EventArgs e)
        {
            #region 删除子件
            var r = gridDetail.GetFocusedDataRow();
            model.WorkOrderDetail.Rows.Remove(r); 
            #endregion
        }


        //==============================================================


        private void Btn_Print_Click(object sender, EventArgs e)
        {
            #region 打印
            //string path = Application.StartupPath.Trim('\\');

            //if (System.IO.File.Exists(path + "\\ReportPrint\\派工单.frx"))
            //{
            //    this.report1.Load(path + "\\ReportPrint\\派工单.frx");
            //}
            //this.report1.RegisterData(dtM, "M");
            //this.report1.GetDataSource("M").Enabled = true;
            //this.report1.Show(); 
            #endregion
        }

        private void Btn_Desgin_Click(object sender, EventArgs e)
        {
            #region 打印设计
            //string path = Application.StartupPath.Trim('\\');

            //if (System.IO.File.Exists(path + "\\ReportPrint\\派工单.frx"))
            //{
            //    this.report1.Load(path + "\\ReportPrint\\派工单.frx");
            //}
            //this.report1.RegisterData(dtM, "M");
            //this.report1.GetDataSource("M").Enabled = true;
            //this.report1.Design(); 
            #endregion
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //int modid = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "modid"));
            //CardDAL dal = new CardDAL();
            //dtD = dal.GetHeadList(modid);
            //this.gridControl2.DataSource = dtD;
        }


        private void GetFTPFileList(string path)
        {
            #region 获取FTP文件列表

            var ftp = FtpControl.GetFtp("WorkOrder/");

            if (ftp.FolderExist(model.WOCode))
            {
                ftp = FtpControl.GetFtp("WorkOrder/" + model.WOCode);

                string[] sArray = ftp.GetFileList();

                if (sArray != null && sArray.Length > 0)
                {
                    this.listBox1.Items.Clear();
                    foreach (string s in sArray)
                    {
                        string[] sAry = s.Split(new char[] { ' ' });
                        this.listBox1.Items.Add(s);
                    }
                }
            }

            #endregion
        }

        private bool UpLoadFile(params string[] fileNames)
        {
            #region 上传图纸
            if (fileNames.Length < 1)
            {
                MsgBox.ShowInfoMsg("选择需要上传的文件！");
                return false;
            }

            try
            {

                var ftp = FtpControl.GetFtp("WorkOrder/" + model.WOCode);

                foreach (string fileName in fileNames)
                {
                    FileInfo file = new FileInfo(fileName);

                    if (ftp.FileExist(file.Name))
                    {
                        MsgBox.ShowInfoMsg("FTP已存在相同名称的文件：" + file.Name);
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


        private void btn_upload_Click(object sender, EventArgs e)
        {
            #region 上传
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (UpLoadFile(dlg.FileNames))
                {
                    MsgBox.ShowInfoMsg("OK");
                    this.GetFTPFileList(model.WOCode);
                }
            }
            #endregion
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            #region 下载
            if (listBox1.SelectedItem == null)
            {
                MsgBox.ShowInfoMsg("请选择下载的文档！");
            }
            else
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = (string)listBox1.SelectedItem;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string filePath = dlg.FileName.Substring(0, dlg.FileName.LastIndexOf("\\"));

                    Ftp ftp = FtpControl.GetFtp("WorkOrder/" + model.WOCode);
                    string message = ftp.Download(filePath, (string)listBox1.SelectedItem);
                    if (message == "") message = "下载完成！";
                    MessageBox.Show(message);
                }
            }
            #endregion
        }

        private void btn_delfile_Click(object sender, EventArgs e)
        {
            #region 删除文档
            if (listBox1.SelectedItem == null)
            {
                MsgBox.ShowInfoMsg("请选择要删除的记录！");
            }
            else if (MsgBox.ShowYesNoMsg("确定删除选中文档？") == DialogResult.Yes)
            {
                Ftp ftp = FtpControl.GetFtp("WorkOrder/" + model.WOCode);
                ftp.DeleteFileName((string)listBox1.SelectedItem);
                this.GetFTPFileList(model.WOCode);
            }
            #endregion
        }

        private void btn_Up_Click(object sender, EventArgs e)
        {
            #region 工序上移
            var index = gridRouter.FocusedRowHandle;
            if (index == 0) return;

            var curOpSeq = gridRouter.GetFocusedRowCellValue("OpSeq");
            var preOpSeq = gridRouter.GetRowCellValue(index - 1, "OpSeq").ToString();

            gridRouter.SetRowCellValue(index, "OpSeq", preOpSeq);
            gridRouter.SetRowCellValue(index - 1, "OpSeq", curOpSeq);

            dvRouter.Sort = "OpSeq";

            gridRouter.FocusedRowHandle = index - 1; 
            #endregion
        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            #region 工序下移
            var index = gridRouter.FocusedRowHandle;
            if (index == gridRouter.DataRowCount - 1) return;

            var curOpSeq = gridRouter.GetFocusedRowCellValue("OpSeq");
            var nextOpSeq = gridRouter.GetRowCellValue(index + 1, "OpSeq").ToString();

            gridRouter.SetRowCellValue(index, "OpSeq", nextOpSeq);
            gridRouter.SetRowCellValue(index + 1, "OpSeq", curOpSeq);

            dvRouter.Sort = "OpSeq";

            gridRouter.FocusedRowHandle = index + 1; 
            #endregion
        }

        private void btn_Addr_Click(object sender, EventArgs e)
        {
            #region 工艺增行
            IRefDAL2 dal = new OperationDAL(Information.UserInfo.ConnU8);
            RefForm2 frm = new RefForm2(dal);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var r = dvRouter.AddNew();
                r.BeginEdit();
                r["guid"] = model.Guid;
                r["operationId"] = frm.rows[0]["operationId"];
                r["OpCode"] = frm.rows[0]["OpCode"];
                r["OpName"] = frm.rows[0]["OpName"];
                r["bQuality"] = 0;
                r.EndEdit();

                this.ReSetOrder();
            } 
            #endregion
        }

        private void btn_Delr_Click(object sender, EventArgs e)
        {
            #region 工艺删行
            if (MsgBox.ShowYesNoMsg("是否删除选定行?") == DialogResult.Yes)
            {
                int index = gridRouter.FocusedRowHandle;
                gridRouter.DeleteRow(index);

                this.ReSetOrder();
            } 
            #endregion
        }

        private void repositoryItemLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            var edit = gridDetail.ActiveEditor;

            gridDetail.SetFocusedRowCellValue("routerId", edit.EditValue);
        }


        private void ReSetOrder()
        {
            int i = 10010;
            foreach (DataRowView r in dvRouter)
            {
                r.BeginEdit();
                r["OpSeq"] = i.ToString().Substring(1);
                i = i + 10;
                r.EndEdit();
            }
        }
    }
}
