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

    public partial class FmCalendar : DevComponents.DotNetBar.OfficeForm
    {
        public FmCalendar()
        {
            InitializeComponent();
            this.numYear.Value = DateTime.Now.Year;
            this.cb_month.Text = DateTime.Now.Month.ToString();
            this.numYear.ValueChanged += LoadData;
            this.cb_month.TextChanged += LoadData;
            this.Load += LoadData;

            this.dataGridViewX1.AutoGenerateColumns = false;
            this.dataGridViewX1.AllowUserToAddRows = false;
        }

        WorkCalendarDAL dal = new WorkCalendarDAL();

        DataTable dtMain;

        private decimal workhours = 0;

        private void BtnLoadDate_Click(object sender, EventArgs e)
        {
            if(dtMain.Rows.Count > 0)
            {
                if(MsgBox.ShowYesNoMsg("表体已存在数据,重新加载将清除当前数据,是否继续?") != DialogResult.Yes)
                {
                    return;
                }
            }

            FmCalendarSet frm = new FmCalendarSet();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.workhours = frm.WorkHours;
                dtMain.Rows.Clear();

                int year = (int)numYear.Value;
                int month = Convert.ToInt32(cb_month.Text);

                DateTime d1 = new DateTime(year, month, 1);
                DateTime d2 = d1.AddMonths(1).AddDays(-1);

                while (d1 <= d2)
                {
                    string week = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(d1.DayOfWeek);

                    var r = dtMain.NewRow();
                    r["dDate"] = d1;
                    r["iHours"] = frm.WeekDays.Contains(week) ? 0 : workhours;
                    r["WeekDay"] = week;
                    r["bRest"] = frm.WeekDays.Contains(week) ? true : false;
                    dtMain.Rows.Add(r);
                    d1 = d1.AddDays(1);
                }

                this.dataGridViewX1.Focus();
            }
        }

        private void LoadData(object sender, EventArgs e)
        {
            int year = (int)numYear.Value;
            int month = Convert.ToInt32(cb_month.Text);   
            dtMain = dal.GetList(year, month);
            if (dtMain.Rows.Count > 0)
            {
                this.workhours = (decimal)dtMain.Rows[0]["iHours"];
            }
            this.dataGridViewX1.DataSource = dtMain;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            dataGridViewX1.EndEdit();
            if(dtMain.Rows.Count < 1)
            {
                throw new Exception("表体没有数据!");
            }
            dal.Add(dtMain);
            MsgBox.ShowInfoMsg("保存成功!");
        }

        private void dataGridViewX1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridViewX1.Columns[e.ColumnIndex].Name == "bRest")
            {
                dataGridViewX1.EndEdit();
                if ((bool)dataGridViewX1.Rows[e.RowIndex].Cells["bRest"].Value)
                {
                    dataGridViewX1.Rows[e.RowIndex].Cells["iHours"].Value = 0;
                }
                else
                {
                    dataGridViewX1.Rows[e.RowIndex].Cells["iHours"].Value = workhours;
                }
            }
        }
    }
}