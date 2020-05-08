using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using DevComponents.AdvTree;
using LanyunMES.Entity;

namespace LanyunMES.UIBase
{
 
    public enum OpState { Add, Update, Del, Browse }; 

     public class UserRight
    {

    }

     public class UserAuth
     {
         public static bool Valid(string strAuthKeyValue, string strModuleClassName)
         {
             string s = "ClassName='" + strModuleClassName + "' and KeyValue='" + strAuthKeyValue + "' and AuthGrant=1";
             DataRow[] drAry = UserToKen.CurrentUserToKen.UserAuth.Select(s);

             if (drAry != null && drAry.Length == 0)
             {
                 MessageBox.Show("没有执行该操作的权限，请联系系统管理员！");
             }

             return (drAry != null && drAry.Length == 0) ? false : true;
         }
     }

    public class BaseHelper
    {

        /// <summary>
        /// 字符在字符串中的出现次数
        /// </summary>
        public static int SubstringCount(string str, string substring)
        {
            #region 字符在字符串中的出现次数
            if (str.Contains(substring))
            {
                string strReplaced = str.Replace(substring, "");
                return (str.Length - strReplaced.Length) / substring.Length;
            }
            return 0; 
            #endregion
        }

        public static void ClearReadOnlyTextBox(object sender, KeyPressEventArgs e)
        {
            #region 只读TextBox退格键清楚Text和Tag内容
            if (sender is TextBox)
            {
                TextBox box = sender as TextBox;
                if ((Keys)e.KeyChar == Keys.Back && box.ReadOnly == true)
                {
                    box.Clear();
                    box.Tag = "";
                }
            } 
            #endregion
        }

        private static void TextBox_DateFormat(object sender, EventArgs e)
        {
            #region 日期关联TextBox日期格式化
            TextBox box = sender as TextBox;
            if (!string.IsNullOrEmpty(box.Text))
            {
                DateTime date = DateTime.Parse(box.Text);
                box.Text = date.ToShortDateString();
            }
            #endregion
        }

        /// <summary>
        /// TextBox格式化日期
        /// </summary>
        /// <param name="boxes"></param>
        public static void TextBox_AddDateChangeEvent(params TextBox[] boxes)
        {
            #region 日期关联Textbox添加日期格式化事件
            foreach (TextBox box in boxes)
            {
                box.TextChanged += new EventHandler(TextBox_DateFormat);
            }
            #endregion
        }
        /// <summary>
        /// 编辑模式时表头TextBox状态
        /// </summary>
        /// <param name="ctrl"></param>
        public static void SetEditMode(Control ctrl)
        {
            #region 编辑模式时表头控件状态
            foreach (Control c in ctrl.Controls)
            {
                if (c is TextBox)
                {
                    if (c.Name.Length >= 4 && c.Name.Substring(0, 4).ToLower() == "txtr")
                    {
                        c.BackColor = SystemColors.Control;
                    }
                    if (c.Name.Length >= 4 && c.Name.Substring(0, 4).ToLower() == "txts")
                    {
                        c.BackColor = Color.LightGray;
                    }
                    if (c.Name.Length >= 4 && c.Name.Substring(0, 4).ToLower() == "txtw")
                    {
                        (c as TextBox).ReadOnly = false;
                        c.BackColor = SystemColors.ControlLightLight;
                    }
                    if (c.Name.Length >= 5 && c.Name.Substring(0, 5).ToLower() == "txtsw")
                    {
                        (c as TextBox).ReadOnly = false;
                        c.BackColor = SystemColors.Info;
                    }
                }
            } 
            #endregion
        }

        /// <summary>
        /// 只读模式时表头TextBox状态
        /// </summary>
        /// <param name="ctrl"></param>
        public static void SetReadMode(Control ctrl)
        {
            #region 只读模式时表头控件状态
            foreach (Control c in ctrl.Controls)
            {
                if (c is TextBox)
                {
                    (c as TextBox).DataBindings.Clear();
                    (c as TextBox).Clear();
                    (c as TextBox).ReadOnly = true;
                    c.BackColor = SystemColors.ControlLightLight;
                }
            }     
            #endregion
        }


        //根据金额计算价格
        public static void CalcPrice(
            DataView view, string sumLength, string piecePrice, string meterPrice, string qty, string taxPrice, 
            string sumMoneyTax, string price, string sumMoney, string taxRate, string sumTax )
        {
            foreach (DataRowView row in view)
            {
                decimal quantity = 0, sLength;
                int inum = 0;

                if (row["iNum"].ToString().Trim() != "")
                {
                    #region 根据支数,支重计算重量
                    inum = Convert.ToInt32(row["iNum"]);

                    if (row["iQty"].ToString().Trim() != "")
                    {
                        quantity = inum * Convert.ToDecimal(row["iQty"]);
                        row[qty] = quantity;
                    }

                    else
                    {
                        quantity = Convert.ToDecimal(row[qty]);
                    }
                    #endregion
                }
                if ((row[piecePrice].ToString() != "" || row[meterPrice].ToString() != "") && inum != 0)
                {
                    #region 支价,米价计算重量单价,金额

                    decimal iTaxRate = Convert.ToDecimal(row[taxRate]);

                    //支价 计算金额
                    if (!string.IsNullOrEmpty(row[piecePrice].ToString()))
                    {
                        row[sumMoneyTax] = Convert.ToDecimal(row[piecePrice]) * inum;
                        row[meterPrice] = DBNull.Value;
                    }
                    //米价 计算金额
                    else if (row[meterPrice].ToString() != "" && row[sumLength].ToString() != "")
                    {
                        sLength = Convert.ToDecimal(row[sumLength]);
                        row[sumMoneyTax] = Convert.ToDecimal(row[meterPrice]) * sLength;
                        row[piecePrice] = DBNull.Value;
                    }
                    else
                    {
                        row[price] = row[sumMoney] = row[sumTax] = row[sumMoneyTax] = DBNull.Value;
                        return;
                    }

                    if (quantity != 0 && row[sumMoneyTax].ToString() != "")
                    {
                        //计算含税单价
                        row[taxPrice] = Math.Round(Convert.ToDecimal(row[sumMoneyTax]) / quantity, 3);
                        //计算无税单价
                        row[price] = Math.Round(Convert.ToDecimal(row[taxPrice]) / (1 + iTaxRate / 100), 3);
                        //计算无税金额
                        row[sumMoney] = Math.Round(Convert.ToDecimal(row[price]) * quantity, 2);
                        //计算税额
                        row[sumTax] = Math.Round(Convert.ToDecimal(row[sumMoneyTax]) - Convert.ToDecimal(row[sumMoney]), 3);
                    }
                    #endregion
                }
                else if (row[qty].ToString() != "" && row[taxPrice].ToString() != "")
                {
                    #region 重量单价计算金额等
                    decimal decTaxRate = 0;
                    decimal decPrice = 0, decTaxPrice = 0, decSumMoney = 0, decSumTax = 0, decSumMoneyTax = 0;
                    decimal decQuantity = 0;

                    if (row[taxRate].ToString() != "")
                        decTaxRate = Math.Round(Convert.ToDecimal(row[taxRate]), 2);

                    decQuantity = Math.Round(Convert.ToDecimal(row[qty]), DataScale.CurrentDataScale.CHSL);

                    decTaxPrice = Math.Round(Convert.ToDecimal(row[taxPrice]), DataScale.CurrentDataScale.CHSL);
                    decPrice = Math.Round(Convert.ToDecimal(row[taxPrice]) / (1 + decTaxRate / 100), DataScale.CurrentDataScale.CHSL);
                    decSumMoney = Math.Round(decPrice * decQuantity, DataScale.CurrentDataScale.JE);
                    decSumMoneyTax = Math.Round(decTaxPrice * decQuantity, DataScale.CurrentDataScale.JE);
                    decSumTax = decSumMoneyTax - decSumMoney;

                    row[price] = decPrice;
                    row[taxPrice] = decTaxPrice;
                    row[sumMoney] = decSumMoney;
                    row[sumTax] = decSumTax;
                    row[sumMoneyTax] = decSumMoneyTax; 
                    #endregion
                }
                else
                {
                    row[price] = row[sumMoney] = row[sumTax] = row[sumMoneyTax] = DBNull.Value;
                } 
            }
        }

        //销售发票勾稽有米价,支价时金额计算
        public static void CalcSumMoneyTax(DataRowView row, string sumLength, string meterPrice,
            string inum, string piecePrice, string qty, string taxPrice, string sumMoneyTax)
        {
                decimal quantity = Convert.ToDecimal(row[qty]);

                if (row[piecePrice].ToString() != "" || row[meterPrice].ToString() != "")
                {
                    #region 计算米价,支价金额
                    if (row[piecePrice].ToString() != "" && row[inum].ToString() != "")
                    {
                        row[sumMoneyTax] = Convert.ToDecimal(row[piecePrice]) * Convert.ToDecimal(row[inum]);
                        row[meterPrice] = DBNull.Value;
                    }
                    else if (row[meterPrice].ToString() != "" && row[sumLength].ToString() != "")
                    {
                        row[sumMoneyTax] = Convert.ToDecimal(row[meterPrice]) * Convert.ToDecimal(row[sumLength]);
                        row[piecePrice] = DBNull.Value;
                    }
                    else if (quantity != 0 && row[sumMoneyTax].ToString() != "")
                    {
                        row[taxPrice] = Math.Round(Convert.ToDecimal(row[sumMoneyTax]) / quantity, 3);
                    } 
                    #endregion
                }
                else if (row[qty].ToString() != "" && row[taxPrice].ToString() != "")
                {
                    #region 重量单价计算金额

                    decimal decTaxPrice = 0, decQuantity = 0;
                    decQuantity = Math.Round(Convert.ToDecimal(row[qty]), DataScale.CurrentDataScale.CHSL);
                    decTaxPrice = Math.Round(Convert.ToDecimal(row[taxPrice]), DataScale.CurrentDataScale.CHSL);
                    row[sumMoneyTax] = Math.Round(decTaxPrice * decQuantity, DataScale.CurrentDataScale.JE);
                    
                    #endregion
                }
        }

        public static string ReadText(string FileName)
        {
            #region 读取txt文件
            string str = null;
            FileStream fs = new FileStream(FileName, FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("GB2312"));
            str = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            return str;
            #endregion
        }
    }


}
