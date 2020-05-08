using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LanyunMES.UI
{
    using Model;
    using DAL;
    using Component;

    public partial class FmAddOperation : Form
    {
        public FmAddOperation(string cardNo)
        {
            InitializeComponent();
            this._cardNo = cardNo;
        }

        private string _cardNo;

        //CardDAL dal = new CardDAL();
        private void FmAddOperation_Load(object sender, EventArgs e)
        {
            #region 加载工序
            //DataTable dt = dal.GetBody(_cardNo);
            //foreach (DataRow row in dt.Rows)
            //{
            //    ListViewItem item;
            //    if (Convert.ToBoolean(row["ReWork"]))
            //        item = new ListViewItem("是");
            //    else
            //        item = new ListViewItem("");
            //    item.SubItems.Add(row["OpSeq"].ToString());
            //    item.SubItems.Add(row["OPName"].ToString());
            //    item.SubItems.Add(row["iQuantity"].ToString());
            //    item.SubItems.Add(row["iWeight"].ToString());
            //    item.SubItems.Add(row["bizhong"].ToString());
            //    item.SubItems.Add(row["OperationId"].ToString());
            //    item.Tag = row;
            //    this.listView1.Items.Add(item);
            //} 
            #endregion
        }

        private void BtnCopyOP_Click(object sender, EventArgs e)
        {
            #region 复制 返工工序
            ListViewItem curItem = listView1.FocusedItem;

            ListViewItem item = new ListViewItem("是");
            item.SubItems.Add(GetOPSeq());
            item.SubItems.Add(curItem.SubItems[2].Text);
            item.SubItems.Add(curItem.SubItems[3].Text);
            item.SubItems.Add(curItem.SubItems[4].Text);
            item.SubItems.Add(curItem.SubItems[5].Text);
            item.SubItems.Add(curItem.SubItems[6].Text);
            this.listView1.Items.Add(item); 
            #endregion
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            #region  保存新增工序
            //List<CardDetail> list = new List<CardDetail>();

            //foreach (ListViewItem item in listView1.Items)
            //{
            //    if (item.Text == "是")
            //    {
            //        CardDetail model = new CardDetail();
            //        model.reWork = true;
            //        model.cardNo = _cardNo;
            //        if (string.IsNullOrEmpty(item.SubItems[1].Text))
            //        {
            //            MsgBox.ShowInfoMsg("工序行号不能为空!"); return;
            //        }
            //        else
            //            model.OpSeq = item.SubItems[1].Text;

            //        if (string.IsNullOrEmpty(item.SubItems[5].Text))
            //        {
            //            MsgBox.ShowInfoMsg("比重不能为空!"); return;
            //        }
            //        else
            //            model.bizhong = Convert.ToDecimal(item.SubItems[5].Text);

            //        if (string.IsNullOrEmpty(item.SubItems[6].Text))
            //        {
            //            MsgBox.ShowInfoMsg("没有对应的工序ID"); return;
            //        }
            //        else
            //            model.operationId = Convert.ToInt32(item.SubItems[6].Text);

            //        list.Add(model);
            //    }
            //}

            //if (list.Count < 1)
            //{
            //    MsgBox.ShowInfoMsg("没新增的工序记录!");
            //    return;
            //}

            //try
            //{
            //    //dal.AppendDetail(list);
            //    this.DialogResult = DialogResult.OK;
            //}
            //catch (Exception ex)
            //{
            //    MsgBox.ShowInfoMsg(ex.Message);
            //} 
            #endregion
        }

        private string GetOPSeq()
        {
            #region 获取最新OpSeq
            int cNo = 10000 + (listView1.Items.Count + 1) * 10;
            return cNo.ToString().Substring(1);  
            #endregion
        }

        private void Btn_Up_Click(object sender, EventArgs e)
        {
            this.MoveItem(this.listView1, -1);
        }

        private void Btn_Down_Click(object sender, EventArgs e)
        {
            this.MoveItem(this.listView1, 1);
        }


        private void MoveItem(ListView view, int step)
        {
            ListViewItem item = view.FocusedItem;

            int index = item.Index + step;

            if (index < 0) return;
            if (index > view.Items.Count - 1) return;

            item.Remove();

            view.Items.Insert(index, item);

            item.Focused = true;

            foreach(ListViewItem i in view.Items)
            {

            }
        }
    }
}
