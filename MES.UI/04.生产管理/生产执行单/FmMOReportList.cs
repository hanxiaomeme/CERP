using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FastReport;

namespace LanyunMES.UI
{
    using Model;
    using DAL;
    using U8Ext.Ref;
    using System.Collections.Generic;
    using Component;
    using DevExpressUtility;

    public partial class FmMOReportList : DevComponents.DotNetBar.OfficeForm 
    {
        public FmMOReportList()
        {
            InitializeComponent();
            this.DGX.KeyDown += GridViewHelper.KeyDownCellCopy;

            this.Load += Fm_Load;
            //查询
            btn_Query.Click += Query;
            //
            cb_showQPnl.CheckedChanged += ShowQueryPanel;
            gridCtrl.MouseDoubleClick += ShowDetail;
            //参照 职员信息
            this.txt_cWorker.ButtonCustomClick += RefPerson;
        }

        private MCardDAL dal = new MCardDAL();

        private List<string> wheres = new List<string>();
        private List<SqlParameter> parameters = new List<SqlParameter>();


        private void Query(object obj, EventArgs e)
        {
            #region 查询
            UIControl.GetSqlParams(group1.Controls, wheres, parameters);
 
            gridCtrl.DataSource = dal.GetRepRecord(wheres, parameters);
            #endregion
        }


        private void InitDGX()
        {
            DGX.OptionsBehavior.AutoPopulateColumns = false;

            GridViewHelper.AddColumn(DGX, "MoCode", "生产订单号", 100);
            GridViewHelper.AddColumn(DGX, "SortSeq", "行号", 50);
            GridViewHelper.AddColumn(DGX, "CardNo", "流转卡号", 90);
            GridViewHelper.AddColumn(DGX, "WOCode", "指令单号", 90);
            GridViewHelper.AddColumn(DGX, "OpSeq", "工序行号", 70);
            GridViewHelper.AddColumn(DGX, "OpName", "工序名称", 90);
            GridViewHelper.AddColumn(DGX, "cEQName", "设备名称", 80);
            GridViewHelper.AddColumn(DGX, "cInvCode", "存货编码", 90);
            GridViewHelper.AddColumn(DGX, "cInvName", "存货名称", 90);
            GridViewHelper.AddColumn(DGX, "cInvStd", "规格型号", 90);
            GridViewHelper.AddColumn(DGX, "cComUnitName", "单位", 40);

            var col = GridViewHelper.AddColumn(DGX, "hgQty", "合格数量", 80);
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n2}";
            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            col.Summary[0].DisplayFormat = "{0:n2}";

            col = GridViewHelper.AddColumn(DGX, "bhgQty", "不合格数量", 80);
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n2}";
            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            col.Summary[0].DisplayFormat = "{0:n2}";

            GridViewHelper.AddColumn(DGX, "cWorker", "操作员", 70);
            GridViewHelper.AddColumn(DGX, "dRepDate", "报工日期", 90);
            GridViewHelper.AddColumn(DGX, "cMemo", "备注", 100);

        }

        private void Fm_Load(object sender, EventArgs e)
        {
            this.dBegin.Value = DateTime.Today.AddMonths(-3);
            this.dEnd.Value = DateTime.Today;

            InitDGX();
        }

        private void ShowDetail(object sender, MouseEventArgs e)
        {
            #region 生成报检单
            int index = DGX.FocusedRowHandle;
            int guid = Convert.ToInt32(DGX.GetDataRow(index)["autoId"]);

            //FmQmReport frm = new FmQmReport(guid);
            // FmMain.NewPageDelegate(frm);
            //frm.ShowDialog();

            #endregion
        }



        //------------------------------------------------------------

        #region 按钮事件

        private void btn_Export_Click(object sender, EventArgs e)
        {
            #region 导出
            try
            {
                GridViewHelper.ExportToXlsx(gridCtrl);
            }
            catch(Exception ex)
            {
                MsgBox.ShowInfoMsg(ex.Message);
            }

            #endregion
        }

        private void btn_Reflash_Click(object sender, EventArgs e)
        {
            #region 刷新
            if (wheres == null || wheres.Count < 1) return;
            gridCtrl.DataSource = dal.GetRepRecord(wheres, parameters);
            #endregion
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowQueryPanel(object sender, EventArgs e)
        {
            #region 显示隐藏查询界面
            int x = gridCtrl.Location.X;
            this.group1.Visible = (sender as CheckBox).Checked;
            if (group1.Visible)
            {
                gridCtrl.Width -= (group1.Width + 5);
                gridCtrl.Location = new Point(group1.Width + 5, gridCtrl.Location.Y);
            }
            else
            {
                gridCtrl.Location = group1.Location;
                gridCtrl.Width += (group1.Width + 5);
            }
            #endregion
        }

        #endregion

 


        //-------------------------------------------------------------

        /// <summary>
        /// 参照 U8职员档案
        /// </summary>
        private void RefPerson(object obj, EventArgs e)
        {
            IRefDAL dal = new HrPersonDAL(Information.UserInfo.ConnU8);
            RefForm frm = new RefForm(dal);
            if(frm.ShowDialog() == DialogResult.OK)
            {
                (obj as TextBox).Text = frm.rows[0]["cPsn_Name"].ToString();
            }
        }

        /// <summary>
        /// 参照 U8供应商档案
        /// </summary>
        private void RefVendor(object obj, EventArgs e)
        {
            IRefDAL dal = new VendorDAL(Information.UserInfo.ConnU8);
            RefForm frm = new RefForm(dal);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                (obj as TextBox).Text = frm.rows[0]["cVenCode"].ToString();
            }
        }
    }
}
