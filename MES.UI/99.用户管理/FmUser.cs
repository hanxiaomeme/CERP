using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;

namespace LanyunMES.UI
{
    using Business;
    using Common;
    using Entity;

    public partial class FmUser : DevComponents.DotNetBar.OfficeForm
    {
        public FmUser()
        {
            InitializeComponent();
        }

        UserService business = new UserService();

        public List<User> DataList { get; private set; }

        private void InitGrid(DataGridView grid)
        {
            grid.AutoGenerateColumns = false;
            grid.ReadOnly = true;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
 
            DataGridHelper.AddTextBoxColumn(grid, "UserID", "用户ID", 120);
            DataGridHelper.AddTextBoxColumn(grid, "UserName", "用户名", 120);
            DataGridHelper.AddTextBoxColumn(grid, "FCreateDate", "创建日期", 120);
            DataGridHelper.AddCheckBoxColumn(grid, "IsStop", "停用", 80).ReadOnly = true;
        }
 
        private void FmUser_Load(object sender, EventArgs e)
        {
            this.InitGrid(GridView);
            this.DataList = business.GetList();
            this.GridView.DataSource = DataList;
        }

        private void btn_Auth_Click(object sender, EventArgs e)
        {
            //DataTable dt = (DataTable)GridView.DataSource;
            //int userid = Convert.ToInt32(dt.Rows[GridView.CurrentRow.Index]["userid"]);
            //FmUserAuth frm = new FmUserAuth(userid);
            //frm.ShowDialog();
        }
    }
}