namespace MES
{
    partial class FmInvQuery
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_InvCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_InvName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_InvStd = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_QueryCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_LJDB = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.superTabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Size = new System.Drawing.Size(402, 396);
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
            this.superTabControl1.Size = new System.Drawing.Size(402, 422);
            this.superTabControl1.Controls.SetChildIndex(this.superTabControlPanel1, 0);
            // 
            // panelEx2
            // 
            this.panelEx2.Controls.Add(this.txt_LJDB);
            this.panelEx2.Controls.Add(this.label5);
            this.panelEx2.Controls.Add(this.txt_QueryCode);
            this.panelEx2.Controls.Add(this.label4);
            this.panelEx2.Controls.Add(this.txt_InvStd);
            this.panelEx2.Controls.Add(this.label3);
            this.panelEx2.Controls.Add(this.txt_InvName);
            this.panelEx2.Controls.Add(this.label2);
            this.panelEx2.Controls.Add(this.txt_InvCode);
            this.panelEx2.Controls.Add(this.label1);
            this.panelEx2.Size = new System.Drawing.Size(402, 396);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            // 
            // panelEx1
            // 
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "零 件 号";
            // 
            // txt_InvCode
            // 
            this.txt_InvCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_InvCode.Border.Class = "TextBoxBorder";
            this.txt_InvCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_InvCode.DisabledBackColor = System.Drawing.Color.White;
            this.txt_InvCode.ForeColor = System.Drawing.Color.Black;
            this.txt_InvCode.Location = new System.Drawing.Point(120, 45);
            this.txt_InvCode.Name = "txt_InvCode";
            this.txt_InvCode.PreventEnterBeep = true;
            this.txt_InvCode.Size = new System.Drawing.Size(199, 21);
            this.txt_InvCode.TabIndex = 1;
            // 
            // txt_InvName
            // 
            this.txt_InvName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_InvName.Border.Class = "TextBoxBorder";
            this.txt_InvName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_InvName.DisabledBackColor = System.Drawing.Color.White;
            this.txt_InvName.ForeColor = System.Drawing.Color.Black;
            this.txt_InvName.Location = new System.Drawing.Point(120, 87);
            this.txt_InvName.Name = "txt_InvName";
            this.txt_InvName.PreventEnterBeep = true;
            this.txt_InvName.Size = new System.Drawing.Size(199, 21);
            this.txt_InvName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "产品名称";
            // 
            // txt_InvStd
            // 
            this.txt_InvStd.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_InvStd.Border.Class = "TextBoxBorder";
            this.txt_InvStd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_InvStd.DisabledBackColor = System.Drawing.Color.White;
            this.txt_InvStd.ForeColor = System.Drawing.Color.Black;
            this.txt_InvStd.Location = new System.Drawing.Point(120, 127);
            this.txt_InvStd.Name = "txt_InvStd";
            this.txt_InvStd.PreventEnterBeep = true;
            this.txt_InvStd.Size = new System.Drawing.Size(199, 21);
            this.txt_InvStd.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "产品规格";
            // 
            // txt_QueryCode
            // 
            this.txt_QueryCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_QueryCode.Border.Class = "TextBoxBorder";
            this.txt_QueryCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_QueryCode.DisabledBackColor = System.Drawing.Color.White;
            this.txt_QueryCode.ForeColor = System.Drawing.Color.Black;
            this.txt_QueryCode.Location = new System.Drawing.Point(120, 167);
            this.txt_QueryCode.Name = "txt_QueryCode";
            this.txt_QueryCode.PreventEnterBeep = true;
            this.txt_QueryCode.Size = new System.Drawing.Size(199, 21);
            this.txt_QueryCode.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "查 询 码";
            // 
            // txt_LJDB
            // 
            this.txt_LJDB.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_LJDB.Border.Class = "TextBoxBorder";
            this.txt_LJDB.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_LJDB.DisabledBackColor = System.Drawing.Color.White;
            this.txt_LJDB.ForeColor = System.Drawing.Color.Black;
            this.txt_LJDB.Location = new System.Drawing.Point(120, 207);
            this.txt_LJDB.Name = "txt_LJDB";
            this.txt_LJDB.PreventEnterBeep = true;
            this.txt_LJDB.Size = new System.Drawing.Size(199, 21);
            this.txt_LJDB.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "六角对边";
            // 
            // FmInvQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(402, 457);
            this.Name = "FmInvQuery";
            this.Controls.SetChildIndex(this.panelEx1, 0);
            this.Controls.SetChildIndex(this.superTabControl1, 0);
            this.superTabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txt_QueryCode;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_InvStd;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_InvName;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_InvCode;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_LJDB;
        private System.Windows.Forms.Label label5;

    }
}
