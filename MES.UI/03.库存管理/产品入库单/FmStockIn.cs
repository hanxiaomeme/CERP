using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Windows.Forms;

namespace LanyunMES.UI
{
    using Model;
    using DAL;
    using Server.Model;
    using U8Ext.Ref;
    using U8API;
    using Component;

    public partial class FmStockIn : DevComponents.DotNetBar.OfficeForm, IFView<TransVouchDAL>
    {
        private FmStockIn()
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
            this.txtr_whIn.ButtonCustomClick += RefWareHouse;
        }

        public FmStockIn(OpState op = OpState.Add): this()
        {
            this.opState = op;
        }

        public FmStockIn(string guid) : this()
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
        private TransVouch model = null;

        /// <summary>
        /// 控制器
        /// </summary>
        public TransVouchDAL Controller { get; private set; } = new TransVouchDAL();


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
            #region 窗体加载
            this.Text = pnlMain.Text;
            this.InitGridView();

            if (opState == OpState.Add)
            {
                model = model == null ? new TransVouch() : model;
                model.dTVDate = DateTime.Now.Date;
                model.cTVCode = "自动生成";
                model.cMaker = Information.UserInfo.cUser_Name;
                model.dMakeDate = DateTime.Now;
                model.Details = Controller.GetDList("0");
            }

            this.RefreshUI();  
            #endregion
        }

        private void RefreshUI()
        {
            #region 刷新UI
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

            this.txtr_cTVCode.DataBindings.Clear();
            this.txtr_whIn.DataBindings.Clear();
            this.txtr_maker.DataBindings.Clear();
            this.txtr_modifier.DataBindings.Clear();
            this.dTVDate.DataBindings.Clear();
            this.txtr_cAuditPsn.DataBindings.Clear();
            this.txtr_dAuditDate.DataBindings.Clear();
            this.txtr_dModifyDate.DataBindings.Clear();


            this.txtr_cTVCode.DataBindings.Add("Text", model, "cTVCode", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtr_whIn.DataBindings.Add("Text", model, "cIWhName", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtr_maker.DataBindings.Add("Text", model, "cMaker", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtr_modifier.DataBindings.Add("Text", model, "cModifier", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtr_dModifyDate.DataBindings.Add("Text", model, "dModifyDate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.dTVDate.DataBindings.Add("Value", model, "dTVDate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtr_cAuditPsn.DataBindings.Add("Text", model, "cAuditPsn", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtr_dAuditDate.DataBindings.Add("Text", model, "dAuditDate", true, DataSourceUpdateMode.OnPropertyChanged);


            gridControl1.DataSource = model.Details; 
            #endregion
        }

        #region 上下记录

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

        #endregion

        private void Add(object sender, EventArgs e)
        {
            #region 新增
            model = new TransVouch();
            model.dTVDate = DateTime.Now.Date;
            opState = OpState.Add;

            this.RefreshUI(); 
            #endregion
        }

        private void Edit(object sender, EventArgs e)
        {
            #region 编辑
            this.opState = OpState.Update;
            UIControl.SetStatus(this, this.opState);
            //UIControl.SetStatus(bar1, bar2, pnlMain, gridView1, OpState.Update); 
            #endregion
        }

        private void Cancel(object sender, EventArgs e)
        {
            #region 取消
            this.opState = OpState.Browse;
            this.model = Controller.Get(guid);
            if (model == null)
            {
                model = new TransVouch();
            }
            this.RefreshUI(); 
            #endregion
        }

        private void Delete(object sender, EventArgs e)
        {
            #region 删除
            this.Controller.Delete(guid);
            this.model = new TransVouch();
            this.RefreshUI(); 
            #endregion
        }

        private void Save(object sender, EventArgs e)
        {
            #region 保存
            
            this.gridView1.CloseEditor();
            this.gridView1.UpdateCurrentRow();
            SaveCheck();

            if (this.opState == OpState.Add)
            {
                this.guid = Controller.Add(model);
            }
            else if (this.opState == OpState.Update)
            {
                model.cModifier = Information.UserInfo.cUser_Name;
                Controller.Update(model);
            }
            model = Controller.Get(guid);
            this.opState = OpState.Browse;
            RefreshUI(); 
            #endregion
        }

        private void Audit(object obj, EventArgs e)
        {
            #region 审核
            try
            {
                string vouchid;

                if (!string.IsNullOrEmpty(model.cSource))
                {
                    vouchid = new U8API.U8OperationClient().PuStoreInByTV(model.Guid, Information.UserInfo.cUser_Name);
                }
                else
                {
                    vouchid = new U8API.U8OperationClient().TransVouch(model.Guid, Information.UserInfo.cUser_Name);
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowInfoMsg("生成U8单据出错: " + ex.Message);
                return;
            }

            if (Controller.Audit(guid, Information.UserInfo.cUser_Name))
            {
                model = Controller.Get(guid);
                RefreshUI();
            }
            else
            {
                MsgBox.ShowInfoMsg("审核失败!");
            } 
            #endregion
        }

        private void UnAudit(object sender, EventArgs e)
        {
            #region 弃审
            if(!Controller.UnAuditCheck(guid))
            {
                throw new Exception("U8存在关联单据不能弃审!");
            }

            if (Controller.UnAudit(guid))
            {
                model = Controller.Get(guid);
                RefreshUI();
            }
            else
            {
                MsgBox.ShowInfoMsg("弃审失败!");
            } 
            #endregion
        }

        private void SaveCheck()
        {
            #region 保存校验
            if (string.IsNullOrEmpty(model.cIWhCode))
            {
                throw new Exception("入库仓库不能为空!");
            }
            else if (string.IsNullOrEmpty(model.cTVCode))
            {
                throw new Exception("单据号不能为空!");
            }
            else if (model.cSource != "检验单" && string.IsNullOrEmpty(model.cOWhCode))
            {
                throw new Exception("转出仓库不能为空!");
            }

            //foreach (DataRow row in model.Details.Rows)
            //{
            //    if (row.RowState == DataRowState.Deleted) continue;

            //    if (string.IsNullOrEmpty(row["cOutPosCode"].ToString()))
            //    {
            //        throw new Exception("转出货位不能为空!");
            //    }
            //    if (string.IsNullOrEmpty(row["cInPosCode"].ToString()))
            //    {
            //        throw new Exception("转入货位不能为空!");
            //    }
            //} 
            #endregion
        }


        private void Btn_Addline_Click(object sender, EventArgs e)
        {
            this.gridView1.AddNewRow();

            //var row = this.model.Details.NewRow();
            //this.model.Details.Rows.Add(row);

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

        private void RefWareHouse(object sender, EventArgs e)
        {
            #region 参照 - 仓库档案
            IRefDAL2 dal = new WarehouseDAL(Information.UserInfo.ConnU8);
            RefForm2 frm = new RefForm2(dal);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var tbox = (sender as TextBox);
                tbox.Text = frm.rows[0]["cWhName"].ToString();

                if (tbox.Name.Contains("whOut"))
                {
                    if(model.cIWhCode == frm.rows[0]["cWhCode"].ToString())
                    {
                        MsgBox.ShowInfoMsg("转入转出仓库不能相同!");
                        return;
                    }
                    model.cOWhCode = frm.rows[0]["cWhCode"].ToString();
                    foreach(DataRow r in model.Details.Rows)
                    {
                        r["cOutPosCode"] = DBNull.Value;
                        r["cOutPosName"] = DBNull.Value;
                    }
                }
                else
                {
                    if (model.cOWhCode == frm.rows[0]["cWhCode"].ToString())
                    {
                        MsgBox.ShowInfoMsg("转入转出仓库不能相同!");
                        return;
                    }
                    model.cIWhCode = frm.rows[0]["cWhCode"].ToString();
                    foreach (DataRow r in model.Details.Rows)
                    {
                        r["cInPosCode"] = DBNull.Value;
                        r["cInPosName"] = DBNull.Value;
                    }
                }
            } 
            #endregion
        }

        private void RefQmrList(object sender, EventArgs e)
        {
            #region 参照 - 检验单
            FmRQmrList frm = new FmRQmrList();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                (sender as TextBox).Text = frm.selectMitem["QMRCode"].ToString();
                model.cSource = "检验单";
                model.cSourceCode = frm.selectMitem["QMRCode"].ToString();
                model.cSourceGuid = frm.selectMitem["Guid"].ToString();

                model.Details.Rows.Clear();
                foreach(DataRow p in frm.selectDitems)
                {
                    var row = this.model.Details.NewRow();
                    row["POIDs"] = p["POIDs"];
                    row["cOutPosCode"] = p["cPosCode"];
                    row["cOutPosName"] = p["cPosName"];
                    row["cInvCode"] = p["cInvCode"];
                    row["cInvName"] = p["cInvName"];
                    row["cInvStd"] = p["cInvStd"];
                    row["cFree1"] = p["cFree1"];
                    row["cComUnitName"] = p["cComUnitName"];
                    row["iTVQuantity"] = p["iQualifyQty"];
                    model.Details.Rows.Add(row);
                }
          
            } 
            #endregion
        }


        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //this.gridView1.CellValueChanged -= gridView1_CellValueChanged;

            if (e.Column.Name == "cInPosCode" )
            {
                var cposcode = gridView1.GetRowCellValue(e.RowHandle, "cInPosCode").ToString();
                if(!string.IsNullOrEmpty(cposcode))
                {
                    if (string.IsNullOrEmpty(model.cIWhCode))
                    {
                        throw new Exception("先选择仓库!");
                    }
                    gridView1.SetRowCellValue(e.RowHandle, "cInPosName", Controller.GetPosistion(cposcode, model.cIWhCode));
                }            
            }
            else if(e.Column.Name == "cOutPosCode")
            {
                var cposcode = gridView1.GetRowCellValue(e.RowHandle, "cOutPosCode").ToString();

                if (!string.IsNullOrEmpty(cposcode))
                {
                    if (string.IsNullOrEmpty(model.cOWhCode))
                    {
                        throw new Exception("先选择仓库!");
                    }
                    gridView1.SetRowCellValue(e.RowHandle, "cOutPosName", Controller.GetPosistion(cposcode, model.cOWhCode));
                }
            }

            //this.gridView1.CellValueChanged += gridView1_CellValueChanged;
        }
    }
}
