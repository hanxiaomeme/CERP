using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace QWF.Framework.Web.Filter
{
    public class ExceptionAttribute : HandleErrorAttribute
    {
        private string appName = string.Empty;
        public ExceptionAttribute()
        {

        }
        public ExceptionAttribute(string appName)
        {
            this.appName = appName;
        }
        /// <summary>
        /// 应用程序模块名称，如base，可以目录生成对应的日志文件
        /// </summary>
        public string AppName
        {
            get
            {
                return appName;

            }
            set
            {
                appName = value;
            }
        }

        public override void OnException(ExceptionContext filterContext)
        {

            // base.OnException(filterContext);

            var result = new ResultWebData();

            result.Success = false;
            result.Message = "fail!";

            //
            if (filterContext.Exception is QWF.Framework.GlobalException.UIValidateException)
            {
                //如果为UI，数据验证异常则不记录日志

                QWF.Framework.GlobalException.UIValidateException uiex = (QWF.Framework.GlobalException.UIValidateException)filterContext.Exception;

                result.Message = uiex.Message;
                result.ReturnUrl = uiex.ReturnUrl;

            }
            else if (filterContext.Exception is QWF.Framework.GlobalException.UserValidateException)
            {
                result.Message = "用户验证失败，请重新登录！";
                Common.LogHelper.Warning(result.Message + filterContext.Exception.Message);
            }
            else if (filterContext.Exception is QWF.Framework.GlobalException.PermissionException)
            {
                result.Message = "用户权限不够,无法访问！";
                Common.LogHelper.Warning(result.Message + filterContext.Exception.Message);
            }
            else
            {

                var accessInfo = new AccessInfo(filterContext);

                //系统级错误日志，DEGBU模式则显示具体消息给前端,否则不显示
                var sb = new System.Text.StringBuilder();

                sb.Append("系统错误:");
                sb.AppendLine(string.Format("区域={0}, 控制器={1}, 动作={2}, 方法={3}, 错误描述={4}，堆栈={5}",
                    accessInfo.Area,
                    accessInfo.Controller,
                    accessInfo.Action,
                    accessInfo.HttpMethod,
                    filterContext.Exception.Message,
                    filterContext.Exception.StackTrace));

                if (filterContext.Exception is System.Data.Entity.Validation.DbEntityValidationException)
                {
                    //数据库异常
                    var dbEx = (System.Data.Entity.Validation.DbEntityValidationException)filterContext.Exception;
                    sb.AppendLine("数据库异常：" + dbEx.Message);
      
                    var errors = (from u in dbEx.EntityValidationErrors select u.ValidationErrors).ToList();
                    foreach (var item in errors)
                    {
                        sb.AppendLine("ERROR:" + item.FirstOrDefault().ErrorMessage);
                    }

                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {

                        foreach (var validationError in validationErrors.ValidationErrors)
                        {

                            sb.AppendLine(string.Format("具体消息：Class: {0}, Property: {1}, Error: {2}", validationErrors.Entry.Entity.GetType().FullName,
                                validationError.PropertyName,
                                validationError.ErrorMessage));
                        }
                    }
                }

                //写入日志
                Common.LogHelper.Error(AppName, sb.ToString());

#if DEBUG
                result.Message += filterContext.Exception.Message;
#else 
                //dataResult.Message = "调用数据接口失败! 请查看系统日志";
#endif

            }
            var isAjax = filterContext.HttpContext.Request.IsAjaxRequest();

            if (isAjax)
            {
                var actionResult = new ContentResult();
                actionResult.Content = Newtonsoft.Json.JsonConvert.SerializeObject(result);
                filterContext.Result = actionResult;
            }
            else
            {

                System.Web.Mvc.ViewDataDictionary viewData = new ViewDataDictionary();
                viewData["Message"] = result.Message;

                ViewResult viewResult = new ViewResult
                {
                    ViewName = "Error", //错误页
                    MasterName = null,     //指定母版页
                    ViewData = viewData,       //指定模型
                    TempData = filterContext.Controller.TempData
                };

                filterContext.Result = viewResult;
                filterContext.HttpContext.Response.Clear();
                //filterContext.HttpContext.Response.StatusCode = 200;
            }

            filterContext.ExceptionHandled = true;

        }
    }
}
