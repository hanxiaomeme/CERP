using QWF.Framework.ExtendUtils;
using QWF.Framework.GlobalException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Services
{
    /// <summary>
    /// 角色相关服务
    /// </summary>
    public class RoleServices
    {
        private SvrModels.SvrUserIdentifier svrUser;
        public RoleServices(SvrModels.SvrUserIdentifier svrUser)
        {
            this.svrUser = svrUser;
        }

        #region 角色组
        public int CreateRoleGroup(SvrModels.SvrRoleGroupInfo svrModel)
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var helper = new BLL.RoleHelper(db, this.svrUser);
                var role = helper.CreateRoleGroup(svrModel);

                db.SaveChanges();
                return role.GetGroupId();
            }
        }

        public bool UpdateRoleGroup(SvrModels.SvrRoleGroupInfo svrModel)
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var helper = new BLL.RoleHelper(db, this.svrUser);
                var role = helper.GetRoleGroupById(svrModel.GroupId);
                if (role == null)
                    throw new QWF.Framework.GlobalException.UIValidateException(string.Format("角色组不存在GroupId={0}", svrModel.GroupId));

                role.UpdateRoleGroup(svrModel);

                db.SaveChanges();
                return true;
            }
        }

        public bool DeleteRoleGroup(int groupId)
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var helper = new BLL.RoleHelper(db, this.svrUser);
                var role = helper.GetRoleGroupById(groupId);
                if (role == null)
                    throw new QWF.Framework.GlobalException.UIValidateException(string.Format("角色组不存在或已删除，GroupId={0}", groupId));

                role.Deleted();

                db.SaveChanges();
                return true;
            }
        }

        public bool RoleGroupSort(Dictionary<int, int> dic)
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                foreach (var d in dic)
                {
                    var dbModel = db.T_QWF_RoleGroup.Where(w => w.GroupId == d.Key && w.IsDelete == 0).FirstOrDefault();
                    if (dbModel != null)
                        dbModel.SortId = d.Value;
                }
                db.SaveChanges();
            }
            return true;
        }
        #endregion

        #region 角色
        public int CreateRole(SvrModels.SvrRoleInfo svrModel)
        {
            //生产角色编号
            if (svrModel.RoleCode.StrValidatorHelper().StrIsNullOrEmpty())
            {
                var common = new SeqServices(this.svrUser);
                svrModel.RoleCode = common.CreateNewSeqNo("system.rolecode");
            }

            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var helper = new BLL.RoleHelper(db, this.svrUser);

                var role = helper.CreateRole(svrModel);

                db.SaveChanges();
                return role.GetRoleId();
            }
        }

        public bool UpdateRole(SvrModels.SvrRoleInfo svrModel)
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var helper = new BLL.RoleHelper(db, this.svrUser);
                var roleGropup = helper.GetRoleGroupById(svrModel.RoleGroupId);
                if (roleGropup == null)
                    throw new UIValidateException(string.Format("角色组不存在或已删除，GroupId={0}", svrModel.RoleGroupId));

                var role = helper.GetRoleById(svrModel.RoleId);
                if (role == null)
                    throw new UIValidateException(string.Format("角色不存在或删除，RoleId={0}", svrModel.RoleId));

                role.UpdateRole(svrModel);

                db.SaveChanges();
                return true;
            }
        }

        public bool DeleteRole(int roleId)
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var helper = new BLL.RoleHelper(db, this.svrUser);
                var role = helper.GetRoleById(roleId);
                if (role == null)
                    throw new UIValidateException(string.Format("角色不存或已删除,RoleId={0}", roleId));

                role.Deleted();

                db.SaveChanges();
                return true;
            }
        }
        #endregion

        #region 角色对应用户

        public List<string> GetUserInRoleCode(int userId)
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var result = (from a in db.T_QWF_UserInRole
                              join b in db.T_QWF_Role on a.RoleId equals b.RoleId
                              where a.UserId == userId && b.IsDelete == 0
                              select b.RoleCode
                              ).ToList();

                return result;
            }
        }

       /// <summary>
       /// 保存用户角色 幂等操作
       /// </summary>
       /// <param name="roleCodes">角色代码</param>
       /// <param name="userId"></param>
        public void SaveUserInRoleByCodes(string[] roleCodes, int userId)
        {
            if (userId == 0 || userId == 0)
                throw new UIValidateException("用户ID 和角色Code不能为0");

            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                //转化为ROLEID
                var roleIds = db.T_QWF_Role.Where(w => roleCodes.Contains(w.RoleCode) && w.IsDelete == 0).Select(s=>s.RoleId).ToList();
                //删除不存在的角色
                db.T_QWF_UserInRole.Where(w => !roleIds.Contains(w.RoleId) && w.UserId == userId).ToList().ForEach(item =>
                {
                    db.T_QWF_UserInRole.Remove(item);
                });
              
                //逐个添加
                foreach(var roleId in roleIds)
                {
                    var roleHelper = new BLL.RoleHelper(db, this.svrUser);
                    roleHelper.AddUserInRoles(roleId, userId);
                }

                db.SaveChanges();
            }
        }
        /// <summary>
        /// 新增用户角色
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <param name="userId"></param>
        public void AddUserInRoleById(int roleId, int userId)
        {
            if (userId == 0 || roleId == 0)
                throw new UIValidateException("用户ID 和角色ID不能为0");

            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var roleHelper = new BLL.RoleHelper(db, this.svrUser);

                var role = roleHelper.GetRoleById(roleId);
                if (role == null)
                    throw new UIValidateException(string.Format("角色不存在或删除，ID={0}", roleId));

                roleHelper.AddUserInRoles(role.GetRoleId(), userId);

                db.SaveChanges();
            }
        }

        public void AddUserInRole(int roleId, string[] userIds)
        {
            if (roleId == 0)
                throw new UIValidateException("角色ID=0");

            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var roleHelper = new BLL.RoleHelper(db, this.svrUser);

                var role = roleHelper.GetRoleById(roleId);
                if (role == null)
                    throw new UIValidateException(string.Format("角色不存在或删除，ID={0}", roleId));

                foreach (string userId in userIds)
                {
                    roleHelper.AddUserInRoles(role.GetRoleId(), userId.SafeConvert().ToInt32(0));
                }

                db.SaveChanges();
            }
        }

        public bool DeleteUserInRoles(string[] ids)
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var helper = new BLL.RoleHelper(db, this.svrUser);
                foreach (string id in ids)
                {
                    helper.DeleteUserInRoleId(id.SafeConvert().ToInt32());
                }

                db.SaveChanges();
                return true;
            }
        }
        #endregion

        #region 角色对应菜单

        public bool AddRoleInMenu(int roleId, string[] menuIds)
        {
            if (roleId == 0)
                throw new UIValidateException("角色ID=0");

            using (var db = DbAccess.DbFrameworkContext.Create())
            {   //清除ROLEID
                db.T_QWF_RoleInMenu.Where(w => w.RoleId == roleId).ToList().ForEach(item =>
                 {

                     db.T_QWF_RoleInMenu.Remove(item);
                 });

                //写入新的菜单ID
                foreach (var menuId in menuIds)
                {
                    var MenuId = menuId.SafeConvert().ToInt32();
                    if (MenuId > 0)
                    {
                        db.T_QWF_RoleInMenu.Add(new DbAccess.T_QWF_RoleInMenu
                        {
                            RoleId = roleId,
                            MenuId = MenuId,
                            CreateTime = svrUser.CurrentTime,
                            CreateUserId = svrUser.UserId
                        });

                    }

                }

                db.SaveChanges();

                return true;
            }
        }
        #endregion

        #region 角色对应资源代码
        public bool AddRoleInResource(int roleId, string[] ruleIds)
        {
            if (roleId == 0)
                throw new UIValidateException("角色ID=0");

            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                //写入新的菜单ID
                foreach (var ruleId in ruleIds)
                {
                    var iRuleId = ruleId.SafeConvert().ToInt32();
                    if (iRuleId > 0)
                    {
                      
                        if (db.T_QWF_RoleInResource.Where(w=>w.RoleId == roleId && w.RuleId == iRuleId).Count()==0)
                        {
                            db.T_QWF_RoleInResource.Add(new DbAccess.T_QWF_RoleInResource
                            {
                                RoleId = roleId,
                                RuleId = iRuleId,
                                CreateTime = svrUser.CurrentTime,
                                CreateUserId = svrUser.UserId
                            });
                        }

                         

                    }

                }
                db.SaveChanges();

                return true;
            }
        }

        /// <summary>
        /// 删除角色对应的资源代码
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="ruleIds"></param>
        /// <returns></returns>
        public bool DeleteRoleInResource(int roleId, string[] ruleIds)
        {
            if (roleId == 0)
                throw new UIValidateException("角色ID=0");

            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                db.T_QWF_RoleInResource.Where(w => w.RoleId == roleId).ToList().ForEach(item =>
                {
                    if (ruleIds.Contains(item.RuleId.ToString()))
                    {
                        db.T_QWF_RoleInResource.Remove(item);
                    }

                });

                db.SaveChanges();

                return true;
            }
        }
        #endregion
    }
}
