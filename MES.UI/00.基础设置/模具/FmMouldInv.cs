using System;
using System.Data;
using System.Windows.Forms;

namespace LanyunMES.UI
{
    using Common;
    using Component;
    using DAL;
    using Model;
    using U8Ext.Ref;

    public partial class FmMouldInv : DevComponents.DotNetBar.OfficeForm
    {

        private FmMouldInv()
        {
            InitializeComponent();

            this.Text = tab_Main.Text = this.lblModuleTitle.Text;
            this.Load += FormLoad;
            this.btn_DelLine.Click += DeleteLine;
            this.btn_up.Click += btn_up_Click;
            this.btn_down.Click += btn_down_Click;
            this.btn_Save.Click += Save;
        }

        public FmMouldInv(string MId) :this()
        {
            this.MId = MId;
            this.model = dal.Get(MId);
        }

        private string MId;
        private Mould model;
        private DataTable dtInvDetails;
        private OpState opState = OpState.Update;
        private MouldDAL dal = new MouldDAL();


        private void FormLoad(object sender, EventArgs e)
        {
            #region 加载主窗体事件

            this.InitColumns();     
            this.dtInvDetails = dal.GetInvDetails(MId);
            this.Grid.DataSource = dtInvDetails;

            UIBinding<Mould>.UIDataBinding(panelEx1, model);

            #endregion
        }

        private void InitColumns()
        {
            Grid.AutoGenerateColumns = false;
            Grid.RowHeadersVisible = false;
            Grid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            Grid.AllowUserToAddRows = false;

            //DataGridHelper.AddColumn(Grid, "GroupId", "");
            DataGridHelper.AddTextBoxColumn(Grid, "cInvCode", "产品编码", 100).ReadOnly = true;
            DataGridHelper.AddTextBoxColumn(Grid, "cInvName", "产品名称", 100).ReadOnly = true;
            DataGridHelper.AddTextBoxColumn(Grid, "cInvStd", "规格型号", 100).ReadOnly = true;
            
            var col = DataGridHelper.AddTextBoxColumn(Grid, "iPoints", "穴数", 60);
            col.ReadOnly = !model.bGroup;
        }

        private void Save(object sender, EventArgs e)
        {
            this.Grid.EndEdit();

            if (string.IsNullOrEmpty(model.cMCode))
            {
                throw new Exception("模具不能为空!");
            }
            else if (model.bGroup)
            {
                if(dtInvDetails.Rows.Count < 2)
                {
                    throw new Exception("成套模至少需要两个产品记录!");
                }

                int points = 0;
                foreach (DataRow r in dtInvDetails.Rows)
                {
                    if (r["iPoints"] == DBNull.Value || (int)r["iPoints"] <= 0)
                    {
                        throw new Exception("穴数不能为空或小等于0!");
                    }

                    points += (int)r["iPoints"];
                }

                if(model.Points != points)
                {
                    throw new Exception("总穴数和模具穴数不匹配");
                }
            }

            dal.AddInv(MId, dtInvDetails);

            this.DialogResult = DialogResult.OK;
        }

        private void DeleteLine(object sender, EventArgs e)
        {
            DataRow row = dtInvDetails.Rows[Grid.CurrentRow.Index];
            dtInvDetails.Rows.Remove(row);
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            #region 退出模块

            if (this.opState != OpState.Browse)
            {
                if (MsgBox.ShowYesNoMsg("当前数据尚未保存，是否退出？") == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }

            #endregion
        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            DataGridHelper.MoveRow(Grid, MoveState.previous);
        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            DataGridHelper.MoveRow(Grid, MoveState.next);
        }

        private void btn_AddLine_Click(object sender, EventArgs e)
        {
            IRefDAL dal = new InventoryDAL(Information.UserInfo.ConnU8);
            RefForm frm = new RefForm(dal);
            if(frm.ShowDialog() == DialogResult.OK)
            {
                var row = this.dtInvDetails.NewRow();
                row["MId"] = model.MId;
                row["cMCode"] = model.cMCode;
                row["cMName"] = model.cMName;
                row["cInvCode"] = frm.rows[0]["cInvCode"];
                row["cInvName"] = frm.rows[0]["cInvName"];
                row["cInvStd"] = frm.rows[0]["cInvStd"];
                row["iPoints"] = model.Points;
                dtInvDetails.Rows.Add(row);
            }
        }

    }
}