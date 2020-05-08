using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using Component;
using DevExpress.XtraGrid.Columns;

namespace LanyunMES.UI
{
    using DAL;
    using Model;
    using System.Data.SqlClient;
    using DevExpressUtility;

    public partial class FmAPS : DevComponents.DotNetBar.OfficeForm
    {
        public FmAPS()
        {
            InitializeComponent();
            this.Load += FormLoad;
            gridView1.KeyDown += GridViewHelper.KeyDownCellCopy;

            this.tab_Main.Text = this.Text = this.lblModuleTitle.Text;
        }

        private DataView dvMom;
        private APSDAL dal = new APSDAL();


        private void FormLoad(object sender, EventArgs e)
        {
            #region 加载主窗体事件

            this.cb_Style.SelectedIndex = 1;
            this.dateBegin.Value = DateTime.Now.Date.AddDays(1);
            this.dateEnd.Value = dateBegin.Value.Date.AddMonths(1);

            this.InitGridView(this.gridView1);

            this.GetData();

            this.GetMould();

            #endregion
        }

        private void InitGridView(DevExpress.XtraGrid.Views.Grid.GridView grid)
        {
            #region 初始化列
            grid.OptionsView.AllowCellMerge = false;

            var col = GridViewHelper.AddColumn(grid, "WOCode", "指令单号", 100);
            col.Fixed = FixedStyle.Left;
            col.Summary.Add(DevExpress.Data.SummaryItemType.Count);
            col.Summary[0].FieldName = "WOCode";
            col.Summary[0].DisplayFormat = "记录数: {0}";
            col.OptionsColumn.ReadOnly = false;

            GridViewHelper.AddColumn(grid, "MoCode", "生产订单号", 90);
            GridViewHelper.AddColumn(grid, "SortSeq", "行号", 40).OptionsColumn.ReadOnly = false;  
            GridViewHelper.AddColumn(grid, "cInvCode", "存货编码", 120).OptionsColumn.ReadOnly = false;
            GridViewHelper.AddColumn(grid, "cInvName", "存货名称", 120).OptionsColumn.ReadOnly = false;
            GridViewHelper.AddColumn(grid, "cInvStd", "规格型号", 120).OptionsColumn.ReadOnly = false;

            col = GridViewHelper.AddColumn(grid, "iQuantity", "数量", 80);
            col.OptionsColumn.ReadOnly = false;
            col.AppearanceCell.ForeColor = Color.Blue;
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n2}";
            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            col.Summary[0].FieldName = "iQuantity";
            col.Summary[0].DisplayFormat = "{0:n2}";

            GridViewHelper.AddColumn(grid, "cComUnitName", "单位", 50).OptionsColumn.ReadOnly = false; ;
            GridViewHelper.AddColumn(grid, "WGQuantity", "完工数量", 80).OptionsColumn.ReadOnly = false; ;

            col = GridViewHelper.AddColumn(grid, "NWGQuantity", "未完工数量", 80);
            col.OptionsColumn.ReadOnly = false;
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n2}";

            col = GridViewHelper.AddColumn(grid, "NPCQty", "未排产数量", 80);
            col.OptionsColumn.ReadOnly = false;
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n2}";

            GridViewHelper.AddColumn(grid, "MID", "模具ID", 80);
            col = GridViewHelper.AddColumn(grid, "cMName", "模具", 80);
            col.ColumnEdit = RowButtonEdit1;
 
            GridViewHelper.AddColumn(grid, "StartDate", "开工日期", 80).OptionsColumn.ReadOnly = false; ;
            GridViewHelper.AddColumn(grid, "DueDate", "完工日期", 80).OptionsColumn.ReadOnly = false; ;

            grid.OptionsView.ColumnAutoWidth = true;

            #endregion
        }


        private void InitListView(ListView list)
        {
            list.Columns.Add("生产订单号", 90);
            list.Columns.Add("行号", 40);
            list.Columns.Add("存货编码", 120);
            list.Columns.Add("存货名称", 120);
            list.Columns.Add("规格型号", 120);
            list.Columns.Add("数量", 80);
            list.Columns.Add("单位", 50);
            list.Columns.Add("入库数量", 80);
            list.Columns.Add("未入库数量", 80);
            list.Columns.Add("模具", 80);

        }

        private void GetData()
        {
            dvMom = dal.GetMomTable(DateTime.Now.Date).DefaultView;
            gridControl1.DataSource = dvMom;
        }

        private void GetMould()
        {
            Mould m;

            foreach (DataRowView r in dvMom)
            {
                m = dal.GetMouldSignle(r["cInvCode"].ToString());
                if (m != null)
                {
                    r.BeginEdit();
                    r["MID"] = m.MId;
                    r["cMName"] = m.cMName;
                    r.EndEdit();
                }
            }
        }

        private void Save() { }



        private void btn_Save_Click(object sender, EventArgs e)
        {
            #region 保存
            this.Save(); 
            #endregion
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void BtnCalc_Click(object sender, EventArgs e)
        {
            DateTime dBegin = dateBegin.Value.Date;
            DateTime dEnd = dateEnd.Value.Date;

            if(dBegin <= DateTime.Now.Date)
            {
                throw new Exception("计划开始日期必须大于今天!");
            }
            else if(dBegin > dEnd)
            {
                throw new Exception("计划结束日期不能小于开始日期!");
            }

            int i = 0;
            foreach(DataRowView r in dvMom)
            {
                if(r["MID"].ToString() == "")
                {
                    gridView1.FocusedRowHandle = i;
                    throw new Exception("模具不能为空!");
                }
                i++;
            }


            this.CheckWorkCalendar(dBegin, dEnd);
            if (cb_Style.SelectedIndex == 0)
            {
                APS1(dBegin, dEnd);
            }
            else
            {
                APS2(dBegin, dEnd);
            }
        }


        private void APS1(DateTime dBegin, DateTime dEnd)
        {
            #region 最少机台

            //机台日产能表
            var dtEqDayCapacity = dal.GetEqDayCapacity(dBegin, dEnd);

            if(dtEqDayCapacity.Rows.Count < 1)
            {
                throw new Exception("所选排产期间,没有剩余可用设备!");
            }

            List<SqlCommand> cmdlist = new List<SqlCommand>();

            dvMom.Sort = "DueDate, cInvCode";

            foreach (DataRowView r in dvMom)
            {
                //对应机台表
                var dtEquiment = dal.GetMouldEq(r["cInvCode"].ToString(), r["MID"].ToString());

                var qty = Convert.ToDecimal(r["NPCQty"]);

                int EqIndex = 1;

                foreach (DataRow rowEq in dtEquiment.Rows)
                {
                    if (qty <= 0) break;

                    //当前日期可用机台
                    DataView dvEQday = dtEqDayCapacity.DefaultView;
                    dvEQday.RowFilter = "leftHours > 0 and EQId = " + rowEq["EQId"];

                    #region 排产到每日机台
                    foreach (DataRowView row in dvEQday)
                    {

                        if (qty <= 0) break;

                        string cMemo = "";
                        //当前机台日期超交期
                        if (Convert.ToDateTime(r["DueDate"]) < Convert.ToDateTime(row["dDate"]))
                        {
                            //有其他可用机台
                            //if (EqIndex < dtEquiment.Rows.Count)
                            //{
                            //    break;
                            //}

                            cMemo = "逾期";
                        }
                        else
                        {
                            cMemo = "";
                        }

                        var workHours = Convert.ToDecimal(row["LeftHours"]);
                        var capacity = Convert.ToDecimal(rowEq["capacity"]);
                        var dayCapacity = workHours * capacity;

                        if (qty >= dayCapacity)     //剩余数量 > 机台日产能
                        {
                            row["LeftHours"] = 0;

                            SqlParameter[] p = new SqlParameter[]
                            {
                                new SqlParameter("@EQId", rowEq["EQId"]),
                                new SqlParameter("@MID", rowEq["MId"]),
                                new SqlParameter("@cInvCode",r["cInvCode"]),
                                new SqlParameter("@dDate", row["dDate"]),
                                new SqlParameter("@WOCode", r["WOCode"]),
                                new SqlParameter("@sortSeq", DBNull.Value),
                                new SqlParameter("@pcQty", dayCapacity),
                                new SqlParameter("@PCHours", workHours),
                                new SqlParameter("@cMemo", DataHelper.SqlNull(cMemo))
                            };

                            var cmd = dal.GetAddRecordCmd(p);
                            cmdlist.Add(cmd);

                            qty = qty - dayCapacity;
                        }
                        else                    // 0 < 剩余数量 < 机台日产量
                        {
                            row.BeginEdit();
                            row["LeftHours"] = Math.Round(workHours - qty / capacity, 2);
                            row.EndEdit();

                            SqlParameter[] p = new SqlParameter[]
                            {
                                new SqlParameter("@EQId", rowEq["EQId"]),
                                new SqlParameter("@MID", rowEq["MId"]),
                                new SqlParameter("@cInvCode",r["cInvCode"]),
                                new SqlParameter("@dDate", row["dDate"]),
                                new SqlParameter("@WOCode", r["WOCode"]),
                                new SqlParameter("@sortSeq", DBNull.Value),
                                new SqlParameter("@pcQty", qty),
                                new SqlParameter("@PCHours", Math.Round(qty / capacity, 2)),
                                new SqlParameter("@cMemo", DataHelper.SqlNull(cMemo))
                            };

                            var cmd = dal.GetAddRecordCmd(p);
                            cmdlist.Add(cmd);

                            qty = 0;

                        }
                    }
                    #endregion

                    EqIndex++;
                }


                //if (qty > 0) MsgBox.ShowInfoMsg(qty.ToString() + " 未排产");
            }

            DbHelperSQL.ExecuteSqlTran(cmdlist.ToArray());

            MsgBox.ShowInfoMsg("OK");

            this.BtnRefresh_Click(null, null);

            #endregion
        }


        private void APS2(DateTime dBegin, DateTime dEnd)
        {
            #region 平均机台

            dvMom.Sort = "MID, DueDate, cInvCode";

            //所有机台剩余日产能表
            var dtEqDayCapacity = dal.GetEqDayCapacity(dBegin, dEnd);

            if (dtEqDayCapacity.Rows.Count < 1)
            {
                throw new Exception("所选排产期间,没有剩余可用设备!");
            }

            List<SqlCommand> cmdlist = new List<SqlCommand>();


            foreach (DataRowView r in dvMom)
            {
                //模具对应机台表
                var dtEquiment = dal.GetMouldEq(r["cInvCode"].ToString(), r["MID"].ToString());

                var qty = Convert.ToDecimal(r["NPCQty"]);

                foreach (DataRow rowEq in dtEquiment.Rows)
                {
                    if (qty <= 0) break;

                    for (DateTime curDate = dBegin; curDate <= dEnd; curDate = curDate.AddDays(1))
                    {
                        if (qty <= 0) break;

                        //当前日期可用机台
                        DataView dvEQday = dtEqDayCapacity.DefaultView;
                        dvEQday.RowFilter = "leftHours > 0 and EQId = " + rowEq["EQId"] + " and dDate = '" + curDate.ToShortDateString() + "'";

                        #region 排产到每日机台
                        foreach (DataRowView row in dvEQday)
                        {
                            if (qty <= 0) break;

                            string cMemo = "";
                            //当前机台日期超交期
                            if (Convert.ToDateTime(r["DueDate"]) < Convert.ToDateTime(row["dDate"]))
                            {
                                cMemo = "逾期";
                            }
                            else
                            {
                                cMemo = "";
                            }

                            var workHours = Convert.ToDecimal(row["leftHours"]);
                            var capacity = Convert.ToDecimal(rowEq["capacity"]);
                            var dayCapacity = workHours * capacity;

                            if (qty >= dayCapacity)     //剩余数量 > 机台日产能
                            {
                                row["LeftHours"] = 0;

                                SqlParameter[] p = new SqlParameter[]
                                {
                                    new SqlParameter("@EQId", rowEq["EQId"]),
                                    new SqlParameter("@MId", rowEq["MId"]),
                                    new SqlParameter("@cInvCode", r["cInvCode"]),
                                    new SqlParameter("@dDate", row["dDate"]),
                                    new SqlParameter("@WOCode", r["WOCode"]),
                                    new SqlParameter("@sortSeq", r["sortSeq"]),
                                    new SqlParameter("@pcQty", dayCapacity),
                                    new SqlParameter("@PCHours", workHours),
                                    new SqlParameter("@cMemo", DataHelper.SqlNull(cMemo))
                                };

                                var cmd = dal.GetAddRecordCmd(p);
                                cmdlist.Add(cmd);

                                qty = qty - dayCapacity;
                            }
                            else                    // 0 < 剩余数量 < 机台日产量
                            {
                                row["LeftHours"] = Math.Round(workHours - qty / capacity, 2);

                                SqlParameter[] p = new SqlParameter[]
                                {
                                    new SqlParameter("@EQId", rowEq["EQId"]),
                                    new SqlParameter("@MId", rowEq["MId"]),
                                    new SqlParameter("@cInvCode", r["cInvCode"]),
                                    new SqlParameter("@dDate", row["dDate"]),
                                    new SqlParameter("@WOCode", r["WOCode"]),
                                    new SqlParameter("@sortSeq", r["sortSeq"]),
                                    new SqlParameter("@pcQty", qty),
                                    new SqlParameter("@PCHours", Math.Round(qty / capacity, 2)),
                                    new SqlParameter("@cMemo", DataHelper.SqlNull(cMemo))
                                };

                                var cmd = dal.GetAddRecordCmd(p);
                                cmdlist.Add(cmd);

                                qty = 0;
                            }
                        }
                        #endregion
                     
                    }

                }

            }

            DbHelperSQL.ExecuteSqlTran(cmdlist.ToArray());

            MsgBox.ShowInfoMsg("OK");

            this.BtnRefresh_Click(null, null);
            #endregion

        }

        private void CheckWorkCalendar(DateTime dBegin, DateTime dEnd)
        {
            if(!dal.CheckWorkCalendar(dBegin.Year, dBegin.Month))
            {
                throw new Exception(dBegin.Month + "月, 尚未设置工作日历!");
            }
            else if(!dal.CheckWorkCalendar(dEnd.Year, dEnd.Month))
            {
                throw new Exception(dEnd.Month + "月, 尚未设置工作日历!");
            }
        }

        private void RowButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FmRComInfo frm = new FmRComInfo("模具档案", InitRefForm);
            if(frm.ShowDialog() == DialogResult.OK)
            {
                gridView1.SetFocusedRowCellValue("MID", frm.RowResult["MID"]);
                gridView1.SetFocusedRowCellValue("cMName", frm.RowResult["cMName"]);
            }
        }


        private void InitRefForm(DataTable dt, ListView lv)
        {
            string cInvCode = gridView1.GetFocusedRowCellValue("cInvCode").ToString();

            dt = dal.GetMould(cInvCode);

            lv.Columns.Clear();
            lv.Columns.Add("模具编码", 110);
            lv.Columns.Add("模具名称", 130);
            lv.Columns.Add("存货编码", 130);

            foreach(DataRow r in dt.Rows)
            {
                ListViewItem i = new ListViewItem(r["cMCode"].ToString());
                i.SubItems.Add(r["cMName"].ToString());
                i.SubItems.Add(r["cInvCode"].ToString());
                i.Tag = r;
                lv.Items.Add(i);
            }
        }

        private void BtnAPSResult_Click(object sender, EventArgs e)
        {
            DateTime dBegin = dateBegin.Value.Date;
            DateTime dEnd = dateEnd.Value.Date;

            FmAPSResult frm = new FmAPSResult(dBegin, dEnd);
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
        }
    }
}