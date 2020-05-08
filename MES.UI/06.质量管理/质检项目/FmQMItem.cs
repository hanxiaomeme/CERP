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
    using Model;
    using DAL;
    using Component;
    using Common;

    public partial class FmQMItem : DevComponents.DotNetBar.OfficeForm
    {
        private FmQMItem()
        {
            InitializeComponent();

            this.Text = tab_Main.Text = this.lblModuleTitle.Text;
            this.Load += FormLoad;
            this.btn_Save.Click += Save;
        }

        public FmQMItem(int qmcId, int qmItemId) : this()
        {
            this.opState = OpState.Add;
            this.model = new QMItem();
            this.model.QMCId = qmcId;
            this.model.cMaker = Information.UserInfo.cUser_Name;

            lblModuleTitle.Text = "新增 - " + this.lblModuleTitle.Text;
        }

        public FmQMItem(int QMItemId, OpState op = OpState.Browse) : this()
        {
            this.model = dal.Get(QMItemId);
             
        }

        private string oldCode = "";
        private OpState opState;
        private QMItem model;
        private QMItemDAL dal = new QMItemDAL();

        private void FormLoad(object sender, EventArgs e)
        {
            #region 加载主窗体事件

            if(opState == OpState.Update)
            {
                oldCode = model.QMItemCode;
                lblModuleTitle.Text = "编辑 - " + this.lblModuleTitle.Text;
            }

            UIControl.SetStatus(Head_Bar, tab_Main.AttachedControl, opState);

            UIBinding<QMItem>.UIDataBinding(panelEx1, model);

            #endregion
        }

        private void Save(object sender, EventArgs e)
        {
            #region 保存项目档案

            if (string.IsNullOrEmpty(model.QMItemCode))
            {
                throw new Exception("检验编码不能为空!");
            }
            else if (string.IsNullOrEmpty(model.QMItemName))
            {
                throw new Exception("检验名称不能为空!");
            }

            if (opState == OpState.Add)
            {
                if (dal.Exists(model.QMItemCode))
                {
                    throw new Exception("已存在项目编码: " + model.QMItemCode);
                }
               var id =  dal.Add(model);
            }
            else if (opState == OpState.Update)
            {
                if (model.QMItemCode != oldCode && dal.Exists(model.QMItemCode))
                {
                    throw new Exception("已存在项目编码: " + model.QMItemCode);
                }
                dal.Update(model);
            }

            this.DialogResult = DialogResult.OK;
            
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

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            this.opState = OpState.Update;
            UIControl.SetStatus(Head_Bar, tab_Main.AttachedControl, opState);
        }
    }
}