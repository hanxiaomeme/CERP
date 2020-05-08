namespace LanyunMES.UI
{
    partial class FmMouldInv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmMouldInv));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblModuleTitle = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Head_Bar = new DevComponents.DotNetBar.Bar();
            this.btn_Save = new DevComponents.DotNetBar.ButtonItem();
            this.btn_Exit = new DevComponents.DotNetBar.ButtonItem();
            this.Main_pnl = new DevComponents.DotNetBar.PanelEx();
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.Grid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btn_down = new DevComponents.DotNetBar.ButtonX();
            this.btn_up = new DevComponents.DotNetBar.ButtonX();
            this.btn_DelLine = new DevComponents.DotNetBar.ButtonX();
            this.btn_AddLine = new DevComponents.DotNetBar.ButtonX();
            this.txtr_cMName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtr_cMCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.txtr_OpCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.txtr_cMCName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tab_Main = new DevComponents.DotNetBar.SuperTabItem();
            this.Status_Bar = new DevComponents.DotNetBar.Bar();
            this.lbl_status = new DevComponents.DotNetBar.LabelItem();
            this.cbk_bGroup = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Head_Bar)).BeginInit();
            this.Main_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.panelEx1.SuspendLayout();
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
            this.lblModuleTitle.Size = new System.Drawing.Size(484, 35);
            this.lblModuleTitle.TabIndex = 0;
            this.lblModuleTitle.Text = "模具产品对照表";
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
            this.Head_Bar.Size = new System.Drawing.Size(484, 43);
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
            this.Main_pnl.Size = new System.Drawing.Size(484, 449);
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
            this.superTabControl1.Size = new System.Drawing.Size(484, 414);
            this.superTabControl1.TabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superTabControl1.TabIndex = 1;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tab_Main});
            this.superTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue;
            this.superTabControl1.Text = "superTabControl1";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.Grid);
            this.superTabControlPanel1.Controls.Add(this.panelEx1);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 26);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(484, 388);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.tab_Main;
            // 
            // Grid
            // 
            this.Grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Grid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grid.DefaultCellStyle = dataGridViewCellStyle3;
            this.Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.Grid.Location = new System.Drawing.Point(0, 145);
            this.Grid.Name = "Grid";
            this.Grid.RowTemplate.Height = 23;
            this.Grid.Size = new System.Drawing.Size(484, 243);
            this.Grid.TabIndex = 10;
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.cbk_bGroup);
            this.panelEx1.Controls.Add(this.btn_down);
            this.panelEx1.Controls.Add(this.btn_up);
            this.panelEx1.Controls.Add(this.btn_DelLine);
            this.panelEx1.Controls.Add(this.btn_AddLine);
            this.panelEx1.Controls.Add(this.txtr_cMName);
            this.panelEx1.Controls.Add(this.txtr_cMCode);
            this.panelEx1.Controls.Add(this.label3);
            this.panelEx1.Controls.Add(this.txtr_OpCode);
            this.panelEx1.Controls.Add(this.label1);
            this.panelEx1.Controls.Add(this.txtr_cMCName);
            this.panelEx1.Controls.Add(this.label4);
            this.panelEx1.Controls.Add(this.label2);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(484, 145);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 10;
            // 
            // btn_down
            // 
            this.btn_down.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_down.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_down.Location = new System.Drawing.Point(160, 116);
            this.btn_down.Name = "btn_down";
            this.btn_down.Size = new System.Drawing.Size(40, 20);
            this.btn_down.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_down.TabIndex = 13;
            this.btn_down.Text = "下移";
            this.btn_down.Visible = false;
            // 
            // btn_up
            // 
            this.btn_up.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_up.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_up.Location = new System.Drawing.Point(114, 116);
            this.btn_up.Name = "btn_up";
            this.btn_up.Size = new System.Drawing.Size(40, 20);
            this.btn_up.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_up.TabIndex = 12;
            this.btn_up.Text = "上移";
            this.btn_up.Visible = false;
            // 
            // btn_DelLine
            // 
            this.btn_DelLine.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_DelLine.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_DelLine.Location = new System.Drawing.Point(59, 116);
            this.btn_DelLine.Name = "btn_DelLine";
            this.btn_DelLine.Size = new System.Drawing.Size(40, 20);
            this.btn_DelLine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_DelLine.TabIndex = 11;
            this.btn_DelLine.Text = "删行";
            // 
            // btn_AddLine
            // 
            this.btn_AddLine.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_AddLine.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_AddLine.Location = new System.Drawing.Point(13, 116);
            this.btn_AddLine.Name = "btn_AddLine";
            this.btn_AddLine.Size = new System.Drawing.Size(40, 20);
            this.btn_AddLine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_AddLine.TabIndex = 10;
            this.btn_AddLine.Text = "增加";
            this.btn_AddLine.Click += new System.EventHandler(this.btn_AddLine_Click);
            // 
            // txtr_cMName
            // 
            this.txtr_cMName.BackColor = System.Drawing.Color.LemonChiffon;
            // 
            // 
            // 
            this.txtr_cMName.Border.Class = "TextBoxBorder";
            this.txtr_cMName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_cMName.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_cMName.ForeColor = System.Drawing.Color.Black;
            this.txtr_cMName.Location = new System.Drawing.Point(316, 18);
            this.txtr_cMName.Name = "txtr_cMName";
            this.txtr_cMName.PreventEnterBeep = true;
            this.txtr_cMName.ReadOnly = true;
            this.txtr_cMName.Size = new System.Drawing.Size(140, 21);
            this.txtr_cMName.TabIndex = 2;
            this.txtr_cMName.Tag = "cMName";
            // 
            // txtr_cMCode
            // 
            this.txtr_cMCode.BackColor = System.Drawing.Color.LemonChiffon;
            // 
            // 
            // 
            this.txtr_cMCode.Border.Class = "TextBoxBorder";
            this.txtr_cMCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_cMCode.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_cMCode.ForeColor = System.Drawing.Color.Black;
            this.txtr_cMCode.Location = new System.Drawing.Point(84, 18);
            this.txtr_cMCode.Name = "txtr_cMCode";
            this.txtr_cMCode.PreventEnterBeep = true;
            this.txtr_cMCode.ReadOnly = true;
            this.txtr_cMCode.Size = new System.Drawing.Size(140, 21);
            this.txtr_cMCode.TabIndex = 0;
            this.txtr_cMCode.Tag = "cMCode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "模具分类";
            // 
            // txtr_OpCode
            // 
            this.txtr_OpCode.BackColor = System.Drawing.Color.LemonChiffon;
            // 
            // 
            // 
            this.txtr_OpCode.Border.Class = "TextBoxBorder";
            this.txtr_OpCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_OpCode.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_OpCode.ForeColor = System.Drawing.Color.Black;
            this.txtr_OpCode.Location = new System.Drawing.Point(316, 55);
            this.txtr_OpCode.Name = "txtr_OpCode";
            this.txtr_OpCode.PreventEnterBeep = true;
            this.txtr_OpCode.ReadOnly = true;
            this.txtr_OpCode.Size = new System.Drawing.Size(140, 21);
            this.txtr_OpCode.TabIndex = 6;
            this.txtr_OpCode.Tag = "Points";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "模具编码";
            // 
            // txtr_cMCName
            // 
            this.txtr_cMCName.BackColor = System.Drawing.Color.LemonChiffon;
            // 
            // 
            // 
            this.txtr_cMCName.Border.Class = "TextBoxBorder";
            this.txtr_cMCName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_cMCName.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_cMCName.ForeColor = System.Drawing.Color.Black;
            this.txtr_cMCName.Location = new System.Drawing.Point(84, 55);
            this.txtr_cMCName.Name = "txtr_cMCName";
            this.txtr_cMCName.PreventEnterBeep = true;
            this.txtr_cMCName.ReadOnly = true;
            this.txtr_cMCName.Size = new System.Drawing.Size(140, 21);
            this.txtr_cMCName.TabIndex = 4;
            this.txtr_cMCName.Tag = "cMCName";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(269, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "穴数";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "模具名称";
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
            this.Status_Bar.Location = new System.Drawing.Point(0, 492);
            this.Status_Bar.Name = "Status_Bar";
            this.Status_Bar.Size = new System.Drawing.Size(484, 22);
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
            // cbk_bGroup
            // 
            this.cbk_bGroup.AutoCheck = false;
            this.cbk_bGroup.AutoSize = true;
            this.cbk_bGroup.Location = new System.Drawing.Point(396, 91);
            this.cbk_bGroup.Name = "cbk_bGroup";
            this.cbk_bGroup.Size = new System.Drawing.Size(60, 16);
            this.cbk_bGroup.TabIndex = 14;
            this.cbk_bGroup.Tag = "bGroup";
            this.cbk_bGroup.Text = "成套模";
            this.cbk_bGroup.UseVisualStyleBackColor = true;
            // 
            // FmMouldInv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 514);
            this.Controls.Add(this.Main_pnl);
            this.Controls.Add(this.Head_Bar);
            this.Controls.Add(this.Status_Bar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FmMouldInv";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FmBIU";
            ((System.ComponentModel.ISupportInitialize)(this.Head_Bar)).EndInit();
            this.Main_pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
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
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_OpCode;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_cMCName;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_cMName;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_cMCode;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.DataGridViewX Grid;
        private DevComponents.DotNetBar.ButtonX btn_DelLine;
        private DevComponents.DotNetBar.ButtonX btn_AddLine;
        private DevComponents.DotNetBar.ButtonX btn_down;
        private DevComponents.DotNetBar.ButtonX btn_up;
        private System.Windows.Forms.CheckBox cbk_bGroup;
    }
}