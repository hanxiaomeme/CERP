namespace MES
{
    partial class FmInvDetail
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
            this.TabCtrl = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.gpHead = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txt_Toubiao = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label14 = new System.Windows.Forms.Label();
            this.txtr_InvCName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.txtw_InvStd = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lbl_InvStd = new System.Windows.Forms.Label();
            this.txtw_InvName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lbl_InvName = new System.Windows.Forms.Label();
            this.txtw_InvCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lbl_InvCode = new System.Windows.Forms.Label();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btn_Save = new DevComponents.DotNetBar.ButtonItem();
            this.btn_Edit = new DevComponents.DotNetBar.ButtonItem();
            this.gpBody = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtw_CDCS = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lbl_CDCS = new System.Windows.Forms.Label();
            this.txtw_BWCS = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label13 = new System.Windows.Forms.Label();
            this.txtw_DDCS = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label12 = new System.Windows.Forms.Label();
            this.txtw_CGCD_2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label10 = new System.Windows.Forms.Label();
            this.txtw_CGCD_1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label11 = new System.Windows.Forms.Label();
            this.txtw_CGZJ_2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label8 = new System.Windows.Forms.Label();
            this.txtw_CGZJ_1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label9 = new System.Windows.Forms.Label();
            this.txtw_Chishu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label6 = new System.Windows.Forms.Label();
            this.txtw_Yachang = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label7 = new System.Windows.Forms.Label();
            this.txtw_Houdu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label4 = new System.Windows.Forms.Label();
            this.txtw_FLZJ = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.txtw_Luoju = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.txtw_LJDB = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.tab_Main = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.listBoxAdv1 = new DevComponents.DotNetBar.ListBoxAdv();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.btn_Upload = new DevComponents.DotNetBar.ButtonItem();
            this.btn_Download = new DevComponents.DotNetBar.ButtonItem();
            this.btn_PdfPreview = new DevComponents.DotNetBar.ButtonItem();
            this.btn_DelFile = new DevComponents.DotNetBar.ButtonItem();
            this.tab_files = new DevComponents.DotNetBar.SuperTabItem();
            ((System.ComponentModel.ISupportInitialize)(this.TabCtrl)).BeginInit();
            this.TabCtrl.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.gpHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.gpBody.SuspendLayout();
            this.superTabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.SuspendLayout();
            // 
            // TabCtrl
            // 
            this.TabCtrl.BackColor = System.Drawing.Color.White;
            this.TabCtrl.CloseButtonOnTabsAlwaysDisplayed = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.TabCtrl.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.TabCtrl.ControlBox.MenuBox.Name = "";
            this.TabCtrl.ControlBox.Name = "";
            this.TabCtrl.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.TabCtrl.ControlBox.MenuBox,
            this.TabCtrl.ControlBox.CloseBox});
            this.TabCtrl.Controls.Add(this.superTabControlPanel1);
            this.TabCtrl.Controls.Add(this.superTabControlPanel2);
            this.TabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabCtrl.ForeColor = System.Drawing.Color.Black;
            this.TabCtrl.Location = new System.Drawing.Point(0, 0);
            this.TabCtrl.Name = "TabCtrl";
            this.TabCtrl.ReorderTabsEnabled = true;
            this.TabCtrl.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.TabCtrl.SelectedTabIndex = 0;
            this.TabCtrl.Size = new System.Drawing.Size(521, 471);
            this.TabCtrl.TabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TabCtrl.TabIndex = 0;
            this.TabCtrl.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tab_Main,
            this.tab_files});
            this.TabCtrl.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.VisualStudio2008Dock;
            this.TabCtrl.Text = "superTabControl1";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.gpHead);
            this.superTabControlPanel1.Controls.Add(this.bar1);
            this.superTabControlPanel1.Controls.Add(this.gpBody);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 28);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Padding = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.superTabControlPanel1.Size = new System.Drawing.Size(521, 443);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.tab_Main;
            // 
            // gpHead
            // 
            this.gpHead.BackColor = System.Drawing.Color.White;
            this.gpHead.CanvasColor = System.Drawing.SystemColors.Control;
            this.gpHead.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gpHead.Controls.Add(this.txt_Toubiao);
            this.gpHead.Controls.Add(this.label14);
            this.gpHead.Controls.Add(this.txtr_InvCName);
            this.gpHead.Controls.Add(this.label1);
            this.gpHead.Controls.Add(this.txtw_InvStd);
            this.gpHead.Controls.Add(this.lbl_InvStd);
            this.gpHead.Controls.Add(this.txtw_InvName);
            this.gpHead.Controls.Add(this.lbl_InvName);
            this.gpHead.Controls.Add(this.txtw_InvCode);
            this.gpHead.Controls.Add(this.lbl_InvCode);
            this.gpHead.DisabledBackColor = System.Drawing.Color.Empty;
            this.gpHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpHead.Location = new System.Drawing.Point(10, 32);
            this.gpHead.Name = "gpHead";
            this.gpHead.Size = new System.Drawing.Size(501, 125);
            // 
            // 
            // 
            this.gpHead.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.gpHead.Style.BackColorGradientAngle = 90;
            this.gpHead.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.gpHead.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpHead.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.gpHead.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpHead.Style.BorderLeftWidth = 1;
            this.gpHead.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpHead.Style.BorderRightWidth = 1;
            this.gpHead.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpHead.Style.BorderTopWidth = 1;
            this.gpHead.Style.CornerDiameter = 4;
            this.gpHead.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.gpHead.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.gpHead.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.gpHead.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.gpHead.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.gpHead.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.gpHead.TabIndex = 22;
            // 
            // txt_Toubiao
            // 
            this.txt_Toubiao.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_Toubiao.Border.Class = "TextBoxBorder";
            this.txt_Toubiao.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_Toubiao.DisabledBackColor = System.Drawing.Color.White;
            this.txt_Toubiao.ForeColor = System.Drawing.Color.Black;
            this.txt_Toubiao.Location = new System.Drawing.Point(332, 75);
            this.txt_Toubiao.Name = "txt_Toubiao";
            this.txt_Toubiao.PreventEnterBeep = true;
            this.txt_Toubiao.Size = new System.Drawing.Size(150, 21);
            this.txt_Toubiao.TabIndex = 33;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.Window;
            this.label14.Location = new System.Drawing.Point(270, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 32;
            this.label14.Text = "头    标";
            // 
            // txtr_InvCName
            // 
            this.txtr_InvCName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtr_InvCName.Border.Class = "TextBoxBorder";
            this.txtr_InvCName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_InvCName.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_InvCName.ForeColor = System.Drawing.Color.Black;
            this.txtr_InvCName.Location = new System.Drawing.Point(72, 22);
            this.txtr_InvCName.Name = "txtr_InvCName";
            this.txtr_InvCName.PreventEnterBeep = true;
            this.txtr_InvCName.Size = new System.Drawing.Size(170, 21);
            this.txtr_InvCName.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(10, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 30;
            this.label1.Text = "图纸分类";
            // 
            // txtw_InvStd
            // 
            this.txtw_InvStd.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtw_InvStd.Border.Class = "TextBoxBorder";
            this.txtw_InvStd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtw_InvStd.DisabledBackColor = System.Drawing.Color.White;
            this.txtw_InvStd.ForeColor = System.Drawing.Color.Black;
            this.txtw_InvStd.Location = new System.Drawing.Point(72, 76);
            this.txtw_InvStd.Name = "txtw_InvStd";
            this.txtw_InvStd.PreventEnterBeep = true;
            this.txtw_InvStd.Size = new System.Drawing.Size(170, 21);
            this.txtw_InvStd.TabIndex = 29;
            // 
            // lbl_InvStd
            // 
            this.lbl_InvStd.AutoSize = true;
            this.lbl_InvStd.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_InvStd.Location = new System.Drawing.Point(10, 81);
            this.lbl_InvStd.Name = "lbl_InvStd";
            this.lbl_InvStd.Size = new System.Drawing.Size(53, 12);
            this.lbl_InvStd.TabIndex = 28;
            this.lbl_InvStd.Text = "规格型号";
            // 
            // txtw_InvName
            // 
            this.txtw_InvName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtw_InvName.Border.Class = "TextBoxBorder";
            this.txtw_InvName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtw_InvName.DisabledBackColor = System.Drawing.Color.White;
            this.txtw_InvName.ForeColor = System.Drawing.Color.Black;
            this.txtw_InvName.Location = new System.Drawing.Point(72, 49);
            this.txtw_InvName.Name = "txtw_InvName";
            this.txtw_InvName.PreventEnterBeep = true;
            this.txtw_InvName.Size = new System.Drawing.Size(170, 21);
            this.txtw_InvName.TabIndex = 27;
            // 
            // lbl_InvName
            // 
            this.lbl_InvName.AutoSize = true;
            this.lbl_InvName.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_InvName.Location = new System.Drawing.Point(10, 53);
            this.lbl_InvName.Name = "lbl_InvName";
            this.lbl_InvName.Size = new System.Drawing.Size(53, 12);
            this.lbl_InvName.TabIndex = 26;
            this.lbl_InvName.Text = "图纸名称";
            // 
            // txtw_InvCode
            // 
            this.txtw_InvCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtw_InvCode.Border.Class = "TextBoxBorder";
            this.txtw_InvCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtw_InvCode.DisabledBackColor = System.Drawing.Color.White;
            this.txtw_InvCode.ForeColor = System.Drawing.Color.Black;
            this.txtw_InvCode.Location = new System.Drawing.Point(332, 22);
            this.txtw_InvCode.Name = "txtw_InvCode";
            this.txtw_InvCode.PreventEnterBeep = true;
            this.txtw_InvCode.Size = new System.Drawing.Size(150, 21);
            this.txtw_InvCode.TabIndex = 25;
            this.txtw_InvCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CodeBox_KeyPress);
            // 
            // lbl_InvCode
            // 
            this.lbl_InvCode.AutoSize = true;
            this.lbl_InvCode.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_InvCode.Location = new System.Drawing.Point(270, 27);
            this.lbl_InvCode.Name = "lbl_InvCode";
            this.lbl_InvCode.Size = new System.Drawing.Size(53, 12);
            this.lbl_InvCode.TabIndex = 24;
            this.lbl_InvCode.Text = "零 件 号";
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_Save,
            this.btn_Edit});
            this.bar1.Location = new System.Drawing.Point(10, 5);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(501, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 21;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btn_Save
            // 
            this.btn_Save.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Text = "保 存";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Edit
            // 
            this.btn_Edit.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Text = "修 改";
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // gpBody
            // 
            this.gpBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gpBody.CanvasColor = System.Drawing.SystemColors.Control;
            this.gpBody.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.gpBody.Controls.Add(this.txtw_CDCS);
            this.gpBody.Controls.Add(this.lbl_CDCS);
            this.gpBody.Controls.Add(this.txtw_BWCS);
            this.gpBody.Controls.Add(this.label13);
            this.gpBody.Controls.Add(this.txtw_DDCS);
            this.gpBody.Controls.Add(this.label12);
            this.gpBody.Controls.Add(this.txtw_CGCD_2);
            this.gpBody.Controls.Add(this.label10);
            this.gpBody.Controls.Add(this.txtw_CGCD_1);
            this.gpBody.Controls.Add(this.label11);
            this.gpBody.Controls.Add(this.txtw_CGZJ_2);
            this.gpBody.Controls.Add(this.label8);
            this.gpBody.Controls.Add(this.txtw_CGZJ_1);
            this.gpBody.Controls.Add(this.label9);
            this.gpBody.Controls.Add(this.txtw_Chishu);
            this.gpBody.Controls.Add(this.label6);
            this.gpBody.Controls.Add(this.txtw_Yachang);
            this.gpBody.Controls.Add(this.label7);
            this.gpBody.Controls.Add(this.txtw_Houdu);
            this.gpBody.Controls.Add(this.label4);
            this.gpBody.Controls.Add(this.txtw_FLZJ);
            this.gpBody.Controls.Add(this.label5);
            this.gpBody.Controls.Add(this.txtw_Luoju);
            this.gpBody.Controls.Add(this.label3);
            this.gpBody.Controls.Add(this.txtw_LJDB);
            this.gpBody.Controls.Add(this.label2);
            this.gpBody.DisabledBackColor = System.Drawing.Color.Empty;
            this.gpBody.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gpBody.Location = new System.Drawing.Point(10, 157);
            this.gpBody.Name = "gpBody";
            this.gpBody.Size = new System.Drawing.Size(501, 276);
            // 
            // 
            // 
            this.gpBody.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.gpBody.Style.BackColorGradientAngle = 90;
            this.gpBody.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.gpBody.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpBody.Style.BorderBottomWidth = 1;
            this.gpBody.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.gpBody.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpBody.Style.BorderLeftWidth = 1;
            this.gpBody.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpBody.Style.BorderRightWidth = 1;
            this.gpBody.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpBody.Style.BorderTopWidth = 1;
            this.gpBody.Style.CornerDiameter = 4;
            this.gpBody.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.gpBody.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.gpBody.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.gpBody.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.gpBody.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.gpBody.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.gpBody.TabIndex = 12;
            // 
            // txtw_CDCS
            // 
            this.txtw_CDCS.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtw_CDCS.Border.Class = "TextBoxBorder";
            this.txtw_CDCS.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtw_CDCS.DisabledBackColor = System.Drawing.Color.White;
            this.txtw_CDCS.ForeColor = System.Drawing.Color.Black;
            this.txtw_CDCS.Location = new System.Drawing.Point(72, 228);
            this.txtw_CDCS.Name = "txtw_CDCS";
            this.txtw_CDCS.PreventEnterBeep = true;
            this.txtw_CDCS.Size = new System.Drawing.Size(412, 21);
            this.txtw_CDCS.TabIndex = 33;
            // 
            // lbl_CDCS
            // 
            this.lbl_CDCS.AutoSize = true;
            this.lbl_CDCS.Location = new System.Drawing.Point(10, 233);
            this.lbl_CDCS.Name = "lbl_CDCS";
            this.lbl_CDCS.Size = new System.Drawing.Size(53, 12);
            this.lbl_CDCS.TabIndex = 32;
            this.lbl_CDCS.Text = "长端参数";
            // 
            // txtw_BWCS
            // 
            this.txtw_BWCS.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtw_BWCS.Border.Class = "TextBoxBorder";
            this.txtw_BWCS.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtw_BWCS.DisabledBackColor = System.Drawing.Color.White;
            this.txtw_BWCS.ForeColor = System.Drawing.Color.Black;
            this.txtw_BWCS.Location = new System.Drawing.Point(72, 201);
            this.txtw_BWCS.Name = "txtw_BWCS";
            this.txtw_BWCS.PreventEnterBeep = true;
            this.txtw_BWCS.Size = new System.Drawing.Size(412, 21);
            this.txtw_BWCS.TabIndex = 31;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 206);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 30;
            this.label13.Text = "扁位参数";
            // 
            // txtw_DDCS
            // 
            this.txtw_DDCS.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtw_DDCS.Border.Class = "TextBoxBorder";
            this.txtw_DDCS.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtw_DDCS.DisabledBackColor = System.Drawing.Color.White;
            this.txtw_DDCS.ForeColor = System.Drawing.Color.Black;
            this.txtw_DDCS.Location = new System.Drawing.Point(72, 174);
            this.txtw_DDCS.Name = "txtw_DDCS";
            this.txtw_DDCS.PreventEnterBeep = true;
            this.txtw_DDCS.Size = new System.Drawing.Size(412, 21);
            this.txtw_DDCS.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 179);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 28;
            this.label12.Text = "短端参数";
            // 
            // txtw_CGCD_2
            // 
            this.txtw_CGCD_2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtw_CGCD_2.Border.Class = "TextBoxBorder";
            this.txtw_CGCD_2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtw_CGCD_2.DisabledBackColor = System.Drawing.Color.White;
            this.txtw_CGCD_2.ForeColor = System.Drawing.Color.Black;
            this.txtw_CGCD_2.Location = new System.Drawing.Point(332, 128);
            this.txtw_CGCD_2.Name = "txtw_CGCD_2";
            this.txtw_CGCD_2.PreventEnterBeep = true;
            this.txtw_CGCD_2.Size = new System.Drawing.Size(150, 21);
            this.txtw_CGCD_2.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(270, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 26;
            this.label10.Text = "粗杆长度2";
            // 
            // txtw_CGCD_1
            // 
            this.txtw_CGCD_1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtw_CGCD_1.Border.Class = "TextBoxBorder";
            this.txtw_CGCD_1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtw_CGCD_1.DisabledBackColor = System.Drawing.Color.White;
            this.txtw_CGCD_1.ForeColor = System.Drawing.Color.Black;
            this.txtw_CGCD_1.Location = new System.Drawing.Point(72, 128);
            this.txtw_CGCD_1.Name = "txtw_CGCD_1";
            this.txtw_CGCD_1.PreventEnterBeep = true;
            this.txtw_CGCD_1.Size = new System.Drawing.Size(150, 21);
            this.txtw_CGCD_1.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 133);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 24;
            this.label11.Text = "粗杆长度1";
            // 
            // txtw_CGZJ_2
            // 
            this.txtw_CGZJ_2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtw_CGZJ_2.Border.Class = "TextBoxBorder";
            this.txtw_CGZJ_2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtw_CGZJ_2.DisabledBackColor = System.Drawing.Color.White;
            this.txtw_CGZJ_2.ForeColor = System.Drawing.Color.Black;
            this.txtw_CGZJ_2.Location = new System.Drawing.Point(332, 101);
            this.txtw_CGZJ_2.Name = "txtw_CGZJ_2";
            this.txtw_CGZJ_2.PreventEnterBeep = true;
            this.txtw_CGZJ_2.Size = new System.Drawing.Size(150, 21);
            this.txtw_CGZJ_2.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(270, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 22;
            this.label8.Text = "粗杆直径2";
            // 
            // txtw_CGZJ_1
            // 
            this.txtw_CGZJ_1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtw_CGZJ_1.Border.Class = "TextBoxBorder";
            this.txtw_CGZJ_1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtw_CGZJ_1.DisabledBackColor = System.Drawing.Color.White;
            this.txtw_CGZJ_1.ForeColor = System.Drawing.Color.Black;
            this.txtw_CGZJ_1.Location = new System.Drawing.Point(72, 101);
            this.txtw_CGZJ_1.Name = "txtw_CGZJ_1";
            this.txtw_CGZJ_1.PreventEnterBeep = true;
            this.txtw_CGZJ_1.Size = new System.Drawing.Size(150, 21);
            this.txtw_CGZJ_1.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "粗杆直径1";
            // 
            // txtw_Chishu
            // 
            this.txtw_Chishu.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtw_Chishu.Border.Class = "TextBoxBorder";
            this.txtw_Chishu.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtw_Chishu.DisabledBackColor = System.Drawing.Color.White;
            this.txtw_Chishu.ForeColor = System.Drawing.Color.Black;
            this.txtw_Chishu.Location = new System.Drawing.Point(332, 73);
            this.txtw_Chishu.Name = "txtw_Chishu";
            this.txtw_Chishu.PreventEnterBeep = true;
            this.txtw_Chishu.Size = new System.Drawing.Size(150, 21);
            this.txtw_Chishu.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(270, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "齿    数";
            // 
            // txtw_Yachang
            // 
            this.txtw_Yachang.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtw_Yachang.Border.Class = "TextBoxBorder";
            this.txtw_Yachang.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtw_Yachang.DisabledBackColor = System.Drawing.Color.White;
            this.txtw_Yachang.ForeColor = System.Drawing.Color.Black;
            this.txtw_Yachang.Location = new System.Drawing.Point(72, 73);
            this.txtw_Yachang.Name = "txtw_Yachang";
            this.txtw_Yachang.PreventEnterBeep = true;
            this.txtw_Yachang.Size = new System.Drawing.Size(150, 21);
            this.txtw_Yachang.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "牙    长";
            // 
            // txtw_Houdu
            // 
            this.txtw_Houdu.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtw_Houdu.Border.Class = "TextBoxBorder";
            this.txtw_Houdu.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtw_Houdu.DisabledBackColor = System.Drawing.Color.White;
            this.txtw_Houdu.ForeColor = System.Drawing.Color.Black;
            this.txtw_Houdu.Location = new System.Drawing.Point(332, 46);
            this.txtw_Houdu.Name = "txtw_Houdu";
            this.txtw_Houdu.PreventEnterBeep = true;
            this.txtw_Houdu.Size = new System.Drawing.Size(150, 21);
            this.txtw_Houdu.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "厚    度";
            // 
            // txtw_FLZJ
            // 
            this.txtw_FLZJ.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtw_FLZJ.Border.Class = "TextBoxBorder";
            this.txtw_FLZJ.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtw_FLZJ.DisabledBackColor = System.Drawing.Color.White;
            this.txtw_FLZJ.ForeColor = System.Drawing.Color.Black;
            this.txtw_FLZJ.Location = new System.Drawing.Point(72, 46);
            this.txtw_FLZJ.Name = "txtw_FLZJ";
            this.txtw_FLZJ.PreventEnterBeep = true;
            this.txtw_FLZJ.Size = new System.Drawing.Size(150, 21);
            this.txtw_FLZJ.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "法兰直径";
            // 
            // txtw_Luoju
            // 
            this.txtw_Luoju.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtw_Luoju.Border.Class = "TextBoxBorder";
            this.txtw_Luoju.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtw_Luoju.DisabledBackColor = System.Drawing.Color.White;
            this.txtw_Luoju.ForeColor = System.Drawing.Color.Black;
            this.txtw_Luoju.Location = new System.Drawing.Point(332, 18);
            this.txtw_Luoju.Name = "txtw_Luoju";
            this.txtw_Luoju.PreventEnterBeep = true;
            this.txtw_Luoju.Size = new System.Drawing.Size(150, 21);
            this.txtw_Luoju.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(270, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "螺    距";
            // 
            // txtw_LJDB
            // 
            this.txtw_LJDB.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtw_LJDB.Border.Class = "TextBoxBorder";
            this.txtw_LJDB.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtw_LJDB.DisabledBackColor = System.Drawing.Color.White;
            this.txtw_LJDB.ForeColor = System.Drawing.Color.Black;
            this.txtw_LJDB.Location = new System.Drawing.Point(72, 18);
            this.txtw_LJDB.Name = "txtw_LJDB";
            this.txtw_LJDB.PreventEnterBeep = true;
            this.txtw_LJDB.Size = new System.Drawing.Size(150, 21);
            this.txtw_LJDB.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "六角对边";
            // 
            // tab_Main
            // 
            this.tab_Main.AttachedControl = this.superTabControlPanel1;
            this.tab_Main.GlobalItem = false;
            this.tab_Main.Name = "tab_Main";
            this.tab_Main.Text = "图纸档案";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.listBoxAdv1);
            this.superTabControlPanel2.Controls.Add(this.bar2);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 28);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Padding = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.superTabControlPanel2.Size = new System.Drawing.Size(521, 443);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.tab_files;
            // 
            // listBoxAdv1
            // 
            this.listBoxAdv1.AutoScroll = true;
            // 
            // 
            // 
            this.listBoxAdv1.BackgroundStyle.Class = "ListBoxAdv";
            this.listBoxAdv1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listBoxAdv1.CheckStateMember = null;
            this.listBoxAdv1.ContainerControlProcessDialogKey = true;
            this.listBoxAdv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxAdv1.DragDropSupport = true;
            this.listBoxAdv1.Location = new System.Drawing.Point(10, 32);
            this.listBoxAdv1.Name = "listBoxAdv1";
            this.listBoxAdv1.Size = new System.Drawing.Size(501, 401);
            this.listBoxAdv1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.listBoxAdv1.TabIndex = 23;
            this.listBoxAdv1.Text = "listBoxAdv1";
            // 
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar2.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.bar2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar2.IsMaximized = false;
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_Upload,
            this.btn_Download,
            this.btn_PdfPreview,
            this.btn_DelFile});
            this.bar2.Location = new System.Drawing.Point(10, 5);
            this.bar2.Name = "bar2";
            this.bar2.Size = new System.Drawing.Size(501, 27);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 22;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
            // 
            // btn_Upload
            // 
            this.btn_Upload.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btn_Upload.Name = "btn_Upload";
            this.btn_Upload.Text = "上 传";
            this.btn_Upload.Click += new System.EventHandler(this.btn_Upload_Click);
            // 
            // btn_Download
            // 
            this.btn_Download.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btn_Download.Name = "btn_Download";
            this.btn_Download.Text = "下 载";
            this.btn_Download.Click += new System.EventHandler(this.btn_Download_Click);
            // 
            // btn_PdfPreview
            // 
            this.btn_PdfPreview.BeginGroup = true;
            this.btn_PdfPreview.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btn_PdfPreview.Name = "btn_PdfPreview";
            this.btn_PdfPreview.Text = "预 览";
            this.btn_PdfPreview.Click += new System.EventHandler(this.btn_PdfPreview_Click);
            // 
            // btn_DelFile
            // 
            this.btn_DelFile.BeginGroup = true;
            this.btn_DelFile.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btn_DelFile.Name = "btn_DelFile";
            this.btn_DelFile.Text = "删 行";
            this.btn_DelFile.Click += new System.EventHandler(this.btn_DelFile_Click);
            // 
            // tab_files
            // 
            this.tab_files.AttachedControl = this.superTabControlPanel2;
            this.tab_files.GlobalItem = false;
            this.tab_files.Name = "tab_files";
            this.tab_files.Text = "图纸文档";
            // 
            // FmInvDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 471);
            this.Controls.Add(this.TabCtrl);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FmInvDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图纸档案";
            this.Load += new System.EventHandler(this.FmInvDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TabCtrl)).EndInit();
            this.TabCtrl.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.gpHead.ResumeLayout(false);
            this.gpHead.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.gpBody.ResumeLayout(false);
            this.gpBody.PerformLayout();
            this.superTabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperTabControl TabCtrl;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem tab_Main;
        private DevComponents.DotNetBar.Controls.GroupPanel gpBody;
        private DevComponents.DotNetBar.Controls.TextBoxX txtw_CDCS;
        private System.Windows.Forms.Label lbl_CDCS;
        private DevComponents.DotNetBar.Controls.TextBoxX txtw_BWCS;
        private System.Windows.Forms.Label label13;
        private DevComponents.DotNetBar.Controls.TextBoxX txtw_DDCS;
        private System.Windows.Forms.Label label12;
        private DevComponents.DotNetBar.Controls.TextBoxX txtw_CGCD_2;
        private System.Windows.Forms.Label label10;
        private DevComponents.DotNetBar.Controls.TextBoxX txtw_CGCD_1;
        private System.Windows.Forms.Label label11;
        private DevComponents.DotNetBar.Controls.TextBoxX txtw_CGZJ_2;
        private System.Windows.Forms.Label label8;
        private DevComponents.DotNetBar.Controls.TextBoxX txtw_CGZJ_1;
        private System.Windows.Forms.Label label9;
        private DevComponents.DotNetBar.Controls.TextBoxX txtw_Chishu;
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.Controls.TextBoxX txtw_Yachang;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.Controls.TextBoxX txtw_Houdu;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtw_FLZJ;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.Controls.TextBoxX txtw_Luoju;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtw_LJDB;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btn_Save;
        private DevComponents.DotNetBar.ButtonItem btn_Edit;
        private DevComponents.DotNetBar.Controls.GroupPanel gpHead;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_Toubiao;
        private System.Windows.Forms.Label label14;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_InvCName;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtw_InvStd;
        private System.Windows.Forms.Label lbl_InvStd;
        private DevComponents.DotNetBar.Controls.TextBoxX txtw_InvName;
        private System.Windows.Forms.Label lbl_InvName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtw_InvCode;
        private System.Windows.Forms.Label lbl_InvCode;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.ButtonItem btn_Upload;
        private DevComponents.DotNetBar.ButtonItem btn_DelFile;
        private DevComponents.DotNetBar.SuperTabItem tab_files;
        private DevComponents.DotNetBar.ListBoxAdv listBoxAdv1;
        private DevComponents.DotNetBar.ButtonItem btn_Download;
        private DevComponents.DotNetBar.ButtonItem btn_PdfPreview;
    }
}