using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace LanyunMES.UI
{
    using Common;
    using LanyunMES.Entity;

    public partial class FmRole : DevComponents.DotNetBar.OfficeForm
    {
        public FmRole()
        {
            InitializeComponent();
        }


        private void FmRole_Load(object sender, EventArgs e)
        {
            this.InitGrid(GridView);

        }

        private void InitGrid(DataGridView grid)
        {
            grid.AutoGenerateColumns = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.ReadOnly = true;

            DataGridHelper.AddTextBoxColumn(grid, "RoleID", "角色ID", 120);
            DataGridHelper.AddTextBoxColumn(grid, "RoleName", "角色名称", 150);
            DataGridHelper.AddTextBoxColumn(grid, "FNote", "备注", 150);
        }
    }
}