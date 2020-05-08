namespace LanyunMES.UI
{
    partial class FmQSaleMonth
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
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.intbox_year = new DevComponents.Editors.IntegerInput();
            this.intbox_count = new DevComponents.Editors.IntegerInput();
            this.intbox_month = new DevComponents.Editors.IntegerInput();
            this.superTabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intbox_year)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intbox_count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intbox_month)).BeginInit();
            this.SuspendLayout();
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Size = new System.Drawing.Size(438, 482);
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
            this.superTabControl1.Size = new System.Drawing.Size(438, 508);
            this.superTabControl1.Controls.SetChildIndex(this.superTabControlPanel1, 0);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(362, 5);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(293, 5);
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // panelEx2
            // 
            this.panelEx2.Controls.Add(this.intbox_month);
            this.panelEx2.Controls.Add(this.intbox_count);
            this.panelEx2.Controls.Add(this.intbox_year);
            this.panelEx2.Controls.Add(this.label8);
            this.panelEx2.Controls.Add(this.label10);
            this.panelEx2.Controls.Add(this.label9);
            this.panelEx2.Size = new System.Drawing.Size(438, 482);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            // 
            // panelEx1
            // 
            this.panelEx1.Location = new System.Drawing.Point(0, 473);
            this.panelEx1.Size = new System.Drawing.Size(438, 35);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(18, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 25;
            this.label9.Text = "截止年度";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(234, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 26;
            this.label10.Text = "截止月份";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(19, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 28;
            this.label8.Text = "查询月数";
            // 
            // intbox_year
            // 
            // 
            // 
            // 
            this.intbox_year.BackgroundStyle.Class = "DateTimeInputBackground";
            this.intbox_year.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.intbox_year.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.intbox_year.ForeColor = System.Drawing.Color.Black;
            this.intbox_year.Location = new System.Drawing.Point(91, 24);
            this.intbox_year.MaxValue = 2050;
            this.intbox_year.MinValue = 2016;
            this.intbox_year.Name = "intbox_year";
            this.intbox_year.ShowUpDown = true;
            this.intbox_year.Size = new System.Drawing.Size(108, 21);
            this.intbox_year.TabIndex = 37;
            this.intbox_year.Tag = "@iyear";
            this.intbox_year.Value = 2016;
            // 
            // intbox_count
            // 
            // 
            // 
            // 
            this.intbox_count.BackgroundStyle.Class = "DateTimeInputBackground";
            this.intbox_count.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.intbox_count.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.intbox_count.ForeColor = System.Drawing.Color.Black;
            this.intbox_count.Location = new System.Drawing.Point(91, 61);
            this.intbox_count.MaxValue = 12;
            this.intbox_count.MinValue = 1;
            this.intbox_count.Name = "intbox_count";
            this.intbox_count.ShowUpDown = true;
            this.intbox_count.Size = new System.Drawing.Size(108, 21);
            this.intbox_count.TabIndex = 38;
            this.intbox_count.Tag = "@monCount";
            this.intbox_count.Value = 1;
            // 
            // intbox_month
            // 
            // 
            // 
            // 
            this.intbox_month.BackgroundStyle.Class = "DateTimeInputBackground";
            this.intbox_month.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.intbox_month.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.intbox_month.ForeColor = System.Drawing.Color.Black;
            this.intbox_month.Location = new System.Drawing.Point(302, 24);
            this.intbox_month.MaxValue = 12;
            this.intbox_month.MinValue = 1;
            this.intbox_month.Name = "intbox_month";
            this.intbox_month.ShowUpDown = true;
            this.intbox_month.Size = new System.Drawing.Size(108, 21);
            this.intbox_month.TabIndex = 39;
            this.intbox_month.Tag = "@imonth";
            this.intbox_month.Value = 1;
            // 
            // FmQSaleMonth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(438, 508);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "FmQSaleMonth";
            this.Controls.SetChildIndex(this.superTabControl1, 0);
            this.Controls.SetChildIndex(this.panelEx1, 0);
            this.superTabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.intbox_year)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intbox_count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intbox_month)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private DevComponents.Editors.IntegerInput intbox_count;
        private DevComponents.Editors.IntegerInput intbox_year;
        private DevComponents.Editors.IntegerInput intbox_month;
    }
}
