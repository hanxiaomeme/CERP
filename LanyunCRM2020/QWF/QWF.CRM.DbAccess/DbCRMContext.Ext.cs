using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.CRM.DbAccess
{
    public partial class DbCRMContext 
    {
        private DbCRMContext(string connectionString):base(connectionString)
        { }

        public static DbCRMContext Create()
        {
            var connectionString = System.Configuration.ConfigurationManager.AppSettings["qwfDbCRMContext"];

            return new DbCRMContext();
        } 
    }
}
