using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NDF
{
    using NDF.DAL;

    public partial class FmUserRole : Form
    {
        public FmUserRole()
        {
            InitializeComponent();

            InitDGTabStyle();
        }

        public FmUserRole(int nUserId, string strUserName) : this()
		{
            this.Text               = "用户角色 - " + strUserName;
            this.lblUserName.Text   = "用户名: " + strUserName;

			this.m_nUserId			= nUserId;
		}

        private int m_nUserId = 0;

        /// <summary>
        /// 业务数据视图
        /// </summary>
        private DataView m_dvM = null;
        /// <summary>
        /// 线程：获取业务数据
        /// </summary>
        private Thread m_trdGetBusiData = null;
        /// <summary>
        /// 线程：更新(修改)业务数据
        /// </summary>
        private Thread m_trdUpdBusiData = null;
        /// <summary>
        /// 代理：界面更新方法
        /// </summary>
        private delegate void m_dgtUIMethod();
        /// <summary>
        /// 代理：界面更新方法
        /// </summary>
        protected delegate void m_dgtUICursor(Cursor curosr);
        /// <summary>
        /// 代理：消息显示
        /// </summary>
        private delegate void m_dgtUIMsgShow(string strMsg);

        #region 表样式
        protected void InitDGTabStyle()
        {
            this.dgM.TableStyles.Clear();

            DataGridTableStyle dgTS = new DataGridTableStyle();
            dgTS.AllowSorting = false;
            dgTS.MappingName = "UserRole";

            DataGridTextBoxColumn dgColTextBox = null;
            DataGridDateTimePickerColumn dgColdtPicker = null;
            DataGridBoolColumn dgColBool = null;

            dgColBool = new DataGridBoolColumn();
            dgColBool.Alignment = HorizontalAlignment.Center;
            dgColBool.HeaderText = "是否授予";
            dgColBool.ReadOnly = false;
            dgColBool.AllowNull = false;
            dgColBool.NullValue = 0;
            dgColBool.Width = 65;
            dgColBool.TrueValue = 1;
            dgColBool.FalseValue = 0;
            dgColBool.MappingName = "RoleGrant";
            dgTS.GridColumnStyles.Add(dgColBool);

            dgColTextBox = new DataGridNoActiveTextBoxColumn();
            dgColTextBox.HeaderText = "角色编码";
            dgColTextBox.ReadOnly = true;
            dgColTextBox.Width = 120;
            dgColTextBox.MappingName = "RoleCode";
            dgColTextBox.NullText = string.Empty;
            dgTS.GridColumnStyles.Add(dgColTextBox);

            dgColTextBox = new DataGridNoActiveTextBoxColumn();
            dgColTextBox.HeaderText = "角色名称";
            dgColTextBox.ReadOnly = true;
            dgColTextBox.Width = 150;
            dgColTextBox.MappingName = "RoleName";
            dgColTextBox.NullText = string.Empty;
            dgTS.GridColumnStyles.Add(dgColTextBox);

            dgColdtPicker = new DataGridDateTimePickerColumn();
            dgColdtPicker.HeaderText = "gDate";
            dgColdtPicker.Width = 0;
            dgColdtPicker.MappingName = "gDate";
            dgColdtPicker.NullText = DateTime.Now.Date.ToShortDateString();
            dgTS.GridColumnStyles.Add(dgColdtPicker);

            this.dgM.TableStyles.Add(dgTS);
        }
        #endregion

        private void GetBusiData()
        {
            try
            {
                while (!this.IsHandleCreated) { ; }
                this.BeginInvoke(new m_dgtUICursor(this.UICursor), new object[] { Cursors.WaitCursor });

                string strSql = "select * from V_UserRole where UserID = " + m_nUserId;
                this.m_dvM = DbHelperSQL.Query(strSql).Tables[0].DefaultView;
                this.BeginInvoke(new m_dgtUIMethod(this.UIMUpd));
            }
            catch (Exception ex)
            {
                MsgBox.ShowInfoMsg(ex.ToString());
            }
            finally
            {
                this.BeginInvoke(new m_dgtUICursor(this.UICursor), new object[] { Cursors.Default });
            }
        }

        private void UpdBusiData()
        {
            try
            {
                while (!this.IsHandleCreated) { ; }
                this.BeginInvoke(new m_dgtUICursor(this.UICursor), new object[] { Cursors.WaitCursor });

                while (!this.IsHandleCreated) { ; }
                this.Invoke(new m_dgtUIMethod(this.UIGetMainData));

                this.m_bObj.UpdateBusiData();
            }
            finally
            {
                while (!this.IsHandleCreated) { ; }
                this.BeginInvoke(new m_dgtUICursor(this.UICursor), new object[] { Cursors.Default });
            }

            while (!this.IsHandleCreated) { ; }
            this.BeginInvoke(new m_dgtUIMsgShow(this.UIShowMsgBox), new object[] { this.m_bObj.BusiMsg[1] });

            if (this.m_bObj.BusiMsg[0] == "1") GetBusiData();
        }

        private void UIMUpd()
        {
            this.dgM.Enabled = true;
            this.dgM.DataSource = this.m_dvM;
            this.m_dvM.AllowNew = this.m_dvM.AllowDelete = this.m_dvM.AllowEdit = false;

            this.btnSave.Enabled = this.dgM.CurrentRowIndex > -1;
        }

        private void UIShowMsgBox(string strMsg)
        {
            Form fmP = this; Control c = this;
            while (true) { c = c.Parent; if (c != null && c is Form) fmP = (Form)c; if (c == null) break; }
            if (fmP != null) fmP.Activate();
            MsgBox.ShowInfoMsg2(strMsg);
        }

        protected virtual void UICursor(Cursor cursor)
        {
            this.Cursor = cursor;
        }

        private void UIGetMainData()
        {
            DataTable dt = new DataTable("UserRole");
            dt.Columns.Add(new DataColumn("UserId", Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("RoleId", Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("RoleGrant", Type.GetType("System.Int32")));

            DataRow dr = null;
            for (int i = 0; i < this.m_dvM.Count; i++)
            {
                this.m_dvM[i].Row.EndEdit();

                dr = dt.NewRow();
                dr["UserId"] = this.m_nUserId;
                dr["RoleId"] = (int)this.m_dvM[i]["RoleId"];
                dr["RoleGrant"] = (int)this.m_dvM[i]["RoleGrant"];
                dt.Rows.Add(dr);
            }

            if (this.m_bObj.BusiData != null)
                this.m_bObj.BusiData.Tables.Clear();
            else
                this.m_bObj.BusiData = new DataSet();

            this.m_bObj.BusiData.Tables.Add(dt);
        }

        private void FmUserRole_Load(object sender, System.EventArgs e)
        {
            try
            {
                if (this.m_trdGetBusiData != null && this.m_trdGetBusiData.IsAlive)
                    this.m_trdGetBusiData.Abort();
            }
            catch { }
            finally { this.m_trdGetBusiData = null; }

            this.m_trdGetBusiData = new Thread(new ThreadStart(this.GetBusiData));
            this.m_trdGetBusiData.Start();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (this.m_trdUpdBusiData != null && this.m_trdUpdBusiData.IsAlive)
            {
                MsgBox.ShowInfoMsg2("应用程序后台正忙，请稍后再试！"); return;
            }
            this.m_trdUpdBusiData = new Thread(new ThreadStart(this.UpdBusiData));
            this.m_trdUpdBusiData.Start();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgM_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.dgM.CurrentCell.ColumnNumber == Utility.DataGridColumnNumber(this.dgM, "RoleGrant") &&
                this.dgM.HitTest(e.X, e.Y).Type == DataGrid.HitTestType.Cell)
            {
                if (e.Button == MouseButtons.Left && e.Clicks == 2)
                {
                    this.m_dvM.AllowEdit = true;
                    if (this.m_dvM[this.dgM.CurrentRowIndex]["RoleGrant"].ToString() == "1")
                        this.m_dvM[this.dgM.CurrentRowIndex]["RoleGrant"] = 0;
                    else
                        this.m_dvM[this.dgM.CurrentRowIndex]["RoleGrant"] = 1;
                    this.m_dvM.AllowEdit = false;
                }
            }
        }

        private void btnSelAll_Click(object sender, System.EventArgs e)
        {
            if (this.dgM.CurrentRowIndex > -1)
            {
                this.m_dvM.AllowEdit = true;
                for (int i = 0; i < this.m_dvM.Count; i++)
                {
                    this.m_dvM[i].Row.BeginEdit();
                    this.m_dvM[i]["RoleGrant"] = 1;
                    this.m_dvM[i].Row.EndEdit();
                }
                this.m_dvM.AllowEdit = false;
            }
        }

        private void btnNoSelAll_Click(object sender, System.EventArgs e)
        {
            if (this.dgM.CurrentRowIndex > -1)
            {
                this.m_dvM.AllowEdit = true;
                for (int i = 0; i < this.m_dvM.Count; i++)
                {
                    this.m_dvM[i].Row.BeginEdit();
                    this.m_dvM[i]["RoleGrant"] = 0;
                    this.m_dvM[i].Row.EndEdit();
                }
                this.m_dvM.AllowEdit = false;
            }
        }
    }
}