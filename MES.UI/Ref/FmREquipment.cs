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
                var col = DataGridHelper.AddCheckBoxColumn(sGrid, "bChecked", "选择", 50);
                col.Frozen = true;
                col.TrueValue = true;
                col.FalseValue = false;
            }

            DataGridHelper.AddTextBoxColumn(sGrid, "cEQCode", "设备编码").ReadOnly = true;
            DataGridHelper.AddTextBoxColumn(sGrid, "cEQName", "设备名称", 120).ReadOnly = true;
            DataGridHelper.AddTextBoxColumn(sGrid, "cEQCCode", "分类编码").ReadOnly = true;
            DataGridHelper.AddTextBoxColumn(sGrid, "cEQCName", "分类名称").ReadOnly = true;
            DataGridHelper.AddTextBoxColumn(sGrid, "OpCode", "工序编码").ReadOnly = true;
            DataGridHelper.AddTextBoxColumn(sGrid, "OpName", "工序名称", 110).ReadOnly = true;
            DataGridHelper.AddTextBoxColumn(sGrid, "workHours", "日工作效率/H").ReadOnly = true;
            DataGridHelper.AddTextBoxColumn(sGrid, "cMaker", "建档人").ReadOnly = true;
            DataGridHelper.AddTextBoxColumn(sGrid, "dCreateDate", "建档日期").ReadOnly = true;
        }

        protected virtual void FmB_Load(object sender, EventArgs e)
        {
            #region 窗体加载

            InitGridColumn();

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

            paramList = new { cEQCCode = cEQCCode };

            EqList = dal.GetList(strWheres, paramList);

            UIRefresh();

            #endregion
        }

        protected virtual void UIRefresh()
        {
            #region 刷新界面

            this.sGrid.DataSource = EqList;
            this.lblRowCount.Text = "已加载记录数:" + EqList.Count;

            //DataTable table = new DataTable();
            //DataColumn column = new DataColumn();
            ////AutoIncrement  获取或设置一个值，该值指示对于添加到该表中的新行，列是否将列的值自动递增  
            //column.AutoIncrement = true;
            //column.ColumnName = "RowNo";
            //column.AutoIncrementSeed = 1;
            //column.AutoIncrementStep = 1;
            //table.Columns.Add(column);
            ////Merge合并DataTable  
            //table.Merge(dtDetail);

            //this.sGrid.DataSource = table;
            //this.BtnReturn.Enabled = true;

            //this.lblRowCount.Text = "";
            //if (this.dtDetail != null)
            //    this.lblRowCount.Text = "已加载记录数:" + this.dtDetail.Rows.Count;


            #endregion
        }

        private void ReturnData(object sender, EventArgs e)
        {
            #region 新增业务数据

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
                    MsgBox.ShowInfoMsg("当前没有选中记录!");
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

    }
}