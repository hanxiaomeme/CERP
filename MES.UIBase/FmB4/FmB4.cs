using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NDF
{
    public partial class FmB4 : Form
    {
        public FmB4()
        {
            InitializeComponent();

            InitCtrlToolTip();

            this.btnPrint.ContextMenu = this.cntMnuPrint;

            this.dgM.Tag = new int[] { 0, -1 };
            this.dgD.Tag = -1;

            InitPrintSettingsName();
        }

        #region 业务服务、变量和相关属性
        /// <summary>
        /// 是否仅仅显示单据
        /// </summary>
        public bool ShowOnly
        {
            get { return m_bShowOnly; }
            set { m_bShowOnly = value; }
        }
        protected bool m_bShowOnly = false;
        /// <summary>
        /// 模块名称（用于从数据库中访问当前模块操作信息）
        /// </summary>
        protected string m_strModuleName = null;
        /// <summary>
        /// 当前业务操作(新增，修改，删除，审核，反审核)
        /// </summary>
        public BusiOpState OpState
        {
            get { return this.m_bOpState; }
            set { this.m_bOpState = value; }
        }
        protected BusiOpState m_bOpState = BusiOpState.BrowseBusiData;
        /// <summary>
        /// 能否退出模块
        /// </summary>
        public bool CanExitModule
        {
            get { return this.m_bCanExitModule; }
            set { this.m_bCanExitModule = value; }
        }
        protected bool m_bCanExitModule = true;
        /// <summary>
        /// 
        /// </summary>
        public int ModuleBusiDBId
        {
            get { return this.m_nModuleBusiDBId; }
            set { this.m_nModuleBusiDBId = value; }
        }
        protected int m_nModuleBusiDBId = 0;
        /// <summary>
        /// 数据对象
        /// </summary>
        public object DataObject
        {
            get { return this.m_dataObject; }
            set { this.m_dataObject = value; }
        }
        protected object m_dataObject = null;
        /// <summary>
        /// 业务对象
        /// </summary>
        protected BusinessObject m_bmdObj = null;
        /// <summary>
        /// 主表业务数据视图,从表业务数据视图
        /// </summary>
        protected DataView m_dvM = null, m_dvD = null;
        /// <summary>
        /// 主表主键，从表主键，从表外键
        /// </summary>
        protected string m_strPKM = null, m_strPKD = null, m_strFKD = null;
        /// <summary>
        /// 主从表视图名
        /// </summary>
        protected string m_strdvMTableName = "", m_strdvDTableName = "";
        /// <summary>
        /// 记录主从表当前行
        /// </summary>
        protected int /*m_ndgMCurrentRowIndex = -1, */m_ndgDCurrentRowIndex = -1;
        /// <summary>
        /// 不拷贝的字段
        /// </summary>
        protected string[] m_strAryDisCopyTableFieldMain = null, m_strAryDisCopyTableFieldDetail = null;
        /// <summary>
        /// 记录主、从表单元格信息
        /// </summary>
        protected object[] DGCell0 = null, DGCell1 = null;
        /// <summary>
        /// 执行查询标志
        /// </summary>
        protected bool m_bExecQuery = false;
        /// <summary>
        /// 外部传入数据查询过滤条件
        /// </summary>
        public string[] OuterFilterSQL
        {
            set { this.m_strAryOuterFilterSQL = value; }
            get { return this.m_strAryOuterFilterSQL; }
        }
        /// <summary>
        /// 外部传入数据查询过滤条件
        /// </summary>
        public string[] QueryCondition
        {
            set { this.m_strAryQueryCondition = value; }
            get { return this.m_strAryQueryCondition; }
        }
        protected string[] m_strAryOuterFilterSQL = null;
        /// <summary>
        /// 查询条件
        /// </summary>
        protected string[] m_strAryQueryCondition = null;
        /// <summary>
        /// 特殊过滤
        /// </summary>
        protected string[] m_strArySpecFilterM = null, m_strArySpecFilterD = null;
        /// <summary>
        /// 默认过滤
        /// </summary>
        protected string[] m_strAryDftFilterM = null; //, m_strAryDftFilterD = null;
        /// <summary>
        /// 默认过滤标识别
        /// </summary>
        protected bool m_bDftFilterM = true, m_bDftFilterD = true;
        /// <summary>
        /// 子表排序字段
        /// </summary>
        protected string m_strOrderD = null;
        /// <summary>
        /// 报表文件名
        /// </summary>
        protected string m_strRptFile = null;
        /// <summary>
        /// 打印设置
        /// </summary>
        protected string m_strPrintSettings = null;
        /// <summary>
        /// 线程：获取主从表业务数据
        /// </summary>
        protected Thread m_trdGetMDBusiData = null;
        /// <summary>
        /// 线程：更新(新增，修改，删除，审核，反审核)业务数据
        /// </summary>
        protected Thread m_trdUpdMDBusiData = null;
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
        /// 是否第一次加载数据
        /// </summary>
        protected bool m_bFirstGetData = true;
        /// <summary>
        /// 激活窗体是否刷新
        /// </summary>
        public bool ActivatedRefresh
        {
            get { return this.m_bActivatedRefresh; }
            set { this.m_bActivatedRefresh = value; }
        }
        protected bool m_bActivatedRefresh = false;
        /// <summary>
        /// 初始显示单据数
        /// </summary>
        protected int m_nInitVCount = 100;
        #endregion

        protected virtual void InitDGMTabStyle()
        {
        }

        protected virtual void InitDGDTabStyle()
        {
        }

        protected virtual void GetMDBusiData()
        {
            #region 获取主从表业务的数据
            try
            {
                while (!this.IsHandleCreated) { ; }
                this.BeginInvoke(new m_dgtUICursor(this.UICursor), new object[] { Cursors.WaitCursor });

                //查询/过滤条件
                while (!this.IsHandleCreated) { ; }
                this.Invoke(new m_dgtUIMethod(this.UIGetMDSQL));

                this.m_bmdObj.GetBusiData();

                if (this.m_bmdObj.BusiMsg[0] == "1")
                {
                    while (!this.IsHandleCreated) { ; }
                    this.BeginInvoke(new m_dgtUIMethod(this.UIMUpd));
                }
                else
                {
                    while (!this.IsHandleCreated) { ; }
                    this.BeginInvoke(new m_dgtUIMsgShow(this.UIShowMsgBox), new object[] { this.m_bmdObj.BusiMsg[1] });
                }
            }
            catch { }
            finally
            {
                while (!this.IsHandleCreated) { ; }
                this.BeginInvoke(new m_dgtUICursor(this.UICursor), new object[] { Cursors.Default });
            }
            #endregion
        }

        protected virtual void UIGetMDSQL()
        {
            #region 获取主数据过滤条件

            string s = "1=1";
            if (this.m_strAryOuterFilterSQL != null)
            {
                s += " and " + this.m_strAryOuterFilterSQL[0];
            }

            if (this.m_bOpState == BusiOpState.BrowseBusiData)
            {
                if (this.m_strAryQueryCondition != null)
                {
                    s += " and " + this.m_strAryQueryCondition[0];
                    this.m_bDftFilterM = this.m_bDftFilterD = false;
                }
                else
                {
                    s += " and datediff(month,MDate,getdate())<=6 ";
                }
                /*
                else
                {
                    s += " and (" + this.m_strPKM + " in(select top " + this.m_nInitVCount.ToString() + " " + this.m_strPKM + " from " + this.m_strdvMTableName + " where 1=1 " + (this.m_strArySpecFilterM != null ? " and " + this.m_strArySpecFilterM[0] : "") + " order by " + this.m_strPKM + " asc))";
                }
                */
            }

            if (this.m_bOpState == BusiOpState.AddBusiData)
            {
                //s += " and (" + this.m_strPKM + " in(select top " + this.m_nInitVCount.ToString() + " " + this.m_strPKM + " from " + this.m_strdvMTableName + " where 1=1 " + (this.m_strArySpecFilterM != null ? " and " + this.m_strArySpecFilterM[0] : "") + " order by " + this.m_strPKM + " asc))";
                s += " and datediff(month,MDate,getdate())<=6 ";
                //this.m_strAryQueryCondition = new string[] { "datediff(month,MDate,getdate())<=6" };
            }

            if (this.m_bOpState == BusiOpState.None ||
                this.m_bOpState == BusiOpState.EditBusiData ||
                this.m_bOpState == BusiOpState.DelBusiData ||
                this.m_bOpState == BusiOpState.SubmitBusiData ||
                this.m_bOpState == BusiOpState.AuditBusiData ||
                this.m_bOpState == BusiOpState.UnAuditBusiData ||
                this.m_bOpState == BusiOpState.RegBusiData ||
                this.m_bOpState == BusiOpState.UnRegBusiData)
            {
                if (this.m_strAryQueryCondition != null)
                {
                    s += " and " + this.m_strAryQueryCondition[0];
                    this.m_bDftFilterM = this.m_bDftFilterD = false;
                }
                else
                {
                    s += " and datediff(month,MDate,getdate())<=6 ";
                }
                /*
                else
                {
                    s += " and (" + this.m_strPKM + " in(select top " + this.m_nInitVCount.ToString() + " " + this.m_strPKM + " from " + this.m_strdvMTableName + " where 1=1 " + (this.m_strArySpecFilterM != null ? " and " + this.m_strArySpecFilterM[0] : "") + " order by " + this.m_strPKM + " asc))";
                }
                */
            }

            if (this.m_strArySpecFilterM != null)
                s += " and " + this.m_strArySpecFilterM[0];
            if (this.m_strAryDftFilterM != null && this.m_bDftFilterM)
                s += " and " + this.m_strAryDftFilterM[0];

            this.m_bmdObj.BusiAttaSQL = new string[] { s };
            this.m_bmdObj.BusiOrderSQL = new string[] { this.m_strPKM };
            #endregion
        }

        protected virtual void UpdMDBusiData()
        {
            #region 更新主从表业务数据
            try
            {
                while (!this.IsHandleCreated) { ; }
                this.BeginInvoke(new m_dgtUICursor(this.UICursor), new object[] { Cursors.WaitCursor });

                while (!this.IsHandleCreated) { ; }
                this.Invoke(new m_dgtUIMethod(this.GetMDTabChgedData));

                switch (this.m_bOpState)
                {
                    case BusiOpState.AddBusiData:
                        this.m_bmdObj.InsertBusiData();

                        break;
                    case BusiOpState.EditBusiData:
                        this.m_bmdObj.UpdateBusiData();

                        break;
                    case BusiOpState.DelBusiData:
                        this.m_bmdObj.DeleteBusiData();

                        break;
                    case BusiOpState.SubmitBusiData:
                        this.m_bmdObj.SubmitBusiData();

                        break;
                    case BusiOpState.AuditBusiData:
                        this.m_bmdObj.AuditBusiData();

                        break;
                    case BusiOpState.UnAuditBusiData:
                        this.m_bmdObj.UnAuditBusiData();

                        break;
                    case BusiOpState.RegBusiData:
                        this.m_bmdObj.RegBusiData();

                        break;
                    case BusiOpState.UnRegBusiData:
                        this.m_bmdObj.UnRegBusiData();

                        break;
                    default:
                        break;
                }
            }
            finally
            {
                while (!this.IsHandleCreated) { ; }
                this.BeginInvoke(new m_dgtUICursor(this.UICursor), new object[] { Cursors.Default });
            }

            if (this.m_bmdObj.BusiMsg[0] == "1" && SystemOption.MsgShowEnabled)
            {
                while (!this.IsHandleCreated) { ; }
                this.BeginInvoke(new m_dgtUIMsgShow(this.UIShowMsgBox), new object[] { this.m_bmdObj.BusiMsg[1] });
            }
            else if (this.m_bmdObj.BusiMsg[0] == "0")
            {
                while (!this.IsHandleCreated) { ; }
                this.BeginInvoke(new m_dgtUIMsgShow(this.UIShowMsgBox), new object[] { this.m_bmdObj.BusiMsg[1] });
            }

            if (this.m_bmdObj.BusiMsg[0] == "1") GetMDBusiData();
            #endregion
        }

        protected virtual void GetMDTabChgedData()
        {
            #region 获取主从表操作业务数据
            if (this.m_dvM.Count > 0) this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
            DataTable dtMain = null, dtDetail = null;
            if (this.m_bOpState == BusiOpState.AddBusiData)
            {
                dtMain = this.m_dvM.Table.GetChanges(DataRowState.Added);
            }
            else if (this.m_bOpState == BusiOpState.EditBusiData)
            {
                dtMain = this.m_dvM.Table.GetChanges(DataRowState.Modified);
                if (dtMain == null)
                {
                    dtMain = this.m_dvM.Table.Clone();
                    dtMain.ImportRow(this.m_dvM[this.dgM.CurrentRowIndex].Row);
                }
            }
            else if (this.m_bOpState == BusiOpState.DelBusiData ||
                this.m_bOpState == BusiOpState.SubmitBusiData ||
                this.m_bOpState == BusiOpState.AuditBusiData ||
                this.m_bOpState == BusiOpState.UnAuditBusiData ||
                this.m_bOpState == BusiOpState.RegBusiData ||
                this.m_bOpState == BusiOpState.UnRegBusiData)
            {
                dtMain = this.m_dvM.Table.Clone();
                dtMain.ImportRow(this.m_dvM[this.dgM.CurrentRowIndex].Row);
            }

            if (this.m_bOpState == BusiOpState.AddBusiData ||
                this.m_bOpState == BusiOpState.EditBusiData)
            {
                if (this.m_dvD.Table.GetChanges(DataRowState.Added | DataRowState.Deleted | DataRowState.Modified) == null)
                    dtDetail = this.m_dvD.Table.Clone();
                else
                    dtDetail = this.m_dvD.Table.GetChanges(DataRowState.Added | DataRowState.Deleted | DataRowState.Modified);
            }

            if (this.m_bmdObj.BusiData != null)
                this.m_bmdObj.BusiData.Tables.Clear();
            else
                this.m_bmdObj.BusiData = new DataSet();

            if (this.m_bOpState == BusiOpState.AddBusiData || this.m_bOpState == BusiOpState.EditBusiData)
            {
                this.m_bmdObj.BusiData.Tables.Add(dtMain);
                this.m_bmdObj.BusiData.Tables.Add(dtDetail);
            }
            else
                this.m_bmdObj.BusiData.Tables.Add(dtMain);
            #endregion
        }

        protected virtual void UIMUpd()
        {
            #region 主表部分界面更新
            try
            {
                while (!this.IsHandleCreated) { ; }
                this.BeginInvoke(new m_dgtUICursor(this.UICursor), new object[] { Cursors.WaitCursor });

                if (this.m_dvM != null) { this.m_dvM.Dispose(); this.m_dvM = null; }

                this.dgM.Enabled = true;
                this.m_dvM = new DataView(this.m_bmdObj.BusiData.Tables[0].Copy());
                this.m_dvM.AllowNew = this.m_dvM.AllowEdit = this.m_dvM.AllowDelete = false;
                this.dgM.DataSource = null; this.dgM.DataSource = this.m_dvM;

                this.m_bFirstGetData = false;

                UpdCtl1(new string[] { "pnltabPage201" });

                if (this.dgM.CurrentRowIndex > -1)
                {
                    if (this.m_bOpState == BusiOpState.InitBusiData)
                        this.dgM.CurrentRowIndex = this.m_dvM.Count - 1;
                    else if (this.m_bOpState == BusiOpState.BrowseBusiData)
                        this.dgM.CurrentRowIndex = /*this.m_dvM.Count - 1*/0;
                    else if (this.m_bOpState == BusiOpState.AddBusiData)
                        this.dgM.CurrentRowIndex = GetdgMAfterAddedRowIndex(0);
                    else if (this.m_bOpState == BusiOpState.None ||
                        this.m_bOpState == BusiOpState.BrowseBusiData ||
                        this.m_bOpState == BusiOpState.EditBusiData ||
                        this.m_bOpState == BusiOpState.SubmitBusiData ||
                        this.m_bOpState == BusiOpState.AuditBusiData ||
                        this.m_bOpState == BusiOpState.UnAuditBusiData ||
                        this.m_bOpState == BusiOpState.RegBusiData ||
                        this.m_bOpState == BusiOpState.UnRegBusiData)
                        this.dgM.CurrentRowIndex = GetdgMCurrentRowIndex(0);
                    else if (this.m_bOpState == BusiOpState.DelBusiData)
                        this.dgM.CurrentRowIndex = GetdgMAfterDeletedRowIndex(0);

                    this.dgM.Tag = new int[] { (int)this.m_dvM[this.dgM.CurrentRowIndex][this.m_strPKM], this.dgM.CurrentRowIndex };

                    this.dgM.Select(this.dgM.CurrentRowIndex);
                }
                else
                {
                    this.dgM.Tag = new int[] { 0, -1 };
                }

                this.btnAdd.Enabled = true;
                this.btnEdit.Enabled = this.btnDel.Enabled = this.btnCopy.Enabled = this.btnPrint.Enabled = this.btnSelectAll.Enabled = this.btnUnSelectAll.Enabled = this.btnProcess.Enabled = this.dgM.CurrentRowIndex > -1;
                this.btnSave.Enabled = this.btnCancel.Enabled = this.btnSubmit.Enabled = this.btnAudit.Enabled = this.btnUnAudit.Enabled = false;

                UIDataBinding(0);
                UISpcDataBinding(0);

                UINavigation(0);

                UIDUpd();

                this.m_bOpState = BusiOpState.None;

                this.DGCell0 = null;

                this.statusBarPanel1.Text = "";
                if (this.m_dvM != null)
                    this.statusBarPanel1.Text = "已加载记录数:" + this.m_dvM.Count.ToString();

                if (this.dgM.TableStyles.Count > 0)
                    this.dgM.TableStyles[0].AllowSorting = true;
                //if (this.dgD.TableStyles.Count > 0)
                //    this.dgD.TableStyles[0].AllowSorting = true;

                if (this.m_bShowOnly) MShowOnly();
                UICtrl.AppDoEvents(3);
            }
            catch { }
            finally
            {
                while (!this.IsHandleCreated) { ; }
                this.BeginInvoke(new m_dgtUICursor(this.UICursor), new object[] { Cursors.Default });
            }

            #endregion
        }

        protected virtual void UIDUpd()
        {
            #region 从表部分界面更新

            this.Cursor = Cursors.WaitCursor;

            //if (this.m_dvD != null) { this.m_dvD.Dispose(); this.m_dvD = null; }

            string s = null;

            if (this.dgM.CurrentRowIndex > -1)
            {
                s = "select * from " + this.m_strdvDTableName + " where ";
                s += this.m_strFKD + " = " + this.m_dvM[dgM.CurrentRowIndex][this.m_strPKM];
                if (this.m_strArySpecFilterD != null)
                    s += " and " + this.m_strArySpecFilterD[0];
                //if (this.m_strAryDftFilterD != null && this.m_bDftFilterD)
                //    s += " and " + this.m_strAryDftFilterD[0];
            }
            else
            {
                s = "select * from " + this.m_strdvDTableName + " where " + this.m_strFKD + " = -1";
            }

            BusinessObject bo = new BusinessObject();
            bo.BusiDBId = this.m_nModuleBusiDBId;
            bo.BusiDataSQL = new string[] { s };

            if (!string.IsNullOrEmpty(m_strOrderD))
            {
                bo.BusiOrderSQL = new string[] { m_strOrderD };
            }

            bo.GetBusiData();
            if (bo.BusiMsg[0] == "0")
            {
                MsgBox.ShowErrMsg2(bo.BusiMsg[1]); return;
            }

            bo.BusiData.Tables[0].TableName = "t1";

            this.m_dvD = new DataView(bo.BusiData.Tables[0].Copy());
            this.m_dvD.AllowNew = this.m_dvD.AllowEdit = this.m_dvD.AllowDelete = false;
            this.dgD.DataSource = this.m_dvD;

            this.dgD.Enabled = this.dgD.ReadOnly = true;

            this.btnAddDLine.Enabled = this.btnDelDLine.Enabled = false;

            this.DGCell1 = null;

            if (this.m_ndgDCurrentRowIndex > -1 && this.m_ndgDCurrentRowIndex < this.m_dvD.Count)
            {
                this.dgD.UnSelect(this.dgD.CurrentRowIndex);
                this.dgD.Select(this.m_ndgDCurrentRowIndex);
                this.dgD.CurrentRowIndex = this.m_ndgDCurrentRowIndex;
            }

            UIDCol();

            this.Cursor = Cursors.Default;

            #endregion
        }

        protected virtual void UIDCol()
        {
        }

        protected virtual void MShowOnly()
        {
            this.btnAdd.Enabled = this.btnEdit.Enabled = this.btnDel.Enabled = this.btnCopy.Enabled = false;
            this.btnSave.Enabled = this.btnCancel.Enabled = this.btnSubmit.Enabled = this.btnAudit.Enabled = this.btnUnAudit.Enabled = false;
            this.btnQuery.Enabled = false;

            this.btnPrint.Enabled = this.btnExport.Enabled = this.btnProcess.Enabled = true;

            this.tabCtlMain.SelectedTab = this.tabPage2;
        }

        protected virtual int GetdgMAfterAddedRowIndex(int nFlag)
        {
            #region 新增数据成功并刷新后，获取行索引，一般为ID值最大的行索引
            int nMaxPKId = (int)this.m_dvM[0][this.m_strPKM], nRowIndex = 0;
            for (int i = 1; i < this.m_dvM.Count; i++)
            {
                if ((int)this.m_dvM[i][this.m_strPKM] > nMaxPKId) { nMaxPKId = (int)this.m_dvM[i][this.m_strPKM]; nRowIndex = i; }
            }
            return nRowIndex;
            #endregion
        }

        protected virtual int GetdgMCurrentRowIndex(int nFlag)
        {
            #region 非新增或删除数据并刷新后，获取行索引，一般不变
            int nPKId = ((int[])this.dgM.Tag)[0], nRowIndex = 0;
            for (int i = 0; i < this.m_dvM.Count; i++)
            {
                if ((int)this.m_dvM[i][this.m_strPKM] == nPKId) { nRowIndex = i; break; }
            }
            return nRowIndex;
            #endregion
        }

        protected virtual int GetdgMAfterDeletedRowIndex(int nFlag)
        {
            #region 删除数据成功并刷新后，获取行索引，一般为被删除行的下一行索引
            return ((int[])this.dgM.Tag)[1] <= this.m_dvM.Count - 1 ? (int)((int[])this.dgM.Tag)[1] : this.m_dvM.Count - 1;
            #endregion
        }

        protected virtual void UIDataBinding(int nFlag)
        {
        }

        protected virtual void UISpcDataBinding(int nFlag)
        {
        }

        protected virtual void UINavigation(int nFlag)
        {
            this.btnFRec.Enabled = this.btnPRec.Enabled = this.btnNRec.Enabled = this.btnLRec.Enabled = false;
            if (this.m_dvM != null && this.dgM.DataSource != null && this.dgM.CurrentRowIndex > -1)
            {
                if (this.dgM.CurrentRowIndex == 0 && this.m_dvM.Count > 1)
                    this.btnNRec.Enabled = this.btnLRec.Enabled = true;
                else if (this.dgM.CurrentRowIndex > 0 && this.dgM.CurrentRowIndex < this.m_dvM.Count - 1)
                    this.btnFRec.Enabled = this.btnPRec.Enabled = this.btnNRec.Enabled = this.btnLRec.Enabled = true;
                else if (this.dgM.CurrentRowIndex == this.m_dvM.Count - 1 && this.m_dvM.Count > 1)
                    this.btnFRec.Enabled = this.btnPRec.Enabled = true;
            }
        }

        protected virtual void UIShowMsgBox(string strMsg)
        {
            UICtrl.FmActive(this); MsgBox.ShowInfoMsg2(strMsg);
        }

        protected DialogResult UIShowYesNoMsgBox(string strMsg)
        {
            UICtrl.FmActive(this); return MsgBox.ShowYesNoMsg2(strMsg);
        }

        protected virtual void UICursor(Cursor cursor)
        {
            this.Cursor = cursor;
        }

        //*****************************************************************************************
        protected virtual void dgM_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.Cursor == Cursors.WaitCursor) return;

            try
            {
                if (e.Button == MouseButtons.Left && e.Clicks == 2 && this.dgM.HitTest(e.X, e.Y).Type == DataGrid.HitTestType.RowHeader)
                    this.tabCtlMain.SelectedIndex = 1;

                if (e.Button == MouseButtons.Left && e.Clicks == 2 && this.dgM.HitTest(e.X, e.Y).Type == DataGrid.HitTestType.Cell)
                {
                    if (this.dgM.CurrentCell.ColumnNumber == Utility.DataGridColumnNumber(this.dgM, "IsSelected") && Utility.IsContainsFieldName(this.dgM, "IsSelected"))
                    {
                        if (this.m_dvM[this.dgM.CurrentRowIndex]["IsSelected"].ToString() == "0")
                        {
                            #region 选定
                            if (this.m_dvM.AllowEdit)
                            {
                                this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
                                this.m_dvM[this.dgM.CurrentRowIndex]["IsSelected"] = 1;
                                this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
                            }
                            else
                            {
                                this.m_dvM.AllowEdit = true;
                                this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
                                this.m_dvM[this.dgM.CurrentRowIndex]["IsSelected"] = 1;
                                this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
                                this.m_dvM.AllowEdit = false;
                            }
                            #endregion
                        }
                        else if (this.m_dvM[this.dgM.CurrentRowIndex]["IsSelected"].ToString() == "1")
                        {
                            #region 非选定
                            if (this.m_dvM.AllowEdit)
                            {
                                this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
                                this.m_dvM[this.dgM.CurrentRowIndex]["IsSelected"] = 0;
                                this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
                            }
                            else
                            {
                                this.m_dvM.AllowEdit = true;
                                this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
                                this.m_dvM[this.dgM.CurrentRowIndex]["IsSelected"] = 0;
                                this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
                                this.m_dvM.AllowEdit = false;
                            }
                            #endregion
                        }
                    }
                    else
                    {
                        this.tabCtlMain.SelectedIndex = 1;
                    }
                }
            }
            catch { }
        }

        protected virtual void dgM_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                if (this.Cursor == Cursors.WaitCursor) return;

                System.Windows.Forms.DataGrid.HitTestInfo hitTestInfo = this.dgM.HitTest(e.X, e.Y);
                if (this.m_dvM != null && this.dgM.DataSource != null && hitTestInfo.Row > -1 && hitTestInfo.Row != ((int[])this.dgM.Tag)[1])
                {
                    this.dgM.Tag = new int[] { (int)this.m_dvM[hitTestInfo.Row][this.m_strPKM], hitTestInfo.Row };

                    UIDUpd();
                }

                UISpcDataBinding(0);

                UINavigation(0);
            }
            catch { }
        }

        protected virtual void dgD_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.Cursor == Cursors.WaitCursor) return;

            try
            {
                System.Windows.Forms.DataGrid.HitTestInfo hitTestInfo = this.dgD.HitTest(e.X, e.Y);
                if (hitTestInfo.Row > -1 && hitTestInfo.Row != (int)this.dgD.Tag)
                    this.dgD.Tag = hitTestInfo.Row;
            }
            catch { }

            try
            {
                if (e.Button == MouseButtons.Left && e.Clicks == 2 && this.dgD.HitTest(e.X, e.Y).Type == DataGrid.HitTestType.Cell && Utility.IsContainsFieldName(this.dgD, "IsSelected"))
                {
                    if (this.dgD.CurrentCell.ColumnNumber == Utility.DataGridColumnNumber(this.dgD, "IsSelected"))
                    {
                        if (this.m_dvD[this.dgD.CurrentRowIndex]["IsSelected"].ToString() == "0")
                        {
                            #region 选定
                            if (this.m_dvD.AllowEdit)
                            {
                                this.m_dvD[this.dgD.CurrentRowIndex].Row.BeginEdit();
                                this.m_dvD[this.dgD.CurrentRowIndex]["IsSelected"] = 1;
                                this.m_dvD[this.dgD.CurrentRowIndex].Row.EndEdit();
                            }
                            else
                            {
                                this.m_dvD.AllowEdit = true;
                                this.m_dvD[this.dgD.CurrentRowIndex].Row.BeginEdit();
                                this.m_dvD[this.dgD.CurrentRowIndex]["IsSelected"] = 1;
                                this.m_dvD[this.dgD.CurrentRowIndex].Row.EndEdit();
                                this.m_dvD.AllowEdit = false;
                            }
                            #endregion
                        }
                        else if (this.m_dvD[this.dgD.CurrentRowIndex]["IsSelected"].ToString() == "1")
                        {
                            #region 非选定
                            if (this.m_dvD.AllowEdit)
                            {
                                this.m_dvD[this.dgD.CurrentRowIndex].Row.BeginEdit();
                                this.m_dvD[this.dgD.CurrentRowIndex]["IsSelected"] = 0;
                                this.m_dvD[this.dgD.CurrentRowIndex].Row.EndEdit();
                            }
                            else
                            {
                                this.m_dvD.AllowEdit = true;
                                this.m_dvD[this.dgD.CurrentRowIndex].Row.BeginEdit();
                                this.m_dvD[this.dgD.CurrentRowIndex]["IsSelected"] = 0;
                                this.m_dvD[this.dgD.CurrentRowIndex].Row.EndEdit();
                                this.m_dvD.AllowEdit = false;
                            }
                            #endregion
                        }
                    }
                }
            }
            catch { }
        }

        protected virtual void dgD_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.Cursor == Cursors.WaitCursor) return;

                System.Windows.Forms.DataGrid.HitTestInfo hitTestInfo = this.dgD.HitTest(e.X, e.Y);

                this.m_ndgDCurrentRowIndex = hitTestInfo.Row;
            }
            catch { }
        }

        protected virtual void dgD_MouseMove(object sender, MouseEventArgs e)
        {

        }

        protected virtual void dgM_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.Cursor == Cursors.WaitCursor) return;

            try
            {
                UISpcDataBinding(0);
            }
            catch { }
        }

        protected virtual void dgM_CurrentCellChanged(object sender, System.EventArgs e)
        {
        }

        protected virtual void dgD_CurrentCellChanged(object sender, System.EventArgs e)
        {
        }

        //*****************************************************************************************
        protected virtual void FmKeyDown(object sender, KeyEventArgs e)
        {
        }

        protected virtual void FmB_KeyDown(object sender, KeyEventArgs e)
        {
            FmKeyDown(sender, e);
        }

        protected virtual void FmB_FormClosing(object sender, FormClosingEventArgs e)
        {
            #region 模块退出确认

            this.m_bCanExitModule = true;

            if (this.m_bOpState == BusiOpState.AddBusiData || this.m_bOpState == BusiOpState.EditBusiData)
            {
                if (MsgBox.ShowYesNoMsg2("正在增加或编辑数据，确定要退出吗？") != DialogResult.Yes)
                {
                    this.m_bCanExitModule = false;
                    e.Cancel = true;
                }
            }

            #endregion
        }

        protected virtual void FmB_Load(object sender, System.EventArgs e)
        {
            #region 加载窗体

            this.m_bmdObj = new BusinessObject();

            this.m_bmdObj.BusiDBId = this.m_nModuleBusiDBId;

            GetModuleBusiParams();

            InitDGMTabStyle();
            InitDGDTabStyle();

            try
            {
                if (this.m_trdGetMDBusiData != null && this.m_trdGetMDBusiData.IsAlive) this.m_trdGetMDBusiData.Abort();
            }
            catch { }
            finally { this.m_trdGetMDBusiData = null; }

            this.m_trdGetMDBusiData = new Thread(new ThreadStart(this.GetMDBusiData));
            this.m_trdGetMDBusiData.Start();

            #endregion
        }

        protected virtual void FmB_Activated(object sender, EventArgs e)
        {
            #region 激活窗体
            if (!this.Disposing && !this.IsDisposed && !this.m_bFirstGetData && this.m_bActivatedRefresh && (this.m_bOpState != BusiOpState.AddBusiData && this.m_bOpState != BusiOpState.EditBusiData))
            {
                if (this.m_trdGetMDBusiData != null && this.m_trdGetMDBusiData.IsAlive) return;
                this.m_trdGetMDBusiData = new Thread(new ThreadStart(this.GetMDBusiData));
                this.m_trdGetMDBusiData.Start();
            }
            #endregion
        }

        protected virtual void btnAdd_Click(object sender, System.EventArgs e)
        {
            #region 新增业务数据
            this.m_dvM.Table.AcceptChanges();
            this.m_dvD.Table.AcceptChanges();

            this.m_dvM.AllowNew = true;
            DataRowView drv = this.m_dvM.AddNew();
            drv.BeginEdit(); drv[this.m_strPKM] = 0; drv.EndEdit();
            this.m_dvM.AllowNew = false;

            this.dgM.CurrentRowIndex = this.m_dvM.Count - 1;
            this.m_dvM.AllowEdit = true;
            this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();

            UpdCtl2(new string[] { "pnltabPage201" });

            this.btnFRec.Enabled = this.btnPRec.Enabled = this.btnNRec.Enabled = this.btnLRec.Enabled = false;
            this.dgM.Enabled = false;
            this.btnAdd.Enabled = this.btnEdit.Enabled = this.btnDel.Enabled = this.btnCopy.Enabled = this.btnAudit.Enabled = this.btnUnAudit.Enabled = this.btnPrint.Enabled = this.btnSelectAll.Enabled = this.btnUnSelectAll.Enabled = /*this.btnProcess.Enabled =*/ false;
            this.btnSave.Enabled = this.btnCancel.Enabled = true;

            this.btnAddDLine.Enabled = this.m_dvD.AllowEdit = true;
            this.dgD.ReadOnly = false;

            this.m_dvD.Table.Clear();
            this.m_dvD.RowFilter = "";

            this.m_bOpState = BusiOpState.AddBusiData;

            if (this.dgM.TableStyles.Count > 0)
                this.dgM.TableStyles[0].AllowSorting = false;
            if (this.dgD.TableStyles.Count > 0)
                this.dgD.TableStyles[0].AllowSorting = false;

            this.tabCtlMain.SelectedIndex = 1;

            UIDCol();
            #endregion
        }

        protected virtual void btnEdit_Click(object sender, System.EventArgs e)
        {
            #region 编辑业务数据
            this.m_dvM.Table.AcceptChanges();
            this.m_dvD.Table.AcceptChanges();

            this.m_dvM.AllowEdit = true;
            this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();

            UpdCtl2(new string[] { "pnltabPage201" });

            this.btnFRec.Enabled = this.btnPRec.Enabled = this.btnNRec.Enabled = this.btnLRec.Enabled = false;
            this.dgM.Enabled = false;
            this.btnAdd.Enabled = this.btnEdit.Enabled = this.btnDel.Enabled = this.btnCopy.Enabled = this.btnAudit.Enabled = this.btnUnAudit.Enabled = this.btnPrint.Enabled = this.btnSelectAll.Enabled = this.btnUnSelectAll.Enabled = /*this.btnProcess.Enabled =*/ false;
            this.btnSave.Enabled = this.btnCancel.Enabled = true;

            this.btnAddDLine.Enabled = this.m_dvD.AllowEdit = true;
            this.btnDelDLine.Enabled = this.dgD.CurrentRowIndex > -1;
            this.dgD.ReadOnly = false;

            this.m_bOpState = BusiOpState.EditBusiData;

            if (this.tabCtlMain.SelectedIndex == 0)
            {
                this.tabCtlMain.SelectedIndex = 1;
                this.dgM.Tag = new int[] { (int)m_dvM[dgM.CurrentRowIndex][m_strPKM], dgM.CurrentRowIndex };
                if (dgD.DataSource == null)
                {
                    this.UIDUpd();
                }            
            }

            //if (this.dgM.TableStyles.Count > 0)
            //    this.dgM.TableStyles[0].AllowSorting = false;
            if (this.dgD.TableStyles.Count > 0)
                this.dgD.TableStyles[0].AllowSorting = false;
                
            #endregion
        }

        protected virtual void btnDel_Click(object sender, System.EventArgs e)
        {
            #region 删除业务数据
            if (MsgBox.ShowYesNoMsg2("确定要删除吗？") == DialogResult.Yes)
            {
                this.m_bOpState = BusiOpState.DelBusiData;

                if (this.m_trdUpdMDBusiData != null && this.m_trdUpdMDBusiData.IsAlive)
                {
                    MsgBox.ShowInfoMsg2("应用程序后台正忙，请稍后再试！"); return;
                }
                this.m_trdUpdMDBusiData = new Thread(new ThreadStart(this.UpdMDBusiData));
                this.m_trdUpdMDBusiData.Start();
            }
            #endregion
        }

        protected virtual void btnSave_Click(object sender, System.EventArgs e)
        {
            #region 保存业务数据
            if (this.m_trdUpdMDBusiData != null && this.m_trdUpdMDBusiData.IsAlive)
            {
                MsgBox.ShowInfoMsg2("应用程序后台正忙，请稍后再试！"); return;
            }
            this.m_trdUpdMDBusiData = new Thread(new ThreadStart(this.UpdMDBusiData));
            this.m_trdUpdMDBusiData.Start();
            #endregion
        }

        protected virtual void btnCancel_Click(object sender, System.EventArgs e)
        {
            #region 取消操作业务数据
            this.m_bOpState = BusiOpState.None;
            if (this.m_bmdObj.BusiDataPre != null)
            {
                this.m_bmdObj.BusiData.Clear();
                this.m_bmdObj.BusiData = this.m_bmdObj.BusiDataPre.Copy();
                UIMUpd();
            }
            #endregion
        }

        protected virtual void btnCopy_Click(object sender, System.EventArgs e)
        {
            #region 复制业务数据
            this.btnCopy.Enabled = false;
            //表头数据
            DataRow drMain = this.m_dvM[this.dgM.CurrentRowIndex].Row;
            //表体数据
            DataTable dtDetail = this.m_dvD.Table.Clone();
            for (int i = 0; i < this.m_dvD.Count; i++)
            {
                dtDetail.ImportRow(this.m_dvD[i].Row);
            }
            //复制表头
            this.btnAdd_Click(null, null);
            int nColCountMain = drMain.Table.Columns.Count;
            for (int i = 0; i < nColCountMain; i++)
            {
                string strColName = drMain.Table.Columns[i].ColumnName;
                for (int j = 0; j < this.m_dvM.Table.Columns.Count; j++)
                {
                    bool bCopy = true;
                    if (this.m_strAryDisCopyTableFieldMain != null && this.m_strAryDisCopyTableFieldMain.Length > 0)
                    {
                        for (int k = 0; k < this.m_strAryDisCopyTableFieldMain.Length; k++)
                        {
                            if (strColName.ToLower() == this.m_strAryDisCopyTableFieldMain[k].ToLower()) { bCopy = false; break; }
                        }
                    }
                    if (!bCopy) continue;
                    if (strColName == this.m_dvM.Table.Columns[j].ColumnName)
                    {
                        if (strColName.ToLower() == this.m_strPKM.ToLower())
                            this.m_dvM[this.dgM.CurrentRowIndex][strColName] = -1;
                        else
                            this.m_dvM[this.dgM.CurrentRowIndex][strColName] = drMain[i];
                        break;
                    }
                }
            }
            this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
            //复制表体
            this.m_dvD.AllowEdit = true;
            this.dgD.ReadOnly = false;
            foreach (DataRow drDetail in dtDetail.Rows)
            {
                this.btnAddDLine_Click(null, null);
                int nColCountDetail = drDetail.Table.Columns.Count;
                for (int i = 0; i < nColCountDetail; i++)
                {
                    string strColName = drDetail.Table.Columns[i].ColumnName;
                    for (int j = 0; j < this.m_dvD.Table.Columns.Count; j++)
                    {
                        bool bCopy = true;
                        if (this.m_strAryDisCopyTableFieldDetail != null && this.m_strAryDisCopyTableFieldDetail.Length > 0)
                        {
                            for (int k = 0; k < this.m_strAryDisCopyTableFieldDetail.Length; k++)
                            {
                                if (strColName.ToLower() == this.m_strAryDisCopyTableFieldDetail[k].ToLower()) { bCopy = false; break; }
                            }
                        }
                        if (!bCopy) continue;
                        if (strColName == this.m_dvD.Table.Columns[j].ColumnName)
                        {
                            if (strColName.ToLower() == this.m_strPKD.ToLower())
                                this.m_dvD[this.dgD.CurrentRowIndex][strColName] = -1;
                            else
                                this.m_dvD[this.dgD.CurrentRowIndex][strColName] = drDetail[i];
                            break;
                        }
                    }
                }
                this.m_dvD[this.dgD.CurrentRowIndex].Row.EndEdit();
            }
            #endregion
        }

        protected virtual void btnSubmit_Click(object sender, System.EventArgs e)
        {
            #region 提交业务数据
            this.m_bOpState = BusiOpState.SubmitBusiData;

            if (this.m_dvM.Count > 0) this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

            if (this.m_trdUpdMDBusiData != null && this.m_trdUpdMDBusiData.IsAlive)
            {
                MsgBox.ShowInfoMsg2("应用程序后台正忙，请稍后再试！"); return;
            }
            this.m_trdUpdMDBusiData = new Thread(new ThreadStart(this.UpdMDBusiData));
            this.m_trdUpdMDBusiData.Start();
            #endregion
        }

        protected virtual void btnAudit_Click(object sender, System.EventArgs e)
        {
            #region 审核业务数据
            this.m_bOpState = BusiOpState.AuditBusiData;

            if (this.m_dvM.Count > 0) this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

            if (this.m_trdUpdMDBusiData != null && this.m_trdUpdMDBusiData.IsAlive)
            {
                MsgBox.ShowInfoMsg2("应用程序后台正忙，请稍后再试！"); return;
            }
            this.m_trdUpdMDBusiData = new Thread(new ThreadStart(this.UpdMDBusiData));
            this.m_trdUpdMDBusiData.Start();
            #endregion
        }

        protected virtual void btnUnAudit_Click(object sender, System.EventArgs e)
        {
            #region 弃审业务数据
            this.m_bOpState = BusiOpState.UnAuditBusiData;

            if (this.m_dvM.Count > 0) this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

            if (this.m_trdUpdMDBusiData != null && this.m_trdUpdMDBusiData.IsAlive)
            {
                MsgBox.ShowInfoMsg2("应用程序后台正忙，请稍后再试！"); return;
            }
            this.m_trdUpdMDBusiData = new Thread(new ThreadStart(this.UpdMDBusiData));
            this.m_trdUpdMDBusiData.Start();
            #endregion
        }

        protected virtual void btnReg_Click(object sender, System.EventArgs e)
        {
            #region 记帐业务数据
            this.m_bOpState = BusiOpState.RegBusiData;

            if (this.m_dvM.Count > 0) this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

            if (this.m_trdUpdMDBusiData != null && this.m_trdUpdMDBusiData.IsAlive)
            {
                MsgBox.ShowInfoMsg2("应用程序后台正忙，请稍后再试！"); return;
            }
            this.m_trdUpdMDBusiData = new Thread(new ThreadStart(this.UpdMDBusiData));
            this.m_trdUpdMDBusiData.Start();
            #endregion
        }

        protected virtual void btnUnReg_Click(object sender, System.EventArgs e)
        {
            #region 反记帐业务数据
            this.m_bOpState = BusiOpState.UnRegBusiData;

            if (this.m_dvM.Count > 0) this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

            if (this.m_trdUpdMDBusiData != null && this.m_trdUpdMDBusiData.IsAlive)
            {
                MsgBox.ShowInfoMsg2("应用程序后台正忙，请稍后再试！"); return;
            }
            this.m_trdUpdMDBusiData = new Thread(new ThreadStart(this.UpdMDBusiData));
            this.m_trdUpdMDBusiData.Start();
            #endregion
        }

        protected virtual void btnPrint_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.cntMnuPrint.Show((sender as Button), new Point(0, (sender as Button).Height));
        }

        protected virtual void btnPrint_Click(object sender, System.EventArgs e)
        {
        }

        protected virtual void miPrtTab_Click(object sender, EventArgs e)
        {
            ExecPrtTab();
        }

        protected virtual void miPrint_Click(object sender, EventArgs e)
        {
            ExecPrint();
        }

        protected virtual void miPrintSettings_Click(object sender, EventArgs e)
        {
            ExecPrintSettings();
        }

        protected virtual void InitPrintSettingsName()
        {
        }

        protected virtual void ExecPrtTab()
        {
        }

        protected virtual void ExecPrint()
        {
        }

        protected virtual void ExecPrintSettings()
        {
            FmPrintSettings f = new FmPrintSettings();
            PrintSettings.GetPrintSettings(this.m_strPrintSettings, ConfInfo.GetPrnSettingsFile(), f);
            Application.DoEvents();
            if (f.ShowDialog() == DialogResult.OK)
            {
                PrintSettings.SavePrintSettings(this.m_strPrintSettings, ConfInfo.GetPrnSettingsFile(), f);
            }
        }

        protected virtual void btnExport_Click(object sender, EventArgs e)
        {
        }

        protected virtual void btnQuery_Click(object sender, EventArgs e)
        {
            #region 查询业务数据
            this.m_bOpState = BusiOpState.BrowseBusiData;

            if (this.m_trdGetMDBusiData != null && this.m_trdGetMDBusiData.IsAlive)
            {
                MsgBox.ShowInfoMsg2("应用程序后台正忙，请稍后再试！"); return;
            }
            this.m_trdGetMDBusiData = new Thread(new ThreadStart(this.GetMDBusiData));
            this.m_trdGetMDBusiData.Start();
            #endregion
        }

        protected virtual void GetProcessContextMenu(ref ContextMenu cm)
        {
        }

        protected virtual void btnProcess_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ContextMenu cm = null;
                GetProcessContextMenu(ref cm);
                if(cm != null)
                    cm.Show((sender as Button), new Point(0, (sender as Button).Height));
            }
        }

        protected virtual void btnProcess_Click(object sender, EventArgs e)
        {
        }

        protected virtual void btnRefresh_Click(object sender, System.EventArgs e)
        {
            #region 刷新业务数据
            this.m_bOpState = BusiOpState.None;

            if (this.m_trdGetMDBusiData != null && this.m_trdGetMDBusiData.IsAlive)
            {
                MsgBox.ShowInfoMsg2("应用程序后台正忙，请稍后再试！"); return;
            }
            this.m_trdGetMDBusiData = new Thread(new ThreadStart(this.GetMDBusiData));
            this.m_trdGetMDBusiData.Start();
            #endregion
        }

        protected virtual void btnExit_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        #region 导航按钮
        //*****************************************************************************************
        protected virtual void btnFRec_Click(object sender, System.EventArgs e)
        {
            #region 首记录按钮
            if (this.m_dvM != null && this.dgM.DataSource != null && this.dgM.CurrentRowIndex > -1)
            {
                this.m_ndgDCurrentRowIndex = -1;
                this.dgM.UnSelect(this.dgM.CurrentRowIndex);
                this.dgM.CurrentRowIndex = 0;
                this.dgM.Tag = new int[] { (int)this.m_dvM[this.dgM.CurrentRowIndex][this.m_strPKM], this.dgM.CurrentRowIndex };
                this.dgM.Select(this.dgM.CurrentRowIndex);

                UIDUpd();
            }

            UISpcDataBinding(0);

            UINavigation(0);
            #endregion
        }

        protected virtual void btnPRec_Click(object sender, System.EventArgs e)
        {
            #region 上一记录按钮
            if (this.m_dvM != null && this.dgM.DataSource != null && this.dgM.CurrentRowIndex > 0)
            {
                this.m_ndgDCurrentRowIndex = -1;
                this.dgM.UnSelect(this.dgM.CurrentRowIndex);
                this.dgM.CurrentRowIndex = this.dgM.CurrentRowIndex - 1;
                this.dgM.Tag = new int[] { (int)this.m_dvM[this.dgM.CurrentRowIndex][this.m_strPKM], this.dgM.CurrentRowIndex };
                this.dgM.Select(this.dgM.CurrentRowIndex);

                UIDUpd();
            }

            UISpcDataBinding(0);

            UINavigation(0);
            #endregion
        }

        protected virtual void btnNRec_Click(object sender, System.EventArgs e)
        {
            #region 下记录按钮
            if (this.m_dvM != null && this.dgM.DataSource != null && this.dgM.CurrentRowIndex < this.m_dvM.Count - 1)
            {
                this.m_ndgDCurrentRowIndex = -1;
                this.dgM.UnSelect(this.dgM.CurrentRowIndex);
                this.dgM.CurrentRowIndex = this.dgM.CurrentRowIndex + 1;
                this.dgM.Tag = new int[] { (int)this.m_dvM[this.dgM.CurrentRowIndex][this.m_strPKM], this.dgM.CurrentRowIndex };
                this.dgM.Select(this.dgM.CurrentRowIndex);

                UIDUpd();
            }

            UISpcDataBinding(0);

            UINavigation(0);
            #endregion
        }

        protected virtual void btnLRec_Click(object sender, System.EventArgs e)
        {
            #region 末记录按钮
            if (this.m_dvM != null && this.dgM.DataSource != null && this.dgM.CurrentRowIndex > -1)
            {
                this.m_ndgDCurrentRowIndex = -1;
                this.dgM.UnSelect(this.dgM.CurrentRowIndex);
                this.dgM.CurrentRowIndex = this.m_dvM.Count - 1;
                this.dgM.Tag = new int[] { (int)this.m_dvM[this.dgM.CurrentRowIndex][this.m_strPKM], this.dgM.CurrentRowIndex };
                this.dgM.Select(this.dgM.CurrentRowIndex);

                UIDUpd();
            }

            UISpcDataBinding(0);

            UINavigation(0);
            #endregion
        }
        //*****************************************************************************************
        #endregion

        protected virtual void btnAddDLine_Click(object sender, System.EventArgs e)
        {
            #region 新增业务数据行
            this.m_dvD.AllowNew = true;
            DataRowView drv = this.m_dvD.AddNew();
            drv.BeginEdit();
            if (this.m_strPKD != null && this.m_strPKD != "")
                drv[this.m_strPKD] = -1;
            drv[this.m_strFKD] = this.m_dvM[this.dgM.CurrentRowIndex][this.m_strPKM];
            drv.EndEdit();
            this.m_dvD.AllowNew = false;

            this.dgD.Tag = this.dgD.CurrentRowIndex = this.m_dvD.Count - 1;
            this.btnDelDLine.Enabled = this.dgD.CurrentRowIndex > -1;

            if (this.dgD.TableStyles.Count > 0)
                this.dgD.TableStyles[0].AllowSorting = false;
            #endregion
        }

        protected virtual void btnDelDLine_Click(object sender, System.EventArgs e)
        {
            #region 删除业务数据行
            if (this.DGCell1 != null)
            {
                DataGridCell cell = (DataGridCell)this.DGCell1[0];
                if (this.dgD.CurrentRowIndex == cell.RowNumber) this.DGCell1 = null;
            }
            if (this.dgD.CurrentRowIndex > -1)
            {
                this.m_dvD.AllowDelete = true;
                this.m_dvD.Delete(this.dgD.CurrentRowIndex);
                this.m_dvD.AllowDelete = false;
            }
            this.btnDelDLine.Enabled = this.dgD.CurrentRowIndex > -1;
            #endregion
        }

        protected virtual void tabCtlMain_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            #region 切换选项卡
            try
            {
                if (this.Cursor == Cursors.WaitCursor)
                    this.tabCtlMain.SelectedIndex = 0;

                if (this.tabCtlMain.SelectedIndex == 1 &&
                    this.dgD.CurrentRowIndex > -1 &&
                    this.m_bOpState != BusiOpState.AddBusiData &&
                    this.m_bOpState != BusiOpState.EditBusiData)
                {
                    Application.DoEvents();
                    this.dgM.Tag = new int[]{(int)m_dvM[dgM.CurrentRowIndex][m_strPKM], dgM.CurrentRowIndex};
                    UISpcDataBinding(0);
                    UIDUpd();
                    Application.DoEvents();
                }
            }
            catch { }
            #endregion
        }

        protected virtual void btnSelectAll_Click(object sender, EventArgs e)
        {
            SelectData(1);
        }

        protected virtual void btnUnSelectAll_Click(object sender, EventArgs e)
        {
            SelectData(0);
        }

        protected virtual void SelectData(int nFlag)
        {
            #region 全选/全消数据

            if (this.m_bOpState == BusiOpState.AddBusiData || this.m_bOpState == BusiOpState.EditBusiData) return;

            try
            {
                if (this.m_dvM != null && this.dgM.CurrentRowIndex > -1)
                {
                    bool bExist = false;
                    DataRow dr = this.m_dvM[0].Row;
                    int nColCount = dr.Table.Columns.Count;
                    for (int i = 0; i < nColCount; i++)
                    {
                        if (dr.Table.Columns[i].ColumnName.ToLower() == "IsSelected".ToLower())
                        {
                            bExist = true; break;
                        }
                    }
                    Application.DoEvents();

                    if (bExist)
                    {
                        int ndx = 0;
                        if (!this.m_dvM.AllowEdit)
                            this.m_dvM.AllowEdit = true;

                        for (int i = 0; i < this.m_dvM.Count; i++)
                        {
                            ndx++; if (ndx % 100 == 0) { ndx = 0; Application.DoEvents(); }
                            this.m_dvM[i].Row.BeginEdit();
                            this.m_dvM[i]["IsSelected"] = nFlag;
                            this.m_dvM[i].Row.EndEdit();
                        }
                        this.m_dvM.AllowEdit = false;
                    }
                }
            }
            catch { }

            #endregion
        }

        #region 控件设置、控件刷新
        protected virtual void UpdCtl1(string[] strAryCCtlNames)
        {
            if (strAryCCtlNames != null && strAryCCtlNames.Length > 0)
            {
                for (int i = 0; i < strAryCCtlNames.Length; i++)
                {
                    foreach (Control cc in Controls.Find(strAryCCtlNames[i], true))
                    {
                        foreach (Control c in cc.Controls)
                        {
                            if (c is TextBox) { (c as TextBox).DataBindings.Clear(); (c as TextBox).Clear(); (c as TextBox).ReadOnly = true; c.BackColor = SystemColors.ControlLightLight; }
                            if (c is Label && c.Name.Length >= 5 && c.Name.Substring(0, 5).ToLower() == "lblrs") c.Visible = false;
                            if (c is Button && c.Name.Length >= 4 && c.Name.Substring(0, 4).ToLower() == "btns") c.Visible = false;
                            if (c is Button && c.Name.Length >= 4 && c.Name.Substring(0, 4).ToLower() == "btnc") c.Visible = false;
                        }
                    }
                }
            }
        }

        protected virtual void UpdCtl2(string[] strAryCCtlNames)
        {
            if (strAryCCtlNames != null && strAryCCtlNames.Length > 0)
            {
                for (int i = 0; i < strAryCCtlNames.Length; i++)
                {
                    foreach (Control cc in Controls.Find(strAryCCtlNames[i], true))
                    {
                        foreach (Control c in cc.Controls)
                        {
                            if (c is TextBox && c.Name.Length >= 4 && c.Name.Substring(0, 4).ToLower() == "txtr")
                            {
                                c.BackColor = SystemColors.Control;
                            }
                            if (c is TextBox && c.Name.Length >= 4 && c.Name.Substring(0, 4).ToLower() == "txts")
                            {
                                c.BackColor = Color.LightGray;
                            }
                            if (c is TextBox && c.Name.Length >= 4 && c.Name.Substring(0, 4).ToLower() == "txtw")
                            {
                                (c as TextBox).ReadOnly = false; c.BackColor = SystemColors.ControlLightLight;
                            }
                            if (c is TextBox && c.Name.Length >= 5 && c.Name.Substring(0, 5).ToLower() == "txtsw")
                            {
                                (c as TextBox).ReadOnly = false; c.BackColor = SystemColors.Info;
                            }
                            if (c is Label && c.Name.Length >= 5 && c.Name.Substring(0, 5).ToLower() == "lblrs") c.Visible = true;
                            if (c is Button && c.Name.Length >= 4 && c.Name.Substring(0, 4).ToLower() == "btns") c.Visible = true;
                            if (c is Button && c.Name.Length >= 4 && c.Name.Substring(0, 4).ToLower() == "brnc") c.Visible = true;
                        }
                    }
                }
            }
        }

        protected virtual void TextBox_TextChanged1Event(string[] txtCtrlNames)
        {
            foreach (Control cc in Controls.Find("pnltabPage101", true))
            {
                foreach (Control c in cc.Controls)
                {
                    for (int j = 0; j < txtCtrlNames.Length; j++)
                    {
                        if (c is TextBox && c.Name.ToLower() == txtCtrlNames[j].ToLower())
                        {
                            (c as TextBox).TextChanged += new EventHandler(UICtrl.TextBox_TextChanged1);
                        }
                    }
                }
            }
        }

        protected virtual void TextBox_TextChanged1Event(string[] strAryCCtlNames, string[] txtCtrlNames)
        {
            if (strAryCCtlNames != null && strAryCCtlNames.Length > 0)
            {
                for (int i = 0; i < strAryCCtlNames.Length; i++)
                {
                    foreach (Control cc in Controls.Find(strAryCCtlNames[i], true))
                    {
                        foreach (Control c in cc.Controls)
                        {
                            for (int j = 0; j < txtCtrlNames.Length; j++)
                            {
                                if (c is TextBox && c.Name.ToLower() == txtCtrlNames[j].ToLower())
                                {
                                    (c as TextBox).TextChanged += new EventHandler(UICtrl.TextBox_TextChanged1);
                                }
                            }
                        }
                    }
                }
            }
        }

        protected virtual void InitCtrlToolTip()
        {
            this.toolTip1.SetToolTip(this.btnFRec, "首记录");
            this.toolTip1.SetToolTip(this.btnPRec, "上一记录");
            this.toolTip1.SetToolTip(this.btnNRec, "下一记录");
            this.toolTip1.SetToolTip(this.btnLRec, "末记录");
        }
        #endregion

        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        protected virtual void GetModuleBusiParams()
        {
            BusinessObject bo = new BusinessObject();
            bo.BusiDBId = this.m_nModuleBusiDBId;
            bo.BusiDataSQL = new string[] { "select * from ModuleBusiObject where ModuleFmName='" + this.m_strModuleName + "'" };
            bo.GetBusiData();
            if (bo.BusiMsg[0] == "0")
            {
                MsgBox.ShowErrMsg2(bo.BusiMsg[1]);
            }
            else if (bo.BusiMsg[0] == "1" && bo.BusiData.Tables[0].Rows.Count > 0)
            {
                DataRow dr = bo.BusiData.Tables[0].Rows[0];

                this.m_bmdObj.BusiTableFlag = (int)dr["TabFlag"];

                this.m_bmdObj.BusiName = dr["BusiName"].ToString();

                this.m_bmdObj.BusiMPKDFK1 = dr["MPKDFK1"].ToString();

                this.m_bmdObj.BusiDataSQL = dr["GetSQL"].ToString().Trim().Split(new char[] { ',' });
                this.m_bmdObj.BusiAttaSQL = new string[] { "1=1", "1=1" };
                this.m_bmdObj.BusiTableNames = dr["TabNames"].ToString().Trim().Split(new char[] { ',' });

                this.m_bmdObj.BusiAddDataSP = dr["AddDataSP"].ToString().Trim().Split(new char[] { ',' });
                this.m_bmdObj.BusiEditDataSP = dr["EditDataSP"].ToString().Trim().Split(new char[] { ',' });
                this.m_bmdObj.BusiDelDataSP = dr["DelDataSP"].ToString().Trim().Split(new char[] { ',' });
                this.m_bmdObj.BusiSubmitDataSP = dr["SubmitDataSP"].ToString().Trim().Split(new char[] { ',' });
                this.m_bmdObj.BusiAuditDataSP = dr["AuditDataSP"].ToString().Trim().Split(new char[] { ',' });
                this.m_bmdObj.BusiUnAuditDataSP = dr["UnAuditDataSP"].ToString().Trim().Split(new char[] { ',' });
                this.m_bmdObj.BusiRegDataSP = dr["RegDataSP"].ToString().Trim().Split(new char[] { ',' });
                this.m_bmdObj.BusiUnRegDataSP = dr["UnRegDataSP"].ToString().Trim().Split(new char[] { ',' });

                this.m_strPKM = dr["MPK"].ToString();
                this.m_strFKD = dr["DFK"].ToString();
                this.m_strPKD = dr["DPK"].ToString();
                this.m_strdvMTableName = dr["MView"].ToString();
                this.m_strdvDTableName = dr["DView"].ToString();
            }
        }
    }
}