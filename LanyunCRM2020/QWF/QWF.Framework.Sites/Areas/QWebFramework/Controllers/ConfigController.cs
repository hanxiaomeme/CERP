using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QWF.Framework.ExtendUtils;
using QWF.Framework.GlobalException;

namespace QWF.Framework.Sites.Areas.QWebFramework.Controllers
{
    public class ConfigController : Controller
    {
        // GET: QWebFramework/Config
        public ActionResult ConfigList()
        {
            return View();
        }

        //GET: /QWebFramework/Config/ConfigSort
        public ActionResult ConfigSort()
        {
            return View();
        }


        public ActionResult GetConfigTreeGrid()
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var rows = db.T_QWF_Config.AsNoTracking().Where(w => w.IsDelete == 0).OrderBy(o => o.SortId).ToList();

                var tree = new Web.UI.TreeConverter<DbAccess.T_QWF_Config>();

                tree.ClosedLayer = 2;//这里要全部展开。否则是会异步加载

                tree.GetId = m => { return m.ConfigId.ToString(); };
                tree.GetParentId = m => { return m.ParentId.ToString(); };

                //映射字段
                var treeList = tree.ConvertTo(item =>
                {
                    var node = new Models.ConfigTreeGrid();
                    node.id = item.ConfigId.ToString();
                    node.text = item.ConfigName;

                    node.ConfigId = item.ConfigId;
                    node.ConfigName = item.ConfigName;
                    node.ConfigCode = item.ConfigResourceCode;
                    node.ConfigValue = item.ConfigValue;
                    node.Remarks = item.ConfigRemarks;
                    node.ValueType = item.ConfigValueType;
                    node.CreateTime = item.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
                    node.UpdateTime = item.UpdateTime == null ? string.Empty : item.UpdateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");

                    return node;
                }, rows, "0");
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(treeList));
            }
        }

        public ActionResult GetConfigTree()
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var rows = db.T_QWF_Config.AsNoTracking().Where(w => w.IsDelete == 0).OrderBy(o => o.SortId).ToList();

                var tree = new Web.UI.TreeConverter<DbAccess.T_QWF_Config>();

                tree.ClosedLayer = 2;//这里要全部展开。否则是会异步加载

                tree.GetId = m => { return m.ConfigId.ToString(); };
                tree.GetParentId = m => { return m.ParentId.ToString(); };

                //映射字段
                var treeList = tree.ConvertTo(item =>
                {
                    var node = new Web.UI.BaseTreeNode();
                    node.id = item.ConfigId.ToString();

                    node.text = item.ConfigName;
                    return node;
                }, rows, "0");
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(treeList));
            }
        }

        public ActionResult GetConfigInfo()
        {
            var result = Web.ResultWebData.Default();

            var configId = Request["configId"].SafeConvert().ToInt32(0);
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var dbModel = db.T_QWF_Config.Where(w => w.IsDelete == 0 && w.ConfigId == configId).FirstOrDefault();
                if (dbModel == null)
                    throw new UIValidateException("找不到配置表信息ID=" + configId);

                var data = new
                {
                    ConfigId = dbModel.ConfigId,
                    ParentId = dbModel.ParentId,
                    ConfigName = dbModel.ConfigName,
                    ConfigValue = dbModel.ConfigValue,
                    ConfigResourceCode = dbModel.ConfigResourceCode,
                    ValueType = dbModel.ConfigValueType,
                    Remarks = dbModel.ConfigRemarks
                };

                result.Data = data;
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
            }
        }

        public ActionResult AddConfig()
        {
            var result = Web.ResultWebData.Default();

            var parentId = this.Request["parentId"].SafeConvert().ToInt32();
            var menuName = this.Request["configName"].SafeConvert().ToStr();

            int ConfigId = MainServices.CreateWebAppServices.GetConfigServices().AddConfig(parentId, menuName);
            result.Data = new { ConfigId = ConfigId };

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        public ActionResult EditConfig()
        {
            var result = Web.ResultWebData.Default();

            var svrModel = new Services.SvrModels.SvrConfigInfo();

            svrModel.ConfigId = this.Request["configId"].SafeConvert().ToInt32(0);
            svrModel.ConfigName = this.Request["configName"].SafeConvert().ToStr();
            svrModel.ConfigResourceCode = this.Request["configResourceCode"].SafeConvert().ToStr();
            svrModel.ConfigValue = this.Request["configValue"].SafeConvert().ToStr();
            svrModel.ConfigValueType = this.Request["valueType"].SafeConvert().ToStr();
            svrModel.ParentId = this.Request["parentId"].SafeConvert().ToInt32(0);
            svrModel.ConfigRemarks = this.Request["remarks"].SafeConvert().ToStr();

            int oldParentId = this.Request["oldParentId"].SafeConvert().ToInt32(0);
            MainServices.CreateWebAppServices.GetConfigServices().EditConfig(oldParentId, svrModel);

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));



        }

        public ActionResult DelConfig()
        {
            int configId = this.Request["configId"].SafeConvert().ToInt32(0);

            MainServices.CreateWebAppServices.GetConfigServices().DeleteConfig(configId);
            var result = Web.ResultWebData.Default();
            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));

        }

        public ActionResult HiddenConfig()
        {
            int configId = this.Request["configId"].SafeConvert().ToInt32(0);

            MainServices.CreateWebAppServices.GetConfigServices().HiddenConfig(configId);
            var result = Web.ResultWebData.Default();
            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));


        }

        public ActionResult ShowConfig()
        {
            int configId = this.Request["configId"].SafeConvert().ToInt32(0);

            MainServices.CreateWebAppServices.GetConfigServices().ShowConfig(configId);
            var result = Web.ResultWebData.Default();
            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));


        }

        public ActionResult ConfigTreeSort()
        {
            var dic = QWF.Framework.Web.QWFRequest.GetSortDictionary();

            var result = Web.ResultWebData.Default();
            //排序
            MainServices.CreateWebAppServices.GetConfigServices().ConfigTreeSort(dic);
            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }


    }
}