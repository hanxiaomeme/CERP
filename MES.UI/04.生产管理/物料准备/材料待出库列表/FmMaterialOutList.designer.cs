namespace LanyunMES.UI
{
    partial class FmMaterialOutList
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
            this.ToolBar = new DevComponents.DotNetBar.Bar();
            this.btn_Export = new DevComponents.DotNetBar.ButtonItem();
            this.BtnQuery = new DevComponents.DotNetBar.ButtonItem();
            this.Btn_OK = new DevComponents.DotNetBar.ButtonItem();
            this.BtnRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.StatusBar = new DevComponents.DotNetBar.Bar();
            this.sBar_lbl = new DevComponents.DotNetBar.LabelItem();
            this.pnl_title = new DevComponents.DotNetBar.PanelEx();
            this.cb_NoStart = new System.Windows.Forms.CheckBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.ToolBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBar)).BeginInit();
            this.pnl_title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            this.ToolBar.AntiAlias = true;
            this.ToolBar.BarType = DevComponents.DotNetBar.eBarType.MenuBar;
            this.ToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolBar.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.ToolBar.IsMaximized = false;
            this.ToolBar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_Export,
            this.BtnQuery,
            this.Btn_OK,
            this.BtnRefresh});
            this.ToolBar.Location = new System.Drawing.Point(0, 0);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.Size = new System.Drawing.Size(973, 27);
            this.ToolBar.Stretch = true;
            this.ToolBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ToolBar.TabIndex = 0;
            this.ToolBar.TabStop = false;
            this.ToolBar.Text = "bar1";
            // 
            // btn_Export
            // 
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Text = "导出(&E)";
            // 
            // BtnQuery
            // 
            this.BtnQuery.BeginGroup = true;
            this.BtnQuery.Name = "BtnQuery";
            this.BtnQuery.Text = "查询(&Q)";
            this.BtnQuery.Click += new System.EventHandler(this.BtnQuery_Click);
            // 
            // Btn_OK
            // 
            this.Btn_OK.Name = "Btn_OK";
            this.Btn_OK.Text = "选择(&C)";
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Text = "刷新(&R)";
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // StatusBar
            // 
            this.StatusBar.AntiAlias = true;
            this.StatusBar.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
            this.StatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StatusBar.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.StatusBar.IsMaximized = false;
            this.StatusBar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.sBar_lbl});
            this.StatusBar.Location = new System.Drawing.Point(0, 528);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(973, 22);
            this.StatusBar.Stretch = true;
            this.StatusBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.StatusBar.TabIndex = 3;
            this.StatusBar.TabStop = false;
            this.StatusBar.Text = "bar2";
            // 
            // sBar_lbl
            // 
            this.sBar_lbl.Name = "sBar_lbl";
            this.sBar_lbl.Text = "--";
            // 
            // pnl_title
            // 
            this.pnl_title.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnl_title.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnl_title.Controls.Add(this.cb_NoStart);
            this.pnl_title.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnl_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_title.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnl_title.Location = new System.Drawing.Point(0, 27);
            this.pnl_title.Name = "pnl_title";
            this.pnl_title.Size = new System.Drawing.Size(973, 40);
            this.pnl_title.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnl_title.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnl_title.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnl_title.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnl_title.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Top;
            this.pnl_title.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnl_title.Style.GradientAngle = 90;
            this.pnl_title.TabIndex = 15;
            this.pnl_title.Text = "待领料流转卡列表";
            // 
            // cb_NoStart
            // 
            this.cb_NoStart.AutoSize = true;
            this.cb_NoStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_NoStart.Location = new System.Drawing.Point(141, 13);
            this.cb_NoStart.Name = "cb_NoStart";
            this.cb_NoStart.Size = new System.Drawing.Size(84, 16);
            this.cb_NoStart.TabIndex = 0;
            this.cb_NoStart.Text = "包括未开工";
            this.cb_NoStart.UseVisualStyleBackColor = true;
            this.cb_NoStart.Visible = false;
            this.cb_NoStart.CheckedChanged += new System.EventHandler(this.cb_NoStart_CheckedChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 67);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(973, 265);
            this.gridControl1.TabIndex = 24;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoPopulateColumns = false;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 40;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControl2.Location = new System.Drawing.Point(0, 332);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(973, 196);
            this.gridControl2.TabIndex = 28;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.AutoPopulateColumns = false;
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsSelection.CheckBoxSelectorColumnWidth = 40;
            this.gridView2.OptionsSelection.MultiSelect = true;
            this.gridView2.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowFooter = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // FmMaterialOutList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(973, 550);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.gridControl2);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.pnl_title);
            this.Controls.Add(this.ToolBar);
            this.DoubleBuffered = true;
            this.Name = "FmMaterialOutList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "未完工工单列表";
            ((System.ComponentModel.ISupportInitialize)(this.ToolBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBar)).EndInit();
            this.pnl_title.ResumeLayout(false);
            this.pnl_title.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelItem sBar_lbl;
        protected DevComponents.DotNetBar.ButtonItem btn_Export;
        protected DevComponents.DotNetBar.ButtonItem Btn_OK;
        protected DevComponents.DotNetBar.Bar ToolBar;
        protected DevComponents.DotNetBar.Bar StatusBar;
        protected DevComponents.DotNetBar.PanelEx pnl_title;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.CheckBox cb_NoStart;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevComponents.DotNetBar.ButtonItem BtnRefresh;
        private DevComponents.DotNetBar.ButtonItem BtnQuery;
    }
}