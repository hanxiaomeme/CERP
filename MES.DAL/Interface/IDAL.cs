using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LanyunMES.DAL
{
    public interface IDAL<T>
    {
        T Get(string guid);
        string Add(T model);
        void Update(T model);
        bool Delete(string guid);
        bool Audit(string guid, string person);
        bool UnAudit(string guid);
        DataTable GetList(string[] wheres, params SqlParameter[] parameters);

    }
}
