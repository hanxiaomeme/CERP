using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;

namespace LanyunMES.UI
{
    using DAL;
    using Model;
    using DevExpress.XtraGrid.Columns;
    using Component;
    using DevExpressUtility;
    using DTO;

    public partial class FmWOList : DevComponents.DotNetBar.OfficeForm
    {
        public FmWOList(int modid = 0)
        {
            InitializeComponent();
            this.gridView1.KeyDown += GridViewHelper.KeyDownCellCopy;
            this.gridView1.CellMerge += GridViewHelper.gridviewCellMerge;

            this.InitGrid();
            this.InitGridRouter();

            if (modid != 0)
            {
                _whereList.Add("modid = " + modid);
                this.ExecQuery();
            }
        }

        private DataTable dtM = new DataTable();
        private WorkOrderDTO model = null;
        private WorkOrderDAL dal = new WorkOrderDAL();
        private List<string> _whereList = new List<string>();
        private List<SqlParameter> _paramList = new List<SqlParameter>();

        //当前选中行
        private int currentIndex = 0;

        private void InitGrid()
        {
            #region 初始化列
            this.gridView1.OptionsView.AllowCellMerge = false;

            var col = GridViewHelper.AddColumn(this.gridView1, "WOCode", "指令单号", 120);
            col.Fixed = FixedStyle.Left;
            col.Summary.Add(DevExpress.Data.SummaryItemType.Count);
            col.Summary[0].FieldName = "WOCode";
            col.Summary[0].DisplayFormat = "记录数: {0}";

            GridViewHelper.AddColumn(this.gridView1, "MoCode", "生产订单号", 100);           
            GridViewHelper.AddColumn(this.gridView1, "SortSeq", "行号", 40);
            GridViewHelper.AddColumn(this.gridView1, "cInvCode", "存货编码", 150);
            GridViewHelper.AddColumn(this.gridView1, "cInvName", "存货名称", 120);
            GridViewHelper.AddColumn(this.gridView1, "cInvStd", "规格型号", 120);

            col = GridViewHelper.AddColumn(this.gridView1, "iQuantity", "预计数量", 80);
            col.AppearanceCell.ForeColor = Color.Blue;
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n2}";
            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            col.Summary[0].FieldName = "iQuantity";
            col.Summary[0].DisplayFormat = "{0:n2}";

            GridViewHelper.AddColumn(this.gridView1, "cComUnitName", "单位", 50);
            GridViewHelper.AddColumn(this.gridView1, "grade", "BOM层级", 60);
            GridViewHelper.AddColumn(this.gridView1, "maker", "制单人", 70);
            GridViewHelper.AddColumn(this.gridView1, "createDate", "创建日期", 90);
            GridViewHelper.AddColumn(this.gridView1, "bMemo", "备注", 60);
            GridViewHelper.AddColumn(this.gridView1, "bClosed", "已关闭", 60);
            GridViewHelper.AddColumn(this.gridView1, "ClosePsn", "关闭人", 60);
            GridViewHelper.AddColumn(this.gridView1, "CloseDate", "关闭时间", 120);

            #endregion
        }

        private void InitGridRouter()
        {
            #region 初始化工艺列
            var col = GridViewHelper.AddColumn(this.gridRouter, "cInvCode", "存货编码", 130);
            col.Summary.Add(DevExpress.Data.SummaryItemType.Count);
            col.Summary[0].FieldName = "cInvCode";
            col.Summary[0].DisplayFormat = "记录:{0}";

            GridViewHelper.AddColumn(this.gridRouter, "OpSeq", "序号", 60);
            GridViewHelper.AddColumn(this.gridRouter, "OpName", "工序名称", 80);
            GridViewHelper.AddColumn(this.gridRouter, "cEQName", "设备名称", 90);
            GridViewHelper.AddColumn(this.gridRouter, "CycleTime", "节拍", 80);
            GridViewHelper.AddColumn(this.gridRouter, "bQuality", "是否质检", 70);
            GridViewHelper.AddColumn(this.gridRouter, "cMemo", "备注", 80);

            gridRouter.OptionsView.ColumnAutoWidth = true; 
            #endregion
        }

        private void FmProductOrder_Load(object sender, EventArgs e)
        {
            //this.InitGrid();
            //this.InitGridRouter();
        }

        private void Btn_PrintDesgin_Click(object sender, EventArgs e)
        {
            #region 打印设计

            string path = Application.StartupPath.Trim('\\');
            string filePath = path + "\\ReportPrint\\指令单.frx";

            if (System.IO.File.Exists(filePath))
            {
                report1.Load(filePath);
            }

            this.report1.RegisterData(dtM, "M");
            this.report1.RegisterData(model.WorkOrderRouter, "D");
            this.report1.GetDataSource("M").Enabled = true;
            this.report1.GetDataSource("D").Enabled = true;
            this.report1.Design(); 
            #endregion
        }

        private void Btn_Print_Click(object sender, EventArgs e)
        {
            #region 打印
            string path = Application.StartupPath.Trim('\\');

            string filePath = path + "\\ReportPrint\\指令单.frx";

            if (System.IO.File.Exists(filePath))
            {
                report1.Load(filePath);
            }
            this.report1.RegisterData(dtM, "M");
            this.report1.RegisterData(model.WorkOrderRouter, "D");
            this.report1.GetDataSource("M").Enabled = true;
            this.report1.GetDataSource("D").Enabled = true;
            this.report1.Show();
            #endregion
        }

        private void Btn_Query_Click(object sender, EventArgs e)
        {
            #region 查询
            FmQWOList frm = new FmQWOList();
            frm.LoadSqlParams(this._paramList);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                this._whereList = frm.ListWhere;
                this._paramList = frm.Parameters;


                this.Invoke(new System.Action(()=> 
                {                   
                    WaitFormHelper.ShowWait(this, "表急啊.....");
                }));

                System.Action query = () => { ExecQuery(); };

                new Thread(() =>
                {                 
                    this.Invoke(query);
                }).Start();

                this.Invoke(new Action(WaitFormHelper.CloseWait));
            
            } 
            #endregion
        }

        private void BtnReflash_Click(object sender, EventArgs e)
        {
            #region 刷新
            if (_whereList != null && _whereList.Count > 0)
            {
                this.ExecQuery();
            }
            #endregion
        }

        private void ExecQuery()
        {         
            this.dtM = dal.GetWorkOrderList(_whereList, _paramList);
            this.gridControl1.DataSource = dtM;   
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            //string guid = gridView1.GetFocusedRowCellValue("guid").ToString();
            //FmWODetail frm = new FmWODetail(guid);
            //frm.ShowDialog();

            #region 修改工序
            if (dal.ExistRef(model.Guid))
                throw new Exception("已经生成流转卡,不能修改!");

            FmWORouter frm = new FmWORouter(model.Guid);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                gridControl3.DataSource = dal.GetRouter(model.Guid);
            } 
            #endregion
        }

        private void btnEditDetail_Click(object sender, EventArgs e)
        {
            #region 修改子件

            if (dal.ExistRef(model.Guid))
                throw new Exception("已经生成流转卡,不能修改!");

            FmWODetails frm = new FmWODetails(model.Guid);
            if (frm.ShowDialog() == DialogResult.OK)
            {              
                this.model = dal.Get(model.Guid);
                gridControl2.DataSource = dal.GetDetail(model.Guid);
            }
            #endregion
        }

        private void GetFTPFileList(string path)
        {
            #region 获取FTP文件列表

            this.listBox1.Items.Clear();

            var ftp = FtpControl.GetFtp("WorkOrder/");

            if (ftp.FolderExist(path))
            {
                ftp = FtpControl.GetFtp("WorkOrder/" + path);

                string[] sArray = ftp.GetFileList();

                if (sArray != null && sArray.Length > 0)
                {                 
                    foreach (string s in sArray)
                    {
                        string[] sAry = s.Split(new char[] { ' ' });
                        this.listBox1.Items.Add(s);
                    }
                }
            }

            #endregion
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle > -1)
            {
                this.currentIndex = e.FocusedRowHandle;
                string guid = gridView1.GetFocusedRowCellValue("guid").ToString();
                this.model = dal.Get(guid);

                this.gridControl3.DataSource = model.WorkOrderRouter;
                this.gridControl2.DataSource = model.WorkOrderDetail;

                //this.GetFTPFileList(model.WOCode);
            }
        }

        /// <summary>
        /// 创建流转卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_MoCard_Click(object sender, EventArgs e)
        {
            
             
            if(model.WorkOrderRouter.Rows.Count < 1)
            {
                throw new Exception("当前指令单没有工艺!");
            }

            foreach (DataRow r in model.WorkOrderDetail.Rows)
            {
                if (r["RouterId"].ToString() == "")
                {
                    throw new Exception("有子件尚未分配领用工序!");
                }
            }

            //string WoGuid = gridView1.GetFocusedRowCellValue("guid").ToString();

            //FmCreateMCard frm = new FmCreateMCard(WoGuid);
            //frm.ShowDialog();

            var frm = new FmCreateCardBox(model.iQuantity);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                string woGuid = gridView2.GetFocusedRowCellValue("guid").ToString();
                new MCardDAL().CreateCard(woGuid, frm.CreateCount, frm.iQuantity);

                new FmMCardList(woGuid).ShowDialog();
            }


            //string cMaker = Information.UserInfo.cUser_Name;

            //string cardNo = new MCardDAL().CreateCard(WoGuid, cMaker);

            //MessageBox.Show("已生成流转卡:[" + cardNo + "]");
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            var selectRows = this.gridView1.GetSelectedRows();

            if (selectRows.Length < 1)
            {
                throw new Exception("当前没有选中行!");
            }

            if (MsgBox.ShowYesNoMsg("确定关闭所选指令单?") != DialogResult.Yes) return;

            List<dynamic> cards = new List<dynamic>();

            foreach (int i in this.gridView1.GetSelectedRows())
            {
                cards.Add(new { guid = gridView1.GetDataRow(i)["guid"].ToString() });
            }

            dal.SetClosedStatus(true, Information.UserInfo.cUser_Name, cards.ToArray());

            //刷新
            this.ExecQuery();
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            var selectRows = this.gridView1.GetSelectedRows();

            if (selectRows.Length < 1)
            {
                throw new Exception("当前没有选中行!");
            }

            if (MsgBox.ShowYesNoMsg("确定打开所选指令单?") != DialogResult.Yes) return;

            List<dynamic> cards = new List<dynamic>();

            foreach (int i in this.gridView1.GetSelectedRows())
            {
                cards.Add(new { guid = gridView1.GetDataRow(i)["guid"].ToString() });
            }

            dal.SetClosedStatus(false, null, cards.ToArray());

            //刷新
            this.ExecQuery();
        }

        private void Btn_MoCards_Click(object sender, EventArgs e)
        {
            var handleArray = gridView1.GetSelectedRows();

            StringBuilder sb = new StringBuilder();

            var cardDal = new MCardDAL();

            foreach(int handle in handleArray)
            {
                var guid = gridView1.GetRowCellValue(handle, "guid").ToString();
                var wocode = gridView1.GetRowCellValue(handle, "WOCode").ToString();

                if (dal.ExistRef(guid))
                {
                    sb.Append("指令单:" + wocode + " 已存在流转卡, 不能批量生成!\r\n");
                    continue;
                }

                var model = dal.Get(guid);

                if(model.bClosed)
                {
                    sb.Append("指令单:" + model.WOCode + " 已关闭, 不能创建!\r\n");
                    continue;
                }
                else if(model.WorkOrderRouter.Rows.Count < 1)
                {
                    sb.Append("指令单:" + model.WOCode + " 没有工艺, 创建失败!\r\n");
                    continue;
                }

                foreach (DataRow r in model.WorkOrderDetail.Rows)
                {
                    if (r["RouterId"].ToString() == "")
                    {
                        sb.Append("指令单:" + model.WOCode + " 有子件尚未分配领用工序, 创建失败!\r\n");
                        continue;
                    }
                }

                cardDal.CreateCard(model.Guid, 1, model.iQuantity);
            }
            if (sb.ToString() == "") sb.Append("创建成功!");

            MsgBox.ShowInfoMsg(sb.ToString());
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            GridViewHelper.ExportToXlsx(gridControl1);
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if(e.DisplayText == "Y")
            {
                e.Appearance.BackColor = Color.YellowGreen;
            }
        }
    }
}
