namespace LanyunMES.UI
{
    partial class FmEquipmentList
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmEquipmentList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.ToolBar = new DevComponents.DotNetBar.Bar();
            this.btn_Add = new DevComponents.DotNetBar.ButtonItem();
            this.btn_Edit = new DevComponents.DotNetBar.ButtonItem();
            this.btn_Del = new DevComponents.DotNetBar.ButtonItem();
            this.btn_Print = new DevComponents.DotNetBar.ButtonItem();
            this.btn_PrintDesgin = new DevComponents.DotNetBar.ButtonItem();
            this.Btn_Export = new DevComponents.DotNetBar.ButtonItem();
            this.btn_Query = new DevComponents.DotNetBar.ButtonItem();
            this.btn_Refresh = new DevComponents.DotNetBar.ButtonItem();
            this.btn_ColSetting = new DevComponents.DotNetBar.ButtonItem();
            this.BtnMP = new DevComponents.DotNetBar.ButtonItem();
            this.pnl_Head = new DevComponents.DotNetBar.PanelEx();
            this.TreeM = new DevComponents.AdvTree.AdvTree();
            this.rootNode = new DevComponents.AdvTree.Node();
            this.elementStyle5 = new DevComponents.DotNetBar.ElementStyle();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle2 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle3 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle4 = new DevComponents.DotNetBar.ElementStyle();
            this.collapsibleSplitContainer1 = new DevComponents.DotNetBar.Controls.CollapsibleSplitContainer();
            this.sGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.StatusBar = new DevComponents.DotNetBar.Bar();
            this.lblRowCount = new DevComponents.DotNetBar.LabelItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.GridOP = new DevComponents.DotNetBar.Controls.DataGridViewX();
            ((System.ComponentModel.ISupportInitialize)(this.ToolBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TreeM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.collapsibleSplitContainer1)).BeginInit();
            this.collapsibleSplitContainer1.Panel1.SuspendLayout();
            this.collapsibleSplitContainer1.Panel2.SuspendLayout();
            this.collapsibleSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridOP)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "next.gif");
            this.imageList1.Images.SetKeyName(1, "last.gif");
            // 
            // ToolBar
            // 
            this.ToolBar.AntiAlias = true;
            this.ToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolBar.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.ToolBar.IsMaximized = false;
            this.ToolBar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_Add,
            this.btn_Edit,
            this.btn_Del,
            this.btn_Print,
            this.Btn_Export,
            this.btn_Query,
            this.btn_Refresh,
            this.btn_ColSetting,
            this.BtnMP});
            this.ToolBar.Location = new System.Drawing.Point(0, 0);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.Size = new System.Drawing.Size(961, 27);
            this.ToolBar.Stretch = true;
            this.ToolBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ToolBar.TabIndex = 6;
            this.ToolBar.TabStop = false;
            this.ToolBar.Text = "ToolBar";
            // 
            // btn_Add
            // 
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Text = "新增";
            // 
            // btn_Edit
            // 
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Text = "编辑";
            // 
            // btn_Del
            // 
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Text = "删除";
            // 
            // btn_Print
            // 
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.SplitButton = true;
            this.btn_Print.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_PrintDesgin});
            this.btn_Print.Text = "打印";
            this.btn_Print.Visible = false;
            this.btn_Print.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btn_PrintDesgin
            // 
            this.btn_PrintDesgin.Name = "btn_PrintDesgin";
            this.btn_PrintDesgin.Text = "打印设计";
            this.btn_PrintDesgin.Click += new System.EventHandler(this.btn_PrintDesgin_Click);
            // 
            // Btn_Export
            // 
            this.Btn_Export.BeginGroup = true;
            this.Btn_Export.Name = "Btn_Export";
            this.Btn_Export.Text = "输出";
            this.Btn_Export.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btn_Query
            // 
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Text = "查询";
            this.btn_Query.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Text = "刷新";
            this.btn_Refresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btn_ColSetting
            // 
            this.btn_ColSetting.Name = "btn_ColSetting";
            this.btn_ColSetting.Text = "栏目";
            this.btn_ColSetting.Visible = false;
            this.btn_ColSetting.Click += new System.EventHandler(this.btnColSettings_Click);
            // 
            // BtnMP
            // 
            this.BtnMP.BeginGroup = true;
            this.BtnMP.Name = "BtnMP";
            this.BtnMP.Text = "维护计划";
            // 
            // pnl_Head
            // 
            this.pnl_Head.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnl_Head.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnl_Head.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnl_Head.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Head.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnl_Head.Location = new System.Drawing.Point(0, 27);
            this.pnl_Head.Name = "pnl_Head";
            this.pnl_Head.Size = new System.Drawing.Size(961, 40);
            this.pnl_Head.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnl_Head.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnl_Head.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnl_Head.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnl_Head.Style.BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.pnl_Head.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
            this.pnl_Head.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnl_Head.Style.GradientAngle = 90;
            this.pnl_Head.TabIndex = 0;
            this.pnl_Head.Text = "设备档案";
            // 
            // TreeM
            // 
            this.TreeM.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.TreeM.AllowDrop = true;
            this.TreeM.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.TreeM.BackgroundStyle.Class = "TreeBorderKey";
            this.TreeM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TreeM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeM.ForeColor = System.Drawing.Color.Black;
            this.TreeM.ImageList = this.imageList1;
            this.TreeM.Location = new System.Drawing.Point(0, 0);
            this.TreeM.Name = "TreeM";
            this.TreeM.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.rootNode});
            this.TreeM.NodesConnector = this.nodeConnector1;
            this.TreeM.NodeStyle = this.elementStyle1;
            this.TreeM.PathSeparator = ";";
            this.TreeM.Size = new System.Drawing.Size(225, 480);
            this.TreeM.Styles.Add(this.elementStyle1);
            this.TreeM.Styles.Add(this.elementStyle2);
            this.TreeM.Styles.Add(this.elementStyle3);
            this.TreeM.Styles.Add(this.elementStyle4);
            this.TreeM.Styles.Add(this.elementStyle5);
            this.TreeM.TabIndex = 1;
            this.TreeM.Text = "advTree1";
            // 
            // rootNode
            // 
            this.rootNode.Expanded = true;
            this.rootNode.ExpandVisibility = DevComponents.AdvTree.eNodeExpandVisibility.Hidden;
            this.rootNode.FullRowBackground = true;
            this.rootNode.Name = "rootNode";
            this.rootNode.Selectable = false;
            this.rootNode.Style = this.elementStyle5;
            this.rootNode.Text = "模块名称";
            // 
            // elementStyle5
            // 
            this.elementStyle5.BackColor = System.Drawing.Color.White;
            this.elementStyle5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(228)))), ((int)(((byte)(240)))));
            this.elementStyle5.BackColorGradientAngle = 90;
            this.elementStyle5.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle5.BorderBottomWidth = 1;
            this.elementStyle5.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle5.BorderLeftWidth = 1;
            this.elementStyle5.BorderRightWidth = 1;
            this.elementStyle5.BorderTopWidth = 1;
            this.elementStyle5.CornerDiameter = 4;
            this.elementStyle5.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle5.Description = "Gray";
            this.elementStyle5.Name = "elementStyle5";
            this.elementStyle5.PaddingBottom = 1;
            this.elementStyle5.PaddingLeft = 1;
            this.elementStyle5.PaddingRight = 1;
            this.elementStyle5.PaddingTop = 1;
            this.elementStyle5.TextColor = System.Drawing.Color.Black;
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(122)))));
            // 
            // elementStyle1
            // 
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle2
            // 
            this.elementStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            this.elementStyle2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(228)))));
            this.elementStyle2.BackColorGradientAngle = 90;
            this.elementStyle2.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle2.BorderBottomWidth = 1;
            this.elementStyle2.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle2.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle2.BorderLeftWidth = 1;
            this.elementStyle2.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle2.BorderRightWidth = 1;
            this.elementStyle2.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle2.BorderTopWidth = 1;
            this.elementStyle2.CornerDiameter = 4;
            this.elementStyle2.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle2.Description = "Blue";
            this.elementStyle2.Name = "elementStyle2";
            this.elementStyle2.PaddingBottom = 1;
            this.elementStyle2.PaddingLeft = 1;
            this.elementStyle2.PaddingRight = 1;
            this.elementStyle2.PaddingTop = 1;
            this.elementStyle2.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle3
            // 
            this.elementStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.elementStyle3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(224)))), ((int)(((byte)(252)))));
            this.elementStyle3.BackColorGradientAngle = 90;
            this.elementStyle3.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle3.BorderBottomWidth = 1;
            this.elementStyle3.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle3.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle3.BorderLeftWidth = 1;
            this.elementStyle3.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle3.BorderRightWidth = 1;
            this.elementStyle3.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle3.BorderTopWidth = 1;
            this.elementStyle3.CornerDiameter = 4;
            this.elementStyle3.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle3.Description = "BlueLight";
            this.elementStyle3.Name = "elementStyle3";
            this.elementStyle3.PaddingBottom = 1;
            this.elementStyle3.PaddingLeft = 1;
            this.elementStyle3.PaddingRight = 1;
            this.elementStyle3.PaddingTop = 1;
            this.elementStyle3.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(84)))), ((int)(((byte)(115)))));
            // 
            // elementStyle4
            // 
            this.elementStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(232)))));
            this.elementStyle4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(149)))), ((int)(((byte)(170)))));
            this.elementStyle4.BackColorGradientAngle = 90;
            this.elementStyle4.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle4.BorderBottomWidth = 1;
            this.elementStyle4.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle4.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle4.BorderLeftWidth = 1;
            this.elementStyle4.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle4.BorderRightWidth = 1;
            this.elementStyle4.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle4.BorderTopWidth = 1;
            this.elementStyle4.CornerDiameter = 4;
            this.elementStyle4.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle4.Description = "Silver";
            this.elementStyle4.Name = "elementStyle4";
            this.elementStyle4.PaddingBottom = 1;
            this.elementStyle4.PaddingLeft = 1;
            this.elementStyle4.PaddingRight = 1;
            this.elementStyle4.PaddingTop = 1;
            this.elementStyle4.TextColor = System.Drawing.Color.Black;
            // 
            // collapsibleSplitContainer1
            // 
            this.collapsibleSplitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.collapsibleSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.collapsibleSplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.collapsibleSplitContainer1.ForeColor = System.Drawing.Color.Black;
            this.collapsibleSplitContainer1.Location = new System.Drawing.Point(0, 67);
            this.collapsibleSplitContainer1.Name = "collapsibleSplitContainer1";
            // 
            // collapsibleSplitContainer1.Panel1
            // 
            this.collapsibleSplitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(198)))));
            this.collapsibleSplitContainer1.Panel1.Controls.Add(this.TreeM);
            this.collapsibleSplitContainer1.Panel1.ForeColor = System.Drawing.Color.Black;
            // 
            // collapsibleSplitContainer1.Panel2
            // 
            this.collapsibleSplitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(198)))));
            this.collapsibleSplitContainer1.Panel2.Controls.Add(this.splitContainer1);
            this.collapsibleSplitContainer1.Panel2.ForeColor = System.Drawing.Color.Black;
            this.collapsibleSplitContainer1.Size = new System.Drawing.Size(961, 480);
            this.collapsibleSplitContainer1.SplitterDistance = 225;
            this.collapsibleSplitContainer1.SplitterWidth = 2;
            this.collapsibleSplitContainer1.TabIndex = 1;
            // 
            // sGrid
            // 
            this.sGrid.AllowUserToAddRows = false;
            this.sGrid.AllowUserToResizeRows = false;
            this.sGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.sGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.sGrid.ColumnHeadersHeight = 25;
            this.sGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.sGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.sGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sGrid.EnableHeadersVisualStyles = false;
            this.sGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(157)))));
            this.sGrid.HighlightSelectedColumnHeaders = false;
            this.sGrid.Location = new System.Drawing.Point(0, 0);
            this.sGrid.Name = "sGrid";
            this.sGrid.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.sGrid.RowHeadersVisible = false;
            this.sGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.sGrid.RowTemplate.Height = 23;
            this.sGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sGrid.Size = new System.Drawing.Size(486, 480);
            this.sGrid.TabIndex = 0;
            this.sGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.sGrid_RowEnter);
            // 
            // StatusBar
            // 
            this.StatusBar.AntiAlias = true;
            this.StatusBar.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
            this.StatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StatusBar.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.StatusBar.IsMaximized = false;
            this.StatusBar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblRowCount});
            this.StatusBar.Location = new System.Drawing.Point(0, 547);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(961, 22);
            this.StatusBar.Stretch = true;
            this.StatusBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.StatusBar.TabIndex = 7;
            this.StatusBar.TabStop = false;
            this.StatusBar.Text = "bar1";
            // 
            // lblRowCount
            // 
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Text = "已加载记录：0";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.sGrid);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.GridOP);
            this.splitContainer1.Size = new System.Drawing.Size(734, 480);
            this.splitContainer1.SplitterDistance = 486;
            this.splitContainer1.TabIndex = 1;
            // 
            // GridOP
            // 
            this.GridOP.AllowUserToAddRows = false;
            this.GridOP.AllowUserToResizeRows = false;
            this.GridOP.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.GridOP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GridOP.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridOP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.GridOP.ColumnHeadersHeight = 25;
            this.GridOP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridOP.DefaultCellStyle = dataGridViewCellStyle5;
            this.GridOP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridOP.EnableHeadersVisualStyles = false;
            this.GridOP.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(157)))));
            this.GridOP.HighlightSelectedColumnHeaders = false;
            this.GridOP.Location = new System.Drawing.Point(0, 0);
            this.GridOP.Name = "GridOP";
            this.GridOP.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridOP.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.GridOP.RowHeadersVisible = false;
            this.GridOP.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.GridOP.RowTemplate.Height = 23;
            this.GridOP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridOP.Size = new System.Drawing.Size(244, 480);
            this.GridOP.TabIndex = 1;
            // 
            // FmEquipmentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 569);
            this.Controls.Add(this.collapsibleSplitContainer1);
            this.Controls.Add(this.pnl_Head);
            this.Controls.Add(this.ToolBar);
            this.Controls.Add(this.StatusBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FmEquipmentList";
            this.ShowIcon = false;
            this.Text = "FmTreeGrid";
            ((System.ComponentModel.ISupportInitialize)(this.ToolBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TreeM)).EndInit();
            this.collapsibleSplitContainer1.Panel1.ResumeLayout(false);
            this.collapsibleSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.collapsibleSplitContainer1)).EndInit();
            this.collapsibleSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBar)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridOP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.ImageList imageList1;
        protected DevComponents.DotNetBar.Bar ToolBar;
        protected DevComponents.DotNetBar.ButtonItem btn_Add;
        protected DevComponents.DotNetBar.ButtonItem btn_Edit;
        protected DevComponents.DotNetBar.ButtonItem btn_Del;
        protected DevComponents.DotNetBar.ButtonItem btn_Print;
        protected DevComponents.DotNetBar.ButtonItem Btn_Export;
        protected DevComponents.DotNetBar.ButtonItem btn_Query;
        private DevComponents.DotNetBar.ButtonItem btn_PrintDesgin;
        protected DevComponents.DotNetBar.ButtonItem btn_Refresh;
        protected DevComponents.DotNetBar.ButtonItem btn_ColSetting;
        protected DevComponents.AdvTree.AdvTree TreeM;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        protected DevComponents.DotNetBar.Controls.CollapsibleSplitContainer collapsibleSplitContainer1;
        private DevComponents.DotNetBar.LabelItem lblRowCount;
        protected DevComponents.AdvTree.Node rootNode;
        protected DevComponents.DotNetBar.PanelEx pnl_Head;
        protected DevComponents.DotNetBar.Controls.DataGridViewX sGrid;
        protected DevComponents.DotNetBar.Bar StatusBar;
        private DevComponents.DotNetBar.ElementStyle elementStyle5;
        private DevComponents.DotNetBar.ElementStyle elementStyle2;
        private DevComponents.DotNetBar.ElementStyle elementStyle3;
        private DevComponents.DotNetBar.ElementStyle elementStyle4;
        private DevComponents.DotNetBar.ButtonItem BtnMP;
        private System.Windows.Forms.SplitContainer splitContainer1;
        protected DevComponents.DotNetBar.Controls.DataGridViewX GridOP;
    }
}