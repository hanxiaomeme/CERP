using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Windows.Forms;

namespace LanyunMES.UI
{
    using Model;
    using Server.Model;
    using U8Ext.Ref;
    using Component;
    using DevExpressUtility;

    public partial class FmWOReport : DevComponents.DotNetBar.OfficeForm, IFView<QmRecordController>
    {
        private FmWOReport()
        {
            InitializeComponent();
            this.Load += FmLoad;
            this.BtnCancel.Click += Cancel;
            this.BtnSave.Click += Save;
        }

        public FmWOReport(string guid) : this()
        {
            this.guid = guid;
            this.model = Controller.Get(guid);
            if(model == null)
            {
                throw new Exception("找不到对应单据!");
            }
        }

        //操作类型
        private OpState opState;

        //主键单据Guid
        private string guid;

        //报检单对象
        private QmRecord model = null;

        /// <summary>
        /// 控制器
        /// </summary>
        public QmRecordController Controller { get; private set; } = new QmRecordController();


        //===========================================================

        private void InitGridView()
        {
            gridView1.OptionsBehavior.AutoPopulateColumns = false;

            var column = GridViewHelper.AddColumn(this.gridView1, "WOCode", "指令单号", 90);
            column.Summary.Add(DevExpress.Data.SummaryItemType.Count);
            column.Summary[0].FieldName = "WOCode";
            column.Summary[0].DisplayFormat = "{记录:0}";
            column.OptionsColumn.ReadOnly = true;

            GridViewHelper.AddColumn(this.gridView1, "MoCode", "生产订单", 90).OptionsColumn.ReadOnly = true;
            GridViewHelper.AddColumn(this.gridView1, "SortSeq", "行号", 40).OptionsColumn.ReadOnly = true;
            GridViewHelper.AddColumn(this.gridView1, "OpSeq", "工序序号", 70).OptionsColumn.ReadOnly = true;
            GridViewHelper.AddColumn(this.gridView1, "OpName", "工序名称", 80).OptionsColumn.ReadOnly = true;
            GridViewHelper.AddColumn(this.gridView1, "cInvCode", "存货编码", 100).OptionsColumn.ReadOnly = true;
            GridViewHelper.AddColumn(this.gridView1, "cInvName", "存货名称", 100).OptionsColumn.ReadOnly = true;
            GridViewHelper.AddColumn(this.gridView1, "cInvStd", "规格型号", 100).OptionsColumn.ReadOnly = true;

            column = GridViewHelper.AddColumn(this.gridView1, "WOQty", "工单数量", 80);
            column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            column.DisplayFormat.FormatString = "{0:n2}";
            column.OptionsColumn.ReadOnly = true;

            column = GridViewHelper.AddColumn(this.gridView1, "RepQty", "已报工数量", 90);
            column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            column.DisplayFormat.FormatString = "{0:n2}";
            column.OptionsColumn.ReadOnly = true;

            column = GridViewHelper.AddColumn(this.gridView1, "iQuantity", "报工数量", 80);
            column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            column.DisplayFormat.FormatString = "{0:n2}";

            column = GridViewHelper.AddColumn(this.gridView1, "Worker", "操作员", 70);

            GridViewHelper.AddColumn(this.gridView1, "cMemo", "备注", 80);

        }

        private void FmLoad(object sender, EventArgs e)
        {
            this.Text = pnlMain.Text;
            this.InitGridView();

            this.RefreshUI(); 
        }

        private void RefreshUI()
        {
            if (opState == OpState.Browse || opState == OpState.Audit)
            {
                if (model.iState == 0)
                {
                    this.opState = OpState.Browse;
                }
                else if (model.iState == 1)
                {
                    this.opState = OpState.Audit;
                }
            }

            UIControl.SetStatus(this, this.opState);

            this.txtr_QmCode.DataBindings.Clear();
            this.txtr_maker.DataBindings.Clear();
            this.dQmDate.DataBindings.Clear();

            this.txtr_QmCode.DataBindings.Add("Text", model, "QMRCode", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtr_maker.DataBindings.Add("Text", model, "cMaker", true, DataSourceUpdateMode.OnPropertyChanged);
            this.dQmDate.DataBindings.Add("Value", model, "dDate", true, DataSourceUpdateMode.OnPropertyChanged);

            gridControl1.DataSource = model.Details;
        }



        //取消
        private void Cancel(object sender, EventArgs e)
        {
            this.opState = OpState.Browse;
            this.model = Controller.Get(guid);
            if(model == null)
            {
                model = new QmRecord();
            }
            this.RefreshUI();
        }


        //保存
        private void Save(object sender, EventArgs e)
        {
            SaveCheck();

            if(this.opState == OpState.Add)
            {
                this.guid = Controller.Add(model);
            }
            else if(this.opState == OpState.Update)
            {
                model.cModifier = Information.UserInfo.cUser_Name;
                Controller.Update(model);
            }        
            model = Controller.Get(guid);
            this.opState = OpState.Browse;
            RefreshUI();
        }

        //审核
        private void Audit(object obj, EventArgs e)
        {
            //try
            //{
            //    Controller.U8PuStoreIn(this.model);
            //}
            //catch (Exception ex)
            //{
            //    MsgBox.ShowInfoMsg("生成U8采购入库单出错: " + ex.Message);
            //    return;
            //}

            if (Controller.Audit(guid, Information.UserInfo.cUser_Name))
            {
                model = Controller.Get(guid);
                RefreshUI();
            }
            else
            {
                MsgBox.ShowInfoMsg("审核失败!");
            }
        }

        //弃审
        private void UnAudit(object sender, EventArgs e)
        {
            if (Controller.UnAudit(guid))
            {
                model = Controller.Get(guid);
                RefreshUI();
            }
            else
            {
                MsgBox.ShowInfoMsg("弃审失败!");
            }
        }

        private void SaveCheck()
        {
            if(string.IsNullOrEmpty(model.cVenCode))
            {
                throw new Exception("供应商不能为空!");
            }
            if (string.IsNullOrEmpty(model.QMRCode))
            {
                throw new Exception("单据号不能为空!");
            }

            foreach (DataRow row in model.Details.Rows)
            {
                if (row.RowState == DataRowState.Deleted) continue;

                var hgQty = Convert.ToDecimal(row["iQualifyQty"]);
                var bhgQty = Convert.ToDecimal(row["iUnQualifyQty"]);
                var qmQty = Convert.ToDecimal(row["qmQty"]);

                if(hgQty + bhgQty != qmQty)
                {
                    throw new Exception("合格数量加不合格数量不等于质检数量!");
                }
            }
        }


        private void Btn_Addline_Click(object sender, EventArgs e)
        {
            //this.bindingList.AddNew();
            //if(this.txtr_vendor.Text.Trim() == "")
            //{
            //    MsgBox.ShowInfoMsg("请先选择供应商！");
            //    this.txtr_vendor.Focus();
            //    return;
            //}
        }

        private void Btn_Delline_Click(object sender, EventArgs e)
        {
            int handle = this.gridView1.FocusedRowHandle;
            this.gridView1.DeleteRow(handle);
        }

        private void RefVendor(object sender, EventArgs e)
        {
            IRefDAL dal = new VendorDAL(Information.UserInfo.ConnU8);
            RefForm frm = new RefForm(dal);
            if(frm.ShowDialog() == DialogResult.OK)
            {
                (sender as TextBox).Tag = frm.rows[0]["cVenCode"].ToString();
                (sender as TextBox).Text = frm.rows[0]["cVenName"].ToString();
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.gridView1.CellValueChanged -= gridView1_CellValueChanged;

            if (e.Column.Name == "iQualifyQty")
            {
                var hgQty = Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "iQualifyQty"));

                var qmQty = Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "qmQty"));

                if(hgQty > qmQty)
                {
                    throw new Exception("合格数量不能大于报检数量!");
                }
                else
                {
                    gridView1.SetRowCellValue(e.RowHandle,"iUnQualifyQty", qmQty - hgQty);
                }
            }
            else if(e.Column.Name == "iUnQualifyQty")
            {

                var bhgQty = Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "iUnQualifyQty"));

                var qmQty = Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "qmQty"));

                if (bhgQty > qmQty)
                {
                    throw new Exception("不合格数量不能大于报检数量!");
                }
                else
                {
                    gridView1.SetRowCellValue(e.RowHandle, "iQualifyQty", qmQty - bhgQty);
                }
            }

            this.gridView1.CellValueChanged += gridView1_CellValueChanged;
        }
    }
}
