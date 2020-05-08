using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QWF.Framework.GlobalException;
using QWF.Framework.ExtendUtils;

namespace QWF.Framework.Services.BLL
{
    internal class OrgHelper
    {
        public DbAccess.DbFrameworkContext DbContext { get; private set; }
        public SvrModels.SvrUserIdentifier SvrUser { get; private set; }

        public OrgHelper(DbAccess.DbFrameworkContext db,Services.SvrModels.SvrUserIdentifier svrUser)
        {
            this.DbContext = db;
            this.SvrUser = svrUser;
        }

        /// <summary>
        /// 按ID获取机构ID
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        public Org GetOrgInfoById(int orgId)
        {
            var info = DbContext.T_QWF_Org.Where(w => w.OrgId == orgId && w.IsDelete == 0).FirstOrDefault();
            return info == null ? null : new Org(info, this);   
        }

        public Org CreateOrgInfo(SvrModels.SvrOrgInfo info)
        {
            var dbModel = new DbAccess.T_QWF_Org();
 
            dbModel.OrgCode = info.OrgCode;
            dbModel.OrgName = info.OrgName;
            dbModel.OrgAttribute = (int)info.OrgAttribute;
            dbModel.IsOut = info.IsOut;
            dbModel.ParentId = info.ParentId;
            dbModel.CreateTime = SvrUser.CurrentTime;
            dbModel.CreateUserId = SvrUser.UserId;
            dbModel.Remarks = info.Remarks;
            dbModel.IsSubNode = 1;
            //关键参数
            dbModel.ParentId = info.ParentId;
            string orgIdList = string.Empty;
            if (info.ParentId == 0)
            {
                //顶级节点
                dbModel.LayerId = 1;
                dbModel.SortId = 0;
                orgIdList = ",";
            }
            else
            {
                //找到父节点信息
                var dbParentNode = DbContext.T_QWF_Org.Where(w => w.OrgId == info.ParentId && w.IsDelete == 0).FirstOrDefault();
                if (dbParentNode == null)
                    throw new UIValidateException("上级节点信息获取失败");

                //设置当前节点信息
                dbModel.LayerId = dbParentNode.LayerId + 1;//层级+1
                orgIdList = dbParentNode.OrgIdList;


                var qrySort = DbContext.T_QWF_Org.Where(w => w.ParentId == info.ParentId && w.IsDelete == 0);
                if (qrySort.Count() == 0)
                {
                    dbModel.SortId = 1;
                }
                else
                {
                    //获取父接点下的子节点最大的SortId + 1
                    dbModel.SortId = qrySort.Max(m => m.SortId) + 1;
                  
                }

                //更新父节点的IsSubNode
                dbParentNode.IsSubNode = 1;

            }

            //这里要获取到自增ID，只能这样做了
            DbContext.T_QWF_Org.Add(dbModel);
            DbContext.SaveChanges();

            //这里再修改OrgIdList;
            dbModel.OrgIdList = orgIdList  + dbModel.OrgId + ",";

            var org = new Org(dbModel,this);

            org.UpdateOrgPath(dbModel.OrgId);

            return org;
        }

       
    }
}
