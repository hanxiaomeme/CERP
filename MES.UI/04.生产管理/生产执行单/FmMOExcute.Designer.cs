namespace LanyunMES.UI
{
    partial class FmMOExcute
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
            this.BtnSelectCard = new DevComponents.DotNetBar.ButtonItem();
            this.BtnChange = new DevComponents.DotNetBar.ButtonItem();
            this.pnlMain = new DevComponents.DotNetBar.PanelEx();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_cardNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_Equipment = new System.Windows.Forms.Label();
            this.lbl_OpName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl = new DevComponents.DotNetBar.SuperTabControl();
            this.lbl_title = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.BtnSelectCard,
            this.BtnChange});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.PaddingRight = 50;
            this.bar1.Size = new System.Drawing.Size(996, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 6;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // BtnSelectCard
            // 
            this.BtnSelectCard.BeginGroup = true;
            this.BtnSelectCard.Name = "BtnSelectCard";
            this.BtnSelectCard.Text = "打开流转卡(&O)";
            this.BtnSelectCard.Click += new System.EventHandler(this.BtnSelectCard_Click);
            // 
            // BtnChange
            // 
            this.BtnChange.Name = "BtnChange";
            this.BtnChange.Text = "切换工序/设备(&C)";
            this.BtnChange.Click += new System.EventHandler(this.BtnChange_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlMain.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.txt_cardNo);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.lbl_Equipment);
            this.pnlMain.Controls.Add(this.lbl_OpName);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMain.Location = new System.Drawing.Point(0, 62);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(996, 93);
            this.pnlMain.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlMain.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlMain.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlMain.Style.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlMain.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlMain.Style.GradientAngle = 90;
            this.pnlMain.Style.LineAlignment = System.Drawing.StringAlignment.Near;
            this.pnlMain.Style.MarginTop = 10;
            this.pnlMain.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(471, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "转到流转卡:";
            // 
            // txt_cardNo
            // 
            this.txt_cardNo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_cardNo.Border.Class = "TextBoxBorder";
            this.txt_cardNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_cardNo.DisabledBackColor = System.Drawing.Color.White;
            this.txt_cardNo.ForeColor = System.Drawing.Color.Black;
            this.txt_cardNo.Location = new System.Drawing.Point(573, 54);
            this.txt_cardNo.Name = "txt_cardNo";
            this.txt_cardNo.PreventEnterBeep = true;
            this.txt_cardNo.Size = new System.Drawing.Size(167, 21);
            this.txt_cardNo.TabIndex = 5;
            this.txt_cardNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cardNo_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(27, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(364, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "工序状态: 1.材料准备-->2.材料确认-->3.开工-->4.完工";
            // 
            // lbl_Equipment
            // 
            this.lbl_Equipment.AutoSize = true;
            this.lbl_Equipment.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Equipment.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Equipment.Location = new System.Drawing.Point(354, 23);
            this.lbl_Equipment.Name = "lbl_Equipment";
            this.lbl_Equipment.Size = new System.Drawing.Size(26, 16);
            this.lbl_Equipment.TabIndex = 3;
            this.lbl_Equipment.Text = "--";
            // 
            // lbl_OpName
            // 
            this.lbl_OpName.AutoSize = true;
            this.lbl_OpName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_OpName.ForeColor = System.Drawing.Color.Blue;
            this.lbl_OpName.Location = new System.Drawing.Point(126, 23);
            this.lbl_OpName.Name = "lbl_OpName";
            this.lbl_OpName.Size = new System.Drawing.Size(26, 16);
            this.lbl_OpName.TabIndex = 2;
            this.lbl_OpName.Text = "--";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(255, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "当前设备：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(27, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前工序：";
            // 
            // tabControl
            // 
            this.tabControl.BackColor = System.Drawing.Color.White;
            this.tabControl.CloseButtonOnTabsVisible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tabControl.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.tabControl.ControlBox.MenuBox.Name = "";
            this.tabControl.ControlBox.Name = "";
            this.tabControl.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tabControl.ControlBox.MenuBox,
            this.tabControl.ControlBox.CloseBox});
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ForeColor = System.Drawing.Color.Black;
            this.tabControl.Location = new System.Drawing.Point(0, 155);
            this.tabControl.Name = "tabControl";
            this.tabControl.ReorderTabsEnabled = true;
            this.tabControl.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl.SelectedTabIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(996, 316);
            this.tabControl.TabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl.TabIndex = 27;
            this.tabControl.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.VisualStudio2008Dock;
            this.tabControl.Text = "superTabControl1";
            // 
            // lbl_title
            // 
            this.lbl_title.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lbl_title.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_title.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_title.Location = new System.Drawing.Point(0, 27);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(996, 35);
            this.lbl_title.TabIndex = 7;
            this.lbl_title.Text = "生产执行单";
            this.lbl_title.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // FmMOExcute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 471);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Name = "FmMOExcute";
            this.RenderFormIcon = false;
            this.RenderFormText = false;
            this.Text = "生产执行单";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem BtnSelectCard;
        private DevComponents.DotNetBar.PanelEx pnlMain;
        private DevComponents.DotNetBar.SuperTabControl tabControl;
        private System.Windows.Forms.Label lbl_Equipment;
        private System.Windows.Forms.Label lbl_OpName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_cardNo;
        private DevComponents.DotNetBar.ButtonItem BtnChange;
        private DevComponents.DotNetBar.LabelX lbl_title;
    }
}