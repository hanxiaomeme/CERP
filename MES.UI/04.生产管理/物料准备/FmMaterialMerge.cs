using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace LanyunMES.UI
{
    using Common;
    using Component;
    using DevExpressUtility;
    using DAL;
    using Model;
    public partial class FmMaterialMerge : DevComponents.DotNetBar.OfficeForm
    {
        public FmMaterialMerge()
        {
            InitializeComponent();
            this.Load += FormLoad; 
        }

        public FmMaterialMerge(DataRow[] rows): this()
        {
            this.opState = OpState.Add;
            model = new MergeCard();
            model.MCCode = "自动生成";
            model.dtDetails = dal.GetDTable("");
            model.cInvCode = rows[0]["cInvCode"].ToString();
            model.cInvName = rows[0]["cInvName"].ToString();
            model.cInvStd = rows[0]["cInvStd"].ToString();
            model.dDate = DateTime.Now.Date;
            model.cMaker = Information.UserInfo.cUser_Name;

            decimal iqty = 0;
            foreach(DataRow row in rows)
            {
                var r = model.dtDetails.NewRow();
                r["cardNo"] = row["cardNo"];
                r["cardChildId"] = row["AutoId"];
                //r["opSeq"] = row["OpSeq"];
                r["OpName"] = row["OpName"];
                r["cInvCode"] = row["cInvCode"];
                r["cInvName"] = row["cInvName"];
                r["cInvStd"] = row["cInvStd"];
                r["MergeQuantity"] = row["iQuantity"];
                r["cComUnitName"] = row["cComUnitName"];
                iqty += Convert.ToDecimal(row["iQuantity"]);
                model.dtDetails.Rows.Add(r);
            }

            model.iQuantity = iqty;
        }

        public FmMaterialMerge(string guid): this()
        {
            this.opState = OpState.Browse;
            model = dal.Get(guid);
        }

        private OpState opState = OpState.Browse;
        private MergeCard model;
        private MergeCardDAL dal = new MergeCardDAL();

        private void InitGrid()
        {
            GridViewHelper.AddColumn(GridCard, "cardNo", "流转卡号", 100, readOnly: true);
            //GridViewHelper.AddColumn(GridCard, "opSeq", "工序序号", 70);
            GridViewHelper.AddColumn(GridCard, "OpName", "工序名称", 80, readOnly: true);
            GridViewHelper.AddColumn(GridCard, "cInvCode", "存货编码", 120, readOnly: true);
            GridViewHelper.AddColumn(GridCard, "cInvName", "存货名称", 100, readOnly: true);
            GridViewHelper.AddColumn(GridCard, "cInvStd", "规格型号", 100, readOnly: true);

            var col = GridViewHelper.AddColumn(GridCard, "MergeQuantity", "数量", 70);
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n2}";

            GridViewHelper.AddColumn(GridCard, "cComUnitName", "单位", 50, readOnly: true);
        }

        private void FormLoad(object sender, EventArgs e)
        {
            this.InitGrid();           
            this.SetUIStatus(opState);
        }

        private void SetUIStatus(OpState op)
        {
            if (model != null) UIBinding<MergeCard>.UIDataBinding(pnlMain, model);
            UIControl.SetStatus(this, op);
            gridControl1.DataSource = model.dtDetails;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string guid = "";
            if(opState == OpState.Add)
            {
                guid = dal.Add(model);
            }
            else if(opState == OpState.Update)
            {
                guid = model.Guid; 
            }

            this.opState = OpState.Browse;
            this.model = dal.Get(guid);

            SetUIStatus(opState);
        }

        private void BtnAudit_Click(object sender, EventArgs e)
        {

        }
    }
}