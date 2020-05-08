using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LanyunMES.UI
{
    using Model;
    using Server.Model;
    using Common;
    using DAL;
    using DevComponents.DotNetBar;
    using Component;
    using System.Diagnostics;
    using System.IO;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpressUtility;

    public partial class MCardControlMerge : UserControl
    {
        public MCardControlMerge(int EQId, int OperationId)
        {
            InitializeComponent();

            this.EQID = EQId;
            this.OperationID = OperationId;
        }


        /// <summary>
        /// 流转卡DAL
        /// </summary>
        private MCardDAL dal = new MCardDAL();

        /// <summary>
        /// 设备ID
        /// </summary>
        public int EQID { get; private set; }

        /// <summary>
        /// 当前工序ID
        /// </summary>
        public int OperationID { get; private set; }


        private void InitGrid(GridView Grid)
        {
            Grid.OptionsBehavior.AutoPopulateColumns = false;

            GridViewHelper.AddColumn(Grid, "MoCode", "生产订单号", 100);
            GridViewHelper.AddColumn(Grid, "SortSeq", "行号", 50);
            GridViewHelper.AddColumn(Grid, "CardNo", "流转卡号", 90);
            GridViewHelper.AddColumn(Grid, "WOCode", "指令单号", 90);
            GridViewHelper.AddColumn(Grid, "OpSeq", "工序行号", 70);
            GridViewHelper.AddColumn(Grid, "OpName", "工序名称", 90);
            GridViewHelper.AddColumn(Grid, "cEQName", "设备名称", 80);
            GridViewHelper.AddColumn(Grid, "cInvCode", "存货编码", 90);
            GridViewHelper.AddColumn(Grid, "cInvName", "存货名称", 90);
            GridViewHelper.AddColumn(Grid, "cInvStd", "规格型号", 90);
            GridViewHelper.AddColumn(Grid, "cMemo", "备注", 100);

            var col = GridViewHelper.AddColumn(Grid, "iQuantity", "流转卡数量", 80);
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n2}";
            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            col.Summary[0].DisplayFormat = "{0:n2}";


            GridViewHelper.AddColumn(Grid, "cComUnitName", "单位", 40);


            col = GridViewHelper.AddColumn(Grid, "hgQty", "合格数量", 80);
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n2}";
            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            col.Summary[0].DisplayFormat = "{0:n2}";

            col = GridViewHelper.AddColumn(Grid, "bhgQty", "不合格数量", 80);
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n2}";
            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            col.Summary[0].DisplayFormat = "{0:n2}";
        }


        //加载流转卡数据
        private void LoadCardData(string cardNo)
        {
            //if (!dal.Exists(cardNo))
            //{
            //    throw new Exception("找不到流转卡: " + cardNo);
            //}

            //card = dal.Get(cardNo);

            //if (card == null)
            //{
            //    MsgBox.ShowInfoMsg("找不到流转卡: " + cardNo);
            //    return;
            //}

            //if (card.M.curOperation == null)
            //{
            //    MsgBox.ShowInfoMsg("当前工序为空!");
            //    return;
            //}

            ////istatus = 1 物料需求标识
            //if (card.M.curOperation.iStatus == 0)
            //{
            //    dal.SetOperationStatus(1, card.M.curOperation.AutoId);
            //    card.M.curOperation.iStatus = 1;
            //}

            //UIBinding<CardMain>.UIDataBinding(pnl_Main, card.M);

            //UIBinding<CardDetail>.UIDataBinding(lbl_dStartDate, "dStartDate", card.M.curOperation);
            //list_children.Items.Clear();

            //foreach (CardChildren c in card.ZJList)
            //{
            //    ListViewItem item = new ListViewItem(c.OpName.ToString());
            //    item.SubItems.Add(c.cInvCode);
            //    item.SubItems.Add(c.cInvName);
            //    item.SubItems.Add(c.cInvStd);
            //    item.SubItems.Add(c.iQuantity.ToString());
            //    item.SubItems.Add(c.rQuantity.ToString());
            //    item.Tag = c;
            //    list_children.Items.Add(item);
            //}

            //switch (card.M.curOperation.iStatus)
            //{
            //    case 1:
            //        lbl_Status.Text = "材料准备";
            //        break;
            //    case 2:
            //        lbl_Status.Text = "材料确认";
            //        break;
            //    case 3:
            //        lbl_Status.Text = "已开工";
            //        break;
            //    case 4:
            //        lbl_Status.Text = "已报检";
            //        break;
            //    case 5:
            //        lbl_Status.Text = "已检验";
            //        break;
            //    case 6:
            //        lbl_Status.Text = "已完工";
            //        break;
            //}

            //this.SetBtnGo(BtnGo);
            ////this.SetBtnBack(btnBack);
            //this.btnBack.Visible = card.M.curOperation.iStatus > 1;

            //lbl_bQuality.Text = card.M.curOperation.bQuality ? "是" : "否";
            //lbl_bChild.Text = card.M.bChild ? "是" : "否";
            //lbl_QmR.Text = new QmCardOPDAL().HaveQmReport(card.M.curOperation) ? "已报检" : "未报检";

        }

        private void BtnMaterialOK_Click(object sender, EventArgs e)
        {
            #region 材料确认

            //if (card.M.curOperation.iStatus == 1)
            //{
            //    dal.SetOperationStatus(2, card.M.curOperation.AutoId);
            //}
            //else if (card.M.curOperation.iStatus == 2)
            //{
            //    dal.SetOperationStatus(1, card.M.curOperation.AutoId);
            //}

            //LoadCardData(card.M.CardNo);

            #endregion
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            #region 开工
            //if (card.M.curOperation.iStatus == 3)
            //{
            //    throw new Exception("当前工序已经开工!");
            //}
            //else if (card.M.curOperation.iStatus != 2)
            //{
            //    throw new Exception("当前工序材料尚未确认!");
            //}

            //dal.SetOperationStatus(3, card.M.curOperation.AutoId);
            //dal.SetOperationEq(eqid, card.M.curOperation.AutoId);
            //LoadCardData(card.M.CardNo);

            //decimal iQuantity = Convert.ToDecimal(card.M.iQuantity);
            //decimal cycleTime = Convert.ToDecimal(card.M.curOperation.CycleTime);

            //if (cycleTime == 0)
            //{
            //    throw new Exception("当前工序设备没有对应设置节拍, 无法计算预计完工时间!");
            //}

            //var min = Convert.ToDouble(Math.Ceiling(iQuantity / cycleTime));

            //var plantime = Convert.ToDateTime(card.M.curOperation.dStartDate).AddMinutes(min);

            //timer1.Interval = Convert.ToInt32(min * 60 * 1000);
            //timer1.Start();
            #endregion
        }


        private void BtnReport_Click(object sender, EventArgs e)
        {
            //if (card.M.curOperation.iStatus != 3)
            //{
            //    throw new Exception("当前工序尚未开工!");
            //}
            //else if (card.M.curOperation.bQuality)
            //{
            //    if (!new QmCardOPDAL().HaveQmReport(card.M.curOperation))
            //    {
            //        throw new Exception("当前工序尚未报检!");
            //    }
            //}
        }

        private void BtnQmOP_Click(object sender, EventArgs e)
        {
 
        }


        private void SetBtnGo(ButtonX btn)
        {
            //int iStatus = card.M.curOperation.iStatus;

            //BtnEventClear(BtnGo);

            //if (iStatus == 1)
            //{
            //    btn.Text = "材料确认";
            //    btn.Click += BtnMaterialOK_Click;
            //}
            //else if (iStatus == 2)
            //{
            //    btn.Text = "开工";
            //    btn.Click += BtnStart_Click;
            //}
            //else if (card.M.curOperation.bQuality)
            //{
            //    if (iStatus == 3)
            //    {
            //        btn.Text = "报检";
            //        btn.Click += BtnQmOP_Click;
            //    }
            //    else if (iStatus == 4)
            //    {
            //        btn.Text = "检验";
            //        btn.Click += BtnReport_Click;
            //    }
            //}
            //else if (iStatus == 3 || iStatus == 5)
            //{
            //    btn.Text = "报工";
            //    btn.Click += BtnReport_Click;
            //}
            //else if (iStatus == 6)
            //{
            //    btn.Text = "已完工";
            //}

            //BtnGo.Enabled = !(iStatus == 6);

        }



        private void BtnEventClear(ButtonX btn)
        {
            btn.Click -= BtnMaterialOK_Click;
            btn.Click -= BtnStart_Click;
            btn.Click -= BtnQmOP_Click;
            btn.Click -= BtnReport_Click;
            btn.Click -= BtnReport_Click;
        }

        //撤销
        private void btnBack_Click(object sender, EventArgs e)
        {
            
        }

        //取消物料准备(撤销需求推送)
        private void BtnCancel_Click(object sender, EventArgs e)
        {
           
        }

    }
        
}
