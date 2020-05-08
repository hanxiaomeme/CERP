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
    using Common;
    using DAL;
    using Component;

    public partial class FmMould : DevComponents.DotNetBar.OfficeForm
    {

        private FmMould()
        {
            InitializeComponent();

            this.Text = tab_Main.Text = this.lblModuleTitle.Text;
            this.Load += FormLoad;
            this.txtr_cMCName.ButtonCustomClick += RefMouldClass;
            this.btn_Save.Click += Save;
        }

        public FmMould(MouldClass modelC, OpState op = OpState.Add) : this()
        {
            this.opState = op;
            this.modelC = modelC;
        }

        public FmMould(string MId, OpState op = OpState.Update) :this()
        {
            this.opState = op;
            this.MId = MId;
        }

        private string MId;
        private string oldMCode = "";
        private OpState opState;
        private Mould model;
        private MouldClass modelC;
        private MouldDAL dal = new MouldDAL();


        private void FormLoad(object sender, EventArgs e)
        {
            #region 加载主窗体事件

            if (opState == OpState.Add)
            {
                model = new Mould();
                model.dtEquipment = dal.GetEqDetails("");
                model.MCId = modelC.MCId;
                model.cMCCode = modelC.Code;
                model.cMCName = modelC.Name;
                model.cMaker = Information.UserInfo.cUser_Name;
                lblModuleTitle.Text = "新增 - " + this.lblModuleTitle.Text;
            }
            else if(opState == OpState.Update)
            {
                model = dal.Get(MId);
                model.cModifier = Information.UserInfo.cUser_Name;
                oldMCode = model.cMCode;
                lblModuleTitle.Text = "编辑 - " + this.lblModuleTitle.Text;
            }

            UIControl.SetStatus(tab_Main.AttachedControl, opState);
            UIBinding<Mould>.UIDataBinding(tab_Main.AttachedControl, model);

            #endregion
        }

        private void Save(object sender, EventArgs e)
        {
            #region 保存模具档案
            if (string.IsNullOrEmpty(model.cMCode))
            {
                throw new Exception("模具编码不能为空!");
            }
            else if (string.IsNullOrEmpty(model.cMName))
            {
                throw new Exception("模具名称不能为空!");
            }
            else if (model.MCId == 0)
            {
                throw new Exception("模具分类不能为空!");
            }
            else if (model.Points == 0)
            {
                throw new Exception("穴数不能为空!");
            }

            if (opState == OpState.Add)
            {
                if (dal.Exists(model.cMCode))
                {
                    throw new Exception("已存在模具编码: " + model.cMCode);
                }
                dal.Add(model);
            }
            else if (opState == OpState.Update)
            {
                if (model.cMCode != oldMCode && dal.Exists(model.cMCode))
                {
                    throw new Exception("已存在模具编码: " + model.cMCode);
                }
                dal.Update(model);
            }

            this.DialogResult = DialogResult.OK; 
            #endregion
        }

        private void RefMouldClass(object sender, EventArgs e)
        {
            #region 参照--模具分类
            ITreeClassDAL dal = new MouldClassDAL();
            FmRClassInfo frm = new FmRClassInfo(dal, "模具分类");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var result = frm.Result as MouldClass;
                (sender as TextBox).Text = result.Name;
                model.MCId = result.MCId;
                model.cMCCode = result.Code;
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
    }
}