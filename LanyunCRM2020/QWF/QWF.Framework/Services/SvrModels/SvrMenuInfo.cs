using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Services.SvrModels
{

    public class SvrMenuInfo
    {
       
        [Range(1, Int32.MaxValue, ErrorMessage = "菜单ID为0")]
        public int MenuId { get; set; }

        public int ParentId { get; set; }

       
        [Required(ErrorMessage = "菜单名称不能为NULL")]
        public string MenuName { get; set; }

        public bool IsShow { get; set; }
        public bool IsTarget { get; set; }
        public string IconCls { get; set; }
        public string DefaultUrl { get; set; }
        public List<string> Urls { get; set; }
    }
}
