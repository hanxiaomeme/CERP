using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LanyunMES.UI
{
    using DAL;
    using Model;
    using Component;
    using DevComponents.AdvTree;
    using Common;

    public partial class FmREquipment : DevComponents.DotNetBar.OfficeForm
    {
        public FmREquipment(bool bMutiSelected = false)
        {
            InitializeComponent();

            this.bMutiSelected = bMutiSelected;
            this.Text = TreeM.Nodes[0].Text = pnl_Head.Text;

            this.Load += FmB_Load;
            this.BtnReturn.Click += ReturnData;

            if (!bMutiSelected)
            {
                this.sGrid.DoubleClick += ReturnData;
            }
        }

        public Equipment[] Results { get; private set; }

        private bool bMutiSelected;
        private List<Equipment> EqList;
        private string[] strWheres = null;
        private dynamic paramList;
        private EquipmentDAL dal = new EquipmentDAL();

        protected virtual void InitGridColumn()
        {
            this.sGrid.AutoGenerateColumns = false;

            if(bMutiSelected)
            {
                var col = DataGridHelper.AddCheckBoxColumn(sGrid, "bChecked", "ѡ��", 50);
                col.Frozen = true;
                col.TrueValue = true;
                col.FalseValue = false;
            }

            DataGridHelper.AddTextBoxColumn(sGrid, "cEQCode", "�豸����").ReadOnly = true;
            DataGridHelper.AddTextBoxColumn(sGrid, "cEQName", "�豸����", 120).ReadOnly = true;
            DataGridHelper.AddTextBoxColumn(sGrid, "cEQCCode", "�������").ReadOnly = true;
            DataGridHelper.AddTextBoxColumn(sGrid, "cEQCName", "��������").ReadOnly = true;
            DataGridHelper.AddTextBoxColumn(sGrid, "OpCode", "�������").ReadOnly = true;
            DataGridHelper.AddTextBoxColumn(sGrid, "OpName", "��������", 110).ReadOnly = true;
            DataGridHelper.AddTextBoxColumn(sGrid, "workHours", "�չ���Ч��/H").ReadOnly = true;
            DataGridHelper.AddTextBoxColumn(sGrid, "cMaker", "������").ReadOnly = true;
            DataGridHelper.AddTextBoxColumn(sGrid, "dCreateDate", "��������").ReadOnly = true;
        }

        protected virtual void FmB_Load(object sender, EventArgs e)
        {
            #region �������

            InitGridColumn();

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

            paramList = new { cEQCCode = cEQCCode };

            EqList = dal.GetList(strWheres, paramList);

            UIRefresh();

            #endregion
        }

        protected virtual void UIRefresh()
        {
            #region ˢ�½���

            this.sGrid.DataSource = EqList;
            this.lblRowCount.Text = "�Ѽ��ؼ�¼��:" + EqList.Count;

            //DataTable table = new DataTable();
            //DataColumn column = new DataColumn();
            ////AutoIncrement  ��ȡ������һ��ֵ����ֵָʾ������ӵ��ñ��е����У����Ƿ��е�ֵ�Զ�����  
            //column.AutoIncrement = true;
            //column.ColumnName = "RowNo";
            //column.AutoIncrementSeed = 1;
            //column.AutoIncrementStep = 1;
            //table.Columns.Add(column);
            ////Merge�ϲ�DataTable  
            //table.Merge(dtDetail);

            //this.sGrid.DataSource = table;
            //this.BtnReturn.Enabled = true;

            //this.lblRowCount.Text = "";
            //if (this.dtDetail != null)
            //    this.lblRowCount.Text = "�Ѽ��ؼ�¼��:" + this.dtDetail.Rows.Count;


            #endregion
        }

        private void ReturnData(object sender, EventArgs e)
        {
            #region ����ҵ������

            sGrid.EndEdit();

            if (bMutiSelected)
            {
                List<Equipment> list = new List<Equipment>();
                foreach (DataGridViewRow r in sGrid.Rows)
                {
                    if (r.Cells["bChecked"].Value != null && (bool)r.Cells["bChecked"].Value)
                    {                         
                        list.Add(EqList[r.Index]);
                    }
                }

                if (list.Count < 1)
                {
                    MsgBox.ShowInfoMsg("��ǰû��ѡ�м�¼!");
                    return;
                }

                Results = list.ToArray();
            }
            else
            {
                Results = new Equipment[] { EqList[sGrid.CurrentRow.Index] };
            }

            DialogResult = DialogResult.OK;

            #endregion
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

    }
}