using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LanyunMES.UI
{
    using Common;
    using DAL;

    public partial class FmSaleDemand : Form
    {
        public FmSaleDemand()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
        }

        private void BtnLoadXls_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Filter = "Excel文档|*.xls;*.xlsx";
            if(fdlg.ShowDialog() == DialogResult.OK)
            {
                string file = fdlg.FileName;
                DataTable dt = NPOIHelper.ExcelToTable(file);
                foreach(DataColumn col in dt.Columns)
                {
                    switch(col.Caption)
                    {
                        case "日期":
                            col.ColumnName = "dDate";   
                            break;
                        case "客户编码":
                            col.ColumnName = "cCusCode";
                            break;
                        case "客户零件号":
                            col.ColumnName = "cCusInvCode";
                            break;
                        case "存货编码":
                            col.ColumnName = "cInvCode";
                            break;
                        case "千件":
                            col.ColumnName = "iQuantity";
                            break;
                    }
                }

                this.dataGridView1.DataSource = dt;
            }
        }
    }
}
