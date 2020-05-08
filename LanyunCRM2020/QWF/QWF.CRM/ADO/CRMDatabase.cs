using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.CRM.ADO
{
    /// <summary>
    /// 后期应该是改成实现 IDatabase 的接口 ,接口应该包含，基本的ADO方式操作，如，分页，创建表，字段等方法
    /// </summary>
    public class CRMDatabase:QWF.Framework.ADO.SQLServerDatabase
    {
        public CRMDatabase():
            base("QWF.ADO.QCRM")
        {

        }

        //CRM 扩展方法
    }
}
