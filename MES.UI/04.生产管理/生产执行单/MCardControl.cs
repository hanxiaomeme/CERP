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

    public partial class MCardControl : UserControl
    {
        public MCardControl(string cardNo, int EQId)
        {
            InitializeComponent();
            this.LoadCardData(cardNo);
            this.Name = cardNo;
            this.Text = cardNo;

            this.eqid = EQId;
        }

        private Card card;
        /// <summary>
        /// 流转卡DAL
        /// </summary>
        private MCardDAL dal = new MCardDAL();
        private decimal seconds = 300;
        private int eqid;

        private string basePath, curPath;

        public SetTimeDelegate Settime { get; set; }
        public CloseTab CloseParentTab { get; set; }

        public delegate void SetTimeDelegate(decimal seconds);

        //加载流转卡数据
        private void LoadCardData(string cardNo)
        {
            if(!dal.Exists(cardNo))
            {
                throw new Exception("找不到流转卡: " + cardNo);
            }

            card = dal.Get(cardNo);

            if(card == null)
            {
                MsgBox.ShowInfoMsg("找不到流转卡: " + cardNo);
                return;
            }

            if(card.M.curOperation == null)
            {
                MsgBox.ShowInfoMsg("当前工序为空!");
                return;
            }

            //istatus = 1 物料需求标识
            if (card.M.curOperation.iStatus == 0)
            {
                dal.SetOperationStatus(1, card.M.curOperation.AutoId);
                card.M.curOperation.iStatus = 1;
            }

            UIBinding<CardMain>.UIDataBinding(pnl_Main, card.M);

            UIBinding<CardDetail>.UIDataBinding(lbl_dStartDate, "dStartDate", card.M.curOperation);
            list_children.Items.Clear();

            foreach(CardChildren c in card.ZJList)
            {
                ListViewItem item = new ListViewItem(c.OpName.ToString());
                item.SubItems.Add(c.cInvCode);
                item.SubItems.Add(c.cInvName);
                item.SubItems.Add(c.cInvStd);
                item.SubItems.Add(c.iQuantity.ToString());
                item.SubItems.Add(c.rQuantity.ToString());
                item.Tag = c;
                list_children.Items.Add(item);
            }

            switch (card.M.curOperation.iStatus)
            {
                case 1:
                    lbl_Status.Text = "材料准备";
                    break;
                case 2:
                    lbl_Status.Text = "材料确认";
                    break;
                case 3:
                    lbl_Status.Text = "已开工";
                    break;
                case 4:
                    lbl_Status.Text = "已报检";
                    break;
                case 5:
                    lbl_Status.Text = "已检验";
                    break;
                case 6:
                    lbl_Status.Text = "已完工";
                    break;
            }

            this.SetBtnGo(BtnGo);
            //this.SetBtnBack(btnBack);
            this.btnBack.Visible = card.M.curOperation.iStatus > 1;

            lbl_bQuality.Text = card.M.curOperation.bQuality ? "是" : "否";
            lbl_bChild.Text = card.M.bChild ? "是" : "否";
            lbl_QmR.Text = new QmCardOPDAL().HaveQmReport(card.M.curOperation) ? "已报检" : "未报检";

            #region 加载共享文件列表

            FileExpControl ctrl = new FileExpControl(cardNo);
            ctrl.Parent = groupPanel2;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Show();

            #endregion
        }

        private void BtnMaterialOK_Click(object sender, EventArgs e)
        {
            #region 材料确认

            if(card.M.curOperation.iStatus == 1)
            {
                dal.SetOperationStatus(2, card.M.curOperation.AutoId);
            }
            else if(card.M.curOperation.iStatus == 2)
            {
                dal.SetOperationStatus(1, card.M.curOperation.AutoId);
            }
            
            LoadCardData(card.M.CardNo);

            #endregion
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            #region 开工
            if(card.M.curOperation.iStatus == 3)
            {
                throw new Exception("当前工序已经开工!");
            }
            else if(card.M.curOperation.iStatus != 2)
            {
                throw new Exception("当前工序材料尚未确认!");
            }

            dal.SetOperationStatus(3, card.M.curOperation.AutoId);
            dal.SetOperationEq(eqid, card.M.curOperation.AutoId);
            LoadCardData(card.M.CardNo);

            decimal iQuantity = Convert.ToDecimal( card.M.iQuantity);
            decimal cycleTime = Convert.ToDecimal(card.M.curOperation.CycleTime);

            if(cycleTime == 0)
            {
                throw new Exception("当前工序设备没有对应设置节拍, 无法计算预计完工时间!");
            }

            var min = Convert.ToDouble( Math.Ceiling(iQuantity / cycleTime));

            var plantime = Convert.ToDateTime(card.M.curOperation.dStartDate).AddMinutes(min);

            timer1.Interval = Convert.ToInt32(min * 60 * 1000);
            timer1.Start(); 
            #endregion
        }

        public void StartTimer(object sender, EventArgs e)
        {
            seconds--;

            if (Settime != null)
            {
                Settime(seconds);
            }
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            if(card.M.curOperation.iStatus != 3)
            {
                throw new Exception("当前工序尚未开工!");
            }
            else if(card.M.curOperation.bQuality)
            {
                if(!new QmCardOPDAL().HaveQmReport(card.M.curOperation))
                {
                    throw new Exception("当前工序尚未报检!");
                }
            }
            FmMOReport frm = new FmMOReport(card.M.CardNo);
            if(frm.ShowDialog() == DialogResult.OK)
            {
                CloseParentTab(this.Name);
            }
        }

        private void BtnQmOP_Click(object sender, EventArgs e)
        {
            if (card.M.curOperation.iStatus != 3)
            {
                throw new Exception("当前工序尚未开工!");
            }

            FmOpQMReport frm = new FmOpQMReport(card.M.CardNo);
            frm.ShowDialog();
        }

        
        private void SetBtnGo(ButtonX btn)
        {
            int iStatus = card.M.curOperation.iStatus;

            BtnEventClear(BtnGo);

            if (iStatus == 1)
            {
                btn.Text = "材料确认";
                btn.Click += BtnMaterialOK_Click;
            }
            else if(iStatus == 2)
            {
                btn.Text = "开工";
                btn.Click += BtnStart_Click;
            }
            else if(card.M.curOperation.bQuality)
            {
                if(iStatus == 3)
                {
                    btn.Text = "报检";
                    btn.Click += BtnQmOP_Click;
                }
                else if(iStatus == 4)
                {
                    btn.Text = "检验";
                    btn.Click += BtnReport_Click;
                }
            }
            else if(iStatus == 3 || iStatus == 5)
            {
                btn.Text = "报工";
                btn.Click += BtnReport_Click;
            }
            else if(iStatus == 6)
            {
                btn.Text = "已完工";
            }

            BtnGo.Enabled = !(iStatus == 6);

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
            int iStatus = card.M.curOperation.iStatus;
 
            int autoId = card.M.curOperation.AutoId;

            if (iStatus == 2)   //材料确认
            {
               dal.SetOperationStatus(1, autoId);                
            }
            else if (iStatus == 3)  //已开工
            {
               dal.SetOperationStatus(2, autoId);
            }
            #region 弃用 -- 撤销检验,报检
            //else if (card.M.curOperation.bQuality && iStatus == 4)  //已报检
            //{
            //    btn.Text = "撤销报检";
            //    btn.Click += new EventHandler(new Action<object, EventArgs>((o, e) => {
            //        var cardNo = card.M.CardNo;
            //        var opSeq = card.M.curOperation.OpSeq;
            //        new QmCardOPDAL().Del(cardNo, opSeq);

            //        dal.SetOperationStatus(3, autoId);
            //    }));
            //}       
            //else if (iStatus == 5)  //已检验
            //{
            //    btn.Text = "撤销检验单";
            //    btn.Click += new EventHandler(new Action<object, EventArgs>((o,e)=> {
            //    }));
            //} 
            #endregion

            else if (iStatus == 6)   //已完工
            {
                var autoid = card.M.curOperation.AutoId;
                int ist = card.M.curOperation.bQuality ? 5 : 3;

                dal.SetOperationStatus(ist, autoid);
                dal.CancelOPRep(autoid);
            }

            this.LoadCardData(card.M.CardNo);
        }

        //取消物料准备(撤销需求推送)
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            var reqDal = new MaterialRequestDAL();
            var routerId = card.M.curOperation.RouterId;

            if (reqDal.IsMerge(routerId))
            {
                var ls = reqDal.GetList(routerId);

                if (ls.Find(x => x.bMP == true) != null)
                {
                    throw new Exception("当前流转卡材料以及生成拣货单，无法删除！");
                }

                if (MsgBox.ShowYesNoMsg("当前流转卡材料合并，撤销将和合并卡一同撤销，是否继续？") == DialogResult.Yes)
                {
                    //ls.ForEach(x =>
                    //{
                    //    reqDal.Delete(x.Guid);
                    //    //关闭标签
                    //    x.Children.ForEach(y =>
                    //    {
                    //        FmMOExcute.CloseCtrlTab(y.CardNo);
                    //    });
                    //});
                }
            }
            else
            {
                //var ls = reqDal.GetList(routerId, false);

                //if (ls.Find(x => x.bMP == true) != null)
                //{
                //    throw new Exception("当前流转卡材料以及生成拣货单，无法删除！");
                //}

                //ls.ForEach(x => {
                //    reqDal.Delete(x.Guid);
                //    FmMOExcute.CloseCtrlTab(x.CardNo);
                //});
                 
            }      
        }

 
    }


    public delegate void CloseTab(string tabName);
}
