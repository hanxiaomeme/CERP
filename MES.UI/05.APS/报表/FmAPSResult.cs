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
    using Model;
    using U8Ext.Ref;
    using DevExpressUtility;

    public partial class FmAPSResult : DevComponents.DotNetBar.OfficeForm
    {
        public FmAPSResult()
        {
            InitializeComponent();
            this.DGX.KeyDown += GridViewHelper.KeyDownCellCopy;

            this.Text = pnl_title.Text;
            
            this.Load += Fm_Load;
            btn_Query.Click += Query;
            cb_showQPnl.CheckedChanged += ShowQueryPanel;
            gridCtrl.MouseDoubleClick += ShowDetail;

            this.dBegin.Value = DateTime.Today.Date;
            this.dEnd.Value = DateTime.Today.AddDays(7);
        }

        public FmAPSResult(DateTime dateS, DateTime dateE): this()
        {
            this.dBegin.Value = dateS;
            this.dEnd.Value = dateE;
            this.Query(null, null);
        }


        private APSDAL dal = new APSDAL();
        private DateTime dateBegin, dateEnd;
        private DataTable dtM;


        private void Query(object obj, EventArgs e)
        {
            #region 查询
            this.dateBegin = dBegin.Value.Date;
            this.dateEnd = dEnd.Value.Date;

            this.dtM = dal.GetAPSResult(dateBegin, dateEnd);
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
                        
            GridViewHelper.AddColumn(DGX, "cMCode", "模具编码", 80);
            GridViewHelper.AddColumn(DGX, "cMName", "模具名称", 90);
            GridViewHelper.AddColumn(DGX, "cInvCode", "存货编码", 100);
            GridViewHelper.AddColumn(DGX, "cInvName", "存货名称", 100);
            GridViewHelper.AddColumn(DGX, "cInvStd", "规格型号", 100);
            GridViewHelper.AddColumn(DGX, "cComUnitName", "单位", 40);
            GridViewHelper.AddColumn(DGX, "MoCode", "生产订单", 90);
            GridViewHelper.AddColumn(DGX, "SortSeq", "行号", 40);

            GridViewHelper.AddColumn(DGX, "EQID", "EQId", 40).Visible = false;
            GridViewHelper.AddColumn(DGX, "MID", "MID", 40).Visible = false;


            if (dtM == null) return;

            foreach (DataColumn col in dtM.Columns)
            {
                if (DGX.Columns.ColumnByFieldName(col.ColumnName) == null)
                {
                    var newcol = GridViewHelper.AddColumn(DGX, col.ColumnName, col.ColumnName, 80);
                    newcol.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    newcol.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    newcol.DisplayFormat.FormatString = "{0:n2}";

                    newcol.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
                    newcol.Summary[0].DisplayFormat = "{0}";
                    newcol.Summary[0].FieldName = col.ColumnName;
                }
            }

        }

        private void Fm_Load(object sender, EventArgs e)
        {
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
            this.dtM = dal.GetAPSResult(dateBegin, dateEnd);
            gridCtrl.DataSource = dtM;
            #endregion
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
