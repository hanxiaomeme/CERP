using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QWF.Framework.Services;
using QWF.Framework.ExtendUtils;
using QWF.Framework.Services.SvrModels;
using System.Web;

namespace QWF.Framework.Services
{
    public class UsersServices
    {
        /// <summary>
        /// 调用接口服务者的标识
        /// </summary>
        private SvrUserIdentifier svrUser;

        /// <summary>
        /// 用户接口
        /// </summary>
        /// <param name="svrUser">调用接口服务者的标识</param>
        public UsersServices(SvrUserIdentifier svrUser)
        {
            this.svrUser = svrUser;
        }
        /// <summary>
        /// 创建用户接口
        /// </summary>
        /// <param name="svrUserInfo"></param>
        /// <returns></returns>
        public int CreateUser(SvrUserInfo svrUserInfo)
        {

            //开始
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var userHelper = new BLL.UserHelper(db, this.svrUser);
                BLL.User user = userHelper.CreateUserInfo(svrUserInfo);
                //保存修改
                db.SaveChanges();

                return user.GetNewUserId();
            }
        }

        /// <summary>
        /// 更新用户数据
        /// </summary>
        /// <param name="svrUserInfo"></param>
        /// <returns></returns>
        public int UpdateUser(SvrUserInfo svrUserInfo)
        {
            if (svrUserInfo.OrgId == 0)
                throw new QWF.Framework.GlobalException.UIValidateException("机构ID为NULL");

            //开始
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var userHelper = new BLL.UserHelper(db, this.svrUser);

                BLL.User user = userHelper.GetUserInfoById(svrUserInfo.UserId);
                if (user == null)
                    throw new QWF.Framework.GlobalException.UIValidateException(string.Format("用户ID=【{0}】不存在！", svrUserInfo.UserId));


                //密码不为空则修改密码
                if (!svrUserInfo.PassWord.StrValidatorHelper().StrIsNullOrEmpty())
                    user.DbModel.PassWord = svrUserInfo.PassWord;

                if (!svrUserInfo.UserCode.StrValidatorHelper().StrIsNullOrEmpty())
                    user.DbModel.UserCode = svrUserInfo.UserCode;

                //必要字段

                user.DbModel.OrgId = svrUserInfo.OrgId;
                user.DbModel.Leader = svrUserInfo.Leader ? 1 : 0;
                user.DbModel.QQ = svrUserInfo.Realname;
                user.DbModel.Realname = svrUserInfo.Realname;
                user.DbModel.Tel = svrUserInfo.Tel;
                user.DbModel.Phone = svrUserInfo.Phone;
                user.DbModel.Email = svrUserInfo.Email;
                user.DbModel.Position = svrUserInfo.Position;
                user.DbModel.Weixin = svrUserInfo.Weixin;
                user.DbModel.Fax = svrUserInfo.Fax;
                user.DbModel.UserRemarks = svrUserInfo.UserRemarks;

                if(svrUserInfo.UserStatus == SvrUserInfo.UserStatusEnum.正常 || svrUserInfo.UserStatus == SvrUserInfo.UserStatusEnum.禁用 )
                    user.DbModel.UserStatus =(int) svrUserInfo.UserStatus;

                //修改者
                user.DbModel.UpdateUserId = this.svrUser.UserId;
                user.DbModel.UpdateTime = DateTime.Now;
                //保存修改
                db.SaveChanges();

                return user.GetNewUserId();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">DelUser,StopUser,StartUser</param>
        /// <param name="userIds"></param>
        /// <returns></returns>
        public bool OrderUser(string type, List<string> userIds)
        {
            if (userIds.Count == 0)
                return true;

            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                foreach (var userid in userIds)
                {
                    var userHelper = new BLL.UserHelper(db, this.svrUser);
                    //获取用户对象
                    var user = userHelper.GetUserInfoById(userid.SafeConvert().ToInt32(0));

                    if (user != null)
                    {
                        switch (type)
                        {
                            case "DelUser":
                                user.DelUser();
                                break;
                            case "StopUser":
                                user.StopUser();
                                break;
                            case "StartUser":
                                user.StartUser();
                                break;
                        }
                    }
                }
                //一次提交
                db.SaveChanges();

            }

            return true;
        }

        public bool ResetPassword(int userId,string oldPassword, string newPassword)
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var helper = new BLL.UserHelper(db, svrUser);
                var user = helper.GetUserInfoById(userId);
                if(user!=null)
                {
                    if (user.GetPassword() != oldPassword.StringHelper().EncodeMD5())
                        throw new QWF.Framework.GlobalException.UIValidateException("旧密码不正确");

                    user.ResetPassword(newPassword.StringHelper().EncodeMD5());

                    
                }
                db.SaveChanges();
            }

            return true;
        }


    }
}
