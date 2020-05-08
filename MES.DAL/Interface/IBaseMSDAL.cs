using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity
{
    public interface IBaseMSDAL<T> where T:class, new()
    {
        T Get(int id);

        DataTable GetDTable(int id);

        DataTable GetTable(string[] wheres);

        int Add(T model);

        void Update(T model);

        bool Delete(int id);

        bool Exists(string cCode);

        bool ExistsRef(int id);

    }
}
