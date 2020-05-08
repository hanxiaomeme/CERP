using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanyunMES.Entity
{
    public class Menu: ITreeItem
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        public int FItemID { get; set; }

        /// <summary>
        /// 菜单编码
        /// </summary>
        public string FNumber { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string FName { get; set; }

        public int MenuType { get; set; } = 1;

        /// <summary>
        /// 层级
        /// </summary>
        public int FLevel { get; set; }

        /// <summary>
        /// 类库名称
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 类名(完整名称)
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 是否停用
        /// </summary>
        public bool IsStop { get; set; }

        /// <summary>
        /// 是否末级
        /// </summary>
        public bool IsEnd { get; set; }

        /// <summary>
        /// 参数
        /// </summary>
        public string Params { get; set; }

        /// <summary>
        /// 显示类型(0:标签, 1:弹窗)
        /// </summary>
        public int ShowStyle { get; set; } = 0;
    }
}
