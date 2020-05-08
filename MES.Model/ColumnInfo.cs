
using System;

namespace LanyunMES.Entity
{
	/// <summary>
	/// ColumnInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ColumnInfo
	{
		#region Model
		private string _tablename;
		private string _columnname;
		private string _headtext;
		private int? _position;
		private string _columntype;
		private bool _visable= true;
		/// <summary>
		/// 
		/// </summary>
		public string TableName
		{
			set{ _tablename=value;}
			get{return _tablename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ColumnName
		{
			set{ _columnname=value;}
			get{return _columnname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HeadText
		{
			set{ _headtext=value;}
			get{return _headtext;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Position
		{
			set{ _position=value;}
			get{return _position;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ColumnType
		{
			set{ _columntype=value;}
			get{return _columntype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool visable
		{
			set{ _visable=value;}
			get{return _visable;}
		}
		#endregion Model

	}
}

