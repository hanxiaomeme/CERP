namespace NDF
{
    partial class FmRoleModule
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblRoleName = new System.Windows.Forms.Label();
            this.grpBoxRoleModule = new System.Windows.Forms.GroupBox();
            this.tvModule = new System.Windows.Forms.TreeView();
            this.grpBoxRoleModule.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(326, 538);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(50, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Location = new System.Drawing.Point(270, 538);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 24);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblRoleName
            // 
            this.lblRoleName.AutoSize = true;
            this.lblRoleName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRoleName.Location = new System.Drawing.Point(8, 24);
            this.lblRoleName.Name = "lblRoleName";
            this.lblRoleName.Size = new System.Drawing.Size(84, 14);
            this.lblRoleName.TabIndex = 1;
            this.lblRoleName.Text = "角色名:XXXX";
            this.lblRoleName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpBoxRoleModule
            // 
            this.grpBoxRoleModule.Controls.Add(this.lblRoleName);
            this.grpBoxRoleModule.Controls.Add(this.tvModule);
            this.grpBoxRoleModule.Location = new System.Drawing.Point(12, 8);
            this.grpBoxRoleModule.Name = "grpBoxRoleModule";
            this.grpBoxRoleModule.Size = new System.Drawing.Size(370, 524);
            this.grpBoxRoleModule.TabIndex = 0;
            this.grpBoxRoleModule.TabStop = false;
            this.grpBoxRoleModule.Text = "模块设置";
            // 
            // tvModule
            // 
            this.tvModule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvModule.CheckBoxes = true;
            this.tvModule.HideSelection = false;
            this.tvModule.Location = new System.Drawing.Point(8, 48);
            this.tvModule.Name = "tvModule";
            this.tvModule.Size = new System.Drawing.Size(353, 468);
            this.tvModule.TabIndex = 0;
            this.tvModule.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvModule_AfterCheck);
            // 
            // FmRoleModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 568);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpBoxRoleModule);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FmRoleModule";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "角色模块";
            this.Load += new System.EventHandler(this.FmRoleModule_Load);
            this.grpBoxRoleModule.ResumeLayout(false);
            this.grpBoxRoleModule.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblRoleName;
        private System.Windows.Forms.GroupBox grpBoxRoleModule;
        private System.Windows.Forms.TreeView tvModule;
    }
}