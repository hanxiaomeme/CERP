namespace LanyunMES.UI
{
    partial class FmRClassInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmRClassInfo));
            this.lblModuleTitle = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.Head_Bar = new DevComponents.DotNetBar.Bar();
            this.btn_Return = new DevComponents.DotNetBar.ButtonItem();
            this.btn_Exit = new DevComponents.DotNetBar.ButtonItem();
            this.Main_pnl = new DevComponents.DotNetBar.PanelEx();
            this.TreeM = new DevComponents.AdvTree.AdvTree();
            this.rootNode = new DevComponents.AdvTree.Node();
            this.elementStyle5 = new DevComponents.DotNetBar.ElementStyle();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle2 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle3 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle4 = new DevComponents.DotNetBar.ElementStyle();
            this.Status_Bar = new DevComponents.DotNetBar.Bar();
            this.lbl_status = new DevComponents.DotNetBar.LabelItem();
            ((System.ComponentModel.ISupportInitialize)(this.Head_Bar)).BeginInit();
            this.Main_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Status_Bar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblModuleTitle
            // 
            this.lblModuleTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblModuleTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblModuleTitle.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblModuleTitle.ForeColor = System.Drawing.Color.Black;
            this.lblModuleTitle.Location = new System.Drawing.Point(0, 0);
            this.lblModuleTitle.Name = "lblModuleTitle";
            this.lblModuleTitle.Size = new System.Drawing.Size(433, 35);
            this.lblModuleTitle.TabIndex = 0;
            this.lblModuleTitle.Text = "分类名称";
            this.lblModuleTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "book.png");
            this.imageList1.Images.SetKeyName(1, "out.png");
            this.imageList1.Images.SetKeyName(2, "pen.png");
            this.imageList1.Images.SetKeyName(3, "refresh.png");
            this.imageList1.Images.SetKeyName(4, "trash.png");
            this.imageList1.Images.SetKeyName(5, "check.png");
            // 
            // Head_Bar
            // 
            this.Head_Bar.AntiAlias = true;
            this.Head_Bar.Dock = System.Windows.Forms.DockStyle.Top;
            this.Head_Bar.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Head_Bar.Images = this.imageList1;
            this.Head_Bar.IsMaximized = false;
            this.Head_Bar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_Return,
            this.btn_Exit});
            this.Head_Bar.Location = new System.Drawing.Point(0, 0);
            this.Head_Bar.Name = "Head_Bar";
            this.Head_Bar.Size = new System.Drawing.Size(433, 45);
            this.Head_Bar.Stretch = true;
            this.Head_Bar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Head_Bar.TabIndex = 1;
            this.Head_Bar.TabStop = false;
            this.Head_Bar.Text = "bar1";
            // 
            // btn_Return
            // 
            this.btn_Return.ImageIndex = 5;
            this.btn_Return.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_Return.Name = "btn_Return";
            this.btn_Return.Text = "选择";
            // 
            // btn_Exit
            // 
            this.btn_Exit.ImageIndex = 1;
            this.btn_Exit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Text = "退出";
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // Main_pnl
            // 
            this.Main_pnl.CanvasColor = System.Drawing.SystemColors.Control;
            this.Main_pnl.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Main_pnl.Controls.Add(this.TreeM);
            this.Main_pnl.Controls.Add(this.lblModuleTitle);
            this.Main_pnl.DisabledBackColor = System.Drawing.Color.Empty;
            this.Main_pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_pnl.Location = new System.Drawing.Point(0, 45);
            this.Main_pnl.Name = "Main_pnl";
            this.Main_pnl.Size = new System.Drawing.Size(433, 438);
            this.Main_pnl.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.Main_pnl.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.Main_pnl.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.Main_pnl.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.Main_pnl.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.Main_pnl.Style.GradientAngle = 90;
            this.Main_pnl.TabIndex = 0;
            this.Main_pnl.Text = "panelEx1";
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
            this.TreeM.Location = new System.Drawing.Point(0, 35);
            this.TreeM.Name = "TreeM";
            this.TreeM.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.rootNode});
            this.TreeM.NodesConnector = this.nodeConnector1;
            this.TreeM.NodeStyle = this.elementStyle1;
            this.TreeM.PathSeparator = ";";
            this.TreeM.Size = new System.Drawing.Size(433, 403);
            this.TreeM.Styles.Add(this.elementStyle1);
            this.TreeM.Styles.Add(this.elementStyle2);
            this.TreeM.Styles.Add(this.elementStyle3);
            this.TreeM.Styles.Add(this.elementStyle4);
            this.TreeM.Styles.Add(this.elementStyle5);
            this.TreeM.TabIndex = 3;
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
            // Status_Bar
            // 
            this.Status_Bar.AntiAlias = true;
            this.Status_Bar.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
            this.Status_Bar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Status_Bar.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Status_Bar.IsMaximized = false;
            this.Status_Bar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lbl_status});
            this.Status_Bar.Location = new System.Drawing.Point(0, 483);
            this.Status_Bar.Name = "Status_Bar";
            this.Status_Bar.Size = new System.Drawing.Size(433, 22);
            this.Status_Bar.Stretch = true;
            this.Status_Bar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Status_Bar.TabIndex = 0;
            this.Status_Bar.TabStop = false;
            this.Status_Bar.Text = "bar1";
            // 
            // lbl_status
            // 
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Text = "--";
            // 
            // FmRClassInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 505);
            this.Controls.Add(this.Main_pnl);
            this.Controls.Add(this.Head_Bar);
            this.Controls.Add(this.Status_Bar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FmRClassInfo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FmBIU";
            ((System.ComponentModel.ISupportInitialize)(this.Head_Bar)).EndInit();
            this.Main_pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TreeM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Status_Bar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label lblModuleTitle;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.ButtonItem btn_Return;
        private DevComponents.DotNetBar.ButtonItem btn_Exit;
        private DevComponents.DotNetBar.LabelItem lbl_status;
        protected DevComponents.DotNetBar.Bar Head_Bar;
        protected DevComponents.DotNetBar.Bar Status_Bar;
        protected DevComponents.DotNetBar.PanelEx Main_pnl;
        protected DevComponents.AdvTree.AdvTree TreeM;
        protected DevComponents.AdvTree.Node rootNode;
        private DevComponents.DotNetBar.ElementStyle elementStyle5;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.ElementStyle elementStyle2;
        private DevComponents.DotNetBar.ElementStyle elementStyle3;
        private DevComponents.DotNetBar.ElementStyle elementStyle4;
    }
}