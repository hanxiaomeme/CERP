namespace LanyunMES.UI
{
    partial class FmMouldEqInvAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmMouldEqInvAdd));
            this.lblModuleTitle = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Head_Bar = new DevComponents.DotNetBar.Bar();
            this.btn_OK = new DevComponents.DotNetBar.ButtonItem();
            this.btn_Exit = new DevComponents.DotNetBar.ButtonItem();
            this.Main_pnl = new DevComponents.DotNetBar.PanelEx();
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.txtr_cInvCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label8 = new System.Windows.Forms.Label();
            this.txtr_cInvName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtr_cInvStd = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tab_Main = new DevComponents.DotNetBar.SuperTabItem();
            this.Status_Bar = new DevComponents.DotNetBar.Bar();
            this.lbl_status = new DevComponents.DotNetBar.LabelItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.Grid = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.Head_Bar)).BeginInit();
            this.Main_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Status_Bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
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
            this.lblModuleTitle.Size = new System.Drawing.Size(541, 35);
            this.lblModuleTitle.TabIndex = 0;
            this.lblModuleTitle.Text = "模具-产品组合";
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
            this.imageList1.Images.SetKeyName(5, "check.png");
            // 
            // Head_Bar
            // 
            this.Head_Bar.AntiAlias = true;
            this.Head_Bar.Dock = System.Windows.Forms.DockStyle.Top;
            this.Head_Bar.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Head_Bar.Images = this.imageList1;
            this.Head_Bar.IsMaximized = false;
            this.Head_Bar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_OK,
            this.btn_Exit});
            this.Head_Bar.Location = new System.Drawing.Point(0, 0);
            this.Head_Bar.Name = "Head_Bar";
            this.Head_Bar.Size = new System.Drawing.Size(541, 45);
            this.Head_Bar.Stretch = true;
            this.Head_Bar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Head_Bar.TabIndex = 1;
            this.Head_Bar.TabStop = false;
            this.Head_Bar.Text = "bar1";
            // 
            // btn_OK
            // 
            this.btn_OK.ImageIndex = 5;
            this.btn_OK.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Text = "确定";
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
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
            this.Main_pnl.Location = new System.Drawing.Point(0, 45);
            this.Main_pnl.Name = "Main_pnl";
            this.Main_pnl.Size = new System.Drawing.Size(541, 395);
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
            this.superTabControl1.Size = new System.Drawing.Size(541, 360);
            this.superTabControl1.TabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superTabControl1.TabIndex = 1;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tab_Main});
            this.superTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue;
            this.superTabControl1.Text = "superTabControl1";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.gridControl1);
            this.superTabControlPanel1.Controls.Add(this.txtr_cInvCode);
            this.superTabControlPanel1.Controls.Add(this.label8);
            this.superTabControlPanel1.Controls.Add(this.txtr_cInvName);
            this.superTabControlPanel1.Controls.Add(this.label5);
            this.superTabControlPanel1.Controls.Add(this.label1);
            this.superTabControlPanel1.Controls.Add(this.txtr_cInvStd);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 26);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(541, 334);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.tab_Main;
            // 
            // txtr_cInvCode
            // 
            this.txtr_cInvCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtr_cInvCode.Border.Class = "TextBoxBorder";
            this.txtr_cInvCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_cInvCode.ButtonCustom.Tooltip = "存货档案";
            this.txtr_cInvCode.ButtonCustom.Visible = true;
            this.txtr_cInvCode.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_cInvCode.ForeColor = System.Drawing.Color.Black;
            this.txtr_cInvCode.Location = new System.Drawing.Point(90, 19);
            this.txtr_cInvCode.Name = "txtr_cInvCode";
            this.txtr_cInvCode.PreventEnterBeep = true;
            this.txtr_cInvCode.Size = new System.Drawing.Size(161, 21);
            this.txtr_cInvCode.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(16, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "规格型号：";
            // 
            // txtr_cInvName
            // 
            this.txtr_cInvName.BackColor = System.Drawing.Color.OldLace;
            // 
            // 
            // 
            this.txtr_cInvName.Border.Class = "TextBoxBorder";
            this.txtr_cInvName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_cInvName.ButtonCustom.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtr_cInvName.ButtonCustom.SymbolColor = System.Drawing.Color.RoyalBlue;
            this.txtr_cInvName.ButtonCustom.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.txtr_cInvName.ButtonCustom2.Enabled = false;
            this.txtr_cInvName.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_cInvName.ForeColor = System.Drawing.Color.Black;
            this.txtr_cInvName.Location = new System.Drawing.Point(353, 19);
            this.txtr_cInvName.Name = "txtr_cInvName";
            this.txtr_cInvName.PreventEnterBeep = true;
            this.txtr_cInvName.Size = new System.Drawing.Size(165, 21);
            this.txtr_cInvName.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(282, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "产品名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "产品编码：";
            // 
            // txtr_cInvStd
            // 
            this.txtr_cInvStd.BackColor = System.Drawing.Color.OldLace;
            // 
            // 
            // 
            this.txtr_cInvStd.Border.Class = "TextBoxBorder";
            this.txtr_cInvStd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_cInvStd.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_cInvStd.ForeColor = System.Drawing.Color.Black;
            this.txtr_cInvStd.Location = new System.Drawing.Point(90, 55);
            this.txtr_cInvStd.Name = "txtr_cInvStd";
            this.txtr_cInvStd.PreventEnterBeep = true;
            this.txtr_cInvStd.ReadOnly = true;
            this.txtr_cInvStd.Size = new System.Drawing.Size(161, 21);
            this.txtr_cInvStd.TabIndex = 16;
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
            this.Status_Bar.Location = new System.Drawing.Point(0, 440);
            this.Status_Bar.Name = "Status_Bar";
            this.Status_Bar.Size = new System.Drawing.Size(541, 22);
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
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControl1.Location = new System.Drawing.Point(0, 110);
            this.gridControl1.MainView = this.Grid;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(541, 224);
            this.gridControl1.TabIndex = 22;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.Grid});
            // 
            // Grid
            // 
            this.Grid.GridControl = this.gridControl1;
            this.Grid.Name = "Grid";
            this.Grid.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.Grid.OptionsSelection.CheckBoxSelectorColumnWidth = 50;
            this.Grid.OptionsSelection.MultiSelect = true;
            this.Grid.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.Grid.OptionsView.ColumnAutoWidth = false;
            this.Grid.OptionsView.ShowGroupPanel = false;
            // 
            // FmMouldEqInvAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 462);
            this.Controls.Add(this.Main_pnl);
            this.Controls.Add(this.Head_Bar);
            this.Controls.Add(this.Status_Bar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FmMouldEqInvAdd";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FmBIU";
            ((System.ComponentModel.ISupportInitialize)(this.Head_Bar)).EndInit();
            this.Main_pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.superTabControlPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Status_Bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label lblModuleTitle;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.ButtonItem btn_OK;
        private DevComponents.DotNetBar.ButtonItem btn_Exit;
        private DevComponents.DotNetBar.LabelItem lbl_status;
        protected DevComponents.DotNetBar.Bar Head_Bar;
        protected DevComponents.DotNetBar.Bar Status_Bar;
        protected DevComponents.DotNetBar.SuperTabControl superTabControl1;
        protected DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        protected DevComponents.DotNetBar.SuperTabItem tab_Main;
        protected DevComponents.DotNetBar.PanelEx Main_pnl;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_cInvCode;
        private System.Windows.Forms.Label label8;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_cInvName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_cInvStd;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView Grid;
    }
}