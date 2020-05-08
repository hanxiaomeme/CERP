using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FastReport;

namespace LanyunMES.UIBase
{
    using Common;
    using Component;
    using DAL;
    using Entity;

    abstract public partial class FmQList : Form
    {
        public FmQList()
        {
            InitializeComponent();
            DGX.AutoGenerateColumns = false;
        }

        #region 定义的变量

        protected string moduleName = null;                 
        protected DataView dv = null;   
        protected string dBegin, dEnd;
        protected string[] sumFields = null;    //合计列集合
        protected bool footerVisible = true;    //合计行是否可见

        #endregion

        protected void Fm_Load(object sender, EventArgs e)
        {
            this.dBegin = DateTime.Today.AddMonths(-12).ToString();
            this.dEnd = DateTime.Today.ToString();

            //滚动时重新绘制合计字段
            if (footerVisible == true)
            {
                pnlFooter.Visible = true;
                DGX.Scroll += new ScrollEventHandler(scroll_Changed);
            }
            else
            {
                pnlFooter.Visible = false;
            }

            if (!string.IsNullOrEmpty(moduleName))
            {
                BusinessInfoDAL dal = new BusinessInfoDAL();
                BusinessInfo busiInfo = dal.GetModel(moduleName);
            }

            InitDGX();
        }

        protected abstract void InitDGX();

        protected virtual void ShowDetail(object sender, MouseEventArgs e) { }

        protected virtual void LoadPintReport()
        {
            #region 载入打印模板
            if (File.Exists("./ReportPrint/" + this.Text + ".frx"))
            {
                this.PrintReport.RegisterData(this.dv, "MTable");
                this.PrintReport.Load("./ReportPrint/" + this.Text + ".frx");
            }
            else
            {
                MsgBox.ShowInfoMsg("找不到对应模板!");
            }
            #endregion
        }



        //---------------------合计行-------------------------------------

        private void scroll_Changed(object sender, ScrollEventArgs e)
        {
            this.lblSumFoot.Refresh();   //重绘合计行
        }

        private void lblSumFoot_Paint(object sender, PaintEventArgs e)
        {
            #region 合计列计算
            if (this.sumFields == null || this.sumFields.Length == 0) return;

            Graphics grf = e.Graphics;
            int x = 0;
            if (DGX.RowHeadersVisible == true)
            {
                x += this.DGX.RowHeadersWidth;
            }

            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = StringAlignment.Far;

            foreach (DataGridViewColumn col in DGX.Columns)
            {
                x += col.Width;
                foreach (string field in sumFields)
                {
                    var fieldName = field.Split('|')[0];
                    var fieldFormat = field.Contains("|") ? field.Split('|')[1] : "n2";

                    if (col.DataPropertyName == fieldName)
                    {
                        decimal decSumValue = 0;
                        string strSumValue = "";

                        foreach (DataGridViewRow row in DGX.Rows)
                        {
                            if (row.Cells[fieldName].Value != DBNull.Value)
                            {
                                decSumValue += Convert.ToDecimal(row.Cells[fieldName].Value);
                            }
                        }

                        strSumValue = string.IsNullOrEmpty(fieldFormat) ? decSumValue.ToString() : decSumValue.ToString(fieldFormat);

                        int xPoint = x - (DGX.HorizontalScrollingOffset + lblSum.Width);

                        grf.DrawString(strSumValue, this.lblSumFoot.Font, Brushes.Blue, xPoint, 5, strFormat);
                    }
                }
            }

            #endregion
        }

        //------------------------------------------------------------

        #region 按钮事件

        private void btn_Export_Click(object sender, EventArgs e)
        {
            #region 导出按钮

            if (Export.ExpToExcel(DGX))
            {
                MessageBox.Show("导出成功！");
            }


            #endregion
        }


        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DGX_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowDetail(sender, e);
        }

        private void btn_showGP1_ValueChanged(object sender, EventArgs e)
        {
            #region 显示隐藏查询界面
            int x = group2.Location.X;
            this.group1.Visible = btn_showGP1.Value;
            if (group1.Visible)
            {
                group2.Width -= (group1.Width + 5);
                group2.Location = new Point(270, group2.Location.Y);
            }
            else
            {
                group2.Location = group1.Location;
                group2.Width += (group1.Width + 5);
            } 
            #endregion
        }

        #endregion
    }
}
