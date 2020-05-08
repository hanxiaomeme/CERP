using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LanyunMES.UIBase
{

    public abstract partial class FmBILL : DevComponents.DotNetBar.OfficeForm
    {
        public FmBILL(OpState operation)
        {
            InitializeComponent();
            this.opState = operation;
        }

        protected OpState opState = OpState.Browse;

        protected int curId = 0;
 

        /// <summary>
        /// 加载数据
        /// </summary>
        protected abstract void Get();

        protected abstract void Add();

        protected abstract void Delete();

        /// <summary>
        /// 保存
        /// </summary>
        protected abstract void Save();

        /// <summary>
        /// 保存校验
        /// </summary>
        protected abstract bool SaveCheck();

        protected abstract void AddRow();

        protected abstract void DeleteRow();




        //===========================================================

        private void FmBILL_Load(object sender, EventArgs e)
        {
            UIControl.SetStatus(bar1, bar2, pnlMain, gridView1, this.opState);
            this.Get();
        }

        //编辑
        private void Btn_Edit_Click(object sender, EventArgs e)
        {
            this.opState = OpState.Update;
            UIControl.SetStatus(bar1, bar2, pnlMain, gridView1, OpState.Update);
        }

        //第一条记录
        private void Btn_first_Click(object sender, EventArgs e)
        {
            //this.curId = bllM.GetID(Navtion.first, 0);
            //this.LoadData(curId);
        }

        //上一条记录
        private void Btn_previous_Click(object sender, EventArgs e)
        {
            //int pid = bllM.GetID(Navtion.previous, curId);
            //if (pid == 0)
            //{
            //    MsgBox.ShowInfoMsg("已经是第一条记录！");
            //}
            //else
            //{
            //    this.curId = pid;
            //    this.LoadData(curId);
            //}
        }

        //下一条记录
        private void Btn_next_Click(object sender, EventArgs e)
        {
            //int nid = bllM.GetID(Navtion.next, curId);
            //if (nid == 0)
            //{
            //    MsgBox.ShowInfoMsg("已经是最后一条记录！");
            //}
            //else
            //{
            //    this.curId = nid;
            //    this.LoadData(curId);
            //}
        }

        //最后一条记录
        private void Btn_last_Click(object sender, EventArgs e)
        {
            //this.curId = bllM.GetID(Navtion.last, 0);
            //this.LoadData(curId);
        }

        //新增
        private void Btn_Add_Click(object sender, EventArgs e)
        {
            this.opState = OpState.Add;
            UIControl.SetStatus(bar1, bar2, pnlMain, gridView1, OpState.Add);
            this.Add();
        }

        //取消
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.opState = OpState.Browse;
            UIControl.SetStatus(bar1, bar2, pnlMain, gridView1, OpState.Browse);
            //this.LoadData(curId);
        }

        //保存
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if (this.SaveCheck())
            {
                this.Save();
                this.opState = OpState.Browse;
            }
        }

        private void Btn_Addline_Click(object sender, EventArgs e)
        {
            this.AddRow();
        }

        private void Btn_Delline_Click(object sender, EventArgs e)
        {
            this.DeleteRow();
        }
    }
}
