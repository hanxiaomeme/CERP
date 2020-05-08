namespace NDF
{
    partial class FmSysIOLog
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLogMge = new System.Windows.Forms.Button();
            this.cntMnuLogMge = new System.Windows.Forms.ContextMenu();
            this.miDelSelLog = new System.Windows.Forms.MenuItem();
            this.miClsExpLog = new System.Windows.Forms.MenuItem();
            this.miClsAllLog = new System.Windows.Forms.MenuItem();
            this.pnl0101.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgM)).BeginInit();
            this.pnl0202.SuspendLayout();
            this.pnl0201.SuspendLayout();
            this.pnl02.SuspendLayout();
            this.pnl03.SuspendLayout();
            this.pnl01.SuspendLayout();
            this.pnl0102.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(102, 3);
            // 
            // lblModuleTitle
            // 
            this.lblModuleTitle.Text = "上机日志";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(148, 3);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(8, 30);
            this.btnPrint.Visible = false;
            // 
            // dgM
            // 
            this.dgM.CaptionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgM.Size = new System.Drawing.Size(792, 446);
            // 
            // pnl0202
            // 
            this.pnl0202.Location = new System.Drawing.Point(0, 32);
            this.pnl0202.Size = new System.Drawing.Size(792, 446);
            // 
            // pnl0201
            // 
            this.pnl0201.Controls.Add(this.btnLogMge);
            this.pnl0201.Size = new System.Drawing.Size(792, 32);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(56, 3);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(10, 3);
            // 
            // btnLogMge
            // 
            this.btnLogMge.Location = new System.Drawing.Point(10, 4);
            this.btnLogMge.Name = "btnLogMge";
            this.btnLogMge.Size = new System.Drawing.Size(89, 24);
            this.btnLogMge.TabIndex = 0;
            this.btnLogMge.Text = "日志操作...";
            this.btnLogMge.UseVisualStyleBackColor = true;
            this.btnLogMge.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnLogMge_MouseDown);
            // 
            // cntMnuLogMge
            // 
            this.cntMnuLogMge.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miDelSelLog,
            this.miClsExpLog,
            this.miClsAllLog});
            // 
            // miDelSelLog
            // 
            this.miDelSelLog.Index = 0;
            this.miDelSelLog.Text = "删除选定日志";
            this.miDelSelLog.Click += new System.EventHandler(this.miDelSelLog_Click);
            // 
            // miClsExpLog
            // 
            this.miClsExpLog.Index = 1;
            this.miClsExpLog.Text = "清除异常日志";
            this.miClsExpLog.Click += new System.EventHandler(this.miClsExpLog_Click);
            // 
            // miClsAllLog
            // 
            this.miClsAllLog.Index = 2;
            this.miClsAllLog.Text = "清除所有日志";
            this.miClsAllLog.Click += new System.EventHandler(this.miClsAllLog_Click);
            // 
            // FmSysIOLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Name = "FmSysIOLog";
            this.Text = "上机日志";
            this.Load += new System.EventHandler(this.FmQB_Load);
            this.pnl0101.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgM)).EndInit();
            this.pnl0202.ResumeLayout(false);
            this.pnl0201.ResumeLayout(false);
            this.pnl02.ResumeLayout(false);
            this.pnl03.ResumeLayout(false);
            this.pnl01.ResumeLayout(false);
            this.pnl0102.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogMge;
        private System.Windows.Forms.ContextMenu cntMnuLogMge;
        private System.Windows.Forms.MenuItem miDelSelLog;
        private System.Windows.Forms.MenuItem miClsExpLog;
        private System.Windows.Forms.MenuItem miClsAllLog;
    }
}
