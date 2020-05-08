using System;

namespace LanyunMES.Entity
{
	public class ModuleItem
	{

		/// <summary>
		/// 模块编码用于分级别（三位一级例：001，001001，001001001）
		/// </summary>
        public string ModuleCode { get; set; }

		/// <summary>
		/// 模块名称（例：人员信息）
		/// </summary>
        public string ModuleName { get; set; }

		/// <summary>
		/// 文件名称（不带后缀名）
		/// </summary>
        public string FileName { get; set; }

		/// <summary>
		/// 文件类型（dll, exe)
		/// </summary>
		public string FileType
		{
			get { return this.m_strFileType; }
			set { this.m_strFileType = value; }
		}
		private string m_strFileType = "dll";

		/// <summary>
		/// 构造函数参数集
		/// </summary>
        public string Params { get; set; }

		/// <summary>
		/// 类全称（包括命名空间）
		/// </summary>
        public string ClassFullName { get; set; }
		/// <summary>
		/// 是否末级别
		/// </summary>
		public bool IsEnd
		{
			get { return this.m_bIsEnd; }
			set { this.m_bIsEnd = value; }
		}
		private bool m_bIsEnd = true;

		/// <summary>
		/// 是否使用
		/// </summary>
		public bool IsUse
		{
			get { return this.m_bIsUse; }
			set { this.m_bIsUse = value; }
		}
		private bool m_bIsUse = true;


		/// <summary>
		/// 界面显示方式
		/// </summary>
		public int ShowStyle
		{
			get { return this.m_nShowStyle; }
			set { this.m_nShowStyle = value; }
		}
		private int m_nShowStyle = 0;
	}
}