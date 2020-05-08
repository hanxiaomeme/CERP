using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QWF.Framework.ExtendUtils;
using QWF.Framework.GlobalException;

namespace QWF.CRM.WebApp.Areas.QCRMSetting.Controllers
{
    public class UserColumnSettingController : Controller
    {
        // GET: QCRMSetting/UserColumnSetting
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetColumnList()
        {
            var listType = Request["qryListType"].SafeConvert().ToStr();

            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            var result = QWF.Framework.Web.ResultWebData.Default();



            using (var db = DbAccess.DbCRMContext.Create())
            {
                SetDefaultSetting(db);

                var qry = from a in db.T_QCRM_UserQueryListSetting.AsNoTracking()
                          join b in db.T_QCRM_QueryList.AsNoTracking() on a.QueryListId equals b.Id
                          where a.UserCode == curUser.CurrentUserCode && b.ListType == listType && b.Hide == 0

                          orderby a.SortId
                          select new
                          {
                              a.Id,
                              b.TitleName,
                              a.SortId,
                              a.StyleWidth,
                              a.IsHide,
                              HideName = a.IsHide == 1 ? "√" : ""
                          };

                //if (qry.Count() == 0)
                //    throw new UIValidateException("当前用户没有任何列信息，请先点击【初始化字段】！");

                //var qry = from a in db.T_QCRM_QueryList.AsNoTracking().Where(w => w.ListType == listType && w.Hide == 0)
                //          join uql in db.T_QCRM_UserQueryListSetting.AsNoTracking().Where(w => w.UserCode == curUser.CurrentUserCode) on a.Id equals uql.QueryListId into bb
                //          from b in bb.DefaultIfEmpty()

                //          select new
                //          {
                //              a.Id,
                //              a.TitleName,
                //              a.SortId,
                //              a.StyleWidth,
                //              a.IsHide,
                //              HideName = a.IsHide == 1 ? "√" : ""
                //          };

                var obj = new { total = qry.Count(), rows = qry.ToList().OrderBy(o => o.IsHide).ToList() };
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
            }
        }

        public ActionResult GetListType()
        {

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var qry = db.T_QCRM_ListType.AsNoTracking().Where(w => w.IsHide == 0).Select(s => new
                {
                    s.ListType,
                    s.TypeName
                });
                var obj = new { total = qry.Count(), rows = qry.ToList() };
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
            }
        }

        private void SetDefaultSetting(DbAccess.DbCRMContext db)
        {
            //初始化配置
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            var result = QWF.Framework.Web.ResultWebData.Default();

            //用户已配置的字段
            var qryUser = db.T_QCRM_UserQueryListSetting.AsNoTracking().Where(w => w.UserCode == curUser.CurrentUserCode).Select(s => s.QueryListId).ToList();

            //遍历查找不存在数据,并插入默认值
            db.T_QCRM_QueryList.AsNoTracking().Where(w => !qryUser.Contains(w.Id)).ToList().ForEach(item =>
              {
                  var dbModel = new DbAccess.T_QCRM_UserQueryListSetting();

                  dbModel.QueryListId = item.Id;
                  dbModel.StyleWidth = item.StyleWidth;
                  dbModel.SortId = item.SortId;
                  dbModel.IsHide = item.Hide;
                  dbModel.UserCode = curUser.CurrentUserCode;
                  dbModel.CreateTime = DateTime.Now;
                  dbModel.CreateUser = curUser.CurrentUserCode;

                  db.T_QCRM_UserQueryListSetting.Add(dbModel);
              });
            db.SaveChanges();


        }

        public ActionResult Save()
        {
            //初始化配置
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            var result = QWF.Framework.Web.ResultWebData.Default();

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var widthDic = new Dictionary<int, int>();
                string[] keys = QWF.Framework.Web.QWFRequest.GetFormAllKeys();
                foreach (string key in keys)
                {
                    if (key.StartsWith("widthId_"))
                    {
                        int width = Request[key].SafeConvert().ToInt32(-1);
                        int id = key.Substring(8).SafeConvert().ToInt32(-1);
                        if (width == -1 || id == -1)
                        {
                            throw new UIValidateException("宽度数字请填写正确！");
                        }
                        widthDic.Add(id, width);
                    }
                }
                //排序
                var sortDic = QWF.Framework.Web.QWFRequest.GetSortDictionary();

                //更新数据
                var now = DateTime.Now;
                foreach (var dic in sortDic)
                {
                    var dbModel = db.T_QCRM_UserQueryListSetting.Where(w => w.Id == dic.Key).FirstOrDefault();

                    if (dbModel != null)
                    {

                        dbModel.StyleWidth = widthDic[dic.Key];
                        dbModel.SortId = dic.Value;

                        if (dbModel.IsHide == 1)
                            dbModel.SortId = 0;

                    }
                }

                db.SaveChanges();

                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
            }
        }

        public ActionResult SetShowHide()
        {
            //初始化配置
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            var result = QWF.Framework.Web.ResultWebData.Default();

            var ids = Request["ids"].SafeConvert().ToStr().StringHelper().SplitToArray();
            var type = Request["type"].SafeConvert().ToStr();

            if (type.Length == 0)
                throw new UIValidateException("请选择隐藏/显示的类型。");

            using (var db = DbAccess.DbCRMContext.Create())
            {
                foreach (var strId in ids)
                {
                    var id = strId.SafeConvert().ToInt32(0);
                    var dbModel = db.T_QCRM_UserQueryListSetting.Where(w => w.Id == id).FirstOrDefault();
                    if (dbModel != null)
                    {
                        dbModel.IsHide = type == "hide" ? 1 : 0;
                    }
                }
                db.SaveChanges();
            }
            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

    }
}