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

    public partial class FmEquipment : DevComponents.DotNetBar.OfficeForm
    {

        private FmEquipment()
        {
            InitializeComponent();

            this.Text = tab_Main.Text = this.lblModuleTitle.Text;
            this.Load += FormLoad;
            //this.txtr_OpCode.ButtonCustomClick += RefOperation;
            this.txtr_cEQCName.ButtonCustomClick += RefEquipmentCls;
            this.btn_Save.Click += Save;
        }

        public FmEquipment(EquipmentClass modelC, OpState op = OpState.Add) : this()
        {
            this.opState = op;
            this.modelC = modelC;
        }

        public FmEquipment(int EQId, OpState op = OpState.Update) :this()
        {
            this.opState = op;
            this.EQId = EQId;
        }

        private int EQId;
        private string oldEQCode = "";
        private OpState opState;
        private Equipment model;
        private EquipmentClass modelC;
        private EquipmentDAL dal = new EquipmentDAL();


        private void InitGrid()
        {
            Grid.AutoGenerateColumns = false;
            //Grid.ReadOnly = true;
            Grid.RowHeadersVisible = false;
            //Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Grid.AllowUserToAddRows = false;

            DataGridHelper.AddTextBoxColumn(Grid, "OpCode", "�������").ReadOnly = true;
            DataGridHelper.AddTextBoxColumn(Grid, "OpName", "��������", 100).ReadOnly = true;
            var col = DataGridHelper.AddTextBoxColumn(Grid, "cycleTime", "����/min", 80);
            col.DefaultCellStyle.Format = "0.00";

            Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void FormLoad(object sender, EventArgs e)
        {
            #region �����������¼�

            InitGrid();

            if (opState == OpState.Add)
            {
                model = new Equipment();
                if (modelC != null)
                {
                    model.EQCId = modelC.EQCId;
                    model.cEQCCode = modelC.Code;
                    model.cEQCName = modelC.Name;
                    model.cMaker = Information.UserInfo.cUser_Name;
                    model.dtOperations = dal.GetDTable(0);
                }
                lblModuleTitle.Text = "���� - " + this.lblModuleTitle.Text;
            }
            else if(opState == OpState.Update)
            {
                model = dal.Get(EQId);
                model.cModifier = Information.UserInfo.cUser_Name;
                oldEQCode = model.cEQCode;
                lblModuleTitle.Text = "�༭ - " + this.lblModuleTitle.Text;
            }

            UIControl.SetStatus(tab_Main.AttachedControl, opState);

            UIBinding<Equipment>.UIDataBinding(panelEx1, model);

            Grid.DataSource = model.dtOperations;

            #endregion
        }

        private void Save(object sender, EventArgs e)
        {
            #region �����豸����

            Grid.EndEdit();
            model.dtOperations.Rows[Grid.CurrentRow.Index].EndEdit();

            if (string.IsNullOrEmpty(model.cEQCode))
            {
                throw new Exception("�豸���벻��Ϊ��!");
            }
            else if (string.IsNullOrEmpty(model.cEQName))
            {
                throw new Exception("�豸���Ʋ���Ϊ��!");
            }
            else if (model.EQCId == 0)
            {
                throw new Exception("�豸���಻��Ϊ��!");
            }
            //else if (model.operationId == 0)
            //{
            //    throw new Exception("������Ϊ��!");
            //}

            foreach(DataRow r in model.dtOperations.Rows)
            {
                if (r["cycleTime"].ToString() == "" || Convert.ToDecimal( r["cycleTime"]) <= 0)
                {
                    throw new Exception("���Ĳ���Ϊ��,����С����0!");
                }
            }

            if (opState == OpState.Add)
            {
                if (dal.Exists(model.cEQCode))
                {
                    throw new Exception("�Ѵ����豸����: " + model.cEQCode);
                }
               var id =  dal.Add(model);
            }
            else if (opState == OpState.Update)
            {
                if (model.cEQCode != oldEQCode && dal.Exists(model.cEQCode))
                {
                    throw new Exception("�Ѵ����豸����: " + model.cEQCode);
                }
                dal.Update(model);
            }

            this.DialogResult = DialogResult.OK;
            
            #endregion
        }

        private void RefOperation(object sender, EventArgs e)
        {
            #region ����--���򵵰�
            //IRefDAL2 refdal = new OperationDAL(Information.UserInfo.ConnU8);
            //RefForm2 frm = new RefForm2(refdal);
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    model.operationId = (int)frm.rows[0]["operationId"];
            //    txtr_OpCode.Text = frm.rows[0]["OpCode"].ToString();
            //    txtr_OpName.Text = frm.rows[0]["OpName"].ToString();
            //} 
            #endregion
        }

        private void RefEquipmentCls(object sender, EventArgs e)
        {
            #region ����--�豸����
            var dal = new EquipmentClassDAL();
            FmRClassInfo frm = new FmRClassInfo(dal, "�豸����");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var result = frm.Result as EquipmentClass;
                (sender as TextBox).Text = result.Name;
                model.EQCId = result.EQCId;
                model.cEQCCode = result.Code;
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

        private void btn_AddLine_Click(object sender, EventArgs e)
        {
            IRefDAL2 dal = new OperationDAL(Information.UserInfo.ConnU8);
            RefForm2 frm = new RefForm2(dal);
            if(frm.ShowDialog() == DialogResult.OK)
            {
                var r = model.dtOperations.NewRow();
                r["operationId"] = frm.rows[0]["operationId"];
                r["OpCode"] = frm.rows[0]["OpCode"];
                r["OpName"] = frm.rows[0]["OpName"];
                r["cycleTime"] = 0;
                model.dtOperations.Rows.Add(r);
            }
        }

        private void btn_DelLine_Click(object sender, EventArgs e)
        {
            Grid.Rows.Remove(Grid.CurrentRow);
        }
    }
}