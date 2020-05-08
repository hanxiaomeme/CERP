using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QWF.Framework.ExtendUtils;
using QWF.Framework.GlobalException;

namespace QWF.Framework.Sites.Areas.QWebFramework.Controllers
{
    public class MenuController : Controller
    {
        // GET: QWebFramework/MenuList
        public ActionResult MenuList()
        {
            return View();
        }

        public ActionResult MenuSort()
        {
            return View();
        }

        public ActionResult GetMenuTreeGrid()
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                //获取全部机构数据
                var items = db.T_QWF_Menu.AsNoTracking().OrderBy(o => o.SortId).
                    ThenBy(o => o.MenuName).AsQueryable().ToList();

                var tree = new Web.UI.TreeConverter<DbAccess.T_QWF_Menu>();

                tree.GetId = m => { return m.MenuId.ToString(); };
                tree.GetParentId = m => { return m.ParentId.ToString(); };
                tree.ClosedLayer = 2;

                var result = tree.ConvertTo(item => {
                    var node = new Models.MenuTreeGrid();
                    node.id = item.MenuId.ToString();

                    node.MenuId = item.MenuId;
                    node.MenuName = item.MenuName;
                    node.CreateTime = item.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
                    node.UpdateTime = item.UpdateTime == null ? string.Empty : item.UpdateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");

                  return node;
                }, items, "0");

                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
            }


        }

        public ActionResult MenuTreeSort()
        {
            var dic = QWF.Framework.Web.QWFRequest.GetSortDictionary();

            var result = Web.ResultWebData.Default();
            //排序
            MainServices.CreateWebAppServices.GetMenuServices().MenuTreeSort(dic);


            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        public ActionResult GetMenuTree()
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                //获取全部显示的菜单数据
                var items = db.T_QWF_Menu.AsNoTracking().
                    OrderBy(o => o.SortId).ThenBy(o => o.MenuName).ToList();

                var tree = new Web.UI.TreeConverter<DbAccess.T_QWF_Menu>();

                tree.GetId = m => { return m.MenuId.ToString(); };
                tree.GetParentId = m => { return m.ParentId.ToString(); };

                //映射字段
                var treeList = tree.ConvertTo(item =>
                {
                    var node = new Web.UI.BaseTreeNode();
                    node.id = item.MenuId.ToString();
                    node.text = item.MenuName;
                    //node.attributes = new
                    return node;
                }, items, "0");
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(treeList));
            }

        }

        public ActionResult GetMenuInfo()
        {
            var menuId = this.Request["menuId"].SafeConvert().ToInt32();
            if (menuId == 0)
                throw new UIValidateException("MenuID为0！");

            var result = Web.ResultWebData.Default();
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                //获取全部显示的菜单数据
                var info = db.T_QWF_Menu.AsNoTracking().Where(w => w.MenuId == menuId).FirstOrDefault();

                if (info == null)
                    throw new UIValidateException("菜单不存在,已经被删除或ID不正确!");

                //菜单下的Urls
                var urls = string.Empty;

                db.T_QWF_MenuInUrl.AsNoTracking().Where(w => w.MenuId == menuId).ToList().ForEach(items =>
                {
                    if (urls.Length > 0)
                        urls += Environment.NewLine;

                    urls += items.Url;
                });


                result.Data = new
                {
                    MenuId = info.MenuId,
                    MenuName = info.MenuName,
                    IsShow = info.IsShow,
                    IsTarget = info.Target,
                    IconCls = info.IconCls,
                    ParentId = info.ParentId,
                    DefaultUrl = info.DefaultUrl,

                    MenuUrls = urls
                };

                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
            }
        }

        public ActionResult GetMenuInRole()
        {

            //业务参数
            var menuId = this.Request["menuId"].SafeConvert().ToInt32(0);
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                //获取全部显示的菜单数据
                var qry = from a in db.T_QWF_Role
                          join b in db.T_QWF_RoleInMenu on a.RoleId equals b.RoleId
                          where a.IsDelete==0 && b.MenuId == menuId
                          select new
                          {
                              a.RoleName,
                              b.MenuId,
                              b.RoleId
                          };


                var total = qry.Count();
                var result = new { total = total, rows = qry.ToList() };

                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
            }
        }

        public ActionResult AddMenu()
        {
            var result = Web.ResultWebData.Default();

            var parentId = this.Request["parentId"].SafeConvert().ToInt32();
            var menuName = this.Request["menuName"].SafeConvert().ToStr();

            int menuId = MainServices.CreateWebAppServices.GetMenuServices().AddMenu(parentId, menuName);
            result.Data = new { MenuId = menuId };

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));

        }

        public ActionResult EditMenu()
        {
            var oldParentId = this.Request["oldParentId"].SafeConvert().ToInt32(0);

            var svrModel = new Services.SvrModels.SvrMenuInfo();
            svrModel.MenuId = this.Request["menuId"].SafeConvert().ToInt32(0);
            svrModel.MenuName = this.Request["menuName"].SafeConvert().ToStr();
            svrModel.ParentId = this.Request["parentId"].SafeConvert().ToInt32(0);
            svrModel.IsShow = this.Request["isShow"].SafeConvert().ToBool();
            svrModel.IconCls = this.Request["iconCls"].SafeConvert().ToStr();
            svrModel.IsTarget = this.Request["isTarget"].SafeConvert().ToBool();
            svrModel.Urls = new List<string>();

            var urls = this.Request["menuUrls"].SafeConvert().ToStr();
            string sLine = null;
            System.IO.StringReader sr = new System.IO.StringReader(urls);
            while ((sLine = sr.ReadLine())!=null)
            {
                svrModel.Urls.Add(sLine);
            }
            svrModel.DefaultUrl = this.Request["defaultUrl"].SafeConvert().ToStr();
            MainServices.CreateWebAppServices.GetMenuServices().EditMenu(oldParentId, svrModel);

            var result = Web.ResultWebData.Default();
            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        public ActionResult DeleteMenu()
        {
            var menuId = this.Request["menuId"].SafeConvert().ToInt32(0);
            MainServices.CreateWebAppServices.GetMenuServices().DeleteMenu(menuId);
            var result = Web.ResultWebData.Default();
            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

    }
}