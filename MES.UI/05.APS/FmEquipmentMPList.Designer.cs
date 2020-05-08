namespace LanyunMES.UI
{
    partial class FmEquipmentMPList
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
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.BtnQuery = new DevComponents.DotNetBar.ButtonItem();
            this.BtnAdd = new DevComponents.DotNetBar.ButtonItem();
            this.BtnEdit = new DevComponents.DotNetBar.ButtonItem();
            this.BtnDel = new DevComponents.DotNetBar.ButtonItem();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cEQCName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cEQCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cEQName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cMaker = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.stopHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.iHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCalcEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.pnlMain = new DevComponents.DotNetBar.PanelEx();
            this.workHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.BtnQuery,
            this.BtnAdd,
            this.BtnEdit,
            this.BtnDel});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.PaddingRight = 50;
            this.bar1.Size = new System.Drawing.Size(1076, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 6;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // BtnQuery
            // 
            this.BtnQuery.Name = "BtnQuery";
            this.BtnQuery.Text = "查询(&Q)";
            this.BtnQuery.Click += new System.EventHandler(this.BtnQuery_Click);
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
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridControl2.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black;
            this.gridControl2.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridControl2.EmbeddedNavigator.Appearance.Options.UseForeColor = true;
            this.gridControl2.Location = new System.Drawing.Point(0, 77);
            this.gridControl2.MainView = this.gridView1;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCalcEdit2});
            this.gridControl2.Size = new System.Drawing.Size(1076, 508);
            this.gridControl2.TabIndex = 7;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.cEQCode,
            this.cEQName,
            this.dDate,
            this.cEQCName,
            this.iHours,
            this.stopHours,
            this.workHours,
            this.reason,
            this.cMaker,
            this.dCreateDate});
            this.gridView1.GridControl = this.gridControl2;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // cEQCName
            // 
            this.cEQCName.Caption = "设备分类";
            this.cEQCName.FieldName = "cEQCName";
            this.cEQCName.Name = "cEQCName";
            this.cEQCName.Visible = true;
            this.cEQCName.VisibleIndex = 3;
            this.cEQCName.Width = 128;
            // 
            // cEQCode
            // 
            this.cEQCode.Caption = "设备编码";
            this.cEQCode.FieldName = "cEQCode";
            this.cEQCode.Name = "cEQCode";
            this.cEQCode.OptionsColumn.AllowEdit = false;
            this.cEQCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "cInvCode", "记录数: {0}")});
            this.cEQCode.Visible = true;
            this.cEQCode.VisibleIndex = 0;
            this.cEQCode.Width = 106;
            // 
            // cEQName
            // 
            this.cEQName.Caption = "设备名称";
            this.cEQName.FieldName = "cEQName";
            this.cEQName.Name = "cEQName";
            this.cEQName.OptionsColumn.AllowEdit = false;
            this.cEQName.Visible = true;
            this.cEQName.VisibleIndex = 1;
            this.cEQName.Width = 125;
            // 
            // cMaker
            // 
            this.cMaker.Caption = "制单人";
            this.cMaker.FieldName = "cMaker";
            this.cMaker.Name = "cMaker";
            this.cMaker.Visible = true;
            this.cMaker.VisibleIndex = 8;
            this.cMaker.Width = 77;
            // 
            // dCreateDate
            // 
            this.dCreateDate.Caption = "制单日期";
            this.dCreateDate.FieldName = "dCreateDate";
            this.dCreateDate.Name = "dCreateDate";
            this.dCreateDate.Visible = true;
            this.dCreateDate.VisibleIndex = 9;
            this.dCreateDate.Width = 100;
            // 
            // stopHours
            // 
            this.stopHours.Caption = "停机时间/H";
            this.stopHours.FieldName = "stopHours";
            this.stopHours.Name = "stopHours";
            this.stopHours.Visible = true;
            this.stopHours.VisibleIndex = 5;
            this.stopHours.Width = 81;
            // 
            // iHours
            // 
            this.iHours.Caption = "日工作效率/H";
            this.iHours.FieldName = "iHours";
            this.iHours.Name = "iHours";
            this.iHours.Visible = true;
            this.iHours.VisibleIndex = 4;
            this.iHours.Width = 88;
            // 
            // repositoryItemCalcEdit2
            // 
            this.repositoryItemCalcEdit2.AutoHeight = false;
            this.repositoryItemCalcEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCalcEdit2.Name = "repositoryItemCalcEdit2";
            // 
            // pnlMain
            // 
            this.pnlMain.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlMain.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlMain.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMain.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlMain.Location = new System.Drawing.Point(0, 27);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1076, 50);
            this.pnlMain.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlMain.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlMain.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlMain.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlMain.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlMain.Style.GradientAngle = 90;
            this.pnlMain.TabIndex = 0;
            this.pnlMain.Text = "设备维护计划列表";
            // 
            // workHours
            // 
            this.workHours.Caption = "工作时间/H";
            this.workHours.FieldName = "workHours";
            this.workHours.Name = "workHours";
            this.workHours.Visible = true;
            this.workHours.VisibleIndex = 6;
            this.workHours.Width = 82;
            // 
            // reason
            // 
            this.reason.Caption = "停机原因";
            this.reason.FieldName = "reason";
            this.reason.Name = "reason";
            this.reason.Visible = true;
            this.reason.VisibleIndex = 7;
            this.reason.Width = 165;
            // 
            // dDate
            // 
            this.dDate.Caption = "日期";
            this.dDate.FieldName = "dDate";
            this.dDate.Name = "dDate";
            this.dDate.Visible = true;
            this.dDate.VisibleIndex = 2;
            this.dDate.Width = 106;
            // 
            // FmEquipmentMPList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 585);
            this.Controls.Add(this.gridControl2);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.bar1);
            this.Name = "FmEquipmentMPList";
            this.RenderFormIcon = false;
            this.RenderFormText = false;
            this.Text = "检验单";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem BtnAdd;
        private DevComponents.DotNetBar.ButtonItem BtnEdit;
        private DevComponents.DotNetBar.ButtonItem BtnDel;
        private DevComponents.DotNetBar.ButtonItem BtnQuery;
        protected DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn cEQCName;
        private DevExpress.XtraGrid.Columns.GridColumn cEQCode;
        private DevExpress.XtraGrid.Columns.GridColumn cEQName;
        private DevExpress.XtraGrid.Columns.GridColumn cMaker;
        private DevExpress.XtraGrid.Columns.GridColumn dCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn stopHours;
        private DevExpress.XtraGrid.Columns.GridColumn iHours;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repositoryItemCalcEdit2;
        private DevComponents.DotNetBar.PanelEx pnlMain;
        private DevExpress.XtraGrid.Columns.GridColumn dDate;
        private DevExpress.XtraGrid.Columns.GridColumn workHours;
        private DevExpress.XtraGrid.Columns.GridColumn reason;
    }
}