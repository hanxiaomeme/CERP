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
    using DAL.U8;
    using DevExpress.XtraGrid.Columns;
    using System.Data.SqlClient;
    using Component;
    using DevExpressUtility;

    public partial class FmMORep : Form
    {
        public FmMORep()
        {
            InitializeComponent();
            this.gridView1.KeyDown += GridViewHelper.KeyDownCellCopy;
            this.gridView1.CellMerge += GridViewHelper.gridviewCellMerge;
        }

        private DataTable dtM;
        private MomDAL dal = new MomDAL();
        private List<string> _whereList;
        private List<SqlParameter> _paramList;

        private void InitGrid()
        {
            #region 初始化列
            this.gridView1.OptionsView.AllowCellMerge = true;

            GridColumn col = GridViewHelper.AddColumn(this.gridView1, "MoCode", "生产订单号", 100);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            col = GridViewHelper.AddColumn(this.gridView1, "SortSeq", "行号", 50);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            col = GridViewHelper.AddColumn(this.gridView1, "cSOCode", "销售订单", 100);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            col = GridViewHelper.AddColumn(this.gridView1, "cCusInvCode", "客户零件号", 120);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            col = GridViewHelper.AddColumn(this.gridView1, "cInvCode", "存货编码", 150);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            col = GridViewHelper.AddColumn(this.gridView1, "cInvName", "存货名称", 150);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            col = GridViewHelper.AddColumn(this.gridView1, "cInvStd", "规格型号", 120);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            col = GridViewHelper.AddColumn(this.gridView1, "dubie", "镀别", 80);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            col = GridViewHelper.AddColumn(this.gridView1, "Free1", "头标", 80);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            col = GridViewHelper.AddColumn(this.gridView1, "orderQty", "生产订单千件", 90);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n2}";

            col = GridViewHelper.AddColumn(this.gridView1, "OpSeq", "工序序号", 70);

            col = GridViewHelper.AddColumn(this.gridView1, "OPName", "工序名称", 70);

            col = GridViewHelper.AddColumn(this.gridView1, "iQuantity", "已报工千件", 80);
            col.AppearanceCell.ForeColor = Color.Red;
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n3}";

            col = GridViewHelper.AddColumn(this.gridView1, "iWeight", "已报工重量", 90);
            col.AppearanceCell.ForeColor = Color.Red;
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n2}";

            col = GridViewHelper.AddColumn(this.gridView1, "LQty", "工序剩余/千件", 90);
            //col.AppearanceCell.ForeColor = Color.Red;
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n3}";

            col = GridViewHelper.AddColumn(this.gridView1, "LWeight", "工序剩余/Kg", 90);
            //col.AppearanceCell.ForeColor = Color.Red;
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n2}";

            col = GridViewHelper.AddColumn(this.gridView1, "LQty2", "订单剩余/千件", 90);
            col.AppearanceCell.ForeColor = Color.Red;
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n3}";

            col = GridViewHelper.AddColumn(this.gridView1, "repPercent", "完成率", 70);
            col.AppearanceCell.ForeColor = Color.Blue;
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n2}%";

            //GridViewHelper.AddColumn(this.gridView1, "Remark", "备注", 150); 
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
            this.dtM = dal.GetTableRepSum(_whereList, _paramList);
            this.gridControl1.DataSource = dtM; 
            #endregion
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            #region 查看报工明细
            //DataRow row = this.gridView1.GetDataRow(gridView1.FocusedRowHandle);
            //int modid = Convert.ToInt32(row["modid"]);

            //string[] wheres = new string[]
            //{
            //    "isnull(curOpSeq,'') <> '0010' and modid = " + modid
            //};

            //MCardDAL dal = new MCardDAL();
            //DataTable dt = dal.GetTableList(wheres.ToList(), null);
            //FmCardList frm = new FmCardList(dt);
            //frm.ShowDialog(); 
            #endregion
        }

        private void Btn_Query_Click(object sender, EventArgs e)
        {
            FmQMORep frm = new FmQMORep();
            if (_paramList != null)
            {
                frm.LoadSqlParams(_paramList);
            }
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this._whereList = frm.ListWhere;
                this._paramList = frm.Parameters;
                this.dtM = dal.GetTableRepSum(_whereList, _paramList);
                this.gridControl1.DataSource = dtM;
            }
        }

    }
}
