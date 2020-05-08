using QWF.Framework.GlobalException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Services.BLL
{
    internal class RoleHelper
    {
        public DbAccess.DbFrameworkContext DbContext { get; private set; }
        public SvrModels.SvrUserIdentifier SvrUser { get; set; }

        public RoleHelper(DbAccess.DbFrameworkContext db, SvrModels.SvrUserIdentifier svrUser)
        {
            this.DbContext = db;
            this.SvrUser = svrUser;
        }

        #region 角色组
        public RoleGroup GetRoleGroupById(int groupId)
        {
            var dbModel = DbContext.T_QWF_RoleGroup.Where(w => w.GroupId == groupId && w.IsDelete == 0).FirstOrDefault();
            return dbModel == null ? null : new RoleGroup(dbModel, this);
        }

        public RoleGroup CreateRoleGroup(SvrModels.SvrRoleGroupInfo svrModel)
        {
            //验证模型
            var checkModel = QWF.Framework.Validation.ValidationHelper.Validate(svrModel);

            if (!checkModel.IsValid)
                throw new UIValidateException("数据验证失败！" + checkModel.ToString());

            if (DbContext.T_QWF_RoleGroup.Where(w => w.GroupName == svrModel.GroupName && w.IsDelete == 0).Count() > 0)
                throw new UIValidateException(string.Format("已经存在角色组【{0}】,请换一个名称.", svrModel.GroupName));
            //设置
            var dbModel = new DbAccess.T_QWF_RoleGroup();

            dbModel.GroupName = svrModel.GroupName;
            dbModel.GroupRemarks = svrModel.GroupRemarks;
            dbModel.IsDelete = 1;
            dbModel.CreateTime = SvrUser.CurrentTime;

            DbContext.T_QWF_RoleGroup.Add(dbModel);

            return new RoleGroup(dbModel, this);

        }

        #endregion

        #region 角色

        public Role GetRoleById(int roleId)
        {
            var role = this.DbContext.T_QWF_Role.Where(w => w.RoleId == roleId && w.IsDelete == 0).FirstOrDefault();
            return role == null ? null : new Role(role, this);
        }

        public Role GetRoleByCode(string roleCode)
        {
            var role = this.DbContext.T_QWF_Role.Where(w => w.RoleCode == roleCode && w.IsDelete == 0).FirstOrDefault();
            return role == null ? null : new Role(role, this);
        }
        public Role CreateRole(SvrModels.SvrRoleInfo svrModel)
        {

            //数据验证
            var checkModel = QWF.Framework.Validation.ValidationHelper.Validate(svrModel);
            if (!checkModel.IsValid)
                throw new UIValidateException("数据验证失败！" + checkModel.ToString());

            //逻辑验证
            if (GetRoleGroupById(svrModel.RoleGroupId) == null)
                throw new UIValidateException(string.Format("角色组不存在或已删除！角色组ID={0}", svrModel.RoleGroupId));


            //设置数据
            var dbModel = new DbAccess.T_QWF_Role();

            dbModel.RoleCode = svrModel.RoleCode;
            dbModel.RoleGroupId = svrModel.RoleGroupId;
            dbModel.RoleName = svrModel.RoleName;
            dbModel.Remarks = svrModel.Remarks;
            dbModel.IsDelete = 0;
            dbModel.CreateUserId = SvrUser.UserId;
            dbModel.CreateTime = SvrUser.CurrentTime;

            //保存数据
            DbContext.T_QWF_Role.Add(dbModel);

            return new Role(dbModel, this);

        }

        #endregion

        #region 用户对应的角色
       
        public UserInRole GetUserInRole(int roleId, int userId)
        {
            var dbModel = this.DbContext.T_QWF_UserInRole.Where(w => w.RoleId == roleId && w.UserId == userId).FirstOrDefault();
            return dbModel == null ? null : new UserInRole(dbModel, this);
        }

        public void AddUserInRoles(int roleId, int userId)
        {
         

            if(GetUserInRole(roleId,userId) == null)
            {
                var dbModel = new DbAccess.T_QWF_UserInRole();

                dbModel.RoleId = roleId;
                dbModel.UserId = userId;
                dbModel.CreateTime = SvrUser.CurrentTime;
                dbModel.CreateUserId = SvrUser.UserId;

                this.DbContext.T_QWF_UserInRole.Add(dbModel);
            }
        }

        public void DeleteUserInRoleId(int id)
        {
            var dbModel = this.DbContext.T_QWF_UserInRole.Where(w => w.Id == id).FirstOrDefault();
            if( dbModel != null)
            {
                this.DbContext.T_QWF_UserInRole.Remove(dbModel);
            }
        }

        #endregion
    }
}
