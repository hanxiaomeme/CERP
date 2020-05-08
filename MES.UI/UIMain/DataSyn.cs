using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SUPortal
{
    public partial class DataSyn : Form
    {
        protected int m_nModuleBusiDBId = 0;

        protected BusinessObject m_bmdObj = null;

        protected string[] busiData = null;

        protected string[] BusiMsg = new string[] { "1", "" };

        protected DataSet ds = null;

        protected string flag = "";

        public DataSyn()
        {
            InitializeComponent();
        }

        private void DataSyn_Load(object sender, EventArgs e)
        {
            CheckListInit();
        }

        private void CheckListInit()
        {
            this.ModuleList.Items.Add("编码方案");
            
            this.ModuleList.Items.Add("数据精度");
            
            this.ModuleList.Items.Add("部门档案");
            
            this.ModuleList.Items.Add("职员档案");
            
            this.ModuleList.Items.Add("客户分类");
            
            this.ModuleList.Items.Add("客户档案");
            
            this.ModuleList.Items.Add("供应商分类");
            
            this.ModuleList.Items.Add("供应商档案");
            
            this.ModuleList.Items.Add("地区分类");
            
            this.ModuleList.Items.Add("存货分类");
            
            this.ModuleList.Items.Add("存货档案");
            
            this.ModuleList.Items.Add("仓库档案");
            
            this.ModuleList.Items.Add("收发类别");
            

            this.ModuleList.Items.Add("管抷采购入库");
            
            this.ModuleList.Items.Add("材料采购入库");
            
            this.ModuleList.Items.Add("产成品入库");
            
            this.ModuleList.Items.Add("其他入库");
            
            this.ModuleList.Items.Add("在制品入库");
            

            this.ModuleList.Items.Add("管抷出库");
            
            this.ModuleList.Items.Add("材料出库");
            
            this.ModuleList.Items.Add("销售出库");
            
            this.ModuleList.Items.Add("其他出库");
            
            this.ModuleList.Items.Add("在制品出库");
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.ModuleList.Items.Count; i++)
            {
                this.ModuleList.SetItemChecked(i, true);
            }

        }

        private void btnSelectNone_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < this.ModuleList.Items.Count; i++)
            {
                this.ModuleList.SetItemChecked(i, false);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int checkedNum = this.ModuleList.CheckedItems.Count;
            if (checkedNum == 0)
            {
                MessageBox.Show("请至少勾选一项");
            }
            else
            {
                if (MsgBox.ShowYesNoMsg2("确定要同步数据吗？") == DialogResult.Yes)
                {
                    try
                    {

                        for (int i = 0; i < checkedNum; i++)
                        {
                            string tempStr = this.ModuleList.CheckedItems[i].ToString();
                            this.flag = tempStr;
                            switch (tempStr)
                            {
                                case "编码方案":
                                    this.busiData = new string[] { "select * from GradeConf" };
                                    this.UpdateData();
                                    break;
                                case "数据精度":
                                    break;
                                case "部门档案":
                                    break;
                                case "职员档案":
                                    break;
                                case "客户分类":
                                    break;
                                case "客户档案":
                                    break;
                                case "供应商分类":
                                    break;
                                case "供应商档案":
                                    break;
                                case "地区分类":
                                    break;
                                case "存货分类":
                                    break;
                                case "存货档案":
                                    break;
                                case "仓库档案":
                                    break;
                                case "收发类别":
                                    break;
                                case "管抷采购入库":
                                    break;
                                case "材料采购入库":
                                    break;
                                case "产成品入库":
                                    break;
                                case "其他入库":
                                    break;
                                case "在制品入库":
                                    break;
                                case "管抷出库":
                                    break;
                                case "材料出库":
                                    break;
                                case "销售出库":
                                    break;
                                case "其他出库":
                                    break;
                                case "在制品出库":
                                    break;
                            }
                        }
                        if (this.BusiMsg[0] != "0")
                        {
                            MessageBox.Show(this.BusiMsg[1]);
                        }
                    }
                    catch (Exception e1)
                    {
                        MsgBox.ShowErrMsg2(e1.ToString());
                    }
                    


                }
            }
        }

        private void UpdateData()
        {
            try
            {
                DataSet ds = new DataSet();
                this.m_bmdObj = new BusinessObject(this.m_nModuleBusiDBId);
                this.m_bmdObj.BusiDataSQL = this.busiData;
                this.m_bmdObj.GetBusiData();

                this.BusiMsg = this.m_bmdObj.BusiMsg;

                this.ds = this.m_bmdObj.BusiData;

                if (this.BusiMsg[0] == "0")
                {
                    MsgBox.ShowErrMsg2(this.BusiMsg[1]);
                }
                else if (this.BusiMsg[0] == "1" && this.ds.Tables[0].Rows.Count > 0)
                {
                    this.m_bmdObj.BusiDataSQL[0] = this.flag;
                    this.m_bmdObj.BusiDBId = 3;

                    this.m_bmdObj.SynchronousData();

                    this.BusiMsg = this.m_bmdObj.BusiMsg;

                    if (this.BusiMsg[0] == "0")
                    {
                        MsgBox.ShowErrMsg2(this.BusiMsg[1]);
                    }
                }
            }
            catch (Exception e)
            {
                MsgBox.ShowErrMsg2(e.ToString());
                return;
            }
            
        }
    }
}
