using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using QWF.Framework.ExtendUtils;
using QWF.Framework.GlobalException;

namespace QWF.CRM.PlugIn
{
    public class PlugInServices
    {
        /// <summary>
        /// 获取表单插件的的实例
        /// </summary>
        public static IPlugIn GetInstance(string formCode)
        {
            //反射
            using (var db = QWF.CRM.DbAccess.DbCRMContext.Create())
            {
                var form = db.T_QCRM_Form.Where(w => w.Code == formCode).FirstOrDefault();
                if (form == null)
                    throw new UIValidateException("编号为【{0}】的表单数据不存在。",formCode);

                if (form.PlugInClass.StrValidatorHelper().StrIsNullOrEmpty())
                    return null;
     
                Type t = Type.GetType(form.PlugInClass);
                if (t == null)
                    return null;

                object instance = Activator.CreateInstance(t);
                if(instance == null)
                    throw new UIValidateException("【{0}】的实例为null，请检查数据。如果没有实现插件，请使用管理员权限在后台配置删除表单【{1}】处理插件。", form.PlugInClass,form.Name);

                return (IPlugIn)instance;
            }
        }


    }
}
