using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LanyunMES.UIBase
{
    using Business;
    using UIBusiness;

    public partial class RefForm : DevComponents.DotNetBar.Office2007Form
    {
        public RefForm(IUIItemService business, string headText)
        {
            InitializeComponent();

            this.Text = headText;

            this.busi = business;
        }

        private DataTable DtM;

        private IUIItemService busi;

        private bool bMutiSelected = false;

        public List<DataRow> SelectedRows { get; private set; }


        private void RefForm_Load(object sender, EventArgs e)
        {
            busi.InitGrid(this.dataGridView1);

            this.BtnQuery_Click(sender, e);
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            #region 返回所选记录
            if (!bMutiSelected)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    int index = dataGridView1.CurrentRow.Index;
                    DataRow row = (dataGridView1.DataSource as DataTable).Rows[index];
                    SelectedRows = new List<DataRow>();
                    SelectedRows.Add(row);
                }
            }
            this.DialogResult = DialogResult.OK;
            #endregion
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            #region 查询

            string value = this.txt_Qbox.Text.Trim();

            DtM = busi.business.GetTable(value);
            this.dataGridView1.DataSource = DtM;
            this.lbl_Count.Text = "记录：" + DtM.Rows.Count;

            #endregion
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            this.BtnOK_Click(null, null);
        }

        //=====================================================================

    }
}
