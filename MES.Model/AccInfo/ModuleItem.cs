using System;

namespace LanyunMES.Entity
{
	public class ModuleItem
	{

		/// <summary>
		/// ģ��������ڷּ�����λһ������001��001001��001001001��
		/// </summary>
        public string ModuleCode { get; set; }

		/// <summary>
		/// ģ�����ƣ�������Ա��Ϣ��
		/// </summary>
        public string ModuleName { get; set; }

		/// <summary>
		/// �ļ����ƣ�������׺����
		/// </summary>
        public string FileName { get; set; }

		/// <summary>
		/// �ļ����ͣ�dll, exe)
		/// </summary>
		public string FileType
		{
			get { return this.m_strFileType; }
			set { this.m_strFileType = value; }
		}
		private string m_strFileType = "dll";

		/// <summary>
		/// ���캯��������
		/// </summary>
        public string Params { get; set; }

		/// <summary>
		/// ��ȫ�ƣ����������ռ䣩
		/// </summary>
        public string ClassFullName { get; set; }
		/// <summary>
		/// �Ƿ�ĩ����
		/// </summary>
		public bool IsEnd
		{
			get { return this.m_bIsEnd; }
			set { this.m_bIsEnd = value; }
		}
		private bool m_bIsEnd = true;

		/// <summary>
		/// �Ƿ�ʹ��
		/// </summary>
		public bool IsUse
		{
			get { return this.m_bIsUse; }
			set { this.m_bIsUse = value; }
		}
		private bool m_bIsUse = true;


		/// <summary>
		/// ������ʾ��ʽ
		/// </summary>
		public int ShowStyle
		{
			get { return this.m_nShowStyle; }
			set { this.m_nShowStyle = value; }
		}
		private int m_nShowStyle = 0;
	}
}