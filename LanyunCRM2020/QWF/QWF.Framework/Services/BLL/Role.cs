using QWF.Framework.GlobalException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Services.BLL
{
    internal class Role
    {
        private DbAccess.T_QWF_Role dbModel;
        private RoleHelper helper;

        public Role(DbAccess.T_QWF_Role dbModel, RoleHelper helper)
        {
            this.dbModel = dbModel;
            this.helper = helper;
        }

        public int GetRoleId()
        {
            return this.dbModel.RoleId;
        }

        public void UpdateRole(SvrModels.SvrRoleInfo svrModel)
        {
            //数据验证
            svrModel.RoleCode = dbModel.RoleCode;

            var checkModel = QWF.Framework.Validation.ValidationHelper.Validate(svrModel);
            if (!checkModel.IsValid)
                throw new UIValidateException("数据验证失败！" + checkModel.ToString());

            //逻辑验证
            if (helper.GetRoleGroupById(svrModel.RoleGroupId) == null)
                throw new UIValidateException(string.Format("角色组不存在或已删除！角色组ID={0}", svrModel.RoleGroupId));

            //设置数据
            dbModel.RoleGroupId = svrModel.RoleGroupId;
            dbModel.RoleName = svrModel.RoleName;
            dbModel.Remarks = svrModel.Remarks;
            dbModel.UpdateUserId = helper.SvrUser.UserId;
            dbModel.UpdateTime = helper.SvrUser.CurrentTime;
        }

        public void Deleted()
        {
            //是否有用户
            if ( helper.DbContext.T_QWF_UserInRole.Where(w=>w.RoleId == dbModel.RoleId).Count() > 0 )
                throw new UIValidateException(string.Format("请先删除角色【{0}】下的用户", dbModel.RoleName));
            
            //是否配置角色控制
            if (helper.DbContext.T_QWF_RoleInResource.Where(w => w.RoleId == dbModel.RoleId).Count() > 0)
                throw new UIValidateException(string.Format("请先删除角色【{0}】下的角色控制权限", dbModel.RoleName));


            this.dbModel.IsDelete = 1;
            dbModel.UpdateUserId = helper.SvrUser.UserId;
            dbModel.UpdateTime = helper.SvrUser.CurrentTime;
        }


    }
}
