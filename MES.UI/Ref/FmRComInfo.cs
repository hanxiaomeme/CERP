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

    public partial class FmRComInfo : DevComponents.DotNetBar.OfficeForm
    {
        public FmRComInfo(string title, InitForm initForm)
        {
            InitializeComponent();
            this.panelEx1.Text = this.Text = title;
            this.initForm = initForm;
            this.Load += LoadData;
        }


        private DataTable dtMain;
        public DataRow RowResult { get; private set; }

        InitForm initForm;

        public delegate void InitForm(DataTable dt, ListView lv);


        private void LoadData(object sender, EventArgs e)
        {
            // 设置行高
            ImageList imgList = new ImageList();
            // 分别是宽和高
            imgList.ImageSize = new Size(1, 25);
            // 这里设置listView的SmallImageList ,用imgList将其撑大
            listView1.SmallImageList = imgList;

            initForm(dtMain, listView1);
        }


        private void BtnReturn_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count < 1)
            {
                throw new Exception("没有选中记录!");
            }

            this.RowResult = listView1.SelectedItems[0].Tag as DataRow;

            this.DialogResult = DialogResult.OK;
        }
    }
}