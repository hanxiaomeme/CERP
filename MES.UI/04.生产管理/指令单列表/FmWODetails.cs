using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Text;
using System.Windows.Forms;

namespace LanyunMES.UI
{
    using Component;
    using DAL;
    using Model;
    using U8Ext.Ref;

    public partial class FmWODetails : DevComponents.DotNetBar.OfficeForm
    {
        public FmWODetails(OpState opState)
        {
            InitializeComponent();
            this.Text = this.lblModuleTitle.Text;
            this.tab_Main.Text = this.lblModuleTitle.Text;
            this.Load += FormLoad;
            this.btn_Save.Click += Save;
            this.btn_AddLine.Click += AddLine;
            this.btn_DelLine.Click += DelLine;
            this.opState = opState;
        }

        public FmWODetails(string woGuid) :this(OpState.Update)
        {
            this.woGuid = woGuid;
        }

        private string woGuid;
        private WorkOrderDAL dal = new WorkOrderDAL();
        private DataView dvDetail;

        private OpState opState { get; set; }


        protected void Save(object sender, EventArgs e)
        {

            SaveCheck();

            gridDetail.PostEditor();
   
            gridDetail.UpdateCurrentRow();

            dal.SaveDetail(dvDetail);
            this.DialogResult = DialogResult.OK;

        }

        private void SaveCheck()
        {
            foreach (DataRowView r in dvDetail)
            {
                if (r["routerId"].ToString() == "")
                {
                    throw new Exception("子件尚未选择工序!");
                }
                else if (r["iQty"].ToString() == "")
                {
                    throw new Exception("子件数量尚未填写!");
                }
            }
        }

        private void FormLoad(object sender, EventArgs e)
        {
            #region 加载主窗体事件

            new Thread(()=> {
                this.BeginInvoke(new Action(() =>
                {
                    dvDetail = dal.GetDetail(woGuid).DefaultView;
                    this.gridControl1.DataSource = dvDetail;
                }));
            }).Start();


            repositoryItemLookUpEdit1.DataSource = dal.GetRouter(woGuid);
            repositoryItemLookUpEdit1.KeyMember = "autoid";
            repositoryItemLookUpEdit1.ValueMember = "autoid";
            repositoryItemLookUpEdit1.DisplayMember = "OpName";

            repositoryItemLookUpEdit1.Columns.AddRange(
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                {
                    new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OpSeq", "序号"),
                    new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OpName", "工序")
                });

            #endregion
        }

        private void AddLine(object sender, EventArgs e)
        {
            #region 增加子件
            IRefDAL dal = new InventoryDAL(Information.UserInfo.ConnU8);
            RefForm frm = new RefForm(dal);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var r = dvDetail.AddNew();
                r.BeginEdit();
                r["guid"] = woGuid;
                r["DInvCode"] = frm.rows[0]["cInvCode"];
                r["DInvName"] = frm.rows[0]["cInvName"];
                r["DInvStd"] = frm.rows[0]["cInvStd"];
                r.EndEdit();
            }
            #endregion
        }

        private void DelLine(object sender, EventArgs e)
        {
            #region 删除子件
            if (MsgBox.ShowYesNoMsg("是否删除选定行?") == DialogResult.Yes)
            {
                var index = gridDetail.FocusedRowHandle;
                gridDetail.DeleteRow(index);
            } 
            #endregion
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            #region 退出模块

            if (this.opState != OpState.Browse)
            {
                if (MsgBox.ShowYesNoMsg("当前数据尚未保存，是否退出？") == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }

            #endregion
        }

        private void repositoryItemLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            var edit = gridDetail.ActiveEditor;
           
            gridDetail.SetFocusedRowCellValue("routerId", edit.EditValue);
        }
    }
}