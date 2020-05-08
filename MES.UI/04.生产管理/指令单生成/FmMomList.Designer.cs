namespace LanyunMES.UI
{
    partial class FmMomList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmMomList));
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.Btn_Print = new DevComponents.DotNetBar.ButtonItem();
            this.Btn_Desgin = new DevComponents.DotNetBar.ButtonItem();
            this.Btn_Query = new DevComponents.DotNetBar.ButtonItem();
            this.Btn_Refresh = new DevComponents.DotNetBar.ButtonItem();
            this.BtnExpDetail = new DevComponents.DotNetBar.ButtonItem();
            this.Btn_Delete = new DevComponents.DotNetBar.ButtonItem();
            this.report1 = new FastReport.Report();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cInvCodeBtnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.checkEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MoCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WOCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cInvCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cInvName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cInvStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.iQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Grade = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridControl3 = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gx_WOCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gx_cInvCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gx_cInvName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gx_cInvStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gx_OpSeq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gx_OpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.btn_EditRouter = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cInvCodeBtnEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Btn_Print,
            this.Btn_Query,
            this.Btn_Refresh,
            this.BtnExpDetail,
            this.Btn_Delete});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.PaddingRight = 50;
            this.bar1.Size = new System.Drawing.Size(1033, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 7;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // Btn_Print
            // 
            this.Btn_Print.Name = "Btn_Print";
            this.Btn_Print.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Btn_Desgin});
            this.Btn_Print.Text = "打印(&P)";
            this.Btn_Print.Visible = false;
            this.Btn_Print.Click += new System.EventHandler(this.Btn_Print_Click);
            // 
            // Btn_Desgin
            // 
            this.Btn_Desgin.Name = "Btn_Desgin";
            this.Btn_Desgin.Text = "打印设计";
            this.Btn_Desgin.Click += new System.EventHandler(this.Btn_Desgin_Click);
            // 
            // Btn_Query
            // 
            this.Btn_Query.Name = "Btn_Query";
            this.Btn_Query.Text = "查询(&Q)";
            // 
            // Btn_Refresh
            // 
            this.Btn_Refresh.Name = "Btn_Refresh";
            this.Btn_Refresh.Text = "刷新(&R)";
            // 
            // BtnExpDetail
            // 
            this.BtnExpDetail.BeginGroup = true;
            this.BtnExpDetail.Name = "BtnExpDetail";
            this.BtnExpDetail.Text = "生成指令单(&E)";
            // 
            // Btn_Delete
            // 
            this.Btn_Delete.Name = "Btn_Delete";
            this.Btn_Delete.Text = "删除指令单(&D)";
            this.Btn_Delete.Click += new System.EventHandler(this.Btn_Delete_Click);
            // 
            // report1
            // 
            this.report1.NeedRefresh = false;
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridControl1.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black;
            this.gridControl1.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridControl1.EmbeddedNavigator.Appearance.Options.UseForeColor = true;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cInvCodeBtnEdit,
            this.repositoryItemTextEdit1,
            this.checkEdit});
            this.gridControl1.Size = new System.Drawing.Size(1033, 311);
            this.gridControl1.TabIndex = 9;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.PlainText;
            this.gridView1.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 50;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
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
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.ForeColor = System.Drawing.Color.Black;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.splitContainer1.Panel1.Controls.Add(this.gridControl1);
            this.splitContainer1.Panel1.ForeColor = System.Drawing.Color.Black;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Controls.Add(this.bar2);
            this.splitContainer1.Panel2.ForeColor = System.Drawing.Color.Black;
            this.splitContainer1.Size = new System.Drawing.Size(1033, 550);
            this.splitContainer1.SplitterDistance = 311;
            this.splitContainer1.TabIndex = 10;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 27);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gridControl2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gridControl3);
            this.splitContainer2.Size = new System.Drawing.Size(1033, 208);
            this.splitContainer2.SplitterDistance = 540;
            this.splitContainer2.TabIndex = 12;
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridControl2.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black;
            this.gridControl2.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridControl2.EmbeddedNavigator.Appearance.Options.UseForeColor = true;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemCheckEdit1});
            this.gridControl2.Size = new System.Drawing.Size(540, 208);
            this.gridControl2.TabIndex = 10;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MoCode,
            this.WOCode,
            this.cInvCode,
            this.cInvName,
            this.cInvStd,
            this.iQuantity,
            this.Grade});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.PlainText;
            this.gridView2.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsCustomization.AllowSort = false;
            this.gridView2.OptionsSelection.CheckBoxSelectorColumnWidth = 50;
            this.gridView2.OptionsView.ShowFooter = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // MoCode
            // 
            this.MoCode.Caption = "生产订单号";
            this.MoCode.FieldName = "MoCode";
            this.MoCode.Name = "MoCode";
            this.MoCode.Width = 100;
            // 
            // WOCode
            // 
            this.WOCode.Caption = "指令单号";
            this.WOCode.FieldName = "WOCode";
            this.WOCode.Name = "WOCode";
            this.WOCode.Visible = true;
            this.WOCode.VisibleIndex = 0;
            this.WOCode.Width = 102;
            // 
            // cInvCode
            // 
            this.cInvCode.Caption = "产品编码";
            this.cInvCode.FieldName = "cInvCode";
            this.cInvCode.Name = "cInvCode";
            this.cInvCode.Visible = true;
            this.cInvCode.VisibleIndex = 2;
            this.cInvCode.Width = 102;
            // 
            // cInvName
            // 
            this.cInvName.Caption = "产品名称";
            this.cInvName.FieldName = "cInvName";
            this.cInvName.Name = "cInvName";
            this.cInvName.Visible = true;
            this.cInvName.VisibleIndex = 3;
            this.cInvName.Width = 102;
            // 
            // cInvStd
            // 
            this.cInvStd.Caption = "规格型号";
            this.cInvStd.FieldName = "cInvStd";
            this.cInvStd.Name = "cInvStd";
            this.cInvStd.Visible = true;
            this.cInvStd.VisibleIndex = 4;
            this.cInvStd.Width = 102;
            // 
            // iQuantity
            // 
            this.iQuantity.Caption = "数量";
            this.iQuantity.FieldName = "iQuantity";
            this.iQuantity.Name = "iQuantity";
            this.iQuantity.Visible = true;
            this.iQuantity.VisibleIndex = 5;
            this.iQuantity.Width = 89;
            // 
            // Grade
            // 
            this.Grade.Caption = "BOM层级";
            this.Grade.FieldName = "grade";
            this.Grade.Name = "Grade";
            this.Grade.Visible = true;
            this.Grade.VisibleIndex = 1;
            this.Grade.Width = 60;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.DisplayFormat.FormatString = "#,###.000";
            this.repositoryItemTextEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit2.EditFormat.FormatString = "#,###.000";
            this.repositoryItemTextEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // gridControl3
            // 
            this.gridControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl3.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridControl3.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black;
            this.gridControl3.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridControl3.EmbeddedNavigator.Appearance.Options.UseForeColor = true;
            this.gridControl3.Location = new System.Drawing.Point(0, 0);
            this.gridControl3.MainView = this.gridView3;
            this.gridControl3.Name = "gridControl3";
            this.gridControl3.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit2,
            this.repositoryItemTextEdit3,
            this.repositoryItemCheckEdit2});
            this.gridControl3.Size = new System.Drawing.Size(489, 208);
            this.gridControl3.TabIndex = 12;
            this.gridControl3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gx_WOCode,
            this.gx_cInvCode,
            this.gx_cInvName,
            this.gx_cInvStd,
            this.gx_OpSeq,
            this.gx_OpName});
            this.gridView3.GridControl = this.gridControl3;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.Editable = false;
            this.gridView3.OptionsBehavior.ReadOnly = true;
            this.gridView3.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.PlainText;
            this.gridView3.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.gridView3.OptionsCustomization.AllowFilter = false;
            this.gridView3.OptionsCustomization.AllowSort = false;
            this.gridView3.OptionsSelection.CheckBoxSelectorColumnWidth = 50;
            this.gridView3.OptionsView.AllowCellMerge = true;
            this.gridView3.OptionsView.ShowFooter = true;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // gx_WOCode
            // 
            this.gx_WOCode.Caption = "指令单号";
            this.gx_WOCode.FieldName = "WOCode";
            this.gx_WOCode.Name = "gx_WOCode";
            this.gx_WOCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gx_WOCode.Visible = true;
            this.gx_WOCode.VisibleIndex = 0;
            this.gx_WOCode.Width = 100;
            // 
            // gx_cInvCode
            // 
            this.gx_cInvCode.Caption = "产品编码";
            this.gx_cInvCode.FieldName = "cInvCode";
            this.gx_cInvCode.Name = "gx_cInvCode";
            this.gx_cInvCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gx_cInvCode.Visible = true;
            this.gx_cInvCode.VisibleIndex = 3;
            this.gx_cInvCode.Width = 100;
            // 
            // gx_cInvName
            // 
            this.gx_cInvName.Caption = "产品名称";
            this.gx_cInvName.FieldName = "cInvName";
            this.gx_cInvName.Name = "gx_cInvName";
            this.gx_cInvName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gx_cInvName.Visible = true;
            this.gx_cInvName.VisibleIndex = 4;
            this.gx_cInvName.Width = 90;
            // 
            // gx_cInvStd
            // 
            this.gx_cInvStd.Caption = "规格型号";
            this.gx_cInvStd.FieldName = "cInvStd";
            this.gx_cInvStd.Name = "gx_cInvStd";
            this.gx_cInvStd.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gx_cInvStd.Visible = true;
            this.gx_cInvStd.VisibleIndex = 5;
            this.gx_cInvStd.Width = 94;
            // 
            // gx_OpSeq
            // 
            this.gx_OpSeq.Caption = "序号";
            this.gx_OpSeq.FieldName = "OpSeq";
            this.gx_OpSeq.Name = "gx_OpSeq";
            this.gx_OpSeq.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gx_OpSeq.Visible = true;
            this.gx_OpSeq.VisibleIndex = 1;
            this.gx_OpSeq.Width = 35;
            // 
            // gx_OpName
            // 
            this.gx_OpName.Caption = "工序名称";
            this.gx_OpName.FieldName = "OpName";
            this.gx_OpName.Name = "gx_OpName";
            this.gx_OpName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gx_OpName.Visible = true;
            this.gx_OpName.VisibleIndex = 2;
            this.gx_OpName.Width = 70;
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
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar2.IsMaximized = false;
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_EditRouter});
            this.bar2.Location = new System.Drawing.Point(0, 0);
            this.bar2.Name = "bar2";
            this.bar2.PaddingRight = 50;
            this.bar2.Size = new System.Drawing.Size(1033, 27);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 13;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
            // 
            // btn_EditRouter
            // 
            this.btn_EditRouter.Name = "btn_EditRouter";
            this.btn_EditRouter.Text = "修改工艺";
            // 
            // FmMomList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 577);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Name = "FmMomList";
            this.ShowIcon = false;
            this.Text = "指令单生成";
            this.Load += new System.EventHandler(this.FmProductOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cInvCodeBtnEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem Btn_Query;
        private DevComponents.DotNetBar.ButtonItem BtnExpDetail;
        private FastReport.Report report1;
        private DevComponents.DotNetBar.ButtonItem Btn_Print;
        private DevComponents.DotNetBar.ButtonItem Btn_Desgin;
        private DevComponents.DotNetBar.ButtonItem Btn_Refresh;
        protected DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit cInvCodeBtnEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit checkEdit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        protected DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn cInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn cInvName;
        private DevExpress.XtraGrid.Columns.GridColumn cInvStd;
        private DevExpress.XtraGrid.Columns.GridColumn iQuantity;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn MoCode;
        private DevExpress.XtraGrid.Columns.GridColumn WOCode;
        private DevExpress.XtraGrid.Columns.GridColumn Grade;
        private System.Windows.Forms.SplitContainer splitContainer2;
        protected DevExpress.XtraGrid.GridControl gridControl3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gx_WOCode;
        private DevExpress.XtraGrid.Columns.GridColumn gx_cInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn gx_cInvName;
        private DevExpress.XtraGrid.Columns.GridColumn gx_cInvStd;
        private DevExpress.XtraGrid.Columns.GridColumn gx_OpSeq;
        private DevExpress.XtraGrid.Columns.GridColumn gx_OpName;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.ButtonItem btn_EditRouter;
        private DevComponents.DotNetBar.ButtonItem Btn_Delete;
    }
}