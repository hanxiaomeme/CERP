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
    using System.Data.SqlClient;
    using Component;
    using DevExpressUtility;
    using Common;

    public partial class FmMaintenancePlan : DevComponents.DotNetBar.OfficeForm
    {
        public FmMaintenancePlan()
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

            this.txtr_cEQCode.ButtonCustomClick += RefEq;
            this.gridView2.RowClick += LoadData;

            this.gridView1.KeyDown += GridViewHelper.KeyDownCellCopy;
            this.gridView2.KeyDown += GridViewHelper.KeyDownCellCopy;

            this.Text = pnlMain.Text;
        }

        public FmMaintenancePlan(string guid) : this()
        {
            this.guid = guid;
            this.model = dal.Get(guid);
            if(model == null)
            {
                throw new Exception("找不到对应单据!");
            }
            this.opState = OpState.Browse;
        }

        //主键单据Guid
        private string guid;
        //操作类型
        private OpState opState = OpState.None;
        //单据对象
        private MaintenancePlan model = null;

        private List<string> wheres;
        private List<SqlParameter> paramList;

        MaintenancePlanDAL dal  = new MaintenancePlanDAL();


        //===========================================================

        private void InitGridColumns()
        {
            gridView1.OptionsBehavior.AutoPopulateColumns = false;

            //var column = UIGridControl.AddColumn(this.gridView1, "cPOID", "采购订单号", 80);
            //column.Summary.Add(DevExpress.Data.SummaryItemType.Count);
            //column.Summary[0].FieldName = "cPOID";
            //column.Summary[0].DisplayFormat = "{记录:0}"; 
        }

        private void FmLoad(object sender, EventArgs e)
        {            
            this.InitGridColumns();

            this.gridControl2.DataSource = dal.GetDataTable(null, null);

            if (opState == OpState.Add)
            {
                model = new MaintenancePlan();
                model.cMaker = Information.UserInfo.cUser_Name;
                model.DtBody = dal.GetBodyTable("");
            }

            this.RefreshUI();
        }

        private void LoadData(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            string guid = gridView2.GetRowCellValue(e.RowHandle, "guid").ToString();

            this.model = dal.Get(guid);
            this.opState = OpState.Browse;
            this.RefreshUI();
        }

        private void RefreshUI()
        {
            if (model != null)
            {
                UIBinding<MaintenancePlan>.UIDataBinding(pnlMain, model);
                gridControl1.DataSource = model.DtBody;
            }

            UIControl.SetStatus(this.collapsibleSplitContainer1.Panel2, this.opState);
            UIControl.SetStatus(this, this.opState);

            if (opState == OpState.Add || opState == OpState.Update)
            {
                gridControl2.Enabled = false;
            }
            else
            {
                gridControl2.Enabled = true;
            }
        }

        private void RefreshList()
        {
            if (wheres != null && wheres.Count > 0)
            {
                this.gridControl2.DataSource = dal.GetDataTable(wheres.ToArray(), paramList.ToArray());
            }
            else
            {
                this.gridControl2.DataSource = dal.GetDataTable(null,null);
            }
        }


        #region 上下条记录
        //第一条记录
        private void Btn_first_Click(object sender, EventArgs e)
        {

        }

        //上一条记录
        private void Btn_previous_Click(object sender, EventArgs e)
        {

        }

        //下一条记录
        private void Btn_next_Click(object sender, EventArgs e)
        {

        }

        //最后一条记录
        private void Btn_last_Click(object sender, EventArgs e)
        {

        } 
        #endregion


        //新增
        private void Add(object sender, EventArgs e)
        {
            opState = OpState.Add;

            model = new MaintenancePlan();
            model.cMaker = Information.UserInfo.cUser_Name;
            model.DtBody = dal.GetBodyTable("");

            this.RefreshUI();
        }

        //编辑
        private void Edit(object sender, EventArgs e)
        {
            this.opState = OpState.Update;
            this.RefreshUI();
        }

        //取消
        private void Cancel(object sender, EventArgs e)
        {
            if (opState == OpState.Add)
            {
                this.opState = OpState.None;
            }
            else if (opState == OpState.Update)
            {
                this.opState = OpState.Browse;
            }

            this.model = null;
            this.RefreshUI();
        }

        //删除
        private void Delete(object sender, EventArgs e)
        {
            this.dal.Delete(model.guid);
            this.model = new MaintenancePlan();
            this.RefreshList();
            this.RefreshUI();
        }

        //保存
        private void Save(object sender, EventArgs e)
        {
            SaveCheck();

            if (this.opState == OpState.Add)
            {
                this.guid = dal.Add(model);
            }
            else if (this.opState == OpState.Update)
            {
                model.cModifier = Information.UserInfo.cUser_Name;
                dal.Update(model);
            }
            model = dal.Get(guid);
            this.opState = OpState.Browse;

            RefreshList();
            RefreshUI();
        }

        //审核
        private void Audit(object obj, EventArgs e)
        {
            //if (dal.Audit(guid, Information.UserInfo.cUser_Name))
            //{
            //    model = dal.Get(guid);
            //    RefreshUI();
            //}
            //else
            //{
            //    MsgBox.ShowInfoMsg("审核失败!");
            //}
        }

        //弃审
        private void UnAudit(object sender, EventArgs e)
        {
            //if (dal.UnAudit(guid))
            //{
            //    model = dal.Get(guid);
            //    RefreshUI();
            //}
            //else
            //{
            //    MsgBox.ShowInfoMsg("弃审失败!");
            //}
        }

        private void SaveCheck()
        {
            if (model.EQId == 0)
            {
                throw new Exception("产品不能为空!");
            }
            if(model.DtBody.Rows.Count < 1)
            {
                throw new Exception("表体不能为空!");
            }

            foreach (DataRow row in model.DtBody.Rows)
            {
                //if(row["iStep"].ToString() == "")
                //{
                //    throw new Exception("节拍不能为空!");
                //}    
            }
        }

        private void Btn_Addline_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(model.cCode))
            {
                MsgBox.ShowInfoMsg("请先选择设备！");
                this.txtr_cEQName.Focus();
                return;
            }

            FmRMould frm = new FmRMould();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                var mid = frm.Result.MId;
                DataTable dt = new MouldDAL().GetEqDetails(mid);
                if(dt.Rows.Count < 1)
                {
                    throw new Exception("所选模具没有设置对应设备!");
                }

                foreach(DataRow r in dt.Rows)
                {
                    var row = model.DtBody.NewRow();
                    row["MId"] = frm.Result.MId;
                    row["cMCode"] = frm.Result.cMCode;
                    row["cMName"] = frm.Result.cMName;
                    row["Points"] = frm.Result.Points;
                    row["EQId"] = r["EQId"];
                    row["cEQCode"] = r["cEQCode"];
                    row["cEQName"] = r["cEQName"];
                    row["OpCode"] = r["OpCode"];
                    row["OpName"] = r["OpName"];

                    model.DtBody.Rows.Add(row);
                }
            }
        }

        private void Btn_Delline_Click(object sender, EventArgs e)
        {
            int handle = this.gridView1.FocusedRowHandle;
            this.gridView1.DeleteRow(handle);
        }

        private void RefEq(object sender, EventArgs e)
        {
            if (rb1.Checked)
                RefEquipment();
            else
                RefEquipmentClass();
        }

        private void RefEquipment()
        {
            FmREquipment frm = new FmREquipment();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                model.EQId = frm.Results[0].EQId;
                txtr_cEQCode.Text = frm.Results[0].cEQCode;
                txtr_cEQName.Text = frm.Results[0].cEQName;
                model.bClass = false;
            }
        }

        private void RefEquipmentClass()
        {
            ITreeClassDAL dal = new EquipmentClassDAL();
            FmRClassInfo frm = new FmRClassInfo(dal, "设备分类");
            if(frm.ShowDialog() == DialogResult.OK)
            {
                var result = frm.Result as EquipmentClass;
                model.EQId = result.EQCId;
                txtr_cEQCode.Text = result.Code;
                txtr_cEQName.Text = result.Name;
                model.bClass = true;
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //this.gridView1.CellValueChanged -= gridView1_CellValueChanged;

            //if (e.Column.Name == "iQualifyQty")
            //{
            //    var hgQty = Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "iQualifyQty"));

            //    var qmQty = Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "qmQty"));

            //    if(hgQty > qmQty)
            //    {
            //        throw new Exception("合格数量不能大于报检数量!");
            //    }
            //    else
            //    {
            //        gridView1.SetRowCellValue(e.RowHandle,"iUnQualifyQty", qmQty - hgQty);
            //    }
            //}
            //else if(e.Column.Name == "iUnQualifyQty")
            //{

            //    var bhgQty = Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "iUnQualifyQty"));

            //    var qmQty = Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "qmQty"));

            //    if (bhgQty > qmQty)
            //    {
            //        throw new Exception("不合格数量不能大于报检数量!");
            //    }
            //    else
            //    {
            //        gridView1.SetRowCellValue(e.RowHandle, "iQualifyQty", qmQty - bhgQty);
            //    }
            //}

            //this.gridView1.CellValueChanged += gridView1_CellValueChanged;
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            FmInvMouldQ frm =  new FmInvMouldQ();
            frm.LoadSqlParams(paramList);
            if(frm.ShowDialog() == DialogResult.OK)
            {
                this.wheres = frm.ListWhere;
                this.paramList = frm.Parameters;

                this.gridControl2.DataSource = dal.GetDataTable(wheres.ToArray(), paramList.ToArray());
            } 
        }
    }
}
