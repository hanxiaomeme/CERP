namespace LanyunMES.UI
{
    partial class FmQmRecord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmQmRecord));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGuid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.POIDs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cPOID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cPosCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cPosName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cInvCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cInvName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cInvStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cFree1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.qmQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.iQualifyQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCalcEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.iUnQualifyQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.remark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bar1 = new DevComponents.DotNetBar.Bar();
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
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.txt_search = new DevComponents.DotNetBar.TextBoxItem();
            this.pnlMain = new DevComponents.DotNetBar.PanelEx();
            this.txtr_dAuditDate = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label10 = new System.Windows.Forms.Label();
            this.txtr_cAuditPsn = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_checkPsn = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label8 = new System.Windows.Forms.Label();
            this.txtw_cMemo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label7 = new System.Windows.Forms.Label();
            this.txtr_dModifyDate = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label6 = new System.Windows.Forms.Label();
            this.dQmDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtr_vendor = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtr_modifier = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtr_maker = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtr_QmCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.BtnAddLine = new DevComponents.DotNetBar.ButtonItem();
            this.BtnDelLine = new DevComponents.DotNetBar.ButtonItem();
            this.lbl_title = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dQmDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 255);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCalcEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1054, 325);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGuid,
            this.AutoId,
            this.POIDs,
            this.cPOID,
            this.cPosCode,
            this.cPosName,
            this.cInvCode,
            this.cInvName,
            this.cInvStd,
            this.cFree1,
            this.qmQty,
            this.iQualifyQty,
            this.iUnQualifyQty,
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
            // POIDs
            // 
            this.POIDs.Caption = "采购订单行ID";
            this.POIDs.FieldName = "POIDs";
            this.POIDs.Name = "POIDs";
            this.POIDs.OptionsColumn.AllowEdit = false;
            this.POIDs.Width = 49;
            // 
            // cPOID
            // 
            this.cPOID.Caption = "采购订单号";
            this.cPOID.FieldName = "cPOID";
            this.cPOID.Name = "cPOID";
            this.cPOID.OptionsColumn.AllowEdit = false;
            this.cPOID.Visible = true;
            this.cPOID.VisibleIndex = 0;
            this.cPOID.Width = 94;
            // 
            // cPosCode
            // 
            this.cPosCode.Caption = "货位编码";
            this.cPosCode.FieldName = "cPosCode";
            this.cPosCode.Name = "cPosCode";
            this.cPosCode.Visible = true;
            this.cPosCode.VisibleIndex = 1;
            this.cPosCode.Width = 80;
            // 
            // cPosName
            // 
            this.cPosName.Caption = "货位名称";
            this.cPosName.FieldName = "cPosName";
            this.cPosName.Name = "cPosName";
            this.cPosName.OptionsColumn.AllowEdit = false;
            this.cPosName.OptionsColumn.ReadOnly = true;
            this.cPosName.Visible = true;
            this.cPosName.VisibleIndex = 2;
            this.cPosName.Width = 90;
            // 
            // cInvCode
            // 
            this.cInvCode.Caption = "存货编码";
            this.cInvCode.FieldName = "cInvCode";
            this.cInvCode.Name = "cInvCode";
            this.cInvCode.OptionsColumn.AllowEdit = false;
            this.cInvCode.Visible = true;
            this.cInvCode.VisibleIndex = 3;
            this.cInvCode.Width = 123;
            // 
            // cInvName
            // 
            this.cInvName.Caption = "存货名称";
            this.cInvName.FieldName = "cInvName";
            this.cInvName.Name = "cInvName";
            this.cInvName.OptionsColumn.AllowEdit = false;
            this.cInvName.Visible = true;
            this.cInvName.VisibleIndex = 4;
            this.cInvName.Width = 118;
            // 
            // cInvStd
            // 
            this.cInvStd.Caption = "规格型号";
            this.cInvStd.FieldName = "cInvStd";
            this.cInvStd.Name = "cInvStd";
            this.cInvStd.OptionsColumn.AllowEdit = false;
            this.cInvStd.Visible = true;
            this.cInvStd.VisibleIndex = 5;
            this.cInvStd.Width = 117;
            // 
            // cFree1
            // 
            this.cFree1.Caption = "自由项1";
            this.cFree1.FieldName = "cFree1";
            this.cFree1.Name = "cFree1";
            this.cFree1.OptionsColumn.AllowEdit = false;
            this.cFree1.Width = 83;
            // 
            // qmQty
            // 
            this.qmQty.Caption = "报检数量";
            this.qmQty.DisplayFormat.FormatString = "{0:n2}";
            this.qmQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.qmQty.FieldName = "qmQty";
            this.qmQty.Name = "qmQty";
            this.qmQty.OptionsColumn.AllowEdit = false;
            this.qmQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qmQty", "{0:n2}")});
            this.qmQty.Visible = true;
            this.qmQty.VisibleIndex = 6;
            this.qmQty.Width = 67;
            // 
            // iQualifyQty
            // 
            this.iQualifyQty.Caption = "合格数量";
            this.iQualifyQty.ColumnEdit = this.repositoryItemCalcEdit1;
            this.iQualifyQty.DisplayFormat.FormatString = "{0:n2}";
            this.iQualifyQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.iQualifyQty.FieldName = "iQualifyQty";
            this.iQualifyQty.Name = "iQualifyQty";
            this.iQualifyQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "iQualifyQty", "{0:n2}")});
            this.iQualifyQty.Visible = true;
            this.iQualifyQty.VisibleIndex = 7;
            this.iQualifyQty.Width = 67;
            // 
            // repositoryItemCalcEdit1
            // 
            this.repositoryItemCalcEdit1.AutoHeight = false;
            this.repositoryItemCalcEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCalcEdit1.Name = "repositoryItemCalcEdit1";
            // 
            // iUnQualifyQty
            // 
            this.iUnQualifyQty.Caption = "不合格数量";
            this.iUnQualifyQty.DisplayFormat.FormatString = "{0:n2}";
            this.iUnQualifyQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.iUnQualifyQty.FieldName = "iUnQualifyQty";
            this.iUnQualifyQty.Name = "iUnQualifyQty";
            this.iUnQualifyQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "iUnQualifyQty", "{0:n2}")});
            this.iUnQualifyQty.Visible = true;
            this.iUnQualifyQty.VisibleIndex = 8;
            // 
            // remark
            // 
            this.remark.Caption = "备注";
            this.remark.FieldName = "remark";
            this.remark.Name = "remark";
            this.remark.Visible = true;
            this.remark.VisibleIndex = 9;
            this.remark.Width = 110;
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
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
            this.Btn_last,
            this.labelItem1,
            this.txt_search});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.PaddingRight = 50;
            this.bar1.Size = new System.Drawing.Size(1054, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 6;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // BtnAdd
            // 
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Text = "新增";
            this.BtnAdd.Visible = false;
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
            // labelItem1
            // 
            this.labelItem1.BackColor = System.Drawing.Color.Transparent;
            this.labelItem1.ForeColor = System.Drawing.Color.Black;
            this.labelItem1.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "单据号：";
            // 
            // txt_search
            // 
            this.txt_search.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.txt_search.Name = "txt_search";
            this.txt_search.TextBoxWidth = 150;
            this.txt_search.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // pnlMain
            // 
            this.pnlMain.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlMain.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlMain.Controls.Add(this.txtr_dAuditDate);
            this.pnlMain.Controls.Add(this.label10);
            this.pnlMain.Controls.Add(this.txtr_cAuditPsn);
            this.pnlMain.Controls.Add(this.label9);
            this.pnlMain.Controls.Add(this.txt_checkPsn);
            this.pnlMain.Controls.Add(this.label8);
            this.pnlMain.Controls.Add(this.txtw_cMemo);
            this.pnlMain.Controls.Add(this.label7);
            this.pnlMain.Controls.Add(this.txtr_dModifyDate);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.dQmDate);
            this.pnlMain.Controls.Add(this.txtr_vendor);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.txtr_modifier);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.txtr_maker);
            this.pnlMain.Controls.Add(this.txtr_QmCode);
            this.pnlMain.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMain.Location = new System.Drawing.Point(0, 62);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1054, 166);
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
            // 
            // txtr_dAuditDate
            // 
            this.txtr_dAuditDate.BackColor = System.Drawing.Color.OldLace;
            // 
            // 
            // 
            this.txtr_dAuditDate.Border.Class = "TextBoxBorder";
            this.txtr_dAuditDate.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_dAuditDate.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_dAuditDate.ForeColor = System.Drawing.Color.Black;
            this.txtr_dAuditDate.Location = new System.Drawing.Point(469, 91);
            this.txtr_dAuditDate.Name = "txtr_dAuditDate";
            this.txtr_dAuditDate.PreventEnterBeep = true;
            this.txtr_dAuditDate.ReadOnly = true;
            this.txtr_dAuditDate.Size = new System.Drawing.Size(145, 21);
            this.txtr_dAuditDate.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(395, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "审核日期：";
            // 
            // txtr_cAuditPsn
            // 
            this.txtr_cAuditPsn.BackColor = System.Drawing.Color.OldLace;
            // 
            // 
            // 
            this.txtr_cAuditPsn.Border.Class = "TextBoxBorder";
            this.txtr_cAuditPsn.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_cAuditPsn.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_cAuditPsn.ForeColor = System.Drawing.Color.Black;
            this.txtr_cAuditPsn.Location = new System.Drawing.Point(130, 91);
            this.txtr_cAuditPsn.Name = "txtr_cAuditPsn";
            this.txtr_cAuditPsn.PreventEnterBeep = true;
            this.txtr_cAuditPsn.ReadOnly = true;
            this.txtr_cAuditPsn.Size = new System.Drawing.Size(145, 21);
            this.txtr_cAuditPsn.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(68, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "审核人：";
            // 
            // txt_checkPsn
            // 
            this.txt_checkPsn.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_checkPsn.Border.Class = "TextBoxBorder";
            this.txt_checkPsn.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_checkPsn.ButtonCustom.Visible = true;
            this.txt_checkPsn.DisabledBackColor = System.Drawing.Color.White;
            this.txt_checkPsn.ForeColor = System.Drawing.Color.Black;
            this.txt_checkPsn.Location = new System.Drawing.Point(469, 56);
            this.txt_checkPsn.Name = "txt_checkPsn";
            this.txt_checkPsn.PreventEnterBeep = true;
            this.txt_checkPsn.Size = new System.Drawing.Size(145, 21);
            this.txt_checkPsn.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(407, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "检验员：";
            // 
            // txtw_cMemo
            // 
            this.txtw_cMemo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtw_cMemo.Border.Class = "TextBoxBorder";
            this.txtw_cMemo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtw_cMemo.DisabledBackColor = System.Drawing.Color.White;
            this.txtw_cMemo.ForeColor = System.Drawing.Color.Black;
            this.txtw_cMemo.Location = new System.Drawing.Point(130, 126);
            this.txtw_cMemo.Name = "txtw_cMemo";
            this.txtw_cMemo.PreventEnterBeep = true;
            this.txtw_cMemo.Size = new System.Drawing.Size(484, 21);
            this.txtw_cMemo.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(80, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "备注：";
            // 
            // txtr_dModifyDate
            // 
            this.txtr_dModifyDate.BackColor = System.Drawing.Color.OldLace;
            // 
            // 
            // 
            this.txtr_dModifyDate.Border.Class = "TextBoxBorder";
            this.txtr_dModifyDate.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_dModifyDate.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_dModifyDate.ForeColor = System.Drawing.Color.Black;
            this.txtr_dModifyDate.Location = new System.Drawing.Point(746, 91);
            this.txtr_dModifyDate.Name = "txtr_dModifyDate";
            this.txtr_dModifyDate.PreventEnterBeep = true;
            this.txtr_dModifyDate.ReadOnly = true;
            this.txtr_dModifyDate.Size = new System.Drawing.Size(145, 21);
            this.txtr_dModifyDate.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(672, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "修改日期：";
            // 
            // dQmDate
            // 
            // 
            // 
            // 
            this.dQmDate.BackgroundStyle.BackColor = System.Drawing.Color.OldLace;
            this.dQmDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dQmDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dQmDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dQmDate.ButtonDropDown.Visible = true;
            this.dQmDate.IsInputReadOnly = true;
            this.dQmDate.IsPopupCalendarOpen = false;
            this.dQmDate.Location = new System.Drawing.Point(469, 21);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dQmDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dQmDate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dQmDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dQmDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dQmDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dQmDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dQmDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dQmDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dQmDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dQmDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dQmDate.MonthCalendar.DisplayMonth = new System.DateTime(2018, 8, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dQmDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dQmDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dQmDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dQmDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dQmDate.MonthCalendar.TodayButtonVisible = true;
            this.dQmDate.Name = "dQmDate";
            this.dQmDate.Size = new System.Drawing.Size(145, 21);
            this.dQmDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dQmDate.TabIndex = 9;
            // 
            // txtr_vendor
            // 
            this.txtr_vendor.BackColor = System.Drawing.Color.OldLace;
            // 
            // 
            // 
            this.txtr_vendor.Border.Class = "TextBoxBorder";
            this.txtr_vendor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_vendor.ButtonCustom.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtr_vendor.ButtonCustom.SymbolColor = System.Drawing.Color.RoyalBlue;
            this.txtr_vendor.ButtonCustom.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.txtr_vendor.ButtonCustom2.Enabled = false;
            this.txtr_vendor.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_vendor.ForeColor = System.Drawing.Color.Black;
            this.txtr_vendor.Location = new System.Drawing.Point(130, 56);
            this.txtr_vendor.Name = "txtr_vendor";
            this.txtr_vendor.PreventEnterBeep = true;
            this.txtr_vendor.Size = new System.Drawing.Size(254, 21);
            this.txtr_vendor.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(68, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "供应商：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(411, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "日期：";
            // 
            // txtr_modifier
            // 
            this.txtr_modifier.BackColor = System.Drawing.Color.OldLace;
            // 
            // 
            // 
            this.txtr_modifier.Border.Class = "TextBoxBorder";
            this.txtr_modifier.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_modifier.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_modifier.ForeColor = System.Drawing.Color.Black;
            this.txtr_modifier.Location = new System.Drawing.Point(746, 56);
            this.txtr_modifier.Name = "txtr_modifier";
            this.txtr_modifier.PreventEnterBeep = true;
            this.txtr_modifier.ReadOnly = true;
            this.txtr_modifier.Size = new System.Drawing.Size(145, 21);
            this.txtr_modifier.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(696, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "修改：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(696, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "制单：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "单据号：";
            // 
            // txtr_maker
            // 
            this.txtr_maker.BackColor = System.Drawing.Color.OldLace;
            // 
            // 
            // 
            this.txtr_maker.Border.Class = "TextBoxBorder";
            this.txtr_maker.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_maker.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_maker.ForeColor = System.Drawing.Color.Black;
            this.txtr_maker.Location = new System.Drawing.Point(746, 21);
            this.txtr_maker.Name = "txtr_maker";
            this.txtr_maker.PreventEnterBeep = true;
            this.txtr_maker.ReadOnly = true;
            this.txtr_maker.Size = new System.Drawing.Size(145, 21);
            this.txtr_maker.TabIndex = 1;
            // 
            // txtr_QmCode
            // 
            this.txtr_QmCode.BackColor = System.Drawing.Color.OldLace;
            // 
            // 
            // 
            this.txtr_QmCode.Border.Class = "TextBoxBorder";
            this.txtr_QmCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_QmCode.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_QmCode.ForeColor = System.Drawing.Color.Black;
            this.txtr_QmCode.Location = new System.Drawing.Point(130, 21);
            this.txtr_QmCode.Name = "txtr_QmCode";
            this.txtr_QmCode.PreventEnterBeep = true;
            this.txtr_QmCode.ReadOnly = true;
            this.txtr_QmCode.Size = new System.Drawing.Size(145, 21);
            this.txtr_QmCode.TabIndex = 0;
            this.txtr_QmCode.Text = "自动生成";
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
            this.bar2.Location = new System.Drawing.Point(0, 228);
            this.bar2.Name = "bar2";
            this.bar2.Size = new System.Drawing.Size(1054, 27);
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
            this.BtnAddLine.Visible = false;
            this.BtnAddLine.Click += new System.EventHandler(this.Btn_Addline_Click);
            // 
            // BtnDelLine
            // 
            this.BtnDelLine.Name = "BtnDelLine";
            this.BtnDelLine.Text = "删行";
            this.BtnDelLine.Click += new System.EventHandler(this.Btn_Delline_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_title.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_title.Location = new System.Drawing.Point(0, 27);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(1054, 35);
            this.lbl_title.TabIndex = 20;
            this.lbl_title.Text = "检验单";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FmQmRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 580);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.bar2);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Name = "FmQmRecord";
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
            ((System.ComponentModel.ISupportInitialize)(this.dQmDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
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
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.TextBoxItem txt_search;
        private DevComponents.DotNetBar.PanelEx pnlMain;
        private DevComponents.DotNetBar.ButtonItem Btn_first;
        private DevComponents.DotNetBar.ButtonItem Btn_previous;
        private DevComponents.DotNetBar.ButtonItem Btn_next;
        private DevComponents.DotNetBar.ButtonItem Btn_last;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.ButtonItem BtnAddLine;
        private DevComponents.DotNetBar.ButtonItem BtnDelLine;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_maker;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_QmCode;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_modifier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dQmDate;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_vendor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtw_cMemo;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_dModifyDate;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraGrid.Columns.GridColumn AutoId;
        private DevExpress.XtraGrid.Columns.GridColumn POIDs;
        private DevExpress.XtraGrid.Columns.GridColumn cPOID;
        private DevExpress.XtraGrid.Columns.GridColumn cInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn cFree1;
        private DevExpress.XtraGrid.Columns.GridColumn iQualifyQty;
        private DevExpress.XtraGrid.Columns.GridColumn qmQty;
        private DevExpress.XtraGrid.Columns.GridColumn colGuid;
        private DevExpress.XtraGrid.Columns.GridColumn remark;
        private DevExpress.XtraGrid.Columns.GridColumn cInvName;
        private DevExpress.XtraGrid.Columns.GridColumn cInvStd;
        private DevExpress.XtraGrid.Columns.GridColumn iUnQualifyQty;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_checkPsn;
        private System.Windows.Forms.Label label8;
        private DevComponents.DotNetBar.ButtonItem BtnUnAudit;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_dAuditDate;
        private System.Windows.Forms.Label label10;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_cAuditPsn;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraGrid.Columns.GridColumn cPosCode;
        private DevExpress.XtraGrid.Columns.GridColumn cPosName;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repositoryItemCalcEdit1;
        private System.Windows.Forms.Label lbl_title;
    }
}