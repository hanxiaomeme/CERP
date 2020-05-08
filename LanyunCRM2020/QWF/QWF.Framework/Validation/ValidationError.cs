using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Validation
{
    /// <summary>
    /// 校验错误
    /// </summary>
    public class ValidationError
    {
        public string FieldName { get; set; }
        public string Message { get; set; }
    }
}
