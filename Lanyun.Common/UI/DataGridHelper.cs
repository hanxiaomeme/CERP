using System;
using System.Data;
using System.Windows.Forms;

namespace Lanyun.Common
{
    public class DataGridHelper
    {
        public static DataGridViewTextBoxColumn AddTextBoxColumn(DataGridView grid, string filedName, string HeadText, int width = 90)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name = filedName;
            col.DataPropertyName = filedName;            
            col.HeaderText = HeadText;
            col.FillWeight = width;
            col.Width = width;
            grid.Columns.Add(col);
            return col;
        }

        public static DataGridViewCheckBoxColumn AddCheckBoxColumn(DataGridView grid, string filedName, string HeadText, int width = 60)
        {
            DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            col.Name = filedName;
            col.DataPropertyName = filedName;
            col.HeaderText = HeadText;
            col.FillWeight = width;
            col.Width = width;
            grid.Columns.Add(col);
            return col;
        }

        /// <summary>
        /// 移动DataTable行
        /// </summary>
        public static void MoveRow(DataGridView grid, MoveState mState)
        {
            int movePos = 0;
            if(grid.CurrentRow.Index == 0)
            {
                if(mState == MoveState.first || mState == MoveState.previous)
                {
                    throw new Exception("已经是第一行!");
                }
            }
            else if(grid.CurrentRow.Index == grid.Rows.Count - 1)
            {
                if (mState == MoveState.last || mState == MoveState.next)
                {
                    throw new Exception("已经是最后行!");
                }
            }

            switch (mState)
            {
                case MoveState.previous:
                    movePos = grid.CurrentRow.Index - 1;
                    break;
                case MoveState.next:
                    movePos = grid.CurrentRow.Index + 2;
                    break;
                case MoveState.first:
                    movePos = 0;
                    break;
                case MoveState.last:
                    movePos = grid.Rows.Count - 1;
                    break;
                default:
                    break;
            }

            var row = (grid.CurrentRow.DataBoundItem as DataRowView).Row;

            var dt = (grid.DataSource as DataView).Table;

            var newRow = dt.NewRow();

            newRow.ItemArray = row.ItemArray;

            dt.Rows.InsertAt(newRow, movePos);

            dt.Rows.Remove(row);
        }
        
    }

    public enum MoveState { previous, next, first, last }
}
