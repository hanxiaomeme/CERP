using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LanyunMES.UI
{
    using DAL;
    using DevExpress.XtraGrid.Columns;
    using System.Data.SqlClient;
    using DevExpressUtility;

    public partial class FmStockDetail : Form
    {
        public FmStockDetail()
        {
            InitializeComponent();
            this.gridView1.KeyDown += GridViewHelper.KeyDownCellCopy;
            this.gridView1.CellMerge += GridViewHelper.gridviewCellMerge;
        }

        private DataTable dtM = new DataTable();
        private StockDAL dal = new StockDAL();

        private List<string> whereList;
        private List<SqlParameter> paramList;

        private void InitGrid()
        {
            #region 初始化列
            this.gridView1.OptionsView.AllowCellMerge = false;

            GridColumn col = GridViewHelper.AddColumn(this.gridView1, "cDepName", "当前部门", 120);
            col.Summary.Add(DevExpress.Data.SummaryItemType.Count);
            col.Summary[0].FieldName = "CardNo";
            col.Summary[0].DisplayFormat = "记录:{0}";

            col = GridViewHelper.AddColumn(this.gridView1, "CardNo", "流转卡号", 100);

            col = GridViewHelper.AddColumn(this.gridView1, "cSOCode", "销售订单号", 90);

            col = GridViewHelper.AddColumn(this.gridView1, "MoCode", "生产订单号", 90);

            col = GridViewHelper.AddColumn(this.gridView1, "SortSeq", "生产订单行号", 80);

            col = GridViewHelper.AddColumn(this.gridView1, "cCusInvCode", "客户零件号", 120);

            col = GridViewHelper.AddColumn(this.gridView1, "cInvCode", "存货编码", 150);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            col = GridViewHelper.AddColumn(this.gridView1, "cInvName", "存货名称", 120);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            col = GridViewHelper.AddColumn(this.gridView1, "cInvStd", "规格型号", 150);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            col = GridViewHelper.AddColumn(this.gridView1, "Free1", "头标", 80);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            col = GridViewHelper.AddColumn(this.gridView1, "dubie", "镀别", 80);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            col = GridViewHelper.AddColumn(this.gridView1, "yachang", "牙长", 80);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            col = GridViewHelper.AddColumn(this.gridView1, "OpSeq", "工序序号", 65);

            col = GridViewHelper.AddColumn(this.gridView1, "OPName", "当前工序", 80);
            col.AppearanceCell.ForeColor = Color.Blue;

            col = GridViewHelper.AddColumn(this.gridView1, "nextOPName", "下道工序", 80);
            col.AppearanceCell.ForeColor = Color.SkyBlue;

            col = GridViewHelper.AddColumn(this.gridView1, "iQuantity", "千件", 90);
            col.AppearanceCell.ForeColor = Color.Red;
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "#,##0.000";
            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            col.Summary[0].FieldName = "iQuantity";
            col.Summary[0].DisplayFormat = "{0:n3}";

            col = GridViewHelper.AddColumn(this.gridView1, "bizhong", "工序比重", 70);

            col = GridViewHelper.AddColumn(this.gridView1, "iWeight", "重量", 90);
            col.AppearanceCell.ForeColor = Color.Red;
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "#,##0.00";
            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            col.Summary[0].FieldName = "iWeight";
            col.Summary[0].DisplayFormat = "{0:n2}";

            GridViewHelper.AddColumn(this.gridView1, "HeatNo", "热处理批号", 90);

            GridViewHelper.AddColumn(this.gridView1, "ylBarCode", "原料条码", 90);
            GridViewHelper.AddColumn(this.gridView1, "luhao", "炉号", 90);
            GridViewHelper.AddColumn(this.gridView1, "caizhi", "原料材质", 70);
            GridViewHelper.AddColumn(this.gridView1, "hhph", "回火批号", 80);
            GridViewHelper.AddColumn(this.gridView1, "chandi", "产地", 80);
            GridViewHelper.AddColumn(this.gridView1, "repDate", "报工时间", 100);
            GridViewHelper.AddColumn(this.gridView1, "repPsn", "报工人", 80);

            col = GridViewHelper.AddColumn(this.gridView1, "DepChangeDate", "部门调整时间", 140);
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";

            GridViewHelper.AddColumn(this.gridView1, "DepChangePsn", "调整人", 70);

            //GridViewHelper.AddColumn(this.gridView1, "caizhi", "材质", 80);
            //GridViewHelper.AddColumn(this.gridView1, "CreateDate", "日期", 80);
            //GridViewHelper.AddColumn(this.gridView1, "CreatePsn", "制单人", 80);
            //GridViewHelper.AddColumn(this.gridView1, "Remark", "备注", 150); 
            #endregion
        }

        private void FmProductOrder_Load(object sender, EventArgs e)
        {
            this.InitGrid();
        }

        private void Btn_PrintDesgin_Click(object sender, EventArgs e)
        {
            #region 打印

            #endregion
        }

        private void Btn_Print_Click(object sender, EventArgs e)
        {
            #region 设计

            #endregion
        }

        private void Btn_Query_Click(object sender, EventArgs e)
        {
            FmQStockDetail frm = new FmQStockDetail();
            if (paramList != null)
            {
                frm.LoadSqlParams(this.paramList);
            }
            if(frm.ShowDialog() == DialogResult.OK)
            {
                this.whereList = frm.ListWhere;
                this.paramList = frm.Parameters;

                this.dtM = dal.GetStockDetail(whereList, paramList);
                this.gridControl1.DataSource = dtM;
            }
        }


        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.C)
            {
                Clipboard.SetDataObject(gridView1.GetFocusedRowCellValue(gridView1.FocusedColumn));
                e.Handled = true;
            }
        }

        private void Btn_Export_Click(object sender, EventArgs e)
        {
            GridViewHelper.ExportToXlsx(this.gridControl1);
        }

        private void Btn_Refresh_Click(object sender, EventArgs e)
        {
            this.dtM = dal.GetStockDetail(whereList, paramList);
            this.gridControl1.DataSource = dtM;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            #region 查询报工记录明细

            string cardNo = gridView1.GetFocusedRowCellValue("CardNo").ToString();

            MCardDAL dal = new MCardDAL();
            List<string> wheres = new List<string>();
            wheres.Add("t1.CardNo = '" + cardNo + "'");
            DataTable dt = dal.GetRepRecord(wheres, null);

            FmRepList frm = new FmRepList(dt);
            frm.ShowDialog();

            #endregion
        }
    }
}
