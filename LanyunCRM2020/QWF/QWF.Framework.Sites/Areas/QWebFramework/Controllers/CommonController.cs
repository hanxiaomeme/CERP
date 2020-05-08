using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QWF.Framework.ExtendUtils;

namespace QWF.Framework.Sites.Areas.QWebFramework.Controllers
{
    public class CommonController : Controller
    {
        private string ConvertUrl(string url)
        {
            if(url.StartsWith("http") || url.StartsWith("https"))
            {
                return url;
            }
            else if(url.StartsWith("/"))
            {
                return Url.Content("~" + url);
            }
            else
            {
                return Url.Content("~/" + url);
            }

        }
        // GET: QWebFramework/Common/GetUserLeftMenu
        public ActionResult GetUserLeftMenu()
        {
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            using (var db = QWF.Framework.DbAccess.DbFrameworkContext.Create())
            {
                //权限过滤
                var qryMenuIds = (from a in db.T_QWF_RoleInMenu
                                  join b in db.T_QWF_UserInRole on a.RoleId equals b.RoleId
                                  join c in db.T_QWF_Menu on a.MenuId equals c.MenuId
                                  where b.UserId == curUser.CurrentUserId && c.IsShow == 1
                                  select c.MenuIdList).ToList();

                List<int> menuIds = new List<int>();
                foreach(var ids in qryMenuIds)
                {
                    ids.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(id =>
                    {
                        if (id.Length > 0)
                        {
                            menuIds.Add(id.SafeConvert().ToInt32());
                        }
                    });
                }

                menuIds = menuIds.Distinct().ToList();




                var rows = db.T_QWF_Menu.Where(w => menuIds.Contains(w.MenuId)).OrderBy(o => o.SortId).Select(s => new Models.LeftMenuTree
                {
                    MenuId = s.MenuId,
                    ParentId = s.ParentId,
                    MenuName = s.MenuName,
                    DefaultUrl =s.DefaultUrl,
                    IconCls = s.IconCls,
                    Target = s.Target
                }).ToList();
           
                var tree = new Web.UI.TreeConverter<Models.LeftMenuTree>();

                //设置树属性
                tree.ClosedLayer = 1;
                tree.GetId = m => { return m.MenuId.ToString(); };
                tree.GetParentId = m => { return m.ParentId.ToString(); };
                //tree.SetSelectedId = "100005";

                //转化
                var treeList = tree.ConvertTo(item =>
                {
                    //设置每个树节点的数据
                    var node = new Web.UI.BaseTreeNode();
                    node.id = item.MenuId.ToString();
                    node.text = item.MenuName;
                    node.iconCls = item.IconCls;
                    //扩展属性
                    dynamic attributes = new ExpandoObject();
                    attributes.url = ConvertUrl(item.DefaultUrl);
                    attributes.menuId = item.MenuId;
                    attributes.target = item.Target;

                    node.attributes = attributes;

                    return node;
                }, rows, "100000");

                return this.Content(JsonConvert.SerializeObject(treeList));
            }
        }

        /// <summary>
        /// QWebFramework/Common/GetOrgTree
        /// </summary>
        /// <returns></returns>
        public ActionResult GetOrgTree()
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var rows = db.T_QWF_Org.AsNoTracking().Where(w => w.IsDelete == 0).OrderBy(o => o.SortId).ThenBy(o => o.OrgName).ToList();

                var tree = new Web.UI.TreeConverter<DbAccess.T_QWF_Org>();

                tree.ClosedLayer = 2;//这里要全部展开。否则是会异步加载
                
                tree.GetId = m => { return m.OrgId.ToString(); };
                tree.GetParentId = m => { return m.ParentId.ToString(); };

                //映射字段
                var treeList = tree.ConvertTo(item =>
                {
                    var node = new Web.UI.BaseTreeNode();
                    node.id = item.OrgId.ToString();

                    node.text = item.OrgName;
                    return node;
                }, rows, "0");
                return this.Content(JsonConvert.SerializeObject(treeList));
            }
        }

    }
}