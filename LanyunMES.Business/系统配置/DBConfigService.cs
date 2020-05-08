using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Business 
{
    using Lanyun.DBUtil;

    public class DBConfigService
    {
        public void SerConnectionString(string connectionString)
        {
             DbHelperSQL.SetConnectionStr(connectionString);
        }
    }
}
