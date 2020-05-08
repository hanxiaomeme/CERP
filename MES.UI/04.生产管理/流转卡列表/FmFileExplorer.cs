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
    using DevComponents.Editors;
    using DevComponents.Editors.DateTimeAdv;

    using DAL;
    using Model;
    using Server.Model;
    using Common;
    using Component;
    using System.IO;
    using System.Diagnostics;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpressUtility;

    public partial class FmFileExplorer : DevComponents.DotNetBar.OfficeForm
    {
        public FmFileExplorer(string cardNo)
        {
            InitializeComponent();

            var ctrl = new FileExpControl(cardNo);
            ctrl.Parent = this;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Show();
        }  
    }
}