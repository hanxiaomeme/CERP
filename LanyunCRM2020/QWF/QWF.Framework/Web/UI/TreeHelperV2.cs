using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Web.UI
{

    public class BaseTreeNode
    {
        /// <summary>
        /// 树主键ID
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 树节点名称
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string text { get; set; }

        /// <summary>
        /// 展开或关闭
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string state { get; set; }

        ///// <summary>
        ///// 设置默认选中，不用设置
        ///// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string selected { get; set; }
        /// <summary>
        /// 动态附加属性
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public dynamic attributes { get; set; }

        /// <summary>
        /// 子节点,不用设置
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<BaseTreeNode> children { get; set; }
        /// <summary>
        /// 图标CSS
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string iconCls { get; set; }

        //checked 是关键字，只能通过PropertyName来指定
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore,PropertyName ="checked")]
        public bool? checkbox { get; set; }
    }

    /// <summary>
    /// Tree转化类
    /// </summary>
    /// <typeparam name="T">需要的转化的对象</typeparam>
    public class TreeConverter<T> where T : class
    {

        /// <summary>
        /// 关闭第几层，默认全部暂开
        /// </summary>
        public int ClosedLayer { get; set; }

        /// <summary>
        /// 设置/获取 主键ID
        /// </summary>
        public Func<T, string> GetId
        {
            get;
            set;
        }
        /// <summary>
        /// 设置/父ID 父ID
        /// </summary>
        public Func<T, string> GetParentId
        {
            get;
            set;
        }

        /// <summary>
        /// checked "true","false"
        /// </summary>
        public Func<T, bool?> GetCheckbox
        {
            get;
            set;
        }

        /// <summary>
        /// 设置 选中的ID
        /// </summary>
        public string SetSelectedId { get; set; }

        /// <summary>
        /// 转化成List的树结构
        /// </summary>
        /// <param name="func">需要映射树结构<->集合数据 的方法</param>
        /// <param name="items">数据集合</param>
        /// <param name="parentId">父节点ID,0或空则全部树</param>
        /// <returns></returns>
        public List<BaseTreeNode> ConvertTo(Func<T, BaseTreeNode> func, List<T> items, string parentId)
        {
            List<BaseTreeNode> nodes = new List<BaseTreeNode>();

            if (string.IsNullOrEmpty(parentId))
                parentId = "0";

            int layer = 1;

            var rootItems = items.Where(m => { return this.GetParentId(m) == parentId; }).ToList();

            foreach (var rootItem in rootItems)
            {
                var node = func(rootItem);
                if(GetCheckbox != null)
                {
                    node.checkbox = GetCheckbox(rootItem);
                }
               

                if (this.ClosedLayer == 0)
                {
                    node.state = "open";
                }
                else
                {
                    if (layer >= this.ClosedLayer)
                    {
                        if (items.Find(m => { return this.GetParentId(m) == node.id; }) != null)
                        {
                            node.state = "closed";
                        }
                    }
                    else
                    {
                        node.state = "open";
                    }
                }
                node.selected = node.id == SetSelectedId ? "true" : null;

                //是否有字节点
                var childItem = items.Find(m => { return this.GetParentId(m) == node.id; });
                if (childItem != null)
                {
                    node.children = new List<BaseTreeNode>();
                    ConvertToChildren(func, node, items, layer);
                }

                nodes.Add(node);
            }
            return nodes;
        }

        private void ConvertToChildren(Func<T, BaseTreeNode> func, BaseTreeNode fnode, List<T> items, int layer)
        {

            layer++;
            foreach (var item in items)
            {
                if (this.GetParentId(item) != fnode.id) continue;

                var node = func(item);
                if (GetCheckbox != null)
                {
                    node.checkbox = GetCheckbox(item);
                }
                if (this.ClosedLayer == 0)
                {
                    node.state = "open";
                }
                else
                {
                    if (layer >= this.ClosedLayer)
                    {
                        if (items.Find(m => { return this.GetParentId(m) == node.id; }) != null)
                        {
                            node.state = "closed";
                        }
                    }
                    else
                    {
                        node.state = "open";
                    }
                }

                //是否有字节点
                var childItem = items.Find(m => { return this.GetParentId(m) == node.id; });
                if (childItem != null)
                {
                    node.children = new List<BaseTreeNode>();
                    ConvertToChildren(func, node, items, layer);
                }

                fnode.children.Add(node);

            }
        }
    }
}
