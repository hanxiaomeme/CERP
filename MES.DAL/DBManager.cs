using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.DAL
{
    using SqlSugar;

    public class DBManager<T> where T: class, new()
    {
        public DBManager()
        {
            Db = new SqlSugarClient(
                new ConnectionConfig()
                {
                    DbType = DbType.SqlServer,
                    InitKeyType = InitKeyType.SystemTable,
                    IsAutoCloseConnection = true,
                    ConnectionString = "server=192.168.0.105;uid=sa;pwd=jxbs-1934;database=MES"
                });
        }

        public SqlSugarClient Db;

        public SimpleClient<T> OperationDB { get { return new SimpleClient<T>(Db); } }

        public List<T> GetAll()
        {
            return OperationDB.GetList();
        }

        public void Add(T model)
        {
            OperationDB.Insert(model);
        }

        public void Update(T model)
        {
            OperationDB.Update(model);
        }

        public void Delete(dynamic id)
        {
            //OperationDB.DeleteById(id);
        }
    }
}
