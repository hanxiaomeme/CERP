using QWF.Framework.ExtendUtils;
using QWF.Framework.GlobalException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QWF.CRM.WebApp.Areas.QCRMSetting.Controllers
{
    public class QueryCategoryController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetFieldList()
        {
            using (var db = DbAccess.DbCRMContext.Create())
            {
                var rows = (from a in db.T_QCRM_Fields
                            join tqq in db.T_QCRM_QueryList on new { TableCode = a.TableCode, FieldCode = a.Code } equals new { TableCode = tqq.TableCode, FieldCode = tqq.FieldCode }
                            into bb
                            from b in bb.DefaultIfEmpty()
                            where a.TableCode == "TB_Customer"
                            select new
                            {
                                Code = a.TableCode + "_" + a.Code,
                                Name = b == null ? a.Name : b.TitleName,
                                Type = a.FieldType,
                                IsUserField = b == null ? false : (b.IsUserField == 1 ? true : false)
                            }).ToList();



                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(rows));
            }

        }

        public ActionResult GetList()
        {
            using (var db = DbAccess.DbCRMContext.Create())
            {
                var items = (from a in db.T_QCRM_QueryCategory.AsNoTracking()
                             join qql in db.T_QCRM_QueryList.AsNoTracking() on a.SortField equals qql.TableCode + "_" + qql.FieldCode into bb
                             from b in bb.DefaultIfEmpty()
                             orderby a.SortId
                             select new Models.DB_QueryCategory
                             {
                                 Id = a.Id,
                                 ParentId = a.ParentId,
                                 Name = a.Name,
                                 Remarks = a.Remarks,
                                 CreateTime = a.CreateTime,
                                 UpdateTime = a.UpdateTime,
                                 AscOrDesc = a.AscOrDesc,
                                 SortField = a.SortField,
                                 TitleName = b.TitleName,
                                 AndOr = a.AndOr
                             }).ToList();

                var tree = new QWF.Framework.Web.UI.TreeConverter<Models.DB_QueryCategory>();

                tree.GetId = m => { return m.Id.ToString(); };
                tree.GetParentId = m => { return m.ParentId.ToString(); };

                var result = tree.ConvertTo(item =>
                {
                    var node = new Models.QueryCategoryTreeGrid();
                    node.id = item.Id.ToString();
                    node.ParentId = item.ParentId;
                    node.Name = item.Name;
                    node.Remarks = item.Remarks;
                    node.QueryCategoryId = item.Id;
                    node.CreateTime = item.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
                    node.UpdateTime = item.UpdateTime == null ? string.Empty : item.UpdateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    node.AscOrDesc = item.AscOrDesc;
                    node.SortField = item.SortField;
                    node.SortFieldName = string.Empty;
                    node.AndOr = item.AndOr;
                    node.AndOrName = item.ParentId == 0 ? "" : (item.AndOr == "and" ? "满足全部条件" : "满足其中之一");

                    if (!item.SortField.StrValidatorHelper().StrIsNullOrEmpty())
                    {
                        var filedName = item.TitleName;
                        var ascOrDesc = item.AscOrDesc == "desc" ? "降序" : "升序";
                        filedName = string.Format("{0} ({1})", filedName, ascOrDesc);

                        node.SortFieldName = filedName;
                    }

                    return node;
                }, items, "0");

                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
            }

        }

        public ActionResult GetBigCategoryList()
        {
            using (var db = DbAccess.DbCRMContext.Create())
            {
                var items = db.T_QCRM_QueryCategory.Where(w => w.ParentId == 0).Select(s => new { s.Id, s.Name }).ToList();

                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(items));
            }
        }

        public ActionResult GetSortFileds()
        {
            using (var db = DbAccess.DbCRMContext.Create())
            {
                //获取指定排序的ID
                var rows = db.T_QCRM_QueryList.Where(w => w.ListType == "customer_list" && w.Sortable == 1).Select(s => new
                {
                    Code = s.TableCode + "_" + s.FieldCode,
                    Name = s.TitleName
                }).ToList();
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(rows));
            }
        }

        public ActionResult Save()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            var id = this.Request["id"].SafeConvert().ToInt32(0);
            var name = this.Request["name"].SafeConvert().ToStr();
            var remarks = this.Request["remarks"].SafeConvert().ToStr();
            var isTopNode = Request["isTopNode"].SafeConvert().ToInt32(0);
            var parentId = Request["parentId"].SafeConvert().ToInt32(0);
            var sortField = Request["sortField"].SafeConvert().ToStr();
            var ascOrDesc = Request["ascOrDesc"].SafeConvert().ToStr("desc");
            var andOr = Request["andOr"].SafeConvert().ToStr("and");

            if (id == 0 && isTopNode == 0 && parentId == 0)
                throw new UIValidateException("请选择一个所属分类或勾选成大类。");

            if (name.Length == 0)
                throw new UIValidateException("分类名称不能为空填。");

            DbAccess.T_QCRM_QueryCategory dbModel = null;
            using (var db = DbAccess.DbCRMContext.Create())
            {
                if (id == 0)
                {
                    //新增

                    dbModel = new DbAccess.T_QCRM_QueryCategory();

                    var maxSortId = 0;
                    var qry = db.T_QCRM_QueryCategory.Where(w => w.ParentId == parentId);
                    if (qry.Count() > 0)
                        maxSortId = qry.Max(m => m.SortId);

                    dbModel.Name = name;
                    dbModel.Remarks = remarks;
                    dbModel.ParentId = isTopNode == 1 ? 0 : parentId;
                    dbModel.SortId = maxSortId + 1;
                    dbModel.ShareType = "all";
                    dbModel.CreateTime = DateTime.Now;
                    dbModel.CreateUser = curUser.CurrentUserCode;
                    dbModel.SortField = sortField;
                    dbModel.AscOrDesc = ascOrDesc;
                    dbModel.AndOr = andOr;

                    db.T_QCRM_QueryCategory.Add(dbModel);
                }

                else
                {
                    //编辑

                    dbModel = db.T_QCRM_QueryCategory.Where(w => w.Id == id).FirstOrDefault();
                    if (dbModel == null)
                        throw new UIValidateException("ID=【{0}】的分类不存在", id);

                    dbModel.Name = name;
                    dbModel.Remarks = remarks;
                    if (dbModel.ParentId > 0 && parentId > 0)
                    {
                        dbModel.ParentId = parentId;
                    }
                    dbModel.ShareType = "all";
                    dbModel.UpdateTime = DateTime.Now;
                    dbModel.UpdateUser = curUser.CurrentUserCode;
                    dbModel.SortField = sortField;
                    dbModel.AscOrDesc = ascOrDesc;
                    dbModel.AndOr = andOr;
                }

                db.SaveChanges();

                result.Data = new { Id = dbModel.Id, ParentId = dbModel.ParentId };
            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));


        }

        public ActionResult Delete()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();
            var id = Request["id"].SafeConvert().ToInt32(0);

            using (var db = DbAccess.DbCRMContext.Create())
            {
                if (db.T_QCRM_QueryCategory.Where(w => w.ParentId == id).Count() > 0)
                    throw new UIValidateException("当前分类下还有子类,请先删除子类。");

                var dbModel = db.T_QCRM_QueryCategory.Where(w => w.Id == id).FirstOrDefault();
                if (dbModel != null)
                {
                    //移除子项
                    db.T_QCRM_QueryWhere.Where(w => w.QueryCategoryId == id).ToList().ForEach(item =>
                    {
                        db.T_QCRM_QueryWhere.Remove(item);
                    });
                    //移除查询分类
                    db.T_QCRM_QueryCategory.Remove(dbModel);
                }
                //
                db.SaveChanges();
            }
            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        public ActionResult Sort()
        {
            var dic = QWF.Framework.Web.QWFRequest.GetSortDictionary();

            //
            var result = QWF.Framework.Web.ResultWebData.Default();
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();

            //排序
            using (var db = DbAccess.DbCRMContext.Create())
            {
                foreach (var d in dic)
                {
                    var dbModel = db.T_QCRM_QueryCategory.Where(w => w.Id == d.Key).FirstOrDefault();
                    if (dbModel != null)
                    {
                        dbModel.SortId = d.Value;
                    }
                }
                db.SaveChanges();
            }


            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        public ActionResult GetWhereListById()
        {
            var categoryId = this.Request["categoryId"].SafeConvert().ToInt32(0);

            int pageSize = this.Request["rows"].SafeConvert().ToInt32(30);
            int pageIndex = this.Request["page"].SafeConvert().ToInt32(1);
            var pageSort = this.Request["sort"].SafeConvert().ToStr("SortId"); //排序字段 
            var pageOrderby = this.Request["orderby"].SafeConvert().ToStr("asc");// 升序或降序

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var qry = from a in db.T_QCRM_QueryWhere.AsNoTracking()
                          join b in db.T_QCRM_Fields.AsNoTracking() on a.FieldCode equals b.TableCode + "_" + b.Code
                          join user in db.T_QWF_User.AsNoTracking().Where(w => w.IsDelete == 0) on a.UserCode equals user.UserCode into cc
                          from c in cc.DefaultIfEmpty()
                          where a.QueryCategoryId == categoryId
                          select new
                          {
                              a.Id,
                              a.QueryCategoryId,
                              a.FieldCode,
                              b.Name,
                              a.Expression,
                              a.FieldValue,
                              a.FieldValueType,
                              a.StaticDateValue,
                              a.DateType,
                              a.DateNum,
                              a.CreateTime,
                              a.UpdateTime,
                              a.FieldQueryType,
                              a.UserCode,
                              a.UserCodeType,
                              a.SortId,
                              c.Realname

                          };

                qry = QWF.Framework.Dynamic.QueryableHelper.DataSorting(qry, pageSort, pageOrderby);

                //分页
                var total = qry.Count();
                qry = QWF.Framework.Dynamic.QueryableHelper.DataPaging(qry, pageIndex, pageSize);
                var dateTypes = QWF.Framework.MainServices.CreateWebAppServices.GetConfigServices().GetNodeItemsByCode("qwf.qcrm.dateExpression");
                var fieldTypes = QWF.Framework.MainServices.CreateWebAppServices.GetConfigServices().GetNodeItemsByCode("qwf.qcrm.fieldtype");
                var expressions = QWF.Framework.MainServices.CreateWebAppServices.GetConfigServices().GetNodeItemsByCode("qwf.qcrm.expression");

                var dicationaryList = db.T_QCRM_Dictionary.AsNoTracking().Select(s => new QWF.Framework.Web.BaseItemKeyValue { Key = s.ItemValue, Value = s.ItemName }).ToList();
                var productList = db.T_QCRM_Product.AsNoTracking().Select(s => new QWF.Framework.Web.BaseItemKeyValue { Key = s.Code, Value = s.Name });

                var dicAndPordList = dicationaryList.Concat(productList).ToList();

                var rows = from a in qry.ToList()
                           join b in fieldTypes on a.FieldValueType equals b.Value
                           join exp in expressions on a.Expression equals exp.Value into ee 
                           from e in ee.DefaultIfEmpty()
                           join c in dateTypes on a.DateType.ToString() equals c.Value into cc
                            from d in cc.DefaultIfEmpty()
                           select new
                           {

                               a.Id,
                               a.QueryCategoryId,
                               FieldName = a.Name,
                               a.FieldCode,
                               a.Expression,
                               ExpressionName = e==null?"": e.Name,
                               a.FieldValue,
                               FieldValueName = ConvertDictionaryToName(dicAndPordList, a.FieldValueType, a.FieldValue),
                               a.FieldValueType,
                               FieldValueTypeName = b.Name,
                               a.StaticDateValue,
                               a.DateType,
                               DateTypeName = d == null ? "" : d.Name,
                               a.DateNum,
                               a.FieldQueryType,
                               a.UserCode,
                               a.UserCodeType,
                               UserRealname = a.Realname,
                               CreateTime = a.CreateTime.SafeConvert().ToTimeStrDefault(),
                               UpdateTime = a.UpdateTime.SafeConvert().ToTimeStrDefault()
                           };

                var result = new { total = total, rows = rows };

                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
            }

        }

        private string ConvertDictionaryToName(List<QWF.Framework.Web.BaseItemKeyValue> list, string fieldType, string fieldValue)
        {
            string result = string.Empty;

            if (fieldValue.Length > 0)
            {
                fieldValue.StringHelper().SplitToList().ForEach(val =>
                {
                    if (val.Trim().Length > 0)
                    {
                        var dic = list.Where(w => w.Key == val).FirstOrDefault();

                        if (result.Length > 0)
                            result += ",";

                        result += dic == null ? val : dic.Value;
                    }
                });
            }
            return result;
        }

        public ActionResult SaveWhereSetting()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            var fieldQueryType = QWF.CRM.Utils.FieldQueryType.QueryType_00;// 字段查询类型;

            var whereId = this.Request["whereId"].SafeConvert().ToInt32(0);
            var categoryId = this.Request["categoryId"].SafeConvert().ToInt32(0);

            var fieldCode = Request["fieldCode"].SafeConvert().ToStr();
            var expression = Request["expression"].SafeConvert().ToStr();
            var fieldValue = this.Request["fieldValue"].SafeConvert().ToStr();
            var fieldType = this.Request["fieldType"].SafeConvert().ToStr();
            var staticDateValue = Request["staticDate"].SafeConvert().ToStr();
            var dateNum = Request["dateNum"].SafeConvert().ToInt32(0);
            var dateType = Request["dateType"].SafeConvert().ToInt32(0);
            var userCode = Request["sysUserCode"].SafeConvert().ToStr();
            var isUserField = Request["isUserField"].SafeConvert().ToBool();
            var userCodeType = 0; //默认自己；

            if (categoryId == 0)
                throw new UIValidateException("查询分类ID不正确,ID=0。");

            if (fieldCode.Length == 0)
                throw new UIValidateException("请选择字段。");


            if (expression.Length == 0 && fieldType != "datetime" && !isUserField)
                throw new UIValidateException("请选择表达式。");

            if (fieldType == "datetime")
            {
                if(dateType<10 && staticDateValue.Length==0)
                {
                    throw new UIValidateException("请填写固定日期。");
                }

                if (dateType >= 50 && dateNum==0)
                {
                    throw new UIValidateException("请填写天数。");
                }

                fieldQueryType = QWF.CRM.Utils.FieldQueryType.QueryType_01;
            }
            else if (isUserField)
            {
                if (userCode.Length == 0)
                    throw new UIValidateException("请选择系统用户。");

                fieldQueryType = QWF.CRM.Utils.FieldQueryType.QueryType_02;
                userCodeType = (userCode == "myself") ? 1 : 2;
                expression = "=";
            }
            else
            {
                if (fieldValue.Length == 0)
                    throw new UIValidateException("请填写值。");
            }

            DbAccess.T_QCRM_QueryWhere dbModel = null;
            using (var db = DbAccess.DbCRMContext.Create())
            {
                if (whereId == 0)
                {
                    dbModel = new DbAccess.T_QCRM_QueryWhere();
                }
                else
                {
                    //编辑

                    dbModel = db.T_QCRM_QueryWhere.Where(w => w.Id == whereId).FirstOrDefault();
                    if (dbModel == null)
                        throw new UIValidateException("ID=【{0}】的记录不存在。", whereId);

                    dbModel.UpdateTime = DateTime.Now;
                    dbModel.UpdateUser = curUser.CurrentUserCode;
                }

                //公共参数
                dbModel.QueryCategoryId = categoryId;
                dbModel.FieldCode = fieldCode;
                dbModel.Expression = expression;
                dbModel.FieldValue = fieldValue;
                dbModel.FieldValueType = fieldType;
                dbModel.StaticDateValue = staticDateValue;
                dbModel.DateNum = dateNum;
                dbModel.DateType = dateType;
                dbModel.CreateTime = DateTime.Now;
                dbModel.CreateUser = curUser.CurrentUserCode;
                dbModel.FieldQueryType = fieldQueryType;
                dbModel.UserCodeType = userCodeType;
                dbModel.UserCode = userCode;

                if (whereId == 0)
                {
                    //新增
                    db.T_QCRM_QueryWhere.Add(dbModel);
                }


                db.SaveChanges();
            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        public ActionResult DeleteWhereSetting()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();
            var id = Request["id"].SafeConvert().ToInt32(0);

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var dbModel = db.T_QCRM_QueryWhere.Where(w => w.Id == id).FirstOrDefault();
                if (dbModel != null)
                {
                    db.T_QCRM_QueryWhere.Remove(dbModel);

                    db.SaveChanges();
                }
            }
            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        public ActionResult GetSysUserList()
        {
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var rows = db.T_QWF_User.Where(w => w.IsDelete == 0 && w.UserCode != curUser.CurrentUserCode).Select(s => new
                {
                    Value = s.UserCode,
                    Name = s.Realname
                }).ToList();

                rows.Insert(0, new { Value = "myself", Name = "自己" });


                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(rows));
            }
        }


        public ActionResult SaveWhereSort()
        {
            var dic = QWF.Framework.Web.QWFRequest.GetSortDictionary();

            //
            var result = QWF.Framework.Web.ResultWebData.Default();
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();

            //排序
            using (var db = DbAccess.DbCRMContext.Create())
            {
                foreach (var d in dic)
                {
                    var dbModel = db.T_QCRM_QueryWhere.Where(w => w.Id == d.Key).FirstOrDefault();
                    if (dbModel != null)
                    {
                        dbModel.SortId = d.Value;
                    }
                }
                db.SaveChanges();
            }
            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        #region  权限配置
        public ActionResult RoleInCategory()
        {
            return View();
        }


        public ActionResult GetRoleList()
        {
            using (var db = DbAccess.DbCRMContext.Create())
            {
                var qry = db.T_QWF_Role.Where(w => w.IsDelete == 0).Select(s => new
                {
                    s.RoleId,
                    s.RoleCode,
                    s.RoleName
                });

                var data = new { total = qry.Count(), rows = qry.ToList() };
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(data));
            }
        }

        public ActionResult GetRoleInCategoryList()
        {
            var roleCode = this.Request["roleCode"].SafeConvert().ToStr();

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var rows = (from a in db.T_QCRM_QueryCategory
                            join trc in db.T_QCRM_RoleInQueryCategory on new { RoleCode = roleCode, CategoryId = a.Id } equals new { RoleCode = trc.RoleCode, CategoryId = trc.CategoryId } into bb
                            from b in bb.DefaultIfEmpty()
                            orderby a.SortId
                            select new Models.RoleInQueryCategory
                            {
                                CategoryName = a.Name,
                                CategoryId = a.Id,
                                ParentId = a.ParentId,
                                RoleCode = b.RoleCode
                            }).ToList();

                var tree = new QWF.Framework.Web.UI.TreeConverter<Models.RoleInQueryCategory>();

                tree.GetId = m => { return m.CategoryId.ToString(); };
                tree.GetParentId = m => { return m.ParentId.ToString(); };
                tree.GetCheckbox = m => { return m.RoleCode != null && m.ParentId > 0 ? true : (bool?)null; };

                //映射字段
                var treeList = tree.ConvertTo(item =>
                {
                    var node = new QWF.Framework.Web.UI.BaseTreeNode();
                    node.id = item.CategoryId.ToString();
                    node.text = item.CategoryName;
                    return node;
                }, rows.ToList(), "0");
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(treeList));
            }
        }
        public ActionResult SaveRoleInCategory()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();

            var roleCode = Request["roleCode"].SafeConvert().ToStr();
            var categoryIds = Request["categoryIds"].SafeConvert().ToStr().StringHelper().SplitToList();

            using (var db = DbAccess.DbCRMContext.Create())
            {
                //幂等
                //清除不存在的categoryIds的集合
                db.T_QCRM_RoleInQueryCategory.Where(w => !categoryIds.Contains(w.CategoryId.ToString()) && w.RoleCode == roleCode).ToList().ForEach(item =>
                {
                    db.T_QCRM_RoleInQueryCategory.Remove(item);
                });

                //新增没有的
                categoryIds.ForEach(categoryId =>
                {
                    var id = categoryId.SafeConvert().ToInt32();
                    if (db.T_QCRM_RoleInQueryCategory.Where(w => w.CategoryId == id && w.RoleCode == roleCode).Count() == 0)
                    {
                        var dbModel = new DbAccess.T_QCRM_RoleInQueryCategory();
                        dbModel.RoleCode = roleCode;
                        dbModel.CategoryId = id;
                        dbModel.CreateTime = DateTime.Now;
                        dbModel.CreateUser = curUser.CurrentUserCode;

                        db.T_QCRM_RoleInQueryCategory.Add(dbModel);

                    }
                });

                db.SaveChanges();
            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));

        }
        #endregion


    }
}