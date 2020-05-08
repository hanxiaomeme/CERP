using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Services.SvrModels
{
    /// <summary>
    /// 服务调用者的用户标识
    /// </summary>
    public class SvrUserIdentifier
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserCode { get; set; }
        public DateTime CurrentTime { get; set; }
    }
}
