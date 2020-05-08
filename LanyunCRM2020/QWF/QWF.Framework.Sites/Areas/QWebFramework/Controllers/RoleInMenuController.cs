using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QWF.Framework.ExtendUtils;

namespace QWF.Framework.Sites.Areas.QWebFramework.Controllers
{
    public class RoleInMenuController : Controller
    {
        // GET: QWebFramework/RoleInMenu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetRoleList()
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var rows = db.T_QWF_Role.AsNoTracking().Where(w => w.IsDelete == 0).ToList().Select(o => new
                {
                    o.RoleId,
                    o.RoleName
                }).ToList();

                var data = new { total = rows.Count, rows = rows };
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(rows));
            }
        }

        public ActionResult GetMenuTree()
        {
            var roleId = this.Request["roleId"].SafeConvert().ToInt32(0);

            using (var db = DbAccess.DbFrameworkContext.Create())
            {

                var rows = (from a in db.T_QWF_Menu
                           join b in  db.T_QWF_RoleInMenu 
                                on new { a.MenuId, RoleId = roleId } equals new {b.MenuId,b.RoleId } into cc
                           from d in cc.DefaultIfEmpty()
                           orderby a.SortId
                           select new Models.RoleInMenu
                           {
                               IsSubNode = a.IsSubNode,
                               MenuName = a.MenuName,
                               ParentId = a.ParentId,
                               MenuId = a.MenuId,
                               RoleId = d.RoleId,

                           }).ToList();

                var tree = new Web.UI.TreeConverter<Models.RoleInMenu>();

                tree.GetId = m => { return m.MenuId.ToString(); };
                tree.GetParentId = m => { return m.ParentId.ToString(); };
                tree.GetCheckbox = m => { return m.RoleId != null && m.IsSubNode == 0 ? true : (bool?)null; };

                //映射字段
                var treeList = tree.ConvertTo(item =>
                {
                    var node = new Web.UI.BaseTreeNode();
                    node.id = item.MenuId.ToString();
                    //node.checkbox = item.RoleId
                    node.text = item.MenuName;
                    return node;
                }, rows.ToList(), "0");
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(treeList));
            }
        }


        public ActionResult SaveRoleInMenu()
        {
            var result = Web.ResultWebData.Default();
           //参数
            var roleId = this.Request["roleId"].SafeConvert().ToInt32(0);
            var menuIds = this.Request["menuIds"].StringHelper().SplitToArray(",", StringSplitOptions.RemoveEmptyEntries);

            //执行
            var services = MainServices.CreateWebAppServices.GetRoleServices();
            services.AddRoleInMenu(roleId, menuIds);
            //输出
            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }
    }
}