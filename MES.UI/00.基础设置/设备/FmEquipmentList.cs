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

            var col = DataGridHelper.AddTextBoxColumn(sGrid, "RowNo", "���", 40);
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;

            DataGridHelper.AddTextBoxColumn(sGrid, "cEQCode", "�豸����");
            DataGridHelper.AddTextBoxColumn(sGrid, "cEQName", "�豸����", 120);
            DataGridHelper.AddTextBoxColumn(sGrid, "cEQCCode", "�������");
            DataGridHelper.AddTextBoxColumn(sGrid, "cEQCName", "��������");
            //DataGridHelper.AddTextBoxColumn(sGrid, "OpCode", "�������");
            //DataGridHelper.AddTextBoxColumn(sGrid, "OpName", "��������", 110);
            DataGridHelper.AddTextBoxColumn(sGrid, "workHours", "�չ���Ч��/H");
            DataGridHelper.AddCheckBoxColumn(sGrid, "bStop", "�Ƿ�ͣ��");
            DataGridHelper.AddTextBoxColumn(sGrid, "cMaker", "������", 80);
            DataGridHelper.AddTextBoxColumn(sGrid, "dCreateDate", "��������");

            this.sGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        protected virtual void InitGridColumnOP()
        {
            this.GridOP.AutoGenerateColumns = false;
            DataGridHelper.AddTextBoxColumn(GridOP, "OpCode", "�������");
            DataGridHelper.AddTextBoxColumn(GridOP, "OpName", "��������", 110);
            DataGridHelper.AddTextBoxColumn(GridOP, "cycleTime", "����/min");

            this.GridOP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        protected virtual void FmB_Load(object sender, EventArgs e)
        {
            #region �������

            InitGridColumn();

            InitGridColumnOP();

            var treeData = new EquipmentClassDAL().GetList();

            TreeHelper.LoadAdvTree(TreeM, treeData, NodeClick);

            #endregion
        }

        protected virtual void NodeClick(object sender, EventArgs e)
        {
            #region ��ȡNode��ϸ

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
            #region ˢ�½���

            this.sGrid.DataSource = EqList;

            foreach(DataGridViewRow r in sGrid.Rows)
            {
                r.Cells["RowNo"].Value = r.Index + 1;
            }

            this.lblRowCount.Text = "�Ѽ��ؼ�¼��:" + this.EqList.Count;

            #endregion
        }

        private void Add(object sender, System.EventArgs e)
        {
            #region ����ҵ������

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
            #region �༭ҵ������

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
            #region ɾ��ҵ������

            var eq = EqList[sGrid.CurrentRow.Index];

            if (dal.ExistsRef(eq.EQId))
            {
                throw new Exception("�豸�Ѿ������ò���ɾ��!");
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
            #region ����Excel

            if (Export.ExpToExcel(sGrid))
            {
                MessageBox.Show("�����ɹ���");
            }

            #endregion
        }

        private void btnColSettings_Click(object sender, EventArgs e)
        {

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            #region ��ѯҵ������


            this.sGrid.Focus();
            #endregion
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            #region ˢ��ҵ������

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