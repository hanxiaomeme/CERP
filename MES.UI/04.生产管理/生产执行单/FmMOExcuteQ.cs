
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace LanyunMES.UI
{
    using LanyunMES.Entity;
    using U8Ext.Ref;

    public partial class FmMOExcuteQ : LanyunMES.UIBase.FmQBox
    {
        public FmMOExcuteQ()
        {
            InitializeComponent();
            txtr_OpName.ButtonCustomClick += RefOperation;
            txtr_machine.ButtonCustomClick += RefEquipment;
        }

        public int EQId { get; private set; } = 0;
        public int OperationId { get; private set; }

        private void RefOperation(object sender, EventArgs e)
        {
            IRefDAL2 dal = new OperationDAL(Information.UserInfo.ConnU8);
            RefForm2 frm = new RefForm2(dal);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                OperationId = Convert.ToInt32(frm.rows[0]["operationId"]);
                this.txtr_OpName.Text = frm.rows[0]["OpName"].ToString();
            }
        }

        private void RefEquipment(object sender, EventArgs e)
        {
            FmREquipment frm = new FmREquipment();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                EQId = Convert.ToInt32(frm.Results[0].EQId);
                this.txtr_machine.Text = frm.Results[0].cEQName;
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if(OperationId == 0)
            {
                throw new Exception("工序不能为空!");
            }
            if (Information.UserInfo.cUser_Id != "caowei")
            {
                if (EQId == 0)
                {
                    throw new Exception("设备不能为空!");
                }
            }

            this.DialogResult = DialogResult.OK;
        }
    
    }
}
