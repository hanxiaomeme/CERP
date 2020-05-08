using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MES.DAL
{
    public class PackageDAL
    {
        public DataTable GetPackList(List<string> wheres, List<SqlParameter> parameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select t2.cInvCode, inv.cInvName, inv.cInvStd, inv.cInvDefine1 yachang, t2.cFree1,");
            sb.Append("inv.cInvDefine5 dubie, t1.* from MES_PalInfo t1 ");
            sb.Append(" left join SO_SODetails t2 on t1.cSOCode = t2.cSOCode and t1.iRowNo = t2.iRowNo");
            sb.Append(" left join Inventory inv on t2.cInvCode = inv.cInvCode ");

            if (wheres != null && wheres.Count > 0)
            {
                string strWhere = string.Join(" and ", wheres.ToArray());
                sb.Append(" where " + strWhere);
            }

            sb.Append(" order by t1.RepDate, t2.cSOCode, t2.iRowNo, t1.PalNo");

            if (parameters != null && parameters.Count > 0)
            {
                return DbHelperSQL.Query(sb.ToString(), parameters.ToArray()).Tables[0];
            }
            else
            {
                return DbHelperSQL.Query(sb.ToString()).Tables[0];
            }
        }
    }
}
