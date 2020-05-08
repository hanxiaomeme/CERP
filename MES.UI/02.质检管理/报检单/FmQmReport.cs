using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Windows.Forms;

namespace LanyunMES.UI
{
    using Component;
    using Model;
    using Server.Model;
    using U8Ext.Ref;

    public partial class FmQmReport : DevComponents.DotNetBar.OfficeForm
    {
        private FmQmReport()
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
            this.gridView1.CellValueChanged += UpdateRowStatus;
            //this.gridView1.CellValueChanged += QualityChecked;
        }



        /// <summary>
        /// 设置Grid行为编辑状态
        /// </summary>
        private void UpdateRowStatus(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var state = (ModelState)gridView1.GetRowCellValue(e.RowHandle, "ModelState");
            if (state != ModelState.added || state != ModelState.modified)
            {
                model.Details[e.RowHandle].ModelState = ModelState.modified;
            }
        }

        public FmQmReport(string guid) : this()
        {
            this.guid = guid;
            this.model = controller.Get(guid);
            this.opState = model.iState == 1 ? OpState.Audit : OpState.Browse;
        }

        public FmQmReport(QmReport model) : this()
        {
            this.opState = OpState.Add;
            this.model = model;
            this.model.QMCode = "自动生成";
        }


        //操作类型
        private OpState opState;

        //主键单据Guid
        private string guid;

        //报检单对象
        private QmReport model = null;

        //子表绑定对象
        private BindingList<QmReports> bindingList;

        /// <summary>
        /// 控制器
        /// </summary>
        public QmReportController controller { get; private set; } = new QmReportController();

        

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
            this.txtr_modifyDate.DataBindings.Clear();
            this.txtr_cAuditPsn.DataBindings.Clear();
            this.txtr_dAuditDate.DataBindings.Clear();
            this.txtw_cMemo.DataBindings.Clear();

            this.txtr_QmCode.DataBindings.Add("Text", model, "QMCode", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtr_maker.DataBindings.Add("Text", model, "cMaker", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtr_vendor.DataBindings.Add("Text", model.Vendor, "cVenName", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtr_vendor.DataBindings.Add("Tag", model.Vendor, "cVenCode", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtr_modifier.DataBindings.Add("Text", model, "cModifier", true, DataSourceUpdateMode.OnPropertyChanged);
            this.dQmDate.DataBindings.Add("Value", model, "dDate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtr_modifyDate.DataBindings.Add("Text", model, "dModifyDate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtr_cAuditPsn.DataBindings.Add("Text", model, "cAuditPsn", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtr_dAuditDate.DataBindings.Add("Text", model, "dAuditDate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtw_cMemo.DataBindings.Add("Text", model, "cMemo", true, DataSourceUpdateMode.OnPropertyChanged);


            bindingList = new BindingList<QmReports>(model.Details);
            gridControl1.DataSource = bindingList;
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
            model = new QmReport();
            model.dDate = DateTime.Now.Date;
            opState = OpState.Add;

            this.RefreshUI();
        }

        //编辑
        private void Edit(object sender, EventArgs e)
        {
            this.opState = OpState.Update;
            UIControl.SetStatus(this, opState);
        }

        //取消
        private void Cancel(object sender, EventArgs e)
        {
            this.opState = OpState.Browse;
            this.model = controller.Get(guid);
            if(model == null )
            {
                model = new QmReport();
            }
            this.RefreshUI();
        }
         
        //删除
        private void Delete(object sender, EventArgs e)
        {
            this.controller.Delete(guid);
            this.model = new QmReport();
            this.RefreshUI();
        }

        //审核
        private void Audit(object sender, EventArgs e)
        {
            try
            {
                controller.U8PuStoreIn(this.model);
            }
            catch(Exception ex)
            {
                MsgBox.ShowInfoMsg("生成U8采购入库单出错: " + ex.Message);
                return;
            }

            if (controller.Audit(guid, Information.UserInfo.cUser_Name))
            {
                model = controller.Get(guid);
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
            if (controller.UnAudit(guid))
            {
                model = controller.Get(guid);
                RefreshUI();
            }
            else
            {
                MsgBox.ShowInfoMsg("弃审失败!");
            }
        }

        //保存
        private void Save(object sender, EventArgs e)
        {
            try
            {
                this.gridView1.CloseEditor();
                this.gridView1.UpdateCurrentRow();
                this.SaveCheck();

                if (this.opState == OpState.Add)
                {
                    this.guid = controller.Add(model);
                }
                else if (this.opState == OpState.Update)
                {
                    model.cModifier = Information.UserInfo.cUser_Name;
                    model.dModifyDate = DateTime.Now;
                    controller.Update(model);
                }

                opState = OpState.Browse;
                model = controller.Get(guid);
                RefreshUI();
                //model.Details.ForEach(p => p.ModelState = ModelState.unChanged);
                //this.opState = OpState.Browse;
                //UIControl.SetStatus(this, opState);
            }
            catch (Exception ex)
            {
                MsgBox.ShowInfoMsg(ex.Message);
            }
        }

        //是否报检
        private void QualityChecked(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.Column.FieldName == "bQuality")
            {
                decimal qmQty = (bool)e.Value ? (decimal)gridView1.GetRowCellValue(e.RowHandle, "arrQty") : 0;
                gridView1.SetRowCellValue(e.RowHandle, "qmQty", qmQty);
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




        private void SaveCheck()
        {
            if (string.IsNullOrEmpty(model.cVenCode))
            {
                throw new Exception("供应商不能为空!");
            }
            foreach (var a in model.Details)
            {
                if (a.arrQty <= 0)
                {
                    throw new Exception("到货数量不能小于等于0");
                }
                else if(a.arrQty < a.qmQty)
                {
                    throw new Exception("报检数量不能大于到货数量!");
                }
                else if(string.IsNullOrEmpty(a.cPosCode))
                {
                    throw new Exception("货位不能为空!");
                }
            }
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

        //表体单元格数据改变事件
        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "bQualify")
            {
                if ((bool)e.Value)
                {
                    var value = gridView1.GetRowCellValue(e.RowHandle, "arrQty");
                    gridView1.SetRowCellValue(e.RowHandle, "qmQty", value);
                }
                else
                {
                    gridView1.SetRowCellValue(e.RowHandle, "qmQty", 0);
                }
            }
            else if (e.Column.FieldName == "qmQty")
            {
                if (!(bool)gridView1.GetRowCellValue(e.RowHandle, "bQualify"))
                {
                    gridView1.SetRowCellValue(e.RowHandle, e.Column.Name, 0);
                }
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "cPosCode")
            {
                var cPosCode = e.Value.ToString();
                if (!string.IsNullOrEmpty(cPosCode))
                {
                    var cPosName = controller.GetPosName(cPosCode);
                    gridView1.SetRowCellValue(e.RowHandle, "cPosName", cPosName);
                }
            }
        }
    }
}
