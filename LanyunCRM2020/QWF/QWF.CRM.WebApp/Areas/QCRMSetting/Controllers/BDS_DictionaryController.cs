using QWF.Framework.ExtendUtils;
using QWF.Framework.GlobalException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QWF.CRM.WebApp.Areas.QCRMSetting.Controllers
{
    public class BDS_DictionaryController : Controller
    {
        // GET: QCRMSetting/BDS_Dictionary
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList()
        {

            var name = this.Request["qryName"].SafeConvert().ToStr();

            int pageSize = this.Request["rows"].SafeConvert().ToInt32(30);
            int pageIndex = this.Request["page"].SafeConvert().ToInt32(1);
            var pageSort = this.Request["sort"].SafeConvert().ToStr("CreateTime"); //排序字段 
            var pageOrderby = this.Request["orderby"].SafeConvert().ToStr("desc");// 升序或降序

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var qry = db.T_QCRM_Dictionary.Where(w => w.ParentId == 0 && w.DictionaryType == 0);

                //排序
                qry = QWF.Framework.Dynamic.QueryableHelper.DataSorting(qry, pageSort, pageOrderby);
                //过滤
                if (name.Length > 0)
                {
                    qry = qry.Where(w => w.ItemName.Contains(name));
                }
                var total = qry.Count();
                qry = QWF.Framework.Dynamic.QueryableHelper.DataPaging(qry, pageIndex, pageSize);
                var rows = qry.ToList().Select(s => new
                {
                    s.Id,
                    s.Code,
                    s.DataSource,
                    DataSourceName = s.DataSource == 1 ? "√" : "",
                    s.Remarks,
                    s.ViewName,
                    Name = s.ItemName,
                    CreateTime = s.CreateTime.SafeConvert().ToTimeStrDefault(),
                    UpdateTime = s.UpdateTime.SafeConvert().ToTimeStrDefault()
                });

                var result = new { total = total, rows = rows };
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));

            }
        }

        public ActionResult Save()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            var name = this.Request["name"].SafeConvert().ToStr();
            var id = this.Request["id"].SafeConvert().ToInt32(0);
            var dataSoruce = this.Request["dataSource"].SafeConvert().ToBool();
            var viewName = this.Request["viewName"].SafeConvert().ToStr();
            var remarks = Request["remarks"].SafeConvert().ToStr();

            if (name.Length == 0)
                throw new UIValidateException("请填写字典的分类名称。");

            using (var db = DbAccess.DbCRMContext.Create())
            {
                if (id == 0)
                {
                    var itemCount = db.T_QCRM_Dictionary.Where(w => w.ItemName == name && w.ParentId == 0).Count();
                    if (itemCount > 0)
                        throw new UIValidateException("字典的分类名称【{0}】已存在，请更换一个分类名称。", name);

                    //
                    var dbModel = new DbAccess.T_QCRM_Dictionary();
                    if (dataSoruce)
                    {
                        dbModel.DataSource = 1;
                        if (viewName.Length == 0)
                            throw new UIValidateException("动态数据下的视图不能空填。");

                        dbModel.ViewName = viewName;

                    }
                    dbModel.ItemName = name;
                    dbModel.CreateTime = DateTime.Now;
                    dbModel.CreateUser = curUser.CurrentUserCode;
                    dbModel.ItemSort = 0;
                    dbModel.Code = QWF.Framework.MainServices.CreateWebAppServices.GetSeqServices().CreateNewSeqNo("crm.dictionary.code").Replace("-", "");
                    dbModel.Remarks = remarks;

                    db.T_QCRM_Dictionary.Add(dbModel);
                    //创建视图
                    ADO.ADO_Helper.Create().CreateDictionaryView(dbModel.Code);

                    //写入数据表

                    var tableModel = new DbAccess.T_QCRM_Tables();
                    tableModel.Name = "数据字典_" + dbModel.ItemName;
                    tableModel.Code = "v_" + dbModel.Code;
                    tableModel.CreateTime = DateTime.Now;
                    tableModel.CreateUser = curUser.CurrentUserCode;
                    db.T_QCRM_Tables.Add(tableModel);

                    var fieldModel_Name = new DbAccess.T_QCRM_Fields();
                    fieldModel_Name.TableCode = tableModel.Code;
                    fieldModel_Name.Code = "ItemName";
                    fieldModel_Name.FieldType = "text";
                    fieldModel_Name.FieldTypeLength = 50;
                    fieldModel_Name.Name = dbModel.ItemName + "名称";
                    fieldModel_Name.CreateTime = DateTime.Now;
                    fieldModel_Name.CreateUser = curUser.CurrentUserCode;
                    db.T_QCRM_Fields.Add(fieldModel_Name);

                }
                else
                {
                    if (db.T_QCRM_Dictionary.Where(w => w.ItemName == name && w.ParentId == 0 && w.Id != id).Count() > 0)
                        throw new UIValidateException("字典的分类名称【{0}】已存在，请更换一个分类名称。", name);

                    var dbModel = db.T_QCRM_Dictionary.Where(w => w.Id == id).FirstOrDefault();
                    if (dbModel == null)
                        throw new UIValidateException(string.Format("字典分类数据不存在，不能编辑ID={0}。", id));

                    dbModel.ItemName = name;
                    dbModel.UpdateTime = DateTime.Now;
                    dbModel.UpdateUser = curUser.CurrentUserCode;
                    if (dataSoruce)
                    {
                        dbModel.DataSource = 1;
                        if (viewName.Length == 0)
                            throw new UIValidateException("动态数据下的视图不能空填。");
                        dbModel.ViewName = viewName;

                    }
                    else
                    {
                        dbModel.DataSource = 0;
                        dbModel.ViewName = string.Empty;

                    }

                    //更新数据表
                    var tableModel = db.T_QCRM_Tables.Where(w => w.Code == "v_" + dbModel.Code).FirstOrDefault();
                    if (tableModel != null)
                    {
                        tableModel.Name = "数据字典_" + dbModel.ItemName;
                        tableModel.UpdateTime = DateTime.Now;
                        tableModel.UpdateUser = curUser.CurrentUserCode;
                    }

                }


                db.SaveChanges();
            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));

        }

        public ActionResult Delete()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();

            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            var id = this.Request["Id"].SafeConvert().ToInt32(0);

            using (var db = DbAccess.DbCRMContext.Create())
            {
                if (db.T_QCRM_Dictionary.Where(w => w.ParentId == id).Count() > 0)
                    throw new UIValidateException("该记录存在子项数据，请先删除子项数据。");


               

                var dbModel = db.T_QCRM_Dictionary.Where(w => w.Id == id).FirstOrDefault();
                if (dbModel != null)
                {
                    if( dbModel.ParentId ==0)
                    {
                        if (db.T_QCRM_Tables.Where(w => w.Code == "v_" + dbModel.Code && w.Deleted == 0).Count() > 0)
                            throw new UIValidateException("该记录已经关联数据表，请在“数据表管理”中先删除【{0}】的数据。", "数据字典_" + dbModel.ItemName);

                    }

                    db.T_QCRM_Dictionary.Remove(dbModel);
                }
                   

                //记录删除记录

                //写入操作日志
                QWF.Framework.MainServices.CreateWebAppServices.GetUserActionLogServices().
                    WriterActionLog("普通字典数据管理删除", Framework.Services.SvrModels.SverUserActionLogType.Delete, null, new { 父ID = dbModel.ParentId, 字典名称 = dbModel.ItemName, 字段值 = dbModel.ItemValue });


                db.SaveChanges();
            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        public ActionResult GetInputItemList()
        {
            var parentId = this.Request["parentId"].SafeConvert().ToInt32(0);

            int pageSize = this.Request["rows"].SafeConvert().ToInt32(30);
            int pageIndex = this.Request["page"].SafeConvert().ToInt32(1);
            var pageSort = this.Request["sort"].SafeConvert().ToStr("ItemSort"); //排序字段 
            var pageOrderby = this.Request["orderby"].SafeConvert().ToStr("asc");// 升序或降序

            if (parentId == 0)
                throw new UIValidateException("请选择字典分类");

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var qry = db.T_QCRM_Dictionary.Where(w => w.ParentId == parentId);

                //排序
                qry = QWF.Framework.Dynamic.QueryableHelper.DataSorting(qry, pageSort, pageOrderby);
                var total = qry.Count();
                qry = QWF.Framework.Dynamic.QueryableHelper.DataPaging(qry, pageIndex, pageSize);

                // 获取字典
                var rows = qry.ToList().Select(s => new
                {
                    s.Id,
                    s.ItemName,
                    s.ItemValue,
                    s.ItemSort,
                    s.ItemValueType,
                    s.Hide,
                    s.ParentId,
                    ItemValueTypeName = s.ItemValueType == 1 ? "系统生成" : "自定义",
                    HideName = s.Hide == 1 ? "√" : "",
                    CreateTime = s.CreateTime.SafeConvert().ToTimeStrDefault(),
                    UpdateTime = s.UpdateTime.SafeConvert().ToTimeStrDefault(),
                });
                var result = new { total = total, rows = rows };
                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));

            }
        }

        public ActionResult SaveInputItem()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();

            var parentId = this.Request["parentId"].SafeConvert().ToInt32(0);
            var itemId = this.Request["itemId"].SafeConvert().ToInt32(0);
            var formInputId = this.Request["formInputId"].SafeConvert().ToInt32(0);
            var itemName = this.Request["itemName"].SafeConvert().ToStr();
            var itemValue = this.Request["itemValue"].SafeConvert().ToStr();
            var systemVaule = this.Request["systemVaule"].SafeConvert().ToBool();

            using (var db = DbAccess.DbCRMContext.Create())
            {
                //同一个分类不能有相同的值

                if (itemId == 0)
                {
                    var dbModel = new DbAccess.T_QCRM_Dictionary();
                    if (systemVaule)
                        itemValue = QWF.Framework.MainServices.CreateWebAppServices.GetSeqServices().CreateNewSeqNo("crm.inputitem.value").Replace("-", "");


                    if (db.T_QCRM_Dictionary.Where(w => w.ParentId == parentId && w.ItemValue == itemValue).Count() > 0)
                        throw new UIValidateException("子项的值已经存在 【{0}】，不能添加！", itemValue);

                    var itemCount = db.T_QCRM_Dictionary.Where(w => w.ParentId == parentId).Count();

                    dbModel.ParentId = parentId;
                    dbModel.ItemValueType = systemVaule ? 1 : 0;
                    dbModel.ItemValue = itemValue;
                    dbModel.ItemName = itemName;
                    dbModel.ItemSort = itemCount + 1;

                    dbModel.Hide = 0;
                    dbModel.CreateTime = DateTime.Now;
                    dbModel.CreateUser = curUser.CurrentUserCode;

                    db.T_QCRM_Dictionary.Add(dbModel);

                    //写入字段表


                }
                else
                {

                    var dbModel = db.T_QCRM_Dictionary.Where(w => w.Id == itemId).FirstOrDefault();
                    if (dbModel == null)
                        throw new UIValidateException("数据字典子项数据不存在 ID=【{0}】", itemId);

                    if (dbModel.ItemValueType == 0)
                    {
                        if (db.T_QCRM_Dictionary.Where(w => w.ParentId == parentId && w.ItemValue == itemValue && w.Id != itemId).Count() > 0)
                            throw new UIValidateException("子项的值已经存在 【{0}】，不能添加！", itemValue);

                        dbModel.ItemValue = itemValue;
                    }

                    dbModel.ItemName = itemName;
                    dbModel.UpdateTime = DateTime.Now;
                    dbModel.UpdateUser = curUser.CurrentUserCode;

                }
                db.SaveChanges();
            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));

        }

        public ActionResult OrderIntpuItem()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();

            var id = this.Request["id"].SafeConvert().ToInt32(0);
            var type = this.Request["type"].SafeConvert().ToStr();

            if (id == 0)
                throw new UIValidateException("ID=0");

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var dbModel = db.T_QCRM_Dictionary.Where(w => w.Id == id).FirstOrDefault();
                if (dbModel == null)
                    throw new UIValidateException("记录不存在ID=【{0}】", id);

                switch (type)
                {
                    case "show":
                        dbModel.Hide = 0;
                        break;
                    case "hide":
                        dbModel.Hide = 1;
                        break;
                }

                dbModel.UpdateTime = DateTime.Now;
                dbModel.UpdateUser = curUser.CurrentUserCode;

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

            var formData = Request["id"].SafeConvert().ToInt32(0);

            //排序
            using (var db = DbAccess.DbCRMContext.Create())
            {
                foreach (var d in dic)
                {
                    var dbModel = db.T_QCRM_Dictionary.Where(w => w.Id == d.Key).FirstOrDefault();
                    if (dbModel != null)
                    {
                        dbModel.ItemSort = d.Value;
                        dbModel.UpdateTime = DateTime.Now;
                        dbModel.UpdateUser = curUser.CurrentUserCode;
                    }

                }
                db.SaveChanges();
            }


            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        #region 树形字典
        public ActionResult TreeIndex()
        {
            return View();
        }

        public ActionResult GetDictionaryTree()
        {
            using (var db = DbAccess.DbCRMContext.Create())
            {
                var rows = db.T_QCRM_Dictionary.AsNoTracking().Where(w => w.DictionaryType == 1).OrderBy(o => o.ItemSort).ToList();

                var tree = new QWF.Framework.Web.UI.TreeConverter<DbAccess.T_QCRM_Dictionary>();

                tree.ClosedLayer = 2;//这里要全部展开。否则是会异步加载

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

        public ActionResult GetTreeGridList()
        {
            using (var db = DbAccess.DbCRMContext.Create())
            {
                //获取全部数据
                var items = db.T_QCRM_Dictionary.AsNoTracking().Where(w => w.DictionaryType == 1).OrderBy(o => o.ItemSort).ToList();

                var tree = new QWF.Framework.Web.UI.TreeConverter<DbAccess.T_QCRM_Dictionary>();

                tree.GetId = m => { return m.Id.ToString(); };
                tree.GetParentId = m => { return m.ParentId.ToString(); };

                var result = tree.ConvertTo(item =>
                {
                    var node = new Models.DictionaryTreeGrid();
                    node.id = item.Id.ToString();
                    node.Code = item.Code;
                    node.Name = item.ItemName;
                    node.ParentId = item.ParentId;
                    node.IsParent = item.ParentId == 0 ? "√" : "";
                    node.ItemValue = item.ItemValue;
                    node.ItemValueType = item.ItemValueType;
                    node.ItemValueTypeName = item.ItemValueType == 1 ? "自定义" : "系统生成";
                    node.ItemSort = item.ItemSort;
                    node.CreateTime = item.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
                    node.UpdateTime = item.UpdateTime == null ? string.Empty : item.UpdateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    return node;
                }, items, "0");

                return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
            }



        }

        public ActionResult SaveTree()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();

            var id = Request["id"].SafeConvert().ToInt32(0);
            var name = Request["name"].SafeConvert().ToStr();
            var isParent = Request["isTopNode"].SafeConvert().ToBool();
            var parentId = this.Request["parentId"].SafeConvert().ToInt32(0);
            var oldParentId = this.Request["oldParentId"].SafeConvert().ToInt32();
            var itemValue = this.Request["itemValue"].SafeConvert().ToStr();
            var systemVaule = this.Request["systemVaule"].SafeConvert().ToBool();

            if (id == 0)
            {
                //新增
                #region add 
                using (var db = DbAccess.DbCRMContext.Create())
                {
                    if (db.T_QCRM_Dictionary.Where(w => w.ParentId == parentId && w.ItemName == name).Count() > 0)
                        throw new UIValidateException("名称【{0}】已经存在！请更换", name);

                    var dbModel = new DbAccess.T_QCRM_Dictionary();

                    dbModel.DictionaryType = 1;
                    dbModel.ItemName = name;
                    dbModel.ParentId = parentId;
                    dbModel.CreateTime = DateTime.Now;
                    dbModel.CreateUser = curUser.CurrentUserCode;

                    string idList = string.Empty;
                    if (isParent)
                    {     //顶级节点
                        dbModel.Code = QWF.Framework.MainServices.CreateWebAppServices.GetSeqServices().CreateNewSeqNo("crm.dictionary.code").Replace("-", "");
                        dbModel.LayerId = 1;
                        dbModel.ItemSort = 0;
                        idList = ",";
                    }
                    else
                    {
                        if (systemVaule)
                            itemValue = QWF.Framework.MainServices.CreateWebAppServices.GetSeqServices().CreateNewSeqNo("crm.inputitem.value").Replace("-", "");

                        dbModel.ItemValueType = systemVaule ? 1 : 0;
                        dbModel.ItemValue = itemValue;

                        //找到父节点信息
                        var dbParentNode = db.T_QCRM_Dictionary.Where(w => w.Id == parentId).FirstOrDefault();
                        if (dbParentNode == null)
                            throw new UIValidateException("上级节点信息获取失败");

                        //设置当前节点信息
                        dbModel.LayerId = dbParentNode.LayerId + 1;//层级+1
                        idList = dbParentNode.IdList;

                        var qrySort = db.T_QCRM_Dictionary.Where(w => w.ParentId == parentId);
                        if (qrySort.Count() == 0)
                        {
                            dbModel.ItemSort = 1;
                        }
                        else
                        {
                            //获取父接点下的子节点最大的SortId + 1
                            dbModel.ItemSort = qrySort.Max(m => m.ItemSort) + 1;

                        }

                        //更新父节点的IsSubNode
                        dbParentNode.IsSubNode = 1;

                    }

                    //这里要获取到自增ID，只能这样做了
                    db.T_QCRM_Dictionary.Add(dbModel);
                    db.SaveChanges();

                    //这里再修改idList;
                    dbModel.IdList = idList + dbModel.Id + ",";
                    //
                    //顶级字段创建视图
                    if (parentId == 0)
                    {
                        ADO.ADO_Helper.Create().CreateDictionaryTreeView(dbModel.Code, dbModel.Id.ToString());

                        //写入数据表
                        var tableModel = new DbAccess.T_QCRM_Tables();
                        tableModel.Name = "多级数据字典_" + dbModel.ItemName;
                        tableModel.Code = "v_tree_" + dbModel.Code;
                        tableModel.CreateTime = DateTime.Now;
                        tableModel.CreateUser = curUser.CurrentUserCode;
                        db.T_QCRM_Tables.Add(tableModel);

                        var fieldModel_Name = new DbAccess.T_QCRM_Fields();
                        fieldModel_Name.TableCode = tableModel.Code;
                        fieldModel_Name.Code = "ItemName";
                        fieldModel_Name.FieldType = "text";
                        fieldModel_Name.FieldTypeLength = 50;
                        fieldModel_Name.Name = dbModel.ItemName + "名称";
                        fieldModel_Name.CreateTime = DateTime.Now;
                        fieldModel_Name.CreateUser = curUser.CurrentUserCode;
                        db.T_QCRM_Fields.Add(fieldModel_Name);

                        var fieldModel_NamePath = new DbAccess.T_QCRM_Fields();
                        fieldModel_NamePath.TableCode = tableModel.Code;
                        fieldModel_NamePath.Code = "ItemFullNamePath";
                        fieldModel_NamePath.FieldType = "text";
                        fieldModel_NamePath.FieldTypeLength = 2000;
                        fieldModel_NamePath.Name = dbModel.ItemName + "路径名称";
                        fieldModel_NamePath.CreateTime = DateTime.Now;
                        fieldModel_NamePath.CreateUser = curUser.CurrentUserCode;
                        db.T_QCRM_Fields.Add(fieldModel_NamePath);

                    }
                    db.SaveChanges();

                    //更新路径
                    UpdateDictionaryPath(db,dbModel.Id);
                }
                #endregion
            }
            else
            {
                #region edit
                using (var db = DbAccess.DbCRMContext.Create())
                {
                    var dbModel = db.T_QCRM_Dictionary.Where(w => w.Id == id && w.DictionaryType == 1).FirstOrDefault();
                    if (dbModel == null)
                        throw new UIValidateException("编辑数据出错:不存在ID={0}", id);

                    dbModel.ItemName = name;
                    if (dbModel.ItemValueType == 0)
                        dbModel.ItemValue = itemValue;


                    var oldIdList = dbModel.IdList;

                    if (parentId == id)
                        throw new UIValidateException("所属机构不能设置和当前机构一样");

                    if (oldParentId != parentId)//已经移动了节点
                    {
                        //相同一个节点下。父节点不能向子节点移动
                        var qryIsSubNode = db.T_QCRM_Dictionary.Where(w => w.Id == parentId).ToList().Where(w => w.IdList.Contains("," + id + ","));
                        if (qryIsSubNode != null && qryIsSubNode.Count() > 0)
                            throw new UIValidateException("上级节点不能向下级节点移动");

                        //原来的父节点
                        var oldParentNode = db.T_QCRM_Dictionary.Where(w => w.Id == oldParentId).FirstOrDefault();
                        if (oldParentNode == null && oldParentId != 0)
                            throw new UIValidateException(string.Format("old orgid ={0} 不存在", oldParentId));

                        var newParentNode = db.T_QCRM_Dictionary.Where(w => w.Id == parentId).FirstOrDefault();
                        if (newParentNode == null && parentId != 0)
                            throw new UIValidateException(string.Format("new orgid ={0} 不存在", parentId));

                        dbModel.ParentId = parentId;

                        //层级信息
                        if (parentId == 0)
                        {
                            dbModel.IdList = "," + dbModel.Id + ",";
                            dbModel.LayerId = 1;
                        }
                        else
                        {

                            dbModel.IdList = newParentNode.IdList + dbModel.Id + ",";
                            dbModel.LayerId = newParentNode.LayerId + 1;
                        }
                        dbModel.ItemSort = 0;


                        //更新 变更后当前节点子节点的 idlist
                        var subList = db.T_QCRM_Dictionary.ToList().Where(w => w.IdList != null && w.IdList.IndexOf("," + dbModel.Id + ",") > -1 && w.Id != dbModel.Id);
                        foreach (var sub in subList)
                        {
                            sub.IdList = sub.IdList.Replace(oldIdList, dbModel.IdList);
                            sub.LayerId = sub.IdList.StringHelper().SplitToArray(",", StringSplitOptions.RemoveEmptyEntries).Length;
                        }

                        //这里改变了层级关系，防止后面计算错，先更新到db 中
                        db.SaveChanges();

                        UpdateSubNodeFlag(db, id);
                        UpdateSubNodeFlag(db, parentId);
                        UpdateSubNodeFlag(db, oldParentId);

                        //更新路径
                    }
                    db.SaveChanges();

                    //更新路径
                    UpdateDictionaryPath(db, id);
                    UpdateDictionaryPath(db, parentId);
                    UpdateDictionaryPath(db, oldParentId);
                }
                #endregion

            }

            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        private void UpdateSubNodeFlag(DbAccess.DbCRMContext db, int orgId)
        {
            if (orgId > 0)
            {
                var node = db.T_QCRM_Dictionary.Where(w => w.Id == orgId).FirstOrDefault();
                var subCont = db.T_QCRM_Dictionary.Where(w => w.ParentId == orgId).Count();
                node.IsSubNode = subCont > 0 ? 1 : 0;
            }

        }

        public void UpdateDictionaryPath(DbAccess.DbCRMContext db,int dicId)
        {
            db.T_QCRM_Dictionary.Where(w=>w.DictionaryType==1).ToList().Where(w =>w.IdList.IndexOf("," + dicId.ToString() + ",") > -1).ToList().ForEach(dic =>
            {

                var dicIds = dic.IdList.StringHelper().SplitToArray(",", StringSplitOptions.RemoveEmptyEntries);
                var dicItems = db.T_QCRM_Dictionary.Select(s => new { s.Id, s.ItemName }).ToList().Where(w => dicIds.Contains(w.Id.ToString()));
                var itemNameFullPath = string.Empty;
                
                foreach (var item in dicItems)
                {
                
                    if (itemNameFullPath.Length > 0)
                        itemNameFullPath += ">";

                    itemNameFullPath += item.ItemName;
                }

                dic.ItemFullNamePath = itemNameFullPath;
            });

            db.SaveChanges();

        }

        public ActionResult DeleteTree()
        {
            var result = QWF.Framework.Web.ResultWebData.Default();
            var id = Request["id"].SafeConvert().ToInt32(0);

            using (var db = DbAccess.DbCRMContext.Create())
            {
                if (db.T_QCRM_Dictionary.Where(w => w.ParentId == id).Count() > 0)
                    throw new UIValidateException("当前分类下还有子项,请先删除子项数据。");

                var dbModel = db.T_QCRM_Dictionary.Where(w => w.Id == id).FirstOrDefault();
                if (dbModel != null)
                {
                    if (dbModel.ParentId == 0)
                    {
                        if (db.T_QCRM_Tables.Where(w => w.Code == "v_tree_" + dbModel.Code && w.Deleted == 0).Count() > 0)
                            throw new UIValidateException("该记录已经关联数据表，请在“数据表管理”中先删除【{0}】的数据。", "多级数据字典_" + dbModel.ItemName);

                    }

                    db.T_QCRM_Dictionary.Remove(dbModel);

                    QWF.Framework.MainServices.CreateWebAppServices.GetUserActionLogServices().
                       WriterActionLog("多级字典数据管理删除", Framework.Services.SvrModels.SverUserActionLogType.Delete, null, new { 父ID = dbModel.ParentId, 字典名称 = dbModel.ItemName, 字段值 = dbModel.ItemValue });

                }
                //
                db.SaveChanges();
            }
            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));

        }



        public ActionResult TreeSort()
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            string[] keys = QWF.Framework.Web.QWFRequest.GetFormAllKeys();
            foreach (string key in keys)
            {
                if (key.StartsWith("sortId_"))
                {
                    int sortId = Request[key].SafeConvert().ToInt32(-1);
                    int id = key.Substring(7).SafeConvert().ToInt32(-1);
                    if (sortId == -1 || id == 0)
                    {
                        throw new UIValidateException("排序数字请填写正确。");
                    }
                    dic.Add(id, sortId);
                }
            }

            //
            var result = QWF.Framework.Web.ResultWebData.Default();
            var formData = Request["id"].SafeConvert().ToInt32(0);

            //排序
            using (var db = DbAccess.DbCRMContext.Create())
            {
                foreach (var d in dic)
                {
                    var dbModel = db.T_QCRM_Dictionary.Where(w => w.Id == d.Key).FirstOrDefault();
                    if (dbModel != null)
                        dbModel.ItemSort = d.Value;

                }
                db.SaveChanges();
            }


            return this.Content(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }
        #endregion

    }
}