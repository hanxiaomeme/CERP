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
    using Server.Model;
    using U8Ext.Ref;
    using DAL;

    public partial class FmOpQMReport : DevComponents.DotNetBar.OfficeForm
    {
        public FmOpQMReport(string cardNo)
        {
            InitializeComponent();
            txt_qty.KeyPress += UICtrl.TextBox_NumOnly;
            this.cardNo = cardNo;
        }

        MCardDAL dal = new MCardDAL();

        private string cardNo;
        private CardMain cardM;

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

            this.cardM = dal.GetCardMain(cardNo);
            this.LoadData();
        }

        private void LoadData()
        {
            UIBinding<CardMain>.UIDataBinding(pnlM, cardM);
            UIBinding<CardDetail>.UIDataBinding(pnlD, cardM.curOperation);
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            var cardD = cardM.curOperation;

            if(string.IsNullOrEmpty(txt_qty.Text) || Convert.ToDecimal(txt_qty.Text) <=0)
            {
                throw new Exception("报检数量不能小于等0");
            }

            QMCardOP model = new QMCardOP()
            {
                CardNo = cardD.CardNo,
                OpSeq = cardD.OpSeq,
                iQuantity = Convert.ToDecimal(txt_qty.Text)
            };

            new QmCardOPDAL().Add(model);

            this.DialogResult = DialogResult.OK;
        }


    }
}