using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Services.SvrModels
{

    public class SvrRoleGroupInfo
    {
        /// <summary>
        /// 分组ID
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// 组名
        /// </summary>
        [Required(ErrorMessage ="角色组名称不能为空")]
        [StringLength(50,ErrorMessage ="角色组长度不能过50个字符")]
        public string GroupName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(500, ErrorMessage = "角色组备注不能过200个字符")]
        public string GroupRemarks { get; set; }


    }
}
