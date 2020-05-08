using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Web
{
    /// <summary>
    /// 
    /// </summary>
    public class ResultWebData
    {
        private string message = "success";
        private string returnUrl = string.Empty;

        /// <summary>
        /// 返回消息
        /// </summary>
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }
        /// <summary>
        /// 接口状态 
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 返回的URL
        /// </summary>
        public string ReturnUrl
        {
            get
            {
                return returnUrl;
            }
            set
            {
                returnUrl = value;
            }
        }

        public object Data { get; set; }

        public static ResultWebData Default()
        {
            return new ResultWebData { Success = true, Message = "success", ReturnUrl = string.Empty };
        }
    }
}
