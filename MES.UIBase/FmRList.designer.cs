namespace LanyunMES.UIBase
{
    partial class FmRList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ToolBar = new DevComponents.DotNetBar.Bar();
            this.btn_Export = new DevComponents.DotNetBar.ButtonItem();
            this.btn_Reflash = new DevComponents.DotNetBar.ButtonItem();
            this.StatusBar = new DevComponents.DotNetBar.Bar();
            this.sBar_lbl = new DevComponents.DotNetBar.LabelItem();
            this.btn_Query = new DevComponents.DotNetBar.ButtonX();
            this.DGX = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.pnlFooter = new DevComponents.DotNetBar.PanelEx();
            this.lblSumFoot = new DevComponents.DotNetBar.LabelX();
            this.lblSum = new DevComponents.DotNetBar.LabelX();
            this.group1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.group2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.pnl_title = new DevComponents.DotNetBar.PanelEx();
            ((System.ComponentModel.ISupportInitialize)(this.ToolBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGX)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.group1.SuspendLayout();
            this.group2.SuspendLayout();
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
            this.btn_Reflash});
            this.ToolBar.Location = new System.Drawing.Point(0, 0);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.Size = new System.Drawing.Size(996, 27);
            this.ToolBar.Stretch = true;
            this.ToolBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ToolBar.TabIndex = 0;
            this.ToolBar.TabStop = false;
            this.ToolBar.Text = "bar1";
            // 
            // btn_Export
            // 
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Text = "导出(&D)";
            // 
            // btn_Reflash
            // 
            this.btn_Reflash.Name = "btn_Reflash";
            this.btn_Reflash.Text = "刷新(&R)";
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
            this.StatusBar.Location = new System.Drawing.Point(0, 566);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(996, 22);
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
            // btn_Query
            // 
            this.btn_Query.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Query.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Query.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Query.Location = new System.Drawing.Point(96, 453);
            this.btn_Query.MaximumSize = new System.Drawing.Size(50, 50);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(50, 25);
            this.btn_Query.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_Query.TabIndex = 0;
            this.btn_Query.Text = "查 询";
            // 
            // DGX
            // 
            this.DGX.AllowUserToAddRows = false;
            this.DGX.AllowUserToDeleteRows = false;
            this.DGX.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DGX.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DGX.BackgroundColor = System.Drawing.Color.White;
            this.DGX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGX.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DGX.ColumnHeadersHeight = 25;
            this.DGX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGX.DefaultCellStyle = dataGridViewCellStyle7;
            this.DGX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGX.EnableHeadersVisualStyles = false;
            this.DGX.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.DGX.HighlightSelectedColumnHeaders = false;
            this.DGX.Location = new System.Drawing.Point(0, 0);
            this.DGX.Margin = new System.Windows.Forms.Padding(5);
            this.DGX.Name = "DGX";
            this.DGX.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGX.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.DGX.RowHeadersVisible = false;
            this.DGX.RowTemplate.Height = 23;
            this.DGX.SelectAllSignVisible = false;
            this.DGX.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGX.Size = new System.Drawing.Size(716, 456);
            this.DGX.TabIndex = 6;
            // 
            // pnlFooter
            // 
            this.pnlFooter.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlFooter.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlFooter.Controls.Add(this.lblSumFoot);
            this.pnlFooter.Controls.Add(this.lblSum);
            this.pnlFooter.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 456);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(716, 25);
            this.pnlFooter.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlFooter.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlFooter.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlFooter.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlFooter.Style.GradientAngle = 90;
            this.pnlFooter.TabIndex = 7;
            // 
            // lblSumFoot
            // 
            // 
            // 
            // 
            this.lblSumFoot.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSumFoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSumFoot.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSumFoot.Location = new System.Drawing.Point(52, 0);
            this.lblSumFoot.Name = "lblSumFoot";
            this.lblSumFoot.Size = new System.Drawing.Size(664, 25);
            this.lblSumFoot.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblSumFoot.TabIndex = 4;
            this.lblSumFoot.Paint += new System.Windows.Forms.PaintEventHandler(this.lblSumFoot_Paint);
            // 
            // lblSum
            // 
            // 
            // 
            // 
            this.lblSum.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSum.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSum.Location = new System.Drawing.Point(0, 0);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(52, 25);
            this.lblSum.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblSum.TabIndex = 5;
            this.lblSum.Text = "合 计：";
            this.lblSum.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // group1
            // 
            this.group1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.group1.BackColor = System.Drawing.Color.White;
            this.group1.CanvasColor = System.Drawing.SystemColors.Control;
            this.group1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.group1.Controls.Add(this.btn_Query);
            this.group1.DisabledBackColor = System.Drawing.Color.Empty;
            this.group1.Location = new System.Drawing.Point(5, 73);
            this.group1.Name = "group1";
            this.group1.Size = new System.Drawing.Size(260, 487);
            // 
            // 
            // 
            this.group1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.group1.Style.BackColorGradientAngle = 90;
            this.group1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.group1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.group1.Style.BorderBottomWidth = 1;
            this.group1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.group1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.group1.Style.BorderLeftWidth = 1;
            this.group1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.group1.Style.BorderRightWidth = 1;
            this.group1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.group1.Style.BorderTopWidth = 1;
            this.group1.Style.CornerDiameter = 4;
            this.group1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.group1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.group1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.group1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.group1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.group1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.group1.TabIndex = 4;
            // 
            // group2
            // 
            this.group2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group2.BackColor = System.Drawing.Color.White;
            this.group2.CanvasColor = System.Drawing.SystemColors.Control;
            this.group2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.group2.Controls.Add(this.DGX);
            this.group2.Controls.Add(this.pnlFooter);
            this.group2.DisabledBackColor = System.Drawing.Color.Empty;
            this.group2.Location = new System.Drawing.Point(270, 73);
            this.group2.Name = "group2";
            this.group2.Size = new System.Drawing.Size(722, 487);
            // 
            // 
            // 
            this.group2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.group2.Style.BackColorGradientAngle = 90;
            this.group2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.group2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.group2.Style.BorderBottomWidth = 1;
            this.group2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.group2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.group2.Style.BorderLeftWidth = 1;
            this.group2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.group2.Style.BorderRightWidth = 1;
            this.group2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.group2.Style.BorderTopWidth = 1;
            this.group2.Style.CornerDiameter = 4;
            this.group2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.group2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.group2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.group2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.group2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.group2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.group2.TabIndex = 14;
            // 
            // pnl_title
            // 
            this.pnl_title.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnl_title.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnl_title.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnl_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_title.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnl_title.Location = new System.Drawing.Point(0, 27);
            this.pnl_title.Name = "pnl_title";
            this.pnl_title.Size = new System.Drawing.Size(996, 40);
            this.pnl_title.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnl_title.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnl_title.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnl_title.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnl_title.Style.GradientAngle = 90;
            this.pnl_title.TabIndex = 15;
            this.pnl_title.Text = "列表名称";
            // 
            // FmRRouter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(996, 588);
            this.Controls.Add(this.group2);
            this.Controls.Add(this.group1);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.pnl_title);
            this.Controls.Add(this.ToolBar);
            this.DoubleBuffered = true;
            this.Name = "FmRRouter";
            this.ShowIcon = false;
            this.Text = "FmQList";
            ((System.ComponentModel.ISupportInitialize)(this.ToolBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGX)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.group1.ResumeLayout(false);
            this.group2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelItem sBar_lbl;
        protected DevComponents.DotNetBar.ButtonItem btn_Export;
        protected DevComponents.DotNetBar.ButtonItem btn_Reflash;
        protected DevComponents.DotNetBar.Controls.DataGridViewX DGX;
        private DevComponents.DotNetBar.PanelEx pnlFooter;
        private DevComponents.DotNetBar.LabelX lblSumFoot;
        private DevComponents.DotNetBar.LabelX lblSum;
        protected DevComponents.DotNetBar.ButtonX btn_Query;
        protected DevComponents.DotNetBar.Bar ToolBar;
        protected DevComponents.DotNetBar.Bar StatusBar;
        protected DevComponents.DotNetBar.Controls.GroupPanel group1;
        protected DevComponents.DotNetBar.Controls.GroupPanel group2;
        protected DevComponents.DotNetBar.PanelEx pnl_title;
    }
}