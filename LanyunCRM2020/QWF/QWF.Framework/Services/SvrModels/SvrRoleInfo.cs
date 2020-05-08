using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Services.SvrModels
{
   [DataContract]
   public class SvrRoleInfo
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        [DataMember]
        public int RoleId { get; set; }
        /// <summary>
        /// 角色CODE RO-yyyy-MMdd-00000
        /// </summary>
        [Required(ErrorMessage ="角色Code为空")]
        public string RoleCode { get; set; }
        [DataMember]
        [Required(ErrorMessage = "角色名称为空")]
        public string RoleName { get; set; }

        [DataMember]
        [Range(1,Int32.MaxValue,ErrorMessage = "所属角色组ID为0或所属角色组不存在")]
        public int RoleGroupId { get; set; }

        [DataMember]
        public string Remarks { get; set; }

    }
}
