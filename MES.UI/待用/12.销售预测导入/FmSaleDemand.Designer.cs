namespace LanyunMES.UI
{
    partial class FmSaleDemand
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.BtnLoadXls = new DevComponents.DotNetBar.ButtonItem();
            this.BtnSave = new DevComponents.DotNetBar.ButtonItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCusCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCusInvCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cInvCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iQuantity = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.BtnLoadXls,
            this.BtnSave});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(825, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // BtnLoadXls
            // 
            this.BtnLoadXls.Name = "BtnLoadXls";
            this.BtnLoadXls.Text = "导入Excel";
            this.BtnLoadXls.Click += new System.EventHandler(this.BtnLoadXls_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BeginGroup = true;
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Text = "保存";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeight = 25;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dDate,
            this.cCusCode,
            this.cCusName,
            this.cCusInvCode,
            this.cInvCode,
            this.iQuantity});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(825, 443);
            this.dataGridView1.TabIndex = 1;
            // 
            // dDate
            // 
            this.dDate.DataPropertyName = "dDate";
            this.dDate.FillWeight = 80F;
            this.dDate.HeaderText = "日期";
            this.dDate.Name = "dDate";
            this.dDate.ReadOnly = true;
            this.dDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // cCusCode
            // 
            this.cCusCode.DataPropertyName = "cCusCode";
            this.cCusCode.FillWeight = 80F;
            this.cCusCode.HeaderText = "客户编码";
            this.cCusCode.Name = "cCusCode";
            this.cCusCode.ReadOnly = true;
            // 
            // cCusName
            // 
            this.cCusName.DataPropertyName = "cCusName";
            this.cCusName.HeaderText = "客户名称";
            this.cCusName.Name = "cCusName";
            this.cCusName.ReadOnly = true;
            // 
            // cCusInvCode
            // 
            this.cCusInvCode.DataPropertyName = "cCusInvCode";
            this.cCusInvCode.HeaderText = "客户零件号";
            this.cCusInvCode.Name = "cCusInvCode";
            this.cCusInvCode.ReadOnly = true;
            // 
            // cInvCode
            // 
            this.cInvCode.DataPropertyName = "cInvCode";
            this.cInvCode.HeaderText = "存货编码";
            this.cInvCode.Name = "cInvCode";
            this.cInvCode.ReadOnly = true;
            // 
            // iQuantity
            // 
            // 
            // 
            // 
            this.iQuantity.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.iQuantity.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.iQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.iQuantity.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText;
            this.iQuantity.DataPropertyName = "iQuantity";
            this.iQuantity.FillWeight = 80F;
            this.iQuantity.HeaderText = "千件";
            this.iQuantity.Increment = 1D;
            this.iQuantity.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.iQuantity.Name = "iQuantity";
            this.iQuantity.ReadOnly = true;
            // 
            // FmSaleDemand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 470);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.bar1);
            this.Name = "FmSaleDemand";
            this.Text = "FmSaleDemand";
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem BtnLoadXls;
        private DevComponents.DotNetBar.ButtonItem BtnSave;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCusCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCusInvCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn cInvCode;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn iQuantity;
    }
}