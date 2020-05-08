namespace NDF
{
    partial class FmUserRole
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
            this.dgM = new SUDataGrid();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNoSelAll = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSelAll = new System.Windows.Forms.Button();
            this.grpBoxUserRole = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgM)).BeginInit();
            this.grpBoxUserRole.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgM
            // 
            this.dgM.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgM.CaptionBackColor = System.Drawing.SystemColors.ControlDark;
            this.dgM.CaptionText = "用户角色";
            this.dgM.CaptionVisible = false;
            this.dgM.DataMember = "";
            this.dgM.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgM.Location = new System.Drawing.Point(12, 48);
            this.dgM.Name = "dgM";
            this.dgM.Size = new System.Drawing.Size(456, 440);
            this.dgM.TabIndex = 0;
            this.dgM.Tag = -1;
            this.dgM.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgM_MouseDown);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUserName.Location = new System.Drawing.Point(12, 24);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(91, 14);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "用户名：XXXX";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(441, 544);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(48, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNoSelAll
            // 
            this.btnNoSelAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNoSelAll.Location = new System.Drawing.Point(48, 496);
            this.btnNoSelAll.Name = "btnNoSelAll";
            this.btnNoSelAll.Size = new System.Drawing.Size(40, 24);
            this.btnNoSelAll.TabIndex = 4;
            this.btnNoSelAll.Text = "全消";
            this.btnNoSelAll.Click += new System.EventHandler(this.btnNoSelAll_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Location = new System.Drawing.Point(385, 544);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(48, 24);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSelAll
            // 
            this.btnSelAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSelAll.Location = new System.Drawing.Point(8, 496);
            this.btnSelAll.Name = "btnSelAll";
            this.btnSelAll.Size = new System.Drawing.Size(40, 24);
            this.btnSelAll.TabIndex = 3;
            this.btnSelAll.Text = "全选";
            this.btnSelAll.Click += new System.EventHandler(this.btnSelAll_Click);
            // 
            // grpBoxUserRole
            // 
            this.grpBoxUserRole.Controls.Add(this.btnNoSelAll);
            this.grpBoxUserRole.Controls.Add(this.btnSelAll);
            this.grpBoxUserRole.Controls.Add(this.dgM);
            this.grpBoxUserRole.Controls.Add(this.lblUserName);
            this.grpBoxUserRole.Location = new System.Drawing.Point(8, 8);
            this.grpBoxUserRole.Name = "grpBoxUserRole";
            this.grpBoxUserRole.Size = new System.Drawing.Size(480, 528);
            this.grpBoxUserRole.TabIndex = 0;
            this.grpBoxUserRole.TabStop = false;
            this.grpBoxUserRole.Text = "角色设置";
            // 
            // FmUserRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 576);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpBoxUserRole);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FmUserRole";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户角色";
            this.Load += new System.EventHandler(this.FmUserRole_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgM)).EndInit();
            this.grpBoxUserRole.ResumeLayout(false);
            this.grpBoxUserRole.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SUDataGrid dgM;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNoSelAll;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSelAll;
        private System.Windows.Forms.GroupBox grpBoxUserRole;
    }
}