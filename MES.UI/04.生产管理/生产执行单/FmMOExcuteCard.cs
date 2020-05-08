using System;
using System.Collections.Generic;
using System.Linq;
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
    using Model;
    using Server.Model;
    using DAL;
    using DevExpressUtility;
    using DevExpress.XtraGrid.Views.Grid;

    public partial class FmMOExcuteCard : DevComponents.DotNetBar.OfficeForm
    {
        public FmMOExcuteCard(int EQId, int OperationId)
        {
            InitializeComponent();
            this.Load += FormLoad;
            this.eqId = EQId;
            this.operationId = OperationId;
        }

        // 当前机台ID
        private int eqId;
        // 当前工序ID
        private int operationId;
    

        MCardDAL dal = new MCardDAL();


        public List<string> cardList { get; private set; } = new List<string>();

        /// <summary>
        /// 所选流转卡集合
        /// </summary>
        public List<Card> listCard { get; private set; } = new List<Card>();

        /// <summary>
        /// 所选流转卡材料集合
        /// </summary>
        public List<MaterialRequest> listMReq { get; private set; } = new List<MaterialRequest>();

        /// <summary>
        /// 流转卡材料汇总集合
        /// </summary>
        public List<MaterialRequestSum> listMReqSum { get; private set; } = new List<MaterialRequestSum>();
 

        private void FormLoad(object obj, EventArgs e)
        {
            this.InitGridCard(gridCard);
            this.InitGrid(gridView1);
            this.InitGridSummary(gridSummary);
        }

        private void InitGridCard(GridView grid)
        {
            grid.KeyDown += GridViewHelper.KeyDownCellCopy;
            grid.OptionsBehavior.AutoPopulateColumns = false;

            var col = GridViewHelper.AddColumn(grid, "CardNo", "流转卡号", 100, readOnly: true);
            col.Summary.Add(DevExpress.Data.SummaryItemType.Count);
            col.Summary[0].FieldName = "cInvCode";
            col.Summary[0].DisplayFormat = "卡数:{0}";

            GridViewHelper.AddColumn(grid, "MoCode", "生产订单号", 90, readOnly: true);
            GridViewHelper.AddColumn(grid, "cInvCode", "存货编码", 120, readOnly: true);
            GridViewHelper.AddColumn(grid, "cInvName", "存货名称", 120, readOnly: true);
            GridViewHelper.AddColumn(grid, "cInvStd", "规格型号", 90, readOnly: true);
            GridViewHelper.AddColumn(grid, "curOpSeq", "工序序号", 60, readOnly: true);
            GridViewHelper.AddColumn(grid, "curOpName", "工序名称", 80, readOnly: true);

            col =  GridViewHelper.AddColumn(grid, "iQuantity", "生产数量", 70);
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n3}";
            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            col.Summary[0].FieldName = "iQuantity";
            col.Summary[0].DisplayFormat = "{0:n3}";

            GridViewHelper.AddColumn(grid, "cMemo", "备注", 100, readOnly: true);
        }

        private void InitGrid(GridView grid)
        {
            grid.KeyDown += GridViewHelper.KeyDownCellCopy;
            grid.OptionsBehavior.AutoPopulateColumns = false;

            //GridViewHelper.AddColumn(grid, "MergeGuid", "MergeGuid", 120, readOnly: true);
            var col = GridViewHelper.AddColumn(grid, "cInvCode", "材料编码", 120, readOnly:true);
            col.Summary.Add(DevExpress.Data.SummaryItemType.Count);
            col.Summary[0].FieldName = "cInvCode";
            col.Summary[0].DisplayFormat = "记录数:{0}";

            GridViewHelper.AddColumn(grid, "cInvName", "材料名称", 100, readOnly: true);
            GridViewHelper.AddColumn(grid, "cInvStd", "规格型号", 100, readOnly: true);
            GridViewHelper.AddColumn(grid, "OpName", "工序名称", 80, readOnly: true);

            col = GridViewHelper.AddColumn(grid, "iQuantity", "合计数量", 80, readOnly:true);
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n3}";
            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            col.Summary[0].FieldName = "iQuantity";
            col.Summary[0].DisplayFormat = "{0:n3}";

            GridViewHelper.AddColumn(grid, "cComUnitName", "单位", 40, readOnly: true);
        }

        private void InitGridSummary(GridView grid)
        {
            grid.KeyDown += GridViewHelper.KeyDownCellCopy;
            grid.OptionsBehavior.AutoPopulateColumns = false;

            var col = GridViewHelper.AddColumn(grid, "cInvCode", "材料编码", 120, readOnly: true);
            col.Summary.Add(DevExpress.Data.SummaryItemType.Count);
            col.Summary[0].FieldName = "cInvCode";
            col.Summary[0].DisplayFormat = "记录数:{0}";

            GridViewHelper.AddColumn(grid, "cInvName", "材料名称", 100, readOnly: true);
            GridViewHelper.AddColumn(grid, "cInvStd", "规格型号", 100, readOnly: true);
            GridViewHelper.AddColumn(grid, "OpName", "工序名称", 80, readOnly: true);

            col = GridViewHelper.AddColumn(grid, "iQuantitySum", "汇总数量", 80, readOnly: true);
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n3}";
            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            col.Summary[0].FieldName = "iQuantitySum";
            col.Summary[0].DisplayFormat = "{0:n3}";

            col = GridViewHelper.AddColumn(grid, "iQuantityMerge", "合并数量", 80);
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n3}";
            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            col.Summary[0].FieldName = "iQuantityMerge";
            col.Summary[0].DisplayFormat = "{0:n3}";

            GridViewHelper.AddColumn(grid, "cComUnitName", "单位", 40, readOnly: true);
        }


        /// <summary>
        /// 添加流转卡
        /// </summary>
        private void txt_CardNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                var cardNo = (sender as TextBox).Text.Trim();

                if (string.IsNullOrEmpty(cardNo))
                {
                    throw new Exception("流转卡号不能为空!");
                }
                else if (!dal.Exists(cardNo))
                {
                    throw new Exception("流转卡号[" + cardNo + "] 不存在!");
                }
                else if (listCard.Find(x => x.M.CardNo == cardNo ) != null)
                {
                    throw new Exception("卡号已经添加!");
                }

                var card = dal.Get(cardNo);

                if (card.M.bClosed)
                {
                    throw new Exception("当前流转卡已经关闭!");
                }
                else if(card.M.bPause)
                {
                    throw new Exception("当前流转卡暂停,不能继续!");
                }
                else if(card.M.curOperationId != operationId)
                {
                    throw new Exception("流转卡:[" + card.M.CardNo + "] 当前工序与所选工序不匹配!");
                }
                else if (card.M.curOperation.EQId != 0 && card.M.curOperation.EQId != eqId)
                {
                    if(MsgBox.ShowYesNoMsg("流转卡:[" + card.M.CardNo + "] 当前设定设备与所选设备不匹配,是否选择!") != DialogResult.Yes)
                    {
                        return;
                    }
                }

                //流转卡
                listCard.Insert(0, card);

                //iStatus = 0 : 未推送需求
                if (!new MaterialRequestDAL().ExistCard(cardNo, card.M.curOperation.RouterId))
                {
                    //过滤当前工序材料
                    var materials = card.ZJList.Where(x => x.RouterId == card.M.curOperation.RouterId).ToList();

                    materials.ForEach(m =>
                    {
                        listMReq.Add(new MaterialRequest
                        {
                            bMerge = false,
                            CardChildId = m.AutoID,
                            CardNo = m.CardNo,
                            cComUnitName = m.cComUnitName,
                            cInvCode = m.cInvCode,
                            cInvName = m.cInvName,
                            cInvStd = m.cInvStd,
                            iQuantity = m.iQuantity,
                            iReqQuantity = m.iQuantity,
                            operationId = m.OperationId,
                            OpName = m.OpName
                        });
                    });
                }


                var listCardM = listCard.Select((x, y) =>
                {
                    return x.M;
                }).ToList();

                BindingList<CardMain> blist = new BindingList<CardMain>(listCardM);
                this.gridControl2.DataSource = blist;

                //材料汇总
                this.cb_bSum_Click(null, null);

                this.txt_CardNo.Clear();
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if(listCard.Count < 1)
            {
                throw new Exception("流转卡记录不能为空!");
            }

            listCard.ForEach(x =>
            {
                this.cardList.Add(x.M.CardNo);
            });

            //绑定机台
            dal.SetOperationEq(listCard, eqId);

            var mrdal = new MaterialRequestDAL();

            //保存合并单
            if (cb_bSum.Checked)
            {
                mrdal.AddSum(listMReq, listMReqSum);
            }
            else
            {
                mrdal.Add(listMReq);
            }


            this.DialogResult = DialogResult.OK;
        }

        private class GroupItem
        {
            public string cInvCode { get; set; }
            public string cInvName { get; set; }
            public string cInvStd { get; set; }
            public string cComUnitName { get; set; }
            public int OperationId { get; set; }
            public string OpName { get; set; }
            public decimal iQuantity { get; set; }
        }

        private void cb_bSum_Click(object sender, EventArgs e)
        {
            #region 是否合并需求

            if (cb_bSum.Checked)
            {
                if (this.listCard.Count <= 1)
                {
                    cb_bSum.Checked = false;
                    throw new Exception("单个流转卡,不需要合并!");
                }

               this.listMReqSum = listMReq.GroupBy(x => new
                {
                    x.cInvCode,
                    x.cInvName,
                    x.cInvStd,
                    x.operationId,
                    x.OpName,
                    x.cComUnitName
                }).Select(y =>
                {
                    var sum = new MaterialRequestSum
                    {
                        Guid = Guid.NewGuid().ToString(),
                        cInvCode = y.Key.cInvCode,
                        cInvName = y.Key.cInvName,
                        cInvStd = y.Key.cInvStd,
                        OperationId = y.Key.operationId,
                        OpName = y.Key.OpName,
                        cComUnitName = y.Key.cComUnitName,
                        iQuantitySum = y.Sum(s => s.iQuantity),
                        iQuantityMerge = y.Sum(s => s.iQuantity)
                    };

                    y.ToList().ForEach(d =>
                    {
                        d.MergeGuid = sum.Guid;
                        d.bMerge = true;
                    });

                    return sum;
                }).ToList();

                this.gridControl3.DataSource = listMReqSum;
            }
            else
            {
                listMReq.ForEach(x =>
                {
                    x.bMerge = false;
                    x.MergeGuid = null;
                    x.iQuantity = Convert.ToDecimal(x.iReqQuantity);
                });

                this.gridControl3.DataSource = null;
            }

            this.gridControl1.DataSource = listMReq;
            this.gridControl1.RefreshDataSource();
            #endregion
        }

        private void BtnDelLine_Click(object sender, EventArgs e)
        {
            var cardM = gridCard.GetFocusedRow() as CardMain;

            gridCard.DeleteRow(gridCard.FocusedRowHandle);

            listCard.RemoveAll(x => x.M.CardNo == cardM.CardNo);
            listMReq.RemoveAll(x => x.CardNo == cardM.CardNo);

            this.cb_bSum_Click(null, null);
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            if(listCard.Count < 1)
            {
                throw new Exception("没有记录, 请先扫描流转卡!");
            }

            List<string> cards = new List<string>();
            listCard.ForEach(x =>
            {
                cards.Add(x.M.CardNo);
            });

            var dt = new MCardDAL().GetExportTable(cards.ToArray());
            
            using (var sfd = new SaveFileDialog())
            {
                sfd.DefaultExt = "xlsx";
                sfd.Filter = "* Excel文件|*.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    NPOIHelper.TableToExcel(dt, sfd.FileName);
                    MsgBox.ShowInfoMsg("导出成功!");
                }
            }
               
            
        }

        private void gridSummary_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var curMRSum = gridSummary.GetFocusedRow() as MaterialRequestSum;

            if (e.Column.Name == "iQuantityMerge" &&  curMRSum.iQuantityMerge > 0)
            {
                curMRSum.iRate = curMRSum.iQuantityMerge / curMRSum.iQuantitySum;

                listMReq.ForEach(x =>
                {
                    if(x.MergeGuid == curMRSum.Guid && curMRSum.iRate > 0)
                    {
                        x.iQuantity = Math.Round(Convert.ToDecimal(x.iReqQuantity) * curMRSum.iRate, 4);
                    }
                });
            }

            this.gridControl1.DataSource = listMReq;
            this.gridControl1.RefreshDataSource();
        }
    }
}