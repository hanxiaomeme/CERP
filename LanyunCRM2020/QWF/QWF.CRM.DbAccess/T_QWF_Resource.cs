//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace QWF.CRM.DbAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_QWF_Resource
    {
        public int RuleId { get; set; }
        public string ResourceCode { get; set; }
        public string ResourceName { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public Nullable<int> UpdateUserId { get; set; }
        public int ResourceType { get; set; }
        public string ResourceRemarks { get; set; }
    }
}
