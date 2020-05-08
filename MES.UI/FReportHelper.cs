using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

namespace LanyunMES.UI
{
    using Component;

    public class FReportHelper 
    {
        private static FastReport.Report rep = new FastReport.Report();

        public static FastReport.Report GetReport(string filePath, DataSet ds)
        {
            rep.RegisterData(ds, "data");

            if (File.Exists(filePath))
            {
                rep.Load(filePath);
            }
            else
            {
                MsgBox.ShowInfoMsg("找不到文件: \r\n" +  filePath);
            }

            return rep;
        }

        public static FastReport.Report GetReport(string filePath, DataTable dtM, DataTable dtD)
        {
            rep.RegisterData(dtM, "M");
            rep.RegisterData(dtD, "D");

            if (File.Exists(filePath))
            {
                rep.Load(filePath);
            }
            else
            {
                MsgBox.ShowInfoMsg("找不到文件: \r\n" + filePath);
            }

            return rep;
        }


    }

    public class FReportHelper<T> where T : class, new()
    {
        private static FastReport.Report rep = new FastReport.Report();
        public static FastReport.Report GetReport(string filePath, List<T> list, DataTable dtD)
        {
            rep.RegisterData(list, "M");
            rep.RegisterData(dtD, "D");

            if (File.Exists(filePath))
            {
                rep.Load(filePath);
            }
            else
            {
                MsgBox.ShowInfoMsg("找不到文件: \r\n" + filePath);
            }

            return rep;
        }
    }
}
