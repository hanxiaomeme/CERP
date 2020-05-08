namespace LanyunMES.UI
{
    partial class FmQOutSource
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
            this.dEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label2 = new System.Windows.Forms.Label();
            this.dBegin = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_cardNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_cInvStd = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_WOCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_cFree1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.Rb_Out = new System.Windows.Forms.RadioButton();
            this.Rb_In = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_cVenCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.Btn_Ref = new System.Windows.Forms.Button();
            this.superTabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBegin)).BeginInit();
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
            this.panelEx2.Controls.Add(this.Btn_Ref);
            this.panelEx2.Controls.Add(this.txt_cVenCode);
            this.panelEx2.Controls.Add(this.label7);
            this.panelEx2.Controls.Add(this.Rb_In);
            this.panelEx2.Controls.Add(this.Rb_Out);
            this.panelEx2.Controls.Add(this.label6);
            this.panelEx2.Controls.Add(this.txt_cFree1);
            this.panelEx2.Controls.Add(this.label5);
            this.panelEx2.Controls.Add(this.txt_WOCode);
            this.panelEx2.Controls.Add(this.txt_cInvStd);
            this.panelEx2.Controls.Add(this.label4);
            this.panelEx2.Controls.Add(this.label3);
            this.panelEx2.Controls.Add(this.dEnd);
            this.panelEx2.Controls.Add(this.label2);
            this.panelEx2.Controls.Add(this.dBegin);
            this.panelEx2.Controls.Add(this.label1);
            this.panelEx2.Controls.Add(this.txt_cardNo);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "流转卡号";
            // 
            // dEnd
            // 
            // 
            // 
            // 
            this.dEnd.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dEnd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dEnd.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dEnd.ButtonDropDown.Visible = true;
            this.dEnd.IsPopupCalendarOpen = false;
            this.dEnd.Location = new System.Drawing.Point(296, 31);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dEnd.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dEnd.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dEnd.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dEnd.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dEnd.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dEnd.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dEnd.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dEnd.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dEnd.MonthCalendar.DisplayMonth = new System.DateTime(2018, 3, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dEnd.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dEnd.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dEnd.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dEnd.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dEnd.MonthCalendar.TodayButtonVisible = true;
            this.dEnd.Name = "dEnd";
            this.dEnd.ShowCheckBox = true;
            this.dEnd.Size = new System.Drawing.Size(132, 21);
            this.dEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dEnd.TabIndex = 10;
            this.dEnd.Tag = "t1.dDate <= @dEnd";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "至";
            // 
            // dBegin
            // 
            // 
            // 
            // 
            this.dBegin.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dBegin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dBegin.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dBegin.ButtonDropDown.Visible = true;
            this.dBegin.IsPopupCalendarOpen = false;
            this.dBegin.Location = new System.Drawing.Point(81, 31);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dBegin.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dBegin.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dBegin.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dBegin.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dBegin.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dBegin.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dBegin.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dBegin.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dBegin.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dBegin.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dBegin.MonthCalendar.DisplayMonth = new System.DateTime(2018, 3, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dBegin.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dBegin.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dBegin.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dBegin.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dBegin.MonthCalendar.TodayButtonVisible = true;
            this.dBegin.Name = "dBegin";
            this.dBegin.ShowCheckBox = true;
            this.dBegin.Size = new System.Drawing.Size(132, 21);
            this.dBegin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dBegin.TabIndex = 8;
            this.dBegin.Tag = "t1.dDate >= @dBegin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "日期";
            // 
            // txt_cardNo
            // 
            this.txt_cardNo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_cardNo.Border.Class = "TextBoxBorder";
            this.txt_cardNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_cardNo.DisabledBackColor = System.Drawing.Color.White;
            this.txt_cardNo.ForeColor = System.Drawing.Color.Black;
            this.txt_cardNo.Location = new System.Drawing.Point(81, 67);
            this.txt_cardNo.Name = "txt_cardNo";
            this.txt_cardNo.PreventEnterBeep = true;
            this.txt_cardNo.Size = new System.Drawing.Size(132, 21);
            this.txt_cardNo.TabIndex = 6;
            this.txt_cardNo.Tag = "t3.cardNo = @cardNo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(235, 72);
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
            this.txt_cInvStd.Location = new System.Drawing.Point(296, 67);
            this.txt_cInvStd.Name = "txt_cInvStd";
            this.txt_cInvStd.PreventEnterBeep = true;
            this.txt_cInvStd.Size = new System.Drawing.Size(132, 21);
            this.txt_cInvStd.TabIndex = 13;
            this.txt_cInvStd.Tag = "inv.cInvStd like @cInvStd";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "单据号";
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
            this.txt_WOCode.Location = new System.Drawing.Point(81, 103);
            this.txt_WOCode.Name = "txt_WOCode";
            this.txt_WOCode.PreventEnterBeep = true;
            this.txt_WOCode.Size = new System.Drawing.Size(132, 21);
            this.txt_WOCode.TabIndex = 14;
            this.txt_WOCode.Tag = "t1.cCode = @cCode";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(259, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "头标";
            // 
            // txt_cFree1
            // 
            this.txt_cFree1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_cFree1.Border.Class = "TextBoxBorder";
            this.txt_cFree1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_cFree1.DisabledBackColor = System.Drawing.Color.White;
            this.txt_cFree1.ForeColor = System.Drawing.Color.Black;
            this.txt_cFree1.Location = new System.Drawing.Point(296, 103);
            this.txt_cFree1.Name = "txt_cFree1";
            this.txt_cFree1.PreventEnterBeep = true;
            this.txt_cFree1.Size = new System.Drawing.Size(132, 21);
            this.txt_cFree1.TabIndex = 16;
            this.txt_cFree1.Tag = "t3.Free1 = @Free1";
            // 
            // Rb_Out
            // 
            this.Rb_Out.AutoSize = true;
            this.Rb_Out.Checked = true;
            this.Rb_Out.Location = new System.Drawing.Point(45, 185);
            this.Rb_Out.Name = "Rb_Out";
            this.Rb_Out.Size = new System.Drawing.Size(71, 16);
            this.Rb_Out.TabIndex = 18;
            this.Rb_Out.TabStop = true;
            this.Rb_Out.Text = "委外出库";
            this.Rb_Out.UseVisualStyleBackColor = true;
            // 
            // Rb_In
            // 
            this.Rb_In.AutoSize = true;
            this.Rb_In.Location = new System.Drawing.Point(142, 185);
            this.Rb_In.Name = "Rb_In";
            this.Rb_In.Size = new System.Drawing.Size(71, 16);
            this.Rb_In.TabIndex = 19;
            this.Rb_In.TabStop = true;
            this.Rb_In.Text = "委外入库";
            this.Rb_In.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "供应商编码";
            // 
            // txt_cVenCode
            // 
            this.txt_cVenCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_cVenCode.Border.Class = "TextBoxBorder";
            this.txt_cVenCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_cVenCode.DisabledBackColor = System.Drawing.Color.White;
            this.txt_cVenCode.ForeColor = System.Drawing.Color.Black;
            this.txt_cVenCode.Location = new System.Drawing.Point(81, 143);
            this.txt_cVenCode.Name = "txt_cVenCode";
            this.txt_cVenCode.PreventEnterBeep = true;
            this.txt_cVenCode.Size = new System.Drawing.Size(132, 21);
            this.txt_cVenCode.TabIndex = 21;
            this.txt_cVenCode.Tag = "t1.cVenCode = @cVenCode";
            this.txt_cVenCode.MouseEnter += new System.EventHandler(this.txt_cVenCode_MouseEnter);
            // 
            // Btn_Ref
            // 
            this.Btn_Ref.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Ref.ForeColor = System.Drawing.Color.SteelBlue;
            this.Btn_Ref.Location = new System.Drawing.Point(214, 143);
            this.Btn_Ref.Name = "Btn_Ref";
            this.Btn_Ref.Size = new System.Drawing.Size(21, 21);
            this.Btn_Ref.TabIndex = 22;
            this.Btn_Ref.Text = "R";
            this.Btn_Ref.UseVisualStyleBackColor = true;
            this.Btn_Ref.Visible = false;
            this.Btn_Ref.Click += new System.EventHandler(this.Btn_Ref_Click);
            // 
            // FmQOutSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(455, 505);
            this.Name = "FmQOutSource";
            this.Controls.SetChildIndex(this.superTabControl1, 0);
            this.Controls.SetChildIndex(this.panelEx1, 0);
            this.superTabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBegin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dEnd;
        private System.Windows.Forms.Label label2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dBegin;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_cardNo;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_cInvStd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_WOCode;
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_cFree1;
        private System.Windows.Forms.RadioButton Rb_In;
        private System.Windows.Forms.RadioButton Rb_Out;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_cVenCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Btn_Ref;
    }
}
