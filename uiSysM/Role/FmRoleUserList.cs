using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NDF
{
    public partial class FmRoleUserList : Form
    {
        public FmRoleUserList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 数据对象
        /// </summary>
        public object DataObject
        {
            get { return this.m_dataObject; }
            set { this.m_dataObject = value; }
        }
        protected object m_dataObject = null;

        private void FmRoleUserList_Load(object sender, EventArgs e)
        {
            DataRow dr = (DataRow)this.m_dataObject;

            this.Text = "详细用户 - 角色:" + dr["RoleName"] + "," + dr["RoleCode"];

            string s = "";
            s += "select ";
            s += "uri.RoleId,";
            s += "uri.UserId,";
            s += "ui.UserName,";
            s += "ui.PersonCode,";
            s += "ui.PersonName";
            s += " from ";
            s += "UserRoleInfo uri";
            s += " left outer join UserInfo ui on ui.UserId=uri.UserId";
            s += " where ";
            s += "uri.RoleId=" + dr["RoleId"];
            BusinessObject bo = new BusinessObject();
            bo.BusiDataSQL = new string[] { s };
            bo.GetBusiData();
            if (bo.BusiMsg[0] == "1")
            {
                for (int i = 0; i < bo.BusiData.Tables[0].Rows.Count; i++)
                {
                    DataRow r = bo.BusiData.Tables[0].Rows[i];

                    ListViewItem lvi = new ListViewItem(r["UserName"].ToString(), 0);
                    lvi.SubItems.Add(r["PersonCode"].ToString());
                    lvi.SubItems.Add(r["PersonName"].ToString());

                    this.lvUser.Items.Add(lvi);
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}