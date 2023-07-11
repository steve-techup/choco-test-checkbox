using System;
using System.Collections.Generic;
using System.IO;
using Caretag_Class.Repositories;
using MiniExcelLibs;

namespace Main.Services
{
    public class ExcelExportService
    {   
        public void ExportPacklistToExcel(string filename, List<PackingListRow> packingList, string packingListName, bool overwriteFile)
        {
            ExportToExcel(filename, packingListName, packingList, overwriteFile);
        }

        // Export table to excel file
        public void ExportToExcel<T>(string fileName, string sheetName, List<T> rows, bool overwriteFile)
        {
            try
            {
                var sheet = rows.ToArray();
                var sheets = new Dictionary<string, object>
                {
                    [sheetName] = sheet,
                };
                
                MiniExcel.SaveAs(fileName, sheets, overwriteFile: overwriteFile);
            }
            catch (Exception e)
            {
                
            }
        }
    }
}
