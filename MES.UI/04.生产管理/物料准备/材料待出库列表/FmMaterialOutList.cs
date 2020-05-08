using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LanyunMES.UI
{
    using DAL;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpressUtility;
    using System.Data.SqlClient;

    public partial class FmMaterialOutList : DevComponents.DotNetBar.OfficeForm
    {
        public FmMaterialOutList()
        {
            InitializeComponent();

            this.gridView1.KeyDown += GridViewHelper.KeyDownCellCopy;
            this.gridView2.KeyDown += GridViewHelper.KeyDownCellCopy;

            //窗体标题
            this.Text = pnl_title.Text;
            //窗体加载
            this.Load += Fm_Load;
            //导出Excel
            this.btn_Export.Click += ExportExcel;
            //返回数据
            this.Btn_OK.Click += GetResult;
        }

        private DataTable mData = null;
        private MaterialRequestDAL dal = new MaterialRequestDAL();

        private string[] _wheres;
        private SqlParameter[] _parameters;

        public DataRow[] selectRows { get; private set; }


        private void Fm_Load(object sender, EventArgs e)
        {
            this.InitGrid(gridView1);
            this.InitGridD(gridView2);
            this.LoadData();
        }

        private void InitGrid(GridView view)
        {
            view.OptionsBehavior.AutoPopulateColumns = false;
            view.OptionsView.ColumnAutoWidth = true;

            var col = GridViewHelper.AddColumn(view, "CardNo", "流转卡号", 110);
            col.Summary.Add(DevExpress.Data.SummaryItemType.Count);
            col.Summary[0].FieldName = "CardNo";
            col.Summary[0].DisplayFormat = "记录:{0}";

            GridViewHelper.AddColumn(view, "MoCode", "生产订单号", 90);

            GridViewHelper.AddColumn(view, "IsMerge", "是否合并", 80);

            GridViewHelper.AddColumn(view, "cInvCode", "存货编码", 120);
            GridViewHelper.AddColumn(view, "cInvName", "存货名称", 120);
            GridViewHelper.AddColumn(view, "cInvStd", "规格型号", 90);
            GridViewHelper.AddColumn(view, "OpName", "工序名称", 80);

            col = GridViewHelper.AddColumn(view, "iQuantity", "材料数量",70);
            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            col.Summary[0].FieldName = "iQuantity";
            col.Summary[0].DisplayFormat = "{0:n4}";

            col = GridViewHelper.AddColumn(view, "iReqQuantity", "合并前数量", 80);
            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            col.Summary[0].FieldName = "iReqQuantity";
            col.Summary[0].DisplayFormat = "{0:n4}";

            GridViewHelper.AddColumn(view, "cComUnitName", "单位", 40);

        }

        private void InitGridD(GridView view)
        {
            view.OptionsBehavior.AutoPopulateColumns = false;
            view.OptionsView.ColumnAutoWidth = true;
            view.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;

            var col = GridViewHelper.AddColumn(view, "CardNo", "流转卡号", 120);
            col.Summary.Add(DevExpress.Data.SummaryItemType.Count);
            col.Summary[0].FieldName = "CardNo";
            col.Summary[0].DisplayFormat = "记录:{0}";

            GridViewHelper.AddColumn(view, "cInvCode", "存货编码", 120);
            GridViewHelper.AddColumn(view, "cInvName", "存货名称", 120);
            GridViewHelper.AddColumn(view, "cInvStd", "规格型号", 120);
            GridViewHelper.AddColumn(view, "OpName", "工序名称", 80);


            col = GridViewHelper.AddColumn(view, "iQuantity", "材料数量", 80);
            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            col.Summary[0].FieldName = "iQuantity";
            col.Summary[0].DisplayFormat = "{0:n2}";


            GridViewHelper.AddColumn(view, "cComUnitName", "单位", 40);
        }

        private void GetResult(object sender, EventArgs e)
        {
            List<DataRow> ls = new List<DataRow>();

            foreach (int i in gridView1.GetSelectedRows())
            {
                ls.Add(gridView1.GetDataRow(i));
            }

            if(ls.Count < 1)
            {
                throw new Exception("没有选中行!");
            }
            else
            {
                FmMaterialPlan frm = new FmMaterialPlan();
                frm.LoadData(ls.ToArray());
                if(frm.ShowDialog() == DialogResult.OK)
                {
                    this.LoadData();
                }
            }
        }

        private void ExportExcel(object sender, EventArgs e)
        {
            #region 导出Excel
            GridViewHelper.ExportToXlsx(gridControl1);
            #endregion
        }

        private void LoadData()
        {
            this.mData = dal.GetMaterialReqTable(null);
            this.gridControl1.DataSource = mData;
        }

        private void cb_NoStart_CheckedChanged(object sender, EventArgs e)
        {
            //var startOnly = !(sender as CheckBox).Checked;
            //this.mData = dal.GetMaterialOutList(startOnly);
            //this.gridControl1.DataSource = mData;
        }

        /// <summary>
        /// 合并领料(弃)
        /// </summary>
        private void BtnMegra_Click(object sender, EventArgs e)
        {
            List<DataRow> ls = new List<DataRow>();

            foreach (int i in gridView1.GetSelectedRows())
            {
                ls.Add(gridView1.GetDataRow(i));
            }

            if (ls.Count < 1)
            {
                throw new Exception("没有选中行!");
            }

            string cInvCode = "";
            ls.ForEach(r =>
            {
                if(cInvCode != "" && r["cInvCode"].ToString() != cInvCode)
                {
                    throw new Exception("所选行存货编码不一致!");
                }
            });

            FmMaterialMerge frm = new FmMaterialMerge(ls.ToArray());
            if(frm.ShowDialog() == DialogResult.OK)
            {

            }

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                var guid = gridView1.GetFocusedRowCellValue("guid").ToString();

                gridControl2.DataSource = dal.GetMaterialReqDTable(guid);
            }

        }

        /// <summary>
        /// 刷新
        /// </summary>
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            this.mData = dal.GetMaterialReqTable(_wheres, _parameters);
            this.gridControl1.DataSource = mData;
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            FmMaterialOutListQ frm = new FmMaterialOutListQ();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                this._wheres = frm.ListWhere.ToArray();
                this._parameters = frm.Parameters.ToArray();
                this.mData = dal.GetMaterialReqTable(_wheres, _parameters);
                this.gridControl1.DataSource = mData;
            }
        }
    }
}
