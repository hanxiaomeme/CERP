using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LanyunMES.UIBase
{
    using LanyunMES.Entity;
    using UIBusiness;

    public interface ITreeGrid
    {
        BusinessInfo busiInfo { get; }
        GradeInfo gradeInfo { get; }

        //DataView GetTreeData();
        //DataView GetGridData(string str, bool isLinkFiled);
    }

    public class TTreeGrid: ITreeGrid
    {
        public TTreeGrid(string moduleName)
        {
            //BusinessInfoDAL dal = new BusinessInfoDAL();
            //busiInfo = dal.GetModel(moduleName);

            //GradeInfoDAL gDAL = new GradeInfoDAL();
            //gradeInfo = gDAL.GetModel(moduleName);
        }

        public BusinessInfo busiInfo { get; set; }
        public GradeInfo gradeInfo { get; set; }


        //public virtual DataView GetTreeData()
        //{
            //string sql = "select * from " + busiInfo.MView + " order by " + busiInfo.MTLnk;
            //DataView dv = DbHelperSQL.Query(sql).Tables[0].DefaultView;
            //return dv;
        //}

        //public virtual DataView GetGridData(string str, bool isLinkFiled)
        //{
            //if (isLinkFiled)
            //{
            //    string sql = "select * from " + busiInfo.DView + " where " + busiInfo.MTLnk + " like @mTLnkValue + '%'";
            //    SqlParameter param = new SqlParameter("mTLnkValue", str);
            //    return DbHelperSQL.Query(sql, param).Tables[0].DefaultView;
            //}
            //else
            //{
            //    string sql = "select * from " + busiInfo.DView + " where " + str;
            //    return DbHelperSQL.Query(sql).Tables[0].DefaultView;
            //}
        //}
    }
}
