using DevComponents.AdvTree;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using DevComponents.Editors.DateTimeAdv;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using LanyunMES.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace LanyunMES.UI
{
    using Business;
    using Common;

    public class TreeHelper
    {
        public static void LoadAdvTree<T>(AdvTree tree, List<T> treeList, EventHandler NodeClick, bool showCode = true)
            where T: ITreeItem
        {
            #region 加载AdvTree数据
            Node rootNode = tree.Nodes.Count > 0 ? tree.Nodes[0] : null;
            Node[] nodes = new Node[10];

            if(rootNode != null)
            {
                rootNode.Nodes.Clear();
            }
            else
            {
                tree.Nodes.Clear();
            }

            foreach (var item in treeList)
            {
                nodes[item.FLevel] = new Node();

                if (showCode)
                    nodes[item.FLevel].Text = item.FNumber + " - " + item.FName;
                else
                    nodes[item.FLevel].Text = item.FName;

                nodes[item.FLevel].Name = item.FNumber;
                nodes[item.FLevel].Tag = item;
                if (NodeClick != null)
                {
                    nodes[item.FLevel].NodeClick += new EventHandler(NodeClick);
                }
                if (tree.ImageList != null)
                {
                    nodes[item.FLevel].Image = tree.ImageList.Images[0];
                }
                if (item.FLevel > 1)
                {
                    nodes[item.FLevel - 1].Nodes.Add(nodes[item.FLevel]);
                }
                else if (item.FLevel == 1)
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
        /// <summary>
        /// 设置单据UI控件状态
        /// </summary>
        /// <param name="control"></param>
        /// <param name="status"></param>
        public static void SetStatus(Control control, UIStatus status)
        {
            foreach (Control ctrl in control.Controls)
            {
                if (ctrl is Bar)
                {
                    SetBarStatus(ctrl as Bar, status);
                }
                else if (ctrl is GridControl)
                {
                    #region GridView状态
                    var view = (ctrl as GridControl).MainView;

                    if(status == UIStatus.Browse)
                    {
                        (ctrl as GridControl).DataSource = null;
                    }
                    if (status == UIStatus.Add || status == UIStatus.Edit)
                    {
                        (view as GridView).OptionsBehavior.Editable = true;
                        (view as GridView).OptionsBehavior.ReadOnly = false;
                        (view as GridView).OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
                    }
                    else
                    {
                        (view as GridView).OptionsBehavior.Editable = false;
                        (view as GridView).OptionsBehavior.ReadOnly = true;
                        (view as GridView).OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
                    }
                    #endregion
                }
                else if(ctrl is DataGridView)
                {
                    var grid = ctrl as DataGridView;
                    grid.ReadOnly = (status == UIStatus.Browse || status == UIStatus.Audit);
                }
                else if (ctrl is Panel)
                {
                    SetStatus(ctrl as Panel, status);
                }
                else if(ctrl is SplitContainer)
                {
                    var sp = ctrl as SplitContainer;
                    SetStatus(sp.Panel1, status);
                    SetStatus(sp.Panel2, status);
                }
                else
                {
                    SetCtrlStatus(ctrl, status);
                }
            }
        }

        public static void SetStatus(Bar toolbar, Control panMain, UIStatus status)
        {
            SetBarStatus(toolbar, status);
           
            foreach (Control ctrl in panMain.Controls)
            {
                if (ctrl is Panel)
                {
                    SetStatus(ctrl as Panel, status);
                }
                else
                {
                    SetCtrlStatus(ctrl, status);
                }
            }
        }


        /// <summary>
        /// 设置DotNetBar 按钮状态
        /// </summary>
        private static void SetBarStatus(Bar bar,  UIStatus status)
        {
            #region 设置按钮状态
            foreach (BaseItem item in bar.Items)
            {
                if (!(item is ButtonItem)) continue;

                var statusInfo = UIControlStatusService.Get(item.Name);
                if (statusInfo == null)
                {
                    continue;
                }
                switch (status)
                {
                    case UIStatus.Browse:
                        item.Enabled = statusInfo.sBrowse;
                        break;
                    case UIStatus.Add:
                        item.Enabled = statusInfo.sAdd;
                        break;
                    case UIStatus.Edit:
                        item.Enabled = statusInfo.sEdit;
                        break;
                    case UIStatus.Audit:
                        item.Enabled = statusInfo.sAudit;
                        break;
                    default:
                        item.Enabled = false;
                        break;
                }
            }
            #endregion
        }

        private static void SetCtrlStatus(Control editCtrl, UIStatus status)
        {
            #region 基本Eidt空间

            if (status == UIStatus.Browse)
            {
                if (editCtrl is TextBox)
                {
                    (editCtrl as TextBox).Text = "";
                }
            }

            if (status == UIStatus.Add || status == UIStatus.Edit)
            {
                if (editCtrl is TextBoxX)
                {
                    (editCtrl as TextBoxX).ButtonCustom.Visible = (editCtrl as TextBoxX).ButtonCustom.Tooltip == "" ? false : true;
                }

                if (editCtrl is TextBox)
                {
                    if ((editCtrl as TextBox).Name.Substring(0, 4).ToLower() != "txtr")
                    {
                        (editCtrl as TextBox).ReadOnly = false;
                        (editCtrl as TextBox).BackColor = Color.White;
                    }
                    else
                    {
                        (editCtrl as TextBox).ReadOnly = true;
                        (editCtrl as TextBox).BackColor = Color.OldLace;
                    }
                }
                else if(editCtrl is Button)
                {
                    (editCtrl as Button).Enabled = true;
                }
                else if (editCtrl is ButtonX)
                {
                    (editCtrl as ButtonX).Enabled = true;
                }
                else if (editCtrl is DateTimePicker)
                {
                    (editCtrl as DateTimePicker).Enabled = true;
                    (editCtrl as DateTimePicker).BackColor = Color.White;
                }
                else if (editCtrl is DateTimeInput)
                {
                    (editCtrl as DateTimeInput).ButtonDropDown.Visible = true;
                    (editCtrl as DateTimeInput).BackgroundStyle.BackColor = Color.OldLace;
                }
            }
            else
            {
                if (editCtrl is TextBox)
                {
                    (editCtrl as TextBox).ReadOnly = true;
                    (editCtrl as TextBox).BackColor = Color.WhiteSmoke;
                }
                if (editCtrl is TextBoxX)
                {
                    (editCtrl as TextBoxX).ButtonCustom.Visible = false;
                }
                else if (editCtrl is Button)
                {
                    (editCtrl as Button).Enabled = false;
                }
                else if (editCtrl is ButtonX)
                {
                    (editCtrl as ButtonX).Enabled = false;
                }
                else if (editCtrl is DateTimePicker)
                {
                    (editCtrl as DateTimePicker).Enabled = false;
                    (editCtrl as DateTimePicker).BackColor = Color.WhiteSmoke;
                }
                else if (editCtrl is DateTimeInput)
                {
                    (editCtrl as DateTimeInput).ButtonDropDown.Visible = false;
                    (editCtrl as DateTimeInput).BackgroundStyle.BackColor = Color.WhiteSmoke;
                }
            }
            
            #endregion
        }


        public static void GetSqlParams(Control.ControlCollection controls, List<string> wheres, List<SqlParameter> parameters)
        {
            #region 获取过滤条件

            string strWhere, keyWord;
            wheres.Clear();
            parameters.Clear();

            foreach (Control ctrl in controls)
            {
                if (ctrl is TextBox && (ctrl as TextBox).Text.Trim() != "")
                {
                    strWhere = (ctrl as TextBox).Tag.ToString();

                    wheres.Add(strWhere);
                    keyWord = strWhere.Substring(strWhere.IndexOf('@'));                   
                    keyWord = keyWord.Replace(")", "");
                    keyWord = keyWord.Split(' ')[0];
                    if (strWhere.ToLower().Contains("like"))
                    {
                        parameters.Add(new SqlParameter(keyWord,  (ctrl as TextBox).Text.Trim() + "%"));
                    }
                    else
                    {
                        parameters.Add(new SqlParameter(keyWord, (ctrl as TextBox).Text.Trim()));
                    }
                }
                else if (ctrl is DateTimeInput)
                {
                    if ((ctrl as DateTimeInput).LockUpdateChecked)
                    {
                        strWhere = (ctrl as DateTimeInput).Tag.ToString();
                        wheres.Add(strWhere);
                        keyWord = strWhere.Substring(strWhere.IndexOf('@'));
                        parameters.Add(new SqlParameter(keyWord, (ctrl as DateTimeInput).Value.ToShortDateString()));
                    }
                }
                else if (ctrl is IntegerInput && (ctrl as IntegerInput).Text != "")
                {
                    strWhere = (ctrl as IntegerInput).Tag.ToString();
                    wheres.Add(strWhere);
                    keyWord = strWhere.Substring(strWhere.IndexOf('@'));
                    keyWord = keyWord.Replace(")", "");
                    parameters.Add(new SqlParameter(keyWord, (ctrl as IntegerInput).Value));
                }
                else if (ctrl is CheckBox)
                {
                    if ((ctrl as CheckBox).Checked)
                    {
                        strWhere = (ctrl as CheckBox).Tag.ToString();
                        wheres.Add(strWhere);
                    }
                }
            }
            #endregion
        }

        public static void GetSqlParams2(Control.ControlCollection controls, List<string> wheres, List<SqlParameter> parameters)
        {
            #region 获取过滤条件

            string strWhere, keyWord;
            wheres.Clear();
            parameters.Clear();

            foreach (Control ctrl in controls)
            {
                if (ctrl is TextBox && (ctrl as TextBox).Text.Trim() != "")
                {
                    string[] strArry = (ctrl as TextBox).Tag.ToString().Split('|');
                    wheres.Add(strArry[0]);
                    keyWord = strArry[1];

                    if (strArry[0].ToLower().Contains("like"))
                    {
                        parameters.Add(new SqlParameter(keyWord, (ctrl as TextBox).Text.Trim() + "%"));
                    }
                    else
                    {
                        parameters.Add(new SqlParameter(keyWord, (ctrl as TextBox).Text.Trim()));
                    }
                }
                else if (ctrl is DateTimeInput)
                {
                    if ((ctrl as DateTimeInput).LockUpdateChecked)
                    {
                        string[] strArry = (ctrl as TextBox).Tag.ToString().Split('|');
                        wheres.Add(strArry[0]);
                        keyWord = strArry[1];
                        parameters.Add(new SqlParameter(keyWord, (ctrl as DateTimeInput).Value.ToShortDateString()));
                    }
                }
                else if (ctrl is IntegerInput && (ctrl as IntegerInput).Text != "")
                {
                    string[] strArry = (ctrl as TextBox).Tag.ToString().Split('|');
                    wheres.Add(strArry[0]);
                    keyWord = strArry[1];
                    parameters.Add(new SqlParameter(keyWord, (ctrl as IntegerInput).Value));
                }
                else if (ctrl is CheckBox)
                {
                    if ((ctrl as CheckBox).Checked)
                    {
                        strWhere = (ctrl as CheckBox).Tag.ToString();
                        wheres.Add(strWhere);
                    }
                }
            }
            #endregion
        }

    }
}
