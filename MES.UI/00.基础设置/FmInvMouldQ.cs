using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace LanyunMES.UI
{
    using Model;
    using U8Ext.Ref;
    using DevComponents.Editors;
    using DevComponents.Editors.DateTimeAdv;


    public partial class FmInvMouldQ : DevComponents.DotNetBar.OfficeForm
    {
        public FmInvMouldQ()
        {
            InitializeComponent();
            this.txt_cInvCodeS.ButtonCustomClick += RefInventory;
            this.txt_cInvCodeE.ButtonCustomClick += RefInventory;
        }

        //where条件List
        public List<string> ListWhere
        {
            get { return this._ListWhere; }
        }
        protected List<string> _ListWhere = new List<string>();

        
        public List<SqlParameter> Parameters
        {
            get { return this._parameters; }
        }
        protected List<SqlParameter> _parameters = new List<SqlParameter>();

        protected void GetSqlParams()
        {
            #region 获取过滤条件
            string strWhere, keyWord;

            foreach (Control ctrl in this.panelEx2.Controls)
            {
                if (ctrl is TextBox && (ctrl as TextBox).Text.Trim() != "")
                {
                    strWhere = (ctrl as TextBox).Tag.ToString();
                    this._ListWhere.Add(strWhere);
                    keyWord = strWhere.Substring(strWhere.IndexOf('@'));
                    keyWord = keyWord.Replace(")", "");
                    if (strWhere.ToLower().Contains("like"))
                    {
                        this._parameters.Add(new SqlParameter(keyWord, (ctrl as TextBox).Text.Trim() + "%"));
                    }
                    else
                    {
                        this._parameters.Add(new SqlParameter(keyWord, (ctrl as TextBox).Text.Trim()));
                    }
                }
                else if (ctrl is DateTimeInput)
                {
                    if ((ctrl as DateTimeInput).LockUpdateChecked)
                    {
                        strWhere = (ctrl as DateTimeInput).Tag.ToString();
                        this._ListWhere.Add(strWhere);
                        keyWord = strWhere.Substring(strWhere.IndexOf('@'));
                        this._parameters.Add(new SqlParameter(keyWord, (ctrl as DateTimeInput).Value));
                    }
                }
                else if(ctrl is IntegerInput && (ctrl as IntegerInput).Text != "")
                {
                    strWhere = (ctrl as IntegerInput).Tag.ToString();
                    this._ListWhere.Add(strWhere);
                    keyWord = strWhere.Substring(strWhere.IndexOf('@'));
                    keyWord = keyWord.Replace(")", "");
                    this._parameters.Add(new SqlParameter(keyWord, (ctrl as IntegerInput).Value));          
                }
                else if(ctrl is CheckBox)
                {
                    if ((ctrl as CheckBox).Checked)
                    {
                        strWhere = (ctrl as CheckBox).Tag.ToString();
                        this._ListWhere.Add(strWhere);
                    }
                }
            } 
            #endregion
        }

        public void LoadSqlParams(List<SqlParameter> parameters)
        {
            #region 加载上次查询条件
            if (parameters == null || parameters.Count < 1) return;

            //先清除日期
            foreach (Control ctrl in panelEx2.Controls)
            {
                if (ctrl is DateTimeInput)
                {
                    (ctrl as DateTimeInput).LockUpdateChecked = false;
                    (ctrl as DateTimeInput).Text = "";
                }
            }

            foreach (SqlParameter p in parameters)
            {
                foreach (Control ctrl in this.panelEx2.Controls)
                {
                    if (ctrl is TextBox)
                    {
                        if (ctrl.Tag.ToString().Contains(p.ParameterName))
                        {
                            string s = p.Value.ToString();
                            if(s.Substring(s.Length-1) == "%")
                            {
                                s = s.Substring(0, s.Length - 1);
                            }
                            (ctrl as TextBox).Text = s;
                        }
                    }
                    else if (ctrl is DateTimeInput)
                    {
                        if (ctrl.Tag.ToString().Contains(p.ParameterName))
                        {
                            (ctrl as DateTimeInput).LockUpdateChecked = true;
                            (ctrl as DateTimeInput).Value = Convert.ToDateTime(p.Value);  
                        }
                    }
                    else if (ctrl is IntegerInput)
                    {
                        if (ctrl.Tag.ToString().Contains(p.ParameterName))
                        {
                            (ctrl as IntegerInput).Value = Convert.ToInt32(p.Value);
                        }
                    }
                }
            } 

            #endregion
        }

        private void RefInventory(object sender, EventArgs e)
        {
            IRefDAL dal = new InventoryDAL(Information.UserInfo.ConnU8);
            RefForm frm = new RefForm(dal);
            if(frm.ShowDialog() == DialogResult.OK)
            {
                (sender as TextBox).Text = frm.rows[0]["cInvCode"].ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.GetSqlParams();
            this.DialogResult = DialogResult.OK;
        }
    }
}