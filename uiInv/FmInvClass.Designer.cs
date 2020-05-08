namespace MES
{
    partial class FmInvClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmInvClass));
            ((System.ComponentModel.ISupportInitialize)(this.ToolBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.collapsibleSplitContainer1)).BeginInit();
            this.collapsibleSplitContainer1.Panel1.SuspendLayout();
            this.collapsibleSplitContainer1.Panel2.SuspendLayout();
            this.collapsibleSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBar)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Head
            // 
            this.pnl_Head.Size = new System.Drawing.Size(892, 28);
            this.pnl_Head.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnl_Head.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnl_Head.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnl_Head.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnl_Head.Style.BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.pnl_Head.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
            this.pnl_Head.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnl_Head.Style.GradientAngle = 90;
            // 
            // collapsibleSplitContainer1
            // 
            this.collapsibleSplitContainer1.BackColor = System.Drawing.Color.White;
            this.collapsibleSplitContainer1.Location = new System.Drawing.Point(0, 55);
            // 
            // collapsibleSplitContainer1.Panel1
            // 
            this.collapsibleSplitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            // 
            // collapsibleSplitContainer1.Panel2
            // 
            this.collapsibleSplitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(198)))));
            this.collapsibleSplitContainer1.Size = new System.Drawing.Size(892, 440);
            // 
            // TreeM
            // 
            // 
            // 
            // 
            this.TreeM.BackgroundStyle.Class = "TreeBorderKey";
            this.TreeM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TreeM.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TreeM.Size = new System.Drawing.Size(250, 440);
            // 
            // StatusBar
            // 
            this.StatusBar.Location = new System.Drawing.Point(0, 495);
            // 
            // panelEx1
            // 
            this.panelEx1.Size = new System.Drawing.Size(640, 440);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.Etched;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            // 
            // txt_CName
            // 
            // 
            // 
            // 
            this.txt_CName.Border.Class = "TextBoxBorder";
            this.txt_CName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_CName.Location = new System.Drawing.Point(128, 116);
            // 
            // txt_CCode
            // 
            // 
            // 
            // 
            this.txt_CCode.Border.Class = "TextBoxBorder";
            this.txt_CCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_CCode.Location = new System.Drawing.Point(128, 78);
            // 
            // lbl_cName
            // 
            // 
            // 
            // 
            this.lbl_cName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_cName.ForeColor = System.Drawing.Color.Black;
            this.lbl_cName.Location = new System.Drawing.Point(78, 118);
            this.lbl_cName.Size = new System.Drawing.Size(75, 21);
            // 
            // lbl_cCode
            // 
            // 
            // 
            // 
            this.lbl_cCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_cCode.ForeColor = System.Drawing.Color.Black;
            this.lbl_cCode.Location = new System.Drawing.Point(78, 78);
            this.lbl_cCode.Size = new System.Drawing.Size(75, 21);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.Images.SetKeyName(0, "next.gif");
            this.imageList1.Images.SetKeyName(1, "last.gif");
            // 
            // FmInvClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(892, 517);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FmInvClass";
            this.Text = "图纸分类";
            this.Load += new System.EventHandler(this.FmInvClass_Load);
            this.Controls.SetChildIndex(this.StatusBar, 0);
            this.Controls.SetChildIndex(this.ToolBar, 0);
            this.Controls.SetChildIndex(this.pnl_Head, 0);
            this.Controls.SetChildIndex(this.collapsibleSplitContainer1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ToolBar)).EndInit();
            this.collapsibleSplitContainer1.Panel1.ResumeLayout(false);
            this.collapsibleSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.collapsibleSplitContainer1)).EndInit();
            this.collapsibleSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TreeM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBar)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

    }
}
