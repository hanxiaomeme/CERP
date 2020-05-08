using QWF.Framework.ExtendUtils;
using QWF.Framework.GlobalException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Services.BLL
{
    internal class Config
    {
        private DbAccess.T_QWF_Config dbModel;
        private BLL.ConfigHelper helper;

        public int ConfigId
        {
            get
            {
                return dbModel.ConfigId;
            }
        }

        public Config(DbAccess.T_QWF_Config dbModel, BLL.ConfigHelper helper)
        {
            this.dbModel = dbModel;
            this.helper = helper;
        }

        public void UpdateConfigNode(int oldParentId, SvrModels.SvrConfigInfo svrModel)
        {
            this.dbModel.ConfigName = svrModel.ConfigName;
            this.dbModel.ConfigValue = svrModel.ConfigValue;
            this.dbModel.ConfigValueType = svrModel.ConfigValueType;
            this.dbModel.ConfigResourceCode = svrModel.ConfigResourceCode;
            this.dbModel.ConfigRemarks = svrModel.ConfigRemarks;

            this.dbModel.UpdateTime = helper.SvrUser.CurrentTime;
            this.dbModel.UpdateUserId = helper.SvrUser.UserId;

            var oldIdList = this.dbModel.ConfigIdList;

            if(this.helper.DbContext.T_QWF_Config.Where(w=>w.ConfigResourceCode == svrModel.ConfigResourceCode && w.ConfigId != svrModel.ConfigId  && svrModel.ConfigResourceCode.Length>0).Count() >0 )
                throw new UIValidateException("节点代码【{0}】已经存在！",svrModel.ConfigResourceCode);

            //svrModel.ParentId == svrModel.OrgId
            if (svrModel.ParentId == svrModel.ConfigId)
                throw new UIValidateException("所属节点不能设置和当前节点一样");

            if (oldParentId != svrModel.ParentId)//已经移动了节点
            {
                //相同一个节点下。父节点不能向子节点移动
                var qryIsSubNode = this.helper.DbContext.T_QWF_Config.ToList().Where(w => w.ConfigId == svrModel.ParentId && w.ConfigIdList.Contains("," + svrModel.ConfigId + ","));
                if (qryIsSubNode.Count() > 0)
                    throw new UIValidateException("上级节点不能向下级节点移动");

                //原来的父节点
                var oldParentNode = this.helper.DbContext.T_QWF_Config.Where(w => w.ConfigId == oldParentId).FirstOrDefault();
                if (oldParentNode == null && oldParentId != 0)
                    throw new UIValidateException(string.Format("old configid ={0} 不存在", oldParentId));

                var newParentNode = this.helper.DbContext.T_QWF_Config.Where(w => w.ConfigId == svrModel.ParentId).FirstOrDefault();
                if (newParentNode == null && svrModel.ParentId != 0)
                    throw new UIValidateException(string.Format("new configId ={0} 不存在", svrModel.ParentId));

                this.dbModel.ParentId = svrModel.ParentId;


                //层级信息
                if (svrModel.ParentId == 0)
                {
                    this.dbModel.ConfigIdList = "," + this.dbModel.ConfigId + ",";
                    this.dbModel.LayerId = 1;
                }
                else
                {

                    this.dbModel.ConfigIdList = newParentNode.ConfigIdList + this.dbModel.ConfigId + ",";
                    this.dbModel.LayerId = newParentNode.LayerId + 1;
                }
                this.dbModel.SortId = 0;

                //更新 变更后当前节点子节点的 idlist
                var subList = this.helper.DbContext.T_QWF_Config.ToList().Where(w => w.ConfigIdList.Contains("," + this.dbModel.ConfigId + ",") && w.ConfigId != dbModel.ConfigId).ToList();
                foreach (var sub in subList)
                {
                    sub.ConfigIdList = sub.ConfigIdList.Replace(oldIdList, dbModel.ConfigIdList);
                    sub.LayerId = sub.ConfigIdList.StringHelper().SplitToArray(",", StringSplitOptions.RemoveEmptyEntries).Length;
                }
            }

            //这里改变了层级关系，防止后面计算错，先更新到db 中
            this.helper.DbContext.SaveChanges();

            this.UpdateSubNodeFlag(svrModel.ConfigId);
            this.UpdateSubNodeFlag(svrModel.ParentId);
            this.UpdateSubNodeFlag(oldParentId);
        }

        private void UpdateSubNodeFlag(int configId)
        {
            if (configId > 0)
            {
                var node = this.helper.DbContext.T_QWF_Config.Where(w => w.ConfigId == configId && w.IsDelete == 0 ).FirstOrDefault();
                var subCont = this.helper.DbContext.T_QWF_Config.Where(w => w.ParentId == configId && w.IsDelete == 0).Count();
                node.IsSubNode = subCont > 0 ? 1 : 0;
            }

        }


        public void Delete()
        {
            if (helper.DbContext.T_QWF_Config.Where(w => w.ParentId == dbModel.ConfigId && w.IsDelete == 0).Count() > 0)
                throw new UIValidateException(string.Format("【{0}】存在子节点, 请先删除子节点", dbModel.ConfigName));

            this.dbModel.IsDelete = 1;
        }

        public void Hidden()
        {
            this.dbModel.IsHidden = 1;
        }

        public void Show()
        {
            this.dbModel.IsHidden = 0;
        }
    }
}
