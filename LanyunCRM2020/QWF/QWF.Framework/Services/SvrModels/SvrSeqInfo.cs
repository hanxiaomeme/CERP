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
    public class SvrSeqInfo
    {

        [Required(ErrorMessage = "编号不能为null")]
        public string Code { get; set; }

        [Required(ErrorMessage = "名称不能为null")]
        public string Name { get; set; }

        [Required(ErrorMessage = "前缀不能为null")]
        public string Prefix { get; set; }

        [Required( ErrorMessage = "日期格式不能为null")]
        public string DateFormart { get; set; }

        [Range(1, Int32.MaxValue, ErrorMessage = "序列长度不能为0")]
        public int SerialLength { get; set; }
    }
}
