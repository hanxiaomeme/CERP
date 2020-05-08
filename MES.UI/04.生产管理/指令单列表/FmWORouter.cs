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

    public partial class FmWORouter : DevComponents.DotNetBar.OfficeForm
    {
        public FmWORouter(OpState opState)
        {
            InitializeComponent();
            this.Text = this.lblModuleTitle.Text;
            this.tab_Main.Text = this.lblModuleTitle.Text;
            this.Load += FormLoad;
            this.btn_Save.Click += Save;
            this.btn_Up.Click += MoveUp;
            this.btn_Down.Click += MoveDown;
            this.btn_AddLine.Click += AddLine;
            this.btn_DelLine.Click += DelLine;
            this.opState = opState;
        }

        public FmWORouter(string woGuid) :this(OpState.Update)
        {
            this.woGuid = woGuid;
        }

        private string woGuid;
        private WorkOrderDAL dal = new WorkOrderDAL();
        private DataView dvRouter;

        /// <summary>
        /// 当前业务操作(新增，修改，删除)
        /// </summary>
        private OpState opState { get; set; }


        protected void Save(object sender, EventArgs e)
        {
            gridRouter.PostEditor();
            gridRouter.UpdateCurrentRow();

            dal.SaveRouter(dvRouter);
            this.DialogResult = DialogResult.OK;

        }

        private void FormLoad(object sender, EventArgs e)
        {
            #region 加载主窗体事件

            new Thread(()=> {
                this.BeginInvoke(new Action(() =>
                {
                    dvRouter = dal.GetRouter(woGuid).DefaultView;
                    this.gridControl1.DataSource = dvRouter;
                }));
            }).Start();

            #endregion
        }

        private void MoveUp(object sender, EventArgs e)
        { 
            #region 工序上移
            var index = gridRouter.FocusedRowHandle;
            if (index == 0) return;

            var curOpSeq = gridRouter.GetFocusedRowCellValue("OpSeq");
            var preOpSeq = gridRouter.GetRowCellValue(index - 1, "OpSeq").ToString();

            gridRouter.SetRowCellValue(index, "OpSeq", preOpSeq);
            gridRouter.SetRowCellValue(index - 1, "OpSeq", curOpSeq);

            dvRouter.Sort = "OpSeq";

            gridRouter.FocusedRowHandle = index - 1;
            #endregion
        }

        private void MoveDown(object sender, EventArgs e)
        {
            #region 工序下移
            var index = gridRouter.FocusedRowHandle;
            if (index == gridRouter.DataRowCount - 1) return;

            var curOpSeq = gridRouter.GetFocusedRowCellValue("OpSeq");
            var nextOpSeq = gridRouter.GetRowCellValue(index + 1, "OpSeq").ToString();

            gridRouter.SetRowCellValue(index, "OpSeq", nextOpSeq);
            gridRouter.SetRowCellValue(index + 1, "OpSeq", curOpSeq);

            dvRouter.Sort = "OpSeq";

            gridRouter.FocusedRowHandle = index + 1;
            #endregion
        }

        private void ReSetOrder()
        {
            int i = 10010;
            foreach(DataRowView r in dvRouter)
            {
                r.BeginEdit();
                r["OpSeq"] = i.ToString().Substring(1);
                i = i + 10;
                r.EndEdit();
            }
        }

        private void AddLine(object sender, EventArgs e)
        {
            #region 增加行
            IRefDAL2 dal = new OperationDAL(Information.UserInfo.ConnU8);
            RefForm2 frm = new RefForm2(dal);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var r = dvRouter.AddNew();
                r.BeginEdit();
                r["guid"] = woGuid;
                r["operationId"] = frm.rows[0]["operationId"];
                r["OpName"] = frm.rows[0]["OpName"];
                r["bQuality"] = 0;
                r.EndEdit();

                this.ReSetOrder();
            } 
            #endregion
        }

        private void DelLine(object sender, EventArgs e)
        {
            #region 删除行
            if (MsgBox.ShowYesNoMsg("是否删除选定行?") == DialogResult.Yes)
            {
                int index = gridRouter.FocusedRowHandle;
                gridRouter.DeleteRow(index);

                this.ReSetOrder();
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

        private void rowButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FmREquipment frm = new FmREquipment();
            if(frm.ShowDialog()== DialogResult.OK)
            {

                var row = gridRouter.GetFocusedDataRow();
                row["EQId"] = frm.Results[0].EQId;

                gridRouter.SetFocusedRowCellValue("cEQCode", frm.Results[0].cEQCode);
                gridRouter.SetFocusedRowCellValue("cEQName", frm.Results[0].cEQName);
            }
        }
    }
}