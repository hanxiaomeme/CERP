using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LanyunMES.UI
{
    using UIBase;
    using Model;
    using DAL;
    using DAL.U8;
    using DevExpress.XtraGrid.Columns;
    using System.Data.SqlClient;
    using Component;
    using DevExpressUtility;

    public partial class FmMomList : DevComponents.DotNetBar.OfficeForm
    {
        public FmMomList()
        {
            InitializeComponent();
            this.gridView1.KeyDown += GridViewHelper.KeyDownCellCopy;
            this.gridView2.KeyDown += GridViewHelper.KeyDownCellCopy;
            this.gridView3.KeyDown += GridViewHelper.KeyDownCellCopy;
            this.BtnExpDetail.Click += ExpDetail;
            this.Btn_Query.Click += QueryData;
            this.Btn_Refresh.Click += RefreshData;

            this.btn_EditRouter.Click += RouterSet;
        }


        private DataTable dtM;
        private MomDAL dal = new MomDAL();
        private List<string> _whereList = new List<string>();
        private List<SqlParameter> _paramList = new List<SqlParameter>();

        private void InitGrid()
        {
            #region 初始化列
            GridColumn col = GridViewHelper.AddColumn(this.gridView1, "MoCode", "生产订单号", 90);
            col.Fixed = FixedStyle.Left;
            col.Summary.Add(DevExpress.Data.SummaryItemType.Count);
            col.Summary[0].FieldName = "MoCode";
            col.Summary[0].DisplayFormat = "记录数:{0}";

            GridViewHelper.AddColumn(this.gridView1, "MoTypeName", "生产类别", 90);
            GridViewHelper.AddColumn(this.gridView1, "CreateDate", "日期", 90);
            GridViewHelper.AddColumn(this.gridView1, "BomType", "类型", 50);
            GridViewHelper.AddColumn(this.gridView1, "SortSeq", "行号", 40);
            GridViewHelper.AddColumn(this.gridView1, "cInvCode", "存货编码", 150);
            GridViewHelper.AddColumn(this.gridView1, "cInvName", "存货名称", 120);
            GridViewHelper.AddColumn(this.gridView1, "cInvStd", "规格型号", 120);
            GridViewHelper.AddColumn(this.gridView1, "cComUnitName", "单位", 40);
            //GridViewHelper.AddColumn(this.gridView1, "Free1", "头标", 80);

            col = GridViewHelper.AddColumn(this.gridView1, "Qty", "数量", 90);
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.AppearanceCell.ForeColor = Color.Red;
            col.DisplayFormat.FormatString = "n3";
            var sitem = col.Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            sitem.FieldName = "Qty";
            sitem.DisplayFormat = "{0:n2}";

            GridViewHelper.AddColumn(this.gridView1, "SoCode", "订单号", 90);

            GridViewHelper.AddColumn(this.gridView1, "Remark", "备注", 150); 
            #endregion
        }

        private void FmProductOrder_Load(object sender, EventArgs e)
        {
            this.InitGrid();
        }


        private void QueryData(object sender, EventArgs e)
        {
            #region 查询
            FmQMomList frm = new FmQMomList();
            if (_paramList != null)
            {
                frm.LoadSqlParams(_paramList);
            }
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this._whereList = frm.ListWhere;
                this._paramList = frm.Parameters;
                this.dtM = dal.GetTableList(_whereList, _paramList);
                this.gridControl1.DataSource = dtM;
            } 
            #endregion
        }

        private void RefreshData(object sender, EventArgs e)
        {
            #region 刷新

            if (_whereList != null && _whereList.Count > 0)
            {
                this.dtM = dal.GetTableList(_whereList, _paramList);
                this.gridControl1.DataSource = dtM;
            }

            #endregion
        }

        /// <summary>
        /// 指令单生成
        /// </summary>
        private void ExpDetail(object obj, EventArgs e)
        {
            #region 生成指令单

            if(dtM == null || dtM.Rows.Count < 1)
            {
                throw new Exception("表体没有记录!");
            }

            int modid = Convert.ToInt32(gridView1.GetFocusedRowCellValue("modid"));

            var wodal = new WorkOrderDAL();

            if (wodal.ExistWorkOrder(modid))
            {
                throw new Exception("已经生成指令单!");
            }
            else if(gridView1.GetFocusedRowCellValue("BomId").ToString() == "")
            {
                throw new Exception("生产订单没有选择BOM,请检查!");
            }
            //else if(!wodal.ExistBOM(modid))
            //{
            //    throw new Exception("没有BOM,请检查!");
            //}
            //是否存在工艺路线
            else if(!wodal.ExistPRouting(modid))
            {
                if(MsgBox.ShowYesNoMsg("没有工艺路线,是否加载默认工艺!")== DialogResult.Yes)
                {
                    dal.CreateWorkOrderRouting(modid, "001", Information.UserInfo.cUser_Name);
                }
                //throw new Exception("没用工艺路线,请检查");
            }
            else
            {
                dal.CreateWorkOrder(modid, Information.UserInfo.cUser_Name);
            }

            var dtWorkOrder = wodal.GetWorkOrderList(modid);
            var dtRouter = wodal.GetRouter(modid);
            this.gridControl2.DataSource = dtWorkOrder;
            this.gridControl3.DataSource = dtRouter;


            //匹配指令单材料对应工序
            MatchOperation(modid);

            #region 检查已生成指令单是否有工艺路线
            string msg = "";
            bool bExist = false;
            foreach (DataRow r in dtWorkOrder.Rows)
            {
                foreach (DataRow r2 in dtRouter.Rows)
                {
                    if (r["WOCode"].ToString() == r2["WOCode"].ToString())
                    {
                        bExist = true;
                        break;
                    }

                    bExist = false;
                }

                if (!bExist)
                    msg += r["WOCode"] + "没有工艺路线; \r\n";
                else
                    continue;
            }
            if (msg != "")
            {
                MsgBox.ShowInfoMsg(msg);
            }

            #endregion

            #endregion

            using (var frm = new FmWOList(modid))
            {
                frm.ShowDialog();
            }
        }


        private void RouterSet(object sender, EventArgs e)
        {
            if(gridControl2.DataSource == null || gridView2.RowCount < 1)
            {
                MsgBox.ShowInfoMsg("当前指令单没有记录!");
                return;
            }

            string woGuid = gridView2.GetFocusedRowCellValue("guid").ToString();

            FmWORouter frm = new FmWORouter(woGuid);
            if(frm.ShowDialog() == DialogResult.OK)
            {
                int modid = Convert.ToInt32(gridView1.GetFocusedDataRow()["modid"]);
                this.LoadDetails(modid);
            }
        }

        private void Btn_Print_Click(object sender, EventArgs e)
        {
            #region 打印
            string path = Application.StartupPath.Trim('\\');

            if (System.IO.File.Exists(path + "\\ReportPrint\\派工单.frx"))
            {
                this.report1.Load(path + "\\ReportPrint\\派工单.frx");
            }
            this.report1.RegisterData(dtM, "M");
            this.report1.GetDataSource("M").Enabled = true;
            this.report1.Show(); 
            #endregion
        }

        private void Btn_Desgin_Click(object sender, EventArgs e)
        {
            #region 打印设计
            string path = Application.StartupPath.Trim('\\');

            if (System.IO.File.Exists(path + "\\ReportPrint\\派工单.frx"))
            {
                this.report1.Load(path + "\\ReportPrint\\派工单.frx");
            }
            this.report1.RegisterData(dtM, "M");
            this.report1.GetDataSource("M").Enabled = true;
            this.report1.Design(); 
            #endregion
        }


        private void LoadDetails(int modid)
        {
            var wodal = new WorkOrderDAL();
            this.gridControl2.DataSource = wodal.GetWorkOrderList(modid);
            this.gridControl3.DataSource = wodal.GetRouter(modid);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int modid = Convert.ToInt32(gridView1.GetRowCellValue(e.FocusedRowHandle, "modid"));
            this.LoadDetails(modid);
        }


        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            #region 删除指令单
            if (MsgBox.ShowYesNoMsg("即将删除当前生产订单行对应的所有指令单,是否继续!") != DialogResult.Yes)
            {
                return;
            }

            int modid = Convert.ToInt32(gridView1.GetFocusedDataRow()["modid"]);
            var wodal = new WorkOrderDAL();

            if (wodal.ExistRef(modid))
            {
                throw new Exception("生产订单对应的指令单已经生成流转卡不能删除!");
            }

            if(wodal.Delete(modid))
            {
                this.LoadDetails(modid);
            }
           
            #endregion
        }




        //============================================================

        private void MatchOperation(int modid)
        {
            #region 匹配生产订单行对应指令单子件工艺
            var wodal = new WorkOrderDAL();

            var dtRouter = wodal.GetRouter(modid);
            var dtDetail = wodal.GetDetail(modid);

            foreach (DataRow d in dtDetail.Rows)
            {
                if (string.IsNullOrEmpty(d["operationId"].ToString()))
                {
                    continue;
                }

                var gyArray = dtRouter.Select("operationId = " + d["operationId"] + " and guid = '" + d["guid"] + "'");
                if (gyArray != null && gyArray.Length == 1)
                {
                    d["routerId"] = gyArray[0]["autoid"];

                    var autoid = Convert.ToInt32(d["AutoId"]);
                    var routerid = Convert.ToInt32(d["routerId"]);

                    wodal.UpdateWODRouterId(autoid, routerid);
                }
                else
                {
                    continue;
                }
            }
            #endregion
        }

    }
}
