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
    using U8Ext.Ref;
    using Component;
    using Common;

    public partial class FmRouting : DevComponents.DotNetBar.OfficeForm
    {

        public FmRouting()
        {
            InitializeComponent();

            this.Text = this.lblModuleTitle.Text;
            this.Load += FormLoad;
            this.BtnSave.Click += Save;

            this.opState = OpState.Browse;
        }

        private string oldCode = "";
        private OpState opState;
        private Routing model;
        private RoutingDAL dal = new RoutingDAL();


        private void InitGrid()
        {
            Grid.AutoGenerateColumns = false;
            //Grid.ReadOnly = true;
            Grid.RowHeadersVisible = false;
            //Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Grid.AllowUserToAddRows = false;

            DataGridHelper.AddTextBoxColumn(Grid, "OpSeq", "工序序号").ReadOnly = true;
            DataGridHelper.AddTextBoxColumn(Grid, "OpCode", "工序编码").ReadOnly = true;
            DataGridHelper.AddTextBoxColumn(Grid, "OpName", "工序名称", 100).ReadOnly = true;

            Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void InitGridList()
        {
            GridList.AutoGenerateColumns = false;
            //Grid.ReadOnly = true;
            GridList.RowHeadersVisible = false;
            //Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridList.AllowUserToAddRows = false;

            DataGridHelper.AddTextBoxColumn(GridList, "RoutingCode", "工艺路线编码", 120).ReadOnly = true;
            DataGridHelper.AddTextBoxColumn(GridList, "RoutingName", "工艺路线名称", 120).ReadOnly = true;

            GridList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void RefreshUI()
        {
            if (model != null)
            {
                UIBinding<Routing>.UIDataBinding(panelEx2, model);
                Grid.DataSource = model.DtRoutings;
            }

            UIControl.SetStatus(Head_Bar, panelEx1, opState);          
        }

        private void SetOpSeq(DataTable dt)
        {
            var i = 10010;

            foreach(DataRow r in dt.Rows)
            {
                if (r.RowState == DataRowState.Deleted)
                    continue;

                r.BeginEdit();
                r["OpSeq"] = i.ToString().Substring(1);
                r.EndEdit();
                i = i + 10;
            }
        }

        private void FormLoad(object sender, EventArgs e)
        {
            #region 加载主窗体事件

            InitGrid();
            InitGridList();

            GridList.DataSource = dal.GetTable(null);

            RefreshUI();

            #endregion
        }

        private void Save(object sender, EventArgs e)
        {
            #region 保存设备档案

            Grid.EndEdit();
           

            if (string.IsNullOrEmpty(model.RoutingCode))
            {
                throw new Exception("工艺路线编码不能为空!");
            }
            else if (string.IsNullOrEmpty(model.RoutingName))
            {
                throw new Exception("工艺路线名称不能为空!");
            }
            else if(model.DtRoutings.Rows.Count < 1)
            {
                throw new Exception("表体不能为空!");
            }

            model.DtRoutings.Rows[Grid.CurrentRow.Index].EndEdit();

            if (opState == OpState.Add)
            {
                if (dal.Exists(model.RoutingCode))
                {
                    throw new Exception("已存在工艺路线编码: " + model.RoutingCode);
                }
                dal.Add(model);
            }
            else if (opState == OpState.Update)
            {
                if (model.RoutingCode != oldCode && dal.Exists(model.RoutingCode))
                {
                    throw new Exception("已存在工艺路线编码: " + model.RoutingCode);
                }
                dal.Update(model);
            }

            this.opState = OpState.Browse;
            this.RefreshUI();

            this.GridList.DataSource = dal.GetTable(null);
            
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

        private void btn_AddLine_Click(object sender, EventArgs e)
        {
            IRefDAL2 dal = new OperationDAL(Information.UserInfo.ConnU8);
            RefForm2 frm = new RefForm2(dal);
            if(frm.ShowDialog() == DialogResult.OK)
            {
                var r = model.DtRoutings.NewRow();
                r["operationId"] = frm.rows[0]["operationId"];
                r["OpCode"] = frm.rows[0]["OpCode"];
                r["OpName"] = frm.rows[0]["OpName"];
                model.DtRoutings.Rows.Add(r);
                this.SetOpSeq(model.DtRoutings);
            }
        }

        private void btn_DelLine_Click(object sender, EventArgs e)
        {
            Grid.Rows.Remove(Grid.CurrentRow);
            this.SetOpSeq(model.DtRoutings);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if(this.model == null)
            {
                throw new Exception("没有选择编辑记录!");
            }
            opState = OpState.Update;
            RefreshUI();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            this.opState = OpState.Add;
            this.model = dal.New();
            this.RefreshUI();

        }

        private void GridList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(GridList.DataSource == null)
            {
                return;
            }
            else if(e.RowIndex >= 0)
            {
                var dt = GridList.DataSource as DataTable;
                int id = Convert.ToInt32(dt.Rows[e.RowIndex]["RoutingId"]);
                this.model = dal.Get(id);
                this.oldCode = model.RoutingCode;
                this.opState = OpState.Browse;
                this.RefreshUI();
            }
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            var index = GridList.CurrentRow.Index;

            if(index >= 0)
            {

                if (MsgBox.ShowYesNoMsg("确定删除选中行?") == DialogResult.Yes)
                {
                    var dt = GridList.DataSource as DataTable;
                    int id = Convert.ToInt32(dt.Rows[index]["RoutingId"]);
                    dal.Delete(id);
                    this.GridList.DataSource = dal.GetTable(null);
                }
               
            }
        }
    }
}