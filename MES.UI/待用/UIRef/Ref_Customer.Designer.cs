namespace MES.UI
{
    partial class Ref_Customer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ref_Customer));
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.BtnOK = new DevComponents.DotNetBar.ButtonItem();
            this.BtnCancel = new DevComponents.DotNetBar.ButtonItem();
            this.collapsibleSplitContainer1 = new DevComponents.DotNetBar.Controls.CollapsibleSplitContainer();
            this.InvClass_Tree = new DevComponents.AdvTree.AdvTree();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cCusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cCusName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cCCCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cCCName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dCusDevDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.collapsibleSplitContainer1)).BeginInit();
            this.collapsibleSplitContainer1.Panel1.SuspendLayout();
            this.collapsibleSplitContainer1.Panel2.SuspendLayout();
            this.collapsibleSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InvClass_Tree)).BeginInit();
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
            this.collapsibleSplitContainer1.Panel1.Controls.Add(this.InvClass_Tree);
            // 
            // collapsibleSplitContainer1.Panel2
            // 
            this.collapsibleSplitContainer1.Panel2.Controls.Add(this.gridControl1);
            this.collapsibleSplitContainer1.Size = new System.Drawing.Size(984, 455);
            this.collapsibleSplitContainer1.SplitterDistance = 233;
            this.collapsibleSplitContainer1.SplitterWidth = 20;
            this.collapsibleSplitContainer1.TabIndex = 1;
            // 
            // InvClass_Tree
            // 
            this.InvClass_Tree.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.InvClass_Tree.AllowDrop = true;
            this.InvClass_Tree.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.InvClass_Tree.BackgroundStyle.Class = "TreeBorderKey";
            this.InvClass_Tree.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.InvClass_Tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InvClass_Tree.DragDropEnabled = false;
            this.InvClass_Tree.ImageList = this.imageList1;
            this.InvClass_Tree.Location = new System.Drawing.Point(0, 0);
            this.InvClass_Tree.MultiNodeDragDropAllowed = false;
            this.InvClass_Tree.Name = "InvClass_Tree";
            this.InvClass_Tree.NodesConnector = this.nodeConnector1;
            this.InvClass_Tree.NodeStyle = this.elementStyle1;
            this.InvClass_Tree.PathSeparator = ";";
            this.InvClass_Tree.Size = new System.Drawing.Size(233, 455);
            this.InvClass_Tree.Styles.Add(this.elementStyle1);
            this.InvClass_Tree.TabIndex = 3;
            this.InvClass_Tree.Text = "advTree1";
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
            this.cCusCode,
            this.cCusName,
            this.cCCCode,
            this.cCCName,
            this.dCusDevDate});
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
            // cCusCode
            // 
            this.cCusCode.Caption = "客户编码";
            this.cCusCode.FieldName = "cCusCode";
            this.cCusCode.Name = "cCusCode";
            this.cCusCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "cInvCode", "记录数：{0}")});
            this.cCusCode.Visible = true;
            this.cCusCode.VisibleIndex = 0;
            this.cCusCode.Width = 105;
            // 
            // cCusName
            // 
            this.cCusName.Caption = "客户名称";
            this.cCusName.FieldName = "cCusName";
            this.cCusName.Name = "cCusName";
            this.cCusName.Visible = true;
            this.cCusName.VisibleIndex = 1;
            this.cCusName.Width = 202;
            // 
            // cCCCode
            // 
            this.cCCCode.Caption = "分类编码";
            this.cCCCode.FieldName = "cCCCode";
            this.cCCCode.Name = "cCCCode";
            this.cCCCode.Visible = true;
            this.cCCCode.VisibleIndex = 2;
            this.cCCCode.Width = 120;
            // 
            // cCCName
            // 
            this.cCCName.Caption = "分类名称";
            this.cCCName.FieldName = "cCCName";
            this.cCCName.Name = "cCCName";
            this.cCCName.Visible = true;
            this.cCCName.VisibleIndex = 3;
            this.cCCName.Width = 135;
            // 
            // dCusDevDate
            // 
            this.dCusDevDate.Caption = "发展日期";
            this.dCusDevDate.FieldName = "dCusDevDate";
            this.dCusDevDate.Name = "dCusDevDate";
            this.dCusDevDate.Visible = true;
            this.dCusDevDate.VisibleIndex = 4;
            this.dCusDevDate.Width = 134;
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx2.Location = new System.Drawing.Point(0, 27);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(984, 80);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.Style.LineAlignment = System.Drawing.StringAlignment.Near;
            this.panelEx2.Style.MarginTop = 5;
            this.panelEx2.TabIndex = 5;
            this.panelEx2.Text = "客户档案";
            // 
            // Ref_Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.collapsibleSplitContainer1);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Name = "Ref_Customer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "参照 -- 客户档案";
            this.Load += new System.EventHandler(this.Ref_Inventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.collapsibleSplitContainer1.Panel1.ResumeLayout(false);
            this.collapsibleSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.collapsibleSplitContainer1)).EndInit();
            this.collapsibleSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InvClass_Tree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem BtnOK;
        private DevComponents.DotNetBar.ButtonItem BtnCancel;
        private DevComponents.DotNetBar.Controls.CollapsibleSplitContainer collapsibleSplitContainer1;
        private DevComponents.AdvTree.AdvTree InvClass_Tree;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn cCusCode;
        private DevExpress.XtraGrid.Columns.GridColumn cCusName;
        private DevExpress.XtraGrid.Columns.GridColumn cCCCode;
        private DevExpress.XtraGrid.Columns.GridColumn cCCName;
        private DevExpress.XtraGrid.Columns.GridColumn dCusDevDate;
        private DevComponents.DotNetBar.PanelEx panelEx2;
    }
}