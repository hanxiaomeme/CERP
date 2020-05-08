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
    using U8API;
    using Component;

    public partial class FmQmRecord : DevComponents.DotNetBar.OfficeForm, IFView<QmRecordController>
    {
        private FmQmRecord()
        {
            InitializeComponent();
            this.Load += FmLoad;
            this.BtnAdd.Click += Add;
            this.BtnEdit.Click += Edit;
            this.BtnCancel.Click += Cancel;
            this.BtnSave.Click += Save;
            this.BtnDel.Click += Delete;
            this.BtnAudit.Click += Audit;
            this.BtnUnAudit.Click += UnAudit;
            this.txtr_vendor.ButtonCustomClick += RefVendor;
        }

        public FmQmRecord(string guid) : this()
        {
            this.guid = guid;
            this.model = Controller.Get(guid);
            if(model == null)
            {
                throw new Exception("找不到对应单据!");
            }
        }

        public FmQmRecord(QmRecord model) : this()
        {
            this.opState = OpState.Add;
            this.model = model;
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

            //var column = UIGridControl.AddColumn(this.gridView1, "cPOID", "采购订单号", 80);
            //column.Summary.Add(DevExpress.Data.SummaryItemType.Count);
            //column.Summary[0].FieldName = "cPOID";
            //column.Summary[0].DisplayFormat = "{记录:0}";

            //UIGridControl.AddColumn(this.gridView1, "cInvCode", "存货编码", 100);
            //UIGridControl.AddColumn(this.gridView1, "cInvName", "存货名称", 90);
            //UIGridControl.AddColumn(this.gridView1, "cInvStd", "规格型号", 100);
            //UIGridControl.AddColumn(this.gridView1, "cFree1", "自由项1", 80);
            //UIGridControl.AddColumn(this.gridView1, "arrQty", "到货数量", 80);
            //UIGridControl.AddColumn(this.gridView1, "qmQty", "报检数量", 80);
            //UIGridControl.AddColumn(this.gridView1, "remark", "备注", 100);     
        }

        private void FmLoad(object sender, EventArgs e)
        {
            this.Text = pnlMain.Text;
            this.InitGridView();
            
            if (opState == OpState.Add)
            {
                model = model == null ? new QmRecord() : model;
                model.dDate = DateTime.Now.Date;
            }

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
            this.txtr_vendor.DataBindings.Clear();
            this.txtr_maker.DataBindings.Clear();
            this.txtr_modifier.DataBindings.Clear();
            this.dQmDate.DataBindings.Clear();
            this.txt_checkPsn.DataBindings.Clear();
            this.txtr_cAuditPsn.DataBindings.Clear();
            this.txtr_dAuditDate.DataBindings.Clear();
            this.txtr_dModifyDate.DataBindings.Clear();
             

            this.txtr_QmCode.DataBindings.Add("Text", model, "QMRCode", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txt_checkPsn.DataBindings.Add("Text", model, "checkPsn", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtr_maker.DataBindings.Add("Text", model, "cMaker", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtr_vendor.DataBindings.Add("Text", model.Vendor, "cVenName", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtr_vendor.DataBindings.Add("Tag", model.Vendor, "cVenCode", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtr_modifier.DataBindings.Add("Text", model, "cModifier", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtr_dModifyDate.DataBindings.Add("Text", model, "dModifyDate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.dQmDate.DataBindings.Add("Value", model, "dDate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtr_cAuditPsn.DataBindings.Add("Text", model, "cAuditPsn", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtr_dAuditDate.DataBindings.Add("Text", model, "dAuditDate", true, DataSourceUpdateMode.OnPropertyChanged);


            gridControl1.DataSource = model.Details;
        }


        //第一条记录
        private void Btn_first_Click(object sender, EventArgs e)
        {
            //this.curId = bllM.GetID(Navtion.first, 0);
            //this.LoadData(curId);
        }

        //上一条记录
        private void Btn_previous_Click(object sender, EventArgs e)
        {
            //int pid = bllM.GetID(Navtion.previous, curId);
            //if (pid == 0)
            //{
            //    MsgBox.ShowInfoMsg("已经是第一条记录！");
            //}
            //else
            //{
            //    this.curId = pid;
            //    this.LoadData(curId);
            //}
        }

        //下一条记录
        private void Btn_next_Click(object sender, EventArgs e)
        {
            //int nid = bllM.GetID(Navtion.next, curId);
            //if (nid == 0)
            //{
            //    MsgBox.ShowInfoMsg("已经是最后一条记录！");
            //}
            //else
            //{
            //    this.curId = nid;
            //    this.LoadData(curId);
            //}
        }

        //最后一条记录
        private void Btn_last_Click(object sender, EventArgs e)
        {
            //this.curId = bllM.GetID(Navtion.last, 0);
            //this.LoadData(curId);
        }



        //新增
        private void Add(object sender, EventArgs e)
        {
            model = new QmRecord();
            model.dDate = DateTime.Now.Date;
            opState = OpState.Add;

            this.RefreshUI();
        }

        //编辑
        private void Edit(object sender, EventArgs e)
        {
            this.opState = OpState.Update;
            UIControl.SetStatus(this, this.opState);
            //UIControl.SetStatus(bar1, bar2, pnlMain, gridView1, OpState.Update);
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

        //删除
        private void Delete(object sender, EventArgs e)
        {
            this.Controller.Delete(guid);
            this.model = new QmRecord();
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
            if(this.txtr_vendor.Text.Trim() == "")
            {
                MsgBox.ShowInfoMsg("请先选择供应商！");
                this.txtr_vendor.Focus();
                return;
            }
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
