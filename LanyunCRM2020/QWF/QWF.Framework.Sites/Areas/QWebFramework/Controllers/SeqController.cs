using QWF.Framework.ExtendUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QWF.Framework.Sites.Areas.QWebFramework.Controllers
{
    public class SeqController : Controller
    {
        // GET: QWebFramework/Seq
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            #region 参数
            int pageSize = this.Request["rows"].SafeConvert().ToInt32(30);
            int pageIndex = this.Request["page"].SafeConvert().ToInt32(1);
            var pageSort = this.Request["sort"].SafeConvert().ToStr("Name"); //排序字段 
            var pageOrderby = this.Request["orderby"].SafeConvert().ToStr("asc");// 升序或降序

            var qrySeqName = Request["qrySeqName"].SafeConvert().ToStr();

            #endregion

            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var qry = db.T_QWF_Seq.AsNoTracking().AsQueryable();
                //排序
                qry = QWF.Framework.Dynamic.QueryableHelper.DataSorting(qry, pageSort, pageOrderby);
                //过滤
                if (qrySeqName.Length > 0)
                {
                    qry = qry.Where(w => w.Name.Contains(qrySeqName));
                }
                //分页
                var total = qry.Count();
                qry = QWF.Framework.Dynamic.QueryableHelper.DataPaging(qry, pageIndex, pageSize);

                var rows = qry.ToList();
                //输出
                var data = new { total = total, rows = rows };

                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(data));
            }

        }

        public ActionResult Save()
        {
            var id = this.Request["id"].SafeConvert().ToStr();

            var svrModel = new Services.SvrModels.SvrSeqInfo();
            svrModel.Code = this.Request["code"].SafeConvert().ToStr();
            svrModel.Name = this.Request["name"].SafeConvert().ToStr();
            svrModel.Prefix = this.Request["prefix"].SafeConvert().ToStr();
            svrModel.DateFormart = this.Request["dateFormart"].SafeConvert().ToStr();
            svrModel.SerialLength = this.Request["serialLength"].SafeConvert().ToInt32(0);
            //
            var services = MainServices.CreateWebAppServices.GetSeqServices();
            if(id.Length>0)
            {
                //编辑
                svrModel.Code = id;
                services.EditSeqSetting(svrModel);
            }
            else
            {
                //新增
                services.AddSeqSetting(svrModel);
            }
            var result = Web.ResultWebData.Default();

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        public ActionResult Delete()
        {
            var code = this.Request["code"].SafeConvert().ToStr();
            
            MainServices.CreateWebAppServices.GetSeqServices().DeleteSeqSetting(code);
            var result = Web.ResultWebData.Default();
            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }
    }
}