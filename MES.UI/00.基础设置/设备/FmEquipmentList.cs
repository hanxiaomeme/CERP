//※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※
//
//树控件的节点的 Tag 属性，记录 Tag = new string[] { 分类编码（如：DepCode）, 分类名称（如：DepName） };
//
//※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevComponents.AdvTree;

namespace LanyunMES.UI
{
    using Model;
    using DAL;
    using Common;

    public partial class FmEquipmentList : DevComponents.DotNetBar.OfficeForm
    {
        public FmEquipmentList()
        {
            InitializeComponent();
            this.Text = TreeM.Nodes[0].Text = pnl_Head.Text;

            this.Load += FmB_Load;
            this.btn_Add.Click += Add;
            this.btn_Edit.Click += Edit;
            this.btn_Del.Click += Delete;
            this.sGrid.DoubleClick += Edit;
        }


        private List<Equipment> EqList;
        private string[] strWheres = null;
        private dynamic paramList;

        private Equipment currentEQ = null;

        EquipmentDAL dal = new EquipmentDAL();
 
        protected virtual void InitGridColumn()
        {
            this.sGrid.AutoGenerateColumns = false;

            var col = DataGridHelper.AddTextBoxColumn(sGrid, "RowNo", "序号", 40);
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;

            DataGridHelper.AddTextBoxColumn(sGrid, "cEQCode", "设备编码");
            DataGridHelper.AddTextBoxColumn(sGrid, "cEQName", "设备名称", 120);
            DataGridHelper.AddTextBoxColumn(sGrid, "cEQCCode", "分类编码");
            DataGridHelper.AddTextBoxColumn(sGrid, "cEQCName", "分类名称");
            //DataGridHelper.AddTextBoxColumn(sGrid, "OpCode", "工序编码");
            //DataGridHelper.AddTextBoxColumn(sGrid, "OpName", "工序名称", 110);
            DataGridHelper.AddTextBoxColumn(sGrid, "workHours", "日工作效率/H");
            DataGridHelper.AddCheckBoxColumn(sGrid, "bStop", "是否停用");
            DataGridHelper.AddTextBoxColumn(sGrid, "cMaker", "建档人", 80);
            DataGridHelper.AddTextBoxColumn(sGrid, "dCreateDate", "建档日期");

            this.sGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        protected virtual void InitGridColumnOP()
        {
            this.GridOP.AutoGenerateColumns = false;
            DataGridHelper.AddTextBoxColumn(GridOP, "OpCode", "工序编码");
            DataGridHelper.AddTextBoxColumn(GridOP, "OpName", "工序名称", 110);
            DataGridHelper.AddTextBoxColumn(GridOP, "cycleTime", "节拍/min");

            this.GridOP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        protected virtual void FmB_Load(object sender, EventArgs e)
        {
            #region 窗体加载

            InitGridColumn();

            InitGridColumnOP();

            var treeData = new EquipmentClassDAL().GetList();

            TreeHelper.LoadAdvTree(TreeM, treeData, NodeClick);

            #endregion
        }

        protected virtual void NodeClick(object sender, EventArgs e)
        {
            #region 获取Node明细

            string cEQCCode = (sender as Node).Name;

            strWheres = new string[]
            {
                "cEQCCode like @cEQCCode + '%'"
            };

            this.paramList = new { @cEQCCode = cEQCCode };

            this.EqList = dal.GetList(strWheres, paramList);

            if (EqList.Count > 0)
            {
                this.currentEQ = EqList[0];

            }

            UIRefresh();

            #endregion
        }

        protected virtual void UIRefresh()
        {
            #region 刷新界面

            this.sGrid.DataSource = EqList;

            foreach(DataGridViewRow r in sGrid.Rows)
            {
                r.Cells["RowNo"].Value = r.Index + 1;
            }

            this.lblRowCount.Text = "已加载记录数:" + this.EqList.Count;

            #endregion
        }

        private void Add(object sender, System.EventArgs e)
        {
            #region 新增业务数据

            EquipmentClass modelC = null;

            if (TreeM.SelectedNode != null)
            {
                var node = TreeM.SelectedNode;

                modelC = node.Tag as EquipmentClass;
            }

            FmEquipment frm = new FmEquipment(modelC);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                EqList = dal.GetList(strWheres, paramList);
                UIRefresh();
            }

            #endregion
        }

        private void Edit(object sender, System.EventArgs e)
        {
            #region 编辑业务数据

            var eq = EqList[sGrid.CurrentRow.Index];

            FmEquipment frm = new FmEquipment(eq.EQId);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                EqList = dal.GetList(strWheres, paramList);
                this.UIRefresh();
            }
            #endregion
        }

        private void Delete(object sender, System.EventArgs e)
        {
            #region 删除业务数据

            var eq = EqList[sGrid.CurrentRow.Index];

            if (dal.ExistsRef(eq.EQId))
            {
                throw new Exception("设备已经被引用不能删除!");
            }
            else
            {
                dal.Delete(eq.EQId);
                EqList = dal.GetList(strWheres, paramList);
                UIRefresh();
            }

            #endregion
        }


        private void btnPrint_Click(object sender, System.EventArgs e)
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

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            #region 刷新业务数据

            EqList = dal.GetList(strWheres, paramList);
            UIRefresh();

            #endregion
        }

        private void sGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.currentEQ = EqList[e.RowIndex];

            this.GridOP.DataSource = dal.GetDTable(currentEQ.EQId);

        }
    }
}