namespace LanyunMES.UI
{
    partial class FmInvMould
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmInvMould));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGuid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.iOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cMCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cMName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Points = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cEQCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cEQName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OpCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.iStep = new DevExpress.XtraGrid.Columns.GridColumn();
            this.timeQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.remark = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.txtr_cInvCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label8 = new System.Windows.Forms.Label();
            this.txtr_cInvName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtr_cInvStd = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.BtnAddLine = new DevComponents.DotNetBar.ButtonItem();
            this.BtnDelLine = new DevComponents.DotNetBar.ButtonItem();
            this.BtnUp = new DevComponents.DotNetBar.ButtonItem();
            this.BtnDown = new DevComponents.DotNetBar.ButtonItem();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cInvCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cInvName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cInvStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCalcEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.collapsibleSplitContainer1 = new DevComponents.DotNetBar.Controls.CollapsibleSplitContainer();
            this.bClassDesc = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridControl1.Location = new System.Drawing.Point(0, 154);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCalcEdit1});
            this.gridControl1.Size = new System.Drawing.Size(909, 405);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGuid,
            this.AutoId,
            this.iOrder,
            this.cMCode,
            this.cMName,
            this.Points,
            this.bClassDesc,
            this.cEQCode,
            this.cEQName,
            this.OpCode,
            this.OpName,
            this.iStep,
            this.timeQty,
            this.remark});
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
            // iOrder
            // 
            this.iOrder.Caption = "优先级";
            this.iOrder.FieldName = "iOrder";
            this.iOrder.Name = "iOrder";
            this.iOrder.Visible = true;
            this.iOrder.VisibleIndex = 0;
            this.iOrder.Width = 50;
            // 
            // cMCode
            // 
            this.cMCode.Caption = "模具编码";
            this.cMCode.FieldName = "cMCode";
            this.cMCode.Name = "cMCode";
            this.cMCode.OptionsColumn.AllowEdit = false;
            this.cMCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "cMCode", "记录数: {0}")});
            this.cMCode.Visible = true;
            this.cMCode.VisibleIndex = 1;
            this.cMCode.Width = 102;
            // 
            // cMName
            // 
            this.cMName.Caption = "模具名称";
            this.cMName.FieldName = "cMName";
            this.cMName.Name = "cMName";
            this.cMName.OptionsColumn.AllowEdit = false;
            this.cMName.Visible = true;
            this.cMName.VisibleIndex = 2;
            this.cMName.Width = 102;
            // 
            // Points
            // 
            this.Points.Caption = "穴数";
            this.Points.FieldName = "Points";
            this.Points.Name = "Points";
            this.Points.OptionsColumn.AllowEdit = false;
            this.Points.Visible = true;
            this.Points.VisibleIndex = 3;
            this.Points.Width = 50;
            // 
            // cEQCode
            // 
            this.cEQCode.Caption = "设备编码";
            this.cEQCode.FieldName = "cEQCode";
            this.cEQCode.Name = "cEQCode";
            this.cEQCode.OptionsColumn.AllowEdit = false;
            this.cEQCode.Visible = true;
            this.cEQCode.VisibleIndex = 5;
            this.cEQCode.Width = 102;
            // 
            // cEQName
            // 
            this.cEQName.Caption = "设备名称";
            this.cEQName.FieldName = "cEQName";
            this.cEQName.Name = "cEQName";
            this.cEQName.OptionsColumn.AllowEdit = false;
            this.cEQName.OptionsColumn.ReadOnly = true;
            this.cEQName.Visible = true;
            this.cEQName.VisibleIndex = 6;
            this.cEQName.Width = 102;
            // 
            // OpCode
            // 
            this.OpCode.Caption = "工序编码";
            this.OpCode.FieldName = "OpCode";
            this.OpCode.Name = "OpCode";
            this.OpCode.OptionsColumn.AllowEdit = false;
            this.OpCode.Width = 94;
            // 
            // OpName
            // 
            this.OpName.Caption = "工序名称";
            this.OpName.FieldName = "OpName";
            this.OpName.Name = "OpName";
            this.OpName.OptionsColumn.AllowEdit = false;
            this.OpName.Width = 126;
            // 
            // iStep
            // 
            this.iStep.Caption = "节拍/秒";
            this.iStep.FieldName = "iStep";
            this.iStep.Name = "iStep";
            this.iStep.Visible = true;
            this.iStep.VisibleIndex = 7;
            this.iStep.Width = 58;
            // 
            // timeQty
            // 
            this.timeQty.Caption = "产能/H";
            this.timeQty.DisplayFormat.FormatString = "{0:n2}";
            this.timeQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.timeQty.FieldName = "timeQty";
            this.timeQty.Name = "timeQty";
            this.timeQty.OptionsColumn.AllowEdit = false;
            this.timeQty.Visible = true;
            this.timeQty.VisibleIndex = 8;
            this.timeQty.Width = 58;
            // 
            // remark
            // 
            this.remark.Caption = "备注";
            this.remark.FieldName = "remark";
            this.remark.Name = "remark";
            this.remark.Visible = true;
            this.remark.VisibleIndex = 9;
            this.remark.Width = 180;
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
            this.bar1.Size = new System.Drawing.Size(1264, 27);
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
            this.pnlMain.Controls.Add(this.txtr_cInvCode);
            this.pnlMain.Controls.Add(this.label8);
            this.pnlMain.Controls.Add(this.txtr_cInvName);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.txtr_cInvStd);
            this.pnlMain.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(909, 127);
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
            this.pnlMain.Text = "产品模具设备对照表";
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
            this.txtr_cInvCode.Location = new System.Drawing.Point(107, 60);
            this.txtr_cInvCode.Name = "txtr_cInvCode";
            this.txtr_cInvCode.PreventEnterBeep = true;
            this.txtr_cInvCode.Size = new System.Drawing.Size(145, 21);
            this.txtr_cInvCode.TabIndex = 15;
            this.txtr_cInvCode.Tag = "cInvCode";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(588, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 14;
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
            this.txtr_cInvName.Location = new System.Drawing.Point(375, 60);
            this.txtr_cInvName.Name = "txtr_cInvName";
            this.txtr_cInvName.PreventEnterBeep = true;
            this.txtr_cInvName.Size = new System.Drawing.Size(165, 21);
            this.txtr_cInvName.TabIndex = 8;
            this.txtr_cInvName.Tag = "cInvName";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(304, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "产品名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
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
            this.txtr_cInvStd.Location = new System.Drawing.Point(662, 60);
            this.txtr_cInvStd.Name = "txtr_cInvStd";
            this.txtr_cInvStd.PreventEnterBeep = true;
            this.txtr_cInvStd.ReadOnly = true;
            this.txtr_cInvStd.Size = new System.Drawing.Size(160, 21);
            this.txtr_cInvStd.TabIndex = 0;
            this.txtr_cInvStd.Tag = "cInvStd";
            // 
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar2.IsMaximized = false;
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.BtnAddLine,
            this.BtnDelLine,
            this.BtnUp,
            this.BtnDown});
            this.bar2.Location = new System.Drawing.Point(0, 127);
            this.bar2.Name = "bar2";
            this.bar2.Size = new System.Drawing.Size(909, 27);
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
            // BtnUp
            // 
            this.BtnUp.Name = "BtnUp";
            this.BtnUp.Text = "上移";
            this.BtnUp.Click += new System.EventHandler(this.BtnUp_Click);
            // 
            // BtnDown
            // 
            this.BtnDown.Name = "BtnDown";
            this.BtnDown.Text = "下移";
            this.BtnDown.Click += new System.EventHandler(this.BtnDown_Click);
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCalcEdit2});
            this.gridControl2.Size = new System.Drawing.Size(335, 559);
            this.gridControl2.TabIndex = 6;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.cInvCode,
            this.cInvName,
            this.cInvStd});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsView.ShowFooter = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // cInvCode
            // 
            this.cInvCode.Caption = "存货编码";
            this.cInvCode.FieldName = "cInvCode";
            this.cInvCode.Name = "cInvCode";
            this.cInvCode.OptionsColumn.AllowEdit = false;
            this.cInvCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "cInvCode", "记录数: {0}")});
            this.cInvCode.Visible = true;
            this.cInvCode.VisibleIndex = 0;
            this.cInvCode.Width = 90;
            // 
            // cInvName
            // 
            this.cInvName.Caption = "存货名称";
            this.cInvName.FieldName = "cInvName";
            this.cInvName.Name = "cInvName";
            this.cInvName.OptionsColumn.AllowEdit = false;
            this.cInvName.Visible = true;
            this.cInvName.VisibleIndex = 1;
            this.cInvName.Width = 90;
            // 
            // cInvStd
            // 
            this.cInvStd.Caption = "规格型号";
            this.cInvStd.FieldName = "cInvStd";
            this.cInvStd.Name = "cInvStd";
            this.cInvStd.OptionsColumn.AllowEdit = false;
            this.cInvStd.Visible = true;
            this.cInvStd.VisibleIndex = 2;
            this.cInvStd.Width = 90;
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
            this.collapsibleSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.collapsibleSplitContainer1.Location = new System.Drawing.Point(0, 27);
            this.collapsibleSplitContainer1.Name = "collapsibleSplitContainer1";
            // 
            // collapsibleSplitContainer1.Panel1
            // 
            this.collapsibleSplitContainer1.Panel1.Controls.Add(this.gridControl2);
            this.collapsibleSplitContainer1.Panel1MinSize = 0;
            // 
            // collapsibleSplitContainer1.Panel2
            // 
            this.collapsibleSplitContainer1.Panel2.Controls.Add(this.gridControl1);
            this.collapsibleSplitContainer1.Panel2.Controls.Add(this.bar2);
            this.collapsibleSplitContainer1.Panel2.Controls.Add(this.pnlMain);
            this.collapsibleSplitContainer1.Panel2MinSize = 0;
            this.collapsibleSplitContainer1.Size = new System.Drawing.Size(1264, 559);
            this.collapsibleSplitContainer1.SplitterDistance = 335;
            this.collapsibleSplitContainer1.SplitterWidth = 20;
            this.collapsibleSplitContainer1.TabIndex = 27;
            // 
            // bClassDesc
            // 
            this.bClassDesc.Caption = "设备类别";
            this.bClassDesc.FieldName = "bClassDesc";
            this.bClassDesc.Name = "bClassDesc";
            this.bClassDesc.Visible = true;
            this.bClassDesc.VisibleIndex = 4;
            this.bClassDesc.Width = 71;
            // 
            // FmInvMould
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 586);
            this.Controls.Add(this.collapsibleSplitContainer1);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Name = "FmInvMould";
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
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_cInvStd;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_cInvName;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraGrid.Columns.GridColumn AutoId;
        private DevExpress.XtraGrid.Columns.GridColumn cMCode;
        private DevExpress.XtraGrid.Columns.GridColumn cMName;
        private DevExpress.XtraGrid.Columns.GridColumn timeQty;
        private DevExpress.XtraGrid.Columns.GridColumn colGuid;
        private DevExpress.XtraGrid.Columns.GridColumn remark;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_cInvCode;
        private System.Windows.Forms.Label label8;
        private DevComponents.DotNetBar.ButtonItem BtnUnAudit;
        private DevExpress.XtraGrid.Columns.GridColumn cEQCode;
        private DevExpress.XtraGrid.Columns.GridColumn cEQName;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repositoryItemCalcEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn OpCode;
        private DevExpress.XtraGrid.Columns.GridColumn OpName;
        private DevExpress.XtraGrid.Columns.GridColumn iStep;
        private DevExpress.XtraGrid.Columns.GridColumn Points;
        protected DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn cInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn cInvName;
        private DevExpress.XtraGrid.Columns.GridColumn cInvStd;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repositoryItemCalcEdit2;
        private DevComponents.DotNetBar.ButtonItem BtnQuery;
        private DevComponents.DotNetBar.Controls.CollapsibleSplitContainer collapsibleSplitContainer1;
        private DevExpress.XtraGrid.Columns.GridColumn iOrder;
        private DevComponents.DotNetBar.ButtonItem BtnUp;
        private DevComponents.DotNetBar.ButtonItem BtnDown;
        private DevExpress.XtraGrid.Columns.GridColumn bClassDesc;
    }
}