using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;

namespace MES
{
    using MES.Model;
    using MES.DAL;
    using MES.UIBase;

    public partial class FmInv : FmTreeGrid
    {
        public FmInv()
        {
            InitializeComponent();
            this.ModuleName = "InventoryClass";
        }


        protected override void InitGridColumn()
        {
            #region 初始化列
            DataGridViewLabelXColumn col;

            col = new DataGridViewLabelXColumn();
            col.Name = col.DataPropertyName = "InvCode";
            col.HeaderText = "零件号";
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            col.SortMode = DataGridViewColumnSortMode.Automatic;
            col.Width = 150;
            sGrid.Columns.Add(col);

            col = new DataGridViewLabelXColumn();
            col.Name = col.DataPropertyName = "InvName";
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            col.HeaderText = "产品名称";
            col.Width = 120;
            sGrid.Columns.Add(col);

            col = new DataGridViewLabelXColumn();
            col.Name = col.DataPropertyName = "InvStd";
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            col.HeaderText = "规格型号";
            col.Width = 150;
            sGrid.Columns.Add(col);

            col = new DataGridViewLabelXColumn();
            col.Name = col.DataPropertyName = "DDCS";
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            col.HeaderText = "短端参数";
            col.Width = 100;
            sGrid.Columns.Add(col);

            col = new DataGridViewLabelXColumn();
            col.Name = col.DataPropertyName = "CDCS";
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            col.HeaderText = "长端参数";
            col.Width = 100;
            sGrid.Columns.Add(col);

            col = new DataGridViewLabelXColumn();
            col.Name = col.DataPropertyName = "luoju";
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            col.HeaderText = "螺距";
            col.Width = 80;
            sGrid.Columns.Add(col);

            col = new DataGridViewLabelXColumn();
            col.Name = col.DataPropertyName = "ljdb";
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            col.HeaderText = "六角对边";
            col.Width = 80;
            sGrid.Columns.Add(col);

            col = new DataGridViewLabelXColumn();
            col.Name = col.DataPropertyName = "houdu";
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            col.HeaderText = "厚度";
            col.Width = 80;
            sGrid.Columns.Add(col);

            col = new DataGridViewLabelXColumn();
            col.Name = col.DataPropertyName = "chishu";
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            col.HeaderText = "齿数";
            col.Width = 80;
            sGrid.Columns.Add(col);

            col = new DataGridViewLabelXColumn();
            col.Name = col.DataPropertyName = "yachang";
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            col.HeaderText = "牙长";
            col.Width = 80;
            sGrid.Columns.Add(col);

            col = new DataGridViewLabelXColumn();
            col.Name = col.DataPropertyName = "cgzj_1";
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            col.HeaderText = "粗杆直径1";
            col.Width = 80;
            sGrid.Columns.Add(col);

            col = new DataGridViewLabelXColumn();
            col.Name = col.DataPropertyName = "cgcd_1";
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            col.HeaderText = "粗杆长度1";
            col.Width = 80;
            sGrid.Columns.Add(col);

            col = new DataGridViewLabelXColumn();
            col.Name = col.DataPropertyName = "cgzj_2";
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            col.HeaderText = "粗杆直径2";
            col.Width = 80;
            sGrid.Columns.Add(col);

            col = new DataGridViewLabelXColumn();
            col.Name = col.DataPropertyName = "cgcd_2";
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            col.HeaderText = "粗杆长度2";
            col.Width = 80;
            sGrid.Columns.Add(col);

            //sGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; 
            #endregion
        }

        private void FrmInv_Load(object sender, EventArgs e)
        {
            FmB_Load(sender, e);
        }

        protected override void btnAdd_Click(object sender, EventArgs e)
        {
            #region 新增
            InventoryClassDAL invcDAL = new InventoryClassDAL();
            InventoryClass invC = invcDAL.GetModel(TreeM.SelectedNode.Name);

            FmInvDetail frm = new FmInvDetail(OpState.Add, invC);
            UICtrl.SetShowStyle(frm, 1);
            frm.ShowDialog();
            if (frm.Saved == true)
            {

                if (this.dvDetail != null)
                {
                    this.dvDetail.Dispose();
                    this.dvDetail = null;
                }
                string[] sArray = (string[])m_tnSelected.Tag;

                this.GetMBusiData(sArray[0],true);
            }
            #endregion
        }

        protected override void btnEdit_Click(object sender, EventArgs e)
        {
            #region 编辑
            if (sGrid.CurrentRow.Index >= 0)
            {
                InventoryDAL invDAL = new InventoryDAL();
                Inventory inv = invDAL.DataRowToModel(dvDetail[sGrid.CurrentRow.Index].Row);
                FmInvDetail frm = new FmInvDetail(OpState.Browse, inv);
                frm.ShowDialog();
                if (frm.Saved == true)
                {
                    string[] sArray = (string[])m_tnSelected.Tag;
                    this.GetMBusiData(sArray[0], true);
                }
            }
            else
            {
                MsgBox.ShowInfoMsg("没有选择记录！");
            } 
            #endregion
        }

        protected override void btnDel_Click(object sender, EventArgs e)
        {
            #region 删除
            if (sGrid.CurrentRow.Index >= 0)
            {
                if (MsgBox.ShowYesNoMsg("确定删除选定的记录？") == DialogResult.Yes)
                {
                    InventoryDAL invDAL = new InventoryDAL();
                    int invid = Convert.ToInt32(dvDetail[sGrid.CurrentRow.Index]["invID"]);
                    string invCode = dvDetail[sGrid.CurrentRow.Index]["InvCode"].ToString();

                    if (DelFtpFiles(invCode))
                    {
                        if (invDAL.Delete(invid))
                        {
                            string[] sArray = (string[])m_tnSelected.Tag;

                            this.GetMBusiData(sArray[0], true);
                        }
                    }
                }
            }
            else
            {
                MsgBox.ShowInfoMsg("没有选择记录！");
            }  
            #endregion
        }

        protected override void btnQuery_Click(object sender, EventArgs e)
        {
            #region 查询
            FmInvQuery frm = new FmInvQuery();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.StrQuery == "")
                {
                    string[] sArray = (string[])m_tnSelected.Tag;
                    this.GetMBusiData(sArray[0], true);
                }
                else
                {
                    this.GetMBusiData(frm.StrQuery, false);
                }

            } 
            #endregion
        }

        private bool DelFtpFiles(string invCode)
        {
            #region 删除图纸编码文件夹下所有文件
            try
            {
                string ip = "192.168.0.10/PDF Files/" + invCode;
                Ftp ftp = new Ftp(ip, "ftpuser", "ndf1985");
                string[] files = ftp.GetFileList();

                if (files != null && files.Length > 0)
                {
                    ftp.DeleteFiles(files);
                }
                return true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowInfoMsg(ex.ToString());
                return false;
            } 
            #endregion

        }

        
    }
}
