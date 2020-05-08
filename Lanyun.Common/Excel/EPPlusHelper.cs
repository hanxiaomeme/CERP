using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lanyun.Common
{
    using OfficeOpenXml;
    using System.IO;

    public class EPPlusHelper
    {
        public static void DataGridViewToExcel(DataGridView grid, string filePath)
        {
            using (ExcelPackage pck = new ExcelPackage())
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Sheet1");

                for (int i = 0; i < grid.Columns.Count; i++)
                {
                    ws.Cells[1,i + 1].Value = grid.Columns[i].HeaderText;
                }


                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    for (int j = 0; j < grid.Columns.Count; j++)
                    {
                        var value = grid.Rows[i].Cells[j].Value;
                        if (value != null && value != DBNull.Value)
                        {
                            if (grid.Rows[i].Cells[j].ValueType == typeof(double) ||
                                grid.Rows[i].Cells[j].ValueType == typeof(decimal))
                            {
                                ws.Cells[i + 2,j + 1].Value = Convert.ToDouble(grid.Rows[i].Cells[j].Value);
                            }
                            else
                            {
                                ws.Cells[i + 2, j + 1].Value = grid.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }
                }

                FileStream fileStream = new FileStream(filePath, FileMode.Create);

                pck.SaveAs(fileStream);
            }
        }
    }
}
