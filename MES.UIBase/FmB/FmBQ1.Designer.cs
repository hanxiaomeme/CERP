namespace Eastar
{
    partial class FmBQ1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnl03 = new System.Windows.Forms.Panel();
            this.btnClsQC = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.pnl0202 = new System.Windows.Forms.Panel();
            this.pnl02 = new System.Windows.Forms.Panel();
            this.pnl020203 = new System.Windows.Forms.Panel();
            this.pnl0201 = new System.Windows.Forms.Panel();
            this.pnl01 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.pnl03.SuspendLayout();
            this.pnl0202.SuspendLayout();
            this.pnl02.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(384, 416);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(376, 390);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "查询条件";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pnl03
            // 
            this.pnl03.Controls.Add(this.btnClsQC);
            this.pnl03.Controls.Add(this.btnCancel);
            this.pnl03.Controls.Add(this.btnOK);
            this.pnl03.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl03.Location = new System.Drawing.Point(5, 421);
            this.pnl03.Name = "pnl03";
            this.pnl03.Size = new System.Drawing.Size(384, 28);
            this.pnl03.TabIndex = 1;
            // 
            // btnClsQC
            // 
            this.btnClsQC.Location = new System.Drawing.Point(50, 3);
            this.btnClsQC.Name = "btnClsQC";
            this.btnClsQC.Size = new System.Drawing.Size(45, 23);
            this.btnClsQC.TabIndex = 2;
            this.btnClsQC.Text = "清除";
            this.btnClsQC.UseVisualStyleBackColor = true;
            this.btnClsQC.Click += new System.EventHandler(this.btnClsQC_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(100, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(45, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(5, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(45, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnl0202
            // 
            this.pnl0202.Controls.Add(this.tabControl1);
            this.pnl0202.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl0202.Location = new System.Drawing.Point(0, 0);
            this.pnl0202.Name = "pnl0202";
            this.pnl0202.Size = new System.Drawing.Size(384, 416);
            this.pnl0202.TabIndex = 2;
            // 
            // pnl02
            // 
            this.pnl02.Controls.Add(this.pnl0202);
            this.pnl02.Controls.Add(this.pnl020203);
            this.pnl02.Controls.Add(this.pnl0201);
            this.pnl02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl02.Location = new System.Drawing.Point(5, 5);
            this.pnl02.Name = "pnl02";
            this.pnl02.Size = new System.Drawing.Size(384, 416);
            this.pnl02.TabIndex = 1;
            // 
            // pnl020203
            // 
            this.pnl020203.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl020203.Location = new System.Drawing.Point(384, 0);
            this.pnl020203.Name = "pnl020203";
            this.pnl020203.Size = new System.Drawing.Size(0, 416);
            this.pnl020203.TabIndex = 3;
            // 
            // pnl0201
            // 
            this.pnl0201.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl0201.Location = new System.Drawing.Point(0, 0);
            this.pnl0201.Name = "pnl0201";
            this.pnl0201.Size = new System.Drawing.Size(0, 416);
            this.pnl0201.TabIndex = 1;
            this.pnl0201.Visible = false;
            // 
            // pnl01
            // 
            this.pnl01.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl01.Location = new System.Drawing.Point(5, 5);
            this.pnl01.Name = "pnl01";
            this.pnl01.Size = new System.Drawing.Size(384, 0);
            this.pnl01.TabIndex = 0;
            // 
            // FmBQ1
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(394, 454);
            this.Controls.Add(this.pnl02);
            this.Controls.Add(this.pnl03);
            this.Controls.Add(this.pnl01);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FmBQ1";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查询";
            this.Load += new System.EventHandler(this.FmBQ_Load);
            this.tabControl1.ResumeLayout(false);
            this.pnl03.ResumeLayout(false);
            this.pnl0202.ResumeLayout(false);
            this.pnl02.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel pnl03;
        protected System.Windows.Forms.TabControl tabControl1;
        protected System.Windows.Forms.TabPage tabPage1;
        protected System.Windows.Forms.Button btnCancel;
        protected System.Windows.Forms.Button btnOK;
        protected System.Windows.Forms.Button btnClsQC;
        protected System.Windows.Forms.Panel pnl0202;
        protected System.Windows.Forms.Panel pnl02;
        protected System.Windows.Forms.Panel pnl020203;
        protected System.Windows.Forms.Panel pnl0201;
        protected System.Windows.Forms.Panel pnl01;

    }
}