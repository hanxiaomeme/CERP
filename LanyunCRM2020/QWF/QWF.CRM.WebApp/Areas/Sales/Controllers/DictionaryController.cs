using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QWF.Framework.ExtendUtils;

namespace QWF.CRM.WebApp.Areas.Sales.Controllers
{
    public class DictionaryController : Controller
    {
        // GET: Sales/Dictionary
        public ActionResult GetTreeByCode()
        {
            var code = Request["code"].SafeConvert().ToStr();
            using (var db = DbAccess.DbCRMContext.Create())
            {
                var rootId = db.T_QCRM_Dictionary.Where(w => w.Code == code).Select(s => s.Id).FirstOrDefault();
                if (rootId > 0)
                {
                    var ids = "," + rootId.ToString() + ",";

                    var rows = db.T_QCRM_Dictionary.AsNoTracking().Where(w => w.IdList.IndexOf(ids) > -1).OrderBy(o => o.ItemSort).ToList();
                    var tree = new QWF.Framework.Web.UI.TreeConverter<DbAccess.T_QCRM_Dictionary>();

                    tree.ClosedLayer = 3;//这里要全部展开。否则是会异步加载
                    tree.GetId = m => { return m.Id.ToString(); };
                    tree.GetParentId = m => { return m.ParentId.ToString(); };

                    //映射字段
                    var treeList = tree.ConvertTo(item =>
                    {
                        var node = new QWF.Framework.Web.UI.BaseTreeNode();
                        node.id = item.Id.ToString();
                        node.text = item.ItemName;
                        return node;
                    }, rows, "0");
                    return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(treeList));
                }

            }

            return this.Content(string.Empty);
        }

        public ActionResult GetItemByCode()
        {
            var code = Request["code"].SafeConvert().ToStr();
            using (var db = DbAccess.DbCRMContext.Create())
            {
                var rootId = db.T_QCRM_Dictionary.AsNoTracking().Where(w => w.Code == code).Select(s => s.Id).FirstOrDefault();
                if (rootId > 0)
                {
                    var items = db.T_QCRM_Dictionary.Where(w => w.ParentId == rootId).OrderBy(o => o.ItemSort).
                                Select(s => new
                                {
                                    Name = s.ItemName,
                                    Value = s.ItemValue
                                }).ToList();

                    return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(items));
                }
            }

            return this.Content(string.Empty);
        }
        
        public ActionResult GetViewItemByCode()
        {
            var code = Request["code"].SafeConvert().ToStr();
            var rows = new List<Models.UI_DictionaryKeyInValue>();
            var typeCode = Request["typeCode"].SafeConvert().ToStr();

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var viewName = db.T_QCRM_Dictionary.Where(w => w.Code == code).FirstOrDefault().ViewName;
                string sql = "select DicName,DicValue from " + viewName;

                if (typeCode.Length > 0)
                    sql += string.Format(" where TypeCode='{0}'", typeCode);
                    
                rows = db.Database.SqlQuery<Models.UI_DictionaryKeyInValue>(sql).ToList();

            }

            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(rows));
        }

    }
}