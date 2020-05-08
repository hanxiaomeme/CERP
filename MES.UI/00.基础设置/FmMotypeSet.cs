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
    using DAL;
    using Model;
    using Component;
    using U8Ext.Ref;

    public partial class FmMotypeSet : DevComponents.DotNetBar.OfficeForm
    {
        public FmMotypeSet()
        {
            InitializeComponent();
            this.Load += GetData;
        }

        MoTypeControlDAL dal = new MoTypeControlDAL();

        private int motypeid = 0;

        public void GetData(object obj, EventArgs e)
        {
            listView1.Items.Clear();
            ListViewItem item;
            foreach(var a in dal.GetList())
            {
                item = new ListViewItem(a.MotypeCode);
                item.SubItems.Add(a.MotypeName);
                item.SubItems.Add(a.bOrderOff ? "关闭" : "打开");
                item.Tag = a;

                listView1.Items.Add(item);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if(this.motypeid != 0)
            {
                var it = new MoTypeControl();
                it.MoTypeId = motypeid;
                it.bOrderOff = true;
                dal.Add(it);
                this.motypeid = 0;
                this.textBoxX1.Text = "";
                this.GetData(null, null);
            }           
            else
            {
                throw new Exception("请选择U8生产类别!");
            }

        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            var item = listView1.SelectedItems[0].Tag as MoTypeControl;

            dal.Delete(item.MoTypeId);

            this.GetData(null, null);
        }

        private void textBoxX1_ButtonCustomClick(object sender, EventArgs e)
        {
            IRefDAL2 dal = new MOTypeDAL(Information.UserInfo.ConnU8);
            RefForm2 frm = new RefForm2(dal);
            if(frm.ShowDialog() == DialogResult.OK)
            {
                this.motypeid = Convert.ToInt32(frm.rows[0]["motypeid"]);
                (sender as TextBox).Text = frm.rows[0]["description"].ToString();
            }
        }
    }
}
