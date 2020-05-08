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
    using DAL.U8;
    using DevExpressUtility;
    using Common;

    public partial class FmMomDetail : DevComponents.DotNetBar.OfficeForm
    {
        public FmMomDetail()
        {
            InitializeComponent();
            this.Load += FormLoad;
            this.gridView1.KeyDown += GridViewHelper.KeyDownCellCopy;
        }

        public FmMomDetail(int modid) : this()
        {
            U8modid = modid;
        }

        private int U8modid;             //生产订单行
        private MomOrder model;
        private MomOrderDAL dal = new MomOrderDAL();

        private void InitGrid()
        {
            #region 初始化列
            //GridColumn col = UIGridControl.AddColumn(this.gridView1, "MoCode", "生产订单号", 80);
            //col.Fixed = FixedStyle.Left;
            //col.Summary.Add(DevExpress.Data.SummaryItemType.Count);
            //col.Summary[0].FieldName = "MoCode";
            //col.Summary[0].DisplayFormat = "记录数:{0}";

            //UIGridControl.AddColumn(this.gridView1, "CreateDate", "日期", 80);
            //UIGridControl.AddColumn(this.gridView1, "BomType", "类型", 50);
            //UIGridControl.AddColumn(this.gridView1, "SortSeq", "行号", 40);
            //UIGridControl.AddColumn(this.gridView1, "cInvCode", "存货编码", 150);
            //UIGridControl.AddColumn(this.gridView1, "cInvName", "存货名称", 120);
            //UIGridControl.AddColumn(this.gridView1, "cInvStd", "规格型号", 120);
            //UIGridControl.AddColumn(this.gridView1, "Free1", "头标", 80);

            //col = UIGridControl.AddColumn(this.gridView1, "Qty", "数量", 90);
            //col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //col.AppearanceCell.ForeColor = Color.Red;
            //col.DisplayFormat.FormatString = "n3";
            //var sitem = col.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            //sitem.FieldName = "Qty";
            //sitem.DisplayFormat = "{0:n2}";

            //UIGridControl.AddColumn(this.gridView1, "SoCode", "订单号", 80);
            //UIGridControl.AddColumn(this.gridView1, "iCount", "流转卡数量", 80);

            //UIGridControl.AddColumn(this.gridView1, "Remark", "备注", 150); 
            #endregion
        }

        private void UIDataBinding()
        {
            //数据绑定
            UIBinding<MomOrder>.UIDataBinding(this, model);
        }


        private void FormLoad(object sender, EventArgs e)
        {
            this.InitGrid();
            var u8MomDetail = new MomDAL().GetMomDetail(U8modid);

            //model = dal.GetMomOrder("0");
            //model.MoCode = u8MomDetail.MoCode;
            //model.SortSeq = u8MomDetail.SortSeq;
            //model.cInvCode = u8MomDetail.InvCode;
            //model.cInvName = u8MomDetail.cInvName;
            //model.cInvStd = u8MomDetail.cInvStd;
            //model.iQuantity = u8MomDetail.Qty;

            this.UIDataBinding();
        }


        private void Btn_Print_Click(object sender, EventArgs e)
        {
            #region 打印
            //string path = Application.StartupPath.Trim('\\');

            //if (System.IO.File.Exists(path + "\\ReportPrint\\派工单.frx"))
            //{
            //    this.report1.Load(path + "\\ReportPrint\\派工单.frx");
            //}
            //this.report1.RegisterData(dtM, "M");
            //this.report1.GetDataSource("M").Enabled = true;
            //this.report1.Show(); 
            #endregion
        }

        private void Btn_Desgin_Click(object sender, EventArgs e)
        {
            #region 打印设计
            //string path = Application.StartupPath.Trim('\\');

            //if (System.IO.File.Exists(path + "\\ReportPrint\\派工单.frx"))
            //{
            //    this.report1.Load(path + "\\ReportPrint\\派工单.frx");
            //}
            //this.report1.RegisterData(dtM, "M");
            //this.report1.GetDataSource("M").Enabled = true;
            //this.report1.Design(); 
            #endregion
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //int modid = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "modid"));
            //CardDAL dal = new CardDAL();
            //dtD = dal.GetHeadList(modid);
            //this.gridControl2.DataSource = dtD;
        }

        private void GetMomInvDetail(object sender, EventArgs e)
        {
            //var data = dal.GetU8Bom(momDetail.InvCode);

            //foreach(DataRow row in data.Rows)
            //{
            //    if()
            //}
        }
    }
}
