namespace LanyunMES.UI
{
    partial class FmStockIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmStockIn));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CardNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MoCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cPosCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cPosName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cInvCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cInvName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cInvStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.iQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.remark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCalcEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
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
            this.txtr_whIn = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtr_dAuditDate = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label10 = new System.Windows.Forms.Label();
            this.txtr_cAuditPsn = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label9 = new System.Windows.Forms.Label();
            this.txtw_cMemo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label7 = new System.Windows.Forms.Label();
            this.txtr_dModifyDate = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label6 = new System.Windows.Forms.Label();
            this.dTVDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtr_modifier = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtr_maker = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtr_cTVCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.BtnAddLine = new DevComponents.DotNetBar.ButtonItem();
            this.BtnDelLine = new DevComponents.DotNetBar.ButtonItem();
            this.lbl_title = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtr_dCreateDate = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.WOCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cComUnitName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dTVDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 258);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCalcEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1054, 322);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MoCode,
            this.WOCode,
            this.CardNo,
            this.cPosCode,
            this.cPosName,
            this.cInvCode,
            this.cInvName,
            this.cInvStd,
            this.iQuantity,
            this.cComUnitName,
            this.remark});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // CardNo
            // 
            this.CardNo.Caption = "流转卡号";
            this.CardNo.FieldName = "CardNo";
            this.CardNo.Name = "CardNo";
            this.CardNo.Visible = true;
            this.CardNo.VisibleIndex = 0;
            this.CardNo.Width = 105;
            // 
            // MoCode
            // 
            this.MoCode.Caption = "生产订单号";
            this.MoCode.FieldName = "MoCode";
            this.MoCode.Name = "MoCode";
            this.MoCode.Visible = true;
            this.MoCode.VisibleIndex = 2;
            this.MoCode.Width = 108;
            // 
            // cPosCode
            // 
            this.cPosCode.Caption = "货位编码";
            this.cPosCode.FieldName = "cPosCode";
            this.cPosCode.Name = "cPosCode";
            this.cPosCode.Visible = true;
            this.cPosCode.VisibleIndex = 3;
            this.cPosCode.Width = 68;
            // 
            // cPosName
            // 
            this.cPosName.Caption = "货位名称";
            this.cPosName.FieldName = "cPosName";
            this.cPosName.Name = "cPosName";
            this.cPosName.OptionsColumn.AllowEdit = false;
            this.cPosName.Visible = true;
            this.cPosName.VisibleIndex = 4;
            this.cPosName.Width = 91;
            // 
            // cInvCode
            // 
            this.cInvCode.Caption = "存货编码";
            this.cInvCode.FieldName = "cInvCode";
            this.cInvCode.Name = "cInvCode";
            this.cInvCode.Visible = true;
            this.cInvCode.VisibleIndex = 5;
            this.cInvCode.Width = 103;
            // 
            // cInvName
            // 
            this.cInvName.Caption = "存货名称";
            this.cInvName.FieldName = "cInvName";
            this.cInvName.Name = "cInvName";
            this.cInvName.OptionsColumn.AllowEdit = false;
            this.cInvName.Visible = true;
            this.cInvName.VisibleIndex = 6;
            this.cInvName.Width = 97;
            // 
            // cInvStd
            // 
            this.cInvStd.Caption = "规格型号";
            this.cInvStd.FieldName = "cInvStd";
            this.cInvStd.Name = "cInvStd";
            this.cInvStd.OptionsColumn.AllowEdit = false;
            this.cInvStd.Visible = true;
            this.cInvStd.VisibleIndex = 7;
            this.cInvStd.Width = 85;
            // 
            // iQuantity
            // 
            this.iQuantity.Caption = "数量";
            this.iQuantity.DisplayFormat.FormatString = "{0:n2}";
            this.iQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.iQuantity.FieldName = "iQuantity";
            this.iQuantity.Name = "iQuantity";
            this.iQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "iTVQuantity", "{0:n2}")});
            this.iQuantity.Visible = true;
            this.iQuantity.VisibleIndex = 8;
            this.iQuantity.Width = 53;
            // 
            // remark
            // 
            this.remark.Caption = "备注";
            this.remark.FieldName = "remark";
            this.remark.Name = "remark";
            this.remark.Visible = true;
            this.remark.VisibleIndex = 10;
            this.remark.Width = 170;
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
            this.pnlMain.Controls.Add(this.txtr_dCreateDate);
            this.pnlMain.Controls.Add(this.label8);
            this.pnlMain.Controls.Add(this.txtr_whIn);
            this.pnlMain.Controls.Add(this.txtr_dAuditDate);
            this.pnlMain.Controls.Add(this.label10);
            this.pnlMain.Controls.Add(this.txtr_cAuditPsn);
            this.pnlMain.Controls.Add(this.label9);
            this.pnlMain.Controls.Add(this.txtw_cMemo);
            this.pnlMain.Controls.Add(this.label7);
            this.pnlMain.Controls.Add(this.txtr_dModifyDate);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.dTVDate);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.txtr_modifier);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.txtr_maker);
            this.pnlMain.Controls.Add(this.txtr_cTVCode);
            this.pnlMain.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMain.Location = new System.Drawing.Point(0, 62);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1054, 169);
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
            // txtr_whIn
            // 
            this.txtr_whIn.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtr_whIn.Border.Class = "TextBoxBorder";
            this.txtr_whIn.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_whIn.ButtonCustom.Tooltip = "转入仓库";
            this.txtr_whIn.ButtonCustom.Visible = true;
            this.txtr_whIn.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_whIn.ForeColor = System.Drawing.Color.Black;
            this.txtr_whIn.Location = new System.Drawing.Point(748, 19);
            this.txtr_whIn.Name = "txtr_whIn";
            this.txtr_whIn.PreventEnterBeep = true;
            this.txtr_whIn.Size = new System.Drawing.Size(145, 21);
            this.txtr_whIn.TabIndex = 20;
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
            this.txtr_dAuditDate.Location = new System.Drawing.Point(452, 91);
            this.txtr_dAuditDate.Name = "txtr_dAuditDate";
            this.txtr_dAuditDate.PreventEnterBeep = true;
            this.txtr_dAuditDate.ReadOnly = true;
            this.txtr_dAuditDate.Size = new System.Drawing.Size(145, 21);
            this.txtr_dAuditDate.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(378, 96);
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
            this.txtr_cAuditPsn.Location = new System.Drawing.Point(132, 91);
            this.txtr_cAuditPsn.Name = "txtr_cAuditPsn";
            this.txtr_cAuditPsn.PreventEnterBeep = true;
            this.txtr_cAuditPsn.ReadOnly = true;
            this.txtr_cAuditPsn.Size = new System.Drawing.Size(145, 21);
            this.txtr_cAuditPsn.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(70, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "审核人：";
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
            this.txtw_cMemo.Location = new System.Drawing.Point(132, 126);
            this.txtw_cMemo.Name = "txtw_cMemo";
            this.txtw_cMemo.PreventEnterBeep = true;
            this.txtw_cMemo.Size = new System.Drawing.Size(465, 21);
            this.txtw_cMemo.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(82, 130);
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
            this.txtr_dModifyDate.Location = new System.Drawing.Point(748, 97);
            this.txtr_dModifyDate.Name = "txtr_dModifyDate";
            this.txtr_dModifyDate.PreventEnterBeep = true;
            this.txtr_dModifyDate.ReadOnly = true;
            this.txtr_dModifyDate.Size = new System.Drawing.Size(145, 21);
            this.txtr_dModifyDate.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(674, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "修改日期：";
            // 
            // dTVDate
            // 
            // 
            // 
            // 
            this.dTVDate.BackgroundStyle.BackColor = System.Drawing.Color.OldLace;
            this.dTVDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dTVDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dTVDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dTVDate.ButtonDropDown.Visible = true;
            this.dTVDate.IsInputReadOnly = true;
            this.dTVDate.IsPopupCalendarOpen = false;
            this.dTVDate.Location = new System.Drawing.Point(452, 19);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dTVDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dTVDate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dTVDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dTVDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dTVDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dTVDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dTVDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dTVDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dTVDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dTVDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dTVDate.MonthCalendar.DisplayMonth = new System.DateTime(2018, 8, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dTVDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dTVDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dTVDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dTVDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dTVDate.MonthCalendar.TodayButtonVisible = true;
            this.dTVDate.Name = "dTVDate";
            this.dTVDate.Size = new System.Drawing.Size(145, 21);
            this.dTVDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dTVDate.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(674, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "转入仓库：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(402, 24);
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
            this.txtr_modifier.Location = new System.Drawing.Point(748, 58);
            this.txtr_modifier.Name = "txtr_modifier";
            this.txtr_modifier.PreventEnterBeep = true;
            this.txtr_modifier.ReadOnly = true;
            this.txtr_modifier.Size = new System.Drawing.Size(145, 21);
            this.txtr_modifier.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(698, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "修改：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "制单：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 26);
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
            this.txtr_maker.Location = new System.Drawing.Point(132, 57);
            this.txtr_maker.Name = "txtr_maker";
            this.txtr_maker.PreventEnterBeep = true;
            this.txtr_maker.ReadOnly = true;
            this.txtr_maker.Size = new System.Drawing.Size(145, 21);
            this.txtr_maker.TabIndex = 1;
            // 
            // txtr_cTVCode
            // 
            this.txtr_cTVCode.BackColor = System.Drawing.Color.OldLace;
            // 
            // 
            // 
            this.txtr_cTVCode.Border.Class = "TextBoxBorder";
            this.txtr_cTVCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_cTVCode.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_cTVCode.ForeColor = System.Drawing.Color.Black;
            this.txtr_cTVCode.Location = new System.Drawing.Point(132, 21);
            this.txtr_cTVCode.Name = "txtr_cTVCode";
            this.txtr_cTVCode.PreventEnterBeep = true;
            this.txtr_cTVCode.ReadOnly = true;
            this.txtr_cTVCode.Size = new System.Drawing.Size(145, 21);
            this.txtr_cTVCode.TabIndex = 0;
            this.txtr_cTVCode.Text = "自动生成";
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
            this.bar2.Location = new System.Drawing.Point(0, 231);
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
            this.lbl_title.TabIndex = 23;
            this.lbl_title.Text = "产品入库单";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(378, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 21;
            this.label8.Text = "制单日期：";
            // 
            // txtr_dCreateDate
            // 
            this.txtr_dCreateDate.BackColor = System.Drawing.Color.OldLace;
            // 
            // 
            // 
            this.txtr_dCreateDate.Border.Class = "TextBoxBorder";
            this.txtr_dCreateDate.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_dCreateDate.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_dCreateDate.ForeColor = System.Drawing.Color.Black;
            this.txtr_dCreateDate.Location = new System.Drawing.Point(452, 57);
            this.txtr_dCreateDate.Name = "txtr_dCreateDate";
            this.txtr_dCreateDate.PreventEnterBeep = true;
            this.txtr_dCreateDate.ReadOnly = true;
            this.txtr_dCreateDate.Size = new System.Drawing.Size(145, 21);
            this.txtr_dCreateDate.TabIndex = 22;
            // 
            // WOCode
            // 
            this.WOCode.Caption = "指令单号";
            this.WOCode.FieldName = "WOCode";
            this.WOCode.Name = "WOCode";
            this.WOCode.Visible = true;
            this.WOCode.VisibleIndex = 1;
            this.WOCode.Width = 105;
            // 
            // cComUnitName
            // 
            this.cComUnitName.Caption = "单位";
            this.cComUnitName.FieldName = "cComUnitName";
            this.cComUnitName.Name = "cComUnitName";
            this.cComUnitName.Visible = true;
            this.cComUnitName.VisibleIndex = 9;
            this.cComUnitName.Width = 51;
            // 
            // FmStockIn
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
            this.Name = "FmStockIn";
            this.RenderFormIcon = false;
            this.RenderFormText = false;
            this.Text = "调拨单";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dTVDate)).EndInit();
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
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_cTVCode;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_modifier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dTVDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtw_cMemo;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_dModifyDate;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraGrid.Columns.GridColumn MoCode;
        private DevExpress.XtraGrid.Columns.GridColumn cPosCode;
        private DevExpress.XtraGrid.Columns.GridColumn cInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn iQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn CardNo;
        private DevExpress.XtraGrid.Columns.GridColumn remark;
        private DevExpress.XtraGrid.Columns.GridColumn cInvName;
        private DevExpress.XtraGrid.Columns.GridColumn cInvStd;
        private DevComponents.DotNetBar.ButtonItem BtnUnAudit;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_dAuditDate;
        private System.Windows.Forms.Label label10;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_cAuditPsn;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraGrid.Columns.GridColumn cPosName;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repositoryItemCalcEdit1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_whIn;
        private System.Windows.Forms.Label lbl_title;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_dCreateDate;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraGrid.Columns.GridColumn WOCode;
        private DevExpress.XtraGrid.Columns.GridColumn cComUnitName;
    }
}