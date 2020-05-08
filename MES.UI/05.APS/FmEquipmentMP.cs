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
        private DateTime oldDate;   //修改前日期
        private Equipment eq;       //设备党产
        private OpState opState;
        private MaintenancePlans model;
        private MaintenancePlansDAL dal = new MaintenancePlansDAL();


        private void FormLoad(object sender, EventArgs e)
        {
            #region 加载主窗体事件

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
                lblModuleTitle.Text = "新增 - " + this.lblModuleTitle.Text;
            }
            else if(opState == OpState.Update)
            {
                model = dal.Get(AutoId);
                this.oldDate = model.dDate;
                lblModuleTitle.Text = "编辑 - " + this.lblModuleTitle.Text;
            }

            //UIControl.SetStatus(tab_Main.AttachedControl, opState);
            UIBinding<MaintenancePlans>.UIDataBinding(tab_Main.AttachedControl, model);

            #endregion
        }

        private void Save(object sender, EventArgs e)
        {
            #region 保存模具档案

            this.numericUpDown1_ValueChanged(null, null);

            if (string.IsNullOrEmpty(model.cEQCode))
            {
                throw new Exception("设备编码不能为空!");
            }
            else if (model.stopHours <= 0)
            {
                throw new Exception("停机时间不能小于等于0!");
            }

            if (opState == OpState.Add)
            {
                if (dal.Exists(model.EQId, model.dDate))
                {
                    throw new Exception("当前日期: " + model.dDate.ToShortDateString() + " 已存在维护计划!");
                }
                dal.Add(model);
            }
            else if (opState == OpState.Update)
            {
                if (model.dDate != oldDate && dal.Exists(model.EQId, model.dDate))
                {
                    throw new Exception("当前日期: " + model.dDate.ToShortDateString() + " 已存在维护计划!");
                }
                dal.Update(model);
            }

            this.DialogResult = DialogResult.OK; 
            #endregion
        }

        private void RefEquipment(object sender, EventArgs e)
        {
            #region 参照--设备档案
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

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            decimal a = (decimal)numericUpDown1.Value;
            if(a > model.iHours)
            {
                MsgBox.ShowInfoMsg("停机时间不能大于日工作效率!");
                numericUpDown1.Value = 0;
                return;
            }
            model.workHours = model.iHours - a;
        }
    }
}