using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace QWF.CRM.PlugIn.Common
{
    /// <summary>
    /// 客户删除插件
    /// </summary>
    public class CustomerDelete : IPlugIn
    {
        public virtual void Fail(Exception e)
        {

        }

        public virtual void OnBegin(HttpContext httpContext, string pkId, string customerCode, Dictionary<string, object> dicParams = null)
        {

        }

        public virtual void OnSuccess(HttpContext httpContext, string pkId, string customerCode, Dictionary<string, object> dicParams = null)
        {
            //清空相关的数据
            var ado = new ADO.CRMDatabase();
            var db = ado.GetDatabase();
            DbCommand cmd = db.GetStoredProcCommand("P_CustomerDelete");
            db.AddInParameter(cmd, "@CustomerCode", System.Data.DbType.String, customerCode);
            db.ExecuteNonQuery(cmd);
        }
    }
}
