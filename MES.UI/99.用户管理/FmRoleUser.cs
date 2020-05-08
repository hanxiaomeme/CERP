using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;


namespace LanyunMES.UI
{
    using DevComponents.AdvTree;
    using Entity;
    using Business;
    using System.Windows.Forms;
    using Common;

    public partial class FmRoleUser : DevComponents.DotNetBar.OfficeForm
    {
        public FmRoleUser(int roleId)
        {
            InitializeComponent();

            this.Role = business.GetRoleUserDTO(roleId);
        }

        private RoleService business = new RoleService();

        public RoleUserDTO Role { get; private set; }


        private void InitGrid(DataGridView grid)
        {
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;

            var col = DataGridHelper.AddTextBoxColumn(grid, "UserID", "用户ID");
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridHelper.AddTextBoxColumn(grid, "UserName", "用户名");
        }
 
        private void FmUserAuth_Load(object sender, EventArgs e)
        {
            
        }
 
    }

 

}