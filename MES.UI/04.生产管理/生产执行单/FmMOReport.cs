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
    using Common;
    using Component;
    using Report;
    using Model;
    using DTO;
    using Server.Model;
    using U8Ext.Ref;
    using DAL;

    public partial class FmMOReport : DevComponents.DotNetBar.OfficeForm
    {
        public FmMOReport(string cardNo)
        {
            InitializeComponent();
            txt_qty.KeyPress += UICtrl.TextBox_NumOnly;
            txt_hgQty.KeyPress += UICtrl.TextBox_NumOnly;

            txt_qty.TextChanged += CalcQty;
            txt_hgQty.TextChanged += CalcQty;
            this.cardNo = cardNo;
        }

        ReportClient rep = new ReportClient();

        MCardDAL dal = new MCardDAL();

        private string cardNo;
   
        public Card card { get; private set; }

        private void FmMOReport_Load(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(cardNo))
            {
                throw new Exception("流转卡号不能为空!");
            }
            else if (!dal.Exists(cardNo))
            {
                throw new Exception("流转卡号[" + cardNo + "] 不存在!");
            }

            this.card = rep.GetCard(cardNo);

            if(card.M.bClosed)
            {
                throw new Exception("当前流转卡已经关闭!");
            }
            else if(card.M.bPause)
            {
                throw new Exception("当前流转卡已经暂停,不能继续!");
            }

            this.LoadData();     
        }

        private void LoadData()
        {
            UIBinding<CardMain>.UIDataBinding(pnlM, card.M);
            UIBinding<CardDetail>.UIDataBinding(pnlD, card.M.curOperation);

            this.lbl_opMemo.Text = card.M.curOperation.cMemo;

            card.M.curOperation.cDepCode = card.M.MDeptCode;
            this.txtr_cDepName.Text = card.M.MDeptName;

            var preOp = dal.GetPrevious(card.M.CardNo, card.M.curOpSeq);

            if(preOp != null)
            {
                this.txt_qty.Text = preOp.hgQty.ToString();
                this.txt_hgQty.Text = preOp.hgQty.ToString();
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            this.CalcQty(null, null);

            var wo = new WorkOrderDAL().GetModel(card.M.WOGuid);

            //是否母件
            if(wo.Grade == 0)
            {
                //所有子件卡是否完工
                if(!dal.ChildCardAllComplete(wo.U8Modid))
                {
                    throw new Exception("存在未完工的零件流转卡, 不能报工!");
                }
            }


            var cardD = card.M.curOperation;

            if(cardD.hgQty <= 0)
            {
                throw new Exception("合格数量不能小于等0");
            }
            else if(string.IsNullOrEmpty(cardD.cWorker))
            {
                throw new Exception("操作工不能为空!");
            }

            //检验报工数量, 不能大于上道
            if (cardD.OpSeq != "0010")
            {
                var preOperation = card.DList.FindLast(x => Convert.ToInt32(x.OpSeq) < Convert.ToInt32(cardD.OpSeq));

                var preQty =  preOperation.hgQty + preOperation.bhgQty;
                if (cardD.hgQty + cardD.bhgQty > preQty)
                {
                    throw new Exception("当前工序报工数量不能大于上道报工数量(" + preQty + ")");
                }
            }

            if (!string.IsNullOrEmpty(txt_worker.Text.Trim()))
            {
                this.GetPerson(txt_worker.Text.Trim());
            }

            cardD.cRepPsn = Information.UserInfo.cUser_Name;

            //报工
            var u8rdid = new ReportClient().ReportOP(cardD);

            if (!string.IsNullOrEmpty(u8rdid))
            {
                MsgBox.ShowInfoMsg("已生成产品入库单, ID: " + u8rdid);
            }

            //var wo = new WorkOrderDAL().Get(cardM.WOGuid);

            //if (wo.Grade == 0)
            //{
            //    if (!cardM.bChild && !dal.HaveNextOpSeq(cardD.CardNo, cardD.OpSeq))
            //    {
            //        string id = new U8API.U8OperationClient().ProductIn(cardM.CardNo, cardD.OpSeq);
            //        MsgBox.ShowInfoMsg("已生成产品入库单, ID: " + id);
            //    }
            //}


            this.DialogResult = DialogResult.OK;
        }

        private void txt_worker_ButtonCustomClick(object sender, EventArgs e)
        {
            IRefDAL dal = new HrPersonDAL(Information.UserInfo.ConnU8);
            RefForm frm = new RefForm(dal);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.txt_worker.Text = frm.rows[0]["cPsn_Name"].ToString();
                this.txtr_cDepName.Text = frm.rows[0]["cDepName"].ToString();
                card.M.curOperation.cDepCode = frm.rows[0]["cDepCode"].ToString();
            }
        }

        /// <summary>
        /// 计算不合格数量
        /// </summary>
        private void CalcQty(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_qty.Text)) return;

            if (string.IsNullOrEmpty(txt_hgQty.Text)) return;

            var qty = Convert.ToDecimal(txt_qty.Text);
            var hgqty = Convert.ToDecimal(txt_hgQty.Text);

            if (qty < hgqty)
                throw new Exception("合格数量不能大于报工数量!");

            card.M.curOperation.bhgQty = qty - hgqty;
        }

        private void txt_worker_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_worker.Text.Trim()))
            {
                this.GetPerson(txt_worker.Text.Trim());
            }
        }

        private void txt_worker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txt_worker.Text.Trim()))
                {
                    this.GetPerson(txt_worker.Text.Trim());
                }                   
            }           
        }


        private void GetPerson(string cPerson)
        {
            var dal = new HrPersonDAL(Information.UserInfo.ConnU8);

            var row = dal.Get(txt_worker.Text.Trim());

            if (row == null) throw new Exception("操作员编码: " + txt_worker.Text + " 不存在!");

            this.card.M.curOperation.cDepCode = row["cDepCode"].ToString();
            this.txt_worker.Text = row["cPsn_Name"].ToString();
            this.txtr_cDepName.Text = row["cDepName"].ToString();
        }

 
    }
}