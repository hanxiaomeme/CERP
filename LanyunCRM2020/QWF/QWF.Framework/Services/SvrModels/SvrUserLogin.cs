using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Services.SvrModels
{
    public enum SvrLoginLoginStauts
    {
        /// <summary>
        /// 成功
        /// </summary>
        Success = 1,
        /// <summary>
        /// 失败
        /// </summary>
        Error = 2
    }

    public class SvrLoginLog
    {
        public string AppId { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 登录的IP
        /// </summary>
        public string Ip { get; set; }
        /// <summary>
        /// 登录状态 2 失败，1 成功
        /// </summary>
        public SvrLoginLoginStauts LoginStatus { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Remarks { get; set; }
    }
}
