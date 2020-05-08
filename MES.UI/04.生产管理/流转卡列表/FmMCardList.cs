using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LanyunMES.UI
{
    using Model;
    using Server.Model;
    using Component;
    using DAL;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpressUtility;
    using System.ComponentModel;

    public partial class FmMCardList : DevComponents.DotNetBar.OfficeForm
    {
        public FmMCardList(string woGuid = null)
        {
            InitializeComponent();

            //导出Excel
            this.GirdCard.KeyDown += GridViewHelper.KeyDownCellCopy;
            this.GridRouter.KeyDown += GridViewHelper.KeyDownCellCopy;
            this.GirdCard.CellMerge += GridViewHelper.gridviewCellMerge;

            this.InitGrid();
            this.InitGridDetail();
            this.InitGridrouter();

            if (!string.IsNullOrEmpty(woGuid))
            {
                _whereList.Add("woGuid = @woGuid");
                _paramList.Add(new SqlParameter("@woGuid", woGuid));
                this.ExecQuery();
            }
        }

        private DataTable cardTable;
        private MCardDAL dal = new MCardDAL();
        private List<string> _whereList = new List<string>();
        private List<SqlParameter> _paramList = new List<SqlParameter>();


        private void InitGrid()
        {
            #region 初始化列
            //this.GirdCard.OptionsView.AllowCellMerge = true;

            var col = GridViewHelper.AddColumn(this.GirdCard, "CardNo", "流转卡号", 120);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            col.Fixed = FixedStyle.Left;
            col.Summary.Add(DevExpress.Data.SummaryItemType.Count);
            col.Summary[0].FieldName = "CardNo";
            col.Summary[0].DisplayFormat = "记录:{0}";

            //GridViewHelper.AddColumn(this.GirdCard, "bChild", "子卡", 40);
            //GridViewHelper.AddColumn(this.GirdCard, "pCardNo", "母件卡号", 100);

            GridViewHelper.AddColumn(this.GirdCard, "bClosedDesc", "关闭", 60, true);

            GridViewHelper.AddColumn(this.GirdCard, "bPauseDesc", "暂停", 60, true);

            //GridViewHelper.AddColumn(this.GirdCard, "bPause", "暂停", 60, true);
            GridViewHelper.AddColumn(this.GirdCard, "WOCode", "指令单号", 120);
            GridViewHelper.AddColumn(this.GirdCard, "MoCode", "生产订单号", 100);
            GridViewHelper.AddColumn(this.GirdCard, "SortSeq", "行号", 40);
            GridViewHelper.AddColumn(this.GirdCard, "cInvCode", "存货编码", 150);
            GridViewHelper.AddColumn(this.GirdCard, "cInvName", "存货名称", 120);
            GridViewHelper.AddColumn(this.GirdCard, "cInvStd", "规格型号", 120);

            col = GridViewHelper.AddColumn(this.GirdCard, "iQuantity", "数量", 80);
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n2}";
            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            col.Summary[0].FieldName = "iQuantity";

            GridViewHelper.AddColumn(this.GirdCard, "cComUnitName", "单位", 50);
            col = GridViewHelper.AddColumn(this.GirdCard, "curOpSeq", "当前工序", 70);
            col.AppearanceCell.ForeColor = Color.Blue;

            col = GridViewHelper.AddColumn(this.GirdCard, "curOpName", "当前工序名称", 90);
            col.AppearanceCell.ForeColor = Color.Blue;

            col = GridViewHelper.AddColumn(this.GirdCard, "CompleteDesc", "状态", 70);
            col.AppearanceCell.ForeColor = Color.Blue;

            GridViewHelper.AddColumn(this.GirdCard, "dCreateDate", "制卡日期", 80);
            GridViewHelper.AddColumn(this.GirdCard, "cMaker", "制单人", 80);

            GridViewHelper.AddColumn(this.GirdCard, "cCode", "U8入库单号", 90);

            GridViewHelper.AddColumn(this.GirdCard, "bMemo", "备注", 60);

            #endregion
        }

        private void InitGridDetail()
        {
            #region 初始化列
            this.GridDetail.OptionsView.AllowCellMerge = false;

            //autoid = GridViewHelper.AddColumn(this.GridDetail, "CardNo", "流转卡号", 110);
            GridViewHelper.AddColumn(this.GridDetail, "OpName", "工序名称", 90);
            GridViewHelper.AddColumn(this.GridDetail, "cInvCode", "材料编码", 100);
            GridViewHelper.AddColumn(this.GridDetail, "cInvName", "名称", 100);
            GridViewHelper.AddColumn(this.GridDetail, "cInvStd", "规格", 100);

            var col = GridViewHelper.AddColumn(this.GridDetail, "iQuantity", "数量", 70);
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n3}";

            GridViewHelper.AddColumn(this.GridDetail, "cComUnitName", "单位", 40);


            #endregion
        }

        private void InitGridrouter()
        {
            #region 初始化列
            this.GridRouter.OptionsView.AllowCellMerge = false;

            GridViewHelper.AddColumn(this.GridRouter, "CardNo", "流转卡号", 110);

            GridViewHelper.AddColumn(this.GridRouter, "OpSeq", "行号", 40);
            GridViewHelper.AddColumn(this.GridRouter, "OpName", "工序名称", 90);


            GridViewHelper.AddColumn(this.GridRouter, "cMemo", "备注", 90);

            var col = GridViewHelper.AddColumn(this.GridRouter, "dStartDate", "开工日期", 140);
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";

            GridViewHelper.AddColumn(this.GridRouter, "hgQty", "合格数量", 70);
            GridViewHelper.AddColumn(this.GridRouter, "bhgQty", "不合格数量", 80);
            GridViewHelper.AddColumn(this.GridRouter, "cWorker", "操作工", 60);

            col = GridViewHelper.AddColumn(this.GridRouter, "dRepDate", "报工日期", 140);
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";

            col = GridViewHelper.AddColumn(this.GridRouter, "timeUsed", "工序用时", 60);
            col.FieldName = null;
            col.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            col.UnboundExpression = "[dRepDate] - [dStartDate]";

            GridViewHelper.AddColumn(this.GridRouter, "cRepPsn", "报工人", 60);

            #endregion
        }
 
        private void Btn_PrintDesgin_Click(object sender, EventArgs e)
        {
            #region 打印设计

            if(GirdCard.GetSelectedRows().Length < 1)
            {
                throw new Exception("没有选择数据!");
            }

            List<string> list = new List<string>();

            foreach (int index in GirdCard.GetSelectedRows())
            {
                list.Add(GirdCard.GetRowCellValue(index, "CardNo").ToString());
            }

            DataTable dtMain = dal.GetHead(list.ToArray());
            DataTable dtDetail = dal.GetBody(list.ToArray());

            string path = Application.StartupPath.Trim('\\');

            this.report1.Load(path + "\\ReportPrint\\产品跟踪卡.frx");
            this.report1.RegisterData(dtMain, "M");
            this.report1.RegisterData(dtDetail, "D");
            this.report1.GetDataSource("M").Enabled = true;
            this.report1.GetDataSource("D").Enabled = true;
            this.report1.Design(); 
            #endregion
        }

        private void Btn_Print_Click(object sender, EventArgs e)
        {
            #region 打印

            if (GirdCard.GetSelectedRows().Length < 1)
            {
                throw new Exception("没有选择数据!");
            }

            List<string> list = new List<string>();

            foreach (int index in GirdCard.GetSelectedRows())
            {
                list.Add(GirdCard.GetRowCellValue(index, "CardNo").ToString());
            }

            DataTable dtMain = dal.GetHead(list.ToArray());
            DataTable dtDetail = dal.GetBody(list.ToArray());

            string path = Application.StartupPath.Trim('\\');

            this.report1.Load(path + "\\ReportPrint\\产品跟踪卡.frx");
            this.report1.RegisterData(dtMain, "M");
            this.report1.RegisterData(dtDetail, "D");
            this.report1.GetDataSource("M").Enabled = true;
            this.report1.GetDataSource("D").Enabled = true;
            this.report1.Show(); 
            #endregion
        }

        private void Btn_Query_Click(object sender, EventArgs e)
        {
            #region 查询
            FmQMCardList frm = new FmQMCardList();
            frm.LoadSqlParams(this._paramList);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                this._whereList = frm.ListWhere;
                this._paramList = frm.Parameters;


                this.Invoke(new System.Action(()=> 
                {                   
                    WaitFormHelper.ShowWait(this, "请稍后.....");
                }));

                System.Action query = () => { ExecQuery(); };

                new Thread(() =>
                {                 
                    this.Invoke(query);
                }).Start();

                this.Invoke(new System.Action(WaitFormHelper.CloseWait));
            
            } 
            #endregion
        }

        private void ExecQuery()
        {
            cardTable = dal.GetHeadTable(_whereList.ToArray(), _paramList.ToArray());

            gridControl1.DataSource = cardTable;
        }


        /// <summary>
        /// 刷新
        /// </summary>
        private void BtnReflash_Click(object sender, EventArgs e)
        {
            if(_whereList.Count < 1)
            {
                MsgBox.ShowInfoMsg("没有查询条件!");
                return;
            }

            this.ExecQuery();
        }

        private void BtnDelCard_Click(object sender, EventArgs e)
        {
            #region 删除流转卡

            if (MsgBox.ShowYesNoMsg("确定删除选定的流转卡?") != DialogResult.Yes)
                return;

            StringBuilder sb = new StringBuilder();

            foreach(int handle in this.GirdCard.GetSelectedRows())
            {
                string[] wheres = new string[]
                {
                    "cardNo = @cardNo"
                };

                var card = ConvertToModel.DataRowToModel<CardMain>(GirdCard.GetDataRow(handle));

                //引用校验
                dal.ExistRef(card.CardNo);

                if (card.curOpSeq != "0010")
                {
                    sb.Append("流转卡" + card.CardNo + "已经报工,不能删除! \r\n");
                }
                else
                {
                    dal.Delete(card.CardNo);
                }
                
            }

            if(sb.ToString() == "")
            {
                sb.Append("删除成功！");
            }

            MsgBox.ShowInfoMsg(sb.ToString());

            this.BtnReflash_Click(null, null);

            #endregion
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle > -1)
            {

                CardMain cardm = ConvertToModel.DataRowToModel<CardMain>(GirdCard.GetFocusedDataRow());

                gridControl2.DataSource = dal.GetDetailList(cardm.CardNo);
                gridControl3.DataSource = dal.GetChildList(cardm.CardNo);
            }
            else
            {
                gridControl2.DataSource = null;
                gridControl3.DataSource = null;
            }

        }

        private void Btn_CreateCard_Click(object sender, EventArgs e)
        {
            if((bool)GirdCard.GetFocusedRowCellValue("bChild"))
            {
                throw new Exception("子件流转卡不能创建子卡!");
            }

            string cardNo = GirdCard.GetFocusedRowCellValue("CardNo").ToString();

            FmCreateDCard frm = new FmCreateDCard(cardNo);
            if(frm.ShowDialog() == DialogResult.OK)
            {
                this.BtnReflash_Click(null, null);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            var selectRows = this.GirdCard.GetSelectedRows();

            if(selectRows.Length < 1)
            {
                throw new Exception("当前没有选中行!");
            }

            if (MsgBox.ShowYesNoMsg("确定关闭所选流转卡?") != DialogResult.Yes) return;

            List<CardMain> cards = new List<CardMain>();

            foreach (int i in this.GirdCard.GetSelectedRows())
            {
                var cardm = ConvertToModel.DataRowToModel<CardMain>(GirdCard.GetDataRow(i));
                cards.Add(cardm);
            }

            dal.SetClosedStatus(true, Information.UserInfo.cUser_Name, cards.ToArray());

            //刷新
            this.ExecQuery();
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            var selectRows = this.GirdCard.GetSelectedRows();

            if (selectRows.Length < 1)
            {
                throw new Exception("当前没有选中行!");
            }

            if (MsgBox.ShowYesNoMsg("确定打开所选流转卡?") != DialogResult.Yes) return;

            List<CardMain> cards = new List<CardMain>();

            foreach (int i in this.GirdCard.GetSelectedRows())
            {
                var cardm = ConvertToModel.DataRowToModel<CardMain>(GirdCard.GetDataRow(i));
                cards.Add(cardm);
            }

            dal.SetClosedStatus(false, null, cards.ToArray());

            //刷新
            this.ExecQuery();
        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        private void BtnExport_Click(object sender, EventArgs e)
        {
            GridViewHelper.ExportToXlsx(this.gridControl1);
        }

        private void BtnQueryFile_Click(object sender, EventArgs e)
        {
            string cardNo = this.GirdCard.GetFocusedRowCellValue("CardNo").ToString();

            if(!string.IsNullOrEmpty(cardNo))
            {
                FmFileExplorer frm = new FmFileExplorer(cardNo);
                frm.ShowDialog();
            }
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            string cardNo = this.GirdCard.GetFocusedRowCellValue("CardNo").ToString();

            FmMOCard frm = new FmMOCard(cardNo);
            frm.ShowDialog();
        }

        private void GirdCard_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if(e.DisplayText == "Y")
            {
                e.Appearance.BackColor = Color.YellowGreen;
            }
        }

        /// <summary>
        /// 暂停
        /// </summary>
        private void BtnPause_Click(object sender, EventArgs e)
        {
            var selectRows = this.GirdCard.GetSelectedRows();

            if (selectRows.Length < 1)
            {
                throw new Exception("当前没有选中行!");
            }

            if (MsgBox.ShowYesNoMsg("确定关闭所选流转卡?") != DialogResult.Yes) return;

            List<CardMain> cards = new List<CardMain>();

            foreach (int i in this.GirdCard.GetSelectedRows())
            {
                var cardm = ConvertToModel.DataRowToModel<CardMain>(GirdCard.GetDataRow(i));
                cards.Add(cardm);
            }

            dal.SetPauseStatus(true, Information.UserInfo.cUser_Name, cards.ToArray());

            //刷新
            this.ExecQuery();
        }

        /// <summary>
        /// 开启
        /// </summary>
        private void BtnStart_Click(object sender, EventArgs e)
        {
            var selectRows = this.GirdCard.GetSelectedRows();

            if (selectRows.Length < 1)
            {
                throw new Exception("当前没有选中行!");
            }

            if (MsgBox.ShowYesNoMsg("确定打开所选流转卡?") != DialogResult.Yes) return;

            List<CardMain> cards = new List<CardMain>();

            foreach (int i in this.GirdCard.GetSelectedRows())
            {
                var cardm = ConvertToModel.DataRowToModel<CardMain>(GirdCard.GetDataRow(i));
                cards.Add(cardm);
            }

            dal.SetPauseStatus(false, null, cards.ToArray());

            //刷新
            this.ExecQuery();
        }
    }
}
