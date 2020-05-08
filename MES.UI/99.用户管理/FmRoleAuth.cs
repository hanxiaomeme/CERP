using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;


namespace LanyunMES.UI
{
    using DevComponents.AdvTree;
    using Entity;
    using Business;

    public partial class FmRoleAuth : DevComponents.DotNetBar.OfficeForm
    {
        public FmRoleAuth(int roleId)
        {
            InitializeComponent();

            this.Role = business.GetRoleUserDTO(roleId);
        }

        private RoleService business = new RoleService();
        public Role Role { get; private set; }

        private void LoadData()
        {
            //UserModuleAuthManager m = new UserModuleAuthManager();
            //try
            //{
            //   this.LoadModleAuth(this.advTree1, m.GetList(userid).Tables[0]);
            //}
            //catch (Exception ex)
            //{
            //    MsgBox.ShowInfoMsg(ex.ToString());
            //}
        }

        private void FmUserAuth_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void advTree1_AfterCheck(object sender, DevComponents.AdvTree.AdvTreeCellEventArgs e)
        {
            this.advTree1.AfterCheck -= advTree1_AfterCheck;

            Node node = e.Cell.Parent;

            //级联更改子节点状态
            this.SetChildCheck(node);
    
            //更新父节点状态
            this.SetParentCheck(node);

            this.advTree1.AfterCheck += advTree1_AfterCheck;
        }


        private void LoadModleAuth(AdvTree tree, DataTable dt)
        {
            #region 加载用户权限表
            Node[] nodes = new Node[10];
            foreach (DataRow row in dt.Rows)
            {
                int grade = Convert.ToInt32(row["grade"]);

                nodes[grade] = new Node(row["ModuleName"].ToString());
                nodes[grade].Name = row["ModuleCode"].ToString();
                nodes[grade].CheckBoxVisible = true;

                if (Convert.ToBoolean(row["HasAuth"]))
                {
                    nodes[grade].Checked = true;
                }

                if (row["userType"].ToString() == "R")
                {
                    nodes[grade].Enabled = false;
                    nodes[grade].Tag = "R";
                }
                else
                {
                    nodes[grade].Tag = "U";
                }

                if (grade > 1)
                {
                    nodes[grade - 1].Nodes.Add(nodes[grade]);
                }
                else if (grade == 1)
                {
                    tree.Nodes.Add(nodes[grade]);
                }
            }
            #endregion         
        }

        private void SetChildCheck(Node node)
        {
            #region 设置子节点状态
            if (node.Nodes.Count > 0)
            {
                foreach (Node n in node.Nodes)
                {
                    n.Checked = node.Checked;
                    if (n.Nodes.Count > 0)
                    {
                        SetChildCheck(n);
                    }
                }
            } 
            #endregion
        }

        private void SetParentCheck(Node node)
        {
            #region 设置父节点状态
            while (node.Parent != null && node.Parent is Node)
            {
                bool childChecked = false;
                foreach (Node n in node.Parent.Nodes)
                {
                    if (n.Checked)
                    {
                        childChecked = true;
                        break;
                    }
                }

                node.Parent.Checked = childChecked;

                node = node.Parent;
            } 
            #endregion
        }
    }

    public class TNode
    {
        public string id { get; set; }
        public string text { get; set; }
        public bool Checked { get; set; }
        public List<TNode> children { get; set; }
    }


}