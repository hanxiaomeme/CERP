using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.DAL
{
    using Entity;

    public interface ITreeDAL<T> where T: ITreeItem
    {
        List<T> GetList();
        int Add(T model);
    }
}
