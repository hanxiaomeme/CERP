using QWF.Framework.ExtendUtils;
using QWF.Framework.GlobalException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.CRM.Utils
{

    public class FormUtils
    {
        private QWF.Framework.Services.SvrModels.SvrShortUserInfo curUser;

        private System.Web.HttpContext httpContext;

        /// <summary>
        /// 安全字典，在做 删除和编辑操作，带上的参数，防止跨站攻击
        /// 例如：
        /// </summary>
        public Dictionary<object, string> SafeDictionary { get; set; }
        /// <summary>
        /// 表单代码
        /// </summary>
        public string FormCode { get; private set; }
        /// <summary>
        /// 表单对象
        /// </summary>
        public DbAccess.T_QCRM_Form DbForm { get ;  private set; }

        private string pkValue;
        /// <summary>
        /// 初始化 表单对象
        /// </summary>
        /// <param name="httpContext">httpContext 已经包含关键参数 formCode</param>
        public FormUtils(System.Web.HttpContext httpContext)
        {
            if (httpContext.Request["formCode"] == null)
                throw new UIValidateException("错误formCode不在请求中！");

            this.FormCode = httpContext.Request["formCode"].SafeConvert().ToStr();
            this.httpContext = httpContext;

            pkValue = httpContext.Request["__qcrm_pkval"].SafeConvert().ToStr();

            curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();

            SafeDictionary = new Dictionary<object, string>();
            Init();
        }

        private void Init ()
        {
            using (var db = DbAccess.DbCRMContext.Create())
            {
                this.DbForm = db.T_QCRM_Form.Where(w => w.Code == this.FormCode).FirstOrDefault();

                if(DbForm ==null)
                    throw new UIValidateException("表单信息不存在！Code=【{0}】", this.FormCode);
            }
        }
        /// <summary>
        /// 保存表单
        /// 关于权限说明：方法内部已做大颗粒度的权限判断。
        /// 1.需要配置角色对应表单的权限。方法内部判断是否
        /// 2.数据范围的权限，需要在调用用该方法前做由业务模块判断。
        /// </summary>
        public void SaveForm()
        {
            SaveForm<string>(null);
        }
        /// <summary>
        /// 保存表单
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resultPkName">新增保存，需要返回的自增ID或唯一ID的字段名称（目前不支持自增ID的返回）</param>
        /// <returns></returns>
        public T SaveForm<T>(string resultPkName)
        {
            T result = default(T);

            if (!this.IsOrderForm())
                throw new UIValidateException("保存表单错误：用户【{0}】对【{1}】无操作权限!",this.curUser.CurrentUserName,this.DbForm.Name);

            using (var db = QWF.CRM.DbAccess.DbCRMContext.Create())
            {
                var inputs = (from a in db.T_QCRM_FormInput.AsNoTracking()
                              join b in db.T_QCRM_Fields.AsNoTracking() on new { TableCode = a.TableCode, FieldCode = a.FieldCode } equals new { TableCode = b.TableCode, FieldCode = b.Code }
                              join c in db.T_QCRM_Tables.AsNoTracking() on b.TableCode equals c.Code
                              where a.FormCode == this.FormCode && b.Deleted == 0 && c.Deleted == 0 
                              select new
                              {
                                  a.FormCode,
                                  a.TableCode,
                                  a.FieldCode,
                                  a.InputType,
                                  a.InputName,
                                  a.DefaultValue,
                                  a.DefaultValueType,
                                  b.FieldType,
                                  b.IsNotNull,
                                  b.OnlyKey,
                                  b.PK,
                                  a.Name,
                                  c.DeleteType,
                                  c.DeleteField,
                                  c.DeleteFlag
                              }).ToList();

                #region 获取_并验证_参数

                Dictionary<string, string> fields = new Dictionary<string, string>();
                foreach (var input in inputs)
                {
                    var value = input.InputType == "system" ? GetSystemInputValue(input.DefaultValueType, input.DefaultValue, this.DbForm.ActionType) : httpContext.Request[input.InputName].SafeConvert().ToStr();

                    if (input.FieldType == "decimal" || input.FieldType == "int")
                    {
                        fields.Add(input.FieldCode, value);
                    }
                    else
                    {
                        fields.Add(input.FieldCode, "'" + value + "'");
                    }
                    //必填
                    if (input.IsNotNull == 1 && value.StrValidatorHelper().StrIsNullOrEmpty())
                        throw new UIValidateException("【{0}】为必填的数据，请重新填写或选择。", input.Name);

                    //唯一验证,值不为空并不是PK键
                    if(input.OnlyKey == 1 && !value.StrValidatorHelper().StrIsNullOrEmpty() && input.PK != 1 )
                    {
                        var checkSQL = string.Empty;

                        if(this.DbForm.ActionType == "create")
                        {
                            //新增
                            checkSQL = string.Format("SELECT COUNT(*) FROM {0} WHERE {1} = {2} ",
                                input.TableCode, input.FieldCode, fields[input.FieldCode]);
                        }
                        else if(this.DbForm.ActionType == "update")
                        {
                            //找到主键
                            var pk = db.T_QCRM_Fields.Where(w => w.TableCode == input.TableCode && w.PK == 1).FirstOrDefault();
                            if (pk == null)
                                throw new UIValidateException("表【{0}】没有配置主键。", input.TableCode);

                            if(pkValue.StrValidatorHelper().StrIsNullOrEmpty())
                                throw new UIValidateException("主键的值为空，请检查参数。");

                            string pkWhere = string.Empty;
                            if (pkValue.StrValidatorHelper().IsNumeric())
                            {
                                pkWhere = string.Format(" and {0}!= {1}", pk.Code, pkValue);
                            }
                            else
                            {
                                pkWhere = string.Format(" and {0}!= '{1}'", pk.Code, pkValue);
                            }

                                
                            checkSQL = string.Format("SELECT COUNT(*) FROM {0} WHERE {1} = {2} {3}",
                                input.TableCode, input.FieldCode, fields[input.FieldCode],pkWhere);
                        }

                        if(input.DeleteType == 1) //逻辑删除
                        {
                            var deleteFlag = input.DeleteFlag;
                            if(!deleteFlag.StrValidatorHelper().IsNumeric())
                            {
                                deleteFlag = "'" + deleteFlag + "'";
                            }
                            checkSQL += string.Format(" and {0} = {1}", input.DeleteField, deleteFlag);
                        }

                        var iCount = db.Database.SqlQuery<int>(checkSQL).First();
                        if (iCount > 0)
                            throw new UIValidateException("数据唯一性检查失败,内容有重复，<br/> 数据项:【{0}】</br> 内容: 【{1}】。", input.Name,value);

                    }

                }
                #endregion

                string sql = string.Empty;
                if (this.DbForm.ActionType == "create")
                {
                    string param = string.Empty;
                    string values = string.Empty;
                    foreach (var field in fields)
                    {
                        if (field.Value.Replace("'", "").Length > 0)
                        {
                            if (param.Length > 0)
                            {
                                param += ",";
                                values += ",";
                            }
                            param += field.Key;
                            values += field.Value;
                        }
                    }
                    sql = string.Format("insert into {0} ({1}) values ({2})", this.DbForm.MainTable, param, values);
                    if (resultPkName != null)
                        result = (T)(object)fields[resultPkName];

                }
                else if (this.DbForm.ActionType == "update")
                {
                    var pk = (from a in db.T_QCRM_Form
                              join b in db.T_QCRM_Tables on a.MainTable equals b.Code
                              join c in db.T_QCRM_Fields on b.Code equals c.TableCode
                              where c.PK == 1 && b.Deleted == 0 && c.Deleted == 0 && a.Code == this.FormCode
                              select new { c.Code, c.Name }).ToList().FirstOrDefault();
                    // 不从客户端出入PKname，安全考虑
                    if (pk == null)
                        throw new UIValidateException("没有配置主键!");
                    var pkName = pk.Code;
                    //update
                    string updateParams = string.Empty;
                    foreach (var field in fields)
                    {
                        //不能更新主键 
                        if (field.Key != pk.Code)
                        {
                            if (updateParams.Length > 0)
                                updateParams += ",";

                            updateParams += field.Key + "=" + field.Value;
                        }

                    }

                    var where = string.Format("{0} = '{1}'", pkName, pkValue.Trim());
                    //安全参数
                    if(SafeDictionary != null &&SafeDictionary.Count() > 0)
                    {
                        foreach(var dic in SafeDictionary)
                        {
                            where += string.Format(" and {0} = '{1}'", dic.Key, dic.Value);
                        }
                    }
                    sql = string.Format("update {0} set {1} where {2}", this.DbForm.MainTable, updateParams, where);

                }
                //执行SQL;
                QWF.CRM.ADO.ADO_Helper.Create().ExecSQL(sql);
                return result;
            }
        }

        /// <summary>
        /// 删除表单
        /// </summary>
        /// <param name="formCode"></param>
        public void DeleteForm()
        {
            if (!this.IsOrderForm())
                throw new UIValidateException("删除表单错误：用户【{0}】对【{1}】无操作权限!", this.curUser.CurrentUserName, this.DbForm.Name);

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var from = (from a in db.T_QCRM_Form
                            join b in db.T_QCRM_Tables on a.MainTable equals b.Code
                            join c in db.T_QCRM_Fields on b.Code equals c.TableCode
                            where c.PK == 1 && a.Code == this.FormCode
                            select new { a.MainTable, FieldCode = c.Code, PkName = c.TableCode + "_" + c.Code, c.Name }).ToList().FirstOrDefault();

                var pkValue = this.httpContext.Request[from.PkName].SafeConvert().ToStr();

                var where = string.Format("{0} = '{1}'", from.FieldCode, pkValue);
                //安全参数
                if (SafeDictionary != null && SafeDictionary.Count() > 0)
                {
                    foreach (var dic in SafeDictionary)
                    {
                        where += string.Format(" and {0} = '{1}'", dic.Key, dic.Value);
                    }
                }

                string sql = string.Format("delete from {0} where {1} ", from.MainTable, where);

                ADO.ADO_Helper.Create().ExecSQL(sql);
            }
        }

        private string GetSystemInputValue(string type, string paramValue, string actionType)
        {
            string resultValue = null;
            switch (type)
            {
                case "sys_user":
                    resultValue = QWF.Framework.Web.UserContext.GetCurrentInfo().CurrentUserCode;
                    break;
                case "sys_time":
                    resultValue = DateTime.Now.ToString();
                    break;
                case "guid":
                    resultValue = Guid.NewGuid().ToString();
                    break;
                case "sys_code":
                    resultValue = actionType == "create" ? QWF.Framework.MainServices.CreateWebAppServices.GetSeqServices().CreateNewSeqNo(paramValue) : string.Empty;
                    break;
                case "request":
                    resultValue = this.httpContext.Request[paramValue].SafeConvert().ToStr();
                    break;
                case "sys_value":
                    resultValue = paramValue;
                    break;
            }
            return resultValue;
        }

        /// <summary>
        /// 当前用户或角色对此表单是否有权限
        /// </summary>
        /// <param name="formCode"></param>
        /// <returns></returns>
        private bool IsOrderForm()
        {
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();

            var roleCodes = curUser.GetRolesCodes();

            using (var db = DbAccess.DbCRMContext.Create())
            {
                var qry = db.T_QCRM_UserInForm.Where(w => (w.UserType == "role" && roleCodes.Contains(w.TypeCode)|| (w.UserType == "user" && w.TypeCode == curUser.CurrentUserCode))
                                                           && w.FormCode == this.FormCode).Select(s => new { s.FormCode });
                if (qry.Count() > 0)
                    return true;
                
            }
            return false;
        }


      
    }
}
