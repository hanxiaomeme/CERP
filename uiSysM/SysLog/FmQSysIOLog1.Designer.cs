namespace NDF
{
    partial class FmQSysIOLog1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmQSysIOLog1));
            this.label1 = new System.Windows.Forms.Label();
            this.txtLDateF = new System.Windows.Forms.TextBox();
            this.txtLDateT = new System.Windows.Forms.TextBox();
            this.btnSLDateF = new System.Windows.Forms.Button();
            this.btnSLDateT = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboBoxUserName = new System.Windows.Forms.ComboBox();
            this.cboBoxHostName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnl02.SuspendLayout();
            this.pnl03.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pnl0202.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl01
            // 
            this.pnl01.Size = new System.Drawing.Size(442, 8);
            // 
            // pnl02
            // 
            this.pnl02.Size = new System.Drawing.Size(442, 432);
            // 
            // pnl03
            // 
            this.pnl03.Size = new System.Drawing.Size(442, 28);
            // 
            // tabControl1
            // 
            this.tabControl1.Size = new System.Drawing.Size(424, 432);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cboBoxHostName);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cboBoxUserName);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnSLDateT);
            this.tabPage1.Controls.Add(this.btnSLDateF);
            this.tabPage1.Controls.Add(this.txtLDateT);
            this.tabPage1.Controls.Add(this.txtLDateF);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Size = new System.Drawing.Size(416, 407);
            // 
            // pnl0202
            // 
            this.pnl0202.Size = new System.Drawing.Size(424, 432);
            // 
            // pnl020203
            // 
            this.pnl020203.Location = new System.Drawing.Point(432, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "日    期";
            // 
            // txtLDateF
            // 
            this.txtLDateF.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtLDateF.Location = new System.Drawing.Point(71, 6);
            this.txtLDateF.Name = "txtLDateF";
            this.txtLDateF.ReadOnly = true;
            this.txtLDateF.Size = new System.Drawing.Size(128, 21);
            this.txtLDateF.TabIndex = 10;
            this.txtLDateF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLDateF_KeyPress);
            // 
            // txtLDateT
            // 
            this.txtLDateT.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtLDateT.Location = new System.Drawing.Point(255, 6);
            this.txtLDateT.Name = "txtLDateT";
            this.txtLDateT.ReadOnly = true;
            this.txtLDateT.Size = new System.Drawing.Size(128, 21);
            this.txtLDateT.TabIndex = 11;
            this.txtLDateT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLDateT_KeyPress);
            // 
            // btnSLDateF
            // 
            this.btnSLDateF.Image = ((System.Drawing.Image)(resources.GetObject("btnSLDateF.Image")));
            this.btnSLDateF.Location = new System.Drawing.Point(199, 6);
            this.btnSLDateF.Name = "btnSLDateF";
            this.btnSLDateF.Size = new System.Drawing.Size(24, 21);
            this.btnSLDateF.TabIndex = 12;
            this.btnSLDateF.Click += new System.EventHandler(this.btnSLDateF_Click);
            // 
            // btnSLDateT
            // 
            this.btnSLDateT.Image = ((System.Drawing.Image)(resources.GetObject("btnSLDateT.Image")));
            this.btnSLDateT.Location = new System.Drawing.Point(383, 6);
            this.btnSLDateT.Name = "btnSLDateT";
            this.btnSLDateT.Size = new System.Drawing.Size(24, 21);
            this.btnSLDateT.TabIndex = 13;
            this.btnSLDateT.Click += new System.EventHandler(this.btnSLDateT_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "用 户 名";
            // 
            // cboBoxUserName
            // 
            this.cboBoxUserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBoxUserName.FormattingEnabled = true;
            this.cboBoxUserName.Location = new System.Drawing.Point(71, 30);
            this.cboBoxUserName.Name = "cboBoxUserName";
            this.cboBoxUserName.Size = new System.Drawing.Size(128, 20);
            this.cboBoxUserName.TabIndex = 15;
            // 
            // cboBoxHostName
            // 
            this.cboBoxHostName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBoxHostName.FormattingEnabled = true;
            this.cboBoxHostName.Location = new System.Drawing.Point(71, 54);
            this.cboBoxHostName.Name = "cboBoxHostName";
            this.cboBoxHostName.Size = new System.Drawing.Size(128, 20);
            this.cboBoxHostName.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "工 作 站";
            // 
            // FmQSysIOLog1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(442, 468);
            this.Name = "FmQSysIOLog1";
            this.pnl02.ResumeLayout(false);
            this.pnl03.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.pnl0202.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboBoxHostName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboBoxUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSLDateT;
        private System.Windows.Forms.Button btnSLDateF;
        private System.Windows.Forms.TextBox txtLDateT;
        private System.Windows.Forms.TextBox txtLDateF;
    }
}
