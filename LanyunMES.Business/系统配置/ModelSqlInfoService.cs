using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Business
{
    using DAL;
    using Entity;

    /// <summary>
    /// 单据配置信息
    /// </summary>
    public class ModelSqlInfoService
    {
        static ICTransTypeDAL tranDAL = new ICTransTypeDAL();

        /// <summary>
        /// 获取单据配置信息
        /// </summary>
        /// <param name="fTranType">FTranType</param>
        /// <param name="userId">用户ID</param>
        public static List<ModelSqlInfo> GetModelSqlInfo(int fTranType, int userId = 0)
        {
            var tranInfo = tranDAL.Get(fTranType);

            if (tranInfo == null)
            {
                throw new Exception("没有FTranType:" + fTranType + "配置信息!");
            }
 
            //主表
            var mTable = tranInfo.Tables.Find(x => x.bSlave == false);

            List<ModelSqlInfo> mSqlList = new List<ModelSqlInfo>();


            var hasMoneyAuth = new Auth_DataDAL().Exist(fTranType, userId);

            tranInfo.Tables.ForEach(x =>
            {
                var fields = ICTableFieldDAL.GetTableFields(fTranType, x.FTableName);

                //====================是否有金额权限===================
                if (mTable.bMoneyAuth && !hasMoneyAuth)
                {
                    fields.ForEach(f =>
                    {
                        if(f.FFieldName.ToLower().Contains("amount") || f.FFieldName.ToLower().Contains("price"))
                        {
                            fields.Remove(f);
                        }
                    });
                }
                //======================================================

                var minfo = new ModelSqlInfo()
                {
                    TableInfo = x,
                    SQL_Select = GetSelectSql(x, fields),
                    SQL_Insert = GetInsertSql(x, fields),
                    SQL_Update = GetUpdateSql(x, fields),
                    SQL_Delete = GetDeleteSql(tranInfo, x.FTableName),
                    SQL_List = tranInfo.FListSQL
                };
                mSqlList.Add(minfo);
            });

            return mSqlList;
        }

 
        /// <summary>
        /// 生成SelectSQL
        /// </summary>
        private static string GetSelectSql(ICTableInfo tableInfo, List<ICTableField> fields)
        {
            string tableName = tableInfo.FTableName;

            //查询字段
            List<string> fieldList = new List<string>();
            //查询表
            HashSet<string> hashset = new HashSet<string>();
 
            fields.ForEach(x =>
            {
                if(!string.IsNullOrEmpty(x.FFormula))
                {
                    fieldList.Add(x.FFormula + " as " + x.FFieldName);
                }
                else if (!string.IsNullOrEmpty(x.FRefTable))
                {
                    //查询字段(table.FieldName)
                    var refTable = string.IsNullOrEmpty(x.FRefTableAliases) ? x.FRefTable : x.FRefTableAliases;
                    fieldList.Add(refTable + "." + x.FRefField + " as " + x.FFieldName);

                    //查询关联表(table as aliasesName)
                    string str = string.IsNullOrEmpty(x.FRefTableAliases) ? x.FRefTable : x.FRefTable + " as " + x.FRefTableAliases;
                    if (x.FKeyField.Contains("."))
                    {
                        str += " on " + x.FKeyField + " = " + refTable + "." + x.FRefKeyField;
                        //附加关联条件
                        if (!string.IsNullOrEmpty(x.FConditions))
                        {
                            str += " and " + x.FConditions;
                        }
                    }
                    else
                    {
                        str += " on T." + x.FKeyField + " = " + refTable + "." + x.FRefKeyField;
                        //附加关联条件
                        if (!string.IsNullOrEmpty(x.FConditions))
                        {
                            str += " and " + refTable + "." + x.FConditions;
                        }
                    }

                    hashset.Add(str);
                }
                else
                {
                    fieldList.Add("T." + x.FFieldName);
                }
            });

            StringBuilder sb = new StringBuilder("select ");
            sb.Append(string.Join(",", fieldList.ToArray()));
            sb.Append(" from " + tableName + " T");

            if (hashset.Count > 0)
            {
                sb.Append(" left join ");
            }
            sb.Append(string.Join(" left join ", hashset.ToArray()));

            return sb.ToString();
        }

        /// <summary>
        /// 生成InsertSQL
        /// </summary>
        private static string GetInsertSql(ICTableInfo tableInfo, List<ICTableField> fields)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();

            string tableName = tableInfo.FTableName;

            //var fields = ICTableDAL.GetTableFields(tableInfo.FID, tableInfo.FTableName);

            if (fields.Find(x => x.bInsert) == null)
            {
                return null;
            }

            sb.Append("insert into " + tableName + "(");

            fields.ForEach(x =>
            {
                if (x.bInsert)
                {
                    sb.Append(x.FFieldName + ", ");
                    sb2.Append("@" + x.FFieldName + ", ");
                }
            });

            sb.Remove(sb.Length - 2, 2);
            sb2.Remove(sb2.Length - 2, 2);

            sb.Append(")");

            if (tableInfo.PK_identity)
            {
                sb.Append(" output inserted." + tableInfo.FPKName);
            }

            sb.Append(" values (");
            sb.Append(sb2.ToString() + ")");

            return sb.ToString();

        }

        /// <summary>
        /// 生成UpdateSQL
        /// </summary>
        private static string GetUpdateSql(ICTableInfo tableInfo, List<ICTableField> fields)
        {
            string tableName = tableInfo.FTableName;

            //var fields = ICTableDAL.GetTableFields(tableInfo.FID, tableInfo.FTableName);

            if (fields.Find(x => x.bUpdate) == null)
            {
                return null;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("update " + tableName + " set ");

            fields.ForEach(x =>
            {
                if (x.bUpdate)
                {
                    sb.Append(x.FFieldName + " = @" + x.FFieldName + ", ");
                }
            });

            sb.Remove(sb.Length - 2, 2);
            sb.Append(" where " + tableInfo.FPKName + " = @" + tableInfo.FPKName);

            return sb.ToString();
        }

        /// <summary>
        /// 生成DeleteSQL
        /// </summary>
        private static string GetDeleteSql(ICTransType tranInfo, string fTableName)
        {
            var tableInfo = tranInfo.Tables.Find(x => x.FTableName == fTableName);

            string sql = "";
            if (!tableInfo.bSlave)
            {
                tranInfo.Tables.ForEach(x =>
                {
                    sql += ";delete from " + x.FTableName + " where " + tableInfo.FPKName + " = @" + tableInfo.FPKName;
                });
            }
            else
            {
                sql = "delete from " + tableInfo.FTableName + " where " + tableInfo.FPKName + " = @" + tableInfo.FPKName;
            }

            return sql;
        }

    }
}
