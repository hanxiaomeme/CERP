namespace LanyunMES.UI
{
    partial class FmQmPuIn
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
            this.txtr_warehouse = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnOK = new DevComponents.DotNetBar.ButtonX();
            this.txtr_Position = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtr_warehouse
            // 
            this.txtr_warehouse.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.txtr_warehouse.Border.Class = "TextBoxBorder";
            this.txtr_warehouse.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_warehouse.ButtonCustom.Visible = true;
            this.txtr_warehouse.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_warehouse.ForeColor = System.Drawing.Color.Black;
            this.txtr_warehouse.Location = new System.Drawing.Point(150, 50);
            this.txtr_warehouse.Name = "txtr_warehouse";
            this.txtr_warehouse.PreventEnterBeep = true;
            this.txtr_warehouse.ReadOnly = true;
            this.txtr_warehouse.Size = new System.Drawing.Size(184, 22);
            this.txtr_warehouse.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "入库仓库：";
            // 
            // BtnOK
            // 
            this.BtnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnOK.Location = new System.Drawing.Point(259, 160);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BtnOK.TabIndex = 4;
            this.BtnOK.Text = "确定";
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // txtr_Position
            // 
            this.txtr_Position.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.txtr_Position.Border.Class = "TextBoxBorder";
            this.txtr_Position.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtr_Position.ButtonCustom.Visible = true;
            this.txtr_Position.DisabledBackColor = System.Drawing.Color.White;
            this.txtr_Position.ForeColor = System.Drawing.Color.Black;
            this.txtr_Position.Location = new System.Drawing.Point(150, 98);
            this.txtr_Position.Name = "txtr_Position";
            this.txtr_Position.PreventEnterBeep = true;
            this.txtr_Position.ReadOnly = true;
            this.txtr_Position.Size = new System.Drawing.Size(184, 22);
            this.txtr_Position.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(91, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "货位：";
            // 
            // FmQmPuIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 215);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtr_Position);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtr_warehouse);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FmQmPuIn";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "采购入库生单信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtr_warehouse;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX BtnOK;
        private DevComponents.DotNetBar.Controls.TextBoxX txtr_Position;
        private System.Windows.Forms.Label label2;
    }
}