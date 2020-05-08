using QWF.Framework.GlobalException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.CRM.ADO
{
    public partial class ADO_Helper
    {
        private QWF.CRM.ADO.CRMDatabase ado;

        public ADO_Helper()
        {
            this.ado = new CRMDatabase();
        }

        public static ADO_Helper Create()
        {
            return new ADO_Helper();
        }



        /// <summary>
        /// 检查表是否物理存在
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool ExistsTable(string tableName)
        {
            return ado.ExistsTable(tableName);
        }

        public bool CreateTable(string tableName)
        {
            if (ado.ExistsTable(tableName))
                throw new UIValidateException("表名【{0}】已经物理存在，不能创建表", tableName);

            return ado.CreateTable(tableName);
        }

        public bool ExistsField(string tableName, string fieldName)
        {
            return ado.ExistsField(tableName, fieldName);
        }

        public bool CreateField(string tableName, string fieldName, string fieldType, int fieldTypeLength)
        {
            if (ExistsField(tableName, fieldName))
                throw new UIValidateException("字段【{0}.{1}】已经物理存在，不能创建!", tableName, fieldName);

            return ado.CreateField(tableName, fieldName, fieldType, fieldTypeLength);
        }

        public bool AddPrimaryKey(string tableName, string fieldName, string fieldType, int fieldTypeLength)
        {
            return ado.SetPrimaryKey(tableName, fieldName, fieldType, fieldTypeLength);
        }

        public bool AlterFieldLength(string tableName, string fieldName, string fieldType, int fieldTypeLength)
        {
            return ado.AlterFieldLength(tableName, fieldName, fieldType, fieldTypeLength);
        }


        public int ExecSQL(string sql)
        {
            var db = ado.GetDatabase();
            var cmd = db.GetSqlStringCommand(sql);
            return db.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// 创建字典视图
        /// </summary>
        /// <param name="code"></param>
        public void CreateDictionaryView(string code)
        {
            //code = "v_" + code;
            ado.CreateDictionaryView(code);
        }

        //删除字典视图
        public void DropDictionaryView(string code)
        {
            //ado.
        }

        public void CreateDictionaryTreeView(string code,string parentId)
        {
            code = "v_tree_" + code;
            ado.CreateDictionaryViewTree(code, parentId);
        }


        public bool CheckedColumsExists(string tableRelation, string colName)
        {
            if (string.IsNullOrWhiteSpace(tableRelation) || string.IsNullOrWhiteSpace(colName))
                throw new UIValidateException("表关系和列名不能为空，请检查数据。");

            //替换SQL模板
            using (var db = DbAccess.DbCRMContext.Create())
            {
                tableRelation = QWF.CRM.Utils.FormPagedUtils.Create(db).SQL_Replace(tableRelation);
            }
            return ado.CheckedColumsExists(tableRelation, colName);
        }
    }
}