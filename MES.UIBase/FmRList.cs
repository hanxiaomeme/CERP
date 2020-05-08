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
    using DAL;

    public partial class FmRList : DevComponents.DotNetBar.OfficeForm
    {
        public FmRList()
        {
            InitializeComponent();
            //窗体标题
            this.Text = pnl_title.Text;
            //窗体加载
            this.Load += Fm_Load;
            //查询
            this.btn_Query.Click += Query;
            //导出Excel
            this.btn_Export.Click += ExportExcel;
        }

        protected DataTable mData = null;   
        protected string[] sumFields = null;    //合计列集合
        protected bool footerVisible = true;    //合计行是否可见


        protected void Fm_Load(object sender, EventArgs e)
        {
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

            DGX.AutoGenerateColumns = false;
            InitDGX();
        }

        protected virtual void InitDGX()
        {
            
        }

        protected virtual void Query(object sender, EventArgs e)
        {

        }

        private void ExportExcel(object sender, EventArgs e)
        {
            #region 导出按钮
            if (Export.ExpToExcel(DGX))
            {
                MessageBox.Show("导出成功！");
            }
            #endregion
        }



        //---------------------合计行-------------------------------------

        private void scroll_Changed(object sender, ScrollEventArgs e)
        {
            #region 合计行刷新
            this.lblSumFoot.Refresh();   
            #endregion
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

        private void QueryPnlShow(object sender, EventArgs e)
        {
            #region 显示隐藏查询界面
            int x = group2.Location.X;
            //this.group1.Visible = btn_showGP1.Value;
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

    }
}
