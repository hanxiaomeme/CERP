using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Business
{
    using DAL;
    using Entity;
 
    public class MenuService
    {
        MenuDAL DAL = new MenuDAL();

        public Menu Get(int Id)
        {
            return DAL.Get(Id);
        }

        public List<Menu> GetList()
        {
            return DAL.GetList();
        }

        public List<Menu> GetList(string userName)
        {
            if(userName.ToLower() == "admin")
            {
                return DAL.GetList();
            }
            else
            {
                return DAL.GetList(userName);
            }
        }

        public int Add(Menu menu)
        {
            return DAL.Add(menu);
        }

        public bool Update(Menu menu)
        {
            return DAL.Update(menu);
        }

        public bool Delete(int id)
        {
            return DAL.Delete(id);
        }

        public bool Exists(string fNumber)
        {
            return DAL.Exists(fNumber);
        }
    }
}
