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
    using Component;
    using DAL;

    public partial class FmRWOOperation : DevComponents.DotNetBar.OfficeForm
    {
        public FmRWOOperation(string woGuid)
        {
            InitializeComponent();
            this.Text = this.panelEx1.Text;
            this.Load += LoadData;

            this.dtMain = new WorkOrderDAL().GetRouter(woGuid);
        }


        private DataTable dtMain;
        public DataRow[] RowResult { get; private set; }


        private void LoadData(object sender, EventArgs e)
        {
            // 设置行高
            ImageList imgList = new ImageList();
            // 分别是宽和高
            imgList.ImageSize = new Size(1, 25);
            // 这里设置listView的SmallImageList ,用imgList将其撑大
            listView1.SmallImageList = imgList;

            foreach(DataRow row in dtMain.Rows)
            {
                ListViewItem item = new ListViewItem(row["OpSeq"].ToString());
                item.SubItems.Add(row["OpName"].ToString());
                item.Tag = row;
                listView1.Items.Add(item);
            }
        }


        private void BtnReturn_Click(object sender, EventArgs e)
        {
            if(listView1.CheckedItems.Count < 1)
            {
                throw new Exception("没有选中记录!");
            }

            List<DataRow> list = new List<DataRow>();

            foreach(ListViewItem item in listView1.CheckedItems)
            {
                list.Add(item.Tag as DataRow);
            }

            RowResult = list.ToArray();

            this.DialogResult = DialogResult.OK;
        }

    }
}