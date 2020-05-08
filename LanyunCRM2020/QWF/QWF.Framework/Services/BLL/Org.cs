using QWF.Framework.GlobalException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QWF.Framework.ExtendUtils;

namespace QWF.Framework.Services.BLL
{
    internal class Org
    {
        private DbAccess.T_QWF_Org dbModel;
        private BLL.OrgHelper helper;

        public Org(DbAccess.T_QWF_Org dbModel, BLL.OrgHelper helper)
        {
            this.dbModel = dbModel;
            this.helper = helper;
        }

        public int GetOrgId()
        {
            return dbModel.OrgId;
        }

        public void UpdateOrgInfo(int oldParentId, SvrModels.SvrOrgInfo svrModel)
        {
            this.dbModel.OrgName = svrModel.OrgName;
            this.dbModel.OrgAttribute = (int)svrModel.OrgAttribute;
            this.dbModel.IsOut = svrModel.IsOut;
            this.dbModel.Remarks = svrModel.Remarks;
            this.dbModel.UpdateTime = helper.SvrUser.CurrentTime;
            this.dbModel.UpdateUserId = helper.SvrUser.UserId;

            var oldIdList = this.dbModel.OrgIdList;
            if (svrModel.ParentId == svrModel.OrgId)
                throw new UIValidateException("所属机构不能设置和当前机构一样");

            if (oldParentId != svrModel.ParentId)//已经移动了节点
            {
                //相同一个节点下。父节点不能向子节点移动
                var qryIsSubNode = this.helper.DbContext.T_QWF_Org.ToList().Where(w => w.OrgId == svrModel.ParentId && w.OrgIdList.Contains("," + svrModel.OrgId + ","));
                if (qryIsSubNode.Count() > 0)
                    throw new UIValidateException("上级节点不能向下级节点移动");

                //原来的父节点
                var oldParentNode = this.helper.DbContext.T_QWF_Org.Where(w => w.OrgId == oldParentId && w.IsDelete == 0).FirstOrDefault();
                if (oldParentNode == null && oldParentId != 0)
                    throw new UIValidateException(string.Format("old orgid ={0} 不存在", oldParentId));

                var newParentNode = this.helper.DbContext.T_QWF_Org.Where(w => w.OrgId == svrModel.ParentId && w.IsDelete == 0).FirstOrDefault();
                if (newParentNode == null && svrModel.ParentId != 0)
                    throw new UIValidateException(string.Format("new orgid ={0} 不存在", svrModel.ParentId));

                this.dbModel.ParentId = svrModel.ParentId;
                
                
                //层级信息
                if (svrModel.ParentId == 0)
                {
                    this.dbModel.OrgIdList = "," + this.dbModel.OrgId + ",";
                    this.dbModel.LayerId = 1;
                }
                else
                {

                    this.dbModel.OrgIdList = newParentNode.OrgIdList + this.dbModel.OrgId + ",";
                    this.dbModel.LayerId = newParentNode.LayerId + 1;
                }
                this.dbModel.SortId = 0;


                //更新 变更后当前节点子节点的 idlist
                var subList = this.helper.DbContext.T_QWF_Org.Where(w => w.OrgIdList!=null && w.OrgIdList.Contains("," + this.dbModel.OrgId + ",") && w.OrgId != dbModel.OrgId).ToList();
                foreach(var sub in subList)
                {
                    sub.OrgIdList = sub.OrgIdList.Replace(oldIdList,dbModel.OrgIdList);
                    sub.LayerId = sub.OrgIdList.StringHelper().SplitToArray(",", StringSplitOptions.RemoveEmptyEntries).Length;
                }

                //这里改变了层级关系，防止后面计算错，先更新到db 中
                this.helper.DbContext.SaveChanges();

                
                this.UpdateSubNodeFlag(svrModel.OrgId);
                this.UpdateSubNodeFlag(svrModel.ParentId);
                this.UpdateSubNodeFlag(oldParentId);
            }

            this.helper.DbContext.SaveChanges();
            //更新路径
            this.UpdateOrgPath(svrModel.OrgId);
            this.UpdateOrgPath(svrModel.ParentId);
            this.UpdateOrgPath(oldParentId);
        }

        private void UpdateSubNodeFlag(int orgId)
        {
            if (orgId > 0)
            {
                var node = this.helper.DbContext.T_QWF_Org.Where(w => w.OrgId == orgId && w.IsDelete == 0).FirstOrDefault();
                var subCont = this.helper.DbContext.T_QWF_Org.Where(w => w.ParentId == orgId && w.IsDelete == 0).Count();
                node.IsSubNode = subCont > 0 ? 1 : 0;
            }

        }

        /// <summary>
        /// 更新路径
        /// </summary>
        /// <param name="orgId"></param>
        public void UpdateOrgPath(int orgId)
        {
            this.helper.DbContext.T_QWF_Org.ToList().Where(w => w.OrgIdList.IndexOf("," + orgId.ToString() + ",") > -1).ToList().ForEach(org =>
            {
                
                var orgIds = org.OrgIdList.StringHelper().SplitToArray(",", StringSplitOptions.RemoveEmptyEntries);
                var orgItems = this.helper.DbContext.T_QWF_Org.Select(s => new { s.OrgId, s.OrgName, s.OrgCode }).ToList().Where(w => orgIds.Contains(w.OrgId.ToString()));
                var orgNamePath = string.Empty;
                var orgCodeList = ",";
                foreach (var item in orgItems)
                {
                    orgCodeList = orgCodeList + item.OrgCode + ",";

                    if (orgNamePath.Length > 0)
                        orgNamePath += ">";

                    orgNamePath += item.OrgName;
                }

                org.OrgNamePath = orgNamePath;
                org.OrgCodeList = orgCodeList;
            });

           
        }

        public void Deleted()
        {
            //当前节点是否有用户。
            // 当前下是否有子节点
            var userNum = this.helper.DbContext.T_QWF_User.Where(w => w.OrgId == dbModel.OrgId && w.IsDelete == 0).Count();
            if (userNum > 0)
                throw new UIValidateException(string.Format("【{0}】机构下是有存在用户，不能删除！如需要删除，请先删除【{0}】机构下的用户。",dbModel.OrgName));

            var isSubNum = this.helper.DbContext.T_QWF_Org.Where(w => w.ParentId == dbModel.OrgId && w.IsDelete == 0).Count();
            if (isSubNum > 0)
                throw new UIValidateException(string.Format("【{0}】机构下存在子节点，不能删除！如需要删除，请先删除【{0}】机构下的子节点。", dbModel.OrgName));

            this.dbModel.IsDelete = 1;
            this.dbModel.UpdateTime = helper.SvrUser.CurrentTime;
            this.dbModel.UpdateUserId = helper.SvrUser.UserId;

        }
    }
}
