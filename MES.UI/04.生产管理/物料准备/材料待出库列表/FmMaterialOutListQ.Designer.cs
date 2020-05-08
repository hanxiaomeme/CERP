namespace LanyunMES.UI
{
    partial class FmMaterialOutListQ
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
            this.label4 = new System.Windows.Forms.Label();
            this.txt_cInvStd = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_WOCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxX2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxX3 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_cInvCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateBegin = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dateEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.chk_bClosed = new System.Windows.Forms.CheckBox();
            this.superTabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Size = new System.Drawing.Size(455, 479);
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
            this.panelEx2.Controls.Add(this.chk_bClosed);
            this.panelEx2.Controls.Add(this.dateEnd);
            this.panelEx2.Controls.Add(this.dateBegin);
            this.panelEx2.Controls.Add(this.label2);
            this.panelEx2.Controls.Add(this.label1);
            this.panelEx2.Controls.Add(this.txt_cInvCode);
            this.panelEx2.Controls.Add(this.label11);
            this.panelEx2.Controls.Add(this.textBoxX3);
            this.panelEx2.Controls.Add(this.label10);
            this.panelEx2.Controls.Add(this.textBoxX2);
            this.panelEx2.Controls.Add(this.label9);
            this.panelEx2.Controls.Add(this.label5);
            this.panelEx2.Controls.Add(this.txt_WOCode);
            this.panelEx2.Controls.Add(this.txt_cInvStd);
            this.panelEx2.Controls.Add(this.label4);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(235, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "规格型号";
            // 
            // txt_cInvStd
            // 
            this.txt_cInvStd.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_cInvStd.Border.Class = "TextBoxBorder";
            this.txt_cInvStd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_cInvStd.DisabledBackColor = System.Drawing.Color.White;
            this.txt_cInvStd.ForeColor = System.Drawing.Color.Black;
            this.txt_cInvStd.Location = new System.Drawing.Point(296, 106);
            this.txt_cInvStd.Name = "txt_cInvStd";
            this.txt_cInvStd.PreventEnterBeep = true;
            this.txt_cInvStd.Size = new System.Drawing.Size(132, 21);
            this.txt_cInvStd.TabIndex = 13;
            this.txt_cInvStd.Tag = "cInvStd like \'%\' + @cInvStd";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "指令单号";
            this.label5.Visible = false;
            // 
            // txt_WOCode
            // 
            this.txt_WOCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_WOCode.Border.Class = "TextBoxBorder";
            this.txt_WOCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_WOCode.DisabledBackColor = System.Drawing.Color.White;
            this.txt_WOCode.ForeColor = System.Drawing.Color.Black;
            this.txt_WOCode.Location = new System.Drawing.Point(81, 27);
            this.txt_WOCode.Name = "txt_WOCode";
            this.txt_WOCode.PreventEnterBeep = true;
            this.txt_WOCode.Size = new System.Drawing.Size(132, 21);
            this.txt_WOCode.TabIndex = 14;
            this.txt_WOCode.Tag = "WOCode = @WOCode";
            this.txt_WOCode.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 22;
            this.label9.Text = "生产订单";
            // 
            // textBoxX2
            // 
            this.textBoxX2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxX2.Border.Class = "TextBoxBorder";
            this.textBoxX2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX2.DisabledBackColor = System.Drawing.Color.White;
            this.textBoxX2.ForeColor = System.Drawing.Color.Black;
            this.textBoxX2.Location = new System.Drawing.Point(81, 66);
            this.textBoxX2.Name = "textBoxX2";
            this.textBoxX2.PreventEnterBeep = true;
            this.textBoxX2.Size = new System.Drawing.Size(132, 21);
            this.textBoxX2.TabIndex = 23;
            this.textBoxX2.Tag = "MoCode = @MoCode";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(259, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 24;
            this.label10.Text = "行号";
            // 
            // textBoxX3
            // 
            this.textBoxX3.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxX3.Border.Class = "TextBoxBorder";
            this.textBoxX3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX3.DisabledBackColor = System.Drawing.Color.White;
            this.textBoxX3.ForeColor = System.Drawing.Color.Black;
            this.textBoxX3.Location = new System.Drawing.Point(296, 66);
            this.textBoxX3.Name = "textBoxX3";
            this.textBoxX3.PreventEnterBeep = true;
            this.textBoxX3.Size = new System.Drawing.Size(132, 21);
            this.textBoxX3.TabIndex = 25;
            this.textBoxX3.Tag = "SortSeq = @SortSeq";
            // 
            // txt_cInvCode
            // 
            this.txt_cInvCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_cInvCode.Border.Class = "TextBoxBorder";
            this.txt_cInvCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_cInvCode.DisabledBackColor = System.Drawing.Color.White;
            this.txt_cInvCode.ForeColor = System.Drawing.Color.Black;
            this.txt_cInvCode.Location = new System.Drawing.Point(81, 106);
            this.txt_cInvCode.Name = "txt_cInvCode";
            this.txt_cInvCode.PreventEnterBeep = true;
            this.txt_cInvCode.Size = new System.Drawing.Size(132, 21);
            this.txt_cInvCode.TabIndex = 27;
            this.txt_cInvCode.Tag = "cInvCode = @cInvCode";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 111);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 26;
            this.label11.Text = "产品编码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 28;
            this.label1.Text = "日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 29;
            this.label2.Text = "至";
            // 
            // dateBegin
            // 
            // 
            // 
            // 
            this.dateBegin.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateBegin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateBegin.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateBegin.ButtonDropDown.Visible = true;
            this.dateBegin.IsPopupCalendarOpen = false;
            this.dateBegin.Location = new System.Drawing.Point(81, 145);
            this.dateBegin.LockUpdateChecked = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.dateBegin.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateBegin.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateBegin.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateBegin.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateBegin.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateBegin.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateBegin.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateBegin.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateBegin.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateBegin.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateBegin.MonthCalendar.DisplayMonth = new System.DateTime(2019, 6, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dateBegin.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateBegin.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateBegin.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateBegin.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateBegin.MonthCalendar.TodayButtonVisible = true;
            this.dateBegin.Name = "dateBegin";
            this.dateBegin.ShowCheckBox = true;
            this.dateBegin.Size = new System.Drawing.Size(132, 21);
            this.dateBegin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateBegin.TabIndex = 30;
            this.dateBegin.Tag = "dCreateDate >= @dBegin";
            // 
            // dateEnd
            // 
            // 
            // 
            // 
            this.dateEnd.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateEnd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateEnd.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateEnd.ButtonDropDown.Visible = true;
            this.dateEnd.IsPopupCalendarOpen = false;
            this.dateEnd.Location = new System.Drawing.Point(296, 145);
            this.dateEnd.LockUpdateChecked = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.dateEnd.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateEnd.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateEnd.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateEnd.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateEnd.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateEnd.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateEnd.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateEnd.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateEnd.MonthCalendar.DisplayMonth = new System.DateTime(2019, 6, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dateEnd.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateEnd.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateEnd.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateEnd.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateEnd.MonthCalendar.TodayButtonVisible = true;
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.ShowCheckBox = true;
            this.dateEnd.Size = new System.Drawing.Size(132, 21);
            this.dateEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateEnd.TabIndex = 31;
            this.dateEnd.Tag = "convert(char(10),dCreateDate,121) <= @dEnd";
            // 
            // chk_bClosed
            // 
            this.chk_bClosed.AutoSize = true;
            this.chk_bClosed.Checked = true;
            this.chk_bClosed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_bClosed.Location = new System.Drawing.Point(296, 227);
            this.chk_bClosed.Name = "chk_bClosed";
            this.chk_bClosed.Size = new System.Drawing.Size(84, 16);
            this.chk_bClosed.TabIndex = 32;
            this.chk_bClosed.Tag = "isnull(bClosed,0) = 0";
            this.chk_bClosed.Text = "隐藏已关闭";
            this.chk_bClosed.UseVisualStyleBackColor = true;
            // 
            // FmMaterialOutListQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(455, 505);
            this.DoubleBuffered = true;
            this.Name = "FmMaterialOutListQ";
            this.Controls.SetChildIndex(this.superTabControl1, 0);
            this.Controls.SetChildIndex(this.panelEx1, 0);
            this.superTabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.Controls.TextBoxX txt_cInvStd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_WOCode;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX2;
        private System.Windows.Forms.Label label9;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX3;
        private System.Windows.Forms.Label label10;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_cInvCode;
        private System.Windows.Forms.Label label11;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateEnd;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateBegin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chk_bClosed;
    }
}
