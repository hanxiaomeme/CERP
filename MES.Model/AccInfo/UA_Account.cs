using System;
namespace LanyunMES.Entity
{
    /// <summary>
    /// UnitInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class UA_Account
    {
        public string cAcc_Id { get; set; }
        public string cAcc_Name { get; set; }
        public string cUnitName { get; set; }
        public string iYear { get; set; }
    }
}

