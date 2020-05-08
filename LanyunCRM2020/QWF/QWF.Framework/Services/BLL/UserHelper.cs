using QWF.Framework.Services.BLL.Models;
using QWF.Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QWF.Framework.ExtendUtils;
using QWF.Framework.GlobalException;

namespace QWF.Framework.Services.BLL
{
    internal class UserHelper
    {
        /// <summary>
        /// 框架DB的上下文
        /// </summary>
        public DbAccess.DbFrameworkContext DbContext { get; private set; }
        /// <summary>
        /// 服务调用者标识
        /// </summary>
        public Services.SvrModels.SvrUserIdentifier SvrUser;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="qwfContext">框架DB的上下文</param>
        /// <param name="svrUser">服务调用者标识</param>
        public UserHelper(DbAccess.DbFrameworkContext qwfContext, Services.SvrModels.SvrUserIdentifier svrUser)
        {
            this.DbContext = qwfContext;
            this.SvrUser = svrUser;
        }
        /// <summary>
        /// 获取用户基本信息
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="isChecked">是否判断用户状态如：用户不存在，如果不判断可能为返回为NULL</param>
        /// <returns>返回用户信息</returns>
        public User GetUserInfo(string userName, bool isChecked = true)
        {
            var dbUser = DbContext.T_QWF_User.Where(w => w.UserName == userName).FirstOrDefault();

            if (isChecked)
            {
                if (dbUser == null)
                    throw new UserValidateException(userName + "用户不存在!");

                if (dbUser.IsDelete == 1)
                    throw new UserValidateException(userName + "用户已经删除!");

                if (dbUser.UserStatus == (int)SvrModels.SvrUserInfo.UserStatusEnum.禁用)
                    throw new UserValidateException(userName + "用户已禁用!");
            }

            return new User(dbUser, DbContext, this);
        }

        public User GetUserInfoById(int userId)
        {
            var dbUser = DbContext.T_QWF_User.Where(w => w.UserId == userId && w.IsDelete == 0).FirstOrDefault();
            return dbUser == null ? null : new User(dbUser, DbContext, this);
        }

        /// <summary>
        /// 创建用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User CreateUserInfo(SvrModels.SvrUserInfo user)
        {

            var checkModel = QWF.Framework.Validation.ValidationHelper.Validate(user);
            if (!checkModel.IsValid)
                throw new UIValidateException("数据验证失败！" + checkModel.ToString());

            if(user.UserName.Length <3 )
                throw new UIValidateException("账号长度至少3位");

            if (user.PassWord.StrValidatorHelper().StrIsNullOrEmpty())
                throw new UIValidateException("密码不能空");
            

            //逻辑验证
            var userNameCount = DbContext.T_QWF_User.Where(w => w.UserName == user.UserName && w.IsDelete == 0).Count();
            if (userNameCount > 0)
                throw new GlobalException.UIValidateException(string.Format("用户【{0}】已经存在，不能添加!", user.UserName));

            //用户CODE 规则
            if (user.UserCode.StrValidatorHelper().StrIsNullOrEmpty())
            {
                var common = new SeqServices(this.SvrUser);
                user.UserCode = common.CreateNewSeqNo("system.userCode");
            }
            //验证用户CODE 
            var userCodeCount = DbContext.T_QWF_User.Where(w => w.UserCode == user.UserCode && w.IsDelete == 0).Count();
            if (userCodeCount > 0)
                throw new UIValidateException(string.Format("用户CODE:【{0}】已经存在，不能添加!", user.UserCode));


            var dbUser = new DbAccess.T_QWF_User();

            dbUser.UserCode = user.UserCode;
            dbUser.UserName = user.UserName;
            dbUser.PassWord = user.PassWord;
            dbUser.OrgId = user.OrgId;
            dbUser.Leader = user.Leader?1:0;
            dbUser.UserStatus = (int)SvrModels.SvrUserInfo.UserStatusEnum.正常;
            dbUser.IsDelete = 0;
            dbUser.QQ = user.Realname;
            dbUser.Realname = user.Realname;
            dbUser.Tel = user.Tel;
            dbUser.Phone = user.Phone;
            dbUser.Email = user.Email;
            dbUser.Position = user.Position;
            dbUser.Weixin = user.Weixin;
            dbUser.Fax = user.Fax;
            dbUser.UserRemarks = user.UserRemarks;

            dbUser.CreateUserId = SvrUser.UserId;
            dbUser.CreateTime = SvrUser.CurrentTime;

            this.DbContext.T_QWF_User.Add(dbUser);

            return new User(dbUser, DbContext, this);
        }


        /// <summary>
        /// 验证用户TOKEN
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="token"></param>
        /// <param name="url"></param>
        /// <param name="isCheckedUrl"></param>
        /// <returns></returns>
        public User CheckUserToken(string appId, string token)
        {
            //解密token
            string key = Common.ConfigHelper.GetParameterValue(GlobalConst.APP_Core_ConfigName, "DES3_Key");
            int tokenTimeOut = Common.ConfigHelper.GetParameterValue(GlobalConst.APP_Core_ConfigName, "UserToken_TimeOut").SafeConvert().ToInt32(1);
            string decryptToken = Common.DES3.DES3DecryptECB(token, key);

            //JSON 反序列化成对象
            BLL.Models.UserToken userToken = Newtonsoft.Json.JsonConvert.DeserializeObject<BLL.Models.UserToken>(decryptToken);

            using (var qwfContext = DbAccess.DbFrameworkContext.Create())
            {

                //获取用户信息
                BLL.User user = this.GetUserInfo(userToken.UserName);

                TimeSpan ts = DateTime.Now.Subtract(userToken.Time);

                //验证时间戳
                if (ts.TotalHours > tokenTimeOut)
                    throw new UIValidateException("用户登录超时,请重新登录!", GlobalConst.LoginURL);

                // 验证密码
                if (userToken.CilentPassWord != (userToken.Time + user.GetPassword()).StringHelper().EncodeMD5())
                    throw new UIValidateException("用户验证失败,请重新登录!", GlobalConst.LoginURL);

                //如果发现token的时间过期时间小于1小时，快过期了则更新COOKIE TOKEN
                if ((tokenTimeOut - ts.TotalHours) <= 1)
                {
                    user.SetUserTokenCookie(appId);
                }
                return user;
            }
        }
    }
}
