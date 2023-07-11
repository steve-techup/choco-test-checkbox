using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace Main.Extensions
{
    public static class DevExpressExtensions
    {
        public static void RemoveForeignKeyDuplicateColumns(this GridView gridView)
        {
            if (gridView == null) return;
            var foreignKeyColumns = gridView.Columns
                .Where(c => c.FieldName.EndsWith("!Key") &&
                            (c.ColumnType == typeof(int) || c.ColumnType == typeof(long)) && c.Visible).ToList();

            foreach (var column in foreignKeyColumns)
            {
                gridView.Columns.Remove(column);
            }

        }
    }
}
