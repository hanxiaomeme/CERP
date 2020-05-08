using QWF.Framework.Services.SvrModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QWF.Framework.IOC
{
    public abstract class IUserIoc
    {
        #region 创建用户信息
        /// <summary>
        /// 创建开始
        /// </summary>
        /// <param name="svrUser">传入的参数</param>
        /// <returns></returns>
        public virtual SvrUserInfo CreateBegin(SvrUserInfo svrUser) { return svrUser; }
        /// <summary>
        /// 创建用户成功
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public virtual bool CreateSuccess(int userId) { return true; }
        /// <summary>
        /// 创建用户失败
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public virtual bool CreateFail(SvrUserInfo svrUser, Exception e) { return true; }
        #endregion

        #region 修改用户信息
        /// <summary>
        /// 编辑用户开始
        /// </summary>
        /// <param name="svrUser">传入的参数</param>
        /// <returns></returns>
        public virtual SvrUserInfo UpdateBegin(SvrUserInfo svrUser) { return svrUser; }
        /// <summary>
        /// 编辑用户成功
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public virtual bool UpdateSuccess(int userId) { return true; }
        /// <summary>
        /// 编辑用户失败
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public virtual bool UpdateFail(SvrUserInfo svrUser, Exception e) { return true; }

        #endregion

        #region  删除，启动，停止
        /// <summary>
        /// 开始
        /// </summary>
        /// <param name="type">DelUser,StopUser,StartUser</param>
        /// <param name="userIds"></param>
        /// <returns></returns>
        public virtual bool OrderUserBegin(string type, List<string> userIds)
        {
            return true;
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="type">DelUser,StopUser,StartUser</param>
        /// <param name="userIds"></param>
        /// <returns></returns>
        public virtual bool OrderUserSuccess(string type, List<string> userIds)
        {
            return true;
        }
        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="type">DelUser,StopUser,StartUser</param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public virtual bool OrderUserFail(string type, List<string> userId)
        {
            return true;
        }
        #endregion


    }
}
