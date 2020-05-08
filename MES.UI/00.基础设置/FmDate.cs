using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace U8Ext
{
	/// <summary>
	/// FmDate 的摘要说明。
	/// </summary>
	public class FmDate : System.Windows.Forms.Form
	{
		#region 控件
		private System.Windows.Forms.Panel pnl01;
		private System.Windows.Forms.Panel pnl02;
		private System.Windows.Forms.Panel pnl03;
		private System.Windows.Forms.Label lblW1;
		private System.Windows.Forms.Label lblW2;
		private System.Windows.Forms.Label lblW3;
		private System.Windows.Forms.Label lblW4;
		private System.Windows.Forms.Label lblW5;
		private System.Windows.Forms.Label lblW6;
		private System.Windows.Forms.Label lblW7;
		private System.Windows.Forms.Label lblDay1;
		private System.Windows.Forms.Label lblDay2;
		private System.Windows.Forms.Label lblDay3;
		private System.Windows.Forms.Label lblDay4;
		private System.Windows.Forms.Label lblDay5;
		private System.Windows.Forms.Label lblDay6;
		private System.Windows.Forms.Label lblDay7;
		private System.Windows.Forms.Label lblDay8;
		private System.Windows.Forms.Label lblDay9;
		private System.Windows.Forms.Label lblDay10;
		private System.Windows.Forms.Label lblDay11;
		private System.Windows.Forms.Label lblDay12;
		private System.Windows.Forms.Label lblDay13;
		private System.Windows.Forms.Label lblDay14;
		private System.Windows.Forms.Label lblDay17;
		private System.Windows.Forms.Label lblDay16;
		private System.Windows.Forms.Label lblDay15;
		private System.Windows.Forms.Label lblDay28;
		private System.Windows.Forms.Label lblDay27;
		private System.Windows.Forms.Label lblDay26;
		private System.Windows.Forms.Label lblDay25;
		private System.Windows.Forms.Label lblDay24;
		private System.Windows.Forms.Label lblDay23;
		private System.Windows.Forms.Label lblDay22;
		private System.Windows.Forms.Label lblDay21;
		private System.Windows.Forms.Label lblDay20;
		private System.Windows.Forms.Label lblDay19;
		private System.Windows.Forms.Label lblDay18;
		private System.Windows.Forms.Label lblDay35;
		private System.Windows.Forms.Label lblDay34;
		private System.Windows.Forms.Label lblDay33;
		private System.Windows.Forms.Label lblDay32;
		private System.Windows.Forms.Label lblDay31;
		private System.Windows.Forms.Label lblDay30;
		private System.Windows.Forms.Label lblDay29;
        private System.Windows.Forms.Label lblDay42;
        private System.Windows.Forms.Label lblDay41;
        private System.Windows.Forms.Label lblDay40;
        private System.Windows.Forms.Label lblDay39;
        private System.Windows.Forms.Label lblDay38;
        private System.Windows.Forms.Label lblDay37;
        private System.Windows.Forms.Label lblDay36;
		private System.Windows.Forms.ComboBox cboBoxSelectYear;
		private System.Windows.Forms.ComboBox cboBoxSelectMonth;
		private System.Windows.Forms.Label lblYear;
		private System.Windows.Forms.Button btnPreYear;
		private System.Windows.Forms.Button btnNextYear;
		private System.Windows.Forms.Button btnToday;
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public FmDate()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //

            #region 初始年份
            for (int i = 1980; i <= 2099; i++)
			{
				this.cboBoxSelectYear.Items.Add(i);
            }
            #endregion

            #region 初始月份
            this.cboBoxSelectMonth.Items.Clear();
			this.cboBoxSelectMonth.Items.Add("一月");
			this.cboBoxSelectMonth.Items.Add("二月");
			this.cboBoxSelectMonth.Items.Add("三月");
			this.cboBoxSelectMonth.Items.Add("四月");
			this.cboBoxSelectMonth.Items.Add("五月");
			this.cboBoxSelectMonth.Items.Add("六月");
			this.cboBoxSelectMonth.Items.Add("七月");
			this.cboBoxSelectMonth.Items.Add("八月");
			this.cboBoxSelectMonth.Items.Add("九月");
			this.cboBoxSelectMonth.Items.Add("十月");
			this.cboBoxSelectMonth.Items.Add("十一月");
			this.cboBoxSelectMonth.Items.Add("十二月");
            #endregion

            #region 关联事件
            foreach (Control c in this.pnl02.Controls)
			{
				if (c.Name.Length >= 6 && c.Name.Substring(0, 6).ToUpper() == "LBLDAY")
				{
					c.Click		+= new System.EventHandler(this.lblDayClick);
					c.DoubleClick += new System.EventHandler(this.lblDayDoubleClick);
				}
            }
            #endregion

            Application.DoEvents();
		}

        public FmDate(string strAttaText) : this()
        {
            if (strAttaText != null && strAttaText.Trim() != "")
                this.Text = this.Text + " - " + strAttaText;
        }

		#region 清理所有正在使用的资源
		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmDate));
            this.pnl01 = new System.Windows.Forms.Panel();
            this.btnNextYear = new System.Windows.Forms.Button();
            this.btnPreYear = new System.Windows.Forms.Button();
            this.lblYear = new System.Windows.Forms.Label();
            this.cboBoxSelectMonth = new System.Windows.Forms.ComboBox();
            this.cboBoxSelectYear = new System.Windows.Forms.ComboBox();
            this.pnl02 = new System.Windows.Forms.Panel();
            this.lblDay35 = new System.Windows.Forms.Label();
            this.lblDay34 = new System.Windows.Forms.Label();
            this.lblDay33 = new System.Windows.Forms.Label();
            this.lblDay32 = new System.Windows.Forms.Label();
            this.lblDay31 = new System.Windows.Forms.Label();
            this.lblDay30 = new System.Windows.Forms.Label();
            this.lblDay29 = new System.Windows.Forms.Label();
            this.lblDay28 = new System.Windows.Forms.Label();
            this.lblDay27 = new System.Windows.Forms.Label();
            this.lblDay26 = new System.Windows.Forms.Label();
            this.lblDay25 = new System.Windows.Forms.Label();
            this.lblDay24 = new System.Windows.Forms.Label();
            this.lblDay23 = new System.Windows.Forms.Label();
            this.lblDay22 = new System.Windows.Forms.Label();
            this.lblDay21 = new System.Windows.Forms.Label();
            this.lblDay20 = new System.Windows.Forms.Label();
            this.lblDay19 = new System.Windows.Forms.Label();
            this.lblDay18 = new System.Windows.Forms.Label();
            this.lblDay17 = new System.Windows.Forms.Label();
            this.lblDay16 = new System.Windows.Forms.Label();
            this.lblDay15 = new System.Windows.Forms.Label();
            this.lblDay14 = new System.Windows.Forms.Label();
            this.lblDay13 = new System.Windows.Forms.Label();
            this.lblDay12 = new System.Windows.Forms.Label();
            this.lblDay11 = new System.Windows.Forms.Label();
            this.lblDay10 = new System.Windows.Forms.Label();
            this.lblDay9 = new System.Windows.Forms.Label();
            this.lblDay8 = new System.Windows.Forms.Label();
            this.lblDay7 = new System.Windows.Forms.Label();
            this.lblDay6 = new System.Windows.Forms.Label();
            this.lblDay5 = new System.Windows.Forms.Label();
            this.lblDay4 = new System.Windows.Forms.Label();
            this.lblDay3 = new System.Windows.Forms.Label();
            this.lblDay2 = new System.Windows.Forms.Label();
            this.lblDay1 = new System.Windows.Forms.Label();
            this.lblW7 = new System.Windows.Forms.Label();
            this.lblW6 = new System.Windows.Forms.Label();
            this.lblW5 = new System.Windows.Forms.Label();
            this.lblW4 = new System.Windows.Forms.Label();
            this.lblW3 = new System.Windows.Forms.Label();
            this.lblW2 = new System.Windows.Forms.Label();
            this.lblW1 = new System.Windows.Forms.Label();
            this.pnl03 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnToday = new System.Windows.Forms.Button();
            this.lblDay42 = new System.Windows.Forms.Label();
            this.lblDay41 = new System.Windows.Forms.Label();
            this.lblDay40 = new System.Windows.Forms.Label();
            this.lblDay39 = new System.Windows.Forms.Label();
            this.lblDay38 = new System.Windows.Forms.Label();
            this.lblDay37 = new System.Windows.Forms.Label();
            this.lblDay36 = new System.Windows.Forms.Label();
            this.pnl01.SuspendLayout();
            this.pnl02.SuspendLayout();
            this.pnl03.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl01
            // 
            this.pnl01.BackColor = System.Drawing.SystemColors.Control;
            this.pnl01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl01.Controls.Add(this.btnNextYear);
            this.pnl01.Controls.Add(this.btnPreYear);
            this.pnl01.Controls.Add(this.lblYear);
            this.pnl01.Controls.Add(this.cboBoxSelectMonth);
            this.pnl01.Controls.Add(this.cboBoxSelectYear);
            this.pnl01.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl01.Location = new System.Drawing.Point(0, 0);
            this.pnl01.Name = "pnl01";
            this.pnl01.Size = new System.Drawing.Size(289, 32);
            this.pnl01.TabIndex = 0;
            // 
            // btnNextYear
            // 
            this.btnNextYear.Image = ((System.Drawing.Image)(resources.GetObject("btnNextYear.Image")));
            this.btnNextYear.Location = new System.Drawing.Point(252, 3);
            this.btnNextYear.Name = "btnNextYear";
            this.btnNextYear.Size = new System.Drawing.Size(32, 24);
            this.btnNextYear.TabIndex = 4;
            this.btnNextYear.Click += new System.EventHandler(this.btnNextYear_Click);
            // 
            // btnPreYear
            // 
            this.btnPreYear.Image = ((System.Drawing.Image)(resources.GetObject("btnPreYear.Image")));
            this.btnPreYear.Location = new System.Drawing.Point(3, 3);
            this.btnPreYear.Name = "btnPreYear";
            this.btnPreYear.Size = new System.Drawing.Size(32, 24);
            this.btnPreYear.TabIndex = 3;
            this.btnPreYear.Click += new System.EventHandler(this.btnPreYear_Click);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(135, 7);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(17, 12);
            this.lblYear.TabIndex = 2;
            this.lblYear.Text = "年";
            this.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboBoxSelectMonth
            // 
            this.cboBoxSelectMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBoxSelectMonth.Location = new System.Drawing.Point(159, 5);
            this.cboBoxSelectMonth.Name = "cboBoxSelectMonth";
            this.cboBoxSelectMonth.Size = new System.Drawing.Size(88, 20);
            this.cboBoxSelectMonth.TabIndex = 1;
            this.cboBoxSelectMonth.SelectedIndexChanged += new System.EventHandler(this.cboBoxSelectMonth_SelectedIndexChanged);
            // 
            // cboBoxSelectYear
            // 
            this.cboBoxSelectYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBoxSelectYear.Location = new System.Drawing.Point(40, 5);
            this.cboBoxSelectYear.Name = "cboBoxSelectYear";
            this.cboBoxSelectYear.Size = new System.Drawing.Size(88, 20);
            this.cboBoxSelectYear.TabIndex = 0;
            this.cboBoxSelectYear.SelectedIndexChanged += new System.EventHandler(this.cboBoxSelectYear_SelectedIndexChanged);
            // 
            // pnl02
            // 
            this.pnl02.BackColor = System.Drawing.SystemColors.Control;
            this.pnl02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl02.Controls.Add(this.lblDay42);
            this.pnl02.Controls.Add(this.lblDay41);
            this.pnl02.Controls.Add(this.lblDay40);
            this.pnl02.Controls.Add(this.lblDay39);
            this.pnl02.Controls.Add(this.lblDay38);
            this.pnl02.Controls.Add(this.lblDay37);
            this.pnl02.Controls.Add(this.lblDay36);
            this.pnl02.Controls.Add(this.lblDay35);
            this.pnl02.Controls.Add(this.lblDay34);
            this.pnl02.Controls.Add(this.lblDay33);
            this.pnl02.Controls.Add(this.lblDay32);
            this.pnl02.Controls.Add(this.lblDay31);
            this.pnl02.Controls.Add(this.lblDay30);
            this.pnl02.Controls.Add(this.lblDay29);
            this.pnl02.Controls.Add(this.lblDay28);
            this.pnl02.Controls.Add(this.lblDay27);
            this.pnl02.Controls.Add(this.lblDay26);
            this.pnl02.Controls.Add(this.lblDay25);
            this.pnl02.Controls.Add(this.lblDay24);
            this.pnl02.Controls.Add(this.lblDay23);
            this.pnl02.Controls.Add(this.lblDay22);
            this.pnl02.Controls.Add(this.lblDay21);
            this.pnl02.Controls.Add(this.lblDay20);
            this.pnl02.Controls.Add(this.lblDay19);
            this.pnl02.Controls.Add(this.lblDay18);
            this.pnl02.Controls.Add(this.lblDay17);
            this.pnl02.Controls.Add(this.lblDay16);
            this.pnl02.Controls.Add(this.lblDay15);
            this.pnl02.Controls.Add(this.lblDay14);
            this.pnl02.Controls.Add(this.lblDay13);
            this.pnl02.Controls.Add(this.lblDay12);
            this.pnl02.Controls.Add(this.lblDay11);
            this.pnl02.Controls.Add(this.lblDay10);
            this.pnl02.Controls.Add(this.lblDay9);
            this.pnl02.Controls.Add(this.lblDay8);
            this.pnl02.Controls.Add(this.lblDay7);
            this.pnl02.Controls.Add(this.lblDay6);
            this.pnl02.Controls.Add(this.lblDay5);
            this.pnl02.Controls.Add(this.lblDay4);
            this.pnl02.Controls.Add(this.lblDay3);
            this.pnl02.Controls.Add(this.lblDay2);
            this.pnl02.Controls.Add(this.lblDay1);
            this.pnl02.Controls.Add(this.lblW7);
            this.pnl02.Controls.Add(this.lblW6);
            this.pnl02.Controls.Add(this.lblW5);
            this.pnl02.Controls.Add(this.lblW4);
            this.pnl02.Controls.Add(this.lblW3);
            this.pnl02.Controls.Add(this.lblW2);
            this.pnl02.Controls.Add(this.lblW1);
            this.pnl02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl02.Location = new System.Drawing.Point(0, 32);
            this.pnl02.Name = "pnl02";
            this.pnl02.Size = new System.Drawing.Size(289, 126);
            this.pnl02.TabIndex = 1;
            // 
            // lblDay35
            // 
            this.lblDay35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay35.Location = new System.Drawing.Point(244, 90);
            this.lblDay35.Name = "lblDay35";
            this.lblDay35.Size = new System.Drawing.Size(40, 16);
            this.lblDay35.TabIndex = 41;
            this.lblDay35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay34
            // 
            this.lblDay34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay34.Location = new System.Drawing.Point(204, 90);
            this.lblDay34.Name = "lblDay34";
            this.lblDay34.Size = new System.Drawing.Size(40, 16);
            this.lblDay34.TabIndex = 40;
            this.lblDay34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay33
            // 
            this.lblDay33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay33.Location = new System.Drawing.Point(164, 90);
            this.lblDay33.Name = "lblDay33";
            this.lblDay33.Size = new System.Drawing.Size(40, 16);
            this.lblDay33.TabIndex = 39;
            this.lblDay33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay32
            // 
            this.lblDay32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay32.Location = new System.Drawing.Point(124, 90);
            this.lblDay32.Name = "lblDay32";
            this.lblDay32.Size = new System.Drawing.Size(40, 16);
            this.lblDay32.TabIndex = 38;
            this.lblDay32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay31
            // 
            this.lblDay31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay31.Location = new System.Drawing.Point(84, 90);
            this.lblDay31.Name = "lblDay31";
            this.lblDay31.Size = new System.Drawing.Size(40, 16);
            this.lblDay31.TabIndex = 37;
            this.lblDay31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay30
            // 
            this.lblDay30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay30.Location = new System.Drawing.Point(44, 90);
            this.lblDay30.Name = "lblDay30";
            this.lblDay30.Size = new System.Drawing.Size(40, 16);
            this.lblDay30.TabIndex = 36;
            this.lblDay30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay29
            // 
            this.lblDay29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay29.Location = new System.Drawing.Point(4, 90);
            this.lblDay29.Name = "lblDay29";
            this.lblDay29.Size = new System.Drawing.Size(40, 16);
            this.lblDay29.TabIndex = 35;
            this.lblDay29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay28
            // 
            this.lblDay28.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay28.Location = new System.Drawing.Point(244, 74);
            this.lblDay28.Name = "lblDay28";
            this.lblDay28.Size = new System.Drawing.Size(40, 16);
            this.lblDay28.TabIndex = 34;
            this.lblDay28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay27
            // 
            this.lblDay27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay27.Location = new System.Drawing.Point(204, 74);
            this.lblDay27.Name = "lblDay27";
            this.lblDay27.Size = new System.Drawing.Size(40, 16);
            this.lblDay27.TabIndex = 33;
            this.lblDay27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay26
            // 
            this.lblDay26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay26.Location = new System.Drawing.Point(164, 74);
            this.lblDay26.Name = "lblDay26";
            this.lblDay26.Size = new System.Drawing.Size(40, 16);
            this.lblDay26.TabIndex = 32;
            this.lblDay26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay25
            // 
            this.lblDay25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay25.Location = new System.Drawing.Point(124, 74);
            this.lblDay25.Name = "lblDay25";
            this.lblDay25.Size = new System.Drawing.Size(40, 16);
            this.lblDay25.TabIndex = 31;
            this.lblDay25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay24
            // 
            this.lblDay24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay24.Location = new System.Drawing.Point(84, 74);
            this.lblDay24.Name = "lblDay24";
            this.lblDay24.Size = new System.Drawing.Size(40, 16);
            this.lblDay24.TabIndex = 30;
            this.lblDay24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay23
            // 
            this.lblDay23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay23.Location = new System.Drawing.Point(44, 74);
            this.lblDay23.Name = "lblDay23";
            this.lblDay23.Size = new System.Drawing.Size(40, 16);
            this.lblDay23.TabIndex = 29;
            this.lblDay23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay22
            // 
            this.lblDay22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay22.Location = new System.Drawing.Point(4, 74);
            this.lblDay22.Name = "lblDay22";
            this.lblDay22.Size = new System.Drawing.Size(40, 16);
            this.lblDay22.TabIndex = 28;
            this.lblDay22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay21
            // 
            this.lblDay21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay21.Location = new System.Drawing.Point(244, 58);
            this.lblDay21.Name = "lblDay21";
            this.lblDay21.Size = new System.Drawing.Size(40, 16);
            this.lblDay21.TabIndex = 27;
            this.lblDay21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay20
            // 
            this.lblDay20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay20.Location = new System.Drawing.Point(204, 58);
            this.lblDay20.Name = "lblDay20";
            this.lblDay20.Size = new System.Drawing.Size(40, 16);
            this.lblDay20.TabIndex = 26;
            this.lblDay20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay19
            // 
            this.lblDay19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay19.Location = new System.Drawing.Point(164, 58);
            this.lblDay19.Name = "lblDay19";
            this.lblDay19.Size = new System.Drawing.Size(40, 16);
            this.lblDay19.TabIndex = 25;
            this.lblDay19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay18
            // 
            this.lblDay18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay18.Location = new System.Drawing.Point(124, 58);
            this.lblDay18.Name = "lblDay18";
            this.lblDay18.Size = new System.Drawing.Size(40, 16);
            this.lblDay18.TabIndex = 24;
            this.lblDay18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay17
            // 
            this.lblDay17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay17.Location = new System.Drawing.Point(84, 58);
            this.lblDay17.Name = "lblDay17";
            this.lblDay17.Size = new System.Drawing.Size(40, 16);
            this.lblDay17.TabIndex = 23;
            this.lblDay17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay16
            // 
            this.lblDay16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay16.Location = new System.Drawing.Point(44, 58);
            this.lblDay16.Name = "lblDay16";
            this.lblDay16.Size = new System.Drawing.Size(40, 16);
            this.lblDay16.TabIndex = 22;
            this.lblDay16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay15
            // 
            this.lblDay15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay15.Location = new System.Drawing.Point(4, 58);
            this.lblDay15.Name = "lblDay15";
            this.lblDay15.Size = new System.Drawing.Size(40, 16);
            this.lblDay15.TabIndex = 21;
            this.lblDay15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay14
            // 
            this.lblDay14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay14.Location = new System.Drawing.Point(244, 42);
            this.lblDay14.Name = "lblDay14";
            this.lblDay14.Size = new System.Drawing.Size(40, 16);
            this.lblDay14.TabIndex = 20;
            this.lblDay14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay13
            // 
            this.lblDay13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay13.Location = new System.Drawing.Point(204, 42);
            this.lblDay13.Name = "lblDay13";
            this.lblDay13.Size = new System.Drawing.Size(40, 16);
            this.lblDay13.TabIndex = 19;
            this.lblDay13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay12
            // 
            this.lblDay12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay12.Location = new System.Drawing.Point(164, 42);
            this.lblDay12.Name = "lblDay12";
            this.lblDay12.Size = new System.Drawing.Size(40, 16);
            this.lblDay12.TabIndex = 18;
            this.lblDay12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay11
            // 
            this.lblDay11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay11.Location = new System.Drawing.Point(124, 42);
            this.lblDay11.Name = "lblDay11";
            this.lblDay11.Size = new System.Drawing.Size(40, 16);
            this.lblDay11.TabIndex = 17;
            this.lblDay11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay10
            // 
            this.lblDay10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay10.Location = new System.Drawing.Point(84, 42);
            this.lblDay10.Name = "lblDay10";
            this.lblDay10.Size = new System.Drawing.Size(40, 16);
            this.lblDay10.TabIndex = 16;
            this.lblDay10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay9
            // 
            this.lblDay9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay9.Location = new System.Drawing.Point(44, 42);
            this.lblDay9.Name = "lblDay9";
            this.lblDay9.Size = new System.Drawing.Size(40, 16);
            this.lblDay9.TabIndex = 15;
            this.lblDay9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay8
            // 
            this.lblDay8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay8.Location = new System.Drawing.Point(4, 42);
            this.lblDay8.Name = "lblDay8";
            this.lblDay8.Size = new System.Drawing.Size(40, 16);
            this.lblDay8.TabIndex = 14;
            this.lblDay8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay7
            // 
            this.lblDay7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay7.Location = new System.Drawing.Point(244, 26);
            this.lblDay7.Name = "lblDay7";
            this.lblDay7.Size = new System.Drawing.Size(40, 16);
            this.lblDay7.TabIndex = 13;
            this.lblDay7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay6
            // 
            this.lblDay6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay6.Location = new System.Drawing.Point(204, 26);
            this.lblDay6.Name = "lblDay6";
            this.lblDay6.Size = new System.Drawing.Size(40, 16);
            this.lblDay6.TabIndex = 12;
            this.lblDay6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay5
            // 
            this.lblDay5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay5.Location = new System.Drawing.Point(164, 26);
            this.lblDay5.Name = "lblDay5";
            this.lblDay5.Size = new System.Drawing.Size(40, 16);
            this.lblDay5.TabIndex = 11;
            this.lblDay5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay4
            // 
            this.lblDay4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay4.Location = new System.Drawing.Point(124, 26);
            this.lblDay4.Name = "lblDay4";
            this.lblDay4.Size = new System.Drawing.Size(40, 16);
            this.lblDay4.TabIndex = 10;
            this.lblDay4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay3
            // 
            this.lblDay3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay3.Location = new System.Drawing.Point(84, 26);
            this.lblDay3.Name = "lblDay3";
            this.lblDay3.Size = new System.Drawing.Size(40, 16);
            this.lblDay3.TabIndex = 9;
            this.lblDay3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay2
            // 
            this.lblDay2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay2.Location = new System.Drawing.Point(44, 26);
            this.lblDay2.Name = "lblDay2";
            this.lblDay2.Size = new System.Drawing.Size(40, 16);
            this.lblDay2.TabIndex = 8;
            this.lblDay2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay1
            // 
            this.lblDay1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay1.Location = new System.Drawing.Point(4, 26);
            this.lblDay1.Name = "lblDay1";
            this.lblDay1.Size = new System.Drawing.Size(40, 16);
            this.lblDay1.TabIndex = 7;
            this.lblDay1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblW7
            // 
            this.lblW7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblW7.Location = new System.Drawing.Point(244, 2);
            this.lblW7.Name = "lblW7";
            this.lblW7.Size = new System.Drawing.Size(40, 16);
            this.lblW7.TabIndex = 6;
            this.lblW7.Text = "六";
            this.lblW7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblW6
            // 
            this.lblW6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblW6.Location = new System.Drawing.Point(204, 2);
            this.lblW6.Name = "lblW6";
            this.lblW6.Size = new System.Drawing.Size(40, 16);
            this.lblW6.TabIndex = 5;
            this.lblW6.Text = "五";
            this.lblW6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblW5
            // 
            this.lblW5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblW5.Location = new System.Drawing.Point(164, 2);
            this.lblW5.Name = "lblW5";
            this.lblW5.Size = new System.Drawing.Size(40, 16);
            this.lblW5.TabIndex = 4;
            this.lblW5.Text = "四";
            this.lblW5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblW4
            // 
            this.lblW4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblW4.Location = new System.Drawing.Point(124, 2);
            this.lblW4.Name = "lblW4";
            this.lblW4.Size = new System.Drawing.Size(40, 16);
            this.lblW4.TabIndex = 3;
            this.lblW4.Text = "三";
            this.lblW4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblW3
            // 
            this.lblW3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblW3.Location = new System.Drawing.Point(84, 2);
            this.lblW3.Name = "lblW3";
            this.lblW3.Size = new System.Drawing.Size(40, 16);
            this.lblW3.TabIndex = 2;
            this.lblW3.Text = "二";
            this.lblW3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblW2
            // 
            this.lblW2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblW2.Location = new System.Drawing.Point(44, 2);
            this.lblW2.Name = "lblW2";
            this.lblW2.Size = new System.Drawing.Size(40, 16);
            this.lblW2.TabIndex = 1;
            this.lblW2.Text = "一";
            this.lblW2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblW1
            // 
            this.lblW1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblW1.Location = new System.Drawing.Point(4, 2);
            this.lblW1.Name = "lblW1";
            this.lblW1.Size = new System.Drawing.Size(40, 16);
            this.lblW1.TabIndex = 0;
            this.lblW1.Text = "日";
            this.lblW1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl03
            // 
            this.pnl03.BackColor = System.Drawing.SystemColors.Control;
            this.pnl03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl03.Controls.Add(this.btnCancel);
            this.pnl03.Controls.Add(this.btnSelect);
            this.pnl03.Controls.Add(this.btnToday);
            this.pnl03.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl03.Location = new System.Drawing.Point(0, 158);
            this.pnl03.Name = "pnl03";
            this.pnl03.Size = new System.Drawing.Size(289, 32);
            this.pnl03.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(235, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(48, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSelect.Location = new System.Drawing.Point(186, 3);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(48, 24);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "选择";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnToday
            // 
            this.btnToday.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnToday.Location = new System.Drawing.Point(3, 3);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(48, 24);
            this.btnToday.TabIndex = 0;
            this.btnToday.Text = "今天";
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            // 
            // lblDay42
            // 
            this.lblDay42.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay42.Location = new System.Drawing.Point(244, 106);
            this.lblDay42.Name = "lblDay42";
            this.lblDay42.Size = new System.Drawing.Size(40, 16);
            this.lblDay42.TabIndex = 48;
            this.lblDay42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay41
            // 
            this.lblDay41.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay41.Location = new System.Drawing.Point(204, 106);
            this.lblDay41.Name = "lblDay41";
            this.lblDay41.Size = new System.Drawing.Size(40, 16);
            this.lblDay41.TabIndex = 47;
            this.lblDay41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay40
            // 
            this.lblDay40.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay40.Location = new System.Drawing.Point(164, 106);
            this.lblDay40.Name = "lblDay40";
            this.lblDay40.Size = new System.Drawing.Size(40, 16);
            this.lblDay40.TabIndex = 46;
            this.lblDay40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay39
            // 
            this.lblDay39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay39.Location = new System.Drawing.Point(124, 106);
            this.lblDay39.Name = "lblDay39";
            this.lblDay39.Size = new System.Drawing.Size(40, 16);
            this.lblDay39.TabIndex = 45;
            this.lblDay39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay38
            // 
            this.lblDay38.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay38.Location = new System.Drawing.Point(84, 106);
            this.lblDay38.Name = "lblDay38";
            this.lblDay38.Size = new System.Drawing.Size(40, 16);
            this.lblDay38.TabIndex = 44;
            this.lblDay38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay37
            // 
            this.lblDay37.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay37.Location = new System.Drawing.Point(44, 106);
            this.lblDay37.Name = "lblDay37";
            this.lblDay37.Size = new System.Drawing.Size(40, 16);
            this.lblDay37.TabIndex = 43;
            this.lblDay37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay36
            // 
            this.lblDay36.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDay36.Location = new System.Drawing.Point(4, 106);
            this.lblDay36.Name = "lblDay36";
            this.lblDay36.Size = new System.Drawing.Size(40, 16);
            this.lblDay36.TabIndex = 42;
            this.lblDay36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FmDate
            // 
            this.AcceptButton = this.btnSelect;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(289, 190);
            this.Controls.Add(this.pnl02);
            this.Controls.Add(this.pnl03);
            this.Controls.Add(this.pnl01);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FmDate";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "日期";
            this.Load += new System.EventHandler(this.FmDate_Load);
            this.pnl01.ResumeLayout(false);
            this.pnl01.PerformLayout();
            this.pnl02.ResumeLayout(false);
            this.pnl03.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		public string DateTimeSelected
		{
			get { return this.m_strDateTimeSelected; }
            set { this.m_strDateTimeSelected = value; }
		}
		private string m_strDateTimeSelected = "";

		private int m_nSelectedYear		= DateTime.Now.Date.Year;
		private int m_nSelectedMonth	= DateTime.Now.Date.Month;
		private int m_nSelectedDay		= DateTime.Now.Date.Day;

        private int m_nPrevYear = 0, m_nPrevMonth = 0, m_nPrevMonthDays = 0;
        private int m_nNextYear = 0, m_nNextMonth = 0, m_nNextMonthDays = 0;

		/// <summary>
		/// 获取某年某月的天数
		/// </summary>
		/// <param name="nYear"></param>
		/// <param name="nMonth"></param>
		/// <returns></returns>
		private int GetDaysInMonth(int nYear, int nMonth)
		{
			return DateTime.DaysInMonth(nYear, nMonth);
		}

		/// <summary>
		/// 获取某年某月1号的星期
		/// </summary>
		/// <param name="nYear"></param>
		/// <param name="nMonth"></param>
		/// <returns></returns>
		private int GetDayOfWeekOfFirstDayInMonth(int nYear, int nMonth)
		{
			return (int)((new DateTime(nYear, nMonth, 1)).DayOfWeek);
		}

		private void ShowDateOfYearMonth(int nYear, int nMonth)
		{
            this.m_nPrevYear = nYear;
            this.m_nPrevMonth = nMonth - 1;
            if (this.m_nPrevMonth == 0)
            {
                this.m_nPrevYear = nYear - 1;
                this.m_nPrevMonth = 12;
            }
            this.m_nNextYear = nYear;
            this.m_nNextMonth = nMonth + 1;
            if (this.m_nNextMonth == 13)
            {
                this.m_nNextYear = nYear + 1;
                this.m_nNextMonth = 1;
            }

            this.m_nPrevMonthDays = GetDaysInMonth(this.m_nPrevYear, this.m_nPrevMonth);
            this.m_nNextMonthDays = GetDaysInMonth(this.m_nNextYear, this.m_nNextMonth);

			int nDays = GetDaysInMonth(nYear, nMonth), nDayOfWeek = GetDayOfWeekOfFirstDayInMonth(nYear, nMonth);
			int nPosition = nDayOfWeek + 1;

			foreach (Control c in this.pnl02.Controls)
			{
				if (c.Name.Length >= 6 && c.Name.Substring(0, 6).ToUpper() == "LBLDAY")
				{
					c.Enabled = true;
                    (c as Label).Text = "";
					(c as Label).BorderStyle = BorderStyle.Fixed3D;
					(c as Label).ForeColor = Color.Black;
					(c as Label).BackColor = Color.White;
				}
			}
            Application.DoEvents();

            int nPrevMonthDays = this.m_nPrevMonthDays;
            for (int i = nDayOfWeek; i >= 1; i--)
            {
                foreach (Control c in this.pnl02.Controls)
                {
                    if (c.Name.ToUpper() == "LBLDAY" + i.ToString())
                    {
                        int nD = nPrevMonthDays--;
                        (c as Label).Tag = this.m_nPrevYear + "-" + this.m_nPrevMonth + "-" + nD;
                        (c as Label).Text = nD.ToString();
                        (c as Label).ForeColor = SystemColors.Control;
                        break;
                    }
                }
            }
            Application.DoEvents();

            for (int i = 1; i <= nDays; i++)
            {
                foreach (Control c in this.pnl02.Controls)
                {
                    if (c.Name.ToUpper() == "LBLDAY" + nPosition.ToString())
                    {
                        (c as Label).Tag = nYear + "-" + nMonth + "-" + i;
                        (c as Label).Text = i.ToString();
                        if (i == this.m_nSelectedDay) (c as Label).BackColor = Color.Green;
                        if (DateTime.Now.Date.Year == nYear && DateTime.Now.Date.Month == nMonth && i == DateTime.Now.Date.Day)
                        {
                            (c as Label).BorderStyle = BorderStyle.FixedSingle;
                            (c as Label).ForeColor = Color.Red;
                        }
                        break;
                    }
                }
                nPosition += 1;
            }
            Application.DoEvents();

            int nCount = 1;
            for (int i = nPosition; i <= 42; i++)
            {
                foreach (Control c in this.pnl02.Controls)
                {
                    if (c.Name.ToUpper() == "LBLDAY" + i.ToString())
                    {
                        int nD = nCount++;
                        (c as Label).Tag = this.m_nNextYear + "-" + this.m_nNextMonth + "-" + nD;
                        (c as Label).Text = nD.ToString();
                        (c as Label).ForeColor = SystemColors.Control;
                        break;
                    }
                }
            }
            Application.DoEvents();
		}

		private void lblDayClick(object sender, System.EventArgs e)
		{
            if (((sender) as Label).BackColor != Color.Green)
            {
                foreach (Control c in this.pnl02.Controls)
                {
                    if (c.Name.Length >= 6 && c.Name.Substring(0, 6).ToUpper() == "LBLDAY")
                    {
                        c.BackColor = Color.White;
                        this.m_nSelectedDay = int.Parse(((sender) as Label).Text);
                    }
                }
                ((sender) as Label).BackColor = Color.Green;
            }

            Application.DoEvents();

            DateTime dt = Convert.ToDateTime(((sender) as Label).Tag.ToString());
            if (dt.Year != int.Parse(this.cboBoxSelectYear.Text) || dt.Month != this.cboBoxSelectMonth.SelectedIndex + 1)
            {
                ShowDateOfYearMonth(dt.Year, dt.Month);

                this.cboBoxSelectYear.SelectedIndexChanged -= new System.EventHandler(this.cboBoxSelectYear_SelectedIndexChanged);
                this.cboBoxSelectMonth.SelectedIndexChanged -= new System.EventHandler(this.cboBoxSelectMonth_SelectedIndexChanged);
                this.cboBoxSelectYear.SelectedIndex = this.cboBoxSelectYear.FindString(dt.Year.ToString());
                this.cboBoxSelectMonth.SelectedIndex = dt.Month - 1;
                this.cboBoxSelectYear.SelectedIndexChanged += new System.EventHandler(this.cboBoxSelectYear_SelectedIndexChanged);
                this.cboBoxSelectMonth.SelectedIndexChanged += new System.EventHandler(this.cboBoxSelectMonth_SelectedIndexChanged);
            }

            Application.DoEvents();
		}

		private void lblDayDoubleClick(object sender, System.EventArgs e)
		{
			this.btnSelect_Click(null, null);
		}

		private void FmDate_Load(object sender, System.EventArgs e)
		{
            DateTime tmpDT;
            try
            {
                tmpDT = DateTime.Parse(this.m_strDateTimeSelected);
            }
            catch
            {
                tmpDT = DateTime.Now;
            }

			this.m_nSelectedYear	= tmpDT.Year;
			this.m_nSelectedMonth	= tmpDT.Month;
			this.m_nSelectedDay		= tmpDT.Day;
			this.cboBoxSelectYear.SelectedIndex		= this.cboBoxSelectYear.FindString(this.m_nSelectedYear.ToString());
			this.cboBoxSelectMonth.SelectedIndex	= this.m_nSelectedMonth - 1;
			ShowDateOfYearMonth(this.m_nSelectedYear, this.m_nSelectedMonth);
		}

		private void cboBoxSelectYear_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.cboBoxSelectYear.Text != "" && this.cboBoxSelectMonth.Text != "")
				ShowDateOfYearMonth(int.Parse(this.cboBoxSelectYear.Text), this.cboBoxSelectMonth.SelectedIndex + 1);
		}

		private void cboBoxSelectMonth_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.cboBoxSelectYear.Text != "" && this.cboBoxSelectMonth.Text != "")
				ShowDateOfYearMonth(int.Parse(this.cboBoxSelectYear.Text), this.cboBoxSelectMonth.SelectedIndex + 1);
		}

		private void btnPreYear_Click(object sender, System.EventArgs e)
		{
			if (this.cboBoxSelectYear.SelectedIndex > 0)
				this.cboBoxSelectYear.SelectedIndex = this.cboBoxSelectYear.SelectedIndex - 1;
		}

		private void btnNextYear_Click(object sender, System.EventArgs e)
		{
			if (this.cboBoxSelectYear.SelectedIndex < this.cboBoxSelectYear.Items.Count - 1)
				this.cboBoxSelectYear.SelectedIndex = this.cboBoxSelectYear.SelectedIndex + 1;
		}

		private void btnToday_Click(object sender, System.EventArgs e)
		{
			this.m_nSelectedYear	= DateTime.Now.Date.Year;
			this.m_nSelectedMonth	= DateTime.Now.Date.Month;
			this.m_nSelectedDay		= DateTime.Now.Date.Day;

			ShowDateOfYearMonth(this.m_nSelectedYear, this.m_nSelectedMonth);

			this.cboBoxSelectYear.SelectedIndexChanged	-= new System.EventHandler(this.cboBoxSelectYear_SelectedIndexChanged);
			this.cboBoxSelectMonth.SelectedIndexChanged -= new System.EventHandler(this.cboBoxSelectMonth_SelectedIndexChanged);
			this.cboBoxSelectYear.SelectedIndex		= this.cboBoxSelectYear.FindString(this.m_nSelectedYear.ToString());
			this.cboBoxSelectMonth.SelectedIndex	= this.m_nSelectedMonth - 1;
			this.cboBoxSelectYear.SelectedIndexChanged	+= new System.EventHandler(this.cboBoxSelectYear_SelectedIndexChanged);
			this.cboBoxSelectMonth.SelectedIndexChanged += new System.EventHandler(this.cboBoxSelectMonth_SelectedIndexChanged);

			this.btnSelect_Click(null, null);
		}

		private void btnSelect_Click(object sender, System.EventArgs e)
		{
            foreach (Control c in this.pnl02.Controls)
            {
                if (c.Name.Length >= 6 && c.Name.Substring(0, 6).ToUpper() == "LBLDAY")
                {
                    if (c.BackColor == Color.Green)
                    {
                        this.m_strDateTimeSelected = c.Tag.ToString();
                        break;
                    }
                }
            }
            Application.DoEvents();

			this.DialogResult = DialogResult.OK;

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            Close();
        }
	}
}