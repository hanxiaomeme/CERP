using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace LanyunMES.UI
{
    using Component;
    using Entity;
    using U8Ext.Ref;
    using DevExpressUtility;

    public partial class FmInvMould : DevComponents.DotNetBar.OfficeForm
    {
        public FmInvMould()
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
            this.txtr_cInvCode.ButtonCustomClick += RefInventory;
            this.gridView2.RowClick += LoadData;

            this.gridView1.KeyDown += GridViewHelper.KeyDownCellCopy;
            this.gridView2.KeyDown += GridViewHelper.KeyDownCellCopy;

            this.Text = pnlMain.Text;
        }

        public FmInvMould(string cInvCode) : this()
        {
            this.opState = OpState.Browse;
            this.InvCode = cInvCode;
        }

        //操作类型
        private OpState opState = OpState.None;
 

        private List<string> wheres;
        private List<SqlParameter> paramList;
        private string InvCode;
        private DataTable dtMain, dtDetail;
        //MouldEquipmentInvDAL dal  = new MouldEquipmentInvDAL();


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

            this.dtMain = dal.GetInvTable(null);
            this.gridControl2.DataSource = dtMain;

            this.RefreshUI();
        }

        private void LoadData(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            this.InvCode = gridView2.GetRowCellValue(e.RowHandle, "cInvCode").ToString();

            this.dtDetail = dal.GetTableByInv(InvCode);
            this.opState = OpState.Browse;
            this.RefreshUI();
        }

        private void RefreshUI()
        {
            if (opState == OpState.Add)
            {
                this.dtDetail = dal.GetTableByInv("");
                this.txtr_cInvCode.Clear();
                this.txtr_cInvName.Clear();
                this.txtr_cInvStd.Clear();
            }

            if (dtDetail != null && dtDetail.Rows.Count > 0)
            {
                var row = dtDetail.Rows[0];

                txtr_cInvCode.Text = row[txtr_cInvCode.Tag.ToString()].ToString();
                txtr_cInvName.Text = row[txtr_cInvName.Tag.ToString()].ToString();
                txtr_cInvStd.Text = row[txtr_cInvStd.Tag.ToString()].ToString();
            }

            gridControl1.DataSource = dtDetail;

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
                this.gridControl2.DataSource = dal.GetInvTable(wheres.ToArray(), paramList.ToArray());
            }
            else
            {
                this.gridControl2.DataSource = dal.GetInvTable(null);
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
            this.opState = OpState.Add;
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

            this.RefreshUI();
        }

        //删除
        private void Delete(object sender, EventArgs e)
        {
            this.dal.DeleteByInv(InvCode);
            this.RefreshList();
            this.RefreshUI();
        }

        //保存
        private void Save(object sender, EventArgs e)
        {
            SaveCheck();

            SetOrder();

            foreach(DataRow r in dtDetail.Rows)
            {
                if (r.RowState == DataRowState.Deleted) continue;

                r["cInvCode"] = InvCode;
            }

            if (this.opState == OpState.Add || opState == OpState.Update)
            {
                dal.Save(InvCode, dtDetail);
            }

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
            if (string.IsNullOrEmpty(txtr_cInvCode.Text))
            {
                throw new Exception("产品不能为空!");
            }
            else if(dtDetail.Rows.Count < 1)
            {
                throw new Exception("表体不能为空!");
            }
            else if(opState == OpState.Add && dal.ExistInv(InvCode))
            {
                throw new Exception("产品: " + InvCode + " 已存在!");
            }


            foreach (DataRow row in dtDetail.Rows)
            {
                if (row.RowState == DataRowState.Deleted) continue;

                if(row["iStep"].ToString() == "")
                {
                    throw new Exception("节拍不能为空!");
                }    
            }
        }

        private void Btn_Addline_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtr_cInvCode.Text))
            {
                MsgBox.ShowInfoMsg("请先选择存货！");
                this.txtr_cInvName.Focus();
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
                    var row = dtDetail.NewRow();
                    row["MId"] = frm.Result.MId;
                    row["cMCode"] = frm.Result.cMCode;
                    row["cMName"] = frm.Result.cMName;
                    row["Points"] = frm.Result.Points;
                    row["bClass"] = r["bClass"];
                    row["bClassDesc"] = r["bClassDesc"];
                    row["EQId"] = r["EQId"];
                    row["cEQCode"] = r["cEQCode"];
                    row["cEQName"] = r["cEQName"];

                    dtDetail.Rows.Add(row);
                }

                SetOrder();
            }
        }

        private void Btn_Delline_Click(object sender, EventArgs e)
        {
            int handle = this.gridView1.FocusedRowHandle;
            this.gridView1.DeleteRow(handle);
        }

        private void RefInventory(object sender, EventArgs e)
        {
            IRefDAL dal = new InventoryDAL(Information.UserInfo.ConnU8);
            RefForm frm = new RefForm(dal);
            if(frm.ShowDialog() == DialogResult.OK)
            {
                var row = frm.rows[0];
                InvCode = row["cInvCode"].ToString();
                txtr_cInvCode.Text = row["cInvCode"].ToString();
                txtr_cInvName.Text = row["cInvName"].ToString();
                txtr_cInvStd.Text = row["cInvStd"].ToString();
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //this.gridView1.CellValueChanged -= gridView1_CellValueChanged;

            if (e.Column.Name == "iStep")
            {
                var points = Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "Points"));

                var iStep = Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "iStep"));

                decimal timeQty = points * (3600 / iStep);

                gridView1.SetRowCellValue(e.RowHandle, "timeQty", timeQty);

            }

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

                this.gridControl2.DataSource = dal.GetInvTable(wheres.ToArray(), paramList.ToArray());
            } 
        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            GridViewHelper.MoveRow(gridView1, DevMoveState.previous);
            this.SetOrder();
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            GridViewHelper.MoveRow(gridView1, DevMoveState.next);
            this.SetOrder();
        }

        private void SetOrder()
        {
            int i = 1;
            foreach(DataRow r in dtDetail.Rows)
            {
                if (r.RowState == DataRowState.Deleted) continue;

                r["iOrder"] = i;
                i++;
            }
        }
    }
}
