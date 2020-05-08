using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MES
{
    using MES.UIBase;
    using MES.DAL;

    public partial class FmInvQuery : MES.uiBase.FmQBox
    {
        public FmInvQuery()
        {
            InitializeComponent();
        }

        protected override string GetQueryStr()
        {
            string str = "", str2 = "";
            if (txt_InvCode.Text.Trim() != "")
            {
                str += "InvCode like '%" + txt_InvCode.Text.Trim() + "%'";
            }
            if (txt_InvName.Text.Trim() != "")
            {
                str2 = "InvName like '%" + txt_InvName.Text.Trim() + "%'";

                if (str.Trim() == "")
                    str += str2;
                else
                    str += " and " + str2;
            }
            if (txt_InvStd.Text.Trim() != "")
            {
                str2 = "InvStd like '%" + txt_InvStd.Text.Trim() + "%'";

                if (str.Trim() == "")
                    str += str2;
                else
                    str += " and " + str2;
            }
            if (txt_LJDB.Text.Trim() != "")
            {
                str2 = "LJDB like '%" + txt_LJDB.Text.Trim() +"%'";

                if (str.Trim() == "")
                    str += str2;
                else
                    str += " and " + str2;
            }
            if (txt_QueryCode.Text.Trim() != "")
            {
                string strw = "%" + txt_QueryCode.Text.Trim() + "%";
                
                str2 = "DDCS like '" + strw;
                str2 += "' or CDCS like '" + strw + "'";

                if (str.Trim() == "")
                    str += str2;
                else
                    str += " and " + str2;
            }
            return str;
        }
    }
}
