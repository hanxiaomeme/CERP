namespace LanyunMES.UI
{
    partial class FmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmMain));
            this.statusBarPanel5 = new System.Windows.Forms.StatusBarPanel();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel4 = new System.Windows.Forms.StatusBarPanel();
            this.tmrCurDateTime = new System.Windows.Forms.Timer(this.components);
            this.pnl_Head = new DevComponents.DotNetBar.PanelEx();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.MenuBar = new DevComponents.DotNetBar.Bar();
            this.MenuMsys = new DevComponents.DotNetBar.ButtonItem();
            this.MenuPwdMdy = new DevComponents.DotNetBar.ButtonItem();
            this.MenuSkin = new DevComponents.DotNetBar.ButtonItem();
            this.MenuExit = new DevComponents.DotNetBar.ButtonItem();
            this.MenuHelp = new DevComponents.DotNetBar.ButtonItem();
            this.MenuHelpConent = new DevComponents.DotNetBar.ButtonItem();
            this.MenuAbout = new DevComponents.DotNetBar.ButtonItem();
            this.cb_showMenu = new DevComponents.DotNetBar.CheckBoxItem();
            this.pnl_Center = new DevComponents.DotNetBar.PanelEx();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TreeMenu = new DevComponents.AdvTree.AdvTree();
            this.RootNode = new DevComponents.AdvTree.Node();
            this.elementStyle10 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle2 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle3 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle4 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle5 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle6 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle7 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle8 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle9 = new DevComponents.DotNetBar.ElementStyle();
            this.TabCtlMain = new DevComponents.DotNetBar.SuperTabControl();
            this.tabMainPnl = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.tabMain = new DevComponents.DotNetBar.SuperTabItem();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuBar)).BeginInit();
            this.pnl_Center.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabCtlMain)).BeginInit();
            this.TabCtlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBarPanel5
            // 
            this.statusBarPanel5.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.statusBarPanel5.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.statusBarPanel5.Name = "statusBarPanel5";
            this.statusBarPanel5.Text = "显示时间";
            this.statusBarPanel5.Width = 64;
            // 
            // statusBar
            // 
            this.statusBar.ForeColor = System.Drawing.Color.Black;
            this.statusBar.Location = new System.Drawing.Point(0, 672);
            this.statusBar.Name = "statusBar";
            this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3,
            this.statusBarPanel4,
            this.statusBarPanel5});
            this.statusBar.ShowPanels = true;
            this.statusBar.Size = new System.Drawing.Size(1341, 24);
            this.statusBar.TabIndex = 0;
            this.statusBar.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Text = "就绪";
            this.statusBarPanel1.Width = 1037;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.statusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Text = "单位名称";
            this.statusBarPanel2.Width = 64;
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.statusBarPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Text = "用户:系统用户";
            this.statusBarPanel3.Width = 95;
            // 
            // statusBarPanel4
            // 
            this.statusBarPanel4.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.statusBarPanel4.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.statusBarPanel4.Name = "statusBarPanel4";
            this.statusBarPanel4.Text = "业务日期";
            this.statusBarPanel4.Width = 64;
            // 
            // tmrCurDateTime
            // 
            this.tmrCurDateTime.Enabled = true;
            this.tmrCurDateTime.Interval = 1000;
            this.tmrCurDateTime.Tick += new System.EventHandler(this.tmrCurDateTime_Tick);
            // 
            // pnl_Head
            // 
            this.pnl_Head.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnl_Head.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnl_Head.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnl_Head.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Head.Location = new System.Drawing.Point(0, 26);
            this.pnl_Head.Name = "pnl_Head";
            this.pnl_Head.Size = new System.Drawing.Size(1341, 66);
            this.pnl_Head.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnl_Head.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnl_Head.Style.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnl_Head.Style.BackgroundImage")));
            this.pnl_Head.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnl_Head.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
            this.pnl_Head.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnl_Head.Style.GradientAngle = 90;
            this.pnl_Head.TabIndex = 10;
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // MenuBar
            // 
            this.MenuBar.AccessibleDescription = "DotNetBar Bar (MenuBar)";
            this.MenuBar.AccessibleName = "DotNetBar Bar";
            this.MenuBar.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.MenuBar.AntiAlias = true;
            this.MenuBar.BarType = DevComponents.DotNetBar.eBarType.MenuBar;
            this.MenuBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuBar.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MenuBar.IsMaximized = false;
            this.MenuBar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.MenuMsys,
            this.MenuHelp,
            this.cb_showMenu});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.MenuBar = true;
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(1341, 26);
            this.MenuBar.Stretch = true;
            this.MenuBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.MenuBar.TabIndex = 12;
            this.MenuBar.TabStop = false;
            this.MenuBar.Text = "bar1";
            // 
            // MenuMsys
            // 
            this.MenuMsys.Name = "MenuMsys";
            this.MenuMsys.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.MenuPwdMdy,
            this.MenuSkin,
            this.MenuExit});
            this.MenuMsys.Text = "系统(&S)";
            // 
            // MenuPwdMdy
            // 
            this.MenuPwdMdy.BeginGroup = true;
            this.MenuPwdMdy.Name = "MenuPwdMdy";
            this.MenuPwdMdy.Text = "修改密码(&P)";
            this.MenuPwdMdy.Visible = false;
            this.MenuPwdMdy.Click += new System.EventHandler(this.mnuItmMdyPwd_Click);
            // 
            // MenuSkin
            // 
            this.MenuSkin.Name = "MenuSkin";
            this.MenuSkin.Text = "系统主题";
            // 
            // MenuExit
            // 
            this.MenuExit.BeginGroup = true;
            this.MenuExit.Name = "MenuExit";
            this.MenuExit.Text = "退出(&X)";
            this.MenuExit.Click += new System.EventHandler(this.mnuItmExit_Click);
            // 
            // MenuHelp
            // 
            this.MenuHelp.Name = "MenuHelp";
            this.MenuHelp.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.MenuHelpConent,
            this.MenuAbout});
            this.MenuHelp.Text = "帮助(&H)";
            // 
            // MenuHelpConent
            // 
            this.MenuHelpConent.Name = "MenuHelpConent";
            this.MenuHelpConent.Text = "帮助";
            this.MenuHelpConent.Click += new System.EventHandler(this.mnuItmHelpContent_Click);
            // 
            // MenuAbout
            // 
            this.MenuAbout.Name = "MenuAbout";
            this.MenuAbout.Text = "关于";
            this.MenuAbout.Click += new System.EventHandler(this.mnuItmAbout_Click);
            // 
            // cb_showMenu
            // 
            this.cb_showMenu.Checked = true;
            this.cb_showMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_showMenu.Name = "cb_showMenu";
            this.cb_showMenu.Text = "功能菜单";
            this.cb_showMenu.TextColor = System.Drawing.Color.SteelBlue;
            this.cb_showMenu.CheckedChanged += new DevComponents.DotNetBar.CheckBoxChangeEventHandler(this.cb_showMenu_CheckedChanged);
            // 
            // pnl_Center
            // 
            this.pnl_Center.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnl_Center.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnl_Center.Controls.Add(this.splitContainer1);
            this.pnl_Center.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnl_Center.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Center.Location = new System.Drawing.Point(0, 92);
            this.pnl_Center.Name = "pnl_Center";
            this.pnl_Center.Padding = new System.Windows.Forms.Padding(3);
            this.pnl_Center.Size = new System.Drawing.Size(1341, 580);
            this.pnl_Center.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnl_Center.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnl_Center.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnl_Center.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnl_Center.Style.GradientAngle = 90;
            this.pnl_Center.TabIndex = 19;
            this.pnl_Center.Text = "panelEx1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.ForeColor = System.Drawing.Color.Black;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TreeMenu);
            this.splitContainer1.Panel1.ForeColor = System.Drawing.Color.Black;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TabCtlMain);
            this.splitContainer1.Panel2.ForeColor = System.Drawing.Color.Black;
            this.splitContainer1.Size = new System.Drawing.Size(1335, 574);
            this.splitContainer1.SplitterDistance = 213;
            this.splitContainer1.TabIndex = 17;
            // 
            // TreeMenu
            // 
            this.TreeMenu.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.TreeMenu.AllowDrop = true;
            this.TreeMenu.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.TreeMenu.BackgroundStyle.Class = "TreeBorderKey";
            this.TreeMenu.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TreeMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeMenu.ExpandBackColor = System.Drawing.Color.White;
            this.TreeMenu.ExpandButtonType = DevComponents.AdvTree.eExpandButtonType.Triangle;
            this.TreeMenu.ForeColor = System.Drawing.Color.Black;
            this.TreeMenu.Location = new System.Drawing.Point(0, 0);
            this.TreeMenu.Name = "TreeMenu";
            this.TreeMenu.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.RootNode});
            this.TreeMenu.NodeSpacing = 22;
            this.TreeMenu.NodeStyle = this.elementStyle1;
            this.TreeMenu.PathSeparator = ";";
            this.TreeMenu.Size = new System.Drawing.Size(213, 574);
            this.TreeMenu.Styles.Add(this.elementStyle1);
            this.TreeMenu.Styles.Add(this.elementStyle2);
            this.TreeMenu.Styles.Add(this.elementStyle3);
            this.TreeMenu.Styles.Add(this.elementStyle4);
            this.TreeMenu.Styles.Add(this.elementStyle5);
            this.TreeMenu.Styles.Add(this.elementStyle6);
            this.TreeMenu.Styles.Add(this.elementStyle7);
            this.TreeMenu.Styles.Add(this.elementStyle8);
            this.TreeMenu.Styles.Add(this.elementStyle9);
            this.TreeMenu.Styles.Add(this.elementStyle10);
            this.TreeMenu.TabIndex = 1;
            this.TreeMenu.Text = "advTree1";
            // 
            // RootNode
            // 
            this.RootNode.Expanded = true;
            this.RootNode.ExpandVisibility = DevComponents.AdvTree.eNodeExpandVisibility.Hidden;
            this.RootNode.FullRowBackground = true;
            this.RootNode.Name = "RootNode";
            this.RootNode.Style = this.elementStyle10;
            this.RootNode.Text = "功能菜单";
            // 
            // elementStyle10
            // 
            this.elementStyle10.BackColor = System.Drawing.Color.White;
            this.elementStyle10.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(228)))), ((int)(((byte)(240)))));
            this.elementStyle10.BackColorGradientAngle = 90;
            this.elementStyle10.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle10.BorderBottomWidth = 1;
            this.elementStyle10.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle10.BorderLeftWidth = 1;
            this.elementStyle10.BorderRightWidth = 1;
            this.elementStyle10.BorderTopWidth = 1;
            this.elementStyle10.CornerDiameter = 4;
            this.elementStyle10.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle10.Description = "Gray";
            this.elementStyle10.Name = "elementStyle10";
            this.elementStyle10.PaddingBottom = 1;
            this.elementStyle10.PaddingLeft = 1;
            this.elementStyle10.PaddingRight = 1;
            this.elementStyle10.PaddingTop = 1;
            this.elementStyle10.TextColor = System.Drawing.Color.Black;
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
            this.elementStyle3.BorderBottomWidth = 1;
            this.elementStyle3.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle3.BorderLeftWidth = 1;
            this.elementStyle3.BorderRightWidth = 1;
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
            this.elementStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.elementStyle4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(153)))), ((int)(((byte)(183)))));
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
            this.elementStyle4.Description = "SilverMist";
            this.elementStyle4.Name = "elementStyle4";
            this.elementStyle4.PaddingBottom = 1;
            this.elementStyle4.PaddingLeft = 1;
            this.elementStyle4.PaddingRight = 1;
            this.elementStyle4.PaddingTop = 1;
            this.elementStyle4.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(86)))), ((int)(((byte)(113)))));
            // 
            // elementStyle5
            // 
            this.elementStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(253)))), ((int)(((byte)(215)))));
            this.elementStyle5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(249)))), ((int)(((byte)(111)))));
            this.elementStyle5.BackColorGradientAngle = 90;
            this.elementStyle5.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle5.BorderBottomWidth = 1;
            this.elementStyle5.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle5.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle5.BorderLeftWidth = 1;
            this.elementStyle5.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle5.BorderRightWidth = 1;
            this.elementStyle5.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle5.BorderTopWidth = 1;
            this.elementStyle5.CornerDiameter = 4;
            this.elementStyle5.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle5.Description = "Lemon";
            this.elementStyle5.Name = "elementStyle5";
            this.elementStyle5.PaddingBottom = 1;
            this.elementStyle5.PaddingLeft = 1;
            this.elementStyle5.PaddingRight = 1;
            this.elementStyle5.PaddingTop = 1;
            this.elementStyle5.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle6
            // 
            this.elementStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(232)))));
            this.elementStyle6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(149)))), ((int)(((byte)(170)))));
            this.elementStyle6.BackColorGradientAngle = 90;
            this.elementStyle6.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle6.BorderBottomWidth = 1;
            this.elementStyle6.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle6.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle6.BorderLeftWidth = 1;
            this.elementStyle6.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle6.BorderRightWidth = 1;
            this.elementStyle6.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle6.BorderTopWidth = 1;
            this.elementStyle6.CornerDiameter = 4;
            this.elementStyle6.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle6.Description = "Silver";
            this.elementStyle6.Name = "elementStyle6";
            this.elementStyle6.PaddingBottom = 1;
            this.elementStyle6.PaddingLeft = 1;
            this.elementStyle6.PaddingRight = 1;
            this.elementStyle6.PaddingTop = 1;
            this.elementStyle6.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle7
            // 
            this.elementStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.elementStyle7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(153)))), ((int)(((byte)(183)))));
            this.elementStyle7.BackColorGradientAngle = 90;
            this.elementStyle7.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle7.BorderBottomWidth = 1;
            this.elementStyle7.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle7.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle7.BorderLeftWidth = 1;
            this.elementStyle7.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle7.BorderRightWidth = 1;
            this.elementStyle7.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle7.BorderTopWidth = 1;
            this.elementStyle7.CornerDiameter = 4;
            this.elementStyle7.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle7.Description = "SilverMist";
            this.elementStyle7.Name = "elementStyle7";
            this.elementStyle7.PaddingBottom = 1;
            this.elementStyle7.PaddingLeft = 1;
            this.elementStyle7.PaddingRight = 1;
            this.elementStyle7.PaddingTop = 1;
            this.elementStyle7.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(86)))), ((int)(((byte)(113)))));
            // 
            // elementStyle8
            // 
            this.elementStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(232)))));
            this.elementStyle8.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(149)))), ((int)(((byte)(170)))));
            this.elementStyle8.BackColorGradientAngle = 90;
            this.elementStyle8.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle8.BorderBottomWidth = 1;
            this.elementStyle8.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle8.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle8.BorderLeftWidth = 1;
            this.elementStyle8.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle8.BorderRightWidth = 1;
            this.elementStyle8.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle8.BorderTopWidth = 1;
            this.elementStyle8.CornerDiameter = 4;
            this.elementStyle8.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle8.Description = "Silver";
            this.elementStyle8.Name = "elementStyle8";
            this.elementStyle8.PaddingBottom = 1;
            this.elementStyle8.PaddingLeft = 1;
            this.elementStyle8.PaddingRight = 1;
            this.elementStyle8.PaddingTop = 1;
            this.elementStyle8.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle9
            // 
            this.elementStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(232)))));
            this.elementStyle9.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(149)))), ((int)(((byte)(170)))));
            this.elementStyle9.BackColorGradientAngle = 90;
            this.elementStyle9.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle9.BorderBottomWidth = 1;
            this.elementStyle9.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle9.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle9.BorderLeftWidth = 1;
            this.elementStyle9.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle9.BorderRightWidth = 1;
            this.elementStyle9.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle9.BorderTopWidth = 1;
            this.elementStyle9.CornerDiameter = 4;
            this.elementStyle9.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle9.Description = "Silver";
            this.elementStyle9.Name = "elementStyle9";
            this.elementStyle9.PaddingBottom = 1;
            this.elementStyle9.PaddingLeft = 1;
            this.elementStyle9.PaddingRight = 1;
            this.elementStyle9.PaddingTop = 1;
            this.elementStyle9.TextColor = System.Drawing.Color.Black;
            // 
            // TabCtlMain
            // 
            this.TabCtlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TabCtlMain.CloseButtonOnTabsVisible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.TabCtlMain.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.TabCtlMain.ControlBox.MenuBox.Name = "";
            this.TabCtlMain.ControlBox.Name = "";
            this.TabCtlMain.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.TabCtlMain.ControlBox.MenuBox,
            this.TabCtlMain.ControlBox.CloseBox});
            this.TabCtlMain.Controls.Add(this.tabMainPnl);
            this.TabCtlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabCtlMain.ForeColor = System.Drawing.Color.Black;
            this.TabCtlMain.Location = new System.Drawing.Point(0, 0);
            this.TabCtlMain.Name = "TabCtlMain";
            this.TabCtlMain.ReorderTabsEnabled = true;
            this.TabCtlMain.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.TabCtlMain.SelectedTabIndex = 2;
            this.TabCtlMain.Size = new System.Drawing.Size(1118, 574);
            this.TabCtlMain.TabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabCtlMain.TabIndex = 6;
            this.TabCtlMain.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tabMain});
            this.TabCtlMain.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue;
            this.TabCtlMain.TabVerticalSpacing = 3;
            // 
            // tabMainPnl
            // 
            this.tabMainPnl.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.tabMainPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMainPnl.Location = new System.Drawing.Point(0, 24);
            this.tabMainPnl.Name = "tabMainPnl";
            this.tabMainPnl.Size = new System.Drawing.Size(1118, 550);
            this.tabMainPnl.TabIndex = 0;
            this.tabMainPnl.TabItem = this.tabMain;
            // 
            // tabMain
            // 
            this.tabMain.AttachedControl = this.tabMainPnl;
            this.tabMain.CloseButtonVisible = false;
            this.tabMain.GlobalItem = false;
            this.tabMain.Name = "tabMain";
            this.tabMain.Text = "主界面";
            // 
            // FmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1341, 696);
            this.Controls.Add(this.pnl_Center);
            this.Controls.Add(this.pnl_Head);
            this.Controls.Add(this.MenuBar);
            this.Controls.Add(this.statusBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "FmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生产执行管理系统";
            this.TransparencyKey = System.Drawing.Color.White;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FmMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuBar)).EndInit();
            this.pnl_Center.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TreeMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabCtlMain)).EndInit();
            this.TabCtlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusBarPanel statusBarPanel5;
        private System.Windows.Forms.StatusBar statusBar;
        private System.Windows.Forms.StatusBarPanel statusBarPanel3;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.Timer tmrCurDateTime;
        private System.Windows.Forms.StatusBarPanel statusBarPanel4;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private DevComponents.DotNetBar.PanelEx pnl_Head;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.Bar MenuBar;
        private DevComponents.DotNetBar.ButtonItem MenuPwdMdy;
        private DevComponents.DotNetBar.ButtonItem MenuSkin;
        private DevComponents.DotNetBar.ButtonItem MenuExit;
        private DevComponents.DotNetBar.ButtonItem MenuHelpConent;
        private DevComponents.DotNetBar.ButtonItem MenuAbout;
        public DevComponents.DotNetBar.ButtonItem MenuMsys;
        public DevComponents.DotNetBar.ButtonItem MenuHelp;
        private DevComponents.DotNetBar.PanelEx pnl_Center;
        private DevComponents.DotNetBar.CheckBoxItem cb_showMenu;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.AdvTree.AdvTree TreeMenu;
        private DevComponents.AdvTree.Node RootNode;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.ElementStyle elementStyle2;
        private DevComponents.DotNetBar.ElementStyle elementStyle3;
        private DevComponents.DotNetBar.ElementStyle elementStyle4;
        private DevComponents.DotNetBar.SuperTabControl TabCtlMain;
        private DevComponents.DotNetBar.SuperTabControlPanel tabMainPnl;
        private DevComponents.DotNetBar.SuperTabItem tabMain;
        private DevComponents.DotNetBar.ElementStyle elementStyle5;
        private DevComponents.DotNetBar.ElementStyle elementStyle6;
        private DevComponents.DotNetBar.ElementStyle elementStyle7;
        private DevComponents.DotNetBar.ElementStyle elementStyle10;
        private DevComponents.DotNetBar.ElementStyle elementStyle8;
        private DevComponents.DotNetBar.ElementStyle elementStyle9;
    }
}