namespace LanyunMES.UI
{
    partial class FmQStock
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_cInvCodeS = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_cInvCodeE = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_cCusInvCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.superTabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Size = new System.Drawing.Size(455, 479);
            this.superTabControlPanel1.Controls.SetChildIndex(this.panelEx2, 0);
            // 
            // superTabControl1
            // 
            this.superTabControl1.BackColor = System.Drawing.Color.White;
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
            this.superTabControl1.Size = new System.Drawing.Size(455, 505);
            this.superTabControl1.Controls.SetChildIndex(this.superTabControlPanel1, 0);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(378, 5);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(309, 5);
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // panelEx2
            // 
            this.panelEx2.Controls.Add(this.txt_cCusInvCode);
            this.panelEx2.Controls.Add(this.label3);
            this.panelEx2.Controls.Add(this.txt_cInvCodeE);
            this.panelEx2.Controls.Add(this.txt_cInvCodeS);
            this.panelEx2.Controls.Add(this.label2);
            this.panelEx2.Controls.Add(this.label1);
            this.panelEx2.Size = new System.Drawing.Size(455, 479);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            // 
            // panelEx1
            // 
            this.panelEx1.Location = new System.Drawing.Point(0, 470);
            this.panelEx1.Size = new System.Drawing.Size(455, 35);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "至";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "存货编码";
            // 
            // txt_cInvCodeS
            // 
            this.txt_cInvCodeS.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_cInvCodeS.Border.Class = "TextBoxBorder";
            this.txt_cInvCodeS.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_cInvCodeS.DisabledBackColor = System.Drawing.Color.White;
            this.txt_cInvCodeS.ForeColor = System.Drawing.Color.Black;
            this.txt_cInvCodeS.Location = new System.Drawing.Point(98, 32);
            this.txt_cInvCodeS.Name = "txt_cInvCodeS";
            this.txt_cInvCodeS.PreventEnterBeep = true;
            this.txt_cInvCodeS.Size = new System.Drawing.Size(132, 21);
            this.txt_cInvCodeS.TabIndex = 12;
            this.txt_cInvCodeS.Tag = "MomD.InvCode >= @cInvCodeS";
            // 
            // txt_cInvCodeE
            // 
            this.txt_cInvCodeE.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_cInvCodeE.Border.Class = "TextBoxBorder";
            this.txt_cInvCodeE.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_cInvCodeE.DisabledBackColor = System.Drawing.Color.White;
            this.txt_cInvCodeE.ForeColor = System.Drawing.Color.Black;
            this.txt_cInvCodeE.Location = new System.Drawing.Point(282, 32);
            this.txt_cInvCodeE.Name = "txt_cInvCodeE";
            this.txt_cInvCodeE.PreventEnterBeep = true;
            this.txt_cInvCodeE.Size = new System.Drawing.Size(132, 21);
            this.txt_cInvCodeE.TabIndex = 13;
            this.txt_cInvCodeE.Tag = "MomD.InvCode <= @cInvCodeE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "客户零件号";
            // 
            // txt_cCusInvCode
            // 
            this.txt_cCusInvCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_cCusInvCode.Border.Class = "TextBoxBorder";
            this.txt_cCusInvCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_cCusInvCode.DisabledBackColor = System.Drawing.Color.White;
            this.txt_cCusInvCode.ForeColor = System.Drawing.Color.Black;
            this.txt_cCusInvCode.Location = new System.Drawing.Point(98, 72);
            this.txt_cCusInvCode.Name = "txt_cCusInvCode";
            this.txt_cCusInvCode.PreventEnterBeep = true;
            this.txt_cCusInvCode.Size = new System.Drawing.Size(132, 21);
            this.txt_cCusInvCode.TabIndex = 15;
            this.txt_cCusInvCode.Tag = "MomD.InvCode =( select top 1 cInvCode from CusInvContrapose where cCusInvCode = @" +
    "cCusInvCode )";
            // 
            // FmQStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(455, 505);
            this.Name = "FmQStock";
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_cInvCodeE;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_cInvCodeS;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_cCusInvCode;
        private System.Windows.Forms.Label label3;
    }
}
