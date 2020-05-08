using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Business
{
    using DAL;
    using Entity;

    public class UIControlStatusService
    {
        static UIControlStatusDAL DAL = new UIControlStatusDAL();

        public static UIControlStatus Get(string ctrlName)
        {
            return DAL.Get(ctrlName);
        }
    }
}
