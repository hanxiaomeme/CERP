namespace LanyunMES.UI
{
    partial class FmQMomList
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
            this.txt_cMoCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.dBegin = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label2 = new System.Windows.Forms.Label();
            this.dEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_cInvStd = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxX3 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_cInvCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_MoType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.chk_bWOCreated = new System.Windows.Forms.CheckBox();
            this.superTabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dBegin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Size = new System.Drawing.Size(474, 457);
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
            this.superTabControl1.Size = new System.Drawing.Size(474, 483);
            this.superTabControl1.Controls.SetChildIndex(this.superTabControlPanel1, 0);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(380, 5);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(311, 5);
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // panelEx2
            // 
            this.panelEx2.Controls.Add(this.chk_bWOCreated);
            this.panelEx2.Controls.Add(this.cb_MoType);
            this.panelEx2.Controls.Add(this.label4);
            this.panelEx2.Controls.Add(this.txt_cInvCode);
            this.panelEx2.Controls.Add(this.label13);
            this.panelEx2.Controls.Add(this.textBoxX3);
            this.panelEx2.Controls.Add(this.label10);
            this.panelEx2.Controls.Add(this.txt_cInvStd);
            this.panelEx2.Controls.Add(this.label5);
            this.panelEx2.Controls.Add(this.label3);
            this.panelEx2.Controls.Add(this.dEnd);
            this.panelEx2.Controls.Add(this.label2);
            this.panelEx2.Controls.Add(this.dBegin);
            this.panelEx2.Controls.Add(this.label1);
            this.panelEx2.Controls.Add(this.txt_cMoCode);
            this.panelEx2.Size = new System.Drawing.Size(474, 457);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            // 
            // panelEx1
            // 
            this.panelEx1.Location = new System.Drawing.Point(0, 448);
            this.panelEx1.Size = new System.Drawing.Size(474, 35);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            // 
            // txt_cMoCode
            // 
            this.txt_cMoCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_cMoCode.Border.Class = "TextBoxBorder";
            this.txt_cMoCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_cMoCode.DisabledBackColor = System.Drawing.Color.White;
            this.txt_cMoCode.ForeColor = System.Drawing.Color.Black;
            this.txt_cMoCode.Location = new System.Drawing.Point(89, 74);
            this.txt_cMoCode.Name = "txt_cMoCode";
            this.txt_cMoCode.PreventEnterBeep = true;
            this.txt_cMoCode.Size = new System.Drawing.Size(132, 21);
            this.txt_cMoCode.TabIndex = 0;
            this.txt_cMoCode.Tag = "MoCode = @MoCode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "日期";
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
            this.dBegin.Location = new System.Drawing.Point(89, 36);
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
            this.dBegin.TabIndex = 2;
            this.dBegin.Tag = "createDate >= @dBegin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "至";
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
            this.dEnd.Location = new System.Drawing.Point(308, 36);
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
            this.dEnd.Size = new System.Drawing.Size(137, 21);
            this.dEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dEnd.TabIndex = 4;
            this.dEnd.Tag = "createDate <= @dEnd";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "生产订单号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "规格型号";
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
            this.txt_cInvStd.Location = new System.Drawing.Point(308, 116);
            this.txt_cInvStd.Name = "txt_cInvStd";
            this.txt_cInvStd.PreventEnterBeep = true;
            this.txt_cInvStd.Size = new System.Drawing.Size(137, 21);
            this.txt_cInvStd.TabIndex = 9;
            this.txt_cInvStd.Tag = "cInvStd like @cInvStd";
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
            this.textBoxX3.Location = new System.Drawing.Point(308, 74);
            this.textBoxX3.Name = "textBoxX3";
            this.textBoxX3.PreventEnterBeep = true;
            this.textBoxX3.Size = new System.Drawing.Size(137, 21);
            this.textBoxX3.TabIndex = 27;
            this.textBoxX3.Tag = "SortSeq = @SortSeq";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(265, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 26;
            this.label10.Text = "行号";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 120);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 41;
            this.label13.Text = "存货编码";
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
            this.txt_cInvCode.Location = new System.Drawing.Point(89, 116);
            this.txt_cInvCode.Name = "txt_cInvCode";
            this.txt_cInvCode.PreventEnterBeep = true;
            this.txt_cInvCode.Size = new System.Drawing.Size(132, 21);
            this.txt_cInvCode.TabIndex = 42;
            this.txt_cInvCode.Tag = "cInvCode = @cInvCode";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 43;
            this.label4.Text = "生产类别";
            // 
            // cb_MoType
            // 
            this.cb_MoType.DisplayMember = "Text";
            this.cb_MoType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_MoType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_MoType.ForeColor = System.Drawing.Color.Black;
            this.cb_MoType.FormattingEnabled = true;
            this.cb_MoType.ItemHeight = 15;
            this.cb_MoType.Location = new System.Drawing.Point(89, 157);
            this.cb_MoType.Name = "cb_MoType";
            this.cb_MoType.Size = new System.Drawing.Size(132, 21);
            this.cb_MoType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_MoType.TabIndex = 44;
            this.cb_MoType.Tag = "MoTypeId = @MoTypeId";
            // 
            // chk_bWOCreated
            // 
            this.chk_bWOCreated.AutoSize = true;
            this.chk_bWOCreated.Checked = true;
            this.chk_bWOCreated.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_bWOCreated.Location = new System.Drawing.Point(89, 209);
            this.chk_bWOCreated.Name = "chk_bWOCreated";
            this.chk_bWOCreated.Size = new System.Drawing.Size(144, 16);
            this.chk_bWOCreated.TabIndex = 46;
            this.chk_bWOCreated.Tag = "u8modid = 0";
            this.chk_bWOCreated.Text = "隐藏已生成指令单订单";
            this.chk_bWOCreated.UseVisualStyleBackColor = true;
            // 
            // FmQMomList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(474, 483);
            this.Name = "FmQMomList";
            this.Controls.SetChildIndex(this.superTabControl1, 0);
            this.Controls.SetChildIndex(this.panelEx1, 0);
            this.superTabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dBegin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEnd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txt_cMoCode;
        private System.Windows.Forms.Label label3;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dEnd;
        private System.Windows.Forms.Label label2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dBegin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_cInvStd;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX3;
        private System.Windows.Forms.Label label10;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_cInvCode;
        private System.Windows.Forms.Label label13;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cb_MoType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chk_bWOCreated;
    }
}
