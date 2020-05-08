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
        /// ��ǰҵ�����(�������޸ģ�ɾ��)
        /// </summary>
        private OpState opState { get; set; }


        protected void GetData() { }

        protected void Save() { }

        private void FormLoad(object sender, EventArgs e)
        {
            #region �����������¼�

            this.tab_Main.Text = this.lblModuleTitle.Text;
            UIControl.SetTextBoxState(tab_Main.AttachedControl);


            if(this.opState == OpState.Add)
                this.Text = "���� - " + this.lblModuleTitle.Text;
            else if (this.opState == OpState.Update)
                this.Text = "�༭ - " + this.lblModuleTitle.Text;       

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
            #region ����
            this.Save(); 
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
    }
}