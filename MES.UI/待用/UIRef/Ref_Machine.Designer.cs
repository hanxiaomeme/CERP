namespace MES.UI
{
    partial class Ref_Machine
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ref_Machine));
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.BtnOK = new DevComponents.DotNetBar.ButtonItem();
            this.BtnCancel = new DevComponents.DotNetBar.ButtonItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnlHead = new DevComponents.DotNetBar.PanelEx();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cMacCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cMacName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cMacStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cMacVend = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WcCode = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.BtnOK,
            this.BtnCancel});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(484, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // BtnOK
            // 
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Text = "确定";
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Text = "取消";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "play_blue.png");
            // 
            // pnlHead
            // 
            this.pnlHead.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlHead.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlHead.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHead.Location = new System.Drawing.Point(0, 27);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Size = new System.Drawing.Size(484, 80);
            this.pnlHead.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlHead.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlHead.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlHead.Style.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlHead.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlHead.Style.GradientAngle = 90;
            this.pnlHead.Style.LineAlignment = System.Drawing.StringAlignment.Near;
            this.pnlHead.Style.MarginTop = 5;
            this.pnlHead.TabIndex = 5;
            this.pnlHead.Text = "机台设备档案";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 107);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(484, 355);
            this.gridControl1.TabIndex = 9;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.cMacCode,
            this.cMacName,
            this.cMacStd,
            this.cMacVend,
            this.WcCode});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // cMacCode
            // 
            this.cMacCode.Caption = "设备编码";
            this.cMacCode.FieldName = "cMacCode";
            this.cMacCode.Name = "cMacCode";
            this.cMacCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "cInvCode", "记录数：{0}")});
            this.cMacCode.Visible = true;
            this.cMacCode.VisibleIndex = 0;
            this.cMacCode.Width = 100;
            // 
            // cMacName
            // 
            this.cMacName.Caption = "机台名称";
            this.cMacName.FieldName = "cMacName";
            this.cMacName.Name = "cMacName";
            this.cMacName.Visible = true;
            this.cMacName.VisibleIndex = 1;
            this.cMacName.Width = 98;
            // 
            // cMacStd
            // 
            this.cMacStd.Caption = "机台规格";
            this.cMacStd.FieldName = "cMacStd";
            this.cMacStd.Name = "cMacStd";
            this.cMacStd.Visible = true;
            this.cMacStd.VisibleIndex = 2;
            this.cMacStd.Width = 92;
            // 
            // cMacVend
            // 
            this.cMacVend.Caption = "所属部门";
            this.cMacVend.FieldName = "cMacVend";
            this.cMacVend.Name = "cMacVend";
            this.cMacVend.Visible = true;
            this.cMacVend.VisibleIndex = 3;
            this.cMacVend.Width = 85;
            // 
            // WcCode
            // 
            this.WcCode.Caption = "工作中心编码";
            this.WcCode.FieldName = "WcCode";
            this.WcCode.Name = "WcCode";
            this.WcCode.Visible = true;
            this.WcCode.VisibleIndex = 4;
            this.WcCode.Width = 91;
            // 
            // Ref_Machine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.pnlHead);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Name = "Ref_Machine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "参照 -- 机台档案";
            this.Load += new System.EventHandler(this.Ref_Inventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem BtnOK;
        private DevComponents.DotNetBar.ButtonItem BtnCancel;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.PanelEx pnlHead;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn cMacCode;
        private DevExpress.XtraGrid.Columns.GridColumn cMacName;
        private DevExpress.XtraGrid.Columns.GridColumn cMacStd;
        private DevExpress.XtraGrid.Columns.GridColumn cMacVend;
        private DevExpress.XtraGrid.Columns.GridColumn WcCode;
    }
}