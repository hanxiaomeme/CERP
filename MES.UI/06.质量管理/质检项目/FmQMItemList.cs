//������������������������������������������������������������������������������������������������������������������������������
//
//���ؼ��Ľڵ�� Tag ���ԣ���¼ Tag = new string[] { ������루�磺DepCode��, �������ƣ��磺DepName�� };
//
//������������������������������������������������������������������������������������������������������������������������������
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

            var col = DataGridHelper.AddTextBoxColumn(sGrid, "RowNo", "���", 40);
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;

            DataGridHelper.AddTextBoxColumn(sGrid, "QMItemCode", "�������");
            DataGridHelper.AddTextBoxColumn(sGrid, "QMItemName", "��������", 120);
            DataGridHelper.AddTextBoxColumn(sGrid, "QMCCode", "��Ŀ����");
            DataGridHelper.AddTextBoxColumn(sGrid, "QMCName", "��Ŀ����");
            DataGridHelper.AddTextBoxColumn(sGrid, "cMaker", "������");
            DataGridHelper.AddTextBoxColumn(sGrid, "dCreateDate", "��������");

            this.sGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        protected virtual void FmB_Load(object sender, EventArgs e)
        {
            #region �������

            InitGridColumn();

            var treeData = new QMItemDAL().GetClassList();

            //TreeHelper.LoadAdvTree(TreeM, treeData, NodeClick);

            LoadAdvTree(TreeM, treeData, NodeClick);

            #endregion
        }

        protected virtual void NodeClick(object sender, EventArgs e)
        {
            #region ��ȡNode��ϸ

            this.currentQMCId = Convert.ToInt32((sender as Node).Name);

            this.QMList = dal.GetList(currentQMCId);

            UIRefresh();

            #endregion
        }

        protected virtual void UIRefresh()
        {
            #region ˢ�½���

            this.sGrid.DataSource = QMList;

            foreach(DataGridViewRow r in sGrid.Rows)
            {
                r.Cells["RowNo"].Value = r.Index + 1;
            }

            this.lblRowCount.Text = "�Ѽ��ؼ�¼��:" + this.QMList.Count;

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
            #region �༭ҵ������

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
        /// ɾ���ʼ����
        /// </summary>
        private void DeleteClass(object sender, System.EventArgs e)
        {
            #region ɾ��ҵ������

            if(TreeM.SelectedIndex < 0)
            {
                throw new Exception("��ѡ��Ҫɾ�����ʼ����!");
            }

            var itemClass = this.TreeM.SelectedNode.Tag as QMItemClass;

            if(dal.ExistChildClass(itemClass.QMCCode))
            {
                throw new Exception("�����¼����಻��ɾ��!");
            }
            else if(dal.ExistChild(itemClass.QMCId))
            {
                throw new Exception("��ǰ�����´����ʼ���Ŀ,����ɾ��!");
            }

            if(MsgBox.ShowYesNoMsg("ȷ��ɾ����ѡ����?") == DialogResult.Yes)
            {
                dal.DeleteClass(itemClass.QMCId);

                var treeData = new QMItemDAL().GetClassList();
                LoadAdvTree(TreeM, treeData, NodeClick);
            }

            #endregion
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            #region ����Excel

            if (Export.ExpToExcel(sGrid))
            {
                MessageBox.Show("�����ɹ���");
            }

            #endregion
        }


        private void btnAddItem_Click(object sender, EventArgs e)
        {
            #region ����ҵ������

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
            #region ����AdvTree����
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
        /// ɾ����¼
        /// </summary>
        private void btnDelItem_Click(object sender, EventArgs e)
        {
            if(sGrid.CurrentRow.Index < 0)
            {
                throw new Exception("û��ѡ��ɾ����!");
            }

            var item = QMList[sGrid.CurrentRow.Index];

            if (MsgBox.ShowYesNoMsg("ȷ��ɾ����ǰ��¼?") == DialogResult.Yes)
            {
                dal.Delete(item.QMItemId);

                this.QMList = dal.GetList(currentQMCId);

                UIRefresh();
            }
        }
    }
}