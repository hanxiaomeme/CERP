using QWF.Framework.GlobalException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Services
{
    public class ResouceServices
    {
        private SvrModels.SvrUserIdentifier svrUser;

        public ResouceServices(SvrModels.SvrUserIdentifier svrUser)
        {
            this.svrUser = svrUser;
        }

        public int CreateResourceCode(string resourceCode, string resourceName,string remarks)
        {
            if (string.IsNullOrEmpty(resourceCode))
                throw new UIValidateException("资源代码为null");

            using (var db = DbAccess.DbFrameworkContext.Create())
            {
               if( db.T_QWF_Resource.Where(w => w.ResourceCode == resourceCode).Count()>0)
                    throw new UIValidateException(string.Format("资源代码不能重复!资源代码【{0}】", resourceCode));

                var dbModel = new DbAccess.T_QWF_Resource();
                dbModel.ResourceName = resourceName;
                dbModel.ResourceCode = resourceCode;
                dbModel.ResourceRemarks = remarks;
                dbModel.CreateTime = svrUser.CurrentTime;
                dbModel.CreateUserId = svrUser.UserId;

                db.T_QWF_Resource.Add(dbModel);

                db.SaveChanges();

                return dbModel.RuleId;
            }
        }

        public bool UpdateResourceCode(int ruleId, string resourceName,string remarks)
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var dbModel = db.T_QWF_Resource.Where(w => w.RuleId == ruleId).FirstOrDefault();
                if (dbModel == null)
                    throw new UIValidateException(string.Format("资源代码不存在,ID=【{0}】", ruleId));

                dbModel.ResourceName = resourceName;
                dbModel.ResourceRemarks = remarks;
                dbModel.UpdateTime = svrUser.CurrentTime;
                dbModel.UpdateUserId = svrUser.UserId;
                

                db.SaveChanges();
                return true;
            }
        }

        public bool DeleteResource(int ruleId)
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                if (db.T_QWF_RoleInResource.Where(w => w.RuleId == ruleId).Count() > 0)
                    throw new UIValidateException("请先选删除【角色控制权限】的对应的数据");

                var dbModel = db.T_QWF_Resource.Where(w => w.RuleId == ruleId).FirstOrDefault();
                if (dbModel != null)
                {
                    db.T_QWF_Resource.Remove(dbModel);
                    db.SaveChanges();
                }

                return true;
            }
        }
    }
}
