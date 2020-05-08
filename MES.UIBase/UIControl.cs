using DevComponents.AdvTree;
using DevComponents.DotNetBar;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LanyunMES.UIBase
{
    using LanyunMES.Entity;
    using System.Drawing;

    public class TreeHelper
    {
        public static void LoadAdvTree<T>(AdvTree tree, List<T> iModels, EventHandler NodeClick, bool showCode = true)
            where T:ITreeItem
        {
            #region 加载AdvTree数据
            Node rootNode = tree.Nodes.Count > 0 ? tree.Nodes[0] : null;
            Node[] nodes = new Node[10];

            foreach (var iModel in iModels)
            {
                nodes[iModel.FLevel] = new Node();

                if (showCode)
                    nodes[iModel.FLevel].Text = iModel.FNumber + " - " + iModel.FName;
                else
                    nodes[iModel.FLevel].Text = iModel.FName;

                nodes[iModel.FLevel].Name = iModel.FNumber;
                nodes[iModel.FLevel].Tag = new string[] { iModel.FNumber, iModel.FName };
                nodes[iModel.FLevel].NodeClick += new EventHandler(NodeClick);
                if (tree.ImageList != null)
                {
                    nodes[iModel.FLevel].Image = tree.ImageList.Images[0];
                }
                if (iModel.FLevel > 1)
                {
                    nodes[iModel.FLevel - 1].Nodes.Add(nodes[iModel.FLevel]);
                }
                else if (iModel.FLevel == 1)
                {
                    //判断是否存在根节点
                    if (rootNode != null)
                        rootNode.Nodes.Add(nodes[1]);
                    else
                        tree.Nodes.Add(nodes[1]);
                }
            } 
            #endregion
        }

        public static void LoadAdvTree(AdvTree tv, DataView dv, string codeColName, string txtColName, string gradeColName, string isEndColName, EventHandler NodeClick, bool showCode)
        {
            #region 加载树AdvTree
            Node rootNode = null;
            if (tv.Nodes.Count > 0)
            {
                rootNode = tv.Nodes[0];
            }

            Node[] nodes = new Node[10];
            foreach (DataRowView drv in dv)
            {
                int i = int.Parse(drv[gradeColName].ToString());

                if (showCode)
                    nodes[i] = new Node(drv[codeColName].ToString() + " - " + drv[txtColName].ToString());
                else
                    nodes[i] = new Node(drv[txtColName].ToString());

                nodes[i].Tag = new string[] { drv[codeColName].ToString(), drv[txtColName].ToString() };
                nodes[i].Name = drv[codeColName].ToString();

                if (!string.IsNullOrEmpty(isEndColName))
                {
                    if ((bool)drv[isEndColName] == true )
                    {
                        nodes[i].NodeClick += new EventHandler(NodeClick);
                        nodes[i].Image = tv.ImageList.Images[0];
                    }
                }
                else
                {
                    nodes[i].NodeClick += new EventHandler(NodeClick);
                    nodes[i].Image = tv.ImageList.Images[0];
                }
                if (i > 1)
                {
                    nodes[i - 1].Nodes.Add(nodes[i]);
                }
                else if (i == 1)
                {
                    //判断是否存在根节点
                    if (rootNode != null)
                        rootNode.Nodes.Add(nodes[i]);
                    else
                        tv.Nodes.Add(nodes[i]);
                }
            }
            #endregion
        }

        public static void LoadTVData(TreeView tv, DataView dv, string codeColName, string txtColName, string gradeColName, string isEndColName, bool showCode)
        {
            #region 加载树TreeView
            TreeNode rootNode = tv.Nodes[0];
            TreeNode[] nodes = new TreeNode[10];
            foreach (DataRowView drv in dv)
            {
                int i = int.Parse(drv[gradeColName].ToString());

                if (showCode)
                    nodes[i] = new TreeNode(drv[codeColName].ToString() + " - " + drv[txtColName].ToString());
                else
                    nodes[i] = new TreeNode(drv[txtColName].ToString());

                nodes[i].Tag = drv[codeColName].ToString();
                if (drv[isEndColName].ToString() == "1")
                {
                    nodes[i].ImageIndex = 0;
                }
                if (i > 1)
                {
                    nodes[i - 1].Nodes.Add(nodes[i]);
                }
                else if (i == 1)
                {
                    //判断是否存在根节点
                    if (rootNode != null)
                        tv.Nodes[0].Nodes.Add(nodes[i]);
                    else
                        tv.Nodes.Add(nodes[i]);
                }

                //展开根节点
                if (rootNode != null) rootNode.Expand();
            }
            #endregion
        }
    }

    public class UIControl
    {
        public static void SetStatus(Bar toolbar, Bar dbar, Control panMain, GridView grid, OpState mode)
        {
            ButtonItem item;

            if (mode == OpState.Browse)
            {
                foreach (BaseItem aitem in toolbar.Items)
                {
                    #region toolbar
                    if (aitem is ButtonItem)
                    {
                        item = aitem as ButtonItem;
                        if (item.Text.Contains("增"))
                        {
                            item.Enabled = true;
                        }
                        else if (item.Text.Contains("删"))
                        {
                            item.Enabled = true;
                        }
                        else if (item.Text.Contains("改"))
                        {
                            item.Enabled = true;
                        }
                        else if (item.Text.Contains("存"))
                        {
                            item.Enabled = false;
                        }
                        else if (item.Text.Contains("消"))
                        {
                            item.Enabled = false;
                        }
                        else if (item.Text.Contains("审"))
                        {
                            item.Enabled = true;
                        }
                        else if (item.Name.Contains("previous"))
                        {
                            item.Enabled = true;
                        }
                        else if (item.Name.Contains("next"))
                        {
                            item.Enabled = true;
                        }
                        else if (item.Name.Contains("last"))
                        {
                            item.Enabled = true;
                        }
                        else if (item.Name.Contains("first"))
                        {
                            item.Enabled = true;
                        }
                    }
                    #endregion
                }
                foreach (BaseItem aitem in dbar.Items)
                {
                    if (aitem is ButtonItem)
                    {
                        (aitem as ButtonItem).Enabled = false;
                    }
                }
                foreach (Control ctrl in panMain.Controls)
                {
                    if (ctrl is TextEdit)
                    {
                        (ctrl as TextEdit).ReadOnly = true;
                        (ctrl as TextEdit).BackColor = System.Drawing.Color.LightGray;
                    }
                    if (ctrl is ButtonEdit)
                    {
                        (ctrl as ButtonEdit).Properties.Buttons[0].Visible = false;
                    }
                }

                grid.OptionsBehavior.ReadOnly = true;
                grid.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
                grid.OptionsBehavior.Editable = false;

            }
            else if (mode == OpState.Update || mode == OpState.Add)
            {
                foreach (BaseItem aitem in toolbar.Items)
                {
                    #region toolbar
                    if (aitem is ButtonItem)
                    {
                        item = aitem as ButtonItem;

                        if (item.Text.Contains("增"))
                        {
                            item.Enabled = false;
                        }
                        else if (item.Text.Contains("删"))
                        {
                            item.Enabled = false;
                        }
                        else if (item.Text.Contains("改"))
                        {
                            item.Enabled = false;
                        }
                        else if (item.Text.Contains("存"))
                        {
                            item.Enabled = true;
                        }
                        else if (item.Text.Contains("消"))
                        {
                            item.Enabled = true;
                        }
                        else if (item.Text.Contains("审"))
                        {
                            item.Enabled = false;
                        }
                        else if (item.Name.Contains("previous"))
                        {
                            item.Enabled = false;
                        }
                        else if (item.Name.Contains("next"))
                        {
                            item.Enabled = false;
                        }
                        else if (item.Name.Contains("last"))
                        {
                            item.Enabled = false;
                        }
                        else if (item.Name.Contains("first"))
                        {
                            item.Enabled = false;
                        }
                    }
                    #endregion
                }
                foreach (BaseItem aitem in dbar.Items)
                {
                    if (aitem is ButtonItem)
                    {
                        (aitem as ButtonItem).Enabled = true;
                    }
                }
                foreach (Control ctrl in panMain.Controls)
                {
                    if (ctrl is TextEdit)
                    {
                        if ((ctrl as TextEdit).Name.Substring(0, 4).ToLower() != "txtr")
                        {
                            (ctrl as TextEdit).ReadOnly = false;
                            (ctrl as TextEdit).BackColor = System.Drawing.Color.White;
                        }
                        if (ctrl is ButtonEdit)
                        {
                            (ctrl as ButtonEdit).Properties.Buttons[0].Visible = true;
                        }
                    }
                }

                grid.OptionsBehavior.ReadOnly = false;
                grid.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
                grid.OptionsBehavior.Editable = true;
            }
        }

        /// <summary>
        /// 设置TextBox状态
        /// </summary>
        /// <param name="ctl">TextBox所在control</param>
        public static void SetTextBoxState(Control ctl)
        {
            foreach (Control c in ctl.Controls)
            {
                if (c is TextBox)
                {
                    (c as TextBox).DataBindings.Clear();
                    (c as TextBox).Clear();

                    if (c.Name.Length >= 4 && c.Name.Substring(0, 4).ToLower() == "txtr")
                    {
                        (c as TextBox).ReadOnly = true;
                        c.BackColor = SystemColors.ControlLight;
                    }
                    if (c.Name.Length >= 4 && c.Name.Substring(0, 4).ToLower() == "txtw")
                    {
                        (c as TextBox).ReadOnly = false;
                        c.BackColor = SystemColors.Window;
                    }
                }
            }
        }
    }

}
