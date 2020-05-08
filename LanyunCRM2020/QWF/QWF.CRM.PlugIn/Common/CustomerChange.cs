using QWF.Framework.GlobalException;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using QWF.Framework.ExtendUtils;

namespace QWF.CRM.PlugIn.Common
{
    /// <summary>
    /// 客户变更扩展插件
    /// </summary>
    public class CustomerChange : IPlugIn
    {
        public virtual void Fail(Exception e)
        {
            
        }

        public virtual void OnBegin(HttpContext httpContext, string pkId, string customerCode, Dictionary<string, object> dicParams = null)
        {
            
        }

        public virtual void OnSuccess(HttpContext httpContext, string pkId, string customerCodes, Dictionary<string, object> dicParams = null)
        {
            //转移客户，则需要转移全部相关数据。
            if (dicParams == null)
                throw new UIValidateException("客户转移扩展插件错误，字典扩展参数为NULL");

            if (!dicParams.ContainsKey("ChangeToUserCode"))
                throw new UIValidateException("新的拥有者参数为NULL");

            var changToUserCode = dicParams["ChangeToUserCode"].ToString();

            var ado = new ADO.CRMDatabase();
            var db = ado.GetDatabase();
            string sql = "update TB_Customer set CreateUser = @ChangToUserCode where CustomerCode = @CustomerCode";
            var cmd = db.GetSqlStringCommand(sql);
            db.AddInParameter(cmd, "@CustomerCode", DbType.String);
            db.AddInParameter(cmd, "@ChangToUserCode", DbType.String, changToUserCode);

            customerCodes.StringHelper().SplitToList().ForEach(customerCode =>
            {
                db.SetParameterValue(cmd, "@CustomerCode", customerCode);
                db.ExecuteNonQuery(cmd);
            });
        }
    }
}
