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
    using U8Ext.Ref;
    using System.Collections.Generic;
    using Component;
    using DevExpressUtility;

    public partial class FmQmRecordList : DevComponents.DotNetBar.OfficeForm, IFView<QmRecordController>
    {
        public FmQmRecordList()
        {
            InitializeComponent();
            this.DGX.KeyDown += GridViewHelper.KeyDownCellCopy;

            this.Text = pnl_title.Text;
            
            this.Load += Fm_Load;
            btn_Query.Click += Query;
            txt_vendor.ButtonCustomClick += RefVendor;
            cb_showQPnl.CheckedChanged += ShowQueryPanel;
            gridCtrl.MouseDoubleClick += ShowDetail;
        }

        public QmRecordController Controller { get; private set; } = new QmRecordController();

        private List<string> wheres = new List<string>();
        private List<SqlParameter> parameters = new List<SqlParameter>();


        private void Query(object obj, EventArgs e)
        {
            #region 查询
            UIControl.GetSqlParams(group1.Controls, wheres, parameters);
            gridCtrl.DataSource = Controller.GetList(wheres.ToArray(), parameters.ToArray());
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

            GridViewHelper.AddColumn(DGX, "QMRCode", "检验单号", 90);
            GridViewHelper.AddColumn(DGX, "dDate", "日期", 80);
            GridViewHelper.AddColumn(DGX, "cVenName", "供应商名称", 120);
            GridViewHelper.AddColumn(DGX, "cPOID", "采购订单号", 90);
            GridViewHelper.AddColumn(DGX, "ivouchrowno", "行号", 40);
            GridViewHelper.AddColumn(DGX, "cInvCode", "存货编码", 90);
            GridViewHelper.AddColumn(DGX, "cInvName", "存货名称", 90);
            GridViewHelper.AddColumn(DGX, "cInvStd", "规格型号", 90);
            GridViewHelper.AddColumn(DGX, "cComUnitName", "单位", 40);

            var col = GridViewHelper.AddColumn(DGX, "qmQty", "报检数量", 90);
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n2}";
            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            col.Summary[0].DisplayFormat = "{0:n2}";

            col = GridViewHelper.AddColumn(DGX, "iQualifyQty", "合格数量", 90);
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n2}";
            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            col.Summary[0].DisplayFormat = "{0:n2}";

            col = GridViewHelper.AddColumn(DGX, "iUnQualifyQty", "不合格数量", 90);
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n2}";
            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            col.Summary[0].DisplayFormat = "{0:n2}";

            GridViewHelper.AddColumn(DGX, "U8RDCode", "U8采购入库单", 90);
            GridViewHelper.AddColumn(DGX, "cAuditPsn", "审核人", 70);
            GridViewHelper.AddColumn(DGX, "cMaker", "制单人", 70);
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
            #region 查看单据
            int index = DGX.FocusedRowHandle;
            string guid = DGX.GetDataRow(index)["guid"].ToString();

            FmQmRecord frm = new FmQmRecord(guid);
            //FmMain.NewPageDelegate(frm);
            frm.ShowDialog();
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
            gridCtrl.DataSource = Controller.GetList(wheres.ToArray(), parameters.ToArray());
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

 
    }
}
