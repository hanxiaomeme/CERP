namespace LanyunMES.UI
{
    partial class FmWOList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmWOList));
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.BtnExport = new DevComponents.DotNetBar.ButtonItem();
            this.Btn_Print = new DevComponents.DotNetBar.ButtonItem();
            this.Btn_PrintDesgin = new DevComponents.DotNetBar.ButtonItem();
            this.Btn_Query = new DevComponents.DotNetBar.ButtonItem();
            this.BtnReflash = new DevComponents.DotNetBar.ButtonItem();
            this.BtnEdit = new DevComponents.DotNetBar.ButtonItem();
            this.btnEditDetail = new DevComponents.DotNetBar.ButtonItem();
            this.Btn_MoCard = new DevComponents.DotNetBar.ButtonItem();
            this.Btn_MoCards = new DevComponents.DotNetBar.ButtonItem();
            this.BtnClose = new DevComponents.DotNetBar.ButtonItem();
            this.BtnOpen = new DevComponents.DotNetBar.ButtonItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cInvCodeBtnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.checkEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.report1 = new FastReport.Report();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridControl3 = new DevExpress.XtraGrid.GridControl();
            this.gridRouter = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dOpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DInvCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DInvName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DInvStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.iQty = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cInvCodeBtnEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRouter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.BtnExport,
            this.Btn_Print,
            this.Btn_Query,
            this.BtnReflash,
            this.BtnEdit,
            this.btnEditDetail,
            this.Btn_MoCard,
            this.BtnClose});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.PaddingRight = 50;
            this.bar1.Size = new System.Drawing.Size(1088, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 7;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // BtnExport
            // 
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Text = "导出(&E)";
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // Btn_Print
            // 
            this.Btn_Print.BeginGroup = true;
            this.Btn_Print.Name = "Btn_Print";
            this.Btn_Print.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Btn_PrintDesgin});
            this.Btn_Print.Text = "打印";
            this.Btn_Print.Click += new System.EventHandler(this.Btn_Print_Click);
            // 
            // Btn_PrintDesgin
            // 
            this.Btn_PrintDesgin.Name = "Btn_PrintDesgin";
            this.Btn_PrintDesgin.Text = "设计";
            this.Btn_PrintDesgin.Click += new System.EventHandler(this.Btn_PrintDesgin_Click);
            // 
            // Btn_Query
            // 
            this.Btn_Query.BeginGroup = true;
            this.Btn_Query.Name = "Btn_Query";
            this.Btn_Query.Text = "查询";
            this.Btn_Query.Click += new System.EventHandler(this.Btn_Query_Click);
            // 
            // BtnReflash
            // 
            this.BtnReflash.Name = "BtnReflash";
            this.BtnReflash.Text = "刷新";
            this.BtnReflash.Click += new System.EventHandler(this.BtnReflash_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.BeginGroup = true;
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Text = "修改工序";
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // btnEditDetail
            // 
            this.btnEditDetail.Name = "btnEditDetail";
            this.btnEditDetail.Text = "修改子件";
            this.btnEditDetail.Click += new System.EventHandler(this.btnEditDetail_Click);
            // 
            // Btn_MoCard
            // 
            this.Btn_MoCard.BeginGroup = true;
            this.Btn_MoCard.Name = "Btn_MoCard";
            this.Btn_MoCard.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Btn_MoCards});
            this.Btn_MoCard.Text = "生成流转卡";
            this.Btn_MoCard.Click += new System.EventHandler(this.Btn_MoCard_Click);
            // 
            // Btn_MoCards
            // 
            this.Btn_MoCards.Name = "Btn_MoCards";
            this.Btn_MoCards.Text = "批量生成";
            this.Btn_MoCards.Click += new System.EventHandler(this.Btn_MoCards_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.BeginGroup = true;
            this.BtnClose.ForeColor = System.Drawing.Color.Red;
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.BtnOpen});
            this.BtnClose.Text = "关闭";
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnOpen
            // 
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Text = "打开";
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cInvCodeBtnEdit,
            this.repositoryItemTextEdit1,
            this.checkEdit});
            this.gridControl1.Size = new System.Drawing.Size(880, 335);
            this.gridControl1.TabIndex = 8;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 40;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // cInvCodeBtnEdit
            // 
            this.cInvCodeBtnEdit.AutoHeight = false;
            this.cInvCodeBtnEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.cInvCodeBtnEdit.Name = "cInvCodeBtnEdit";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.DisplayFormat.FormatString = "#,###.000";
            this.repositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.EditFormat.FormatString = "#,###.000";
            this.repositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // checkEdit
            // 
            this.checkEdit.AutoHeight = false;
            this.checkEdit.Name = "checkEdit";
            this.checkEdit.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // report1
            // 
            this.report1.NeedRefresh = false;
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridControl1);
            this.splitContainer1.Panel1.Controls.Add(this.listBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1088, 546);
            this.splitContainer1.SplitterDistance = 335;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 9;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(880, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(208, 335);
            this.listBox1.TabIndex = 5;
            this.listBox1.Visible = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Size = new System.Drawing.Size(1088, 206);
            this.splitContainer2.SplitterDistance = 565;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 11;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox3.Controls.Add(this.gridControl3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(565, 206);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "工序";
            // 
            // gridControl3
            // 
            this.gridControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl3.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridControl3.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black;
            this.gridControl3.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridControl3.EmbeddedNavigator.Appearance.Options.UseForeColor = true;
            this.gridControl3.Location = new System.Drawing.Point(3, 17);
            this.gridControl3.MainView = this.gridRouter;
            this.gridControl3.Name = "gridControl3";
            this.gridControl3.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit2,
            this.repositoryItemTextEdit3,
            this.repositoryItemCheckEdit2});
            this.gridControl3.Size = new System.Drawing.Size(559, 186);
            this.gridControl3.TabIndex = 10;
            this.gridControl3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridRouter});
            // 
            // gridRouter
            // 
            this.gridRouter.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridRouter.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridRouter.GridControl = this.gridControl3;
            this.gridRouter.Name = "gridRouter";
            this.gridRouter.OptionsBehavior.Editable = false;
            this.gridRouter.OptionsBehavior.ReadOnly = true;
            this.gridRouter.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.PlainText;
            this.gridRouter.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.gridRouter.OptionsCustomization.AllowFilter = false;
            this.gridRouter.OptionsCustomization.AllowSort = false;
            this.gridRouter.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridRouter.OptionsView.ColumnAutoWidth = false;
            this.gridRouter.OptionsView.ShowGroupPanel = false;
            // 
            // repositoryItemButtonEdit2
            // 
            this.repositoryItemButtonEdit2.AutoHeight = false;
            this.repositoryItemButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.DisplayFormat.FormatString = "#,###.000";
            this.repositoryItemTextEdit3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit3.EditFormat.FormatString = "#,###.000";
            this.repositoryItemTextEdit3.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            this.repositoryItemCheckEdit2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox2.Controls.Add(this.gridControl2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(517, 206);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "子件原料";
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridControl2.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black;
            this.gridControl2.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridControl2.EmbeddedNavigator.Appearance.Options.UseForeColor = true;
            this.gridControl2.Location = new System.Drawing.Point(3, 17);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(511, 186);
            this.gridControl2.TabIndex = 10;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView2.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.dOpName,
            this.DInvCode,
            this.DInvName,
            this.DInvStd,
            this.iQty});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.PlainText;
            this.gridView2.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsCustomization.AllowSort = false;
            this.gridView2.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // dOpName
            // 
            this.dOpName.Caption = "工序";
            this.dOpName.FieldName = "OpName";
            this.dOpName.Name = "dOpName";
            this.dOpName.Visible = true;
            this.dOpName.VisibleIndex = 0;
            this.dOpName.Width = 78;
            // 
            // DInvCode
            // 
            this.DInvCode.Caption = "子件编码";
            this.DInvCode.FieldName = "DInvCode";
            this.DInvCode.Name = "DInvCode";
            this.DInvCode.Visible = true;
            this.DInvCode.VisibleIndex = 1;
            this.DInvCode.Width = 120;
            // 
            // DInvName
            // 
            this.DInvName.Caption = "子件名称";
            this.DInvName.FieldName = "DInvName";
            this.DInvName.Name = "DInvName";
            this.DInvName.Visible = true;
            this.DInvName.VisibleIndex = 2;
            this.DInvName.Width = 96;
            // 
            // DInvStd
            // 
            this.DInvStd.Caption = "子件规格";
            this.DInvStd.FieldName = "DInvStd";
            this.DInvStd.Name = "DInvStd";
            this.DInvStd.Visible = true;
            this.DInvStd.VisibleIndex = 3;
            this.DInvStd.Width = 96;
            // 
            // iQty
            // 
            this.iQty.Caption = "子件数量";
            this.iQty.FieldName = "iQty";
            this.iQty.Name = "iQty";
            this.iQty.Visible = true;
            this.iQty.VisibleIndex = 4;
            this.iQty.Width = 60;
            // 
            // FmWOList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 573);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Name = "FmWOList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "指令单列表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FmProductOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cInvCodeBtnEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRouter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem Btn_Print;
        protected DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit cInvCodeBtnEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit checkEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private FastReport.Report report1;
        private DevComponents.DotNetBar.ButtonItem Btn_PrintDesgin;
        private DevComponents.DotNetBar.ButtonItem Btn_Query;
        private DevComponents.DotNetBar.ButtonItem BtnReflash;
        private DevComponents.DotNetBar.ButtonItem BtnEdit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox3;
        protected DevExpress.XtraGrid.GridControl gridControl3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridRouter;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private System.Windows.Forms.GroupBox groupBox2;
        protected DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn dOpName;
        private DevExpress.XtraGrid.Columns.GridColumn DInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn DInvName;
        private DevExpress.XtraGrid.Columns.GridColumn DInvStd;
        private DevExpress.XtraGrid.Columns.GridColumn iQty;
        private DevComponents.DotNetBar.ButtonItem Btn_MoCard;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox listBox1;
        private DevComponents.DotNetBar.ButtonItem btnEditDetail;
        private DevComponents.DotNetBar.ButtonItem BtnClose;
        private DevComponents.DotNetBar.ButtonItem BtnOpen;
        private DevComponents.DotNetBar.ButtonItem Btn_MoCards;
        private DevComponents.DotNetBar.ButtonItem BtnExport;
    }
}