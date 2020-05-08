namespace LanyunMES.UIBase
{
    partial class FmBILL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmBILL));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.Btn_Add = new DevComponents.DotNetBar.ButtonItem();
            this.Btn_Edit = new DevComponents.DotNetBar.ButtonItem();
            this.Btn_Del = new DevComponents.DotNetBar.ButtonItem();
            this.Btn_Save = new DevComponents.DotNetBar.ButtonItem();
            this.Btn_Cancel = new DevComponents.DotNetBar.ButtonItem();
            this.Btn_Audit = new DevComponents.DotNetBar.ButtonItem();
            this.Btn_first = new DevComponents.DotNetBar.ButtonItem();
            this.Btn_previous = new DevComponents.DotNetBar.ButtonItem();
            this.Btn_next = new DevComponents.DotNetBar.ButtonItem();
            this.Btn_last = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.txt_search = new DevComponents.DotNetBar.TextBoxItem();
            this.pnlMain = new DevComponents.DotNetBar.PanelEx();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.Btn_Addline = new DevComponents.DotNetBar.ButtonItem();
            this.Btn_Delline = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 222);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(990, 326);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Btn_Add,
            this.Btn_Edit,
            this.Btn_Del,
            this.Btn_Save,
            this.Btn_Cancel,
            this.Btn_Audit,
            this.Btn_first,
            this.Btn_previous,
            this.Btn_next,
            this.Btn_last,
            this.labelItem1,
            this.txt_search});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.PaddingRight = 50;
            this.bar1.Size = new System.Drawing.Size(990, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 6;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // Btn_Add
            // 
            this.Btn_Add.Name = "Btn_Add";
            this.Btn_Add.Text = "新增";
            this.Btn_Add.Click += new System.EventHandler(this.Btn_Add_Click);
            // 
            // Btn_Edit
            // 
            this.Btn_Edit.Name = "Btn_Edit";
            this.Btn_Edit.Text = "修改";
            this.Btn_Edit.Click += new System.EventHandler(this.Btn_Edit_Click);
            // 
            // Btn_Del
            // 
            this.Btn_Del.Name = "Btn_Del";
            this.Btn_Del.Text = "删除";
            // 
            // Btn_Save
            // 
            this.Btn_Save.BeginGroup = true;
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Text = "保存";
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Text = "取消";
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // Btn_Audit
            // 
            this.Btn_Audit.BeginGroup = true;
            this.Btn_Audit.Name = "Btn_Audit";
            this.Btn_Audit.Text = "审核";
            // 
            // Btn_first
            // 
            this.Btn_first.BeginGroup = true;
            this.Btn_first.Image = ((System.Drawing.Image)(resources.GetObject("Btn_first.Image")));
            this.Btn_first.Name = "Btn_first";
            this.Btn_first.Text = "f";
            this.Btn_first.Click += new System.EventHandler(this.Btn_first_Click);
            // 
            // Btn_previous
            // 
            this.Btn_previous.Image = ((System.Drawing.Image)(resources.GetObject("Btn_previous.Image")));
            this.Btn_previous.Name = "Btn_previous";
            this.Btn_previous.Text = "p";
            this.Btn_previous.Click += new System.EventHandler(this.Btn_previous_Click);
            // 
            // Btn_next
            // 
            this.Btn_next.Image = ((System.Drawing.Image)(resources.GetObject("Btn_next.Image")));
            this.Btn_next.Name = "Btn_next";
            this.Btn_next.Text = "n";
            this.Btn_next.Click += new System.EventHandler(this.Btn_next_Click);
            // 
            // Btn_last
            // 
            this.Btn_last.Image = ((System.Drawing.Image)(resources.GetObject("Btn_last.Image")));
            this.Btn_last.Name = "Btn_last";
            this.Btn_last.Text = "l";
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
            this.pnlMain.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMain.Location = new System.Drawing.Point(0, 27);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(990, 168);
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
            this.pnlMain.Text = "单据名称";
            // 
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar2.IsMaximized = false;
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Btn_Addline,
            this.Btn_Delline});
            this.bar2.Location = new System.Drawing.Point(0, 195);
            this.bar2.Name = "bar2";
            this.bar2.Size = new System.Drawing.Size(990, 27);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 23;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
            // 
            // Btn_Addline
            // 
            this.Btn_Addline.Name = "Btn_Addline";
            this.Btn_Addline.Text = "增行";
            this.Btn_Addline.Click += new System.EventHandler(this.Btn_Addline_Click);
            // 
            // Btn_Delline
            // 
            this.Btn_Delline.Name = "Btn_Delline";
            this.Btn_Delline.Text = "删行";
            this.Btn_Delline.Click += new System.EventHandler(this.Btn_Delline_Click);
            // 
            // FmBILL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 548);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.bar2);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Name = "FmBILL";
            this.RenderFormIcon = false;
            this.RenderFormText = false;
            this.Text = "销售订单";
            this.Load += new System.EventHandler(this.FmBILL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        protected DevExpress.XtraGrid.GridControl gridControl1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem Btn_Add;
        private DevComponents.DotNetBar.ButtonItem Btn_Edit;
        private DevComponents.DotNetBar.ButtonItem Btn_Del;
        private DevComponents.DotNetBar.ButtonItem Btn_Save;
        private DevComponents.DotNetBar.ButtonItem Btn_Cancel;
        private DevComponents.DotNetBar.ButtonItem Btn_Audit;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.TextBoxItem txt_search;
        private DevComponents.DotNetBar.PanelEx pnlMain;
        private DevComponents.DotNetBar.ButtonItem Btn_first;
        private DevComponents.DotNetBar.ButtonItem Btn_previous;
        private DevComponents.DotNetBar.ButtonItem Btn_next;
        private DevComponents.DotNetBar.ButtonItem Btn_last;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.ButtonItem Btn_Addline;
        private DevComponents.DotNetBar.ButtonItem Btn_Delline;
    }
}