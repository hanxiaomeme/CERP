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
    using U8.Model;
    using DAL;
    using MES.BLL;

    public partial class Ref_Customer : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Ref_Customer()
        {
            InitializeComponent();
        }

        List<U8CustomerClass> cusClist = new List<U8CustomerClass>();
        List<U8Customer> cuslist = new List<U8Customer>();
        public U8Customer resultCus = null;
        CustomerClassBLL cusCBll = new CustomerClassBLL();
        CustomerBLL cusBll = new CustomerBLL();

        U8CustomerClass 

        //DataTable dt;
        //public List<DataRow> rows = new List<DataRow>();

        private void LoadTree()
        {
            cusClist = cusCBll.GetModelList("");
             
            Node rootNode = null;
            if (this.InvClass_Tree.Nodes.Count > 0)
            {
                rootNode = InvClass_Tree.Nodes[0];
            }

            Node[] nodes = new Node[10];
            foreach (CustomerClass invc in cusClist)
            {
                int i = invc.iCCGrade;

                nodes[i] = new Node(invc.cCCName);
                nodes[i].Tag = new string[] { invc.cCCCode, invc.cCCName };
                nodes[i].Name = invc.cCCCode;
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

        private void NodeClick(object sender, EventArgs e)
        {
            string cCCCode = (sender as Node).Name;
            cuslist = cusBll.GetModelList("cCCCode like '" + cCCCode + "%'");
            this.gridControl1.DataSource = cuslist;
        }

        private void Ref_Inventory_Load(object sender, EventArgs e)
        {
            this.LoadTree();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            resultCus = cuslist[gridView1.GetSelectedRows()[0]];      
            this.DialogResult = DialogResult.OK;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.gridView1_DoubleClick(sender, e);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
