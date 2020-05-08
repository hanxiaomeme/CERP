using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NDF
{
    public partial class FmSysIOLog : Eastar.FmQB2
    {
        public FmSysIOLog()
        {
            InitializeComponent();

            this.m_strModuleName = "SysIOLog";
        }

        protected override void FmQB_Load(object sender, EventArgs e)
        {
            base.FmQB_Load(sender, e);
        }

        #region 表样式
        protected override void InitDGTabStyle()
        {
            this.dgM.TableStyles.Clear();

            DataGridTableStyle dgTS = new DataGridTableStyle();
            dgTS.AllowSorting       = false;
            dgTS.MappingName        = "t";

            DataGridTextBoxColumn dgColTextBox = null;
            DataGridDateTimePickerColumn dgColdtPicker = null;

            dgColTextBox = new DataGridNoActiveTextBoxColumn();
            dgColTextBox.HeaderText = "标识号";
            dgColTextBox.Alignment = HorizontalAlignment.Center;
            dgColTextBox.ReadOnly = true;
            dgColTextBox.Width = 100;
            dgColTextBox.MappingName = "AutoId";
            dgColTextBox.NullText = string.Empty;
            dgTS.GridColumnStyles.Add(dgColTextBox);

            dgColTextBox = new DataGridNoActiveTextBoxColumn();
            dgColTextBox.HeaderText = "日期";
            dgColTextBox.Alignment = HorizontalAlignment.Center;
            dgColTextBox.ReadOnly = true;
            dgColTextBox.Width = 80;
            dgColTextBox.MappingName = "LDate";
            dgColTextBox.NullText = "";
            dgColTextBox.Format = "yyyy-MM-dd";
            dgTS.GridColumnStyles.Add(dgColTextBox);

            dgColTextBox = new DataGridNoActiveTextBoxColumn();
            dgColTextBox.HeaderText = "用户名";
            dgColTextBox.Alignment = HorizontalAlignment.Center;
            dgColTextBox.ReadOnly = true;
            dgColTextBox.Width = 150;
            dgColTextBox.MappingName = "UserName";
            dgColTextBox.NullText = string.Empty;
            dgTS.GridColumnStyles.Add(dgColTextBox);

            dgColTextBox = new DataGridNoActiveTextBoxColumn();
            dgColTextBox.HeaderText = "工作站";
            dgColTextBox.Alignment = HorizontalAlignment.Center;
            dgColTextBox.ReadOnly = true;
            dgColTextBox.Width = 150;
            dgColTextBox.MappingName = "HostName";
            dgColTextBox.NullText = string.Empty;
            dgTS.GridColumnStyles.Add(dgColTextBox);

            dgColTextBox = new DataGridNoActiveTextBoxColumn();
            dgColTextBox.HeaderText = "IP地址";
            dgColTextBox.Alignment = HorizontalAlignment.Center;
            dgColTextBox.ReadOnly = true;
            dgColTextBox.Width = 150;
            dgColTextBox.MappingName = "IPAddr";
            dgColTextBox.NullText = string.Empty;
            dgTS.GridColumnStyles.Add(dgColTextBox);

            dgColTextBox = new DataGridNoActiveTextBoxColumn();
            dgColTextBox.HeaderText = "登入时间";
            dgColTextBox.Alignment = HorizontalAlignment.Center;
            dgColTextBox.ReadOnly = true;
            dgColTextBox.Width = 150;
            dgColTextBox.MappingName = "LITime";
            dgColTextBox.NullText = "";
            dgColTextBox.Format = "yyyy-MM-dd HH:mm:ss";
            dgTS.GridColumnStyles.Add(dgColTextBox);

            dgColTextBox = new DataGridNoActiveTextBoxColumn();
            dgColTextBox.HeaderText = "登出时间";
            dgColTextBox.Alignment = HorizontalAlignment.Center;
            dgColTextBox.ReadOnly = true;
            dgColTextBox.Width = 150;
            dgColTextBox.MappingName = "LOTime";
            dgColTextBox.NullText = "";
            dgColTextBox.Format = "yyyy-MM-dd HH:mm:ss";
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

        protected override void GetSQL()
        {
            string s = "(LDate>='" + DateTime.Now.Date.AddMonths(-1).ToShortDateString() + "' and LDate<='" + DateTime.Now.Date.ToShortDateString() + "')";

            this.m_strAryDftFilter = new string[] { s };
            base.GetSQL();
        }

        protected override void btnQuery_Click(object sender, EventArgs e)
        {
            FmQSysIOLog1 f = new FmQSysIOLog1();
            if (f.ShowDialog() == DialogResult.OK)
            {
                Application.DoEvents();

                this.m_bExecQuery = true;
                this.m_strAryQueryCondition = f.QueryCondition;

                base.btnQuery_Click(sender, e);
            }
        }

        private void miDelSelLog_Click(object sender, EventArgs e)
        {
            if (this.dgM.CurrentRowIndex < 0) return;

            if (MsgBox.ShowYesNoMsg2("确定要删除选定日志吗？") == DialogResult.No) return;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                BusinessObject bo = new BusinessObject();
                bo.BusiDataSQL = new string[] { "delete from SysIOLog where AutoId=" + this.m_dvM[this.dgM.CurrentRowIndex]["AutoId"].ToString() };
                bo.ExecBusiCmd1();
                if (bo.BusiMsg[0] == "0")
                {
                    MsgBox.ShowInfoMsg2(bo.BusiMsg[1]);
                }
                else if (bo.BusiMsg[0] == "1")
                {
                    this.btnRefresh_Click(null, null);

                    MsgBox.ShowInfoMsg2("已成功删除选定日志！");
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void miClsExpLog_Click(object sender, EventArgs e)
        {
            if (MsgBox.ShowYesNoMsg2("确定要清除异常日志吗？") == DialogResult.No) return;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                BusinessObject bo = new BusinessObject();
                bo.BusiDataSQL = new string[] { "delete from SysIOLog where LITime is not null and LOTime is null and datediff(d,LITime,'" + DateTime.Now.ToShortDateString() + "')>=1" };
                bo.ExecBusiCmd1();
                if (bo.BusiMsg[0] == "0")
                {
                    MsgBox.ShowInfoMsg2(bo.BusiMsg[1]);
                }
                else if (bo.BusiMsg[0] == "1")
                {
                    this.btnRefresh_Click(null, null);

                    MsgBox.ShowInfoMsg2("已成功清除异常日志！");
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void miClsAllLog_Click(object sender, EventArgs e)
        {
            if (this.dgM.CurrentRowIndex < 0) return;

            if (MsgBox.ShowYesNoMsg2("确定要清除所有日志吗？") == DialogResult.No) return;

            

            try
            {
                this.Cursor = Cursors.WaitCursor;

                BusinessObject bo = new BusinessObject();
                bo.BusiDataSQL = new string[] { "truncate table SysIOLog" };
                bo.ExecBusiCmd1();
                if (bo.BusiMsg[0] == "0")
                {
                    MsgBox.ShowInfoMsg2(bo.BusiMsg[1]);
                }
                else if (bo.BusiMsg[0] == "1")
                {
                    this.btnRefresh_Click(null, null);

                    MsgBox.ShowInfoMsg2("已成功清除所有日志！");
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnLogMge_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.cntMnuLogMge.Show((sender as Button), new Point(0, (sender as Button).Height));
        }

        protected override void btnExport_Click(object sender, EventArgs e)
        {
            this.m_strExportDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            base.btnExport_Click(sender, e);
        }
    }
}