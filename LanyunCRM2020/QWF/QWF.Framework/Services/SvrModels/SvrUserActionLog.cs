using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Services.SvrModels
{
    public enum SverUserActionLogType
    {
        /// <summary>
        /// 默认
        /// </summary>
        Default = 1,
        /// <summary>
        /// 查询
        /// </summary>
        Read = 2,
        /// <summary>
        /// 新增
        /// </summary>
        Create = 3,
        /// <summary>
        /// 编辑
        /// </summary>
        Update = 4,
        /// <summary>
        /// 删除
        /// </summary>
        Delete = 5

    }
    public class SvrUserActionLog
    {
        /// <summary>
        /// 调用者定义代码
        /// </summary>
        public string LogCode { get; set; }
        /// <summary>
        /// 日志类型
        /// </summary>
        public SverUserActionLogType LogType { get; set; }
        /// <summary>
        /// 日志描述
        /// </summary>
        public string LogDescription { get; set; }
        /// <summary>
        /// 由调用者参数
        /// </summary>
        public string LogItems { get; set; }
    }
}
