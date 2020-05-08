using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NDF
{
    public partial class FmIUInv : NDF.FmBIU
    {
        public FmIUInv()
        {
            InitializeComponent();

            BaseHelper.TextBox_AddDateChangeEvent(this.txtSSDate, this.txtSEDate);

            this.m_strModuleName = "Inventory";
        }

        private string[] InvClassInfo = null;
        public void setInvClass(string[] NodeTag)
        {
            InvClassInfo = NodeTag;
        }


        protected override void FmB_Load(object sender, EventArgs e)
        {
            base.FmB_Load(sender, e);
        }

        private bool m_bMUGFlag = false;

        protected override void UIUpd()
        {
            #region �������

            UpdCtl1(new string[] { "tabPage3", "tabPage4", "tabPage5", "tabPage6" });

            base.UIUpd();

            #endregion
        }

        protected override void UIDataBinding(int nFlag)
        {
            #region �ֶΰ�
            //this.txtSAtt1.DataBindings.Add("Text", this.m_dvM, "AttCName1");
            //this.txtSAtt2.DataBindings.Add("Text", this.m_dvM, "AttCName2");


            this.txtWInvCode.DataBindings.Add("Text", this.m_dvM, "InvCode");
            this.txtWInvName.DataBindings.Add("Text", this.m_dvM, "InvName");
            this.txtSInvCCode.DataBindings.Add("Text", this.m_dvM, "InvCCode");
            this.txtSInvCName.DataBindings.Add("Text", this.m_dvM, "InvCName");
            this.txtWInvSpec.DataBindings.Add("Text", this.m_dvM, "InvSpec");
            this.txtSInvMU.DataBindings.Add("Text", this.m_dvM, "MUName");
            this.txtSInvMUG.DataBindings.Add("Text", this.m_dvM, "MUGName");
            //this.txtRInvMUGType.DataBindings.Add("Text", this.m_dvM, "MUGTypeDesc");
            //this.txtSInvASSMU.DataBindings.Add("Text", this.m_dvM, "ASSMUName");
            //this.txtSInvPUMU.DataBindings.Add("Text", this.m_dvM, "PUMUName");
            //this.txtSInvSAMU.DataBindings.Add("Text", this.m_dvM, "SAMUName");
            //this.txtSInvSTMU.DataBindings.Add("Text", this.m_dvM, "STMUName");
            this.txtRDefWhPName.DataBindings.Add("Text", this.m_dvM, "DefWhPName");
            this.txtRDefWhName.DataBindings.Add("Text", this.m_dvM, "DefWhName");

            this.txtWPSPrice.DataBindings.Add("Text", this.m_dvM, "PSPrice");
            this.txtWMPPrice.DataBindings.Add("Text", this.m_dvM, "MPPrice");
            this.txtWRCost.DataBindings.Add("Text", this.m_dvM, "RCost");
            this.txtWNCost.DataBindings.Add("Text", this.m_dvM, "NCost");
            this.txtWLSPrice.DataBindings.Add("Text", this.m_dvM, "LSPrice");
            this.txtWRSPrice.DataBindings.Add("Text", this.m_dvM, "RSPrice");

            this.txtWPdBarCode.DataBindings.Add("Text", this.m_dvM, "PdBarCode");
            this.txtWSafeQty.DataBindings.Add("Text", this.m_dvM, "SafeQty");
            this.txtWTopQty.DataBindings.Add("Text", this.m_dvM, "TopQty");
            this.txtWLowQty.DataBindings.Add("Text", this.m_dvM, "LowQty");
            this.txtWWDays.DataBindings.Add("Text", this.m_dvM, "WDays");

            this.txtSSDate.DataBindings.Add("Text", this.m_dvM, "SDate");
            this.txtSEDate.DataBindings.Add("Text", this.m_dvM, "EDate");

            this.txtWFileCode.DataBindings.Add("Text", this.m_dvM, "FileCode");
            this.txtWPackSpec.DataBindings.Add("Text", this.m_dvM, "PackSpec");
            //this.txtSDefVen.DataBindings.Add("Text", this.m_dvM, "DefVenName");
            //this.txtSPEp.DataBindings.Add("Text", this.m_dvM, "PEpName");

            this.txtWVolume.DataBindings.Add("Text", this.m_dvM, "Volume");
            this.txtWWeight.DataBindings.Add("Text", this.m_dvM, "Weight");

            this.txtWWJ.DataBindings.Add("Text", this.m_dvM, "WJ");
            this.txtWBH.DataBindings.Add("Text", this.m_dvM, "BH");
            //this.txtWCD.DataBindings.Add("Text", this.m_dvM, "CD");
            //this.txtWXS.DataBindings.Add("Text", this.m_dvM, "XS");
            this.txtWiQty.DataBindings.Add("Text", this.m_dvM, "iQty");

            this.txtSgpInvCode.DataBindings.Add("Text", this.m_dvM, "gpInvCode");
            this.txtSgpInvName.DataBindings.Add("Text", this.m_dvM, "gpInvName");
            this.txtSgpInvSpec.DataBindings.Add("Text", this.m_dvM, "gpInvSpec");
            //this.txtWgpiQty.DataBindings.Add("Text", this.m_dvM, "gpiQty");
            //this.txtWcpNum.DataBindings.Add("Text", this.m_dvM, "cpNum");
            this.txtWCCL.DataBindings.Add("Text", this.m_dvM, "CCL");
            this.txtWX.DataBindings.Add("Text", this.m_dvM, "X");

            this.txtSInvMU2.DataBindings.Add("Text", this.m_dvM, "MUName2");
            this.txtSInvMU3.DataBindings.Add("Text", this.m_dvM, "MUName3");

            //this.chkBox_isMaterial.DataBindings.Add("Checked", this.m_dvM, "isMaterial");
            //this.chkBox_isStandard.DataBindings.Add("Checked", this.m_dvM, "isStandard");

            #endregion
        }

        protected override void UIDataBinding2(int nFlag)
        {
            #region �ؼ������
            
            if (this.dgM.CurrentRowIndex > -1)
            {
                DataRowView drv = this.m_dvM[dgM.CurrentRowIndex];

                this.chkBox_isMaterial.Checked = (bool)drv["isMaterial"];
                this.chkBox_isStandard.Checked = (bool)drv["isStandard"];
                this.chkBoxHeatNo.Checked = drv["IsHeatNo"].ToString().Trim() == "1";
                this.chkBoxBatchCode.Checked = drv["IsBatch"].ToString().Trim() == "1";
                this.chkBoxWhPosition.Checked = drv["IsWhPosition"].ToString().Trim() == "1";

                this.chkBoxSale.Checked = drv["IsSale"].ToString().Trim() == "1";
                this.chkBoxPurchase.Checked = drv["IsPurchase"].ToString().Trim() == "1";
                this.chkBoxSelf.Checked = drv["IsSelf"].ToString().Trim() == "1";
                this.chkBoxComsume.Checked = drv["IsComsume"].ToString().Trim() == "1";

                this.cbValueStyle.SelectedIndex = this.cbValueStyle.FindString(drv["ValueStyle"].ToString().Trim());
                this.cboBoxABCFlag.SelectedIndex = this.cboBoxABCFlag.FindString(drv["ABCFlag"].ToString().Trim());

                this.chkBoxBarCodeMg.Checked = drv["IsBarCodeMg"].ToString().Trim() == "1";
                this.chkBoxQualityMg.Checked = drv["IsQualityMg"].ToString().Trim() == "1";
                this.chkBoxBOMMg.Checked = drv["IsBOM"].ToString().Trim() == "1";
            }
            #endregion
        }

        protected override void btnAdd_Click(object sender, EventArgs e)
        {
            #region ����ҵ������

            UpdCtl2(new string[] { "tabPage3", "tabPage4", "tabPage5", "tabPage6" });

            base.btnAdd_Click(sender, e);

            if (!this.m_bMUGFlag)
            {
                this.m_dvM[this.dgM.CurrentRowIndex]["MUGId"] = 1;
                this.m_dvM[this.dgM.CurrentRowIndex]["MUGType"] = 1;
            }

            this.m_dvM[this.dgM.CurrentRowIndex]["IsMaterial"] = 0;
            this.m_dvM[this.dgM.CurrentRowIndex]["IsStandard"] = 0;
            this.m_dvM[this.dgM.CurrentRowIndex]["IsHeatNo"] = 0;
            this.m_dvM[this.dgM.CurrentRowIndex]["IsWhPosition"] = 0;
            this.m_dvM[this.dgM.CurrentRowIndex]["IsSale"] = 0;
            this.m_dvM[this.dgM.CurrentRowIndex]["IsPurchase"] = 0;
            this.m_dvM[this.dgM.CurrentRowIndex]["IsSelf"] = 0;
            this.m_dvM[this.dgM.CurrentRowIndex]["IsComsume"] = 0;
            this.m_dvM[this.dgM.CurrentRowIndex]["IsService"] = 0;
            this.m_dvM[this.dgM.CurrentRowIndex]["IsAccessary"] = 0;
            this.m_dvM[this.dgM.CurrentRowIndex]["SDate"] = DateTime.Now.ToShortDateString();
            this.m_dvM[this.dgM.CurrentRowIndex]["IsBarCodeMg"] = 0;
            this.m_dvM[this.dgM.CurrentRowIndex]["IsQualityMg"] = 0;
            this.m_dvM[this.dgM.CurrentRowIndex]["IsBOM"] = 0;
            this.m_dvM[this.dgM.CurrentRowIndex]["CrePsn"] = UserToKen.CurrentUserToKen.PsnName;
            this.m_dvM[this.dgM.CurrentRowIndex]["CreDate"] = DateTime.Now.ToShortDateString();

            //this.m_dvM[this.dgM.CurrentRowIndex]["XS"] = 0.02491;

            this.chkBoxSale.Enabled = this.chkBoxPurchase.Enabled = this.chkBoxSelf.Enabled = this.chkBoxComsume.Enabled = true;
            this.cboBoxABCFlag.Enabled = this.cbValueStyle.Enabled = true; this.cboBoxABCFlag.SelectedIndex = this.cbValueStyle.SelectedIndex = 0;
            this.chkBoxBarCodeMg.Enabled = this.chkBoxQualityMg.Enabled = this.chkBoxBOMMg.Enabled = this.chkBoxHeatNo.Enabled = this.chkBoxBatchCode.Enabled = true;


            if (InvClassInfo != null)
            {
                BusinessObject bo = new BusinessObject();
                string InvCCode = InvClassInfo[0];
                bo.BusiDataSQL = new string[] { "select InvCID,InvCCode,InvCName from InventoryClass where InvCCode ='" + InvCCode + "'" };
                bo.GetBusiData();
                if (bo.BusiMsg[0] == "1" && bo.BusiData.Tables[0].Rows.Count > 0)
                {
                    this.m_dvM[this.dgM.CurrentRowIndex]["InvCId"] = bo.BusiData.Tables[0].Rows[0]["InvCId"];
                    this.m_dvM[this.dgM.CurrentRowIndex]["InvCCode"] = bo.BusiData.Tables[0].Rows[0]["InvCCode"];
                    this.m_dvM[this.dgM.CurrentRowIndex]["InvCName"] = bo.BusiData.Tables[0].Rows[0]["InvCName"];
                    this.m_dvM[this.dgM.CurrentRowIndex]["InvCode"] = InvCCode.Replace(".", "");

                    string code = InvClassInfo[0].Substring(0, 2);

                    if (code == "01" || code == "02" || code == "08")
                    {
                        if (code == "01")
                        {
                            this.m_dvM[this.dgM.CurrentRowIndex]["XS"] = 0.0246615;
                            this.m_dvM[this.dgM.CurrentRowIndex]["MUId"] = 38;
                            this.m_dvM[this.dgM.CurrentRowIndex]["MUName"] = "KG";
                            this.m_dvM[this.dgM.CurrentRowIndex]["MUId2"] = 47;
                            this.m_dvM[this.dgM.CurrentRowIndex]["MUName2"] = "��";
                            this.m_dvM[this.dgM.CurrentRowIndex]["MUId3"] = 44;
                            this.m_dvM[this.dgM.CurrentRowIndex]["MUName3"] = "֧";
                        }
                        if (code == "02" || code == "08")
                        {
                            this.m_dvM[this.dgM.CurrentRowIndex]["MUId"] = 38;
                            this.m_dvM[this.dgM.CurrentRowIndex]["MUName"] = "����";
                            this.m_dvM[this.dgM.CurrentRowIndex]["MUId2"] = 44;
                            this.m_dvM[this.dgM.CurrentRowIndex]["MUName2"] = "֧";
                            this.m_dvM[this.dgM.CurrentRowIndex]["isSale"] = 1;
                            this.m_dvM[this.dgM.CurrentRowIndex]["isPurchase"] = 1;
                            this.m_dvM[this.dgM.CurrentRowIndex]["isSelf"] = 1;
                            this.m_dvM[this.dgM.CurrentRowIndex]["IsComsume"] = 1;
                            this.chkBoxSale.Checked = true;
                            this.chkBoxPurchase.Checked = true;
                            this.chkBoxSelf.Checked = true;
                            this.chkBoxComsume.Checked = true;
                        }
                        this.m_dvM[this.dgM.CurrentRowIndex]["isMaterial"] = 1;
                        this.m_dvM[this.dgM.CurrentRowIndex]["isStandard"] = 1;
                        this.m_dvM[this.dgM.CurrentRowIndex]["IsBatch"] = 1;
                        this.m_dvM[this.dgM.CurrentRowIndex]["IsHeatNo"] = 1;
                        this.chkBox_isMaterial.Checked = true;
                        this.chkBox_isStandard.Checked = true;
                        this.chkBoxBatchCode.Checked = true;
                        this.chkBoxHeatNo.Checked = true;
                    }

                    if (code == "08")   code = "02";
                    bo.BusiDataSQL = new string[] { "select whid, WhName from WareHouse where WhCode ='" + code + "'" };
                    bo.GetBusiData();
                    if (bo.BusiMsg[0] == "1" && bo.BusiData.Tables[0].Rows.Count > 0)
                    {
                        this.m_dvM[this.dgM.CurrentRowIndex]["WhId"] = bo.BusiData.Tables[0].Rows[0]["WhId"];
                        this.m_dvM[this.dgM.CurrentRowIndex]["DefWhName"] = bo.BusiData.Tables[0].Rows[0]["WhName"];
                    }

                }
            }



            this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

            this.tabCtl1.SelectedIndex = 0;

            this.txtWInvCode.Focus();

            #endregion
        }

        protected override void btnEdit_Click(object sender, EventArgs e)
        {
            #region �༭ҵ������

            UpdCtl2(new string[] { "tabPage3", "tabPage4", "tabPage5", "tabPage6" });

            base.btnEdit_Click(sender, e);

            this.m_dvM[this.dgM.CurrentRowIndex]["MdyPsn"] = UserToKen.CurrentUserToKen.PsnName;
            this.m_dvM[this.dgM.CurrentRowIndex]["MdyDate"] = DateTime.Now.ToShortDateString();
            this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

            //this.btnSInvASSMU.Visible = this.btnSInvPUMU.Visible = this.btnSInvSAMU.Visible = this.btnSInvSTMU.Visible =
            //    this.m_dvM[this.dgM.CurrentRowIndex]["MUGType"].ToString().Trim() == "2" ||
            //    this.m_dvM[this.dgM.CurrentRowIndex]["MUGType"].ToString().Trim() == "3";

            this.chkBoxSale.Enabled = this.chkBoxPurchase.Enabled = this.chkBoxSelf.Enabled = this.chkBoxComsume.Enabled = true;
            this.cboBoxABCFlag.Enabled = this.cbValueStyle.Enabled = true;
            this.chkBoxBarCodeMg.Enabled = this.chkBoxQualityMg.Enabled = this.chkBoxBOMMg.Enabled = this.chkBoxHeatNo.Enabled = this.chkBoxBatchCode.Enabled = true;


            //UICtrl.TextBox_Status1(this.txtWInvCode);
            UICtrl.TextBox_Focus1(this.txtWInvName);

            #endregion
        }

        protected override void btnSave_Click(object sender, EventArgs e)
        {
            #region ����ҵ������
            if (this.m_bOpState == BusiOpState.AddBusiData || this.m_bOpState == BusiOpState.EditBusiData)
            {
                DataRow drM = this.m_dvM[this.dgM.CurrentRowIndex].Row;

                if (drM["InvCode"].ToString().Trim() == "")
                {
                    this.tabCtlMain.SelectedIndex = 1;
                    MsgBox.ShowExcMsg2("������벻��Ϊ�գ�");
                    this.txtWInvCode.Clear(); this.txtWInvCode.Focus(); return;
                }

                if (drM["InvName"].ToString().Trim() == "")
                {
                    this.tabCtlMain.SelectedIndex = 1;
                    MsgBox.ShowExcMsg2("������Ʋ���Ϊ�գ�");
                    this.txtWInvName.Clear(); this.txtWInvName.Focus(); return;
                }

                if (drM["InvCId"].ToString().Trim() == "")
                {
                    this.tabCtlMain.SelectedIndex = 1;
                    MsgBox.ShowExcMsg2("������಻��Ϊ�գ�");
                    this.txtSInvCCode.Clear(); this.txtSInvCCode.Focus(); return;
                }

                /*
                if (drM["WhId"].ToString().Trim() == "")
                {
                    this.tabCtlMain.SelectedIndex = 1;
                    MsgBox.ShowExcMsg2("Ĭ�ϲֿⲻ��Ϊ�գ�");
                    this.txtWhName.Clear(); this.txtWhName.Focus(); return;
                }
                */

                if (drM["MUId"].ToString().Trim() == "")
                {
                    this.tabCtlMain.SelectedIndex = 1;
                    MsgBox.ShowExcMsg2("��������λ����Ϊ�գ�");
                    this.txtSInvMU.Clear(); this.txtSInvMU.Focus(); return;
                }

                if (drM["LowQty"].ToString().Trim() != "" &&
                    drM["TopQty"].ToString().Trim() != "")
                {
                    if (Convert.ToDecimal(drM["LowQty"].ToString().Trim()) >
                        Convert.ToDecimal(drM["TopQty"].ToString().Trim()))
                    {
                        this.tabCtlMain.SelectedIndex = 1;
                        this.tabCtl1.SelectedIndex = 2;
                        MsgBox.ShowExcMsg2("��Ϳ�治�ɴ�����߿�棡");
                        this.txtWLowQty.Focus(); return;
                    }
                }

                if (drM["LowQty"].ToString().Trim() != "" &&
                    drM["TopQty"].ToString().Trim() != "" &&
                    drM["SafeQty"].ToString().Trim() != "")
                {
                    if (Convert.ToDecimal(drM["SafeQty"].ToString().Trim()) >
                        Convert.ToDecimal(drM["TopQty"].ToString().Trim()) ||
                        Convert.ToDecimal(drM["SafeQty"].ToString().Trim()) < Convert.ToDecimal(drM["LowQty"].ToString().Trim()))
                    {
                        this.tabCtlMain.SelectedIndex = 1;
                        this.tabCtl1.SelectedIndex = 2;
                        MsgBox.ShowExcMsg2("��ȫ��治�ɴ�����߿���С����Ϳ�棡");
                        this.txtWSafeQty.Focus(); return;
                    }
                }

                this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
                if (this.cboBoxABCFlag.SelectedIndex == 0)
                    this.m_dvM[this.dgM.CurrentRowIndex]["ABCFlag"] = DBNull.Value;
                else if (this.cboBoxABCFlag.SelectedIndex == 1)
                    this.m_dvM[this.dgM.CurrentRowIndex]["ABCFlag"] = this.cboBoxABCFlag.Text;
                else if (this.cboBoxABCFlag.SelectedIndex == 2)
                    this.m_dvM[this.dgM.CurrentRowIndex]["ABCFlag"] = this.cboBoxABCFlag.Text;
                else if (this.cboBoxABCFlag.SelectedIndex == 3)
                    this.m_dvM[this.dgM.CurrentRowIndex]["ABCFlag"] = this.cboBoxABCFlag.Text;

                if (this.cbValueStyle.SelectedIndex == 0)
                    this.m_dvM[this.dgM.CurrentRowIndex]["ValueStyle"] = DBNull.Value;
                else
                    this.m_dvM[this.dgM.CurrentRowIndex]["ValueStyle"] = this.cbValueStyle.Text;
                if (this.txtWgpiQty.Text.ToString() != "")
                    this.m_dvM[this.dgM.CurrentRowIndex]["gpiQty"] = this.txtWgpiQty.Text.ToString() == "";

                this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

                BusinessObject bo = new BusinessObject();
                string s = null;

                this.txtWiQty_MouseDown(null, null);

                #region ����������Ƿ�����¼�����
                s = "";
                s += "select count(*) as RSCount from InventoryClass where ";
                s += "InvCCode like '" + drM["InvCCode"].ToString().Trim() + "%'";
                s += " and ";
                s += "InvCId!=" + drM["InvCId"].ToString();

                bo.BusiDataSQL = new string[] { s };
                bo.GetBusiData();
                if (bo.BusiMsg[0] == "0")
                {
                    MsgBox.ShowErrMsg2(bo.BusiMsg[1]); return;
                }
                else if (bo.BusiMsg[0] == "1")
                {
                    if ((int)bo.BusiData.Tables[0].Rows[0][0] > 0)
                    {
                        this.tabCtlMain.SelectedIndex = 1;
                        MsgBox.ShowExcMsg2("�����������¼����࣬\n����ѡ�ø÷��࣡");
                        this.txtSInvCCode.Focus();
                        return;
                    }
                }
                #endregion

                #region ����������Ƿ����
                s = "";
                s += "select count(*) as RSCount from Inventory where ";
                s += "InvCode='" + drM["InvCode"].ToString().Trim() + "'";
                s += " and ";
                s += "InvId!=" + drM["InvId"].ToString();

                bo.BusiDataSQL = new string[] { s };
                bo.GetBusiData();
                if (bo.BusiMsg[0] == "0")
                {
                    MsgBox.ShowErrMsg2(bo.BusiMsg[1]); return;
                }
                else if (bo.BusiMsg[0] == "1")
                {
                    if ((int)bo.BusiData.Tables[0].Rows[0][0] > 0)
                    {
                        this.tabCtlMain.SelectedIndex = 1;
                        MsgBox.ShowExcMsg2("��������Ѿ����ڣ�");
                        this.txtWInvCode.Focus();
                        return;
                    }
                }
                #endregion

                #region ����Ƿ������ͬ���ƹ�񵵰�
                if (m_bOpState == BusiOpState.AddBusiData)
                {
                    s = "select 1 from Inventory where InvName = '" + m_dvM[dgM.CurrentRowIndex]["InvName"] + "' and "
                      + "InvSpec = '" + m_dvM[dgM.CurrentRowIndex]["InvSpec"] + "'";
                    bo.BusiDataSQL = new string[] { s };
                    bo.GetBusiData();
                    if (bo.BusiMsg[0] == "1" && bo.BusiData.Tables[0].Rows.Count >= 1)
                    {
                        this.tabCtlMain.SelectedIndex = 1;
                        MsgBox.ShowExcMsg2("�Ѿ�������ͬ���ơ����ĵ�����");
                        this.txtWInvCode.Focus();
                        return;
                    }
                }
                #endregion

                #region ��������λ���Ƿ���Ըı�
                if (this.m_bOpState == BusiOpState.EditBusiData)
                {
                    if (drM["MUGId"].ToString().Trim() != "")
                    {
                        int nCurMUGId = (int)drM["MUGId"];

                        s = "";
                        s += "select MUGId from Inventory where ";
                        s += "InvId=" + drM["InvId"].ToString();
                        s += ";";
                        s += "select ";//���۶���
                        s += "count(*) as RSCount";
                        s += " from ";
                        s += "SaleOrderDetail";
                        s += " where ";
                        s += "InvId=" + drM["InvId"].ToString();
                        s += ";";
                        s += "select ";//��������
                        s += "count(*) as RSCount";
                        s += " from ";
                        s += "PPODetail";
                        s += " where ";
                        s += "InvId=" + drM["InvId"].ToString();
                        s += ";";
                        s += "select ";//�ɹ��ƻ���
                        s += "count(*) as RSCount";
                        s += " from ";
                        s += "PuPDetail";
                        s += " where ";
                        s += "InvId=" + drM["InvId"].ToString();
                        s += ";";
                        s += "select ";//�ɹ�����
                        s += "count(*) as RSCount";
                        s += " from ";
                        s += "PuODetail";
                        s += " where ";
                        s += "InvId=" + drM["InvId"].ToString();
                        s += ";";
                        s += "select ";//����ⵥ
                        s += "count(*) as RSCount";
                        s += " from ";
                        s += "RDDetail";
                        s += " where ";
                        s += "InvId=" + drM["InvId"].ToString();
                        s += ";";
                        s += "select ";//����֪ͨ��
                        s += "count(*) as RSCount";
                        s += " from ";
                        s += "PrTaskMain";
                        s += " where ";
                        s += "PInvId=" + drM["InvId"].ToString();
                        s += ";";
                        s += "select ";//BOM
                        s += "count(*) as RSCount";
                        s += " from ";
                        s += "PPS";
                        s += " where ";
                        s += "InvId=" + drM["InvId"].ToString();
                        s += ";";
                        s += "select ";//����ִ���
                        s += "count(*) as RSCount";
                        s += " from ";
                        s += "CurrentStock";
                        s += " where ";
                        s += "InvId=" + drM["InvId"].ToString();

                        bo.BusiDataSQL = new string[] { s };
                        bo.GetBusiData();
                        if (bo.BusiMsg[0] == "0")
                        {
                            MsgBox.ShowErrMsg2(bo.BusiMsg[1]); return;
                        }
                        else if (bo.BusiMsg[0] == "1")
                        {
                            if (bo.BusiData.Tables[0].Rows[0]["MUGId"].ToString().Trim() != "")
                            {
                                int nOldMUGId = (int)bo.BusiData.Tables[0].Rows[0]["MUGId"];
                                if (nOldMUGId != nCurMUGId)
                                {
                                    int nC1 = (int)bo.BusiData.Tables[1].Rows[0][0];//���۶���
                                    int nC2 = (int)bo.BusiData.Tables[2].Rows[0][0];//��������
                                    int nC4 = (int)bo.BusiData.Tables[3].Rows[0][0];//�ɹ��ƻ���
                                    int nC5 = (int)bo.BusiData.Tables[4].Rows[0][0];//�ɹ�����
                                    int nC6 = (int)bo.BusiData.Tables[5].Rows[0][0];//����ⵥ
                                    int nC7 = (int)bo.BusiData.Tables[6].Rows[0][0];//����֪ͨ��
                                    int nC8 = (int)bo.BusiData.Tables[7].Rows[0][0];//BOM
                                    int nC9 = (int)bo.BusiData.Tables[8].Rows[0][0];//����ִ���
                                    string strMsg = "";
                                    if (nC1 > 0)//���۶���
                                        strMsg += "�ô���Ѿ������۶������ã�\n";
                                    if (nC2 > 0)//��������
                                        strMsg += "�ô���Ѿ��������������ã�\n";
                                    if (nC4 > 0)//�ɹ��ƻ���
                                        strMsg += "�ô���Ѿ����ɹ��ƻ������ã�\n";
                                    if (nC5 > 0)//�ɹ�����
                                        strMsg += "�ô���Ѿ����ɹ��������ã�\n";
                                    if (nC6 > 0)//����ⵥ
                                        strMsg += "�ô���Ѿ���������ⵥ���ã�\n";
                                    if (nC7 > 0)//����֪ͨ��
                                        strMsg += "�ô���Ѿ�������֪ͨ�����ã�\n";
                                    if (nC8 > 0)//BOM
                                        strMsg += "�ô���Ѿ��������嵥���ã�\n";
                                    if (nC9 > 0)//����ִ���
                                        strMsg += "�ô���Ѿ�������ִ������ܱ����ã�\n";
                                    if (strMsg != "")
                                    {
                                        strMsg += "���ɸ��ļ�����λ�飡";
                                        MsgBox.ShowExcMsg2(strMsg); return;
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion

                #region �����������λ�Ƿ���Ըı�
                if (this.m_bOpState == BusiOpState.EditBusiData)
                {
                    int nCurMUId = (int)drM["MUId"];

                    s = "";
                    #region ԭ��������λ
                    s += "select ";
                    s += "MUId";
                    s += " from ";
                    s += "Inventory";
                    s += " where ";
                    s += "InvId=" + drM["InvId"].ToString();
                    #endregion
                    s += ";";
                    #region �����۶�������
                    s += "select ";//���۶���
                    s += "count(*) as RSCount";
                    s += " from ";
                    s += "SaleOrderDetail";
                    s += " where ";
                    s += "InvId=" + drM["InvId"].ToString();
                    #endregion
                    s += ";";
                    #region ��������������
                    s += "select ";//��������
                    s += "count(*) as RSCount";
                    s += " from ";
                    s += "PPODetail";
                    s += " where ";
                    s += "InvId=" + drM["InvId"].ToString();
                    #endregion
                    s += ";";
                    #region �ڲɹ��빺������
                    s += "select ";//�ɹ��빺��
                    s += "count(*) as RSCount";
                    s += " from ";
                    s += "PuPDetail";
                    s += " where ";
                    s += "InvId=" + drM["InvId"].ToString();
                    #endregion
                    s += ";";
                    #region �ڲɹ���������
                    s += "select ";//�ɹ�����
                    s += "count(*) as RSCount";
                    s += " from ";
                    s += "PuODetail";
                    s += " where ";
                    s += "InvId=" + drM["InvId"].ToString();
                    #endregion
                    s += ";";
                    #region ������ⵥ����
                    s += "select ";//����ⵥ
                    s += "count(*) as RSCount";
                    s += " from ";
                    s += "RDDetail";
                    s += " where ";
                    s += "InvId=" + drM["InvId"].ToString();
                    #endregion
                    s += ";";
                    #region ������֪ͨ������
                    s += "select ";//����֪ͨ��
                    s += "count(*) as RSCount";
                    s += " from ";
                    s += "PrTaskMain";
                    s += " where ";
                    s += "PInvId=" + drM["InvId"].ToString();
                    #endregion
                    s += ";";
                    #region ��BOM����
                    s += "select ";//BOM
                    s += "count(*) as RSCount";
                    s += " from ";
                    s += "PPS";
                    s += " where ";
                    s += "InvId=" + drM["InvId"].ToString();
                    #endregion
                    s += ";";
                    #region �ڿ���ִ�������
                    s += "select ";//����ִ���
                    s += "count(*) as RSCount";
                    s += " from ";
                    s += "CurrentStock";
                    s += " where ";
                    s += " (Qty!=0 or iNum!=0) and InvId=" + drM["InvId"].ToString();
                    #endregion

                    bo.BusiDataSQL = new string[] { s };
                    bo.GetBusiData();
                    if (bo.BusiMsg[0] == "0")
                    {
                        MsgBox.ShowErrMsg2(bo.BusiMsg[1]); return;
                    }
                    else if (bo.BusiMsg[0] == "1")
                    {
                        if (bo.BusiData.Tables[0].Rows[0]["MUId"].ToString().Trim() != "")
                        {
                            int nOldMUId = (int)bo.BusiData.Tables[0].Rows[0]["MUId"];
                            if (nOldMUId != nCurMUId)
                            {
                                int nC1 = (int)bo.BusiData.Tables[1].Rows[0][0];//���۶���
                                int nC2 = (int)bo.BusiData.Tables[2].Rows[0][0];//��������
                                int nC4 = (int)bo.BusiData.Tables[3].Rows[0][0];//�ɹ��ƻ���
                                int nC5 = (int)bo.BusiData.Tables[4].Rows[0][0];//�ɹ�����
                                int nC6 = (int)bo.BusiData.Tables[5].Rows[0][0];//����ⵥ
                                int nC7 = (int)bo.BusiData.Tables[6].Rows[0][0];//����֪ͨ��
                                int nC8 = (int)bo.BusiData.Tables[7].Rows[0][0];//BOM
                                int nC9 = (int)bo.BusiData.Tables[8].Rows[0][0];//����ִ���
                                string strMsg = "";
                                if (nC1 > 0)//���۶���
                                    strMsg += "�ô���Ѿ������۶������ã�\n";
                                if (nC2 > 0)//��������
                                    strMsg += "�ô���Ѿ��������������ã�\n";
                                if (nC4 > 0)//�ɹ��ƻ���
                                    strMsg += "�ô���Ѿ����ɹ��ƻ������ã�\n";
                                if (nC5 > 0)//�ɹ�����
                                    strMsg += "�ô���Ѿ����ɹ��������ã�\n";
                                if (nC6 > 0)//����ⵥ
                                    strMsg += "�ô���Ѿ���������ⵥ���ã�\n";
                                if (nC7 > 0)//����֪ͨ��
                                    strMsg += "�ô���Ѿ�������֪ͨ�����ã�\n";
                                if (nC8 > 0)//BOM
                                    strMsg += "�ô���Ѿ��������嵥���ã�\n";
                                if (nC9 > 0)//����ִ���
                                    strMsg += "�ô���Ѿ�������ִ������ܱ����ã�\n";
                                if (strMsg != "")
                                {
                                    strMsg += "���ɸ�����������λ��";
                                    MsgBox.ShowExcMsg2(strMsg); return;
                                }
                            }
                        }
                    }
                }
                #endregion

                #region ����Ƿ���Ըı�BOM��������
                if (this.m_bOpState == BusiOpState.EditBusiData)
                {
                    int nCurBOMFlag = 0;

                    if (drM["IsBOM"] != DBNull.Value)
                    {
                        nCurBOMFlag = (int)drM["IsBOM"];
                    }

                    s = "";
                    s += "select IsBOM from Inventory where InvId=" + drM["InvId"].ToString();
                    s += ";";
                    s += "select count(*) from PPSVer where PInvId=" + drM["InvId"].ToString();

                    bo.BusiDataSQL = new string[] { s };
                    bo.GetBusiData();
                    if (bo.BusiMsg[0] == "0")
                    {
                        MsgBox.ShowErrMsg2(bo.BusiMsg[1]); return;
                    }
                    else if (bo.BusiMsg[0] == "1")
                    {
                        int nOldBOMFlag = (int)bo.BusiData.Tables[0].Rows[0][0];
                        if (nOldBOMFlag != nCurBOMFlag && (int)bo.BusiData.Tables[1].Rows[0][0] > 0)
                        {
                            MsgBox.ShowExcMsg2("�ô���Ѿ����������嵥���ݹ������ɸ����Ƿ�BOM�������ԣ�"); return;
                        }
                    }
                }
                #endregion
            }

            if (this.m_bOpState == BusiOpState.EditBusiData)
            {
                BusinessObject bo = new BusinessObject();
                string sql = "select * from PuoDetail where InvId=" + this.m_dvM[this.dgM.CurrentRowIndex].Row["InvId"].ToString()
                   + ";select * from SaleOrderDetail where InvId=" + this.m_dvM[this.dgM.CurrentRowIndex].Row["InvId"].ToString()
                   + ";select * from RDDetail where InvId=" + this.m_dvM[this.dgM.CurrentRowIndex].Row["InvId"].ToString();
                bo.BusiDataSQL = new string[] { sql };
                bo.GetBusiData();
                if (bo.BusiMsg[0] == "1" && (bo.BusiData.Tables[0].Rows.Count > 0 || bo.BusiData.Tables[1].Rows.Count > 0 || bo.BusiData.Tables[2].Rows.Count > 0))
                {
                    if (MsgBox.ShowYesNoMsg2("�ô�������Ѿ������ã�ȷ���޸���") == DialogResult.No)
                        return;
                }
            }

            if (this.m_bOpState == BusiOpState.AddBusiData || this.m_bOpState == BusiOpState.EditBusiData)
            {
                string InvCode = this.txtWInvCode.Text.ToString();
                int index = InvCode.LastIndexOf(".");
                if (index > -1)
                {
                    string InvCCode = InvCode.Substring(0, index);
                    string s = "select * from InventoryClass where InvCCode='" + InvCCode + "'";
                    BusinessObject bo = new BusinessObject();
                    bo.BusiDataSQL = new string[] { s };
                    bo.GetBusiData();
                    if (bo.BusiMsg[0] == "1" && bo.BusiData.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = bo.BusiData.Tables[0].Rows[0];
                        if (this.m_dvM[this.dgM.CurrentRowIndex]["InvCId"].ToString() != dr["InvCId"].ToString())
                        {
                            if (MsgBox.ShowYesNoMsg2("��������������಻һ�£�ȷ���޸Ľ��Ա���Ϊ׼��������") == DialogResult.Yes)
                            {
                                this.m_dvM[this.dgM.CurrentRowIndex]["InvCId"] = dr["InvCId"].ToString();
                                this.m_dvM[this.dgM.CurrentRowIndex]["InvCCode"] = dr["InvCCode"].ToString();
                                this.m_dvM[this.dgM.CurrentRowIndex]["InvCName"] = dr["InvCName"].ToString();
                            }
                        }
                    }
                    else
                    {
                        MsgBox.ShowErrMsg2("��������������಻���ڣ���ȷ�ϣ�");
                        this.txtWInvCode.Focus();
                        return;
                    }
                }
            }



            base.btnSave_Click(sender, e);
            #endregion
        }

        private void btnSInvClass_Click(object sender, EventArgs e)
        {
            #region ���մ������

            FmRInvClass f = new FmRInvClass();
            UICtrl.SetShowStyle(f, 2);
            if (DialogResult.OK == f.ShowDialog())
            {
                DataRow dr = (DataRow)f.SelectedInfo[0];
                this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
                this.m_dvM[this.dgM.CurrentRowIndex]["InvCId"] = dr["InvCId"];
                this.m_dvM[this.dgM.CurrentRowIndex]["InvCCode"] = dr["InvCCode"];
                this.m_dvM[this.dgM.CurrentRowIndex]["InvCName"] = dr["InvCName"];
                this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
            }
            UICtrl.TextBox_Focus1(this.txtSInvCCode);

            #endregion
        }

        private void btnSInvMU_Click(object sender, System.EventArgs e)
        {
            #region ������������λ
            //
            if (this.m_bMUGFlag && this.m_dvM[this.dgM.CurrentRowIndex]["MUGId"].ToString().Trim() == "")
            {
                MsgBox.ShowInfoMsg2("����ѡ�������λ�飡");
                this.txtSInvMUG.Clear(); this.txtSInvMUG.Focus(); return;
            }

            if (this.m_bMUGFlag)
            {
                FmRMU2 f = new FmRMU2();
                string s = "1=1";
                s += " and MFlag=1";
                s += " and MUGId=" + this.m_dvM[this.dgM.CurrentRowIndex]["MUGId"].ToString().Trim();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    DataRow dr = (DataRow)f.SelectedInfo[0];
                    this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
                    this.m_dvM[this.dgM.CurrentRowIndex]["MUId"] = dr["MUId"];
                    this.m_dvM[this.dgM.CurrentRowIndex]["MUName"] = dr["MUName"];
                    if (this.m_dvM[this.dgM.CurrentRowIndex]["MUGType"].ToString().Trim() == "1")
                    {
                        this.m_dvM[this.dgM.CurrentRowIndex]["ASSMUId"] = dr["MUId"];
                        this.m_dvM[this.dgM.CurrentRowIndex]["ASSMUName"] = dr["MUName"];
                        this.m_dvM[this.dgM.CurrentRowIndex]["SAMUId"] = dr["MUId"];
                        this.m_dvM[this.dgM.CurrentRowIndex]["SAMUName"] = dr["MUName"];
                        this.m_dvM[this.dgM.CurrentRowIndex]["PUMUId"] = dr["MUId"];
                        this.m_dvM[this.dgM.CurrentRowIndex]["PUMUName"] = dr["MUName"];
                        this.m_dvM[this.dgM.CurrentRowIndex]["STMUId"] = dr["MUId"];
                        this.m_dvM[this.dgM.CurrentRowIndex]["STMUName"] = dr["MUName"];
                    }
                    this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
                }
            }
            else
            {
                FmRMU1 f = new FmRMU1();
                string s = "1=1";
                s += " and MFlag=1";
                s += " and MUGId=" + this.m_dvM[this.dgM.CurrentRowIndex]["MUGId"].ToString().Trim();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    DataRow dr = (DataRow)f.SelectedInfo[0];
                    this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
                    this.m_dvM[this.dgM.CurrentRowIndex]["MUId"] = dr["MUId"];
                    this.m_dvM[this.dgM.CurrentRowIndex]["MUName"] = dr["MUName"];
                    if (this.m_dvM[this.dgM.CurrentRowIndex]["MUGType"].ToString().Trim() == "1")
                    {
                        this.m_dvM[this.dgM.CurrentRowIndex]["ASSMUId"] = dr["MUId"];
                        this.m_dvM[this.dgM.CurrentRowIndex]["ASSMUName"] = dr["MUName"];
                        this.m_dvM[this.dgM.CurrentRowIndex]["SAMUId"] = dr["MUId"];
                        this.m_dvM[this.dgM.CurrentRowIndex]["SAMUName"] = dr["MUName"];
                        this.m_dvM[this.dgM.CurrentRowIndex]["PUMUId"] = dr["MUId"];
                        this.m_dvM[this.dgM.CurrentRowIndex]["PUMUName"] = dr["MUName"];
                        this.m_dvM[this.dgM.CurrentRowIndex]["STMUId"] = dr["MUId"];
                        this.m_dvM[this.dgM.CurrentRowIndex]["STMUName"] = dr["MUName"];
                    }
                    this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
                }
            }
            UICtrl.TextBox_Focus1(this.txtSInvMU);
            #endregion
        }

        private void btnSInvMUG_Click(object sender, System.EventArgs e)
        {
            #region ѡ�������λ��
            FmRMUG f = new FmRMUG();
            if (f.ShowDialog() == DialogResult.OK)
            {
                DataRow dr = (DataRow)f.SelectedInfo[0];

                if (dr["HasMU"].ToString().Trim() == "0")
                {
                    MsgBox.ShowInfoMsg2("�ü�����λ����û�м�����λ��");
                }
                else if (dr["HasMMU"].ToString().Trim() == "0")
                {
                    MsgBox.ShowInfoMsg2("�ü�����λ����û����������λ��\n����������һ������λΪ��������λ��");
                }
                else
                {
                    this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
                    this.m_dvM[this.dgM.CurrentRowIndex]["MUGId"] = dr["MUGId"];
                    this.m_dvM[this.dgM.CurrentRowIndex]["MUGName"] = dr["MUGName"];
                    this.m_dvM[this.dgM.CurrentRowIndex]["MUGType"] = dr["MUGType"];
                    this.m_dvM[this.dgM.CurrentRowIndex]["MUGTypeDesc"] = dr["MUGTypeDesc"];
                    this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        string s = "select * from MeasureUnit where MFlag=1 and MUGId=" + dr["MUGId"].ToString();
                        s += ";";
                        s += "select * from MeasureUnit where MFlag=0 and MUGId=" + dr["MUGId"].ToString();

                        BusinessObject bo = new BusinessObject();
                        bo.BusiDataSQL = new string[] { s };

                        bo.GetBusiData();
                        if (bo.BusiMsg[0] == "0")
                        {
                            MsgBox.ShowInfoMsg2(bo.BusiMsg[1]);
                        }
                        else if (bo.BusiMsg[0] == "1")
                        {
                            if (this.m_dvM[this.dgM.CurrentRowIndex]["MUGType"].ToString() == "1")
                            {
                                if (bo.BusiData.Tables[0].Rows.Count > 0)
                                {
                                    DataRow drTmp = bo.BusiData.Tables[0].Rows[0];
                                    this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
                                    this.m_dvM[this.dgM.CurrentRowIndex]["MUId"] = drTmp["MUId"];
                                    this.m_dvM[this.dgM.CurrentRowIndex]["MUName"] = drTmp["MUName"];
                                    this.m_dvM[this.dgM.CurrentRowIndex]["ASSMUId"] = drTmp["MUId"];
                                    this.m_dvM[this.dgM.CurrentRowIndex]["ASSMUName"] = drTmp["MUName"];
                                    this.m_dvM[this.dgM.CurrentRowIndex]["SAMUId"] = drTmp["MUId"];
                                    this.m_dvM[this.dgM.CurrentRowIndex]["SAMUName"] = drTmp["MUName"];
                                    this.m_dvM[this.dgM.CurrentRowIndex]["PUMUId"] = drTmp["MUId"];
                                    this.m_dvM[this.dgM.CurrentRowIndex]["PUMUName"] = drTmp["MUName"];
                                    this.m_dvM[this.dgM.CurrentRowIndex]["STMUId"] = drTmp["MUId"];
                                    this.m_dvM[this.dgM.CurrentRowIndex]["STMUName"] = drTmp["MUName"];
                                    this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
                                }
                            }
                            else if (this.m_dvM[this.dgM.CurrentRowIndex]["MUGType"].ToString() == "2" ||
                                this.m_dvM[this.dgM.CurrentRowIndex]["MUGType"].ToString() == "3")
                            {
                                if (bo.BusiData.Tables[0].Rows.Count > 0)
                                {
                                    DataRow drTmp = bo.BusiData.Tables[0].Rows[0];
                                    this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
                                    this.m_dvM[this.dgM.CurrentRowIndex]["MUId"] = drTmp["MUId"];
                                    this.m_dvM[this.dgM.CurrentRowIndex]["MUName"] = drTmp["MUName"];
                                    this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
                                }
                                if (bo.BusiData.Tables[1].Rows.Count > 0)
                                {
                                    DataRow drTmp = bo.BusiData.Tables[1].Rows[0];
                                    this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
                                    this.m_dvM[this.dgM.CurrentRowIndex]["ASSMUId"] = drTmp["MUId"];
                                    this.m_dvM[this.dgM.CurrentRowIndex]["ASSMUName"] = drTmp["MUName"];
                                    this.m_dvM[this.dgM.CurrentRowIndex]["SAMUId"] = drTmp["MUId"];
                                    this.m_dvM[this.dgM.CurrentRowIndex]["SAMUName"] = drTmp["MUName"];
                                    this.m_dvM[this.dgM.CurrentRowIndex]["PUMUId"] = drTmp["MUId"];
                                    this.m_dvM[this.dgM.CurrentRowIndex]["PUMUName"] = drTmp["MUName"];
                                    this.m_dvM[this.dgM.CurrentRowIndex]["STMUId"] = drTmp["MUId"];
                                    this.m_dvM[this.dgM.CurrentRowIndex]["STMUName"] = drTmp["MUName"];
                                    this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
                                }
                            }
                        }
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }

                    this.btnSInvASSMU.Visible = this.btnSInvPUMU.Visible = this.btnSInvSAMU.Visible = this.btnSInvSTMU.Visible =
                        this.m_dvM[this.dgM.CurrentRowIndex]["MUGType"].ToString().Trim() == "2" ||
                        this.m_dvM[this.dgM.CurrentRowIndex]["MUGType"].ToString().Trim() == "3";
                }
            }
            UICtrl.TextBox_Focus1(this.txtSInvMUG);
            #endregion
        }

        private void btnSInvSAMU_Click(object sender, System.EventArgs e)
        {
            #region �������ۼ�����λ

            if (this.m_dvM[this.dgM.CurrentRowIndex]["MUGId"].ToString().Trim() == "")
            {
                MsgBox.ShowInfoMsg2("����ѡ�������λ�飡");
                this.txtSInvMUG.Clear(); this.txtSInvMUG.Focus(); return;
            }

            FmRMU2 f = new FmRMU2();
            string s = "1=1";
            s += " and MUGId=" + this.m_dvM[this.dgM.CurrentRowIndex]["MUGId"].ToString().Trim();
            if (this.m_dvM[this.dgM.CurrentRowIndex]["MUGType"].ToString().Trim() == "3")
                s += " and MFlag=0";
            f.OuterFilterSQL = new string[] { s };
            if (f.ShowDialog() == DialogResult.OK)
            {
                DataRow dr = (DataRow)f.SelectedInfo[0];
                this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
                this.m_dvM[this.dgM.CurrentRowIndex]["SAMUId"] = dr["MUId"];
                this.m_dvM[this.dgM.CurrentRowIndex]["SAMUName"] = dr["MUName"];
                this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
            }
            UICtrl.TextBox_Focus1(this.txtSInvSAMU);

            #endregion
        }

        private void btnSInvASSMU_Click(object sender, EventArgs e)
        {
            #region �����������ü�����λ

            if (this.m_dvM[this.dgM.CurrentRowIndex]["MUGId"].ToString().Trim() == "")
            {
                MsgBox.ShowInfoMsg2("����ѡ�������λ�飡");
                this.txtSInvMUG.Clear(); this.txtSInvMUG.Focus(); return;
            }

            FmRMU2 f = new FmRMU2();
            string s = "1=1";
            s += " and MUGId=" + this.m_dvM[this.dgM.CurrentRowIndex]["MUGId"].ToString().Trim();
            if (this.m_dvM[this.dgM.CurrentRowIndex]["MUGType"].ToString().Trim() == "3")
                s += " and MFlag=0";
            f.OuterFilterSQL = new string[] { s };
            if (f.ShowDialog() == DialogResult.OK)
            {
                DataRow dr = (DataRow)f.SelectedInfo[0];
                this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
                this.m_dvM[this.dgM.CurrentRowIndex]["ASSMUId"] = dr["MUId"];
                this.m_dvM[this.dgM.CurrentRowIndex]["ASSMUName"] = dr["MUName"];
                this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
            }
            UICtrl.TextBox_Focus1(this.txtSInvASSMU);

            #endregion
        }

        private void btnSInvPUMU_Click(object sender, System.EventArgs e)
        {
            #region ���ղɹ�������λ

            if (this.m_dvM[this.dgM.CurrentRowIndex]["MUGId"].ToString().Trim() == "")
            {
                MsgBox.ShowInfoMsg2("����ѡ�������λ�飡");
                this.txtSInvMUG.Clear(); this.txtSInvMUG.Focus(); return;
            }

            FmRMU2 f = new FmRMU2();
            string s = "1=1";
            s += " and MUGId=" + this.m_dvM[this.dgM.CurrentRowIndex]["MUGId"].ToString().Trim();
            if (this.m_dvM[this.dgM.CurrentRowIndex]["MUGType"].ToString().Trim() == "3")
                s += " and MFlag=0";
            f.OuterFilterSQL = new string[] { s };
            if (f.ShowDialog() == DialogResult.OK)
            {
                DataRow dr = (DataRow)f.SelectedInfo[0];
                this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
                this.m_dvM[this.dgM.CurrentRowIndex]["PUMUId"] = dr["MUId"];
                this.m_dvM[this.dgM.CurrentRowIndex]["PUMUName"] = dr["MUName"];
                this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
            }
            UICtrl.TextBox_Focus1(this.txtSInvPUMU);

            #endregion
        }

        private void btnSInvSTMU_Click(object sender, System.EventArgs e)
        {
            #region ���տ�������λ

            if (this.m_dvM[this.dgM.CurrentRowIndex]["MUGId"].ToString().Trim() == "")
            {
                MsgBox.ShowInfoMsg2("����ѡ�������λ�飡");
                this.txtSInvMUG.Clear(); this.txtSInvMUG.Focus(); return;
            }

            FmRMU2 f = new FmRMU2();
            string s = "1=1";
            s += " and MUGId=" + this.m_dvM[this.dgM.CurrentRowIndex]["MUGId"].ToString().Trim();
            if (this.m_dvM[this.dgM.CurrentRowIndex]["MUGType"].ToString().Trim() == "3")
                s += " and MFlag=0";
            f.OuterFilterSQL = new string[] { s };
            if (f.ShowDialog() == DialogResult.OK)
            {
                DataRow dr = (DataRow)f.SelectedInfo[0];
                this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
                this.m_dvM[this.dgM.CurrentRowIndex]["STMUId"] = dr["MUId"];
                this.m_dvM[this.dgM.CurrentRowIndex]["STMUName"] = dr["MUName"];
                this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
            }
            UICtrl.TextBox_Focus1(this.txtSInvSTMU);

            #endregion
        }

        private void chkBoxSale_Click(object sender, EventArgs e)
        {
            #region ��ѡ/��ѡ�Ƿ����۱�־

            this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
            this.m_dvM[this.dgM.CurrentRowIndex]["IsSale"] = (sender as CheckBox).Checked ? 1 : 0;
            this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

            #endregion
        }

        private void chkBoxPurchase_Click(object sender, EventArgs e)
        {
            #region ��ѡ/��ѡ�Ƿ��⹺��־

            this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
            this.m_dvM[this.dgM.CurrentRowIndex]["IsPurchase"] = (sender as CheckBox).Checked ? 1 : 0;
            this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

            #endregion
        }

        private void chkBoxSelf_Click(object sender, EventArgs e)
        {
            #region ��ѡ/��ѡ�Ƿ����Ʊ�־

            this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
            this.m_dvM[this.dgM.CurrentRowIndex]["IsSelf"] = (sender as CheckBox).Checked ? 1 : 0;
            this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

            #endregion
        }

        private void chkBoxComsume_Click(object sender, EventArgs e)
        {
            #region ��ѡ/��ѡ�Ƿ��������ñ�־

            this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
            this.m_dvM[this.dgM.CurrentRowIndex]["IsComsume"] = (sender as CheckBox).Checked ? 1 : 0;
            this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

            #endregion
        }

        private void txtWPSPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextKeyPress11(sender, e, new string[] { "PSPrice" });
        }

        private void txtWMPPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextKeyPress11(sender, e, new string[] { "MPPrice" });
        }

        private void txtWRCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextKeyPress11(sender, e, new string[] { "RCost" });
        }

        private void txtWNCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextKeyPress11(sender, e, new string[] { "NCost" });
        }

        private void txtWLSPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextKeyPress11(sender, e, new string[] { "LSPrice" });
        }

        private void txtWRSPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextKeyPress11(sender, e, new string[] { "RSPrice" });
        }

        private void btnSSDate_Click(object sender, EventArgs e)
        {
            #region ������������
            FmDate f = new FmDate();
            f.DateTimeSelected = this.m_dvM[this.dgM.CurrentRowIndex]["SDate"].ToString();
            UICtrl.SetShowStyle(f, sender as Button);
            if (DialogResult.OK == f.ShowDialog())
            {
                this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
                this.m_dvM[this.dgM.CurrentRowIndex]["SDate"] = f.DateTimeSelected;
                this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
            }
            UICtrl.TextBox_Focus1(this.txtSSDate);
            #endregion
        }

        private void btnSEDate_Click(object sender, EventArgs e)
        {
            #region ����ͣ������
            FmDate f = new FmDate();
            f.DateTimeSelected = this.m_dvM[this.dgM.CurrentRowIndex]["EDate"].ToString();
            UICtrl.SetShowStyle(f, sender as Button);
            if (DialogResult.OK == f.ShowDialog())
            {
                this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
                this.m_dvM[this.dgM.CurrentRowIndex]["EDate"] = f.DateTimeSelected;
                this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
            }
            UICtrl.TextBox_Focus1(this.txtSEDate);
            #endregion
        }

        private void btnSVen_Click(object sender, EventArgs e)
        {
            #region ���չ�Ӧ��
            FmRVen f = new FmRVen();
            UICtrl.SetShowStyle(f, 2);
            if (DialogResult.OK == f.ShowDialog())
            {
                DataRow dr = (DataRow)f.SelectedInfo[0];
                this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
                this.m_dvM[this.dgM.CurrentRowIndex]["DefVenId"] = dr["VenId"];
                this.m_dvM[this.dgM.CurrentRowIndex]["DefVenCode"] = dr["VenCode"];
                this.m_dvM[this.dgM.CurrentRowIndex]["DefVenName"] = dr["VenName"];
                this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
            }
            UICtrl.TextBox_Focus1(this.txtSDefVen);
            #endregion
        }

        private void btnSPEp_Click(object sender, EventArgs e)
        {
            #region ����������ҵ
            FmRVen f = new FmRVen();
            UICtrl.SetShowStyle(f, 2);
            if (DialogResult.OK == f.ShowDialog())
            {
                DataRow dr = (DataRow)f.SelectedInfo[0];
                this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
                this.m_dvM[this.dgM.CurrentRowIndex]["PEpId"] = dr["VenId"];
                this.m_dvM[this.dgM.CurrentRowIndex]["PEpCode"] = dr["VenCode"];
                this.m_dvM[this.dgM.CurrentRowIndex]["PEpName"] = dr["VenName"];
                this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
            }
            UICtrl.TextBox_Focus1(this.txtSPEp);
            #endregion
        }

        private void txtSEDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextKeyPress21(sender, e, new string[] { "EDate" });
        }

        private void txtSDefVen_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextKeyPress21(sender, e, new string[] { "DefVenId", "DefVenCode", "DefVenName" });
        }

        private void txtSPEp_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextKeyPress21(sender, e, new string[] { "PEpId", "PEpCode", "PEpName" });
        }

        private void chkBoxBarCodeMg_Click(object sender, EventArgs e)
        {
            #region ��ѡ/��ѡ�Ƿ�����������־

            this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
            this.m_dvM[this.dgM.CurrentRowIndex]["IsBarCodeMg"] = (sender as CheckBox).Checked ? 1 : 0;
            this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

            #endregion
        }

        private void chkBoxQualityMg_Click(object sender, EventArgs e)
        {
            #region ��ѡ/��ѡ�Ƿ��ʼ��־

            this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
            this.m_dvM[this.dgM.CurrentRowIndex]["IsQualityMg"] = (sender as CheckBox).Checked ? 1 : 0;
            this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

            #endregion
        }

        private void chkBIsOTC_Click(object sender, EventArgs e)
        {
            #region ��ѡ/��ѡ�Ƿ�OTC��־

            this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
            this.m_dvM[this.dgM.CurrentRowIndex]["IsOTC"] = (sender as CheckBox).Checked ? 1 : 0;
            this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

            #endregion
        }

        private void chkBoxBOMMg_Click(object sender, EventArgs e)
        {
            #region ��ѡ/��ѡ�Ƿ�BOM�����־

            this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
            this.m_dvM[this.dgM.CurrentRowIndex]["IsBOM"] = (sender as CheckBox).Checked ? 1 : 0;
            this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

            #endregion
        }

        private void txtWVolume_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtWWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextKeyPress11(sender, e, new string[] { "Weight" });
        }

        private void txtWSafeQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextKeyPress11(sender, e, new string[] { "SafeQty" });
        }

        private void txtWTopQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextKeyPress11(sender, e, new string[] { "TopQty" });
        }

        private void txtWLowQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextKeyPress11(sender, e, new string[] { "LowQty" });
        }

        private void txtWWDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextKeyPress11(sender, e, new string[] { "WDays" });
        }

        private void txtWWJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextKeyPress11(sender, e, new string[] { "WJ" });
        }

        private void txtWBH_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextKeyPress11(sender, e, new string[] { "BH" });
        }

        private void txtWCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextKeyPress11(sender, e, new string[] { "CD" });
        }

        private void txtWiQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextKeyPress11(sender, e, new string[] { "iQty" });
        }

        private void rdP_Click(object sender, EventArgs e)
        {
            #region ���ô��Ϊ��Ʒ��־

            this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
            this.m_dvM[this.dgM.CurrentRowIndex]["IsP"] = 1;
            this.m_dvM[this.dgM.CurrentRowIndex]["IsC"] = 0;
            this.m_dvM[this.dgM.CurrentRowIndex]["IsM"] = 0;
            this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

            #endregion
        }

        private void rdC_Click(object sender, EventArgs e)
        {
            #region ���ô��Ϊ����/�����־

            this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
            this.m_dvM[this.dgM.CurrentRowIndex]["IsP"] = 0;
            this.m_dvM[this.dgM.CurrentRowIndex]["IsC"] = 1;
            this.m_dvM[this.dgM.CurrentRowIndex]["IsM"] = 0;
            this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

            #endregion
        }

        private void rdM_Click(object sender, EventArgs e)
        {
            #region ���ô��Ϊ���ϱ�־

            this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
            this.m_dvM[this.dgM.CurrentRowIndex]["IsP"] = 0;
            this.m_dvM[this.dgM.CurrentRowIndex]["IsC"] = 0;
            this.m_dvM[this.dgM.CurrentRowIndex]["IsM"] = 1;
            this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

            #endregion
        }

        private void TextKeyPress11(object sender, KeyPressEventArgs e, string[] strFieldNames)
        {
            #region �ı����а�������
            if (this.m_bOpState == BusiOpState.AddBusiData || this.m_bOpState == BusiOpState.EditBusiData)
            {
                if (e.KeyChar == 8)
                {
                    if (strFieldNames != null && strFieldNames.Length > 0)
                    {
                        this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
                        for (int i = 0; i < strFieldNames.Length; i++)
                        {
                            this.m_dvM[this.dgM.CurrentRowIndex][strFieldNames[i]] = DBNull.Value;
                        }
                        this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
                    }
                }
                else
                    UICtrl.TextBox_KeyPress1(sender, e);
            }
            #endregion
        }

        private void TextKeyPress21(object sender, KeyPressEventArgs e, string[] strFieldNames)
        {
            #region �ı����а�������
            if (this.m_bOpState == BusiOpState.AddBusiData || this.m_bOpState == BusiOpState.EditBusiData)
            {
                if (e.KeyChar == 8)
                {
                    if (strFieldNames != null && strFieldNames.Length > 0)
                    {
                        this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
                        for (int i = 0; i < strFieldNames.Length; i++)
                        {
                            this.m_dvM[this.dgM.CurrentRowIndex][strFieldNames[i]] = DBNull.Value;
                        }
                        this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
                    }
                }
            }
            #endregion
        }

        private void chkBoxHeatNo_Click(object sender, EventArgs e)
        {
            #region ��ѡ/��ѡ�Ƿ�¯�Ź����־

            this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
            this.m_dvM[this.dgM.CurrentRowIndex]["IsHeatNo"] = (sender as CheckBox).Checked ? 1 : 0;
            this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

            #endregion
        }

        private void btnRInv_Click(object sender, EventArgs e)
        {
            #region ���մ������
            FmRInv f = new FmRInv();
            UICtrl.SetShowStyle(f, 2);
            if (DialogResult.OK == f.ShowDialog())
            {
                try
                {
                    DataRow dr = (DataRow)f.SelectedInfo[0];
                    this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
                    this.m_dvM[this.dgM.CurrentRowIndex]["gpInvId"] = dr["InvId"];
                    this.m_dvM[this.dgM.CurrentRowIndex]["gpInvCode"] = dr["InvCode"];
                    this.m_dvM[this.dgM.CurrentRowIndex]["gpInvName"] = dr["InvName"];
                    this.m_dvM[this.dgM.CurrentRowIndex]["gpInvSpec"] = dr["InvSpec"];
                    this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
                }
                catch
                { }
            }
            #endregion
        }

        private void txtWcpNum_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.m_dvM[this.dgM.CurrentRowIndex]["cpNum"].ToString() != "" && this.m_dvM[this.dgM.CurrentRowIndex]["iQty"].ToString() != "")
                {
                    double gpiQty = Convert.ToDouble(this.txtWcpNum.Text.ToString()) * Convert.ToDouble(this.txtWiQty.Text.ToString());
                    double zs = Math.Truncate(gpiQty);
                    double xs = gpiQty - zs;
                    if (xs > 0.5)
                    {
                        gpiQty = zs + 1;
                    }
                    else
                    {
                        gpiQty = zs + 0.5;
                    }
                    this.txtWgpiQty.Text = gpiQty.ToString();
                }
            }
            catch
            { }
        }

        private void txtWgpiQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextKeyPress11(sender, e, new string[] { "gpiQty" });
        }

        private void txtWcpNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextKeyPress11(sender, e, new string[] { "cpNum" });
        }

        private void txtWCCL_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextKeyPress11(sender, e, new string[] { "CCL" });
        }

        private void txtWJCL_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextKeyPress11(sender, e, new string[] { "JCL" });
        }

        private void txtWcpNum_Leave(object sender, KeyEventArgs e)
        {
            try
            {
                if (this.m_dvM[this.dgM.CurrentRowIndex]["cpNum"].ToString() != "" && this.m_dvM[this.dgM.CurrentRowIndex]["iQty"].ToString() != "")
                {
                    double gpiQty = Convert.ToDouble(this.txtWcpNum.Text.ToString()) * Convert.ToDouble(this.txtWiQty.Text.ToString());
                    double zs = Math.Truncate(gpiQty);
                    double xs = gpiQty - zs;
                    if (xs > 0.5)
                    {
                        gpiQty = zs + 1;
                    }
                    else
                    {
                        gpiQty = zs + 0.5;
                    }
                    this.txtWgpiQty.Text = gpiQty.ToString();
                }
            }
            catch
            { }
        }

        private void txtWiQty_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();

                double WJ = Convert.ToDouble(this.m_dvM[this.dgM.CurrentRowIndex]["WJ"]);
                double BH = Convert.ToDouble(this.m_dvM[this.dgM.CurrentRowIndex]["BH"]);
                double XS = Convert.ToDouble(this.m_dvM[this.dgM.CurrentRowIndex]["XS"]);
                double iQty = (WJ - BH) * BH * XS ;
                this.m_dvM[this.dgM.CurrentRowIndex]["iQty"] = iQty;

                this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
            }
            catch
            { }
        }

        private void chkBoxBatchCode_Click(object sender, EventArgs e)
        {
            #region ��ѡ/��ѡ�Ƿ�¯�Ź����־

            this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
            this.m_dvM[this.dgM.CurrentRowIndex]["IsBatch"] = (sender as CheckBox).Checked ? 1 : 0;
            this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

            #endregion
        }


        //===========�����������========================

        private void btnSAtt1_Click(object sender, EventArgs e)
        {
            #region ���ո����������1
            FmRAtt frm = new FmRAtt(1);
            UICtrl.SetShowStyle(frm, 1);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
                this.m_dvM[this.dgM.CurrentRowIndex]["AttCID1"] = frm.drv["AttCID"];
                this.m_dvM[this.dgM.CurrentRowIndex]["AttCName1"] = frm.drv["AttCName"];
                this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

                if (m_dvM[dgM.CurrentRowIndex]["AttCID1"].Equals(m_dvM[dgM.CurrentRowIndex]["AttCID2"]))
                {
                    MsgBox.ShowInfoMsg("�ø�����������Ѿ�ѡ��");
                    m_dvM[dgM.CurrentRowIndex]["AttCID1"] = DBNull.Value;
                    m_dvM[this.dgM.CurrentRowIndex]["AttCName1"] = DBNull.Value;
                }
            }

            UICtrl.TextBox_Focus1(this.txtSAtt1);
            #endregion
        }

        private void btnSAtt2_Click(object sender, EventArgs e)
        {
            #region ���ո����������2
            FmRAtt frm = new FmRAtt(1);
            UICtrl.SetShowStyle(frm, 1);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
                this.m_dvM[this.dgM.CurrentRowIndex]["AttCID2"] = frm.drv["AttCID"];
                this.m_dvM[this.dgM.CurrentRowIndex]["AttCName2"] = frm.drv["AttCName"];
                this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

                if (m_dvM[dgM.CurrentRowIndex]["AttCID1"].Equals(m_dvM[dgM.CurrentRowIndex]["AttCID2"]))
                {
                    MsgBox.ShowInfoMsg("�ø�����������Ѿ�ѡ��");
                    m_dvM[dgM.CurrentRowIndex]["AttCID2"] = DBNull.Value;
                    m_dvM[this.dgM.CurrentRowIndex]["AttCName2"] = DBNull.Value;
                }
            }

            UICtrl.TextBox_Focus1(this.txtSAtt2);
            #endregion
        }

        private void btnSInvMU2_Click(object sender, EventArgs e)
        {
            #region ������λ

            FmRMU1 f = new FmRMU1();
            if (f.ShowDialog() == DialogResult.OK)
            {
                DataRow dr = (DataRow)f.SelectedInfo[0];
                this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
                this.m_dvM[this.dgM.CurrentRowIndex]["MUID2"] = dr["MUId"];
                this.m_dvM[this.dgM.CurrentRowIndex]["MUName2"] = dr["MUName"];
                this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
            }

            UICtrl.TextBox_Focus1(this.txtSInvMU2);
            #endregion
        }

        private void btnSInvMU3_Click(object sender, EventArgs e)
        {
            #region ������λ2

            FmRMU1 f = new FmRMU1();
            if (f.ShowDialog() == DialogResult.OK)
            {
                DataRow dr = (DataRow)f.SelectedInfo[0];
                this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
                this.m_dvM[this.dgM.CurrentRowIndex]["MUID3"] = dr["MUId"];
                this.m_dvM[this.dgM.CurrentRowIndex]["MUName3"] = dr["MUName"];
                this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
            }

            UICtrl.TextBox_Focus1(this.txtSInvMU3);
            #endregion
        }

        private void btnDelMU2_Click(object sender, EventArgs e)
        {
            this.m_dvM[dgM.CurrentRowIndex].Row.BeginEdit();
            this.m_dvM[dgM.CurrentRowIndex]["MUID2"] = DBNull.Value;
            this.m_dvM[dgM.CurrentRowIndex]["MUName2"] = DBNull.Value;
            this.m_dvM[dgM.CurrentRowIndex].Row.EndEdit();
        }

        private void btnDelMU3_Click(object sender, EventArgs e)
        {
            this.m_dvM[dgM.CurrentRowIndex].Row.BeginEdit();
            this.m_dvM[dgM.CurrentRowIndex]["MUID3"] = DBNull.Value;
            this.m_dvM[dgM.CurrentRowIndex]["MUName3"] = DBNull.Value;
            this.m_dvM[dgM.CurrentRowIndex].Row.EndEdit();
        }

        private bool checkMU(string InvID)
        {
            string sql = "select 1 from PuODetail where InvID = " + InvID +
                        "union all select 1 from RDDetail where InvID = " + InvID;
            BusinessObject bo = new BusinessObject();
            bo.BusiDataSQL = new string[] { sql };
            bo.GetBusiData();
            if (bo.BusiData.Tables[0].Rows.Count > 0)
            {
                MsgBox.ShowInfoMsg("�����Ѿ���ʹ�ò���ɾ����λ!");
                return false;
            }
            return true;
        }

        private void chkBox_isMaterial_Click(object sender, EventArgs e)
        {
            this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
            this.m_dvM[this.dgM.CurrentRowIndex]["isMaterial"] = (sender as CheckBox).Checked ? 1 : 0;
            this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
        }

        private void chkBox_isStandard_Click(object sender, EventArgs e)
        {
            this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
            this.m_dvM[this.dgM.CurrentRowIndex]["isStandard"] = (sender as CheckBox).Checked ? 1 : 0;
            this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
        }

        private void txtWXS_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextKeyPress11(sender, e, new string[] { "XS" });
        }

        private void btnSWh_Click(object sender, EventArgs e)
        {
            #region ���ղֿ�
            FmRWh f = new FmRWh();
            UICtrl.SetShowStyle(f, 2);
            if (f.ShowDialog() == DialogResult.OK)
            {
                DataRow dr = (DataRow)f.SelectedInfo[0];
                this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
                this.m_dvM[this.dgM.CurrentRowIndex]["WhId"] = dr["WhId"];
                this.m_dvM[this.dgM.CurrentRowIndex]["DefWhName"] = dr["WhName"];
                this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
            }

            #endregion
        }

        private void tabCtl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkBoxWhPosition_Click(object sender, EventArgs e)
        {

            #region ��ѡ/��ѡ�Ƿ��λ�����־

            this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
            this.m_dvM[this.dgM.CurrentRowIndex]["IsWhPosition"] = (sender as CheckBox).Checked ? 1 : 0;
            this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();

            #endregion
        }

        private void btnRWhP_Click(object sender, EventArgs e)
        {

            #region ���ջ�λ
            FmRC1 f = new FmRC1();
            f.BusiValueSQL = "select WhPId, WhPName BusiValue from WhPosition";
            if (f.ShowDialog() == DialogResult.OK)
            {
                DataRow dr = (DataRow)f.SelectedInfo[0];
                this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
                this.m_dvM[this.dgM.CurrentRowIndex]["DefWhPId"] = dr["WhPId"];
                this.m_dvM[this.dgM.CurrentRowIndex]["DefWhPName"] = dr["BusiValue"];
                this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
            }
            #endregion
        }

        private void btnRWh_Click(object sender, EventArgs e)
        {
            #region ���ղֿ�
            FmRWh f = new FmRWh();
            UICtrl.SetShowStyle(f, 2);
            if (f.ShowDialog() == DialogResult.OK)
            {
                DataRow drWh = (DataRow)f.SelectedInfo[0];
                this.m_dvM[this.dgM.CurrentRowIndex].Row.BeginEdit();
                this.m_dvM[this.dgM.CurrentRowIndex]["WhId"] = drWh["WhId"];
                this.m_dvM[this.dgM.CurrentRowIndex]["DefWhName"] = drWh["WhName"];
                this.m_dvM[this.dgM.CurrentRowIndex].Row.EndEdit();
            }
            #endregion
        }

        //==================================================
    }
}