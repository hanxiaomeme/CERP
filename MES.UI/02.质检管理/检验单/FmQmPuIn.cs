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
    using U8Ext.Ref;
    using Model;
    using Component;

    public partial class FmQmPuIn : DevComponents.DotNetBar.OfficeForm
    {
        public FmQmPuIn()
        {
            InitializeComponent();
            this.txtr_warehouse.ButtonCustomClick += RefWarehouse;
            this.txtr_Position.ButtonCustomClick += RefPosition;
            this.txtr_warehouse.KeyPress += KeyPressClearTextBox;
            this.txtr_Position.KeyPress += KeyPressClearTextBox;
        }

        private void KeyPressClearTextBox(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                (sender as TextBox).Clear();
                (sender as TextBox).Tag = null;
            }
            else
            {
                e.Handled = true;
            }
        }

        public string cWhCode { get; private set; }
        public string cPosition { get; private set; }

        private void RefWarehouse(object obj, EventArgs e)
        {
            IRefDAL2 dal = new WarehouseDAL(Information.UserInfo.ConnU8);
            RefForm2 frm = new RefForm2(dal);
            if(frm.ShowDialog() == DialogResult.OK)
            {
                (obj as TextBox).Text = frm.rows[0]["cWhName"].ToString();
                (obj as TextBox).Tag = frm.rows[0]["cWhCode"].ToString();
            }
        }

        private void RefPosition(object obj, EventArgs e)
        {
            if(txtr_warehouse.Tag == null)
            {
                MsgBox.ShowInfoMsg("请先选择仓库!");
                return;
            }

            IRefDAL2 dal = new PositionDAL(Information.UserInfo.ConnU8, txtr_warehouse.Tag.ToString());
            RefForm2 frm = new RefForm2(dal);
            if(frm.ShowDialog() == DialogResult.OK)
            {
                (obj as TextBox).Text = frm.rows[0]["cPosName"].ToString();
                (obj as TextBox).Tag = frm.rows[0]["cPosCode"].ToString();
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if(txtr_warehouse.Tag == null)
            {
                MsgBox.ShowInfoMsg("仓库不能为空!");
            }
            else if(txtr_Position.Tag == null)
            {
                MsgBox.ShowInfoMsg("货位不能为空!");
            }
            else 
            {
                this.cWhCode = txtr_warehouse.Tag.ToString();
                this.cPosition = txtr_Position.Tag.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}