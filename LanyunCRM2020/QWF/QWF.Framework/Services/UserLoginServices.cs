using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QWF.Framework.ExtendUtils;
using QWF.Framework.GlobalException;

namespace QWF.Framework.Services
{
    public class UserLoginServices
    {
        private SvrModels.SvrUserIdentifier svrUserIdentifier;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="svrUserIdentifier">这里应该是一个GUESTd 的标示</param>
        public UserLoginServices(SvrModels.SvrUserIdentifier svrUserIdentifier)
        {
            this.svrUserIdentifier = svrUserIdentifier;
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="userName"></param>
        /// <param name="passWord">由客户端决定加密的方式</param>
        /// <returns></returns>
        public bool CheckUserLogin(string appId, string userName, string passWord)
        {
            if (userName.StrValidatorHelper().StrIsNullOrEmpty())
                throw new Framework.GlobalException.UIValidateException("用户名不能为空");
            if (passWord.StrValidatorHelper().StrIsNullOrEmpty())
                throw new Framework.GlobalException.UIValidateException("密码不能为空");

            using (var qwfContext = DbAccess.DbFrameworkContext.Create())
            {
                var ip = QWF.Framework.Web.QWFRequest.GetIP();
                BLL.UserHelper users = new BLL.UserHelper(qwfContext, svrUserIdentifier);
                BLL.UserLoginHelper loginHelper = new BLL.UserLoginHelper(qwfContext, svrUserIdentifier);

                var log = new SvrModels.SvrLoginLog();
                log.AppId = appId;
                log.Ip = ip;
                log.UserName = userName;
                try
                {
                  
                    BLL.User user = users.GetUserInfo(userName);

                    if (user.GetPassword() != passWord)
                    {
                        log.Remarks = userName + "的密码错误!";
                        throw new UserValidateException(log.Remarks);
                    }

                    user.UpdateLoginLog(ip);
                    user.SetUserTokenCookie(appId);

                    //保存所有修改
                    log.LoginStatus = SvrModels.SvrLoginLoginStauts.Success;
                    loginHelper.Add(log);

                    qwfContext.SaveChanges();
                }
                catch(UserValidateException uex)
                {
                    //写入登录日志
                    log.LoginStatus = SvrModels.SvrLoginLoginStauts.Error;
                    log.Remarks = uex.Message;

                    loginHelper.Add(log);
                    qwfContext.SaveChanges();

                    throw uex;
                }
                return true;
            }

        }


    }
}
