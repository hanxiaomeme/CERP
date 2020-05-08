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
    using Component;

    public partial class FmQMItemList : DevComponents.DotNetBar.OfficeForm
    {
        public FmQMItemList()
        {
            InitializeComponent();
            this.Text = TreeM.Nodes[0].Text = pnl_Head.Text;

            this.Load += FmB_Load;
            this.btn_Add.Click += Add;
            this.btn_Edit.Click += Edit;
            this.btn_Del.Click += DeleteClass;
            this.sGrid.DoubleClick += Edit;
        }


        private List<QMItem> QMList;
        private string[] strWheres = null;
        private dynamic paramList;

        private int currentQMCId;
        QMItemDAL dal = new QMItemDAL();
 
        protected virtual void InitGridColumn()
        {
            this.sGrid.AutoGenerateColumns = false;

            var col = DataGridHelper.AddTextBoxColumn(sGrid, "RowNo", "序号", 40);
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;

            DataGridHelper.AddTextBoxColumn(sGrid, "QMItemCode", "检验编码");
            DataGridHelper.AddTextBoxColumn(sGrid, "QMItemName", "检验名称", 120);
            DataGridHelper.AddTextBoxColumn(sGrid, "QMCCode", "项目编码");
            DataGridHelper.AddTextBoxColumn(sGrid, "QMCName", "项目名称");
            DataGridHelper.AddTextBoxColumn(sGrid, "cMaker", "建档人");
            DataGridHelper.AddTextBoxColumn(sGrid, "dCreateDate", "建档日期");

            this.sGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        protected virtual void FmB_Load(object sender, EventArgs e)
        {
            #region 窗体加载

            InitGridColumn();

            var treeData = new QMItemDAL().GetClassList();

            //TreeHelper.LoadAdvTree(TreeM, treeData, NodeClick);

            LoadAdvTree(TreeM, treeData, NodeClick);

            #endregion
        }

        protected virtual void NodeClick(object sender, EventArgs e)
        {
            #region 获取Node明细

            this.currentQMCId = Convert.ToInt32((sender as Node).Name);

            this.QMList = dal.GetList(currentQMCId);

            UIRefresh();

            #endregion
        }

        protected virtual void UIRefresh()
        {
            #region 刷新界面

            this.sGrid.DataSource = QMList;

            foreach(DataGridViewRow r in sGrid.Rows)
            {
                r.Cells["RowNo"].Value = r.Index + 1;
            }

            this.lblRowCount.Text = "已加载记录数:" + this.QMList.Count;

            #endregion
        }

        private void Add(object sender, System.EventArgs e)
        {
            FmQMItemClass frm = new FmQMItemClass();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var treeData = new QMItemDAL().GetClassList();

                LoadAdvTree(TreeM, treeData, NodeClick);
            }
        }  

        private void Edit(object sender, System.EventArgs e)
        {
            #region 编辑业务数据

            var eq = TreeM.SelectedNode.Tag as QMItemClass;

            FmQMItemClass frm = new FmQMItemClass(eq.QMCId);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var treeData = new QMItemDAL().GetClassList();

                LoadAdvTree(TreeM, treeData, NodeClick);
            }
            #endregion
        }

        /// <summary>
        /// 删除质检分类
        /// </summary>
        private void DeleteClass(object sender, System.EventArgs e)
        {
            #region 删除业务数据

            if(TreeM.SelectedIndex < 0)
            {
                throw new Exception("请选择要删除的质检分类!");
            }

            var itemClass = this.TreeM.SelectedNode.Tag as QMItemClass;

            if(dal.ExistChildClass(itemClass.QMCCode))
            {
                throw new Exception("存在下级分类不能删除!");
            }
            else if(dal.ExistChild(itemClass.QMCId))
            {
                throw new Exception("当前分类下存在质检项目,不能删除!");
            }

            if(MsgBox.ShowYesNoMsg("确定删除所选分类?") == DialogResult.Yes)
            {
                dal.DeleteClass(itemClass.QMCId);

                var treeData = new QMItemDAL().GetClassList();
                LoadAdvTree(TreeM, treeData, NodeClick);
            }

            #endregion
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


        private void btnAddItem_Click(object sender, EventArgs e)
        {
            #region 新增业务数据

            int qmcid = Convert.ToInt32(TreeM.SelectedNode.Name);

            FmQMItem frm = new FmQMItem(qmcid, 0);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.QMList = dal.GetList(qmcid);
                this.sGrid.DataSource = QMList;
            }

            #endregion
        }


        private void LoadAdvTree(AdvTree tree, List<QMItemClass> iModels, EventHandler NodeClick, bool showCode = true)
        {
            #region 加载AdvTree数据
            Node rootNode = tree.Nodes[0];
            Node node;

            rootNode.Nodes.Clear();

            foreach (QMItemClass iModel in iModels)
            {
                node = new Node();

                if (showCode)
                    node.Text = iModel.QMCCode + " - " + iModel.QMCName;
                else
                    node.Text = iModel.QMCName;

                node.Name = iModel.QMCId.ToString();
                node.Tag = iModel;
                if (NodeClick != null)
                {
                    node.NodeClick += new EventHandler(NodeClick);
                }
                if (tree.ImageList != null)
                {
                    node.Image = tree.ImageList.Images[0];
                }

                rootNode.Nodes.Add(node);

            }
            #endregion
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        private void btnDelItem_Click(object sender, EventArgs e)
        {
            if(sGrid.CurrentRow.Index < 0)
            {
                throw new Exception("没有选择删除行!");
            }

            var item = QMList[sGrid.CurrentRow.Index];

            if (MsgBox.ShowYesNoMsg("确定删除当前记录?") == DialogResult.Yes)
            {
                dal.Delete(item.QMItemId);

                this.QMList = dal.GetList(currentQMCId);

                UIRefresh();
            }
        }
    }
}