using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace LanyunMES.UI
{
    using DAL;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Views.BandedGrid;
    using DevExpress.XtraGrid.Views.Grid;
    using DevComponents.DotNetBar;
    using System.Data.SqlClient;
    using Component;
    using DevExpressUtility;

    public partial class FmSaleMonthByInv : Form
    {
        public FmSaleMonthByInv()
        {
            InitializeComponent();
            this.bandedGridView1.KeyDown += GridViewHelper.KeyDownCellCopy;
            this.bandedGridView1.CellMerge += GridViewHelper.gridviewCellMerge;
        }

        private DataTable dtM;
        private StockDAL dal = new StockDAL();
        private List<string> _whereList;
        private List<SqlParameter> _paramList;


        private void InitGrid()
        {
            #region 初始化列

            this.bandedGridView1.Columns.Clear();
            this.bandedGridView1.OptionsView.AllowCellMerge = true;

            //GridColumn col = GridViewHelper.AddColumn(this.bandedGridView1, "cInvAddCode", "老编码", 120);
            BandedGridColumn col = GridViewHelper.AddBandColumn(this.bandedGridView1, "cInvAddCode", "老编码", 120);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            col.Summary.Add(DevExpress.Data.SummaryItemType.Count);
            col.Summary[0].DisplayFormat = "记录:{0}";
            col.Summary[0].FieldName = "cInvAddCode";
            this.bandedGridView1.Bands["chanpin"].Columns.Add(col);

            col = GridViewHelper.AddBandColumn(this.bandedGridView1, "cInvDefine9", "客户名称", 150);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.bandedGridView1.Bands["chanpin"].Columns.Add(col);

            col = GridViewHelper.AddBandColumn(this.bandedGridView1, "InvCode", "存货编码", 130);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.bandedGridView1.Bands["chanpin"].Columns.Add(col);

            col = GridViewHelper.AddBandColumn(this.bandedGridView1, "cInvName", "存货名称", 130);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.bandedGridView1.Bands["chanpin"].Columns.Add(col);

            col = GridViewHelper.AddBandColumn(this.bandedGridView1, "cInvStd", "规格型号", 120);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.bandedGridView1.Bands["chanpin"].Columns.Add(col);

            col = GridViewHelper.AddBandColumn(this.bandedGridView1, "dubie", "镀别", 80);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.bandedGridView1.Bands["chanpin"].Columns.Add(col);

            col = GridViewHelper.AddBandColumn(this.bandedGridView1, "Free1", "头标", 80);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.bandedGridView1.Bands["chanpin"].Columns.Add(col);

            col = GridViewHelper.AddBandColumn(this.bandedGridView1, "dDate", "最近发货日期", 90);
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            // col.DisplayFormat.FormatString = "{yyyy-MM-dd}";
            this.bandedGridView1.Bands["chanpin"].Columns.Add(col);

            col = GridViewHelper.AddBandColumn(this.bandedGridView1, "cInvDefine13", "比重", 80);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridView1.Bands["chanpin"].Columns.Add(col);

            col = GridViewHelper.AddBandColumn(this.bandedGridView1, "AvgQty", "月平均", 80);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.AppearanceCell.ForeColor = Color.Red;
            col.DisplayFormat.FormatString = "{0:n3}";
            this.bandedGridView1.Bands["others"].Columns.Add(col);

            col = GridViewHelper.AddBandColumn(this.bandedGridView1, "cInvDefine12", "预测天数", 80);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            //col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //col.AppearanceCell.ForeColor = Color.Red;
            //col.DisplayFormat.FormatString = "{0:n3}";
            this.bandedGridView1.Bands["others"].Columns.Add(col);

            col = GridViewHelper.AddBandColumn(this.bandedGridView1, "PreQty", "预测数量", 80);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.AppearanceCell.ForeColor = Color.Red;
            col.DisplayFormat.FormatString = "{0:n3}";
            this.bandedGridView1.Bands["others"].Columns.Add(col);


            col = GridViewHelper.AddBandColumn(this.bandedGridView1, "ZZQuantity", "在制品", 80);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.AppearanceCell.ForeColor = Color.Blue;
            col.DisplayFormat.FormatString = "{0:n3}";
            this.bandedGridView1.Bands["stock"].Columns.Add(col);

            col = GridViewHelper.AddBandColumn(this.bandedGridView1, "NStockQty", "完工未入库", 80);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.AppearanceCell.ForeColor = Color.Blue;
            col.DisplayFormat.FormatString = "{0:n3}";
            this.bandedGridView1.Bands["stock"].Columns.Add(col);

            col = GridViewHelper.AddBandColumn(this.bandedGridView1, "KCQuantity", "库存仓库", 80);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.AppearanceCell.ForeColor = Color.Blue;
            col.DisplayFormat.FormatString = "{0:n3}";
            this.bandedGridView1.Bands["stock"].Columns.Add(col);

            col = GridViewHelper.AddBandColumn(this.bandedGridView1, "cusQuantity", "客户仓库", 80);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.AppearanceCell.ForeColor = Color.Blue;
            col.DisplayFormat.FormatString = "{0:n3}";
            this.bandedGridView1.Bands["stock"].Columns.Add(col);

            col = GridViewHelper.AddBandColumn(this.bandedGridView1, "SumQuantity", "合计", 80);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.AppearanceCell.ForeColor = Color.Blue;
            col.DisplayFormat.FormatString = "{0:n3}";
            this.bandedGridView1.Bands["stock"].Columns.Add(col);

            col = GridViewHelper.AddBandColumn(this.bandedGridView1, "PlanQty", "数量", 80);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.AppearanceCell.ForeColor = Color.Blue;
            col.DisplayFormat.FormatString = "{0:n3}";
            this.bandedGridView1.Bands["plan"].Columns.Add(col);

            #endregion
        }

        private void FmProductOrder_Load(object sender, EventArgs e)
        {
            this.InitGrid();
        }

        private void Btn_PrintDesgin_Click(object sender, EventArgs e)
        {
            #region 打印设计
            
            //string cCode = dtM.Rows[gridView1.GetSelectedRows()[0]]["cCode"].ToString();

            //DataTable dtMain = dal.GetHead(cCode);
            //DataTable dtDetail = dal.GetBody(cCode);

            //string filePath = ".\\ReportPrint\\委外出库单.frx";
            //if (System.IO.File.Exists(filePath))
            //    this.report1.Load(filePath);
            
            //this.report1.RegisterData(dtMain, "M");
            //this.report1.RegisterData(dtDetail, "D");
            //this.report1.GetDataSource("M").Enabled = true;
            //this.report1.GetDataSource("D").Enabled = true;
            //this.report1.Design();
            #endregion
        }

        private void Btn_Print_Click(object sender, EventArgs e)
        {
            #region 打印
            //string cCode = dtM.Rows[gridView1.GetSelectedRows()[0]]["cCode"].ToString();

            //DataTable dtMain = dal.GetHead(cCode);
            //DataTable dtDetail = dal.GetBody(cCode);

            //string filePath = ".\\ReportPrint\\委外出库单.frx";
            //if (System.IO.File.Exists(filePath))
            //    this.report1.Load(filePath);

            //this.report1.RegisterData(dtMain, "M");
            //this.report1.RegisterData(dtDetail, "D");
            //this.report1.GetDataSource("M").Enabled = true;
            //this.report1.GetDataSource("D").Enabled = true;
            //this.report1.Show();
            #endregion
        }

        private void Btn_Export_Click(object sender, EventArgs e)
        {
            #region 导出Excel
            try
            {
                GridViewHelper.ExportToXlsx(this.gridControl1);
            }
            catch (Exception ex)
            {
                MsgBox.ShowInfoMsg(ex.ToString());
            } 
            #endregion
        }

        private void Btn_Refresh_Click(object sender, EventArgs e)
        {
            #region 刷新
            this.dtM = dal.GetSaleMonth(_paramList.ToArray());
            this.gridControl1.DataSource = dtM; 
            #endregion
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            #region 数量为0的显示空
            if (e.Column.VisibleIndex > 7 && e.CellValue != DBNull.Value)
            {
                if (Convert.ToDecimal(e.CellValue) == 0)
                {
                    e.DisplayText = "";
                }
            } 
            #endregion
        }

        private void Btn_Query_Click(object sender, EventArgs e)
        {
            FmQSaleMonth frm = new FmQSaleMonth();
            if (_paramList != null)
            {
                frm.LoadSqlParams(_paramList);
            }
            var result = frm.ShowDialog();

            if(result == DialogResult.OK)
            {
                this._paramList = frm.Parameters;

                //定义委托
                System.Action query = () => { ExecQuery(); };

                new Thread(() => {
                    this.Invoke(query);
                }).Start();              
            }

        }

        private void ExecQuery()
        {
            //this._paramList = frm.Parameters;
            this.dtM = dal.GetSaleMonthByInv(_paramList.ToArray());
            this.gridControl1.DataSource = dtM;
            #region 重新初始化列
            //this.gridView1.Columns.Clear();
            this.InitGrid();

            //List<BandedGridColumn> list = new List<BandedGridColumn>();
            foreach (DataColumn col in dtM.Columns)
            {
                if (col.ColumnName == "cInvCode" || col.ColumnName == "cFree1")
                {

                }
                else if (bandedGridView1.Columns.ColumnByFieldName(col.ColumnName) == null)
                {
                    BandedGridColumn newcol = new BandedGridColumn();
                    newcol.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    newcol.Caption = col.ColumnName;
                    newcol.Name = newcol.FieldName = col.ColumnName;
                    newcol.Visible = true;
                    newcol.Width = 80;
                    newcol.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    newcol.DisplayFormat.FormatString = "{0:n3}";

                    this.bandedGridView1.Bands["others"].Columns.Add(newcol);

                    //list.Add(newcol);
                }
            }

            //this.bandedGridView1.AddRange(list.ToArray());
            #endregion
        }

    }
}
