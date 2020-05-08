using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FastReport;

namespace LanyunMES.UI
{
    using DAL.U8;

    using DevExpressUtility;

    public partial class FmRRouter : DevComponents.DotNetBar.OfficeForm
    {
        private FmRRouter()
        {
            InitializeComponent();
            //窗体标题
            this.Text = pnl_title.Text;
            //窗体加载
            this.Load += Fm_Load;
            //查询
            this.btn_Query.Click += Query;
            //导出Excel
            this.btn_Export.Click += ExportExcel;
            //返回数据
            this.Btn_OK.Click += GetResult;
        }

        public FmRRouter(string cInvCode) : this()
        {
            this.cInvCode = cInvCode;
        }

        private DataTable mData = null;
        private string cInvCode;
        private U8PRoutingDAL dal = new U8PRoutingDAL();

        public DataRow[] selectRows { get; private set; }


        protected void Fm_Load(object sender, EventArgs e)
        {
            this.ShowQueryPnl(false);  
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

            var col = GridViewHelper.AddColumn(gridView1, "cInvCode", "存货编码", 120);
            col.Summary.Add(DevExpress.Data.SummaryItemType.Count);
            col.Summary[0].FieldName = "cInvCode";
            col.Summary[0].DisplayFormat = "{记录: 0}";

            GridViewHelper.AddColumn(gridView1, "cInvName", "存货名称", 120);
            GridViewHelper.AddColumn(gridView1, "cInvStd", "规格型号", 120);
            GridViewHelper.AddColumn(gridView1, "OpSeq", "工序序号", 90);
            GridViewHelper.AddColumn(gridView1, "OpCode", "工序编码", 90);
            GridViewHelper.AddColumn(gridView1, "OpName", "工序名称", 90);

        }

        protected virtual void Query(object sender, EventArgs e)
        {

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



        //---------------------合计行-------------------------------------


        private void LoadData()
        {
            this.mData = dal.GetList(cInvCode);
            this.gridControl1.DataSource = mData;
        }

        private void ShowQueryPnl(bool bShow)
        {
            #region 显示隐藏查询界面
            this.splitContainer1.Panel1Collapsed = !bShow;
            #endregion
        }

    }
}
