using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QWF.Framework.ExtendUtils;

namespace QWF.Framework.ADO
{
    public class SQLServerDatabase
    {
        /// <summary>
        /// 默认的数据库字符串
        /// </summary>
        public const string DB_CONN_STRING = "Db.ADO.QWebFramework";

        string connStringName = string.Empty;

        public SQLServerDatabase()
        {

        }
        public SQLServerDatabase(string connStringName)
        {
            this.connStringName = connStringName;
        }

        /// <summary>
        /// 取得数据访问对象
        /// </summary>
        /// <returns></returns>
        public Database GetDatabase()
        {
            if (string.IsNullOrEmpty(connStringName))
            {
                this.connStringName = DB_CONN_STRING;
            }

            return DatabaseFactory.CreateDatabase(connStringName);
        }



        /// <summary>
        /// SQLSERVER 通用分页
        /// </summary>
        /// <param name="pViewFields"></param>
        /// <param name="pTables"></param>
        /// <param name="pWhere"></param>
        /// <param name="pOrderFields"></param>
        /// <param name="pPageIndex"></param>
        /// <param name="pPageSize"></param>
        /// <param name="pNeedReturnRowCount">是否计算总记录数</param>
        /// <param name="pRecCount"></param>
        /// <returns></returns>
        public DataSet GetPagedList(string pViewFields, string pTables, string pWhere, string pOrderFields, int pPageIndex, int pPageSize, bool pNeedReturnRowCount, ref int pRecCount)
        {
            Database db = this.GetDatabase();
            DbCommand cmd = db.GetStoredProcCommand("P_QWF_PublicPaged");
            db.AddInParameter(cmd, "@ViewFields", DbType.String, pViewFields);
            db.AddInParameter(cmd, "@Tables", DbType.String, pTables);
            db.AddInParameter(cmd, "@Where", DbType.String, pWhere);
            db.AddInParameter(cmd, "@OrderFields", DbType.String, pOrderFields);
            db.AddInParameter(cmd, "@PageIndex", DbType.Int32, pPageIndex);
            db.AddInParameter(cmd, "@PageSize", DbType.Int32, pPageSize);
            db.AddInParameter(cmd, "@NeedReturnRowCount", DbType.Boolean, pNeedReturnRowCount);
            db.AddOutParameter(cmd, "@RowCount", DbType.Int32, sizeof(int));

            cmd.CommandTimeout = 60 * 2;

            DataSet dsData = db.ExecuteDataSet(cmd);
            if (pNeedReturnRowCount && dsData != null) { pRecCount = int.Parse(db.GetParameterValue(cmd, "@RowCount").ToString()); }
            return dsData;
        }


        /// <summary>
        /// 判断表是否存在
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool ExistsTable(string table)
        {
            var db = GetDatabase();
            string sql = "select count(*) from sysobjects where id=object_id(@TableName)";
            var cmd = db.GetSqlStringCommand(sql);
            db.AddInParameter(cmd, "@TableName", DbType.String, table);
            var i = db.ExecuteScalar(cmd).SafeConvert().ToInt32(0);
            if (i > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 判断字段是否存在
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool ExistsField(string tableName, string fieldName)
        {
            var db = GetDatabase();
            string sql = "select ISNULL(COL_LENGTH(@TableName, @FieldName) ,0) ";
            var cmd = db.GetSqlStringCommand(sql);

            db.AddInParameter(cmd, "@TableName", DbType.String, tableName);
            db.AddInParameter(cmd, "@FieldName", DbType.String, fieldName);


            var i = db.ExecuteScalar(cmd).SafeConvert().ToInt32(0);
            if (i > 0)
                return true;
            return false;
        }



        /// <summary>
        /// 创建表
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool CreateTable(string table)
        {
            var db = GetDatabase();
            string sql = string.Format(@"
CREATE TABLE [dbo].[{0}](
	[Id] [varchar](50) NOT NULL,
 CONSTRAINT [PK_{0}] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
", table);
            var cmd = db.GetSqlStringCommand(sql);
            db.ExecuteNonQuery(cmd);
            return true;
        }

        /// <summary>
        /// 创建字段
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="fieldName"></param>
        /// <param name="fileType"></param>
        /// <param name="fieldTypeLength"></param>
        /// <returns></returns>
        public bool CreateField(string tableName, string fieldName, string fieldType, int fieldTypeLength)
        {
            var db = GetDatabase();
            //alter table 表名 add 字段 类型 not null
            var dbType = GetDbType(fieldType, fieldTypeLength);

            var sql = string.Format(@"
alter table {0} add {1} {2} null 
", tableName, fieldName, dbType);
            var cmd = db.GetSqlStringCommand(sql);
            db.ExecuteNonQuery(cmd);
            return true;
        }

        public string GetDbType(string fieldType, int fieldTypeLength)
        {
            string dbType = string.Empty;
            switch (fieldType)
            {
                case "text":
                    dbType = string.Format("varchar({0})", fieldTypeLength == 0 ? "max" : fieldTypeLength.ToString());
                    break;
                case "int":
                    dbType = "int";
                    break;
                case "datetime":
                    dbType = "datetime";
                    break;
                case "decimal":
                    dbType = string.Format("Decimal(18,{0})", fieldTypeLength);
                    break;
            }
            return dbType;

        }
        /// <summary>
        /// 设置主键
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public bool SetPrimaryKey(string tableName, string fieldName, string fieldType, int fieldTypeLength)
        {
            var db = GetDatabase();
            var dbType = GetDbType(fieldType, fieldTypeLength);

            string sql = string.Format(@"
            alter table {0} alter column {1} {2} not null;
            alter table {0} add constraint PK_{0} key({1});
            ", tableName, fieldName, dbType);

            var cmd = db.GetSqlStringCommand(sql);
            db.ExecuteNonQuery(cmd);
            return true;

        }

        public bool AlterFieldLength(string tableName, string fieldName, string fieldType, int fieldTypeLength)
        {
            var db = GetDatabase();
            var dbType = GetDbType(fieldType, fieldTypeLength);

            string sql = string.Format(@"
           ALTER TABLE {0} ALTER COLUMN {1} {2}

            ", tableName, fieldName, dbType);
            var cmd = db.GetSqlStringCommand(sql);
            db.ExecuteNonQuery(cmd);
            return true;
        }



        /// <summary>
        /// 创建数据字典视图
        /// </summary>
        /// <param name="code">字段编号</param>
        /// <returns></returns>
        public bool CreateDictionaryView(string code)
        {

            string sql = string.Format(@"CREATE VIEW [dbo].[{0}]
AS
        SELECT     ItemName, ItemValue
        FROM         dbo.T_QCRM_Dictionary
        WHERE     (ParentId =(SELECT     Id
                            FROM          dbo.T_QCRM_Dictionary AS T_QCRM_Dictionary_1
                            WHERE      (Code = '{2}')))

", "v_" + code, code);
            var db = GetDatabase();
            var cmd = db.GetSqlStringCommand(sql);
            db.ExecuteNonQuery(cmd);
            return true;

        }


        public bool DropDictionaryView(string code)
        {
            string sql = string.Format(@"drop table v_{0}") ;
            var db = GetDatabase();
            var cmd = db.GetSqlStringCommand(sql);
            db.ExecuteNonQuery(cmd);
            return true;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool CreateDictionaryViewTree(string code, string parentId)
        {
            string sql = string.Format(@"CREATE VIEW [dbo].[{0}]
AS
      select 
        Id,ParentId,ItemName,ItemValue,IdList,ItemFullNamePath
        from dbo.T_QCRM_Dictionary
        where idlist like '%,{1},%' and Hide=0 and ParentId >0
", code, parentId);
            var db = GetDatabase();
            var cmd = db.GetSqlStringCommand(sql);
            db.ExecuteNonQuery(cmd);
            return true;

        }

        /// <summary>
        /// 检查视图或表关系中列是否存在
        /// </summary>
        /// <param name="tableRelation"> 视图 、 表 、关系表</param>
        /// <param name="colName">列名</param>
        /// <returns></returns>
        public bool CheckedColumsExists(string tableRelation, string colName)
        {
            var db = GetDatabase();
            
            string sql = string.Format("select top 1 * from {0}", tableRelation);
            var cmd = db.GetSqlStringCommand(sql);

            var dt = db.ExecuteDataSet(cmd).Tables[0];
            if(dt!=null)
            {
                return dt.Columns.Contains(colName);
            }
            return false;
        }
    }
}