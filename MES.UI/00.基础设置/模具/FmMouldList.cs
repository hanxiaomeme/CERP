//������������������������������������������������������������������������������������������������������������������������������
//
//���ؼ��Ľڵ�� Tag ���ԣ���¼ Tag = new string[] { ������루�磺DepCode��, �������ƣ��磺DepName�� };
//
//������������������������������������������������������������������������������������������������������������������������������
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

            DataGridHelper.AddTextBoxColumn(sGrid, "cMCode", "�豸����");
            DataGridHelper.AddTextBoxColumn(sGrid, "cMName", "�豸����", 120);
            DataGridHelper.AddTextBoxColumn(sGrid, "cMCCode", "�������");
            DataGridHelper.AddTextBoxColumn(sGrid, "cMCName", "��������");
            DataGridHelper.AddTextBoxColumn(sGrid, "Points", "Ѩ��");
            DataGridHelper.AddTextBoxColumn(sGrid, "cMaker", "������");
            DataGridHelper.AddTextBoxColumn(sGrid, "dCreateDate", "��������");
            DataGridHelper.AddCheckBoxColumn(sGrid, "bGroup", "����ģ").ReadOnly = true;
        }

        protected virtual void FmB_Load(object sender, EventArgs e)
        {
            #region �������

            InitGridColumn();

            var treeData = dalC.GetList();

            TreeHelper.LoadAdvTree(TreeM, treeData, NodeClick);

            // �����и�
            ImageList imgList = new ImageList();
            // �ֱ��ǿ�͸�
            imgList.ImageSize = new Size(1, 20);
            // ��������listView��SmallImageList ,��imgList����Ŵ�
            listView1.SmallImageList = imgList;
            listView2.SmallImageList = imgList;
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
            this.btn_Add.Enabled = true;
            this.btn_Edit.Enabled = this.btn_Del.Enabled = this.btn_Print.Enabled = this.sGrid.RowCount > 0;

            this.lblRowCount.Text = "";
            if (this.dtDetail != null)
                this.lblRowCount.Text = "�Ѽ��ؼ�¼��:" + this.dtDetail.Rows.Count;


            #endregion
        }

        private void Add(object sender, EventArgs e)
        {
            #region ����ҵ������

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
            #region �༭ҵ������
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
            #region ɾ��ҵ������
            if (MsgBox.ShowYesNoMsg("ȷ��ɾ����ǰ��¼?") != DialogResult.Yes)
            {
                return;
            }

            string id = (string)dtDetail.Rows[sGrid.CurrentRow.Index]["MId"];

            if (dal.ExistsRef(id))
            {
                throw new Exception("�豸�Ѿ������ò���ɾ��!");
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            #region ˢ��ҵ������

            dtDetail = dal.GetDataTable(strWheres, parameters);
            UIRefresh();

            #endregion
        }


        private void LoadEqData(string MId)
        {
            #region ����ģ�߶�Ӧ�豸
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
            #region ����ģ�߶�Ӧ��Ʒ
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
            #region ģ���豸��Ӧά��
            if (sGrid.CurrentRow == null)
            {
                throw new Exception("����ѡ��ģ��!");
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
            #region ģ�߲�Ʒ��Ӧά��
            if (sGrid.CurrentRow == null)
            {
                throw new Exception("����ѡ��ģ��!");
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