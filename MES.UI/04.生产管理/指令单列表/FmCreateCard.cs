using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data;

namespace MES.UI
{
    using Model;
    using DAL;
    using Common;
    using Server.Model;

    public partial class FmCreateCard : DevComponents.DotNetBar.Metro.MetroForm
    {
        public FmCreateCard(string guid)
        {
            InitializeComponent();
            this.Load += FmLoad;
            txt_curQuantity.KeyPress += UICtrl.TextBox_NumOnly;

            this.model = dal.Get(guid);
        }

        private Model.WorkOrder model;
        private WorkOrderDAL dal = new WorkOrderDAL();
        private string cardNo;

        private void FmLoad(object sender, EventArgs e)
        {
            if (model != null)
            {
                this.GridChild.AutoGenerateColumns = false;
                UIBinding<Model.WorkOrder>.UIDataBinding(groupBox1, model);
                this.LoadChildren();
                this.LoadOperation();
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            double iQuantity = Convert.ToDouble(txt_curQuantity.Text);
            double leftQty = model.iQuantity - model.MCardQuantity;

            if (iQuantity > leftQty)
            {
                throw new Exception("流转卡合计数量不能大于指令单数量,剩余可开卡数量: " + leftQty);
            }
 
            CardMain cardM = new CardMain();
            cardM.bChild = false;
            cardM.WOGuid = model.Guid;
            cardM.cInvCode = model.cInvCode;
            cardM.iQuantity = iQuantity;
            cardM.cMaker = Information.UserInfo.cUser_Name;

            List<DataRow> list = new List<DataRow>();
            List<DataRow> children = new List<DataRow>();

            foreach(ListViewItem item in listView1.Items)
            {
                list.Add(item.Tag as DataRow);
            }

            foreach (DataRowView r in model.WorkOrderDetail.DefaultView)
            {                
                children.Add(r.Row);
            }

            this.cardNo = new MCardDAL().CreateCard(cardM, list.ToArray(), children.ToArray());
            this.txtr_cardNo.Text = cardNo;

            this.BtnCreate.Enabled = false;
            this.BtnAddOp.Enabled = false;
            this.BtnDelOp.Enabled = false;
            this.BtnDelChild.Enabled = false;
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            #region 打印

            if (string.IsNullOrEmpty(cardNo))
            {
                throw new Exception("未生成流转卡!");
            }

            MCardDAL mdal = new MCardDAL();
            

            DataTable dtMain = mdal.GetHead(cardNo);
            DataTable dtDetail = mdal.GetBody(cardNo);

            string path =  ".\\ReportPrint\\产品跟踪卡.frx";

            var rep = FReportHelper.GetReport(path, dtMain, dtDetail);
            rep.Show();
            
            #endregion
        }

        private void AddOperation(object sender, EventArgs e)
        {
            FmRWOOperation frm = new FmRWOOperation(model.Guid);
            if(frm.ShowDialog() == DialogResult.OK)
            {
                foreach (DataRow r in frm.RowResult)
                {
                    ListViewItem item = new ListViewItem("");
                    item.Tag = r;
                    item.SubItems.Add(r["OpName"].ToString());
                    listView1.Items.Add(item);
                }

                SetOpSeq();
            }
        }

        private void DelOperation(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count < 1)
            {
                throw new Exception("没有选中记录!");
            }

            var item = listView1.SelectedItems[0];

            var rowRouter = item.Tag as DataRow;

            int routerId = Convert.ToInt32(rowRouter["AutoId"]);

            //删除工序对应的原材料
            foreach(DataRowView drv in model.WorkOrderDetail.DefaultView)
            {
                if (drv["routerId"] != null && Convert.ToInt32(drv["routerId"]) == routerId)
                {
                    model.WorkOrderDetail.Rows.Remove(drv.Row);
                }
            }

            //foreach(ListViewItem li in listView2.Items)
            //{
            //    var r = li.Tag as DataRow;
            //    if(r["routerId"] != null && Convert.ToInt32(r["routerId"]) == routerId)
            //    {
            //        listView2.Items.Remove(li);
            //    }
            //}

            listView1.Items.Remove(item);

            SetOpSeq();
        }


        private void LoadOperation()
        {
            foreach(DataRow r in model.WorkOrderRouter.Rows)
            {
                ListViewItem item = new ListViewItem(r["OpSeq"].ToString());
                item.Tag = r;
                item.SubItems.Add(r["OpName"].ToString());
                listView1.Items.Add(item);
            }
        }

        private void LoadChildren()
        {
            var col = new DataColumn("woQty", typeof(double));
            model.WorkOrderDetail.Columns.Add(col);
            
            foreach(DataRow row in model.WorkOrderDetail.Rows)
            {
                row["woQty"] = row["iQty"];
                row["iQty"] = DBNull.Value;
            }

            GridChild.DataSource = model.WorkOrderDetail;
        }

        private void CalcChildQty(double pQty)
        {           
            foreach(DataRowView drv in model.WorkOrderDetail.DefaultView)
            {
                var woQty = Convert.ToDouble(drv["woQty"]);
                var curQty = Math.Round(pQty / model.iQuantity * woQty, 2);

                drv.BeginEdit();
                drv["iQty"] = curQty;
                drv.EndEdit();
            }

        }

        private void SetOpSeq()
        {
            int i = 10010;
            foreach(ListViewItem item in listView1.Items)
            {
                var opseq = i.ToString().Substring(1);
                item.Text = opseq;
                i = i + 10;
            }
        }

        private void txt_curQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txt_curQuantity.Text.Trim() != "")
            {
                double curQty = Convert.ToDouble(this.txt_curQuantity.Text);
                this.CalcChildQty(curQty);
            }
        }
    }
}