using QWF.Framework.GlobalException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Services
{
    public class MenuServices
    {
        private SvrModels.SvrUserIdentifier svrUser;

        public MenuServices(SvrModels.SvrUserIdentifier svrUser)
        {
            this.svrUser = svrUser;
        }

        /// <summary>
        /// menuId, sortId
        /// </summary>
        /// <param name="dic"> 数据集合 key=orgid,value=sortid</param>
        /// <returns></returns>
        public bool MenuTreeSort(Dictionary<int, int> dic)
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                foreach (var d in dic)
                {
                    var dbModel = db.T_QWF_Menu.Where(w => w.MenuId == d.Key).FirstOrDefault();
                    if (dbModel != null)
                        dbModel.SortId = d.Value;

                }
                db.SaveChanges();
            }
            return true;
        }
        /// <summary>
        /// 添加菜单节点
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="menuName"></param>
        /// <returns></returns>
        public int AddMenu(int parentId,string menuName)
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var helper = new BLL.MenuHelper(db, svrUser);
                var menu = helper.CreateMenuNode(parentId, menuName, null);

                db.SaveChanges();
                return menu.MenuId;

            }
        }

        public bool EditMenu(int oldParentId,SvrModels.SvrMenuInfo svrModel)
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var helper = new BLL.MenuHelper(db, this.svrUser);
                var menu = helper.GetMenuNode(svrModel.MenuId);

                if (menu == null)
                    throw new UIValidateException("菜单不存在，ID="+svrModel.MenuId);

                menu.UpdateMenuNode(oldParentId, svrModel);
                db.SaveChanges();
                return true;
            }
        }

        public bool DeleteMenu(int menuId)
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var helper = new BLL.MenuHelper(db, this.svrUser);
                var menu = helper.GetMenuNode(menuId);

                if (menu == null)
                    throw new UIValidateException("菜单不存在，ID=" + menuId);

                menu.Delete();
                db.SaveChanges();
                return true;
            }
        }


    }
}
