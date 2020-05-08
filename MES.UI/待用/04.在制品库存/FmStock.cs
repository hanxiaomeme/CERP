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
    using DevExpress.XtraGrid.Views.Grid;
    using System.Data.SqlClient;
    using DevExpressUtility;

    public partial class FmStock : Form
    {
        public FmStock()
        {
            InitializeComponent();
            this.gridView1.KeyDown += GridViewHelper.KeyDownCellCopy;
        }

        private DataTable dtM = new DataTable();
        private StockDAL dal = new StockDAL();

        private List<string> _whereList;
        private List<SqlParameter> _paramList;

        private void InitGrid()
        {
            #region 初始化列
            this.gridView1.OptionsView.AllowCellMerge = false;

            GridColumn col = GridViewHelper.AddColumn(this.gridView1, "cInvCode", "存货编码", 180);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            col.Summary.Add(DevExpress.Data.SummaryItemType.Count);
            col.Summary[0].FieldName = "cInvCode";
            col.Summary[0].DisplayFormat = "记录:{0}";

            col = GridViewHelper.AddColumn(this.gridView1, "cInvName", "存货名称", 130);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            col = GridViewHelper.AddColumn(this.gridView1, "cInvStd", "规格型号", 150);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            col = GridViewHelper.AddColumn(this.gridView1, "Free1", "头标", 80);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            col = GridViewHelper.AddColumn(this.gridView1, "dubie", "镀别", 80);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            col = GridViewHelper.AddColumn(this.gridView1, "Description", "工序", 80);
            col.AppearanceCell.ForeColor = Color.Blue;

            col = GridViewHelper.AddColumn(this.gridView1, "iQuantity", "千件", 100);
            col.AppearanceCell.ForeColor = Color.Red;
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "#,##0.000";
            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            col.Summary[0].FieldName = "iQuantity";
            col.Summary[0].DisplayFormat = "{0:n3}";

            col = GridViewHelper.AddColumn(this.gridView1, "iWeight", "重量", 90);
            col.AppearanceCell.ForeColor = Color.Red;
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "#,##0.00";
            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            col.Summary[0].FieldName = "iWeight";
            col.Summary[0].DisplayFormat = "{0:n2}";



            //GridViewHelper.AddColumn(this.gridView1, "yachang", "牙长", 80);
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
            #region 查询
            FmQStock frm = new FmQStock();
            if (_paramList != null)
            {
                frm.LoadSqlParams(_paramList);
            }
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this._whereList = frm.ListWhere;
                this._paramList = frm.Parameters;

                this.dtM = dal.GetStock(_whereList, _paramList);
                this.gridControl1.DataSource = dtM;
            } 
            #endregion
        }

        private void gridView1_CellMerge(object sender, CellMergeEventArgs e)
        {
            #region 合并行
            GridView view = sender as GridView;
            string firstColumnFieldName = "cInvCode", secondColumnFieldName = "cInvName";

            if (e.Column.OptionsColumn.AllowMerge == DevExpress.Utils.DefaultBoolean.True)
            {
                string valueFirstColumn1 = Convert.ToString(view.GetRowCellValue(e.RowHandle1, view.Columns[firstColumnFieldName]));
                string valueFirstColumn2 = Convert.ToString(view.GetRowCellValue(e.RowHandle2, view.Columns[firstColumnFieldName]));
                string valueSecondColumn1 = Convert.ToString(view.GetRowCellValue(e.RowHandle1, view.Columns[secondColumnFieldName]));
                string valueSecondColumn2 = Convert.ToString(view.GetRowCellValue(e.RowHandle2, view.Columns[secondColumnFieldName]));

                e.Merge = valueFirstColumn1 == valueFirstColumn2 && valueSecondColumn1 == valueSecondColumn2;
                e.Handled = true;
            }
            #endregion
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
            this.dtM = dal.GetStock(_whereList, _paramList);
            this.gridControl1.DataSource = dtM;
        }
    }
}
