using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using DevComponents.DotNetBar;
using DevComponents.AdvTree;

namespace LanyunMES.UIBase
{
    using DAL;
    using Component;

    public partial class FmTreeClass : DevComponents.DotNetBar.OfficeForm
    {
        public FmTreeClass()
        {
            InitializeComponent();
            this.Text = pnl_Head.Text;
            this.TreeM.Nodes[0].Text = pnl_Head.Text;
            this.Load += FmB_Load;
        }

        private OpState opState = OpState.Browse;
        //private EquipmentClass selectedNode = null;
        //EquipmentClassDAL dal = new EquipmentClassDAL();

        protected virtual void FmB_Load(object sender, System.EventArgs e)
        {
            #region 窗体加载

            //var treeData = dal.GetList();

            //TreeHelper.LoadAdvTree(this.TreeM, treeData, NodeClick);

            //this.lblRowCount.Text = "分类记录：" + treeData.Count.ToString();

            //UIStatus(opState);



            #endregion
        }


        protected virtual void NodeClick(object sender, EventArgs e)
        {
            //TreeNode 点击事件 由继承的子类 override 实现
        }


        protected virtual void UIStatus(OpState opState)
        {
            #region 界面状态
            if (opState == OpState.Browse)
            {
                this.btn_Add.Enabled = btn_Edit.Enabled = btn_Del.Enabled = true;
                this.btn_Query.Enabled = btn_Refresh.Enabled = true;
                this.txt_CCode.Enabled = txt_CName.Enabled = false;
                this.btn_Save.Enabled = this.btn_Cancel.Enabled = false;
                this.TreeM.Enabled = true;
            }
            else if (opState == OpState.Add || opState == OpState.Update)
            {
                this.btn_Add.Enabled = btn_Edit.Enabled = btn_Del.Enabled = false;
                this.btn_Query.Enabled = btn_Refresh.Enabled = false;
                this.txt_CCode.Enabled = txt_CName.Enabled = true;
                this.btn_Save.Enabled = this.btn_Cancel.Enabled = true;
                this.TreeM.Enabled = false;
            }

            this.opState = opState; 
            #endregion
        }


        //===========================================================================


        protected virtual void btn_Add_Click(object sender, EventArgs e)
        {
            this.UIStatus(OpState.Add);
        }
        protected virtual void btn_Save_Click(object sender, EventArgs e)
        {

        }

        protected virtual void btn_Edit_Click(object sender, EventArgs e)
        {
            //if (this.selectedNode == null)
            //{
            //    MsgBox.ShowInfoMsg("没有选择记录！");
            //}
            //else
            //{
            //    this.UIStatus(OpState.Update);
            //}
        }

        protected virtual void btn_Del_Click(object sender, EventArgs e)
        {

        }

        protected virtual void btn_Query_Click(object sender, EventArgs e)
        {

        }


        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.UIStatus(OpState.Browse);
        }

        protected virtual void btn_Refresh_Click(object sender, EventArgs e)
        {
            //var treeData = dal.GetList();
            //TreeHelper.LoadAdvTree(TreeM, treeData, NodeClick);
            //this.UIStatus(OpState.Browse);

            //this.lblRowCount.Text = "分类记录：" + treeData.Count.ToString();
        }




        private void FmTreeClass_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (opState != OpState.Browse)
            {
                if (MsgBox.ShowYesNoMsg2("当前记录未保存是否退出！") != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

    }
}