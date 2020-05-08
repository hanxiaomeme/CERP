namespace LanyunMES.UI
{
    partial class FmQmReportList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmQmReportList));
            this.ToolBar = new DevComponents.DotNetBar.Bar();
            this.btn_Print = new DevComponents.DotNetBar.ButtonItem();
            this.btn_Design = new DevComponents.DotNetBar.ButtonItem();
            this.btn_Export = new DevComponents.DotNetBar.ButtonItem();
            this.btn_Reflash = new DevComponents.DotNetBar.ButtonItem();
            this.BtnRDRecord = new DevComponents.DotNetBar.ButtonItem();
            this.BtnQmRecord = new DevComponents.DotNetBar.ButtonItem();
            this.btn_Exit = new DevComponents.DotNetBar.ButtonItem();
            this.StatusBar = new DevComponents.DotNetBar.Bar();
            this.sBar_lbl = new DevComponents.DotNetBar.LabelItem();
            this.btn_Query = new DevComponents.DotNetBar.ButtonX();
            this.PrintReport = new FastReport.Report();
            this.group1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cb_iState = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbox_bQuality = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dBegin = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txt_vendor = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.pnl_title = new DevComponents.DotNetBar.PanelEx();
            this.cb_showQPnl = new System.Windows.Forms.CheckBox();
            this.gridCtrl = new DevExpress.XtraGrid.GridControl();
            this.DGX = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.ToolBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintReport)).BeginInit();
            this.group1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBegin)).BeginInit();
            this.pnl_title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCtrl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGX)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            this.ToolBar.AntiAlias = true;
            this.ToolBar.BarType = DevComponents.DotNetBar.eBarType.MenuBar;
            this.ToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolBar.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.ToolBar.IsMaximized = false;
            this.ToolBar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_Print,
            this.btn_Export,
            this.btn_Reflash,
            this.BtnRDRecord,
            this.BtnQmRecord,
            this.btn_Exit});
            this.ToolBar.Location = new System.Drawing.Point(0, 0);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.Size = new System.Drawing.Size(1051, 27);
            this.ToolBar.Stretch = true;
            this.ToolBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ToolBar.TabIndex = 0;
            this.ToolBar.TabStop = false;
            this.ToolBar.Text = "bar1";
            // 
            // btn_Print
            // 
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_Design});
            this.btn_Print.Text = "打印(&P)";
            // 
            // btn_Design
            // 
            this.btn_Design.Name = "btn_Design";
            this.btn_Design.Text = "打印设计";
            // 
            // btn_Export
            // 
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Text = "导出(&D)";
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // btn_Reflash
            // 
            this.btn_Reflash.Name = "btn_Reflash";
            this.btn_Reflash.Text = "刷新(&R)";
            this.btn_Reflash.Click += new System.EventHandler(this.btn_Reflash_Click);
            // 
            // BtnRDRecord
            // 
            this.BtnRDRecord.BeginGroup = true;
            this.BtnRDRecord.ForeColor = System.Drawing.Color.Blue;
            this.BtnRDRecord.Name = "BtnRDRecord";
            this.BtnRDRecord.Text = "入库(&R)";
            this.BtnRDRecord.Visible = false;
            // 
            // BtnQmRecord
            // 
            this.BtnQmRecord.ForeColor = System.Drawing.Color.Red;
            this.BtnQmRecord.Name = "BtnQmRecord";
            this.BtnQmRecord.Text = "检验(&B)";
            this.BtnQmRecord.Visible = false;
            // 
            // btn_Exit
            // 
            this.btn_Exit.BeginGroup = true;
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Text = "退出(&E)";
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // StatusBar
            // 
            this.StatusBar.AntiAlias = true;
            this.StatusBar.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
            this.StatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StatusBar.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.StatusBar.IsMaximized = false;
            this.StatusBar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.sBar_lbl});
            this.StatusBar.Location = new System.Drawing.Point(0, 547);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(1051, 22);
            this.StatusBar.Stretch = true;
            this.StatusBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.StatusBar.TabIndex = 3;
            this.StatusBar.TabStop = false;
            this.StatusBar.Text = "bar2";
            // 
            // sBar_lbl
            // 
            this.sBar_lbl.Name = "sBar_lbl";
            this.sBar_lbl.Text = "--";
            // 
            // btn_Query
            // 
            this.btn_Query.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Query.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Query.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Query.Location = new System.Drawing.Point(83, 407);
            this.btn_Query.MaximumSize = new System.Drawing.Size(50, 50);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(50, 25);
            this.btn_Query.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_Query.TabIndex = 0;
            this.btn_Query.Text = "查 询";
            // 
            // PrintReport
            // 
            this.PrintReport.NeedRefresh = false;
            this.PrintReport.ReportResourceString = resources.GetString("PrintReport.ReportResourceString");
            // 
            // group1
            // 
            this.group1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.group1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.group1.CanvasColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.group1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.group1.Controls.Add(this.cb_iState);
            this.group1.Controls.Add(this.label5);
            this.group1.Controls.Add(this.label4);
            this.group1.Controls.Add(this.cbox_bQuality);
            this.group1.Controls.Add(this.label3);
            this.group1.Controls.Add(this.label2);
            this.group1.Controls.Add(this.label1);
            this.group1.Controls.Add(this.dEnd);
            this.group1.Controls.Add(this.dBegin);
            this.group1.Controls.Add(this.txt_vendor);
            this.group1.Controls.Add(this.btn_Query);
            this.group1.DisabledBackColor = System.Drawing.Color.Empty;
            this.group1.Location = new System.Drawing.Point(0, 73);
            this.group1.Name = "group1";
            this.group1.Size = new System.Drawing.Size(225, 468);
            // 
            // 
            // 
            this.group1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.group1.Style.BackColorGradientAngle = 90;
            this.group1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.group1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.group1.Style.BorderBottomWidth = 1;
            this.group1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.group1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.group1.Style.BorderLeftWidth = 1;
            this.group1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.group1.Style.BorderRightWidth = 1;
            this.group1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.group1.Style.BorderTopWidth = 1;
            this.group1.Style.CornerDiameter = 4;
            this.group1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.group1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.group1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.group1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.group1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.group1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.group1.TabIndex = 4;
            // 
            // cb_iState
            // 
            this.cb_iState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cb_iState.ForeColor = System.Drawing.Color.Black;
            this.cb_iState.FormattingEnabled = true;
            this.cb_iState.Items.AddRange(new object[] {
            "",
            "审核",
            "未审核"});
            this.cb_iState.Location = new System.Drawing.Point(83, 258);
            this.cb_iState.Name = "cb_iState";
            this.cb_iState.Size = new System.Drawing.Size(126, 20);
            this.cb_iState.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(12, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 25;
            this.label5.Text = "审核状态：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 24;
            this.label4.Text = "是否质检：";
            // 
            // cbox_bQuality
            // 
            this.cbox_bQuality.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbox_bQuality.ForeColor = System.Drawing.Color.Black;
            this.cbox_bQuality.FormattingEnabled = true;
            this.cbox_bQuality.Items.AddRange(new object[] {
            "",
            "是",
            "否"});
            this.cbox_bQuality.Location = new System.Drawing.Point(83, 220);
            this.cbox_bQuality.Name = "cbox_bQuality";
            this.cbox_bQuality.Size = new System.Drawing.Size(126, 20);
            this.cbox_bQuality.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(11, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "供应商编码/名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "至：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "日期：";
            // 
            // dEnd
            // 
            this.dEnd.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.dEnd.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dEnd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dEnd.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dEnd.ButtonDropDown.Visible = true;
            this.dEnd.ForeColor = System.Drawing.Color.Black;
            this.dEnd.IsPopupCalendarOpen = false;
            this.dEnd.Location = new System.Drawing.Point(13, 110);
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
            this.dEnd.MonthCalendar.DisplayMonth = new System.DateTime(2018, 8, 1, 0, 0, 0, 0);
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
            this.dEnd.Size = new System.Drawing.Size(196, 21);
            this.dEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dEnd.TabIndex = 4;
            this.dEnd.Tag = "dDate <= @dEnd";
            // 
            // dBegin
            // 
            this.dBegin.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.dBegin.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dBegin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dBegin.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dBegin.ButtonDropDown.Visible = true;
            this.dBegin.ForeColor = System.Drawing.Color.Black;
            this.dBegin.IsPopupCalendarOpen = false;
            this.dBegin.Location = new System.Drawing.Point(13, 58);
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
            this.dBegin.MonthCalendar.DisplayMonth = new System.DateTime(2018, 8, 1, 0, 0, 0, 0);
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
            this.dBegin.Size = new System.Drawing.Size(196, 21);
            this.dBegin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dBegin.TabIndex = 3;
            this.dBegin.Tag = "dDate >= @dBegin";
            // 
            // txt_vendor
            // 
            this.txt_vendor.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_vendor.Border.Class = "TextBoxBorder";
            this.txt_vendor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_vendor.DisabledBackColor = System.Drawing.Color.White;
            this.txt_vendor.ForeColor = System.Drawing.Color.Black;
            this.txt_vendor.Location = new System.Drawing.Point(12, 174);
            this.txt_vendor.Name = "txt_vendor";
            this.txt_vendor.PreventEnterBeep = true;
            this.txt_vendor.Size = new System.Drawing.Size(197, 21);
            this.txt_vendor.TabIndex = 1;
            this.txt_vendor.Tag = "cVenName like \'%\' + @cVenName or cVenCode like \'%\' + @cVenName";
            // 
            // pnl_title
            // 
            this.pnl_title.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnl_title.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnl_title.Controls.Add(this.cb_showQPnl);
            this.pnl_title.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnl_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_title.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnl_title.Location = new System.Drawing.Point(0, 27);
            this.pnl_title.Name = "pnl_title";
            this.pnl_title.Size = new System.Drawing.Size(1051, 40);
            this.pnl_title.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnl_title.Style.BackColor1.Color = System.Drawing.SystemColors.Control;
            this.pnl_title.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnl_title.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnl_title.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnl_title.Style.GradientAngle = 90;
            this.pnl_title.TabIndex = 15;
            this.pnl_title.Text = "待分配检验单列表";
            // 
            // cb_showQPnl
            // 
            this.cb_showQPnl.AutoSize = true;
            this.cb_showQPnl.Checked = true;
            this.cb_showQPnl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_showQPnl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_showQPnl.ForeColor = System.Drawing.Color.Black;
            this.cb_showQPnl.Location = new System.Drawing.Point(38, 13);
            this.cb_showQPnl.Name = "cb_showQPnl";
            this.cb_showQPnl.Size = new System.Drawing.Size(72, 16);
            this.cb_showQPnl.TabIndex = 1;
            this.cb_showQPnl.Text = "查询面板";
            this.cb_showQPnl.UseVisualStyleBackColor = true;
            // 
            // gridCtrl
            // 
            this.gridCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridCtrl.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridCtrl.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black;
            this.gridCtrl.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridCtrl.EmbeddedNavigator.Appearance.Options.UseForeColor = true;
            this.gridCtrl.Location = new System.Drawing.Point(231, 73);
            this.gridCtrl.MainView = this.DGX;
            this.gridCtrl.Name = "gridCtrl";
            this.gridCtrl.Size = new System.Drawing.Size(820, 468);
            this.gridCtrl.TabIndex = 19;
            this.gridCtrl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.DGX});
            // 
            // DGX
            // 
            this.DGX.GridControl = this.gridCtrl;
            this.DGX.Name = "DGX";
            this.DGX.OptionsBehavior.Editable = false;
            this.DGX.OptionsBehavior.ReadOnly = true;
            this.DGX.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.DGX.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.DGX.OptionsView.ColumnAutoWidth = false;
            this.DGX.OptionsView.ShowFooter = true;
            this.DGX.OptionsView.ShowGroupPanel = false;
            // 
            // FmQmReportList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1051, 569);
            this.Controls.Add(this.gridCtrl);
            this.Controls.Add(this.group1);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.pnl_title);
            this.Controls.Add(this.ToolBar);
            this.DoubleBuffered = true;
            this.Name = "FmQmReportList";
            this.ShowIcon = false;
            this.Text = "报检单列表";
            ((System.ComponentModel.ISupportInitialize)(this.ToolBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintReport)).EndInit();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBegin)).EndInit();
            this.pnl_title.ResumeLayout(false);
            this.pnl_title.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCtrl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelItem sBar_lbl;
        protected DevComponents.DotNetBar.ButtonItem btn_Print;
        protected DevComponents.DotNetBar.ButtonItem btn_Export;
        protected DevComponents.DotNetBar.ButtonItem btn_Reflash;
        protected DevComponents.DotNetBar.ButtonItem btn_Exit;
        protected DevComponents.DotNetBar.ButtonItem btn_Design;
        protected DevComponents.DotNetBar.ButtonX btn_Query;
        protected DevComponents.DotNetBar.Bar ToolBar;
        protected DevComponents.DotNetBar.Bar StatusBar;
        protected DevComponents.DotNetBar.Controls.GroupPanel group1;
        protected DevComponents.DotNetBar.PanelEx pnl_title;
        private FastReport.Report PrintReport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dEnd;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dBegin;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_vendor;
        private System.Windows.Forms.CheckBox cb_showQPnl;
        private DevExpress.XtraGrid.GridControl gridCtrl;
        private DevExpress.XtraGrid.Views.Grid.GridView DGX;
        private DevComponents.DotNetBar.ButtonItem BtnQmRecord;
        private DevComponents.DotNetBar.ButtonItem BtnRDRecord;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbox_bQuality;
        private System.Windows.Forms.ComboBox cb_iState;
        private System.Windows.Forms.Label label5;
    }
}