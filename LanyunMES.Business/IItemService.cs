using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LanyunMES.Business
{
    public interface IItemService
    {
        DataRow Get(int Id);

        DataTable GetTable(string value);

        int Add(DataRow row);

        bool Update(DataRow row);

        bool Delete(int Id);
    }
}
