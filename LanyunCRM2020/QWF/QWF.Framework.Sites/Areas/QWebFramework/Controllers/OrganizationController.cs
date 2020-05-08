using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QWF.Framework.ExtendUtils;
using QWF.Framework.GlobalException;

namespace QWF.Framework.Sites.Areas.QWebFramework.Controllers
{
    public class OrganizationController : Controller
    {
        // GET: QWebFramework/Organization/OrganizationList
        public ActionResult OrganizationList()
        {
            return View();
        }

        public ActionResult List()
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                //获取全部机构数据
                var items = db.T_QWF_Org.AsNoTracking().Where(w => w.IsDelete == 0).OrderBy(o=>o.SortId).ThenBy(o=>o.OrgName).AsQueryable().ToList();

                var tree = new Web.UI.TreeConverter<DbAccess.T_QWF_Org>();

                tree.GetId = m => { return m.OrgId.ToString(); };
                tree.GetParentId = m => { return m.ParentId.ToString(); };

                var result = tree.ConvertTo(item => {
                    var node = new Models.OrganizactionTreeGrid();
                    node.id = item.OrgId.ToString();

                    node.OrgId = item.OrgId;
                    node.ParentId = item.ParentId;
                    node.OrgName = item.OrgName;
                    node.OrgCode = item.OrgCode;
                    node.IsOutName = item.IsOut==1 ? "外部" : "内部";
                    node.IsOut = item.IsOut==1?true:false;

                    node.Remarks = item.Remarks;
                    node.CreateTime = item.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
                    node.UpdateTime = item.UpdateTime == null ? string.Empty : item.UpdateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");

                    node.OrgAttribute = item.OrgAttribute;
                    node.OrgAttributeName = ((QWF.Framework.Services.SvrModels.SvrOrgInfo.OrgAttributeEnum)item.OrgAttribute).ToString();
                    return node;
                }, items, "0");

                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
            }



        }

        public ActionResult Save()
        {
            var result = Web.ResultWebData.Default();
            //业务参数
            var orgId = this.Request["orgId"].SafeConvert().ToInt32(0);
            var oldParentId = this.Request["oldParentId"].SafeConvert().ToInt32(0);
            var parentId = this.Request["parentId"].SafeConvert().ToInt32(0);
            var isTopNode = Request["isTopNode"].SafeConvert().ToInt32(0);
          
            var orgAttr = Request["orgAttr"].SafeConvert().ToInt32(0);
            var orgName = Request["orgName"].SafeConvert().ToStr();
            var isOut = Request["isOut"].SafeConvert().ToInt32(0) == 1 ? true : false;
            var remarks = Request["remarks"].SafeConvert().ToStr();

            if (isTopNode == 0 && parentId == 0)
                throw new UIValidateException("请选择一个所属机构或勾选顶级机构");
            if (orgAttr == 0)
                throw new UIValidateException("请选择一个机构属性");
            if(orgName.Length==0)
                throw new UIValidateException("机构名称不能为NULL");


            var svrModel = new Services.SvrModels.SvrOrgInfo();
            svrModel.OrgId = orgId;
            svrModel.ParentId = parentId;
            svrModel.OrgName = orgName;
            svrModel.OrgAttribute = (Services.SvrModels.SvrOrgInfo.OrgAttributeEnum)orgAttr;
            svrModel.ParentId = parentId;
            svrModel.IsOut = isOut ? 1 : 0;
            svrModel.Remarks = remarks;

            if (orgId ==0)
            {
                //新增
                MainServices.CreateWebAppServices.GetOrgServices().CreateOrg(svrModel);
            }
            else
            {
                //编辑
                MainServices.CreateWebAppServices.GetOrgServices().UpdateOrg(oldParentId, svrModel);
            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));


        }

        public ActionResult Delete()
        {
            var result = Web.ResultWebData.Default();
            var orgId = Request["id"].SafeConvert().ToInt32(0);

            //删除
            MainServices.CreateWebAppServices.GetOrgServices().DeleteOrg(orgId);

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        public ActionResult TreeSort()
        {
            var dic = QWF.Framework.Web.QWFRequest.GetSortDictionary();

            var result = Web.ResultWebData.Default();
            var formData = Request["id"].SafeConvert().ToInt32(0);

            //排序
            MainServices.CreateWebAppServices.GetOrgServices().TreeSort(dic);

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }
    }
}