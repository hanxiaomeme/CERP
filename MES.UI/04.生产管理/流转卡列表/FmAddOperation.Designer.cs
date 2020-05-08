namespace LanyunMES.UI
{
    partial class FmAddOperation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmAddOperation));
            this.listView1 = new System.Windows.Forms.ListView();
            this.col_ReWork = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_OpSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_OPName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_iQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_iWeight = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_bizhong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnCopyOP = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Btn_Up = new System.Windows.Forms.ToolStripButton();
            this.Btn_Down = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_ReWork,
            this.col_OpSeq,
            this.col_OPName,
            this.col_iQuantity,
            this.col_iWeight,
            this.col_bizhong});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(0, 24);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(439, 395);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // col_ReWork
            // 
            this.col_ReWork.Text = "返工";
            this.col_ReWork.Width = 58;
            // 
            // col_OpSeq
            // 
            this.col_OpSeq.Text = "序号";
            this.col_OpSeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col_OpSeq.Width = 73;
            // 
            // col_OPName
            // 
            this.col_OPName.Text = "工序名称";
            this.col_OPName.Width = 86;
            // 
            // col_iQuantity
            // 
            this.col_iQuantity.Text = "千件";
            this.col_iQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col_iQuantity.Width = 77;
            // 
            // col_iWeight
            // 
            this.col_iWeight.Text = "重量";
            this.col_iWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col_iWeight.Width = 80;
            // 
            // col_bizhong
            // 
            this.col_bizhong.Text = "比重";
            this.col_bizhong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnSave,
            this.toolStripSeparator1,
            this.BtnCopyOP,
            this.toolStripSeparator2,
            this.Btn_Up,
            this.Btn_Down});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(439, 24);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BtnSave
            // 
            this.BtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtnSave.Image = ((System.Drawing.Image)(resources.GetObject("BtnSave.Image")));
            this.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(36, 21);
            this.BtnSave.Text = "保存";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // BtnCopyOP
            // 
            this.BtnCopyOP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtnCopyOP.Image = ((System.Drawing.Image)(resources.GetObject("BtnCopyOP.Image")));
            this.BtnCopyOP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnCopyOP.Name = "BtnCopyOP";
            this.BtnCopyOP.Size = new System.Drawing.Size(65, 21);
            this.BtnCopyOP.Text = "复制-返工";
            this.BtnCopyOP.Click += new System.EventHandler(this.BtnCopyOP_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // Btn_Up
            // 
            this.Btn_Up.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Btn_Up.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Up.Image")));
            this.Btn_Up.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Btn_Up.Name = "Btn_Up";
            this.Btn_Up.Size = new System.Drawing.Size(36, 21);
            this.Btn_Up.Text = "上移";
            this.Btn_Up.Click += new System.EventHandler(this.Btn_Up_Click);
            // 
            // Btn_Down
            // 
            this.Btn_Down.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Btn_Down.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Down.Image")));
            this.Btn_Down.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Btn_Down.Name = "Btn_Down";
            this.Btn_Down.Size = new System.Drawing.Size(36, 21);
            this.Btn_Down.Text = "下移";
            this.Btn_Down.Click += new System.EventHandler(this.Btn_Down_Click);
            // 
            // FmAddOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 419);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FmAddOperation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "增加工序";
            this.Load += new System.EventHandler(this.FmAddOperation_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader col_ReWork;
        private System.Windows.Forms.ColumnHeader col_OpSeq;
        private System.Windows.Forms.ColumnHeader col_OPName;
        private System.Windows.Forms.ColumnHeader col_iQuantity;
        private System.Windows.Forms.ColumnHeader col_iWeight;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnCopyOP;
        private System.Windows.Forms.ColumnHeader col_bizhong;
        private System.Windows.Forms.ToolStripButton BtnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton Btn_Up;
        private System.Windows.Forms.ToolStripButton Btn_Down;
    }
}