using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using FastReport;

namespace LanyunMES.UI
{
    using Model;
    using U8Ext.Ref;
    using Component;
    using DevExpressUtility;

    public partial class POList : Form, IFView<POListController>
    {
        public POList()
        {
            InitializeComponent();
            this.DGX.KeyDown += GridViewHelper.KeyDownCellCopy;

            this.Text = pnl_title.Text;
            
            this.Load += Fm_Load;
            btn_Query.Click += Query;
            btn_AddQmReport.Click += AddQmReport;
            txt_vendor.ButtonCustomClick += RefVendor;
            cb_showQPnl.CheckedChanged += ShowQueryPanel;
        }

        public POListController Controller { get; private set; } = new POListController();
        private List<string> wheres = new List<string>();
        private List<SqlParameter> parameters = new List<SqlParameter>();


        private void Query(object obj, EventArgs e)
        {
            #region 查询
            UIControl.GetSqlParams(group1.Controls, wheres, parameters);
 
            gridCtrl.DataSource = Controller.GetTableList(wheres.ToArray(), parameters.ToArray());
            #endregion
        }

        private void AddQmReport(object obj, EventArgs e)
        {
            #region 生成报检单
            var model = Controller.GetQmModel(this.DGX);
            FmQmReport frm = new FmQmReport(model);
            //FmMain.NewPageDelegate(frm);
            frm.ShowDialog();
            this.btn_Reflash_Click(null, null);
            #endregion
        }

        private void RefVendor(object obj, EventArgs e)
        {
            #region 参照 U8供应商档案
            IRefDAL dal = new VendorDAL(Information.UserInfo.ConnU8);
            RefForm frm = new RefForm(dal);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                (obj as TextBox).Text = frm.rows[0]["cVenCode"].ToString();
            } 
            #endregion
        }

        private void InitDGX()
        {
            DGX.OptionsBehavior.AutoPopulateColumns = false;

            GridViewHelper.AddColumn(DGX, "cPOID", "采购订单号", 90);
            GridViewHelper.AddColumn(DGX, "ivouchrowno", "行号", 40);
            GridViewHelper.AddColumn(DGX, "dPODate", "日期", 80);
            GridViewHelper.AddColumn(DGX, "cVenName", "供应商名称", 120);
            GridViewHelper.AddColumn(DGX, "cAuditDate", "审核日期", 80);
            GridViewHelper.AddColumn(DGX, "cInvCode", "存货编码", 90);
            GridViewHelper.AddColumn(DGX, "cInvName", "存货名称", 90);
            GridViewHelper.AddColumn(DGX, "cInvStd", "规格型号", 90);
            
            var col = GridViewHelper.AddColumn(DGX, "iQuantity", "数量", 90);
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n2}";
            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            col.Summary[0].DisplayFormat = "{0:n2}";

            GridViewHelper.AddColumn(DGX, "cComUnitName", "单位", 40);

            col = GridViewHelper.AddColumn(DGX, "iTaxPrice", "单价", 80);
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n2}";

            col = GridViewHelper.AddColumn(DGX, "iSum", "价税合计", 90);
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n2}";
            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            col.Summary[0].DisplayFormat = "{0:n2}";

            col = GridViewHelper.AddColumn(DGX, "arrQty", "到货数量", 90);
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n2}";
            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            col.Summary[0].DisplayFormat = "{0:n2}";

            col = GridViewHelper.AddColumn(DGX, "iReceivedQTY", "U8累计入库", 90);
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n2}";
            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            col.Summary[0].DisplayFormat = "{0:n2}";

            GridViewHelper.AddColumn(DGX, "cMaker", "制单人", 70);

        }

        private void Fm_Load(object sender, EventArgs e)
        {
            this.dBegin.Value = DateTime.Today.AddMonths(-3);
            this.dEnd.Value = DateTime.Today;

            InitDGX();
        }

        private void ShowDetail(object sender, MouseEventArgs e) { }



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
            gridCtrl.DataSource = Controller.GetTableList(wheres.ToArray(), parameters.ToArray());
            #endregion
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DGX_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowDetail(sender, e);
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

 
    }
}
