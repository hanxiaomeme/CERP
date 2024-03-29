﻿using System;
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
    using DevComponents.DotNetBar;
    using System.Data.SqlClient;
    using Component;
    using DevExpressUtility;

    public partial class FmRepList : Form
    {
        public FmRepList()
        {
            InitializeComponent();
            this.gridView1.KeyDown += GridViewHelper.KeyDownCellCopy;
            this.gridView1.CellMerge += GridViewHelper.gridviewCellMerge;
        }

        public FmRepList(DataTable dt): this()
        {
            this.Btn_Refresh.Visible = false;
            this.gridView1.OptionsBehavior.AutoPopulateColumns = false;
            this.dtM = dt;
            this.gridControl1.DataSource = dtM;
        }

        private DataTable dtM, dtD;
        private MCardDAL dal = new MCardDAL();
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

            col = GridViewHelper.AddColumn(this.gridView1, "CardNo", "流转卡号", 100);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            col.Summary.Add(DevExpress.Data.SummaryItemType.Count);
            col.Summary[0].FieldName = "CardNo";
            col.Summary[0].DisplayFormat = "记录: {0}";
            col.Fixed = FixedStyle.Left;

            col = GridViewHelper.AddColumn(this.gridView1, "cInvCode", "存货编码", 150);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            col = GridViewHelper.AddColumn(this.gridView1, "cInvName", "存货名称", 150);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            col = GridViewHelper.AddColumn(this.gridView1, "cInvStd", "规格型号", 120);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            col = GridViewHelper.AddColumn(this.gridView1, "yachang", "牙长", 80);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            col = GridViewHelper.AddColumn(this.gridView1, "dubie", "镀别", 80);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            col = GridViewHelper.AddColumn(this.gridView1, "Free1", "头标", 80);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            col = GridViewHelper.AddColumn(this.gridView1, "cDepName", "当前部门", 90);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            col = GridViewHelper.AddColumn(this.gridView1, "cGroup", "班组", 80);
 
            col = GridViewHelper.AddColumn(this.gridView1, "OpSeq", "工序序号", 70);

            col = GridViewHelper.AddColumn(this.gridView1, "OPName", "工序名称", 70);


            col = GridViewHelper.AddColumn(this.gridView1, "iWeight", "重量", 90);
            col.AppearanceCell.ForeColor = Color.Red;
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "#,##0.00";
            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            col.Summary[0].FieldName = "iWeight";
            col.Summary[0].DisplayFormat = "{0:n2}";

            col = GridViewHelper.AddColumn(this.gridView1, "iQuantity", "千件", 80);
            col.AppearanceCell.ForeColor = Color.Red;
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "#,##0.00";
            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            col.Summary[0].FieldName = "iQuantity";
            col.Summary[0].DisplayFormat = "{0:n2}";

            col = GridViewHelper.AddColumn(this.gridView1, "orderQty", "生产订单千件", 90);
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "#,##0.00";

            col = GridViewHelper.AddColumn(this.gridView1, "RepDate", "报工日期", 140);
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";

            GridViewHelper.AddColumn(this.gridView1, "RepPsn", "报工人", 80);
            GridViewHelper.AddColumn(this.gridView1, "HeatNo", "热处理批号", 90);
            GridViewHelper.AddColumn(this.gridView1, "ylBarCode", "原料条码", 80);
            GridViewHelper.AddColumn(this.gridView1, "luhao", "炉号", 80);
            GridViewHelper.AddColumn(this.gridView1, "chandi", "产地", 70);
            GridViewHelper.AddColumn(this.gridView1, "caizhi", "材质", 70);
            GridViewHelper.AddColumn(this.gridView1, "hhph", "回火批号", 90);
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
            this.dtM = dal.GetRepRecord(_whereList, _paramList);
            this.gridControl1.DataSource = dtM;
        }

        private void Btn_Query_Click(object sender, EventArgs e)
        {
            FmQRepList frm = new FmQRepList();
            frm.LoadSqlParams(_paramList);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                this._whereList = frm.ListWhere;
                this._paramList = frm.Parameters;
                this.dtM = dal.GetRepRecord(_whereList, _paramList);
                this.gridControl1.DataSource = dtM;
            }
        }

    }
}
