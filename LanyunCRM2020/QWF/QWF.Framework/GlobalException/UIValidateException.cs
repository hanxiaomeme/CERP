using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.GlobalException
{
    /// <summary>
    /// 
    /// </summary>
    public class UIValidateException : System.Exception
    {
        private string returnUrl = string.Empty;

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

        public UIValidateException(string message,params object[] args)
            : base(string.Format(message,args))
        {

        }

        public UIValidateException(string message)
    : base(message)
        {

        }

        //public UIValidateException(string message,string returnUrl)
        //    : base(message)
        //{

        //}
    }
}
