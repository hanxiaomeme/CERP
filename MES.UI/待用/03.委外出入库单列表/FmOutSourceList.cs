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
    using Model;
    using DAL;
    using DevExpress.XtraGrid.Columns;
    using System.Data.SqlClient;
    using Component;
    using DevExpressUtility;

    public partial class FmOutSourceList : Form
    {
        public FmOutSourceList()
        {
            InitializeComponent();
            this.gridView1.KeyDown += GridViewHelper.KeyDownCellCopy;
            this.gridView1.CellMerge += GridViewHelper.gridviewCellMerge;
        }

        private DataTable dtM;
        private OutSourceDAL dal = new OutSourceDAL();
        private List<string> _whereList;
        private List<SqlParameter> _paramList;
        private bool bRDFlag = true;

        private void InitGrid()
        {
            #region 初始化列
            this.gridView1.OptionsView.AllowCellMerge = true;

            GridColumn col = GridViewHelper.AddColumn(this.gridView1, "cCode", "单据号", 100);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            col = GridViewHelper.AddColumn(this.gridView1, "dDate", "日期", 80);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            col = GridViewHelper.AddColumn(this.gridView1, "cVenName", "供应商", 120);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            col = GridViewHelper.AddColumn(this.gridView1, "cDepName", "部门", 90);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            col = GridViewHelper.AddColumn(this.gridView1, "cardNo", "流转卡号", 90);

            col = GridViewHelper.AddColumn(this.gridView1, "opName", "工序", 80);

            col = GridViewHelper.AddColumn(this.gridView1, "cInvCode", "存货编码", 150);
            col = GridViewHelper.AddColumn(this.gridView1, "cInvName", "存货名称", 120);
            col = GridViewHelper.AddColumn(this.gridView1, "cInvStd", "规格型号", 120);
            col = GridViewHelper.AddColumn(this.gridView1, "cFree1", "头标", 80);
            col = GridViewHelper.AddColumn(this.gridView1, "dubie", "镀别", 80);

            col = GridViewHelper.AddColumn(this.gridView1, "iWeight", "重量", 80);
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

            GridViewHelper.AddColumn(this.gridView1, "cMaker", "制单人", 80);
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

            int rowhandle = gridView1.GetSelectedRows()[0];
            string cCode = gridView1.GetRowCellValue(rowhandle, "cCode").ToString();
            DataTable dtMain = dal.GetHead(cCode);
            DataTable dtDetail = dal.GetBody(cCode);

            string filePath = Application.StartupPath.Trim('\\') + "\\ReportPrint\\委外出库单.frx";

            if (System.IO.File.Exists(filePath))
                this.report1.Load(filePath);
            else
                MsgBox.ShowInfoMsg("找不到打印模板");
            
            this.report1.RegisterData(dtMain, "M");
            this.report1.RegisterData(dtDetail, "D");
            this.report1.GetDataSource("M").Enabled = true;
            this.report1.GetDataSource("D").Enabled = true;
            this.report1.Design();
            #endregion
        }

        private void Btn_Print_Click(object sender, EventArgs e)
        {
            #region 打印

            int rowhandle = gridView1.GetSelectedRows()[0];
            string cCode = gridView1.GetRowCellValue(rowhandle, "cCode").ToString();

            DataTable dtMain = dal.GetHead(cCode);
            DataTable dtDetail = dal.GetBody(cCode);

            string filePath = Application.StartupPath.Trim('\\') + "\\ReportPrint\\委外出库单.frx";

            if (System.IO.File.Exists(filePath))
                this.report1.Load(filePath);
            else
                MsgBox.ShowInfoMsg("找不到打印模板");

            this.report1.RegisterData(dtMain, "M");
            this.report1.RegisterData(dtDetail, "D");
            this.report1.GetDataSource("M").Enabled = true;
            this.report1.GetDataSource("D").Enabled = true;
            this.report1.Show();
            #endregion
        }

        private void Btn_Edit_Click(object sender, EventArgs e)
        {
            #region 添加备注

            int index = this.gridView1.GetSelectedRows()[0];
            string cCode = gridView1.GetDataRow(index)["cCode"].ToString();
            DataRow row = new OutSourceDAL().GetHead(cCode).Rows[0];
            FmOutSourceEdit frm = new FmOutSourceEdit(row);
            frm.ShowDialog(); 

            #endregion
        }

        private void Btn_Refresh_Click(object sender, EventArgs e)
        {
            this.dtM = dal.GetTableList(_whereList, _paramList);
            this.gridControl1.DataSource = dtM;
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

        private void Btn_Del_Click(object sender, EventArgs e)
        {
            if(Information.UserInfo.cDept != "信息科")
            {
                MsgBox.ShowInfoMsg("没有权限！");
            }
            else
            {
                if (MsgBox.ShowYesNoMsg("确定删除当前单据？") == DialogResult.Yes)
                {
                    string cCode = gridView1.GetFocusedDataRow()["cCode"].ToString();
                    try
                    {
                        dal.Delete(cCode);
                        MsgBox.ShowInfoMsg("删除成功！");
                    }
                    catch (Exception ex)
                    {
                        MsgBox.ShowInfoMsg(ex.Message);
                    }
                }
            }
        }

        private void Btn_Query_Click(object sender, EventArgs e)
        {
            #region 查询
            FmQOutSource frm = new FmQOutSource();
            if (_paramList != null)
            {
                frm.LoadSqlParams(_paramList);
            }
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this._whereList = frm.ListWhere;
                this._paramList = frm.Parameters;
                this.dtM = dal.GetTableList(_whereList, _paramList);
                this.gridControl1.DataSource = dtM;
            } 
            #endregion
        }

    }
}
