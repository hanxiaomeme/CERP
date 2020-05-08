//※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※
//
//树控件的节点的 Tag 属性，记录 Tag = new string[] { 分类编码（如：DepCode）, 分类名称（如：DepName） };
//
//※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※
using DevComponents.AdvTree;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace LanyunMES.UI
{
    using Common;
    using Component;
    using DAL;
    using Model;
    using System.Data.SqlClient;
    using System.Drawing;

    public partial class FmMouldList : DevComponents.DotNetBar.OfficeForm
    {
        public FmMouldList()
        {
            InitializeComponent();
            this.Text = TreeM.Nodes[0].Text = pnl_Head.Text;

            this.Load += FmB_Load;
            this.btn_Add.Click += Add;
            this.btn_Edit.Click += Edit;
            this.btn_Del.Click += Delete;
            this.sGrid.DoubleClick += Edit;
        }


        private DataTable dtDetail;
        private string[] strWheres = null;
        private SqlParameter[] parameters = null;
        MouldDAL dal = new MouldDAL();
        MouldClassDAL dalC = new MouldClassDAL();


        protected virtual void InitGridColumn()
        {
            this.sGrid.AutoGenerateColumns = false;
            this.sGrid.MultiSelect = false;

            DataGridHelper.AddTextBoxColumn(sGrid, "cMCode", "设备编码");
            DataGridHelper.AddTextBoxColumn(sGrid, "cMName", "设备名称", 120);
            DataGridHelper.AddTextBoxColumn(sGrid, "cMCCode", "分类编码");
            DataGridHelper.AddTextBoxColumn(sGrid, "cMCName", "分类名称");
            DataGridHelper.AddTextBoxColumn(sGrid, "Points", "穴数");
            DataGridHelper.AddTextBoxColumn(sGrid, "cMaker", "建档人");
            DataGridHelper.AddTextBoxColumn(sGrid, "dCreateDate", "建档日期");
            DataGridHelper.AddCheckBoxColumn(sGrid, "bGroup", "成套模").ReadOnly = true;
        }

        protected virtual void FmB_Load(object sender, EventArgs e)
        {
            #region 窗体加载

            InitGridColumn();

            var treeData = dalC.GetList();

            TreeHelper.LoadAdvTree(TreeM, treeData, NodeClick);

            // 设置行高
            ImageList imgList = new ImageList();
            // 分别是宽和高
            imgList.ImageSize = new Size(1, 20);
            // 这里设置listView的SmallImageList ,用imgList将其撑大
            listView1.SmallImageList = imgList;
            listView2.SmallImageList = imgList;
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
            this.btn_Add.Enabled = true;
            this.btn_Edit.Enabled = this.btn_Del.Enabled = this.btn_Print.Enabled = this.sGrid.RowCount > 0;

            this.lblRowCount.Text = "";
            if (this.dtDetail != null)
                this.lblRowCount.Text = "已加载记录数:" + this.dtDetail.Rows.Count;


            #endregion
        }

        private void Add(object sender, EventArgs e)
        {
            #region 新增业务数据

            var node = TreeM.SelectedNode;

            var modelC = node.Tag as MouldClass;

            FmMould frm = new FmMould(modelC);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dtDetail = dal.GetDataTable(strWheres, parameters);
                UIRefresh();
            }

            #endregion
        }

        private void Edit(object sender, EventArgs e)
        {
            #region 编辑业务数据
            string id = (string)dtDetail.Rows[sGrid.CurrentRow.Index]["MId"];

            FmMould frm = new FmMould(id);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dtDetail = dal.GetDataTable(strWheres, parameters);
                this.UIRefresh();
            }
            #endregion
        }

        private void Delete(object sender, EventArgs e)
        {
            #region 删除业务数据
            if (MsgBox.ShowYesNoMsg("确定删除当前记录?") != DialogResult.Yes)
            {
                return;
            }

            string id = (string)dtDetail.Rows[sGrid.CurrentRow.Index]["MId"];

            if (dal.ExistsRef(id))
            {
                throw new Exception("设备已经被引用不能删除!");
            }
            else
            {
                dal.Delete(id);
                dtDetail = dal.GetDataTable(strWheres, parameters);
                UIRefresh();
            }

            #endregion
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btn_PrintDesgin_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            #region 导出Excel

            if (Export.ExpToExcel(sGrid))
            {
                MessageBox.Show("导出成功！");
            }

            #endregion
        }

        private void btnColSettings_Click(object sender, EventArgs e)
        {

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            #region 查询业务数据


            this.sGrid.Focus();
            #endregion
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            #region 刷新业务数据

            dtDetail = dal.GetDataTable(strWheres, parameters);
            UIRefresh();

            #endregion
        }


        private void LoadEqData(string MId)
        {
            #region 加载模具对应设备
            this.listView1.Items.Clear();

            DataTable dt = dal.GetEqDetails(MId);
            foreach (DataRow r in dt.Rows)
            {
                ListViewItem item = new ListViewItem(r["bClassDesc"].ToString());
                item.SubItems.Add(r["cEQCode"].ToString());
                item.SubItems.Add(r["cEQName"].ToString());
                item.SubItems.Add(r["iOrder"].ToString());
                item.SubItems.Add(r["iStep"].ToString());
                item.SubItems.Add(r["capacity"].ToString());
                item.Tag = r;

                this.listView1.Items.Add(item);
            } 
            #endregion
        }

        private void LoadInvData(string MId)
        {
            #region 加载模具对应产品
            this.listView2.Items.Clear();

            DataTable dt = dal.GetInvDetails(MId);
            foreach (DataRow r in dt.Rows)
            {
                ListViewItem item = new ListViewItem(r["cInvCode"].ToString());
                item.SubItems.Add(r["cInvName"].ToString());
                item.SubItems.Add(r["cInvStd"].ToString());
                item.SubItems.Add(r["iPoints"].ToString());
                item.Tag = r;

                this.listView2.Items.Add(item);
            } 
            #endregion
        }


        private void sGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string mid = dtDetail.Rows[e.RowIndex]["MId"].ToString();
            this.LoadEqData(mid);
            this.LoadInvData(mid);
        }

        private void BtnMouldEq_Click(object sender, EventArgs e)
        {
            #region 模具设备对应维护
            if (sGrid.CurrentRow == null)
            {
                throw new Exception("请先选择模具!");
            }

            string mid = dtDetail.Rows[sGrid.CurrentRow.Index]["MId"].ToString();

            FmMouldEq frm = new FmMouldEq(mid);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.LoadEqData(mid);
            } 
            #endregion
        }

        private void BtnInvMould_Click(object sender, EventArgs e)
        {
            #region 模具产品对应维护
            if (sGrid.CurrentRow == null)
            {
                throw new Exception("请先选择模具!");
            }

            string mid = dtDetail.Rows[sGrid.CurrentRow.Index]["MId"].ToString();
            FmMouldInv frm = new FmMouldInv(mid);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.LoadInvData(mid);
            } 
            #endregion
        }
    }
}