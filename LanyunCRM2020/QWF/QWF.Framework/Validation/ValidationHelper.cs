/*--------------------------------------------------------------------------------

Required 标识该属性为必需参数，不能为空
StringLength 标识该字符串有长度限制，可以限制最小或最大长度
Range 标识该属性值范围，通常被用在数值型和日期型
RegularExpression 标识该属性将根据提供的正则表达式进行对比验证
CustomValidation 标识该属性将按照用户提供的自定义验证方法，进行数值验证

----------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace QWF.Framework.Validation
{
   
    /// <summary>
    /// 校验工具类
    /// System.ComponentModel.DataAnnotations
    /// </summary>
    public static class ValidationHelper
    {
        /// <summary>
        /// 验证
        /// </summary>
        public static ValidationErrorCollection Validate(object target)
        {
            var result = new ValidationErrorCollection();

            if (target == null)
            {
                result.Add(new ValidationError() { FieldName = string.Empty, Message = "对象未实例化！" });
                return result;
            }

            Type type = target.GetType();
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                ValidateProperty(property, target, result);
            }

            return result;
        }

        /// <summary>
        /// 验证属性
        /// </summary>
        private static void ValidateProperty(PropertyInfo property, object target, ValidationErrorCollection result)
        {
            var attributes = property.GetCustomAttributes(typeof(ValidationAttribute), true);
            foreach (var attribute in attributes)
            {
                var validationAttribute = attribute as ValidationAttribute;
                if (validationAttribute == null)
                    continue;
                ValidateAttribute(property, validationAttribute, target, result);
            }
        }

        /// <summary>
        /// 验证特性
        /// </summary>
        private static void ValidateAttribute(PropertyInfo property, ValidationAttribute attribute, object target, ValidationErrorCollection result)
        {
            bool isValid = attribute.IsValid(property.GetValue(target));
            if (isValid)
                return;
            result.Add(new ValidationError() { FieldName = property.Name, Message = GetErrorMessage(property.Name, attribute) });
        }

        /// <summary>
        /// 获取错误消息
        /// </summary>
        private static string GetErrorMessage(string propertyName, ValidationAttribute attribute)
        {
            string message = string.Empty;

            if (!string.IsNullOrEmpty(attribute.ErrorMessage))
            {
                message = attribute.ErrorMessage;
            }
            else
            {
                message = attribute.FormatErrorMessage(propertyName);
            }
            return message;
        }
    }
}
