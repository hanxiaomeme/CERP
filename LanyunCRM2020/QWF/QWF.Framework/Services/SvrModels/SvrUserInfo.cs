using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Services.SvrModels
{
    public class SvrUserInfo
    {
        public int UserId { get; set; }
        /// <summary>
        /// CODE 默认格式：US-yyyy-MMdd-00000
        /// system.usercode
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        [Required(ErrorMessage = "账号不能为空")]
        [StringLength(50, ErrorMessage = "账号长度不能过50个字符")]
        public string UserName { get; set; }
        /// <summary>
        /// 密码，加密方式由调用者实现。
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// 所属机构
        /// </summary>
        [Range(1, Int32.MaxValue, ErrorMessage = "机构ID为0")]
        public int OrgId { get; set; }

        public bool Leader { get; set; }
        public UserStatusEnum UserStatus { get; set; }
        public string QQ { get; set; }

        [Required(ErrorMessage = "姓名不能为空")]
        [StringLength(50, ErrorMessage = "姓名长度不能过50个字符")]
        public string Realname { get; set; }


        public string Tel { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public string Weixin { get; set; }
        public string Fax { get; set; }

        [StringLength(500, ErrorMessage = "账号长度不能过500个字符")]
        public string UserRemarks { get; set; }

        public enum UserStatusEnum
        {
            正常=1,
            禁用=2

        }

    }
}
