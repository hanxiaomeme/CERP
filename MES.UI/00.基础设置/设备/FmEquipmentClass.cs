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

namespace LanyunMES.UI
{
    using Model;
    using DAL;
    using Component;

    public partial class FmEquipmentClass : DevComponents.DotNetBar.OfficeForm
    {
        public FmEquipmentClass()
        {
            InitializeComponent();
            this.Text = pnl_Head.Text;
            this.TreeM.Nodes[0].Text = pnl_Head.Text;
            this.Load += FmB_Load;
        }


        private OpState opState = OpState.Browse;
        private EquipmentClass selectedNode = null;
        EquipmentClassDAL dal = new EquipmentClassDAL();
        

        private void FmB_Load(object sender, System.EventArgs e)
        {
            #region 窗体加载, 加载TreeNode

            var treeData = dal.GetList();

            TreeHelper.LoadAdvTree(this.TreeM, treeData, NodeClick);

            this.lblRowCount.Text = "分类记录：" + treeData.Count.ToString();

            UIStatus(opState);

            #endregion
        }

        private void NodeClick(object sender, EventArgs e)
        {
            Node node = sender as Node;
            this.selectedNode = node.Tag as EquipmentClass;
            this.txt_CCode.Text = selectedNode.Code;
            this.txt_CName.Text = selectedNode.Name;               
        }

        private void UIStatus(OpState opState)
        {
            #region 界面状态
            if (opState == OpState.Browse)
            {
                this.btn_Add.Enabled = btn_Edit.Enabled = btn_Del.Enabled = true;
                btn_Refresh.Enabled = true;
                this.txt_CCode.Enabled = txt_CName.Enabled = false;
                this.btn_Save.Enabled = this.btn_Cancel.Enabled = false;
                this.TreeM.Enabled = true;
            }
            else if (opState == OpState.Add || opState == OpState.Update)
            {
                this.btn_Add.Enabled = btn_Edit.Enabled = btn_Del.Enabled = false;
                btn_Refresh.Enabled = false;
                this.txt_CCode.Enabled = txt_CName.Enabled = true;
                this.btn_Save.Enabled = this.btn_Cancel.Enabled = true;
                this.TreeM.Enabled = false;
            }

            this.opState = opState; 
            #endregion
        }


        //===========================================================================


        private void btn_Add_Click(object sender, EventArgs e)
        {
            this.UIStatus(OpState.Add);
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (this.selectedNode == null)
            {
                MsgBox.ShowInfoMsg("没有选择记录！");
            }
            else
            {
                this.UIStatus(OpState.Update);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string cCode = txt_CCode.Text.Trim();

            int len = cCode.LastIndexOf(".");
            if (len > 0)
            {
                string pCode = cCode.Substring(0, len);

                if (!dal.Exists(pCode))
                {
                    throw new Exception("不存在上级分类: " + pCode);
                }
            }
          

            if (opState == OpState.Add)
            {
                if(dal.Exists(cCode))
                {
                    throw new Exception("分类编码: " + cCode + " 已存在!");
                }

                this.selectedNode = new EquipmentClass();
                selectedNode.Code = cCode;
                selectedNode.Name = txt_CName.Text.Trim();
                selectedNode.cMaker = Information.UserInfo.cUser_Name;

                if(dal.Add(selectedNode))
                {
                    this.btn_Refresh_Click(null, null);
                }
            }
            else if(opState == OpState.Update)
            {
                if (selectedNode.Code != cCode)
                {
                    if (dal.Exists(cCode))
                    {
                        throw new Exception("分类编码: " + cCode + " 已存在!");
                    }
                    else if(dal.ExistsChild(selectedNode.Code))
                    {
                        throw new Exception("当前分类存在下级分类, 分类编码不能修改!");
                    }
                }

                selectedNode.Code = cCode;
                selectedNode.Name = txt_CName.Text.Trim();

                if(dal.Update(selectedNode))
                {
                    this.btn_Refresh_Click(null, null);
                }
            }

            TreeM.SelectedNode = TreeM.FindNodeByName(selectedNode.Code);
         
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            #region 删除
            EquipmentClass model = TreeM.SelectedNode.Tag as EquipmentClass;
            if (dal.ExistsChild(model.Code))
            {
                throw new Exception("存在下级分类不能删除!");
            }
            else if (dal.ExistsRef(model.EQCId))
            {
                throw new Exception("分类已经被引用不能删除!");
            }

            if (dal.Delete(model.EQCId))
            {
                this.btn_Refresh_Click(null, null);
            } 
            #endregion
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.UIStatus(OpState.Browse);
        }

        protected virtual void btn_Refresh_Click(object sender, EventArgs e)
        {
            var treeData = dal.GetList();
            TreeHelper.LoadAdvTree(TreeM, treeData, NodeClick);
            this.UIStatus(OpState.Browse);

            this.lblRowCount.Text = "分类记录：" + treeData.Count.ToString();
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