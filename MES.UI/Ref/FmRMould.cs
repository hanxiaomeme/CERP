//※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※
//
//树控件的节点的 Tag 属性，记录 Tag = new string[] { 分类编码（如：DepCode）, 分类名称（如：DepName） };
//
//※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using DevComponents.AdvTree;
using System.Data.SqlClient;

namespace LanyunMES.UI
{
    using Common;
    using Model;
    using DAL;


    public partial class FmRMould : DevComponents.DotNetBar.OfficeForm
    {
        public FmRMould()
        {
            InitializeComponent();
            this.Text = TreeM.Nodes[0].Text = pnl_Head.Text;

            this.Load += FmB_Load;
            this.BtnReturn.Click += ReturnData;
            this.sGrid.DoubleClick += ReturnData;
        }


        public Mould Result { get; private set; }

        private DataTable dtDetail;
        private string[] strWheres = null;
        private SqlParameter[] parameters = null;
        MouldDAL dal = new MouldDAL();
        MouldClassDAL dalC = new MouldClassDAL();

        protected virtual void InitGridColumn()
        {
            this.sGrid.AutoGenerateColumns = false;

            DataGridHelper.AddTextBoxColumn(sGrid, "cMCode", "模具编码");
            DataGridHelper.AddTextBoxColumn(sGrid, "cMName", "模具名称", 120);
            DataGridHelper.AddTextBoxColumn(sGrid, "cMCCode", "分类编码");
            DataGridHelper.AddTextBoxColumn(sGrid, "cMCName", "分类名称");
            DataGridHelper.AddTextBoxColumn(sGrid, "Points", "穴数");
            DataGridHelper.AddTextBoxColumn(sGrid, "cMaker", "建档人");
            DataGridHelper.AddTextBoxColumn(sGrid, "dCreateDate", "建档日期");
        }

        protected virtual void FmB_Load(object sender, EventArgs e)
        {
            #region 窗体加载

            InitGridColumn();

            var treeData = dalC.GetList();

            TreeHelper.LoadAdvTree(TreeM, treeData, NodeClick);

            #endregion
        }

        protected virtual void NodeClick(object sender, EventArgs e)
        {
            #region 获取Node明细

            string cMCCode = (sender as Node).Name;

            strWheres = new string[]
            {
                "cMCCode like @cMCCode + '%'"
            };

            parameters = new SqlParameter[]
            {
                new SqlParameter("@cMCCode", cMCCode)
            };

            dtDetail = dal.GetDataTable(strWheres, parameters);

            UIRefresh();

            #endregion
        }

        protected virtual void UIRefresh()
        {
            #region 刷新界面

            DataTable table = new DataTable();
            DataColumn column = new DataColumn();
            //AutoIncrement  获取或设置一个值，该值指示对于添加到该表中的新行，列是否将列的值自动递增  
            column.AutoIncrement = true;
            column.ColumnName = "RowNo";
            column.AutoIncrementSeed = 1;
            column.AutoIncrementStep = 1;
            table.Columns.Add(column);
            //Merge合并DataTable  
            table.Merge(dtDetail);

            this.sGrid.DataSource = table;
            this.BtnReturn.Enabled = true;

            this.lblRowCount.Text = "";
            if (this.dtDetail != null)
                this.lblRowCount.Text = "已加载记录数:" + this.dtDetail.Rows.Count;


            #endregion
        }

        private void ReturnData(object sender, EventArgs e)
        {
            #region 新增业务数据

            string mid = (string)dtDetail.Rows[sGrid.CurrentRow.Index]["MId"];

            Result = dal.Get(mid);

            DialogResult = DialogResult.OK;

            #endregion
        }


        private void btnQuery_Click(object sender, EventArgs e)
        {
            #region 查询业务数据


            this.sGrid.Focus();
            #endregion
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            #region 刷新业务数据

            dtDetail = dal.GetDataTable(strWheres, parameters);
            UIRefresh();

            #endregion
        }

    }
}