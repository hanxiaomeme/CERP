//������������������������������������������������������������������������������������������������������������������������������
//
//���ؼ��Ľڵ�� Tag ���ԣ���¼ Tag = new string[] { ������루�磺DepCode��, �������ƣ��磺DepName�� };
//
//������������������������������������������������������������������������������������������������������������������������������
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

        #region ҵ�����
        /// <summary>
        /// �������ࣩģ�����ƣ����ڴ����ݿ��з����������ࣩģ�������Ϣ��
        /// </summary>
        public string ModuleName { get; set; }

        ITreeGrid iTreeGrid;

        /// <summary>
        /// ҵ��������ͼ
        /// </summary>
        protected DataView dvTree, dvDetail;

        /// <summary>
        /// ��ѯ����
        /// </summary>
        protected string[] m_strAryQueryCondition = null;

        /// <summary>
        /// �̣߳���ȡҵ������
        /// </summary>
        protected Thread m_trdGetMBusiData = null;

        /// <summary>
        /// �̣߳���ȡҵ������
        /// </summary>
        protected Thread m_trdGetTBusiData = null;

        /// <summary>
        /// ����������·���
        /// </summary>
        protected delegate void m_dgtUIMethod();
        /// <summary>
        /// ����������·���
        /// </summary>
        protected delegate void m_dgtUICursor(Cursor curosr);
        /// <summary>
        /// ������Ϣ��ʾ
        /// </summary>
        protected delegate void m_dgtUIMsgShow(string strMsg);
        /// <summary>
        /// ������Ϣ��ʾ
        /// </summary>
        protected delegate DialogResult m_dgtUIYesNoMsgShow(string strMsg);

        /// <summary>
        /// �����ڵ�
        /// </summary>
        protected Node m_tnRoot = null;
        /// <summary>
        /// ��ǰѡ�������ڵ�
        /// </summary>
        protected Node m_tnSelected = null;
        /// <summary>
        /// �������ࣩ��������֮��Ĺ�����
        /// </summary>
        protected string m_strMTLnkName = "";

        //Grid���ݿ����������
        protected string m_strDPK;

        #endregion

        #region �ּ��ֶΣ�������
        //�ּ�����
        protected string m_strGradeCode = null;
        //�ּ�����
        protected string m_strGradeName = null;
        //�����ֶ�
        protected string m_strGradeField = "";
        #endregion


        protected virtual void InitGridColumn()
        {

        }


        protected virtual void FmB_Load(object sender, System.EventArgs e)
        {
            #region �������

            this.pnl_Head.Text = this.TreeM.Nodes[0].Text = this.Text;

            this.sGrid.AutoGenerateColumns = false;

            this.InitGridColumn();

            this.iTreeGrid = new TTreeGrid(ModuleName);
            //this.dvTree = iTreeGrid.GetTreeData();
            this.m_strGradeCode = iTreeGrid.gradeInfo.CodeColumnName;
            this.m_strGradeName = iTreeGrid.gradeInfo.NameColumnName;
            this.m_strGradeField = iTreeGrid.gradeInfo.GradeColumnName;
            this.m_strDPK = iTreeGrid.busiInfo.DPK;

            GetTBusiData();         //������

            #endregion
        }

        //GetTBusiData --> GetTData --> LoadTVData

        #region ����TreeView��
        protected virtual void GetTBusiData()
        {
            #region ��ȡ�������ࣩ����

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
            #region ��ȡ�������ࣩ����

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
            #region ��ʾģ����
                 
            //���ڵ�
            this.m_tnRoot = this.TreeM.Nodes[0];
            this.m_tnRoot.Nodes.Clear();
            this.m_tnRoot.Expand();

            //���ü�������
            TreeHelper.LoadAdvTree(TreeM, dvTree, m_strGradeCode, m_strGradeName, m_strGradeField, "", NodeClick, true);

            #endregion
        } 
        #endregion

        //NodeClick --> GetMBusiData --> GetMData --> MTableupd

        #region ����TreeViewNode��ϸ

        protected virtual void NodeClick(object sender, EventArgs e)
        {
            #region ��ȡNode��ϸ

            this.m_tnSelected = (Node)sender;

            if (m_tnSelected.Tag == null) return;

            if (this.m_trdGetMBusiData != null && this.m_trdGetMBusiData.IsAlive)
            {
                MsgBox.ShowInfoMsg2("Ӧ�ó����̨��æ�����Ժ����ԣ�"); return;
            }

            string[] sArray = (string[])m_tnSelected.Tag;

            GetMBusiData(sArray[0], true);

            #endregion
        }

        protected virtual void GetMBusiData(string str, bool isLnkField)
        {
            #region ��ȡ��ҵ������

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
            #region ��ȡ��ҵ������

            FmWait1 fmWait = new FmWait1(this, "������ȡ����,���Ժ�...");

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
            #region ˢ�½���

            DataTable table = new DataTable();
            DataColumn column = new DataColumn();
            //AutoIncrement  ��ȡ������һ��ֵ����ֵָʾ������ӵ��ñ��е����У����Ƿ��е�ֵ�Զ�����  
            column.AutoIncrement = true;
            column.ColumnName = "RowNo";
            column.AutoIncrementSeed = 1;
            column.AutoIncrementStep = 1;
            table.Columns.Add(column);
            //Merge�ϲ�DataTable  
            table.Merge(dvDetail.Table);
            this.dvDetail = table.DefaultView;

            this.dvDetail.AllowNew = this.dvDetail.AllowEdit = this.dvDetail.AllowDelete = false;

            this.sGrid.DataSource = this.dvDetail;
            this.btn_Add.Enabled = true;
            this.btn_Edit.Enabled = this.btn_Del.Enabled = this.btn_Print.Enabled = this.sGrid.RowCount > 0;

            //UICtrl.AppDoEvents(3);

            this.lblRowCount.Text = "";
            if (this.dvDetail != null)
                this.lblRowCount.Text = "�Ѽ��ؼ�¼��:" + this.dvDetail.Count.ToString();

            Application.DoEvents(); 
            #endregion
        }

        #endregion

        protected virtual void btnAdd_Click(object sender, System.EventArgs e)
        {
            #region ����ҵ������
            #endregion
        }

        protected virtual void btnEdit_Click(object sender, System.EventArgs e)
        {
            #region �༭ҵ������
            #endregion
        }

        protected virtual void btnDel_Click(object sender, System.EventArgs e)
        {
            #region ɾ��ҵ������

            #endregion
        }


        #region =========��ӡ���==========
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
            #region ����Excel

            if (Export.ExpToExcel(sGrid))
            {
                MessageBox.Show("�����ɹ���");
            }

            #endregion
        }

        protected virtual void btnColSettings_Click(object sender, EventArgs e)
        {

        }

        protected virtual void btnQuery_Click(object sender, EventArgs e)
        {
            #region ��ѯҵ������


            if (this.m_trdGetMBusiData != null && this.m_trdGetMBusiData.IsAlive)
            {
                MsgBox.ShowInfoMsg2("Ӧ�ó����̨��æ�����Ժ����ԣ�"); return;
            }
            //GetMBusiData();

            this.sGrid.Focus();
            #endregion
        }

        protected virtual void btnRefresh_Click(object sender, System.EventArgs e)
        {
            #region ˢ��ҵ������
            //this.m_bOpState = BusiOpState.None;
            if (this.m_trdGetTBusiData != null && this.m_trdGetTBusiData.IsAlive)
            {
                MsgBox.ShowInfoMsg2("Ӧ�ó����̨��æ�����Ժ����ԣ�"); return;
            }
            GetTBusiData();

            this.TreeM.Focus();
            #endregion
        }

        protected virtual void btnExit_Click(object sender, System.EventArgs e)
        {
            #region �˳�ģ��
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