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
    using Business;
    using Common;
    using Component;
    using Entity;

    public partial class FmMenu : DevComponents.DotNetBar.OfficeForm
    {
        public FmMenu()
        {
            InitializeComponent();
            this.Text = pnl_Head.Text;
            this.TreeM.Nodes[0].Text = pnl_Head.Text;
            this.Load += FmB_Load;
        }

        private UIStatus opState;

        private Menu currentMenu;

        private Menu newMenu;

        MenuService menuService = new MenuService();
 
 
        private void FmB_Load(object sender, System.EventArgs e)
        {
            #region 窗体加载
 
            var menuList = menuService.GetList(Information.UserInfo.UserName);

            TreeHelper.LoadAdvTree(TreeM, menuList, NodeClick);

            this.lblRowCount.Text = "分类记录：" + menuList.Count;

            SetUIStatus(opState);
 
            #endregion
        }
 
        private void NodeClick(object sender, EventArgs e)
        {
            currentMenu = (sender as Node).Tag as Menu;

            UIBinding<Menu>.UIDataBinding(panelEx1, currentMenu);
        }


        private void SetUIStatus(UIStatus opState)
        {
            #region 界面状态
            if (opState == UIStatus.Browse)
            {
                this.btn_Add.Enabled = btn_Edit.Enabled = btn_Del.Enabled = true;
                this.btn_Refresh.Enabled = true;
                this.txt_CCode.Enabled = txt_CName.Enabled = false;
                this.btn_Save.Enabled = this.btn_Cancel.Enabled = false;
                this.TreeM.Enabled = true;
            }
            else if (opState == UIStatus.Add || opState == UIStatus.Edit)
            {
                this.btn_Add.Enabled = btn_Edit.Enabled = btn_Del.Enabled = false;
                this.btn_Refresh.Enabled = false;
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
            this.SetUIStatus(UIStatus.Add);

            newMenu = new Menu();

            if (currentMenu != null) newMenu.FNumber = currentMenu.FNumber + ".";

            UIBinding<Menu>.UIDataBinding(panelEx1, newMenu);
        }
 
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (this.currentMenu == null)
            {
                MsgBox.ShowInfoMsg("没有选择记录！");
            }
            else
            {
                SetUIStatus(UIStatus.Edit);
            }
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            menuService.Delete(currentMenu.FItemID);
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            var treeData = menuService.GetList();
            TreeHelper.LoadAdvTree(TreeM, treeData, NodeClick);
            this.SetUIStatus(UIStatus.Browse);

            this.lblRowCount.Text = "分类记录：" + treeData.Count.ToString();
        }

        private void FmTreeClass_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (opState != UIStatus.Browse)
            {
                if (MsgBox.ShowYesNoMsg2("当前记录未保存是否退出！") != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            var m = opState == UIStatus.Add ? newMenu : currentMenu;

            if (string.IsNullOrEmpty(m.FNumber))
            {
                throw new Exception("菜单编码不能为空!");
            }
            else if (string.IsNullOrEmpty(m.FName))
            {
                throw new Exception("菜单名称不能为空!");
            }

            if (opState == UIStatus.Add)
            {
                if(menuService.Exists(m.FNumber))
                {
                    throw new Exception("编码:[" + m.FNumber + "], 已经存在!");
                }
                menuService.Add(m);
                newMenu = null;
            }
            else if(opState == UIStatus.Edit)
            {
                var oldMenu = menuService.Get(m.FItemID);

                if(oldMenu.FNumber != m.FNumber)
                {
                    if (menuService.Exists(m.FNumber))
                    {
                        throw new Exception("编码:[" + newMenu.FNumber + "], 已经存在!");
                    }
                }

                menuService.Update(m);
            }

            SetUIStatus(UIStatus.Browse);
            this.btn_Refresh_Click(null, null);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            UIBinding<Menu>.UIDataBinding(panelEx1, currentMenu);

            newMenu = null;

            SetUIStatus(UIStatus.Browse);
        }
    }
}