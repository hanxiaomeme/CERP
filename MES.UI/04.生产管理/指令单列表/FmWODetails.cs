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
                    throw new Exception("�Ӽ���δѡ����!");
                }
                else if (r["iQty"].ToString() == "")
                {
                    throw new Exception("�Ӽ�������δ��д!");
                }
            }
        }

        private void FormLoad(object sender, EventArgs e)
        {
            #region �����������¼�

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
                    new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OpSeq", "���"),
                    new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OpName", "����")
                });

            #endregion
        }

        private void AddLine(object sender, EventArgs e)
        {
            #region �����Ӽ�
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
            #region ɾ���Ӽ�
            if (MsgBox.ShowYesNoMsg("�Ƿ�ɾ��ѡ����?") == DialogResult.Yes)
            {
                var index = gridDetail.FocusedRowHandle;
                gridDetail.DeleteRow(index);
            } 
            #endregion
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            #region �˳�ģ��

            if (this.opState != OpState.Browse)
            {
                if (MsgBox.ShowYesNoMsg("��ǰ������δ���棬�Ƿ��˳���") == DialogResult.Yes)
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