using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Text;
using System.Windows.Forms;

namespace LanyunMES.UI
{
    using Model;
    using DAL;
    using U8Ext.Ref;
    using DevComponents.AdvTree;

    public partial class FmRClassInfo : DevComponents.DotNetBar.OfficeForm
    {
        public FmRClassInfo(ITreeClassDAL iDAL, string title) 
        {
            InitializeComponent();
            this.dal = iDAL;
            this.Text = rootNode.Text = lblModuleTitle.Text = title;
            this.Load += FormLoad;
            this.btn_Return.Click += ReturnModelC;
            this.TreeM.NodeDoubleClick += ReturnModelC;
        }

        public ITreeModel Result { get; private set; }
        private ITreeClassDAL dal;

        private void FormLoad(object sender, EventArgs e)
        {
            #region 加载主窗体事件

            var list = dal.GetList();

            TreeHelper.LoadAdvTree(TreeM, list, null);

            #endregion
        }

        private void ReturnModelC(object sender, EventArgs e)
        {
            var node = TreeM.SelectedNode;
            Result = node.Tag as ITreeModel;
            this.DialogResult = DialogResult.OK;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            #region 退出模块

            this.Close();

            #endregion
        }
    }
}