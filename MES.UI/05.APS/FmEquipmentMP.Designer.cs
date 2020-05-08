namespace LanyunMES.UI
{
    partial class FmEquipmentMP
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmEquipmentMP));
            this.lblModuleTitle = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Head_Bar = new DevComponents.DotNetBar.Bar();
            this.btn_Save = new DevComponents.DotNetBar.ButtonItem();
            this.btn_Exit = new DevComponents.DotNetBar.ButtonItem();
            this.Main_pnl = new DevComponents.DotNetBar.PanelEx();
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxX2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtr_iHours = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtr_cMaker = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtr_cEQCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtr_cEQName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tab_Main = new DevComponents.DotNetBar.SuperTabItem();
            this.Status_Bar = new DevComponents.DotNetBar.Bar();
            this.lbl_status = new DevComponents.DotNetBar.LabelItem();
            this.txt_workhours = new DevComponents.DotNetBar.Controls.TextBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.Head_Bar)).BeginInit();
            this.Main_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Status_Bar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblModuleTitle
            // 
            this.lblModuleTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblModuleTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblModuleTitle.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblModuleTitle.ForeColor = System.Drawing.Color.Black;
            this.lblModuleTitle.Location = new System.Drawing.Point(0, 0);
            this.lblModuleTitle.Name = "lblModuleTitle";
            this.lblModuleTitle.Size = new System.Drawing.Size(492, 35);
            this.lblModuleTitle.TabIndex = 0;
            this.lblModuleTitle.Text = "设备维护计划";
            this.lblModuleTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "book.png");
            this.imageList1.Images.SetKeyName(1, "out.png");
            this.imageList1.Images.SetKeyName(2, "pen.png");
            this.imageList1.Images.SetKeyName(3, "refresh.png");
            this.imageList1.Images.SetKeyName(4, "trash.png");
            // 
            // Head_Bar
            // 
            this.Head_Bar.AntiAlias = true;
            this.Head_Bar.Dock = System.Windows.Forms.DockStyle.Top;
            this.Head_Bar.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Head_Bar.Images = this.imageList1;
            this.Head_Bar.IsMaximized = false;
            this.Head_Bar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_Save,
            this.btn_Exit});
            this.Head_Bar.Location = new System.Drawing.Point(0, 0);
            this.Head_Bar.Name = "Head_Bar";
            this.Head_Bar.Size = new System.Drawing.Size(492, 43);
            this.Head_Bar.Stretch = true;
            this.Head_Bar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Head_Bar.TabIndex = 1;
            this.Head_Bar.TabStop = false;
            this.Head_Bar.Text = "bar1";
            // 
            // btn_Save
            // 
            this.btn_Save.ImageIndex = 0;
            this.btn_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Text = "保存";
            // 
            // btn_Exit
            // 
            this.btn_Exit.ImageIndex = 1;
            this.btn_Exit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Text = "退出";
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // Main_pnl
            // 
            this.Main_pnl.CanvasColor = System.Drawing.SystemColors.Control;
            this.Main_pnl.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Main_pnl.Controls.Add(this.superTabControl1);
            this.Main_pnl.Controls.Add(this.lblModuleTitle);
            this.Main_pnl.DisabledBackColor = System.Drawing.Color.Empty;
            this.Main_pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_pnl.Location = new System.Drawing.Point(0, 43);
            this.Main_pnl.Name = "Main_pnl";
            this.Main_pnl.Size = new System.Drawing.Size(492, 404);
            this.Main_pnl.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.Main_pnl.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.Main_pnl.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.Main_pnl.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.Main_pnl.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.Main_pnl.Style.GradientAngle = 90;
            this.Main_pnl.TabIndex = 0;
            this.Main_pnl.Text = "panelEx1";
            // 
            // superTabControl1
            // 
            this.superTabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
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
            this.superTabControl1.Controls.Add(this.superTabControlPanel1);
            this.superTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl1.ForeColor = System.Drawing.Color.Black;
            this.superTabControl1.Location = new System.Drawing.Point(0, 35);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.superTabControl1.SelectedTabIndex = 0;
            this.superTabControl1.Size = new System.Drawing.Size(492, 369);
            this.superTabControl1.TabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superTabControl1.TabIndex = 1;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tab_Main});
            this.superTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue;
            this.superTabControl1.Text = "superTabControl1";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.txt_workhours);
            this.superTabControlPanel1.Controls.Add(this.textBoxX1);
            this.superTabControlPanel1.Controls.Add(this.textBoxX2);
            this.superTabControlPanel1.Controls.Add(this.label9);
            this.superTabControlPanel1.Controls.Add(this.label8);
            this.superTabControlPanel1.Controls.Add(this.txtr_iHours);
            this.superTabControlPanel1.Controls.Add(this.label7);
            this.superTabControlPanel1.Controls.Add(this.label6);
            this.superTabControlPanel1.Controls.Add(this.numericUpDown1);
            this.superTabControlPanel1.Controls.Add(this.label4);
            this.superTabControlPanel1.Controls.Add(this.txtr_cMaker);
            this.superTabControlPanel1.Controls.Add(this.label3);
            this.superTabControlPanel1.Controls.Add(this.dateTimePicker1);
            this.superTabControlPanel1.Controls.Add(this.label2);
            this.superTabControlPanel1.Controls.Add(this.txtr_cEQCode);
            this.superTabControlPanel1.Controls.Add(this.txtr_cEQName);
            this.superTabControlPanel1.Controls.Add(this.label5);
            this.superTabControlPanel1.Controls.Add(this.label1);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 26);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(492, 343);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.tab_Main;
            // 
            // textBoxX1
            // 
            this.textBoxX1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.ButtonCustom.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBoxX1.ButtonCustom.SymbolColor = System.Drawing.Color.RoyalBlue;
            this.textBoxX1.ButtonCustom.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.textBoxX1.ButtonCustom2.Enabled = false;
            this.textBoxX1.DisabledBackColor = System.Drawing.Color.White;
            this.textBoxX1.ForeColor = System.Drawing.Color.Black;
            this.textBoxX1.Location = new System.Drawing.Point(108, 186);
            this.textBoxX1.Multiline = true;
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.PreventEnterBeep = true;
            this.textBoxX1.Size = new System.Drawing.Size(361, 56);
            this.textBoxX1.TabIndex = 34;
            this.textBoxX1.Tag = "reason";
            // 
            // textBoxX2
            // 
            this.textBoxX2.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // 
            // 
            this.textBoxX2.Border.Class = "TextBoxBorder";
            this.textBoxX2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX2.ButtonCustom.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBoxX2.ButtonCustom.SymbolColor = System.Drawing.Color.RoyalBlue;
            this.textBoxX2.ButtonCustom.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.textBoxX2.ButtonCustom2.Enabled = false;
            this.textBoxX2.DisabledBackColor = System.Drawing.Color.White;
            this.textBoxX2.ForeColor = System.Drawing.Color.Black;
            this.textBoxX2.Location = new System.Drawing.Point(349, 264);
            this.textBoxX2.Name = "textBoxX2";
            this.textBoxX2.PreventEnterBeep = true;
            this.textBoxX2.ReadOnly = true;
            this.textBoxX2.Size = new System.Drawing.Size(120, 21);
            this.textBoxX2.TabIndex = 33;
            this.textBoxX2.Tag = "dCreateDate";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(277, 270);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 32;
            this.label9.Text = "制单日期：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(34, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 30;
            this.label8.Text = "停机原因：";
            // 
            // txtr_iHours
            // 
            this.txtr_iHours.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // 
            // 
            this.txtr_iHours.Border.Class = "TextBoxBorder";
            this.txtr_iHours.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_iHours.ButtonCustom.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtr_iHours.ButtonCustom.SymbolColor = System.Drawing.Color.RoyalBlue;
            this.txtr_iHours.ButtonCustom.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.txtr_iHours.ButtonCustom2.Enabled = false;
            this.txtr_iHours.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_iHours.ForeColor = System.Drawing.Color.Black;
            this.txtr_iHours.Location = new System.Drawing.Point(349, 97);
            this.txtr_iHours.Name = "txtr_iHours";
            this.txtr_iHours.PreventEnterBeep = true;
            this.txtr_iHours.ReadOnly = true;
            this.txtr_iHours.Size = new System.Drawing.Size(120, 21);
            this.txtr_iHours.TabIndex = 29;
            this.txtr_iHours.Tag = "iHours";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(265, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = "工作效率/H：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(265, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 26;
            this.label6.Text = "工作时间/H：";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 1;
            this.numericUpDown1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDown1.Location = new System.Drawing.Point(108, 137);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 21);
            this.numericUpDown1.TabIndex = 25;
            this.numericUpDown1.Tag = "stopHours";
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(25, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 24;
            this.label4.Text = "停机时间/H：";
            // 
            // txtr_cMaker
            // 
            this.txtr_cMaker.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // 
            // 
            this.txtr_cMaker.Border.Class = "TextBoxBorder";
            this.txtr_cMaker.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_cMaker.ButtonCustom.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtr_cMaker.ButtonCustom.SymbolColor = System.Drawing.Color.RoyalBlue;
            this.txtr_cMaker.ButtonCustom.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.txtr_cMaker.ButtonCustom2.Enabled = false;
            this.txtr_cMaker.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_cMaker.ForeColor = System.Drawing.Color.Black;
            this.txtr_cMaker.Location = new System.Drawing.Point(108, 265);
            this.txtr_cMaker.Name = "txtr_cMaker";
            this.txtr_cMaker.PreventEnterBeep = true;
            this.txtr_cMaker.ReadOnly = true;
            this.txtr_cMaker.Size = new System.Drawing.Size(120, 21);
            this.txtr_cMaker.TabIndex = 23;
            this.txtr_cMaker.Tag = "cMaker";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(46, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "制单人：";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(108, 97);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(120, 21);
            this.dateTimePicker1.TabIndex = 21;
            this.dateTimePicker1.Tag = "dDate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(58, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "日期：";
            // 
            // txtr_cEQCode
            // 
            this.txtr_cEQCode.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // 
            // 
            this.txtr_cEQCode.Border.Class = "TextBoxBorder";
            this.txtr_cEQCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_cEQCode.ButtonCustom.Tooltip = "存货档案";
            this.txtr_cEQCode.ButtonCustom.Visible = true;
            this.txtr_cEQCode.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_cEQCode.ForeColor = System.Drawing.Color.Black;
            this.txtr_cEQCode.Location = new System.Drawing.Point(108, 23);
            this.txtr_cEQCode.Name = "txtr_cEQCode";
            this.txtr_cEQCode.PreventEnterBeep = true;
            this.txtr_cEQCode.ReadOnly = true;
            this.txtr_cEQCode.Size = new System.Drawing.Size(165, 21);
            this.txtr_cEQCode.TabIndex = 19;
            this.txtr_cEQCode.Tag = "cEQCode";
            // 
            // txtr_cEQName
            // 
            this.txtr_cEQName.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // 
            // 
            this.txtr_cEQName.Border.Class = "TextBoxBorder";
            this.txtr_cEQName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_cEQName.ButtonCustom.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtr_cEQName.ButtonCustom.SymbolColor = System.Drawing.Color.RoyalBlue;
            this.txtr_cEQName.ButtonCustom.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.txtr_cEQName.ButtonCustom2.Enabled = false;
            this.txtr_cEQName.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_cEQName.ForeColor = System.Drawing.Color.Black;
            this.txtr_cEQName.Location = new System.Drawing.Point(108, 59);
            this.txtr_cEQName.Name = "txtr_cEQName";
            this.txtr_cEQName.PreventEnterBeep = true;
            this.txtr_cEQName.ReadOnly = true;
            this.txtr_cEQName.Size = new System.Drawing.Size(165, 21);
            this.txtr_cEQName.TabIndex = 18;
            this.txtr_cEQName.Tag = "cEQName";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(34, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "设备名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(34, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "设备编码：";
            // 
            // tab_Main
            // 
            this.tab_Main.AttachedControl = this.superTabControlPanel1;
            this.tab_Main.GlobalItem = false;
            this.tab_Main.Name = "tab_Main";
            this.tab_Main.Text = "模块名称";
            // 
            // Status_Bar
            // 
            this.Status_Bar.AntiAlias = true;
            this.Status_Bar.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
            this.Status_Bar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Status_Bar.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Status_Bar.IsMaximized = false;
            this.Status_Bar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lbl_status});
            this.Status_Bar.Location = new System.Drawing.Point(0, 447);
            this.Status_Bar.Name = "Status_Bar";
            this.Status_Bar.Size = new System.Drawing.Size(492, 22);
            this.Status_Bar.Stretch = true;
            this.Status_Bar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Status_Bar.TabIndex = 0;
            this.Status_Bar.TabStop = false;
            this.Status_Bar.Text = "bar1";
            // 
            // lbl_status
            // 
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Text = "--";
            // 
            // txt_workhours
            // 
            this.txt_workhours.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // 
            // 
            this.txt_workhours.Border.Class = "TextBoxBorder";
            this.txt_workhours.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_workhours.ButtonCustom.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txt_workhours.ButtonCustom.SymbolColor = System.Drawing.Color.RoyalBlue;
            this.txt_workhours.ButtonCustom.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.txt_workhours.ButtonCustom2.Enabled = false;
            this.txt_workhours.DisabledBackColor = System.Drawing.Color.White;
            this.txt_workhours.ForeColor = System.Drawing.Color.Black;
            this.txt_workhours.Location = new System.Drawing.Point(348, 137);
            this.txt_workhours.Name = "txt_workhours";
            this.txt_workhours.PreventEnterBeep = true;
            this.txt_workhours.ReadOnly = true;
            this.txt_workhours.Size = new System.Drawing.Size(120, 21);
            this.txt_workhours.TabIndex = 35;
            this.txt_workhours.Tag = "workHours";
            // 
            // FmEquipmentMP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 469);
            this.Controls.Add(this.Main_pnl);
            this.Controls.Add(this.Head_Bar);
            this.Controls.Add(this.Status_Bar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FmEquipmentMP";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FmBIU";
            ((System.ComponentModel.ISupportInitialize)(this.Head_Bar)).EndInit();
            this.Main_pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.superTabControlPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Status_Bar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label lblModuleTitle;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.ButtonItem btn_Save;
        private DevComponents.DotNetBar.ButtonItem btn_Exit;
        private DevComponents.DotNetBar.LabelItem lbl_status;
        protected DevComponents.DotNetBar.Bar Head_Bar;
        protected DevComponents.DotNetBar.Bar Status_Bar;
        protected DevComponents.DotNetBar.SuperTabControl superTabControl1;
        protected DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        protected DevComponents.DotNetBar.SuperTabItem tab_Main;
        protected DevComponents.DotNetBar.PanelEx Main_pnl;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_cEQCode;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_cEQName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_cMaker;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_iHours;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_workhours;
    }
}