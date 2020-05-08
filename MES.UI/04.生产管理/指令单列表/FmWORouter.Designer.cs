namespace LanyunMES.UI
{
    partial class FmWORouter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmWORouter));
            this.lblModuleTitle = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Head_Bar = new DevComponents.DotNetBar.Bar();
            this.btn_Save = new DevComponents.DotNetBar.ButtonItem();
            this.btn_Up = new DevComponents.DotNetBar.ButtonItem();
            this.btn_Down = new DevComponents.DotNetBar.ButtonItem();
            this.btn_AddLine = new DevComponents.DotNetBar.ButtonItem();
            this.btn_DelLine = new DevComponents.DotNetBar.ButtonItem();
            this.btn_Exit = new DevComponents.DotNetBar.ButtonItem();
            this.Main_pnl = new DevComponents.DotNetBar.PanelEx();
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridRouter = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gx_OpSeq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gx_OpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gx_WOCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gx_cycleTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gx_cEQCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rowButtonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gx_EqName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gx_bQuality = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tab_Main = new DevComponents.DotNetBar.SuperTabItem();
            this.Status_Bar = new DevComponents.DotNetBar.Bar();
            this.lbl_status = new DevComponents.DotNetBar.LabelItem();
            this.gx_cMemo = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Head_Bar)).BeginInit();
            this.Main_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRouter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowButtonEdit)).BeginInit();
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
            this.lblModuleTitle.Size = new System.Drawing.Size(821, 35);
            this.lblModuleTitle.TabIndex = 0;
            this.lblModuleTitle.Text = "工艺路线";
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
            this.Head_Bar.IsMaximized = false;
            this.Head_Bar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_Save,
            this.btn_Up,
            this.btn_Down,
            this.btn_AddLine,
            this.btn_DelLine,
            this.btn_Exit});
            this.Head_Bar.Location = new System.Drawing.Point(0, 0);
            this.Head_Bar.Name = "Head_Bar";
            this.Head_Bar.Size = new System.Drawing.Size(821, 27);
            this.Head_Bar.Stretch = true;
            this.Head_Bar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Head_Bar.TabIndex = 1;
            this.Head_Bar.TabStop = false;
            this.Head_Bar.Text = "bar1";
            // 
            // btn_Save
            // 
            this.btn_Save.ImageIndex = 0;
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Text = "保存";
            // 
            // btn_Up
            // 
            this.btn_Up.BeginGroup = true;
            this.btn_Up.Name = "btn_Up";
            this.btn_Up.Text = "上移";
            // 
            // btn_Down
            // 
            this.btn_Down.Name = "btn_Down";
            this.btn_Down.Text = "下移";
            // 
            // btn_AddLine
            // 
            this.btn_AddLine.BeginGroup = true;
            this.btn_AddLine.Name = "btn_AddLine";
            this.btn_AddLine.Text = "增行";
            // 
            // btn_DelLine
            // 
            this.btn_DelLine.Name = "btn_DelLine";
            this.btn_DelLine.Text = "删行";
            // 
            // btn_Exit
            // 
            this.btn_Exit.BeginGroup = true;
            this.btn_Exit.ImageIndex = 1;
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
            this.Main_pnl.Location = new System.Drawing.Point(0, 27);
            this.Main_pnl.Name = "Main_pnl";
            this.Main_pnl.Size = new System.Drawing.Size(821, 475);
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
            this.superTabControl1.Size = new System.Drawing.Size(821, 440);
            this.superTabControl1.TabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superTabControl1.TabIndex = 1;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tab_Main});
            this.superTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue;
            this.superTabControl1.Text = "superTabControl1";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.panelEx1);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 26);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(821, 414);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.tab_Main;
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.gridControl1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(821, 414);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridControl1.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black;
            this.gridControl1.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridControl1.EmbeddedNavigator.Appearance.Options.UseForeColor = true;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridRouter;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rowButtonEdit});
            this.gridControl1.Size = new System.Drawing.Size(821, 414);
            this.gridControl1.TabIndex = 13;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridRouter});
            // 
            // gridRouter
            // 
            this.gridRouter.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gx_OpSeq,
            this.gx_OpName,
            this.gx_WOCode,
            this.gx_cycleTime,
            this.gx_cEQCode,
            this.gx_EqName,
            this.gx_bQuality,
            this.gx_cMemo});
            this.gridRouter.GridControl = this.gridControl1;
            this.gridRouter.Name = "gridRouter";
            this.gridRouter.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.PlainText;
            this.gridRouter.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.gridRouter.OptionsCustomization.AllowSort = false;
            this.gridRouter.OptionsSelection.CheckBoxSelectorColumnWidth = 50;
            this.gridRouter.OptionsView.ShowGroupPanel = false;
            // 
            // gx_OpSeq
            // 
            this.gx_OpSeq.Caption = "序号";
            this.gx_OpSeq.FieldName = "OpSeq";
            this.gx_OpSeq.Name = "gx_OpSeq";
            this.gx_OpSeq.OptionsColumn.AllowEdit = false;
            this.gx_OpSeq.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gx_OpSeq.OptionsColumn.ReadOnly = true;
            this.gx_OpSeq.Visible = true;
            this.gx_OpSeq.VisibleIndex = 0;
            this.gx_OpSeq.Width = 56;
            // 
            // gx_OpName
            // 
            this.gx_OpName.Caption = "工序名称";
            this.gx_OpName.FieldName = "OpName";
            this.gx_OpName.Name = "gx_OpName";
            this.gx_OpName.OptionsColumn.AllowEdit = false;
            this.gx_OpName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gx_OpName.OptionsColumn.ReadOnly = true;
            this.gx_OpName.Visible = true;
            this.gx_OpName.VisibleIndex = 1;
            this.gx_OpName.Width = 83;
            // 
            // gx_WOCode
            // 
            this.gx_WOCode.Caption = "指令单号";
            this.gx_WOCode.FieldName = "WOCode";
            this.gx_WOCode.Name = "gx_WOCode";
            this.gx_WOCode.OptionsColumn.AllowEdit = false;
            this.gx_WOCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gx_WOCode.OptionsColumn.ReadOnly = true;
            this.gx_WOCode.Visible = true;
            this.gx_WOCode.VisibleIndex = 2;
            this.gx_WOCode.Width = 141;
            // 
            // gx_cycleTime
            // 
            this.gx_cycleTime.Caption = "节拍";
            this.gx_cycleTime.FieldName = "CycleTime";
            this.gx_cycleTime.Name = "gx_cycleTime";
            this.gx_cycleTime.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gx_cycleTime.Visible = true;
            this.gx_cycleTime.VisibleIndex = 5;
            this.gx_cycleTime.Width = 88;
            // 
            // gx_cEQCode
            // 
            this.gx_cEQCode.Caption = "设备编码";
            this.gx_cEQCode.ColumnEdit = this.rowButtonEdit;
            this.gx_cEQCode.FieldName = "cEQCode";
            this.gx_cEQCode.Name = "gx_cEQCode";
            this.gx_cEQCode.Visible = true;
            this.gx_cEQCode.VisibleIndex = 3;
            this.gx_cEQCode.Width = 80;
            // 
            // rowButtonEdit
            // 
            this.rowButtonEdit.AutoHeight = false;
            this.rowButtonEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rowButtonEdit.Name = "rowButtonEdit";
            this.rowButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rowButtonEdit_ButtonClick);
            // 
            // gx_EqName
            // 
            this.gx_EqName.Caption = "设备名称";
            this.gx_EqName.FieldName = "cEQName";
            this.gx_EqName.Name = "gx_EqName";
            this.gx_EqName.OptionsColumn.AllowEdit = false;
            this.gx_EqName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gx_EqName.OptionsColumn.ReadOnly = true;
            this.gx_EqName.Visible = true;
            this.gx_EqName.VisibleIndex = 4;
            this.gx_EqName.Width = 117;
            // 
            // gx_bQuality
            // 
            this.gx_bQuality.Caption = "是否质检";
            this.gx_bQuality.FieldName = "bQuality";
            this.gx_bQuality.Name = "gx_bQuality";
            this.gx_bQuality.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gx_bQuality.Visible = true;
            this.gx_bQuality.VisibleIndex = 6;
            this.gx_bQuality.Width = 74;
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
            this.Status_Bar.Location = new System.Drawing.Point(0, 502);
            this.Status_Bar.Name = "Status_Bar";
            this.Status_Bar.Size = new System.Drawing.Size(821, 22);
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
            // gx_cMemo
            // 
            this.gx_cMemo.Caption = "备注";
            this.gx_cMemo.FieldName = "cMemo";
            this.gx_cMemo.Name = "gx_cMemo";
            this.gx_cMemo.Visible = true;
            this.gx_cMemo.VisibleIndex = 7;
            this.gx_cMemo.Width = 130;
            // 
            // FmWORouter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 524);
            this.Controls.Add(this.Main_pnl);
            this.Controls.Add(this.Head_Bar);
            this.Controls.Add(this.Status_Bar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FmWORouter";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FmBIU";
            ((System.ComponentModel.ISupportInitialize)(this.Head_Bar)).EndInit();
            this.Main_pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRouter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowButtonEdit)).EndInit();
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
        protected DevComponents.DotNetBar.PanelEx panelEx1;
        protected DevComponents.DotNetBar.PanelEx Main_pnl;
        protected DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridRouter;
        private DevExpress.XtraGrid.Columns.GridColumn gx_WOCode;
        private DevExpress.XtraGrid.Columns.GridColumn gx_cycleTime;
        private DevExpress.XtraGrid.Columns.GridColumn gx_EqName;
        private DevExpress.XtraGrid.Columns.GridColumn gx_bQuality;
        private DevExpress.XtraGrid.Columns.GridColumn gx_OpSeq;
        private DevExpress.XtraGrid.Columns.GridColumn gx_OpName;
        private DevComponents.DotNetBar.ButtonItem btn_Up;
        private DevComponents.DotNetBar.ButtonItem btn_Down;
        private DevComponents.DotNetBar.ButtonItem btn_AddLine;
        private DevComponents.DotNetBar.ButtonItem btn_DelLine;
        private DevExpress.XtraGrid.Columns.GridColumn gx_cEQCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rowButtonEdit;
        private DevExpress.XtraGrid.Columns.GridColumn gx_cMemo;
    }
}