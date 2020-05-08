using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.AdvTree;

namespace MES.UI
{
    using MES.Model;
    using MES.BLL;
    using MES.UIBase;

    public partial class Ref_Inventory : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Ref_Inventory()
        {
            InitializeComponent();
        }

        List<InventoryClass> invClist = new List<InventoryClass>();
        InventoryClassBLL invCBll = new InventoryClassBLL();
        InventoryBLL invBll = new InventoryBLL();
        DataTable dt;
        public List<DataRow> rows = new List<DataRow>();
        private int pageIndex = 1, pageSize = 500;
        private decimal pageCount = 1;
        private string strWhere = "";

        private void LoadTree()
        {
            invClist = invCBll.GetModelList("", "cInvCCode");
             
            Node rootNode = null;
            if (this.InvClass_Tree.Nodes.Count > 0)
            {
                rootNode = InvClass_Tree.Nodes[0];
            }

            Node[] nodes = new Node[10];
            foreach (InventoryClass invc in invClist)
            {
                int i = invc.iInvCGrade;

                nodes[i] = new Node(invc.Name);
                nodes[i].Tag = new string[] { invc.cInvCCode, invc.cInvCCode };
                nodes[i].Name = invc.cInvCCode;
                nodes[i].Image = InvClass_Tree.ImageList.Images[0];
                nodes[i].NodeClick += new EventHandler(NodeClick);
     
                if (i > 1)
                {
                    nodes[i - 1].Nodes.Add(nodes[i]);
                }
                else if (i == 1)
                {
                    //判断是否存在根节点
                    if (rootNode != null)
                        rootNode.Nodes.Add(nodes[i]);
                    else
                        InvClass_Tree.Nodes.Add(nodes[i]);
                }
            }
        }

        private void LoadGrid(string strWhere, int pageIndex, int pageSize)
        {
            decimal RecCount = invBll.GetRecordCount(strWhere);
            pageCount = Math.Ceiling(RecCount / pageSize);
            dt = invBll.GetListByPage(strWhere, "cInvCode", pageIndex, pageSize).Tables[0];
            this.gridControl1.DataSource = dt;
            this.lbl_Pages.Text = "记录：" + RecCount + " | 第" + pageIndex + "页， 共" + pageCount + "页";
        }

        private void NodeClick(object sender, EventArgs e)
        {
            string curCCode = (sender as Node).Name;
            strWhere = "bSale = 1 and dEDate is null and cInvCCode like '" + curCCode + "%'";

            LoadGrid(strWhere,pageIndex, pageSize);
        }


        private void Ref_Inventory_Load(object sender, EventArgs e)
        {
            this.LoadTree();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.gridView1.GetSelectedRows().Length; i++)
            {
                rows.Add(dt.Rows[gridView1.GetSelectedRows()[i]]);
            }
            this.DialogResult = DialogResult.OK;
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            if (pageIndex != 1)
            {
                this.LoadGrid(strWhere, 1, pageSize);
                pageIndex = 1;
            }
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            if (pageIndex > 1)
            {
                this.LoadGrid(strWhere, pageIndex - 1, pageSize);
                pageIndex--;
            }
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            if (pageCount > pageIndex)
            {
                this.LoadGrid(strWhere, pageIndex + 1, pageSize);
                pageIndex++;
            }
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            if (pageIndex != pageCount)
            {
                this.LoadGrid(strWhere, Convert.ToInt32(pageCount), pageSize);
                pageIndex = Convert.ToInt32(pageCount);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.gridView1_DoubleClick(sender, e);
        }
    }
}
