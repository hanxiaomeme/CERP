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

    public partial class FmRecord01 : DevComponents.DotNetBar.OfficeForm, IFView<RDRecordController>
    {
        private FmRecord01()
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
            this.BtnPrintBarCode.Click += PrintBarCode;
            this.BtnPrintDesgin.Click += PrintDesgin;
            this.txtr_vendor.ButtonCustomClick += RefVendor;
            this.txtr_warehouse.ButtonCustomClick += RefWarehouse;
            this.colBtnPostion.Click += RefPosition;
        }



        public FmRecord01(string guid) : this()
        {
            this.guid = guid;
            this.model = Controller.Get(guid);
            if(model == null)
            {
                throw new Exception("找不到对应单据!");
            }
        }

        public FmRecord01(RDRecord model) : this()
        {
            this.opState = OpState.Add;
            this.model = model;
        }


        //操作类型
        private OpState opState;

        //主键单据Guid
        private string guid;

        //报检单对象
        private RDRecord model = null;

        /// <summary>
        /// 控制器
        /// </summary>
        public RDRecordController Controller { get; private set; } = new RDRecordController();


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
                model = model == null ? new RDRecord() : model;
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

            this.txtw_QmCode.DataBindings.Clear();
            this.txtr_vendor.DataBindings.Clear();
            this.txtr_maker.DataBindings.Clear();
            this.txtr_modifier.DataBindings.Clear();
            this.dQmDate.DataBindings.Clear();
            this.txtr_warehouse.DataBindings.Clear();
            this.txtr_cAuditPsn.DataBindings.Clear();
            this.txtr_dAuditDate.DataBindings.Clear();
            this.txtr_dModifyDate.DataBindings.Clear();
            this.txtr_cSource.DataBindings.Clear();


            this.txtr_cSource.DataBindings.Add("Text", model, "cSource", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtw_QmCode.DataBindings.Add("Text", model, "cCode", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtr_warehouse.DataBindings.Add("Text", model, "cWhName", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtr_maker.DataBindings.Add("Text", model, "cMaker", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtr_vendor.DataBindings.Add("Text", model, "cVenName", true, DataSourceUpdateMode.OnPropertyChanged);
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
            model = new RDRecord();
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
                model = new RDRecord();
            }
            this.RefreshUI();
        }

        //删除
        private void Delete(object sender, EventArgs e)
        {
            this.Controller.Delete(guid);
            this.model = new RDRecord();
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
            string vouchId = null;

            //生成U8采购入库
            vouchId = new U8OperationClient().PuStoreInAdd2(guid, Information.UserInfo.cUser_Name);


            if (Controller.Audit(guid, Information.UserInfo.cUser_Name, vouchId))
            {

                model = Controller.Get(guid);     
                           
                RefreshUI();

                MsgBox.ShowInfoMsg("生成采购入库单到U8成功: 单据ID: " + vouchId);
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

        private void PrintBarCode(object sender, EventArgs e)
        {
            string path = Application.StartupPath.Trim('\\');

            DataTable dt = this.gridControl1.DataSource as DataTable;

            this.PrintReport.Load(path + "\\ReportPrint\\采购入库条码.frx");
            this.PrintReport.RegisterData(dt, "M");
            this.PrintReport.Show();
        }


        private void PrintDesgin(object sender, EventArgs e)
        {
            string path = Application.StartupPath.Trim('\\');

            DataTable dt = this.gridControl1.DataSource as DataTable;

            this.PrintReport.Load(path + "\\ReportPrint\\采购入库条码.frx");
            this.PrintReport.RegisterData(dt, "M");
            this.PrintReport.Design();
        }

        private void SaveCheck()
        {
            #region 保存前检验
            if (string.IsNullOrEmpty(model.cVenCode))
            {
                throw new Exception("供应商不能为空!");
            }
            else if (string.IsNullOrEmpty(model.cCode))
            {
                throw new Exception("单据号不能为空!");
            }
            else if (string.IsNullOrEmpty(model.cWhCode))
            {
                txtr_warehouse.Focus();
                throw new Exception("仓库不能为空!");
            }

            foreach (DataRow row in model.Details.Rows)
            {
                if (row.RowState == DataRowState.Deleted) continue;

                if (row["cPosCode"].ToString() == "")
                {
                    throw new Exception("货位不能为空!");
                }

                var qty = Convert.ToDecimal(row["iQuantity"]);

                if (qty == 0)
                {
                    throw new Exception("数量不能为0!");
                }
            } 
            #endregion
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
            #region 供应商档案
            IRefDAL dal = new VendorDAL(Information.UserInfo.ConnU8);
            RefForm frm = new RefForm(dal);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                model.cVenCode = frm.rows[0]["cVenCode"].ToString();
                (sender as TextBox).Text = frm.rows[0]["cVenName"].ToString();
            } 
            #endregion
        }

        private void RefWarehouse(object sender, EventArgs e)
        {
            #region 仓库档案
            IRefDAL2 dal = new WarehouseDAL(Information.UserInfo.ConnU8);
            RefForm2 frm = new RefForm2(dal);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                model.cWhCode = frm.rows[0]["cWhCode"].ToString();
                this.txtr_warehouse.Text = frm.rows[0]["cWhName"].ToString(); 
                
                foreach(DataRow row in model.Details.Rows)
                {
                    row["cPosCode"] = DBNull.Value;
                    row["cPosName"] = DBNull.Value;
                }             
            } 
            #endregion
        }

        private void RefPosition(object sender, EventArgs e)
        {
            #region 货位档案
            if (string.IsNullOrEmpty(model.cWhCode))
            {
                MsgBox.ShowInfoMsg("请先选择仓库!");
                return;
            }
            IRefDAL2 dal = new PositionDAL(Information.UserInfo.ConnU8, model.cWhCode);
            RefForm2 frm = new RefForm2(dal);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                int handle = gridView1.FocusedRowHandle;
                gridView1.SetFocusedRowCellValue("cPosCode", frm.rows[0]["cPosCode"]);
                gridView1.SetFocusedRowCellValue("cPosName", frm.rows[0]["cPosName"]);
            } 
            #endregion
        }


    }
}
