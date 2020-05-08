namespace LanyunMES.UI
{
    partial class FmMaterialPlan
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cWhItemButtonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.cPositionButtonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.BtnPrint = new DevComponents.DotNetBar.ButtonItem();
            this.BtnDesign = new DevComponents.DotNetBar.ButtonItem();
            this.BtnAdd = new DevComponents.DotNetBar.ButtonItem();
            this.BtnEdit = new DevComponents.DotNetBar.ButtonItem();
            this.BtnDel = new DevComponents.DotNetBar.ButtonItem();
            this.BtnSave = new DevComponents.DotNetBar.ButtonItem();
            this.BtnCancel = new DevComponents.DotNetBar.ButtonItem();
            this.BtnAudit = new DevComponents.DotNetBar.ButtonItem();
            this.BtnUnAudit = new DevComponents.DotNetBar.ButtonItem();
            this.BtnMatch = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.txt_search = new DevComponents.DotNetBar.TextBoxItem();
            this.pnlMain = new DevComponents.DotNetBar.PanelEx();
            this.txt_wareHouse = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label8 = new System.Windows.Forms.Label();
            this.txtr_cDepName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label6 = new System.Windows.Forms.Label();
            this.txtr_cRdName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.dtPicker = new System.Windows.Forms.DateTimePicker();
            this.txtr_dAuditDate = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label10 = new System.Windows.Forms.Label();
            this.txtr_cAuditPsn = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label9 = new System.Windows.Forms.Label();
            this.txtw_cMemo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label7 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cWhItemButtonEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cPositionButtonEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 249);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cWhItemButtonEdit,
            this.cPositionButtonEdit});
            this.gridControl1.Size = new System.Drawing.Size(1054, 331);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Enter += new System.EventHandler(this.gridControl1_Enter);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // cWhItemButtonEdit
            // 
            this.cWhItemButtonEdit.AutoHeight = false;
            this.cWhItemButtonEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.cWhItemButtonEdit.Name = "cWhItemButtonEdit";
            this.cWhItemButtonEdit.Click += new System.EventHandler(this.cWhItemButtonEdit_Click);
            // 
            // cPositionButtonEdit
            // 
            this.cPositionButtonEdit.AutoHeight = false;
            this.cPositionButtonEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.cPositionButtonEdit.Name = "cPositionButtonEdit";
            this.cPositionButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cPositionButtonEdit_ButtonClick);
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.BtnPrint,
            this.BtnAdd,
            this.BtnEdit,
            this.BtnDel,
            this.BtnSave,
            this.BtnCancel,
            this.BtnAudit,
            this.BtnUnAudit,
            this.BtnMatch,
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
            // BtnPrint
            // 
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.BtnDesign});
            this.BtnPrint.Text = "打印(&P)";
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // BtnDesign
            // 
            this.BtnDesign.Name = "BtnDesign";
            this.BtnDesign.Text = "打印设计";
            this.BtnDesign.Click += new System.EventHandler(this.BtnDesign_Click);
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
            // BtnMatch
            // 
            this.BtnMatch.Name = "BtnMatch";
            this.BtnMatch.Text = "匹配货位";
            this.BtnMatch.Click += new System.EventHandler(this.btn_Match_Click);
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
            this.pnlMain.Controls.Add(this.txt_wareHouse);
            this.pnlMain.Controls.Add(this.label8);
            this.pnlMain.Controls.Add(this.txtr_cDepName);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.txtr_cRdName);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.dtPicker);
            this.pnlMain.Controls.Add(this.txtr_dAuditDate);
            this.pnlMain.Controls.Add(this.label10);
            this.pnlMain.Controls.Add(this.txtr_cAuditPsn);
            this.pnlMain.Controls.Add(this.label9);
            this.pnlMain.Controls.Add(this.txtw_cMemo);
            this.pnlMain.Controls.Add(this.label7);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.txtr_modifier);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.txtr_maker);
            this.pnlMain.Controls.Add(this.txtr_QmCode);
            this.pnlMain.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMain.Location = new System.Drawing.Point(0, 27);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1054, 195);
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
            this.pnlMain.Text = "拣货单";
            // 
            // txt_wareHouse
            // 
            this.txt_wareHouse.BackColor = System.Drawing.Color.FloralWhite;
            // 
            // 
            // 
            this.txt_wareHouse.Border.Class = "TextBoxBorder";
            this.txt_wareHouse.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_wareHouse.ButtonCustom.Tooltip = "rd_style";
            this.txt_wareHouse.ButtonCustom.Visible = true;
            this.txt_wareHouse.DisabledBackColor = System.Drawing.Color.White;
            this.txt_wareHouse.ForeColor = System.Drawing.Color.Black;
            this.txt_wareHouse.Location = new System.Drawing.Point(429, 89);
            this.txt_wareHouse.Name = "txt_wareHouse";
            this.txt_wareHouse.PreventEnterBeep = true;
            this.txt_wareHouse.ReadOnly = true;
            this.txt_wareHouse.Size = new System.Drawing.Size(145, 21);
            this.txt_wareHouse.TabIndex = 26;
            this.txt_wareHouse.Tag = "cWhName";
            this.txt_wareHouse.ButtonCustomClick += new System.EventHandler(this.txt_wareHouse_ButtonCustomClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(379, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 25;
            this.label8.Text = "仓库：";
            // 
            // txtr_cDepName
            // 
            this.txtr_cDepName.BackColor = System.Drawing.Color.FloralWhite;
            // 
            // 
            // 
            this.txtr_cDepName.Border.Class = "TextBoxBorder";
            this.txtr_cDepName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_cDepName.ButtonCustom.Tooltip = "department";
            this.txtr_cDepName.ButtonCustom.Visible = true;
            this.txtr_cDepName.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_cDepName.ForeColor = System.Drawing.Color.Black;
            this.txtr_cDepName.Location = new System.Drawing.Point(745, 56);
            this.txtr_cDepName.Name = "txtr_cDepName";
            this.txtr_cDepName.PreventEnterBeep = true;
            this.txtr_cDepName.ReadOnly = true;
            this.txtr_cDepName.Size = new System.Drawing.Size(145, 21);
            this.txtr_cDepName.TabIndex = 24;
            this.txtr_cDepName.Tag = "cDepName";
            this.txtr_cDepName.ButtonCustomClick += new System.EventHandler(this.txtr_cDepName_ButtonCustomClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(695, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 23;
            this.label6.Text = "部门：";
            // 
            // txtr_cRdName
            // 
            this.txtr_cRdName.BackColor = System.Drawing.Color.FloralWhite;
            // 
            // 
            // 
            this.txtr_cRdName.Border.Class = "TextBoxBorder";
            this.txtr_cRdName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_cRdName.ButtonCustom.Tooltip = "rd_style";
            this.txtr_cRdName.ButtonCustom.Visible = true;
            this.txtr_cRdName.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_cRdName.ForeColor = System.Drawing.Color.Black;
            this.txtr_cRdName.Location = new System.Drawing.Point(129, 89);
            this.txtr_cRdName.Name = "txtr_cRdName";
            this.txtr_cRdName.PreventEnterBeep = true;
            this.txtr_cRdName.ReadOnly = true;
            this.txtr_cRdName.Size = new System.Drawing.Size(145, 21);
            this.txtr_cRdName.TabIndex = 22;
            this.txtr_cRdName.Tag = "cRdName";
            this.txtr_cRdName.ButtonCustomClick += new System.EventHandler(this.txtr_cRdName_ButtonCustomClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 21;
            this.label5.Text = "出库类别：";
            // 
            // dtPicker
            // 
            this.dtPicker.CustomFormat = "yyyy-MM-dd";
            this.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPicker.Location = new System.Drawing.Point(429, 56);
            this.dtPicker.Name = "dtPicker";
            this.dtPicker.Size = new System.Drawing.Size(145, 21);
            this.dtPicker.TabIndex = 20;
            this.dtPicker.Tag = "dDate";
            // 
            // txtr_dAuditDate
            // 
            this.txtr_dAuditDate.BackColor = System.Drawing.Color.FloralWhite;
            // 
            // 
            // 
            this.txtr_dAuditDate.Border.Class = "TextBoxBorder";
            this.txtr_dAuditDate.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_dAuditDate.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_dAuditDate.ForeColor = System.Drawing.Color.Black;
            this.txtr_dAuditDate.Location = new System.Drawing.Point(745, 121);
            this.txtr_dAuditDate.Name = "txtr_dAuditDate";
            this.txtr_dAuditDate.PreventEnterBeep = true;
            this.txtr_dAuditDate.ReadOnly = true;
            this.txtr_dAuditDate.Size = new System.Drawing.Size(145, 21);
            this.txtr_dAuditDate.TabIndex = 19;
            this.txtr_dAuditDate.Tag = "dAuditDate";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(671, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "审核日期：";
            // 
            // txtr_cAuditPsn
            // 
            this.txtr_cAuditPsn.BackColor = System.Drawing.Color.FloralWhite;
            // 
            // 
            // 
            this.txtr_cAuditPsn.Border.Class = "TextBoxBorder";
            this.txtr_cAuditPsn.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_cAuditPsn.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_cAuditPsn.ForeColor = System.Drawing.Color.Black;
            this.txtr_cAuditPsn.Location = new System.Drawing.Point(429, 121);
            this.txtr_cAuditPsn.Name = "txtr_cAuditPsn";
            this.txtr_cAuditPsn.PreventEnterBeep = true;
            this.txtr_cAuditPsn.ReadOnly = true;
            this.txtr_cAuditPsn.Size = new System.Drawing.Size(145, 21);
            this.txtr_cAuditPsn.TabIndex = 17;
            this.txtr_cAuditPsn.Tag = "cAuditPsn";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(367, 126);
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
            this.txtw_cMemo.Location = new System.Drawing.Point(129, 157);
            this.txtw_cMemo.Name = "txtw_cMemo";
            this.txtw_cMemo.PreventEnterBeep = true;
            this.txtw_cMemo.Size = new System.Drawing.Size(445, 21);
            this.txtw_cMemo.TabIndex = 13;
            this.txtw_cMemo.Tag = "cMemo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(79, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "备注：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(379, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "日期：";
            // 
            // txtr_modifier
            // 
            this.txtr_modifier.BackColor = System.Drawing.Color.FloralWhite;
            // 
            // 
            // 
            this.txtr_modifier.Border.Class = "TextBoxBorder";
            this.txtr_modifier.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_modifier.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_modifier.ForeColor = System.Drawing.Color.Black;
            this.txtr_modifier.Location = new System.Drawing.Point(129, 121);
            this.txtr_modifier.Name = "txtr_modifier";
            this.txtr_modifier.PreventEnterBeep = true;
            this.txtr_modifier.ReadOnly = true;
            this.txtr_modifier.Size = new System.Drawing.Size(145, 21);
            this.txtr_modifier.TabIndex = 5;
            this.txtr_modifier.Tag = "cModifier";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "修改：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(695, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "制单：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "单据号：";
            // 
            // txtr_maker
            // 
            this.txtr_maker.BackColor = System.Drawing.Color.FloralWhite;
            // 
            // 
            // 
            this.txtr_maker.Border.Class = "TextBoxBorder";
            this.txtr_maker.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_maker.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_maker.ForeColor = System.Drawing.Color.Black;
            this.txtr_maker.Location = new System.Drawing.Point(745, 89);
            this.txtr_maker.Name = "txtr_maker";
            this.txtr_maker.PreventEnterBeep = true;
            this.txtr_maker.ReadOnly = true;
            this.txtr_maker.Size = new System.Drawing.Size(145, 21);
            this.txtr_maker.TabIndex = 1;
            this.txtr_maker.Tag = "cMaker";
            // 
            // txtr_QmCode
            // 
            this.txtr_QmCode.BackColor = System.Drawing.Color.FloralWhite;
            // 
            // 
            // 
            this.txtr_QmCode.Border.Class = "TextBoxBorder";
            this.txtr_QmCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_QmCode.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_QmCode.ForeColor = System.Drawing.Color.Black;
            this.txtr_QmCode.Location = new System.Drawing.Point(129, 56);
            this.txtr_QmCode.Name = "txtr_QmCode";
            this.txtr_QmCode.PreventEnterBeep = true;
            this.txtr_QmCode.ReadOnly = true;
            this.txtr_QmCode.Size = new System.Drawing.Size(145, 21);
            this.txtr_QmCode.TabIndex = 0;
            this.txtr_QmCode.Tag = "MPCode";
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
            this.bar2.Location = new System.Drawing.Point(0, 222);
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
            // FmMaterialPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 580);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.bar2);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Name = "FmMaterialPlan";
            this.RenderFormIcon = false;
            this.RenderFormText = false;
            this.Text = "检验单";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cWhItemButtonEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cPositionButtonEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
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
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.ButtonItem BtnAddLine;
        private DevComponents.DotNetBar.ButtonItem BtnDelLine;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_maker;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_QmCode;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_modifier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtw_cMemo;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.ButtonItem BtnUnAudit;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_dAuditDate;
        private System.Windows.Forms.Label label10;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_cAuditPsn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtPicker;
        private DevComponents.DotNetBar.ButtonItem BtnPrint;
        private DevComponents.DotNetBar.ButtonItem BtnDesign;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit cWhItemButtonEdit;
        private DevComponents.DotNetBar.ButtonItem BtnMatch;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_cRdName;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_cDepName;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit cPositionButtonEdit;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_wareHouse;
        private System.Windows.Forms.Label label8;
    }
}