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

        #region ҵ����񡢱������������
        /// <summary>
        /// �Ƿ������ʾ����
        /// </summary>
        public bool isShowOnly
        {
            get { return m_bShowOnly; }
            set { m_bShowOnly = value; }
        }
        protected bool m_bShowOnly = false;

        /// <summary>
        /// ģ�����ƣ����ڴ����ݿ��з��ʵ�ǰģ�������Ϣ��
        /// </summary>
        public string ModuleName
        {
            get { return this.m_strModuleName; }
            set { this.m_strModuleName = value; }
        }
        protected string m_strModuleName = null;

        /// <summary>
        /// ��ǰҵ�����(�������޸ģ�ɾ������ˣ������)
        /// </summary>
        public BusiOpState OpState
        {
            get { return this.m_bOpState; }
            set { this.m_bOpState = value; }
        }
        protected BusiOpState m_bOpState = BusiOpState.BrowseBusiData;

        /// <summary>
        /// �ܷ��˳�ģ��
        /// </summary>
        public bool CanExitModule
        {
            get { return this.m_bCanExitModule; }
            set { this.m_bCanExitModule = value; }
        }
        protected bool m_bCanExitModule = true;

        /// <summary>
        /// ҵ�����
        /// </summary>
        protected BusinessObject m_bmdObj = new BusinessObject();

        /// <summary>
        /// ����ҵ��������ͼ,�ӱ�ҵ��������ͼ
        /// </summary>
        protected DataView m_dvM = null, m_dvD = null;

        /// <summary>
        /// �����������ӱ��������ӱ����
        /// </summary>
        protected string m_strPKM = null, m_strPKD = null, m_strFKD = null;

        /// <summary>
        /// ���ӱ���ͼ��
        /// </summary>
        protected string m_strdvMTableName = "", m_strdvDTableName = "";

        /// <summary>
        /// ���������ˮƽ������
        /// </summary>
        protected HScrollBar m_hsdgD = null;

        /// <summary>
        /// ��������Ĵ�ֱ������
        /// </summary>
        protected VScrollBar m_vsdgD = null;

        /// <summary>
        /// �ϼ��ֶ�
        /// </summary>
        protected string[] m_strArySumFields = null;

        /// <summary>
        /// ����ID
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
        /// 0:��һ����¼ -1:��һ����¼ 1:��һ����¼ 9:���һ����¼
        /// </summary>
        /// <param name="typeID">����</param>
        /// <returns></returns>
        protected virtual string GetMainID(MainIDType typeID)
        {
            #region ��ȡ����ID

            //this.Cursor = Cursors.WaitCursor;

            string str = "";
            if (typeID == MainIDType.Last) //��ȡ��󵥾�ID
                str = "select isnull(Max(" + m_strPKM + "),0) from " + m_strdvMTableName;

            else if (typeID == MainIDType.Previous) //��ȡ��һ������ID
                str = "select Max(" + m_strPKM + ") from " + m_strdvMTableName
                    + " where " + m_strPKM + " < " + MainID;

            else if (typeID == MainIDType.Next) //��ȡ��һ������ID
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
        /// 0:��ʼ״̬ 1:����  2:�༭
        /// </summary>
        /// <param name="value">����</param>
        protected void SetBtnMode(int value)
        {
            #region ���ð�ť״̬
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


        #region ���ݲ������

        protected delegate void UIGetData();

        //ί��
        protected void DoGetData()
        {
            UIGetData UIGet = new UIGetData(GetMDBusiData);
            this.BeginInvoke(UIGet);
        }

        //��ȡ����GetMDBusiData()-->GetSQL()-->MTableUpd()
        protected virtual void GetMDBusiData()
        {
            #region ��ȡ���ӱ�ҵ�������

            this.Cursor = Cursors.WaitCursor;

            //��ȡSQL���
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
            #region ��ȡ�����ݹ�������

            string sqlM = "select * from " + m_strdvMTableName + " where " + m_strPKM + " = " + MainID;

            string sqlD = "select * from " + m_strdvDTableName + " where " + m_strFKD + " = " + MainID;

            this.m_bmdObj.BusiDataSQL = new string[] { sqlM, sqlD };

            #endregion
        }

        protected virtual void MTableUpd()
        {
            #region ���ӱ��ֽ������

            //�����
            this.m_dvM = m_bmdObj.BusiData.Tables[0].DefaultView;

            //�ӱ��
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
                this.statusBarPanel1.Text = "��¼��:" + this.m_dvD.Count.ToString();

            if (this.m_bShowOnly) ShowOnly();

            UICtrl.AppDoEvents(3);

            #endregion
        }

        //------------------------------------------------------------------

        protected virtual void UpdMDBusiData()
        {
            #region �������ӱ�ҵ������
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
                //����,ɾ����λ����󵥾�
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
            #region ��ȡ���ӱ����ҵ������
            if (this.m_dvM.Count > 0)
            {
                this.Txt_BillCode.Focus();      //�л�����,ʹ����TextBox�������ݵ�DataView
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

        #region ��������,�ر��¼�
        protected virtual void FmB_Load(object sender, System.EventArgs e)
        {
            #region ���ش���

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
            #region ģ���˳�ȷ��

            this.m_bCanExitModule = true;

            if (this.m_bOpState == BusiOpState.AddBusiData || this.m_bOpState == BusiOpState.EditBusiData)
            {
                if (MsgBox.ShowYesNoMsg2("�������ӻ�༭���ݣ�ȷ��Ҫ�˳���") != DialogResult.Yes)
                {
                    this.m_bCanExitModule = false;
                    e.Cancel = true;
                }
            }

            #endregion
        } 
        #endregion

        #region ��ذ�ť�¼�
        //����
        protected virtual void btnAdd_Click(object sender, System.EventArgs e)
        {
            #region ����ҵ������
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
        //�༭
        protected virtual void btnEdit_Click(object sender, System.EventArgs e)
        {
            #region �༭ҵ������
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
        //ɾ��
        protected virtual void btnDel_Click(object sender, System.EventArgs e)
        {
            #region ɾ��ҵ������
            if (MsgBox.ShowYesNoMsg2("ȷ��Ҫɾ����") == DialogResult.Yes)
            {
                this.m_bOpState = BusiOpState.DelBusiData;

                UpdMDBusiData();
            }
            #endregion
        }
        //����
        protected virtual void btnSave_Click(object sender, System.EventArgs e)
        {
            #region ����ҵ������
            UpdMDBusiData();
            #endregion
        }
        //ȡ��
        protected virtual void btnCancel_Click(object sender, System.EventArgs e)
        {
            #region ȡ������ҵ������
            this.m_bOpState = BusiOpState.None;
            if (this.m_bmdObj.BusiDataPre != null)
            {
                this.m_bmdObj.BusiData.Clear();
                this.m_bmdObj.BusiData = this.m_bmdObj.BusiDataPre.Copy();
                MTableUpd();
            }
            #endregion
        }
        //���
        protected virtual void btnAudit_Click(object sender, System.EventArgs e)
        {
            #region ���ҵ������
            this.m_bOpState = BusiOpState.AuditBusiData;

            if (this.m_dvM.Count > 0) this.m_dvM[0].Row.EndEdit();

            UpdMDBusiData();
            #endregion
        }
        //����
        protected virtual void btnUnAudit_Click(object sender, System.EventArgs e)
        {
            #region ����ҵ������
            this.m_bOpState = BusiOpState.UnAuditBusiData;

            if (this.m_dvM.Count > 0) this.m_dvM[0].Row.EndEdit();

            UpdMDBusiData();
            #endregion
        }
        //��ӡ
        protected virtual void miPrint_Click(object sender, EventArgs e)
        {
            #region ��ӡ����

            this.Report.RegisterData(m_dvM, m_strdvMTableName);
            this.Report.RegisterData(m_dvD, m_strdvDTableName);

            DataBand MBand = this.Report.FindObject("Data1") as DataBand;
            MBand.DataSource = this.Report.GetDataSource(m_strdvMTableName);

            DataBand DBand = this.Report.FindObject("Data3") as DataBand;
            DBand.DataSource = this.Report.GetDataSource(m_strdvDTableName);

            this.Report.Show();

            #endregion
        }
        //��ӡ���
        protected virtual void miDesgin_Click(object sender, EventArgs e)
        {
            #region ��ӡ���

            this.Report.RegisterData(m_dvM, m_strdvMTableName);
            this.Report.RegisterData(m_dvD, m_strdvDTableName);

            DataBand MBand = this.Report.FindObject("Data1") as DataBand;
            MBand.DataSource = this.Report.GetDataSource(m_strdvMTableName);

            DataBand DBand = this.Report.FindObject("Data3") as DataBand;
            DBand.DataSource = this.Report.GetDataSource(m_strdvDTableName);

            this.Report.Design();
            #endregion
        }
        //ˢ��
        protected virtual void btnRefresh_Click(object sender, System.EventArgs e)
        {
            #region ˢ��ҵ������
            this.m_bOpState = BusiOpState.None;
            new Thread(DoGetData).Start();
            #endregion
        }
        //�˳�
        protected virtual void btnExit_Click(object sender, System.EventArgs e)
        {
            #region �˳�ģ��
            Close();
            #endregion
        }
        //��һ����¼
        private void Btn_First_Click(object sender, EventArgs e)
        {
            #region ��һ��¼��ť

            this.MainID = GetMainID(MainIDType.First);
            new Thread(DoGetData).Start();
            this.tabPage1.Focus();

            #endregion
        }
        //��һ����¼
        protected virtual void btnPRec_Click(object sender, System.EventArgs e)
        {
            #region ��һ��¼��ť

            string mainID = GetMainID(MainIDType.Previous);

            if (mainID == "-1")
            {
                MsgBox.ShowInfoMsg("û�и����¼!");
                return;
            }
            this.MainID = mainID;
            new Thread(DoGetData).Start();
            this.tabPage1.Focus();

            #endregion
        }
        //��һ����¼
        protected virtual void btnNRec_Click(object sender, System.EventArgs e)
        {
            #region ��һ��¼��ť

            string mainID = GetMainID(MainIDType.Next);

            if (mainID == "-1")
            {
                MsgBox.ShowInfoMsg("û�и����¼!");
                return;
            }

            this.MainID = mainID;
            new Thread(DoGetData).Start();
            this.tabPage1.Focus();

            #endregion
        }
        //���һ����¼
        private void Btn_Last_Click(object sender, EventArgs e)
        {
            #region ���һ��¼��ť

            this.MainID = GetMainID(MainIDType.Last);
            new Thread(DoGetData).Start();
            this.tabPage1.Focus();

            #endregion
        }
        //����
        protected virtual void btnAddDLine_Click(object sender, System.EventArgs e)
        {
            #region ����ҵ��������
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
        //ɾ��
        protected virtual void btnDelDLine_Click(object sender, System.EventArgs e)
        {
            #region ɾ��ҵ��������

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

        //��ѯ
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
            #region ֻ��״̬
            this.Btn_Add.Enabled = this.Btn_Edit.Enabled = this.Btn_Del.Enabled = false;
            this.Btn_Save.Enabled = this.Btn_Cancel.Enabled = this.Btn_Audit.Enabled = this.Btn_UnAudit.Enabled = false;

            this.Btn_PrintMenu.Enabled = true;

            this.pnlD_Button.Enabled = false;
            this.dgD.ReadOnly = true; 
            #endregion
        }

        protected virtual void MTableDataBinding(int nFlag)
        {
            #region ���ֶ�
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
            #region �������ı���
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
            #region ����뿪�ı���
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
            #region ����ı���
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
            #region ��ť�������ı���
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
                #region ���ղ���
                FmRC1 f = new FmRC1();
                f.BusiValueSQL = "select scOBVA1Id,scOBVA1Name BusiValue from scOBVA1 where KeyName = '����'";
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
                #region ����������׼
                FmRC1 f = new FmRC1();
                f.BusiValueSQL = "select scOBVA1Name as BusiValue,gDate from scOBVA1 where KeyName = '������׼'";
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

        #region �ϼ������
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
            #region �ϼ��м���

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
                        //���
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
            #region ���븽��
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

                        MsgBox.ShowInfoMsg("���븽���ɹ�!");
                    }
                    else
                        MsgBox.ShowInfoMsg("��������ʧ��!");
                }
                else
                    MsgBox.ShowInfoMsg("��������ʧ��!");
            }
            catch
            {
                MsgBox.ShowInfoMsg("��������ʧ��!");
            }

            #endregion
        }

        protected void DownAtt(string tableName)
        {
            #region ���ظ���
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
                    MsgBox.ShowInfoMsg("û�и���!");
                }
            }
            catch { }

            #endregion
        }

        /// <summary>
        /// ���ݵ��ݺŲ�ѯ
        /// </summary>
        /// <param name="sql">��ѯ���</param>
        /// <param name="paramName">���ݺŲ�����</param>
        protected void QueryByCode(string sql, string paramName)
        {
            #region ���ݵ��ݺŲ�ѯ
            if (m_bOpState == BusiOpState.AddBusiData || m_bOpState == BusiOpState.EditBusiData)
            {
                MsgBox.ShowInfoMsg("��ǰ���ڱ༭״̬���޷���ѯ��");
                return;
            }
 
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add(paramName, SqlDbType.NVarChar);
            cmd.Parameters[paramName].Value = this.Txt_BillCode.Text;
            BusinessObject bo = new BusinessObject();
            bo.BusiSqlCmd = new SqlCommand[] { cmd };
            bo.GetBusinessData();
            if (bo.BusiData.Tables[0].Rows.Count <= 0)
                MsgBox.ShowInfoMsg("�ö����Ų�����,��û��Ȩ�޲鿴!");
            else if (bo.BusiData.Tables[0].Rows.Count > 1)
                MsgBox.ShowInfoMsg("�ö����Ŵ��ڶ�����¼,�뵽�����б��ѯ!");
            else
            {
                this.MainID = bo.BusiData.Tables[0].Rows[0][0].ToString();
                this.GetMDBusiData();
            }
            #endregion
        }

        //�����б�
        protected virtual void Btn_List_Click(object sender, EventArgs e)
        {

        }

        //����
        private void Btn_SetAtt_Click(object sender, EventArgs e)
        {
            this.LoadAtt();
        }

        protected virtual void Btn_GetAtt_Click(object sender, EventArgs e)
        {
            
        }

        private void Btn_DelAtt_Click(object sender, EventArgs e)
        {
            //ɾ������
            this.m_dvM[0]["Attachment"] = DBNull.Value;
            this.m_dvM[0]["AttName"] = DBNull.Value;
            this.m_dvM[0]["AttExt"] = DBNull.Value;
        }
    }
}