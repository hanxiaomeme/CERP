﻿using System;
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

    public partial class Ref_SaleType : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Ref_SaleType()
        {
            InitializeComponent();
        }

        List<SaleType> list;
        SaleTypeBLL bll = new SaleTypeBLL();
        public SaleType resultSt = null;

        private void Ref_Inventory_Load(object sender, EventArgs e)
        {
            this.Text = "参照 -- " + this.pnlHead.Text;
            list = bll.GetModelList("");
            this.gridControl1.DataSource = list;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            resultSt = list[gridView1.GetSelectedRows()[0]];      
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
