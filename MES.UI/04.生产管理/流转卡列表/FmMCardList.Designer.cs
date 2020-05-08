namespace LanyunMES.UI
{
    partial class FmMCardList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmMCardList));
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.BtnBrowse = new DevComponents.DotNetBar.ButtonItem();
            this.BtnExport = new DevComponents.DotNetBar.ButtonItem();
            this.Btn_Print = new DevComponents.DotNetBar.ButtonItem();
            this.Btn_PrintDesgin = new DevComponents.DotNetBar.ButtonItem();
            this.Btn_CreateCard = new DevComponents.DotNetBar.ButtonItem();
            this.Btn_Query = new DevComponents.DotNetBar.ButtonItem();
            this.BtnReflash = new DevComponents.DotNetBar.ButtonItem();
            this.BtnDelCard = new DevComponents.DotNetBar.ButtonItem();
            this.BtnClose = new DevComponents.DotNetBar.ButtonItem();
            this.BtnOpen = new DevComponents.DotNetBar.ButtonItem();
            this.BtnPause = new DevComponents.DotNetBar.ButtonItem();
            this.BtnStart = new DevComponents.DotNetBar.ButtonItem();
            this.BtnQueryFile = new DevComponents.DotNetBar.ButtonItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.GirdCard = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.report1 = new FastReport.Report();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.GridRouter = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridControl3 = new DevExpress.XtraGrid.GridControl();
            this.GridDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GirdCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridRouter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.BtnBrowse,
            this.BtnExport,
            this.Btn_Print,
            this.Btn_CreateCard,
            this.Btn_Query,
            this.BtnReflash,
            this.BtnDelCard,
            this.BtnClose,
            this.BtnPause,
            this.BtnQueryFile});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.PaddingRight = 50;
            this.bar1.Size = new System.Drawing.Size(979, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 7;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // BtnBrowse
            // 
            this.BtnBrowse.Name = "BtnBrowse";
            this.BtnBrowse.Text = "查看(&B)";
            this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // BtnExport
            // 
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Text = "导出(&E)";
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // Btn_Print
            // 
            this.Btn_Print.BeginGroup = true;
            this.Btn_Print.Name = "Btn_Print";
            this.Btn_Print.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Btn_PrintDesgin});
            this.Btn_Print.Text = "打印";
            this.Btn_Print.Click += new System.EventHandler(this.Btn_Print_Click);
            // 
            // Btn_PrintDesgin
            // 
            this.Btn_PrintDesgin.Name = "Btn_PrintDesgin";
            this.Btn_PrintDesgin.Text = "设计";
            this.Btn_PrintDesgin.Click += new System.EventHandler(this.Btn_PrintDesgin_Click);
            // 
            // Btn_CreateCard
            // 
            this.Btn_CreateCard.ForeColor = System.Drawing.Color.Blue;
            this.Btn_CreateCard.Name = "Btn_CreateCard";
            this.Btn_CreateCard.Text = "生成子卡";
            this.Btn_CreateCard.Visible = false;
            this.Btn_CreateCard.Click += new System.EventHandler(this.Btn_CreateCard_Click);
            // 
            // Btn_Query
            // 
            this.Btn_Query.BeginGroup = true;
            this.Btn_Query.Name = "Btn_Query";
            this.Btn_Query.Text = "查询";
            this.Btn_Query.Click += new System.EventHandler(this.Btn_Query_Click);
            // 
            // BtnReflash
            // 
            this.BtnReflash.Name = "BtnReflash";
            this.BtnReflash.Text = "刷新";
            this.BtnReflash.Click += new System.EventHandler(this.BtnReflash_Click);
            // 
            // BtnDelCard
            // 
            this.BtnDelCard.BeginGroup = true;
            this.BtnDelCard.ForeColor = System.Drawing.Color.Red;
            this.BtnDelCard.Name = "BtnDelCard";
            this.BtnDelCard.Text = "删卡";
            this.BtnDelCard.Click += new System.EventHandler(this.BtnDelCard_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.BtnOpen});
            this.BtnClose.Text = "关闭";
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnOpen
            // 
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Text = "打开";
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // BtnPause
            // 
            this.BtnPause.Name = "BtnPause";
            this.BtnPause.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.BtnStart});
            this.BtnPause.Text = "暂停";
            this.BtnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Text = "开启";
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // BtnQueryFile
            // 
            this.BtnQueryFile.BeginGroup = true;
            this.BtnQueryFile.Name = "BtnQueryFile";
            this.BtnQueryFile.Text = "查看文件(&L)";
            this.BtnQueryFile.Click += new System.EventHandler(this.BtnQueryFile_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 27);
            this.gridControl1.MainView = this.GirdCard;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(979, 317);
            this.gridControl1.TabIndex = 8;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GirdCard});
            // 
            // GirdCard
            // 
            this.GirdCard.GridControl = this.gridControl1;
            this.GirdCard.Name = "GirdCard";
            this.GirdCard.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GirdCard.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GirdCard.OptionsBehavior.Editable = false;
            this.GirdCard.OptionsBehavior.ReadOnly = true;
            this.GirdCard.OptionsSelection.CheckBoxSelectorColumnWidth = 40;
            this.GirdCard.OptionsSelection.MultiSelect = true;
            this.GirdCard.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.GirdCard.OptionsView.ColumnAutoWidth = false;
            this.GirdCard.OptionsView.ShowFooter = true;
            this.GirdCard.OptionsView.ShowGroupPanel = false;
            this.GirdCard.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.GirdCard_CustomDrawCell);
            this.GirdCard.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // report1
            // 
            this.report1.NeedRefresh = false;
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.GridRouter;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(546, 202);
            this.gridControl2.TabIndex = 9;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridRouter});
            // 
            // GridRouter
            // 
            this.GridRouter.GridControl = this.gridControl2;
            this.GridRouter.Name = "GridRouter";
            this.GridRouter.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridRouter.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridRouter.OptionsBehavior.Editable = false;
            this.GridRouter.OptionsBehavior.ReadOnly = true;
            this.GridRouter.OptionsSelection.CheckBoxSelectorColumnWidth = 40;
            this.GridRouter.OptionsView.ColumnAutoWidth = false;
            this.GridRouter.OptionsView.ShowGroupPanel = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer1.Location = new System.Drawing.Point(0, 344);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridControl2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridControl3);
            this.splitContainer1.Size = new System.Drawing.Size(979, 202);
            this.splitContainer1.SplitterDistance = 546;
            this.splitContainer1.TabIndex = 10;
            // 
            // gridControl3
            // 
            this.gridControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl3.Location = new System.Drawing.Point(0, 0);
            this.gridControl3.MainView = this.GridDetail;
            this.gridControl3.Name = "gridControl3";
            this.gridControl3.Size = new System.Drawing.Size(429, 202);
            this.gridControl3.TabIndex = 10;
            this.gridControl3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridDetail});
            // 
            // GridDetail
            // 
            this.GridDetail.GridControl = this.gridControl3;
            this.GridDetail.Name = "GridDetail";
            this.GridDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridDetail.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridDetail.OptionsBehavior.Editable = false;
            this.GridDetail.OptionsBehavior.ReadOnly = true;
            this.GridDetail.OptionsSelection.CheckBoxSelectorColumnWidth = 40;
            this.GridDetail.OptionsView.ColumnAutoWidth = false;
            this.GridDetail.OptionsView.ShowGroupPanel = false;
            // 
            // FmMCardList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 546);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Name = "FmMCardList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "流转卡列表";
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GirdCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridRouter)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem Btn_Print;
        protected DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView GirdCard;
        private FastReport.Report report1;
        private DevComponents.DotNetBar.ButtonItem Btn_PrintDesgin;
        private DevComponents.DotNetBar.ButtonItem Btn_Query;
        private DevComponents.DotNetBar.ButtonItem BtnReflash;
        private DevComponents.DotNetBar.ButtonItem BtnDelCard;
        protected DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView GridRouter;
        private DevComponents.DotNetBar.ButtonItem Btn_CreateCard;
        private System.Windows.Forms.SplitContainer splitContainer1;
        protected DevExpress.XtraGrid.GridControl gridControl3;
        private DevExpress.XtraGrid.Views.Grid.GridView GridDetail;
        private DevComponents.DotNetBar.ButtonItem BtnClose;
        private DevComponents.DotNetBar.ButtonItem BtnPause;
        private DevComponents.DotNetBar.ButtonItem BtnOpen;
        private DevComponents.DotNetBar.ButtonItem BtnExport;
        private DevComponents.DotNetBar.ButtonItem BtnQueryFile;
        private DevComponents.DotNetBar.ButtonItem BtnBrowse;
        private DevComponents.DotNetBar.ButtonItem BtnStart;
    }
}