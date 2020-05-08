using QWF.Framework.ExtendUtils;
using QWF.Framework.GlobalException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Services.BLL
{
    internal class Menu
    {

        private DbAccess.T_QWF_Menu dbModel;
        private BLL.MenuHelper helper;

        public int MenuId
        {
            get
            {
                return dbModel.MenuId;
            }
        }

        public Menu(DbAccess.T_QWF_Menu dbModel, BLL.MenuHelper helper)
        {
            this.dbModel = dbModel;
            this.helper = helper;
        }

        public void UpdateMenuNode(int oldParentId, SvrModels.SvrMenuInfo svrModel)
        {
            this.dbModel.MenuName = svrModel.MenuName;
            this.dbModel.IsShow = svrModel.IsShow ? 1 : 0;
            this.dbModel.Target = svrModel.IsTarget ? 1 : 0;
            this.dbModel.IconCls = svrModel.IconCls;
            this.dbModel.DefaultUrl = svrModel.DefaultUrl;

            this.dbModel.UpdateTime = helper.SvrUser.CurrentTime;
            this.dbModel.UpdateUserId = helper.SvrUser.UserId;

            var oldIdList = this.dbModel.MenuIdList;

            if (svrModel.ParentId == svrModel.MenuId && oldParentId > 0)
                throw new UIValidateException("所属菜单不能设置和当前菜单一样");

            if (oldParentId != svrModel.ParentId)//已经移动了节点
            {
                //相同一个节点下。父节点不能向子节点移动
                var qryIsSubNode = this.helper.DbContext.T_QWF_Menu.Where(w => w.MenuId == svrModel.ParentId).ToList().Where(w=> w.MenuIdList.IndexOf("," + svrModel.MenuId + ",") > -1);

                if (qryIsSubNode.Count() >0)
                    throw new UIValidateException("上级节点不能向下级节点移动");

                //原来的父节点
                var oldParentNode = this.helper.DbContext.T_QWF_Menu.Where(w => w.MenuId == oldParentId ).FirstOrDefault();
                if (oldParentNode == null && oldParentId != 0)
                    throw new UIValidateException(string.Format("old menuid ={0} 不存在", oldParentId));

                var newParentNode = this.helper.DbContext.T_QWF_Menu.Where(w => w.MenuId == svrModel.ParentId).FirstOrDefault();
                if (newParentNode == null && svrModel.ParentId != 0)
                    throw new UIValidateException(string.Format("new menuid ={0} 不存在", svrModel.ParentId));

                this.dbModel.ParentId = svrModel.ParentId;


                //层级信息
                if (svrModel.ParentId == 0)
                {
                    this.dbModel.MenuIdList = "," + this.dbModel.MenuId + ",";
                    this.dbModel.LayerId = 1;
                }
                else
                {

                    this.dbModel.MenuIdList = newParentNode.MenuIdList + this.dbModel.MenuId + ",";
                    this.dbModel.LayerId = newParentNode.LayerId + 1;
                }
                this.dbModel.SortId = 0;

                //更新 变更后当前节点子节点的 idlist
                //var subList = this.helper.DbContext.T_QWF_Menu.Where(w => (w.MenuIdList.Contains("," + this.dbModel.MenuId + ",")) && w.MenuId != dbModel.MenuId).ToList();
                var subList = this.helper.DbContext.T_QWF_Menu.ToList().Where(w => w.MenuIdList.IndexOf("," + this.dbModel.MenuId + ",")>0 && w.MenuId != dbModel.MenuId).ToList();
                foreach (var sub in subList)
                {
                    sub.MenuIdList = sub.MenuIdList.Replace(oldIdList, dbModel.MenuIdList);
                    sub.LayerId = sub.MenuIdList.StringHelper().SplitToArray(",", StringSplitOptions.RemoveEmptyEntries).Length;
                }
            }

            this.UpdateSubNodeFlag(svrModel.MenuId);
            this.UpdateSubNodeFlag(svrModel.ParentId);
            this.UpdateSubNodeFlag(oldParentId);

            //更新菜单URL

            //urls 
            //清除 menuid 的 URL
            helper.DbContext.T_QWF_MenuInUrl.Where(w => w.MenuId == svrModel.MenuId).ToList().ForEach(item =>
            {
                helper.DbContext.T_QWF_MenuInUrl.Remove(item);
            });

            //写入
            svrModel.Urls.Distinct().ToList().ForEach(url =>
            {
                if(url.Length>0)
                {
                    helper.DbContext.T_QWF_MenuInUrl.Add(new DbAccess.T_QWF_MenuInUrl
                    {
                        MenuId = dbModel.MenuId,
                        Url = url.Trim(),
                        CreateTime = this.helper.SvrUser.CurrentTime,
                        CreateUserId = this.helper.SvrUser.UserId
                    });
                }
                
            });

        }


        private void UpdateSubNodeFlag(int menuId)
        {
            if (menuId > 0)
            {
                var node = this.helper.DbContext.T_QWF_Menu.Where(w => w.MenuId == menuId).FirstOrDefault();
                var subCont = this.helper.DbContext.T_QWF_Menu.Where(w => w.ParentId == menuId).Count();
                node.IsSubNode = subCont > 0 ? 1 : 0;
            }

        }


        public void Delete()
        {
            if (helper.DbContext.T_QWF_Menu.Where(w => w.ParentId == dbModel.MenuId).Count() > 0)
                throw new UIValidateException(string.Format("【{0}】存在子节点, 请先删除子节点", dbModel.MenuName));

          
            //清除url节点
            helper.DbContext.T_QWF_MenuInUrl.Where(w => w.MenuId == dbModel.MenuId).ToList().ForEach(item =>
            {
                helper.DbContext.T_QWF_MenuInUrl.Remove(item);
            });
            ////清除角色对应的菜单
            helper.DbContext.T_QWF_RoleInMenu.Where(w => w.MenuId == dbModel.MenuId).ToList().ForEach(item =>
            {
                helper.DbContext.T_QWF_RoleInMenu.Remove(item);
            });

            helper.DbContext.T_QWF_Menu.Remove(dbModel);
        }

    }
}
