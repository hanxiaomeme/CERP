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
    public class SvrConfigInfo
    {
        [DataMember]
        [Range(1, Int32.MaxValue, ErrorMessage = "ID为0")]
        public int ConfigId { get; set; }

        public string ConfigResourceCode { get; set; }

        [Required(ErrorMessage = "配置节点名称不能为NULL")]
        public string ConfigName { get; set; }

        public string ConfigValueType { get; set; }
        public string ConfigValue { get; set; }
        public int ParentId { get; set; }
        public string ConfigRemarks { get; set; }

    }
}
