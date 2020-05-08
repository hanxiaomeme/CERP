namespace LanyunMES.UI
{
    partial class FmMOExcuteQ
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtr_machine = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtr_OpName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.RB_1 = new System.Windows.Forms.RadioButton();
            this.RB_2 = new System.Windows.Forms.RadioButton();
            this.superTabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Size = new System.Drawing.Size(404, 418);
            this.superTabControlPanel1.Controls.SetChildIndex(this.panelEx2, 0);
            // 
            // superTabControl1
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl1.ControlBox.MenuBox.Name = "";
            this.superTabControl1.ControlBox.Name = "";
            this.superTabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl1.ControlBox.MenuBox,
            this.superTabControl1.ControlBox.CloseBox});
            this.superTabControl1.Size = new System.Drawing.Size(404, 444);
            this.superTabControl1.Controls.SetChildIndex(this.superTabControlPanel1, 0);
            // 
            // btn_OK
            // 
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // panelEx2
            // 
            this.panelEx2.Controls.Add(this.RB_2);
            this.panelEx2.Controls.Add(this.RB_1);
            this.panelEx2.Controls.Add(this.label3);
            this.panelEx2.Controls.Add(this.label2);
            this.panelEx2.Controls.Add(this.txtr_machine);
            this.panelEx2.Controls.Add(this.txtr_OpName);
            this.panelEx2.Size = new System.Drawing.Size(404, 418);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            // 
            // panelEx1
            // 
            this.panelEx1.Location = new System.Drawing.Point(0, 409);
            this.panelEx1.Size = new System.Drawing.Size(404, 35);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Moccasin;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(69, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 13;
            this.label3.Text = "机台设备：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Moccasin;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(69, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 12;
            this.label2.Text = "工序名称：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtr_machine
            // 
            this.txtr_machine.BackColor = System.Drawing.Color.OldLace;
            // 
            // 
            // 
            this.txtr_machine.Border.Class = "TextBoxBorder";
            this.txtr_machine.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_machine.ButtonCustom.Visible = true;
            this.txtr_machine.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_machine.ForeColor = System.Drawing.Color.Black;
            this.txtr_machine.Location = new System.Drawing.Point(158, 111);
            this.txtr_machine.Name = "txtr_machine";
            this.txtr_machine.PreventEnterBeep = true;
            this.txtr_machine.ReadOnly = true;
            this.txtr_machine.Size = new System.Drawing.Size(181, 21);
            this.txtr_machine.TabIndex = 11;
            // 
            // txtr_OpName
            // 
            this.txtr_OpName.BackColor = System.Drawing.Color.OldLace;
            // 
            // 
            // 
            this.txtr_OpName.Border.Class = "TextBoxBorder";
            this.txtr_OpName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_OpName.ButtonCustom.Visible = true;
            this.txtr_OpName.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_OpName.ForeColor = System.Drawing.Color.Black;
            this.txtr_OpName.Location = new System.Drawing.Point(158, 56);
            this.txtr_OpName.Name = "txtr_OpName";
            this.txtr_OpName.PreventEnterBeep = true;
            this.txtr_OpName.ReadOnly = true;
            this.txtr_OpName.Size = new System.Drawing.Size(181, 21);
            this.txtr_OpName.TabIndex = 10;
            // 
            // RB_1
            // 
            this.RB_1.AutoSize = true;
            this.RB_1.Checked = true;
            this.RB_1.Location = new System.Drawing.Point(69, 171);
            this.RB_1.Name = "RB_1";
            this.RB_1.Size = new System.Drawing.Size(71, 16);
            this.RB_1.TabIndex = 14;
            this.RB_1.TabStop = true;
            this.RB_1.Text = "标准流程";
            this.RB_1.UseVisualStyleBackColor = true;
            // 
            // RB_2
            // 
            this.RB_2.AutoSize = true;
            this.RB_2.Location = new System.Drawing.Point(224, 171);
            this.RB_2.Name = "RB_2";
            this.RB_2.Size = new System.Drawing.Size(71, 16);
            this.RB_2.TabIndex = 15;
            this.RB_2.Text = "样品流程";
            this.RB_2.UseVisualStyleBackColor = true;
            // 
            // FmMOExcuteQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(404, 444);
            this.Name = "FmMOExcuteQ";
            this.Controls.SetChildIndex(this.superTabControl1, 0);
            this.Controls.SetChildIndex(this.panelEx1, 0);
            this.superTabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_machine;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_OpName;
        private System.Windows.Forms.RadioButton RB_2;
        private System.Windows.Forms.RadioButton RB_1;
    }
}
