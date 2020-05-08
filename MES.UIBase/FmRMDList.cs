using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace LanyunMES.UIBase
{
    using DAL;
    using Component;
    using LanyunMES.Entity;

    public partial class FmRMDList : DevComponents.DotNetBar.OfficeForm
    {
        public FmRMDList()
        {
            InitializeComponent();
            this.Load += Fm_Load;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="moduleName">模块名称</param>
        /// <param name="isSelectD">是否选择子表记录</param>
        /// <param name="isMutiSelectD">子表记录是否多选</param>
        public FmRMDList(string moduleName, bool isSelectD, bool isMutiSelectD) : this()
        {
            this.InitGridM(dgMain);

            BusinessInfoDAL busiDAL = new BusinessInfoDAL();
            BusinessInfo busiInfo = busiDAL.GetModel(moduleName);
            this.mpk = busiInfo.MPK;
            this.dpk = busiInfo.DPK;
            this.fk = busiInfo.DFK;
            this.mViewName = busiInfo.MView;
            this.dViewName = busiInfo.DView;

            this._isSelectD = isSelectD;
            this._isMutiSelectD = isMutiSelectD;

        }


        #region 业务对象,变量

        protected DataView dvMain = null, dvDetail = null;
        //Dictionary<string, string> dic = null;
        protected string mpk, dpk, fk, mViewName, dViewName;
        protected int curRowIndex = -1;
        public string str_MsqlCondition, str_DsqlCondition, str_MsqlOrderField;

        private DataRow _selectMitem;
        public DataRow selectMitem
        {
            get { return _selectMitem; }
        }

        private List<DataRow> _selectDitems;
        public List<DataRow> selectDitems
        {
            get { return _selectDitems; }
        }
        //是否返回子表记录
        private bool _isSelectD = false;
        //子表记录是否多选
        private bool _isMutiSelectD = false;
        /// <summary>
        /// 是否显示关闭,还原记录按钮
        /// </summary>
        protected bool showCRbutton = false;

        #endregion

        protected virtual void InitGridM(DataGridView dgv)
        {
            dgv.Columns.Clear();
            dgv.AutoGenerateColumns = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        protected virtual void InitGridD(DataGridView dgv)
        {
            dgv.Columns.Clear();
            dgv.AutoGenerateColumns = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }


        protected void Fm_Load(object sender, EventArgs e)
        {
            #region 窗体加载

            if (_isSelectD)
            {
                this.InitGridD(dgDetail);
                this.pnl_Dtools.Visible = true;
            }
            else
            {
                this.pnl_Dtools.Visible = false;
            }

            GetMViewData();      
                           
            #endregion
        }

        protected void GetMViewData()
        {
            #region 获取主表数据
            string m_sql = "select * from " + mViewName;
            if (!string.IsNullOrEmpty(str_MsqlCondition))
            {
                m_sql += " where " + str_MsqlCondition;
            }

            if (dvMain != null)
            {
                dvMain.Dispose();
                dvMain = null;
            }
            //dvMain = DbHelperSQL.Query(m_sql).Tables[0].DefaultView;
            dvMain.AllowNew = dvMain.AllowEdit = false;
            dgMain.DataSource = dvMain;

            if (dvMain.Table.Rows.Count > 0)
                curRowIndex = dgMain.CurrentRow.Index;
            else
                curRowIndex = -1;
            if (curRowIndex >= 0 && _isSelectD)
            {
                string fkid = dvMain[curRowIndex][fk].ToString();
                GetDViewData(fkid);
            }
            statusLabel1.Text = "主表记录：" + dgMain.RowCount;
            #endregion
        }

        protected void GetDViewData(string fkid)
        {
            #region 获取子表数据
            string d_sql = "select * from " + dViewName + " where " + fk + " = " + fkid;
            if (!string.IsNullOrEmpty(str_DsqlCondition))
            {
                d_sql += " and " + str_DsqlCondition;
            }
            if (dvDetail != null)
            {
                dvDetail.Dispose();
                dvDetail = null;
            }
            //dvDetail = DbHelperSQL.Query(d_sql).Tables[0].DefaultView;
            dvDetail.AllowNew = false;
            dvDetail.AllowEdit = true;
            dgDetail.DataSource = dvDetail;
            statusLabel2.Text = "  子表记录：" + dgDetail.RowCount;
            this.cBox_SelectAll.Checked = false;
            #endregion
        }

        protected DataGridViewTextBoxColumn GridAddTextCol(DataGridView dgv, string colName, string colText, int width)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name = col.DataPropertyName = colName;
            col.HeaderText = colText;
            col.Width = width;
            dgv.Columns.Add(col);
            return col;
        }

        protected DataGridViewCheckBoxColumn GridAddCheckCol(DataGridView dgv, string colName, string colText, int width)
        {
            DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
            col.Name = col.DataPropertyName = colName;
            col.HeaderText = colText;
            col.Width = width;
            dgv.Columns.Add(col);
            return col;
        }


        public void InitReportXml(DataView dv, string xmlName)
        {
            string path = "";
            if (!Directory.Exists("./RefXml"))
            {
                Directory.CreateDirectory("./RefXml");
            }
            else
            {
                path = "./RefXml/" + xmlName + ".xml";
                if (File.Exists(path)) return;

                XmlDocument doc = new XmlDocument();
                XmlElement xmlRoot = doc.CreateElement("columns");
                doc.AppendChild(xmlRoot);
                foreach (DataColumn col in dv.Table.Columns)
                {
                    XmlElement item = doc.CreateElement("item");
                    xmlRoot.AppendChild(item);

                    XmlElement colName = doc.CreateElement("Name");
                    colName.InnerText = col.ColumnName;
                    item.AppendChild(colName);

                    XmlElement colText = doc.CreateElement("Text");
                    colText.InnerText = col.ColumnName;
                    item.AppendChild(colText);

                    XmlElement colVisible = doc.CreateElement("visible");
                    colVisible.InnerText = "1";
                    item.AppendChild(colVisible);

                    XmlElement colWidth = doc.CreateElement("width");
                    colWidth.InnerText = "100";
                    item.AppendChild(colWidth);
                }
                doc.Save(path);
            }
        }

        public void GetReportXml(DataGridView dgv, string xmlName)
        {
            string path = "";
            if (File.Exists("./RefXml/" + xmlName + ".xml"))
            {
                path = "./RefXml/" + xmlName + ".xml";
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode root = doc.SelectSingleNode("columns");
                foreach (XmlNode item in root)
                {
                    if (item.ChildNodes[2].InnerText == "1")
                    {
                        DGXAddCol(dgv, item);
                    }
                }
            }
            else
            {
                MsgBox.ShowInfoMsg("找不到配置文件");
                return;
            }
        }

        protected void DGXAddCol(DataGridView dgv, XmlNode item)
        {
            string colName = item["colName"].InnerText;
            string colText = item["colText"].InnerText;
            int colWidth = int.Parse(item["colWidth"].InnerText);
            if (colName == "isSelected")
            {
                DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn(false);
                col.HeaderText = colText;
            }
            else
            {
                dgv.Columns.Add(colName, colText);
            }
            dgv.Columns[colName].DataPropertyName = colName;
            dgv.Columns[colName].Width = colWidth;
            dgv.Columns[colName].ReadOnly = true;
        }

        protected virtual void cbx_ListChanged()
        {

        }



        /// <summary>
        /// 显示所有子表记录
        /// </summary>
        protected virtual void showAllDRec()
        {

        }

        //------------------------------------------

        private void Btn_Select_Click(object sender, EventArgs e)
        {
            #region 确定返回选中记录

            if (dvMain.Count <= 0) return;

            this._selectMitem = dvMain[dgMain.CurrentRow.Index].Row;
  
            if (_isSelectD)
            {
                this.dgDetail.EndEdit();
                this._selectDitems = new List<DataRow>();

                if (_isMutiSelectD)
                {
                    foreach (DataRowView drv in dvDetail)
                    {
                        if (drv["isSelected"].ToString() == "1")
                        {
                            _selectDitems.Add(drv.Row);
                        }
                    }
                }
                else
                {
                    this._selectDitems.Add(dvDetail[dgDetail.CurrentRow.Index].Row);
                }
            }

            this.DialogResult = DialogResult.OK; 
            #endregion
        }

        private void Btn_Reflash_Click(object sender, EventArgs e)
        {
            GetMViewData();
        }

        private void dgMain_CurrentCellChanged(object sender, EventArgs e)
        {
            #region 主表行改变后重新获取子表数据
            if (dgMain.CurrentRow != null && dgMain.CurrentRow.Index >= 0 && dgMain.CurrentRow.Index != curRowIndex)
            {
                curRowIndex = dgMain.CurrentRow.Index;
                GetDViewData(dvMain[curRowIndex][fk].ToString());
            }
            #endregion
        }

        private void cBox_SelectAll_CheckedChanged(object sender, EventArgs e)
        {
            #region 全选,全消

            if (dvMain.Count <= 0) return;

            if (_isMutiSelectD && dgDetail.RowCount > 0)
            {
                //dvDetail.AllowEdit = true;
                if (this.cBox_SelectAll.Checked)
                {
                    foreach (DataRowView drv in dvDetail)
                    {
                        drv.BeginEdit();
                        drv["isSelected"] = "1";
                        drv.EndEdit();
                    }
                }
                else
                {
                    foreach (DataRowView drv in dvDetail)
                    {
                        drv.BeginEdit();
                        drv["isSelected"] = "0";
                        drv.EndEdit();
                    }
                }
                //dvDetail.AllowEdit = false;
            } 
            #endregion
        }

        private void cbx_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbx_ListChanged();
        }

        private void cBox_ShowDAll_Click(object sender, EventArgs e)
        {
            showAllDRec();
        }

    }
}
