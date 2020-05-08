using FastReport;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LanyunMES.UI
{
    using Component;
    using DAL;
    using DevExpressUtility;

    public partial class FmEQResult : DevComponents.DotNetBar.OfficeForm
    {
        public FmEQResult()
        {
            InitializeComponent();
            this.DGX.KeyDown += GridViewHelper.KeyDownCellCopy;

            this.Text = pnl_title.Text;
            
            this.Load += Fm_Load;
            btn_Query.Click += Query;
            cb_showQPnl.CheckedChanged += ShowQueryPanel;
            gridCtrl.MouseDoubleClick += ShowDetail;
        }


        private APSDAL dal = new APSDAL();
        private DateTime dateBegin, dateEnd;
        private DataTable dtM;


        private void Query(object obj, EventArgs e)
        {
            #region 查询
            this.dateBegin = dBegin.Value.Date;
            this.dateEnd = dEnd.Value.Date;

            this.dtM = dal.GetAPSEQResult(dateBegin, dateEnd);
            this.InitDGX();
            gridCtrl.DataSource = dtM;

            #endregion
        }

        private void InitDGX()
        {
            //DGX.GroupPanelText = "将需要汇总的列拖动到此处";
            DGX.Columns.Clear();
            DGX.OptionsBehavior.AutoPopulateColumns = false;
            DGX.OptionsView.AllowCellMerge = true;

            var column = GridViewHelper.AddColumn(DGX, "cEQCode", "设备编码", 80);
            column.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            column.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

            column = GridViewHelper.AddColumn(DGX, "cEQName", "设备名称", 90);
            column.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            column.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                        
            GridViewHelper.AddColumn(DGX, "EQId", "EQId", 40).Visible = false;


            if (dtM == null) return;

            foreach (DataColumn col in dtM.Columns)
            {
                if (DGX.Columns.ColumnByFieldName(col.ColumnName) == null)
                {
                    var newcol = GridViewHelper.AddColumn(DGX, col.ColumnName, col.ColumnName, 80);
                    newcol.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    newcol.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    newcol.DisplayFormat.FormatString = "{0:n0}";

                    //newcol.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
                    //newcol.Summary[0].DisplayFormat = "{0}";
                    //newcol.Summary[0].FieldName = col.ColumnName;
                }
            }

        }

        private void Fm_Load(object sender, EventArgs e)
        {
            this.dBegin.Value = DateTime.Today.Date;
            this.dEnd.Value = DateTime.Today.AddDays(7);

            InitDGX();
        }

        private void ShowDetail(object sender, MouseEventArgs e)
        {
            #region 查看单据
            //int index = DGX.FocusedRowHandle;
            //string guid = DGX.GetDataRow(index)["guid"].ToString();

            //FmQmRecord frm = new FmQmRecord(guid);
            ////FmMain.NewPageDelegate(frm);
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
            this.dtM = dal.GetAPSEQResult(dateBegin, dateEnd);
            gridCtrl.DataSource = dtM;
            #endregion
        }

        private void DGX_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if(e.Column.DisplayFormat.FormatType != DevExpress.Utils.FormatType.Numeric)
            {
                return;
            }

            if (e.CellValue == null || e.CellValue == DBNull.Value)
            {
                e.DisplayText = "休";
                e.Appearance.BackColor = Color.Red;
            }
            else if(  Convert.ToDecimal(e.CellValue) > 100)
            {
                e.Appearance.BackColor = Color.LightYellow;
            }
            else if(Convert.ToDecimal(e.CellValue) < 100)
            {
                e.Appearance.BackColor = Color.LightGreen;
            }
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
