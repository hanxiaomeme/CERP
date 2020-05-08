using QWF.Framework.GlobalException;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QWF.Framework.ExtendUtils;

namespace QWF.CRM.Utils
{
    public class FieldQueryType
    {
        /// <summary>
        /// 默认
        /// </summary>
        public const string QueryType_00="00";
       /// <summary>
       /// 查询类型为 时间
       /// </summary>
        public const string QueryType_01 ="01";
        /// <summary>
        /// 查询类型 用户
        /// </summary>
        public const string QueryType_02 ="02";
    }

    public class FormPagedUtils
    {
     
       
        /// <summary>
        /// 当前用户信息
        /// </summary>
        private QWF.Framework.Services.SvrModels.SvrShortUserInfo curUser;
        /// <summary>
        /// CRM数据库上下文
        /// </summary>
        private DbAccess.DbCRMContext dbCrmContext;

        public FormPagedUtils(DbAccess.DbCRMContext db)
        {
            curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            this.dbCrmContext = db;
        }

        /// <summary>
        /// 创建新的实例
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static FormPagedUtils Create(DbAccess.DbCRMContext db)
        {
            return new FormPagedUtils(db);
        }

        /// <summary>
        /// 查询分页
        /// </summary>
        /// <param name="listType">列表代码</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="total">总记录数</param>
        /// <param name="whereId">保存的固定查询条件ID</param>
        /// <param name="queryExpressions">客户端附加的条件表示式</param>
        /// <param name="orderBy">排序表达式 xxx asc xxx desc </param>
        /// <returns></returns>
        public List<Dictionary<string, object>> ListPaged(string listType, int pageIndex, ref int total, int whereId, List<string> queryExpressions,string queryOrderBy=null)
        {

            var dbListType = dbCrmContext.T_QCRM_ListType.AsNoTracking().Where(w => w.ListType == listType && w.IsHide == 0).FirstOrDefault();
            var dbQueryList = dbCrmContext.T_QCRM_QueryList.AsNoTracking().Where(w => w.ListType == listType).ToList();

            if (dbListType == null)
                throw new UIValidateException("没有配置的查询列表 listype=【{0}】。", dbListType);

            //
            var tables = SQL_Replace(dbListType.TableRelation);

            var fileds = string.Empty;
            dbQueryList.ForEach(item =>
            {
                if (fileds.Length > 0)
                    fileds += ",";
                fileds += item.TableCode + "_" + item.FieldCode;
            });

            var orderby = dbListType.OrderBy + " " + dbListType.AscOrDesc ;    //默认排序

         
            var pageSize = dbListType.PageSize == 0 ? 10000 : dbListType.PageSize; //默认分页大小
            var where = " 1=1 ";

            if (whereId > 0)
            {
              
                var queryCategory = dbCrmContext.T_QCRM_QueryCategory.AsNoTracking().Where(w => w.Id == whereId).FirstOrDefault();

                if (queryCategory!=null)
                {
                    dbCrmContext.T_QCRM_QueryWhere.AsNoTracking().Where(w => w.QueryCategoryId == whereId).OrderBy(o=>o.SortId).ToList().ForEach(item =>
                    {
                        #region 生产where条件
                        var productServerField = ConfigUtils.Instance.GetServerTimeList();
                        //产品服务时间字段
                        where += queryCategory.AndOr + " ";

                        if(productServerField.Where(w =>w.VirtualFieldCode==item.FieldCode).Count()>0 )
                        {
                            where += GetProductServerTimeSQL(item);
                        }
                        else if(item.FieldQueryType == QWF.CRM.Utils.FieldQueryType.QueryType_01)
                        {
                            where += GetDateExpression(item.FieldCode, item.DateType.Value, item.DateNum.Value, item.StaticDateValue);
                        }
                        else
                        {
                            where += GetWhereExpression(item);
                        }
                        #endregion;
                    });

                    //排序
                    if (!string.IsNullOrWhiteSpace(queryCategory.SortField))
                        orderby = queryCategory.SortField + " " + queryCategory.AscOrDesc;
                }
            }

            if (queryExpressions != null)
            {
                foreach (var query in queryExpressions)
                {
                    where += string.Format(" {0} ", query);
                }
            }

            // 使用传入的的排序
            if (!string.IsNullOrWhiteSpace(queryOrderBy))
                orderby = queryOrderBy; 

            var ado = new ADO.CRMDatabase();
            var ds = ado.GetPagedList(fileds, tables, where, orderby, pageIndex, pageSize, true, ref total);
            var list = new List<Dictionary<string, object>>();

            if (ds != null && ds.Tables.Count > 0)
            {
                //按字段配置输出字段
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    var row = new Dictionary<string, object>();
                    foreach (var setting in dbQueryList)
                    {
                        var columnName = setting.TableCode + "_" + setting.FieldCode;
                        var rowData = ds.Tables[0].Rows[i];
                        var data = ds.Tables[0].Rows[i][columnName];
                        var dataType = ds.Tables[0].Columns[columnName].DataType;

                        //先默认输出格式化
                        object defaultVal = DefaultFormatter(rowData, columnName, data, dataType);
                        row.Add(setting.TableCode + "_" + setting.FieldCode, defaultVal);
                        //如果值指定初输出
                        if (!setting.FormatterType.StrValidatorHelper().StrIsNullOrEmpty())
                        {
                            //格式化的字段名,存储2个值，一个原始值，一个格式化的值
                            var fmtVal = FormatterField(rowData, columnName, data, dataType, setting.FormatterType, setting.FieldFormatter);
                            row.Add(setting.TableCode + "_" + setting.FieldCode + "_FMT", fmtVal);
                        }
                    }
                    list.Add(row);
                }
            }

            return list;

        }


        private string GetWhereExpression(DbAccess.T_QCRM_QueryWhere item)
        {
            var whereSQL = string.Empty;

            #region 计算值
            string fieldValue = string.Empty;
            if (item.FieldQueryType == FieldQueryType.QueryType_02) //用户
            {
                #region 用户 1 自己 ,2指定编码
                if (item.UserCodeType.Value == 1)
                {
                    fieldValue = curUser.CurrentUserCode;
                }
                else if (item.UserCodeType.Value == 2)
                {
                    fieldValue = item.UserCode;
                }
                #endregion
            }
            else
            {
                fieldValue = item.FieldValue;
            }
            #endregion

            if (item.Expression == "in" || item.Expression == "notin") 
            {
                string isNot = item.Expression == "notin" ? "not" : "";

                if (item.FieldValue.IndexOf(",") > 0) // 多值情况
                {
                    string sql = string.Empty;
                    item.FieldValue.StringHelper().SplitToList().ForEach(val =>
                    {
                        if (sql.Length > 0)
                            sql += " or ";
                        sql += string.Format("{0} {1} like '%{2}%'", item.FieldCode,isNot, val);
                    });

                    whereSQL += string.Format("({0})", sql);
                }
                else
                {
                    whereSQL += string.Format("  {0} {1} like '%{2}%'", item.FieldCode,isNot, fieldValue);
                }
            }
            else
            {
                //常规表达式

                if (item.FieldValueType == "text")
                {
                    fieldValue = string.Format("'{0}'", fieldValue);
                }
                whereSQL += string.Format(" {0} {1} {2}", item.FieldCode,item.Expression, fieldValue);
            }

            return whereSQL;

        }
        /// <summary>
        /// 获取产品服务的过滤条件
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private string GetProductServerTimeSQL(DbAccess.T_QCRM_QueryWhere item)
        {
            
            var subWhere = new StringBuilder("select distinct CustomerCode from T_QCRM_CustomerProduct where ");
            var fieldCode = Utils.ConfigUtils.Instance.GetServerTimeList().Where(w => w.VirtualFieldCode == item.FieldCode).FirstOrDefault().FileCode;

            string dateSql = GetDateExpression(fieldCode, item.DateType.Value, item.DateNum.Value, item.StaticDateValue);

            subWhere.Append(dateSql);

            string sql = string.Format("TB_Customer_CustomerCode in ({0})",subWhere.ToString());

            return sql;
        }

        /// <summary>
        /// 获取时间表达式
        /// </summary>
        /// <param name="dateType"></param>
        /// <param name="dateNum"></param>
        /// <param name="staticDateValue"></param>
        /// <returns></returns>
        private string GetDateExpression(string fieldCode ,int dateType, int dateNum, string staticDateValue)
        {
            string result = string.Empty;

            var type = (QWF.CRM.Models.QueryDateTypeEnum)dateType;

            if(dateType<10)
            {
                //固定时间
                string expression = string.Empty;
                switch(type)
                {
                    case Models.QueryDateTypeEnum._1_等于:
                        expression = "=";
                        break;
                    case Models.QueryDateTypeEnum._2_大于:
                        expression = ">";
                        break;
                    case Models.QueryDateTypeEnum._3_大于等于:
                        expression = ">=";
                        break;
                    case Models.QueryDateTypeEnum._4_小于:
                        expression = "<";
                        break;
                    case Models.QueryDateTypeEnum._5_小于等于:
                        expression = "<=";
                        break;
                }
                result = string.Format("{0} {1} '{2}' ",fieldCode,expression,staticDateValue);
            }
            else if(dateType>= 10 && dateType <50 )
            { 
                var beginTime=DateTime.Now;
                var endTime = DateTime.Now;

                #region 常用时间，固定设置
                switch (type)
                {
                    case Models.QueryDateTypeEnum._10_今天:
                        beginTime = DateTime.Now.Date;
                        endTime = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
                        break;
                    case Models.QueryDateTypeEnum._11_昨天:
                        beginTime = DateTime.Now.Date.AddDays(-1);
                        endTime = beginTime.AddDays(1).AddSeconds(-1);
                        break;
                    case Models.QueryDateTypeEnum._12_明天:
                        beginTime = DateTime.Now.AddDays(1);
                        endTime = beginTime.AddDays(1).AddSeconds(-1);
                        break;
                    case Models.QueryDateTypeEnum._20_本周:
                        beginTime  = DateTime.Now.Date.AddDays(1 - Convert.ToInt16(DateTime.Now.DayOfWeek)); //周1
                        endTime = DateTime.Now.Date.AddDays(7 - Convert.ToInt16(DateTime.Now.DayOfWeek)); //周日 
                        endTime = endTime.AddDays(1).AddSeconds(-1); 
                        break;
                    case Models.QueryDateTypeEnum._21_上一周:
                        beginTime = DateTime.Now.Date.AddDays(1 - Convert.ToInt16(DateTime.Now.DayOfWeek) - 7);
                        endTime = DateTime.Now.Date.AddDays(7 - Convert.ToInt16(DateTime.Now.DayOfWeek) - 7);
                        endTime = endTime.AddDays(1).AddSeconds(-1);
                        break;
                    case Models.QueryDateTypeEnum._22_下一周:
                        beginTime = DateTime.Now.Date.AddDays(1 - Convert.ToInt16(DateTime.Now.DayOfWeek) + 7);
                        endTime = DateTime.Now.Date.AddDays(7 - Convert.ToInt16(DateTime.Now.DayOfWeek) + 7);
                        endTime = endTime.AddDays(1).AddSeconds(-1);
                        break;
                    case Models.QueryDateTypeEnum._30_本月:
                        beginTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                        endTime = beginTime.AddMonths(1).AddSeconds(-1);
                        break;
                    case Models.QueryDateTypeEnum._31_上一月:
                        beginTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month-1, 1);
                        endTime = beginTime.AddMonths(1).AddSeconds(-1);
                        break;
                    case Models.QueryDateTypeEnum._32_下一月:
                        beginTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1);
                        endTime = beginTime.AddMonths(1).AddSeconds(-1);
                        break;
                    case Models.QueryDateTypeEnum._40_今年:
                        beginTime = new DateTime(DateTime.Now.Year, 1, 1);
                        endTime = new DateTime(DateTime.Now.Year, 12, 31, 23, 59, 59);
                        break;
                    case Models.QueryDateTypeEnum._41_去年:
                        beginTime = new DateTime(DateTime.Now.Year-1, 1, 1);
                        endTime = new DateTime(DateTime.Now.Year-1, 12, 31, 23, 59, 59);
                        break;
                    case Models.QueryDateTypeEnum._42_明年:
                        beginTime = new DateTime(DateTime.Now.Year + 1, 1, 1);
                        endTime = new DateTime(DateTime.Now.Year + 1, 12, 31, 23, 59, 59);
                        break;
                }
                result = string.Format("{0} between '{1}' and '{2}'", fieldCode, beginTime.ToString(), endTime.ToString());
                #endregion
            }
            else
            {
                var beginTime = DateTime.Now;
                var endTime = DateTime.Now;

                #region 按天的设置
                switch (type)
                {
                    case Models.QueryDateTypeEnum._50_最近xx天:
                        beginTime = DateTime.Now.Date.AddDays(-dateNum);
                        endTime = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
                        break;
                    case Models.QueryDateTypeEnum._51_之后xx天:
                        beginTime = DateTime.Now.Date;
                        endTime = DateTime.Now.Date.AddDays(dateNum).AddDays(1).AddSeconds(-1);
                        break;
                }

                result = string.Format("{0} between '{1}' and '{2}'", fieldCode, beginTime.ToString(), endTime.ToString());

                #endregion
            }

            return result;
        }

        /// <summary>
        /// 默认的输出格式
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columnName"></param>
        /// <param name="val"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        private object DefaultFormatter(DataRow row, string columnName, object val, Type dataType)
        {
            if (row.IsNull(columnName) || val.ToString().Length == 0)
            {
                //日期,字符串 则返回字符串
                if (dataType == typeof(DateTime) || dataType == typeof(string))
                {
                    return string.Empty;
                }
                else
                {
                    return null;
                }
            }

            if (dataType == typeof(DateTime) && val.ToString().Length > 0)
            {
                if (row.Field<DateTime>(columnName).Year == 1900)
                    return string.Empty;
            }

            object result = val;
            if (dataType == typeof(DateTime))
            {
                //日期格式统一输出
                result = row.Field<DateTime>(columnName).ToString("yyyy-MM-dd HH:mm:ss");
                return result;
            }
            return result;

        }
        /// <summary>
        /// 按指定的格式格式化字符
        /// </summary>
        /// <param name="val">值</param>
        /// <param name="dataType">字段的实际存储的类型</param>
        /// <param name="formatterType">格式化类型01,02,02</param>
        /// <param name="fieldFormatter">具体要格式的参数</param>
        /// <returns></returns>
        private object FormatterField(DataRow row, string columnName, object val, Type dataType, string formatterType, string fieldFormatter)
        {
            //为空的情况
            if (row.IsNull(columnName) || val.ToString().Length == 0)
            {
                //日期,字符串 则返回字符串
                if (dataType == typeof(DateTime) || dataType == typeof(string))
                {
                    return string.Empty;
                }
                else
                {
                    return null;
                }
            }

            if (dataType == typeof(DateTime) && val.ToString().Length > 0)
            {
                if (row.Field<DateTime>(columnName).Year == 1900)
                    return string.Empty;
            }

            object result = val;

            //不需要格式化
            if (string.IsNullOrWhiteSpace(formatterType))
            {
                return DefaultFormatter(row, columnName, val, dataType);
            }
            int decimals = 2; //精度默认2
            switch (formatterType)
            {
                case "100": //日期 
                    if (dataType == typeof(DateTime))
                        result = string.IsNullOrWhiteSpace(fieldFormatter) ? row.Field<DateTime>(columnName).ToString("yyyy-MM-dd HH:mm:ss") : row.Field<DateTime>(columnName).ToString(fieldFormatter);
                    break;
                case "101": //网址 支持模板替换
                    if (string.IsNullOrWhiteSpace(fieldFormatter))
                    {
                        fieldFormatter = fieldFormatter.Replace("$qwf_value$", val.ToString());
                        result = string.Format(@"<a href='{0}'>点击打开</a>", fieldFormatter);
                    }
                    break;
                case "102": //货币格式
                    if (dataType == typeof(int) || dataType == typeof(decimal))
                    {
                        result = Math.Round(Convert.ToDecimal(val), decimals).ToString("N");
                    }
                    break;
                case "103": //103  小数 
                    if (dataType == typeof(int) || dataType == typeof(decimal))
                    {
                        decimals = string.IsNullOrWhiteSpace(fieldFormatter) ? 2 : fieldFormatter.SafeConvert().ToInt32(2);
                        result = Math.Round(Convert.ToDecimal(val), decimals);
                    }
                    break;
                case "104": //QQ

                    break;
                case "105": //百分比,
                    if (dataType == typeof(int) || dataType == typeof(decimal))
                    {
                        var p = string.IsNullOrWhiteSpace(fieldFormatter) ? "P" : "P" + fieldFormatter;
                        result = Convert.ToDecimal(val).ToString(p);
                    }

                    break;
                case "106"://邮箱
                    result = string.Format("<a href='mailto:{0}'>{0}</a>", val.ToString());
                    break;
                case "107": // 账号
                    int len = string.IsNullOrWhiteSpace(fieldFormatter) ? 4 : fieldFormatter.SafeConvert().ToInt32(4);
                    var sVal = val.ToString();
                    var temp = string.Empty;
                    for (int i = 0; i < sVal.Length; i++)
                    {
                        temp += sVal[i];
                        if ((i + 1) % len == 0)
                            temp += " ";
                    }
                    result = temp.Trim();
                    break;
            }

            return result;
        }

        /// <summary>
        /// SQL模板替换
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public string SQL_Replace(string sql)
        {
            var permission = QWF.CRM.Utils.PermissionUtils.Create();

            sql = sql.Replace("$qwf_UserId$", curUser.CurrentUserId.ToString());  //当前用户ID
            sql = sql.Replace("$qwf_UserCode$", curUser.CurrentUserCode);        //当前用户CODE
            sql = sql.Replace("$qwf_OrgId$", curUser.CurrentOrgId.ToString());  //当前用户所属机构ID
            sql = sql.Replace("$qwf_UserType$", ((int)permission.GetUserType()).ToString()); //用户类型
            sql = sql.Replace("$qwf_DataRange$", ((int)permission.GetDataRange()).ToString()); //数据范围
            return sql;

        }

        /// <summary>
        /// 根据快速查询的搜索条件生成条件表达式
        /// </summary>
        /// <param name="qrySreachId">搜索ID</param>
        /// <param name="qSreachText">关键字</param>
        /// <param name="qrySreachBeginTime">开始时间</param>
        /// <param name="qrySreachEndTime">结束时间</param>
        /// <param name="qSreachSelect"></param>
        /// <param name="qSreachSelectTree">树节点值</param>
        /// <param name="isVague">精确</param>
        /// <returns></returns>
        public List<string> GetQuerySreachExpression(int qrySreachId, string qSreachText, DateTime qrySreachBeginTime, DateTime qrySreachEndTime, string qSreachSelect, string qSreachSelectTree, bool isVague)
        {
            var query = new List<string>();

            if (qrySreachId > 0)
            {
                var quickSreach = (from a in dbCrmContext.T_QCRM_QuickSreach.AsNoTracking()
                                   join b in dbCrmContext.T_QCRM_QueryList.AsNoTracking() on a.QueryFieldId equals b.Id
                                   join c in dbCrmContext.T_QCRM_Fields.AsNoTracking() on new { TableCode = b.TableCode, FiledCode = b.FieldCode } equals new { TableCode = c.TableCode, FiledCode = c.Code }
                                   where a.Id == qrySreachId
                                   select new
                                   {
                                       a.SreachType,
                                       a.DictionaryId,
                                       b.TableCode,
                                       b.FieldCode,
                                       c.FieldType
                                   }).FirstOrDefault();

                if (quickSreach != null)
                {
                    #region expression 
                    var sreachFieldName = quickSreach.TableCode + "_" + quickSreach.FieldCode;
                    var sreachValue = string.Empty;
                    var filedTypeIsStr = (quickSreach.FieldType == "int" || quickSreach.FieldType == "decimal") ? false : true;
                    var expression = "";

                    if (quickSreach.SreachType == "select")
                    {
                        #region select
                        sreachValue = qSreachSelect;//
                        var dicType = dbCrmContext.T_QCRM_Dictionary.Where(w => w.Id == quickSreach.DictionaryId).FirstOrDefault();
                        if (dicType != null)
                        {
                            if (dicType.DictionaryType == 1)
                            {
                                sreachValue = qSreachSelectTree;
                            }
                         
                            if(filedTypeIsStr)
                            {
                                //如果是字符要转化一下。
                                sreachValue = ConverToWhereInStr(sreachValue);
                            }
                            if(sreachValue.Length>0)
                            {
                                expression = string.Format(" and {0} in ({1})", sreachFieldName, sreachValue);
                            }
                        }
                        #endregion
                    }
                    else if (quickSreach.SreachType == "date")
                    {
                        if (isVague)
                        {
                            expression = string.Format(" and {0} = '{1}'", sreachFieldName, qrySreachBeginTime);
                        }
                        else
                        {
                            expression = string.Format(" and {0} between '{1}' and '{2}'", sreachFieldName, qrySreachBeginTime, qrySreachEndTime);
                        }
                    }
                    else if (quickSreach.SreachType == "text")
                    {
                        if (isVague)
                        {
                            sreachValue = filedTypeIsStr ? string.Format("'{0}'", qSreachText.Trim()) : qSreachText.Trim();
                            expression = string.Format(" and {0} = {1}", sreachFieldName, sreachValue);
                        }
                        else
                        {
                            expression = string.Format(" and {0} like '%{1}%'", sreachFieldName, qSreachText.Trim());
                        }
                    }
                    #endregion

                    query.Add(expression);
                }
            }
            return query;
        }

        /// <summary>
        /// 将字符串数组转化为where in 可以识别的格式
        /// </summary>
        /// <param name="values">,</param>
        /// <returns>'val1', 'val2'的格式</returns>
        public string ConverToWhereInStr(string inValues)
        {
            string result = string.Empty;
            var values = inValues.StringHelper().SplitToArray(",", StringSplitOptions.RemoveEmptyEntries);

            foreach (string val in values)
            {
                if(val.Length > 0 )
                {
                    if (result.Length > 0)
                        result += ",";

                    result += string.Format("'{0}'", val);
                }
            }

            return result;
        }
    }
}
