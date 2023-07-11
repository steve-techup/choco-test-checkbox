using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminStation.ViewModels.ReactiveUI
{
    public static class Common
    {
        public static string? ShowExcelSaveDialog()
        {
            FileDialog dialog = new SaveFileDialog();
            dialog.AddExtension = true;
            dialog.DefaultExt = ".xlsx";
            dialog.Filter = "Excel Files|*.xlsx";
            dialog.Title = "Select Excel File";

            var result = dialog.ShowDialog();
            return result == DialogResult.OK ? dialog.FileName : null;
        }

        public static void ShowSuccessDialog()
        {
            MessageBox.Show("Export successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
