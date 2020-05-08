using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lanyun.Common
{
	public class UIControlHelper
	{
        /// <summary>
        /// 设置TextBox为只读状态
        /// </summary>
        public static void TextBox_ReadOnly(TextBox textBox)
        {
            textBox.ReadOnly = true;
            textBox.BackColor = SystemColors.Control; 
        }

        /// <summary>
        /// 设置TextBox内容日期格式化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		public static void TextBox_DateFormat(object sender, EventArgs e)
		{
            TextBox t = (sender as TextBox);
            if (t.Text.Trim() != "")
                t.Text = DateTime.Parse(t.Text.Trim()).ToShortDateString(); 
        }

        /// <summary>
        /// 限制TextBox只能输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">KeyPressEventArgs</param>
		public static void TextBox_NumOnly(object sender, KeyPressEventArgs e)
		{
            if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            } 
        }

        /// <summary>
        /// 清除TextBox Text和Tag内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void Textbox_ClearTextAndTag(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                (sender as TextBox).Clear();
                (sender as TextBox).Tag = null;
            } 
        }


        public static void SetShowStyle(Form form, int nStyle)
        {
            switch (nStyle)
            {
                case 1:
                    {
                        form.FormBorderStyle = FormBorderStyle.FixedSingle;
                        form.MaximizeBox = false;
                        form.MinimizeBox = false;
                        form.ShowInTaskbar = false;
                        form.StartPosition = FormStartPosition.CenterScreen;

                        break;
                    }
                case 2:
                    {
                        form.ShowInTaskbar = false;
                        form.MinimizeBox = false;
                        form.WindowState = FormWindowState.Maximized;
                        form.StartPosition = FormStartPosition.CenterScreen;

                        break;
                    }
                case 3:
                    {
                        form.FormBorderStyle = FormBorderStyle.FixedDialog;
                        form.MaximizeBox = false;
                        form.MinimizeBox = false;
                        form.ShowInTaskbar = false;
                        form.StartPosition = FormStartPosition.CenterScreen;

                        break;
                    }
                default:
                    break;
            }
        }


        /// <summary>
        /// TextBox后添加按钮
        /// </summary>
        /// <param name="textbox"></param>
        public static void ShowRefButton(TextBox textbox, EventHandler buttonClick)
        {
            Button button = new Button();
            button.Height = textbox.Height;
            button.Width = textbox.Height - 5;
            button.Visible = false;
            button.Text = "|";
            button.Parent = textbox;
            button.FlatStyle = FlatStyle.Flat;
            button.Dock = DockStyle.Right;

            button.Click += buttonClick;

            textbox.Enter += new EventHandler((sender, e) =>
            {
                button.Visible = true;
            });
            textbox.Leave += new EventHandler((sender, e) =>
            {
                button.Visible = false;
            });
        }

    }
}