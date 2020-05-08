namespace MES.UI
{
    partial class Ref_SaleType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ref_SaleType));
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.BtnOK = new DevComponents.DotNetBar.ButtonItem();
            this.BtnCancel = new DevComponents.DotNetBar.ButtonItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnlHead = new DevComponents.DotNetBar.PanelEx();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cSTCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cSTName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cRDCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bDefault = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bSTMPS_MRP = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.pnlHead.Text = "销售类型档案";
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
            this.cSTCode,
            this.cSTName,
            this.cRDCode,
            this.bDefault,
            this.bSTMPS_MRP});
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
            // cSTCode
            // 
            this.cSTCode.Caption = "销售类型编码";
            this.cSTCode.FieldName = "cSTCode";
            this.cSTCode.Name = "cSTCode";
            this.cSTCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "cInvCode", "记录数：{0}")});
            this.cSTCode.Visible = true;
            this.cSTCode.VisibleIndex = 0;
            this.cSTCode.Width = 111;
            // 
            // cSTName
            // 
            this.cSTName.Caption = "销售类型名称";
            this.cSTName.FieldName = "cSTName";
            this.cSTName.Name = "cSTName";
            this.cSTName.Visible = true;
            this.cSTName.VisibleIndex = 1;
            this.cSTName.Width = 158;
            // 
            // cRDCode
            // 
            this.cRDCode.Caption = "出库类别编码";
            this.cRDCode.FieldName = "cRDCode";
            this.cRDCode.Name = "cRDCode";
            this.cRDCode.Visible = true;
            this.cRDCode.VisibleIndex = 2;
            this.cRDCode.Width = 139;
            // 
            // bDefault
            // 
            this.bDefault.Caption = "是否默认";
            this.bDefault.FieldName = "bDefault";
            this.bDefault.Name = "bDefault";
            this.bDefault.Visible = true;
            this.bDefault.VisibleIndex = 3;
            this.bDefault.Width = 141;
            // 
            // bSTMPS_MRP
            // 
            this.bSTMPS_MRP.Caption = "是否参与需求运算";
            this.bSTMPS_MRP.FieldName = "bSTMPS_MRP";
            this.bSTMPS_MRP.Name = "bSTMPS_MRP";
            this.bSTMPS_MRP.Visible = true;
            this.bSTMPS_MRP.VisibleIndex = 4;
            this.bSTMPS_MRP.Width = 147;
            // 
            // Ref_SaleType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.pnlHead);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Name = "Ref_SaleType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "参照 -- 客户档案";
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
        private DevExpress.XtraGrid.Columns.GridColumn cSTCode;
        private DevExpress.XtraGrid.Columns.GridColumn cSTName;
        private DevExpress.XtraGrid.Columns.GridColumn cRDCode;
        private DevExpress.XtraGrid.Columns.GridColumn bDefault;
        private DevExpress.XtraGrid.Columns.GridColumn bSTMPS_MRP;
    }
}