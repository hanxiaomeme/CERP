using System;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.AdvTree;

namespace LanyunMES.UI
{
    using Entity;
    using Business;
    using Common;
    using Component;
    using System.Reflection;
 

    public partial class FmMain : Office2007Form
    {
        #region 定义的变量

        private string HelpString = "";

        //企业名称
        public string EnName
        {
            get { return this._strEnName; }
            set
            {
                //this.lblEnName.Text = lblEnName.Text.Replace("管理系统", value);
                //this.statusBarPanel2.Text = this._strEnName = "企业:" + value; 
            }
        }
        private string _strEnName = "";


        //定义newPage 委托类型
        public static Action<Form> NewPageDelegate;
        public static Func<string,bool> ActivePageDelegate;

        #endregion

        public FmMain()
        {
            InitializeComponent();
 
            this.InitUI();
            this.RegEvent();

            NewPageDelegate = this.NewPage;
            ActivePageDelegate = this.ActivePage;
        }

        private void RegEvent()
        {
            //设置皮肤
            this.Load += LoadSkinMenu;
            //设置fastreport语言
            this.Load += SetReportLang;
           
        }

        UserService userService = new UserService();

        private void InitUI()
        {
            #region 成功登录后处理

            InitTreeMenu();                                                 //初始化树菜单
            InitStatusBar();                                                //初始化状态栏
            
            //this.EnName = Information.UserInfo.cUnitName;                   //获取用户企业信息
             
            #endregion
        }

        private void InitTreeMenu()
        {
            #region 加载Tree菜单

            MenuService menuService = new MenuService();
    
            var menuList = menuService.GetList(Information.UserInfo.UserName);

            TreeHelper.LoadAdvTree(TreeMenu, menuList, LoadModule, false);

            //this.RootNode.ExpandAll();
  
            #endregion
        }

        private void InitStatusBar()
        {
            #region 初始化状态栏
            this.statusBarPanel1.Text = "就绪";
            //this.statusBarPanel3.Text = "用户:" + Information.UserInfo.cUser_Name;
            this.statusBarPanel4.Text = "业务日期:" + Information.BusiDate.ToShortDateString();
            this.statusBarPanel5.Text = DateTime.Now.ToString("HH:mm:ss");
            #endregion
        }

        //===============================================
        private void NewPage(Form frm, string tag)
        {
            #region 新建标签 SuperTabItem

            if (ActivePage(tag))
            {
                return;
            }

            SuperTabItem tab = this.TabCtlMain.CreateTab(frm.Text);
            TabCtlMain.SelectedTab = tab; 
            tab.Tag = tag;
            frm.TopLevel = false;
            frm.FormClosed += new FormClosedEventHandler(FmModule_Closed);     //Form关闭时关闭父标签
            frm.Parent = tab.AttachedControl;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();

            #endregion
        }

        private void NewPage(Form frm)
        {
            #region 新建标签 SuperTabItem

            if(ActivePage(frm.Name))
            {
                return;
            }

            SuperTabItem tab = this.TabCtlMain.CreateTab(frm.Text);
            TabCtlMain.SelectedTab = tab;
            tab.Tag = frm.Name;
            frm.TopLevel = false;
            frm.FormClosed += new FormClosedEventHandler(FmModule_Closed);     //Form关闭时关闭父标签
            frm.Parent = tab.AttachedControl;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();

            #endregion
        }

        private bool ActivePage(string tag)
        {
            #region 如果标签已打开,激活标签

            foreach (SuperTabItem tab in TabCtlMain.Tabs)
            {
                if (tab.Tag != null && tab.Tag.ToString() == tag)
                {
                    TabCtlMain.SelectedTab = tab;
                    return true;
                }
            }
            return false;

            #endregion
        }

        private void OnTabClose(SuperTabItem tab)
        {
            #region 关闭便签调用事件
            foreach (Form frm in tab.AttachedControl.Controls)
            {
                frm.Close();
                break;
            }
            #endregion
        }
        //================================================


        private void FmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            #region 主窗口关闭中
            if (MsgBox.ShowYesNoMsg2("确定要退出系统吗？", "退出系统") == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
            #endregion
        }


        private void FmModule_Closed(object sender, EventArgs e)
        {
            #region  模块窗体关闭调用事件,关闭标签

            Form frm = (Form)sender;
            if (frm.Parent != null)
            {
                Control ctrl = frm.Parent;

                foreach (SuperTabItem tab in TabCtlMain.Tabs)
                {
                    if (tab.AttachedControl == ctrl)
                    {
                        tab.Close(); break;
                    }
                }
                
            }
            #endregion
        }

        //LoadModule --> 
        private void LoadModule(object sender, System.EventArgs e)
        {
            #region 获取模块对象

            var node = (Node)sender;
            var menu = node.Tag as Menu;

            if (!this.ActivePage(menu.FNumber))
            {
                if (!userService.HaveMenuAuth(Information.UserInfo.UserID, menu.FItemID))
                {
                    MsgBox.ShowInfoMsg("权限不足，请联系管理员");
                    return;
                }

                this.CreateForm(menu);
            }

            #endregion
        }
 
        /// <summary>
        /// 加载菜单窗体
        /// </summary>
        /// <param name="menu">菜单对象</param>
        private void CreateForm(Menu menu)
        {         
            var ass = Assembly.LoadFrom(menu.FileName);

            Type t = ass.GetType(menu.ClassName);

            Form fm =  Activator.CreateInstance(t) as Form;

            if(menu.ShowStyle == 0)
            {
                NewPage(fm, menu.FNumber);
            }
        }

        private void tmrCurDateTime_Tick(object sender, System.EventArgs e)
        {
            #region 显示时间

            this.statusBarPanel5.Text = DateTime.Now.ToString("HH:mm:ss");

            #endregion
        }
 

        #region 系统菜单
    
        private void mnuItmMdyPwd_Click(object sender, EventArgs e)
        {
            #region 修改密码
            (new FmMdyPwd()).ShowDialog(this);
            #endregion
        }

        private void mnuItmExit_Click(object sender, System.EventArgs e)
        {
            #region 退出系统
            Close();
            #endregion
        }

        #endregion

        #region 帮助菜单
        //帮助菜单###############################################################################################################################################

        private void mnuItmHelpContent_Click(object sender, EventArgs e)
        {
            //HelpNavigator nav = HelpNavigator.KeywordIndex;

            //Help.ShowHelp(this, "./help/帮助文档.chm", nav, this.HelpString);
        }

        private void mnuItmAbout_Click(object sender, System.EventArgs e)
        {
            (new FmAbout()).ShowDialog(this);
        }

        #endregion


        //================载入皮肤===============================

        #region  系统主题皮肤设置

        private void LoadSkinMenu(object sender, System.EventArgs e)
        {
            #region 载入skin菜单和skin设置

            string[] styles = Enum.GetNames(typeof(eStyle));
            foreach (string sname in styles)
            {
                ButtonItem item = new ButtonItem(sname, sname);
                this.MenuSkin.SubItems.Add(item);
                item.Click += new EventHandler(new Action<object, EventArgs>((x,y)=>
                {
                    ButtonItem btn = x as ButtonItem;
                    this.styleManager1.ManagerStyle = (eStyle)Enum.Parse(typeof(eStyle), btn.Name);
                    this.MenuBar.Refresh();
                    XMLHelper.SetInnerText("./config.xml", "MESConfig/skin/style", item.Name);
                }));
            }
           
            this.LoadSkinCfg();

            #endregion
        }

        private void LoadSkinCfg()
        {
            #region 加载皮肤设置
            if (File.Exists("./config.xml"))
            {
                string value = XMLHelper.GetInnerText("./config.xml", "MESConfig/skin/style");
                this.styleManager1.ManagerStyle = (eStyle)Enum.Parse(typeof(eStyle), value);
            } 
            #endregion
        }

        #endregion

        #region  加载FastReport语言包

        private void SetReportLang(object sender, System.EventArgs e)
        {
            FastReport.Utils.Res.LocaleFolder = Application.StartupPath;
            FastReport.Utils.Res.LoadLocale(@"./Localization/Chinese (Simplified).frl");
        }

        #endregion

 
        private void cb_showMenu_CheckedChanged(object sender, CheckBoxChangeEventArgs e)
        {
            this.splitContainer1.Panel1Collapsed = !cb_showMenu.Checked;
        }
 
    }

}