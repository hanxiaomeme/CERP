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

    public partial class Ref_Person : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Ref_Person()
        {
            InitializeComponent();
        }

        List<ITreeModel> deplist;
        DepartmentBLL depBll = new DepartmentBLL();

        List<Person> psnlist;
        PersonBLL psnBll = new PersonBLL();
        public Person resultPsn = null;

        private void Ref_Inventory_Load(object sender, EventArgs e)
        {
            this.Text = "参照 -- " + this.pnlHead.Text;
            deplist = depBll.GetTreeList("");
            TreeHelper.LoadAdvTree(this.TreeClass, deplist, NodeClick);
        }

        private void NodeClick(object sender, EventArgs e)
        {
            string code = (sender as Node).Name;
            psnlist = psnBll.GetModelList("Person.cDepCode like '" + code + "%'");
            this.gridControl1.DataSource = psnlist;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            resultPsn = psnlist[gridView1.GetSelectedRows()[0]];      
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
