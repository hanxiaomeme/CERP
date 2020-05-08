using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using QWF.CRM.DbAccess;
using QWF.Framework.ExtendUtils;
using System.Data.Common;
using System.Data;
using QWF.Framework.GlobalException;

namespace QWF.CRM.PlugIn.QBS
{
    /// <summary>
    /// 客户新增处理插件
    /// </summary>
    public class CustomerCreate : IPlugIn
    {
        public void Fail(Exception e)
        {

        }

        public void OnBegin(HttpContext httpContext, string pkId, string customerCode, Dictionary<string, object> dicParams = null)
        {
            /*
            * 1.需要验证联系方式数据的唯一性，并返回个性的提示
            */
            var phone = httpContext.Request["TB_Customer_Contact"].SafeConvert().ToStr();

            if (!phone.StrValidatorHelper().StrIsNullOrEmpty())
            {

                var ado = new QWF.CRM.ADO.CRMDatabase();
                var db = ado.GetDatabase();

                string sql = string.Format(@"
select a.CustomerName,b.Realname,a.Contact
    from TB_Customer a
    inner   join t_qwf_user b on a.CreateUser = b.UserCode
where a.Contact = @Contact and a.Deleted = 0
    ", phone);
                DbCommand cmd = db.GetSqlStringCommand(sql);
                db.AddInParameter(cmd, "@Contact", DbType.String, phone);

                var dt = db.ExecuteDataSet(cmd).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    throw new UIValidateException("联系方式【{0}】已经存在，客户名称为【{1}】，数据的拥有者为【{2}】",
                        dt.Rows[0]["Contact"],
                        dt.Rows[0]["CustomerName"],
                        dt.Rows[0]["Realname"]);

                }

            }

        }

        public void OnSuccess(HttpContext httpContext, string pkId, string customerCode, Dictionary<string, object> dicParams = null)
        {
            
        }
    }
}
