namespace NDF
{
    partial class FmIURole
    {
        /// <summary>
        /// ����������������
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// ������������ʹ�õ���Դ��
        /// </summary>
        /// <param name="disposing">���Ӧ�ͷ��й���Դ��Ϊ true������Ϊ false��</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows ������������ɵĴ���

        /// <summary>
        /// �����֧������ķ��� - ��Ҫ
        /// ʹ�ô���༭���޸Ĵ˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            this.txtWRoleName = new System.Windows.Forms.TextBox();
            this.txtWRoleCode = new System.Windows.Forms.TextBox();
            this.lblBName = new System.Windows.Forms.Label();
            this.lblBCode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            this.pnl01.SuspendLayout();
            this.pnl02.SuspendLayout();
            this.pnl03.SuspendLayout();
            this.pnl0102.SuspendLayout();
            this.pnl0101.SuspendLayout();
            this.pnl0202.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgM)).BeginInit();
            this.tabCtlMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Size = new System.Drawing.Size(472, 22);
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Width = 456;
            // 
            // pnl01
            // 
            this.pnl01.Size = new System.Drawing.Size(472, 64);
            // 
            // pnl02
            // 
            this.pnl02.Size = new System.Drawing.Size(472, 287);
            // 
            // pnl03
            // 
            this.pnl03.Location = new System.Drawing.Point(0, 351);
            this.pnl03.Size = new System.Drawing.Size(472, 22);
            // 
            // pnl0102
            // 
            this.pnl0102.Size = new System.Drawing.Size(472, 23);
            // 
            // pnl0101
            // 
            this.pnl0101.Size = new System.Drawing.Size(472, 41);
            // 
            // pnl0202
            // 
            this.pnl0202.Size = new System.Drawing.Size(472, 287);
            // 
            // pnl0203
            // 
            this.pnl0203.Location = new System.Drawing.Point(0, 287);
            this.pnl0203.Size = new System.Drawing.Size(472, 0);
            // 
            // pnl0201
            // 
            this.pnl0201.Size = new System.Drawing.Size(472, 0);
            // 
            // lblModuleTitle
            // 
            this.lblModuleTitle.Size = new System.Drawing.Size(470, 21);
            this.lblModuleTitle.Text = "��ɫ";
            // 
            // tabCtlMain
            // 
            this.tabCtlMain.Size = new System.Drawing.Size(472, 287);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtWRoleName);
            this.tabPage1.Controls.Add(this.txtWRoleCode);
            this.tabPage1.Controls.Add(this.lblBName);
            this.tabPage1.Controls.Add(this.lblBCode);
            this.tabPage1.Size = new System.Drawing.Size(464, 262);
            // 
            // txtWRoleName
            // 
            this.txtWRoleName.Location = new System.Drawing.Point(69, 30);
            this.txtWRoleName.Name = "txtWRoleName";
            this.txtWRoleName.Size = new System.Drawing.Size(256, 21);
            this.txtWRoleName.TabIndex = 15;
            // 
            // txtWRoleCode
            // 
            this.txtWRoleCode.Location = new System.Drawing.Point(69, 6);
            this.txtWRoleCode.Name = "txtWRoleCode";
            this.txtWRoleCode.Size = new System.Drawing.Size(128, 21);
            this.txtWRoleCode.TabIndex = 14;
            // 
            // lblBName
            // 
            this.lblBName.AutoSize = true;
            this.lblBName.Location = new System.Drawing.Point(5, 30);
            this.lblBName.Name = "lblBName";
            this.lblBName.Size = new System.Drawing.Size(53, 12);
            this.lblBName.TabIndex = 13;
            this.lblBName.Text = "��ɫ����";
            this.lblBName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBCode
            // 
            this.lblBCode.AutoSize = true;
            this.lblBCode.ForeColor = System.Drawing.Color.Blue;
            this.lblBCode.Location = new System.Drawing.Point(5, 6);
            this.lblBCode.Name = "lblBCode";
            this.lblBCode.Size = new System.Drawing.Size(53, 12);
            this.lblBCode.TabIndex = 12;
            this.lblBCode.Text = "��ɫ����";
            this.lblBCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FmIURole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(472, 373);
            this.Name = "FmIURole";
            this.Text = "��ɫ";
            this.Load += new System.EventHandler(this.FmB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            this.pnl01.ResumeLayout(false);
            this.pnl02.ResumeLayout(false);
            this.pnl03.ResumeLayout(false);
            this.pnl0102.ResumeLayout(false);
            this.pnl0101.ResumeLayout(false);
            this.pnl0101.PerformLayout();
            this.pnl0202.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgM)).EndInit();
            this.tabCtlMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtWRoleName;
        private System.Windows.Forms.TextBox txtWRoleCode;
        private System.Windows.Forms.Label lblBName;
        private System.Windows.Forms.Label lblBCode;




    }
}
