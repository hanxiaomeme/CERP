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

    public partial class FmQMItemClass : DevComponents.DotNetBar.OfficeForm
    {
        private FmQMItemClass()
        {
            InitializeComponent();

            this.Text = tab_Main.Text = this.lblModuleTitle.Text;
            this.Load += FormLoad;
            this.btn_Save.Click += Save;
        }

        public FmQMItemClass(OpState op = OpState.Add) : this()
        {
            this.opState = op;
        }

        public FmQMItemClass(int QMCId ,OpState op = OpState.Browse) : this()
        {
            this.model = dal.GetClass(QMCId);
        }

        private string oldCode = "";
        private OpState opState;
        private QMItemClass model;
        private QMItemDAL dal = new QMItemDAL();

        private void FormLoad(object sender, EventArgs e)
        {
            #region �����������¼�

            if (opState == OpState.Add)
            {
                model = new QMItemClass()
                { 
                   cMaker = Information.UserInfo.cUser_Name
                };
                lblModuleTitle.Text = "���� - " + this.lblModuleTitle.Text;
            }
            else if(opState == OpState.Update)
            {
                oldCode = model.QMCCode;
                lblModuleTitle.Text = "�༭ - " + this.lblModuleTitle.Text;
            }

            UIControl.SetStatus(Head_Bar, tab_Main.AttachedControl, opState);

            UIBinding<QMItemClass>.UIDataBinding(panelEx1, model);

            #endregion
        }

        private void Save(object sender, EventArgs e)
        {
            #region ������Ŀ����

            if (string.IsNullOrEmpty(model.QMCCode))
            {
                throw new Exception("��Ŀ���벻��Ϊ��!");
            }
            else if (string.IsNullOrEmpty(model.QMCName))
            {
                throw new Exception("��Ŀ���Ʋ���Ϊ��!");
            }

            if (opState == OpState.Add)
            {
                if (dal.ExistClass(model.QMCCode))
                {
                    throw new Exception("�Ѵ�����Ŀ����: " + model.QMCCode);
                }
               var id =  dal.AddClass(model);
            }
            else if (opState == OpState.Update)
            {
                if (model.QMCCode != oldCode && dal.ExistClass(model.QMCCode))
                {
                    throw new Exception("�Ѵ�����Ŀ����: " + model.QMCCode);
                }
                dal.UpdateClass(model);
            }

            this.DialogResult = DialogResult.OK;
            
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

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            this.opState = OpState.Update;
            UIControl.SetStatus(Head_Bar, tab_Main.AttachedControl, opState);
        }
    }
}