using QWF.Framework.GlobalException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Services.BLL
{
    internal class RoleGroup
    {
        private DbAccess.T_QWF_RoleGroup dbModel;

        private RoleHelper helper;

        public RoleGroup(DbAccess.T_QWF_RoleGroup dbModel, RoleHelper helper)
        {
            this.dbModel = dbModel;
            this.helper = helper;
        }

        #region 角色组
        public int GetGroupId()
        {
            return dbModel.GroupId;
        }

        public void UpdateRoleGroup(SvrModels.SvrRoleGroupInfo svrModel)
        {
            //验证模型
            var checkModel = QWF.Framework.Validation.ValidationHelper.Validate(svrModel);
            if (!checkModel.IsValid)
                throw new UIValidateException("数据验证失败！" + checkModel.ToString());
            //设置
            if (dbModel == null)
                throw new UIValidateException("角色组模型为NULL！" + checkModel.ToString());

            if( helper.DbContext.T_QWF_RoleGroup.Where(w => w.GroupName == svrModel.GroupName && w.IsDelete == 0 && w.GroupId != svrModel.GroupId).Count()>0)
                throw new UIValidateException(string.Format("角色组【{0}】名称已存在，请换一个名称!",svrModel.GroupName));

            dbModel.GroupName = svrModel.GroupName;
            dbModel.GroupRemarks = svrModel.GroupRemarks;

            dbModel.UpdateTime = helper.SvrUser.CurrentTime;

        }

        public void Deleted()
        {
            //
            if (helper.DbContext.T_QWF_Role.Where(w => w.RoleGroupId == dbModel.GroupId && w.IsDelete == 0).Count() > 0)
                throw new UIValidateException(string.Format("如需要删除角色组，请先删除【{0}】角色组下的角色", dbModel.GroupName));

            dbModel.IsDelete = 1;
        }

        #endregion
    }
}
