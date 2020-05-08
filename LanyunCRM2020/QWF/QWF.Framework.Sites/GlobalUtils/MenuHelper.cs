using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QWF.Framework.ExtendUtils;

namespace QWF.Framework.Sites.GlobalUtils
{
    public class MenuHelper
    {
        /// <summary>
        /// 面包屑导航 
        /// </summary>
        /// <returns></returns>
        public static List<string> GetLocationNavMenu()
        {
            List<string> list = new List<string>();

            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                //获取当前路径
                string url = QWF.Framework.Web.QWFRequest.GetAbsolutePath();
                //查询出menuIds 
                var menuIds = (from a in db.T_QWF_MenuInUrl
                                 join b in db.T_QWF_Menu on a.MenuId equals b.MenuId
                                 where a.Url == url || a.Url == url.Substring(1)
                                 select new
                                 {
                                     b.MenuIdList
                                 }).FirstOrDefault();

                if (menuIds != null)
                {
                    var menuIdList = menuIds.ToString().StringHelper().SplitToList(",", StringSplitOptions.RemoveEmptyEntries);

                    var qry = db.T_QWF_Menu.Where(w => menuIdList.Contains(w.MenuId.ToString()));

                    qry.Select(o => new { o.MenuName }).ToList().ForEach(item =>
                    {
                        list.Add(item.MenuName);
                    });

                }

                return list;

            }
        }

    }
}