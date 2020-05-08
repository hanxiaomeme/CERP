namespace LanyunMES.UI
{
    partial class FmMaterialMerge
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
            this.GridCard = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.BtnEdit = new DevComponents.DotNetBar.ButtonItem();
            this.BtnSave = new DevComponents.DotNetBar.ButtonItem();
            this.BtnAudit = new DevComponents.DotNetBar.ButtonItem();
            this.pnlMain = new DevComponents.DotNetBar.PanelEx();
            this.dtPicker = new System.Windows.Forms.DateTimePicker();
            this.txt_iQuantity = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label7 = new System.Windows.Forms.Label();
            this.txtr_cInvStd = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label6 = new System.Windows.Forms.Label();
            this.txtr_cInvName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.txtr_cInvCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label4 = new System.Windows.Forms.Label();
            this.txtr_cMaker = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtr_Code = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.lbl_title = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 232);
            this.gridControl1.MainView = this.GridCard;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(957, 224);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridCard});
            // 
            // GridCard
            // 
            this.GridCard.GridControl = this.gridControl1;
            this.GridCard.Name = "GridCard";
            this.GridCard.OptionsView.ShowGroupPanel = false;
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.BtnEdit,
            this.BtnSave,
            this.BtnAudit});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(957, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 1;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // BtnEdit
            // 
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Text = "编辑(&E)";
            // 
            // BtnSave
            // 
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Text = "保存(&S)";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnAudit
            // 
            this.BtnAudit.Name = "BtnAudit";
            this.BtnAudit.Text = "审核(&Y)";
            this.BtnAudit.Click += new System.EventHandler(this.BtnAudit_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlMain.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlMain.Controls.Add(this.dtPicker);
            this.pnlMain.Controls.Add(this.txt_iQuantity);
            this.pnlMain.Controls.Add(this.label7);
            this.pnlMain.Controls.Add(this.txtr_cInvStd);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.txtr_cInvName);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.txtr_cInvCode);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.txtr_cMaker);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.txtr_Code);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMain.Location = new System.Drawing.Point(0, 62);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(957, 143);
            this.pnlMain.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlMain.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlMain.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlMain.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlMain.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlMain.Style.GradientAngle = 90;
            this.pnlMain.TabIndex = 2;
            // 
            // dtPicker
            // 
            this.dtPicker.CustomFormat = "yyyy-MM-dd";
            this.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPicker.Location = new System.Drawing.Point(408, 21);
            this.dtPicker.Name = "dtPicker";
            this.dtPicker.Size = new System.Drawing.Size(140, 22);
            this.dtPicker.TabIndex = 14;
            this.dtPicker.Tag = "dDate";
            this.dtPicker.Value = new System.DateTime(2019, 1, 1, 20, 30, 0, 0);
            // 
            // txt_iQuantity
            // 
            this.txt_iQuantity.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_iQuantity.Border.Class = "TextBoxBorder";
            this.txt_iQuantity.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_iQuantity.DisabledBackColor = System.Drawing.Color.White;
            this.txt_iQuantity.ForeColor = System.Drawing.Color.Black;
            this.txt_iQuantity.Location = new System.Drawing.Point(135, 100);
            this.txt_iQuantity.Name = "txt_iQuantity";
            this.txt_iQuantity.PreventEnterBeep = true;
            this.txt_iQuantity.Size = new System.Drawing.Size(140, 22);
            this.txt_iQuantity.TabIndex = 13;
            this.txt_iQuantity.Tag = "iQuantity";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(85, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "数量";
            // 
            // txtr_cInvStd
            // 
            this.txtr_cInvStd.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtr_cInvStd.Border.Class = "TextBoxBorder";
            this.txtr_cInvStd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_cInvStd.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_cInvStd.ForeColor = System.Drawing.Color.Black;
            this.txtr_cInvStd.Location = new System.Drawing.Point(680, 61);
            this.txtr_cInvStd.Name = "txtr_cInvStd";
            this.txtr_cInvStd.PreventEnterBeep = true;
            this.txtr_cInvStd.Size = new System.Drawing.Size(140, 22);
            this.txtr_cInvStd.TabIndex = 11;
            this.txtr_cInvStd.Tag = "cInvStd";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(346, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "制单人";
            // 
            // txtr_cInvName
            // 
            this.txtr_cInvName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtr_cInvName.Border.Class = "TextBoxBorder";
            this.txtr_cInvName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_cInvName.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_cInvName.ForeColor = System.Drawing.Color.Black;
            this.txtr_cInvName.Location = new System.Drawing.Point(408, 61);
            this.txtr_cInvName.Name = "txtr_cInvName";
            this.txtr_cInvName.PreventEnterBeep = true;
            this.txtr_cInvName.Size = new System.Drawing.Size(140, 22);
            this.txtr_cInvName.TabIndex = 9;
            this.txtr_cInvName.Tag = "cInvName";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(358, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "日期";
            // 
            // txtr_cInvCode
            // 
            this.txtr_cInvCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtr_cInvCode.Border.Class = "TextBoxBorder";
            this.txtr_cInvCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_cInvCode.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_cInvCode.ForeColor = System.Drawing.Color.Black;
            this.txtr_cInvCode.Location = new System.Drawing.Point(135, 61);
            this.txtr_cInvCode.Name = "txtr_cInvCode";
            this.txtr_cInvCode.PreventEnterBeep = true;
            this.txtr_cInvCode.Size = new System.Drawing.Size(140, 22);
            this.txtr_cInvCode.TabIndex = 7;
            this.txtr_cInvCode.Tag = "cInvCode";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(606, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "规格型号";
            // 
            // txtr_cMaker
            // 
            this.txtr_cMaker.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtr_cMaker.Border.Class = "TextBoxBorder";
            this.txtr_cMaker.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_cMaker.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_cMaker.ForeColor = System.Drawing.Color.Black;
            this.txtr_cMaker.Location = new System.Drawing.Point(408, 100);
            this.txtr_cMaker.Name = "txtr_cMaker";
            this.txtr_cMaker.PreventEnterBeep = true;
            this.txtr_cMaker.Size = new System.Drawing.Size(140, 22);
            this.txtr_cMaker.TabIndex = 5;
            this.txtr_cMaker.Tag = "cMaker";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(334, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "原料名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "原料编码";
            // 
            // txtr_Code
            // 
            this.txtr_Code.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtr_Code.Border.Class = "TextBoxBorder";
            this.txtr_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_Code.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_Code.ForeColor = System.Drawing.Color.Black;
            this.txtr_Code.Location = new System.Drawing.Point(135, 21);
            this.txtr_Code.Name = "txtr_Code";
            this.txtr_Code.PreventEnterBeep = true;
            this.txtr_Code.Size = new System.Drawing.Size(140, 22);
            this.txtr_Code.TabIndex = 1;
            this.txtr_Code.Tag = "MCCode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "单据号";
            // 
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar2.IsMaximized = false;
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem2});
            this.bar2.Location = new System.Drawing.Point(0, 205);
            this.bar2.Name = "bar2";
            this.bar2.Size = new System.Drawing.Size(957, 27);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 6;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
            // 
            // buttonItem2
            // 
            this.buttonItem2.ForeColor = System.Drawing.Color.Black;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Text = "删行";
            // 
            // lbl_title
            // 
            this.lbl_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_title.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_title.Location = new System.Drawing.Point(0, 27);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(957, 35);
            this.lbl_title.TabIndex = 1;
            this.lbl_title.Text = "原材料需求合并单";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FmMaterialMegra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 456);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.bar2);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FmMaterialMegra";
            this.ShowIcon = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView GridCard;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.PanelEx pnlMain;
        private DevComponents.DotNetBar.ButtonItem BtnEdit;
        private DevComponents.DotNetBar.ButtonItem BtnSave;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_iQuantity;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_cInvStd;
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_cInvName;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_cInvCode;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_cMaker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_Code;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private System.Windows.Forms.DateTimePicker dtPicker;
        private System.Windows.Forms.Label lbl_title;
        private DevComponents.DotNetBar.ButtonItem BtnAudit;
    }
}