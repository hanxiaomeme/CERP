using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace LanyunMES.Entity
{
    public class UserToKen
    {


        /// <summary>
        /// 当前系统登录用户信息
        /// </summary>
        public static UserToKen CurrentUserToKen { get; set; }


		/// <summary>
		/// 用户登录ID
		/// </summary>
        public int UserId { get; set; }

		/// <summary>
		/// 用户登录名称
		/// </summary>
        public string UserName { get; set; }

		/// <summary>
		/// 登录用户的的密码
		/// </summary>
        public string UserPwd { get; set; }

        //User是否管理员
        public bool isAdmin { get; set; }


        /// <summary>
        /// 登录用户的人员ID
        /// </summary>
        public int PsnId { get; set; }

        /// <summary>
        /// 登入用户的人员代码
        /// </summary>
        public string PsnCode { get; set; }

        /// <summary>
        /// 登录用户的人员名字
        /// </summary>
        public string PsnName { get; set; }

		/// <summary>
		/// 登录用户人员所属的部门ID
		/// </summary>
        public int DepId { get; set; }

		/// <summary>
		/// 登录用户人员所属部门编码
		/// </summary>
        public string DepCode { get; set; }

		/// <summary>
		/// 登录用户人员所属部门名称
		/// </summary>
        public string DepName { get; set; }

        /// <summary>
        /// 业务日期
        /// </summary>
        public DateTime BusiDate
        {
            get { return this.m_dtBusiDate; }
            set { m_dtBusiDate = value; }
        }
        private DateTime m_dtBusiDate = DateTime.Now.Date;

		/// <summary>
		/// 登录用户使用的机器名称
		/// </summary>
		public string HostName
		{
            get { return _HostName; }
            set { _HostName = value; }
		}
		private string _HostName = "localhost";

		/// <summary>
		/// 登录用户使用的机器的IP地址
		/// </summary>
		public string IPAddr
		{
            get { return _IPAddr; }
            set { _IPAddr = value; }
		}
		private string _IPAddr = "127.0.0.1";

		/// <summary>
		/// 登录用户的功能菜单
		/// </summary>
        public DataTable UserFuncModule { get; set; }

		/// <summary>
		/// 登录用户的调整权限
		/// </summary>
		public DataTable UserAuth
		{
            get { return _UserAuth; }
		}
		private DataTable _UserAuth = null;


		/// <summary>
		/// 用户类型
		/// </summary>
		public int UserType
		{
			get { return this.m_nUserType; }
			set { this.m_nUserType = value; }
		}
		private int m_nUserType = 0;

		/// <summary>
		/// 用户登入登出日志号
		/// </summary>
        public int IOLogRegId { get; set; }
        
    }


}