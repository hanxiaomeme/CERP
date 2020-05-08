namespace LanyunMES.UI
{
    partial class FmOpQMReport
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
            this.pnlM = new DevComponents.DotNetBar.PanelEx();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_cInvName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_cInvCode = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_OpName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_OpSeq = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_cardNo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.pnlD = new DevComponents.DotNetBar.PanelEx();
            this.BtnOK = new DevComponents.DotNetBar.ButtonX();
            this.txt_qty = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.pnlD.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlM
            // 
            this.pnlM.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlM.CausesValidation = false;
            this.pnlM.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlM.Controls.Add(this.label7);
            this.pnlM.Controls.Add(this.label8);
            this.pnlM.Controls.Add(this.lbl_cInvName);
            this.pnlM.Controls.Add(this.label6);
            this.pnlM.Controls.Add(this.lbl_cInvCode);
            this.pnlM.Controls.Add(this.label4);
            this.pnlM.Controls.Add(this.lbl_OpName);
            this.pnlM.Controls.Add(this.label3);
            this.pnlM.Controls.Add(this.lbl_OpSeq);
            this.pnlM.Controls.Add(this.label2);
            this.pnlM.Controls.Add(this.lbl_cardNo);
            this.pnlM.Controls.Add(this.label1);
            this.pnlM.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlM.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlM.Location = new System.Drawing.Point(0, 25);
            this.pnlM.Name = "pnlM";
            this.pnlM.Size = new System.Drawing.Size(439, 119);
            this.pnlM.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlM.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlM.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlM.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlM.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlM.Style.GradientAngle = 90;
            this.pnlM.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(315, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 12;
            this.label7.Tag = "cInvStd";
            this.label7.Text = "--";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(242, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "规格型号：";
            // 
            // lbl_cInvName
            // 
            this.lbl_cInvName.AutoSize = true;
            this.lbl_cInvName.Location = new System.Drawing.Point(107, 81);
            this.lbl_cInvName.Name = "lbl_cInvName";
            this.lbl_cInvName.Size = new System.Drawing.Size(15, 13);
            this.lbl_cInvName.TabIndex = 10;
            this.lbl_cInvName.Tag = "cInvName";
            this.lbl_cInvName.Text = "--";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "存货名称：";
            // 
            // lbl_cInvCode
            // 
            this.lbl_cInvCode.AutoSize = true;
            this.lbl_cInvCode.Location = new System.Drawing.Point(107, 50);
            this.lbl_cInvCode.Name = "lbl_cInvCode";
            this.lbl_cInvCode.Size = new System.Drawing.Size(15, 13);
            this.lbl_cInvCode.TabIndex = 8;
            this.lbl_cInvCode.Tag = "cInvCode";
            this.lbl_cInvCode.Text = "--";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "存货编码：";
            // 
            // lbl_OpName
            // 
            this.lbl_OpName.AutoSize = true;
            this.lbl_OpName.Location = new System.Drawing.Point(315, 50);
            this.lbl_OpName.Name = "lbl_OpName";
            this.lbl_OpName.Size = new System.Drawing.Size(15, 13);
            this.lbl_OpName.TabIndex = 6;
            this.lbl_OpName.Tag = "curOpName";
            this.lbl_OpName.Text = "--";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(242, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "工序名称：";
            // 
            // lbl_OpSeq
            // 
            this.lbl_OpSeq.AutoSize = true;
            this.lbl_OpSeq.Location = new System.Drawing.Point(315, 19);
            this.lbl_OpSeq.Name = "lbl_OpSeq";
            this.lbl_OpSeq.Size = new System.Drawing.Size(15, 13);
            this.lbl_OpSeq.TabIndex = 4;
            this.lbl_OpSeq.Tag = "curOpSeq";
            this.lbl_OpSeq.Text = "--";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(242, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "工序行号：";
            // 
            // lbl_cardNo
            // 
            this.lbl_cardNo.AutoSize = true;
            this.lbl_cardNo.Location = new System.Drawing.Point(107, 19);
            this.lbl_cardNo.Name = "lbl_cardNo";
            this.lbl_cardNo.Size = new System.Drawing.Size(15, 13);
            this.lbl_cardNo.TabIndex = 2;
            this.lbl_cardNo.Tag = "CardNo";
            this.lbl_cardNo.Text = "--";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "流转卡号：";
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(439, 25);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 5;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // pnlD
            // 
            this.pnlD.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlD.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlD.Controls.Add(this.BtnOK);
            this.pnlD.Controls.Add(this.txt_qty);
            this.pnlD.Controls.Add(this.label5);
            this.pnlD.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlD.Location = new System.Drawing.Point(0, 144);
            this.pnlD.Name = "pnlD";
            this.pnlD.Size = new System.Drawing.Size(439, 107);
            this.pnlD.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlD.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlD.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlD.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlD.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlD.Style.GradientAngle = 90;
            this.pnlD.TabIndex = 16;
            // 
            // BtnOK
            // 
            this.BtnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnOK.Location = new System.Drawing.Point(296, 36);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 28);
            this.BtnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BtnOK.TabIndex = 24;
            this.BtnOK.Text = "确 定";
            this.BtnOK.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // txt_qty
            // 
            this.txt_qty.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_qty.Border.Class = "TextBoxBorder";
            this.txt_qty.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_qty.DisabledBackColor = System.Drawing.Color.White;
            this.txt_qty.ForeColor = System.Drawing.Color.Black;
            this.txt_qty.Location = new System.Drawing.Point(105, 36);
            this.txt_qty.Name = "txt_qty";
            this.txt_qty.PreventEnterBeep = true;
            this.txt_qty.Size = new System.Drawing.Size(85, 22);
            this.txt_qty.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "报检数量：";
            // 
            // FmOpQMReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 251);
            this.Controls.Add(this.pnlD);
            this.Controls.Add(this.pnlM);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "FmOpQMReport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "报检";
            this.Load += new System.EventHandler(this.FmMOReport_Load);
            this.pnlM.ResumeLayout(false);
            this.pnlM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.pnlD.ResumeLayout(false);
            this.pnlD.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx pnlM;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Bar bar1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_cInvName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_cInvCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_OpName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_OpSeq;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_cardNo;
        private DevComponents.DotNetBar.PanelEx pnlD;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_qty;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.ButtonX BtnOK;
    }
}