using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanyunMES.Entity
{
    public class ModelSqlInfo
    {
        /// <summary>
        /// 表配置信息
        /// </summary>
        public ICTableInfo TableInfo { get; set; }

        /// <summary>
        /// 查询sql
        /// </summary>
        public string SQL_Select { get; set; }

        /// <summary>
        /// 新增sql
        /// </summary>
        public string SQL_Insert { get; set; }

        /// <summary>
        /// 更新sql
        /// </summary>
        public string SQL_Update { get; set; }

        /// <summary>
        /// 删除sql
        /// </summary>
        public string SQL_Delete { get; set; }

        /// <summary>
        /// 查询列表SQL
        /// </summary>
        public string SQL_List { get; set; }
    }
}
