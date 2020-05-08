using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LanyunMES.UI
{
    using Common;
    using Component;
    using DAL;
    using DevExpressUtility;
    using Model;
    using U8API;
    using U8Ext.Ref;
    using FastReport;

    public partial class FmMaterialPlanBak : DevComponents.DotNetBar.OfficeForm
    {
        public FmMaterialPlanBak(OpState op = OpState.Add)
        {
            InitializeComponent();
            this.Text = pnlMain.Text;
            this.opState = op;

            this.Load += FmLoad;
            this.BtnAdd.Click += Add;
            this.BtnEdit.Click += Edit;
            this.BtnCancel.Click += Cancel;
            this.BtnSave.Click += Save;
            this.BtnDel.Click += Delete;
            this.BtnAudit.Click += Audit;
            this.BtnUnAudit.Click += UnAudit;

            if (opState == OpState.Add)
            {
                this.Add(null, null);
            }
        }

        public FmMaterialPlanBak(string guid) : this(OpState.Browse)
        {
            this.guid = guid;
            this.model = dal.Get(guid);
            if(model == null)
            {
                throw new Exception("找不到对应单据!");
            }
        }

        private OpState opState;
        private string guid;
        private MaterialPlan model = null;
        MaterialPlanDAL dal  = new MaterialPlanDAL();


        //===========================================================


        /// <summary>
        /// 载入待出库行记录
        /// </summary>
        /// <param name="rows">以选择待出库行</param>
        public void LoadData(DataRow[] rows)
        {
            foreach(DataRow r in rows)
            {
                var guid = r["guid"].ToString();

                if (HaveSelected(guid))
                {
                    continue;
                }

                var row = model.dtDetails.NewRow();
                row["CardNo"] = r["CardNo"];
                //row["OpSeq"] = r["OpSeq"];
                row["cInvCode"] = r["cInvCode"];
                row["cInvName"] = r["cInvName"];
                row["cInvStd"] = r["cInvStd"];
                row["cComUnitName"] = r["cComUnitName"];
                row["operationId"] = r["operationId"];
                row["OpName"] = r["OpName"];
                row["iQuantity"] = r["iQuantity"];
                row["mrGuid"] = guid;
                //row["mccId"] = r["AutoId"];
                model.dtDetails.Rows.Add(row);
            }
        }


        private void InitGridView()
        {
            gridView1.Columns.Clear();

            gridView1.OptionsBehavior.AutoPopulateColumns = false;

            var column = GridViewHelper.AddColumn(this.gridView1, "cPosCode", "货位编码", 70);
            column.Summary.Add(DevExpress.Data.SummaryItemType.Count);
            column.Summary[0].FieldName = "cPosCode";
            column.Summary[0].DisplayFormat = "{记录:0}";

            GridViewHelper.AddColumn(this.gridView1, "cPosName", "货位名称", 80, readOnly: true);
            GridViewHelper.AddColumn(this.gridView1, "cardNo", "流转卡号", readOnly: true);
            GridViewHelper.AddColumn(this.gridView1, "OpSeq", "工序序号", 70, readOnly: true);            
            GridViewHelper.AddColumn(this.gridView1, "OpName", "工序名称", 80, readOnly: true);
            GridViewHelper.AddColumn(this.gridView1, "cInvCode", "存货编码", 120, readOnly: true);
            GridViewHelper.AddColumn(this.gridView1, "cInvName", "存货名称", 100, readOnly: true);
            GridViewHelper.AddColumn(this.gridView1, "cInvStd", "规格型号", 100, readOnly: true);
            GridViewHelper.AddColumn(this.gridView1, "iQuantity", "数量", 80);
            GridViewHelper.AddColumn(this.gridView1, "cComUnitName", "单位", 50, readOnly: true);
        }

        private void FmLoad(object sender, EventArgs e)
        {         
            this.InitGridView();
            this.RefreshUI(); 
        }

        private void RefreshUI()
        {
            if (opState == OpState.Browse || opState == OpState.Audit)
            {
                if (string.IsNullOrEmpty(model.cAuditPsn))
                {
                    this.opState = OpState.Browse;
                }
                else
                {
                    this.opState = OpState.Audit;
                }
            }

            UIControl.SetStatus(this, this.opState);

            UIBinding<MaterialPlan>.UIDataBinding(pnlMain, model);

            gridControl1.DataSource = model.dtDetails;
        }


        //新增
        private void Add(object sender, EventArgs e)
        {
            model = new MaterialPlan();
            model.MPCode = "自动生成";
            model.cMaker = Information.UserInfo.cUser_Name;
            model.dDate = DateTime.Now.Date;

            model.dtDetails = dal.GetBody("");

            this.opState = OpState.Add;

            this.RefreshUI();
        }

        //编辑
        private void Edit(object sender, EventArgs e)
        {
            this.opState = OpState.Update;
            UIControl.SetStatus(this, this.opState);
        }

        //取消
        private void Cancel(object sender, EventArgs e)
        {
            this.opState = OpState.Browse;
            this.model = dal.Get(guid);
            if(model == null)
            {
                model = new MaterialPlan();
            }
            this.RefreshUI();
        }

        //删除
        private void Delete(object sender, EventArgs e)
        {
            this.dal.Delete(guid);
            this.model = new MaterialPlan();
            this.model.dDate = DateTime.Now.Date;
            this.RefreshUI();
        }

        //保存
        private void Save(object sender, EventArgs e)
        {
            SaveCheck();

            if(this.opState == OpState.Add)
            {
                this.guid = dal.Add(model);
            }
            else if(this.opState == OpState.Update)
            {
                model.cModifier = Information.UserInfo.cUser_Name;
                //dal.Update(model);
            }        
            model = dal.Get(guid);
            this.opState = OpState.Browse;
            RefreshUI();
        }

        //审核
        private void Audit(object obj, EventArgs e)
        {
            //try
            //{
            //    U8PuStoreIn(this.model);
            //}
            //catch (Exception ex)
            //{
            //    MsgBox.ShowInfoMsg("生成U8材料出库单出错: " + ex.Message);
            //    return;
            //}

            new U8OperationClient().AuditMaterialPlan(guid, Information.UserInfo.cUser_Name);

            MsgBox.ShowInfoMsg("生成U8材料出库单成功");

            model = dal.Get(guid);
            RefreshUI();
        }

        //弃审
        private void UnAudit(object sender, EventArgs e)
        {
            new U8OperationClient().UnAuditMaterialPlan(guid);
            model = dal.Get(guid);
            RefreshUI(); 
        }

        private void SaveCheck()
        {
            //if (string.IsNullOrEmpty(model.cWhCode))
            //{
            //    throw new Exception("仓库不能为空!");
            //}
            foreach (DataRow row in model.dtDetails.Rows)
            {
                if (row.RowState == DataRowState.Deleted) continue;

                if(row["iQuantity"] == DBNull.Value || Convert.ToDecimal(row["iQuantity"]) <= 0)
                {
                    throw new Exception("数量不能为空或小于等于0!"); 
                }
                else if(row["cPosCode"] == DBNull.Value || row["cPosCode"].ToString() == "")
                {
                    throw new Exception("货位不能为空");
                }
            }
        }


        private void Btn_Addline_Click(object sender, EventArgs e)
        {
            FmRMaterialOutList frm = new FmRMaterialOutList();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                this.LoadData(frm.selectRows);
            }
        }

        private void Btn_Delline_Click(object sender, EventArgs e)
        {
            int handle = this.gridView1.FocusedRowHandle;
            this.gridView1.DeleteRow(handle);
        }


        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.gridView1.CellValueChanged -= gridView1_CellValueChanged;

            try
            {
                if (e.Column.Name == "iQualifyQty")
                {
                    var hgQty = Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "iQualifyQty"));

                    var qmQty = Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "qmQty"));

                    if (hgQty > qmQty)
                    {
                        throw new Exception("合格数量不能大于报检数量!");
                    }
                    else
                    {
                        gridView1.SetRowCellValue(e.RowHandle, "iUnQualifyQty", qmQty - hgQty);
                    }
                }
                else if (e.Column.Name == "iUnQualifyQty")
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
                else if (e.Column.FieldName == "cPosCode")
                {
                    //if (string.IsNullOrEmpty(model.cWhCode))
                    //{
                    //    this.txtr_warehouse.Focus();
                    //    gridView1.SetRowCellValue(e.RowHandle, "cPosCode", null);
                    //    throw new Exception("仓库编码不能为空!");
                    //}

                    //var cPosCode = e.Value.ToString();
                    //if (!string.IsNullOrEmpty(cPosCode))
                    //{
                    //    var cPosName = new PositionDAL(Information.UserInfo.ConnU8, model.cWhCode).GetName(cPosCode);
                    //    gridView1.SetRowCellValue(e.RowHandle, "cPosName", cPosName);
                    //}
                }
            }
            finally
            {
                this.gridView1.CellValueChanged += gridView1_CellValueChanged;
            }            
        }


        /// <summary>
        /// 是否已经选择
        /// </summary>
        private bool HaveSelected(string guid)
        {
            foreach (DataRow r in model.dtDetails.Rows)
            {
                if (r["guid"].ToString() == guid)
                {
                    return true;
                }
            }

            return false;
        }

        private void txtr_dModifyDate_ButtonCustomClick(object sender, EventArgs e)
        {
            //IRefDAL2 dal = new WarehouseDAL(Information.UserInfo.ConnU8);
            //RefForm2 frm = new RefForm2(dal);
            //if(frm.ShowDialog() == DialogResult.OK)
            //{
            //    model.cWhCode = frm.rows[0]["cWhCode"].ToString();
            //    (sender as TextBox).Text = frm.rows[0]["cWhName"].ToString();
            //}
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            List<MaterialPlan> ls = new List<MaterialPlan>();
            ls.Add(model);

            string file = ".//ReportPrint//拣货单.frx";
            FReportHelper<MaterialPlan>.GetReport(file, ls, ls[0].dtDetails).Show();
        }

        private void BtnDesign_Click(object sender, EventArgs e)
        {
            List<MaterialPlan> ls = new List<MaterialPlan>();
            ls.Add(model);

            string file = ".//ReportPrint//拣货单.frx";
            FReportHelper<MaterialPlan>.GetReport(file, ls, ls[0].dtDetails).Design();
        }
    }
}
