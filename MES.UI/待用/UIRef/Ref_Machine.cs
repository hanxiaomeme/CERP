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
    using MES.DAL;
    using MES.UIBase;

    public partial class Ref_Machine: DevComponents.DotNetBar.Metro.MetroForm
    {
        public Ref_Machine()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 只显示对应生产订单行存货对应设备
        /// </summary>
        /// <param name="modids"></param>
        public Ref_Machine(params int[] modids)
        {
            InitializeComponent();
            this.modids = modids;
        }

        List<Machine> list;
        MachineDAL dal = new MachineDAL();
        public Machine resultSt = null;
        private int[] modids;

        private void Ref_Inventory_Load(object sender, EventArgs e)
        {
            this.Text = "参照 -- " + this.pnlHead.Text;
            if (this.modids != null && modids.Length > 0)
            {
                list = dal.GetModelList(modids);
            }
            else
            {
                list = dal.GetModelList("");
            }
            this.gridControl1.DataSource = list;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            int index = gridView1.GetSelectedRows()[0];

            int sindex =  gridView1.GetDataSourceRowIndex(index);

            resultSt = list[sindex];      
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
