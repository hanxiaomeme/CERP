using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace NDF
{
    public partial class FmB43 : Form
    {
        public FmB43()
        {
            InitializeComponent();

            this.m_hsdgD = ((HScrollBar)this.dgD.Controls[0]);
            this.m_vsdgD = ((VScrollBar)this.dgD.Controls[1]);
            this.m_hsdgD.ValueChanged += new EventHandler(this.hsdgD_ValueChanged);
            this.m_vsdgD.ValueChanged += new EventHandler(this.vsdgD_ValueChanged);

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
        public string ModuleName
        {
            get { return this.m_strModuleName; }
            set { this.m_strModuleName = value; }
        }
        protected string m_strModuleName = null;

        protected string PuOCode = "";
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
        /// 记录从表当前行
        /// </summary>
        protected int m_ndgDCurrentRowIndex = -1;
        /// <summary>
        /// 不拷贝的字段
        /// </summary>
        protected string[] m_strAryDisCopyTableFieldMain = null, m_strAryDisCopyTableFieldDetail = null;

        /// <summary>
        /// 记录主、从表单元格信息
        /// </summary>
        protected object[] DGCell0 = null, DGCell1 = null;

        /// <summary>
        /// 外部传入数据查询过滤条件(刷新,重新查询保留)
        /// </summary>
        public string[] OuterFilterSQL
        {
            set { this.m_strAryOuterFilterSQL = value; }
            get { return this.m_strAryOuterFilterSQL; }
        }
        protected string[] m_strAryOuterFilterSQL = null;

        /// <summary>
        /// 外部传入数据查询过滤条件(刷新,重新查询变化)
        /// </summary>
        public string[] QueryCondition
        {
            set { this.m_strAryQueryCondition = value; }
            get { return this.m_strAryQueryCondition; }
        }
        protected string[] m_strAryQueryCondition = null;

        /// <summary>
        /// 特殊过滤
        /// </summary>
        protected string[] m_strArySpecFilterM = null, m_strArySpecFilterD = null;

        /// <summary>
        /// 默认过滤
        /// </summary>
        protected string[] m_strAryDftFilterM = null, m_strAryDftFilterD = null;

        /// <summary>
        /// 报表文件名
        /// </summary>
        protected string m_strRptFile = null;

        /// <summary>
        /// 打印设置
        /// </summary>
        protected string m_strPrintSettings = null;

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
        /// 数据网格的水平滚动条
        /// </summary>
        protected HScrollBar m_hsdgD = null;

        /// <summary>
        /// 数据网格的垂直滚动条
        /// </summary>
        protected VScrollBar m_vsdgD = null;

        /// <summary>
        /// 是否显示合计字段
        /// </summary>
        protected bool m_bShowFootSum = true;

        /// <summary>
        /// 合计字段
        /// </summary>
        protected string[] m_strArySumFields = null;

        /// <summary>
        /// 是否显示客户全称
        /// </summary>
        protected bool isFullName;

        /// <summary>
        /// 默认显示1年内的数据
        /// </summary>
        protected bool list1YearData = true;


        #endregion


        //======================
        protected virtual void isAtt()
        {         
            #region 设置辅助属性列,辅助单位列是否可编辑

            //try
            //{
            //    if (dgD.CurrentRowIndex >= 0)
            //    {
            //        if (m_dvD[dgD.CurrentRowIndex]["isHeatNo"].ToString() == "True")
            //            this.dgD.TableStyles[0].GridColumnStyles["HeatNo"].ReadOnly = false;
            //        else
            //            this.dgD.TableStyles[0].GridColumnStyles["HeatNo"].ReadOnly = true;

            //        if (m_dvD[dgD.CurrentRowIndex]["isMaterial"].ToString() == "True")
            //            this.dgD.TableStyles[0].GridColumnStyles["Material"].ReadOnly = false;
            //        else
            //            this.dgD.TableStyles[0].GridColumnStyles["Material"].ReadOnly = true;

            //        if (m_dvD[dgD.CurrentRowIndex]["isStandard"].ToString() == "True")
            //            this.dgD.TableStyles[0].GridColumnStyles["Standard"].ReadOnly = false;
            //        else
            //            this.dgD.TableStyles[0].GridColumnStyles["Standard"].ReadOnly = true;
            //    }
            //}
            //catch
            //{ }

            #endregion
        }

        protected virtual bool CheckAtt(int i)
        {
            /*
            #region 保存材质,生产标准检验

            if (m_dvD[i]["isMaterial"].ToString() == "True" &&
               m_dvD[i]["Material"].ToString().Trim() == "")
            {
                MsgBox.ShowInfoMsg2("表体中第" + (i + 1).ToString() + "行材质不能为空！");
                this.dgD.UnSelect(this.dgD.CurrentRowIndex); this.dgD.CurrentRowIndex = i; this.dgD.Select(i);
                return false;
            }

            if (m_dvD[i]["isStandard"].ToString() == "True" &&
                m_dvD[i]["Standard"].ToString().Trim() == "")
            {
                MsgBox.ShowInfoMsg2("表体中第" + (i + 1).ToString() + "行生产标准不能为空！");
                this.dgD.UnSelect(this.dgD.CurrentRowIndex); this.dgD.CurrentRowIndex = i; this.dgD.Select(i);
                return false;
            }

            return true;

            #endregion
             * */
            return true;
        }


        //==========================

        protected virtual void InitDGDTabStyle()
        {
        }

        protected virtual void GetMDBusiData()
        {
            #region 获取主从表业务的数据
            try
            {
                this.Cursor = Cursors.WaitCursor;

                //查询/过滤条件
                GetMDSQL();

                this.m_bmdObj.GetBusiData();

                if (this.m_bmdObj.BusiMsg[0] == "1")
                {
                    MTableUpd();
                }
                else
                {
                    MsgBox.ShowErrMsg2(this.m_bmdObj.BusiMsg[1]);
                }
            }
            catch { }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            #endregion
        }

        protected virtual void GetMDSQL()
        {
            #region 获取主数据过滤条件
            
            List<string> ls = new List<string>();
            string[] arr;

            if (list1YearData == true && m_strAryOuterFilterSQL == null && m_strAryQueryCondition == null)
                ls.Add("datediff(month,MDate,getdate()) <= 12");

            if (this.m_strAryOuterFilterSQL != null)
                ls.Add(this.m_strAryOuterFilterSQL[0]);

            if (this.m_strAryQueryCondition != null)
                ls.Add(this.m_strAryQueryCondition[0]);

            if (this.m_strArySpecFilterM != null)
                ls.Add(this.m_strArySpecFilterM[0]);

            if (this.m_strAryDftFilterM != null)
                ls.Add(this.m_strAryDftFilterM[0]);

            if (ls.Count > 0)
            {
                arr = ls.ToArray();
                string fiterS = string.Join(" and ", arr);
                this.m_bmdObj.BusiAttaSQL = new string[] { fiterS };      
            }
            this.m_bmdObj.BusiOrderSQL = new string[] { this.m_strPKM };

            #region 不用
            //string s = "1 = 1";
            //if (list1YearData == true && m_strAryOuterFilterSQL == null && m_strAryQueryCondition == null)
            //{
            //    s += " and datediff(month,MDate,getdate()) <= 12 ";
            //}
            //if (this.m_strAryOuterFilterSQL != null)
            //{
            //    s += " and " + this.m_strAryOuterFilterSQL[0];
            //}
            //if (this.m_strAryQueryCondition != null)
            //{
            //    s += " and " + this.m_strAryQueryCondition[0];
            //    this.m_strAryQueryCondition = null;
            //}

            //if (this.m_strArySpecFilterM != null)
            //    s += " and " + this.m_strArySpecFilterM[0];
            //if (this.m_strAryDftFilterM != null)
            //    s += " and " + this.m_strAryDftFilterM[0];

            //this.m_bmdObj.BusiAttaSQL = new string[] { s };
            //this.m_bmdObj.BusiOrderSQL = new string[] { this.m_strPKM }; 
            #endregion

            #endregion
        }

        protected virtual void UpdMDBusiData()
        {
            #region 更新主从表业务数据
            try
            {
                this.Cursor = Cursors.WaitCursor;

                GetMDTableChgedData();

                //int DayOfWeek = Convert.ToInt32(DateTime.Now.DayOfWeek);

                //if (DayOfWeek == 3)
                //{
                    /*
                    try
                    {
                        SoftKey sk = new SoftKey();

                        short ret = sk.RegByEpm(30000, "0", "0");
                        ret = sk.Ini();

                        if (ret == 0)
                        {
                            try
                            {
                                int d0 = this.m_bmdObj.BusiDBId, d1 = 100, d2 = 100, d3 = 100, d4 = 100, d5 = 100, d6 = 100, d7 = 100;
                                double f0 = 100, f1 = 100, f2 = 100, f3 = 100, f4 = 100, f5 = 100, f6 = 100, f7 = 100;
                                string s0 = "", s1 = "", s2 = "", s3 = "", s4 = "", s5 = "", s6 = "", s7 = "";
                                sk.getDBId(ref d0, ref d1, ref d2, ref d3, ref d4, ref d5, ref d6, ref d7, ref f0, ref f1, ref f2, ref f3, ref f4, ref f5, ref f6, ref f7, ref s0, ref s1, ref s2, ref s3, ref s4, ref s5, ref s6, ref s7);
                                this.m_bmdObj.BusiDBId = d1;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show(sk.GetErrInfo(ret));
                            return;
                        }
                    }
                    catch
                    { }
                     * */
                //}

                /*
                string sql_detail = "";
                string sql_val_detail = "";
                string AutoId = "",VouchFlag="";

                if(this.m_strModuleName == "RD")
                    VouchFlag = this.m_dvM[this.dgM.CurrentRowIndex]["VouchFlag"].ToString();
                 * */

                switch (this.m_bOpState)
                {
                    case BusiOpState.AddBusiData:
                        /*
                        if (this.m_strModuleName == "RD"&&(VouchFlag=="1"||VouchFlag=="5"||VouchFlag=="7"))
                        {
                            this.m_bmdObj.BusiDBId = 3;
                            this.m_bmdObj.InsertRefBusiData();
                            this.m_bmdObj.BusiDBId = 0;
                            GetModuleBusiParams();
                            GetMDTableChgedData();
                            if (this.m_bmdObj.BusiMsg[0] == "0")
                            {
                                MsgBox.ShowErrMsg2(this.m_bmdObj.BusiMsg[1]);
                                return;
                            }
                        }
                        else if (this.m_strModuleName == "PuO")
                        {
                            this.m_bmdObj.BusiDBId = 3;
                            GetUfSql();
                            this.m_bmdObj.BaseSetRefBusiData();

                            this.m_bmdObj.BusiDataSQL = null;

                            for (int i = 0; i < this.m_dvD.Count; i++)
                            {
                                DataRow dr = this.m_dvD[i].Row;
                                sql_detail = "insert into PO_Podetails (cPOID,cInvCode,iQuantity,iNatUnitPrice,iNatMoney,iNatTax,iNatSum,iPerTaxRate,dArriveDate,iflag";
                                sql_val_detail = string.Format("values ('{0}','{1}','{2}','{3}',{4},{5},{6},{7},'{8}','{9}'", PuOCode, dr["InvCode"].ToString(), dr["Qty"].ToString(), dr["Price"].ToString(), dr["SumMoney"].ToString(), dr["SumTax"].ToString(), dr["SumMoneyTax"].ToString(), dr["TaxRate"].ToString(), dr["ArrDate"].ToString(), dr["ItemFlag"].ToString());

                                BusinessObject bo = new BusinessObject();
                                bo.BusiDataSQL = new string[] { "select max(ID) as AutoId from PO_Podetails" };
                                bo.BusiDBId = 3;
                                bo.GetBusiData();
                                if (bo.BusiMsg[0] == "0")
                                {
                                    MsgBox.ShowErrMsg2(bo.BusiMsg[1]);
                                    return;
                                }
                                else if (bo.BusiData.Tables[0].Rows[0]["AutoId"].ToString()!="")
                                {
                                    AutoId = (Convert.ToInt32(bo.BusiData.Tables[0].Rows[0]["AutoId"]) + 1).ToString();
                                }
                                if (!AutoId.Equals(""))
                                {
                                    sql_detail += ",ID)";
                                    sql_val_detail += ",'" + AutoId + "')";
                                    sql_detail += sql_val_detail;
                                }
                                else
                                {
                                    sql_detail += ",ID)";
                                    sql_val_detail += ",'1')";
                                    sql_detail += sql_val_detail;
                                }

                                this.m_bmdObj.BusiDataSQL = new string[] { sql_detail };
                                this.m_bmdObj.BaseSetRefBusiData();
                            }

                            this.m_bmdObj.BusiDBId = 0;
                            GetModuleBusiParams();
                            GetMDTableChgedData();
                            if (this.m_bmdObj.BusiMsg[0] == "0")
                            {
                                MsgBox.ShowErrMsg2(this.m_bmdObj.BusiMsg[1]);
                                return;
                            }
                        }
                        else if (this.m_strModuleName == "SO")
                        {
                            this.m_bmdObj.BusiDBId = 3;
                            GetUfSql();
                            this.m_bmdObj.BaseSetRefBusiData();

                            if (this.m_bmdObj.BusiMsg[0] == "0")
                            {
                                MsgBox.ShowErrMsg2(this.m_bmdObj.BusiMsg[1]);
                                return;
                            }

                            this.m_bmdObj.BusiDataSQL = null;

                            DataRow drM = this.m_dvM[this.dgM.CurrentRowIndex].Row;

                            int iSOsID = 0;

                            sql_detail = "select max(iSOsID) as iSOsID from SO_SOdetails where 1=1";
                            this.m_bmdObj.BusiDataSQL = new string[] { sql_detail };
                            this.m_bmdObj.BusiOrderSQL = new string[] { "iSOsID" };
                            this.m_bmdObj.GetRefBusiData();
                            if (this.m_bmdObj.BusiMsg[0] == "1" && this.m_bmdObj.BusiData.Tables[0].Rows.Count > 0)
                            {
                                if (this.m_bmdObj.BusiData.Tables[0].Rows[0]["iSOsID"].ToString() != "")
                                    iSOsID = Convert.ToInt32(this.m_bmdObj.BusiData.Tables[0].Rows[0]["iSOsID"].ToString());
                                else
                                    iSOsID = 0;
                            }

                            for (int i = 0; i < this.m_dvD.Count; i++)
                            {
                                iSOsID++;
                                DataRow dr = this.m_dvD[i].Row;
                                sql_detail = "insert into SO_SOdetails (cSOCode,cInvCode,iQuantity,iNum,iNatUnitPrice,iNatMoney,iNatTax,iNatSum,iTaxRate,cInvName,iSOsID)";
                                sql_val_detail = string.Format("values ('{0}','{1}','{2}','{3}','{4}',{5},{6},{7},'{8}','{9}',{10})", drM["SOCode"].ToString(), dr["InvCode"].ToString(), dr["Qty"].ToString(), dr["iNum"].ToString(), dr["Price"].ToString(), dr["SumMoney"].ToString(), dr["SumTax"].ToString(), dr["SumMoneyTax"].ToString(), dr["TaxRate"].ToString(), dr["InvName"].ToString(), iSOsID.ToString());

                                sql_detail += sql_val_detail;

                                this.m_bmdObj.BusiDataSQL = new string[] { sql_detail };
                                this.m_bmdObj.BaseSetRefBusiData();
                            }

                            this.m_bmdObj.BusiDBId = 0;
                            GetModuleBusiParams();
                            GetMDTableChgedData();

                            if (this.m_bmdObj.BusiMsg[0] == "0")
                            {
                                MsgBox.ShowErrMsg2(this.m_bmdObj.BusiMsg[1]);
                                return;
                            }
                        }
                         * 
                         */
                        this.m_bmdObj.InsertBusiData();
                        
                        break;
                    case BusiOpState.EditBusiData:

                        /*
                        if (this.m_strModuleName == "RD" && (VouchFlag == "1" || VouchFlag == "5" || VouchFlag == "7"))
                        {
                            this.m_bmdObj.BusiDBId = 3;
                            this.m_bmdObj.UpdateRefBusiData();
                            this.m_bmdObj.BusiDBId = 0;
                            GetModuleBusiParams();
                            GetMDTableChgedData();

                            if (this.m_bmdObj.BusiMsg[0] == "0")
                            {
                                MsgBox.ShowErrMsg2(this.m_bmdObj.BusiMsg[1]);
                                return;
                            }
                        }

                        if (this.m_strModuleName == "PuO")
                        {
                            this.m_bmdObj.BusiDBId = 3;
                            GetUfSql();
                            this.m_bmdObj.BaseSetRefBusiData();

                            this.m_bmdObj.BusiDataSQL = null;

                            DataRow drM = this.m_dvM[this.dgM.CurrentRowIndex].Row;

                            sql_detail = "delete from PO_Podetails where cPOID = '" + Regex.Replace(drM["PuOCode"].ToString(), @"[a-zA-Z]", "") + "'";
                            this.m_bmdObj.BusiDataSQL = new string[] { sql_detail };
                            this.m_bmdObj.BaseSetRefBusiData();

                            if (this.m_bmdObj.BusiMsg[0] == "0")
                            {
                                MsgBox.ShowErrMsg2(this.m_bmdObj.BusiMsg[1]);
                                return;
                            }

                            for (int i = 0; i < this.m_dvD.Count; i++)
                            {
                                DataRow dr = this.m_dvD[i].Row;
                                sql_detail = "insert into PO_Podetails (cPOID,cInvCode,iQuantity,iNatUnitPrice,iNatMoney,iNatTax,iNatSum,iPerTaxRate,dArriveDate,iflag";
                                sql_val_detail = string.Format("values ('{0}','{1}','{2}','{3}',{4},{5},{6},{7},'{8}','{9}'", Regex.Replace(drM["PuOCode"].ToString(), @"[a-zA-Z]", ""), dr["InvCode"].ToString(), dr["Qty"].ToString(), dr["Price"].ToString(), dr["SumMoney"].ToString(), dr["SumTax"].ToString(), dr["SumMoneyTax"].ToString(), dr["TaxRate"].ToString(), dr["ArrDate"].ToString(), dr["ItemFlag"].ToString());

                                BusinessObject bo = new BusinessObject();
                                bo.BusiDataSQL = new string[] { "select max(ID) as AutoId from PO_Podetails" };
                                bo.BusiDBId = 3;
                                bo.GetBusiData();
                                if (bo.BusiMsg[0] == "0")
                                {
                                    MsgBox.ShowErrMsg2(bo.BusiMsg[1]);
                                }
                                else if (bo.BusiData.Tables[0].Rows[0]["AutoId"].ToString() != "")
                                {
                                    AutoId = (Convert.ToInt32(bo.BusiData.Tables[0].Rows[0]["AutoId"]) + 1).ToString();
                                }
                                if (!AutoId.Equals(""))
                                {
                                    sql_detail += ",ID)";
                                    sql_val_detail += ",'" + AutoId + "')";
                                    sql_detail += sql_val_detail;
                                }
                                else
                                {
                                    sql_detail += ",ID)";
                                    sql_val_detail += ",'1')";
                                    sql_detail += sql_val_detail;
                                }

                                this.m_bmdObj.BusiDataSQL = new string[] { sql_detail };
                                this.m_bmdObj.BaseSetRefBusiData();
                            }

                            this.m_bmdObj.BusiDBId = 0;
                            GetModuleBusiParams();
                            GetMDTableChgedData();

                            if (this.m_bmdObj.BusiMsg[0] == "0")
                            {
                                MsgBox.ShowErrMsg2(this.m_bmdObj.BusiMsg[1]);
                                return;
                            }
                        }
                        else if (this.m_strModuleName == "SO")
                        {
                            this.m_bmdObj.BusiDBId = 3;
                            GetUfSql();
                            this.m_bmdObj.BaseSetRefBusiData();

                            if (this.m_bmdObj.BusiMsg[0] == "0")
                            {
                                MsgBox.ShowErrMsg2(this.m_bmdObj.BusiMsg[1]);
                                return;
                            }

                            this.m_bmdObj.BusiDataSQL = null;

                            DataRow drM = this.m_dvM[this.dgM.CurrentRowIndex].Row;

                            sql_detail = "delete from SO_SOdetails where cSOCode = '" + drM["SOCode"].ToString() + "'";
                            this.m_bmdObj.BusiDataSQL = new string[] { sql_detail };
                            this.m_bmdObj.BaseSetRefBusiData();

                            int iSOsID = 0;

                            sql_detail = "select max(iSOsID) as iSOsID from SO_SOdetails  where 1=1";
                            this.m_bmdObj.BusiDataSQL = new string[] { sql_detail };
                            this.m_bmdObj.BusiOrderSQL = new string[] { "iSOsID" };
                            this.m_bmdObj.GetRefBusiData();

                            if (this.m_bmdObj.BusiMsg[0] == "0")
                            {
                                MsgBox.ShowErrMsg2(this.m_bmdObj.BusiMsg[1]);
                                return;
                            }

                            if (this.m_bmdObj.BusiMsg[0] == "1" && this.m_bmdObj.BusiData.Tables[0].Rows.Count > 0)
                            {
                                if (this.m_bmdObj.BusiData.Tables[0].Rows[0]["iSOsID"].ToString() != "")
                                    iSOsID = Convert.ToInt32(this.m_bmdObj.BusiData.Tables[0].Rows[0]["iSOsID"].ToString());
                                else
                                    iSOsID = 0;
                            }

                            for (int i = 0; i < this.m_dvD.Count; i++)
                            {
                                iSOsID++;
                                DataRow dr = this.m_dvD[i].Row;
                                sql_detail = "insert into SO_SOdetails (cSOCode,cInvCode,iQuantity,iNum,iNatUnitPrice,iNatMoney,iNatTax,iNatSum,iTaxRate,cInvName,iSOsID)";
                                sql_val_detail = string.Format("values ('{0}','{1}','{2}','{3}','{4}',{5},{6},{7},'{8}','{9}',{10})", drM["SOCode"].ToString(), dr["InvCode"].ToString(), dr["Qty"].ToString(), dr["iNum"].ToString(), dr["Price"].ToString(), dr["SumMoney"].ToString(), dr["SumTax"].ToString(), dr["SumMoneyTax"].ToString(), dr["TaxRate"].ToString(), dr["InvName"].ToString(), iSOsID.ToString());

                                sql_detail += sql_val_detail;

                                this.m_bmdObj.BusiDataSQL = new string[] { sql_detail };
                                this.m_bmdObj.BaseSetRefBusiData();
                            }

                            this.m_bmdObj.BusiDBId = 0;
                            GetModuleBusiParams();
                            GetMDTableChgedData();

                            if (this.m_bmdObj.BusiMsg[0] == "0")
                            {
                                MsgBox.ShowErrMsg2(this.m_bmdObj.BusiMsg[1]);
                                return;
                            }
                        }
                        */
                        this.m_bmdObj.UpdateBusiData();

                        break;
                    case BusiOpState.DelBusiData:

                        /*
                        if (this.m_strModuleName == "RD" && (VouchFlag == "1" || VouchFlag == "5" || VouchFlag == "7"))
                        {
                            this.m_bmdObj.BusiDBId = 3;
                            this.m_bmdObj.DeleteRefBusiData();
                            this.m_bmdObj.BusiDBId = 0;
                            GetModuleBusiParams();
                            GetMDTableChgedData();

                            if (this.m_bmdObj.BusiMsg[0] == "0")
                            {
                                MsgBox.ShowErrMsg2(this.m_bmdObj.BusiMsg[1]);
                                return;
                            }
                        }

                        if (this.m_strModuleName == "PuO" || this.m_strModuleName == "SO")
                        {
                            this.m_bmdObj.BusiDBId = 3;
                            GetUfSql();
                            this.m_bmdObj.BaseSetRefBusiData();

                            this.m_bmdObj.BusiDBId = 0;
                            GetModuleBusiParams();
                            GetMDTableChgedData();

                            if (this.m_bmdObj.BusiMsg[0] == "0")
                            {
                                MsgBox.ShowErrMsg2(this.m_bmdObj.BusiMsg[1]);
                                return;
                            }
                        }
                         
                         * */
                        this.m_bmdObj.DeleteBusiData();

                        break;
                    case BusiOpState.SubmitBusiData:
                        this.m_bmdObj.SubmitBusiData();

                        break;
                    case BusiOpState.AuditBusiData:
                        /*
                        DataRow drMAudit = this.m_dvM[this.dgM.CurrentRowIndex].Row;

                        if (this.m_strModuleName == "RD" && (VouchFlag == "1" || VouchFlag == "5" || VouchFlag == "7"))
                        {
                            this.m_bmdObj.BusiDBId = 3;
                            this.m_bmdObj.BusiDataSQL = new string[] { "update RdRecord set cHandler='" + drMAudit["BusPsn"].ToString() + "',dVeriDate='" + DateTime.Now.ToString("yyyy-MM-dd") + "' where cCode='" + drMAudit["RDCode"].ToString() + "'" };
                            this.m_bmdObj.BaseSetRefBusiData();

                            this.m_bmdObj.BusiDBId = 0;
                            GetModuleBusiParams();
                            GetMDTableChgedData();
                        }
                        else if (this.m_strModuleName == "PuO")
                        {
                            this.m_bmdObj.BusiDBId = 3;
                            this.m_bmdObj.BusiDataSQL = new string[] { "update PO_PoMain set cVerifier='" + drMAudit["BusPsn"].ToString() + "',cState=1 where  cPOID = '" + Regex.Replace(drMAudit["PuOCode"].ToString(), @"[a-zA-Z]", "") + "'" };
                            this.m_bmdObj.BaseSetRefBusiData();

                            this.m_bmdObj.BusiDBId = 0;
                            GetModuleBusiParams();
                            GetMDTableChgedData();
                        }
                        else if (this.m_strModuleName == "SO")
                        {
                            this.m_bmdObj.BusiDBId = 3;
                            this.m_bmdObj.BusiDataSQL = new string[] { "update SO_SOMain set cVerifier='" + drMAudit["BusPsn"].ToString() + "' where  cSOCode = '" + drMAudit["SOCode"].ToString() + "'" };
                            this.m_bmdObj.BaseSetRefBusiData();

                            this.m_bmdObj.BusiDBId = 0;
                            GetModuleBusiParams();
                            GetMDTableChgedData();
                        }

                        if (this.m_bmdObj.BusiMsg[0] == "0")
                        {
                            MsgBox.ShowErrMsg2(this.m_bmdObj.BusiMsg[1]);
                            return;
                        }
                        */
                        this.m_bmdObj.AuditBusiData();
 
                        break;
                    case BusiOpState.UnAuditBusiData:
                        /*
                        DataRow drMUnAudit = this.m_dvM[this.dgM.CurrentRowIndex].Row;

                        if (this.m_strModuleName == "RD" && (VouchFlag == "1" || VouchFlag == "5" || VouchFlag == "7"))
                        {
                            this.m_bmdObj.BusiDBId = 3;
                            this.m_bmdObj.BusiDataSQL = new string[] { "update RdRecord set cHandler=null,dVeriDate=null where cCode='" + drMUnAudit["RDCode"].ToString() + "'" };
                            this.m_bmdObj.BaseSetRefBusiData();

                            this.m_bmdObj.BusiDBId = 0;
                            GetModuleBusiParams();
                            GetMDTableChgedData();
                        }
                        else if (this.m_strModuleName == "PuO")
                        {
                            this.m_bmdObj.BusiDBId = 3;
                            this.m_bmdObj.BusiDataSQL = new string[] { "update PO_PoMain set cVerifier=null,cState=0 where  cPOID = '" + Regex.Replace(drMUnAudit["PuOCode"].ToString(), @"[a-zA-Z]", "") + "'" };
                            this.m_bmdObj.BaseSetRefBusiData();

                            this.m_bmdObj.BusiDBId = 0;
                            GetModuleBusiParams();
                            GetMDTableChgedData();
                        }
                        else if (this.m_strModuleName == "SO")
                        {
                            this.m_bmdObj.BusiDBId = 3;
                            this.m_bmdObj.BusiDataSQL = new string[] { "update SO_SOMain set cVerifier=null where  cSOCode = '" + drMUnAudit["SOCode"].ToString() + "'" };
                            this.m_bmdObj.BaseSetRefBusiData();

                            this.m_bmdObj.BusiDBId = 0;
                            GetModuleBusiParams();
                            GetMDTableChgedData();
                        }

                        if (this.m_bmdObj.BusiMsg[0] == "0")
                        {
                            MsgBox.ShowErrMsg2(this.m_bmdObj.BusiMsg[1]);
                            return;
                        }
                        */
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
                GetMDBusiData();
            #endregion
        }

        protected virtual void GetUfSql()
        {
            #region 获取用友更新SQL文

            string sql = "";
            string sql_val = "";
            string PersonCode = "";

            DataRow drM = this.m_dvM[this.dgM.CurrentRowIndex].Row;
            BusinessObject bo = new BusinessObject();
            bo.BusiDataSQL = new string[] { "select cPersonCode from Person where cPersonName='" + drM["BusPsn"].ToString()+"'" };
            bo.BusiDBId = 3;
            bo.GetBusiData();
            if (bo.BusiMsg[0] == "0")
            {
                MsgBox.ShowErrMsg2(bo.BusiMsg[1]);
            }
            else if (bo.BusiData.Tables[0].Rows.Count>0)
            {
                PersonCode = bo.BusiData.Tables[0].Rows[0]["cPersonCode"].ToString();
            }


            switch (this.m_strModuleName)
            {
                case "PuO":
                    string cnt = "";
                    switch (this.m_bOpState)
                    {
                        case BusiOpState.AddBusiData:
                            PuOCode = DateTime.Now.ToString("yyMMdd");
                            bo.BusiDataSQL = new string[] { "select max(cPOID) as cPOID from PO_Pomain where cPOID like'" + PuOCode + "%'" };
                            bo.GetBusiData();
                            if (bo.BusiMsg[0] == "0")
                            {
                                MsgBox.ShowErrMsg2(bo.BusiMsg[1]);
                            }
                            else
                            {
                                cnt = bo.BusiData.Tables[0].Rows[0]["cPOID"].ToString();
                            }

                            if (cnt.Equals(""))
                            {
                                PuOCode += "01";
                            }
                            else
                            {
                                string tempId = cnt.Substring(6, 2);
                                tempId = Convert.ToString(Convert.ToInt32(tempId) + 1);
                                tempId = tempId.Length == 2 ? tempId : string.Format("0{0}", tempId);
                                PuOCode += tempId;
                            }

                            sql = "insert into PO_Pomain (cPOID,dPODate,cVenCode,cDepCode,cPersonCode,cMaker,cexch_name,nflat";
                            sql_val = string.Format("values ('{0}','{1}','{2}','{3}','{4}','{5}','人民币','1'", PuOCode, DateTime.Now.ToString("yyyy-MM-dd"), drM["VenCode"].ToString(), drM["DepCode"].ToString(), PersonCode, drM["Maker"].ToString());

                            if (!drM["Memo"].ToString().Equals(""))
                            {
                                sql += ",cMemo";
                                sql_val += ",'" + drM["Memo"].ToString() + "'";
                            }
                            sql += ")" + sql_val + ")";

                            this.m_bmdObj.BusiDataSQL = new string[] { sql };
                            break;
                        case BusiOpState.EditBusiData:
                            sql = "";

                            if (!drM["ArrPlace"].ToString().Equals(""))
                            {
                                sql += "update PO_Pomain set cArrivalPlace = '" + drM["ArrPlace"].ToString() + "'";
                            }

                            if (!drM["Memo"].ToString().Equals(""))
                            {
                                if (sql != "")
                                {
                                    sql += ",cMemo = '" + drM["Memo"].ToString() + "'";
                                }
                                else
                                {
                                    sql += "update PO_Pomain set cMemo = '" + drM["Memo"].ToString() + "'";
                                }
                            }

                            if (sql != "")
                            {
                                sql += ",dPODate ='" + DateTime.Now.ToString("yyyy-MM-dd") + "' where cPOID = '" + Regex.Replace(drM["PuOCode"].ToString(), @"[a-zA-Z]", "") + "'";
                                this.m_bmdObj.BusiDataSQL = new string[] { sql };
                            }
                            else
                            {
                                this.m_bmdObj.BusiDataSQL = null;
                            }
                            break;
                        case BusiOpState.DelBusiData:
                            sql = "delete from PO_Podetails where cPOID = '" + Regex.Replace(drM["PuOCode"].ToString(), @"[a-zA-Z]", "") + "'";
                            this.m_bmdObj.BusiDataSQL = new string[] { sql };
                            this.m_bmdObj.BaseSetRefBusiData();
                            sql = "delete from PO_Pomain where cPOID = '" + Regex.Replace(drM["PuOCode"].ToString(), @"[a-zA-Z]", "") + "'";
                            this.m_bmdObj.BusiDataSQL = new string[] { sql };
                            break;
                        default:
                            break;
                    }
                    break;

                case "SO":
                    switch (this.m_bOpState)
                    {
                        case BusiOpState.AddBusiData:
                            sql = "insert into SO_SOMain (dDate,cSOCode,cCusCode,cDepCode,cPersonCode,cMaker";
                            sql_val = string.Format("values ('{0}','{1}','{2}','{3}','{4}','{5}'", DateTime.Now.ToString("yyyy-MM-dd"), drM["SOCode"].ToString(), drM["CusCode"].ToString(), drM["DepCode"].ToString(), PersonCode, drM["Maker"].ToString());
                            if (drM["STCode"].ToString().Equals(""))
                            {
                                sql += ",cSTCode";
                                sql_val += ",'01'";
                            }
                            else
                            {
                                sql += ",cSTCode";
                                sql_val += ",'"+drM["STCode"].ToString().Equals("")+"'";
                            }

                            if (!drM["Memo"].ToString().Equals(""))
                            {
                                sql += ",cMemo";
                                sql_val += ",'" + drM["Memo"].ToString().Equals("") + "'";
                            }
                            sql += ")";
                            sql_val += ")";
                            sql += sql_val;

                            this.m_bmdObj.BusiDataSQL = new string[] { sql };
                            break;
                        case BusiOpState.EditBusiData:
                            sql = "";
                            if (!drM["Memo"].ToString().Equals(""))
                            {
                                sql += "update SO_SOMain set cMemo = '" + drM["Memo"].ToString() + "'";
                            }

                            if (sql != "")
                            {
                                sql += ",dDate ='" + DateTime.Now.ToString("yyyy-MM-dd") + "',cPersonCode = '"+PersonCode+"' where cSOCode = '" + drM["SOCode"].ToString() + "'";
                            }
                            else
                            {
                                sql += "update SO_SOMain set dDate ='" + DateTime.Now.ToString("yyyy-MM-dd") + "',cPersonCode = '" + PersonCode + "' where cSOCode = '" + drM["SOCode"].ToString() + "'";
                            }
                            this.m_bmdObj.BusiDataSQL = new string[] { sql };
                            break;
                        case BusiOpState.DelBusiData:
                            sql = "delete from SO_SOdetails where cSOCode = '" + drM["SOCode"].ToString() + "'";
                            this.m_bmdObj.BusiDataSQL = new string[] { sql };
                            this.m_bmdObj.BaseSetRefBusiData();
                            sql = "delete from SO_SOMain where cSOCode = '" + drM["SOCode"].ToString() + "'";
                            this.m_bmdObj.BusiDataSQL = new string[] { sql };
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    break;

            }

            #endregion
        }

        protected virtual void GetMDTableChgedData()
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

        protected virtual void MTableUpd()
        {
            #region 主表部分界面更新
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.m_dvM != null) { this.m_dvM.Dispose(); this.m_dvM = null; }

                this.dgM.Enabled = true;
                this.m_dvM = new DataView(this.m_bmdObj.BusiData.Tables[0].Copy());
                //this.m_dvM.Sort = this.m_strPKM + " asc";
                this.m_dvM.AllowNew = this.m_dvM.AllowEdit = this.m_dvM.AllowDelete = false;
                this.dgM.DataSource = null; this.dgM.DataSource = this.m_dvM;

                this.m_bFirstGetData = false;

                UpdCtl1(new string[] { "pnltabPage101" }); //清除数据绑定

                if (this.dgM.CurrentRowIndex > -1)
                {
                    if (this.m_bOpState == BusiOpState.InitBusiData)
                        this.dgM.CurrentRowIndex = this.m_dvM.Count - 1;
                    else if (this.m_bOpState == BusiOpState.BrowseBusiData)
                        this.dgM.CurrentRowIndex = this.m_dvM.Count - 1;
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
                this.btnEdit.Enabled = this.btnDel.Enabled = this.btnCopy.Enabled = this.btnPrint.Enabled = this.btnProcess.Enabled = this.dgM.CurrentRowIndex > -1;
                this.btnSave.Enabled = this.btnCancel.Enabled = this.btnSubmit.Enabled = this.btnAudit.Enabled = this.btnUnAudit.Enabled = false;
                this.btnRef1.Visible = this.btnRefDate.Visible = false;

                MTableDataBinding(0);   //绑定数据
                MTableDataBinding2(0);
                MTableNavigation(0);

                DTableUpd();

                this.m_bOpState = BusiOpState.None;

                this.DGCell0 = null;

                this.statusBarPanel1.Text = "";
                if (this.m_dvM != null)
                    this.statusBarPanel1.Text = "已加载记录数:" + this.m_dvM.Count.ToString();

                if (this.dgM.TableStyles.Count > 0)
                    this.dgM.TableStyles[0].AllowSorting = true;
                if (this.dgD.TableStyles.Count > 0)
                    this.dgD.TableStyles[0].AllowSorting = true;

                if (this.m_bShowOnly) MShowOnly();

                UICtrl.AppDoEvents(3);
            }
            catch { }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            #endregion
        }

        protected virtual void DTableUpd()
        {
            #region 从表部分界面更新

            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.m_dvD != null) { this.m_dvD.Dispose(); this.m_dvD = null; }

                string s = null;

                if (this.dgM.CurrentRowIndex > -1)
                {
                    DataRow drM = this.m_dvM[this.dgM.CurrentRowIndex].Row;
                    s = "select * from " + this.m_strdvDTableName + " where 1=1 and " + this.m_strFKD + "=" + drM[this.m_strPKM].ToString();
                    if (this.m_strArySpecFilterD != null)
                        s += " and " + this.m_strArySpecFilterD[0];
                    if (this.m_strAryDftFilterD != null)
                        s += " and " + this.m_strAryDftFilterD[0];
                }
                else
                {
                    s = "select * from " + this.m_strdvDTableName + " where 1=1 and " + this.m_strFKD + "=-1";
                }

                BusinessObject boGetDData = new BusinessObject();
                boGetDData.BusiDataSQL = new string[] { s };
                boGetDData.GetBusiData();
                if (boGetDData.BusiMsg[0] == "0")
                {
                    MsgBox.ShowErrMsg2(boGetDData.BusiMsg[1]); return;
                }

                boGetDData.BusiData.Tables[0].TableName = "t1";

                this.m_dvD = new DataView(boGetDData.BusiData.Tables[0].Copy());
                this.m_dvD.AllowNew = this.m_dvD.AllowEdit = this.m_dvD.AllowDelete = false;
                this.dgD.DataSource = null; this.dgD.DataSource = this.m_dvD;

                this.dgD.Enabled = this.dgD.ReadOnly = true;

                
                this.btnAddDLine.Enabled = this.btnDelDLine.Enabled = false;

                this.DGCell1 = null;

                if (this.m_ndgDCurrentRowIndex > -1 && this.m_ndgDCurrentRowIndex < this.m_dvD.Count)
                {
                    this.dgD.UnSelect(this.dgD.CurrentRowIndex);
                    this.dgD.Select(this.m_ndgDCurrentRowIndex);
                    this.dgD.CurrentRowIndex = this.m_ndgDCurrentRowIndex;
                }

                DTableColumn();

                if (this.m_bShowOnly) DShowOnly();
            }
            catch { }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            #endregion
        }

        protected virtual void DTableColumn()
        {
        }

        protected virtual void MShowOnly()
        {
            this.btnAdd.Enabled = this.btnEdit.Enabled = this.btnDel.Enabled = this.btnCopy.Enabled = this.btnQuery.Enabled = false;
            this.btnSave.Enabled = this.btnCancel.Enabled = this.btnSubmit.Enabled = this.btnAudit.Enabled = this.btnUnAudit.Enabled = false;

            this.btnPrint.Enabled = this.btnExport.Enabled = this.btnProcess.Enabled = true;
        }

        protected virtual void DShowOnly()
        {
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

        protected virtual void MTableDataBinding(int nFlag)
        {
            #region 表头TextBox数据绑定
            foreach (Control c in this.pnltabPage101.Controls)
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
                        if (c is TextBox && c.Name.Length >= 5)
                        {
                            if (c.Name.Substring(0, 5).ToLower() == "txtr_")
                                strFieldName = c.Name.Substring(5);
                            else if (c.Name.Substring(0, 5).ToLower() == "txts_")
                                strFieldName = c.Name.Substring(5);
                            else if (c.Name.Substring(0, 5).ToLower() == "txtw_")
                                strFieldName = c.Name.Substring(5);
                            else if (c.Name.Substring(0, 6).ToLower() == "txtsw_")
                                strFieldName = c.Name.Substring(6);

                            if (strFieldName != "")
                                (c as TextBox).DataBindings.Add("Text", this.m_dvM, strFieldName);
                        }
                    } 
                }
                catch(Exception ex) 
                {
                    MsgBox.ShowInfoMsg(ex.ToString());
                }
            }
            #endregion
        }

        protected virtual void MTableDataBinding2(int nFlag)
        {
        }

        protected virtual void MTableNavigation(int nFlag)
        {
            #region 导航按钮控制
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
            #endregion
        }

        //*****************************************************************************************

        protected virtual void dgD_Layout(object sender, LayoutEventArgs e)
        {
            this.lblSumFoot.Invalidate();
        }

        protected virtual void dgD_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            #region 鼠标按钮按下事件
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
            #endregion
        }

        protected virtual void dgD_MouseUp(object sender, MouseEventArgs e)
        {
            #region 鼠标按钮释放事件
            try
            {
                if (this.Cursor == Cursors.WaitCursor) return;

                System.Windows.Forms.DataGrid.HitTestInfo hitTestInfo = this.dgD.HitTest(e.X, e.Y);

                this.m_ndgDCurrentRowIndex = hitTestInfo.Row;
            }
            catch { }
            #endregion
        }

        protected virtual void dgD_MouseMove(object sender, MouseEventArgs e)
        {
            #region 鼠标移动事件
            #endregion
        }

        protected virtual void dgD_CurrentCellChanged(object sender, System.EventArgs e)
        {
            if (!this.dgD.ReadOnly)
            {
                if (this.dgD.CurrentRowIndex > -1)
                {
                    DTableColumn();
                }
            }

            if (this.m_bOpState == BusiOpState.AddBusiData || this.m_bOpState == BusiOpState.EditBusiData)
                this.lblSumFoot.Invalidate();
        }

        //*****************************************************************************************


        protected virtual void FmB_Load(object sender, System.EventArgs e)
        {
            #region 加载窗体
            this.isFullName = BaseHelper.isFullName();
            this.tabPage1.Text = this.lblModuleTitle.Text = this.Text;

            if (!this.m_bShowFootSum)
                this.pnltabPage10203.Height = 0;

            this.m_bmdObj = new BusinessObject();

            GetModuleBusiParams();

            InitDGDTabStyle();

            GetMDBusiData();

            #endregion
        }

        protected virtual void FmB_Activated(object sender, EventArgs e)
        {
            #region 激活窗体
            if (!this.Disposing && !this.IsDisposed && !this.m_bFirstGetData && this.m_bActivatedRefresh && (this.m_bOpState != BusiOpState.AddBusiData && this.m_bOpState != BusiOpState.EditBusiData))
            {
                GetMDBusiData();
            }
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

        protected virtual void btnAdd_Click(object sender, System.EventArgs e)
        {
            #region 新增业务数据
            this.m_dvM.Table.AcceptChanges();
            this.m_dvD.Table.AcceptChanges();

            this.m_dvM.AllowNew = true;
            DataRowView drv = this.m_dvM.AddNew();
            drv.BeginEdit(); drv[this.m_strPKM] = 0; drv.EndEdit();
            this.m_dvM.AllowNew = false;

            this.dgM.CurrentRowIndex = (this.m_dvM.Count - 1);
            this.m_dvM.AllowEdit = true;
            this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();

            UpdCtl2(new string[] { "pnltabPage101" });

            this.btnFRec.Enabled = this.btnPRec.Enabled = this.btnNRec.Enabled = this.btnLRec.Enabled = false;
            this.dgM.Enabled = false;
            this.btnAdd.Enabled = this.btnEdit.Enabled = this.btnDel.Enabled = this.btnCopy.Enabled = this.btnAudit.Enabled = this.btnUnAudit.Enabled = this.btnPrint.Enabled = /*this.btnProcess.Enabled =*/ false;
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

            DTableColumn();
            #endregion
        }

        protected virtual void btnEdit_Click(object sender, System.EventArgs e)
        {
            #region 编辑业务数据
            this.m_dvM.Table.AcceptChanges();
            this.m_dvD.Table.AcceptChanges();

            this.m_dvM.AllowEdit = true;
            this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();

            UpdCtl2(new string[] { "pnltabPage101" });

            this.btnFRec.Enabled = this.btnPRec.Enabled = this.btnNRec.Enabled = this.btnLRec.Enabled = false;
            this.dgM.Enabled = false;
            this.btnAdd.Enabled = this.btnEdit.Enabled = this.btnDel.Enabled = this.btnCopy.Enabled = this.btnAudit.Enabled = this.btnUnAudit.Enabled = this.btnPrint.Enabled = /*this.btnProcess.Enabled =*/ false;
            this.btnSave.Enabled = this.btnCancel.Enabled = true;

            this.btnAddDLine.Enabled = this.m_dvD.AllowEdit = true;
            this.btnDelDLine.Enabled = this.dgD.CurrentRowIndex > -1;
            this.dgD.ReadOnly = false;

            this.m_bOpState = BusiOpState.EditBusiData;

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

                UpdMDBusiData();
            }
            #endregion
        }

        protected virtual void btnSave_Click(object sender, System.EventArgs e)
        {
            #region 保存业务数据
            UpdMDBusiData();
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
                MTableUpd();
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

            UpdMDBusiData();
            #endregion
        }

        protected virtual void btnAudit_Click(object sender, System.EventArgs e)
        {
            #region 审核业务数据
            this.m_bOpState = BusiOpState.AuditBusiData;

            if (this.m_dvM.Count > 0) this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

            UpdMDBusiData();
            #endregion
        }

        protected virtual void btnUnAudit_Click(object sender, System.EventArgs e)
        {
            #region 弃审业务数据
            this.m_bOpState = BusiOpState.UnAuditBusiData;

            if (this.m_dvM.Count > 0) this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

            UpdMDBusiData();
            #endregion
        }

        protected virtual void btnReg_Click(object sender, System.EventArgs e)
        {
            #region 记帐业务数据
            this.m_bOpState = BusiOpState.RegBusiData;

            if (this.m_dvM.Count > 0) this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

            UpdMDBusiData();
            #endregion
        }

        protected virtual void btnUnReg_Click(object sender, System.EventArgs e)
        {
            #region 反记帐业务数据
            this.m_bOpState = BusiOpState.UnRegBusiData;

            if (this.m_dvM.Count > 0) this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

            UpdMDBusiData();
            #endregion
        }

        #region 打印相关
        protected virtual void btnPrint_Click(object sender, System.EventArgs e)
        {
            this.cntMnuPrint.Show((sender as Button), new Point(0, (sender as Button).Height));
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
        #endregion

        #region 联查相关
        protected virtual void GetProcessContextMenu(ref ContextMenu cm)
        {

        }

        protected virtual void btnProcess_Click(object sender, EventArgs e)
        {
            ContextMenu cm = null;
            GetProcessContextMenu(ref cm);
            if (cm != null)
                cm.Show((sender as Button), new Point(0, (sender as Button).Height));
        }
        #endregion

        protected virtual void btnExport_Click(object sender, EventArgs e)
        {
        }

        protected virtual void btnQuery_Click(object sender, EventArgs e)
        {
            #region 查询业务数据
            this.m_bOpState = BusiOpState.BrowseBusiData;

            GetMDBusiData();
            #endregion
        }     

        protected virtual void btnRefresh_Click(object sender, System.EventArgs e)
        {
            #region 刷新业务数据
            this.m_bOpState = BusiOpState.None;

            GetMDBusiData();
            #endregion
        }

        protected virtual void btnExit_Click(object sender, System.EventArgs e)
        {
            #region 退出模块
            Close();
            #endregion
        }

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

                DTableUpd();
            }

            MTableDataBinding2(0);

            MTableNavigation(0);

            this.tabPage1.Focus();
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

                DTableUpd();
            }

            MTableDataBinding2(0);

            MTableNavigation(0);

            this.tabPage1.Focus();
            #endregion
        }

        protected virtual void btnNRec_Click(object sender, System.EventArgs e)
        {
            #region 下一记录按钮
            if (this.m_dvM != null && this.dgM.DataSource != null && this.dgM.CurrentRowIndex < this.m_dvM.Count - 1)
            {
                this.m_ndgDCurrentRowIndex = -1;
                this.dgM.UnSelect(this.dgM.CurrentRowIndex);
                this.dgM.CurrentRowIndex = this.dgM.CurrentRowIndex + 1;
                this.dgM.Tag = new int[] { (int)this.m_dvM[this.dgM.CurrentRowIndex][this.m_strPKM], this.dgM.CurrentRowIndex };
                this.dgM.Select(this.dgM.CurrentRowIndex);

                DTableUpd();
            }

            MTableDataBinding2(0);

            MTableNavigation(0);

            this.tabPage1.Focus();
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

                DTableUpd();
            }

            MTableDataBinding2(0);

            MTableNavigation(0);

            this.tabPage1.Focus();
            #endregion
        }

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
                if (this.m_dvD != null && this.dgD.CurrentRowIndex > -1)
                {
                    bool bExist = false;
                    DataRow dr = this.m_dvD[0].Row;
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
                        if (!this.m_dvD.AllowEdit)
                            this.m_dvD.AllowEdit = true;

                        for (int i = 0; i < this.m_dvD.Count; i++)
                        {
                            ndx++; if (ndx % 100 == 0) { ndx = 0; Application.DoEvents(); }
                            this.m_dvD[i].Row.BeginEdit();
                            this.m_dvD[i]["IsSelected"] = nFlag;
                            this.m_dvD[i].Row.EndEdit();
                        }
                        this.m_dvD.AllowEdit = false;
                    }
                }
            }
            catch { }

            this.dgD.Focus();

            #endregion
        }

        protected virtual void lblFootSum_Paint(object sender, PaintEventArgs e)
        {
            #region 合计列计算
            try
            {
                if (this.m_strArySumFields == null || this.m_strArySumFields.Length == 0) return;
                if (this.dgD.TableStyles.Count == 0) return;

                Graphics g = e.Graphics;
                StringFormat strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Far;

                int nColCount = this.dgD.TableStyles[0].GridColumnStyles.Count;
                int x = this.dgD.TableStyles[0].RowHeaderWidth;
                for (int i = 0; i < nColCount; i++)
                {
                    int nColWidth = this.dgD.TableStyles[0].GridColumnStyles[i].Width;
                    if (nColWidth <= 0) continue;

                    x += nColWidth;

                    for (int j = 0; j < this.m_strArySumFields.Length; j++)
                    {
                        string[] strTemps = this.m_strArySumFields[j].Split('|');
                        string strFieldName = strTemps[0].Trim();
                        string strFieldFormat = strTemps[1].Trim();

                        if (i == Utility.DataGridColumnNumber(this.dgD, strFieldName))
                        {
                            //求和
                            decimal decSumValue = 0;
                            if (this.m_dvD != null)
                            {
                                //decSumValue = decimal.Parse(m_dvD.Table.Compute("sum(" + strFieldName + ")", "").ToString());
                                for (int k = 0; k < this.m_dvD.Count; k++)
                                {
                                    DataRow dr = this.m_dvD[k].Row;
                                    if (dr[strFieldName].ToString() != "")
                                        decSumValue += Convert.ToDecimal(dr[strFieldName]);
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
            }
            catch { }
            #endregion
        }

        protected virtual void hsdgD_ValueChanged(object sender, EventArgs e)
        {
            this.lblSumFoot.Invalidate();
        }

        protected virtual void vsdgD_ValueChanged(object sender, EventArgs e)
        {
            this.lblSumFoot.Invalidate();
        }

        #region 控件设置、控件刷新

        /// <summary>
        /// 清除数据绑定,设置TextBox等控件为只读状态
        /// </summary>
        /// <param name="strAryCCtlNames">控件所属Panel</param>
        protected virtual void UpdCtl1(string[] strAryCCtlNames)
        {
            #region 表头设置为只读状态,TextBox,ComboBox清除数据绑定
            if (strAryCCtlNames != null && strAryCCtlNames.Length > 0)
            {
                for (int i = 0; i < strAryCCtlNames.Length; i++)
                {
                    foreach (Control cc in Controls.Find(strAryCCtlNames[i], true))
                    {
                        foreach (Control c in cc.Controls)
                        {
                            if (c is TextBox)
                            {
                                (c as TextBox).DataBindings.Clear();
                                (c as TextBox).Clear();
                                (c as TextBox).ReadOnly = true;
                                c.BackColor = SystemColors.ControlLightLight;
                            }
                            else if (c is ComboBox && c.Name.Substring(0, 5) == "cbox_")
                            {
                                (c as ComboBox).DataBindings.Clear();
                                (c as ComboBox).Enabled = false;
                            }
                            else if (c is Label && c.Name.Length >= 5 && c.Name.Substring(0, 5).ToLower() == "lblrs")
                                c.Visible = false;
                            else if (c is Button && c.Name.Length >= 4 && c.Name.Substring(0, 4).ToLower() == "btns")
                                c.Visible = false;
                            else if (c is Button && c.Name.Length >= 4 && c.Name.Substring(0, 4).ToLower() == "btnc")
                                c.Visible = false;
                        }
                    }
                }
            } 
            #endregion
        }

        /// <summary>
        /// 设置TextBox等控件为可编辑状态
        /// </summary>
        /// <param name="strAryCCtlNames">控件所属Panel</param>
        protected virtual void UpdCtl2(string[] strAryCCtlNames)
        {
            #region 表头设置为可编辑状态
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
                            else if (c is TextBox && c.Name.Length >= 4 && c.Name.Substring(0, 4).ToLower() == "txts")
                            {
                                c.BackColor = Color.LightGray;
                            }
                            else if (c is TextBox && c.Name.Length >= 4 && c.Name.Substring(0, 4).ToLower() == "txtw")
                            {
                                (c as TextBox).ReadOnly = false; c.BackColor = SystemColors.ControlLightLight;
                            }
                            else if (c is TextBox && c.Name.Length >= 5 && c.Name.Substring(0, 5).ToLower() == "txtsw")
                            {
                                (c as TextBox).ReadOnly = false; c.BackColor = SystemColors.Info;
                            }
                            else if (c is ComboBox && c.Name.Substring(0, 5).ToLower() == "cbox_")
                            {
                                (c as ComboBox).Enabled = true;
                            }
                            else if (c is Label && c.Name.Length >= 5 && c.Name.Substring(0, 5).ToLower() == "lblrs")
                                c.Visible = true;
                            else if (c is Button && c.Name.Length >= 4 && c.Name.Substring(0, 4).ToLower() == "btns")
                                c.Visible = true;
                            else if (c is Button && c.Name.Length >= 4 && c.Name.Substring(0, 4).ToLower() == "brnc")
                                c.Visible = true;
                        }
                    }
                }
            } 
            #endregion
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

                    MTableKeyPressClsData(textBox, strs[1]);
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
            foreach (Control c in this.pnltabPage101.Controls)
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

        protected virtual void dgDColTxtBtn_CellButtonClicked(object sender, DataGridCellButtonClickEventArgs e)
        {
            DTableRefData((sender as DataGridTextButtonColumn).MappingName);
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

        protected virtual void MTableKeyPressClsData(TextBox textBox, string strKeyValue)
        {
        }

        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        protected virtual void GetModuleBusiParams()
        {
            #region 获取模块信息
            BusinessObject bo = new BusinessObject();
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
            #endregion
        }
    }
}