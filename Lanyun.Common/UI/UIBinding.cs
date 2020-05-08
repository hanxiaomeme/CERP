using System.Windows.Forms;

namespace Lanyun.Common
{
    /// <summary>
    /// WinForm控件绑定实体类熟悉
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public class UIBinding<T>   
    {
        /// <summary>
        /// 控件数据绑定, 根据控件Tag内容绑定Model字段
        /// </summary>
        public static void UIDataBinding(Control control, T model)
        {
            foreach (Control ctrl in control.Controls)
            {
                if (ctrl is Panel)
                {
                    UIDataBinding(ctrl, model);
                    continue;
                }

                if (ctrl.Tag == null || ctrl.Tag.ToString() == "")
                {
                    continue;
                }
                else 
                {
                    bool bExists = false;
                    foreach(var p in model.GetType().GetProperties())
                    {
                        if(p.Name == ctrl.Tag.ToString())
                        {
                            bExists = true;
                            break;
                        }
                    }
                    if (!bExists)
                    {
                        MessageBox.Show("组件 " + ctrl.Name + " 绑定的属性 " + ctrl.Tag.ToString() + " 不存在！");
                        return;
                    }
                }

                if (ctrl is TextBox)
                {
                    TextBox t = ctrl as TextBox;
                    t.DataBindings.Clear();
                    t.DataBindings.Add("Text", model, t.Tag.ToString(), true, DataSourceUpdateMode.OnPropertyChanged);
                }
                else if (ctrl is Label)
                {
                    Label t = ctrl as Label;
                    t.DataBindings.Clear();
                    t.DataBindings.Add("Text", model, t.Tag.ToString(), true, DataSourceUpdateMode.OnPropertyChanged);
                }
                else if (ctrl is CheckBox)
                {
                    CheckBox box = ctrl as CheckBox;
                    string fieldName = box.Tag.ToString();
                    box.DataBindings.Clear();
                    box.DataBindings.Add("Checked", model, fieldName, false, DataSourceUpdateMode.OnPropertyChanged);
                }
                else if (ctrl is NumericUpDown)
                {
                    var num = ctrl as NumericUpDown;
                    string fieldName = num.Tag.ToString();
                    num.DataBindings.Clear();
                    num.DataBindings.Add("value", model, fieldName, false, DataSourceUpdateMode.OnPropertyChanged);
                }
                else if (ctrl is DateTimePicker)
                {
                    var dp = ctrl as DateTimePicker;
                    string fieldName = dp.Tag.ToString();
                    dp.DataBindings.Clear();
                    dp.DataBindings.Add("value", model, fieldName, false, DataSourceUpdateMode.OnPropertyChanged);
                }
                else
                {
                    foreach(var p in ctrl.GetType().GetProperties())
                    {
                        if(p.Name == "Text")
                        {
                            string fieldName = ctrl.Tag.ToString();
                            ctrl.DataBindings.Clear();
                            ctrl.DataBindings.Add("Text", model, fieldName, false, DataSourceUpdateMode.OnPropertyChanged);
                            break;
                        }             
                    }
                }
            }
        }

        public static void UIDataBinding(Control ctrl, string fieldName, T model)
        {
            if (ctrl is TextBox)
            {
                TextBox t = ctrl as TextBox;
                t.DataBindings.Clear();
                t.DataBindings.Add("Text", model, fieldName, true, DataSourceUpdateMode.OnPropertyChanged);
            }
            else if (ctrl is Label)
            {
                Label t = ctrl as Label;
                t.DataBindings.Clear();
                t.DataBindings.Add("Text", model, fieldName, true, DataSourceUpdateMode.OnPropertyChanged);
            }
            else if (ctrl is CheckBox)
            {
                CheckBox box = ctrl as CheckBox;
                box.DataBindings.Clear();
                box.DataBindings.Add("Checked", model, fieldName, false, DataSourceUpdateMode.OnPropertyChanged);
            }
            else if (ctrl is NumericUpDown)
            {
                var num = ctrl as NumericUpDown;
                num.DataBindings.Clear();
                num.DataBindings.Add("value", model, fieldName, false, DataSourceUpdateMode.OnPropertyChanged);
            }
            else if (ctrl is DateTimePicker)
            {
                var dp = ctrl as DateTimePicker;
                dp.DataBindings.Clear();
                dp.DataBindings.Add("value", model, fieldName, false, DataSourceUpdateMode.OnPropertyChanged);
            }
        }

    }
}
