namespace LanyunMES.UI
{
    partial class FmMaintenancePlan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmMaintenancePlan));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGuid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cMCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.stopHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.workHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCalcEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.BtnQuery = new DevComponents.DotNetBar.ButtonItem();
            this.BtnAdd = new DevComponents.DotNetBar.ButtonItem();
            this.BtnEdit = new DevComponents.DotNetBar.ButtonItem();
            this.BtnDel = new DevComponents.DotNetBar.ButtonItem();
            this.BtnSave = new DevComponents.DotNetBar.ButtonItem();
            this.BtnCancel = new DevComponents.DotNetBar.ButtonItem();
            this.BtnAudit = new DevComponents.DotNetBar.ButtonItem();
            this.BtnUnAudit = new DevComponents.DotNetBar.ButtonItem();
            this.Btn_first = new DevComponents.DotNetBar.ButtonItem();
            this.Btn_previous = new DevComponents.DotNetBar.ButtonItem();
            this.Btn_next = new DevComponents.DotNetBar.ButtonItem();
            this.Btn_last = new DevComponents.DotNetBar.ButtonItem();
            this.pnlMain = new DevComponents.DotNetBar.PanelEx();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.txtr_cEQCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtr_cEQName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.BtnAddLine = new DevComponents.DotNetBar.ButtonItem();
            this.BtnDelLine = new DevComponents.DotNetBar.ButtonItem();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bClassDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cEQCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cInvName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCalcEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.collapsibleSplitContainer1 = new DevComponents.DotNetBar.Controls.CollapsibleSplitContainer();
            this.dMakeDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cMaker = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cModifier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dModifyDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.txtr_cMaker = new DevComponents.DotNetBar.Controls.TextBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.collapsibleSplitContainer1)).BeginInit();
            this.collapsibleSplitContainer1.Panel1.SuspendLayout();
            this.collapsibleSplitContainer1.Panel2.SuspendLayout();
            this.collapsibleSplitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridControl1.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black;
            this.gridControl1.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridControl1.EmbeddedNavigator.Appearance.Options.UseForeColor = true;
            this.gridControl1.Location = new System.Drawing.Point(0, 169);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCalcEdit1});
            this.gridControl1.Size = new System.Drawing.Size(514, 389);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGuid,
            this.AutoId,
            this.cMCode,
            this.stopHours,
            this.workHours,
            this.reason});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // colGuid
            // 
            this.colGuid.Caption = "主表主键";
            this.colGuid.FieldName = "Guid";
            this.colGuid.Name = "colGuid";
            this.colGuid.Width = 79;
            // 
            // AutoId
            // 
            this.AutoId.Caption = "AutoID";
            this.AutoId.FieldName = "AutoId";
            this.AutoId.Name = "AutoId";
            this.AutoId.Width = 49;
            // 
            // cMCode
            // 
            this.cMCode.Caption = "日期";
            this.cMCode.FieldName = "dDate";
            this.cMCode.Name = "cMCode";
            this.cMCode.OptionsColumn.AllowEdit = false;
            this.cMCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "cMCode", "记录数: {0}")});
            this.cMCode.Visible = true;
            this.cMCode.VisibleIndex = 0;
            this.cMCode.Width = 145;
            // 
            // stopHours
            // 
            this.stopHours.Caption = "停机时间/H";
            this.stopHours.FieldName = "iStep";
            this.stopHours.Name = "stopHours";
            this.stopHours.Visible = true;
            this.stopHours.VisibleIndex = 1;
            this.stopHours.Width = 135;
            // 
            // workHours
            // 
            this.workHours.Caption = "开机时间/H";
            this.workHours.DisplayFormat.FormatString = "{0:n2}";
            this.workHours.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.workHours.FieldName = "timeQty";
            this.workHours.Name = "workHours";
            this.workHours.OptionsColumn.AllowEdit = false;
            this.workHours.Visible = true;
            this.workHours.VisibleIndex = 2;
            this.workHours.Width = 126;
            // 
            // reason
            // 
            this.reason.Caption = "原因";
            this.reason.FieldName = "remark";
            this.reason.Name = "reason";
            this.reason.Visible = true;
            this.reason.VisibleIndex = 3;
            this.reason.Width = 197;
            // 
            // repositoryItemCalcEdit1
            // 
            this.repositoryItemCalcEdit1.AutoHeight = false;
            this.repositoryItemCalcEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCalcEdit1.Name = "repositoryItemCalcEdit1";
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.BtnQuery,
            this.BtnAdd,
            this.BtnEdit,
            this.BtnDel,
            this.BtnSave,
            this.BtnCancel,
            this.BtnAudit,
            this.BtnUnAudit,
            this.Btn_first,
            this.Btn_previous,
            this.Btn_next,
            this.Btn_last});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.PaddingRight = 50;
            this.bar1.Size = new System.Drawing.Size(1076, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 6;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // BtnQuery
            // 
            this.BtnQuery.Name = "BtnQuery";
            this.BtnQuery.Text = "查询(&Q)";
            this.BtnQuery.Click += new System.EventHandler(this.BtnQuery_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.BeginGroup = true;
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Text = "新增";
            // 
            // BtnEdit
            // 
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Text = "修改";
            // 
            // BtnDel
            // 
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Text = "删除";
            // 
            // BtnSave
            // 
            this.BtnSave.BeginGroup = true;
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Text = "保存";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Text = "取消";
            // 
            // BtnAudit
            // 
            this.BtnAudit.BeginGroup = true;
            this.BtnAudit.Name = "BtnAudit";
            this.BtnAudit.Text = "审核";
            // 
            // BtnUnAudit
            // 
            this.BtnUnAudit.Name = "BtnUnAudit";
            this.BtnUnAudit.Text = "弃审";
            // 
            // Btn_first
            // 
            this.Btn_first.BeginGroup = true;
            this.Btn_first.Image = ((System.Drawing.Image)(resources.GetObject("Btn_first.Image")));
            this.Btn_first.Name = "Btn_first";
            this.Btn_first.Text = "f";
            this.Btn_first.Visible = false;
            this.Btn_first.Click += new System.EventHandler(this.Btn_first_Click);
            // 
            // Btn_previous
            // 
            this.Btn_previous.Image = ((System.Drawing.Image)(resources.GetObject("Btn_previous.Image")));
            this.Btn_previous.Name = "Btn_previous";
            this.Btn_previous.Text = "p";
            this.Btn_previous.Visible = false;
            this.Btn_previous.Click += new System.EventHandler(this.Btn_previous_Click);
            // 
            // Btn_next
            // 
            this.Btn_next.Image = ((System.Drawing.Image)(resources.GetObject("Btn_next.Image")));
            this.Btn_next.Name = "Btn_next";
            this.Btn_next.Text = "n";
            this.Btn_next.Visible = false;
            this.Btn_next.Click += new System.EventHandler(this.Btn_next_Click);
            // 
            // Btn_last
            // 
            this.Btn_last.Image = ((System.Drawing.Image)(resources.GetObject("Btn_last.Image")));
            this.Btn_last.Name = "Btn_last";
            this.Btn_last.Text = "l";
            this.Btn_last.Visible = false;
            this.Btn_last.Click += new System.EventHandler(this.Btn_last_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlMain.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlMain.Controls.Add(this.txtr_cMaker);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.rb2);
            this.pnlMain.Controls.Add(this.rb1);
            this.pnlMain.Controls.Add(this.txtr_cEQCode);
            this.pnlMain.Controls.Add(this.txtr_cEQName);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(514, 142);
            this.pnlMain.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlMain.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlMain.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlMain.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlMain.Style.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlMain.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlMain.Style.GradientAngle = 90;
            this.pnlMain.Style.LineAlignment = System.Drawing.StringAlignment.Near;
            this.pnlMain.Style.MarginTop = 10;
            this.pnlMain.TabIndex = 1;
            this.pnlMain.Text = "设备维护计划";
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.ForeColor = System.Drawing.Color.Black;
            this.rb2.Location = new System.Drawing.Point(418, 57);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(71, 16);
            this.rb2.TabIndex = 19;
            this.rb2.Text = "设备分类";
            this.rb2.UseVisualStyleBackColor = true;
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Checked = true;
            this.rb1.ForeColor = System.Drawing.Color.Black;
            this.rb1.Location = new System.Drawing.Point(324, 57);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(71, 16);
            this.rb1.TabIndex = 18;
            this.rb1.TabStop = true;
            this.rb1.Text = "设备明细";
            this.rb1.UseVisualStyleBackColor = true;
            // 
            // txtr_cEQCode
            // 
            this.txtr_cEQCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtr_cEQCode.Border.Class = "TextBoxBorder";
            this.txtr_cEQCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_cEQCode.ButtonCustom.Tooltip = "存货档案";
            this.txtr_cEQCode.ButtonCustom.Visible = true;
            this.txtr_cEQCode.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_cEQCode.ForeColor = System.Drawing.Color.Black;
            this.txtr_cEQCode.Location = new System.Drawing.Point(105, 57);
            this.txtr_cEQCode.Name = "txtr_cEQCode";
            this.txtr_cEQCode.PreventEnterBeep = true;
            this.txtr_cEQCode.Size = new System.Drawing.Size(185, 21);
            this.txtr_cEQCode.TabIndex = 15;
            // 
            // txtr_cEQName
            // 
            this.txtr_cEQName.BackColor = System.Drawing.Color.White;
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
            this.txtr_cEQName.Location = new System.Drawing.Point(105, 95);
            this.txtr_cEQName.Name = "txtr_cEQName";
            this.txtr_cEQName.PreventEnterBeep = true;
            this.txtr_cEQName.Size = new System.Drawing.Size(185, 21);
            this.txtr_cEQName.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(31, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "设备名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(31, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "设备编码：";
            // 
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar2.IsMaximized = false;
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.BtnAddLine,
            this.BtnDelLine});
            this.bar2.Location = new System.Drawing.Point(0, 142);
            this.bar2.Name = "bar2";
            this.bar2.Size = new System.Drawing.Size(514, 27);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 23;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
            // 
            // BtnAddLine
            // 
            this.BtnAddLine.Name = "BtnAddLine";
            this.BtnAddLine.Text = "增行";
            this.BtnAddLine.Click += new System.EventHandler(this.Btn_Addline_Click);
            // 
            // BtnDelLine
            // 
            this.BtnDelLine.Name = "BtnDelLine";
            this.BtnDelLine.Text = "删行";
            this.BtnDelLine.Click += new System.EventHandler(this.Btn_Delline_Click);
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
            this.repositoryItemCalcEdit2});
            this.gridControl2.Size = new System.Drawing.Size(542, 558);
            this.gridControl2.TabIndex = 6;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.bClassDesc,
            this.cEQCode,
            this.cInvName,
            this.cMaker,
            this.dMakeDate,
            this.cModifier,
            this.dModifyDate});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsView.ShowFooter = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // bClassDesc
            // 
            this.bClassDesc.Caption = "类别";
            this.bClassDesc.Name = "bClassDesc";
            this.bClassDesc.Visible = true;
            this.bClassDesc.VisibleIndex = 0;
            this.bClassDesc.Width = 60;
            // 
            // cEQCode
            // 
            this.cEQCode.Caption = "设备编码";
            this.cEQCode.FieldName = "cInvCode";
            this.cEQCode.Name = "cEQCode";
            this.cEQCode.OptionsColumn.AllowEdit = false;
            this.cEQCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "cInvCode", "记录数: {0}")});
            this.cEQCode.Visible = true;
            this.cEQCode.VisibleIndex = 1;
            this.cEQCode.Width = 80;
            // 
            // cInvName
            // 
            this.cInvName.Caption = "设备名称";
            this.cInvName.FieldName = "cInvName";
            this.cInvName.Name = "cInvName";
            this.cInvName.OptionsColumn.AllowEdit = false;
            this.cInvName.Visible = true;
            this.cInvName.VisibleIndex = 2;
            this.cInvName.Width = 80;
            // 
            // repositoryItemCalcEdit2
            // 
            this.repositoryItemCalcEdit2.AutoHeight = false;
            this.repositoryItemCalcEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCalcEdit2.Name = "repositoryItemCalcEdit2";
            // 
            // collapsibleSplitContainer1
            // 
            this.collapsibleSplitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.collapsibleSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.collapsibleSplitContainer1.ForeColor = System.Drawing.Color.Black;
            this.collapsibleSplitContainer1.Location = new System.Drawing.Point(0, 27);
            this.collapsibleSplitContainer1.Name = "collapsibleSplitContainer1";
            // 
            // collapsibleSplitContainer1.Panel1
            // 
            this.collapsibleSplitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.collapsibleSplitContainer1.Panel1.Controls.Add(this.gridControl2);
            this.collapsibleSplitContainer1.Panel1.ForeColor = System.Drawing.Color.Black;
            this.collapsibleSplitContainer1.Panel1MinSize = 0;
            // 
            // collapsibleSplitContainer1.Panel2
            // 
            this.collapsibleSplitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.collapsibleSplitContainer1.Panel2.Controls.Add(this.gridControl1);
            this.collapsibleSplitContainer1.Panel2.Controls.Add(this.bar2);
            this.collapsibleSplitContainer1.Panel2.Controls.Add(this.pnlMain);
            this.collapsibleSplitContainer1.Panel2.ForeColor = System.Drawing.Color.Black;
            this.collapsibleSplitContainer1.Panel2MinSize = 0;
            this.collapsibleSplitContainer1.Size = new System.Drawing.Size(1076, 558);
            this.collapsibleSplitContainer1.SplitterDistance = 542;
            this.collapsibleSplitContainer1.SplitterWidth = 20;
            this.collapsibleSplitContainer1.TabIndex = 27;
            // 
            // dMakeDate
            // 
            this.dMakeDate.Caption = "制单日期";
            this.dMakeDate.FieldName = "dMakeDate";
            this.dMakeDate.Name = "dMakeDate";
            this.dMakeDate.Visible = true;
            this.dMakeDate.VisibleIndex = 3;
            this.dMakeDate.Width = 70;
            // 
            // cMaker
            // 
            this.cMaker.Caption = "制单人";
            this.cMaker.FieldName = "cMaker";
            this.cMaker.Name = "cMaker";
            this.cMaker.Visible = true;
            this.cMaker.VisibleIndex = 4;
            this.cMaker.Width = 57;
            // 
            // cModifier
            // 
            this.cModifier.Caption = "修改";
            this.cModifier.FieldName = "cModifier";
            this.cModifier.Name = "cModifier";
            this.cModifier.Visible = true;
            this.cModifier.VisibleIndex = 5;
            this.cModifier.Width = 60;
            // 
            // dModifyDate
            // 
            this.dModifyDate.Caption = "修改日期";
            this.dModifyDate.FieldName = "dModifyDate";
            this.dModifyDate.Name = "dModifyDate";
            this.dModifyDate.Visible = true;
            this.dModifyDate.VisibleIndex = 6;
            this.dModifyDate.Width = 70;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(320, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "制单人：";
            // 
            // txtr_cMaker
            // 
            this.txtr_cMaker.BackColor = System.Drawing.Color.White;
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
            this.txtr_cMaker.Location = new System.Drawing.Point(382, 95);
            this.txtr_cMaker.Name = "txtr_cMaker";
            this.txtr_cMaker.PreventEnterBeep = true;
            this.txtr_cMaker.Size = new System.Drawing.Size(107, 21);
            this.txtr_cMaker.TabIndex = 21;
            this.txtr_cMaker.Tag = "cMaker";
            // 
            // FmMaintenancePlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 585);
            this.Controls.Add(this.collapsibleSplitContainer1);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Name = "FmMaintenancePlan";
            this.RenderFormIcon = false;
            this.RenderFormText = false;
            this.Text = "检验单";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit2)).EndInit();
            this.collapsibleSplitContainer1.Panel1.ResumeLayout(false);
            this.collapsibleSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.collapsibleSplitContainer1)).EndInit();
            this.collapsibleSplitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        protected DevExpress.XtraGrid.GridControl gridControl1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem BtnAdd;
        private DevComponents.DotNetBar.ButtonItem BtnEdit;
        private DevComponents.DotNetBar.ButtonItem BtnDel;
        private DevComponents.DotNetBar.ButtonItem BtnSave;
        private DevComponents.DotNetBar.ButtonItem BtnCancel;
        private DevComponents.DotNetBar.ButtonItem BtnAudit;
        private DevComponents.DotNetBar.PanelEx pnlMain;
        private DevComponents.DotNetBar.ButtonItem Btn_first;
        private DevComponents.DotNetBar.ButtonItem Btn_previous;
        private DevComponents.DotNetBar.ButtonItem Btn_next;
        private DevComponents.DotNetBar.ButtonItem Btn_last;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.ButtonItem BtnAddLine;
        private DevComponents.DotNetBar.ButtonItem BtnDelLine;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_cEQName;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraGrid.Columns.GridColumn AutoId;
        private DevExpress.XtraGrid.Columns.GridColumn cMCode;
        private DevExpress.XtraGrid.Columns.GridColumn workHours;
        private DevExpress.XtraGrid.Columns.GridColumn colGuid;
        private DevExpress.XtraGrid.Columns.GridColumn reason;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_cEQCode;
        private DevComponents.DotNetBar.ButtonItem BtnUnAudit;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repositoryItemCalcEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn stopHours;
        protected DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn cEQCode;
        private DevExpress.XtraGrid.Columns.GridColumn cInvName;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repositoryItemCalcEdit2;
        private DevComponents.DotNetBar.ButtonItem BtnQuery;
        private DevComponents.DotNetBar.Controls.CollapsibleSplitContainer collapsibleSplitContainer1;
        private System.Windows.Forms.RadioButton rb2;
        private System.Windows.Forms.RadioButton rb1;
        private DevExpress.XtraGrid.Columns.GridColumn bClassDesc;
        private DevExpress.XtraGrid.Columns.GridColumn cMaker;
        private DevExpress.XtraGrid.Columns.GridColumn dMakeDate;
        private DevExpress.XtraGrid.Columns.GridColumn cModifier;
        private DevExpress.XtraGrid.Columns.GridColumn dModifyDate;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_cMaker;
        private System.Windows.Forms.Label label2;
    }
}