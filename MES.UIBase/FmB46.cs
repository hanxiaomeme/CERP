using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using FastReport;
using System.Text.RegularExpressions;
using System.IO;
using System.Data.SqlClient;

namespace NDF.UIBase
{
    using NDF.DAL;
    using NDF.Model;

    public partial class FmB46 : Form
    {
        public FmB46()
        {
            InitializeComponent();

            this.m_hsdgD = ((HScrollBar)this.dgD.Controls[0]);
            this.m_vsdgD = ((VScrollBar)this.dgD.Controls[1]);
            this.m_hsdgD.ValueChanged += new EventHandler(this.ScrollBar_ValueChanged);
            this.m_vsdgD.ValueChanged += new EventHandler(this.ScrollBar_ValueChanged);
        }

        #region 业务服务、变量和相关属性
        /// <summary>
        /// 是否仅仅显示单据
        /// </summary>
        public bool isShowOnly
        {
            get { return m_bShowOnly; }
            set { m_bShowOnly = value; }
        }
        protected bool m_bShowOnly = false;

        /// <summary>
        /// 模块名称（用于从数据库中访问当前模块操作信息）
        /// </summary>
        public string ModuleName
        {
            get { return this.m_strModuleName; }
            set { this.m_strModuleName = value; }
        }
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
        /// 业务对象
        /// </summary>
        protected BusinessObject m_bmdObj = new BusinessObject();

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
        /// 数据网格的水平滚动条
        /// </summary>
        protected HScrollBar m_hsdgD = null;

        /// <summary>
        /// 数据网格的垂直滚动条
        /// </summary>
        protected VScrollBar m_vsdgD = null;

        /// <summary>
        /// 合计字段
        /// </summary>
        protected string[] m_strArySumFields = null;

        /// <summary>
        /// 主表ID
        /// </summary>
        public string CurrentMID
        {
            get { return this.MainID; }
            set { this.MainID = value; }
        }
        protected string MainID = "";

        protected DataRowView m_drv = null;

        #endregion

        protected enum MainIDType { First = 0, Last = 9, Next = 1, Previous = -1 };

        /// <summary>
        /// 0:第一条记录 -1:上一条记录 1:下一条记录 9:最后一条记录
        /// </summary>
        /// <param name="typeID">类型</param>
        /// <returns></returns>
        protected virtual string GetMainID(MainIDType typeID)
        {
            #region 获取单据ID

            //this.Cursor = Cursors.WaitCursor;

            string str = "";
            if (typeID == MainIDType.Last) //获取最后单据ID
                str = "select isnull(Max(" + m_strPKM + "),0) from " + m_strdvMTableName;

            else if (typeID == MainIDType.Previous) //获取上一条单据ID
                str = "select Max(" + m_strPKM + ") from " + m_strdvMTableName
                    + " where " + m_strPKM + " < " + MainID;

            else if (typeID == MainIDType.Next) //获取下一条单据ID
                str = "select min(" + m_strPKM + ") from " + m_strdvMTableName
                    + " where " + m_strPKM + " > " + MainID;

            else if (typeID == MainIDType.First)
                str = "select isnull(min(" + m_strPKM + "),0) from " + m_strdvMTableName;

            BusinessObject bo = new BusinessObject();
            bo.BusiDataSQL = new string[] { str };
            bo.GetBusiData();
            //this.Cursor = Cursors.Default;
            if (bo.BusiData.Tables[0].Rows[0][0].ToString() != "")
            {
                return bo.BusiData.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                return "-1";
            }

            #endregion
        }


        /// <summary>
        /// 0:初始状态 1:新增  2:编辑
        /// </summary>
        /// <param name="value">类型</param>
        protected void SetBtnMode(int value)
        {
            #region 设置按钮状态
            if (value == 0)
            {
                this.Btn_Add.Enabled = Btn_Previous.Enabled = Btn_Next.Enabled = true;
                this.Btn_First.Enabled = Btn_Last.Enabled = true;
                this.Btn_Edit.Enabled = Btn_Del.Enabled = Btn_PrintMenu.Enabled = m_dvM.Count > 0;
                this.Btn_Save.Enabled = Btn_Cancel.Enabled = Btn_Audit.Enabled = Btn_UnAudit.Enabled = false;
                this.btnRef1.Visible = btnRefDate.Visible = false;
                this.Btn_SetAtt.Enabled = this.Btn_DelAtt.Enabled = false;
            }
            else if (value == 1)
            {
                this.Btn_Previous.Enabled = Btn_Next.Enabled = Btn_First.Enabled = Btn_Last.Enabled = false;
                this.Btn_Add.Enabled = Btn_Edit.Enabled = Btn_Del.Enabled = false;
                this.Btn_Audit.Enabled = Btn_UnAudit.Enabled = Btn_PrintMenu.Enabled = false;
                this.Btn_Save.Enabled = Btn_Cancel.Enabled = true;
                this.btnAddDLine.Enabled = true;
                this.Btn_SetAtt.Enabled = this.Btn_DelAtt.Enabled = true;
            }
            else if (value == 2)
            {
                this.Btn_Previous.Enabled = Btn_Next.Enabled = Btn_First.Enabled = Btn_Last.Enabled = false;
                this.Btn_Add.Enabled = Btn_Edit.Enabled = Btn_Del.Enabled = false;
                this.Btn_Audit.Enabled = Btn_UnAudit.Enabled = Btn_PrintMenu.Enabled = false;
                this.Btn_Save.Enabled = Btn_Cancel.Enabled = true;
                this.Btn_SetAtt.Enabled = this.Btn_DelAtt.Enabled = true;
                this.btnAddDLine.Enabled = true;
                this.btnDelDLine.Enabled = this.dgD.CurrentRowIndex > -1;
            } 
            #endregion
        }


        #region 数据操作相关

        protected delegate void UIGetData();

        //委托
        protected void DoGetData()
        {
            UIGetData UIGet = new UIGetData(GetMDBusiData);
            this.BeginInvoke(UIGet);
        }

        //获取数据GetMDBusiData()-->GetSQL()-->MTableUpd()
        protected virtual void GetMDBusiData()
        {
            #region 获取主从表业务的数据

            this.Cursor = Cursors.WaitCursor;

            //获取SQL语句
            this.GetMDSQL();

            this.m_bmdObj.GetBusiData();

            if (this.m_bmdObj.BusiMsg[0] == "1")
            {
                MTableUpd();
            }
            else
            {
                MsgBox.ShowErrMsg2(this.m_bmdObj.BusiMsg[1]);
            }

            this.Cursor = Cursors.Default;

            #endregion
        }

        protected virtual void GetMDSQL()
        {
            #region 获取主数据过滤条件

            string sqlM = "select * from " + m_strdvMTableName + " where " + m_strPKM + " = " + MainID;

            string sqlD = "select * from " + m_strdvDTableName + " where " + m_strFKD + " = " + MainID;

            this.m_bmdObj.BusiDataSQL = new string[] { sqlM, sqlD };

            #endregion
        }

        protected virtual void MTableUpd()
        {
            #region 主从表部分界面更新

            //主表绑定
            this.m_dvM = m_bmdObj.BusiData.Tables[0].DefaultView;

            //从表绑定
            m_bmdObj.BusiData.Tables[1].TableName = "t1";
            this.m_dvD = m_bmdObj.BusiData.Tables[1].DefaultView;
            this.m_dvD.AllowNew = this.m_dvD.AllowEdit = this.m_dvD.AllowDelete = false;
            this.dgD.DataSource = this.m_dvD;
            this.dgD.Enabled = this.dgD.ReadOnly = true;
            this.btnAddDLine.Enabled = this.btnDelDLine.Enabled = false;


            BaseHelper.SetReadMode(pnl_PageM);

            this.SetBtnMode(0);

            MTableDataBinding(0);
            MTableDataBinding2(0);

            this.m_bOpState = BusiOpState.None;

            this.statusBarPanel1.Text = "";

            if (this.m_dvM != null)
                this.statusBarPanel1.Text = "记录数:" + this.m_dvD.Count.ToString();

            if (this.m_bShowOnly) ShowOnly();

            UICtrl.AppDoEvents(3);

            #endregion
        }

        //------------------------------------------------------------------

        protected virtual void UpdMDBusiData()
        {
            #region 更新主从表业务数据
            try
            {
                this.Cursor = Cursors.WaitCursor;

                GetMDTableChgedData();


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
                this.Cursor = Cursors.Default;
            }

            if (this.m_bmdObj.BusiMsg[0] == "1" && SystemOption.MsgShowEnabled)
            {
                MsgBox.ShowInfoMsg2(this.m_bmdObj.BusiMsg[1]);
            }
            else if (this.m_bmdObj.BusiMsg[0] == "0")
            {
                MsgBox.ShowErrMsg2(this.m_bmdObj.BusiMsg[1]);
            }

            if (this.m_bmdObj.BusiMsg[0] == "1")
            {
                //新增,删除定位到最后单据
                if (m_bOpState == BusiOpState.AddBusiData || m_bOpState == BusiOpState.DelBusiData)
                {
                    this.MainID = GetMainID(MainIDType.Last);
                }

                new Thread(DoGetData).Start();              
            }
            #endregion
        }

        protected virtual void GetMDTableChgedData()
        {
            #region 获取主从表操作业务数据
            if (this.m_dvM.Count > 0)
            {
                this.Txt_BillCode.Focus();      //切换焦点,使最后的TextBox更新数据到DataView
                this.m_dvM[0].Row.EndEdit();           
            }
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
                    dtMain.ImportRow(this.m_dvM[0].Row);
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
                dtMain.ImportRow(this.m_dvM[0].Row);
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

        #endregion

        #region 窗体载入,关闭事件
        protected virtual void FmB_Load(object sender, System.EventArgs e)
        {
            #region 加载窗体

            this.tabPage1.Text = this.lblModuleTitle.Text = this.Text;

            BusinessInfoDAL busiDAL = new BusinessInfoDAL();
            BusinessInfo busiInfo = busiDAL.GetModel(ModuleName);

            this.m_strPKM = busiInfo.MPK;
            this.m_strPKD = busiInfo.DPK;
            this.m_strFKD = busiInfo.DFK;
            this.m_strdvMTableName = busiInfo.MView;
            this.m_strdvDTableName = busiInfo.DView;

            if (string.IsNullOrEmpty(MainID))
            {
                this.MainID = GetMainID(MainIDType.Last);
            }

            this.InitDGDTabStyle();

            //this.GetMDBusiData();

            while(!this.IsHandleCreated) {;}
            Thread t = new Thread(DoGetData);
            t.IsBackground = true;
            t.Start();
       

            #endregion
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
        #endregion

        #region 相关按钮事件
        //新增
        protected virtual void btnAdd_Click(object sender, System.EventArgs e)
        {
            #region 新增业务数据
            this.m_dvM.Table.AcceptChanges();
            this.m_dvD.Table.AcceptChanges();

            this.m_dvM.Table.Clear();
            this.m_dvM.AllowNew = true;
            m_drv = this.m_dvM.AddNew();
            m_drv.BeginEdit();
            m_drv[this.m_strPKM] = 0;
            this.m_dvM.AllowNew = false;

            this.dgD.ReadOnly = false;
            this.m_dvD.AllowEdit = true;
            this.m_dvD.Table.Clear();

            this.m_bOpState = BusiOpState.AddBusiData;
            BaseHelper.SetEditMode(pnl_PageM);
            this.SetBtnMode(1);

            DTableColumn();
            #endregion
        }
        //编辑
        protected virtual void btnEdit_Click(object sender, System.EventArgs e)
        {
            #region 编辑业务数据
            this.m_dvM.Table.AcceptChanges();
            this.m_dvD.Table.AcceptChanges();

            this.m_dvM.AllowEdit = true;
            m_drv = m_dvM[0];
            m_drv.BeginEdit();

            this.m_dvD.AllowEdit = true;
            this.dgD.ReadOnly = false;

            this.m_bOpState = BusiOpState.EditBusiData;
            BaseHelper.SetEditMode(pnl_PageM);
            this.SetBtnMode(2);

            #endregion
        }
        //删除
        protected virtual void btnDel_Click(object sender, System.EventArgs e)
        {
            #region 删除业务数据
            if (MsgBox.ShowYesNoMsg2("确定要删除吗？") == DialogResult.Yes)
            {
                this.m_bOpState = BusiOpState.DelBusiData;

                UpdMDBusiData();
            }
            #endregion
        }
        //保存
        protected virtual void btnSave_Click(object sender, System.EventArgs e)
        {
            #region 保存业务数据
            UpdMDBusiData();
            #endregion
        }
        //取消
        protected virtual void btnCancel_Click(object sender, System.EventArgs e)
        {
            #region 取消操作业务数据
            this.m_bOpState = BusiOpState.None;
            if (this.m_bmdObj.BusiDataPre != null)
            {
                this.m_bmdObj.BusiData.Clear();
                this.m_bmdObj.BusiData = this.m_bmdObj.BusiDataPre.Copy();
                MTableUpd();
            }
            #endregion
        }
        //审核
        protected virtual void btnAudit_Click(object sender, System.EventArgs e)
        {
            #region 审核业务数据
            this.m_bOpState = BusiOpState.AuditBusiData;

            if (this.m_dvM.Count > 0) this.m_dvM[0].Row.EndEdit();

            UpdMDBusiData();
            #endregion
        }
        //弃审
        protected virtual void btnUnAudit_Click(object sender, System.EventArgs e)
        {
            #region 弃审业务数据
            this.m_bOpState = BusiOpState.UnAuditBusiData;

            if (this.m_dvM.Count > 0) this.m_dvM[0].Row.EndEdit();

            UpdMDBusiData();
            #endregion
        }
        //打印
        protected virtual void miPrint_Click(object sender, EventArgs e)
        {
            #region 打印单据

            this.Report.RegisterData(m_dvM, m_strdvMTableName);
            this.Report.RegisterData(m_dvD, m_strdvDTableName);

            DataBand MBand = this.Report.FindObject("Data1") as DataBand;
            MBand.DataSource = this.Report.GetDataSource(m_strdvMTableName);

            DataBand DBand = this.Report.FindObject("Data3") as DataBand;
            DBand.DataSource = this.Report.GetDataSource(m_strdvDTableName);

            this.Report.Show();

            #endregion
        }
        //打印设计
        protected virtual void miDesgin_Click(object sender, EventArgs e)
        {
            #region 打印设计

            this.Report.RegisterData(m_dvM, m_strdvMTableName);
            this.Report.RegisterData(m_dvD, m_strdvDTableName);

            DataBand MBand = this.Report.FindObject("Data1") as DataBand;
            MBand.DataSource = this.Report.GetDataSource(m_strdvMTableName);

            DataBand DBand = this.Report.FindObject("Data3") as DataBand;
            DBand.DataSource = this.Report.GetDataSource(m_strdvDTableName);

            this.Report.Design();
            #endregion
        }
        //刷新
        protected virtual void btnRefresh_Click(object sender, System.EventArgs e)
        {
            #region 刷新业务数据
            this.m_bOpState = BusiOpState.None;
            new Thread(DoGetData).Start();
            #endregion
        }
        //退出
        protected virtual void btnExit_Click(object sender, System.EventArgs e)
        {
            #region 退出模块
            Close();
            #endregion
        }
        //第一条记录
        private void Btn_First_Click(object sender, EventArgs e)
        {
            #region 第一记录按钮

            this.MainID = GetMainID(MainIDType.First);
            new Thread(DoGetData).Start();
            this.tabPage1.Focus();

            #endregion
        }
        //上一条记录
        protected virtual void btnPRec_Click(object sender, System.EventArgs e)
        {
            #region 上一记录按钮

            string mainID = GetMainID(MainIDType.Previous);

            if (mainID == "-1")
            {
                MsgBox.ShowInfoMsg("没有更多记录!");
                return;
            }
            this.MainID = mainID;
            new Thread(DoGetData).Start();
            this.tabPage1.Focus();

            #endregion
        }
        //下一条记录
        protected virtual void btnNRec_Click(object sender, System.EventArgs e)
        {
            #region 下一记录按钮

            string mainID = GetMainID(MainIDType.Next);

            if (mainID == "-1")
            {
                MsgBox.ShowInfoMsg("没有更多记录!");
                return;
            }

            this.MainID = mainID;
            new Thread(DoGetData).Start();
            this.tabPage1.Focus();

            #endregion
        }
        //最后一条记录
        private void Btn_Last_Click(object sender, EventArgs e)
        {
            #region 最后一记录按钮

            this.MainID = GetMainID(MainIDType.Last);
            new Thread(DoGetData).Start();
            this.tabPage1.Focus();

            #endregion
        }
        //增行
        protected virtual void btnAddDLine_Click(object sender, System.EventArgs e)
        {
            #region 新增业务数据行
            this.m_dvD.AllowNew = true;
            DataRowView drv = this.m_dvD.AddNew();
            drv.BeginEdit();
            if (this.m_strPKD != null && this.m_strPKD != "")
                drv[this.m_strPKD] = -1;
            drv[this.m_strFKD] = this.m_dvM[0][this.m_strPKM];
            drv.EndEdit();
            this.m_dvD.AllowNew = false;

            this.dgD.Tag = this.dgD.CurrentRowIndex = this.m_dvD.Count - 1;
            this.btnDelDLine.Enabled = this.dgD.CurrentRowIndex > -1;

            if (this.m_dvD.Count > 0)
                this.dgD.TableStyles[0].AllowSorting = false;
            #endregion
        }
        //删行
        protected virtual void btnDelDLine_Click(object sender, System.EventArgs e)
        {
            #region 删除业务数据行

            if (this.dgD.CurrentRowIndex > -1)
            {
                this.m_dvD.AllowDelete = true;
                this.m_dvD.Delete(this.dgD.CurrentRowIndex);
                this.m_dvD.AllowDelete = false;
            }
            this.dgD.CurrentRowIndex = m_dvD.Count - 1;
            this.btnDelDLine.Enabled = this.dgD.CurrentRowIndex > -1;
            #endregion
        }

        //查询
        protected virtual void Btn_Query_Click(object sender, EventArgs e)
        {

        }

        #endregion

        protected virtual void InitDGDTabStyle()
        {

        }

        protected virtual void DTableColumn()
        {

        }

        protected virtual void ShowOnly()
        {
            #region 只读状态
            this.Btn_Add.Enabled = this.Btn_Edit.Enabled = this.Btn_Del.Enabled = false;
            this.Btn_Save.Enabled = this.Btn_Cancel.Enabled = this.Btn_Audit.Enabled = this.Btn_UnAudit.Enabled = false;

            this.Btn_PrintMenu.Enabled = true;

            this.pnlD_Button.Enabled = false;
            this.dgD.ReadOnly = true; 
            #endregion
        }

        protected virtual void MTableDataBinding(int nFlag)
        {
            #region 绑定字段
            foreach (Control c in this.pnl_PageM.Controls)
            {
                try
                {
                    if (c is TextBox && ((c as TextBox).DataBindings.Count <= 0))
                    {
                        c.Enter -= new EventHandler(this.textBox_Enter);
                        c.Leave -= new EventHandler(this.textBox_Leave);
                        c.KeyPress -= new KeyPressEventHandler(this.textBox_KeyPress);

                        c.Enter += new EventHandler(this.textBox_Enter);
                        c.Leave += new EventHandler(this.textBox_Leave);
                        c.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);

                        string strFieldName = "";
                        if (c is TextBox && c.Name.Length >= 5 && c.Name.Substring(0, 5).ToLower() == "txtr_")
                        {
                            strFieldName = c.Name.Substring(5);
                        }
                        if (c is TextBox && c.Name.Length >= 5 && c.Name.Substring(0, 5).ToLower() == "txts_")
                        {
                            strFieldName = c.Name.Substring(5);
                        }
                        if (c is TextBox && c.Name.Length >= 5 && c.Name.Substring(0, 5).ToLower() == "txtw_")
                        {
                            strFieldName = c.Name.Substring(5);
                        }
                        if (c is TextBox && c.Name.Length >= 6 && c.Name.Substring(0, 6).ToLower() == "txtsw_")
                        {
                            strFieldName = c.Name.Substring(6);
                        }

                        if (strFieldName != "")
                            (c as TextBox).DataBindings.Add("Text", this.m_dvM, strFieldName);
                    }
                }
                catch { }
            }
            #endregion
        }

        protected virtual void MTableDataBinding2(int nFlag)
        {

        }

        protected virtual void textBox_Enter(object sender, EventArgs e)
        {
            #region 光标进入文本框
            this.btnRef1.Visible = this.btnRefDate.Visible = false;
            if (this.m_bOpState == BusiOpState.AddBusiData || this.m_bOpState == BusiOpState.EditBusiData)
            {
                try
                {
                    TextBox textBox = sender as TextBox;
                    if (textBox.Tag != null)
                    {
                        string[] strs = textBox.Tag.ToString().Split('|');

                        Size s = new Size(textBox.Size.Height, textBox.Size.Height);
                        Point p = new Point();
                        p.X = textBox.Location.X + textBox.Size.Width;
                        p.Y = textBox.Location.Y;

                        Button btn = null;
                        if (strs[0].ToLower().Trim() == "1".ToLower())
                            btn = this.btnRef1;
                        else if (strs[0].ToLower().Trim() == "d".ToLower())
                            btn = this.btnRefDate;

                        if (btn != null)
                        {
                            btn.Click -= new EventHandler(this.btnRef_Click);
                            btn.Size = s;
                            btn.Location = p;
                            if (this.m_bOpState == BusiOpState.AddBusiData)
                                btn.Visible = true;
                            else if (this.m_bOpState == BusiOpState.EditBusiData)
                                btn.Visible = strs[2] == "1";
                            btn.Tag = new string[] { strs[0], strs[1], strs[2], textBox.Name };
                            btn.Click += new EventHandler(this.btnRef_Click);
                        }
                    }
                }
                catch { }
            }
            #endregion
        }

        protected virtual void textBox_Leave(object sender, EventArgs e)
        {
            #region 光标离开文本框
            try
            {
                string strActCtrlName = this.ActiveControl.Name;
                if (strActCtrlName.ToLower() != "btnRef1".ToLower() && strActCtrlName.ToLower() != "btnRefDate".ToLower())
                    this.btnRef1.Visible = this.btnRefDate.Visible = false;
            }
            catch { }
            #endregion
        }

        protected virtual void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 清除文本框
            if ((this.m_bOpState == BusiOpState.AddBusiData || this.m_bOpState == BusiOpState.EditBusiData) && e.KeyChar == 8)
            {
                TextBox textBox = sender as TextBox;
                if (textBox.Tag != null && textBox.Tag.ToString() != "")
                {
                    string[] strs = textBox.Tag.ToString().Split('|');

                    //MTableKeyPressClsData(textBox, strs[1]);
                }
            }
            #endregion
        }

        protected virtual void btnRef_Click(object sender, EventArgs e)
        {
            string[] strs = (string[])(sender as Button).Tag;

            Button button = sender as Button;
            TextBox textBox = null;
            #region 按钮操作的文本框
            foreach (Control c in this.pnl_PageM.Controls)
            {
                if (c is TextBox && c.Name.Trim().ToLower() == strs[3].Trim().ToLower())
                {
                    textBox = c as TextBox; break;
                }
            }
            #endregion

            MTableRefData(button, textBox, strs[1].Trim());
        }

        protected virtual void MTableRefData(Button button, TextBox textBox, string strKeyValue)
        {

        }

        protected virtual void DTableRefData(string strKeyValue)
        {
            if (strKeyValue.ToLower().Trim() == "Material".ToLower())
            {
                #region 参照材质
                FmRC1 f = new FmRC1();
                f.BusiValueSQL = "select scOBVA1Id,scOBVA1Name BusiValue from scOBVA1 where KeyName = '材质'";
                if (f.ShowDialog() == DialogResult.OK)
                {
                    DataRow dr = (DataRow)f.SelectedInfo[0];
                    this.m_dvD[this.dgD.CurrentRowIndex].Row.BeginEdit();
                    this.m_dvD[this.dgD.CurrentRowIndex]["Material"] = dr["BusiValue"];
                    this.m_dvD[this.dgD.CurrentRowIndex].Row.EndEdit();
                }
                #endregion
            }
            if (strKeyValue.ToLower().Trim() == "Standard".ToLower())
            {
                #region 参照生产标准
                FmRC1 f = new FmRC1();
                f.BusiValueSQL = "select scOBVA1Name as BusiValue,gDate from scOBVA1 where KeyName = '生产标准'";
                if (f.ShowDialog() == DialogResult.OK)
                {
                    DataRow dr = (DataRow)f.SelectedInfo[0];
                    this.m_dvD[this.dgD.CurrentRowIndex].Row.BeginEdit();
                    this.m_dvD[this.dgD.CurrentRowIndex]["Standard"] = dr["BusiValue"];
                    this.m_dvD[this.dgD.CurrentRowIndex].Row.EndEdit();
                }
                #endregion
            }
        }

        protected virtual void dgDColTxtBtn_CellButtonClicked(object sender, DataGridCellButtonClickEventArgs e)
        {
            DTableRefData((sender as DataGridTextButtonColumn).MappingName);
        }
    
        protected void dgD_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.m_bOpState == BusiOpState.AddBusiData || this.m_bOpState == BusiOpState.EditBusiData)
            {
                DTableColumn();
                this.lblSumFoot.Invalidate();
            }
        }

        #region 合计行相关
        protected virtual void ScrollBar_ValueChanged(object sender, EventArgs e)
        {
            this.lblSumFoot.Invalidate();
        }

        protected virtual void dgD_Layout(object sender, LayoutEventArgs e)
        {
            this.lblSumFoot.Invalidate();
        }

        protected virtual void lblFootSum_Paint(object sender, PaintEventArgs e)
        {
            #region 合计列计算

            if (this.m_strArySumFields == null || this.m_strArySumFields.Length == 0) return;
            if (this.dgD.TableStyles.Count == 0 || this.m_dvD.Count <= 0) return;

            Graphics g = e.Graphics;
            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = StringAlignment.Far;

            int nColCount = this.dgD.TableStyles[0].GridColumnStyles.Count;
            int x = this.dgD.TableStyles[0].RowHeaderWidth;
            string colName = "";

            for (int i = 0; i < nColCount; i++)
            {
                int nColWidth = this.dgD.TableStyles[0].GridColumnStyles[i].Width;
                if (nColWidth <= 0) continue;

                colName = this.dgD.TableStyles[0].GridColumnStyles[i].MappingName;
                x += nColWidth;

                foreach (string str in this.m_strArySumFields)
                {
                    string[] strTemps = str.Split('|');
                    string strFieldName = strTemps[0].Trim();
                    string strFieldFormat = strTemps[1].Trim();

                    if (colName == strFieldName)
                    {
                        //求和
                        decimal decSumValue = 0;
                        if (this.m_dvD != null && m_dvD.Count > 0)
                        {
                            //decSumValue = decimal.Parse(m_dvD.Table.Compute("sum(" + strFieldName + ")", "").ToString());
                            foreach (DataRowView drv in m_dvD)
                            {
                                if (drv[strFieldName].ToString() != "")
                                    decSumValue += Convert.ToDecimal(drv[strFieldName]);
                            }
                        }

                        string strSumValue = "";
                        if (strFieldFormat != "")
                            strSumValue = decSumValue.ToString(strFieldFormat);
                        else
                            strSumValue = decSumValue.ToString();

                        g.DrawString(strSumValue, this.lblSumFoot.Font, Brushes.Black, x - m_hsdgD.Value - this.lblSum.Width, 3, strFormat);
                    }
                }
            }

            #endregion
        } 
        #endregion

        protected void LoadAtt()
        {
            #region 载入附件
            try
            {
                if (this.OpenFileDlg.ShowDialog() == DialogResult.OK)
                {
                    if (OpenFileDlg.FileName.Length != 0)
                    {
                        string strname = Path.GetFileName(OpenFileDlg.FileName);
                        string strExt = Path.GetExtension(OpenFileDlg.FileName);
                        FileStream fs = new FileStream(this.OpenFileDlg.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        byte[] buffByte = new byte[fs.Length];
                        fs.Read(buffByte, 0, (int)fs.Length);
                        fs.Close();

                        this.m_dvM[0]["AttName"] = strname;
                        this.m_dvM[0]["AttExt"] = strExt;
                        this.m_dvM[0]["Attachment"] = buffByte;

                        MsgBox.ShowInfoMsg("载入附件成功!");
                    }
                    else
                        MsgBox.ShowInfoMsg("附件载入失败!");
                }
                else
                    MsgBox.ShowInfoMsg("附件载入失败!");
            }
            catch
            {
                MsgBox.ShowInfoMsg("附件载入失败!");
            }

            #endregion
        }

        protected void DownAtt(string tableName)
        {
            #region 下载附件
            try
            {
                BusinessObject bo = new BusinessObject();
                string sql = "select AttName,AttExt,Attachment from " + tableName + " where " + m_strPKM + " = " + m_dvM[0][m_strPKM];
                bo.BusiDataSQL = new string[] { sql };
                bo.GetBusiData();
                if (bo.BusiData.Tables[0].Rows[0]["Attachment"].ToString() != "")
                {
                    SaveFileDlg.FileName = this.m_dvM[0]["AttName"].ToString();
                    SaveFileDlg.DefaultExt = this.m_dvM[0]["AttExt"].ToString();

                    if (SaveFileDlg.ShowDialog() == DialogResult.OK)
                    {
                        byte[] buffByte = (byte[])bo.BusiData.Tables[0].Rows[0]["Attachment"];
                        FileInfo fi = new FileInfo(SaveFileDlg.FileName);
                        FileStream fs = fi.OpenWrite();
                        fs.Write(buffByte, 0, buffByte.Length);
                        fs.Close();

                        fi.CopyTo(SaveFileDlg.FileName);
                        fi.Delete();
                    }
                }
                else
                {
                    MsgBox.ShowInfoMsg("没有附件!");
                }
            }
            catch { }

            #endregion
        }

        /// <summary>
        /// 根据单据号查询
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="paramName">单据号参数名</param>
        protected void QueryByCode(string sql, string paramName)
        {
            #region 根据单据号查询
            if (m_bOpState == BusiOpState.AddBusiData || m_bOpState == BusiOpState.EditBusiData)
            {
                MsgBox.ShowInfoMsg("当前处于编辑状态，无法查询！");
                return;
            }
 
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add(paramName, SqlDbType.NVarChar);
            cmd.Parameters[paramName].Value = this.Txt_BillCode.Text;
            BusinessObject bo = new BusinessObject();
            bo.BusiSqlCmd = new SqlCommand[] { cmd };
            bo.GetBusinessData();
            if (bo.BusiData.Tables[0].Rows.Count <= 0)
                MsgBox.ShowInfoMsg("该订单号不存在,或没有权限查看!");
            else if (bo.BusiData.Tables[0].Rows.Count > 1)
                MsgBox.ShowInfoMsg("该订单号存在多条记录,请到订单列表查询!");
            else
            {
                this.MainID = bo.BusiData.Tables[0].Rows[0][0].ToString();
                this.GetMDBusiData();
            }
            #endregion
        }

        //订单列表
        protected virtual void Btn_List_Click(object sender, EventArgs e)
        {

        }

        //附件
        private void Btn_SetAtt_Click(object sender, EventArgs e)
        {
            this.LoadAtt();
        }

        protected virtual void Btn_GetAtt_Click(object sender, EventArgs e)
        {
            
        }

        private void Btn_DelAtt_Click(object sender, EventArgs e)
        {
            //删除附件
            this.m_dvM[0]["Attachment"] = DBNull.Value;
            this.m_dvM[0]["AttName"] = DBNull.Value;
            this.m_dvM[0]["AttExt"] = DBNull.Value;
        }
    }
}