using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QWF.Framework.ExtendUtils;
namespace QWF.CRM.Utils
{
    public class PermissionUtils
    {
        private QWF.Framework.Services.SvrModels.SvrShortUserInfo shortUserInfo;

        /// <summary>
        /// 当前用户的主要信息
        /// </summary>
        public QWF.Framework.Services.SvrModels.SvrShortUserInfo ShortUserInfo
        {
            get { return shortUserInfo; }
        }

        public PermissionUtils(QWF.Framework.Services.SvrModels.SvrShortUserInfo shortUserInfo)
        {
            this.shortUserInfo = shortUserInfo;
        }


        /// <summary>
        /// 外部调用 快捷入口 
        /// </summary>
        /// <returns></returns>
        public static PermissionUtils Create()
        {
            var curUser = QWF.Framework.Web.UserContext.GetCurrentInfo();
            return new PermissionUtils(curUser);
        }

        #region 常用公共权限辅助方法
        /// <summary>
        /// 获取当前用户的可以管理的子级ID
        /// </summary>
        /// <returns></returns>
        public List<int> GetSubOrgIdList()
        {
            var list = new List<int>();
            using (var db = DbAccess.DbCRMContext.Create())
            {
                list = db.T_QWF_Org.AsNoTracking().Where(w => w.OrgIdList.Contains("," + ShortUserInfo.CurrentOrgId + ",")).Select(s => s.OrgId).ToList();
            }
            return list;
        }

        /// <summary>
        /// 本人的客户
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        public bool IsMyCustomer(string customerCode)
        {
            var userCode = GetCustomerUserByCode(customerCode);

            return userCode == ShortUserInfo.CurrentUserCode ? true : false;
        }

        /// <summary>
        /// 本组/本节点下的可以管理的单个客户
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        public bool IsMyGroupCustomer(string customerCode)
        {
            using (var db = DbAccess.DbCRMContext.Create())
            {
                var userCode = GetCustomerUserByCode(customerCode);
                var orgId = db.T_QWF_User.Where(w => w.UserCode == userCode && w.IsDelete == 0).Select(s => s.OrgId).FirstOrDefault();

                if (orgId == 0)
                    return false;

                var curUserSubOrgIds = GetSubOrgIdList();
                //如果客户信息对应的创建人所在机构，是当前用户可以管理的机构的节点下，则表示为本组用户
                if (curUserSubOrgIds.Where(id => id == orgId).Count() > 0)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 获取客户对应的用户
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns>用户编码</returns>
        private string GetCustomerUserByCode(string customerCode)
        {
            using (var db = DbAccess.DbCRMContext.Create())
            {
                string sql = string.Format("select CreateUser from TB_Customer Where CustomerCode = '{0}' and Deleted=0 ",
                    customerCode, ShortUserInfo.CurrentUserCode);
                string userCode = db.Database.SqlQuery<string>(sql).FirstOrDefault();
                return userCode;
            }
        }

        #endregion

        #region 系统内置角色
        /// <summary>
        /// 系统管理员
        /// </summary>
        /// <returns></returns>
        public bool IsAdministrator()
        {
            return ShortUserInfo.IsAdministrator();
        }
        /// <summary>
        /// CRM 管理员
        /// </summary>
        /// <returns></returns>
        public bool IsCRMAdministrator()
        {
            return ShortUserInfo.IsAuthorization("qcrm.administrator");
        }
        #endregion


        #region 对客户信息的CRUD
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        public bool IsReadCustomer(string customerCode)
        {
            // 系统管理员，CRM管理员，指定可以读取全部的权限
            if (IsAdministrator() || IsCRMAdministrator() || ShortUserInfo.IsAuthorization("qcrm.customer.all.list"))
                return true;

            if (IsMyCustomer(customerCode))
            {
                //系统默认可以读取自己客户的数据
                return true;
            }
            else if (ShortUserInfo.IsAuthorization("qcrm.customer.all.list") && IsMyGroupCustomer(customerCode))
            {
                //读取本组数据
                return true;
            }
            return false;
        }
        /// <summary>
        /// 是否能更新指定客户信息
        /// </summary>
        /// <returns></returns>
        public bool IsUpdateCustomer(string customerCode)
        {
            // 系统管理员，CRM管理员 白呢也指定可以编辑全部的权限
            if ((IsAdministrator() || IsCRMAdministrator()) && ShortUserInfo.IsAuthorization("crm.customer.all.edit"))
                return true;

            //系统默认编辑自己的客户
            if (IsMyCustomer(customerCode))
            {
                return true;
            }
            else if (ShortUserInfo.IsAuthorization("qcrm.customer.mygroup.edit") && IsMyGroupCustomer(customerCode))
            {
                //可以管理本节点下的数据
                return true;
            }

            return false;
        }

        /// <summary>
        /// 是否能删除指定客户信息
        /// </summary>
        /// <returns></returns>
        public bool IsDeleteCustomer(string customerCode)
        {
            // 系统管理员 并且 需要单独配置删除全部的权限
            if (IsAdministrator() && ShortUserInfo.IsAuthorization("qcrm.customer.all.del"))
                return true;

            if (ShortUserInfo.IsAuthorization("qcrm.customer.self.del") && IsMyCustomer(customerCode))
            { //删除本人数据
                return true;
            }
            else if (ShortUserInfo.IsAuthorization("qcrm.customer.mygroup.del") && IsMyGroupCustomer(customerCode))
            {
                //删除本组/本节点的数据
                return true;
            }
            return false;
        }

        /// <summary>
        /// 可以转移客户
        /// </summary>
        /// <returns></returns>
        public bool IsChangCustomer()
        {
            if (IsAdministrator() || IsCRMAdministrator() || ShortUserInfo.IsAuthorization("qcrm.customer.change"))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 显示前端页面的Button
        /// </summary>
        /// <param name="ActoinType"></param>
        /// <returns></returns>
        public bool ShowButtonResource(string actoinType)
        {
            var userId = this.shortUserInfo.CurrentUserId;
            if (userId == 0)
                return false;
            //获取当前是否 新增，修改，删除的数据的权限，大颗粒度
            if (actoinType == "create")
                return true;
            if (actoinType == "update")
                return true;
            if (actoinType == "delete")
            {
                if (ShortUserInfo.IsAuthorization("qcrm.customer.my.del")
                   || ShortUserInfo.IsAuthorization("qcrm.customer.mygroup.del")
                   || ShortUserInfo.IsAuthorization("qcrm.customer.all.del"))
                    return true;
            }

            return false;
        }

        #endregion


        public List<Models.FnEmpItem> GetFuEmpList()
        {
            using (var db = DbAccess.DbCRMContext.Create())
            {
                var userType = (int)GetUserType();
                var dataRange = (int)GetDataRange();
                var sql = string.Format(@"select * from dbo.F_EmpList({0},{1},{2}) ",
                userType, dataRange, shortUserInfo.CurrentUserId);
                return db.Database.SqlQuery<Models.FnEmpItem>(sql).ToList();
            }
        }

        public List<Models.FnEmpItem> GetAllEpmList()
        {
            using (var db = DbAccess.DbCRMContext.Create())
            {
                var userType = (int)Models.PermissionUserType.CrmAdmin;
                var dataRange = (int)Models.PermissionDataRange.All;
                var sql = string.Format(@"select * from dbo.F_EmpList({0},{1},{2}) ",
                userType, dataRange, shortUserInfo.CurrentUserId);
                return db.Database.SqlQuery<Models.FnEmpItem>(sql).ToList();
            }
        }

        /// <summary>
        /// 获取用户类型
        /// </summary>
        /// <returns></returns>
        public Models.PermissionUserType GetUserType()
        {
            if (IsAdministrator())
                return Models.PermissionUserType.SystemAdmin;
            if (IsCRMAdministrator())
                return Models.PermissionUserType.CrmAdmin;

            return Models.PermissionUserType.User;
        }

        /// <summary>
        /// 获取用户的数据范围
        /// </summary>
        /// <returns></returns>
        public Models.PermissionDataRange GetDataRange()
        {

            if (shortUserInfo.IsAuthorization("qcrm.customer.all.list") || IsAdministrator() || IsCRMAdministrator())
                return Models.PermissionDataRange.All;

            if (shortUserInfo.IsAuthorization("qcrm.customer.mygroup.list"))
                return Models.PermissionDataRange.Group;

            return Models.PermissionDataRange.Self;
        }



    }
}
