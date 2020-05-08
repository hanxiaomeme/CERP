namespace LanyunMES.UI
{
    partial class FmCreateMCard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtr_cardNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_curQuantity = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_MCQuantity = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_WOCode = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_MCardCount = new System.Windows.Forms.Label();
            this.lbl_iQuantity = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bar3 = new DevComponents.DotNetBar.Bar();
            this.BtnAddOp = new DevComponents.DotNetBar.ButtonItem();
            this.BtnDelOp = new DevComponents.DotNetBar.ButtonItem();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.BtnCreate = new DevComponents.DotNetBar.ButtonItem();
            this.BtnPrint = new DevComponents.DotNetBar.ButtonItem();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.GridChild = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.OpSeq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DInvCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DInvName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DInvStd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.BtnAddChild = new DevComponents.DotNetBar.ButtonItem();
            this.BtnDelChild = new DevComponents.DotNetBar.ButtonItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridChild)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtr_cardNo);
            this.groupBox1.Controls.Add(this.txt_curQuantity);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lbl_MCQuantity);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lbl_WOCode);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lbl_MCardCount);
            this.groupBox1.Controls.Add(this.lbl_iQuantity);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(950, 103);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // txtr_cardNo
            // 
            this.txtr_cardNo.BackColor = System.Drawing.Color.OldLace;
            // 
            // 
            // 
            this.txtr_cardNo.Border.Class = "TextBoxBorder";
            this.txtr_cardNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_cardNo.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_cardNo.ForeColor = System.Drawing.Color.Black;
            this.txtr_cardNo.Location = new System.Drawing.Point(384, 55);
            this.txtr_cardNo.Name = "txtr_cardNo";
            this.txtr_cardNo.PreventEnterBeep = true;
            this.txtr_cardNo.ReadOnly = true;
            this.txtr_cardNo.Size = new System.Drawing.Size(154, 22);
            this.txtr_cardNo.TabIndex = 28;
            // 
            // txt_curQuantity
            // 
            this.txt_curQuantity.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_curQuantity.Border.Class = "TextBoxBorder";
            this.txt_curQuantity.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_curQuantity.DisabledBackColor = System.Drawing.Color.White;
            this.txt_curQuantity.ForeColor = System.Drawing.Color.Black;
            this.txt_curQuantity.Location = new System.Drawing.Point(145, 55);
            this.txt_curQuantity.Name = "txt_curQuantity";
            this.txt_curQuantity.PreventEnterBeep = true;
            this.txt_curQuantity.Size = new System.Drawing.Size(89, 22);
            this.txt_curQuantity.TabIndex = 27;
            this.txt_curQuantity.TextChanged += new System.EventHandler(this.txt_curQuantity_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(312, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "流转卡号：";
            // 
            // lbl_MCQuantity
            // 
            this.lbl_MCQuantity.AutoSize = true;
            this.lbl_MCQuantity.Location = new System.Drawing.Point(555, 27);
            this.lbl_MCQuantity.Name = "lbl_MCQuantity";
            this.lbl_MCQuantity.Size = new System.Drawing.Size(15, 13);
            this.lbl_MCQuantity.TabIndex = 25;
            this.lbl_MCQuantity.Tag = "MCardQuantity";
            this.lbl_MCQuantity.Text = "--";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(482, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "合计数量：";
            // 
            // lbl_WOCode
            // 
            this.lbl_WOCode.AutoSize = true;
            this.lbl_WOCode.Location = new System.Drawing.Point(99, 26);
            this.lbl_WOCode.Name = "lbl_WOCode";
            this.lbl_WOCode.Size = new System.Drawing.Size(15, 13);
            this.lbl_WOCode.TabIndex = 23;
            this.lbl_WOCode.Tag = "WOCode";
            this.lbl_WOCode.Text = "--";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "指令单号：";
            // 
            // lbl_MCardCount
            // 
            this.lbl_MCardCount.AutoSize = true;
            this.lbl_MCardCount.Location = new System.Drawing.Point(424, 27);
            this.lbl_MCardCount.Name = "lbl_MCardCount";
            this.lbl_MCardCount.Size = new System.Drawing.Size(15, 13);
            this.lbl_MCardCount.TabIndex = 21;
            this.lbl_MCardCount.Tag = "MCardCount";
            this.lbl_MCardCount.Text = "--";
            // 
            // lbl_iQuantity
            // 
            this.lbl_iQuantity.AutoSize = true;
            this.lbl_iQuantity.Location = new System.Drawing.Point(293, 27);
            this.lbl_iQuantity.Name = "lbl_iQuantity";
            this.lbl_iQuantity.Size = new System.Drawing.Size(15, 13);
            this.lbl_iQuantity.TabIndex = 20;
            this.lbl_iQuantity.Tag = "iQuantity";
            this.lbl_iQuantity.Text = "--";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "指令单数量：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "本次流转数量：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(350, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "已开卡数：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Controls.Add(this.bar3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 322);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "工序";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(3, 45);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(219, 274);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "工序序号";
            this.columnHeader1.Width = 81;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "工序名称";
            this.columnHeader2.Width = 93;
            // 
            // bar3
            // 
            this.bar3.AntiAlias = true;
            this.bar3.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar3.DockSide = DevComponents.DotNetBar.eDockSide.Left;
            this.bar3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar3.IsMaximized = false;
            this.bar3.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.BtnAddOp,
            this.BtnDelOp});
            this.bar3.Location = new System.Drawing.Point(3, 18);
            this.bar3.Name = "bar3";
            this.bar3.Size = new System.Drawing.Size(219, 27);
            this.bar3.Stretch = true;
            this.bar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar3.TabIndex = 6;
            this.bar3.TabStop = false;
            this.bar3.Text = "bar3";
            // 
            // BtnAddOp
            // 
            this.BtnAddOp.Name = "BtnAddOp";
            this.BtnAddOp.Text = "增加";
            this.BtnAddOp.Visible = false;
            this.BtnAddOp.Click += new System.EventHandler(this.AddOperation);
            // 
            // BtnDelOp
            // 
            this.BtnDelOp.Name = "BtnDelOp";
            this.BtnDelOp.Text = "删除";
            this.BtnDelOp.Click += new System.EventHandler(this.DelOperation);
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.BtnCreate,
            this.BtnPrint});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(950, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 22;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // BtnCreate
            // 
            this.BtnCreate.Name = "BtnCreate";
            this.BtnCreate.Text = "生成(&C)";
            this.BtnCreate.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnPrint
            // 
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Text = "打印(&P)";
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.groupBox3);
            this.panelEx1.Controls.Add(this.groupBox2);
            this.panelEx1.Controls.Add(this.groupBox1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 27);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(950, 425);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Top;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 23;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.GridChild);
            this.groupBox3.Controls.Add(this.bar2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(225, 103);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(725, 322);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "子件";
            // 
            // GridChild
            // 
            this.GridChild.AllowUserToAddRows = false;
            this.GridChild.AllowUserToDeleteRows = false;
            this.GridChild.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridChild.BackgroundColor = System.Drawing.SystemColors.Window;
            this.GridChild.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GridChild.ColumnHeadersHeight = 25;
            this.GridChild.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GridChild.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OpSeq,
            this.OpName,
            this.DInvCode,
            this.DInvName,
            this.DInvStd,
            this.iQty});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridChild.DefaultCellStyle = dataGridViewCellStyle1;
            this.GridChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridChild.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GridChild.Location = new System.Drawing.Point(3, 45);
            this.GridChild.MultiSelect = false;
            this.GridChild.Name = "GridChild";
            this.GridChild.RowHeadersVisible = false;
            this.GridChild.RowTemplate.Height = 23;
            this.GridChild.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GridChild.Size = new System.Drawing.Size(719, 274);
            this.GridChild.TabIndex = 6;
            // 
            // OpSeq
            // 
            this.OpSeq.DataPropertyName = "OpSeq";
            this.OpSeq.FillWeight = 80F;
            this.OpSeq.HeaderText = "工序序号";
            this.OpSeq.Name = "OpSeq";
            this.OpSeq.ReadOnly = true;
            this.OpSeq.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // OpName
            // 
            this.OpName.DataPropertyName = "OpName";
            this.OpName.HeaderText = "工序名称";
            this.OpName.Name = "OpName";
            this.OpName.ReadOnly = true;
            // 
            // DInvCode
            // 
            this.DInvCode.DataPropertyName = "DInvCode";
            this.DInvCode.HeaderText = "子件编码";
            this.DInvCode.Name = "DInvCode";
            this.DInvCode.ReadOnly = true;
            // 
            // DInvName
            // 
            this.DInvName.DataPropertyName = "DInvStd";
            this.DInvName.HeaderText = "子件名称";
            this.DInvName.Name = "DInvName";
            this.DInvName.ReadOnly = true;
            // 
            // DInvStd
            // 
            this.DInvStd.DataPropertyName = "DInvStd";
            this.DInvStd.HeaderText = "规格型号";
            this.DInvStd.Name = "DInvStd";
            this.DInvStd.ReadOnly = true;
            // 
            // iQty
            // 
            this.iQty.DataPropertyName = "iQty";
            this.iQty.FillWeight = 80F;
            this.iQty.HeaderText = "数量";
            this.iQty.Name = "iQty";
            // 
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar2.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.bar2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar2.IsMaximized = false;
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.BtnAddChild,
            this.BtnDelChild});
            this.bar2.Location = new System.Drawing.Point(3, 18);
            this.bar2.Name = "bar2";
            this.bar2.Size = new System.Drawing.Size(719, 27);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 5;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
            // 
            // BtnAddChild
            // 
            this.BtnAddChild.Name = "BtnAddChild";
            this.BtnAddChild.Text = "增加";
            this.BtnAddChild.Visible = false;
            // 
            // BtnDelChild
            // 
            this.BtnDelChild.Name = "BtnDelChild";
            this.BtnDelChild.Text = "删除";
            // 
            // FmCreateMCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 452);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.bar1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FmCreateMCard";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生成流转卡";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridChild)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_curQuantity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl_MCQuantity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_WOCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_MCardCount;
        private System.Windows.Forms.Label lbl_iQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_cardNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem BtnCreate;
        private DevComponents.DotNetBar.ButtonItem BtnPrint;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Bar bar3;
        private DevComponents.DotNetBar.ButtonItem BtnAddOp;
        private DevComponents.DotNetBar.ButtonItem BtnDelOp;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.ButtonItem BtnAddChild;
        private DevComponents.DotNetBar.ButtonItem BtnDelChild;
        private DevComponents.DotNetBar.Controls.DataGridViewX GridChild;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpSeq;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DInvCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn DInvName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DInvStd;
        private System.Windows.Forms.DataGridViewTextBoxColumn iQty;
    }
}