using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity
{
    public class FileInformaion
    {

        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 文件全路径名称
        /// </summary>
        public string FileFullName { get; set; }

        /// <summary>
        /// 文件拓展名
        /// </summary>
        public string FileExt { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
        public long? FileSize { get; set; }

        /// <summary>
        /// 文件修改日期
        /// </summary>
        public DateTime FileMdyDate { get; set; }

        /// <summary>
        /// 文件创建日期
        /// </summary>
        public DateTime FileCreateDate { get; set; }
    }
}
