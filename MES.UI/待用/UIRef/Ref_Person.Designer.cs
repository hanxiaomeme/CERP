namespace MES.UI
{
    partial class Ref_Person
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ref_Person));
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.BtnOK = new DevComponents.DotNetBar.ButtonItem();
            this.BtnCancel = new DevComponents.DotNetBar.ButtonItem();
            this.collapsibleSplitContainer1 = new DevComponents.DotNetBar.Controls.CollapsibleSplitContainer();
            this.TreeClass = new DevComponents.AdvTree.AdvTree();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cPersonCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cPersonName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cDepCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cPersonPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dPValidDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlHead = new DevComponents.DotNetBar.PanelEx();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.collapsibleSplitContainer1)).BeginInit();
            this.collapsibleSplitContainer1.Panel1.SuspendLayout();
            this.collapsibleSplitContainer1.Panel2.SuspendLayout();
            this.collapsibleSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeClass)).BeginInit();
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
            this.bar1.Size = new System.Drawing.Size(984, 27);
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
            // collapsibleSplitContainer1
            // 
            this.collapsibleSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.collapsibleSplitContainer1.Location = new System.Drawing.Point(0, 107);
            this.collapsibleSplitContainer1.Name = "collapsibleSplitContainer1";
            // 
            // collapsibleSplitContainer1.Panel1
            // 
            this.collapsibleSplitContainer1.Panel1.Controls.Add(this.TreeClass);
            // 
            // collapsibleSplitContainer1.Panel2
            // 
            this.collapsibleSplitContainer1.Panel2.Controls.Add(this.gridControl1);
            this.collapsibleSplitContainer1.Size = new System.Drawing.Size(984, 455);
            this.collapsibleSplitContainer1.SplitterDistance = 233;
            this.collapsibleSplitContainer1.SplitterWidth = 20;
            this.collapsibleSplitContainer1.TabIndex = 1;
            // 
            // TreeClass
            // 
            this.TreeClass.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.TreeClass.AllowDrop = true;
            this.TreeClass.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.TreeClass.BackgroundStyle.Class = "TreeBorderKey";
            this.TreeClass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TreeClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeClass.DragDropEnabled = false;
            this.TreeClass.ImageList = this.imageList1;
            this.TreeClass.Location = new System.Drawing.Point(0, 0);
            this.TreeClass.MultiNodeDragDropAllowed = false;
            this.TreeClass.Name = "TreeClass";
            this.TreeClass.NodesConnector = this.nodeConnector1;
            this.TreeClass.NodeStyle = this.elementStyle1;
            this.TreeClass.PathSeparator = ";";
            this.TreeClass.Size = new System.Drawing.Size(233, 455);
            this.TreeClass.Styles.Add(this.elementStyle1);
            this.TreeClass.TabIndex = 3;
            this.TreeClass.Text = "advTree1";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "play_blue.png");
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle1
            // 
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(731, 455);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.cPersonCode,
            this.cPersonName,
            this.cDepCode,
            this.cPersonPhone,
            this.dPValidDate});
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
            // cPersonCode
            // 
            this.cPersonCode.Caption = "职员编码";
            this.cPersonCode.FieldName = "cPersonCode";
            this.cPersonCode.Name = "cPersonCode";
            this.cPersonCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "cInvCode", "记录数：{0}")});
            this.cPersonCode.Visible = true;
            this.cPersonCode.VisibleIndex = 0;
            this.cPersonCode.Width = 105;
            // 
            // cPersonName
            // 
            this.cPersonName.Caption = "职员名称";
            this.cPersonName.FieldName = "cPersonName";
            this.cPersonName.Name = "cPersonName";
            this.cPersonName.Visible = true;
            this.cPersonName.VisibleIndex = 1;
            this.cPersonName.Width = 202;
            // 
            // cDepCode
            // 
            this.cDepCode.Caption = "部门编码";
            this.cDepCode.FieldName = "cDepCode";
            this.cDepCode.Name = "cDepCode";
            this.cDepCode.Visible = true;
            this.cDepCode.VisibleIndex = 2;
            this.cDepCode.Width = 120;
            // 
            // cPersonPhone
            // 
            this.cPersonPhone.Caption = "电话";
            this.cPersonPhone.FieldName = "cPersonPhone";
            this.cPersonPhone.Name = "cPersonPhone";
            this.cPersonPhone.Visible = true;
            this.cPersonPhone.VisibleIndex = 3;
            this.cPersonPhone.Width = 135;
            // 
            // dPValidDate
            // 
            this.dPValidDate.Caption = "生效日期";
            this.dPValidDate.FieldName = "dPValidDate";
            this.dPValidDate.Name = "dPValidDate";
            this.dPValidDate.Visible = true;
            this.dPValidDate.VisibleIndex = 4;
            this.dPValidDate.Width = 134;
            // 
            // pnlHead
            // 
            this.pnlHead.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlHead.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlHead.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHead.Location = new System.Drawing.Point(0, 27);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Size = new System.Drawing.Size(984, 80);
            this.pnlHead.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlHead.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlHead.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlHead.Style.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlHead.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlHead.Style.GradientAngle = 90;
            this.pnlHead.Style.LineAlignment = System.Drawing.StringAlignment.Near;
            this.pnlHead.Style.MarginTop = 5;
            this.pnlHead.TabIndex = 5;
            this.pnlHead.Text = "职员档案";
            // 
            // Ref_Person
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.collapsibleSplitContainer1);
            this.Controls.Add(this.pnlHead);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Name = "Ref_Person";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "参照 -- 客户档案";
            this.Load += new System.EventHandler(this.Ref_Inventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.collapsibleSplitContainer1.Panel1.ResumeLayout(false);
            this.collapsibleSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.collapsibleSplitContainer1)).EndInit();
            this.collapsibleSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TreeClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem BtnOK;
        private DevComponents.DotNetBar.ButtonItem BtnCancel;
        private DevComponents.DotNetBar.Controls.CollapsibleSplitContainer collapsibleSplitContainer1;
        private DevComponents.AdvTree.AdvTree TreeClass;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn cPersonCode;
        private DevExpress.XtraGrid.Columns.GridColumn cPersonName;
        private DevExpress.XtraGrid.Columns.GridColumn cDepCode;
        private DevExpress.XtraGrid.Columns.GridColumn cPersonPhone;
        private DevExpress.XtraGrid.Columns.GridColumn dPValidDate;
        private DevComponents.DotNetBar.PanelEx pnlHead;
    }
}