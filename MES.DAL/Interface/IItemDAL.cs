using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.DAL
{
    public interface IItemDAL<T> where T: class, new()
    {
        T Get(int id);

        List<T> GetList();

        int Add(T model);

        bool Update(T model);

        bool Delete(int id);

        bool Exists(string cCode);

        bool ExistsRef(int id);
    }
}
