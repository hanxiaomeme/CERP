using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.AdvTree;
using System.Threading;

namespace MES
{
    using MES.Model;
    using MES.DAL;
    using MES.UIBase;
    

    public partial class FmInvClass : FmTreeClass
    {
        public FmInvClass()
        {
            InitializeComponent();
            this.ModuleName = "InventoryClass";
        }

        InventoryClass currentInvC = null;
        InventoryClassDAL invcDAL = new InventoryClassDAL();

        private void FmInvClass_Load(object sender, EventArgs e)
        {
            FmB_Load(sender, e);
        }

        protected override void NodeClick(object sender, EventArgs e)
        {
            if (opState == OpState.Add || opState == OpState.Add)
            {
                return;
            }
            selectedNode = (Node)sender;
            string[] sArray = (string[])selectedNode.Tag;
            this.txt_CCode.Text = sArray[0];
            this.txt_CName.Text = sArray[1];
        }

        protected override void btn_Save_Click(object sender, EventArgs e)
        {
            #region 保存
            if (txt_CCode.Text.Trim() == "" || txt_CName.Text.Trim() == "")
            {
                MsgBox.ShowInfoMsg("分类编码和分类名称不能为空！");
                return;
            }

            //检查上级编码是否存在
            int len = txt_CCode.Text.Trim().LastIndexOf(".");
            if (len > 0)
            {
                string pInvCCode = txt_CCode.Text.Trim().Substring(0, len);
                if (!invcDAL.Exists(pInvCCode))
                {
                    MsgBox.ShowInfoMsg("上级分类编码不存在！");
                    return;
                }
            }

            if (this.opState == OpState.Add)
            {
                if (invcDAL.Exists(txt_CCode.Text.Trim()))
                {
                    MsgBox.ShowInfoMsg("分类编码已经存在！");
                    return;
                }

                InventoryClass invC = new InventoryClass();
                invC.InvCCode = txt_CCode.Text;
                invC.InvCName = txt_CName.Text;

                if (invcDAL.Add(invC) == 0)
                {
                    MsgBox.ShowInfoMsg("保存失败!");
                }
                this.currentInvC = invC;
            }
            else if (this.opState == OpState.Update)
            {
                string[] sArray = (string[])TreeM.SelectedNode.Tag;
                currentInvC = invcDAL.GetModel(sArray[0]);

                if (currentInvC.InvCCode != txt_CCode.Text)
                {
                    if (TreeM.SelectedNode.Nodes.Count > 0)
                    {
                        MsgBox.ShowInfoMsg("当前分类存在下级分类，请先删除或移动下级分类到其他分类下！");
                        return;
                    }

                    if (invcDAL.Exists(txt_CCode.Text))
                    {
                        MsgBox.ShowInfoMsg("当前分类编码已经存在!");
                        return;
                    }
                }

                currentInvC.InvCCode = txt_CCode.Text;
                currentInvC.InvCName = txt_CName.Text;

                if (!invcDAL.Update(currentInvC))
                {
                    MsgBox.ShowInfoMsg("保存失败!");
                }
            }

            //刷新TreeView
            this.btn_Refresh_Click(sender, e); 
            #endregion
        }

        protected override void btn_Del_Click(object sender, EventArgs e)
        {
            #region 删除
            if (MsgBox.ShowYesNoMsg("确定删除分类：" + TreeM.SelectedNode.Text) != DialogResult.Yes)
            {
                return;
            }

            if (TreeM.SelectedNode != null)
            {
                if (TreeM.SelectedNode.Nodes.Count > 0)
                {
                    MsgBox.ShowInfoMsg("非末级分类不能删除");
                    return;
                }
                else
                {
                    InventoryClass invC = invcDAL.GetModel(TreeM.SelectedNode.Name);

                    string sql = "select count(1) from Inventory where InvCID = " + invC.InvCId;

                    if (Convert.ToInt32(DbHelperSQL.GetSingle(sql)) > 0)
                    {
                        MsgBox.ShowInfoMsg("当前分类已经被图纸档案引用，不能删除！");
                        return;
                    }
                    else
                    {
                        invcDAL.Delete(invC.InvCId);
                        currentInvC = invcDAL.GetModel(TreeM.SelectedNode.Parent.Name);
                        this.btn_Refresh_Click(sender, e); 
                    }
                }             
            } 
            #endregion
        }

        protected override void LoadTVData()
        {
            base.LoadTVData();

            //定位当前节点
            if (currentInvC != null)
            {
                TreeM.SelectedNode = TreeM.FindNodeByName(currentInvC.InvCCode);
            }
        }
    }
}
