using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Text;
using System.Windows.Forms;

namespace LanyunMES.UI
{
    using Model;
    using DAL;
    using U8Ext.Ref;
    using DevExpressUtility;

    public partial class FmMouldEqInvAdd : DevComponents.DotNetBar.OfficeForm
    {

        private FmMouldEqInvAdd()
        {
            InitializeComponent();

            this.Text = tab_Main.Text = this.lblModuleTitle.Text;
            this.Load += FormLoad;
            this.txtr_cInvCode.ButtonCustomClick += RefInventory;
        }

        public FmMouldEqInvAdd(string MId, OpState op = OpState.Update) :this()
        {
            this.MId = MId;
        }

        public string[] InvArry { get; private set; }
        public List<DataRow> rowList { get; private set; } = new List<DataRow>();

        private string MId;
        private DataTable dtMouldEq;
        private MouldDAL dal = new MouldDAL();

        private void FormLoad(object sender, EventArgs e)
        {
            #region 加载主窗体事件

            this.InitColumns();
            this.dtMouldEq = dal.GetEqDetails(MId);
            this.gridControl1.DataSource = dtMouldEq;

            #endregion
        }

        private void InitColumns()
        {
            Grid.OptionsBehavior.AutoPopulateColumns = false;

            GridViewHelper.AddColumn(Grid, "bClassDesc", "设备类别", 90);
            GridViewHelper.AddColumn(Grid, "cEQCode", "编码", 100);
            GridViewHelper.AddColumn(Grid, "cEQName", "名称", 100);
            GridViewHelper.AddColumn(Grid, "cEQCName", "设备分类", 100);
            GridViewHelper.AddColumn(Grid, "iOrder", "优先级", 60);

            Grid.OptionsView.ColumnAutoWidth = true;
        }
 
        private void RefInventory(object seder, EventArgs e)
        {
            IRefDAL dal = new InventoryDAL(Information.UserInfo.ConnU8);
            RefForm frm = new RefForm(dal);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var result = frm.rows[0];

                InvArry = new string[]
                {
                    result["cInvCode"].ToString(),
                    result["cInvCode"].ToString(),
                    result["cInvStd"].ToString()
                };

                this.txtr_cInvCode.Text = InvArry[0];
                this.txtr_cInvName.Text = InvArry[1];
                this.txtr_cInvStd.Text = InvArry[2];
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if(InvArry == null)
            {
                throw new Exception("请先选择存货!");
            }
            else if(Grid.SelectedRowsCount < 1)
            {
                throw new Exception("没有选择设置!");
            }

            foreach(int handle in Grid.GetSelectedRows())
            {
                rowList.Add(Grid.GetDataRow(handle));
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}