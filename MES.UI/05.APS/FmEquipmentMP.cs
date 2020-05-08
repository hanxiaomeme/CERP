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

    public partial class FmEquipmentMP : DevComponents.DotNetBar.OfficeForm
    {

        private FmEquipmentMP()
        {
            InitializeComponent();

            this.Text = tab_Main.Text = this.lblModuleTitle.Text;
            this.Load += FormLoad;
            this.txtr_cEQCode.ButtonCustomClick += RefEquipment;
            this.btn_Save.Click += Save;
        }

        public FmEquipmentMP(Equipment Eq): this()
        {
            this.opState = OpState.Add;
            this.eq = Eq;
        }

        public FmEquipmentMP(int AutoId, OpState op = OpState.Update) :this()
        {
            this.opState = op;
            this.AutoId = AutoId;
        }

        private int AutoId;
        private DateTime oldDate;   //�޸�ǰ����
        private Equipment eq;       //�豸����
        private OpState opState;
        private MaintenancePlans model;
        private MaintenancePlansDAL dal = new MaintenancePlansDAL();


        private void FormLoad(object sender, EventArgs e)
        {
            #region �����������¼�

            if (opState == OpState.Add)
            {
                model = new MaintenancePlans();
                if (eq != null)
                {
                    model.EQId = eq.EQId;
                    model.cEQCode = eq.cEQCode;
                    model.cEQName = eq.cEQName;
                    model.cEQCCode = eq.cEQCCode;
                    model.cEQCName = eq.cEQCName;
                }
                model.dDate = DateTime.Now.Date;
                model.cMaker = Information.UserInfo.cUser_Name;
                lblModuleTitle.Text = "���� - " + this.lblModuleTitle.Text;
            }
            else if(opState == OpState.Update)
            {
                model = dal.Get(AutoId);
                this.oldDate = model.dDate;
                lblModuleTitle.Text = "�༭ - " + this.lblModuleTitle.Text;
            }

            //UIControl.SetStatus(tab_Main.AttachedControl, opState);
            UIBinding<MaintenancePlans>.UIDataBinding(tab_Main.AttachedControl, model);

            #endregion
        }

        private void Save(object sender, EventArgs e)
        {
            #region ����ģ�ߵ���

            this.numericUpDown1_ValueChanged(null, null);

            if (string.IsNullOrEmpty(model.cEQCode))
            {
                throw new Exception("�豸���벻��Ϊ��!");
            }
            else if (model.stopHours <= 0)
            {
                throw new Exception("ͣ��ʱ�䲻��С�ڵ���0!");
            }

            if (opState == OpState.Add)
            {
                if (dal.Exists(model.EQId, model.dDate))
                {
                    throw new Exception("��ǰ����: " + model.dDate.ToShortDateString() + " �Ѵ���ά���ƻ�!");
                }
                dal.Add(model);
            }
            else if (opState == OpState.Update)
            {
                if (model.dDate != oldDate && dal.Exists(model.EQId, model.dDate))
                {
                    throw new Exception("��ǰ����: " + model.dDate.ToShortDateString() + " �Ѵ���ά���ƻ�!");
                }
                dal.Update(model);
            }

            this.DialogResult = DialogResult.OK; 
            #endregion
        }

        private void RefEquipment(object sender, EventArgs e)
        {
            #region ����--�豸����
            FmREquipment frm = new FmREquipment();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.txtr_cEQCode.Text = frm.Results[0].cEQCode;
                this.txtr_cEQName.Text = frm.Results[0].cEQName;
                this.txtr_iHours.Text = frm.Results[0].workHours.ToString();
                this.model.EQId = frm.Results[0].EQId;
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

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            decimal a = (decimal)numericUpDown1.Value;
            if(a > model.iHours)
            {
                MsgBox.ShowInfoMsg("ͣ��ʱ�䲻�ܴ����չ���Ч��!");
                numericUpDown1.Value = 0;
                return;
            }
            model.workHours = model.iHours - a;
        }
    }
}