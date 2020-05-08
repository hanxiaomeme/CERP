using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QWF.Framework.ExtendUtils;
using QWF.Framework.GlobalException;
using System.Data.Common;

namespace QWF.CRM.WebApp.Areas.Sales.Controllers
{
    public class MainController : Controller
    {
        // GET: Sales/Main/Index
        public ActionResult Index()
        {
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            //获取用户当前角色集合
            var curUserRoleCode = curUser.GetRolesCodes();

            using (var db = QWF.CRM.DbAccess.DbCRMContext.Create())
            {
                var tableList = db.T_QCRM_ListType.AsNoTracking().Where(w => w.IsHide == 0).ToList();

                var filedList = (from a in db.T_QCRM_QueryList.AsNoTracking()
                                join uql in db.T_QCRM_UserQueryListSetting.AsNoTracking().Where(w => w.UserCode == curUser.CurrentUserCode) on a.Id equals uql.QueryListId into bb
                                from b in bb.DefaultIfEmpty()
                                select new Models.UI_UserField
                                {
                                    Id = a.Id,
                                    ListType = a.ListType,
                                    TableCode = a.TableCode,
                                    FieldCode = a.FieldCode,
                                    StyleCss = a.StyleCss,
                                    TitleName = a.TitleName,
                                    FieldFormatter = a.FieldFormatter,
                                    FormatterType = a.FormatterType,
                                    FieldType = a.FieldType,
                                    Checkbox = a.Checkbox,
                                    IsHide = b == null ? a.Hide : (b.IsHide == 1 || a.Hide == 1) ? 1 : 0, //
                                    StyleWidth = b == null ? a.StyleWidth : b.StyleWidth,
                                    SortId = b == null ? a.SortId : b.SortId
                                }).OrderBy(o=>o.SortId );

                //用户或角色对应的 form 权限,目前后台暂时只支持按角色对应权限。
                var userInFromCodes = db.T_QCRM_UserInForm.AsNoTracking().Where(w => (w.UserType == "role" && curUserRoleCode.Contains(w.TypeCode)
                                            || (w.UserType == "user" && w.TypeCode == curUser.CurrentUserCode))).Select(s => new { s.FormCode });

                var tempList = userInFromCodes.Select(s => s.FormCode).ToList();
                var formList = from a in db.T_QCRM_Form.AsNoTracking()
                               join b in db.T_QCRM_ListInForm.AsNoTracking() on a.Code equals b.FormCode
                               join c in userInFromCodes on a.Code equals c.FormCode
                               select new Models.UI_SalesMainForm
                               {
                                   ListType = b.ListType,
                                   Code = a.Code,
                                   Name = a.Name,
                                   ActionType = a.ActionType,
                                   ActionName = a.ActionName,
                                   ActionStyle = (Models.UI_SalesMainFormActionType)a.ActionStyle,
                                   StyleColums = a.StyleColums,
                                   WindowsWidth = a.WindowsWidth,
                                   ButtonIcon = a.ButtonIcon,
                                   ButtonStyle = a.ButtonStyle,
                                   ButtonSortId = b.SortId

                               };
                var formInputList = from a in db.T_QCRM_FormInput.AsNoTracking()
                                    join b in db.T_QCRM_Fields.AsNoTracking() on new { TableCode = a.TableCode, FiledCode = a.FieldCode } equals new { TableCode = b.TableCode, FiledCode = b.Code }
                                    where b.Deleted == 0
                                    select new Models.UI_Input
                                    {
                                        Id = a.Id,
                                        DefaultValue = a.DefaultValue,
                                        DictionaryCode = a.DictionaryCode,
                                        DefaultValueType = a.DefaultValueType,
                                        TableCode = a.TableCode,
                                        FieldCode = a.FieldCode,
                                        FormCode = a.FormCode,
                                        InputName = a.InputName,
                                        InputType = a.InputType,
                                        IsNotNull = b.IsNotNull,
                                        Name = a.Name,
                                        OnlyKey = b.OnlyKey,
                                        SelectItemValue = a.SelectItemValue,
                                        SortId = a.SortId,
                                        CssWidth = a.CssWidth,
                                        CssHeight = a.CssHeight,
                                        InputDesc = a.InputDesc
                                    };

                var inputItems = db.T_QCRM_Dictionary.AsNoTracking().Where(w => w.Hide == 0);

                var ui = new Models.UI_SalesMain();

                ui.TableList = tableList.ToList();  //显示列表
                ui.UserFields = filedList.ToList(); //显示的列表关联的字段
                ui.FormList = formList.ToList();  // 显示的表单集合
                ui.FormInputs = formInputList.ToList(); //显示表单元素
                ui.Dictionarys = inputItems.ToList(); // 显示表单元素字段的集合

                ui.CustomerListCode = QWF.Framework.Common.ConfigHelper.GetParameterValue("qwf.crm", "customer.main.list");
                ui.CustomerFormList = db.T_QCRM_ListInForm.AsNoTracking().Where(w => w.ListType == ui.CustomerListCode).Select(s => s.FormCode).ToArray();
                ui.SublevelCode = QWF.Framework.Common.ConfigHelper.GetParameterValue("qwf.crm", "customer.sublevel.list").StringHelper().SplitToArray(",", StringSplitOptions.RemoveEmptyEntries);
                ui.CustomerTabs = db.T_QCRM_Tabs.AsNoTracking().ToList(); //客户信息tabs
                //产品服务
                ui.Products = db.T_QCRM_Product.AsNoTracking().Where(w => w.IsHide == 0).OrderBy(o => o.SortId).Select(s => new Models.UI_Product
                {
                    Code = s.Code,
                    Name = s.Name,
                    ItemTitle = s.ItemTitle,
                    ServerType = s.ServerType


                }).ToList();
                //产品子项
                ui.ProductItem = db.T_QCRM_ProductItem.AsNoTracking().Where(w => w.IsHide == 0).Select(s => new Models.UI_ProductItem
                {
                    ItemId = s.Id,
                    ItemName = s.ItemName,
                    ProductCode = s.ProduceCode,
                    SortId = s.SortId.Value

                }).ToList();

                //排序字段
                var sortFileds = db.T_QCRM_QueryList.AsNoTracking().Where(w => w.Sortable == 1).Select(s => new QWF.Framework.Web.BaseItemKeyValue { Key = s.TableCode + "_" + s.FieldCode, Value = s.TitleName });
                ui.SortFields = sortFileds.ToList();
                return View(ui);
            }

        }

        public ActionResult GetQueryCategoryTree()
        {
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();

            var curRoleCode = curUser.GetRolesCodes();
            using (var db = QWF.CRM.DbAccess.DbCRMContext.Create())
            {
                //当前用户能查看的分类

                var qry = (from a in db.T_QCRM_QueryCategory.AsNoTracking().Where(w => w.ShareType == "all")
                           join b in db.T_QCRM_RoleInQueryCategory.AsNoTracking().Where(w => curRoleCode.Contains(w.RoleCode)).Select(s => new { s.CategoryId }).Distinct() on a.Id equals b.CategoryId
                           orderby a.SortId
                           select new
                           {
                               a.Id,
                               a.ParentId
                           }).ToList();

                var parnetIds = qry.Where(w => w.ParentId > 0).Select(s => s.ParentId).ToList();
                var ids = qry.Select(s => s.Id).ToList();
                var allIds = parnetIds.Concat(ids).ToList();

                var qryPublic = db.T_QCRM_QueryCategory.AsNoTracking().Where(w => allIds.Contains(w.Id) && w.ShareType == "all").OrderBy(o => o.SortId).ToList();
                //需要隐藏的配置
                var qryUserSetting = db.T_QCRM_UserQuerySetting.AsNoTracking().Where(w => w.IsHide == 1 && w.UserCode == curUser.CurrentUserCode)
                    .Select(s => s.QueryCategoryId).ToList();

                if (qryUserSetting.Count > 0)
                    qryPublic = qryPublic.Where(w => !qryUserSetting.Contains(w.Id)).ToList();

                var tree = new QWF.Framework.Web.UI.TreeConverter<DbAccess.T_QCRM_QueryCategory>();
                tree.GetId = m => { return m.Id.ToString(); };
                tree.GetParentId = m => { return m.ParentId.ToString(); };

                //映射字段
                var treeList = tree.ConvertTo(item =>
                {
                    var node = new QWF.Framework.Web.UI.BaseTreeNode();
                    node.id = item.Id.ToString();
                    node.text = item.Name;
                    node.attributes = new { parentId = item.ParentId };
                    return node;
                }, qryPublic, "0");

                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(treeList));
            }
        }

        public ActionResult GetDataList()
        {
            var qryListType = this.Request["qcrm_listtype"].SafeConvert().ToStr();
            var qryWhereId = this.Request["whereId"].SafeConvert().ToInt32(0);
            var pageIndex = this.Request["page"].SafeConvert().ToInt32(0);
            var pageSize = this.Request["rows"].SafeConvert().ToInt32(30);

            var qryUserCode = this.Request["qryUserCode"].SafeConvert().ToStr();



            using (var db = QWF.CRM.DbAccess.DbCRMContext.Create())
            {
                var qrySreachId = this.Request["qrySreachId"].SafeConvert().ToInt32(0);
                var qSreachText = this.Request["qSreachText"].SafeConvert().ToStr();
                var qrySreachBeginTime = this.Request["qrySreachBeginTime"].SafeConvert().ToDateTime(new DateTime(1900, 1, 1));
                var qrySreachEndTime = this.Request["qrySreachEndTime"].SafeConvert().ToDateTime(new DateTime(2099, 1, 1));
                var qSreachSelect = this.Request["qSreachSelect"].SafeConvert().ToStr();
                var qSreachSelectTree = this.Request["qSreachSelectTree"].SafeConvert().ToStr();
                var qrySortField = this.Request["qrySortField"].SafeConvert().ToStr();
                var qryAscOrDesc = this.Request["qryAscOrDesc"].SafeConvert().ToStr("desc");

                var isVague = this.Request["qryIsVague"].SafeConvert().ToBool();

                var paged = QWF.CRM.Utils.FormPagedUtils.Create(db);
                var query = paged.GetQuerySreachExpression(qrySreachId, qSreachText, qrySreachBeginTime, qrySreachEndTime, qSreachSelect, qSreachSelectTree, isVague);
                var orderBy = string.Empty;

                if (qryUserCode.Length > 0)
                {
                    qryUserCode = paged.ConverToWhereInStr(qryUserCode);
                    query.Add(string.Format(" and TB_Customer_CreateUser in ({0})", qryUserCode));
                }

                if (qrySortField.Length > 0)
                    orderBy = qrySortField + " " + qryAscOrDesc;


                //
                var total = 0;
                var rows = QWF.CRM.Utils.FormPagedUtils.Create(db).ListPaged(qryListType, pageIndex, ref total, qryWhereId, query, orderBy);
                var result = new { total = total, rows = rows };

                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
            }
        }

        public ActionResult GetTabList()
        {
            var qryListType = this.Request["qcrm_listtype"].SafeConvert().ToStr();
            var pageIndex = this.Request["page"].SafeConvert().ToInt32(0);
            var customerCode = this.Request["customerCode"].SafeConvert().ToStr();

            using (var db = QWF.CRM.DbAccess.DbCRMContext.Create())
            {
                var total = 0;
                var query = new List<string>();
                query.Add(string.Format(" and TB_Customer_CustomerCode = '{0}' ", customerCode));

                var rows = QWF.CRM.Utils.FormPagedUtils.Create(db).ListPaged(qryListType, pageIndex, ref total, 0, query);
                var result = new { total = total, rows = rows };

                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
            }
        }

        public ActionResult SaveForm()
        {
            //客户编码
            var customerCode = Request["customerCode"].SafeConvert().ToStr();
            var pkId = Request["__qcrm_pkval"].SafeConvert().ToStr();//PK值
            if (customerCode.Length == 0)
                throw new UIValidateException("客户编号为空，请检查客户端数据。");

            var httpContext = System.Web.HttpContext.Current;
            var result = QWF.Framework.Web.ResultWebData.Default();
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            var permission = QWF.CRM.Utils.PermissionUtils.Create();
            var formUtils = new QWF.CRM.Utils.FormUtils(httpContext);
            var plugIn = QWF.CRM.PlugIn.PlugInServices.GetInstance(formUtils.FormCode);

            if (formUtils.DbForm.ActionType == "update")
            {
                //设置安全参数
                formUtils.SafeDictionary.Add("CustomerCode", customerCode);
                if (!permission.IsUpdateCustomer(customerCode))
                {
                    var message = string.Format("权限错误(数据)：用户【{0}】对【{1}】无操作权限。", curUser.CurrentUserName, formUtils.DbForm.Name);
                    QWF.Framework.MainServices.CreateWebAppServices.GetUserActionLogServices().WriterActionLog("权限验证.修改数据", Framework.Services.SvrModels.SverUserActionLogType.Update, message, new { 客户编号 = customerCode });
                    throw new UIValidateException(message);
                }
            }
            if (plugIn != null)
                plugIn.OnBegin(httpContext, pkId, customerCode);
            try
            {

                if (formUtils.DbForm.ActionType == "update")
                {
                    //编辑保存
                    formUtils.SaveForm();
                }
                else
                {
                    pkId = formUtils.SaveForm<string>("Id");
                }
            }
            catch (Exception e)
            {
                if (plugIn != null)
                    plugIn.Fail(e);
                throw e;
            }
            //执行成功则实行插件。
            if (plugIn != null)
                plugIn.OnSuccess(httpContext, pkId, customerCode);

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        public ActionResult SaveCustomerForm()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            var customerCode = Request["customerCode"].SafeConvert().ToStr();
            var httpContext = System.Web.HttpContext.Current;
            var formUtils = new QWF.CRM.Utils.FormUtils(httpContext);
            var permissoin = new QWF.CRM.Utils.PermissionUtils(curUser);
            var plugIn = QWF.CRM.PlugIn.PlugInServices.GetInstance(formUtils.FormCode);

            try
            {
                if (formUtils.DbForm.ActionType == "update")
                {
                    if (customerCode.Length == 0)
                        throw new UIValidateException("客户编号为空请检查客户端数据。");

                    if (!permissoin.IsUpdateCustomer(customerCode))
                    {
                        var message = string.Format("权限错误(数据)：用户【{0}】对【{1}】无操作权限", curUser.CurrentUserName, formUtils.DbForm.Name);
                        QWF.Framework.MainServices.CreateWebAppServices.GetUserActionLogServices().WriterActionLog("权限验证.修改数据", Framework.Services.SvrModels.SverUserActionLogType.Update, message, new { 客户编号 = customerCode });
                        throw new UIValidateException(message);
                    }
                    //保存修改
                    if (plugIn != null)
                        plugIn.OnBegin(httpContext, customerCode, customerCode);

                    //安全过滤参数
                    formUtils.SafeDictionary.Add("CustomerCode", customerCode);
                    formUtils.SaveForm();
                }
                else if (formUtils.DbForm.ActionType == "create")
                {
                    if (plugIn != null)
                        plugIn.OnBegin(httpContext, customerCode, string.Empty);
                    //新增保存并返回表单的客户code
                    customerCode = formUtils.SaveForm<string>("CustomerCode").Replace("'", "");
                }
                //产品&服务
                var products = Request["product"].SafeConvert().ToStr().StringHelper().SplitToArray(",", StringSplitOptions.RemoveEmptyEntries);
                var productCodeList = new List<string>();
                products.ToList().ForEach(p =>
                {
                    var productCode = p.Split(new char[1] { '$' }, StringSplitOptions.RemoveEmptyEntries)[0];
                    if (productCode.Length > 0)
                        productCodeList.Add(productCode);
                });

                using (var db = DbAccess.DbCRMContext.Create())
                {
                    //清除不需要的产品，以勾选的服务为准
                    db.T_QCRM_CustomerProduct.Where(w => !productCodeList.Contains(w.ProductCode) && w.CustomerCode == customerCode).ToList().ForEach(item =>
                    {
                        var dbModel = db.T_QCRM_CustomerProduct.Where(w => w.Id == item.Id).FirstOrDefault();
                        db.T_QCRM_CustomerProduct.Remove(dbModel);
                    });

                    foreach (var item in products)
                    {
                        //服务时间：
                        var product = item.SafeConvert().ToStr().StringHelper().SplitToArray("$", StringSplitOptions.RemoveEmptyEntries);
                        var productCode = product[0];
                        var productName = product[1];

                        var beginDate = Request["svrBeginDate_" + productCode].SafeConvert().ToStr();
                        var endDate = Request["svrEndDate_" + productCode].SafeConvert().ToStr();
                        var productItemId = Request["productItem_" + productCode].SafeConvert().ToInt32();
                        var remark = Request["productRemarks_" + productCode].SafeConvert().ToStr();

                        if (beginDate.Length > 0 && endDate.Length == 0)
                            throw new UIValidateException("【{0}】请填写结束时间", productName);

                        if (beginDate.Length > 0 && endDate.Length > 0)
                        {
                            if (endDate.SafeConvert().ToDateTime() <= beginDate.SafeConvert().ToDateTime())
                                throw new UIValidateException("【{0}】结束时间必须大于开始时间", productName);
                        }
                        // 幂等操作产品服务
                        #region 幂等操作产品服务

                        DbAccess.T_QCRM_CustomerProduct dbModel = null;
                        dbModel = db.T_QCRM_CustomerProduct.Where(w => w.CustomerCode == customerCode && w.ProductCode == productCode).FirstOrDefault();
                        if (dbModel == null)
                        {
                            dbModel = new DbAccess.T_QCRM_CustomerProduct();

                            dbModel.ProductCode = productCode;
                            dbModel.CustomerCode = customerCode;
                            dbModel.ProductItemId = productItemId;
                            if (beginDate.Length > 0 && endDate.Length > 0)
                            {
                                dbModel.BeginTime = beginDate.SafeConvert().ToDateTime();
                                dbModel.EndTime = endDate.SafeConvert().ToDateTime();
                            }
                            dbModel.Remarks = remark;
                            dbModel.CreateTime = DateTime.Now;
                            dbModel.CreateUser = curUser.CurrentUserCode;

                            db.T_QCRM_CustomerProduct.Add(dbModel);
                        }
                        else
                        {
                            dbModel.ProductItemId = productItemId;
                            if (beginDate.Length > 0 && endDate.Length > 0)
                            {
                                dbModel.BeginTime = beginDate.SafeConvert().ToDateTime();
                                dbModel.EndTime = endDate.SafeConvert().ToDateTime();
                            }
                            dbModel.Remarks = remark;
                            dbModel.UpdateTime = DateTime.Now;
                            dbModel.UpdateUser = curUser.CurrentUserCode;
                        }

                        //
                        #endregion
                    }
                    //提交保存
                    db.SaveChanges();
                }
                //执行成功
                if (plugIn != null)
                    plugIn.OnSuccess(httpContext, customerCode, customerCode);
                //输出结果
                result.Data = new { Code = customerCode };
            }
            catch (Exception e)
            {
                if (plugIn != null)
                    plugIn.Fail(e);
                throw e;
            }


            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        public ActionResult DeleteCustomer()
        {
            var customerCode = Request["customerCode"].SafeConvert().ToStr();
            var pkId = Request["__qcrm_pkval"].SafeConvert().ToStr();

            if (customerCode.Length == 0)
                throw new UIValidateException("客户编号为空请检查客户端数据。");
            if (pkId.Length == 0)
                throw new UIValidateException("客户ID为空请检查客户端数据。");

            var result = QWF.Framework.Web.ResultWebData.Default();
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();

            var httpContext = System.Web.HttpContext.Current;
            var formUtils = new QWF.CRM.Utils.FormUtils(httpContext);
            var permissoin = new QWF.CRM.Utils.PermissionUtils(curUser);
            var plugIn = QWF.CRM.PlugIn.PlugInServices.GetInstance(formUtils.FormCode);

            if (!permissoin.IsDeleteCustomer(customerCode))
            {
                var message = string.Format("权限错误(数据)：用户【{0}】对【{1}】无操作权限", curUser.CurrentUserName, formUtils.DbForm.Name);
                QWF.Framework.MainServices.CreateWebAppServices.GetUserActionLogServices().WriterActionLog("权限验证.修改数据", Framework.Services.SvrModels.SverUserActionLogType.Update, message, new { 客户编号 = customerCode });
                throw new UIValidateException(message);
            }

            if (plugIn != null)
                plugIn.OnBegin(httpContext, pkId, customerCode);

            try
            {
                //逻辑删除
                formUtils.SafeDictionary.Add("CustomerCode", customerCode);
                formUtils.SaveForm();

                //写入日志
                QWF.Framework.MainServices.CreateWebAppServices.GetUserActionLogServices().WriterActionLog("删除客户", Framework.Services.SvrModels.SverUserActionLogType.Update, null, new { 客户编码 = customerCode });
            }
            catch (Exception e)
            {
                if (plugIn != null)
                    plugIn.Fail(e);
                throw e;
            }

            if (plugIn != null)
                plugIn.OnSuccess(httpContext, customerCode, customerCode);

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        public ActionResult GetFormInputListByCode()
        {
            var formCode = this.Request["formCode"].SafeConvert().ToStr();

            var result = QWF.Framework.Web.ResultWebData.Default();

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var pk = (from a in db.T_QCRM_Form.AsNoTracking()
                          join b in db.T_QCRM_Tables.AsNoTracking() on a.MainTable equals b.Code
                          join c in db.T_QCRM_Fields.AsNoTracking() on b.Code equals c.TableCode
                          where c.PK == 1 && b.Deleted == 0 && c.Deleted == 0 && a.Code == formCode
                          select new { PkName = c.TableCode + "_" + c.Code, c.Name }).ToList().FirstOrDefault();
                if (pk == null)
                    throw new UIValidateException("没有为表【{0}】设置主键。", formCode);

                var rows = db.T_QCRM_FormInput.AsNoTracking().Where(w => w.FormCode == formCode).ToList().Select(s => new
                {
                    RowFieldName = s.TableCode + "_" + s.FieldCode,
                    InputName = s.InputName + "_" + s.Id.ToString(),
                    s.InputType
                });

                result.Data = new { Rows = rows, PkName = pk.PkName };
            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        public ActionResult DeleteForm()
        {
            var customerCode = Request["customerCode"].SafeConvert().ToStr();
            var pkId = Request["__qcrm_pkval"].SafeConvert().ToStr();
            if (customerCode.Length == 0)
                throw new UIValidateException("客户编码为空,请检查客户端数据。");

            var result = QWF.Framework.Web.ResultWebData.Default();
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            var httpContext = System.Web.HttpContext.Current;
            var formUtils = new QWF.CRM.Utils.FormUtils(httpContext);
            var plugIn = QWF.CRM.PlugIn.PlugInServices.GetInstance(formUtils.FormCode);

            //权限验证

            if (!QWF.CRM.Utils.PermissionUtils.Create().IsDeleteCustomer(customerCode))
            {
                var message = string.Format("权限错误(数据)：用户【{0}】对【{1}】无操作权限。", curUser.CurrentUserName, formUtils.DbForm.Name);
                QWF.Framework.MainServices.CreateWebAppServices.GetUserActionLogServices().WriterActionLog("权限验证.修改数据", Framework.Services.SvrModels.SverUserActionLogType.Delete, message, new { 客户编号 = customerCode });
                throw new UIValidateException(message);
            }
            if (plugIn != null)
                plugIn.OnBegin(httpContext, pkId, customerCode);
            //删除表单数据
            try
            {
                formUtils.SafeDictionary.Add("CustomerCode", customerCode);
                formUtils.DeleteForm();
            }
            catch (Exception e)
            {
                if (plugIn != null)
                    plugIn.Fail(e);
                throw e;
            }

            if (plugIn != null)
                plugIn.OnSuccess(httpContext, pkId, customerCode);

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        public ActionResult GetProductListByCustomerCode()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();
            var code = Request["code"].SafeConvert().ToStr();
            using (var db = DbAccess.DbCRMContext.Create())
            {

                var qry = from a in db.T_QCRM_CustomerProduct
                          join b in db.T_QCRM_Product on a.ProductCode equals b.Code
                          where a.CustomerCode == code
                          select new
                          {
                              ProductName = b.Name,
                              a.ProductCode,
                              a.ProductItemId,
                              a.Remarks,
                              a.BeginTime,
                              a.EndTime
                          };

                var rows = qry.ToList().Select(s => new
                {
                    s.ProductCode,
                    s.ProductName,
                    s.ProductItemId,
                    s.Remarks,
                    BeginTime = s.BeginTime != null ? s.BeginTime.Value.ToString("yyyy-MM-dd") : "",
                    EndTime = s.EndTime != null ? s.EndTime.Value.ToString("yyyy-MM-dd") : "",
                });

                result.Data = new { rows = rows };
            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        public ActionResult GetQuickSreachItem()
        {
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var qry = from a in db.T_QCRM_QuickSreach
                          join b in db.T_QCRM_QuickSreachUser on a.Id equals b.SreachId
                          join dic in db.T_QCRM_Dictionary on a.DictionaryId equals dic.Id into cc
                          from c in cc.DefaultIfEmpty()
                          where b.UserCode == curUser.CurrentUserCode
                          orderby c.CreateTime
                          select new
                          {
                              Id = b.SreachId,
                              Name = a.SreachTitle,
                              a.SreachType,
                              a.DictionaryId,
                              DictionaryType = c == null ? -1 : c.DictionaryType,
                              DictionaryCode = c == null ? "" : c.Code
                          };

                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(qry.ToList()));
            }



        }


        public ActionResult ChangeCustomer()
        {
            var customerCodes = Request["customerCodes"].SafeConvert().ToStr();
            var pkId = Request["__qcrm_pkval"].SafeConvert().ToStr();
            if (customerCodes.Length == 0)
                throw new UIValidateException("客户编码为空,请检查客户端数据。");
            var changeToUserCode = Request["changToUserCode"].SafeConvert().ToStr();

            var result = QWF.Framework.Web.ResultWebData.Default();
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            var httpContext = System.Web.HttpContext.Current;
            var formUtils = new QWF.CRM.Utils.FormUtils(httpContext);
            var plugIn = QWF.CRM.PlugIn.PlugInServices.GetInstance(formUtils.FormCode);

            //权限验证

            if (!QWF.CRM.Utils.PermissionUtils.Create().IsChangCustomer())
            {
                var message = string.Format("权限错误(数据)：用户【{0}】对【{1}】无操作权限。", curUser.CurrentUserName, formUtils.DbForm.Name);
                QWF.Framework.MainServices.CreateWebAppServices.GetUserActionLogServices().WriterActionLog("权限验证.修改数据", Framework.Services.SvrModels.SverUserActionLogType.Delete, message, new { 客户编号 = customerCodes });
                throw new UIValidateException(message);
            }
            if (plugIn != null)
                plugIn.OnBegin(httpContext, pkId, customerCodes);

            if (plugIn != null)
            {
                var dicParams = new Dictionary<string, object>();
                dicParams.Add("ChangeToUserCode", changeToUserCode);
                plugIn.OnSuccess(httpContext, pkId, customerCodes, dicParams);
                //写入日志
                QWF.Framework.MainServices.CreateWebAppServices.GetUserActionLogServices().WriterActionLog("客户转移", Framework.Services.SvrModels.SverUserActionLogType.Update, null, new { 客户编码 = customerCodes, 转移给 = changeToUserCode });
            }


            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

    }
}