namespace LanyunMES.UIBase
{
    partial class FmRMDList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmRMDList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Btn_Select = new System.Windows.Forms.ToolStripButton();
            this.Btn_Reflash = new System.Windows.Forms.ToolStripButton();
            this.lbl_CompState = new System.Windows.Forms.ToolStripLabel();
            this.cbx_List = new System.Windows.Forms.ToolStripComboBox();
            this.dgMain = new System.Windows.Forms.DataGridView();
            this.dgDetail = new System.Windows.Forms.DataGridView();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.pnl_Dtools = new System.Windows.Forms.Panel();
            this.cBox_ShowDAll = new System.Windows.Forms.CheckBox();
            this.cBox_SelectAll = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.pnl_Dtools.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Btn_Select,
            this.Btn_Reflash,
            this.lbl_CompState,
            this.cbx_List});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1008, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Btn_Select
            // 
            this.Btn_Select.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Btn_Select.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Select.Image")));
            this.Btn_Select.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Btn_Select.Name = "Btn_Select";
            this.Btn_Select.Size = new System.Drawing.Size(36, 22);
            this.Btn_Select.Text = "确定";
            this.Btn_Select.Click += new System.EventHandler(this.Btn_Select_Click);
            // 
            // Btn_Reflash
            // 
            this.Btn_Reflash.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Btn_Reflash.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Reflash.Image")));
            this.Btn_Reflash.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Btn_Reflash.Name = "Btn_Reflash";
            this.Btn_Reflash.Size = new System.Drawing.Size(36, 22);
            this.Btn_Reflash.Text = "刷新";
            this.Btn_Reflash.Click += new System.EventHandler(this.Btn_Reflash_Click);
            // 
            // lbl_CompState
            // 
            this.lbl_CompState.Margin = new System.Windows.Forms.Padding(150, 1, 0, 2);
            this.lbl_CompState.Name = "lbl_CompState";
            this.lbl_CompState.Size = new System.Drawing.Size(68, 22);
            this.lbl_CompState.Text = "完成状态：";
            // 
            // cbx_List
            // 
            this.cbx_List.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_List.Items.AddRange(new object[] {
            "未完成",
            "已完成",
            "手动关闭"});
            this.cbx_List.Margin = new System.Windows.Forms.Padding(1, 0, 50, 0);
            this.cbx_List.Name = "cbx_List";
            this.cbx_List.Size = new System.Drawing.Size(121, 25);
            this.cbx_List.SelectedIndexChanged += new System.EventHandler(this.cbx_List_SelectedIndexChanged);
            // 
            // dgMain
            // 
            this.dgMain.AllowUserToResizeRows = false;
            this.dgMain.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgMain.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgMain.ColumnHeadersHeight = 25;
            this.dgMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgMain.EnableHeadersVisualStyles = false;
            this.dgMain.Location = new System.Drawing.Point(0, 0);
            this.dgMain.Name = "dgMain";
            this.dgMain.ReadOnly = true;
            this.dgMain.RowHeadersVisible = false;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Red;
            this.dgMain.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.dgMain.RowTemplate.Height = 23;
            this.dgMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgMain.Size = new System.Drawing.Size(1006, 373);
            this.dgMain.TabIndex = 1;
            this.dgMain.CurrentCellChanged += new System.EventHandler(this.dgMain_CurrentCellChanged);
            // 
            // dgDetail
            // 
            this.dgDetail.AllowUserToResizeRows = false;
            this.dgDetail.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgDetail.ColumnHeadersHeight = 25;
            this.dgDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDetail.EnableHeadersVisualStyles = false;
            this.dgDetail.Location = new System.Drawing.Point(0, 25);
            this.dgDetail.Name = "dgDetail";
            this.dgDetail.RowHeadersVisible = false;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Red;
            this.dgDetail.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dgDetail.RowTemplate.Height = 23;
            this.dgDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDetail.Size = new System.Drawing.Size(1006, 276);
            this.dgDetail.TabIndex = 2;
            // 
            // splitMain
            // 
            this.splitMain.BackColor = System.Drawing.SystemColors.Control;
            this.splitMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 25);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.dgMain);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.dgDetail);
            this.splitMain.Panel2.Controls.Add(this.pnl_Dtools);
            this.splitMain.Size = new System.Drawing.Size(1008, 683);
            this.splitMain.SplitterDistance = 375;
            this.splitMain.SplitterWidth = 5;
            this.splitMain.TabIndex = 3;
            // 
            // pnl_Dtools
            // 
            this.pnl_Dtools.BackColor = System.Drawing.SystemColors.Control;
            this.pnl_Dtools.Controls.Add(this.cBox_ShowDAll);
            this.pnl_Dtools.Controls.Add(this.cBox_SelectAll);
            this.pnl_Dtools.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Dtools.Location = new System.Drawing.Point(0, 0);
            this.pnl_Dtools.Name = "pnl_Dtools";
            this.pnl_Dtools.Size = new System.Drawing.Size(1006, 25);
            this.pnl_Dtools.TabIndex = 3;
            // 
            // cBox_ShowDAll
            // 
            this.cBox_ShowDAll.AutoSize = true;
            this.cBox_ShowDAll.Location = new System.Drawing.Point(90, 5);
            this.cBox_ShowDAll.Name = "cBox_ShowDAll";
            this.cBox_ShowDAll.Size = new System.Drawing.Size(108, 16);
            this.cBox_ShowDAll.TabIndex = 1;
            this.cBox_ShowDAll.Text = "包括已完成记录";
            this.cBox_ShowDAll.UseVisualStyleBackColor = true;
            this.cBox_ShowDAll.CheckedChanged += new System.EventHandler(this.cBox_ShowDAll_Click);
            // 
            // cBox_SelectAll
            // 
            this.cBox_SelectAll.AutoSize = true;
            this.cBox_SelectAll.Location = new System.Drawing.Point(12, 5);
            this.cBox_SelectAll.Name = "cBox_SelectAll";
            this.cBox_SelectAll.Size = new System.Drawing.Size(48, 16);
            this.cBox_SelectAll.TabIndex = 0;
            this.cBox_SelectAll.Text = "全选";
            this.cBox_SelectAll.UseVisualStyleBackColor = true;
            this.cBox_SelectAll.CheckedChanged += new System.EventHandler(this.cBox_SelectAll_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel1,
            this.statusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 708);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel1
            // 
            this.statusLabel1.Name = "statusLabel1";
            this.statusLabel1.Size = new System.Drawing.Size(68, 17);
            this.statusLabel1.Text = "主表记录：";
            // 
            // statusLabel2
            // 
            this.statusLabel2.Name = "statusLabel2";
            this.statusLabel2.Size = new System.Drawing.Size(11, 17);
            this.statusLabel2.Text = "|";
            // 
            // FmRMDList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.Name = "FmRMDList";
            this.ShowIcon = false;
            this.Text = "FmRMDList";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetail)).EndInit();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.pnl_Dtools.ResumeLayout(false);
            this.pnl_Dtools.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.Panel pnl_Dtools;
        private System.Windows.Forms.CheckBox cBox_SelectAll;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel2;
        protected System.Windows.Forms.DataGridView dgMain;
        protected System.Windows.Forms.DataGridView dgDetail;
        protected System.Windows.Forms.ToolStrip toolStrip1;
        protected System.Windows.Forms.ToolStripComboBox cbx_List;
        protected System.Windows.Forms.ToolStripButton Btn_Select;
        protected System.Windows.Forms.ToolStripButton Btn_Reflash;
        protected System.Windows.Forms.ToolStripLabel lbl_CompState;
        protected System.Windows.Forms.CheckBox cBox_ShowDAll;
    }
}