using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 

namespace Lanyun
{
    public partial class FmInv : FmB32
    {
        public FmInv()
        {
            InitializeComponent();

            this.m_strMModuleName = "Inventory";
            this.m_strTModuleName = "InvClass";
        }

        #region 表样式
        protected override void InitDGTabStyle()
        {
            this.dgM.TableStyles.Clear();

            DataGridTableStyle dgTS = new DataGridTableStyle();
            dgTS.MappingName = "t";

            DataGridTextBoxColumn dgColTextBox = null;
            DataGridDateTimePickerColumn dgColdtPicker = null;

            dgColTextBox = new DataGridNoActiveTextBoxColumn();
            dgColTextBox.HeaderText = "存货编码";
            dgColTextBox.ReadOnly = true;
            dgColTextBox.Width = 100;
            dgColTextBox.MappingName = "InvCode";
            dgColTextBox.NullText = string.Empty;
            dgTS.GridColumnStyles.Add(dgColTextBox);

            dgColTextBox = new DataGridNoActiveTextBoxColumn();
            dgColTextBox.HeaderText = "存货名称";
            dgColTextBox.ReadOnly = true;
            dgColTextBox.Width = 90;
            dgColTextBox.MappingName = "InvName";
            dgColTextBox.NullText = string.Empty;
            dgTS.GridColumnStyles.Add(dgColTextBox);

            dgColTextBox = new DataGridNoActiveTextBoxColumn();
            dgColTextBox.HeaderText = "规格型号";
            dgColTextBox.ReadOnly = true;
            dgColTextBox.Width = 100;
            dgColTextBox.MappingName = "InvSpec";
            dgColTextBox.NullText = string.Empty;
            dgTS.GridColumnStyles.Add(dgColTextBox);

            dgColTextBox = new DataGridNoActiveTextBoxColumn();
            dgColTextBox.HeaderText = "单位";
            dgColTextBox.Alignment = HorizontalAlignment.Center;
            dgColTextBox.ReadOnly = true;
            dgColTextBox.Width = 50;
            dgColTextBox.MappingName = "MUName";
            dgColTextBox.NullText = string.Empty;
            dgTS.GridColumnStyles.Add(dgColTextBox);

            dgColTextBox = new DataGridNoActiveTextBoxColumn();
            dgColTextBox.HeaderText = "上级分类编码";
            dgColTextBox.ReadOnly = true;
            dgColTextBox.Width = 90;
            dgColTextBox.MappingName = "InvCCode";
            dgColTextBox.NullText = string.Empty;
            dgTS.GridColumnStyles.Add(dgColTextBox);

            dgColTextBox = new DataGridNoActiveTextBoxColumn();
            dgColTextBox.HeaderText = "上级分类名称";
            dgColTextBox.ReadOnly = true;
            dgColTextBox.Width = 80;
            dgColTextBox.MappingName = "InvCName";
            dgColTextBox.NullText = string.Empty;
            dgTS.GridColumnStyles.Add(dgColTextBox);

            dgColTextBox = new DataGridNoActiveTextBoxColumn();
            dgColTextBox.HeaderText = "成材率";
            dgColTextBox.ReadOnly = true;
            dgColTextBox.Width = 60;
            dgColTextBox.MappingName = "CCL";
            dgColTextBox.NullText = string.Empty;
            dgTS.GridColumnStyles.Add(dgColTextBox);

            dgColTextBox = new DataGridNoActiveTextBoxColumn();
            dgColTextBox.HeaderText = "材质";
            dgColTextBox.Alignment = HorizontalAlignment.Center;
            dgColTextBox.ReadOnly = true;
            dgColTextBox.Width = 60;
            dgColTextBox.MappingName = "isMaterialDesc";
            dgColTextBox.NullText = string.Empty;
            dgTS.GridColumnStyles.Add(dgColTextBox);

            dgColTextBox = new DataGridNoActiveTextBoxColumn();
            dgColTextBox.HeaderText = "炉号";
            dgColTextBox.Alignment = HorizontalAlignment.Center;
            dgColTextBox.ReadOnly = true;
            dgColTextBox.Width = 60;
            dgColTextBox.MappingName = "isHeatNoDesc";
            dgColTextBox.NullText = string.Empty;
            dgTS.GridColumnStyles.Add(dgColTextBox);

            dgColTextBox = new DataGridNoActiveTextBoxColumn();
            dgColTextBox.HeaderText = "批号";
            dgColTextBox.Alignment = HorizontalAlignment.Center;
            dgColTextBox.ReadOnly = true;
            dgColTextBox.Width = 60;
            dgColTextBox.MappingName = "isBatchDesc";
            dgColTextBox.NullText = string.Empty;
            dgTS.GridColumnStyles.Add(dgColTextBox);

            dgColTextBox = new DataGridNoActiveTextBoxColumn();
            dgColTextBox.HeaderText = "销售";
            dgColTextBox.Alignment = HorizontalAlignment.Center;
            dgColTextBox.ReadOnly = true;
            dgColTextBox.Width = 60;
            dgColTextBox.MappingName = "IsSaleDesc";
            dgColTextBox.NullText = string.Empty;
            dgTS.GridColumnStyles.Add(dgColTextBox);

            dgColTextBox = new DataGridNoActiveTextBoxColumn();
            dgColTextBox.HeaderText = "外购";
            dgColTextBox.Alignment = HorizontalAlignment.Center;
            dgColTextBox.ReadOnly = true;
            dgColTextBox.Width = 60;
            dgColTextBox.MappingName = "IsPurchaseDesc";
            dgColTextBox.NullText = string.Empty;
            dgTS.GridColumnStyles.Add(dgColTextBox);

            dgColTextBox = new DataGridNoActiveTextBoxColumn();
            dgColTextBox.HeaderText = "自制";
            dgColTextBox.Alignment = HorizontalAlignment.Center;
            dgColTextBox.ReadOnly = true;
            dgColTextBox.Width = 60;
            dgColTextBox.MappingName = "IsSelfDesc";
            dgColTextBox.NullText = string.Empty;
            dgTS.GridColumnStyles.Add(dgColTextBox);

            dgColTextBox = new DataGridNoActiveTextBoxColumn();
            dgColTextBox.HeaderText = "生产耗用";
            dgColTextBox.Alignment = HorizontalAlignment.Center;
            dgColTextBox.ReadOnly = true;
            dgColTextBox.Width = 60;
            dgColTextBox.MappingName = "IsComsumeDesc";
            dgColTextBox.NullText = string.Empty;
            dgTS.GridColumnStyles.Add(dgColTextBox);

            dgColTextBox = new DataGridNoActiveTextBoxColumn();
            dgColTextBox.HeaderText = "计价方式";
            dgColTextBox.Alignment = HorizontalAlignment.Center;
            dgColTextBox.ReadOnly = true;
            dgColTextBox.Width = 90;
            dgColTextBox.MappingName = "ValueStyle";
            dgColTextBox.NullText = string.Empty;
            dgTS.GridColumnStyles.Add(dgColTextBox);

            dgColdtPicker = new DataGridDateTimePickerColumn();
            dgColdtPicker.HeaderText = "gDate";
            dgColdtPicker.Width = 0;
            dgColdtPicker.MappingName = "gDate";
            dgColdtPicker.NullText = DateTime.Now.Date.ToShortDateString();
            dgTS.GridColumnStyles.Add(dgColdtPicker);

            this.dgM.TableStyles.Add(dgTS);
        }
        #endregion

        private string[] NodeTag = null;

        private TreeView GetTV(TreeView tv)
        {
            #region 获得分类TreeView
            tv.Nodes.Clear();
            int grade;
            TreeNode[] nodes = new TreeNode[10];
            nodes[0] = this.m_tnRoot;
            foreach (DataRow dr in m_btObj.BusiData.Tables[0].Rows)
            {
                grade = int.Parse(dr["Grade"].ToString());
                nodes[grade] = new TreeNode(dr["InvCCode"].ToString() + " - " + dr["InvCName"].ToString());
                nodes[grade].Name = dr["InvCCode"].ToString();
                nodes[grade].Tag = new string[] { dr["InvCCode"].ToString(), dr["InvCName"].ToString() };
                if (grade >= 1)
                {
                    nodes[grade - 1].Nodes.Add(nodes[grade]);
                }
            }
            nodes[0].Expand();
            tv.Nodes.Add(nodes[0]);
            return tv; 
            #endregion
        }

        protected override void TVUpd()
        {
            try
            {
                while (!this.IsHandleCreated) { ; }
                this.BeginInvoke(new m_dgtUICursor(this.UICursor), new object[] { Cursors.WaitCursor });

                this.m_alTnRootExpand.Clear();

                this.m_tnRoot = new TreeNode(this.m_btObj.BusiData.Tables["8080"].Rows[0]["RootName"].ToString());
                this.m_tnRoot.Tag = new string[] { "", "" };

                this.GetTV(this.tvM);

                MTableUpdTVNodeChg();
            }
            catch { }
            finally
            {
                while (!this.IsHandleCreated) { ; }
                this.BeginInvoke(new m_dgtUICursor(this.UICursor), new object[] { Cursors.Default });
            }
        }

        protected override void tvM_Click(object sender, EventArgs e)
        {
            TreeNode tn = this.tvM.GetNodeAt(this.m_ntvMouseX, this.m_ntvMouseY);
            if (tn == null) return;

            if (!(this.m_ntvMouseX >= tn.Bounds.X &&
                this.m_ntvMouseX <= tn.Bounds.X + tn.Bounds.Width &&
                this.m_ntvMouseY >= tn.Bounds.Y &&
                this.m_ntvMouseY <= tn.Bounds.Y + tn.Bounds.Height)) return;

            this.m_tnSelected = tn;
            NodeTag = (string[])tn.Tag;
            MTableUpdTVNodeChg();
        }

        protected override void GetTSQL()
        {
            base.GetTSQL();
            this.m_btObj.BusiOrderSQL = new string[] { "InvCCode" };
        }

        protected override void GetMSQL()
        {
            base.GetMSQL();
            this.m_bmObj.BusiOrderSQL = new string[] { "InvCode" };
        }

        protected override void GetSubTreeNodes(TreeNode tn) { }

        protected override void FmB_Load(object sender, EventArgs e)
        {
            base.FmB_Load(sender, e);
        }

        protected override void btnAdd_Click(object sender, EventArgs e)
        {
            #region 新增
            FmIUInv f = new FmIUInv();
            f.OuterFilterSQL = new string[] { this.m_strPK + "=-1" };
            f.OpState = BusiOpState.AddBusiData;
            f.setInvClass(NodeTag);
            UICtrl.SetShowStyle(f, 1);
            if (f.ShowDialog() == DialogResult.Yes)
            {
                this.m_bOpState = f.OpState; GetMBusiData();
            } 
            #endregion
        }

        protected override void btnEdit_Click(object sender, EventArgs e)
        {
            #region 编辑
            FmIUInv f = new FmIUInv();
            f.OuterFilterSQL = new string[] { this.m_strPK + " = " + this.m_dvM[dgM.CurrentRowIndex][this.m_strPK] };
            f.OpState = BusiOpState.EditBusiData;
            UICtrl.SetShowStyle(f, 1);
            if (f.ShowDialog() == DialogResult.Yes)
            {
                this.m_bOpState = f.OpState; GetMBusiData();
            } 
            #endregion
        }

        protected override void btnDel_Click(object sender, EventArgs e)
        {
            #region 删除
            BusinessObject bo = new BusinessObject();
            string sql = "select * from PuoDetail where InvId=" + this.m_dvM[this.dgM.CurrentRowIndex].Row["InvId"].ToString()
                   + ";select * from SaleOrderDetail where InvId=" + this.m_dvM[this.dgM.CurrentRowIndex].Row["InvId"].ToString()
                   + ";select * from RDDetail where InvId=" + this.m_dvM[this.dgM.CurrentRowIndex].Row["InvId"].ToString();
            bo.BusiDataSQL = new string[] { sql };
            bo.GetBusiData();
            if (bo.BusiMsg[0] == "1" && (bo.BusiData.Tables[0].Rows.Count > 0 || bo.BusiData.Tables[1].Rows.Count > 0 || bo.BusiData.Tables[2].Rows.Count > 0))
            {
                MsgBox.ShowErrMsg2("该存货档案已经被引用，不可以删除！"); return;
            }

            base.btnDel_Click(sender, e); 
            #endregion
        }

        protected override void btnQuery_Click(object sender, EventArgs e)
        {
            #region 查询业务数据
            FmQBank f = new FmQBank();
            if (f.ShowDialog() == DialogResult.OK)
            {
                this.m_strAryQueryCondition = f.QueryCondition;

                base.btnQuery_Click(sender, e);
            }
            #endregion
        }

        protected override void InitPrintSettingsName()
        {
            this.m_strPrintSettings = "Inv";
        }

        protected override void ExecPrint()
        {
            #region 执行打印
            try
            {
                this.Cursor = Cursors.WaitCursor;

                GPrinter gPrter = new GPrinter();
                gPrter.DocumentName = "存货档案";
                gPrter.CustomPrintSettings = this.m_strPrintSettings;

                Title title = new Title();
                title.Text = "存货档案";
                gPrter.Title = title;

                gPrter.MultiHeader = PrintUtility.DataGridHeader1(this.dgM);
                gPrter.Body = PrintUtility.DataGridBody1(this.dgM, 25, null, null);

                Print.Run1(gPrter);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            #endregion
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            #region 查看库存
            int invid = (int)m_dvM[dgM.CurrentRowIndex]["InvID"];
            FmInvStock f = new FmInvStock(invid);
            UICtrl.SetShowStyle(f, 1);
            f.ShowDialog(); 
            #endregion
        }
    }
}