using QWF.Framework.GlobalException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Services.BLL
{
    internal class ConfigHelper
    {
        public DbAccess.DbFrameworkContext DbContext { get; private set; }
        public SvrModels.SvrUserIdentifier SvrUser { get; private set; }

        public ConfigHelper(DbAccess.DbFrameworkContext db, Services.SvrModels.SvrUserIdentifier svrUser)
        {
            this.DbContext = db;
            this.SvrUser = svrUser;
        }

        public Config GetConfigNode(int menuId)
        {
            var dbModel = DbContext.T_QWF_Config.Where(w => w.ConfigId == menuId).FirstOrDefault();

            return dbModel == null ? null : new Config(dbModel, this);

        }
        public Config CreateConfigNode(int parentId, string configName)
        {

            var dbModel = new DbAccess.T_QWF_Config();

            dbModel.ConfigName = configName;
            dbModel.ParentId = parentId;

            dbModel.CreateTime = SvrUser.CurrentTime;
            dbModel.CreateUserId = SvrUser.UserId;

            //关键参数
            string configIdList = string.Empty;
            if (parentId == 0)
            {
                //顶级节点
                dbModel.LayerId = 1;
                dbModel.SortId = 0;
                configIdList = ",";
            }
            else
            {
                //找到父节点信息
                var dbParentNode = DbContext.T_QWF_Config.Where(w => w.ConfigId == parentId && w.IsDelete == 0).FirstOrDefault();
                if (dbParentNode == null)
                    throw new UIValidateException("上级节点信息获取失败");

                //设置当前节点信息
                dbModel.LayerId = dbParentNode.LayerId + 1;//层级+1
                configIdList = dbParentNode.ConfigIdList;

                var qrySort = DbContext.T_QWF_Config.Where(w => w.ParentId == parentId && w.IsDelete == 0);
                if (qrySort.Count() == 0)
                {
                    dbModel.SortId = 1;
                }
                else
                {
                    //获取父接点下的子节点最大的SortId + 1
                    dbModel.SortId = qrySort.Max(m => m.SortId) + 1;

                }

                //更新父节点的IsSubNode
                dbParentNode.IsSubNode = 1;

            }

            //这里要获取到自增ID，只能这样做了
            DbContext.T_QWF_Config.Add(dbModel);
            DbContext.SaveChanges();

            //这里再修改OrgIdList;
            dbModel.ConfigIdList = configIdList + dbModel.ConfigId + ",";


            return new Config(dbModel, this);
        }




    }
}
