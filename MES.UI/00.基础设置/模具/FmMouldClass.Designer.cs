namespace LanyunMES.UI
{
    partial class FmMouldClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmMouldClass));
            this.ToolBar = new DevComponents.DotNetBar.Bar();
            this.btn_Add = new DevComponents.DotNetBar.ButtonItem();
            this.btn_Edit = new DevComponents.DotNetBar.ButtonItem();
            this.btn_Del = new DevComponents.DotNetBar.ButtonItem();
            this.btn_Refresh = new DevComponents.DotNetBar.ButtonItem();
            this.pnl_Head = new DevComponents.DotNetBar.PanelEx();
            this.collapsibleSplitContainer1 = new DevComponents.DotNetBar.Controls.CollapsibleSplitContainer();
            this.TreeM = new DevComponents.AdvTree.AdvTree();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.rootNode = new DevComponents.AdvTree.Node();
            this.elementStyle5 = new DevComponents.DotNetBar.ElementStyle();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle2 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle3 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle4 = new DevComponents.DotNetBar.ElementStyle();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btn_Cancel = new DevComponents.DotNetBar.ButtonX();
            this.btn_Save = new DevComponents.DotNetBar.ButtonX();
            this.txt_CName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_CCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lbl_cName = new DevComponents.DotNetBar.LabelX();
            this.lbl_cCode = new DevComponents.DotNetBar.LabelX();
            this.StatusBar = new DevComponents.DotNetBar.Bar();
            this.lblRowCount = new DevComponents.DotNetBar.LabelItem();
            ((System.ComponentModel.ISupportInitialize)(this.ToolBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.collapsibleSplitContainer1)).BeginInit();
            this.collapsibleSplitContainer1.Panel1.SuspendLayout();
            this.collapsibleSplitContainer1.Panel2.SuspendLayout();
            this.collapsibleSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeM)).BeginInit();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBar)).BeginInit();
            this.SuspendLayout();
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
            this.btn_Refresh});
            this.ToolBar.Location = new System.Drawing.Point(0, 0);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.Size = new System.Drawing.Size(892, 27);
            this.ToolBar.Stretch = true;
            this.ToolBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ToolBar.TabIndex = 7;
            this.ToolBar.TabStop = false;
            this.ToolBar.Text = "ToolBar";
            // 
            // btn_Add
            // 
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Text = "新增";
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Edit
            // 
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Text = "编辑";
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // btn_Del
            // 
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Text = "删除";
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.BeginGroup = true;
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Text = "刷新";
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
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
            this.pnl_Head.Size = new System.Drawing.Size(892, 40);
            this.pnl_Head.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnl_Head.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnl_Head.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnl_Head.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnl_Head.Style.BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.pnl_Head.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
            this.pnl_Head.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnl_Head.Style.GradientAngle = 90;
            this.pnl_Head.TabIndex = 11;
            this.pnl_Head.Text = "模具分类";
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
            this.collapsibleSplitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.collapsibleSplitContainer1.Panel2.Controls.Add(this.panelEx1);
            this.collapsibleSplitContainer1.Panel2.ForeColor = System.Drawing.Color.Black;
            this.collapsibleSplitContainer1.Size = new System.Drawing.Size(892, 471);
            this.collapsibleSplitContainer1.SplitterDistance = 250;
            this.collapsibleSplitContainer1.SplitterWidth = 2;
            this.collapsibleSplitContainer1.TabIndex = 12;
            // 
            // TreeM
            // 
            this.TreeM.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.TreeM.AllowDrop = true;
            this.TreeM.AllowExternalDrop = false;
            this.TreeM.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.TreeM.BackgroundStyle.Class = "TreeBorderKey";
            this.TreeM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TreeM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeM.DragDropEnabled = false;
            this.TreeM.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TreeM.ForeColor = System.Drawing.Color.Black;
            this.TreeM.ImageList = this.imageList1;
            this.TreeM.Location = new System.Drawing.Point(0, 0);
            this.TreeM.Name = "TreeM";
            this.TreeM.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.rootNode});
            this.TreeM.NodesConnector = this.nodeConnector1;
            this.TreeM.NodeStyle = this.elementStyle1;
            this.TreeM.PathSeparator = ";";
            this.TreeM.Size = new System.Drawing.Size(250, 471);
            this.TreeM.Styles.Add(this.elementStyle1);
            this.TreeM.Styles.Add(this.elementStyle2);
            this.TreeM.Styles.Add(this.elementStyle3);
            this.TreeM.Styles.Add(this.elementStyle4);
            this.TreeM.Styles.Add(this.elementStyle5);
            this.TreeM.TabIndex = 1;
            this.TreeM.Text = "advTree1";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "next.gif");
            this.imageList1.Images.SetKeyName(1, "last.gif");
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
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btn_Cancel);
            this.panelEx1.Controls.Add(this.btn_Save);
            this.panelEx1.Controls.Add(this.txt_CName);
            this.panelEx1.Controls.Add(this.txt_CCode);
            this.panelEx1.Controls.Add(this.lbl_cName);
            this.panelEx1.Controls.Add(this.lbl_cCode);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(640, 471);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.Etched;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Cancel.Location = new System.Drawing.Point(128, 241);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(60, 23);
            this.btn_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.Text = "取 消";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Save.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Save.Location = new System.Drawing.Point(253, 241);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(60, 23);
            this.btn_Save.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "保 存";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txt_CName
            // 
            this.txt_CName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_CName.Border.Class = "TextBoxBorder";
            this.txt_CName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_CName.DisabledBackColor = System.Drawing.Color.White;
            this.txt_CName.ForeColor = System.Drawing.Color.Black;
            this.txt_CName.Location = new System.Drawing.Point(128, 126);
            this.txt_CName.Name = "txt_CName";
            this.txt_CName.PreventEnterBeep = true;
            this.txt_CName.Size = new System.Drawing.Size(185, 21);
            this.txt_CName.TabIndex = 3;
            // 
            // txt_CCode
            // 
            this.txt_CCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_CCode.Border.Class = "TextBoxBorder";
            this.txt_CCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_CCode.DisabledBackColor = System.Drawing.Color.White;
            this.txt_CCode.ForeColor = System.Drawing.Color.Black;
            this.txt_CCode.Location = new System.Drawing.Point(128, 85);
            this.txt_CCode.Name = "txt_CCode";
            this.txt_CCode.PreventEnterBeep = true;
            this.txt_CCode.Size = new System.Drawing.Size(185, 21);
            this.txt_CCode.TabIndex = 2;
            // 
            // lbl_cName
            // 
            // 
            // 
            // 
            this.lbl_cName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_cName.Location = new System.Drawing.Point(78, 128);
            this.lbl_cName.Name = "lbl_cName";
            this.lbl_cName.Size = new System.Drawing.Size(75, 23);
            this.lbl_cName.TabIndex = 1;
            this.lbl_cName.Text = "名称：";
            // 
            // lbl_cCode
            // 
            // 
            // 
            // 
            this.lbl_cCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_cCode.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cCode.Location = new System.Drawing.Point(78, 85);
            this.lbl_cCode.Name = "lbl_cCode";
            this.lbl_cCode.Size = new System.Drawing.Size(75, 23);
            this.lbl_cCode.TabIndex = 0;
            this.lbl_cCode.Text = "编码：";
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
            this.StatusBar.Location = new System.Drawing.Point(0, 538);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(892, 22);
            this.StatusBar.Stretch = true;
            this.StatusBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.StatusBar.TabIndex = 13;
            this.StatusBar.TabStop = false;
            this.StatusBar.Text = "bar1";
            // 
            // lblRowCount
            // 
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Text = "已加载记录：0";
            // 
            // FmMouldClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 560);
            this.Controls.Add(this.collapsibleSplitContainer1);
            this.Controls.Add(this.pnl_Head);
            this.Controls.Add(this.ToolBar);
            this.Controls.Add(this.StatusBar);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FmMouldClass";
            this.ShowIcon = false;
            this.Text = "MetroForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FmTreeClass_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ToolBar)).EndInit();
            this.collapsibleSplitContainer1.Panel1.ResumeLayout(false);
            this.collapsibleSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.collapsibleSplitContainer1)).EndInit();
            this.collapsibleSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TreeM)).EndInit();
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StatusBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevComponents.DotNetBar.Bar ToolBar;
        protected DevComponents.DotNetBar.ButtonItem btn_Add;
        protected DevComponents.DotNetBar.ButtonItem btn_Edit;
        protected DevComponents.DotNetBar.ButtonItem btn_Del;
        protected DevComponents.DotNetBar.ButtonItem btn_Refresh;
        protected DevComponents.DotNetBar.PanelEx pnl_Head;
        protected DevComponents.DotNetBar.Controls.CollapsibleSplitContainer collapsibleSplitContainer1;
        protected DevComponents.AdvTree.AdvTree TreeM;
        protected DevComponents.AdvTree.Node rootNode;
        private DevComponents.DotNetBar.ElementStyle elementStyle5;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.ElementStyle elementStyle2;
        private DevComponents.DotNetBar.ElementStyle elementStyle3;
        private DevComponents.DotNetBar.ElementStyle elementStyle4;
        protected DevComponents.DotNetBar.Bar StatusBar;
        private DevComponents.DotNetBar.LabelItem lblRowCount;
        protected DevComponents.DotNetBar.PanelEx panelEx1;
        protected DevComponents.DotNetBar.Controls.TextBoxX txt_CName;
        protected DevComponents.DotNetBar.Controls.TextBoxX txt_CCode;
        protected DevComponents.DotNetBar.LabelX lbl_cName;
        protected DevComponents.DotNetBar.LabelX lbl_cCode;
        private DevComponents.DotNetBar.ButtonX btn_Save;
        protected System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.ButtonX btn_Cancel;
    }
}