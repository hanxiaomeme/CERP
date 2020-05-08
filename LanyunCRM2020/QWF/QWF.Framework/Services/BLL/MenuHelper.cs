using QWF.Framework.GlobalException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Services.BLL
{
    internal class MenuHelper
    {
        public DbAccess.DbFrameworkContext DbContext { get; private set; }
        public SvrModels.SvrUserIdentifier SvrUser { get; private set; }

        public MenuHelper(DbAccess.DbFrameworkContext db, Services.SvrModels.SvrUserIdentifier svrUser)
        {
            this.DbContext = db;
            this.SvrUser = svrUser;
        }

        public Menu GetMenuNode(int menuId)
        {
            var dbModel = DbContext.T_QWF_Menu.Where(w => w.MenuId == menuId).FirstOrDefault();

            return dbModel == null ? null : new Menu(dbModel, this);

        }
        public Menu CreateMenuNode(int parentId, string menuName, string iconCls)
        {

            var dbModel = new DbAccess.T_QWF_Menu();

            dbModel.MenuName = menuName;
            dbModel.ParentId = parentId;
            dbModel.IsShow = 1;
            dbModel.IconCls = iconCls;
            dbModel.CreateTime = SvrUser.CurrentTime;
            dbModel.CreateUserId = SvrUser.UserId;

            //关键参数
            string menuIdList = string.Empty;
            if (parentId == 0)
            {
                //顶级节点
                dbModel.LayerId = 1;
                dbModel.SortId = 0;
                menuIdList = ",";
            }
            else
            {
                //找到父节点信息
                var dbParentNode = DbContext.T_QWF_Menu.Where(w => w.MenuId == parentId).FirstOrDefault();
                if (dbParentNode == null)
                    throw new UIValidateException("上级节点信息获取失败");

                //设置当前节点信息
                dbModel.LayerId = dbParentNode.LayerId + 1;//层级+1
                menuIdList = dbParentNode.MenuIdList;

                var qrySort = DbContext.T_QWF_Menu.Where(w => w.ParentId == parentId);
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
            DbContext.T_QWF_Menu.Add(dbModel);
            DbContext.SaveChanges();

            //这里再修改OrgIdList;
            dbModel.MenuIdList = menuIdList + dbModel.MenuId + ",";

            return new Menu(dbModel, this);
        }




    }
}
