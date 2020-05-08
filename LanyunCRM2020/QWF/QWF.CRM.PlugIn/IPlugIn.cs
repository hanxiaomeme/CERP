using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.CRM.PlugIn
{
    public interface IPlugIn
    {

        /// <summary>
        /// 开始执行
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="pkId">如果是新增数据则为NULL,</param>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        void OnBegin(System.Web.HttpContext httpContext, string pkId, string customerCode, Dictionary<string, object> dicParams = null);
        /// <summary>
        /// 执行完成
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="httpContext"></param>
        /// <param name="pkId"></param>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        void OnSuccess(System.Web.HttpContext httpContext, string pkId, string customerCode,Dictionary<string,object> dicParams=null);
        /// <summary>
        /// 执行失败
        /// </summary>
        /// <returns></returns>
        void Fail(Exception e);

    }
}
