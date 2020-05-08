using QWF.Framework.GlobalException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Services
{
    public class ConfigServices
    {
        private SvrModels.SvrUserIdentifier svrUser;

        public ConfigServices(SvrModels.SvrUserIdentifier svrUser)
        {
            this.svrUser = svrUser;
        }

        /// <summary>
        /// configId, sortId
        /// </summary>
        /// <param name="dic"> 数据集合 key=configid,value=sortid</param>
        /// <returns></returns>
        public bool ConfigTreeSort(Dictionary<int, int> dic)
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                foreach (var d in dic)
                {
                    var dbModel = db.T_QWF_Config.Where(w => w.ConfigId == d.Key).FirstOrDefault();
                    if (dbModel != null)
                        dbModel.SortId = d.Value;

                }
                db.SaveChanges();
            }
            return true;
        }
        /// <summary>
        /// 添加配置表节点
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="configName"></param>
        /// <returns></returns>
        public int AddConfig(int parentId, string configName)
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var helper = new BLL.ConfigHelper(db, svrUser);
                var config = helper.CreateConfigNode(parentId, configName);

                db.SaveChanges();
                return config.ConfigId;

            }
        }

        public bool EditConfig(int oldParentId, SvrModels.SvrConfigInfo svrModel)
        {
            var checkModel = QWF.Framework.Validation.ValidationHelper.Validate(svrModel);
            if (!checkModel.IsValid)
                throw new UIValidateException("数据验证失败！" + checkModel.ToString());


            //
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var helper = new BLL.ConfigHelper(db, this.svrUser);
                var config = helper.GetConfigNode(svrModel.ConfigId);

                if (config == null)
                    throw new UIValidateException("配置节点不存在，ID=" + svrModel.ConfigId);

                config.UpdateConfigNode(oldParentId, svrModel);
                db.SaveChanges();
                return true;
            }
        }

        public bool DeleteConfig(int configId)
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var helper = new BLL.ConfigHelper(db, this.svrUser);
                var config = helper.GetConfigNode(configId);

                if (config == null)
                    throw new UIValidateException("配置节点不存在，ID=" + configId);

                config.Delete();
                db.SaveChanges();
                return true;
            }
        }

        public bool HiddenConfig(int configId)
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var helper = new BLL.ConfigHelper(db, this.svrUser);
                var config = helper.GetConfigNode(configId);

                if (config == null)
                    throw new UIValidateException("配置节点不存在，ID=" + configId);

                config.Hidden();
                db.SaveChanges();
                return true;
            }
        }

        public bool ShowConfig(int configId)
        {
            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var helper = new BLL.ConfigHelper(db, this.svrUser);
                var config = helper.GetConfigNode(configId);

                if (config == null)
                    throw new UIValidateException("配置节点不存在，ID=" + configId);

                config.Show();
                db.SaveChanges();
                return true;
            }
        }


        /// <summary>
        /// 获取系统配置表的字节点集合
        /// </summary>
        public List<SvrModels.SvrConfig> GetNodeItemsByCode(string code,bool showHide=false)
        {
            var items = new List<SvrModels.SvrConfig>();

            using (var db = DbAccess.DbFrameworkContext.Create())
            {
                var dbModel = db.T_QWF_Config.Where(w => w.ConfigResourceCode == code).FirstOrDefault();
                if(dbModel !=null)
                {
                    var qry = db.T_QWF_Config.Where(w => w.IsDelete == 0 && w.ParentId == dbModel.ConfigId);
                    if (!showHide)
                        qry =qry.Where(w => w.IsHidden == 0);

                    items = qry.OrderBy(o=>o.SortId).Select(s => new SvrModels.SvrConfig
                    {
                        Id = s.ConfigId,
                        Name = s.ConfigName,
                        Value = s.ConfigValue,
                        IsHide = s.IsHidden == 0 ? true : false
                    }).ToList();
                }
                
            }

            return items;
        }

    }
}
