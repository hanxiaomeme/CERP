using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NDF
{
    public partial class FmRoleModule : Form
    {
        public FmRoleModule()
        {
            InitializeComponent();

            this.m_bObj = new BusinessObject();

            this.m_bObj.BusiName = "DARoleModule";

            this.m_bObj.BusiDataSQL = new string[] { "select * from V_RoleModule where 1=1", "select * from V_ModuleInfo where IsAdmin=0" };
            this.m_bObj.BusiAttaSQL = new string[] { "1=1", "1=1" };
            this.m_bObj.BusiTableNames = new string[] { "RoleModule", "Module" };
        }

        public FmRoleModule(int nRoleId, string strRoleName) : this()
		{
            this.Text               = "角色模块 - " + strRoleName;
            this.lblRoleName.Text   = "角色名: " + strRoleName;

			this.m_nRoleId			= nRoleId;
		}

        /// <summary>
        /// 业务对象
        /// </summary>
        private BusinessObject m_bObj = null;
        /// <summary>
        /// 业务数据视图
        /// </summary>
        private DataView m_dvRoleModule = null;
        /// <summary>
        /// 线程：获取业务数据
        /// </summary>
        private Thread m_trdGetBusiData = null;
        /// <summary>
        /// 线程：更新(修改)业务数据
        /// </summary>
        private Thread m_trdUpdBusiData = null;
        /// <summary>
        /// 代理：界面更新方法
        /// </summary>
        private delegate void m_dgtUIMethod();
        /// <summary>
        /// 代理：界面更新方法
        /// </summary>
        protected delegate void m_dgtUICursor(Cursor curosr);
        /// <summary>
        /// 代理：消息显示
        /// </summary>
        private delegate void m_dgtUIMsgShow(string strMsg);

        private int m_nRoleId = 0;

        private void GetBusiData()
        {
            try
            {
                while (!this.IsHandleCreated) { ; }
                this.BeginInvoke(new m_dgtUICursor(this.UICursor), new object[] { Cursors.WaitCursor });

                this.m_bObj.BusiAttaSQL = new string[] { "RoleId=" + this.m_nRoleId.ToString() };

                this.m_bObj.GetBusiData();

                Thread.Sleep(200);

                if (this.m_bObj.BusiMsg[0] == "1")
                {
                    while (!this.IsHandleCreated) { ; }
                    this.BeginInvoke(new m_dgtUIMethod(this.UIUpd));
                }
                else
                {
                    while (!this.IsHandleCreated) { ; }
                    this.BeginInvoke(new m_dgtUIMsgShow(this.UIShowMsgBox), new object[] { this.m_bObj.BusiMsg[1] });
                }
            }
            finally
            {
                while (!this.IsHandleCreated) { ; }
                this.BeginInvoke(new m_dgtUICursor(this.UICursor), new object[] { Cursors.Default });
            }
        }

        private void UpdBusiData()
        {
            try
            {
                while (!this.IsHandleCreated) { ; }
                this.BeginInvoke(new m_dgtUICursor(this.UICursor), new object[] { Cursors.WaitCursor });

                while (!this.IsHandleCreated) { ; }
                this.Invoke(new m_dgtUIMethod(this.UIGetMainData));

                this.m_bObj.UpdateBusiData();
            }
            finally
            {
                while (!this.IsHandleCreated) { ; }
                this.BeginInvoke(new m_dgtUICursor(this.UICursor), new object[] { Cursors.Default });
            }

            while (!this.IsHandleCreated) { ; }
            this.BeginInvoke(new m_dgtUIMsgShow(this.UIShowMsgBox), new object[] { this.m_bObj.BusiMsg[1] });
        }

        private void UIUpd()
        {
            UITUpd();
        }

        private void UILoadTreeView(TreeNodeCollection tnCollection, DataTable dt, string strModuleCode)
        {
            string strRowFilter = null;
            if (strModuleCode == "")
                strRowFilter = "len(ModuleCode)=3";
            else
                strRowFilter = "substring(ModuleCode,1," + strModuleCode.Length.ToString() + ")='" + strModuleCode + "' and len(ModuleCode)=" + (strModuleCode.Length + 3).ToString();

            DataView dvModule = new DataView(dt);
            dvModule.RowFilter = strRowFilter;

            TreeNode tn = null;
            // 递归方法将模块信息加载到树视图中
            foreach (DataRowView drv in dvModule)
            {
                if (drv["IsUse"].ToString() == "0") continue;

                tn = new TreeNode();
                tn.Tag = drv["ModuleId"];
                if (drv["IsEnd"].ToString().Trim() == "1")
                    tn.Text = "【" + drv["ModuleName"].ToString() + "】";
                else
                    tn.Text = drv["ModuleName"].ToString();

                tnCollection.Add(tn);
                // 递归
                UILoadTreeView(tn.Nodes, dt, drv["ModuleCode"].ToString());
            }
        }

        private void UITUpd()
        {
            this.tvModule.Nodes.Clear();
            UILoadTreeView(this.tvModule.Nodes, this.m_bObj.BusiData.Tables[1], "");
            if (this.tvModule.Nodes.Count > 0)
            {
                this.tvModule.ExpandAll();

                SetModuleTreeState();

                this.tvModule.SelectedNode = this.tvModule.Nodes[0];
            }
        }

        //递归调用完成具体角色权限的初始化
        private void SetModuleTreeState()
        {
            if (this.m_dvRoleModule != null) { this.m_dvRoleModule.Dispose(); this.m_dvRoleModule = null; }
            this.m_dvRoleModule = new DataView(this.m_bObj.BusiData.Tables[0]);
            this.m_dvRoleModule.Sort = "ModuleId";

            foreach (TreeNode tn in this.tvModule.Nodes)
            {
                SetModuleTreeNodeCheckedState(tn);
            }
        }

        //根据用户的权限信息初始化树结点的状态,即设置树节点的 Checked 属性
        private void SetModuleTreeNodeCheckedState(TreeNode treeNode)
        {
            treeNode.Checked = this.m_dvRoleModule.FindRows((int)treeNode.Tag).Length > 0 ? true : false;

            // 对每个节点进行递归调用
            foreach (TreeNode tn in treeNode.Nodes)
            {
                SetModuleTreeNodeCheckedState(tn);
            }
        }

        private void UIShowMsgBox(string strMsg)
        {
            Form fmP = this; Control c = this;
            while (true) { c = c.Parent; if (c != null && c is Form) fmP = (Form)c; if (c == null) break; }
            if (fmP != null) fmP.Activate();
            MsgBox.ShowInfoMsg2(strMsg);
        }

        protected virtual void UICursor(Cursor cursor)
        {
            this.Cursor = cursor;
        }

        protected void UIGetMainData()
        {
            DataTable dtRoleModule = this.m_bObj.BusiData.Tables[0].Clone();

            foreach (TreeNode tn in this.tvModule.Nodes)
            {
                GetBusiDataRoleModule(dtRoleModule, tn);
            }

            if (this.m_bObj.BusiData != null)
                this.m_bObj.BusiData.Tables.Clear();
            else
                this.m_bObj.BusiData = new DataSet();

            this.m_bObj.BusiData.Tables.Add(dtRoleModule);
        }

        //根据树的 Checked 属性向记录集中写权限(角色拥有的模块)
        private void GetBusiDataRoleModule(DataTable dtRoleModule, TreeNode theTreeNode)
        {
            DataRow dr = dtRoleModule.NewRow();

            dr["RoleId"] = this.m_nRoleId;
            dr["ModuleId"] = theTreeNode.Checked ? theTreeNode.Tag : DBNull.Value;

            dtRoleModule.Rows.Add(dr);

            // 对每个节点进行递归调用
            foreach (TreeNode tn in theTreeNode.Nodes)
            {
                GetBusiDataRoleModule(dtRoleModule, tn);
            }
        }

        private void tvModule_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            foreach (TreeNode tn in e.Node.Nodes)
            {
                SetTreeNodeCheckedState(tn, e.Node.Checked);
            }

            if (e.Node.Checked & e.Node.Parent != null)
                SetParentTreeNodeCheckedState(e.Node);
        }

        //置树节点所有子结点的复选框状态
        private void SetTreeNodeCheckedState(TreeNode tn, bool bChecked)
        {
            tn.Checked = bChecked;
            foreach (TreeNode tnTemp in tn.Nodes)
            {
                SetTreeNodeCheckedState(tnTemp, bChecked);
            }
        }

        //置树节点所有父结点的复选框状态,即将一个树节点的复选框选中，它的所有父节点的复选框均为选中状态
        private void SetParentTreeNodeCheckedState(TreeNode tn)
        {
            this.tvModule.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.tvModule_AfterCheck);
            while (tn.Parent != null && tn.Parent.Checked == false) { tn.Parent.Checked = true; tn = tn.Parent; }
            this.tvModule.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvModule_AfterCheck);
        }

        private void FmRoleModule_Load(object sender, System.EventArgs e)
        {
            try
            {
                if (this.m_trdGetBusiData != null && this.m_trdGetBusiData.IsAlive)
                    this.m_trdGetBusiData.Abort();
            }
            catch { }
            finally { this.m_trdGetBusiData = null; }

            this.m_trdGetBusiData = new Thread(new ThreadStart(this.GetBusiData));
            this.m_trdGetBusiData.Start();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (this.m_trdUpdBusiData != null && this.m_trdUpdBusiData.IsAlive)
            {
                MsgBox.ShowInfoMsg2("应用程序后台正忙，请稍后再试！"); return;
            }
            this.m_trdUpdBusiData = new Thread(new ThreadStart(this.UpdBusiData));
            this.m_trdUpdBusiData.Start();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}