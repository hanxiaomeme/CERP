//������������������������������������������������������������������������������������������������������������������������������
//
//���ؼ��Ľڵ�� Tag ���ԣ���¼ Tag = new string[] { ������루�磺DepCode��, �������ƣ��磺DepName�� };
//
//������������������������������������������������������������������������������������������������������������������������������
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

            DataGridHelper.AddTextBoxColumn(sGrid, "cMCode", "ģ�߱���");
            DataGridHelper.AddTextBoxColumn(sGrid, "cMName", "ģ������", 120);
            DataGridHelper.AddTextBoxColumn(sGrid, "cMCCode", "�������");
            DataGridHelper.AddTextBoxColumn(sGrid, "cMCName", "��������");
            DataGridHelper.AddTextBoxColumn(sGrid, "Points", "Ѩ��");
            DataGridHelper.AddTextBoxColumn(sGrid, "cMaker", "������");
            DataGridHelper.AddTextBoxColumn(sGrid, "dCreateDate", "��������");
        }

        protected virtual void FmB_Load(object sender, EventArgs e)
        {
            #region �������

            InitGridColumn();

            var treeData = dalC.GetList();

            TreeHelper.LoadAdvTree(TreeM, treeData, NodeClick);

            #endregion
        }

        protected virtual void NodeClick(object sender, EventArgs e)
        {
            #region ��ȡNode��ϸ

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
            #region ˢ�½���

            DataTable table = new DataTable();
            DataColumn column = new DataColumn();
            //AutoIncrement  ��ȡ������һ��ֵ����ֵָʾ������ӵ��ñ��е����У����Ƿ��е�ֵ�Զ�����  
            column.AutoIncrement = true;
            column.ColumnName = "RowNo";
            column.AutoIncrementSeed = 1;
            column.AutoIncrementStep = 1;
            table.Columns.Add(column);
            //Merge�ϲ�DataTable  
            table.Merge(dtDetail);

            this.sGrid.DataSource = table;
            this.BtnReturn.Enabled = true;

            this.lblRowCount.Text = "";
            if (this.dtDetail != null)
                this.lblRowCount.Text = "�Ѽ��ؼ�¼��:" + this.dtDetail.Rows.Count;


            #endregion
        }

        private void ReturnData(object sender, EventArgs e)
        {
            #region ����ҵ������

            string mid = (string)dtDetail.Rows[sGrid.CurrentRow.Index]["MId"];

            Result = dal.Get(mid);

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

            dtDetail = dal.GetDataTable(strWheres, parameters);
            UIRefresh();

            #endregion
        }

    }
}