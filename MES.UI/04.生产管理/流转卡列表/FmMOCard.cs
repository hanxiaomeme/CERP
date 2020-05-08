using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace LanyunMES.UI
{
    using DAL;
    using Model;
    using Server.Model;
    using Common;
    using Component;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpressUtility;

    public partial class FmMOCard : DevComponents.DotNetBar.OfficeForm
    {
        public FmMOCard(string cardNo)
        {
            InitializeComponent();

            this.Card = dal.Get(cardNo);
            this.Load += FmLoad;
        }


        public Card Card { get; private set; }
        private MCardDAL dal = new MCardDAL();

        private void InitGrid(GridView grid)
        {
            grid.KeyDown += GridViewHelper.KeyDownCellCopy;
            grid.OptionsBehavior.AutoPopulateColumns = false;

            //GridViewHelper.AddColumn(grid, "MergeGuid", "MergeGuid", 120, readOnly: true);

            GridViewHelper.AddColumn(grid, "OpSeq", "工序号", 60, readOnly: true);
            GridViewHelper.AddColumn(grid, "OpName", "工序名称", 80, readOnly: true);

            var col = GridViewHelper.AddColumn(grid, "hgQty", "合格数量", 80, readOnly: true);
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n3}";

            col = GridViewHelper.AddColumn(grid, "bhgQty", "不合格数量", 80, readOnly: true);
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n3}";
      
            GridViewHelper.AddColumn(grid, "cWorker", "操作工", 60, readOnly: true);
            GridViewHelper.AddColumn(grid, "dRepDate", "报工日期", 80, readOnly: true);
            GridViewHelper.AddColumn(grid, "dRepPsn", "报工人", 60, readOnly: true);
        }

        private void FmLoad(object sender, EventArgs e)
        {
            this.InitGrid(GridRecord);

            UIBinding<CardMain>.UIDataBinding(panel1, Card.M);

            this.gridControl1.DataSource = Card.DList;
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if(MsgBox.ShowYesNoMsg("确定撤销最后一道报工记录?") == DialogResult.Yes)
            {
                Report.ReportClient rep = new Report.ReportClient();
                rep.ReportCanel(Card.M.CardNo);


                Card = dal.Get(Card.M.CardNo);

                UIBinding<CardMain>.UIDataBinding(panel1, Card.M);

                this.gridControl1.DataSource = Card.DList;
            }
           
        }
    }
}