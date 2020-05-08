namespace LanyunMES.UI
{
    partial class FmRouting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmRouting));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblModuleTitle = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.Head_Bar = new DevComponents.DotNetBar.Bar();
            this.BtnAdd = new DevComponents.DotNetBar.ButtonItem();
            this.BtnEdit = new DevComponents.DotNetBar.ButtonItem();
            this.BtnSave = new DevComponents.DotNetBar.ButtonItem();
            this.BtnDel = new DevComponents.DotNetBar.ButtonItem();
            this.BtnExit = new DevComponents.DotNetBar.ButtonItem();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.Grid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.btn_DelLine = new DevComponents.DotNetBar.ButtonX();
            this.btn_AddLine = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_cEQName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_cEQCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.Status_Bar = new DevComponents.DotNetBar.Bar();
            this.lbl_status = new DevComponents.DotNetBar.LabelItem();
            this.GridList = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.Head_Bar)).BeginInit();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Status_Bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblModuleTitle
            // 
            this.lblModuleTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblModuleTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblModuleTitle.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblModuleTitle.ForeColor = System.Drawing.Color.Black;
            this.lblModuleTitle.Location = new System.Drawing.Point(0, 49);
            this.lblModuleTitle.Name = "lblModuleTitle";
            this.lblModuleTitle.Size = new System.Drawing.Size(955, 35);
            this.lblModuleTitle.TabIndex = 0;
            this.lblModuleTitle.Text = "工艺路线";
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
            // 
            // Head_Bar
            // 
            this.Head_Bar.AntiAlias = true;
            this.Head_Bar.Dock = System.Windows.Forms.DockStyle.Top;
            this.Head_Bar.DockedBorderStyle = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.Head_Bar.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Head_Bar.Images = this.imageList1;
            this.Head_Bar.IsMaximized = false;
            this.Head_Bar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.BtnAdd,
            this.BtnEdit,
            this.BtnSave,
            this.BtnDel,
            this.BtnExit});
            this.Head_Bar.Location = new System.Drawing.Point(0, 0);
            this.Head_Bar.Name = "Head_Bar";
            this.Head_Bar.Size = new System.Drawing.Size(955, 49);
            this.Head_Bar.Stretch = true;
            this.Head_Bar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Head_Bar.TabIndex = 1;
            this.Head_Bar.TabStop = false;
            this.Head_Bar.Text = "bar1";
            // 
            // BtnAdd
            // 
            this.BtnAdd.ImageIndex = 3;
            this.BtnAdd.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Text = "新增";
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.ImageIndex = 2;
            this.BtnEdit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Text = "编辑";
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.ImageIndex = 0;
            this.BtnSave.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Text = "保存";
            // 
            // BtnDel
            // 
            this.BtnDel.ImageIndex = 4;
            this.BtnDel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Text = "删除";
            this.BtnDel.Click += new System.EventHandler(this.BtnDel_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.ImageIndex = 1;
            this.BtnExit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Text = "退出";
            this.BtnExit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.Grid);
            this.panelEx1.Controls.Add(this.panelEx2);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(436, 344);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // Grid
            // 
            this.Grid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grid.DefaultCellStyle = dataGridViewCellStyle1;
            this.Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.Grid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.Grid.Location = new System.Drawing.Point(0, 121);
            this.Grid.Name = "Grid";
            this.Grid.RowTemplate.Height = 23;
            this.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid.Size = new System.Drawing.Size(436, 223);
            this.Grid.TabIndex = 13;
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.btn_DelLine);
            this.panelEx2.Controls.Add(this.btn_AddLine);
            this.panelEx2.Controls.Add(this.label2);
            this.panelEx2.Controls.Add(this.txt_cEQName);
            this.panelEx2.Controls.Add(this.label1);
            this.panelEx2.Controls.Add(this.txt_cEQCode);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx2.Location = new System.Drawing.Point(0, 0);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(436, 121);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 14;
            // 
            // btn_DelLine
            // 
            this.btn_DelLine.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_DelLine.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_DelLine.Location = new System.Drawing.Point(53, 97);
            this.btn_DelLine.Name = "btn_DelLine";
            this.btn_DelLine.Size = new System.Drawing.Size(40, 20);
            this.btn_DelLine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_DelLine.TabIndex = 27;
            this.btn_DelLine.Text = "删行";
            this.btn_DelLine.Click += new System.EventHandler(this.btn_DelLine_Click);
            // 
            // btn_AddLine
            // 
            this.btn_AddLine.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_AddLine.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_AddLine.Location = new System.Drawing.Point(7, 97);
            this.btn_AddLine.Name = "btn_AddLine";
            this.btn_AddLine.Size = new System.Drawing.Size(40, 20);
            this.btn_AddLine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_AddLine.TabIndex = 26;
            this.btn_AddLine.Text = "增加";
            this.btn_AddLine.Click += new System.EventHandler(this.btn_AddLine_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "工艺路线名称";
            // 
            // txt_cEQName
            // 
            this.txt_cEQName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_cEQName.Border.Class = "TextBoxBorder";
            this.txt_cEQName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_cEQName.DisabledBackColor = System.Drawing.Color.White;
            this.txt_cEQName.ForeColor = System.Drawing.Color.Black;
            this.txt_cEQName.Location = new System.Drawing.Point(138, 55);
            this.txt_cEQName.Name = "txt_cEQName";
            this.txt_cEQName.PreventEnterBeep = true;
            this.txt_cEQName.Size = new System.Drawing.Size(181, 21);
            this.txt_cEQName.TabIndex = 15;
            this.txt_cEQName.Tag = "RoutingName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "工艺路线编码";
            // 
            // txt_cEQCode
            // 
            this.txt_cEQCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_cEQCode.Border.Class = "TextBoxBorder";
            this.txt_cEQCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_cEQCode.DisabledBackColor = System.Drawing.Color.White;
            this.txt_cEQCode.ForeColor = System.Drawing.Color.Black;
            this.txt_cEQCode.Location = new System.Drawing.Point(138, 17);
            this.txt_cEQCode.Name = "txt_cEQCode";
            this.txt_cEQCode.PreventEnterBeep = true;
            this.txt_cEQCode.Size = new System.Drawing.Size(181, 21);
            this.txt_cEQCode.TabIndex = 13;
            this.txt_cEQCode.Tag = "RoutingCode";
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
            this.Status_Bar.Location = new System.Drawing.Point(0, 428);
            this.Status_Bar.Name = "Status_Bar";
            this.Status_Bar.Size = new System.Drawing.Size(955, 22);
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
            // GridList
            // 
            this.GridList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.GridList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridList.DefaultCellStyle = dataGridViewCellStyle2;
            this.GridList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.GridList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GridList.Location = new System.Drawing.Point(0, 0);
            this.GridList.Name = "GridList";
            this.GridList.ReadOnly = true;
            this.GridList.RowTemplate.Height = 23;
            this.GridList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridList.Size = new System.Drawing.Size(514, 344);
            this.GridList.TabIndex = 14;
            this.GridList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridList_RowEnter);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 84);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.GridList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelEx1);
            this.splitContainer1.Size = new System.Drawing.Size(955, 344);
            this.splitContainer1.SplitterDistance = 514;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 4;
            // 
            // FmRouting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lblModuleTitle);
            this.Controls.Add(this.Head_Bar);
            this.Controls.Add(this.Status_Bar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FmRouting";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FmBIU";
            ((System.ComponentModel.ISupportInitialize)(this.Head_Bar)).EndInit();
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Status_Bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridList)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label lblModuleTitle;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.ButtonItem BtnSave;
        private DevComponents.DotNetBar.ButtonItem BtnExit;
        private DevComponents.DotNetBar.LabelItem lbl_status;
        protected DevComponents.DotNetBar.Bar Head_Bar;
        protected DevComponents.DotNetBar.Bar Status_Bar;
        protected DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.DataGridViewX Grid;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_cEQName;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_cEQCode;
        private DevComponents.DotNetBar.ButtonX btn_AddLine;
        private DevComponents.DotNetBar.ButtonX btn_DelLine;
        private DevComponents.DotNetBar.ButtonItem BtnEdit;
        private DevComponents.DotNetBar.Controls.DataGridViewX GridList;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.ButtonItem BtnAdd;
        private DevComponents.DotNetBar.ButtonItem BtnDel;
    }
}