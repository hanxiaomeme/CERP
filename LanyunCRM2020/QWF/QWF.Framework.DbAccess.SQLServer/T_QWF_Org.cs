//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace QWF.Framework.DbAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_QWF_Org
    {
        public int OrgId { get; set; }
        public string OrgCode { get; set; }
        public string OrgName { get; set; }
        public string OrgNamePath { get; set; }
        public int OrgAttribute { get; set; }
        public int IsOut { get; set; }
        public int ParentId { get; set; }
        public int LayerId { get; set; }
        public string OrgIdList { get; set; }
        public string OrgCodeList { get; set; }
        public int SortId { get; set; }
        public int IsDelete { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public int IsSubNode { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> CreateUserId { get; set; }
        public Nullable<int> UpdateUserId { get; set; }
    }
}
