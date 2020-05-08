using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QWF.Framework.Services;
using QWF.Framework.Services.SvrModels;
using QWF.Framework.ExtendUtils;

namespace QWF.Framework
{
    /// <summary>
    /// 服务入口
    /// </summary>
    public class MainServices
    {
        private SvrUserIdentifier svrUserIdentifier;

        public MainServices(SvrUserIdentifier svrUserIdentifier)
        {
            this.svrUserIdentifier = svrUserIdentifier;
        }
        /// <summary>
        /// WebApp 调用服务入口,前提用户必须验证才都能使用的服务
        /// </summary>
        public static MainServices CreateWebAppServices
        {
            get
            {
                var curUserInfo = Web.UserContext.GetCurrentInfo();

                var svrUserIdentifier = new Services.SvrModels.SvrUserIdentifier();
                svrUserIdentifier.UserId = curUserInfo.CurrentUserId;
                svrUserIdentifier.UserName = curUserInfo.CurrentUserName;
                svrUserIdentifier.UserCode = curUserInfo.CurrentUserCode;
                svrUserIdentifier.CurrentTime = DateTime.Now;


                return new MainServices(svrUserIdentifier);
            }
         
        }

        /// <summary>
        ///  WebApp 调用服务入口,可以不用认证就可以调用的服务
        /// </summary>
        public static GuestServices GuestServices
        {
            get
            {
                var svrUserIdentifier =  new SvrUserIdentifier { UserId = 0, UserName = "GUEST" , CurrentTime = DateTime.Now, UserCode="QWF_USER_GUEST" };
                return new GuestServices(svrUserIdentifier);
            }

        }

        /// <summary>
        /// Windows 程序调用入口,通常是winows后台服务，定义一个固定用户即可
        /// </summary>
        /// <returns></returns>
        public static MainServices CreateWindowsAppServices
        {
            get
            {
                var svrUserIdentifier = new Services.SvrModels.SvrUserIdentifier();

                svrUserIdentifier.UserId = Common.ConfigHelper.GetParameterValue(GlobalConst.APP_Core_ConfigName,  "WindowsAppUserId").SafeConvert().ToInt32();
                svrUserIdentifier.UserName = Common.ConfigHelper.GetParameterValue(GlobalConst.APP_Core_ConfigName, "WindowsAppUserName").SafeConvert().ToStr();
                svrUserIdentifier.UserCode = Common.ConfigHelper.GetParameterValue(GlobalConst.APP_Core_ConfigName, "WindowsAppUserCode").SafeConvert().ToStr();
                svrUserIdentifier.CurrentTime = DateTime.Now;

                return new MainServices(svrUserIdentifier);
            }
         
        
        }


        /// <summary>
        /// 获取用户服务类
        /// </summary>
        public UsersServices GetUserServices()
        {
            return new UsersServices(svrUserIdentifier);
        }
        /// <summary>
        /// 获取机构服务类
        /// </summary>
        /// <returns></returns>
        public OrgServices GetOrgServices()
        {
            return new OrgServices(svrUserIdentifier);
        }

        /// <summary>
        /// 获取角色服务类
        /// </summary>
        /// <returns></returns>
        public RoleServices GetRoleServices()
        {
            return new RoleServices(svrUserIdentifier);
        }

        /// <summary>
        /// 获取菜单服务类
        /// </summary>
        /// <returns></returns>
        public MenuServices GetMenuServices()
        {
            return new MenuServices(svrUserIdentifier);
        }

        /// <summary>
        /// 获取资源代码服务类
        /// </summary>
        /// <returns></returns>
        public ResouceServices GetResouceServices()
        {
            return new ResouceServices(svrUserIdentifier);
        }

        /// <summary>
        /// 获取配置表服务类
        /// </summary>
        /// <returns></returns>
        public ConfigServices GetConfigServices()
        {
            return new ConfigServices(svrUserIdentifier);
        }

        /// <summary>
        /// 获取序列号服务类
        /// </summary>
        /// <returns></returns>
        public SeqServices GetSeqServices()
        {
            return new SeqServices(svrUserIdentifier);
        }

        public UserActionLogServices GetUserActionLogServices()
        {
            return new  UserActionLogServices (svrUserIdentifier);
        }
    }

    public class GuestServices
    {
        SvrUserIdentifier svrUserIdentifier;

        public GuestServices(SvrUserIdentifier svrUserIdentifier)
        {
            this.svrUserIdentifier = svrUserIdentifier;
        }
        /// <summary>
        /// 登陆验证的服务调用者可以为GUEST
        /// </summary>
        /// <returns></returns>
        public UserLoginServices GetUserLoginServices()
        {
            return new UserLoginServices(svrUserIdentifier);
        }


    }

   

   
}
