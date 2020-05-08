namespace LanyunMES.UI
{
    partial class FmCalendarSet
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
            this.numHours = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_7 = new System.Windows.Forms.CheckBox();
            this.chk_6 = new System.Windows.Forms.CheckBox();
            this.chk_5 = new System.Windows.Forms.CheckBox();
            this.chk_4 = new System.Windows.Forms.CheckBox();
            this.chk_3 = new System.Windows.Forms.CheckBox();
            this.chk_2 = new System.Windows.Forms.CheckBox();
            this.chk_1 = new System.Windows.Forms.CheckBox();
            this.BtnOK = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.numHours)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // numHours
            // 
            this.numHours.BackColor = System.Drawing.Color.White;
            this.numHours.DecimalPlaces = 1;
            this.numHours.ForeColor = System.Drawing.Color.Black;
            this.numHours.Location = new System.Drawing.Point(161, 47);
            this.numHours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numHours.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numHours.Name = "numHours";
            this.numHours.Size = new System.Drawing.Size(74, 22);
            this.numHours.TabIndex = 5;
            this.numHours.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(70, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "日工作时间";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(253, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "小时";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk_7);
            this.groupBox1.Controls.Add(this.chk_6);
            this.groupBox1.Controls.Add(this.chk_5);
            this.groupBox1.Controls.Add(this.chk_4);
            this.groupBox1.Controls.Add(this.chk_3);
            this.groupBox1.Controls.Add(this.chk_2);
            this.groupBox1.Controls.Add(this.chk_1);
            this.groupBox1.Location = new System.Drawing.Point(23, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 164);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "休息日";
            // 
            // chk_7
            // 
            this.chk_7.AutoSize = true;
            this.chk_7.Checked = true;
            this.chk_7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_7.Location = new System.Drawing.Point(41, 104);
            this.chk_7.Name = "chk_7";
            this.chk_7.Size = new System.Drawing.Size(62, 17);
            this.chk_7.TabIndex = 6;
            this.chk_7.Text = "星期日";
            this.chk_7.UseVisualStyleBackColor = true;
            // 
            // chk_6
            // 
            this.chk_6.AutoSize = true;
            this.chk_6.Checked = true;
            this.chk_6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_6.Location = new System.Drawing.Point(233, 66);
            this.chk_6.Name = "chk_6";
            this.chk_6.Size = new System.Drawing.Size(62, 17);
            this.chk_6.TabIndex = 5;
            this.chk_6.Text = "星期六";
            this.chk_6.UseVisualStyleBackColor = true;
            // 
            // chk_5
            // 
            this.chk_5.AutoSize = true;
            this.chk_5.Location = new System.Drawing.Point(138, 66);
            this.chk_5.Name = "chk_5";
            this.chk_5.Size = new System.Drawing.Size(62, 17);
            this.chk_5.TabIndex = 4;
            this.chk_5.Text = "星期五";
            this.chk_5.UseVisualStyleBackColor = true;
            // 
            // chk_4
            // 
            this.chk_4.AutoSize = true;
            this.chk_4.Location = new System.Drawing.Point(41, 66);
            this.chk_4.Name = "chk_4";
            this.chk_4.Size = new System.Drawing.Size(62, 17);
            this.chk_4.TabIndex = 3;
            this.chk_4.Text = "星期四";
            this.chk_4.UseVisualStyleBackColor = true;
            // 
            // chk_3
            // 
            this.chk_3.AutoSize = true;
            this.chk_3.Location = new System.Drawing.Point(233, 31);
            this.chk_3.Name = "chk_3";
            this.chk_3.Size = new System.Drawing.Size(62, 17);
            this.chk_3.TabIndex = 2;
            this.chk_3.Text = "星期三";
            this.chk_3.UseVisualStyleBackColor = true;
            // 
            // chk_2
            // 
            this.chk_2.AutoSize = true;
            this.chk_2.Location = new System.Drawing.Point(138, 31);
            this.chk_2.Name = "chk_2";
            this.chk_2.Size = new System.Drawing.Size(62, 17);
            this.chk_2.TabIndex = 1;
            this.chk_2.Text = "星期二";
            this.chk_2.UseVisualStyleBackColor = true;
            // 
            // chk_1
            // 
            this.chk_1.AutoSize = true;
            this.chk_1.Location = new System.Drawing.Point(41, 31);
            this.chk_1.Name = "chk_1";
            this.chk_1.Size = new System.Drawing.Size(62, 17);
            this.chk_1.TabIndex = 0;
            this.chk_1.Text = "星期一";
            this.chk_1.UseVisualStyleBackColor = true;
            // 
            // BtnOK
            // 
            this.BtnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnOK.Location = new System.Drawing.Point(282, 290);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BtnOK.TabIndex = 9;
            this.BtnOK.Text = "确 定";
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // FmCalendarSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 325);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numHours);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FmCalendarSet";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            ((System.ComponentModel.ISupportInitialize)(this.numHours)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numHours;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chk_7;
        private System.Windows.Forms.CheckBox chk_6;
        private System.Windows.Forms.CheckBox chk_5;
        private System.Windows.Forms.CheckBox chk_4;
        private System.Windows.Forms.CheckBox chk_3;
        private System.Windows.Forms.CheckBox chk_2;
        private System.Windows.Forms.CheckBox chk_1;
        private DevComponents.DotNetBar.ButtonX BtnOK;
    }
}