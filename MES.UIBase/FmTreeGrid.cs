//※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※
//
//树控件的节点的 Tag 属性，记录 Tag = new string[] { 分类编码（如：DepCode）, 分类名称（如：DepName） };
//
//※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevComponents.AdvTree;
using System.Data.SqlClient;

namespace LanyunMES.UIBase
{
    using LanyunMES.Entity;
    using LanyunMES.DAL;
    using Common;
    using Component;

    public partial class FmTreeGrid : DevComponents.DotNetBar.OfficeForm
    {
        public FmTreeGrid(DataView treeData)
        {
            InitializeComponent();

            this.dvTree = treeData;
            this.Load += FmB_Load;
        }

        #region 业务服务
        /// <summary>
        /// 树（分类）模块名称（用于从数据库中访问树（分类）模块操作信息）
        /// </summary>
        public string ModuleName { get; set; }

        ITreeGrid iTreeGrid;

        /// <summary>
        /// 业务数据视图
        /// </summary>
        protected DataView dvTree, dvDetail;

        /// <summary>
        /// 查询条件
        /// </summary>
        protected string[] m_strAryQueryCondition = null;

        /// <summary>
        /// 线程：获取业务数据
        /// </summary>
        protected Thread m_trdGetMBusiData = null;

        /// <summary>
        /// 线程：获取业务数据
        /// </summary>
        protected Thread m_trdGetTBusiData = null;

        /// <summary>
        /// 代理：界面更新方法
        /// </summary>
        protected delegate void m_dgtUIMethod();
        /// <summary>
        /// 代理：界面更新方法
        /// </summary>
        protected delegate void m_dgtUICursor(Cursor curosr);
        /// <summary>
        /// 代理：消息显示
        /// </summary>
        protected delegate void m_dgtUIMsgShow(string strMsg);
        /// <summary>
        /// 代理：消息显示
        /// </summary>
        protected delegate DialogResult m_dgtUIYesNoMsgShow(string strMsg);

        /// <summary>
        /// 树根节点
        /// </summary>
        protected Node m_tnRoot = null;
        /// <summary>
        /// 当前选定的树节点
        /// </summary>
        protected Node m_tnSelected = null;
        /// <summary>
        /// 树（分类）和主数据之间的关联名
        /// </summary>
        protected string m_strMTLnkName = "";

        //Grid数据库表主键名称
        protected string m_strDPK;

        #endregion

        #region 分级字段（变量）
        //分级编码
        protected string m_strGradeCode = null;
        //分级名称
        protected string m_strGradeName = null;
        //级别字段
        protected string m_strGradeField = "";
        #endregion


        protected virtual void InitGridColumn()
        {

        }


        protected virtual void FmB_Load(object sender, System.EventArgs e)
        {
            #region 窗体加载

            this.pnl_Head.Text = this.TreeM.Nodes[0].Text = this.Text;

            this.sGrid.AutoGenerateColumns = false;

            this.InitGridColumn();

            this.iTreeGrid = new TTreeGrid(ModuleName);
            //this.dvTree = iTreeGrid.GetTreeData();
            this.m_strGradeCode = iTreeGrid.gradeInfo.CodeColumnName;
            this.m_strGradeName = iTreeGrid.gradeInfo.NameColumnName;
            this.m_strGradeField = iTreeGrid.gradeInfo.GradeColumnName;
            this.m_strDPK = iTreeGrid.busiInfo.DPK;

            GetTBusiData();         //加载树

            #endregion
        }

        //GetTBusiData --> GetTData --> LoadTVData

        #region 加载TreeView树
        protected virtual void GetTBusiData()
        {
            #region 获取树（分类）数据

            try
            {
                if (this.m_trdGetTBusiData != null && this.m_trdGetTBusiData.IsAlive) this.m_trdGetTBusiData.Abort();
            }
            catch { }
            finally { this.m_trdGetTBusiData = null; }

            this.m_trdGetTBusiData = new Thread(this.GetTData);
            this.m_trdGetTBusiData.IsBackground = true;
            this.m_trdGetTBusiData.Start();

            #endregion
        }

        protected virtual void GetTData()
        {
            #region 获取树（分类）数据

            try
            {
                while (!this.IsHandleCreated) { ; }
                this.BeginInvoke(new m_dgtUICursor(this.UICursor), new object[] { Cursors.WaitCursor });
                this.BeginInvoke(new m_dgtUIMethod(LoadTVData));
            }
            catch (Exception ex)
            {
                MsgBox.ShowInfoMsg(ex.ToString());
            }
            finally
            {
                this.BeginInvoke(new m_dgtUICursor(this.UICursor), new object[] { Cursors.Default });
            }

            #endregion
        }

        protected virtual void LoadTVData()
        {
            #region 显示模块树
                 
            //根节点
            this.m_tnRoot = this.TreeM.Nodes[0];
            this.m_tnRoot.Nodes.Clear();
            this.m_tnRoot.Expand();

            //调用加载数据
            TreeHelper.LoadAdvTree(TreeM, dvTree, m_strGradeCode, m_strGradeName, m_strGradeField, "", NodeClick, true);

            #endregion
        } 
        #endregion

        //NodeClick --> GetMBusiData --> GetMData --> MTableupd

        #region 加载TreeViewNode明细

        protected virtual void NodeClick(object sender, EventArgs e)
        {
            #region 获取Node明细

            this.m_tnSelected = (Node)sender;

            if (m_tnSelected.Tag == null) return;

            if (this.m_trdGetMBusiData != null && this.m_trdGetMBusiData.IsAlive)
            {
                MsgBox.ShowInfoMsg2("应用程序后台正忙，请稍后再试！"); return;
            }

            string[] sArray = (string[])m_tnSelected.Tag;

            GetMBusiData(sArray[0], true);

            #endregion
        }

        protected virtual void GetMBusiData(string str, bool isLnkField)
        {
            #region 获取主业务数据

            try
            {
                if (this.m_trdGetMBusiData != null && this.m_trdGetMBusiData.IsAlive) 
                    this.m_trdGetMBusiData.Abort();
            }
            catch (Exception ex) 
            {
                MsgBox.ShowInfoMsg(ex.ToString());
            }
            finally { this.m_trdGetMBusiData = null; }

            if (this.dvDetail != null)
            {
                this.dvDetail.Dispose();
                this.dvDetail = null;
            }

            //this.dvDetail = iTreeGrid.GetGridData(str, isLnkField);

            this.m_trdGetMBusiData = new Thread(new ThreadStart(this.GetMData));
            this.m_trdGetMBusiData.IsBackground = true;
            this.m_trdGetMBusiData.Start();

            #endregion
        }

        protected virtual void GetMData()
        {
            #region 获取主业务数据

            FmWait1 fmWait = new FmWait1(this, "正在提取数据,请稍候...");

            try
            {
                while (!this.IsHandleCreated) { ; }
                this.BeginInvoke(new m_dgtUIMethod(fmWait.UIWaitStart), null);
                this.BeginInvoke(new m_dgtUICursor(this.UICursor), new object[] { Cursors.WaitCursor });              
                this.BeginInvoke(new m_dgtUIMethod(this.UIFlash));
            }
            catch(Exception ex) 
            {
                MsgBox.ShowInfoMsg(ex.ToString());
            }
            finally
            {
                this.BeginInvoke(new m_dgtUICursor(this.UICursor), new object[] { Cursors.Default });
                this.BeginInvoke(new m_dgtUIMethod(fmWait.UIWaitEnd), null);
            }

            #endregion
        }     

        protected virtual void UIFlash()
        {
            #region 刷新界面

            DataTable table = new DataTable();
            DataColumn column = new DataColumn();
            //AutoIncrement  获取或设置一个值，该值指示对于添加到该表中的新行，列是否将列的值自动递增  
            column.AutoIncrement = true;
            column.ColumnName = "RowNo";
            column.AutoIncrementSeed = 1;
            column.AutoIncrementStep = 1;
            table.Columns.Add(column);
            //Merge合并DataTable  
            table.Merge(dvDetail.Table);
            this.dvDetail = table.DefaultView;

            this.dvDetail.AllowNew = this.dvDetail.AllowEdit = this.dvDetail.AllowDelete = false;

            this.sGrid.DataSource = this.dvDetail;
            this.btn_Add.Enabled = true;
            this.btn_Edit.Enabled = this.btn_Del.Enabled = this.btn_Print.Enabled = this.sGrid.RowCount > 0;

            //UICtrl.AppDoEvents(3);

            this.lblRowCount.Text = "";
            if (this.dvDetail != null)
                this.lblRowCount.Text = "已加载记录数:" + this.dvDetail.Count.ToString();

            Application.DoEvents(); 
            #endregion
        }

        #endregion

        protected virtual void btnAdd_Click(object sender, System.EventArgs e)
        {
            #region 新增业务数据
            #endregion
        }

        protected virtual void btnEdit_Click(object sender, System.EventArgs e)
        {
            #region 编辑业务数据
            #endregion
        }

        protected virtual void btnDel_Click(object sender, System.EventArgs e)
        {
            #region 删除业务数据

            #endregion
        }


        #region =========打印相关==========
        private void btnPrint_Click(object sender, System.EventArgs e)
        {

        }

        protected virtual void miPrint_Click(object sender, EventArgs e)
        {

        }

        protected virtual void miPrintDesgin_Click(object sender, EventArgs e)
        {

        } 
        #endregion


        protected virtual void btnExport_Click(object sender, EventArgs e)
        {
            #region 导出Excel

            if (Export.ExpToExcel(sGrid))
            {
                MessageBox.Show("导出成功！");
            }

            #endregion
        }

        protected virtual void btnColSettings_Click(object sender, EventArgs e)
        {

        }

        protected virtual void btnQuery_Click(object sender, EventArgs e)
        {
            #region 查询业务数据


            if (this.m_trdGetMBusiData != null && this.m_trdGetMBusiData.IsAlive)
            {
                MsgBox.ShowInfoMsg2("应用程序后台正忙，请稍后再试！"); return;
            }
            //GetMBusiData();

            this.sGrid.Focus();
            #endregion
        }

        protected virtual void btnRefresh_Click(object sender, System.EventArgs e)
        {
            #region 刷新业务数据
            //this.m_bOpState = BusiOpState.None;
            if (this.m_trdGetTBusiData != null && this.m_trdGetTBusiData.IsAlive)
            {
                MsgBox.ShowInfoMsg2("应用程序后台正忙，请稍后再试！"); return;
            }
            GetTBusiData();

            this.TreeM.Focus();
            #endregion
        }

        protected virtual void btnExit_Click(object sender, System.EventArgs e)
        {
            #region 退出模块
            Close();
            #endregion
        }

        protected virtual void sGrid_DoubleClick(object sender, EventArgs e)
        {
            this.btnEdit_Click(sender, e);
        }

        protected virtual void UICursor(Cursor cursor)
        {
            this.Cursor = cursor;
        }

    }
}