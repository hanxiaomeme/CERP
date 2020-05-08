using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Windows.Forms;

namespace LanyunMES.UI
{
    using DAL;
    using System.Data.SqlClient;
    using Component;
    using DevExpressUtility;

    public partial class FmEquipmentMPList : DevComponents.DotNetBar.OfficeForm
    {
        public FmEquipmentMPList()
        {
            InitializeComponent();
            this.Load += FmLoad;
            this.BtnAdd.Click += Add;
            this.BtnEdit.Click += Edit;
            this.BtnDel.Click += Delete;
            this.gridView1.KeyDown += GridViewHelper.KeyDownCellCopy;

            this.Text = pnlMain.Text;
        }

        public FmEquipmentMPList(int EQId): this()
        {
            this.wheres = new List<string> { "EQId = @EQId" };
            paramList = new List<SqlParameter> { new SqlParameter("@EQId", EQId) };
            this.RefreshList();
        }


        private DataTable dtMain;
        private List<string> wheres;
        private List<SqlParameter> paramList;

        MaintenancePlansDAL dal  = new MaintenancePlansDAL();


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
        }

        private void RefreshList()
        {
            if (wheres != null && wheres.Count > 0)
            {
                this.dtMain = dal.GetTable(wheres.ToArray(), paramList.ToArray());
            }
            else
            {
                this.dtMain = dal.GetTable(null, null);   
            }

            this.gridControl2.DataSource = dtMain;
        }

        //新增
        private void Add(object sender, EventArgs e)
        {
            FmEquipmentMP frm = new FmEquipmentMP(null);
            if(frm.ShowDialog() == DialogResult.OK)
            {
                this.RefreshList();
            }
        }

        //编辑
        private void Edit(object sender, EventArgs e)
        {
            if(dtMain == null || dtMain.Rows.Count < 1)
            {
                throw new Exception("当前表体没有记录!");
            }
            int autoId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("AutoId"));
            FmEquipmentMP frm = new FmEquipmentMP(autoId);
            if(frm.ShowDialog() == DialogResult.OK)
            {
                this.RefreshList();
            }
        }

        //删除
        private void Delete(object sender, EventArgs e)
        {
            if (MsgBox.ShowYesNoMsg("确定删除选定记录?") == DialogResult.Yes)
            {
                int autoId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("AutoId"));
                if (dal.Delete(autoId))
                {
                    this.RefreshList();
                }
            }
        }
               
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            FmEquipmentMPQ frm =  new FmEquipmentMPQ();
            frm.LoadSqlParams(paramList);
            if(frm.ShowDialog() == DialogResult.OK)
            {
                this.wheres = frm.ListWhere;
                this.paramList = frm.Parameters;
                this.RefreshList();
            } 
        }
    }
}
