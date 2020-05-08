using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QWF.Framework.ExtendUtils;
using QWF.Framework.GlobalException;

namespace QWF.Framework.Services
{
    /// <summary>
    /// 机构服务接口
    /// </summary>
    public class OrgServices
    {
        private SvrModels.SvrUserIdentifier svrUser;

        public OrgServices(Services.SvrModels.SvrUserIdentifier svrUser)
        {
            this.svrUser = svrUser;
        }

        /// <summary>
        /// 创建机构节点
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int CreateOrg(SvrModels.SvrOrgInfo info)
        {
            if (info.OrgCode.StrValidatorHelper().StrIsNullOrEmpty())
            {
                var common = new SeqServices(this.svrUser);
                info.OrgCode = common.CreateNewSeqNo("system.orgcode");
            }

            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var helper = new Services.BLL.OrgHelper(db,this.svrUser);
                var org = helper.CreateOrgInfo(info);

                //提交
                db.SaveChanges();
                return org.GetOrgId();
            }
        }

        public bool UpdateOrg(int oldParentId,SvrModels.SvrOrgInfo info)
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var helper = new BLL.OrgHelper(db, this.svrUser);
                var org = helper.GetOrgInfoById(info.OrgId);
                if (org == null)
                    throw new UIValidateException(string.Format("机构不存在orgId={0}", info.OrgId.ToString()));

                org.UpdateOrgInfo(oldParentId, info);

                db.SaveChanges();
                
            }
            return true;
        }

        public bool DeleteOrg(int orgId)
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var helper = new BLL.OrgHelper(db, this.svrUser);
                var org = helper.GetOrgInfoById(orgId);

                if (org == null)
                    throw new UIValidateException(string.Format("机构不存在或已被删除ORGID={0}", orgId));

                //删除
                org.Deleted();

                db.SaveChanges();

            }
            return true;
        }

        /// <summary>
        /// orgId, sortId
        /// </summary>
        /// <param name="dic"> 数据集合 key=orgid,value=sortid</param>
        /// <returns></returns>
        public bool TreeSort(Dictionary<int, int> dic)
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                foreach(var d in dic)
                {
                    var dbModel = db.T_QWF_Org.Where(w => w.OrgId == d.Key && w.IsDelete == 0).FirstOrDefault();
                    if (dbModel != null)
                        dbModel.SortId = d.Value;
                   
                }

                db.SaveChanges();
            }
            return true;
        }
    }
}
