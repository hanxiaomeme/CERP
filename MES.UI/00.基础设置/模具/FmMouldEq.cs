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

    public partial class FmMouldEq : DevComponents.DotNetBar.OfficeForm
    {

        private FmMouldEq()
        {
            InitializeComponent();

            this.Text = tab_Main.Text = this.lblModuleTitle.Text;
            this.Load += FormLoad;
            this.btn_AddLine.Click += RefEquipment;
            this.Btn_AddLineCls.Click += RefEquipmentClass;
            this.btn_DelLine.Click += DeleteLine;
            this.btn_Save.Click += Save;
        }

        public FmMouldEq(string MId) :this()
        {
            this.MId = MId;
        }

        private string MId;
        private OpState opState = OpState.Update;
        private Mould model;
        private MouldDAL dal = new MouldDAL();


        private void FormLoad(object sender, EventArgs e)
        {
            #region 加载主窗体事件
            
            model = dal.Get(MId);

            this.InitColumns();
            UIBinding<Mould>.UIDataBinding(panelEx1, model);

            Grid.DataSource = model.dtEquipment.DefaultView;

            model.dtEquipment.ColumnChanging += DtEquipment_ColumnChanging;

            #endregion
        }
        private void InitColumns()
        {
            Grid.AutoGenerateColumns = false;
            //Grid.ReadOnly = true;
            Grid.RowHeadersVisible = false;
            //Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Grid.AllowUserToAddRows = false;

            DataGridHelper.AddTextBoxColumn(Grid, "bClassDesc", "类别");           
            DataGridHelper.AddTextBoxColumn(Grid, "cEQCode", "编码", 100).ReadOnly = true;
            DataGridHelper.AddTextBoxColumn(Grid, "cEQName", "名称", 100).ReadOnly = true;
            DataGridHelper.AddTextBoxColumn(Grid, "cEQCName", "设备分类", 100).ReadOnly = true;
            DataGridHelper.AddTextBoxColumn(Grid, "iStep", "节拍/S", 80);
            DataGridViewTextBoxColumn col = DataGridHelper.AddTextBoxColumn(Grid, "capacity", "产能", 80);
            col.ReadOnly = true;
            col.DefaultCellStyle.Format = "0.00";

            DataGridHelper.AddTextBoxColumn(Grid, "iOrder", "优先级", 70);

            Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void Save(object sender, EventArgs e)
        {
            this.Grid.EndEdit();
            if(string.IsNullOrEmpty(model.cMCode))
            {
                throw new Exception("模具不能为空!");
            }
            foreach(DataRow r in model.dtEquipment.Rows)
            {
                if(r["iStep"] == DBNull.Value || Convert.ToDecimal(r["iStep"]) <= 0)
                {
                    throw new Exception("节拍不能为空!");
                }
            }

            dal.AddEq(MId, model.dtEquipment);

            this.DialogResult = DialogResult.OK;
        }

        private void RefEquipment(object sender, EventArgs e)
        {
            FmREquipment frm = new FmREquipment(true);
            if(frm.ShowDialog() == DialogResult.OK)
            {
                foreach (Equipment eq in frm.Results)
                {
                    foreach (DataRow r in model.dtEquipment.Rows)
                    {
                        if ((int)r["EQId"] == eq.EQId)
                        {
                            throw new Exception("设备: " + eq.cEQName + " 已存在!");
                        }
                    }

                    var row = model.dtEquipment.NewRow();
                    row["MID"] = this.MId;
                    row["bClass"] = false;
                    row["bClassDesc"] = "设备明细";
                    row["EQId"] = eq.EQId;
                    row["cEQCode"] = eq.cEQCode;
                    row["cEQName"] = eq.cEQName;
                    row["cEQCName"] = eq.cEQCName;
                    row["iOrder"] = 5;
                    model.dtEquipment.Rows.Add(row);
                }
            }
        }

        private void RefEquipmentClass(object seder, EventArgs e)
        {
            ITreeClassDAL dal = new EquipmentClassDAL();
            FmRClassInfo frm = new FmRClassInfo(dal, "设备分类");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var result = frm.Result as EquipmentClass;
                foreach (DataRow r in model.dtEquipment.Rows)
                {
                    if ((bool)r["bClass"] && Convert.ToInt32(r["EQId"]) == result.EQCId)
                    {
                        throw new Exception("设备分类: " + result.Code + " 已存在!");
                    }
                }

                var row = model.dtEquipment.NewRow();
                row["MID"] = this.MId;
                row["bClass"] = true;
                row["bClassDesc"] = "设备分类";
                row["EQId"] = result.EQCId;
                row["cEQCode"] = result.Code;
                row["cEQName"] = result.Name;
                row["iOrder"] = 5;
                model.dtEquipment.Rows.Add(row);
            }
        }

        private void DeleteLine(object sender, EventArgs e)
        {
            DataRow row = model.dtEquipment.Rows[Grid.CurrentRow.Index];
            model.dtEquipment.Rows.Remove(row);
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

        private void btn_up_Click(object sender, EventArgs e)
        {
            DataGridHelper.MoveRow(Grid, MoveState.previous);
        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            DataGridHelper.MoveRow(Grid, MoveState.next);
        }


        private void DtEquipment_ColumnChanging(object sender, DataColumnChangeEventArgs e)
        {
            if(e.Column.ColumnName == "iStep")
            {
                if(e.ProposedValue != null && Convert.ToDecimal(e.ProposedValue) > 0)
                {
                    e.Row["capacity"] = (3600 / Convert.ToDecimal(e.ProposedValue)) * model.Points;
                }
            }
        }
    }
}