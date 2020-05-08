using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace LanyunMES.UI
{
    using Server.Model;
    using Model;
    using DAL;
    using Common;
    using DTO;

    public partial class FmCreateDCard : DevComponents.DotNetBar.OfficeForm
    {
        public FmCreateDCard(string pCardNo)
        {
            InitializeComponent();
            this.Load += FmLoad;
            txt_curQuantity.KeyPress += UICtrl.TextBox_NumOnly;

            this.model = dal.GetCardMain(pCardNo);
            this.woModel = new WorkOrderDAL().Get(model.WOGuid);
        }

        private CardMain model;
        private WorkOrderDTO woModel;
        private MCardDAL dal = new MCardDAL();
        private string cardNo;

        private void FmLoad(object sender, EventArgs e)
        {
            if (model != null)
            {
                UIBinding<CardMain>.UIDataBinding(groupBox1, model);

                this.GridDetail.AutoGenerateColumns = false;
                this.LoadChildren();
                this.LoadOperation();
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {

            List<DataRow> list = new List<DataRow>();
            List<DataRow> children = new List<DataRow>();

            foreach(ListViewItem item in listView1.Items)
            {
                list.Add(item.Tag as DataRow);
            }

            foreach (DataRow r in woModel.WorkOrderDetail.Rows)
            {
                if( r["iQty"].ToString() == "" || Convert.ToDecimal(r["iQty"]) <= 0)
                {
                    throw new Exception("材料数量不能小于等于0!");
                }
                children.Add(r);
            }


            CardMain cardM = new CardMain();
            cardM.bChild = true;
            cardM.cInvCode = model.cInvCode;
            cardM.WOGuid = model.WOGuid;
            cardM.pCardNo = model.CardNo;
            cardM.cMemo = txt_cMemo.Text.Trim();
            cardM.iQuantity = Convert.ToDecimal(txt_curQuantity.Text);
            cardM.cMaker = Information.UserInfo.cUser_Name;

           
            
            this.cardNo = new MCardDAL().CreateCard(cardM, list.ToArray(), children.ToArray());


            this.txtr_cardNo.Text = cardNo;

            this.txt_curQuantity.Enabled = false;
            this.txtr_cardNo.Enabled = false;
            this.txt_cMemo.Enabled = false;
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

            string path = Application.StartupPath.Trim('\\');

            this.report1.Load(path + "\\ReportPrint\\产品跟踪卡.frx");
            this.report1.RegisterData(dtMain, "M");
            this.report1.RegisterData(dtDetail, "D");
            this.report1.GetDataSource("M").Enabled = true;
            this.report1.GetDataSource("D").Enabled = true;
            this.report1.Show();
            #endregion
        }

        private void AddOperation(object sender, EventArgs e)
        {
            FmRWOOperation frm = new FmRWOOperation(model.WOGuid);
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

            listView1.Items.Remove(item);

            int routerId = Convert.ToInt32(rowRouter["AutoId"]);

            //删除工序对应的原材料

            var rows = woModel.WorkOrderDetail.Select("routerid = " + routerId);

            foreach (DataRow r in rows)
            {
                woModel.WorkOrderDetail.Rows.Remove(r);
            }

            SetOpSeq();
        }


        private void LoadOperation()
        {
            foreach(DataRow r in woModel.WorkOrderRouter.Rows)
            {
                ListViewItem item = new ListViewItem(r["OpSeq"].ToString());
                item.Tag = r;
                item.SubItems.Add(r["OpName"].ToString());
                listView1.Items.Add(item);
            }
        }

        private void LoadChildren()
        {
            GridDetail.DataSource = woModel.WorkOrderDetail;
            foreach(DataRow r in woModel.WorkOrderDetail.Rows)
            {
                r["iQty"] = 0;
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
                decimal curQty = Convert.ToDecimal(this.txt_curQuantity.Text);
                //this.CalcChildQty(curQty);
            }
        }

        private void BtnDelChild_Click(object sender, EventArgs e)
        {
            GridDetail.Rows.RemoveAt(GridDetail.CurrentRow.Index);
        }

        private void FmCreateDCard_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(!string.IsNullOrEmpty(cardNo))
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}