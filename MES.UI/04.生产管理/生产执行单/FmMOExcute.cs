using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Windows.Forms;

namespace LanyunMES.UI
{
    using DevComponents.DotNetBar;
    using Model;
    using Model.U8;
    using DAL;
    using DAL.U8;
    using U8Ext.Ref;

    public partial class FmMOExcute : DevComponents.DotNetBar.OfficeForm
    {
        public FmMOExcute()
        {
            InitializeComponent();

            this.Load += FmLoad;
            this.Text = lbl_title.Text;

            if (FmMain.ActivePageDelegate(this.Name))
            {
                this.Close();
                return;
            }

            FmMOExcuteQ frm = new FmMOExcuteQ();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                this.equipmentId = frm.EQId;
                this.operationId = frm.OperationId;

                //赋值委托关闭标签
                CloseCtrlTab = this.CloseTab;

                FmMain.NewPageDelegate(this);
                
            }
            else
            {
                this.Close();
            }
            
        }

        public delegate void CloseTabDelegate(string tabName);

        public static CloseTabDelegate CloseCtrlTab;

        private int equipmentId = 0, operationId = 0;

        private void FmLoad(object sender, EventArgs e)
        {
            if(equipmentId != 0)
            {
                var eq = new EquipmentDAL().Get(equipmentId);
                this.lbl_Equipment.Text = eq.cEQName;
            }
            
            var op = new U8OperationDAL().Get(operationId);        
            this.lbl_OpName.Text = op.Description;

            this.OpenCard();
        }

        private void OpenCard()
        {
            #region 打开已已开工,未完工卡

            List<string> wheres = new List<string>()
            {
                "operationId = " + operationId,
                "isnull(bComplete,0) = 0",
                "isnull(bClosed,0) = 0",
                 "(iStatus > 0 and iStatus < 5 or MotypeId in (select MotypeId from motypecontrol where bOrderOff = 1)) "
            };

            if (equipmentId != 0)
                wheres.Add("EQId = " + equipmentId);
 

            var ls = new MCardDAL().GetCardDetails(wheres.ToArray());

            ls.ForEach(x =>
            {
                MCardControl control = new MCardControl(x.CardNo, equipmentId);
                control.CloseParentTab = CloseTab;

                var tab = NewPage(control);

                control.Settime = new MCardControl.SetTimeDelegate(
                     new Action<decimal>(seconds =>
                     {
                         if (seconds < 0)
                         {
                             tab.PredefinedColor = eTabItemColor.Red;
                             tab.Text = x.CardNo + " [超时]";
                             return;
                         }

                         var min = Math.Floor(seconds / 60);
                         var hours = Math.Floor(min / 60);
                         var leftSec = seconds % 60;
                         var str = " [" + hours.ToString() + "小时 " + min.ToString() + "分" + leftSec.ToString() + "秒]";

                         tab.Text = x.CardNo + str;
                     })
                );
            }); 
            #endregion
        }

        private void CloseAllCard()
        {
            foreach (SuperTabItem tab in tabControl.Tabs)
            {
                tab.Close();
            }
        }

        

        private SuperTabItem NewPage(Control ctrl)
        {
            #region 新建标签 SuperTabItem

            //foreach (SuperTabItem item in tabControl.Tabs)
            //{
            //    if (item.Tag != null && item.Tag.ToString() == ctrl.Name)
            //    {
                    
            //        tabControl.SelectedTab = item;
            //        return item;
            //    }
            //}

            SuperTabItem tab = this.tabControl.CreateTab(ctrl.Text);
            tab.Tag = ctrl.Name;
            ctrl.Parent = tab.AttachedControl;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Show();
            return tab;

            #endregion
        }

        private void CloseTab(string tabName)
        {
            foreach (SuperTabItem tab in tabControl.Tabs)
            {
               if(tab.Tag.ToString() == tabName)
                {
                    tab.Close();
                    break;
                }
            }
        }

        //定位流转卡
        private void txt_cardNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                foreach (SuperTabItem tab in tabControl.Tabs)
                {
                    if (tab.Tag.ToString() == (sender as TextBox).Text.Trim())
                    {
                        tabControl.SelectedTab = tab;
                        break;
                    }
                }
            }
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            FmMOExcuteQ frm = new FmMOExcuteQ();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.equipmentId = frm.EQId;
                this.operationId = frm.OperationId;

                this.FmLoad(null, null);
            }
        }

        private void BtnSelectCard_Click(object sender, EventArgs e)
        {
            #region 创建流转卡标签
            if (equipmentId == 0) throw new Exception("请先选择设备!");
            if (operationId == 0) throw new Exception("请先选择工序!");

            FmMOExcuteCard frm = new FmMOExcuteCard(equipmentId, operationId);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                
                foreach (string cardNo in frm.cardList)
                {
                    bool bExist = false;
                    foreach (SuperTabItem item in tabControl.Tabs)
                    {
                        if (item.Tag != null && item.Tag.ToString() == cardNo)
                        {
                            bExist = true;
                            break;
                        }
                    }

                    if (bExist) continue;
     
                    MCardControl control = new MCardControl(cardNo, equipmentId);
                    control.CloseParentTab = CloseTab;

                    var tab = NewPage(control);

                    control.Settime = new MCardControl.SetTimeDelegate(
                         new Action<decimal>(seconds =>
                         {
                             if (seconds < 0)
                             {
                                 tab.PredefinedColor = eTabItemColor.Red;
                                 tab.Text = cardNo + " [超时]";
                                 return;
                             }

                             var min = Math.Floor(seconds / 60);
                             var hours = Math.Floor(min / 60);
                             var leftSec = seconds % 60;
                             var str = " [" + hours.ToString() + "小时 " + min.ToString() + "分" + leftSec.ToString() + "秒]";

                             tab.Text = cardNo + str;
                         })
                    );
                }
            } 
            #endregion
        }


    }
}
