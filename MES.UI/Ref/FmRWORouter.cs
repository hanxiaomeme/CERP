using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LanyunMES.UI
{
    using DAL;
    using DevExpressUtility;

    public partial class FmRWORouter : DevComponents.DotNetBar.OfficeForm
    {
        public FmRWORouter()
        {
            InitializeComponent();
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
        private WorkOrderDAL dal = new WorkOrderDAL();

        public DataRow[] selectRows { get; private set; }


        protected void Fm_Load(object sender, EventArgs e)
        {
            this.InitGrid();
            this.LoadData();
        }

        protected virtual void InitGrid()
        {
            gridView1.OptionsBehavior.AutoPopulateColumns = false;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.ShowFooter = true;
            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 50;

            var col = GridViewHelper.AddColumn(gridView1, "WOCode", "工单", 120);
            col.Summary.Add(DevExpress.Data.SummaryItemType.Count);
            col.Summary[0].FieldName = "WOCode";
            col.Summary[0].DisplayFormat = "{记录: 0}";

            GridViewHelper.AddColumn(gridView1, "cInvCode", "存货编码", 120);
            GridViewHelper.AddColumn(gridView1, "cInvName", "存货名称", 120);
            GridViewHelper.AddColumn(gridView1, "cInvStd", "规格型号", 120);
            GridViewHelper.AddColumn(gridView1, "OpSeq", "工序序号");
            GridViewHelper.AddColumn(gridView1, "OpCode", "工序编码");
            GridViewHelper.AddColumn(gridView1, "OpName", "工序名称");
            GridViewHelper.AddColumn(gridView1, "iQuantity", "数量");
            GridViewHelper.AddColumn(gridView1, "cComUnitName", "单位");
            GridViewHelper.AddColumn(gridView1, "RepQty", "已报工数量");
            GridViewHelper.AddColumn(gridView1, "MoCode", "生产订单号");
            GridViewHelper.AddColumn(gridView1, "SortSeq", "订单行号");
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
                this.selectRows = ls.ToArray();
                this.DialogResult = DialogResult.OK;
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
            string[] wheres = new string[]
            {
                "isnull(repQty,0) < iQuantity"
            };

            this.mData = dal.GetRouter(wheres);
            this.gridControl1.DataSource = mData;
        }

    }
}
