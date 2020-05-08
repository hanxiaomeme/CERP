using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using Component;

namespace LanyunMES.UIBase
{
    public partial class FmBIU : DevComponents.DotNetBar.OfficeForm
    {
        public FmBIU(OpState opState)
        {
            InitializeComponent();
            this.Load += FormLoad;
            this.opState = opState;
        }

        /// <summary>
        /// 当前业务操作(新增，修改，删除)
        /// </summary>
        private OpState opState { get; set; }


        protected void GetData() { }

        protected void Save() { }

        private void FormLoad(object sender, EventArgs e)
        {
            #region 加载主窗体事件

            this.tab_Main.Text = this.lblModuleTitle.Text;
            UIControl.SetTextBoxState(tab_Main.AttachedControl);


            if(this.opState == OpState.Add)
                this.Text = "新增 - " + this.lblModuleTitle.Text;
            else if (this.opState == OpState.Update)
                this.Text = "编辑 - " + this.lblModuleTitle.Text;       

            new Thread(()=> {
                this.BeginInvoke(new Action(() =>
                {
                    this.GetData();
                }));
            }).Start();

            #endregion
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            #region 保存
            this.Save(); 
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