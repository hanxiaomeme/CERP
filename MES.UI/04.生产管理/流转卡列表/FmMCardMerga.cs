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
    using DevExpressUtility;
    using U8Ext.Ref;
    using Component;
    using DAL;

    public partial class FmMCardMerga : DevComponents.DotNetBar.OfficeForm
    {
        public FmMCardMerga(OpState opState = OpState.Add)
        {
            InitializeComponent();
            this.Text = pnlMain.Text;

            this.Load += FmLoad;
            this.BtnAdd.Click += Add;
            this.BtnEdit.Click += Edit;
            this.BtnCancel.Click += Cancel;
            this.BtnSave.Click += Save;
            this.BtnDel.Click += Delete;
            this.BtnAudit.Click += Audit;
            this.BtnUnAudit.Click += UnAudit;

            this.opState = opState;
        }

        public FmMCardMerga(string guid) : this(OpState.Browse)
        {
            this.model = dal.Get(guid);
        }


        private OpState opState;

        private string guid;

        private MergeCard model = null;

        private MergeCardDAL dal = new MergeCardDAL();



        //===========================================================

        private void InitGridView()
        {
            gridView1.OptionsBehavior.AutoPopulateColumns = false;

            var column = GridViewHelper.AddColumn(this.gridView1, "CardNo", "流转卡号");
            column.Summary.Add(DevExpress.Data.SummaryItemType.Count);
            column.Summary[0].FieldName = "CardNo";
            column.Summary[0].DisplayFormat = "{卡数:0}";

            GridViewHelper.AddColumn(this.gridView1, "cInvCode", "存货编码", 120);
            GridViewHelper.AddColumn(this.gridView1, "cInvName", "存货名称",100);
            GridViewHelper.AddColumn(this.gridView1, "cInvStd", "规格型号", 100);
            GridViewHelper.AddColumn(this.gridView1, "OpName", "工序名称");
            GridViewHelper.AddColumn(this.gridView1, "iQuantity", "数量", 70);
            GridViewHelper.AddColumn(this.gridView1, "cComUnitName", "单位", 50);
            GridViewHelper.AddColumn(this.gridView1, "remark", "备注", 100);
        }

        private void FmLoad(object sender, EventArgs e)
        {           
            this.InitGridView();
            
            if (opState == OpState.Add)
            {
                model = new MergeCard();
                model.MCCode = "自动生成";
                model.dDate = DateTime.Now.Date;
            }

            this.RefreshUI(); 
        }

        private void RefreshUI()
        {
            //if (opState == OpState.Browse || opState == OpState.Audit)
            //{
            //    if (model.iState == 0)
            //    {
            //        this.opState = OpState.Browse;
            //    }
            //    else if (model.iState == 1)
            //    {
            //        this.opState = OpState.Audit;
            //    }
            //}

            UIControl.SetStatus(this, this.opState);

            Common.UIBinding<MergeCard>.UIDataBinding(pnlMain, model);

            gridControl1.DataSource = model.dtDetails;
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
            opState = OpState.Add;
            model = new MergeCard();
            model.dDate = DateTime.Now.Date;
            
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
                model = new MergeCard();
            }
            this.RefreshUI();
        }

        //删除
        private void Delete(object sender, EventArgs e)
        {
            this.dal.Delete(guid);
            this.model = new MergeCard();
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

            this.model = dal.Get(guid);
            this.opState = OpState.Browse;
            this.RefreshUI();
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
            if(model.dtDetails == null || model.dtDetails.Rows.Count < 1 )
            {
                throw new Exception("表体不能为空!");
            }

            int operationId = Convert.ToInt32(model.dtDetails.Rows[0]["operationId"]);

            foreach (DataRow row in model.dtDetails.Rows)
            {
                if (row.RowState == DataRowState.Deleted) continue;

                if (operationId != Convert.ToInt32(row["operationId"]))
                {
                    throw new Exception("表体流转卡当前工序不一致,不能合并!");
                }
            }
        }


        private void Btn_Addline_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Delline_Click(object sender, EventArgs e)
        {
            int handle = this.gridView1.FocusedRowHandle;
            this.gridView1.DeleteRow(handle);
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
