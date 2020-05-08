using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace LanyunMES.UI
{
    using Model;
    using DAL;
    using System.Data.SqlClient;

    public partial class FmRQmrList : DevComponents.DotNetBar.OfficeForm
    {
        public FmRQmrList()
        {
            InitializeComponent();
            this.Load += Fm_Load;
            this.dgMain.RowEnter += GetDViewData;
        }


        #region 业务对象,变量

        QmRecordController controller = new QmRecordController();

        private string[] wheres;
        private SqlParameter[] parameters;

        protected DataTable DtM = null, DtD = null;

        public DataRow selectMitem { get; private set; }

        public List<DataRow> selectDitems { get; private set; }

        #endregion

        protected virtual void InitGridM(DataGridView dgv)
        {
            #region 初始化主表列
            dgv.Columns.Clear();
            dgv.AutoGenerateColumns = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            GridAddTextCol(dgMain, "QMRCode", "检验单号", 100);
            GridAddTextCol(dgMain, "dDate", "日期", 90);
            GridAddTextCol(dgMain, "cVenCode", "供应商编码", 80);
            GridAddTextCol(dgMain, "cVenName", "供应商", 180);
            GridAddTextCol(dgMain, "checkPsn", "检验员", 80);
            GridAddTextCol(dgMain, "cMaker", "制单人", 80);
            GridAddTextCol(dgMain, "cAuditPsn", "审核人", 80);
            GridAddTextCol(dgMain, "dAuditDate", "审核日期", 90);
            GridAddTextCol(dgMain, "cMemo", "备注", 130); 
            #endregion
        }

        protected virtual void InitGridD(DataGridView dgv)
        {
            #region 初始化子表列
            dgv.Columns.Clear();
            dgv.AutoGenerateColumns = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            GridAddTextCol(dgDetail, "cPOID", "采购订单号", 100);
            GridAddTextCol(dgDetail, "cPosCode", "货位编码", 80);
            GridAddTextCol(dgDetail, "cPosName", "货位名称", 120);
            GridAddTextCol(dgDetail, "cInvCode", "存货编码", 120);
            GridAddTextCol(dgDetail, "cInvName", "存货名称", 120);
            GridAddTextCol(dgDetail, "cInvStd", "规格型号", 120);
            GridAddTextCol(dgDetail, "cComUnitName", "单位", 40);
            GridAddTextCol(dgDetail, "iQualifyQty", "合格数量", 80);
            GridAddTextCol(dgDetail, "iUnQualifyQty", "不合格数量", 80);
            GridAddTextCol(dgDetail, "remark", "备注", 120); 
            #endregion
        }

        protected void Fm_Load(object sender, EventArgs e)
        {
            #region 窗体加载

            this.InitGridM(dgMain);
            this.InitGridD(dgDetail);

            this.wheres = new string[]
            {
                @"guid in (select t1.guid from QmRecord t1 left join TransVouch t2  
                  on t2.cSource = '检验单' and t2.cSourceGuid = t1.Guid where t2.guid is null)"
            };

            GetMViewData();      
                           
            #endregion
        }

        protected void GetMViewData()
        {
            #region 获取主表数据

            DtM = controller.GetMList(wheres);
            this.dgMain.DataSource = DtM;

            statusLabel1.Text = "主表记录：" + dgMain.RowCount;

            #endregion
        }

        protected void GetDViewData(object sender, DataGridViewCellEventArgs e)
        {
            #region 获取子表数据

            var guid = DtM.Rows[e.RowIndex]["guid"].ToString();
            DtD = controller.GetDList(guid);
            this.dgDetail.DataSource = DtD;
            
            statusLabel2.Text = "  子表记录：" + dgDetail.RowCount;
            this.cBox_SelectAll.Checked = false;

            #endregion
        }

        protected DataGridViewTextBoxColumn GridAddTextCol(DataGridView dgv, string colName, string colText, int width)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name = col.DataPropertyName = colName;
            col.HeaderText = colText;
            col.Width = width;
            dgv.Columns.Add(col);
            return col;
        }

        protected DataGridViewCheckBoxColumn GridAddCheckCol(DataGridView dgv, string colName, string colText, int width)
        {
            DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
            col.Name = col.DataPropertyName = colName;
            col.HeaderText = colText;
            col.Width = width;
            dgv.Columns.Add(col);
            return col;
        }

        protected void DGXAddCol(DataGridView dgv, XmlNode item)
        {
            string colName = item["colName"].InnerText;
            string colText = item["colText"].InnerText;
            int colWidth = int.Parse(item["colWidth"].InnerText);
            if (colName == "isSelected")
            {
                DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn(false);
                col.HeaderText = colText;
            }
            else
            {
                dgv.Columns.Add(colName, colText);
            }
            dgv.Columns[colName].DataPropertyName = colName;
            dgv.Columns[colName].Width = colWidth;
            dgv.Columns[colName].ReadOnly = true;
        }

        protected virtual void cbx_ListChanged()
        {

        }


        //------------------------------------------

        private void Btn_Select_Click(object sender, EventArgs e)
        {
            #region 确定返回选中记录

            if (DtM.Rows.Count <= 0) return;

            this.selectMitem = DtM.Rows[dgMain.CurrentRow.Index];
            this.selectDitems = new List<DataRow>();

            foreach (DataRow row in DtD.Rows)
            {
                selectDitems.Add(row);
            }
     
            this.DialogResult = DialogResult.OK; 

            #endregion
        }

        private void Btn_Reflash_Click(object sender, EventArgs e)
        {
            #region 刷新

            GetMViewData(); 

            #endregion
        }

        private void cBox_SelectAll_CheckedChanged(object sender, EventArgs e)
        {
            #region 全选,全消

            //if (DtM.Rows.Count <= 0) return;

            //if (_isMutiSelectD && dgDetail.RowCount > 0)
            //{
            //    foreach (DataRow row in DtD.Rows)
            //    {
            //        row.BeginEdit();
            //        row["isSelected"] = cBox_SelectAll.Checked;
            //        row.EndEdit();
            //    }
            //} 

            #endregion
        }

    }
}
