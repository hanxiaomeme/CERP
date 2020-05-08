using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.DbAccess
{
    public partial class DbFrameworkContext
    {
        private DbFrameworkContext(string connectionString) :base(connectionString)
        { }

        public static DbFrameworkContext Create()
        {
            var connectionString = System.Configuration.ConfigurationManager.AppSettings["qwfDbFrameworkContext"];
            if (string.IsNullOrWhiteSpace(connectionString))
                connectionString = "DbFrameworkContext";

            return new DbFrameworkContext(connectionString);
        }
    }
}
