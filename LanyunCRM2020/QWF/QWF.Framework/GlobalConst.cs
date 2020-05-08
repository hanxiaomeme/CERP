using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework
{
    public class GlobalConst
    {
       
        public const string APP_Core_ConfigName = "qwf.core";

        #region COOKIE Key
        
        public const string COOKIE_Key_UserToken = "QWF-User-Token";
        public const string COOKIE_Key_AppId = "QWF-AppId";

        #endregion

        #region Session KEY

        public const string SESSION_Key_UserInfo = "qwf.user";

        #endregion

        #region 缓存KEY
        public const string CacheKey_User_UserName = "qwf.cache.user.username.{0}";
        #endregion

        #region 配置文件

        public static string DES3Key
        {
            get
            {
                return Common.ConfigHelper.GetParameterValue(APP_Core_ConfigName, "DES3_Key");
            }
        }

        public static string LoginURL
        {
            get
            {
               return  Common.ConfigHelper.GetParameterValue(APP_Core_ConfigName, "LoginUrl");
            }

        }

        /// <summary>
        /// 版权
        /// </summary>
        public static string Copyright
        {
            get
            {
                return QWF.Assembly.Common.BEGIN_YEAR + "-" + QWF.Assembly.QWebFramework.ASSEMBLY_YEAR + " " + QWF.Assembly.Common.COMPANY;
            }

        }
        public static string AppName
        {
            get
            {
                //return Common.ConfigHelper.GetParameterValue(APP_Core_ConfigName, "AppName");
                return "浙江蓝云信息科技";
            }

        }
        #endregion
    }
}
