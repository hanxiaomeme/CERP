using System;
using System.Data;
using System.Windows.Forms;

namespace NDF
{
    using NDF.DAL;

    public partial class FmUserAuthority : DevComponents.DotNetBar.OfficeForm
    {
        public FmUserAuthority()
        {
            InitializeComponent();
        }

        private DataView dvM, dvD;

        private void FmUserAuthority_Load(object sender, EventArgs e)
        {
            GetAuthInfo();
        }

        private void GetAuthInfo()
        {
            DataSet ds = DbHelperSQL.Query("select * from Authority");
            dvM = ds.Tables[0].DefaultView;
            dvM.AllowNew = false;
            this.AuthView.AutoGenerateColumns = false;
            AuthView.DataSource = dvM;
        }

        private void GetUserInfo(int AuthID)
        {
            string str = "select case when t2.UserID is null then 0 else 1 end isChecked, "
                       + "t1.UserID, t1.UserName, t1.PersonName from UserInfo t1 "
                       + "left join UserAuthority t2 on t1.UserID = t2.UserID and t2.AuthID = " + AuthID;
            DataSet ds = DbHelperSQL.Query(str);
            dvD = ds.Tables[0].DefaultView;
            dvD.AllowNew = false;
            dvD.AllowEdit = true;
            this.UserView.AutoGenerateColumns = false;
            UserView.DataSource = dvD;
        }

        private void AuthView_CurrentCellChanged(object sender, EventArgs e)
        {
            if (AuthView.CurrentRow != null && AuthView.CurrentRow.Index >= 0)
            {
                int authID = int.Parse(dvM[AuthView.CurrentRow.Index]["AuthID"].ToString());
                GetUserInfo(authID);
            }
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            UserView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            string authID = dvM[AuthView.CurrentRow.Index]["AuthID"].ToString();
            string sql = "delete from UserAuthority where AuthID = " + authID;
            foreach(DataRowView row in dvD)
            {
                if (row["isChecked"].ToString() == "1")
                {
                    sql += ";insert into UserAuthority values(" + authID + "," + row["UserID"].ToString() + ")";
                }
            }

            try
            {
                DbHelperSQL.ExecuteSql(sql);
            }
            catch(Exception ex)
            {
                MsgBox.ShowInfoMsg(ex.ToString());
            }

        }

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
